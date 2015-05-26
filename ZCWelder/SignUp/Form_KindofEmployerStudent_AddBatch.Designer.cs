namespace ZCWelder.SignUp
{
    partial class Form_KindofEmployerStudent_AddBatch
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_WelderAdd = new System.Windows.Forms.Button();
            this.MaskedTextBox_KindofEmployerIssueID = new System.Windows.Forms.MaskedTextBox();
            this.TextBox_Subject = new System.Windows.Forms.TextBox();
            this.Label_KindofEmployerIssueID = new System.Windows.Forms.Label();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.Label_Subject = new System.Windows.Forms.Label();
            this.GroupBox_Subject = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_WorkPieceType = new System.Windows.Forms.Label();
            this.TextBox_SubjectID = new System.Windows.Forms.TextBox();
            this.TextBox_WorkPieceType = new System.Windows.Forms.TextBox();
            this.Label_SubjectID = new System.Windows.Forms.Label();
            this.Label_JointType = new System.Windows.Forms.Label();
            this.TextBox_JointType = new System.Windows.Forms.TextBox();
            this.TextBox_WeldingClass = new System.Windows.Forms.TextBox();
            this.Label_WeldingClass = new System.Windows.Forms.Label();
            this.TextBox_WeldingProject = new System.Windows.Forms.TextBox();
            this.Label_WeldingProject = new System.Windows.Forms.Label();
            this.TextBox_WeldingStandard = new System.Windows.Forms.TextBox();
            this.Label_WeldingStandard = new System.Windows.Forms.Label();
            this.Button_SubjectQuery = new System.Windows.Forms.Button();
            this.label_Data = new System.Windows.Forms.Label();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Label_IssueNo = new System.Windows.Forms.Label();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.TextBox_IssueNo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.GroupBox_Subject.SuspendLayout();
            this.TableLayoutPanel3.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_WelderAdd
            // 
            this.button_WelderAdd.Location = new System.Drawing.Point(646, 3);
            this.button_WelderAdd.Name = "button_WelderAdd";
            this.button_WelderAdd.Size = new System.Drawing.Size(89, 21);
            this.button_WelderAdd.TabIndex = 482;
            this.button_WelderAdd.Text = "添加学员";
            this.button_WelderAdd.UseVisualStyleBackColor = true;
            this.button_WelderAdd.Click += new System.EventHandler(this.button_WelderAdd_Click);
            // 
            // MaskedTextBox_KindofEmployerIssueID
            // 
            this.MaskedTextBox_KindofEmployerIssueID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_KindofEmployerIssueID.Location = new System.Drawing.Point(534, 3);
            this.MaskedTextBox_KindofEmployerIssueID.Name = "MaskedTextBox_KindofEmployerIssueID";
            this.MaskedTextBox_KindofEmployerIssueID.ReadOnly = true;
            this.MaskedTextBox_KindofEmployerIssueID.Size = new System.Drawing.Size(106, 21);
            this.MaskedTextBox_KindofEmployerIssueID.TabIndex = 483;
            // 
            // TextBox_Subject
            // 
            this.TableLayoutPanel3.SetColumnSpan(this.TextBox_Subject, 2);
            this.TextBox_Subject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Subject.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_Subject.Location = new System.Drawing.Point(401, 35);
            this.TextBox_Subject.Name = "TextBox_Subject";
            this.TextBox_Subject.ReadOnly = true;
            this.TextBox_Subject.Size = new System.Drawing.Size(206, 21);
            this.TextBox_Subject.TabIndex = 6;
            // 
            // Label_KindofEmployerIssueID
            // 
            this.Label_KindofEmployerIssueID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_KindofEmployerIssueID.AutoSize = true;
            this.Label_KindofEmployerIssueID.Location = new System.Drawing.Point(487, 7);
            this.Label_KindofEmployerIssueID.Name = "Label_KindofEmployerIssueID";
            this.Label_KindofEmployerIssueID.Size = new System.Drawing.Size(41, 12);
            this.Label_KindofEmployerIssueID.TabIndex = 484;
            this.Label_KindofEmployerIssueID.Text = "编号：";
            // 
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(25, 479);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 490;
            this.label_ErrMessage.Text = "错误信息：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(614, 474);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel1.TabIndex = 489;
            // 
            // button_OnOK
            // 
            this.button_OnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OnOK.Location = new System.Drawing.Point(3, 3);
            this.button_OnOK.Name = "button_OnOK";
            this.button_OnOK.Size = new System.Drawing.Size(69, 23);
            this.button_OnOK.TabIndex = 0;
            this.button_OnOK.Text = "确定";
            this.button_OnOK.UseVisualStyleBackColor = true;
            this.button_OnOK.Click += new System.EventHandler(this.button_OnOK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(78, 3);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(69, 23);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Label_Subject
            // 
            this.Label_Subject.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Subject.AutoSize = true;
            this.Label_Subject.Location = new System.Drawing.Point(354, 42);
            this.Label_Subject.Name = "Label_Subject";
            this.Label_Subject.Size = new System.Drawing.Size(41, 12);
            this.Label_Subject.TabIndex = 213;
            this.Label_Subject.Text = "科目：";
            // 
            // GroupBox_Subject
            // 
            this.GroupBox_Subject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBox_Subject.Controls.Add(this.TableLayoutPanel3);
            this.GroupBox_Subject.Location = new System.Drawing.Point(27, 371);
            this.GroupBox_Subject.Name = "GroupBox_Subject";
            this.GroupBox_Subject.Size = new System.Drawing.Size(741, 92);
            this.GroupBox_Subject.TabIndex = 487;
            this.GroupBox_Subject.TabStop = false;
            this.GroupBox_Subject.Text = "考试科目";
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.ColumnCount = 8;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.TableLayoutPanel3.Controls.Add(this.TextBox_Subject, 5, 1);
            this.TableLayoutPanel3.Controls.Add(this.Label_Subject, 4, 1);
            this.TableLayoutPanel3.Controls.Add(this.Label_WorkPieceType, 0, 1);
            this.TableLayoutPanel3.Controls.Add(this.TextBox_SubjectID, 1, 0);
            this.TableLayoutPanel3.Controls.Add(this.TextBox_WorkPieceType, 1, 1);
            this.TableLayoutPanel3.Controls.Add(this.Label_SubjectID, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.Label_JointType, 2, 1);
            this.TableLayoutPanel3.Controls.Add(this.TextBox_JointType, 3, 1);
            this.TableLayoutPanel3.Controls.Add(this.TextBox_WeldingClass, 7, 0);
            this.TableLayoutPanel3.Controls.Add(this.Label_WeldingClass, 6, 0);
            this.TableLayoutPanel3.Controls.Add(this.TextBox_WeldingProject, 5, 0);
            this.TableLayoutPanel3.Controls.Add(this.Label_WeldingProject, 4, 0);
            this.TableLayoutPanel3.Controls.Add(this.TextBox_WeldingStandard, 3, 0);
            this.TableLayoutPanel3.Controls.Add(this.Label_WeldingStandard, 2, 0);
            this.TableLayoutPanel3.Controls.Add(this.Button_SubjectQuery, 7, 1);
            this.TableLayoutPanel3.Location = new System.Drawing.Point(19, 20);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 2;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(705, 64);
            this.TableLayoutPanel3.TabIndex = 0;
            // 
            // Label_WorkPieceType
            // 
            this.Label_WorkPieceType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WorkPieceType.AutoSize = true;
            this.Label_WorkPieceType.Location = new System.Drawing.Point(6, 42);
            this.Label_WorkPieceType.Name = "Label_WorkPieceType";
            this.Label_WorkPieceType.Size = new System.Drawing.Size(65, 12);
            this.Label_WorkPieceType.TabIndex = 207;
            this.Label_WorkPieceType.Text = "工件类型：";
            // 
            // TextBox_SubjectID
            // 
            this.TextBox_SubjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_SubjectID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_SubjectID.Location = new System.Drawing.Point(77, 3);
            this.TextBox_SubjectID.Name = "TextBox_SubjectID";
            this.TextBox_SubjectID.ReadOnly = true;
            this.TextBox_SubjectID.Size = new System.Drawing.Size(80, 21);
            this.TextBox_SubjectID.TabIndex = 0;
            // 
            // TextBox_WorkPieceType
            // 
            this.TextBox_WorkPieceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WorkPieceType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_WorkPieceType.Location = new System.Drawing.Point(77, 35);
            this.TextBox_WorkPieceType.Name = "TextBox_WorkPieceType";
            this.TextBox_WorkPieceType.ReadOnly = true;
            this.TextBox_WorkPieceType.Size = new System.Drawing.Size(80, 21);
            this.TextBox_WorkPieceType.TabIndex = 4;
            // 
            // Label_SubjectID
            // 
            this.Label_SubjectID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_SubjectID.AutoSize = true;
            this.Label_SubjectID.Location = new System.Drawing.Point(6, 10);
            this.Label_SubjectID.Name = "Label_SubjectID";
            this.Label_SubjectID.Size = new System.Drawing.Size(65, 12);
            this.Label_SubjectID.TabIndex = 211;
            this.Label_SubjectID.Text = "科目编号：";
            // 
            // Label_JointType
            // 
            this.Label_JointType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_JointType.AutoSize = true;
            this.Label_JointType.Location = new System.Drawing.Point(164, 42);
            this.Label_JointType.Name = "Label_JointType";
            this.Label_JointType.Size = new System.Drawing.Size(65, 12);
            this.Label_JointType.TabIndex = 487;
            this.Label_JointType.Text = "焊缝类型：";
            // 
            // TextBox_JointType
            // 
            this.TextBox_JointType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_JointType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_JointType.Location = new System.Drawing.Point(235, 35);
            this.TextBox_JointType.Name = "TextBox_JointType";
            this.TextBox_JointType.ReadOnly = true;
            this.TextBox_JointType.Size = new System.Drawing.Size(108, 21);
            this.TextBox_JointType.TabIndex = 5;
            // 
            // TextBox_WeldingClass
            // 
            this.TextBox_WeldingClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WeldingClass.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_WeldingClass.Location = new System.Drawing.Point(613, 3);
            this.TextBox_WeldingClass.Name = "TextBox_WeldingClass";
            this.TextBox_WeldingClass.ReadOnly = true;
            this.TextBox_WeldingClass.Size = new System.Drawing.Size(89, 21);
            this.TextBox_WeldingClass.TabIndex = 3;
            // 
            // Label_WeldingClass
            // 
            this.Label_WeldingClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingClass.AutoSize = true;
            this.Label_WeldingClass.Location = new System.Drawing.Point(566, 10);
            this.Label_WeldingClass.Name = "Label_WeldingClass";
            this.Label_WeldingClass.Size = new System.Drawing.Size(41, 12);
            this.Label_WeldingClass.TabIndex = 209;
            this.Label_WeldingClass.Text = "等级：";
            // 
            // TextBox_WeldingProject
            // 
            this.TextBox_WeldingProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WeldingProject.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_WeldingProject.Location = new System.Drawing.Point(401, 3);
            this.TextBox_WeldingProject.Name = "TextBox_WeldingProject";
            this.TextBox_WeldingProject.ReadOnly = true;
            this.TextBox_WeldingProject.Size = new System.Drawing.Size(157, 21);
            this.TextBox_WeldingProject.TabIndex = 2;
            // 
            // Label_WeldingProject
            // 
            this.Label_WeldingProject.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingProject.AutoSize = true;
            this.Label_WeldingProject.Location = new System.Drawing.Point(354, 10);
            this.Label_WeldingProject.Name = "Label_WeldingProject";
            this.Label_WeldingProject.Size = new System.Drawing.Size(41, 12);
            this.Label_WeldingProject.TabIndex = 485;
            this.Label_WeldingProject.Text = "工程：";
            // 
            // TextBox_WeldingStandard
            // 
            this.TextBox_WeldingStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WeldingStandard.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_WeldingStandard.Location = new System.Drawing.Point(235, 3);
            this.TextBox_WeldingStandard.Name = "TextBox_WeldingStandard";
            this.TextBox_WeldingStandard.ReadOnly = true;
            this.TextBox_WeldingStandard.Size = new System.Drawing.Size(108, 21);
            this.TextBox_WeldingStandard.TabIndex = 1;
            // 
            // Label_WeldingStandard
            // 
            this.Label_WeldingStandard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingStandard.AutoSize = true;
            this.Label_WeldingStandard.Location = new System.Drawing.Point(188, 10);
            this.Label_WeldingStandard.Name = "Label_WeldingStandard";
            this.Label_WeldingStandard.Size = new System.Drawing.Size(41, 12);
            this.Label_WeldingStandard.TabIndex = 205;
            this.Label_WeldingStandard.Text = "标准：";
            // 
            // Button_SubjectQuery
            // 
            this.Button_SubjectQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_SubjectQuery.Location = new System.Drawing.Point(613, 35);
            this.Button_SubjectQuery.Name = "Button_SubjectQuery";
            this.Button_SubjectQuery.Size = new System.Drawing.Size(89, 26);
            this.Button_SubjectQuery.TabIndex = 7;
            this.Button_SubjectQuery.Text = "查询";
            this.Button_SubjectQuery.UseVisualStyleBackColor = true;
            this.Button_SubjectQuery.Click += new System.EventHandler(this.Button_SubjectQuery_Click);
            // 
            // label_Data
            // 
            this.label_Data.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Data.AutoSize = true;
            this.label_Data.Location = new System.Drawing.Point(3, 7);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(41, 12);
            this.label_Data.TabIndex = 3;
            this.label_Data.Text = "数据：";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem_DataGridViewRowFrozenThisColumn
            // 
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Name = "toolStripMenuItem_DataGridViewRowFrozenThisColumn";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem_DataGridViewRowExport
            // 
            this.toolStripMenuItem_DataGridViewRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowExportToExcel});
            this.toolStripMenuItem_DataGridViewRowExport.Name = "toolStripMenuItem_DataGridViewRowExport";
            this.toolStripMenuItem_DataGridViewRowExport.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowExport.Text = "导出";
            // 
            // toolStripMenuItem_DataGridViewRowExportToExcel
            // 
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Name = "toolStripMenuItem_DataGridViewRowExportToExcel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // toolStripMenuItem_DataGridViewRowDelete
            // 
            this.toolStripMenuItem_DataGridViewRowDelete.Name = "toolStripMenuItem_DataGridViewRowDelete";
            this.toolStripMenuItem_DataGridViewRowDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowDelete.Text = "删除";
            this.toolStripMenuItem_DataGridViewRowDelete.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowDelete_Click);
            // 
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowDelete,
            this.toolStripSeparator2,
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(153, 104);
            // 
            // Label_IssueNo
            // 
            this.Label_IssueNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IssueNo.AutoSize = true;
            this.Label_IssueNo.Location = new System.Drawing.Point(292, 7);
            this.Label_IssueNo.Name = "Label_IssueNo";
            this.Label_IssueNo.Size = new System.Drawing.Size(65, 12);
            this.Label_IssueNo.TabIndex = 478;
            this.Label_IssueNo.Text = "班级名称：";
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.AllowUserToAddRows = false;
            this.dataGridView_Data.AllowUserToDeleteRows = false;
            this.dataGridView_Data.AllowUserToOrderColumns = true;
            this.dataGridView_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.Location = new System.Drawing.Point(27, 36);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.ReadOnly = true;
            this.dataGridView_Data.RowTemplate.Height = 23;
            this.dataGridView_Data.Size = new System.Drawing.Size(741, 329);
            this.dataGridView_Data.TabIndex = 486;
            this.dataGridView_Data.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 283F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel4.Controls.Add(this.button_WelderAdd, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.MaskedTextBox_KindofEmployerIssueID, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.Label_KindofEmployerIssueID, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label_Data, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Label_IssueNo, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.TextBox_IssueNo, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(27, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(741, 27);
            this.tableLayoutPanel4.TabIndex = 491;
            // 
            // TextBox_IssueNo
            // 
            this.TextBox_IssueNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_IssueNo.Location = new System.Drawing.Point(363, 3);
            this.TextBox_IssueNo.Name = "TextBox_IssueNo";
            this.TextBox_IssueNo.ReadOnly = true;
            this.TextBox_IssueNo.Size = new System.Drawing.Size(104, 21);
            this.TextBox_IssueNo.TabIndex = 1;
            // 
            // Form_KindofEmployerStudent_AddBatch
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(792, 513);
            this.Controls.Add(this.label_ErrMessage);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView_Data);
            this.Controls.Add(this.GroupBox_Subject);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "Form_KindofEmployerStudent_AddBatch";
            this.Text = "批量添加学员";
            this.Load += new System.EventHandler(this.Form_KindofEmployerStudent_AddBatch_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.GroupBox_Subject.ResumeLayout(false);
            this.TableLayoutPanel3.ResumeLayout(false);
            this.TableLayoutPanel3.PerformLayout();
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_WelderAdd;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_KindofEmployerIssueID;
        internal System.Windows.Forms.TextBox TextBox_Subject;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal System.Windows.Forms.Label Label_Subject;
        internal System.Windows.Forms.Label Label_WorkPieceType;
        internal System.Windows.Forms.TextBox TextBox_SubjectID;
        internal System.Windows.Forms.TextBox TextBox_WorkPieceType;
        internal System.Windows.Forms.Label Label_SubjectID;
        internal System.Windows.Forms.Label Label_JointType;
        internal System.Windows.Forms.TextBox TextBox_JointType;
        internal System.Windows.Forms.TextBox TextBox_WeldingClass;
        internal System.Windows.Forms.Label Label_WeldingClass;
        internal System.Windows.Forms.TextBox TextBox_WeldingProject;
        internal System.Windows.Forms.Label Label_WeldingProject;
        internal System.Windows.Forms.TextBox TextBox_WeldingStandard;
        internal System.Windows.Forms.Label Label_WeldingStandard;
        internal System.Windows.Forms.Button Button_SubjectQuery;
        internal System.Windows.Forms.Label Label_KindofEmployerIssueID;
        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        internal System.Windows.Forms.GroupBox GroupBox_Subject;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowFrozenThisColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridViewRow;
        internal System.Windows.Forms.Label Label_IssueNo;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        internal System.Windows.Forms.TextBox TextBox_IssueNo;
    }
}