using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace NotificationSystem
{
    public class CSVConnectionParam
    {
        public string connectionstring = "";
        public static string xlsconnection = "Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;";
        public static string xlsxconnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;";
        public static string csvconnection ="Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"text;HDR=Yes;FMT=Delimited\";";
        /// <summary>
        /// Constructor for the Connection string Builder.
        /// </summary>
        /// <param name="filetype"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public CSVConnectionParam(string filetype, string filepath)
        {
            try
            {
                if (filetype == "csv")
                {
                    connectionstring = string.Format(csvconnection, filepath);
                }
                else
                {
                    connectionstring = "Not Valid File Type";
                }
            }
            catch (Exception ex1)
            {
                connectionstring = "Exception : " + ex1.Message;
            }
            //return connection;
        }
    }
    public class CSVread
    {
       
        /// <summary>
        /// Gets the List of the Tables in the Excel Sheet
        /// </summary>
        /// <param name="excelconnection"></param>
        /// <returns></returns>
        public List<string> getTablesInExcel(string excelconnection)
        {
            List<string> TableList = new List<string>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(excelconnection))
                {
                    connection.Open();
                    DataTable dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    foreach (DataRow row in dt.Rows)
                        TableList.Add(row["TABLE_NAME"].ToString());
                    connection.Close();
                }
            }
            catch (OleDbException oex1)
            {
                throw oex1;
            }
            return TableList;
        }

        /// <summary>
        /// Gets the Data in the Excel sheet with Column Names 
        /// </summary>
        /// <param name="excelconnection"></param>
        /// <param name="excelsheetname"></param>
        /// <param name="columnames">Default</param>
        /// <returns></returns>
        public DataTable getDataInExcelSheet(string excelconnection, string excelsheetname, string columnames = "*", string wherecondition = "")
        {
            DataTable data = new DataTable();
            string query = string.Format("SELECT {1} FROM [{0}] ", excelsheetname, columnames);
            if (wherecondition != "") query = query + " where " + wherecondition;
            try
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, excelconnection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, excelsheetname);
                    data = ds.Tables[excelsheetname];
                }
            }
            catch (OleDbException oex1)
            {
                throw oex1;
            }
            return data;
        }        
    }
}
