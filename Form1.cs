using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Replace_data_print.DAL;
using System.IO;
using System.Configuration;
using System.Threading;

namespace Replace_data_print
{
    public partial class Form1 : Form
    {
        BAL obj = new BAL();
        DataSet MsDataDELETE = new DataSet();
        DataSet MsDataSet = new DataSet();
        DataSet MsData = new DataSet();
        string Pname = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        public void  FetchData()
        {
            try
            {
                MsDataSet = SqlHelper.ExecuteDataset("SP_FETCHDATA", "1", "PRN_NAME='Print_data1'");
              
                MsData = SqlHelper.ExecuteDataset("SP_FETCH_DATA_TO_PRINT");
                
                DataTable dtBuffer = new DataTable();
                dtBuffer = MsData.Tables[0];
                DataRow[] rowbuffer = null;
                
                    for(int i =1 ;i <= dtBuffer.Rows.Count;i++)
                    {
                       
                        if (rowbuffer == null)
                        {
                            rowbuffer = dtBuffer.Select("IDNew = '" + i + "'");                            
                        }
                        else
                        {
                            rowbuffer = dtBuffer.Select("IDNew = '" + i + "'");
                           
                            MsDataDELETE = SqlHelper.ExecuteDataset("SP_DELETE_DATA");
                        }

                        foreach(DataRow row in rowbuffer)
                        {
                         string prnName = MsDataSet.Tables[0].Rows[0]["PRN_DETAILS"].ToString();
                         prnName = prnName.Replace("<<ID>>", row[0].ToString());
                         prnName = prnName.Replace("<<Field1>>", row[1].ToString());
                         prnName = prnName.Replace("<<Field2>>", row[2].ToString());
                         prnName = prnName.Replace("<<Field3>>", row[3].ToString());
                         prnName = prnName.Replace("<<Field4>>", row[4].ToString());

                         PrinterReadyNess.IPPrint objIPPrint = new PrinterReadyNess.IPPrint();
                         //objIPPrint.Print("192.168.11.13", prnName, "121");
                         objIPPrint.Print("192.168.11.200", prnName, "1000");

                                 //string strIp = ConfigurationSettings.AppSettings["PrinteIp"].ToString();
                                 //string strPort = ConfigurationSettings.AppSettings["PrinterPort"].ToString();
                                 //PrinterReadyNess.IPPrint objIPPrint = new PrinterReadyNess.IPPrint();
                                 //objIPPrint.Print(strIp, prnName, strPort);

                          //printDataOnPrinter(prnName);
                          Thread.Sleep(800);

                          DataSet MsDataInsert = new DataSet();
                          MsDataInsert = SqlHelper.ExecuteDataset("SP_INSERT_PRINTED_DATA", row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14], row[15], row[16], row[17], row[18], row[19], row[20], row[21]);
                        }
                            
                    }
                          MsDataDELETE = SqlHelper.ExecuteDataset("SP_DELETE_DATA");
                    }

            catch (System.Exception ex)
            {
                throw (ex);
            }

        }

        //private void printDataOnPrinter(string printText)
        //{

        //    if (Pname == null || Pname == "")
        //    {
        //        PrintDialog pd = new PrintDialog();
        //        pd.PrinterSettings = new PrinterSettings();
        //        if (DialogResult.OK == pd.ShowDialog(this))
        //        {
        //            Pname = pd.PrinterSettings.PrinterName.ToString();
        //        }
        //    }

        //    if (Pname == null || Pname == "")
        //    {
        //        MessageBox.Show("Printer Not Selected");
        //        return;
        //    }

        //    if (File.Exists(Application.StartupPath + "\\output.txt"))
        //    {
        //        File.Delete(Application.StartupPath + "\\output.txt");
        //    }
        //    File.WriteAllText(Application.StartupPath + "\\output.txt", printText);
        //    String str1 = Application.StartupPath + "\\output.txt";
        //    RawPrinterHelper.SendFileToPrinter(Pname, str1);
        //    Thread.Sleep(800);
        //}
    }
      
    }

