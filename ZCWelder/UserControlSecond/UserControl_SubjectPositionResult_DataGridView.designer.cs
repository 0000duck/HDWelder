namespace ZCWelder.UserControlSecond
{
    partial class UserControl_SubjectPositionResult_DataGridView
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
            this.toolStripMenuItem_RowModifyBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.label_Data = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl_Auxiliary = new System.Windows.Forms.TabControl();
            this.tabPage_SubjectPositionResult = new System.Windows.Forms.TabPage();
            this.tabPage_Exam = new System.Windows.Forms.TabPage();
            this.userControl_WelderExamBase1 = new ZCWelder.UserControlThird.UserControl_WelderExamBase();
            this.tabPage_RegistrationNo = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label_TestCommitteeRegistrationNo = new System.Windows.Forms.Label();
            this.dataGridView_TestCommitteeRegistrationNo = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_TestCommitteeRegistrationNo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_TestCommitteeRegistrationNoAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_TestCommitteeRegistrationNoRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.button_DeletePicture = new System.Windows.Forms.Button();
            this.button_DownLoadPicture = new System.Windows.Forms.Button();
            this.button_UploadPicture = new System.Windows.Forms.Button();
            this.pictureBox_Welder = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_TestCommitteeRegistrationNoRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridView.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl_Auxiliary.SuspendLayout();
            this.tabPage_SubjectPositionResult.SuspendLayout();
            this.tabPage_Exam.SuspendLayout();
            this.tabPage_RegistrationNo.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TestCommitteeRegistrationNo)).BeginInit();
            this.contextMenuStrip_TestCommitteeRegistrationNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Welder)).BeginInit();
            this.contextMenuStrip_TestCommitteeRegistrationNoRow.SuspendLayout();
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
            this.toolStripMenuItem_RowModifyBatch,
            this.toolStripSeparator6,
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripMenuItem_DataGridViewRowRefresh,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(149, 104);
            this.contextMenuStrip_DataGridViewRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridViewRow_Opening);
            // 
            // toolStripMenuItem_RowModifyBatch
            // 
            this.toolStripMenuItem_RowModifyBatch.Name = "toolStripMenuItem_RowModifyBatch";
            this.toolStripMenuItem_RowModifyBatch.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_RowModifyBatch.Text = "批量修改数据";
            this.toolStripMenuItem_RowModifyBatch.Click += new System.EventHandler(this.toolStripMenuItem_RowModifyBatch_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_DataGridViewRowFrozenThisColumn
            // 
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Name = "toolStripMenuItem_DataGridViewRowFrozenThisColumn";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_Click);
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
            this.dataGridView_Data.Size = new System.Drawing.Size(540, 372);
            this.dataGridView_Data.TabIndex = 2;
            this.dataGridView_Data.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
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
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label_Data);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Data);
            this.splitContainer1.Size = new System.Drawing.Size(540, 404);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl_Auxiliary
            // 
            this.tabControl_Auxiliary.Controls.Add(this.tabPage_SubjectPositionResult);
            this.tabControl_Auxiliary.Controls.Add(this.tabPage_Exam);
            this.tabControl_Auxiliary.Controls.Add(this.tabPage_RegistrationNo);
            this.tabControl_Auxiliary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Auxiliary.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Auxiliary.Name = "tabControl_Auxiliary";
            this.tabControl_Auxiliary.SelectedIndex = 0;
            this.tabControl_Auxiliary.Size = new System.Drawing.Size(554, 436);
            this.tabControl_Auxiliary.TabIndex = 6;
            this.tabControl_Auxiliary.SelectedIndexChanged += new System.EventHandler(this.tabControl_Auxiliary_SelectedIndexChanged);
            // 
            // tabPage_SubjectPositionResult
            // 
            this.tabPage_SubjectPositionResult.Controls.Add(this.splitContainer1);
            this.tabPage_SubjectPositionResult.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SubjectPositionResult.Name = "tabPage_SubjectPositionResult";
            this.tabPage_SubjectPositionResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SubjectPositionResult.Size = new System.Drawing.Size(546, 410);
            this.tabPage_SubjectPositionResult.TabIndex = 0;
            this.tabPage_SubjectPositionResult.Text = "考试项目";
            this.tabPage_SubjectPositionResult.UseVisualStyleBackColor = true;
            // 
            // tabPage_Exam
            // 
            this.tabPage_Exam.Controls.Add(this.userControl_WelderExamBase1);
            this.tabPage_Exam.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Exam.Name = "tabPage_Exam";
            this.tabPage_Exam.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Exam.Size = new System.Drawing.Size(546, 410);
            this.tabPage_Exam.TabIndex = 1;
            this.tabPage_Exam.Text = "考试记录";
            this.tabPage_Exam.UseVisualStyleBackColor = true;
            // 
            // userControl_WelderExamBase1
            // 
            this.userControl_WelderExamBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WelderExamBase1.Location = new System.Drawing.Point(3, 3);
            this.userControl_WelderExamBase1.Name = "userControl_WelderExamBase1";
            this.userControl_WelderExamBase1.Size = new System.Drawing.Size(540, 404);
            this.userControl_WelderExamBase1.TabIndex = 0;
            // 
            // tabPage_RegistrationNo
            // 
            this.tabPage_RegistrationNo.Controls.Add(this.splitContainer4);
            this.tabPage_RegistrationNo.Location = new System.Drawing.Point(4, 22);
            this.tabPage_RegistrationNo.Name = "tabPage_RegistrationNo";
            this.tabPage_RegistrationNo.Size = new System.Drawing.Size(546, 410);
            this.tabPage_RegistrationNo.TabIndex = 2;
            this.tabPage_RegistrationNo.Text = "焊工编号和照片";
            this.tabPage_RegistrationNo.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.button_DeletePicture);
            this.splitContainer4.Panel2.Controls.Add(this.button_DownLoadPicture);
            this.splitContainer4.Panel2.Controls.Add(this.button_UploadPicture);
            this.splitContainer4.Panel2.Controls.Add(this.pictureBox_Welder);
            this.splitContainer4.Size = new System.Drawing.Size(546, 410);
            this.splitContainer4.SplitterDistance = 339;
            this.splitContainer4.TabIndex = 10;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label_TestCommitteeRegistrationNo);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView_TestCommitteeRegistrationNo);
            this.splitContainer3.Size = new System.Drawing.Size(337, 408);
            this.splitContainer3.SplitterDistance = 28;
            this.splitContainer3.TabIndex = 9;
            // 
            // label_TestCommitteeRegistrationNo
            // 
            this.label_TestCommitteeRegistrationNo.AutoSize = true;
            this.label_TestCommitteeRegistrationNo.Location = new System.Drawing.Point(17, 11);
            this.label_TestCommitteeRegistrationNo.Name = "label_TestCommitteeRegistrationNo";
            this.label_TestCommitteeRegistrationNo.Size = new System.Drawing.Size(41, 12);
            this.label_TestCommitteeRegistrationNo.TabIndex = 3;
            this.label_TestCommitteeRegistrationNo.Text = "数据：";
            // 
            // dataGridView_TestCommitteeRegistrationNo
            // 
            this.dataGridView_TestCommitteeRegistrationNo.AllowUserToAddRows = false;
            this.dataGridView_TestCommitteeRegistrationNo.AllowUserToDeleteRows = false;
            this.dataGridView_TestCommitteeRegistrationNo.AllowUserToOrderColumns = true;
            this.dataGridView_TestCommitteeRegistrationNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TestCommitteeRegistrationNo.ContextMenuStrip = this.contextMenuStrip_TestCommitteeRegistrationNo;
            this.dataGridView_TestCommitteeRegistrationNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_TestCommitteeRegistrationNo.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_TestCommitteeRegistrationNo.Name = "dataGridView_TestCommitteeRegistrationNo";
            this.dataGridView_TestCommitteeRegistrationNo.ReadOnly = true;
            this.dataGridView_TestCommitteeRegistrationNo.RowTemplate.Height = 23;
            this.dataGridView_TestCommitteeRegistrationNo.Size = new System.Drawing.Size(337, 376);
            this.dataGridView_TestCommitteeRegistrationNo.TabIndex = 2;
            this.dataGridView_TestCommitteeRegistrationNo.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_TestCommitteeRegistrationNo_CellContextMenuStripNeeded);
            // 
            // contextMenuStrip_TestCommitteeRegistrationNo
            // 
            this.contextMenuStrip_TestCommitteeRegistrationNo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_TestCommitteeRegistrationNoAdd,
            this.toolStripSeparator4,
            this.toolStripMenuItem_TestCommitteeRegistrationNoRefresh});
            this.contextMenuStrip_TestCommitteeRegistrationNo.Name = "contextMenuStrip_pWPSTest";
            this.contextMenuStrip_TestCommitteeRegistrationNo.Size = new System.Drawing.Size(101, 54);
            this.contextMenuStrip_TestCommitteeRegistrationNo.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_TestCommitteeRegistrationNo_Opening);
            // 
            // toolStripMenuItem_TestCommitteeRegistrationNoAdd
            // 
            this.toolStripMenuItem_TestCommitteeRegistrationNoAdd.Name = "toolStripMenuItem_TestCommitteeRegistrationNoAdd";
            this.toolStripMenuItem_TestCommitteeRegistrationNoAdd.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_TestCommitteeRegistrationNoAdd.Text = "添加";
            this.toolStripMenuItem_TestCommitteeRegistrationNoAdd.Click += new System.EventHandler(this.toolStripMenuItem_TestCommitteeRegistrationNoRowAdd_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(97, 6);
            // 
            // toolStripMenuItem_TestCommitteeRegistrationNoRefresh
            // 
            this.toolStripMenuItem_TestCommitteeRegistrationNoRefresh.Name = "toolStripMenuItem_TestCommitteeRegistrationNoRefresh";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRefresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRefresh.Text = "刷新";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRefresh.Click += new System.EventHandler(this.toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh_Click);
            // 
            // button_DeletePicture
            // 
            this.button_DeletePicture.Location = new System.Drawing.Point(112, 137);
            this.button_DeletePicture.Name = "button_DeletePicture";
            this.button_DeletePicture.Size = new System.Drawing.Size(75, 23);
            this.button_DeletePicture.TabIndex = 6;
            this.button_DeletePicture.Text = "删除照片";
            this.button_DeletePicture.UseVisualStyleBackColor = true;
            this.button_DeletePicture.Click += new System.EventHandler(this.button_DeletePicture_Click);
            // 
            // button_DownLoadPicture
            // 
            this.button_DownLoadPicture.Location = new System.Drawing.Point(112, 77);
            this.button_DownLoadPicture.Name = "button_DownLoadPicture";
            this.button_DownLoadPicture.Size = new System.Drawing.Size(75, 23);
            this.button_DownLoadPicture.TabIndex = 5;
            this.button_DownLoadPicture.Text = "下载照片";
            this.button_DownLoadPicture.UseVisualStyleBackColor = true;
            this.button_DownLoadPicture.Click += new System.EventHandler(this.button_DownLoadPicture_Click);
            // 
            // button_UploadPicture
            // 
            this.button_UploadPicture.Location = new System.Drawing.Point(112, 11);
            this.button_UploadPicture.Name = "button_UploadPicture";
            this.button_UploadPicture.Size = new System.Drawing.Size(75, 23);
            this.button_UploadPicture.TabIndex = 4;
            this.button_UploadPicture.Text = "上传照片";
            this.button_UploadPicture.UseVisualStyleBackColor = true;
            this.button_UploadPicture.Click += new System.EventHandler(this.button_UploadPicture_Click);
            // 
            // pictureBox_Welder
            // 
            this.pictureBox_Welder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Welder.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_Welder.Name = "pictureBox_Welder";
            this.pictureBox_Welder.Size = new System.Drawing.Size(104, 157);
            this.pictureBox_Welder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Welder.TabIndex = 3;
            this.pictureBox_Welder.TabStop = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenuItem_TestCommitteeRegistrationNoRowExport
            // 
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel});
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExport.Name = "toolStripMenuItem_TestCommitteeRegistrationNoRowExport";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExport.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExport.Text = "导出";
            // 
            // toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel
            // 
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel.Name = "toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel_Click);
            // 
            // toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh
            // 
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh.Name = "toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh.Text = "刷新";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh.Click += new System.EventHandler(this.toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh_Click);
            // 
            // toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn
            // 
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn.Name = "toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn.Click += new System.EventHandler(this.toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenuItem_TestCommitteeRegistrationNoRowDelete
            // 
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowDelete.Name = "toolStripMenuItem_TestCommitteeRegistrationNoRowDelete";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowDelete.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowDelete.Text = "删除";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowDelete.Click += new System.EventHandler(this.toolStripMenuItem_TestCommitteeRegistrationNoRowDelete_Click);
            // 
            // contextMenuStrip_TestCommitteeRegistrationNoRow
            // 
            this.contextMenuStrip_TestCommitteeRegistrationNoRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowAdd,
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowDelete,
            this.toolStripSeparator5,
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn,
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh,
            this.toolStripSeparator2,
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExport});
            this.contextMenuStrip_TestCommitteeRegistrationNoRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_TestCommitteeRegistrationNoRow.Size = new System.Drawing.Size(125, 126);
            this.contextMenuStrip_TestCommitteeRegistrationNoRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_TestCommitteeRegistrationNoRow_Opening);
            // 
            // toolStripMenuItem_TestCommitteeRegistrationNoRowAdd
            // 
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowAdd.Name = "toolStripMenuItem_TestCommitteeRegistrationNoRowAdd";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowAdd.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowAdd.Text = "添加";
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowAdd.Click += new System.EventHandler(this.toolStripMenuItem_TestCommitteeRegistrationNoRowAdd_Click);
            // 
            // UserControl_SubjectPositionResult_DataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl_Auxiliary);
            this.Name = "UserControl_SubjectPositionResult_DataGridView";
            this.Size = new System.Drawing.Size(554, 436);
            this.Load += new System.EventHandler(this.UserControl_Student_DataGridView_Load);
            this.contextMenuStrip_DataGridView.ResumeLayout(false);
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl_Auxiliary.ResumeLayout(false);
            this.tabPage_SubjectPositionResult.ResumeLayout(false);
            this.tabPage_Exam.ResumeLayout(false);
            this.tabPage_RegistrationNo.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TestCommitteeRegistrationNo)).EndInit();
            this.contextMenuStrip_TestCommitteeRegistrationNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Welder)).EndInit();
            this.contextMenuStrip_TestCommitteeRegistrationNoRow.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl_Auxiliary;
        private System.Windows.Forms.TabPage tabPage_SubjectPositionResult;
        private System.Windows.Forms.TabPage tabPage_Exam;
        private System.Windows.Forms.TabPage tabPage_RegistrationNo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_TestCommitteeRegistrationNo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TestCommitteeRegistrationNoAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TestCommitteeRegistrationNoRefresh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TestCommitteeRegistrationNoRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh;
        private System.Windows.Forms.Label label_TestCommitteeRegistrationNo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn;
        private System.Windows.Forms.DataGridView dataGridView_TestCommitteeRegistrationNo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TestCommitteeRegistrationNoRowDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_TestCommitteeRegistrationNoRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TestCommitteeRegistrationNoRowAdd;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowModifyBatch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button button_DownLoadPicture;
        private System.Windows.Forms.Button button_UploadPicture;
        private System.Windows.Forms.PictureBox pictureBox_Welder;
        private System.Windows.Forms.Button button_DeletePicture;
        private ZCWelder.UserControlThird.UserControl_WelderExamBase userControl_WelderExamBase1;
    }
}
