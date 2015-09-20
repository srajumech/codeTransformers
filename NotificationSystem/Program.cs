using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using MongoDB.Bson;
namespace NotificationSystem
{
    class Program
    {
        static csvhelper processcsv = null;
        static void Main(string[] args)
        {
            
            FileLogger.LogToFile("Started");
            ConfigSettings config = new ConfigSettings();
           
            if (processcsv == null)
                processcsv = new csvhelper();
            processcsv.OnThreadComplete += new EventHandler(processcsv_OnThreadComplete);
            csvhelper.Queue.Clear();
            csvlist lsfiles = new csvlist();
            //DownloadHelper.Queue = DataAccess.GetSourceMaps("test");
            csvhelper.Queue = lsfiles.getcsvFiles(ConfigSettings.SharedFolder);
            ProcessQueue();
            //Event based QueueProcessor - End
            FileLogger.LogToFile("Queue processor started...");
            FileLogger.LogToFile("Queue : " + csvhelper.Queue.Count);
            //ConfigSettings config = new ConfigSettings();
            //csvlist lsfiles = new csvlist();
            //List<sourcefiles> csvfiles = lsfiles.getcsvFiles(ConfigSettings.SharedFolder);
            //csvquery query = new csvquery(@"E:\Testing\Hackathon\CSVFileInput\file1.csv");
            //Console.WriteLine(query.getnumberofcolumns());
            //List<string> attr = query.getdistinctattribute();
            //DataTable dt = query.convertcsvtodt(attr); 
            
            //foreach (DataRow dr in dt.Rows)
            //{
                
            //    var document = new BsonDocument();
            //    document.Add("item",dr["item"].ToString()) ;
            //    foreach(string col in attr)
            //    {
            //        var element = new BsonElement(col, dr[col].ToString());
            //        document.Add(element);
            //    }
            //    Console.WriteLine(document);
            //}

        }
        static private void ProcessQueue()
        {
            processcsv.Process(csvhelper.Queue);

        }

        static void processcsv_OnThreadComplete(object sender, EventArgs e)
        {

            FileLogger.LogToFile("Done with this pass, will wait for the execution interval.");
           

        }
    }
}
