using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MasterControl
{
    public partial class MasterControl : Form
    {
        XmlDocument doc;
        string id;
        ErrorProvider errorProvider = new ErrorProvider();
        public MasterControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (txtName.Text == "")
            {
                errorProvider.SetError(txtName, "Name is required");
                return;
            }
            if (txtEmail.Text == "")
            {
                errorProvider.SetError(txtEmail, "Email is required");
                return;
            }
            Regex rex= new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            if(!rex.IsMatch(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Please enter valid email");
                return;
            }
            string subsName, subsEmail;
            subsName = txtName.Text;
            subsEmail = txtEmail.Text;

            if (btnAdd.Text == "Update")
            {
                doc.Load("D:\\Subscriber.xml");
                XmlNode delNode = doc.SelectSingleNode("//Subscribers/Subscriber/ID[text()='" + id + "']");
                delNode.NextSibling.InnerText = txtName.Text;
                delNode.NextSibling.NextSibling.InnerText = txtEmail.Text;
            }
            else
            {
                XmlElement element = doc.CreateElement("Subscriber");
                XmlElement idNode = doc.CreateElement("ID");
                XmlElement nameNode = doc.CreateElement("SubscriberName");
                XmlElement emailNode = doc.CreateElement("Email");

                idNode.InnerText = Guid.NewGuid().ToString();
                nameNode.InnerText = subsName;
                emailNode.InnerText = subsEmail;

                element.AppendChild(idNode);
                element.AppendChild(nameNode);
                element.AppendChild(emailNode);

                doc.DocumentElement.AppendChild(element);
            }
            doc.Save("D:\\Subscriber.xml");
            BindGrid();
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            btnAdd.Text = "Add";
        }

        private void MasterControl_Load(object sender, EventArgs e)
        {
            doc = new XmlDocument();
            if (File.Exists("D:\\Subscriber.xml"))
            {
                doc.Load("D:\\Subscriber.xml");
            }
            else
            {
                doc.LoadXml("<Subscribers></Subscribers>");
            }
            grdviewSubscriber.AutoGenerateColumns = false;
            grdviewSubscriber.AllowUserToAddRows = false;
            
            grdviewSubscriber.Rows.Clear();
            BindGrid();
            LoadSubsciber();
            grdViewCondition.Rows.Clear();
            LoadSubscriberConditions();
        }
        
     
        private void BindGrid()
        {
            DataSet ds = new DataSet();
            ds.ReadXml("D:\\Subscriber.xml");
            
            if (ds.Tables.Count > 0)
            {
                grdviewSubscriber.DataSource = ds;     
                grdviewSubscriber.DataMember = "Subscriber";
            }
        }
        private void LoadSubsciber()
        {
            DataSet ds = new DataSet();
            ds.ReadXml("D:\\Subscriber.xml");
            if (ds.Tables.Count > 0)
            {
                cmbSubscriber.DataSource = ds.Tables[0];
                cmbSubscriber.DisplayMember = "SubscriberName";
                cmbSubscriber.ValueMember = "ID";
            }

            grdViewCondition.Rows.Clear();
            LoadConditionGrid();
            
        }

        private void LoadConditionGrid()
        {
            try
            {
                DataGridViewTextBoxCell txtValue2 = new DataGridViewTextBoxCell();
                DataGridViewComboBoxCell cmbAndOr = new DataGridViewComboBoxCell();
                string[] arrCondition = new string[] { "And", "Or" };
                cmbAndOr.DataSource = arrCondition;
                string text = File.ReadAllText("D:\\AttributeValue.txt");
                string[] arrValue = text.Split(',');                          
                
                DataGridViewComboBoxCell CmbattributeValue = new DataGridViewComboBoxCell();
                CmbattributeValue.DataSource = arrValue;

                DataGridViewComboBoxCell cmbConditions = new DataGridViewComboBoxCell();

                string[] conditions = new string[] { "=", "<", "<=", ">", ">=", "like" };
                cmbConditions.DataSource = conditions;

                DataGridViewTextBoxCell txtValue1 = new DataGridViewTextBoxCell();
                DataGridViewButtonCell button = new DataGridViewButtonCell();
                button.Value = "+";

                DataGridViewRow row = new DataGridViewRow();
                if (grdViewCondition.Rows.Count == 1)
                {
                    row.Cells.Add(txtValue2);
                    row.Cells[0].ReadOnly = true;
                }
                else
                {
                    row.Cells.Add(cmbAndOr);
                }
                row.Cells.Add(CmbattributeValue);
                row.Cells.Add(cmbConditions);
                
                //row.Cells.Add(txtValue1);
                grdViewCondition.Rows.Add(row);
            }
            catch (Exception ex)
            {

            }
        }

       

        private void grdviewSubscriber_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdviewSubscriber.Rows[e.RowIndex].Cells[0].Value != null)
            {
                id = grdviewSubscriber.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = grdviewSubscriber.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEmail.Text = grdviewSubscriber.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (e.ColumnIndex == 3)
                {
                    btnAdd.Text = "Update";
                }
                if (e.ColumnIndex == 4)
                {
                    grdviewSubscriber.Rows.RemoveAt(e.RowIndex);
                    deleteNode(id);
                }
            }
        }

        void deleteNode(string id)
        {
           doc.Load("D:\\Subscriber.xml"); 
           XmlNode delNode = doc.SelectSingleNode("//Subscribers/Subscriber/ID[text()='" + id + "']");
           doc.DocumentElement.RemoveChild(delNode.ParentNode);
           doc.Save("D:\\Subscriber.xml");
           
           BindGrid();
           txtName.Text = string.Empty;
           txtEmail.Text = string.Empty;
        }

        private void grdViewCondition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                LoadConditionGrid();
            }
            else if (e.ColumnIndex == 5)
            {
                if (e.RowIndex != 0)
                {
                    grdViewCondition.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string condition = string.Empty;
            string conditionwithLimiter = string.Empty;
            for (int i = 0; i < grdViewCondition.Rows.Count-1; i++)
            {
                if(i != 0)
                {
                    DataGridViewComboBoxCell cmbAndOr = (DataGridViewComboBoxCell)grdViewCondition.Rows[i].Cells[0];
                    condition += cmbAndOr.Value + " ";
                    conditionwithLimiter += cmbAndOr.Value + "|";
                }
                DataGridViewComboBoxCell cmbattribute = (DataGridViewComboBoxCell)grdViewCondition.Rows[i].Cells[1];
                condition += cmbattribute.Value+ " ";
                conditionwithLimiter += cmbattribute.Value + "|";
                DataGridViewComboBoxCell cmbCondition = (DataGridViewComboBoxCell)grdViewCondition.Rows[i].Cells[2];
                condition += cmbCondition.Value + " ";
                conditionwithLimiter += cmbCondition.Value + "|";
                DataGridViewTextBoxCell txtValue = (DataGridViewTextBoxCell)grdViewCondition.Rows[i].Cells[3];
                condition += txtValue.Value + " ";
                conditionwithLimiter += txtValue.Value + "||";
            }

            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\Subscriber.xml");
            string id = cmbSubscriber.SelectedValue.ToString();
            XmlNode subsNode = doc.SelectSingleNode("//Subscribers/Subscriber/ID[text()='" + id + "']");
            XmlNode nodeCondition = subsNode.ParentNode.SelectSingleNode("Condition");
            if (nodeCondition != null)
            {
                nodeCondition.InnerText = condition;
            }
            else
            {
                nodeCondition = doc.CreateElement("Condition");
                nodeCondition.InnerText = condition;
            }
            XmlNode nodeConditionLimiter = subsNode.ParentNode.SelectSingleNode("ConditionLimiter");
            if (nodeConditionLimiter != null)
            {
                nodeConditionLimiter.InnerText = conditionwithLimiter;
            }
            else
            {
                nodeConditionLimiter = doc.CreateElement("ConditionLimiter");
                nodeConditionLimiter.InnerText = condition;
            }
            
            subsNode.ParentNode.AppendChild(nodeCondition);
            subsNode.ParentNode.AppendChild(nodeConditionLimiter);
            doc.Save("D:\\Subscriber.xml");
        }

        private void cmbSubscriber_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdViewCondition.Rows.Clear();

            LoadSubscriberConditions();
        }

        private void LoadSubscriberConditions()
        {
            doc.Load("D:\\Subscriber.xml");
            string id = cmbSubscriber.SelectedValue.ToString();
            XmlNode subsNode = doc.SelectSingleNode("//Subscribers/Subscriber/ID[text()='" + id + "']");
            if (subsNode != null)
            {
                XmlNode nodeCondition = subsNode.ParentNode.SelectSingleNode("ConditionLimiter");
                if (nodeCondition != null)
                {
                    string condition = nodeCondition.InnerText;
                    string[] arrCondition = condition.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string str in arrCondition)
                    {
                        string[] s = str.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            DataGridViewTextBoxCell txtValue2 = new DataGridViewTextBoxCell();
                            DataGridViewComboBoxCell cmbAndOr = new DataGridViewComboBoxCell();
                            string[] arrAndOr = new string[] { "And", "Or" };
                            cmbAndOr.DataSource = arrAndOr;

                            string text = File.ReadAllText("D:\\AttributeValue.txt");
                            string[] arrValue = text.Split(',');

                            DataGridViewComboBoxCell CmbattributeValue = new DataGridViewComboBoxCell();
                            CmbattributeValue.DataSource = arrValue;
                            DataGridViewComboBoxCell cmbConditions = new DataGridViewComboBoxCell();

                            string[] conditions = new string[] { "=", "<", "<=", ">", ">=", "like" };
                            cmbConditions.DataSource = conditions;
                            DataGridViewTextBoxCell txtValue1 = new DataGridViewTextBoxCell();
                            DataGridViewButtonCell button = new DataGridViewButtonCell();
                            button.Value = "+";

                            if (s[0] == "And" || s[0] == "Or")
                            {
                                cmbAndOr.Value = s[0];
                                CmbattributeValue.Value = s[1];
                                cmbConditions.Value = s[2];
                                txtValue1.Value = s[3];

                            }
                            else
                            {
                                CmbattributeValue.Value = s[0];
                                cmbConditions.Value = s[1];
                                txtValue1.Value = s[2];
                            }
                            DataGridViewRow row = new DataGridViewRow();
                            if (grdViewCondition.Rows.Count == 1)
                            {
                                row.Cells.Add(txtValue2);
                                row.Cells[0].ReadOnly = true;
                            }
                            else
                            {
                                row.Cells.Add(cmbAndOr);
                            }
                            row.Cells.Add(CmbattributeValue);
                            row.Cells.Add(cmbConditions);
                            row.Cells.Add(txtValue1);
                            grdViewCondition.Rows.Add(row);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else
                {
                    LoadConditionGrid();
                }
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            if (tabControl.SelectedTab.Name == "tabConfiguration")
            {
                LoadSubsciber();
                LoadSubscriberConditions();
            }

            if (tabControl.SelectedTab.Name == "tabMasterControl")
            {
                ReadSetting();
            }
        }

        private static string GetConfigFilePath()
        {
            string path = Assembly.GetExecutingAssembly().Location;
            path = path.Substring(0, path.LastIndexOf(@"\") + 1) + @"conf.ini";
            if (File.Exists(path))                    
                return path;
            else 
                using(StreamWriter writer = File.CreateText(path))
                {

                }
            return path;
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
                            //case "writeprocesslog":
                            //    WriteProcessLog = val == "1" ? true : false;
                            //    break;
                            case "sharedcsvpath":
                                txtSharedPath.Text = val;
                                break;
                            case "logpath":
                                txtLogFilePath.Text = val;
                                break;
                            case "processlogfile":
                                txtLogFileName.Text = val;
                                break;
                            //case "timeout":
                            //    try
                            //    {
                            //        Timeout = Convert.ToInt32(val) * 60000;
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        Timeout = 600000; //Default to 10 mins
                            //    }
                            //    break;
                            case "maxthreads":
                                try
                                {
                                    if (Convert.ToInt32(val) > 10)
                                    {
                                        txtMaxThreads.Text = 10.ToString();
                                    }
                                    else
                                    {
                                        txtMaxThreads.Text = Convert.ToInt32(val).ToString();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    txtMaxThreads.Text = 10.ToString(); //Default to 10 threads
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

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if(File.Exists(GetConfigFilePath()))
            {
                File.Delete(GetConfigFilePath());
            }
            
            using(StreamWriter writer = new StreamWriter(GetConfigFilePath()))
            {
                writer.WriteLine("#Shared CSV Path");
                writer.WriteLine("SharedCSVPath = " + txtSharedPath.Text);
                writer.WriteLine("#Log File Path");
                writer.WriteLine("logpath = " + txtLogFilePath.Text);
                writer.WriteLine("#Maximun number of simultaneous threads to be allowed");
                writer.WriteLine("MaxThreads = " + txtMaxThreads.Text);
                writer.WriteLine("#Process log File Name");
                writer.WriteLine("processlogfile = " + txtLogFileName.Text);
            }
        }     

   }
}
