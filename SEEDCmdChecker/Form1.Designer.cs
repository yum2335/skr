namespace SeedCmdChecker
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Clear = new System.Windows.Forms.Button();
            this.textBox_Send = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.comboBox_ComPort = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.textBox_SendLog = new System.Windows.Forms.TextBox();
            this.comboBox_SEEDID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Cmd = new System.Windows.Forms.ComboBox();
            this.label_CMD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Arg1 = new System.Windows.Forms.TextBox();
            this.textBox_Arg3 = new System.Windows.Forms.TextBox();
            this.textBox_Arg4 = new System.Windows.Forms.TextBox();
            this.textBox_Arg5 = new System.Windows.Forms.TextBox();
            this.textBox_Arg2 = new System.Windows.Forms.TextBox();
            this.textBox_RecvLog = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.位置座標 = new System.Windows.Forms.Label();
            this.モータON = new System.Windows.Forms.Button();
            this.モータOFF = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.liner_position = new System.Windows.Forms.TextBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear.Location = new System.Drawing.Point(607, 337);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // textBox_Send
            // 
            this.textBox_Send.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Send.Location = new System.Drawing.Point(271, 404);
            this.textBox_Send.MaxLength = 21;
            this.textBox_Send.Name = "textBox_Send";
            this.textBox_Send.Size = new System.Drawing.Size(288, 25);
            this.textBox_Send.TabIndex = 2;
            this.textBox_Send.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_Send_KeyUp);
            // 
            // Send
            // 
            this.Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Send.Location = new System.Drawing.Point(607, 400);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 3;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // comboBox_ComPort
            // 
            this.comboBox_ComPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_ComPort.FormattingEnabled = true;
            this.comboBox_ComPort.Location = new System.Drawing.Point(36, 403);
            this.comboBox_ComPort.Name = "comboBox_ComPort";
            this.comboBox_ComPort.Size = new System.Drawing.Size(115, 26);
            this.comboBox_ComPort.TabIndex = 4;
            this.comboBox_ComPort.SelectedIndexChanged += new System.EventHandler(this.comboBox_ComPortSelectedIndexChanged);
            this.comboBox_ComPort.Click += new System.EventHandler(this.comboBox_ComPort_Click);
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.ReadBufferSize = 8192;
            // 
            // textBox_SendLog
            // 
            this.textBox_SendLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SendLog.Location = new System.Drawing.Point(6, 22);
            this.textBox_SendLog.Multiline = true;
            this.textBox_SendLog.Name = "textBox_SendLog";
            this.textBox_SendLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_SendLog.Size = new System.Drawing.Size(566, 303);
            this.textBox_SendLog.TabIndex = 0;
            this.textBox_SendLog.TextChanged += new System.EventHandler(this.textBox_SendLog_TextChanged);
            // 
            // comboBox_SEEDID
            // 
            this.comboBox_SEEDID.FormattingEnabled = true;
            this.comboBox_SEEDID.Location = new System.Drawing.Point(207, 401);
            this.comboBox_SEEDID.Name = "comboBox_SEEDID";
            this.comboBox_SEEDID.Size = new System.Drawing.Size(58, 26);
            this.comboBox_SEEDID.TabIndex = 5;
            this.comboBox_SEEDID.SelectedIndexChanged += new System.EventHandler(this.comboBox_SEEDID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "SEED ID";
            // 
            // comboBox_Cmd
            // 
            this.comboBox_Cmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_Cmd.FormattingEnabled = true;
            this.comboBox_Cmd.Location = new System.Drawing.Point(36, 332);
            this.comboBox_Cmd.Name = "comboBox_Cmd";
            this.comboBox_Cmd.Size = new System.Drawing.Size(115, 26);
            this.comboBox_Cmd.TabIndex = 7;
            this.comboBox_Cmd.SelectedIndexChanged += new System.EventHandler(this.comboBox_Cmd_SelectedIndexChanged);
            // 
            // label_CMD
            // 
            this.label_CMD.AutoSize = true;
            this.label_CMD.Location = new System.Drawing.Point(4, 335);
            this.label_CMD.Name = "label_CMD";
            this.label_CMD.Size = new System.Drawing.Size(45, 18);
            this.label_CMD.TabIndex = 12;
            this.label_CMD.Text = "CMD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "arg1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "arg2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "arg3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "arg4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "arg5";
            // 
            // textBox_Arg1
            // 
            this.textBox_Arg1.Enabled = false;
            this.textBox_Arg1.Location = new System.Drawing.Point(184, 333);
            this.textBox_Arg1.Name = "textBox_Arg1";
            this.textBox_Arg1.Size = new System.Drawing.Size(115, 25);
            this.textBox_Arg1.TabIndex = 19;
            this.textBox_Arg1.TextChanged += new System.EventHandler(this.textBox_Arg1_TextChanged);
            // 
            // textBox_Arg3
            // 
            this.textBox_Arg3.Enabled = false;
            this.textBox_Arg3.Location = new System.Drawing.Point(36, 360);
            this.textBox_Arg3.Name = "textBox_Arg3";
            this.textBox_Arg3.Size = new System.Drawing.Size(115, 25);
            this.textBox_Arg3.TabIndex = 21;
            this.textBox_Arg3.TextChanged += new System.EventHandler(this.textBox_Arg3_TextChanged);
            // 
            // textBox_Arg4
            // 
            this.textBox_Arg4.Enabled = false;
            this.textBox_Arg4.Location = new System.Drawing.Point(184, 360);
            this.textBox_Arg4.Name = "textBox_Arg4";
            this.textBox_Arg4.Size = new System.Drawing.Size(115, 25);
            this.textBox_Arg4.TabIndex = 22;
            this.textBox_Arg4.TextChanged += new System.EventHandler(this.textBox_Arg4_TextChanged);
            // 
            // textBox_Arg5
            // 
            this.textBox_Arg5.Enabled = false;
            this.textBox_Arg5.Location = new System.Drawing.Point(329, 360);
            this.textBox_Arg5.Name = "textBox_Arg5";
            this.textBox_Arg5.Size = new System.Drawing.Size(115, 25);
            this.textBox_Arg5.TabIndex = 23;
            this.textBox_Arg5.TextChanged += new System.EventHandler(this.textBox_Arg5_TextChanged);
            // 
            // textBox_Arg2
            // 
            this.textBox_Arg2.Enabled = false;
            this.textBox_Arg2.Location = new System.Drawing.Point(329, 332);
            this.textBox_Arg2.Name = "textBox_Arg2";
            this.textBox_Arg2.Size = new System.Drawing.Size(115, 25);
            this.textBox_Arg2.TabIndex = 24;
            this.textBox_Arg2.TextChanged += new System.EventHandler(this.textBox_Arg2_TextChanged);
            // 
            // textBox_RecvLog
            // 
            this.textBox_RecvLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_RecvLog.Location = new System.Drawing.Point(266, 22);
            this.textBox_RecvLog.Multiline = true;
            this.textBox_RecvLog.Name = "textBox_RecvLog";
            this.textBox_RecvLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_RecvLog.Size = new System.Drawing.Size(306, 304);
            this.textBox_RecvLog.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 18);
            this.label7.TabIndex = 26;
            this.label7.Text = "Send";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 18);
            this.label8.TabIndex = 27;
            this.label8.Text = "Recv";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "Port";
            // 
            // timer2
            // 
            this.timer2.Interval = 20;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // 位置座標
            // 
            this.位置座標.Font = new System.Drawing.Font("MS UI Gothic", 24F);
            this.位置座標.Location = new System.Drawing.Point(601, 22);
            this.位置座標.Name = "位置座標";
            this.位置座標.Size = new System.Drawing.Size(290, 76);
            this.位置座標.TabIndex = 29;
            this.位置座標.Text = "位置座標";
            this.位置座標.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.位置座標.Click += new System.EventHandler(this.label10_Click);
            // 
            // モータON
            // 
            this.モータON.Location = new System.Drawing.Point(654, 117);
            this.モータON.Name = "モータON";
            this.モータON.Size = new System.Drawing.Size(207, 23);
            this.モータON.TabIndex = 30;
            this.モータON.Text = "モータON";
            this.モータON.UseVisualStyleBackColor = true;
            this.モータON.Click += new System.EventHandler(this.ID1モータON_Click);
            // 
            // モータOFF
            // 
            this.モータOFF.Location = new System.Drawing.Point(654, 190);
            this.モータOFF.Name = "モータOFF";
            this.モータOFF.Size = new System.Drawing.Size(207, 23);
            this.モータOFF.TabIndex = 32;
            this.モータOFF.Text = "モータOFF";
            this.モータOFF.UseMnemonic = false;
            this.モータOFF.UseVisualStyleBackColor = true;
            this.モータOFF.Click += new System.EventHandler(this.button1_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(683, 274);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(145, 23);
            this.Start.TabIndex = 34;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Stop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // liner_position
            // 
            this.liner_position.Location = new System.Drawing.Point(723, 332);
            this.liner_position.Multiline = true;
            this.liner_position.Name = "liner_position";
            this.liner_position.Size = new System.Drawing.Size(138, 64);
            this.liner_position.TabIndex = 35;
            // 
            // timer3
            // 
            this.timer3.Interval = 20;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 20;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(922, 425);
            this.Controls.Add(this.liner_position);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.モータOFF);
            this.Controls.Add(this.モータON);
            this.Controls.Add(this.位置座標);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_RecvLog);
            this.Controls.Add(this.textBox_Arg2);
            this.Controls.Add(this.textBox_Arg5);
            this.Controls.Add(this.textBox_Arg4);
            this.Controls.Add(this.textBox_Arg3);
            this.Controls.Add(this.textBox_Arg1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_CMD);
            this.Controls.Add(this.comboBox_Cmd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_SEEDID);
            this.Controls.Add(this.comboBox_ComPort);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.textBox_Send);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.textBox_SendLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(545, 464);
            this.Name = "Form1";
            this.Text = "SeedCmdChecker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox textBox_Send;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.ComboBox comboBox_ComPort;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TextBox textBox_SendLog;
        private System.Windows.Forms.ComboBox comboBox_SEEDID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Cmd;
        private System.Windows.Forms.Label label_CMD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Arg1;
        private System.Windows.Forms.TextBox textBox_Arg3;
        private System.Windows.Forms.TextBox textBox_Arg4;
        private System.Windows.Forms.TextBox textBox_Arg5;
        private System.Windows.Forms.TextBox textBox_Arg2;
        private System.Windows.Forms.TextBox textBox_RecvLog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label 位置座標;
        private System.Windows.Forms.Button モータON;
        private System.Windows.Forms.Button モータOFF;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox liner_position;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
    }
}

