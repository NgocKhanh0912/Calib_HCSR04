This project is the Industrial Measurement subject project that I studied in semester 232. The project content is as follows:

1. The ESP32 communicates with a WinForm on a computer via UART to transmit, receive data, and display the distance on the WinForm. The WinForm will send down calibration parameters to the ESP32.

2. Initially, we measure the distance with the speed of sound parameter set to 343 m/s, creating a table of measured distances with reference distances taken from a ruler. After obtaining a dataset, we use the least squares method in statistics to calibrate the HCSR04 sensor, finding the Calib_SpeedofSound and Calib_Zero values ​​so that the measured distance value is closest to the standard value. These calibration parameters will be sent from the WinForm to the ESP32.
