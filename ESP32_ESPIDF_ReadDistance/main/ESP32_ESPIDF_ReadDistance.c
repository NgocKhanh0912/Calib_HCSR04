// Sinh viên thực hiện: Nguyễn Ngọc Khanh - 2111474 - HCMUT

#include <stdio.h>
#include <string.h>
#include "freertos/FreeRTOS.h"
#include "freertos/task.h"
#include "freertos/queue.h"
#include "driver/gpio.h"
#include "esp_log.h"
#include "driver/uart.h"
#include "esp_timer.h"
#include "esp_system.h"
#include "driver/gpio.h"
#include "stdlib.h"

#define BUF_SIZE (1024)

QueueHandle_t uart_queue;

#define TRIG_PIN GPIO_NUM_13
#define ECHO_PIN GPIO_NUM_12

// Hai biến global lưu giá trị calib được gửi từ GUI xuống
double calib_Zero = 0.0;
double calib_SpeedofSound = 343;

// Dữ liệu nhận được từ giao diện có 2 dạng:

// Dạng 1: "Z...C" trong đó giá trị nằm giữa 'Z' và 'C' là giá trị mà người dùng muốn nhập vào cho biến calib_Zero từ GUI xuống ESP32
// Chữ 'Z' ở đầu chuỗi đại diện cho Zero và chữ C ở cuối chuỗi đại diện cho calib

// Dạng 2: "S...C" trong đó giá trị nằm giữa 'S' và 'C' là giá trị mà người dùng muốn nhập vào cho biến calib_SpeedofSound từ GUI xuống ESP32
// Chữ 'S' ở đầu chuỗi đại diện cho SpeedofSound và chữ C ở cuối chuỗi đại diện cho calib

// Dựa vào chữ cái đầu, vị trí chữ cái đầu và vị trí chữ cái cuối (C) trong chuỗi, ta biết được:
// 1. Biến nào đang được GUI gửi dữ liệu xuống
// 2. Giá trị của biến đó


// Hàm bóc tách chuỗi nhận được từ GUI
void process_uart_data(uint8_t *data, int len) 
{
    // Tìm vị trí của 'Z' hoặc 'S' và 'C'
    int start_pos = -1;
    int end_pos = -1;
    char start_char = '\0';
    for (int i = 0; i < len; i++) 
    {
        // Tìm vị trí đầu chuỗi
        if ((data[i] == 'Z' || data[i] == 'S') && start_pos == -1) 
        {
            start_pos = i;
            start_char = data[i];
        } 

        // Tìm vị trí cuối chuỗi
        else if (data[i] == 'C' && start_pos != -1) 
        {
            end_pos = i;
            break;
        }
    }
    
    // Thực hiện bóc tách để lấy dữ liệu, lưu vào các biến calib
    if (start_pos != -1 && end_pos != -1 && end_pos > start_pos + 1) 
    {
        // Bóc tách, loại bỏ 2 kí tự đầu cuối, giữ lại chuỗi ở giữa là giá trị calib
        int substring_len = end_pos - start_pos - 1;
        char processed_data[substring_len + 1];
        memcpy(processed_data, &data[start_pos + 1], substring_len);
        processed_data[substring_len] = '\0';
        
        // Chuyển chuỗi ở giữa từ kiểu string thành double
        double value = atof(processed_data);

        // Trường hợp kí tự đầu tiên là chữ 'Z', tức là giá trị sẽ là giá trị calib_Zero
        if (start_char == 'Z') 
        {
            calib_Zero = value;
        } 

        // Trường hợp kí tự đầu tiên là chữ 'S', tức là giá trị sẽ là giá trị calib_SpeedofSound
        else if (start_char == 'S') 
        {
            calib_SpeedofSound = value;
        }
    }
}


// Task xử lý khi nhận được dữ liệu từ UART2 từ GUI gửi xuống
void uart_event_task(void *pvParameters) 
{
    uart_event_t event;
    uint8_t *data = (uint8_t *) malloc(BUF_SIZE);
    for (;;) 
    {
        if (xQueueReceive(uart_queue, (void *)&event, (TickType_t)portMAX_DELAY)) 
        {
            memset(data, 0, BUF_SIZE);
            if (event.type == UART_DATA) 
            {
                int len = uart_read_bytes(UART_NUM_2, data, event.size, portMAX_DELAY);
                process_uart_data(data, len);
            }
        }
    }
    free(data);
    vTaskDelete(NULL);
}


// Khởi động UART2
void uart_init(void) 
{
    uart_config_t uart_config = 
    {
        .baud_rate = 9600,
        .data_bits = UART_DATA_8_BITS,
        .parity = UART_PARITY_DISABLE,
        .stop_bits = UART_STOP_BITS_1,
        .flow_ctrl = UART_HW_FLOWCTRL_DISABLE,
        .source_clk = UART_SCLK_APB,
    };

    uart_driver_install(UART_NUM_2, BUF_SIZE * 2, BUF_SIZE * 2, 10, &uart_queue, 0);
    uart_param_config(UART_NUM_2, &uart_config);
    uart_set_pin(UART_NUM_2, GPIO_NUM_17, GPIO_NUM_16, UART_PIN_NO_CHANGE, UART_PIN_NO_CHANGE);

    xTaskCreate(uart_event_task, "uart_event_task", 4096, NULL, 12, NULL);
}


// Hàm đọc và tính giá trị khoảng cách đến vật thể, đơn vị khoảng cách: cm
void HCSR04_ReadDistance(void) 
{
    // Kéo chân tín hiệu TRIG_PIN về 0 trong 2ms
    gpio_set_level(TRIG_PIN, 0);
    vTaskDelay(pdMS_TO_TICKS(2));

    // Kéo chân tín hiệu TRIG_PIN lên 1 trong 10ms
    gpio_set_level(TRIG_PIN, 1);
    vTaskDelay(pdMS_TO_TICKS(10));
    gpio_set_level(TRIG_PIN, 0);

    while (gpio_get_level(ECHO_PIN) == 0);
    int64_t start_time = esp_timer_get_time();

    while (gpio_get_level(ECHO_PIN) == 1);
    int64_t time_us = esp_timer_get_time() - start_time;

    double distance_before_calib = (time_us * 343) / (2 * 10000.0);
    double distance_after_calib = ((time_us * calib_SpeedofSound) / (2 * 10000.0)) + calib_Zero;
    
    // Gửi ngược lại dữ liệu khoảng cách đã tính toán lên GUI theo frame: "@...&...#", trong đó
    // Giá trị nằm giữa '@' và '&' là giá trị distance_before_calib
    // Giá trị nằm giữa '&' và '#' là giá trị distance_after_calib
    // GUI sẽ bóc tách frame truyền này, lấy dữ liệu và hiển thị lên cho người dùng
    char buffer[64];
    int len = sprintf(buffer, "@%.2f&%.2f#\r\n", distance_before_calib, distance_after_calib); 
    uart_write_bytes(UART_NUM_2, buffer, len);
}

void app_main(void) {
    uart_init();

    esp_rom_gpio_pad_select_gpio(TRIG_PIN);
    gpio_set_direction(TRIG_PIN, GPIO_MODE_OUTPUT);
    gpio_set_level(TRIG_PIN, 0);

    esp_rom_gpio_pad_select_gpio(ECHO_PIN);
    gpio_set_direction(ECHO_PIN, GPIO_MODE_INPUT);

    while (1) 
    {
        HCSR04_ReadDistance();
        vTaskDelay(pdMS_TO_TICKS(2000));
    }
}

