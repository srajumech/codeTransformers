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
        static void Main(string[] args)
        {
            ConfigSettings config = new ConfigSettings();
            CSVConnectionParam connection = new CSVConnectionParam("csv", @"E:\Testing\Hackathon\CSVFileInput\file1.csv");
            csvquery query = new csvquery(@"E:\Testing\Hackathon\CSVFileInput\file1.csv");
            Console.WriteLine(query.getnumberofcolumns());
            List<string> attr = query.getdistinctattribute();
            DataTable dt = query.convertcsvtodt(attr); 
            
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
    }
}
