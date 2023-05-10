namespace Replace_data_print
{
    partial class frmPrintData
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
            this.tmrCheckConnection = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.lblcount = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TxtIPAddr = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblReply = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTimeInterval = new System.Windows.Forms.TextBox();
            this.LblDevStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrCheckConnection
            // 
            this.tmrCheckConnection.Interval = 5000;
            this.tmrCheckConnection.Tick += new System.EventHandler(this.tmrCheckConnection_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(424, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 50;
            this.button1.Text = "Send Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(151, 79);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(255, 40);
            this.txtData.TabIndex = 51;
            // 
            // lblcount
            // 
            this.lblcount.AutoSize = true;
            this.lblcount.Location = new System.Drawing.Point(415, 99);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(27, 13);
            this.lblcount.TabIndex = 52;
            this.lblcount.Text = "Msg";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TxtIPAddr
            // 
            this.TxtIPAddr.Location = new System.Drawing.Point(151, 27);
            this.TxtIPAddr.Name = "TxtIPAddr";
            this.TxtIPAddr.Size = new System.Drawing.Size(218, 20);
            this.TxtIPAddr.TabIndex = 54;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(375, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 53;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(151, 53);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(99, 20);
            this.TxtPort.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblReply);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtTimeInterval);
            this.panel1.Controls.Add(this.LblDevStatus);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtData);
            this.panel1.Controls.Add(this.TxtPort);
            this.panel1.Controls.Add(this.TxtIPAddr);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lblcount);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 169);
            this.panel1.TabIndex = 56;
            // 
            // LblReply
            // 
            this.LblReply.AutoSize = true;
            this.LblReply.Location = new System.Drawing.Point(148, 148);
            this.LblReply.Name = "LblReply";
            this.LblReply.Size = new System.Drawing.Size(43, 13);
            this.LblReply.TabIndex = 62;
            this.LblReply.Text = "Reply : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Time Interval";
            // 
            // TxtTimeInterval
            // 
            this.TxtTimeInterval.Location = new System.Drawing.Point(151, 125);
            this.TxtTimeInterval.Name = "TxtTimeInterval";
            this.TxtTimeInterval.Size = new System.Drawing.Size(59, 20);
            this.TxtTimeInterval.TabIndex = 60;
            // 
            // LblDevStatus
            // 
            this.LblDevStatus.AutoSize = true;
            this.LblDevStatus.Location = new System.Drawing.Point(375, 30);
            this.LblDevStatus.Name = "LblDevStatus";
            this.LblDevStatus.Size = new System.Drawing.Size(59, 13);
            this.LblDevStatus.TabIndex = 59;
            this.LblDevStatus.Text = "Connected";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "IP Address";
            // 
            // frmPrintData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 193);
            this.Controls.Add(this.panel1);
            this.Name = "frmPrintData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED Data Application";
            this.Load += new System.EventHandler(this.frmPrintData_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrCheckConnection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lblcount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox TxtIPAddr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblDevStatus;
        private System.Windows.Forms.TextBox TxtTimeInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblReply;
    }
}