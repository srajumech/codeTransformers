//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net.Mail;
//using System.IO;
//using System.Xml;
//using Broadcast;
//namespace NotificationSystem
//{
//    class MailNotification
//    {
//        static INotificationCenter notificationCenter;
//        public static void main()
//        {
//            MailNotification obj = new MailNotification();
//            obj.ReadUserNotification();
//        }
//        public MailNotification()
//        {
//            // Arrange
//            notificationCenter = new NotificationManager();

//            // Act
//        }
//        public void ReadUserNotification()
//        {
//            //  var headquarters = new Headquarter(new NotificationManager());

//            XmlDocument xmldoc = new XmlDocument();
//            XmlNodeList xmlnode;
//            int i = 0;
//            string str = null;
//            FileStream fs = new FileStream("Subscriber.xml", FileMode.Open, FileAccess.Read);
//            xmldoc.Load(fs);
//            xmlnode = xmldoc.GetElementsByTagName("//Subscribers/Subscriber");
//            string subscriberName;
//            string subscriberEmail;
//            string condition;
//            for (i = 0; i <= xmlnode.Count - 1; i++)
//            {
//                subscriberName = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
//                subscriberEmail = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
//                condition = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
//                //subscriber Event
//                notificationCenter.Subscribe<BroadcastMessage<string>>(
//                   (message, sub) =>
//                   {
//                       Console.WriteLine(message.Content);
//                   });

//                //str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + "  " + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + "  " + xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
//                //MessageBox.Show(str);
//            }

//        }


//        public void Send(string server, int port, bool secure, string username, string password, string fromAddress, List<string> addressesTo, string subject, string body, MemoryStream attachment)
//        {
//            MailMessage msg = new MailMessage();
//            msg.IsBodyHtml = true;
//            msg.Subject = subject;
//            msg.Body = body;
//            foreach (string address in addressesTo)
//                msg.To.Add(address);
//            msg.From = new MailAddress(fromAddress);

//            SmtpClient client = new SmtpClient();
//            client.Host = server;
//            client.Port = port;
//            client.EnableSsl = secure;
//            if (username != "" || password != "")
//            {
//                client.UseDefaultCredentials = false;
//                client.Credentials = new System.Net.NetworkCredential(username, password);
//            }
//            else
//            {
//                client.UseDefaultCredentials = true;
//            }
//            client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);

//            //Log.Debug("MailBody", body);
//            //System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Octet);
//            Attachment att = new Attachment(attachment, "BatchList.xls", System.Net.Mime.MediaTypeNames.Application.Octet);

//            msg.Attachments.Add(att);

//            client.SendAsync(msg, new object());
//        }

//        void client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
//        {
//            if (e.Error != null)
//            {
//                FileLogger.LogToFile("Unable to send notification mail - " + e.Error.Message);
//            }
//            else
//            {
//                FileLogger.LogToFile("Notification mail sent.");
//            }
//        }
//    }
//}