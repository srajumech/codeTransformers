using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace NotificationSystem
{
    class FileLogger
    {
        //private static LogMode LogLevel = LogMode.VERBOSE;

        public static void LogToFile(string Message)
        {
            bool LogEnabled = ConfigSettings.WriteProcessLog;

            if (LogEnabled == false) return;
            try
            {
                string LogPath = ConfigSettings.LogPath;
                string FileName = ConfigSettings.ProcessLogFile;

                if (!Directory.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }

                if (!File.Exists(LogPath + @"\" + FileName))
                {
                    using (StreamWriter sw = File.CreateText(LogPath + @"\" + FileName))
                    {
                        sw.WriteLine("Module is running on: " + Environment.MachineName + " under the login of: " + Environment.UserDomainName + @"\" + Environment.UserName);
                        sw.WriteLine("[" + Assembly.GetExecutingAssembly().GetName().Name + " v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "]");
                        sw.WriteLine(System.DateTime.Now + " - " + Message);
                        sw.Close();
                        sw.Dispose();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(LogPath + @"\" + FileName))
                    {
                        sw.WriteLine(System.DateTime.Now + " - " + Message);
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        }
    }

