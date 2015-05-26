namespace ZCWelder.Exam
{
    partial class Form_QC_AddBatch
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
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label_Modified = new System.Windows.Forms.Label();
            this.dataGridView_Modified = new System.Windows.Forms.DataGridView();
            this.dataGridView_Origin = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label_Origin = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Reset = new System.Windows.Forms.Button();
            this.button_Modify = new System.Windows.Forms.Button();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.NumericUpDown_OriginalPeriod = new System.Windows.Forms.NumericUpDown();
            this.TextBox_SupervisionPlace = new System.Windows.Forms.TextBox();
            this.Label_PeriodofValidity = new System.Windows.Forms.Label();
            this.Label_SupervisionPlace = new System.Windows.Forms.Label();
            this.TextBox_WeldingProcessAb = new System.Windows.Forms.TextBox();
            this.DateTimePicker_IssuedOn = new System.Windows.Forms.DateTimePicker();
            this.Label_IssuedOn = new System.Windows.Forms.Label();
            this.Label_WeldingProcessAb = new System.Windows.Forms.Label();
            this.Label_IssueNo = new System.Windows.Forms.Label();
            this.TextBox_IssueNo = new System.Windows.Forms.TextBox();
            this.Label_CertificateNo = new System.Windows.Forms.Label();
            this.MaskedTextBox_NextCertificateNo = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip_ModifiedRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ModifiedRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ModifiedRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ModifiedRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Modified)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Origin)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_OriginalPeriod)).BeginInit();
            this.contextMenuStrip_ModifiedRow.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label_Modified);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridView_Modified);
            this.splitContainer4.Size = new System.Drawing.Size(431, 295);
            this.splitContainer4.SplitterDistance = 30;
            this.splitContainer4.TabIndex = 0;
            // 
            // label_Modified
            // 
            this.label_Modified.AutoSize = true;
            this.label_Modified.Location = new System.Drawing.Point(16, 9);
            this.label_Modified.Name = "label_Modified";
            this.label_Modified.Size = new System.Drawing.Size(341, 12);
            this.label_Modified.TabIndex = 1;
            this.label_Modified.Text = "新证书(只填充原始数据中合格、没有证书且选中的学员证书)：";
            // 
            // dataGridView_Modified
            // 
            this.dataGridView_Modified.AllowUserToAddRows = false;
            this.dataGridView_Modified.AllowUserToDeleteRows = false;
            this.dataGridView_Modified.AllowUserToOrderColumns = true;
            this.dataGridView_Modified.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Modified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Modified.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Modified.Name = "dataGridView_Modified";
            this.dataGridView_Modified.RowTemplate.Height = 23;
            this.dataGridView_Modified.Size = new System.Drawing.Size(429, 259);
            this.dataGridView_Modified.TabIndex = 0;
            this.dataGridView_Modified.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Modified_CellContextMenuStripNeeded);
            // 
            // dataGridView_Origin
            // 
            this.dataGridView_Origin.AllowUserToAddRows = false;
            this.dataGridView_Origin.AllowUserToDeleteRows = false;
            this.dataGridView_Origin.AllowUserToOrderColumns = true;
            this.dataGridView_Origin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Origin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Origin.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Origin.Name = "dataGridView_Origin";
            this.dataGridView_Origin.ReadOnly = true;
            this.dataGridView_Origin.RowTemplate.Height = 23;
            this.dataGridView_Origin.Size = new System.Drawing.Size(429, 230);
            this.dataGridView_Origin.TabIndex = 0;
            this.dataGridView_Origin.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(431, 566);
            this.splitContainer2.SplitterDistance = 267;
            this.splitContainer2.TabIndex = 0;
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
            this.splitContainer3.Panel1.Controls.Add(this.label_Origin);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView_Origin);
            this.splitContainer3.Size = new System.Drawing.Size(431, 267);
            this.splitContainer3.SplitterDistance = 31;
            this.splitContainer3.TabIndex = 0;
            // 
            // label_Origin
            // 
            this.label_Origin.AutoSize = true;
            this.label_Origin.Location = new System.Drawing.Point(16, 8);
            this.label_Origin.Name = "label_Origin";
            this.label_Origin.Size = new System.Drawing.Size(65, 12);
            this.label_Origin.TabIndex = 0;
            this.label_Origin.Text = "原始数据：";
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
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.TableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(698, 566);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_Reset, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Modify, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_OnOK, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Cancel, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 459);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(236, 94);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(3, 3);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(98, 35);
            this.button_Reset.TabIndex = 0;
            this.button_Reset.Text = "重置";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // button_Modify
            // 
            this.button_Modify.Location = new System.Drawing.Point(121, 3);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(98, 35);
            this.button_Modify.TabIndex = 1;
            this.button_Modify.Text = "填充";
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // button_OnOK
            // 
            this.button_OnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OnOK.Location = new System.Drawing.Point(121, 50);
            this.button_OnOK.Name = "button_OnOK";
            this.button_OnOK.Size = new System.Drawing.Size(98, 35);
            this.button_OnOK.TabIndex = 0;
            this.button_OnOK.Text = "确定";
            this.button_OnOK.UseVisualStyleBackColor = true;
            this.button_OnOK.Click += new System.EventHandler(this.button_OnOK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(3, 50);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(98, 35);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 2;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.TableLayoutPanel2.Controls.Add(this.NumericUpDown_OriginalPeriod, 1, 5);
            this.TableLayoutPanel2.Controls.Add(this.TextBox_SupervisionPlace, 1, 3);
            this.TableLayoutPanel2.Controls.Add(this.Label_PeriodofValidity, 0, 5);
            this.TableLayoutPanel2.Controls.Add(this.Label_SupervisionPlace, 0, 3);
            this.TableLayoutPanel2.Controls.Add(this.TextBox_WeldingProcessAb, 1, 1);
            this.TableLayoutPanel2.Controls.Add(this.DateTimePicker_IssuedOn, 1, 4);
            this.TableLayoutPanel2.Controls.Add(this.Label_IssuedOn, 0, 4);
            this.TableLayoutPanel2.Controls.Add(this.Label_WeldingProcessAb, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.Label_IssueNo, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.TextBox_IssueNo, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.Label_CertificateNo, 0, 2);
            this.TableLayoutPanel2.Controls.Add(this.MaskedTextBox_NextCertificateNo, 1, 2);
            this.TableLayoutPanel2.Location = new System.Drawing.Point(11, 11);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 6;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(242, 220);
            this.TableLayoutPanel2.TabIndex = 15;
            // 
            // NumericUpDown_OriginalPeriod
            // 
            this.NumericUpDown_OriginalPeriod.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ZCWelder.Properties.Settings.Default, "OriginalPeriod", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NumericUpDown_OriginalPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumericUpDown_OriginalPeriod.Location = new System.Drawing.Point(87, 183);
            this.NumericUpDown_OriginalPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_OriginalPeriod.Name = "NumericUpDown_OriginalPeriod";
            this.NumericUpDown_OriginalPeriod.Size = new System.Drawing.Size(152, 21);
            this.NumericUpDown_OriginalPeriod.TabIndex = 496;
            this.NumericUpDown_OriginalPeriod.Value = global::ZCWelder.Properties.Settings.Default.OriginalPeriod;
            // 
            // TextBox_SupervisionPlace
            // 
            this.TextBox_SupervisionPlace.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZCWelder.Properties.Settings.Default, "SupervisionPlace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBox_SupervisionPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_SupervisionPlace.Location = new System.Drawing.Point(87, 111);
            this.TextBox_SupervisionPlace.MaxLength = 10;
            this.TextBox_SupervisionPlace.Name = "TextBox_SupervisionPlace";
            this.TextBox_SupervisionPlace.Size = new System.Drawing.Size(152, 21);
            this.TextBox_SupervisionPlace.TabIndex = 84;
            this.TextBox_SupervisionPlace.Text = global::ZCWelder.Properties.Settings.Default.SupervisionPlace;
            // 
            // Label_PeriodofValidity
            // 
            this.Label_PeriodofValidity.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_PeriodofValidity.AutoSize = true;
            this.Label_PeriodofValidity.Location = new System.Drawing.Point(4, 194);
            this.Label_PeriodofValidity.Name = "Label_PeriodofValidity";
            this.Label_PeriodofValidity.Size = new System.Drawing.Size(77, 12);
            this.Label_PeriodofValidity.TabIndex = 82;
            this.Label_PeriodofValidity.Text = "有效期(年)：";
            // 
            // Label_SupervisionPlace
            // 
            this.Label_SupervisionPlace.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_SupervisionPlace.AutoSize = true;
            this.Label_SupervisionPlace.Location = new System.Drawing.Point(16, 120);
            this.Label_SupervisionPlace.Name = "Label_SupervisionPlace";
            this.Label_SupervisionPlace.Size = new System.Drawing.Size(65, 12);
            this.Label_SupervisionPlace.TabIndex = 85;
            this.Label_SupervisionPlace.Text = "考察地点：";
            // 
            // TextBox_WeldingProcessAb
            // 
            this.TextBox_WeldingProcessAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WeldingProcessAb.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_WeldingProcessAb.Location = new System.Drawing.Point(87, 39);
            this.TextBox_WeldingProcessAb.Name = "TextBox_WeldingProcessAb";
            this.TextBox_WeldingProcessAb.ReadOnly = true;
            this.TextBox_WeldingProcessAb.Size = new System.Drawing.Size(152, 21);
            this.TextBox_WeldingProcessAb.TabIndex = 221;
            // 
            // DateTimePicker_IssuedOn
            // 
            this.DateTimePicker_IssuedOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTimePicker_IssuedOn.Location = new System.Drawing.Point(87, 147);
            this.DateTimePicker_IssuedOn.Name = "DateTimePicker_IssuedOn";
            this.DateTimePicker_IssuedOn.Size = new System.Drawing.Size(152, 21);
            this.DateTimePicker_IssuedOn.TabIndex = 80;
            // 
            // Label_IssuedOn
            // 
            this.Label_IssuedOn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IssuedOn.AutoSize = true;
            this.Label_IssuedOn.Location = new System.Drawing.Point(16, 156);
            this.Label_IssuedOn.Name = "Label_IssuedOn";
            this.Label_IssuedOn.Size = new System.Drawing.Size(65, 12);
            this.Label_IssuedOn.TabIndex = 79;
            this.Label_IssuedOn.Text = "发证日期：";
            // 
            // Label_WeldingProcessAb
            // 
            this.Label_WeldingProcessAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingProcessAb.AutoSize = true;
            this.Label_WeldingProcessAb.Location = new System.Drawing.Point(16, 48);
            this.Label_WeldingProcessAb.Name = "Label_WeldingProcessAb";
            this.Label_WeldingProcessAb.Size = new System.Drawing.Size(65, 12);
            this.Label_WeldingProcessAb.TabIndex = 219;
            this.Label_WeldingProcessAb.Text = "焊接方法：";
            // 
            // Label_IssueNo
            // 
            this.Label_IssueNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IssueNo.AutoSize = true;
            this.Label_IssueNo.Location = new System.Drawing.Point(16, 12);
            this.Label_IssueNo.Name = "Label_IssueNo";
            this.Label_IssueNo.Size = new System.Drawing.Size(65, 12);
            this.Label_IssueNo.TabIndex = 218;
            this.Label_IssueNo.Text = "班级编号：";
            // 
            // TextBox_IssueNo
            // 
            this.TextBox_IssueNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_IssueNo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_IssueNo.Location = new System.Drawing.Point(87, 3);
            this.TextBox_IssueNo.Name = "TextBox_IssueNo";
            this.TextBox_IssueNo.ReadOnly = true;
            this.TextBox_IssueNo.Size = new System.Drawing.Size(152, 21);
            this.TextBox_IssueNo.TabIndex = 220;
            // 
            // Label_CertificateNo
            // 
            this.Label_CertificateNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_CertificateNo.AutoSize = true;
            this.Label_CertificateNo.Location = new System.Drawing.Point(16, 84);
            this.Label_CertificateNo.Name = "Label_CertificateNo";
            this.Label_CertificateNo.Size = new System.Drawing.Size(65, 12);
            this.Label_CertificateNo.TabIndex = 76;
            this.Label_CertificateNo.Text = "证号起始：";
            // 
            // MaskedTextBox_NextCertificateNo
            // 
            this.MaskedTextBox_NextCertificateNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_NextCertificateNo.Location = new System.Drawing.Point(87, 75);
            this.MaskedTextBox_NextCertificateNo.Name = "MaskedTextBox_NextCertificateNo";
            this.MaskedTextBox_NextCertificateNo.ReadOnly = true;
            this.MaskedTextBox_NextCertificateNo.Size = new System.Drawing.Size(152, 21);
            this.MaskedTextBox_NextCertificateNo.TabIndex = 497;
            // 
            // contextMenuStrip_ModifiedRow
            // 
            this.contextMenuStrip_ModifiedRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ModifiedRowFrozenThisColumn,
            this.toolStripSeparator1,
            this.toolStripMenuItem_ModifiedRowExport});
            this.contextMenuStrip_ModifiedRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_ModifiedRow.Size = new System.Drawing.Size(119, 54);
            // 
            // toolStripMenuItem_ModifiedRowFrozenThisColumn
            // 
            this.toolStripMenuItem_ModifiedRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_ModifiedRowFrozenThisColumn.Name = "toolStripMenuItem_ModifiedRowFrozenThisColumn";
            this.toolStripMenuItem_ModifiedRowFrozenThisColumn.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem_ModifiedRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_ModifiedRowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_ModifiedRowFrozenThisColumn_CheckStateChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(115, 6);
            // 
            // toolStripMenuItem_ModifiedRowExport
            // 
            this.toolStripMenuItem_ModifiedRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ModifiedRowExportToExcel});
            this.toolStripMenuItem_ModifiedRowExport.Name = "toolStripMenuItem_ModifiedRowExport";
            this.toolStripMenuItem_ModifiedRowExport.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem_ModifiedRowExport.Text = "导出";
            // 
            // toolStripMenuItem_ModifiedRowExportToExcel
            // 
            this.toolStripMenuItem_ModifiedRowExportToExcel.Name = "toolStripMenuItem_ModifiedRowExportToExcel";
            this.toolStripMenuItem_ModifiedRowExportToExcel.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_ModifiedRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_ModifiedRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_ModifiedRowExportToExcel_Click);
            // 
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(119, 54);
            // 
            // toolStripMenuItem_DataGridViewRowFrozenThisColumn
            // 
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Name = "toolStripMenuItem_DataGridViewRowFrozenThisColumn";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(115, 6);
            // 
            // toolStripMenuItem_DataGridViewRowExport
            // 
            this.toolStripMenuItem_DataGridViewRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowExportToExcel});
            this.toolStripMenuItem_DataGridViewRowExport.Name = "toolStripMenuItem_DataGridViewRowExport";
            this.toolStripMenuItem_DataGridViewRowExport.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem_DataGridViewRowExport.Text = "导出";
            // 
            // toolStripMenuItem_DataGridViewRowExportToExcel
            // 
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Name = "toolStripMenuItem_DataGridViewRowExportToExcel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // Form_QC_AddBatch
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(698, 566);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_QC_AddBatch";
            this.Text = "批量添加证书";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_QC_AddBatch_Load);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Modified)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Origin)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_OriginalPeriod)).EndInit();
            this.contextMenuStrip_ModifiedRow.ResumeLayout(false);
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label_Modified;
        private System.Windows.Forms.DataGridView dataGridView_Modified;
        private System.Windows.Forms.DataGridView dataGridView_Origin;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label_Origin;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_OriginalPeriod;
        internal System.Windows.Forms.TextBox TextBox_SupervisionPlace;
        internal System.Windows.Forms.Label Label_PeriodofValidity;
        internal System.Windows.Forms.Label Label_SupervisionPlace;
        internal System.Windows.Forms.TextBox TextBox_WeldingProcessAb;
        internal System.Windows.Forms.DateTimePicker DateTimePicker_IssuedOn;
        internal System.Windows.Forms.Label Label_IssuedOn;
        internal System.Windows.Forms.Label Label_WeldingProcessAb;
        internal System.Windows.Forms.Label Label_IssueNo;
        internal System.Windows.Forms.TextBox TextBox_IssueNo;
        internal System.Windows.Forms.Label Label_CertificateNo;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_NextCertificateNo;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ModifiedRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ModifiedRowFrozenThisColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ModifiedRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ModifiedRowExportToExcel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridViewRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowFrozenThisColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
    }
}