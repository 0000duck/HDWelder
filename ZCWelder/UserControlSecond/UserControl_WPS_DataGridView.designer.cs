namespace ZCWelder.UserControlSecond
{
    partial class UserControl_WPSDataGridView
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
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_pWPS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.label_Data = new System.Windows.Forms.Label();
            this.contextMenuStrip_pWPSRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowModify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_WPSRowLockOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_RowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_RowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.contextMenuStrip_pWPS.SuspendLayout();
            this.contextMenuStrip_pWPSRow.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView_Data.ContextMenuStrip = this.contextMenuStrip_pWPS;
            this.dataGridView_Data.Location = new System.Drawing.Point(0, 27);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.ReadOnly = true;
            this.dataGridView_Data.RowTemplate.Height = 23;
            this.dataGridView_Data.Size = new System.Drawing.Size(598, 430);
            this.dataGridView_Data.TabIndex = 0;
            this.dataGridView_Data.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Data_RowEnter);
            this.dataGridView_Data.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
            this.dataGridView_Data.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_Data_CellFormatting);
            // 
            // contextMenuStrip_pWPS
            // 
            this.contextMenuStrip_pWPS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewAdd,
            this.toolStripSeparator3,
            this.toolStripMenuItem_Refresh});
            this.contextMenuStrip_pWPS.Name = "contextMenuStrip_pWPS";
            this.contextMenuStrip_pWPS.Size = new System.Drawing.Size(101, 54);
            this.contextMenuStrip_pWPS.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_WPS_Opening);
            // 
            // toolStripMenuItem_DataGridViewAdd
            // 
            this.toolStripMenuItem_DataGridViewAdd.Name = "toolStripMenuItem_DataGridViewAdd";
            this.toolStripMenuItem_DataGridViewAdd.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_DataGridViewAdd.Text = "添加";
            this.toolStripMenuItem_DataGridViewAdd.Click += new System.EventHandler(this.toolStripMenuItem_WPSRowAdd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(97, 6);
            // 
            // toolStripMenuItem_Refresh
            // 
            this.toolStripMenuItem_Refresh.Name = "toolStripMenuItem_Refresh";
            this.toolStripMenuItem_Refresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_Refresh.Text = "刷新";
            this.toolStripMenuItem_Refresh.Click += new System.EventHandler(this.toolStripMenuItem_WPSRowRefresh_Click);
            // 
            // label_Data
            // 
            this.label_Data.AutoSize = true;
            this.label_Data.Location = new System.Drawing.Point(8, 9);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(113, 12);
            this.label_Data.TabIndex = 1;
            this.label_Data.Text = "焊接工艺基本信息：";
            // 
            // contextMenuStrip_pWPSRow
            // 
            this.contextMenuStrip_pWPSRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowAdd,
            this.toolStripMenuItem_DataGridViewRowModify,
            this.toolStripMenuItem_DataGridViewRowDelete,
            this.toolStripSeparator4,
            this.toolStripMenuItem_WPSRowLockOut,
            this.toolStripSeparator1,
            this.toolStripMenuItem_RowFrozenThisColumn,
            this.toolStripMenuItem_RowRefresh,
            this.toolStripSeparator2,
            this.toolStripMenuItem_RowExport});
            this.contextMenuStrip_pWPSRow.Name = "contextMenuStrip_pWPSRow";
            this.contextMenuStrip_pWPSRow.Size = new System.Drawing.Size(127, 176);
            this.contextMenuStrip_pWPSRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_WPSRow_Opening);
            // 
            // toolStripMenuItem_DataGridViewRowAdd
            // 
            this.toolStripMenuItem_DataGridViewRowAdd.Name = "toolStripMenuItem_DataGridViewRowAdd";
            this.toolStripMenuItem_DataGridViewRowAdd.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_DataGridViewRowAdd.Text = "添加";
            this.toolStripMenuItem_DataGridViewRowAdd.Click += new System.EventHandler(this.toolStripMenuItem_WPSRowAdd_Click);
            // 
            // toolStripMenuItem_DataGridViewRowModify
            // 
            this.toolStripMenuItem_DataGridViewRowModify.Name = "toolStripMenuItem_DataGridViewRowModify";
            this.toolStripMenuItem_DataGridViewRowModify.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_DataGridViewRowModify.Text = "修改";
            this.toolStripMenuItem_DataGridViewRowModify.Click += new System.EventHandler(this.toolStripMenuItem_WPSRowModify_Click);
            // 
            // toolStripMenuItem_DataGridViewRowDelete
            // 
            this.toolStripMenuItem_DataGridViewRowDelete.Name = "toolStripMenuItem_DataGridViewRowDelete";
            this.toolStripMenuItem_DataGridViewRowDelete.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_DataGridViewRowDelete.Text = "删除";
            this.toolStripMenuItem_DataGridViewRowDelete.Click += new System.EventHandler(this.toolStripMenuItem_WPSRowDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(123, 6);
            // 
            // toolStripMenuItem_WPSRowLockOut
            // 
            this.toolStripMenuItem_WPSRowLockOut.Name = "toolStripMenuItem_WPSRowLockOut";
            this.toolStripMenuItem_WPSRowLockOut.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_WPSRowLockOut.Text = "锁定";
            this.toolStripMenuItem_WPSRowLockOut.Click += new System.EventHandler(this.toolStripMenuItem_WPSRowLockOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(123, 6);
            // 
            // toolStripMenuItem_RowFrozenThisColumn
            // 
            this.toolStripMenuItem_RowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_RowFrozenThisColumn.Name = "toolStripMenuItem_RowFrozenThisColumn";
            this.toolStripMenuItem_RowFrozenThisColumn.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_RowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_RowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_WPSRowFrozenThisColumn_CheckStateChanged);
            // 
            // toolStripMenuItem_RowRefresh
            // 
            this.toolStripMenuItem_RowRefresh.Name = "toolStripMenuItem_RowRefresh";
            this.toolStripMenuItem_RowRefresh.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_RowRefresh.Text = "刷新";
            this.toolStripMenuItem_RowRefresh.Click += new System.EventHandler(this.toolStripMenuItem_WPSRowRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(123, 6);
            // 
            // toolStripMenuItem_RowExport
            // 
            this.toolStripMenuItem_RowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_RowExportExcel});
            this.toolStripMenuItem_RowExport.Name = "toolStripMenuItem_RowExport";
            this.toolStripMenuItem_RowExport.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_RowExport.Text = "导出";
            // 
            // toolStripMenuItem_RowExportExcel
            // 
            this.toolStripMenuItem_RowExportExcel.Name = "toolStripMenuItem_RowExportExcel";
            this.toolStripMenuItem_RowExportExcel.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem_RowExportExcel.Text = "导出Excel";
            this.toolStripMenuItem_RowExportExcel.Click += new System.EventHandler(this.toolStripMenuItem_RowExportExcel_Click);
            // 
            // UserControl_WPSDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Data);
            this.Controls.Add(this.dataGridView_Data);
            this.Name = "UserControl_WPSDataGridView";
            this.Size = new System.Drawing.Size(598, 457);
            this.Load += new System.EventHandler(this.UserControl_WPSDataGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.contextMenuStrip_pWPS.ResumeLayout(false);
            this.contextMenuStrip_pWPSRow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_pWPS;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_pWPSRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowModify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowExportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Refresh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSRowLockOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowFrozenThisColumn;
    }
}
