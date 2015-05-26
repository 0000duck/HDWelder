namespace ZCWelder.UserControlSecond
{
    partial class UserControl_KindofEmployerIssue_DataGridView
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowModify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_RowTransferIssue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RowTransferGXTheoryIssue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.label_Data = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip_DataGridView.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip_DataGridView
            // 
            this.contextMenuStrip_DataGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewAdd,
            this.toolStripSeparator1,
            this.toolStripMenuItem_DataGridViewRefresh});
            this.contextMenuStrip_DataGridView.Name = "contextMenuStrip_pWPSTest";
            this.contextMenuStrip_DataGridView.Size = new System.Drawing.Size(101, 54);
            this.contextMenuStrip_DataGridView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridView_Opening);
            // 
            // toolStripMenuItem_DataGridViewAdd
            // 
            this.toolStripMenuItem_DataGridViewAdd.Name = "toolStripMenuItem_DataGridViewAdd";
            this.toolStripMenuItem_DataGridViewAdd.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_DataGridViewAdd.Text = "添加";
            this.toolStripMenuItem_DataGridViewAdd.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // toolStripMenuItem_DataGridViewRefresh
            // 
            this.toolStripMenuItem_DataGridViewRefresh.Name = "toolStripMenuItem_DataGridViewRefresh";
            this.toolStripMenuItem_DataGridViewRefresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_DataGridViewRefresh.Text = "刷新";
            this.toolStripMenuItem_DataGridViewRefresh.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowRefresh_Click);
            // 
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowAdd,
            this.toolStripMenuItem_DataGridViewRowModify,
            this.toolStripMenuItem_DataGridViewRowDelete,
            this.toolStripSeparator4,
            this.toolStripMenuItem_RowTransferIssue,
            this.toolStripMenuItem_RowTransferGXTheoryIssue,
            this.toolStripSeparator2,
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripMenuItem_DataGridViewRowRefresh,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(153, 198);
            this.contextMenuStrip_DataGridViewRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridViewRow_Opening);
            // 
            // toolStripMenuItem_DataGridViewRowAdd
            // 
            this.toolStripMenuItem_DataGridViewRowAdd.Name = "toolStripMenuItem_DataGridViewRowAdd";
            this.toolStripMenuItem_DataGridViewRowAdd.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowAdd.Text = "添加";
            this.toolStripMenuItem_DataGridViewRowAdd.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowAdd_Click);
            // 
            // toolStripMenuItem_DataGridViewRowModify
            // 
            this.toolStripMenuItem_DataGridViewRowModify.Name = "toolStripMenuItem_DataGridViewRowModify";
            this.toolStripMenuItem_DataGridViewRowModify.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowModify.Text = "修改";
            this.toolStripMenuItem_DataGridViewRowModify.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowModify_Click);
            // 
            // toolStripMenuItem_DataGridViewRowDelete
            // 
            this.toolStripMenuItem_DataGridViewRowDelete.Name = "toolStripMenuItem_DataGridViewRowDelete";
            this.toolStripMenuItem_DataGridViewRowDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowDelete.Text = "删除";
            this.toolStripMenuItem_DataGridViewRowDelete.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem_RowTransferIssue
            // 
            this.toolStripMenuItem_RowTransferIssue.Name = "toolStripMenuItem_RowTransferIssue";
            this.toolStripMenuItem_RowTransferIssue.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_RowTransferIssue.Text = "编入班级";
            this.toolStripMenuItem_RowTransferIssue.Click += new System.EventHandler(this.toolStripMenuItem_RowTransferIssue_Click);
            // 
            // toolStripMenuItem_RowTransferGXTheoryIssue
            // 
            this.toolStripMenuItem_RowTransferGXTheoryIssue.Name = "toolStripMenuItem_RowTransferGXTheoryIssue";
            this.toolStripMenuItem_RowTransferGXTheoryIssue.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_RowTransferGXTheoryIssue.Text = "编入理论班级";
            this.toolStripMenuItem_RowTransferGXTheoryIssue.Click += new System.EventHandler(this.toolStripMenuItem_RowTransferGXTheoryIssue_Click);
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
            // toolStripMenuItem_DataGridViewRowRefresh
            // 
            this.toolStripMenuItem_DataGridViewRowRefresh.Name = "toolStripMenuItem_DataGridViewRowRefresh";
            this.toolStripMenuItem_DataGridViewRowRefresh.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowRefresh.Text = "刷新";
            this.toolStripMenuItem_DataGridViewRowRefresh.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowRefresh_Click);
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
            this.dataGridView_Data.Size = new System.Drawing.Size(578, 405);
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
            this.splitContainer1.Panel1.Controls.Add(this.label_Data);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Data);
            this.splitContainer1.Size = new System.Drawing.Size(578, 437);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 5;
            // 
            // UserControl_KindofEmployerIssue_DataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_KindofEmployerIssue_DataGridView";
            this.Size = new System.Drawing.Size(578, 437);
            this.Load += new System.EventHandler(this.UserControl_Template_DataGridView_Load);
            this.contextMenuStrip_DataGridView.ResumeLayout(false);
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowTransferIssue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RowTransferGXTheoryIssue;
    }
}
