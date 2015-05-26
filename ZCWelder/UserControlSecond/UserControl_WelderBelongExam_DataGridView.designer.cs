namespace ZCWelder.UserControlSecond
{
    partial class UserControl_WelderBelongExam_DataGridView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_WelderBelongExam_DataGridView));
            this.contextMenuStrip_DataGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_RowModifyBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportEmployerStat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowStatisticWelderQC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportSupervisionExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.label_Data = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label_TreeView = new System.Windows.Forms.Label();
            this.treeView_Data = new System.Windows.Forms.TreeView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_ShipClassificationAb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ShipboardNo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_KindofQC = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_QCFilter = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_QCAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_QCSupervision = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_QCProlongation = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_QCRegain = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_QCOverdue = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_DataGridView.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip_QCFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip_DataGridView
            // 
            this.contextMenuStrip_DataGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRefresh});
            this.contextMenuStrip_DataGridView.Name = "contextMenuStrip_pWPSTest";
            this.contextMenuStrip_DataGridView.Size = new System.Drawing.Size(95, 26);
            this.contextMenuStrip_DataGridView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridView_Opening);
            // 
            // toolStripMenuItem_DataGridViewRefresh
            // 
            this.toolStripMenuItem_DataGridViewRefresh.Name = "toolStripMenuItem_DataGridViewRefresh";
            this.toolStripMenuItem_DataGridViewRefresh.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem_DataGridViewRefresh.Text = "刷新";
            this.toolStripMenuItem_DataGridViewRefresh.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowRefresh_Click);
            // 
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_RowModifyBatch,
            this.toolStripSeparator1,
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripMenuItem_DataGridViewRowRefresh,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(203, 104);
            this.contextMenuStrip_DataGridViewRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridViewRow_Opening);
            // 
            // toolStripMenuItem_RowModifyBatch
            // 
            this.toolStripMenuItem_RowModifyBatch.Name = "toolStripMenuItem_RowModifyBatch";
            this.toolStripMenuItem_RowModifyBatch.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem_RowModifyBatch.Text = "批量输入签证和延期数据";
            this.toolStripMenuItem_RowModifyBatch.Click += new System.EventHandler(this.toolStripMenuItem_RowModifyBatch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripMenuItem_DataGridViewRowFrozenThisColumn
            // 
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Name = "toolStripMenuItem_DataGridViewRowFrozenThisColumn";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged);
            // 
            // toolStripMenuItem_DataGridViewRowRefresh
            // 
            this.toolStripMenuItem_DataGridViewRowRefresh.Name = "toolStripMenuItem_DataGridViewRowRefresh";
            this.toolStripMenuItem_DataGridViewRowRefresh.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem_DataGridViewRowRefresh.Text = "刷新";
            this.toolStripMenuItem_DataGridViewRowRefresh.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripMenuItem_DataGridViewRowExport
            // 
            this.toolStripMenuItem_DataGridViewRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowExportToExcel,
            this.toolStripMenuItem_RowExportEmployerStat,
            this.toolStripMenuItem_RowStatisticWelderQC,
            this.toolStripMenuItem_RowExportSupervisionExcel});
            this.toolStripMenuItem_DataGridViewRowExport.Name = "toolStripMenuItem_DataGridViewRowExport";
            this.toolStripMenuItem_DataGridViewRowExport.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem_DataGridViewRowExport.Text = "导出";
            // 
            // toolStripMenuItem_DataGridViewRowExportToExcel
            // 
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Name = "toolStripMenuItem_DataGridViewRowExportToExcel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // toolStripMenuItem_RowExportEmployerStat
            // 
            this.toolStripMenuItem_RowExportEmployerStat.Name = "toolStripMenuItem_RowExportEmployerStat";
            this.toolStripMenuItem_RowExportEmployerStat.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem_RowExportEmployerStat.Text = "在册焊工持证信息";
            this.toolStripMenuItem_RowExportEmployerStat.Click += new System.EventHandler(this.toolStripMenuItem_RowExportEmployerStat_Click);
            // 
            // toolStripMenuItem_RowStatisticWelderQC
            // 
            this.toolStripMenuItem_RowStatisticWelderQC.Name = "toolStripMenuItem_RowStatisticWelderQC";
            this.toolStripMenuItem_RowStatisticWelderQC.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem_RowStatisticWelderQC.Text = "统计持证率";
            this.toolStripMenuItem_RowStatisticWelderQC.Click += new System.EventHandler(this.toolStripMenuItem_RowStatisticWelderQC_Click);
            // 
            // toolStripMenuItem_RowExportSupervisionExcel
            // 
            this.toolStripMenuItem_RowExportSupervisionExcel.Name = "toolStripMenuItem_RowExportSupervisionExcel";
            this.toolStripMenuItem_RowExportSupervisionExcel.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem_RowExportSupervisionExcel.Text = "导出焊工工作业绩表";
            this.toolStripMenuItem_RowExportSupervisionExcel.Click += new System.EventHandler(this.toolStripMenuItem_RowExportSupervisionExcel_Click);
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
            this.dataGridView_Data.Size = new System.Drawing.Size(599, 358);
            this.dataGridView_Data.TabIndex = 2;
            this.dataGridView_Data.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
            this.dataGridView_Data.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_Data_CellFormatting);
            // 
            // label_Data
            // 
            this.label_Data.AutoSize = true;
            this.label_Data.Location = new System.Drawing.Point(18, 8);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(41, 12);
            this.label_Data.TabIndex = 3;
            this.label_Data.Text = "数据：";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(752, 437);
            this.splitContainer2.SplitterDistance = 147;
            this.splitContainer2.TabIndex = 3;
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
            this.splitContainer3.Panel1.Controls.Add(this.label_TreeView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.treeView_Data);
            this.splitContainer3.Size = new System.Drawing.Size(145, 435);
            this.splitContainer3.SplitterDistance = 26;
            this.splitContainer3.TabIndex = 1;
            // 
            // label_TreeView
            // 
            this.label_TreeView.AutoSize = true;
            this.label_TreeView.Location = new System.Drawing.Point(12, 8);
            this.label_TreeView.Name = "label_TreeView";
            this.label_TreeView.Size = new System.Drawing.Size(53, 12);
            this.label_TreeView.TabIndex = 5;
            this.label_TreeView.Text = "船级社：";
            // 
            // treeView_Data
            // 
            this.treeView_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Data.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView_Data.Location = new System.Drawing.Point(0, 0);
            this.treeView_Data.Name = "treeView_Data";
            this.treeView_Data.Size = new System.Drawing.Size(145, 405);
            this.treeView_Data.TabIndex = 0;
            this.treeView_Data.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Data_AfterSelect);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label1);
            this.splitContainer4.Panel1.Controls.Add(this.label_Data);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.toolStripContainer1);
            this.splitContainer4.Size = new System.Drawing.Size(599, 435);
            this.splitContainer4.SplitterDistance = 26;
            this.splitContainer4.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(363, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "证号颜色为红色表示该证书没有正常签证！";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Data);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(599, 358);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(599, 405);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip_QCFilter);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_ShipClassificationAb,
            this.toolStripStatusLabel_ShipboardNo,
            this.toolStripStatusLabel_KindofQC});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(599, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // toolStripStatusLabel_ShipClassificationAb
            // 
            this.toolStripStatusLabel_ShipClassificationAb.AutoSize = false;
            this.toolStripStatusLabel_ShipClassificationAb.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_ShipClassificationAb.Name = "toolStripStatusLabel_ShipClassificationAb";
            this.toolStripStatusLabel_ShipClassificationAb.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel_ShipClassificationAb.Text = "船级社：";
            this.toolStripStatusLabel_ShipClassificationAb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_ShipboardNo
            // 
            this.toolStripStatusLabel_ShipboardNo.AutoSize = false;
            this.toolStripStatusLabel_ShipboardNo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_ShipboardNo.Name = "toolStripStatusLabel_ShipboardNo";
            this.toolStripStatusLabel_ShipboardNo.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel_ShipboardNo.Text = "船舶系列：";
            this.toolStripStatusLabel_ShipboardNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_KindofQC
            // 
            this.toolStripStatusLabel_KindofQC.AutoSize = false;
            this.toolStripStatusLabel_KindofQC.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_KindofQC.Name = "toolStripStatusLabel_KindofQC";
            this.toolStripStatusLabel_KindofQC.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel_KindofQC.Text = "全部证书";
            this.toolStripStatusLabel_KindofQC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip_QCFilter
            // 
            this.toolStrip_QCFilter.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_QCFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_QCAll,
            this.toolStripButton_QCSupervision,
            this.toolStripButton_QCProlongation,
            this.toolStripButton_QCRegain,
            this.toolStripButton_QCOverdue});
            this.toolStrip_QCFilter.Location = new System.Drawing.Point(3, 0);
            this.toolStrip_QCFilter.Name = "toolStrip_QCFilter";
            this.toolStrip_QCFilter.Size = new System.Drawing.Size(408, 25);
            this.toolStrip_QCFilter.TabIndex = 0;
            // 
            // toolStripButton_QCAll
            // 
            this.toolStripButton_QCAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_QCAll.Image")));
            this.toolStripButton_QCAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_QCAll.Name = "toolStripButton_QCAll";
            this.toolStripButton_QCAll.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton_QCAll.Text = "全部证书";
            this.toolStripButton_QCAll.Click += new System.EventHandler(this.toolStripButton_QCAll_Click);
            // 
            // toolStripButton_QCSupervision
            // 
            this.toolStripButton_QCSupervision.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_QCSupervision.Image")));
            this.toolStripButton_QCSupervision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_QCSupervision.Name = "toolStripButton_QCSupervision";
            this.toolStripButton_QCSupervision.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton_QCSupervision.Text = "签证证书";
            this.toolStripButton_QCSupervision.Click += new System.EventHandler(this.toolStripButton_QCAll_Click);
            // 
            // toolStripButton_QCProlongation
            // 
            this.toolStripButton_QCProlongation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_QCProlongation.Image")));
            this.toolStripButton_QCProlongation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_QCProlongation.Name = "toolStripButton_QCProlongation";
            this.toolStripButton_QCProlongation.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton_QCProlongation.Text = "延期证书";
            this.toolStripButton_QCProlongation.Click += new System.EventHandler(this.toolStripButton_QCAll_Click);
            // 
            // toolStripButton_QCRegain
            // 
            this.toolStripButton_QCRegain.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_QCRegain.Image")));
            this.toolStripButton_QCRegain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_QCRegain.Name = "toolStripButton_QCRegain";
            this.toolStripButton_QCRegain.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton_QCRegain.Text = "复训证书";
            this.toolStripButton_QCRegain.Click += new System.EventHandler(this.toolStripButton_QCAll_Click);
            // 
            // toolStripButton_QCOverdue
            // 
            this.toolStripButton_QCOverdue.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_QCOverdue.Image")));
            this.toolStripButton_QCOverdue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_QCOverdue.Name = "toolStripButton_QCOverdue";
            this.toolStripButton_QCOverdue.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton_QCOverdue.Text = "失效证书";
            this.toolStripButton_QCOverdue.ToolTipText = "失效证书，包括过期一年内证书";
            this.toolStripButton_QCOverdue.Click += new System.EventHandler(this.toolStripButton_QCAll_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // UserControl_WelderBelongExam_DataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "UserControl_WelderBelongExam_DataGridView";
            this.Size = new System.Drawing.Size(752, 437);
            this.Load += new System.EventHandler(this.UserControl_Unit_DataGridView_Load);
            this.contextMenuStrip_DataGridView.ResumeLayout(false);
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip_QCFilter.ResumeLayout(false);
            this.toolStrip_QCFilter.PerformLayout();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label_TreeView;
        private System.Windows.Forms.TreeView treeView_Data;
        private System.Windows.Forms.ToolStrip toolStrip_QCFilter;
        private System.Windows.Forms.ToolStripButton toolStripButton_QCAll;
        private System.Windows.Forms.ToolStripButton toolStripButton_QCSupervision;
        private System.Windows.Forms.ToolStripButton toolStripButton_QCProlongation;
        private System.Windows.Forms.ToolStripButton toolStripButton_QCRegain;
        private System.Windows.Forms.ToolStripButton toolStripButton_QCOverdue;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ShipClassificationAb;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ShipboardNo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_KindofQC;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowModifyBatch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportEmployerStat;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowStatisticWelderQC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportSupervisionExcel;
    }
}
