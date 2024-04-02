using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace GUI_ReadDistance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] Baudrate = { "1200", "2400", "3600", "4800", "9600", "115200" };
            cboBaudrate.Items.AddRange(Baudrate);
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboComPort.DataSource = SerialPort.GetPortNames();
            cboBaudrate.Text = "9600";
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            if (!serCOM.IsOpen)
            {
                butConnect.Text = "Connected";
                serCOM.PortName = cboComPort.Text;
                serCOM.BaudRate = Convert.ToInt32(cboBaudrate.Text);

                serCOM.Open();
            }
            else
            {
                butConnect.Text = "Disconnected";
                serCOM.Close();
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butSendZero_Click(object sender, EventArgs e)
        {
            if (!serCOM.IsOpen)
            {
                MessageBox.Show("COM Port has not been connected!");
            }
            else
            {
                string data_zero = txtZeroCalib.Text;

                // Thêm chữ Z ở đầu chuỗi và chữ C ở cuối chuỗi
                data_zero = "Z" + data_zero + "C";

                // Gửi xuống cho ESP32
                serCOM.Write(data_zero);
            }
        }

        private void butSendSS_Click(object sender, EventArgs e)
        {
            if (!serCOM.IsOpen)
            {
                MessageBox.Show("COM Port has not been connected!");
            }

            else
            {
                string data_ss = txtSSCalib.Text;

                // Thêm chữ S ở đầu chuỗi và chữ C ở cuối chuỗi
                data_ss = "S" + data_ss + "C";

                // Gửi xuống cho ESP32
                serCOM.Write(data_ss);
            }
        }

        private StringBuilder receivedData = new StringBuilder();

        private void serCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Đọc dữ liệu từ SerialPort
                string newData = serCOM.ReadLine(); 
                newData = newData.Trim();

                // Thêm dữ liệu mới vào txtAllData
                txtAllData.Text = newData;

                // Thêm dữ liệu vào bộ nhớ đệm
                receivedData.Append(newData);

                // Bóc tách frame nhận được từ ESP32 có dạng: "@...&...#"
                // Kiểm tra xem dữ liệu đã chứa chuỗi kết thúc hay chưa
                if (receivedData.ToString().Contains("@") && receivedData.ToString().Contains("#"))
                {

                    // Lấy chỉ số của ký tự @ đầu tiên
                    int startIndex = receivedData.ToString().IndexOf("@");

                    // Lấy chỉ số của ký tự # cuối cùng
                    int endIndex = receivedData.ToString().LastIndexOf("#");

                    // Trích xuất chuỗi dữ liệu từ vị trí @ đầu tiên đến vị trí # cuối cùng
                    string distanceValue = receivedData.ToString().Substring(startIndex + 1, endIndex - startIndex - 1);

                    // Tách giá trị trước và sau calib dựa trên ký tự '&'
                    string[] parts = distanceValue.Split('&');
                    string valueBeforeCalib = parts[0];
                    string valueAfterCalib = parts[1];

                    // Gửi dữ liệu đến UI trong một phương thức an toàn với thread
                    this.Invoke((MethodInvoker)delegate
                    {
                        // Clear giá trị cũ của txtValue và hiển thị giá trị mới
                        txtValueBeforeCalib.Text = valueBeforeCalib;
                        txtValueAfterCalib.Text = valueAfterCalib;
                    });

                    // Xóa bộ nhớ đệm sau khi đã xử lý
                    receivedData.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while reading data from SerialPort: " + ex.Message);
            }
        }
    }
}
