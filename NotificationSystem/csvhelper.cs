using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Data;
namespace NotificationSystem
{
    class sourcefiles
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _filenm;
        private int _threadnum;
        private bool _started;
        public int threadnum
        {
            get { return _threadnum; }
            set { _threadnum = value; }
        }
        public bool started
        {
            get { return _started; }
            set { _started = value; }
        }
        private DateTime  _lastdt;
        public DateTime lastdt
        {
            get { return _lastdt; }
            set { _lastdt = value; }
        }
        public string filenm
        {
            get { return _filenm; }
            set { _filenm = value; }
        }
    }
    class csvlist
    {
        public List<sourcefiles> getcsvFiles(string path)
        {
            List<sourcefiles> lscsvfiles = new List<sourcefiles>();
            string[] lsfiles =  Directory.GetFiles(path, "*.csv");
            foreach (string file in lsfiles)
            {
                sourcefiles filedt = new sourcefiles();
                filedt.name = file.Substring(file.LastIndexOf(@"\"), file.LastIndexOf(@".") - file.LastIndexOf(@"\"));
                filedt.filenm = file;
                filedt.lastdt = File.GetLastAccessTime(file);
                filedt.started = false;
                lscsvfiles.Add(filedt);
            }
            return lscsvfiles;
        }
    }
    class csvhelper
    {
        public event EventHandler OnThreadComplete;

        public static int RunningProcesses = 0;

        public static List<sourcefiles> Queue = new List<sourcefiles>();

        private const int MAX_CHILD_THREADS = 10;

        /// <summary>
        /// Semaphore object for thread safty
        /// </summary>
        static readonly object locker = new object();

        public void Process(List<sourcefiles> item)
        {
            csvhelper objCH = new csvhelper();
            objCH.OnThreadComplete += new EventHandler(obj_OnThreadComplete);
            Thread worker = new Thread(objCH.DoWork);
            //worker.Name = item.Source;
            

            worker.Start(item);
        }
        public void DoWork(object data)
        {
            try
            {
                WriteLog("Running processes: " + csvhelper.RunningProcesses);

                List<sourcefiles> param = (List<sourcefiles>)data;
                int numoffiles = param.Count;
                int numoffileperthread = 0;
                int Remfile = 0;
                int Max_Threads = ConfigSettings.MaxThreads;
                int req_Threads = 0;
                WriteLog("Maximum Threads" + Max_Threads);
                if (numoffiles > Max_Threads)
                {
                    req_Threads = Max_Threads;
                    numoffileperthread = numoffiles / req_Threads;
                    Remfile = numoffiles % req_Threads;
                    WriteLog("Required Threads" + Max_Threads+" And Number of files per thread:"+ numoffileperthread );
                }
                else
                {
                    req_Threads = numoffiles;
                    numoffileperthread = numoffiles;
                }
                
                List<Thread> childThreads = new List<Thread>();

                if (req_Threads > 0)
                {
                    WriteLog("processing starts" + " file(s)...");

                    try
                    {
                        WriteLog(req_Threads + " threads will be created");
                        for (int i = 0; i < req_Threads; i++)
                        {
                            int StartIndex, EndIndex,threadnum;
                            List<object> childParam = new List<object>();
                            childParam.Add(param);
                            if (i == req_Threads  - 1)
                            {
                                StartIndex = i * numoffileperthread ;
                                EndIndex = StartIndex +numoffileperthread+ Remfile - 1;
                            }
                            else
                            {
                                StartIndex = i * numoffileperthread;
                                EndIndex = StartIndex + (numoffileperthread - 1);
                            }
                            WriteLog(i + " thread is created with start index: "+StartIndex +" End index :"+EndIndex );
                            threadnum = csvhelper.RunningProcesses + 1;
                            childParam.Add(StartIndex);
                            childParam.Add(EndIndex);
                            childParam.Add(threadnum);
                            Thread childThread = new Thread(ProcessFiles);
                            childThread.Start(childParam);
                            childThreads.Add(childThread);
                            csvhelper.RunningProcesses += 1;
                        }
                        
                        //wait for each thread to complete
                        foreach (Thread t in childThreads)
                        {
                            t.Join();
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error in Thread management");
                    }
                }
                else
                {
                    WriteLog("There are no files to be processed!");
                }
            }
            catch (Exception ex)
            {
                WriteLog("[ERROR]: " + ex.Message);
                return;
            }
            finally
            {
                //Do not allow simultaneous manipulation of shared object
                lock (locker)
                {
                    WriteLog( "Thread exited: " + Thread.CurrentThread.Name);
                    csvhelper.RunningProcesses -= 1;
                    if (OnThreadComplete != null)
                        OnThreadComplete(this, new EventArgs());
                }
            }
        }

        private void ProcessFiles(object data)
        {
            List<object> param = (List<object>)data;
            List<sourcefiles> filecol = (List<sourcefiles>) param[0];
            int StartIndex = (int)param[1];
            int EndIndex = (int)param[2];
            int threadnum = (int)param[3];
            for (int i = StartIndex ;i<=EndIndex ;i++)
            {
                csvquery query = new csvquery(filecol[i].filenm);
                WriteLog("Number of Attributes"+query.getnumberofcolumns().ToString());
                List<string> attr = query.getdistinctattribute();
                DataTable dt = query.convertcsvtodt(attr);
                //WriteLog("Thread number: " + filecol[i].threadnum );
                using (StreamWriter sw = File.CreateText(@"C:\Raja\" + filecol[i].name +".txt" ))
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        string line="";
                        foreach (string col in attr)
                        {
                            line = line+col + " : " + dr[col].ToString()+"\n";
                            
                        }
                        sw.WriteLine(line);
                        WriteLog("Thread number: " + threadnum + " --> " + line);
                    }
                }
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
        private void WriteLog(string msg)
        {
            lock (locker)
            {
                FileLogger.LogToFile(msg);
            }
        }
        void obj_OnThreadComplete(object sender, EventArgs e)
        {
            OnThreadComplete(sender, e);
        }
    }
}


