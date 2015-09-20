namespace MasterControl
{
    partial class MasterControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.grdViewCondition = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSubscriber = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabSubscriber = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grdviewSubscriber = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubscriberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnkEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lnkDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tabMasterControl = new System.Windows.Forms.TabPage();
            this.txtMaxThreads = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLogFileName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLogFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSharedPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewCondition)).BeginInit();
            this.tabSubscriber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdviewSubscriber)).BeginInit();
            this.tabMasterControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConfiguration);
            this.tabControl1.Controls.Add(this.tabSubscriber);
            this.tabControl1.Controls.Add(this.tabMasterControl);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(966, 478);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.btnSave);
            this.tabConfiguration.Controls.Add(this.grdViewCondition);
            this.tabConfiguration.Controls.Add(this.label3);
            this.tabConfiguration.Controls.Add(this.cmbSubscriber);
            this.tabConfiguration.Controls.Add(this.label2);
            this.tabConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguration.Size = new System.Drawing.Size(958, 452);
            this.tabConfiguration.TabIndex = 0;
            this.tabConfiguration.Text = "Configuration";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(149, 246);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdViewCondition
            // 
            this.grdViewCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewCondition.ColumnHeadersVisible = false;
            this.grdViewCondition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.grdViewCondition.Location = new System.Drawing.Point(149, 70);
            this.grdViewCondition.Name = "grdViewCondition";
            this.grdViewCondition.Size = new System.Drawing.Size(547, 150);
            this.grdViewCondition.TabIndex = 7;
            this.grdViewCondition.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdViewCondition_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.Text = "+";
            this.Column5.UseColumnTextForButtonValue = true;
            this.Column5.Width = 40;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.Text = "Delete";
            this.Column6.UseColumnTextForButtonValue = true;
            this.Column6.Width = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Condition";
            // 
            // cmbSubscriber
            // 
            this.cmbSubscriber.FormattingEnabled = true;
            this.cmbSubscriber.Location = new System.Drawing.Point(149, 31);
            this.cmbSubscriber.Name = "cmbSubscriber";
            this.cmbSubscriber.Size = new System.Drawing.Size(121, 21);
            this.cmbSubscriber.TabIndex = 1;
            this.cmbSubscriber.SelectedIndexChanged += new System.EventHandler(this.cmbSubscriber_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Subscriber";
            // 
            // tabSubscriber
            // 
            this.tabSubscriber.Controls.Add(this.btnAdd);
            this.tabSubscriber.Controls.Add(this.txtEmail);
            this.tabSubscriber.Controls.Add(this.label1);
            this.tabSubscriber.Controls.Add(this.lblName);
            this.tabSubscriber.Controls.Add(this.txtName);
            this.tabSubscriber.Controls.Add(this.grdviewSubscriber);
            this.tabSubscriber.Location = new System.Drawing.Point(4, 22);
            this.tabSubscriber.Name = "tabSubscriber";
            this.tabSubscriber.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubscriber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabSubscriber.Size = new System.Drawing.Size(958, 452);
            this.tabSubscriber.TabIndex = 1;
            this.tabSubscriber.Text = "Subscriber";
            this.tabSubscriber.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(363, 77);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(83, 77);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(260, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(17, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 18);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 20);
            this.txtName.TabIndex = 1;
            // 
            // grdviewSubscriber
            // 
            this.grdviewSubscriber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdviewSubscriber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SubscriberName,
            this.Email,
            this.lnkEdit,
            this.lnkDelete});
            this.grdviewSubscriber.Location = new System.Drawing.Point(20, 124);
            this.grdviewSubscriber.Name = "grdviewSubscriber";
            this.grdviewSubscriber.Size = new System.Drawing.Size(544, 286);
            this.grdviewSubscriber.TabIndex = 0;
            this.grdviewSubscriber.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdviewSubscriber_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // SubscriberName
            // 
            this.SubscriberName.DataPropertyName = "SubscriberName";
            this.SubscriberName.HeaderText = "Name";
            this.SubscriberName.Name = "SubscriberName";
            this.SubscriberName.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // lnkEdit
            // 
            this.lnkEdit.DataPropertyName = "lnkEdit";
            this.lnkEdit.HeaderText = "Edit";
            this.lnkEdit.Name = "lnkEdit";
            this.lnkEdit.Text = "Edit";
            this.lnkEdit.UseColumnTextForLinkValue = true;
            // 
            // lnkDelete
            // 
            this.lnkDelete.DataPropertyName = "lnkDelete";
            this.lnkDelete.HeaderText = "Delete";
            this.lnkDelete.Name = "lnkDelete";
            this.lnkDelete.Text = "Delete";
            this.lnkDelete.UseColumnTextForLinkValue = true;
            // 
            // tabMasterControl
            // 
            this.tabMasterControl.Controls.Add(this.btnSaveSettings);
            this.tabMasterControl.Controls.Add(this.txtMaxThreads);
            this.tabMasterControl.Controls.Add(this.label7);
            this.tabMasterControl.Controls.Add(this.txtLogFileName);
            this.tabMasterControl.Controls.Add(this.label6);
            this.tabMasterControl.Controls.Add(this.txtLogFilePath);
            this.tabMasterControl.Controls.Add(this.label5);
            this.tabMasterControl.Controls.Add(this.txtSharedPath);
            this.tabMasterControl.Controls.Add(this.label4);
            this.tabMasterControl.Location = new System.Drawing.Point(4, 22);
            this.tabMasterControl.Name = "tabMasterControl";
            this.tabMasterControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabMasterControl.Size = new System.Drawing.Size(958, 452);
            this.tabMasterControl.TabIndex = 2;
            this.tabMasterControl.Text = "Master Control";
            this.tabMasterControl.UseVisualStyleBackColor = true;
            // 
            // txtMaxThreads
            // 
            this.txtMaxThreads.Location = new System.Drawing.Point(201, 156);
            this.txtMaxThreads.Name = "txtMaxThreads";
            this.txtMaxThreads.Size = new System.Drawing.Size(210, 20);
            this.txtMaxThreads.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Max Number of Threads";
            // 
            // txtLogFileName
            // 
            this.txtLogFileName.Location = new System.Drawing.Point(201, 111);
            this.txtLogFileName.Name = "txtLogFileName";
            this.txtLogFileName.Size = new System.Drawing.Size(210, 20);
            this.txtLogFileName.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Log File Name";
            // 
            // txtLogFilePath
            // 
            this.txtLogFilePath.Location = new System.Drawing.Point(201, 72);
            this.txtLogFilePath.Name = "txtLogFilePath";
            this.txtLogFilePath.Size = new System.Drawing.Size(210, 20);
            this.txtLogFilePath.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Log File Path";
            // 
            // txtSharedPath
            // 
            this.txtSharedPath.Location = new System.Drawing.Point(201, 31);
            this.txtSharedPath.Name = "txtSharedPath";
            this.txtSharedPath.Size = new System.Drawing.Size(210, 20);
            this.txtSharedPath.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "CSV Shared Folder Path";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(201, 208);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSettings.TabIndex = 8;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // MasterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 502);
            this.Controls.Add(this.tabControl1);
            this.Name = "MasterControl";
            this.Text = "Configuration Settings";
            this.Load += new System.EventHandler(this.MasterControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabConfiguration.ResumeLayout(false);
            this.tabConfiguration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewCondition)).EndInit();
            this.tabSubscriber.ResumeLayout(false);
            this.tabSubscriber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdviewSubscriber)).EndInit();
            this.tabMasterControl.ResumeLayout(false);
            this.tabMasterControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConfiguration;
        private System.Windows.Forms.TabPage tabSubscriber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView grdviewSubscriber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubscriberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewLinkColumn lnkEdit;
        private System.Windows.Forms.DataGridViewLinkColumn lnkDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSubscriber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdViewCondition;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.TabPage tabMasterControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSharedPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLogFilePath;
        private System.Windows.Forms.TextBox txtLogFileName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaxThreads;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}

