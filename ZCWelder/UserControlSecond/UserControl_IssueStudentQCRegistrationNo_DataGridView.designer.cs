namespace ZCWelder.UserControlSecond
{
    partial class UserControl_IssueStudentQCRegistrationNo_DataGridView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip_DataGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_RowSetQCValid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.label_Data = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkBox_QC = new System.Windows.Forms.CheckBox();
            this.tabControl_Student = new System.Windows.Forms.TabControl();
            this.tabPage_Student = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.userControl_SubjectPositionResult_DataGridViewSecond1 = new ZCWelder.UserControlSecond.UserControl_SubjectPositionResult_DataGridViewSecond();
            this.tabPage_WelderPicture = new System.Windows.Forms.TabPage();
            this.button_DeletePicture = new System.Windows.Forms.Button();
            this.button_DownLoadPicture = new System.Windows.Forms.Button();
            this.button_UploadPicture = new System.Windows.Forms.Button();
            this.pictureBox_Welder = new System.Windows.Forms.PictureBox();
            this.tabPage_TestCommitteeRegistrationNo = new System.Windows.Forms.TabPage();
            this.userControl_WelderTestCommitteeRegistrationNoBase1 = new ZCWelder.UserControlThird.UserControl_WelderTestCommitteeRegistrationNoBase();
            this.tabPage_BlackList = new System.Windows.Forms.TabPage();
            this.userControl_BlackList_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_BlackList_DataGridView();
            this.tabPage_WelderBelongLog = new System.Windows.Forms.TabPage();
            this.userControl_WelderBelongLog_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_WelderBelongLog_DataGridView();
            this.contextMenuStrip_DataGridView.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl_Student.SuspendLayout();
            this.tabPage_Student.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage_WelderPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Welder)).BeginInit();
            this.tabPage_TestCommitteeRegistrationNo.SuspendLayout();
            this.tabPage_BlackList.SuspendLayout();
            this.tabPage_WelderBelongLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip_DataGridView
            // 
            this.contextMenuStrip_DataGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRefresh});
            this.contextMenuStrip_DataGridView.Name = "contextMenuStrip_pWPSTest";
            this.contextMenuStrip_DataGridView.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip_DataGridView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridView_Opening);
            // 
            // toolStripMenuItem_DataGridViewRefresh
            // 
            this.toolStripMenuItem_DataGridViewRefresh.Name = "toolStripMenuItem_DataGridViewRefresh";
            this.toolStripMenuItem_DataGridViewRefresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_DataGridViewRefresh.Text = "刷新";
            this.toolStripMenuItem_DataGridViewRefresh.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowRefresh_Click);
            // 
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_RowSetQCValid,
            this.toolStripSeparator1,
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripMenuItem_DataGridViewRowRefresh,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(149, 104);
            this.contextMenuStrip_DataGridViewRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridViewRow_Opening);
            // 
            // toolStripMenuItem_RowSetQCValid
            // 
            this.toolStripMenuItem_RowSetQCValid.Name = "toolStripMenuItem_RowSetQCValid";
            this.toolStripMenuItem_RowSetQCValid.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_RowSetQCValid.Text = "修改证书信息";
            this.toolStripMenuItem_RowSetQCValid.Click += new System.EventHandler(this.toolStripMenuItem_RowSetQCValid_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_DataGridViewRowFrozenThisColumn
            // 
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Name = "toolStripMenuItem_DataGridViewRowFrozenThisColumn";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged);
            // 
            // toolStripMenuItem_DataGridViewRowRefresh
            // 
            this.toolStripMenuItem_DataGridViewRowRefresh.Name = "toolStripMenuItem_DataGridViewRowRefresh";
            this.toolStripMenuItem_DataGridViewRowRefresh.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_DataGridViewRowRefresh.Text = "刷新";
            this.toolStripMenuItem_DataGridViewRowRefresh.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_DataGridViewRowExport
            // 
            this.toolStripMenuItem_DataGridViewRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowExportToExcel});
            this.toolStripMenuItem_DataGridViewRowExport.Name = "toolStripMenuItem_DataGridViewRowExport";
            this.toolStripMenuItem_DataGridViewRowExport.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_DataGridViewRowExport.Text = "导出";
            // 
            // toolStripMenuItem_DataGridViewRowExportToExcel
            // 
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Name = "toolStripMenuItem_DataGridViewRowExportToExcel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.AllowUserToAddRows = false;
            this.dataGridView_Data.AllowUserToDeleteRows = false;
            this.dataGridView_Data.AllowUserToOrderColumns = true;
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.ContextMenuStrip = this.contextMenuStrip_DataGridView;
            this.dataGridView_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Data.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.ReadOnly = true;
            this.dataGridView_Data.RowTemplate.Height = 23;
            this.dataGridView_Data.Size = new System.Drawing.Size(554, 150);
            this.dataGridView_Data.TabIndex = 2;
            this.dataGridView_Data.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Data_RowEnter);
            this.dataGridView_Data.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
            this.dataGridView_Data.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_Data_CellFormatting);
            // 
            // label_Data
            // 
            this.label_Data.AutoSize = true;
            this.label_Data.Location = new System.Drawing.Point(17, 11);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(41, 12);
            this.label_Data.TabIndex = 3;
            this.label_Data.Text = "数据：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_QC);
            this.splitContainer1.Panel1.Controls.Add(this.label_Data);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Data);
            this.splitContainer1.Size = new System.Drawing.Size(554, 182);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 5;
            // 
            // checkBox_QC
            // 
            this.checkBox_QC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_QC.AutoSize = true;
            this.checkBox_QC.Location = new System.Drawing.Point(426, 7);
            this.checkBox_QC.Name = "checkBox_QC";
            this.checkBox_QC.Size = new System.Drawing.Size(108, 16);
            this.checkBox_QC.TabIndex = 5;
            this.checkBox_QC.Text = "只显示有效证书";
            this.checkBox_QC.UseVisualStyleBackColor = true;
            this.checkBox_QC.CheckedChanged += new System.EventHandler(this.checkBox_QC_CheckedChanged);
            // 
            // tabControl_Student
            // 
            this.tabControl_Student.Controls.Add(this.tabPage_Student);
            this.tabControl_Student.Controls.Add(this.tabPage_WelderPicture);
            this.tabControl_Student.Controls.Add(this.tabPage_TestCommitteeRegistrationNo);
            this.tabControl_Student.Controls.Add(this.tabPage_BlackList);
            this.tabControl_Student.Controls.Add(this.tabPage_WelderBelongLog);
            this.tabControl_Student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Student.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Student.Name = "tabControl_Student";
            this.tabControl_Student.SelectedIndex = 0;
            this.tabControl_Student.Size = new System.Drawing.Size(570, 420);
            this.tabControl_Student.TabIndex = 6;
            // 
            // tabPage_Student
            // 
            this.tabPage_Student.Controls.Add(this.splitContainer2);
            this.tabPage_Student.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Student.Name = "tabPage_Student";
            this.tabPage_Student.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Student.Size = new System.Drawing.Size(562, 394);
            this.tabPage_Student.TabIndex = 0;
            this.tabPage_Student.Text = "考试记录";
            this.tabPage_Student.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.userControl_SubjectPositionResult_DataGridViewSecond1);
            this.splitContainer2.Size = new System.Drawing.Size(556, 388);
            this.splitContainer2.SplitterDistance = 184;
            this.splitContainer2.TabIndex = 6;
            // 
            // userControl_SubjectPositionResult_DataGridViewSecond1
            // 
            this.userControl_SubjectPositionResult_DataGridViewSecond1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_SubjectPositionResult_DataGridViewSecond1.Location = new System.Drawing.Point(0, 0);
            this.userControl_SubjectPositionResult_DataGridViewSecond1.Name = "userControl_SubjectPositionResult_DataGridViewSecond1";
            this.userControl_SubjectPositionResult_DataGridViewSecond1.Size = new System.Drawing.Size(554, 198);
            this.userControl_SubjectPositionResult_DataGridViewSecond1.TabIndex = 1;
            // 
            // tabPage_WelderPicture
            // 
            this.tabPage_WelderPicture.Controls.Add(this.button_DeletePicture);
            this.tabPage_WelderPicture.Controls.Add(this.button_DownLoadPicture);
            this.tabPage_WelderPicture.Controls.Add(this.button_UploadPicture);
            this.tabPage_WelderPicture.Controls.Add(this.pictureBox_Welder);
            this.tabPage_WelderPicture.Location = new System.Drawing.Point(4, 22);
            this.tabPage_WelderPicture.Name = "tabPage_WelderPicture";
            this.tabPage_WelderPicture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_WelderPicture.Size = new System.Drawing.Size(562, 394);
            this.tabPage_WelderPicture.TabIndex = 1;
            this.tabPage_WelderPicture.Text = "焊工照片";
            this.tabPage_WelderPicture.UseVisualStyleBackColor = true;
            // 
            // button_DeletePicture
            // 
            this.button_DeletePicture.Location = new System.Drawing.Point(388, 178);
            this.button_DeletePicture.Name = "button_DeletePicture";
            this.button_DeletePicture.Size = new System.Drawing.Size(75, 23);
            this.button_DeletePicture.TabIndex = 2;
            this.button_DeletePicture.Text = "删除照片";
            this.button_DeletePicture.UseVisualStyleBackColor = true;
            this.button_DeletePicture.Click += new System.EventHandler(this.button_DeletePicture_Click);
            // 
            // button_DownLoadPicture
            // 
            this.button_DownLoadPicture.Location = new System.Drawing.Point(388, 114);
            this.button_DownLoadPicture.Name = "button_DownLoadPicture";
            this.button_DownLoadPicture.Size = new System.Drawing.Size(75, 23);
            this.button_DownLoadPicture.TabIndex = 2;
            this.button_DownLoadPicture.Text = "下载照片";
            this.button_DownLoadPicture.UseVisualStyleBackColor = true;
            this.button_DownLoadPicture.Click += new System.EventHandler(this.button_DownLoadPicture_Click);
            // 
            // button_UploadPicture
            // 
            this.button_UploadPicture.Location = new System.Drawing.Point(388, 48);
            this.button_UploadPicture.Name = "button_UploadPicture";
            this.button_UploadPicture.Size = new System.Drawing.Size(75, 23);
            this.button_UploadPicture.TabIndex = 1;
            this.button_UploadPicture.Text = "上传照片";
            this.button_UploadPicture.UseVisualStyleBackColor = true;
            this.button_UploadPicture.Click += new System.EventHandler(this.button_UploadPicture_Click);
            // 
            // pictureBox_Welder
            // 
            this.pictureBox_Welder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Welder.Location = new System.Drawing.Point(132, 22);
            this.pictureBox_Welder.Name = "pictureBox_Welder";
            this.pictureBox_Welder.Size = new System.Drawing.Size(207, 313);
            this.pictureBox_Welder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Welder.TabIndex = 0;
            this.pictureBox_Welder.TabStop = false;
            // 
            // tabPage_TestCommitteeRegistrationNo
            // 
            this.tabPage_TestCommitteeRegistrationNo.Controls.Add(this.userControl_WelderTestCommitteeRegistrationNoBase1);
            this.tabPage_TestCommitteeRegistrationNo.Location = new System.Drawing.Point(4, 22);
            this.tabPage_TestCommitteeRegistrationNo.Name = "tabPage_TestCommitteeRegistrationNo";
            this.tabPage_TestCommitteeRegistrationNo.Size = new System.Drawing.Size(562, 394);
            this.tabPage_TestCommitteeRegistrationNo.TabIndex = 2;
            this.tabPage_TestCommitteeRegistrationNo.Text = "焊工编号";
            this.tabPage_TestCommitteeRegistrationNo.UseVisualStyleBackColor = true;
            // 
            // userControl_WelderTestCommitteeRegistrationNoBase1
            // 
            this.userControl_WelderTestCommitteeRegistrationNoBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WelderTestCommitteeRegistrationNoBase1.Location = new System.Drawing.Point(0, 0);
            this.userControl_WelderTestCommitteeRegistrationNoBase1.Name = "userControl_WelderTestCommitteeRegistrationNoBase1";
            this.userControl_WelderTestCommitteeRegistrationNoBase1.Size = new System.Drawing.Size(562, 394);
            this.userControl_WelderTestCommitteeRegistrationNoBase1.TabIndex = 0;
            // 
            // tabPage_BlackList
            // 
            this.tabPage_BlackList.Controls.Add(this.userControl_BlackList_DataGridView1);
            this.tabPage_BlackList.Location = new System.Drawing.Point(4, 22);
            this.tabPage_BlackList.Name = "tabPage_BlackList";
            this.tabPage_BlackList.Size = new System.Drawing.Size(562, 394);
            this.tabPage_BlackList.TabIndex = 3;
            this.tabPage_BlackList.Text = "黑名单";
            this.tabPage_BlackList.UseVisualStyleBackColor = true;
            // 
            // userControl_BlackList_DataGridView1
            // 
            this.userControl_BlackList_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_BlackList_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_BlackList_DataGridView1.Name = "userControl_BlackList_DataGridView1";
            this.userControl_BlackList_DataGridView1.Size = new System.Drawing.Size(562, 394);
            this.userControl_BlackList_DataGridView1.TabIndex = 0;
            // 
            // tabPage_WelderBelongLog
            // 
            this.tabPage_WelderBelongLog.Controls.Add(this.userControl_WelderBelongLog_DataGridView1);
            this.tabPage_WelderBelongLog.Location = new System.Drawing.Point(4, 22);
            this.tabPage_WelderBelongLog.Name = "tabPage_WelderBelongLog";
            this.tabPage_WelderBelongLog.Size = new System.Drawing.Size(562, 394);
            this.tabPage_WelderBelongLog.TabIndex = 4;
            this.tabPage_WelderBelongLog.Text = "焊工流动记录";
            this.tabPage_WelderBelongLog.UseVisualStyleBackColor = true;
            // 
            // userControl_WelderBelongLog_DataGridView1
            // 
            this.userControl_WelderBelongLog_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WelderBelongLog_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_WelderBelongLog_DataGridView1.Name = "userControl_WelderBelongLog_DataGridView1";
            this.userControl_WelderBelongLog_DataGridView1.Size = new System.Drawing.Size(562, 394);
            this.userControl_WelderBelongLog_DataGridView1.TabIndex = 0;
            // 
            // UserControl_IssueStudentQCRegistrationNo_DataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl_Student);
            this.Name = "UserControl_IssueStudentQCRegistrationNo_DataGridView";
            this.Size = new System.Drawing.Size(570, 420);
            this.Load += new System.EventHandler(this.UserControl_WelderIssueStudentQCRegistrationNo_DataGridView_Load);
            this.contextMenuStrip_DataGridView.ResumeLayout(false);
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl_Student.ResumeLayout(false);
            this.tabPage_Student.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabPage_WelderPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Welder)).EndInit();
            this.tabPage_TestCommitteeRegistrationNo.ResumeLayout(false);
            this.tabPage_BlackList.ResumeLayout(false);
            this.tabPage_WelderBelongLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridViewRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowFrozenThisColumn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowRefresh;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
        private System.Windows.Forms.CheckBox checkBox_QC;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowSetQCValid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControl_Student;
        private System.Windows.Forms.TabPage tabPage_Student;
        private System.Windows.Forms.TabPage tabPage_WelderPicture;
        private System.Windows.Forms.PictureBox pictureBox_Welder;
        private System.Windows.Forms.Button button_DownLoadPicture;
        private System.Windows.Forms.Button button_UploadPicture;
        private System.Windows.Forms.Button button_DeletePicture;
        private System.Windows.Forms.TabPage tabPage_TestCommitteeRegistrationNo;
        private ZCWelder.UserControlThird.UserControl_WelderTestCommitteeRegistrationNoBase userControl_WelderTestCommitteeRegistrationNoBase1;
        private System.Windows.Forms.TabPage tabPage_BlackList;
        private UserControl_BlackList_DataGridView userControl_BlackList_DataGridView1;
        private System.Windows.Forms.TabPage tabPage_WelderBelongLog;
        private UserControl_WelderBelongLog_DataGridView userControl_WelderBelongLog_DataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private UserControl_SubjectPositionResult_DataGridViewSecond userControl_SubjectPositionResult_DataGridViewSecond1;
    }
}
