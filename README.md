This project is the Industrial Measurement subject project that I studied in semester 232. The project content is as follows:

1. The ESP32 communicates with a WinForm on a computer via UART to transmit, receive data, and display the distance on the WinForm. The WinForm will send down calibration parameters to the ESP32.
   
   a) The data received from the interface comes in 2 forms:
   - Form 1: "Z...C" where the value between 'Z' and 'C' represents the value that the user wants to input for the calib_Zero variable from the GUI to the ESP32.
     The letter 'Z' at the beginning of the string represents Zero, and the letter 'C' at the end of the string represents calib.
   - Form 2: "S...C" where the value between 'S' and 'C' represents the value that the user wants to input for the calib_SpeedofSound variable from the GUI to the ESP32.
     The letter 'S' at the beginning of the string represents SpeedofSound, and the letter 'C' at the end of the string represents calib.
   - Based on the first letter, the position of the first letter, and the position of the last letter (C) in the string, we can determine:
     + Which variable the GUI is currently sending data for
     + The value of that variable.
       
   b) The data transmitted from ESP32 to the GUI has the format: "@...&...#", where:
   - The value between '@' and '&' represents the value of distance_before_calib.
   - The value between '&' and '#' represents the value of distance_after_calib.
     The GUI will parse this frame, extract the data, and display it to the user.

2. Initially, we measure the distance with the speed of sound parameter set to 343 m/s, creating a table of measured distances with reference distances taken from a ruler. After obtaining a dataset, we use the least squares method in statistics to calibrate the HCSR04 sensor, finding the Calib_SpeedofSound and Calib_Zero values ​​so that the measured distance value is closest to the standard value. These calibration parameters will be sent from the WinForm to the ESP32.
