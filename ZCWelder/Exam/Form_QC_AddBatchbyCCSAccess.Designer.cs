namespace ZCWelder.Exam
{
    partial class Form_QC_AddBatchbyCCSAccess
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label_Data = new System.Windows.Forms.Label();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label_NotValid = new System.Windows.Forms.Label();
            this.dataGridView_NotValid = new System.Windows.Forms.DataGridView();
            this.Label_SupervisionPlace = new System.Windows.Forms.Label();
            this.TextBox_SupervisionPlace = new System.Windows.Forms.TextBox();
            this.button_InitData = new System.Windows.Forms.Button();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_NotValidRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_NotValidRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_NotValidRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_NotValidRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.button_InitData2015 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NotValid)).BeginInit();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            this.contextMenuStrip_NotValidRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(469, 13);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel2.TabIndex = 21;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button_InitData2015);
            this.splitContainer1.Panel2.Controls.Add(this.Label_SupervisionPlace);
            this.splitContainer1.Panel2.Controls.Add(this.TextBox_SupervisionPlace);
            this.splitContainer1.Panel2.Controls.Add(this.button_InitData);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(632, 499);
            this.splitContainer1.SplitterDistance = 439;
            this.splitContainer1.TabIndex = 23;
            // 
            // splitContainer2
            // 
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
            this.splitContainer2.Size = new System.Drawing.Size(632, 439);
            this.splitContainer2.SplitterDistance = 214;
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
            this.splitContainer3.Size = new System.Drawing.Size(632, 214);
            this.splitContainer3.SplitterDistance = 28;
            this.splitContainer3.TabIndex = 26;
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
            this.dataGridView_Data.Size = new System.Drawing.Size(632, 182);
            this.dataGridView_Data.TabIndex = 2;
            this.dataGridView_Data.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
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
            this.splitContainer4.Panel1.Controls.Add(this.label_NotValid);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridView_NotValid);
            this.splitContainer4.Size = new System.Drawing.Size(632, 221);
            this.splitContainer4.SplitterDistance = 28;
            this.splitContainer4.TabIndex = 27;
            // 
            // label_NotValid
            // 
            this.label_NotValid.AutoSize = true;
            this.label_NotValid.Location = new System.Drawing.Point(17, 11);
            this.label_NotValid.Name = "label_NotValid";
            this.label_NotValid.Size = new System.Drawing.Size(41, 12);
            this.label_NotValid.TabIndex = 3;
            this.label_NotValid.Text = "数据：";
            // 
            // dataGridView_NotValid
            // 
            this.dataGridView_NotValid.AllowUserToAddRows = false;
            this.dataGridView_NotValid.AllowUserToDeleteRows = false;
            this.dataGridView_NotValid.AllowUserToOrderColumns = true;
            this.dataGridView_NotValid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_NotValid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_NotValid.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_NotValid.Name = "dataGridView_NotValid";
            this.dataGridView_NotValid.ReadOnly = true;
            this.dataGridView_NotValid.RowTemplate.Height = 23;
            this.dataGridView_NotValid.Size = new System.Drawing.Size(632, 189);
            this.dataGridView_NotValid.TabIndex = 2;
            this.dataGridView_NotValid.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_NotValid_CellContextMenuStripNeeded);
            // 
            // Label_SupervisionPlace
            // 
            this.Label_SupervisionPlace.AutoSize = true;
            this.Label_SupervisionPlace.Location = new System.Drawing.Point(295, 21);
            this.Label_SupervisionPlace.Name = "Label_SupervisionPlace";
            this.Label_SupervisionPlace.Size = new System.Drawing.Size(65, 12);
            this.Label_SupervisionPlace.TabIndex = 501;
            this.Label_SupervisionPlace.Text = "考察地点：";
            // 
            // TextBox_SupervisionPlace
            // 
            this.TextBox_SupervisionPlace.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZCWelder.Properties.Settings.Default, "SupervisionPlace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBox_SupervisionPlace.Location = new System.Drawing.Point(366, 18);
            this.TextBox_SupervisionPlace.Name = "TextBox_SupervisionPlace";
            this.TextBox_SupervisionPlace.Size = new System.Drawing.Size(94, 21);
            this.TextBox_SupervisionPlace.TabIndex = 23;
            this.TextBox_SupervisionPlace.Text = global::ZCWelder.Properties.Settings.Default.SupervisionPlace;
            // 
            // button_InitData
            // 
            this.button_InitData.Location = new System.Drawing.Point(19, 16);
            this.button_InitData.Name = "button_InitData";
            this.button_InitData.Size = new System.Drawing.Size(99, 23);
            this.button_InitData.TabIndex = 22;
            this.button_InitData.Text = "重新加载数据";
            this.button_InitData.UseVisualStyleBackColor = true;
            this.button_InitData.Click += new System.EventHandler(this.button_InitData_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenuItem_DataGridViewRowExport
            // 
            this.toolStripMenuItem_DataGridViewRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowExportToExcel});
            this.toolStripMenuItem_DataGridViewRowExport.Name = "toolStripMenuItem_DataGridViewRowExport";
            this.toolStripMenuItem_DataGridViewRowExport.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_DataGridViewRowExport.Text = "导出";
            // 
            // toolStripMenuItem_DataGridViewRowExportToExcel
            // 
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Name = "toolStripMenuItem_DataGridViewRowExportToExcel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // toolStripMenuItem_DataGridViewRowFrozenThisColumn
            // 
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Name = "toolStripMenuItem_DataGridViewRowFrozenThisColumn";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckedChanged += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckedChanged);
            // 
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(125, 54);
            // 
            // contextMenuStrip_NotValidRow
            // 
            this.contextMenuStrip_NotValidRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_NotValidRowFrozenThisColumn,
            this.toolStripSeparator4,
            this.toolStripMenuItem_NotValidRowExport});
            this.contextMenuStrip_NotValidRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_NotValidRow.Size = new System.Drawing.Size(125, 54);
            // 
            // toolStripMenuItem_NotValidRowFrozenThisColumn
            // 
            this.toolStripMenuItem_NotValidRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_NotValidRowFrozenThisColumn.Name = "toolStripMenuItem_NotValidRowFrozenThisColumn";
            this.toolStripMenuItem_NotValidRowFrozenThisColumn.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_NotValidRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_NotValidRowFrozenThisColumn.CheckedChanged += new System.EventHandler(this.toolStripMenuItem_NotValidRowFrozenThisColumn_CheckedChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenuItem_NotValidRowExport
            // 
            this.toolStripMenuItem_NotValidRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_NotValidRowExportToExcel});
            this.toolStripMenuItem_NotValidRowExport.Name = "toolStripMenuItem_NotValidRowExport";
            this.toolStripMenuItem_NotValidRowExport.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_NotValidRowExport.Text = "导出";
            // 
            // toolStripMenuItem_NotValidRowExportToExcel
            // 
            this.toolStripMenuItem_NotValidRowExportToExcel.Name = "toolStripMenuItem_NotValidRowExportToExcel";
            this.toolStripMenuItem_NotValidRowExportToExcel.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem_NotValidRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_NotValidRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_NotValidRowExportToExcel_Click);
            // 
            // button_InitData2015
            // 
            this.button_InitData2015.Location = new System.Drawing.Point(141, 16);
            this.button_InitData2015.Name = "button_InitData2015";
            this.button_InitData2015.Size = new System.Drawing.Size(126, 23);
            this.button_InitData2015.TabIndex = 502;
            this.button_InitData2015.Text = "重新加载数据2015";
            this.button_InitData2015.UseVisualStyleBackColor = true;
            this.button_InitData2015.Click += new System.EventHandler(this.button_InitData2015_Click);
            // 
            // Form_QC_AddBatchbyCCSAccess
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(632, 499);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_QC_AddBatchbyCCSAccess";
            this.Text = "从CCS文件中导入证书数据";
            this.Load += new System.EventHandler(this.Form_QC_AddBatchbyCCSAccess_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NotValid)).EndInit();
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            this.contextMenuStrip_NotValidRow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label_NotValid;
        private System.Windows.Forms.DataGridView dataGridView_NotValid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowFrozenThisColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridViewRow;
        private System.Windows.Forms.Button button_InitData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_NotValidRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_NotValidRowFrozenThisColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_NotValidRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_NotValidRowExportToExcel;
        internal System.Windows.Forms.TextBox TextBox_SupervisionPlace;
        internal System.Windows.Forms.Label Label_SupervisionPlace;
        private System.Windows.Forms.Button button_InitData2015;
    }
}