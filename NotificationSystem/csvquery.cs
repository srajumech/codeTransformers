using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data;
namespace NotificationSystem
{
    class csvquery
    {
        private int _colNum;
        private string _csvpath;
        public int colNum
        {
            get { return _colNum; }
            set { _colNum = value; }
        }
        public string csvpath
        {
            get { return _csvpath; }
            set { _csvpath = value; }
        }
        public csvquery(string file)
        {
            try
            {
                csvpath = file;
            }
            catch (Exception ex)
            {
                FileLogger.LogToFile("Exception: " + ex.Message);
            }
        }
        public int getnumberofcolumns()
        {

            using (StreamReader conf = File.OpenText(csvpath))
            {
                try
                {
                    colNum = conf.ReadLine().Split(',').Length;
                }
                catch (Exception ex)
                {
                    FileLogger.LogToFile("Exception: " + ex.Message);
                }

            }

            return colNum;
        }
        public List<string> getdistinctattribute()
        {
            List<string> columnnms = new List<string>();
            using (StreamReader conf = File.OpenText(csvpath))
            {
                try
                {
                    while (!conf.EndOfStream)
                    {
                        string line = conf.ReadLine();
                        if (line.Split(',').Length == 3)
                        {
                            if (columnnms.Contains(line.Split(',')[1].ToString().ToLower()))
                            {
                            }
                            else
                            {
                                columnnms.Add(line.Split(',')[1].ToString().ToLower());
                            }

                        }
                    }
                    return columnnms;
                }
                catch (Exception ex)
                {
                    FileLogger.LogToFile("Exception in Getting list of attributes: " + ex.Message);
                }

            }
            return columnnms;
        }
        public DataTable convertcsvtodt(List<string> dtattributes)
        {
            dtattributes.Sort();
            DataTable dt = new DataTable();
            dt.Columns.Add("item");
            foreach (string col in dtattributes)
            {
                dt.Columns.Add(col);
            }

            using (StreamReader conf = File.OpenText(csvpath))
            {
                while (!conf.EndOfStream)
                {
                    bool exist = false;
                    string line = conf.ReadLine();
                    var results = from myRow in dt.AsEnumerable()
                                  where myRow.Field<string>("item") == line.Split(',')[0]
                                  select myRow;

                    foreach (DataRow rw in results)
                    {
                        exist = true;
                        dt.Select(string.Format("[item] = '{0}'", Convert.ToInt32(line.Split(',')[0]))).ToList<DataRow>()
     .ForEach(r =>
     {
         r[line.Split(',')[1]] = line.Split(',')[2];
     });
                    }
                    if (!exist)
                    {
                        DataRow dr = dt.NewRow();
                        dr["item"] = Convert.ToInt32(line.Split(',')[0]);
                        dr[line.Split(',')[1]] = line.Split(',')[2];
                        dt.Rows.Add(dr);
                    }
                }

            }
            return dt;
        }
    }

}
