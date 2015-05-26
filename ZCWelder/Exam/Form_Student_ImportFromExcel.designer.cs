namespace ZCWelder.Exam
{
    partial class Form_Student_ImportFromExcel
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GroupBox_Base = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_ShipClassificationAb = new System.Windows.Forms.Label();
            this.Label_IssueNo = new System.Windows.Forms.Label();
            this.Label_SignUpDate = new System.Windows.Forms.Label();
            this.DateTimePicker_SignUpDate = new System.Windows.Forms.DateTimePicker();
            this.Label_Employer = new System.Windows.Forms.Label();
            this.Label_KindofEmployer = new System.Windows.Forms.Label();
            this.Label_ShipboardNo = new System.Windows.Forms.Label();
            this.MaskedTextBox_IssueNo = new System.Windows.Forms.MaskedTextBox();
            this.TextBox_ShipboardNo = new System.Windows.Forms.TextBox();
            this.textBox_ShipClassificationAb = new System.Windows.Forms.TextBox();
            this.textBox_Employer = new System.Windows.Forms.TextBox();
            this.textBox_KindofEmployer = new System.Windows.Forms.TextBox();
            this.GroupBox_WeldingParameter = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_WeldingProcess = new System.Windows.Forms.Label();
            this.Label_Assemblage = new System.Windows.Forms.Label();
            this.ComboBox_WeldingProcess = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.ComboBox_Assemblage = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label_Material = new System.Windows.Forms.Label();
            this.TextBox_WeldingRodDiameter = new System.Windows.Forms.TextBox();
            this.TextBox_RenderWeldingRodDiameter = new System.Windows.Forms.TextBox();
            this.Label_WeldingConsumable = new System.Windows.Forms.Label();
            this.Label_RenderWeldingRodDiameter = new System.Windows.Forms.Label();
            this.Label_WeldingRodDiameter = new System.Windows.Forms.Label();
            this.Label_CoverWeldingRodDiameter = new System.Windows.Forms.Label();
            this.Label_KindofExam = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.TextBox_CoverWeldingRodDiameter = new System.Windows.Forms.TextBox();
            this.Label_Thickness = new System.Windows.Forms.Label();
            this.Label_ExternalDiameter = new System.Windows.Forms.Label();
            this.ComboBox_KindofExam = new System.Windows.Forms.ComboBox();
            this.TextBox_Thickness = new System.Windows.Forms.TextBox();
            this.TextBox_ExternalDiameter = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label_DimensionofMaterial = new System.Windows.Forms.Label();
            this.ComboBox_DimensionofMaterial = new System.Windows.Forms.ComboBox();
            this.textBox_Material = new System.Windows.Forms.TextBox();
            this.textBox_WeldingConsumable = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label_Data = new System.Windows.Forms.Label();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.GroupBox_Base.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.GroupBox_WeldingParameter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.GroupBox_Base);
            this.splitContainer1.Panel1.Controls.Add(this.GroupBox_WeldingParameter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(797, 530);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 0;
            // 
            // GroupBox_Base
            // 
            this.GroupBox_Base.Controls.Add(this.tableLayoutPanel3);
            this.GroupBox_Base.Location = new System.Drawing.Point(12, 3);
            this.GroupBox_Base.Name = "GroupBox_Base";
            this.GroupBox_Base.Size = new System.Drawing.Size(741, 89);
            this.GroupBox_Base.TabIndex = 482;
            this.GroupBox_Base.TabStop = false;
            this.GroupBox_Base.Text = "基本参数";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.35119F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.96581F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.36752F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.96581F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.36752F));
            this.tableLayoutPanel3.Controls.Add(this.Label_ShipClassificationAb, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.Label_IssueNo, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Label_SignUpDate, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.DateTimePicker_SignUpDate, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.Label_Employer, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.Label_KindofEmployer, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Label_ShipboardNo, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.MaskedTextBox_IssueNo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.TextBox_ShipboardNo, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox_ShipClassificationAb, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_Employer, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox_KindofEmployer, 1, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(19, 20);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(705, 56);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // Label_ShipClassificationAb
            // 
            this.Label_ShipClassificationAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_ShipClassificationAb.AutoSize = true;
            this.Label_ShipClassificationAb.Location = new System.Drawing.Point(496, 8);
            this.Label_ShipClassificationAb.Name = "Label_ShipClassificationAb";
            this.Label_ShipClassificationAb.Size = new System.Drawing.Size(53, 12);
            this.Label_ShipClassificationAb.TabIndex = 504;
            this.Label_ShipClassificationAb.Text = "船级社：";
            // 
            // Label_IssueNo
            // 
            this.Label_IssueNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IssueNo.AutoSize = true;
            this.Label_IssueNo.Location = new System.Drawing.Point(19, 8);
            this.Label_IssueNo.Name = "Label_IssueNo";
            this.Label_IssueNo.Size = new System.Drawing.Size(65, 12);
            this.Label_IssueNo.TabIndex = 499;
            this.Label_IssueNo.Text = "班级编号：";
            // 
            // Label_SignUpDate
            // 
            this.Label_SignUpDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_SignUpDate.AutoSize = true;
            this.Label_SignUpDate.Location = new System.Drawing.Point(250, 8);
            this.Label_SignUpDate.Name = "Label_SignUpDate";
            this.Label_SignUpDate.Size = new System.Drawing.Size(65, 12);
            this.Label_SignUpDate.TabIndex = 476;
            this.Label_SignUpDate.Text = "报名日期：";
            // 
            // DateTimePicker_SignUpDate
            // 
            this.DateTimePicker_SignUpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTimePicker_SignUpDate.Enabled = false;
            this.DateTimePicker_SignUpDate.Location = new System.Drawing.Point(321, 3);
            this.DateTimePicker_SignUpDate.Name = "DateTimePicker_SignUpDate";
            this.DateTimePicker_SignUpDate.Size = new System.Drawing.Size(144, 21);
            this.DateTimePicker_SignUpDate.TabIndex = 1;
            // 
            // Label_Employer
            // 
            this.Label_Employer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Employer.AutoSize = true;
            this.Label_Employer.Location = new System.Drawing.Point(274, 36);
            this.Label_Employer.Name = "Label_Employer";
            this.Label_Employer.Size = new System.Drawing.Size(41, 12);
            this.Label_Employer.TabIndex = 497;
            this.Label_Employer.Text = "公司：";
            // 
            // Label_KindofEmployer
            // 
            this.Label_KindofEmployer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_KindofEmployer.AutoSize = true;
            this.Label_KindofEmployer.Location = new System.Drawing.Point(19, 36);
            this.Label_KindofEmployer.Name = "Label_KindofEmployer";
            this.Label_KindofEmployer.Size = new System.Drawing.Size(65, 12);
            this.Label_KindofEmployer.TabIndex = 498;
            this.Label_KindofEmployer.Text = "报考单位：";
            // 
            // Label_ShipboardNo
            // 
            this.Label_ShipboardNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_ShipboardNo.AutoSize = true;
            this.Label_ShipboardNo.Location = new System.Drawing.Point(484, 36);
            this.Label_ShipboardNo.Name = "Label_ShipboardNo";
            this.Label_ShipboardNo.Size = new System.Drawing.Size(65, 12);
            this.Label_ShipboardNo.TabIndex = 507;
            this.Label_ShipboardNo.Text = "船舶系列：";
            // 
            // MaskedTextBox_IssueNo
            // 
            this.MaskedTextBox_IssueNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_IssueNo.Location = new System.Drawing.Point(90, 3);
            this.MaskedTextBox_IssueNo.Name = "MaskedTextBox_IssueNo";
            this.MaskedTextBox_IssueNo.ReadOnly = true;
            this.MaskedTextBox_IssueNo.Size = new System.Drawing.Size(141, 21);
            this.MaskedTextBox_IssueNo.TabIndex = 0;
            // 
            // TextBox_ShipboardNo
            // 
            this.TextBox_ShipboardNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_ShipboardNo.Location = new System.Drawing.Point(555, 31);
            this.TextBox_ShipboardNo.Name = "TextBox_ShipboardNo";
            this.TextBox_ShipboardNo.ReadOnly = true;
            this.TextBox_ShipboardNo.Size = new System.Drawing.Size(147, 21);
            this.TextBox_ShipboardNo.TabIndex = 5;
            // 
            // textBox_ShipClassificationAb
            // 
            this.textBox_ShipClassificationAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ShipClassificationAb.Location = new System.Drawing.Point(555, 3);
            this.textBox_ShipClassificationAb.Name = "textBox_ShipClassificationAb";
            this.textBox_ShipClassificationAb.ReadOnly = true;
            this.textBox_ShipClassificationAb.Size = new System.Drawing.Size(147, 21);
            this.textBox_ShipClassificationAb.TabIndex = 4;
            // 
            // textBox_Employer
            // 
            this.textBox_Employer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Employer.Location = new System.Drawing.Point(321, 31);
            this.textBox_Employer.Name = "textBox_Employer";
            this.textBox_Employer.ReadOnly = true;
            this.textBox_Employer.Size = new System.Drawing.Size(144, 21);
            this.textBox_Employer.TabIndex = 3;
            // 
            // textBox_KindofEmployer
            // 
            this.textBox_KindofEmployer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_KindofEmployer.Location = new System.Drawing.Point(90, 31);
            this.textBox_KindofEmployer.Name = "textBox_KindofEmployer";
            this.textBox_KindofEmployer.ReadOnly = true;
            this.textBox_KindofEmployer.Size = new System.Drawing.Size(141, 21);
            this.textBox_KindofEmployer.TabIndex = 2;
            // 
            // GroupBox_WeldingParameter
            // 
            this.GroupBox_WeldingParameter.Controls.Add(this.tableLayoutPanel1);
            this.GroupBox_WeldingParameter.Location = new System.Drawing.Point(12, 95);
            this.GroupBox_WeldingParameter.Name = "GroupBox_WeldingParameter";
            this.GroupBox_WeldingParameter.Size = new System.Drawing.Size(741, 139);
            this.GroupBox_WeldingParameter.TabIndex = 481;
            this.GroupBox_WeldingParameter.TabStop = false;
            this.GroupBox_WeldingParameter.Text = "焊接参数";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Controls.Add(this.Label_WeldingProcess, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_Assemblage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_WeldingProcess, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label4, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_Assemblage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label3, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_Material, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_WeldingRodDiameter, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_RenderWeldingRodDiameter, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_WeldingConsumable, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label_RenderWeldingRodDiameter, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_WeldingRodDiameter, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label_CoverWeldingRodDiameter, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label_KindofExam, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Label5, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_CoverWeldingRodDiameter, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label_Thickness, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label_ExternalDiameter, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_KindofExam, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_Thickness, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_ExternalDiameter, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label7, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label_DimensionofMaterial, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_DimensionofMaterial, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Material, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingConsumable, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(705, 113);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Label_WeldingProcess
            // 
            this.Label_WeldingProcess.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingProcess.AutoSize = true;
            this.Label_WeldingProcess.Location = new System.Drawing.Point(15, 8);
            this.Label_WeldingProcess.Name = "Label_WeldingProcess";
            this.Label_WeldingProcess.Size = new System.Drawing.Size(65, 12);
            this.Label_WeldingProcess.TabIndex = 451;
            this.Label_WeldingProcess.Text = "焊接方法：";
            // 
            // Label_Assemblage
            // 
            this.Label_Assemblage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Assemblage.AutoSize = true;
            this.Label_Assemblage.Location = new System.Drawing.Point(39, 36);
            this.Label_Assemblage.Name = "Label_Assemblage";
            this.Label_Assemblage.Size = new System.Drawing.Size(41, 12);
            this.Label_Assemblage.TabIndex = 454;
            this.Label_Assemblage.Text = "装配：";
            // 
            // ComboBox_WeldingProcess
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ComboBox_WeldingProcess, 2);
            this.ComboBox_WeldingProcess.DisplayMember = "WeldingProcessAb";
            this.ComboBox_WeldingProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_WeldingProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_WeldingProcess.Enabled = false;
            this.ComboBox_WeldingProcess.FormattingEnabled = true;
            this.ComboBox_WeldingProcess.Location = new System.Drawing.Point(86, 3);
            this.ComboBox_WeldingProcess.Name = "ComboBox_WeldingProcess";
            this.ComboBox_WeldingProcess.Size = new System.Drawing.Size(134, 20);
            this.ComboBox_WeldingProcess.TabIndex = 0;
            this.ComboBox_WeldingProcess.ValueMember = "WeldingProcessAb";
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(685, 36);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(17, 12);
            this.Label4.TabIndex = 488;
            this.Label4.Text = "mm";
            // 
            // ComboBox_Assemblage
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ComboBox_Assemblage, 2);
            this.ComboBox_Assemblage.DisplayMember = "Assemblage";
            this.ComboBox_Assemblage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_Assemblage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Assemblage.Enabled = false;
            this.ComboBox_Assemblage.FormattingEnabled = true;
            this.ComboBox_Assemblage.Location = new System.Drawing.Point(86, 31);
            this.ComboBox_Assemblage.Name = "ComboBox_Assemblage";
            this.ComboBox_Assemblage.Size = new System.Drawing.Size(134, 20);
            this.ComboBox_Assemblage.TabIndex = 1;
            this.ComboBox_Assemblage.ValueMember = "Assemblage";
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(685, 8);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(17, 12);
            this.Label3.TabIndex = 487;
            this.Label3.Text = "mm";
            // 
            // Label_Material
            // 
            this.Label_Material.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Material.AutoSize = true;
            this.Label_Material.Location = new System.Drawing.Point(259, 8);
            this.Label_Material.Name = "Label_Material";
            this.Label_Material.Size = new System.Drawing.Size(41, 12);
            this.Label_Material.TabIndex = 452;
            this.Label_Material.Text = "母材：";
            // 
            // TextBox_WeldingRodDiameter
            // 
            this.TextBox_WeldingRodDiameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WeldingRodDiameter.Location = new System.Drawing.Point(616, 31);
            this.TextBox_WeldingRodDiameter.Name = "TextBox_WeldingRodDiameter";
            this.TextBox_WeldingRodDiameter.ReadOnly = true;
            this.TextBox_WeldingRodDiameter.Size = new System.Drawing.Size(60, 21);
            this.TextBox_WeldingRodDiameter.TabIndex = 7;
            // 
            // TextBox_RenderWeldingRodDiameter
            // 
            this.TextBox_RenderWeldingRodDiameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_RenderWeldingRodDiameter.Location = new System.Drawing.Point(616, 3);
            this.TextBox_RenderWeldingRodDiameter.Name = "TextBox_RenderWeldingRodDiameter";
            this.TextBox_RenderWeldingRodDiameter.ReadOnly = true;
            this.TextBox_RenderWeldingRodDiameter.Size = new System.Drawing.Size(60, 21);
            this.TextBox_RenderWeldingRodDiameter.TabIndex = 6;
            // 
            // Label_WeldingConsumable
            // 
            this.Label_WeldingConsumable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingConsumable.AutoSize = true;
            this.Label_WeldingConsumable.Location = new System.Drawing.Point(235, 36);
            this.Label_WeldingConsumable.Name = "Label_WeldingConsumable";
            this.Label_WeldingConsumable.Size = new System.Drawing.Size(65, 12);
            this.Label_WeldingConsumable.TabIndex = 453;
            this.Label_WeldingConsumable.Text = "焊接材料：";
            // 
            // Label_RenderWeldingRodDiameter
            // 
            this.Label_RenderWeldingRodDiameter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_RenderWeldingRodDiameter.AutoSize = true;
            this.Label_RenderWeldingRodDiameter.Location = new System.Drawing.Point(497, 8);
            this.Label_RenderWeldingRodDiameter.Name = "Label_RenderWeldingRodDiameter";
            this.Label_RenderWeldingRodDiameter.Size = new System.Drawing.Size(113, 12);
            this.Label_RenderWeldingRodDiameter.TabIndex = 484;
            this.Label_RenderWeldingRodDiameter.Text = "打底焊条(丝)直径：";
            // 
            // Label_WeldingRodDiameter
            // 
            this.Label_WeldingRodDiameter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingRodDiameter.AutoSize = true;
            this.Label_WeldingRodDiameter.Location = new System.Drawing.Point(497, 36);
            this.Label_WeldingRodDiameter.Name = "Label_WeldingRodDiameter";
            this.Label_WeldingRodDiameter.Size = new System.Drawing.Size(113, 12);
            this.Label_WeldingRodDiameter.TabIndex = 485;
            this.Label_WeldingRodDiameter.Text = "填充焊条(丝)直径：";
            // 
            // Label_CoverWeldingRodDiameter
            // 
            this.Label_CoverWeldingRodDiameter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_CoverWeldingRodDiameter.AutoSize = true;
            this.Label_CoverWeldingRodDiameter.Location = new System.Drawing.Point(497, 64);
            this.Label_CoverWeldingRodDiameter.Name = "Label_CoverWeldingRodDiameter";
            this.Label_CoverWeldingRodDiameter.Size = new System.Drawing.Size(113, 12);
            this.Label_CoverWeldingRodDiameter.TabIndex = 486;
            this.Label_CoverWeldingRodDiameter.Text = "盖面焊条(丝)直径：";
            // 
            // Label_KindofExam
            // 
            this.Label_KindofExam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_KindofExam.AutoSize = true;
            this.Label_KindofExam.Location = new System.Drawing.Point(15, 92);
            this.Label_KindofExam.Name = "Label_KindofExam";
            this.Label_KindofExam.Size = new System.Drawing.Size(65, 12);
            this.Label_KindofExam.TabIndex = 496;
            this.Label_KindofExam.Text = "考试方式：";
            // 
            // Label5
            // 
            this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(685, 64);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(17, 12);
            this.Label5.TabIndex = 489;
            this.Label5.Text = "mm";
            // 
            // TextBox_CoverWeldingRodDiameter
            // 
            this.TextBox_CoverWeldingRodDiameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_CoverWeldingRodDiameter.Location = new System.Drawing.Point(616, 59);
            this.TextBox_CoverWeldingRodDiameter.Name = "TextBox_CoverWeldingRodDiameter";
            this.TextBox_CoverWeldingRodDiameter.ReadOnly = true;
            this.TextBox_CoverWeldingRodDiameter.Size = new System.Drawing.Size(60, 21);
            this.TextBox_CoverWeldingRodDiameter.TabIndex = 8;
            // 
            // Label_Thickness
            // 
            this.Label_Thickness.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Thickness.AutoSize = true;
            this.Label_Thickness.Location = new System.Drawing.Point(3, 64);
            this.Label_Thickness.Name = "Label_Thickness";
            this.Label_Thickness.Size = new System.Drawing.Size(77, 12);
            this.Label_Thickness.TabIndex = 493;
            this.Label_Thickness.Text = "板(管壁)厚：";
            // 
            // Label_ExternalDiameter
            // 
            this.Label_ExternalDiameter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_ExternalDiameter.AutoSize = true;
            this.Label_ExternalDiameter.Location = new System.Drawing.Point(235, 64);
            this.Label_ExternalDiameter.Name = "Label_ExternalDiameter";
            this.Label_ExternalDiameter.Size = new System.Drawing.Size(65, 12);
            this.Label_ExternalDiameter.TabIndex = 494;
            this.Label_ExternalDiameter.Text = "管子外径：";
            // 
            // ComboBox_KindofExam
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ComboBox_KindofExam, 2);
            this.ComboBox_KindofExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_KindofExam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_KindofExam.Enabled = false;
            this.ComboBox_KindofExam.FormattingEnabled = true;
            this.ComboBox_KindofExam.Location = new System.Drawing.Point(86, 87);
            this.ComboBox_KindofExam.Name = "ComboBox_KindofExam";
            this.ComboBox_KindofExam.Size = new System.Drawing.Size(134, 20);
            this.ComboBox_KindofExam.TabIndex = 9;
            // 
            // TextBox_Thickness
            // 
            this.TextBox_Thickness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Thickness.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_Thickness.Location = new System.Drawing.Point(86, 59);
            this.TextBox_Thickness.Name = "TextBox_Thickness";
            this.TextBox_Thickness.ReadOnly = true;
            this.TextBox_Thickness.Size = new System.Drawing.Size(110, 21);
            this.TextBox_Thickness.TabIndex = 2;
            this.TextBox_Thickness.Text = "22";
            // 
            // TextBox_ExternalDiameter
            // 
            this.TextBox_ExternalDiameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_ExternalDiameter.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_ExternalDiameter.Location = new System.Drawing.Point(306, 59);
            this.TextBox_ExternalDiameter.Name = "TextBox_ExternalDiameter";
            this.TextBox_ExternalDiameter.ReadOnly = true;
            this.TextBox_ExternalDiameter.Size = new System.Drawing.Size(157, 21);
            this.TextBox_ExternalDiameter.TabIndex = 5;
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(203, 64);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(17, 12);
            this.Label2.TabIndex = 497;
            this.Label2.Text = "mm";
            // 
            // Label7
            // 
            this.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(472, 64);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(17, 12);
            this.Label7.TabIndex = 498;
            this.Label7.Text = "mm";
            // 
            // Label_DimensionofMaterial
            // 
            this.Label_DimensionofMaterial.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_DimensionofMaterial.AutoSize = true;
            this.Label_DimensionofMaterial.Location = new System.Drawing.Point(235, 92);
            this.Label_DimensionofMaterial.Name = "Label_DimensionofMaterial";
            this.Label_DimensionofMaterial.Size = new System.Drawing.Size(65, 12);
            this.Label_DimensionofMaterial.TabIndex = 492;
            this.Label_DimensionofMaterial.Text = "母材尺寸：";
            // 
            // ComboBox_DimensionofMaterial
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ComboBox_DimensionofMaterial, 5);
            this.ComboBox_DimensionofMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_DimensionofMaterial.Enabled = false;
            this.ComboBox_DimensionofMaterial.FormattingEnabled = true;
            this.ComboBox_DimensionofMaterial.Items.AddRange(new object[] {
            "F:22，V:22，H:22，O:22",
            "t=22",
            "D:150，t:10",
            "F1:8，F:14",
            "V:10，H:10"});
            this.ComboBox_DimensionofMaterial.Location = new System.Drawing.Point(306, 87);
            this.ComboBox_DimensionofMaterial.Name = "ComboBox_DimensionofMaterial";
            this.ComboBox_DimensionofMaterial.Size = new System.Drawing.Size(396, 20);
            this.ComboBox_DimensionofMaterial.TabIndex = 10;
            // 
            // textBox_Material
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_Material, 2);
            this.textBox_Material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Material.Location = new System.Drawing.Point(306, 3);
            this.textBox_Material.Name = "textBox_Material";
            this.textBox_Material.ReadOnly = true;
            this.textBox_Material.Size = new System.Drawing.Size(183, 21);
            this.textBox_Material.TabIndex = 3;
            // 
            // textBox_WeldingConsumable
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_WeldingConsumable, 2);
            this.textBox_WeldingConsumable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingConsumable.Location = new System.Drawing.Point(306, 31);
            this.textBox_WeldingConsumable.Name = "textBox_WeldingConsumable";
            this.textBox_WeldingConsumable.ReadOnly = true;
            this.textBox_WeldingConsumable.Size = new System.Drawing.Size(183, 21);
            this.textBox_WeldingConsumable.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
            this.splitContainer2.Panel2.Controls.Add(this.label_ErrMessage);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(797, 284);
            this.splitContainer2.SplitterDistance = 225;
            this.splitContainer2.TabIndex = 0;
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
            this.splitContainer3.Panel1.Controls.Add(this.label_Data);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView_Data);
            this.splitContainer3.Size = new System.Drawing.Size(797, 225);
            this.splitContainer3.SplitterDistance = 28;
            this.splitContainer3.TabIndex = 6;
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
            // dataGridView_Data
            // 
            this.dataGridView_Data.AllowUserToAddRows = false;
            this.dataGridView_Data.AllowUserToDeleteRows = false;
            this.dataGridView_Data.AllowUserToOrderColumns = true;
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Data.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.ReadOnly = true;
            this.dataGridView_Data.RowTemplate.Height = 23;
            this.dataGridView_Data.Size = new System.Drawing.Size(797, 193);
            this.dataGridView_Data.TabIndex = 2;
            this.dataGridView_Data.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
            // 
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(29, 17);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 26;
            this.label_ErrMessage.Text = "错误信息：";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(635, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel2.TabIndex = 25;
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(123, 6);
            // 
            // toolStripMenuItem_DataGridViewRowExport
            // 
            this.toolStripMenuItem_DataGridViewRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowExportToExcel});
            this.toolStripMenuItem_DataGridViewRowExport.Name = "toolStripMenuItem_DataGridViewRowExport";
            this.toolStripMenuItem_DataGridViewRowExport.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_DataGridViewRowExport.Text = "导出";
            // 
            // toolStripMenuItem_DataGridViewRowExportToExcel
            // 
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Name = "toolStripMenuItem_DataGridViewRowExportToExcel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // toolStripMenuItem_DataGridViewRowFrozenThisColumn
            // 
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Name = "toolStripMenuItem_DataGridViewRowFrozenThisColumn";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged);
            // 
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(127, 54);
            // 
            // Form_Student_ImportFromExcel
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(797, 530);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_Student_ImportFromExcel";
            this.Text = "从Excel导入学员数据";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Student_ImportFromExcel_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.GroupBox_Base.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.GroupBox_WeldingParameter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        internal System.Windows.Forms.GroupBox GroupBox_WeldingParameter;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Label Label_WeldingProcess;
        internal System.Windows.Forms.Label Label_Assemblage;
        internal System.Windows.Forms.ComboBox ComboBox_WeldingProcess;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox ComboBox_Assemblage;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label_Material;
        internal System.Windows.Forms.TextBox TextBox_WeldingRodDiameter;
        internal System.Windows.Forms.TextBox TextBox_RenderWeldingRodDiameter;
        internal System.Windows.Forms.Label Label_WeldingConsumable;
        internal System.Windows.Forms.Label Label_RenderWeldingRodDiameter;
        internal System.Windows.Forms.Label Label_WeldingRodDiameter;
        internal System.Windows.Forms.Label Label_CoverWeldingRodDiameter;
        internal System.Windows.Forms.Label Label_KindofExam;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox TextBox_CoverWeldingRodDiameter;
        internal System.Windows.Forms.Label Label_Thickness;
        internal System.Windows.Forms.Label Label_ExternalDiameter;
        internal System.Windows.Forms.ComboBox ComboBox_KindofExam;
        internal System.Windows.Forms.TextBox TextBox_Thickness;
        internal System.Windows.Forms.TextBox TextBox_ExternalDiameter;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label_DimensionofMaterial;
        internal System.Windows.Forms.ComboBox ComboBox_DimensionofMaterial;
        private System.Windows.Forms.TextBox textBox_Material;
        private System.Windows.Forms.TextBox textBox_WeldingConsumable;
        internal System.Windows.Forms.GroupBox GroupBox_Base;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        internal System.Windows.Forms.Label Label_ShipClassificationAb;
        internal System.Windows.Forms.Label Label_IssueNo;
        internal System.Windows.Forms.Label Label_SignUpDate;
        internal System.Windows.Forms.DateTimePicker DateTimePicker_SignUpDate;
        internal System.Windows.Forms.Label Label_Employer;
        internal System.Windows.Forms.Label Label_KindofEmployer;
        internal System.Windows.Forms.Label Label_ShipboardNo;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_IssueNo;
        internal System.Windows.Forms.TextBox TextBox_ShipboardNo;
        internal System.Windows.Forms.TextBox textBox_ShipClassificationAb;
        private System.Windows.Forms.TextBox textBox_Employer;
        private System.Windows.Forms.TextBox textBox_KindofEmployer;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowFrozenThisColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridViewRow;
    }
}