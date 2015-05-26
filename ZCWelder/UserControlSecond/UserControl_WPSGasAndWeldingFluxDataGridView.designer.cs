namespace ZCWelder.UserControlSecond
{
    partial class UserControl_WPSGasAndWeldingFluxDataGridView
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
            this.dataGridView_WPSGasAndWeldingFlux = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_WPSGasAndWeldingFlux = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_WPSGasAndWeldingFluxAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WPSGasAndWeldingFluxRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.label_WPSGasAndWeldingFlux = new System.Windows.Forms.Label();
            this.contextMenuStrip_WPSGasAndWeldingFluxRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowModify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WPSGasAndWeldingFlux)).BeginInit();
            this.contextMenuStrip_WPSGasAndWeldingFlux.SuspendLayout();
            this.contextMenuStrip_WPSGasAndWeldingFluxRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_WPSGasAndWeldingFlux
            // 
            this.dataGridView_WPSGasAndWeldingFlux.AllowUserToAddRows = false;
            this.dataGridView_WPSGasAndWeldingFlux.AllowUserToDeleteRows = false;
            this.dataGridView_WPSGasAndWeldingFlux.AllowUserToOrderColumns = true;
            this.dataGridView_WPSGasAndWeldingFlux.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_WPSGasAndWeldingFlux.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_WPSGasAndWeldingFlux.ContextMenuStrip = this.contextMenuStrip_WPSGasAndWeldingFlux;
            this.dataGridView_WPSGasAndWeldingFlux.Location = new System.Drawing.Point(0, 31);
            this.dataGridView_WPSGasAndWeldingFlux.Name = "dataGridView_WPSGasAndWeldingFlux";
            this.dataGridView_WPSGasAndWeldingFlux.ReadOnly = true;
            this.dataGridView_WPSGasAndWeldingFlux.RowTemplate.Height = 23;
            this.dataGridView_WPSGasAndWeldingFlux.Size = new System.Drawing.Size(593, 466);
            this.dataGridView_WPSGasAndWeldingFlux.TabIndex = 0;
            this.dataGridView_WPSGasAndWeldingFlux.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_WPSGasAndWeldingFlux_CellContextMenuStripNeeded);
            // 
            // contextMenuStrip_WPSGasAndWeldingFlux
            // 
            this.contextMenuStrip_WPSGasAndWeldingFlux.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_WPSGasAndWeldingFluxAdd,
            this.toolStripSeparator3,
            this.toolStripMenuItem_WPSGasAndWeldingFluxRefresh});
            this.contextMenuStrip_WPSGasAndWeldingFlux.Name = "contextMenuStrip1";
            this.contextMenuStrip_WPSGasAndWeldingFlux.Size = new System.Drawing.Size(101, 54);
            this.contextMenuStrip_WPSGasAndWeldingFlux.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_WPSGasAndWeldingFlux_Opening);
            // 
            // toolStripMenuItem_WPSGasAndWeldingFluxAdd
            // 
            this.toolStripMenuItem_WPSGasAndWeldingFluxAdd.Name = "toolStripMenuItem_WPSGasAndWeldingFluxAdd";
            this.toolStripMenuItem_WPSGasAndWeldingFluxAdd.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_WPSGasAndWeldingFluxAdd.Text = "添加";
            this.toolStripMenuItem_WPSGasAndWeldingFluxAdd.Click += new System.EventHandler(this.toolStripMenuItem_WPSGasAndWeldingFluxAdd_Click);
            // 
            // toolStripMenuItem_WPSGasAndWeldingFluxRefresh
            // 
            this.toolStripMenuItem_WPSGasAndWeldingFluxRefresh.Name = "toolStripMenuItem_WPSGasAndWeldingFluxRefresh";
            this.toolStripMenuItem_WPSGasAndWeldingFluxRefresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_WPSGasAndWeldingFluxRefresh.Text = "刷新";
            this.toolStripMenuItem_WPSGasAndWeldingFluxRefresh.Click += new System.EventHandler(this.toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh_Click);
            // 
            // label_WPSGasAndWeldingFlux
            // 
            this.label_WPSGasAndWeldingFlux.AutoSize = true;
            this.label_WPSGasAndWeldingFlux.Location = new System.Drawing.Point(13, 12);
            this.label_WPSGasAndWeldingFlux.Name = "label_WPSGasAndWeldingFlux";
            this.label_WPSGasAndWeldingFlux.Size = new System.Drawing.Size(65, 12);
            this.label_WPSGasAndWeldingFlux.TabIndex = 1;
            this.label_WPSGasAndWeldingFlux.Text = "保护介质：";
            // 
            // contextMenuStrip_WPSGasAndWeldingFluxRow
            // 
            this.contextMenuStrip_WPSGasAndWeldingFluxRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowAdd,
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowModify,
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowDelete,
            this.toolStripSeparator1,
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh,
            this.toolStripSeparator2,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_WPSGasAndWeldingFluxRow.Name = "contextMenuStrip_WPSSequenceRow";
            this.contextMenuStrip_WPSGasAndWeldingFluxRow.Size = new System.Drawing.Size(101, 126);
            this.contextMenuStrip_WPSGasAndWeldingFluxRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_WPSGasAndWeldingFluxRow_Opening);
            // 
            // toolStripMenuItem_WPSGasAndWeldingFluxRowAdd
            // 
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowAdd.Name = "toolStripMenuItem_WPSGasAndWeldingFluxRowAdd";
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowAdd.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowAdd.Text = "添加";
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowAdd.Click += new System.EventHandler(this.toolStripMenuItem_WPSGasAndWeldingFluxRowAdd_Click);
            // 
            // toolStripMenuItem_WPSGasAndWeldingFluxRowModify
            // 
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowModify.Name = "toolStripMenuItem_WPSGasAndWeldingFluxRowModify";
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowModify.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowModify.Text = "修改";
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowModify.Click += new System.EventHandler(this.toolStripMenuItem_WPSGasAndWeldingFluxRowModify_Click);
            // 
            // toolStripMenuItem_WPSGasAndWeldingFluxRowDelete
            // 
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowDelete.Name = "toolStripMenuItem_WPSGasAndWeldingFluxRowDelete";
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowDelete.Text = "删除";
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowDelete.Click += new System.EventHandler(this.toolStripMenuItem_WPSGasAndWeldingFluxRowDelete_Click);
            // 
            // toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh
            // 
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh.Name = "toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh";
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh.Text = "刷新";
            this.toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh.Click += new System.EventHandler(this.toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
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
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(97, 6);
            // 
            // UserControl_WPSGasAndWeldingFluxDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_WPSGasAndWeldingFlux);
            this.Controls.Add(this.dataGridView_WPSGasAndWeldingFlux);
            this.Name = "UserControl_WPSGasAndWeldingFluxDataGridView";
            this.Size = new System.Drawing.Size(593, 497);
            this.Load += new System.EventHandler(this.UserControl_WPSGasAndWeldingFluxDataGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WPSGasAndWeldingFlux)).EndInit();
            this.contextMenuStrip_WPSGasAndWeldingFlux.ResumeLayout(false);
            this.contextMenuStrip_WPSGasAndWeldingFluxRow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_WPSGasAndWeldingFlux;
        private System.Windows.Forms.Label label_WPSGasAndWeldingFlux;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_WPSGasAndWeldingFluxRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSGasAndWeldingFluxRowAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSGasAndWeldingFluxRowModify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSGasAndWeldingFluxRowDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_WPSGasAndWeldingFlux;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSGasAndWeldingFluxAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSGasAndWeldingFluxRefresh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
