namespace ZCWelder.UserControlSecond
{
    partial class UserControl_WPSHeatTreatmentDataGridView
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
            this.dataGridView_WPSHeatTreatment = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_WPSHeatTreatment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_WPSHeatTreatmentAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WPSHeatTreatmentRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.label_WPSHeatTreatment = new System.Windows.Forms.Label();
            this.contextMenuStrip_WPSHeatTreatmentRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_WPSHeatTreatmentRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WPSHeatTreatmentRowModify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WPSHeatTreatmentRowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WPSHeatTreatmentRowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WPSHeatTreatment)).BeginInit();
            this.contextMenuStrip_WPSHeatTreatment.SuspendLayout();
            this.contextMenuStrip_WPSHeatTreatmentRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_WPSHeatTreatment
            // 
            this.dataGridView_WPSHeatTreatment.AllowUserToAddRows = false;
            this.dataGridView_WPSHeatTreatment.AllowUserToDeleteRows = false;
            this.dataGridView_WPSHeatTreatment.AllowUserToOrderColumns = true;
            this.dataGridView_WPSHeatTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_WPSHeatTreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_WPSHeatTreatment.ContextMenuStrip = this.contextMenuStrip_WPSHeatTreatment;
            this.dataGridView_WPSHeatTreatment.Location = new System.Drawing.Point(0, 30);
            this.dataGridView_WPSHeatTreatment.Name = "dataGridView_WPSHeatTreatment";
            this.dataGridView_WPSHeatTreatment.ReadOnly = true;
            this.dataGridView_WPSHeatTreatment.RowTemplate.Height = 23;
            this.dataGridView_WPSHeatTreatment.Size = new System.Drawing.Size(588, 501);
            this.dataGridView_WPSHeatTreatment.TabIndex = 0;
            this.dataGridView_WPSHeatTreatment.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_WPSHeatTreatment_CellContextMenuStripNeeded);
            // 
            // contextMenuStrip_WPSHeatTreatment
            // 
            this.contextMenuStrip_WPSHeatTreatment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_WPSHeatTreatmentAdd,
            this.toolStripSeparator1,
            this.toolStripMenuItem_WPSHeatTreatmentRefresh});
            this.contextMenuStrip_WPSHeatTreatment.Name = "contextMenuStrip_WPSTest";
            this.contextMenuStrip_WPSHeatTreatment.Size = new System.Drawing.Size(101, 54);
            this.contextMenuStrip_WPSHeatTreatment.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_WPSHeatTreatment_Opening);
            // 
            // toolStripMenuItem_WPSHeatTreatmentAdd
            // 
            this.toolStripMenuItem_WPSHeatTreatmentAdd.Name = "toolStripMenuItem_WPSHeatTreatmentAdd";
            this.toolStripMenuItem_WPSHeatTreatmentAdd.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_WPSHeatTreatmentAdd.Text = "添加";
            this.toolStripMenuItem_WPSHeatTreatmentAdd.Click += new System.EventHandler(this.toolStripMenuItem_WPSHeatTreatmentAdd_Click);
            // 
            // toolStripMenuItem_WPSHeatTreatmentRefresh
            // 
            this.toolStripMenuItem_WPSHeatTreatmentRefresh.Name = "toolStripMenuItem_WPSHeatTreatmentRefresh";
            this.toolStripMenuItem_WPSHeatTreatmentRefresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_WPSHeatTreatmentRefresh.Text = "刷新";
            this.toolStripMenuItem_WPSHeatTreatmentRefresh.Click += new System.EventHandler(this.toolStripMenuItem_WPSHeatTreatmentRowRefresh_Click);
            // 
            // label_WPSHeatTreatment
            // 
            this.label_WPSHeatTreatment.AutoSize = true;
            this.label_WPSHeatTreatment.Location = new System.Drawing.Point(16, 12);
            this.label_WPSHeatTreatment.Name = "label_WPSHeatTreatment";
            this.label_WPSHeatTreatment.Size = new System.Drawing.Size(77, 12);
            this.label_WPSHeatTreatment.TabIndex = 1;
            this.label_WPSHeatTreatment.Text = "热处理方式：";
            // 
            // contextMenuStrip_WPSHeatTreatmentRow
            // 
            this.contextMenuStrip_WPSHeatTreatmentRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_WPSHeatTreatmentRowAdd,
            this.toolStripMenuItem_WPSHeatTreatmentRowModify,
            this.toolStripMenuItem_WPSHeatTreatmentRowDelete,
            this.toolStripSeparator2,
            this.toolStripMenuItem_WPSHeatTreatmentRowRefresh,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_WPSHeatTreatmentRow.Name = "contextMenuStrip_WPSTestRow";
            this.contextMenuStrip_WPSHeatTreatmentRow.Size = new System.Drawing.Size(153, 148);
            this.contextMenuStrip_WPSHeatTreatmentRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_WPSHeatTreatmentRow_Opening);
            // 
            // toolStripMenuItem_WPSHeatTreatmentRowAdd
            // 
            this.toolStripMenuItem_WPSHeatTreatmentRowAdd.Name = "toolStripMenuItem_WPSHeatTreatmentRowAdd";
            this.toolStripMenuItem_WPSHeatTreatmentRowAdd.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSHeatTreatmentRowAdd.Text = "添加";
            this.toolStripMenuItem_WPSHeatTreatmentRowAdd.Click += new System.EventHandler(this.toolStripMenuItem_WPSHeatTreatmentRowAdd_Click);
            // 
            // toolStripMenuItem_WPSHeatTreatmentRowModify
            // 
            this.toolStripMenuItem_WPSHeatTreatmentRowModify.Name = "toolStripMenuItem_WPSHeatTreatmentRowModify";
            this.toolStripMenuItem_WPSHeatTreatmentRowModify.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSHeatTreatmentRowModify.Text = "修改";
            this.toolStripMenuItem_WPSHeatTreatmentRowModify.Click += new System.EventHandler(this.toolStripMenuItem_WPSHeatTreatmentRowModify_Click);
            // 
            // toolStripMenuItem_WPSHeatTreatmentRowDelete
            // 
            this.toolStripMenuItem_WPSHeatTreatmentRowDelete.Name = "toolStripMenuItem_WPSHeatTreatmentRowDelete";
            this.toolStripMenuItem_WPSHeatTreatmentRowDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSHeatTreatmentRowDelete.Text = "删除";
            this.toolStripMenuItem_WPSHeatTreatmentRowDelete.Click += new System.EventHandler(this.toolStripMenuItem_WPSHeatTreatmentRowDelete_Click);
            // 
            // toolStripMenuItem_WPSHeatTreatmentRowRefresh
            // 
            this.toolStripMenuItem_WPSHeatTreatmentRowRefresh.Name = "toolStripMenuItem_WPSHeatTreatmentRowRefresh";
            this.toolStripMenuItem_WPSHeatTreatmentRowRefresh.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSHeatTreatmentRowRefresh.Text = "刷新";
            this.toolStripMenuItem_WPSHeatTreatmentRowRefresh.Click += new System.EventHandler(this.toolStripMenuItem_WPSHeatTreatmentRowRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
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
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // UserControl_WPSHeatTreatmentDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_WPSHeatTreatment);
            this.Controls.Add(this.dataGridView_WPSHeatTreatment);
            this.Name = "UserControl_WPSHeatTreatmentDataGridView";
            this.Size = new System.Drawing.Size(588, 531);
            this.Load += new System.EventHandler(this.UserControl_WPSHeatTreatmentDataGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WPSHeatTreatment)).EndInit();
            this.contextMenuStrip_WPSHeatTreatment.ResumeLayout(false);
            this.contextMenuStrip_WPSHeatTreatmentRow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_WPSHeatTreatment;
        private System.Windows.Forms.Label label_WPSHeatTreatment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_WPSHeatTreatmentRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSHeatTreatmentRowAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSHeatTreatmentRowModify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSHeatTreatmentRowDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSHeatTreatmentRowRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_WPSHeatTreatment;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSHeatTreatmentAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSHeatTreatmentRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
    }
}
