using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO.Ports;
using System.IO;
using System.Globalization;
using System.Threading;

namespace SeedCmdChecker
{
    public partial class Form1 : Form
    {
        #region フィールド
        private Settings settingsData;
        delegate void SerialReceiveCallback(object sender, SerialDataReceivedEventArgs e);
        delegate void SerialReceivePollCallback(object sender);
        private int historyIndex = 0;
        private const int historyMax = 20;
        private System.Threading.Timer timer;
        private object obj = new object();
        private int timerInterval = 100;
        SeedCmdParameter seedCmdParameter = new SeedCmdParameter();
        private List<Control> argsTextBox = new List<Control>();
        private mouse mouse;
        private int pulse;
        int mouseX;
        int mouseY;
   
        #endregion

        #region コンストラクタ
        public Form1()
        {
            InitializeComponent();
            this.settingsData = Settings.Load();

            // Timerを設定します。
            TimerCallback timerDelegate = new TimerCallback(serialPort_DataReceive);
            this.timer = new System.Threading.Timer(timerDelegate, null, 0, this.timerInterval);


            foreach (SeedCmdData data in seedCmdParameter.CmdDataList)
            {
                this.comboBox_Cmd.Items.Add(data.Name);
            }

            argsTextBox.Add(this.textBox_Arg1);
            argsTextBox.Add(this.textBox_Arg2);
            argsTextBox.Add(this.textBox_Arg3);
            argsTextBox.Add(this.textBox_Arg4);
            argsTextBox.Add(this.textBox_Arg5);
        }

        #endregion

        #region イベント

        /// <summary>
        /// ポーリングでの呼び出し用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void serialPort_DataReceive(object o)
        {
            if (serialPort.IsOpen == false ||
                serialPort.IsOpen == true && serialPort.BytesToRead == 0)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                // 同一メソッドへのコールバックを作成する
                SerialReceivePollCallback delegateMethod = new SerialReceivePollCallback(serialPort_DataReceive);

                // コントロールの親のInvoke()メソッドを呼び出すことで、呼び出し元の
                // コントロールのスレッドでこのメソッドを実行する
                this.Invoke(delegateMethod, new object[] { o });
                return;
            }
            mouse mouse = new mouse();
            // シリアルポートからデータ受信
            char[] data = new char[serialPort.BytesToRead];
            serialPort.Read(data, 0, data.GetLength(0));

            string str = new string(data);
            str = str.Replace("\a", "\\a");
            this.textBox_RecvLog.Text += str.Replace("\r", "\\r\r\n");
            
            if(str.Contains("t30F52FFF5C0200"))
            {
                timer2.Enabled = false;
                
              
            }
            if (str.Contains("t30F52FFF5C02FF"))
            {
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(mouseX, mouseY);
                timer2.Enabled = true;

            }

            //Console.WriteLine(str.Contains("t30F82FFF42"));
        }

        /// <summary>
        /// COMポートが変更された時に呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_ComPortSelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort.PortName == (string)this.comboBox_ComPort.SelectedItem &&
                serialPort.IsOpen == true)
            {
                return;
            }

            try
            {
                if (serialPort.IsOpen == true)
                {
                    serialPort.Close();
                }

                serialPort.PortName = (string)this.comboBox_ComPort.SelectedItem;
                serialPort.Open();

                //
                serialPort.Write("S8\r");
                // CANのオープン
                serialPort.Write("O\r");

                this.settingsData.Port = this.serialPort.PortName;
                Settings.Save(this.settingsData);
            }
            catch
            {
                MessageBox.Show("COMポートのオープンに失敗しました。");
            }
        }

        /// <summary>
        /// COMポートが選択された時に呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_ComPort_Click(object sender, EventArgs e)
        {
            comboBox_ComPort.Items.Clear();
            string[] portArray = SerialPort.GetPortNames();
            foreach (string port in portArray)
            {
                comboBox_ComPort.Items.Add(port);
            }
        }

        /// <summary>
        /// Sendボタンが押された時に呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Send.Text.Length == 0)
                {
                    return;
                }

                string cmd = this.textBox_Send.Text;
                int zeroFillLen = 12 - textBox_Send.Text.Length; // SEED CMDの長さからテキストのコマンド長さを引く。

                for (int i = 0; i < zeroFillLen; i++)
                {
                    cmd += "0";
                }

                this.textBox_SendLog.Text += textBox_Send.Text + "\\r" + "\r\n";

                cmd += "\r";
                serialPort.Write(cmd);

                int index = this.settingsData.SendCmdHistoryList.FindIndex(history => history == textBox_Send.Text);
                if (index == -1)
                {
                    while (this.settingsData.SendCmdHistoryList.Count > historyMax - 1)
                    {
                        this.settingsData.SendCmdHistoryList.RemoveAt(0);
                    }
                }
                else
                {
                    this.settingsData.SendCmdHistoryList.RemoveAt(index);
                }

                this.settingsData.SendCmdHistoryList.Add(textBox_Send.Text);
                Settings.Save(this.settingsData);

                this.historyIndex = 0;
            }
            catch
            {
                MessageBox.Show("送信に失敗しました。");
            }
        }

        /// <summary>
        /// Clearボタンが押された時に呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            this.textBox_SendLog.Clear();
            this.textBox_RecvLog.Clear();
        }

        /// <summary>
        /// フォームが現れるときに実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// SEED IDが変更された場合に呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SEEDID_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.settingsData.SeedId = (string)this.comboBox_SEEDID.SelectedItem;
            Settings.Save(this.settingsData);
            sendCmdUpdate();
        }

        /// <summary>
        /// SENDコマンドテキストボックスでキーが押されて、離された際に呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Send_KeyUp(object sender, KeyEventArgs e)
        {
            int historyCount = this.settingsData.SendCmdHistoryList.Count;
            if (e.KeyData == Keys.Up)
            {
                this.historyIndex++;
                this.historyIndex = this.historyIndex >= historyCount ? historyCount : this.historyIndex;
                if (this.historyIndex <= historyCount && this.historyIndex >= 0)
                {
                    if (this.historyIndex == 0)
                    {
                        this.historyIndex++;
                    }
                    this.textBox_Send.Text = this.settingsData.SendCmdHistoryList[historyCount - this.historyIndex];
                }


                e.Handled = true;
            }
            else if (e.KeyData == Keys.Down)
            {
                this.historyIndex--;
                this.historyIndex = this.historyIndex < 1 ? 0 : this.historyIndex;
                if (this.historyIndex <= historyCount && this.historyIndex > 0)
                {
                    if (this.historyIndex == historyCount)
                    {
                        this.historyIndex--;
                    }
                    this.textBox_Send.Text = this.settingsData.SendCmdHistoryList[historyCount - this.historyIndex];
                }
                else
                {
                    this.textBox_Send.Text = "";
                }

                e.Handled = true;
            }
            else if (e.KeyData == Keys.Enter)
            {
                this.Send_Click(this, null);
            }
        }

        private void button_FileClose_Click(object sender, EventArgs e)
        {
            Log.Close();
        }

        private void textBox_Arg1_TextChanged(object sender, EventArgs e)
        {
            sendCmdUpdate();
        }

        private void textBox_Arg2_TextChanged(object sender, EventArgs e)
        {
            sendCmdUpdate();
        }

        private void textBox_Arg3_TextChanged(object sender, EventArgs e)
        {
            sendCmdUpdate();
        }

        private void textBox_Arg4_TextChanged(object sender, EventArgs e)
        {
            sendCmdUpdate();
        }

        private void textBox_Arg5_TextChanged(object sender, EventArgs e)
        {
            sendCmdUpdate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.timer != null)
            {
                this.timer.Dispose();
            }
            if (this.serialPort != null && this.serialPort.IsOpen == true)
            {
                this.serialPort.Close();
                this.serialPort.Dispose();
            }
        }

        private void comboBox_Cmd_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = this.seedCmdParameter.CmdDataList.FindIndex(s => s.Name == (string)this.comboBox_Cmd.SelectedItem);
            argsTextBoxSetting(this.seedCmdParameter.CmdDataList[i]);
            sendCmdUpdate();
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 送信コマンドの文字列の更新を行います。
        /// </summary>
        private void sendCmdUpdate()
        {
            this.textBox_Send.Text = "";
            this.textBox_Send.Text = "t30" + int.Parse((string)comboBox_SEEDID.SelectedItem).ToString("X") + "8F" + int.Parse((string)comboBox_SEEDID.SelectedItem).ToString("X") + "00" + textBox_Send.Text;

            int cmdIndex = this.seedCmdParameter.CmdDataList.FindIndex(s => s.Name == (string)this.comboBox_Cmd.SelectedItem);
            if (cmdIndex == -1)
            {
                int zeroFillLen = 21 - textBox_Send.Text.Length; // SEED CMDの長さからテキストのコマンド長さを引く。
                for (int i = 0; i < zeroFillLen; i++)
                {
                    this.textBox_Send.Text += "0";
                }
            }
            else
            {
                this.textBox_Send.Text += this.seedCmdParameter.CmdDataList[cmdIndex].Cmd.ToString("X2");
                for (int j = 0; j < this.seedCmdParameter.CmdDataList[cmdIndex].Args.Count; j++)
                {
                    TextBox textBox = argsTextBox[j] as TextBox;
                    int size = this.seedCmdParameter.CmdDataList[cmdIndex].Args[j];
                    string s = "{0:X" + (size * 2).ToString() + "}";
                    //string str = String.Format(s, int.Parse(textBox.Text));
                    int num = 0;

                    if (int.TryParse(textBox.Text, System.Globalization.NumberStyles.HexNumber, null, out num) == false)
                    {
                        this.textBox_Send.Text += String.Format(s, 0);
                    }
                    else
                    {
                        this.textBox_Send.Text += String.Format(s, num); ;
                    }
                }

                int zeroFillLen = 21 - textBox_Send.Text.Length; // SEED CMDの長さからテキストのコマンド長さを引く。
                for (int i = 0; i < zeroFillLen; i++)
                {
                    this.textBox_Send.Text += "0";
                }
            }
        }
        /// <summary>
        /// 選択されたコマンドによって引数用テキストボックスの状態を変更します。
        /// </summary>
        /// <param name="data"></param>
        private void argsTextBoxSetting(SeedCmdData data)
        {
            int i = 0;
            foreach (Control c in argsTextBox)
            {
                TextBox textBox = c as TextBox;
                i++;
                textBox.Enabled = (i > data.Args.Count) ? false : true;
                textBox.MaxLength = (i > data.Args.Count) ? 0 : data.Args[i - 1] * 2;
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            // 現在選択可能なCOMポートを取得します。
            string[] portArray = SerialPort.GetPortNames();
            foreach (string port in portArray)
            {
                comboBox_ComPort.Items.Add(port);
            }

            this.comboBox_ComPort.SelectedItem = this.settingsData.Port;

            // コマンドを送信するSEED IDを設定します。
            for (int i = 1; i < 15; i++)
            {
                comboBox_SEEDID.Items.Add(i.ToString());
            }

            this.comboBox_SEEDID.SelectedItem = (this.settingsData.SeedId != string.Empty) ? this.settingsData.SeedId : "1";
            sendCmdUpdate();

            if (serialPort.IsOpen == true)
            {
                serialPort.Close();
            }
            serialPort.PortName = "COM5";
            serialPort.Open();

            serialPort.Write("S8\r");
            serialPort.Write("O\r");


        }

      
        private void timer2_Tick(object sender, EventArgs e)
        {
      
            位置座標.Text = Control.MousePosition.ToString();
#if DEBUG
            
            try
            {
                string cmd = this.textBox_Send.Text;
                
                mouse = new mouse();
                //マウスx座標をpulseに変換(40000pulse/1280pixel=31)
                pulse = mouse.X * 31;

                //seedコマンドの末尾に4桁指定でx座標を入れる
                textBox_Send.Text = "t3018F10064001100" + pulse.ToString("X4");
               
                int zeroFillLen = 12 - textBox_Send.Text.Length; // SEED CMDの長さからテキストのコマンド長さを引く。
                
                for (int i = 0; i < zeroFillLen; i++)
                {
                    cmd += "0";
                }

                this.textBox_SendLog.Text += textBox_Send.Text + "\\r" + "\r\n";
                //this.liner_position.Text += liner_position.Text + "\\r" + "\r\n";

                cmd += "\r";
                //cmd2 += "\r";
                serialPort.Write(cmd);
               
                //Console.WriteLine(mouse.X);
                //Console.WriteLine(cmd2);
            }
            catch
            {
                MessageBox.Show("送信に失敗しました。");
            }

           



        }
       
#endif
        

        private void ID1モータON_Click(object sender, EventArgs e)
        {
            try
            {

                string cmd = this.textBox_Send.Text;
                textBox_Send.Text = "t3008F000500001000000";
                int zeroFillLen = 12 - textBox_Send.Text.Length; // SEED CMDの長さからテキストのコマンド長さを引く。

                for (int i = 0; i < zeroFillLen; i++)
                {
                    cmd += "0";
                }

                this.textBox_SendLog.Text += textBox_Send.Text + "\\r" + "\r\n";

                cmd += "\r";
                serialPort.Write(cmd);

                int index = this.settingsData.SendCmdHistoryList.FindIndex(history => history == textBox_Send.Text);
                if (index == -1)
                {
                    while (this.settingsData.SendCmdHistoryList.Count > historyMax - 1)
                    {
                        this.settingsData.SendCmdHistoryList.RemoveAt(0);
                    }
                }
                else
                {
                    this.settingsData.SendCmdHistoryList.RemoveAt(index);
                }

                this.settingsData.SendCmdHistoryList.Add(textBox_Send.Text);
                Settings.Save(this.settingsData);

                this.historyIndex = 0;
            }
            catch
            {
                MessageBox.Show("送信に失敗しました。");
            }

        }

        private void ID2モータON_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string cmd = this.textBox_Send.Text;
                textBox_Send.Text = "t3008F000500000000000";
                int zeroFillLen = 12 - textBox_Send.Text.Length; // SEED CMDの長さからテキストのコマンド長さを引く。

                for (int i = 0; i < zeroFillLen; i++)
                {
                    cmd += "0";
                }

                this.textBox_SendLog.Text += textBox_Send.Text + "\\r" + "\r\n";

                cmd += "\r";
                serialPort.Write(cmd);

                int index = this.settingsData.SendCmdHistoryList.FindIndex(history => history == textBox_Send.Text);
                if (index == -1)
                {
                    while (this.settingsData.SendCmdHistoryList.Count > historyMax - 1)
                    {
                        this.settingsData.SendCmdHistoryList.RemoveAt(0);
                    }
                }
                else
                {
                    this.settingsData.SendCmdHistoryList.RemoveAt(index);
                }

                this.settingsData.SendCmdHistoryList.Add(textBox_Send.Text);
                Settings.Save(this.settingsData);

                this.historyIndex = 0;
            }
            catch
            {
                MessageBox.Show("送信に失敗しました。");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (Start.Text == "Start")
            {
                Start.Text = "Stop";
                timer2.Enabled = true;
                timer3.Enabled = true;
                timer4.Enabled = true;
            }
            else
            {
                Start.Text = "Start";
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
            }
            timer1.Enabled = true;
        }

        private void textBox_SendLog_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int ilen = textBox_RecvLog.Text.Length;
            int ilen2 = textBox_SendLog.Text.Length;

            if (ilen > 20000)
                this.textBox_RecvLog.Text = this.textBox_RecvLog.Text.Remove(0, 15000);

            if (ilen2 > 5000)
                this.textBox_SendLog.Text = this.textBox_SendLog.Text.Remove(0, 2000);

            //Console.WriteLine(ilen2.ToString());
            //Console.WriteLine(ilen.ToString());
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                string cmd = this.textBox_Send.Text;

                textBox_Send.Text = "t3028F200430200000000";
                //textBox_Send.Text = "t3008F0005D000D000000";

                int zeroFillLen = 12 - textBox_Send.Text.Length; // SEED CMDの長さからテキストのコマンド長さを引く。

                for (int i = 0; i < zeroFillLen; i++)
                {
                    cmd += "0";
                }

                this.textBox_SendLog.Text += textBox_Send.Text + "\\r" + "\r\n";
                //this.liner_position.Text += liner_position.Text + "\\r" + "\r\n";

                cmd += "\r";
                serialPort.Write(cmd);


            }
            catch
            {
                MessageBox.Show("送信に失敗しました。");
            }


        
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
             if (mouse.X < 600 && mouse.X > 300 && mouse.Y < 600 && mouse.Y > 300)
            {
                try
                {
                    string cmd = this.textBox_Send.Text;


                    mouse = new mouse();
                 

                    //seedコマンドの末尾に4桁指定でx座標を入れる
                    textBox_Send.Text = "t3028F2005D0201000000";

                    int zeroFillLen = 12 - textBox_Send.Text.Length; // SEED CMDの長さからテキストのコマンド長さを引く。

                    for (int i = 0; i < zeroFillLen; i++)
                    {
                        cmd += "0";
                    }

                    this.textBox_SendLog.Text += textBox_Send.Text + "\\r" + "\r\n";
                    //this.liner_position.Text += liner_position.Text + "\\r" + "\r\n";

                    cmd += "\r";
                    //cmd2 += "\r";
                    serialPort.Write(cmd);

                }
                catch
                {
                    MessageBox.Show("送信に失敗しました。");
                }

          
            }
            else
            {
                try
                {
                    string cmd = this.textBox_Send.Text;


                    mouse = new mouse();


                    //seedコマンドの末尾に4桁指定でx座標を入れる
                    textBox_Send.Text = "t3028F2005D0209000000";

                    int zeroFillLen = 12 - textBox_Send.Text.Length; // SEED CMDの長さからテキストのコマンド長さを引く。

                    for (int i = 0; i < zeroFillLen; i++)
                    {
                        cmd += "0";
                    }

                    this.textBox_SendLog.Text += textBox_Send.Text + "\\r" + "\r\n";
                    //this.liner_position.Text += liner_position.Text + "\\r" + "\r\n";

                    cmd += "\r";
                    //cmd2 += "\r";
                    serialPort.Write(cmd);

                    //Console.WriteLine(mouse.X);
                    //Console.WriteLine(cmd2);
                }
                catch
                {
                    MessageBox.Show("送信に失敗しました。");
                }
            }
            
        }
    }
}

