using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Processcsv
{
    class ConfigSettings
    {
        /// <summary>
        /// Gets value shared folder
        /// </summary>
        public static string SharedFolder { get; private set; }
        /// <summary>
        /// Gets value indicating whether process logs are enabled
        /// </summary>
        public static bool WriteProcessLog { get; private set; }
        /// <summary>
        /// Absolute path to the log file
        /// </summary>
        public static string LogPath { get; private set; }
        /// <summary>
        /// Process log file name
        /// </summary>
        public static string ProcessLogFile { get; private set; }
        /// <summary>
        /// Queue refresh timeout
        /// </summary>
        public static double Timeout { get; private set; }
        /// <summary>
        /// Maximum number of simultaneous threads to be allowed
        /// </summary>
        public static int MaxThreads { get; private set; }
        
        public ConfigSettings()
        {
            ReadSetting();
        }

        private static string GetConfigFilePath()
        {
            return @"E:\dotnet\Solutions\NotificationSystem\codeTransformers\Processcsv\bin\Debug\conf.ini";// Assembly.GetExecutingAssembly().Location;
            //string path = Assembly.GetExecutingAssembly().Location;
            //path = path.Substring(0, path.LastIndexOf(@"\") + 1) + @"conf.ini";
            //if (File.Exists(path))
            //    return path;
            //else
            //    throw new Exception("Configuration file missing; make sure conf.ini is available");
        }

        private void ReadSetting()
        {
            string val = string.Empty;
            try
            {
                using (StreamReader conf = File.OpenText(GetConfigFilePath()))
                {
                    while (!conf.EndOfStream)
                    {
                        string line = conf.ReadLine();
                        if (line.Substring(0, 1) == "#")
                        {
                            continue;
                        }
                        string k = line.Substring(0, line.IndexOf("=") - 1);

                        val = line.Substring(line.IndexOf("=") + 2);

                        switch (k.ToLower())
                        {
                            case "sharedfolder":
                                SharedFolder = (val.LastIndexOf("\\") == val.Length) ? val : val + "\\";
                                break;
                            case "writeprocesslog":
                                WriteProcessLog = val == "1" ? true : false;
                                break;
                            case "logpath":
                                LogPath = val;
                                break;
                            case "processlogfile":
                                ProcessLogFile = val;
                                break;
                            case "timeout":
                                try
                                {
                                    Timeout = Convert.ToInt32(val) * 60000;
                                }
                                catch (Exception ex)
                                {
                                    Timeout = 600000; //Default to 10 mins
                                }
                                break;
                            case "maxthreads":
                                try
                                {
                                    if (Convert.ToInt32(val)>10)
                                    {
                                        MaxThreads = 10;
                                    }
                                    else
                                    {
                                        MaxThreads =Convert.ToInt32(val);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MaxThreads = 10; //Default to 10 threads
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

