namespace ZCWelder.Exam
{
	partial class Form_SubjectPositionResult_UpdateBatch
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
            this.label_Data = new System.Windows.Forms.Label();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.checkBox_CheckAll = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportTestApply = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportBendTestApply_JN = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportBendTestApply_AN = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportRTTestApply_JN = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportCrystalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportMTTestApply_JN = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView_Data.RowTemplate.Height = 23;
            this.dataGridView_Data.Size = new System.Drawing.Size(639, 436);
            this.dataGridView_Data.TabIndex = 2;
            this.dataGridView_Data.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
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
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Data);
            this.splitContainer1.Size = new System.Drawing.Size(639, 468);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 6;
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.checkBox_CheckAll);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(639, 524);
            this.splitContainer2.SplitterDistance = 468;
            this.splitContainer2.TabIndex = 7;
            // 
            // checkBox_CheckAll
            // 
            this.checkBox_CheckAll.AutoSize = true;
            this.checkBox_CheckAll.Location = new System.Drawing.Point(19, 9);
            this.checkBox_CheckAll.Name = "checkBox_CheckAll";
            this.checkBox_CheckAll.Size = new System.Drawing.Size(48, 16);
            this.checkBox_CheckAll.TabIndex = 26;
            this.checkBox_CheckAll.Text = "全选";
            this.checkBox_CheckAll.UseVisualStyleBackColor = true;
            this.checkBox_CheckAll.CheckedChanged += new System.EventHandler(this.checkBox_CheckAll_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(477, 9);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel2.TabIndex = 24;
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
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(153, 76);
            this.contextMenuStrip_DataGridViewRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridViewRow_Opening);
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
            this.toolStripMenuItem_DataGridViewRowExportToExcel,
            this.toolStripMenuItem_RowExportTestApply,
            this.toolStripMenuItem_RowExportCrystalReport});
            this.toolStripMenuItem_DataGridViewRowExport.Name = "toolStripMenuItem_DataGridViewRowExport";
            this.toolStripMenuItem_DataGridViewRowExport.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowExport.Text = "导出";
            // 
            // toolStripMenuItem_DataGridViewRowExportToExcel
            // 
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Name = "toolStripMenuItem_DataGridViewRowExportToExcel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // toolStripMenuItem_RowExportTestApply
            // 
            this.toolStripMenuItem_RowExportTestApply.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_RowExportBendTestApply_JN,
            this.toolStripMenuItem_RowExportBendTestApply_AN,
            this.toolStripMenuItem_RowExportRTTestApply_JN,
            this.toolStripMenuItem_RowExportMTTestApply_JN});
            this.toolStripMenuItem_RowExportTestApply.Name = "toolStripMenuItem_RowExportTestApply";
            this.toolStripMenuItem_RowExportTestApply.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem_RowExportTestApply.Text = "导出试验申请单";
            // 
            // toolStripMenuItem_RowExportBendTestApply_JN
            // 
            this.toolStripMenuItem_RowExportBendTestApply_JN.Name = "toolStripMenuItem_RowExportBendTestApply_JN";
            this.toolStripMenuItem_RowExportBendTestApply_JN.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem_RowExportBendTestApply_JN.Text = "导出理化试验申请单(江南造船)";
            this.toolStripMenuItem_RowExportBendTestApply_JN.Click += new System.EventHandler(this.toolStripMenuItem_RowExportBendTestApply_JN_Click);
            // 
            // toolStripMenuItem_RowExportBendTestApply_AN
            // 
            this.toolStripMenuItem_RowExportBendTestApply_AN.Name = "toolStripMenuItem_RowExportBendTestApply_AN";
            this.toolStripMenuItem_RowExportBendTestApply_AN.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem_RowExportBendTestApply_AN.Text = "导出理化试验申请单(安装公司)";
            this.toolStripMenuItem_RowExportBendTestApply_AN.Click += new System.EventHandler(this.toolStripMenuItem_RowExportBendTestApply_AN_Click);
            // 
            // toolStripMenuItem_RowExportRTTestApply_JN
            // 
            this.toolStripMenuItem_RowExportRTTestApply_JN.Name = "toolStripMenuItem_RowExportRTTestApply_JN";
            this.toolStripMenuItem_RowExportRTTestApply_JN.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem_RowExportRTTestApply_JN.Text = "导出RT试验申请单";
            this.toolStripMenuItem_RowExportRTTestApply_JN.Click += new System.EventHandler(this.toolStripMenuItem_RowExportRTTestApply_JN_Click);
            // 
            // toolStripMenuItem_RowExportCrystalReport
            // 
            this.toolStripMenuItem_RowExportCrystalReport.Name = "toolStripMenuItem_RowExportCrystalReport";
            this.toolStripMenuItem_RowExportCrystalReport.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem_RowExportCrystalReport.Text = "导出报表";
            this.toolStripMenuItem_RowExportCrystalReport.Click += new System.EventHandler(this.toolStripMenuItem_RowExportCrystalReport_Click);
            // 
            // toolStripMenuItem_RowExportMTTestApply_JN
            // 
            this.toolStripMenuItem_RowExportMTTestApply_JN.Name = "toolStripMenuItem_RowExportMTTestApply_JN";
            this.toolStripMenuItem_RowExportMTTestApply_JN.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem_RowExportMTTestApply_JN.Text = "导出MT试验申请单";
            this.toolStripMenuItem_RowExportMTTestApply_JN.Click += new System.EventHandler(this.toolStripMenuItem_RowExportMTTestApply_JN_Click);
            // 
            // Form_SubjectPositionResult_UpdateBatch
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(639, 524);
            this.Controls.Add(this.splitContainer2);
            this.Name = "Form_SubjectPositionResult_UpdateBatch";
            this.Text = "学员考试项目信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_SubjectPositionResult_UpdateBatch_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_SubjectPositionResult_UpdateBatch_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridViewRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowFrozenThisColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportTestApply;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportBendTestApply_JN;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportBendTestApply_AN;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportRTTestApply_JN;
        private System.Windows.Forms.CheckBox checkBox_CheckAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportCrystalReport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportMTTestApply_JN;
	}
}