namespace ZCWelder.UserControlSecond
{
    partial class UserControl_WelderBelong_DataGridView
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
            this.toolStripMenuItem_DataGridViewAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ImportFromExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowImportFromExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowModify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_RowStatisticWelderQC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportExcelofWelderBelongQC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportWelderPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportWelderPictureExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.label_Data = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_ExportExcelTemp = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_DataGridView.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExportExcelTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip_DataGridView
            // 
            this.contextMenuStrip_DataGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewAdd,
            this.toolStripMenuItem_ImportFromExcel,
            this.toolStripSeparator1,
            this.toolStripMenuItem_DataGridViewRefresh});
            this.contextMenuStrip_DataGridView.Name = "contextMenuStrip_pWPSTest";
            this.contextMenuStrip_DataGridView.Size = new System.Drawing.Size(240, 76);
            this.contextMenuStrip_DataGridView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridView_Opening);
            // 
            // toolStripMenuItem_DataGridViewAdd
            // 
            this.toolStripMenuItem_DataGridViewAdd.Name = "toolStripMenuItem_DataGridViewAdd";
            this.toolStripMenuItem_DataGridViewAdd.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_DataGridViewAdd.Text = "添加";
            this.toolStripMenuItem_DataGridViewAdd.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowAdd_Click);
            // 
            // toolStripMenuItem_ImportFromExcel
            // 
            this.toolStripMenuItem_ImportFromExcel.Name = "toolStripMenuItem_ImportFromExcel";
            this.toolStripMenuItem_ImportFromExcel.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_ImportFromExcel.Text = "从Excel中导入在册焊工信息";
            this.toolStripMenuItem_ImportFromExcel.Click += new System.EventHandler(this.toolStripMenuItem_RowImportFromExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(236, 6);
            // 
            // toolStripMenuItem_DataGridViewRefresh
            // 
            this.toolStripMenuItem_DataGridViewRefresh.Name = "toolStripMenuItem_DataGridViewRefresh";
            this.toolStripMenuItem_DataGridViewRefresh.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_DataGridViewRefresh.Text = "刷新";
            this.toolStripMenuItem_DataGridViewRefresh.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowRefresh_Click);
            // 
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowAdd,
            this.toolStripMenuItem_RowImportFromExcel,
            this.toolStripMenuItem_DataGridViewRowModify,
            this.toolStripMenuItem_DataGridViewRowDelete,
            this.toolStripSeparator2,
            this.toolStripMenuItem_RowStatisticWelderQC,
            this.toolStripSeparator4,
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripMenuItem_DataGridViewRowRefresh,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(240, 198);
            this.contextMenuStrip_DataGridViewRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridViewRow_Opening);
            // 
            // toolStripMenuItem_DataGridViewRowAdd
            // 
            this.toolStripMenuItem_DataGridViewRowAdd.Name = "toolStripMenuItem_DataGridViewRowAdd";
            this.toolStripMenuItem_DataGridViewRowAdd.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_DataGridViewRowAdd.Text = "添加";
            this.toolStripMenuItem_DataGridViewRowAdd.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowAdd_Click);
            // 
            // toolStripMenuItem_RowImportFromExcel
            // 
            this.toolStripMenuItem_RowImportFromExcel.Name = "toolStripMenuItem_RowImportFromExcel";
            this.toolStripMenuItem_RowImportFromExcel.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_RowImportFromExcel.Text = "从Excel中导入在册焊工信息";
            this.toolStripMenuItem_RowImportFromExcel.Click += new System.EventHandler(this.toolStripMenuItem_RowImportFromExcel_Click);
            // 
            // toolStripMenuItem_DataGridViewRowModify
            // 
            this.toolStripMenuItem_DataGridViewRowModify.Name = "toolStripMenuItem_DataGridViewRowModify";
            this.toolStripMenuItem_DataGridViewRowModify.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_DataGridViewRowModify.Text = "修改";
            this.toolStripMenuItem_DataGridViewRowModify.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowModify_Click);
            // 
            // toolStripMenuItem_DataGridViewRowDelete
            // 
            this.toolStripMenuItem_DataGridViewRowDelete.Name = "toolStripMenuItem_DataGridViewRowDelete";
            this.toolStripMenuItem_DataGridViewRowDelete.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_DataGridViewRowDelete.Text = "删除";
            this.toolStripMenuItem_DataGridViewRowDelete.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(236, 6);
            // 
            // toolStripMenuItem_RowStatisticWelderQC
            // 
            this.toolStripMenuItem_RowStatisticWelderQC.Name = "toolStripMenuItem_RowStatisticWelderQC";
            this.toolStripMenuItem_RowStatisticWelderQC.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_RowStatisticWelderQC.Text = "统计持证率";
            this.toolStripMenuItem_RowStatisticWelderQC.Click += new System.EventHandler(this.toolStripMenuItem_RowStatisticWelderQC_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(236, 6);
            // 
            // toolStripMenuItem_DataGridViewRowFrozenThisColumn
            // 
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Name = "toolStripMenuItem_DataGridViewRowFrozenThisColumn";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged);
            // 
            // toolStripMenuItem_DataGridViewRowRefresh
            // 
            this.toolStripMenuItem_DataGridViewRowRefresh.Name = "toolStripMenuItem_DataGridViewRowRefresh";
            this.toolStripMenuItem_DataGridViewRowRefresh.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_DataGridViewRowRefresh.Text = "刷新";
            this.toolStripMenuItem_DataGridViewRowRefresh.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(236, 6);
            // 
            // toolStripMenuItem_DataGridViewRowExport
            // 
            this.toolStripMenuItem_DataGridViewRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowExportToExcel,
            this.toolStripMenuItem_RowExportReport,
            this.toolStripMenuItem_RowExportExcelofWelderBelongQC,
            this.toolStripMenuItem_RowExportWelderPicture,
            this.toolStripMenuItem_RowExportWelderPictureExcel});
            this.toolStripMenuItem_DataGridViewRowExport.Name = "toolStripMenuItem_DataGridViewRowExport";
            this.toolStripMenuItem_DataGridViewRowExport.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_DataGridViewRowExport.Text = "导出";
            // 
            // toolStripMenuItem_DataGridViewRowExportToExcel
            // 
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Name = "toolStripMenuItem_DataGridViewRowExportToExcel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // toolStripMenuItem_RowExportReport
            // 
            this.toolStripMenuItem_RowExportReport.Name = "toolStripMenuItem_RowExportReport";
            this.toolStripMenuItem_RowExportReport.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem_RowExportReport.Text = "导出焊工持证信息";
            this.toolStripMenuItem_RowExportReport.Click += new System.EventHandler(this.toolStripMenuItem_RowExportReport_Click);
            // 
            // toolStripMenuItem_RowExportExcelofWelderBelongQC
            // 
            this.toolStripMenuItem_RowExportExcelofWelderBelongQC.Name = "toolStripMenuItem_RowExportExcelofWelderBelongQC";
            this.toolStripMenuItem_RowExportExcelofWelderBelongQC.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem_RowExportExcelofWelderBelongQC.Text = "导出焊工持证信息Excel";
            this.toolStripMenuItem_RowExportExcelofWelderBelongQC.Click += new System.EventHandler(this.toolStripMenuItem_RowExportExcelofWelderBelongQC_Click);
            // 
            // toolStripMenuItem_RowExportWelderPicture
            // 
            this.toolStripMenuItem_RowExportWelderPicture.Name = "toolStripMenuItem_RowExportWelderPicture";
            this.toolStripMenuItem_RowExportWelderPicture.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem_RowExportWelderPicture.Text = "导出焊工照片";
            this.toolStripMenuItem_RowExportWelderPicture.Click += new System.EventHandler(this.toolStripMenuItem_RowExportWelderPicture_Click);
            // 
            // toolStripMenuItem_RowExportWelderPictureExcel
            // 
            this.toolStripMenuItem_RowExportWelderPictureExcel.Name = "toolStripMenuItem_RowExportWelderPictureExcel";
            this.toolStripMenuItem_RowExportWelderPictureExcel.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem_RowExportWelderPictureExcel.Text = "导出焊工照片检测状态";
            this.toolStripMenuItem_RowExportWelderPictureExcel.Click += new System.EventHandler(this.toolStripMenuItem_RowExportWelderPictureExcel_Click);
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
            this.dataGridView_Data.Size = new System.Drawing.Size(600, 413);
            this.dataGridView_Data.TabIndex = 2;
            this.dataGridView_Data.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Data_RowEnter);
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_ExportExcelTemp);
            this.splitContainer1.Panel1.Controls.Add(this.label_Data);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Data);
            this.splitContainer1.Size = new System.Drawing.Size(600, 447);
            this.splitContainer1.SplitterDistance = 30;
            this.splitContainer1.TabIndex = 5;
            // 
            // dataGridView_ExportExcelTemp
            // 
            this.dataGridView_ExportExcelTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ExportExcelTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ExportExcelTemp.Location = new System.Drawing.Point(582, 5);
            this.dataGridView_ExportExcelTemp.Name = "dataGridView_ExportExcelTemp";
            this.dataGridView_ExportExcelTemp.RowTemplate.Height = 23;
            this.dataGridView_ExportExcelTemp.Size = new System.Drawing.Size(15, 20);
            this.dataGridView_ExportExcelTemp.TabIndex = 3;
            this.dataGridView_ExportExcelTemp.Visible = false;
            // 
            // UserControl_WelderBelong_DataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_WelderBelong_DataGridView";
            this.Size = new System.Drawing.Size(600, 447);
            this.Load += new System.EventHandler(this.UserControl_Unit_DataGridView_Load);
            this.contextMenuStrip_DataGridView.ResumeLayout(false);
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExportExcelTemp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridViewRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowModify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowFrozenThisColumn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowRefresh;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowStatisticWelderQC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ImportFromExcel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowImportFromExcel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportReport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportExcelofWelderBelongQC;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportWelderPicture;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportWelderPictureExcel;
        private System.Windows.Forms.DataGridView dataGridView_ExportExcelTemp;
    }
}
