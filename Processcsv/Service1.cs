using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
namespace Processcsv
{
    public partial class Service1 : ServiceBase
    {
        csvhelper processcsv = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            FileLogger.LogToFile("Started");
            eventLog1.WriteEntry("Processing of CSV file service started");
            ConfigSettings config = new ConfigSettings();
            interval.Interval = 10; //allow 10 seconds for the service to start up
            interval.Enabled = true;
            if (processcsv == null)
                processcsv = new csvhelper();
            processcsv.OnThreadComplete += new EventHandler(processcsv_OnThreadComplete);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Processing of CSV file service has been stopped");
        }

        private void interval_Elapsed(object sender, ElapsedEventArgs e)
        {
            FileLogger.LogToFile( "Refreshing the queue");
            csvhelper.Queue.Clear();
            csvlist lsfiles = new csvlist();
            //DownloadHelper.Queue = DataAccess.GetSourceMaps("test");
            csvhelper.Queue = lsfiles.getcsvFiles(ConfigSettings.SharedFolder);
            double WaitTime = ConfigSettings.Timeout;
            interval.Interval = WaitTime;
            interval.Enabled = false;
            //Event based QueueProcessor - Start
            ProcessQueue();
            //Event based QueueProcessor - End
            FileLogger.LogToFile( "Queue processor started...");
            FileLogger.LogToFile( "Queue : " + csvhelper.Queue.Count);
        }


        //Event based QueueProcessor - Start
        private void ProcessQueue()
        {
            processcsv.Process(csvhelper.Queue);
                      
        }

        void processcsv_OnThreadComplete(object sender, EventArgs e)
        {
            
                FileLogger.LogToFile("Done with this pass, will wait for the execution interval.");
                interval.Enabled = true;
           
        }
    }
}
