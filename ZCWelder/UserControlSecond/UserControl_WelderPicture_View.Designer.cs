namespace ZCWelder.UserControlSecond
{
    partial class UserControl_WelderPicture_View
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label_Data = new System.Windows.Forms.Label();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Data = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ListViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.label_FileName = new System.Windows.Forms.Label();
            this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_LaborServiceTeam = new System.Windows.Forms.Label();
            this.Label_WorkPlace = new System.Windows.Forms.Label();
            this.Label_Department = new System.Windows.Forms.Label();
            this.TextBox_LaborServiceTeam = new System.Windows.Forms.TextBox();
            this.TextBox_WorkPlace = new System.Windows.Forms.TextBox();
            this.TextBox_Department = new System.Windows.Forms.TextBox();
            this.CheckBox_Sex = new System.Windows.Forms.CheckBox();
            this.Label_WelderName = new System.Windows.Forms.Label();
            this.MaskedTextBox_IdentificationCard = new System.Windows.Forms.MaskedTextBox();
            this.TextBox_WelderName = new System.Windows.Forms.TextBox();
            this.Label_WeldingBeginning = new System.Windows.Forms.Label();
            this.Label_IdentificationCard = new System.Windows.Forms.Label();
            this.Label_Sex = new System.Windows.Forms.Label();
            this.Label_Employer = new System.Windows.Forms.Label();
            this.Label_WorkerID = new System.Windows.Forms.Label();
            this.TextBox_WorkerID = new System.Windows.Forms.TextBox();
            this.TextBox_Employer = new System.Windows.Forms.TextBox();
            this.Label_Schooling = new System.Windows.Forms.Label();
            this.TextBox_Schooling = new System.Windows.Forms.TextBox();
            this.Label_WelderEnglishName = new System.Windows.Forms.Label();
            this.TextBox_WelderEnglishName = new System.Windows.Forms.TextBox();
            this.textBox_WeldingBeginning = new System.Windows.Forms.TextBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.button_DeletePicture = new System.Windows.Forms.Button();
            this.button_DownLoadPicture = new System.Windows.Forms.Button();
            this.pictureBox_Data = new System.Windows.Forms.PictureBox();
            this.toolStripMenuItem_DetectValid = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.contextMenuStrip_Data.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.TableLayoutPanel4.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1015, 545);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label_Data);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView_Data);
            this.splitContainer2.Size = new System.Drawing.Size(298, 543);
            this.splitContainer2.SplitterDistance = 30;
            this.splitContainer2.TabIndex = 0;
            // 
            // label_Data
            // 
            this.label_Data.AutoSize = true;
            this.label_Data.Location = new System.Drawing.Point(15, 11);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(101, 12);
            this.label_Data.TabIndex = 0;
            this.label_Data.Text = "焊工照片文件名：";
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.AllowUserToAddRows = false;
            this.dataGridView_Data.AllowUserToDeleteRows = false;
            this.dataGridView_Data.AllowUserToOrderColumns = true;
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.ContextMenuStrip = this.contextMenuStrip_Data;
            this.dataGridView_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Data.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.ReadOnly = true;
            this.dataGridView_Data.RowTemplate.Height = 23;
            this.dataGridView_Data.Size = new System.Drawing.Size(298, 509);
            this.dataGridView_Data.TabIndex = 0;
            this.dataGridView_Data.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Data_RowEnter);
            // 
            // contextMenuStrip_Data
            // 
            this.contextMenuStrip_Data.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ListViewRefresh,
            this.toolStripMenuItem_DetectValid,
            this.toolStripSeparator2,
            this.toolStripMenuItem_Export});
            this.contextMenuStrip_Data.Name = "contextMenuStrip_Parameter";
            this.contextMenuStrip_Data.Size = new System.Drawing.Size(179, 76);
            // 
            // toolStripMenuItem_ListViewRefresh
            // 
            this.toolStripMenuItem_ListViewRefresh.Name = "toolStripMenuItem_ListViewRefresh";
            this.toolStripMenuItem_ListViewRefresh.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_ListViewRefresh.Text = "刷新";
            this.toolStripMenuItem_ListViewRefresh.Click += new System.EventHandler(this.toolStripMenuItem_ListViewRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // toolStripMenuItem_Export
            // 
            this.toolStripMenuItem_Export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ExportToExcel});
            this.toolStripMenuItem_Export.Name = "toolStripMenuItem_Export";
            this.toolStripMenuItem_Export.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_Export.Text = "导出";
            // 
            // toolStripMenuItem_ExportToExcel
            // 
            this.toolStripMenuItem_ExportToExcel.Name = "toolStripMenuItem_ExportToExcel";
            this.toolStripMenuItem_ExportToExcel.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_ExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_ExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_ExportToExcel_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.textBox_FileName);
            this.splitContainer3.Panel1.Controls.Add(this.label_FileName);
            this.splitContainer3.Panel1.Controls.Add(this.TableLayoutPanel4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(711, 545);
            this.splitContainer3.SplitterDistance = 159;
            this.splitContainer3.TabIndex = 2;
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Location = new System.Drawing.Point(71, 8);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.ReadOnly = true;
            this.textBox_FileName.Size = new System.Drawing.Size(354, 21);
            this.textBox_FileName.TabIndex = 3;
            // 
            // label_FileName
            // 
            this.label_FileName.AutoSize = true;
            this.label_FileName.Location = new System.Drawing.Point(12, 11);
            this.label_FileName.Name = "label_FileName";
            this.label_FileName.Size = new System.Drawing.Size(53, 12);
            this.label_FileName.TabIndex = 2;
            this.label_FileName.Text = "文件名：";
            // 
            // TableLayoutPanel4
            // 
            this.TableLayoutPanel4.ColumnCount = 6;
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel4.Controls.Add(this.Label_LaborServiceTeam, 4, 3);
            this.TableLayoutPanel4.Controls.Add(this.Label_WorkPlace, 4, 2);
            this.TableLayoutPanel4.Controls.Add(this.Label_Department, 4, 1);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_LaborServiceTeam, 5, 3);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_WorkPlace, 5, 2);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_Department, 5, 1);
            this.TableLayoutPanel4.Controls.Add(this.CheckBox_Sex, 1, 2);
            this.TableLayoutPanel4.Controls.Add(this.Label_WelderName, 0, 0);
            this.TableLayoutPanel4.Controls.Add(this.MaskedTextBox_IdentificationCard, 1, 1);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_WelderName, 1, 0);
            this.TableLayoutPanel4.Controls.Add(this.Label_WeldingBeginning, 2, 0);
            this.TableLayoutPanel4.Controls.Add(this.Label_IdentificationCard, 0, 1);
            this.TableLayoutPanel4.Controls.Add(this.Label_Sex, 0, 2);
            this.TableLayoutPanel4.Controls.Add(this.Label_Employer, 4, 0);
            this.TableLayoutPanel4.Controls.Add(this.Label_WorkerID, 2, 1);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_WorkerID, 3, 1);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_Employer, 5, 0);
            this.TableLayoutPanel4.Controls.Add(this.Label_Schooling, 0, 3);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_Schooling, 1, 3);
            this.TableLayoutPanel4.Controls.Add(this.Label_WelderEnglishName, 2, 2);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_WelderEnglishName, 3, 2);
            this.TableLayoutPanel4.Controls.Add(this.textBox_WeldingBeginning, 3, 0);
            this.TableLayoutPanel4.Location = new System.Drawing.Point(8, 34);
            this.TableLayoutPanel4.Name = "TableLayoutPanel4";
            this.TableLayoutPanel4.RowCount = 4;
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel4.Size = new System.Drawing.Size(705, 108);
            this.TableLayoutPanel4.TabIndex = 1;
            // 
            // Label_LaborServiceTeam
            // 
            this.Label_LaborServiceTeam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_LaborServiceTeam.AutoSize = true;
            this.Label_LaborServiceTeam.Location = new System.Drawing.Point(423, 88);
            this.Label_LaborServiceTeam.Name = "Label_LaborServiceTeam";
            this.Label_LaborServiceTeam.Size = new System.Drawing.Size(53, 12);
            this.Label_LaborServiceTeam.TabIndex = 155;
            this.Label_LaborServiceTeam.Text = "劳务队：";
            // 
            // Label_WorkPlace
            // 
            this.Label_WorkPlace.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WorkPlace.AutoSize = true;
            this.Label_WorkPlace.Location = new System.Drawing.Point(423, 61);
            this.Label_WorkPlace.Name = "Label_WorkPlace";
            this.Label_WorkPlace.Size = new System.Drawing.Size(53, 12);
            this.Label_WorkPlace.TabIndex = 154;
            this.Label_WorkPlace.Text = "作业区：";
            // 
            // Label_Department
            // 
            this.Label_Department.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Department.AutoSize = true;
            this.Label_Department.Location = new System.Drawing.Point(435, 34);
            this.Label_Department.Name = "Label_Department";
            this.Label_Department.Size = new System.Drawing.Size(41, 12);
            this.Label_Department.TabIndex = 153;
            this.Label_Department.Text = "部门：";
            // 
            // TextBox_LaborServiceTeam
            // 
            this.TextBox_LaborServiceTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_LaborServiceTeam.Location = new System.Drawing.Point(482, 84);
            this.TextBox_LaborServiceTeam.Name = "TextBox_LaborServiceTeam";
            this.TextBox_LaborServiceTeam.ReadOnly = true;
            this.TextBox_LaborServiceTeam.Size = new System.Drawing.Size(220, 21);
            this.TextBox_LaborServiceTeam.TabIndex = 10;
            // 
            // TextBox_WorkPlace
            // 
            this.TextBox_WorkPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WorkPlace.Location = new System.Drawing.Point(482, 57);
            this.TextBox_WorkPlace.Name = "TextBox_WorkPlace";
            this.TextBox_WorkPlace.ReadOnly = true;
            this.TextBox_WorkPlace.Size = new System.Drawing.Size(220, 21);
            this.TextBox_WorkPlace.TabIndex = 9;
            // 
            // TextBox_Department
            // 
            this.TextBox_Department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Department.Location = new System.Drawing.Point(482, 30);
            this.TextBox_Department.Name = "TextBox_Department";
            this.TextBox_Department.ReadOnly = true;
            this.TextBox_Department.Size = new System.Drawing.Size(220, 21);
            this.TextBox_Department.TabIndex = 8;
            // 
            // CheckBox_Sex
            // 
            this.CheckBox_Sex.AutoSize = true;
            this.CheckBox_Sex.Checked = true;
            this.CheckBox_Sex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Sex.Enabled = false;
            this.CheckBox_Sex.Location = new System.Drawing.Point(63, 57);
            this.CheckBox_Sex.Name = "CheckBox_Sex";
            this.CheckBox_Sex.Size = new System.Drawing.Size(102, 16);
            this.CheckBox_Sex.TabIndex = 2;
            this.CheckBox_Sex.Text = "男 (选空为女)";
            this.CheckBox_Sex.UseVisualStyleBackColor = true;
            // 
            // Label_WelderName
            // 
            this.Label_WelderName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WelderName.AutoSize = true;
            this.Label_WelderName.Location = new System.Drawing.Point(16, 7);
            this.Label_WelderName.Name = "Label_WelderName";
            this.Label_WelderName.Size = new System.Drawing.Size(41, 12);
            this.Label_WelderName.TabIndex = 114;
            this.Label_WelderName.Text = "姓名：";
            // 
            // MaskedTextBox_IdentificationCard
            // 
            this.MaskedTextBox_IdentificationCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_IdentificationCard.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaskedTextBox_IdentificationCard.Location = new System.Drawing.Point(63, 30);
            this.MaskedTextBox_IdentificationCard.Mask = "00000000000000000A";
            this.MaskedTextBox_IdentificationCard.Name = "MaskedTextBox_IdentificationCard";
            this.MaskedTextBox_IdentificationCard.ReadOnly = true;
            this.MaskedTextBox_IdentificationCard.Size = new System.Drawing.Size(118, 21);
            this.MaskedTextBox_IdentificationCard.TabIndex = 1;
            // 
            // TextBox_WelderName
            // 
            this.TextBox_WelderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WelderName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_WelderName.Location = new System.Drawing.Point(63, 3);
            this.TextBox_WelderName.MaxLength = 10;
            this.TextBox_WelderName.Name = "TextBox_WelderName";
            this.TextBox_WelderName.ReadOnly = true;
            this.TextBox_WelderName.Size = new System.Drawing.Size(118, 21);
            this.TextBox_WelderName.TabIndex = 0;
            // 
            // Label_WeldingBeginning
            // 
            this.Label_WeldingBeginning.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingBeginning.AutoSize = true;
            this.Label_WeldingBeginning.Location = new System.Drawing.Point(187, 7);
            this.Label_WeldingBeginning.Name = "Label_WeldingBeginning";
            this.Label_WeldingBeginning.Size = new System.Drawing.Size(113, 12);
            this.Label_WeldingBeginning.TabIndex = 118;
            this.Label_WeldingBeginning.Text = "从事焊接开始日期：";
            // 
            // Label_IdentificationCard
            // 
            this.Label_IdentificationCard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IdentificationCard.AutoSize = true;
            this.Label_IdentificationCard.Location = new System.Drawing.Point(4, 34);
            this.Label_IdentificationCard.Name = "Label_IdentificationCard";
            this.Label_IdentificationCard.Size = new System.Drawing.Size(53, 12);
            this.Label_IdentificationCard.TabIndex = 115;
            this.Label_IdentificationCard.Text = "身份证：";
            // 
            // Label_Sex
            // 
            this.Label_Sex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Sex.AutoSize = true;
            this.Label_Sex.Location = new System.Drawing.Point(16, 61);
            this.Label_Sex.Name = "Label_Sex";
            this.Label_Sex.Size = new System.Drawing.Size(41, 12);
            this.Label_Sex.TabIndex = 139;
            this.Label_Sex.Text = "性别：";
            // 
            // Label_Employer
            // 
            this.Label_Employer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Employer.AutoSize = true;
            this.Label_Employer.Location = new System.Drawing.Point(435, 7);
            this.Label_Employer.Name = "Label_Employer";
            this.Label_Employer.Size = new System.Drawing.Size(41, 12);
            this.Label_Employer.TabIndex = 126;
            this.Label_Employer.Text = "公司：";
            // 
            // Label_WorkerID
            // 
            this.Label_WorkerID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WorkerID.AutoSize = true;
            this.Label_WorkerID.Location = new System.Drawing.Point(259, 34);
            this.Label_WorkerID.Name = "Label_WorkerID";
            this.Label_WorkerID.Size = new System.Drawing.Size(41, 12);
            this.Label_WorkerID.TabIndex = 133;
            this.Label_WorkerID.Text = "工号：";
            // 
            // TextBox_WorkerID
            // 
            this.TextBox_WorkerID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WorkerID.Location = new System.Drawing.Point(306, 30);
            this.TextBox_WorkerID.MaxLength = 10;
            this.TextBox_WorkerID.Name = "TextBox_WorkerID";
            this.TextBox_WorkerID.ReadOnly = true;
            this.TextBox_WorkerID.Size = new System.Drawing.Size(111, 21);
            this.TextBox_WorkerID.TabIndex = 5;
            // 
            // TextBox_Employer
            // 
            this.TextBox_Employer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Employer.Location = new System.Drawing.Point(482, 3);
            this.TextBox_Employer.Name = "TextBox_Employer";
            this.TextBox_Employer.ReadOnly = true;
            this.TextBox_Employer.Size = new System.Drawing.Size(220, 21);
            this.TextBox_Employer.TabIndex = 7;
            // 
            // Label_Schooling
            // 
            this.Label_Schooling.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Schooling.AutoSize = true;
            this.Label_Schooling.Location = new System.Drawing.Point(16, 88);
            this.Label_Schooling.Name = "Label_Schooling";
            this.Label_Schooling.Size = new System.Drawing.Size(41, 12);
            this.Label_Schooling.TabIndex = 117;
            this.Label_Schooling.Text = "学历：";
            // 
            // TextBox_Schooling
            // 
            this.TextBox_Schooling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Schooling.Location = new System.Drawing.Point(63, 84);
            this.TextBox_Schooling.Name = "TextBox_Schooling";
            this.TextBox_Schooling.ReadOnly = true;
            this.TextBox_Schooling.Size = new System.Drawing.Size(118, 21);
            this.TextBox_Schooling.TabIndex = 3;
            // 
            // Label_WelderEnglishName
            // 
            this.Label_WelderEnglishName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WelderEnglishName.AutoSize = true;
            this.Label_WelderEnglishName.Location = new System.Drawing.Point(235, 61);
            this.Label_WelderEnglishName.Name = "Label_WelderEnglishName";
            this.Label_WelderEnglishName.Size = new System.Drawing.Size(65, 12);
            this.Label_WelderEnglishName.TabIndex = 137;
            this.Label_WelderEnglishName.Text = "英文名称：";
            // 
            // TextBox_WelderEnglishName
            // 
            this.TextBox_WelderEnglishName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WelderEnglishName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_WelderEnglishName.Location = new System.Drawing.Point(306, 57);
            this.TextBox_WelderEnglishName.MaxLength = 250;
            this.TextBox_WelderEnglishName.Name = "TextBox_WelderEnglishName";
            this.TextBox_WelderEnglishName.ReadOnly = true;
            this.TextBox_WelderEnglishName.Size = new System.Drawing.Size(111, 21);
            this.TextBox_WelderEnglishName.TabIndex = 6;
            // 
            // textBox_WeldingBeginning
            // 
            this.textBox_WeldingBeginning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingBeginning.Location = new System.Drawing.Point(306, 3);
            this.textBox_WeldingBeginning.Name = "textBox_WeldingBeginning";
            this.textBox_WeldingBeginning.ReadOnly = true;
            this.textBox_WeldingBeginning.Size = new System.Drawing.Size(111, 21);
            this.textBox_WeldingBeginning.TabIndex = 156;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.button_DeletePicture);
            this.splitContainer4.Panel1.Controls.Add(this.button_DownLoadPicture);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.pictureBox_Data);
            this.splitContainer4.Size = new System.Drawing.Size(711, 382);
            this.splitContainer4.SplitterDistance = 99;
            this.splitContainer4.TabIndex = 1;
            // 
            // button_DeletePicture
            // 
            this.button_DeletePicture.Location = new System.Drawing.Point(8, 86);
            this.button_DeletePicture.Name = "button_DeletePicture";
            this.button_DeletePicture.Size = new System.Drawing.Size(75, 23);
            this.button_DeletePicture.TabIndex = 4;
            this.button_DeletePicture.Text = "删除照片";
            this.button_DeletePicture.UseVisualStyleBackColor = true;
            this.button_DeletePicture.Click += new System.EventHandler(this.button_DeletePicture_Click);
            // 
            // button_DownLoadPicture
            // 
            this.button_DownLoadPicture.Location = new System.Drawing.Point(8, 22);
            this.button_DownLoadPicture.Name = "button_DownLoadPicture";
            this.button_DownLoadPicture.Size = new System.Drawing.Size(75, 23);
            this.button_DownLoadPicture.TabIndex = 3;
            this.button_DownLoadPicture.Text = "下载照片";
            this.button_DownLoadPicture.UseVisualStyleBackColor = true;
            this.button_DownLoadPicture.Click += new System.EventHandler(this.button_DownLoadPicture_Click);
            // 
            // pictureBox_Data
            // 
            this.pictureBox_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Data.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Data.Name = "pictureBox_Data";
            this.pictureBox_Data.Size = new System.Drawing.Size(606, 380);
            this.pictureBox_Data.TabIndex = 0;
            this.pictureBox_Data.TabStop = false;
            // 
            // toolStripMenuItem_DetectValid
            // 
            this.toolStripMenuItem_DetectValid.Name = "toolStripMenuItem_DetectValid";
            this.toolStripMenuItem_DetectValid.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem_DetectValid.Text = "检测照片有效状态";
            this.toolStripMenuItem_DetectValid.Click += new System.EventHandler(this.toolStripMenuItem_DetectValid_Click);
            // 
            // UserControl_WelderPicture_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_WelderPicture_View";
            this.Size = new System.Drawing.Size(1015, 545);
            this.Load += new System.EventHandler(this.UserControl_WelderPicture_View_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.contextMenuStrip_Data.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.TableLayoutPanel4.ResumeLayout(false);
            this.TableLayoutPanel4.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.PictureBox pictureBox_Data;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Data;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ListViewRefresh;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel4;
        internal System.Windows.Forms.Label Label_LaborServiceTeam;
        internal System.Windows.Forms.Label Label_WorkPlace;
        internal System.Windows.Forms.Label Label_Department;
        internal System.Windows.Forms.TextBox TextBox_LaborServiceTeam;
        internal System.Windows.Forms.TextBox TextBox_WorkPlace;
        internal System.Windows.Forms.TextBox TextBox_Department;
        internal System.Windows.Forms.CheckBox CheckBox_Sex;
        internal System.Windows.Forms.Label Label_WelderName;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_IdentificationCard;
        internal System.Windows.Forms.TextBox TextBox_WelderName;
        internal System.Windows.Forms.Label Label_WeldingBeginning;
        internal System.Windows.Forms.Label Label_IdentificationCard;
        internal System.Windows.Forms.Label Label_Sex;
        internal System.Windows.Forms.Label Label_Employer;
        internal System.Windows.Forms.Label Label_WorkerID;
        internal System.Windows.Forms.TextBox TextBox_WorkerID;
        internal System.Windows.Forms.TextBox TextBox_Employer;
        internal System.Windows.Forms.Label Label_Schooling;
        internal System.Windows.Forms.TextBox TextBox_Schooling;
        internal System.Windows.Forms.Label Label_WelderEnglishName;
        internal System.Windows.Forms.TextBox TextBox_WelderEnglishName;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox textBox_WeldingBeginning;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Export;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ExportToExcel;
        private System.Windows.Forms.Label label_FileName;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button button_DeletePicture;
        private System.Windows.Forms.Button button_DownLoadPicture;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DetectValid;
    }
}
