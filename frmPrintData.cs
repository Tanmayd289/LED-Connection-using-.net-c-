using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using System.IO;

namespace Replace_data_print
{
    public partial class frmPrintData : Form
    {
        //SetuService.ServiceMaster ObjSErvice = new SetuService.ServiceMaster();
        int NoOfRfidReader;        
        AsynchronousClient[] PrinterList;
        //AsynchronousClient PrinterTest;
        string FilePath = "";
        
        public frmPrintData()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
                       
        private void ConnectIp()
        {
            for (int intCountIp = 0; intCountIp < NoOfRfidReader; intCountIp++)
            {
                try
                {
                    PrinterList[intCountIp] = new AsynchronousClient();
                    PrinterList[intCountIp].Name = "LineName";
                    PrinterList[intCountIp].clsIndex = intCountIp;
                    PrinterList[intCountIp].Connected += new AsynchronousClient.sckConnected(TCP_Connect);
                    PrinterList[intCountIp].Sent += new AsynchronousClient.sckSend(TCP_Sent);
                    PrinterList[intCountIp].Received += new AsynchronousClient.sckReceive(TCP_Received);
                    PrinterList[intCountIp].Disconnected += new AsynchronousClient.sckDisconnected(TCP_Disconnect);

                    if (PrinterList[intCountIp].StartClient(TxtIPAddr.Text, Convert.ToInt32(TxtPort.Text)))
                    {
                        LblDevStatus.Text = "Connected";
                        LblDevStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        LblDevStatus.Text = "DisConnected";
                        LblDevStatus.ForeColor = Color.Red;
                    }
                }
                catch { }
            }
           
        }


        private void TCP_Connect(object Sender)
        {
            LblDevStatus.Text = "Connected";
            LblDevStatus.ForeColor = Color.Green;
            //MessageBox.Show(((AsynchronousClient)Sender).Name);
            // showStatus("connected");
        }

        private void TCP_Sent(object Sender)
        {
            //MessageBox.Show(((AsynchronousClient)Sender).Name );
        }

        private void TCP_Received(object Sender)
        {

            //MessageBox.Show(((AsynchronousClient)Sender).response);
          //  Process(((AsynchronousClient)Sender).response);


            Process(((AsynchronousClient)Sender).response, ((AsynchronousClient)Sender).Name, ((AsynchronousClient)Sender).clsIndex);

        }

        private void TCP_Disconnect(object Sender)
        {
            LblDevStatus.Text = "DisConnected";
            LblDevStatus.ForeColor = Color.Red;
            //MessageBox.Show(((AsynchronousClient)Sender).Name);
            // showStatus("connected");
            //MessageBox.Show("diConnected");
   //         Disconnect_Click(null, null);
        }

        private void Process(string content,string Name, int index)
        {
            MethodInvoker invoker = () =>
            {
                LblReply.Text = content;
                //send data to that printer
                PrinterList[index].Send(Name);

            };
            if (this.InvokeRequired)
            {
                Invoke(invoker);
            }
            else
            {
                invoker();
            }

        }

        string DirPath = "";
        private void frmPrintData_Load(object sender, EventArgs e)
        {
            //fetch socket data
            TxtIPAddr.Text = ConfigurationSettings.AppSettings["DeviceIP"].ToString();
            TxtPort.Text = ConfigurationSettings.AppSettings["DevicePort"].ToString();
            DirPath = ConfigurationSettings.AppSettings["FilePath"].ToString();
            string timerInterval = ConfigurationSettings.AppSettings["TimerInterval"].ToString();    //Added by Muhammad Idris on 22.03.2016           
            //TxtTimeInterval.Text = (timer1.Interval/1000).ToString();                     //Remarked by Muhammad Idris on 22.03.2016
            TxtTimeInterval.Text = timerInterval;                                  //Added by Muhammad Idris on 22.03.2016            
            //----------------------------
            NoOfRfidReader = 1;
            PrinterList = new AsynchronousClient[NoOfRfidReader];
            ConnectIp();
            //tmrCheckConnection.Enabled = true;
        }

        private void ShapConnectedColor_Click(object sender, EventArgs e)
        {

        }

        private void tmrCheckConnection_Tick(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            for (int intCountIp = 0; intCountIp < dtPrinterList.Rows.Count ; intCountIp++)
            {
               
                if (PrinterList[intCountIp].client.Connected)
                {
                    PrinterList[intCountIp].Send(txtData.Text.ToString());
                   // PrinterList[intCountIp].Send("0x020000011099990072720x03");
                   // PrinterList[intCountIp].Send("02 30 30 30 30 30 30 31 30 31 30 30 35 30 30 30 31 31 68 65 6C 6C 6F 20 77 6F 72 6C 64 03");
                }
              
                //if (PrinterList[intCountIp].client.Connected)
                //{
                //    PrinterList[intCountIp].Send("0x02");
                //}
            }*/

            //PrinterTest.Send(txtData.Text);
            PrinterList[0].Send(txtData.Text);
        }
        int i = 1;
        string myString = "";
        string str = "";
        int FileIdx = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Interval = Convert.ToInt32(TxtTimeInterval.Text) * 1000;

            string DataSend = "";
            //try
            //{
            //    if (File.Exists(FilePath))
            //    {
            //        //string DataSend = "";// txtData.Text;//"" + "000000101005000";
            //        string FileStr = File.ReadAllText(FilePath).Trim();
            //        string[] FileCont = FileStr.Split('@');

            //        //int SLen = FileCont[0].Length;
            //        string DStr = FileCont[0].ToString();
            //        if (FileCont.Length > 1)
            //        {
            //            //SLen += FileCont[1].Length + 1;
            //            DStr += " " + FileCont[1].ToString();
            //        }
            //        //if (SLen > 100)
            //        //    SLen = 100;
            //        //DataSend += SLen.ToString().PadLeft(3, '0') + DStr;
            //        DataSend = DStr;
            //        //DataSend += " ";

            //        //PrinterList[0].Send(DataSend);
            //        //ConnectIp();
            //    }
            //}
            //catch { }
            //timer1.Enabled = true;


            //for (int intCountIp = 0; intCountIp < dtPrinterList.Rows.Count; intCountIp++)

            string[] VhFiles = Directory.GetFiles(DirPath,"*.*txt");
            FilePath = "";
            if (VhFiles.Length > 0)
            {
                if (VhFiles.Length <= FileIdx)
                    FileIdx = 0;

                FilePath = VhFiles[FileIdx];
                
                FileIdx += 1;
            }

            {
                try
                {
                    if (File.Exists(FilePath))
                    {
                        string FileStr = File.ReadAllText(FilePath).Trim();
                        
                        try
                        {
                            File.Delete(FilePath);
                        }
                        catch { }

                        string[] FileCont = FileStr.Split('@');
                        for (int FIdx = 0; FIdx <= FileCont.Length - 1; FIdx++)
                        {
                            DataSend = "       " + FileCont[FIdx].Trim();
                            int DataLen = Convert.ToInt16(ConfigurationSettings.AppSettings["DataLen"].ToString());
                            /*
                            if (DataSend.Length > DataLen)
                            {
                                if (FIdx == 0)
                                    DataSend = DataSend.Substring(DataSend.Length - DataLen, DataLen);
                                else
                                    DataSend = DataSend.Substring(0, DataLen);
                            }
                                //DataSend = DataSend.Substring(0, 9);
                            */
                            if (DataSend.Length > DataLen)
                                DataSend = DataSend.Substring(0, DataLen);


                            CreateLogs("SendData.txt", "Start :" + DataSend, null);

                            if (PrinterList[0].client.Connected == false)
                            {
                                try
                                {
                                    PrinterList[0].StopClient();
                                    CreateLogs("SendData.txt", "stop device", null);
                                }
                                catch (Exception ex11)
                                {
                                    CreateLogs("SendData.txt", "Reconnect device", ex11);
                                }
                                try
                                {
                                    PrinterList[0].StartClient(TxtIPAddr.Text, Convert.ToInt32(TxtPort.Text));
                                    CreateLogs("SendData.txt", "Reconnect device", null);
                                }
                                catch (Exception ex12)
                                {
                                    CreateLogs("SendData.txt", "Reconnect device", ex12);
                                }
                            }

                            if (PrinterList[0].client.Connected)
                            {

                                LblDevStatus.Text = "Connected";
                                LblDevStatus.ForeColor = Color.Green;


                                if (i > 0)
                                {
                                    #region Old LED device code
                                    /*
                                    //timer1.Interval = 5000;
                                    string j = "00000010100500000";
                                    //int m = 7 + i.ToString().Length;
                                    int m = DataSend.ToString().Length;

                                    //myString = j.Remove(j.Length - 2, 2);
                                    //str = myString.Replace(myString, myString + m + "Number " + i + "");

                                    //string k = j.Replace("00000010100500000", "000000101005000" + m + "Number " + i + "");
                                    if (m <= 9)
                                    {
                                        myString = j.Remove(j.Length - 2, 2);
                                        str = myString.Replace(myString, myString + m + DataSend + "");
                                    }

                                    else if (m <= 99)
                                    {
                                        myString = j.Remove(j.Length - 3, 3);
                                        str = myString.Replace(myString, myString + m + DataSend + "");
                                    }

                                    else if (m <= 999)
                                    {
                                        myString = j.Remove(j.Length - 4, 4);
                                        str = myString.Replace(myString, myString + m + DataSend + "");
                                    }

                                    else if (m <= 9999)
                                    {
                                        myString = j.Remove(j.Length - 5, 5);
                                        str = myString.Replace(myString, myString + m + DataSend + "");
                                    }

                                    PrinterList[0].Send(str.ToString().Trim());
                                     * */
                                    #endregion

                                    #region New LED Device code
                                    if (FIdx == 0)
                                    {
                                        string j = "00000011100500000";
                                        int m = DataSend.ToString().Length;
                                        if (m <= 9)
                                        {
                                            myString = j.Remove(j.Length - 2, 2);
                                            str = myString.Replace(myString, myString + m + DataSend + "");
                                        }

                                        else if (m <= 99)
                                        {
                                            myString = j.Remove(j.Length - 3, 3);
                                            str = myString.Replace(myString, myString + m + DataSend + "");
                                        }

                                        else if (m <= 999)
                                        {
                                            myString = j.Remove(j.Length - 4, 4);
                                            str = myString.Replace(myString, myString + m + DataSend + "");
                                        }

                                        else if (m <= 9999)
                                        {
                                            myString = j.Remove(j.Length - 5, 5);
                                            str = myString.Replace(myString, myString + m + DataSend + "");
                                        }
                                    }
                                    else if (FIdx == 1)
                                    {
                                        string j = "10000011100500000";
                                        int m = DataSend.ToString().Length;
                                        if (m <= 9)
                                        {
                                            myString = j.Remove(j.Length - 2, 2);
                                            str = myString.Replace(myString, myString + m + DataSend + "");
                                        }

                                        else if (m <= 99)
                                        {
                                            myString = j.Remove(j.Length - 3, 3);
                                            str = myString.Replace(myString, myString + m + DataSend + "");
                                        }

                                        else if (m <= 999)
                                        {
                                            myString = j.Remove(j.Length - 4, 4);
                                            str = myString.Replace(myString, myString + m + DataSend + "");
                                        }

                                        else if (m <= 9999)
                                        {
                                            myString = j.Remove(j.Length - 5, 5);
                                            str = myString.Replace(myString, myString + m + DataSend + "");
                                        }
                                        //Thread.Sleep(2000);
                                    }
                                    #endregion

                                    PrinterList[0].Send(str.ToString().Trim());

                                    lblcount.Text = DataSend;
                                    this.Refresh();
                                    CreateLogs("SendData.txt", "End :" + DataSend + "," + str, null);
                                    System.Threading.Thread.Sleep(Convert.ToInt32(TxtTimeInterval.Text) * 1000);
                                    //string l = txtData.Text.ToString();
                                    //PrinterList[intCountIp].Send(l.ToString());
                                    //lblcount.Text = "Number " + i + "";                                    
                                    //i++;
                                }

                                //string h = Convert.ToInt16(i++).ToString();
                            }
                            else
                            {
                                LblDevStatus.Text = "DisConnected";
                                LblDevStatus.ForeColor = Color.Red;
                            }
                            CreateLogs("SendData.txt", "DevConn :" + LblDevStatus.Text, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CreateLogs("SendData.txt", "Error :" + DataSend, ex);
                }
            }

            timer1.Enabled = true;

        }

        public static void CreateLogs(string FlName, string LogStr, Exception ex)
        {
            try
            {
                string LogPath = Application.StartupPath + "\\Logs\\" + DateTime.Now.ToString("dd-MMM-yy");

                if (!Directory.Exists(LogPath))
                    Directory.CreateDirectory(LogPath);
                StreamWriter sw = new StreamWriter(LogPath + "\\" + FlName, true);

                LogStr = DateTime.Now.ToString("dd-MMM-yy HH:mm:ss") + "\t" + LogStr;
                if (ex != null)
                {
                    LogStr += ",Err : " + ex.Message;// +", Stack : " + ex.StackTrace;
                }

                sw.WriteLine(LogStr);
                sw.Flush();
                sw.Close();
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrinterList[0] = new AsynchronousClient();
            PrinterList[0].StartClient(TxtIPAddr.Text, Convert.ToInt32(TxtPort.Text));
        }

       

    }
}
