using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Replace_data_print.DAL;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;


namespace Replace_data_print
{
    public class BAL : DAL.IFetchData
    {
       public DataSet FetchData()
        {
            DataSet MsDataSet = new DataSet();
            DataSet MsData = new DataSet();
            string asa = "", Pname = "";
            int id;
            try
            {
                MsDataSet = SqlHelper.ExecuteDataset("SP_FETCHDATA", "1", "PRN_NAME='Print_data'");
                string prnName = MsDataSet.Tables[0].Rows[0]["PRN_DETAILS"].ToString();
                string prn1 = prnName;
                asa = prn1;
                MsData = SqlHelper.ExecuteDataset("SP_FETCH_DATA_TO_PRINT");
                string output = "";
                output = MsData.Tables[0].Rows[0]["ID"].ToString();

                foreach (DataRow bufferrow in MsData.Tables[0].Rows)
                {
                    foreach (DataColumn col in MsData.Tables[0].Columns)
                    {

                        if (output.ToString() == Convert.ToInt16(1).ToString())
                        {
                            id = Convert.ToInt32(MsData.Tables[0].Rows[0]["ID"]);
                        }
                        else
                        {
                            id = Convert.ToInt32(MsData.Tables[0].Rows[1]["ID"]);
                        }

                        int i;
                        for (i = 0; i <= Convert.ToInt32(id) - 1; i++)
                        {
                            asa = asa.Replace("<<ID>>", MsData.Tables[0].Rows[i]["ID"].ToString());
                            asa = asa.Replace("<<Field1>>", MsData.Tables[0].Rows[i]["Field1"].ToString());
                            asa = asa.Replace("<<Field2>>", MsData.Tables[0].Rows[i]["Field2"].ToString());
                            asa = asa.Replace("<<Field3>>", MsData.Tables[0].Rows[i]["Field3"].ToString());
                            asa = asa.Replace("<<Field4>>", MsData.Tables[0].Rows[i]["Field4"].ToString());

                            if (File.Exists("D:\\output.txt"))
                            {
                                File.Delete("D:\\output.txt");
                            }

                            FileInfo file1 = new FileInfo("D:\\output.txt");
                            StreamWriter sw;
                            sw = file1.CreateText();
                            sw.Write(asa);
                            sw.Close();

                            if (Pname == null || Pname == "")
                            {
                                PrintDialog pd = new PrintDialog();
                                pd.PrinterSettings = new PrinterSettings();
                                if (DialogResult.OK == pd.ShowDialog(Replace_data_print.Form1.ActiveForm))
                                {
                                    Pname = pd.PrinterSettings.PrinterName.ToString();
                                }
                            }
                        }


                    }

                }
                return MsDataSet;
            }

            catch (System.Exception ex)
            {
                throw (ex);
            }
            
        }
      
    }
}
    
   

