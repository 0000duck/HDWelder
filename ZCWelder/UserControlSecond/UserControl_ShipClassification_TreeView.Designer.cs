namespace ZCWelder.UserControlSecond
{
    partial class UserControl_ShipClassification_TreeView
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
            this.label_Data = new System.Windows.Forms.Label();
            this.treeView_Data = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_TreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewColumnGroupRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_QueryAdvance = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_IssueNoEnd = new System.Windows.Forms.Label();
            this.MaskedTextBox_IssueNoBegin = new System.Windows.Forms.MaskedTextBox();
            this.Label_WeldingProcessAb = new System.Windows.Forms.Label();
            this.Label_Employer = new System.Windows.Forms.Label();
            this.MaskedTextBox_IssueNoEnd = new System.Windows.Forms.MaskedTextBox();
            this.ComboBox_Employer = new System.Windows.Forms.ComboBox();
            this.label_IssueNoBegin = new System.Windows.Forms.Label();
            this.ComboBox_WeldingProcessAb = new System.Windows.Forms.ComboBox();
            this.label_KindofEmployer = new System.Windows.Forms.Label();
            this.comboBox_KindofEmployer = new System.Windows.Forms.ComboBox();
            this.label_ShipClassificationAb = new System.Windows.Forms.Label();
            this.comboBox_ShipClassificationAb = new System.Windows.Forms.ComboBox();
            this.label_ShipboardNo = new System.Windows.Forms.Label();
            this.comboBox_ShipboardNo = new System.Windows.Forms.ComboBox();
            this.comboBox_Material = new System.Windows.Forms.ComboBox();
            this.comboBox_WeldingConsumable = new System.Windows.Forms.ComboBox();
            this.label_Material = new System.Windows.Forms.Label();
            this.label_WeldingConsumable = new System.Windows.Forms.Label();
            this.ComboBox_SignUpDate = new System.Windows.Forms.ComboBox();
            this.DateTimePicker_SignUpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker_SignUpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip_TreeView.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Data
            // 
            this.label_Data.AutoSize = true;
            this.label_Data.Location = new System.Drawing.Point(19, 12);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(41, 12);
            this.label_Data.TabIndex = 5;
            this.label_Data.Text = "数据：";
            // 
            // treeView_Data
            // 
            this.treeView_Data.ContextMenuStrip = this.contextMenuStrip_TreeView;
            this.treeView_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Data.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView_Data.Location = new System.Drawing.Point(0, 0);
            this.treeView_Data.Name = "treeView_Data";
            this.treeView_Data.Size = new System.Drawing.Size(221, 84);
            this.treeView_Data.TabIndex = 0;
            this.treeView_Data.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Data_AfterSelect);
            // 
            // contextMenuStrip_TreeView
            // 
            this.contextMenuStrip_TreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewColumnGroupRefresh});
            this.contextMenuStrip_TreeView.Name = "contextMenuStrip_Parameter";
            this.contextMenuStrip_TreeView.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem_DataGridViewColumnGroupRefresh
            // 
            this.toolStripMenuItem_DataGridViewColumnGroupRefresh.Name = "toolStripMenuItem_DataGridViewColumnGroupRefresh";
            this.toolStripMenuItem_DataGridViewColumnGroupRefresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_DataGridViewColumnGroupRefresh.Text = "刷新";
            this.toolStripMenuItem_DataGridViewColumnGroupRefresh.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewColumnGroupRefresh_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.label_Data);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(221, 570);
            this.splitContainer1.SplitterDistance = 27;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.treeView_Data);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(221, 539);
            this.splitContainer2.SplitterDistance = 84;
            this.splitContainer2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button_QueryAdvance, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(65, 406);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel3.TabIndex = 44;
            // 
            // button_OnOK
            // 
            this.button_OnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OnOK.Location = new System.Drawing.Point(3, 3);
            this.button_OnOK.Name = "button_OnOK";
            this.button_OnOK.Size = new System.Drawing.Size(69, 23);
            this.button_OnOK.TabIndex = 0;
            this.button_OnOK.Text = "查询";
            this.button_OnOK.UseVisualStyleBackColor = true;
            this.button_OnOK.Click += new System.EventHandler(this.button_OnOK_Click);
            // 
            // button_QueryAdvance
            // 
            this.button_QueryAdvance.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_QueryAdvance.Location = new System.Drawing.Point(78, 3);
            this.button_QueryAdvance.Name = "button_QueryAdvance";
            this.button_QueryAdvance.Size = new System.Drawing.Size(69, 23);
            this.button_QueryAdvance.TabIndex = 1;
            this.button_QueryAdvance.Text = "高级";
            this.button_QueryAdvance.UseVisualStyleBackColor = true;
            this.button_QueryAdvance.Click += new System.EventHandler(this.button_QueryAdvance_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.Controls.Add(this.Label_IssueNoEnd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.MaskedTextBox_IssueNoBegin, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_WeldingProcessAb, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label_Employer, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.MaskedTextBox_IssueNoEnd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_Employer, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_IssueNoBegin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_WeldingProcessAb, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_KindofEmployer, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_KindofEmployer, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_ShipClassificationAb, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_ShipClassificationAb, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label_ShipboardNo, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_ShipboardNo, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_Material, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_WeldingConsumable, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label_Material, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingConsumable, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_SignUpDate, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.DateTimePicker_SignUpDateBegin, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.DateTimePicker_SignUpDateEnd, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.Label8, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.Label7, 0, 11);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(215, 361);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // Label_IssueNoEnd
            // 
            this.Label_IssueNoEnd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IssueNoEnd.AutoSize = true;
            this.Label_IssueNoEnd.Location = new System.Drawing.Point(9, 39);
            this.Label_IssueNoEnd.Name = "Label_IssueNoEnd";
            this.Label_IssueNoEnd.Size = new System.Drawing.Size(89, 12);
            this.Label_IssueNoEnd.TabIndex = 20;
            this.Label_IssueNoEnd.Text = "班级编号结束：";
            // 
            // MaskedTextBox_IssueNoBegin
            // 
            this.MaskedTextBox_IssueNoBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_IssueNoBegin.Location = new System.Drawing.Point(104, 3);
            this.MaskedTextBox_IssueNoBegin.Name = "MaskedTextBox_IssueNoBegin";
            this.MaskedTextBox_IssueNoBegin.Size = new System.Drawing.Size(108, 21);
            this.MaskedTextBox_IssueNoBegin.TabIndex = 0;
            this.MaskedTextBox_IssueNoBegin.Leave += new System.EventHandler(this.MaskedTextBox_IssueNoBegin_Leave);
            // 
            // Label_WeldingProcessAb
            // 
            this.Label_WeldingProcessAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingProcessAb.AutoSize = true;
            this.Label_WeldingProcessAb.Location = new System.Drawing.Point(33, 69);
            this.Label_WeldingProcessAb.Name = "Label_WeldingProcessAb";
            this.Label_WeldingProcessAb.Size = new System.Drawing.Size(65, 12);
            this.Label_WeldingProcessAb.TabIndex = 25;
            this.Label_WeldingProcessAb.Text = "焊接方法：";
            // 
            // Label_Employer
            // 
            this.Label_Employer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Employer.AutoSize = true;
            this.Label_Employer.Location = new System.Drawing.Point(57, 99);
            this.Label_Employer.Name = "Label_Employer";
            this.Label_Employer.Size = new System.Drawing.Size(41, 12);
            this.Label_Employer.TabIndex = 35;
            this.Label_Employer.Text = "公司：";
            // 
            // MaskedTextBox_IssueNoEnd
            // 
            this.MaskedTextBox_IssueNoEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_IssueNoEnd.Location = new System.Drawing.Point(104, 33);
            this.MaskedTextBox_IssueNoEnd.Name = "MaskedTextBox_IssueNoEnd";
            this.MaskedTextBox_IssueNoEnd.Size = new System.Drawing.Size(108, 21);
            this.MaskedTextBox_IssueNoEnd.TabIndex = 1;
            // 
            // ComboBox_Employer
            // 
            this.ComboBox_Employer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_Employer.DropDownWidth = 200;
            this.ComboBox_Employer.FormattingEnabled = true;
            this.ComboBox_Employer.Location = new System.Drawing.Point(104, 93);
            this.ComboBox_Employer.Name = "ComboBox_Employer";
            this.ComboBox_Employer.Size = new System.Drawing.Size(108, 20);
            this.ComboBox_Employer.TabIndex = 3;
            // 
            // label_IssueNoBegin
            // 
            this.label_IssueNoBegin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_IssueNoBegin.AutoSize = true;
            this.label_IssueNoBegin.Location = new System.Drawing.Point(3, 9);
            this.label_IssueNoBegin.Name = "label_IssueNoBegin";
            this.label_IssueNoBegin.Size = new System.Drawing.Size(95, 12);
            this.label_IssueNoBegin.TabIndex = 0;
            this.label_IssueNoBegin.Text = " 班级编号开始：";
            // 
            // ComboBox_WeldingProcessAb
            // 
            this.ComboBox_WeldingProcessAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_WeldingProcessAb.FormattingEnabled = true;
            this.ComboBox_WeldingProcessAb.Location = new System.Drawing.Point(104, 63);
            this.ComboBox_WeldingProcessAb.Name = "ComboBox_WeldingProcessAb";
            this.ComboBox_WeldingProcessAb.Size = new System.Drawing.Size(108, 20);
            this.ComboBox_WeldingProcessAb.TabIndex = 2;
            // 
            // label_KindofEmployer
            // 
            this.label_KindofEmployer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_KindofEmployer.AutoSize = true;
            this.label_KindofEmployer.Location = new System.Drawing.Point(33, 129);
            this.label_KindofEmployer.Name = "label_KindofEmployer";
            this.label_KindofEmployer.Size = new System.Drawing.Size(65, 12);
            this.label_KindofEmployer.TabIndex = 35;
            this.label_KindofEmployer.Text = "报考单位：";
            // 
            // comboBox_KindofEmployer
            // 
            this.comboBox_KindofEmployer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_KindofEmployer.DropDownWidth = 200;
            this.comboBox_KindofEmployer.FormattingEnabled = true;
            this.comboBox_KindofEmployer.Location = new System.Drawing.Point(104, 123);
            this.comboBox_KindofEmployer.Name = "comboBox_KindofEmployer";
            this.comboBox_KindofEmployer.Size = new System.Drawing.Size(108, 20);
            this.comboBox_KindofEmployer.TabIndex = 4;
            // 
            // label_ShipClassificationAb
            // 
            this.label_ShipClassificationAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ShipClassificationAb.AutoSize = true;
            this.label_ShipClassificationAb.Location = new System.Drawing.Point(45, 159);
            this.label_ShipClassificationAb.Name = "label_ShipClassificationAb";
            this.label_ShipClassificationAb.Size = new System.Drawing.Size(53, 12);
            this.label_ShipClassificationAb.TabIndex = 35;
            this.label_ShipClassificationAb.Text = "船级社：";
            // 
            // comboBox_ShipClassificationAb
            // 
            this.comboBox_ShipClassificationAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_ShipClassificationAb.DropDownWidth = 200;
            this.comboBox_ShipClassificationAb.FormattingEnabled = true;
            this.comboBox_ShipClassificationAb.Location = new System.Drawing.Point(104, 153);
            this.comboBox_ShipClassificationAb.Name = "comboBox_ShipClassificationAb";
            this.comboBox_ShipClassificationAb.Size = new System.Drawing.Size(108, 20);
            this.comboBox_ShipClassificationAb.TabIndex = 5;
            // 
            // label_ShipboardNo
            // 
            this.label_ShipboardNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ShipboardNo.AutoSize = true;
            this.label_ShipboardNo.Location = new System.Drawing.Point(57, 189);
            this.label_ShipboardNo.Name = "label_ShipboardNo";
            this.label_ShipboardNo.Size = new System.Drawing.Size(41, 12);
            this.label_ShipboardNo.TabIndex = 35;
            this.label_ShipboardNo.Text = "船号：";
            // 
            // comboBox_ShipboardNo
            // 
            this.comboBox_ShipboardNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_ShipboardNo.DropDownWidth = 200;
            this.comboBox_ShipboardNo.FormattingEnabled = true;
            this.comboBox_ShipboardNo.Location = new System.Drawing.Point(104, 183);
            this.comboBox_ShipboardNo.Name = "comboBox_ShipboardNo";
            this.comboBox_ShipboardNo.Size = new System.Drawing.Size(108, 20);
            this.comboBox_ShipboardNo.TabIndex = 6;
            // 
            // comboBox_Material
            // 
            this.comboBox_Material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_Material.DropDownWidth = 200;
            this.comboBox_Material.FormattingEnabled = true;
            this.comboBox_Material.Location = new System.Drawing.Point(104, 213);
            this.comboBox_Material.Name = "comboBox_Material";
            this.comboBox_Material.Size = new System.Drawing.Size(108, 20);
            this.comboBox_Material.TabIndex = 7;
            // 
            // comboBox_WeldingConsumable
            // 
            this.comboBox_WeldingConsumable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_WeldingConsumable.DropDownWidth = 200;
            this.comboBox_WeldingConsumable.FormattingEnabled = true;
            this.comboBox_WeldingConsumable.Location = new System.Drawing.Point(104, 243);
            this.comboBox_WeldingConsumable.Name = "comboBox_WeldingConsumable";
            this.comboBox_WeldingConsumable.Size = new System.Drawing.Size(108, 20);
            this.comboBox_WeldingConsumable.TabIndex = 8;
            // 
            // label_Material
            // 
            this.label_Material.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Material.AutoSize = true;
            this.label_Material.Location = new System.Drawing.Point(57, 219);
            this.label_Material.Name = "label_Material";
            this.label_Material.Size = new System.Drawing.Size(41, 12);
            this.label_Material.TabIndex = 35;
            this.label_Material.Text = "材料：";
            // 
            // label_WeldingConsumable
            // 
            this.label_WeldingConsumable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingConsumable.AutoSize = true;
            this.label_WeldingConsumable.Location = new System.Drawing.Point(33, 249);
            this.label_WeldingConsumable.Name = "label_WeldingConsumable";
            this.label_WeldingConsumable.Size = new System.Drawing.Size(65, 12);
            this.label_WeldingConsumable.TabIndex = 35;
            this.label_WeldingConsumable.Text = "焊接材料：";
            // 
            // ComboBox_SignUpDate
            // 
            this.ComboBox_SignUpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_SignUpDate.DropDownWidth = 200;
            this.ComboBox_SignUpDate.FormattingEnabled = true;
            this.ComboBox_SignUpDate.Items.AddRange(new object[] {
            "报名日期起始",
            "培训开始日期",
            "培训结束日期",
            "理论考试日期",
            "技能考试日期",
            "理论补考日期",
            "技能补考日期",
            "办证日期起始"});
            this.ComboBox_SignUpDate.Location = new System.Drawing.Point(104, 273);
            this.ComboBox_SignUpDate.Name = "ComboBox_SignUpDate";
            this.ComboBox_SignUpDate.Size = new System.Drawing.Size(108, 20);
            this.ComboBox_SignUpDate.TabIndex = 9;
            // 
            // DateTimePicker_SignUpDateBegin
            // 
            this.DateTimePicker_SignUpDateBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTimePicker_SignUpDateBegin.Location = new System.Drawing.Point(104, 303);
            this.DateTimePicker_SignUpDateBegin.Name = "DateTimePicker_SignUpDateBegin";
            this.DateTimePicker_SignUpDateBegin.Size = new System.Drawing.Size(108, 21);
            this.DateTimePicker_SignUpDateBegin.TabIndex = 10;
            // 
            // DateTimePicker_SignUpDateEnd
            // 
            this.DateTimePicker_SignUpDateEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTimePicker_SignUpDateEnd.Location = new System.Drawing.Point(104, 333);
            this.DateTimePicker_SignUpDateEnd.Name = "DateTimePicker_SignUpDateEnd";
            this.DateTimePicker_SignUpDateEnd.Size = new System.Drawing.Size(108, 21);
            this.DateTimePicker_SignUpDateEnd.TabIndex = 11;
            // 
            // Label8
            // 
            this.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(81, 309);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(17, 12);
            this.Label8.TabIndex = 27;
            this.Label8.Text = "从";
            // 
            // Label7
            // 
            this.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(81, 339);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(17, 12);
            this.Label7.TabIndex = 28;
            this.Label7.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "检索条件：";
            // 
            // UserControl_ShipClassification_TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_ShipClassification_TreeView";
            this.Size = new System.Drawing.Size(221, 570);
            this.Load += new System.EventHandler(this.UserControl_ShipClassification_TreeView_Load);
            this.contextMenuStrip_TreeView.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.TreeView treeView_Data;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_TreeView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewColumnGroupRefresh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_QueryAdvance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Label Label_IssueNoEnd;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_IssueNoBegin;
        internal System.Windows.Forms.Label Label_WeldingProcessAb;
        internal System.Windows.Forms.Label Label_Employer;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_IssueNoEnd;
        internal System.Windows.Forms.ComboBox ComboBox_Employer;
        internal System.Windows.Forms.Label label_IssueNoBegin;
        internal System.Windows.Forms.ComboBox ComboBox_WeldingProcessAb;
        internal System.Windows.Forms.Label label_KindofEmployer;
        internal System.Windows.Forms.ComboBox comboBox_KindofEmployer;
        internal System.Windows.Forms.Label label_ShipClassificationAb;
        internal System.Windows.Forms.ComboBox comboBox_ShipClassificationAb;
        internal System.Windows.Forms.Label label_ShipboardNo;
        internal System.Windows.Forms.ComboBox comboBox_ShipboardNo;
        internal System.Windows.Forms.ComboBox comboBox_Material;
        internal System.Windows.Forms.ComboBox comboBox_WeldingConsumable;
        internal System.Windows.Forms.Label label_Material;
        internal System.Windows.Forms.Label label_WeldingConsumable;
        internal System.Windows.Forms.ComboBox ComboBox_SignUpDate;
        internal System.Windows.Forms.DateTimePicker DateTimePicker_SignUpDateBegin;
        internal System.Windows.Forms.DateTimePicker DateTimePicker_SignUpDateEnd;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label label1;
    }
}
