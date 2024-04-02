
namespace GUI_ReadDistance
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serCOM = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butSendSS = new System.Windows.Forms.Button();
            this.butSendZero = new System.Windows.Forms.Button();
            this.txtSSCalib = new System.Windows.Forms.TextBox();
            this.txtZeroCalib = new System.Windows.Forms.TextBox();
            this.txtValueAfterCalib = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAllData = new System.Windows.Forms.TextBox();
            this.txtValueBeforeCalib = new System.Windows.Forms.TextBox();
            this.Communication = new System.Windows.Forms.GroupBox();
            this.cboBaudrate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboComPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butConnect = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.Communication.SuspendLayout();
            this.SuspendLayout();
            // 
            // serCOM
            // 
            this.serCOM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serCOM_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.butSendSS);
            this.groupBox1.Controls.Add(this.butSendZero);
            this.groupBox1.Controls.Add(this.txtSSCalib);
            this.groupBox1.Controls.Add(this.txtZeroCalib);
            this.groupBox1.Controls.Add(this.txtValueAfterCalib);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAllData);
            this.groupBox1.Controls.Add(this.txtValueBeforeCalib);
            this.groupBox1.Location = new System.Drawing.Point(423, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 333);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Calib Zero (cm):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Calib Speed of Sound (m/s):";
            // 
            // butSendSS
            // 
            this.butSendSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSendSS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butSendSS.Location = new System.Drawing.Point(497, 270);
            this.butSendSS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butSendSS.Name = "butSendSS";
            this.butSendSS.Size = new System.Drawing.Size(91, 35);
            this.butSendSS.TabIndex = 19;
            this.butSendSS.Text = "Send";
            this.butSendSS.UseVisualStyleBackColor = true;
            this.butSendSS.Click += new System.EventHandler(this.butSendSS_Click);
            // 
            // butSendZero
            // 
            this.butSendZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSendZero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butSendZero.Location = new System.Drawing.Point(497, 212);
            this.butSendZero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butSendZero.Name = "butSendZero";
            this.butSendZero.Size = new System.Drawing.Size(91, 35);
            this.butSendZero.TabIndex = 18;
            this.butSendZero.Text = "Send";
            this.butSendZero.UseVisualStyleBackColor = true;
            this.butSendZero.Click += new System.EventHandler(this.butSendZero_Click);
            // 
            // txtSSCalib
            // 
            this.txtSSCalib.Location = new System.Drawing.Point(339, 275);
            this.txtSSCalib.Name = "txtSSCalib";
            this.txtSSCalib.Size = new System.Drawing.Size(152, 22);
            this.txtSSCalib.TabIndex = 17;
            // 
            // txtZeroCalib
            // 
            this.txtZeroCalib.Location = new System.Drawing.Point(339, 219);
            this.txtZeroCalib.Name = "txtZeroCalib";
            this.txtZeroCalib.Size = new System.Drawing.Size(152, 22);
            this.txtZeroCalib.TabIndex = 16;
            // 
            // txtValueAfterCalib
            // 
            this.txtValueAfterCalib.Location = new System.Drawing.Point(339, 159);
            this.txtValueAfterCalib.Name = "txtValueAfterCalib";
            this.txtValueAfterCalib.Size = new System.Drawing.Size(152, 22);
            this.txtValueAfterCalib.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Distance after Calib (cm):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Data Frame:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Distance before Calib (cm):";
            // 
            // txtAllData
            // 
            this.txtAllData.Location = new System.Drawing.Point(339, 48);
            this.txtAllData.Name = "txtAllData";
            this.txtAllData.Size = new System.Drawing.Size(152, 22);
            this.txtAllData.TabIndex = 11;
            // 
            // txtValueBeforeCalib
            // 
            this.txtValueBeforeCalib.Location = new System.Drawing.Point(339, 103);
            this.txtValueBeforeCalib.Name = "txtValueBeforeCalib";
            this.txtValueBeforeCalib.Size = new System.Drawing.Size(152, 22);
            this.txtValueBeforeCalib.TabIndex = 12;
            // 
            // Communication
            // 
            this.Communication.Controls.Add(this.cboBaudrate);
            this.Communication.Controls.Add(this.label3);
            this.Communication.Controls.Add(this.cboComPort);
            this.Communication.Controls.Add(this.label2);
            this.Communication.Controls.Add(this.butConnect);
            this.Communication.Controls.Add(this.butExit);
            this.Communication.Location = new System.Drawing.Point(28, 133);
            this.Communication.Name = "Communication";
            this.Communication.Size = new System.Drawing.Size(378, 333);
            this.Communication.TabIndex = 16;
            this.Communication.TabStop = false;
            this.Communication.Text = "Communication";
            // 
            // cboBaudrate
            // 
            this.cboBaudrate.FormattingEnabled = true;
            this.cboBaudrate.Location = new System.Drawing.Point(196, 83);
            this.cboBaudrate.Name = "cboBaudrate";
            this.cboBaudrate.Size = new System.Drawing.Size(152, 24);
            this.cboBaudrate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Baudrate:";
            // 
            // cboComPort
            // 
            this.cboComPort.FormattingEnabled = true;
            this.cboComPort.Location = new System.Drawing.Point(196, 31);
            this.cboComPort.Name = "cboComPort";
            this.cboComPort.Size = new System.Drawing.Size(152, 24);
            this.cboComPort.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select COM:";
            // 
            // butConnect
            // 
            this.butConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.butConnect.Location = new System.Drawing.Point(65, 159);
            this.butConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(232, 55);
            this.butConnect.TabIndex = 7;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // butExit
            // 
            this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butExit.Location = new System.Drawing.Point(110, 242);
            this.butExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(135, 55);
            this.butExit.TabIndex = 8;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(305, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 38);
            this.label1.TabIndex = 15;
            this.label1.Text = "Read Distance from HCSR04";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 508);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Communication);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Communication.ResumeLayout(false);
            this.Communication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serCOM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button butSendSS;
        private System.Windows.Forms.Button butSendZero;
        private System.Windows.Forms.TextBox txtSSCalib;
        private System.Windows.Forms.TextBox txtZeroCalib;
        private System.Windows.Forms.TextBox txtValueAfterCalib;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAllData;
        private System.Windows.Forms.TextBox txtValueBeforeCalib;
        private System.Windows.Forms.GroupBox Communication;
        private System.Windows.Forms.ComboBox cboBaudrate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboComPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Label label1;
    }
}

