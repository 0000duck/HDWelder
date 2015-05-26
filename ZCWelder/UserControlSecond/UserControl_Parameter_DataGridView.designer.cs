namespace ZCWelder.UserControlSecond
{
    partial class UserControl_Parameter_DataGridView
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
            this.dataGridView_Parameter = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Parameter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ParameterAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ParameterRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.label_Parameter = new System.Windows.Forms.Label();
            this.contextMenuStrip_ParameterRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ParameterRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ParameterRowModify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ParameterRowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ParameterRowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ParameterRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ParameterRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ParameterRowExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Query = new System.Windows.Forms.Button();
            this.toolStripMenuItem_ParameterRowExportEMSExcel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Parameter)).BeginInit();
            this.contextMenuStrip_Parameter.SuspendLayout();
            this.contextMenuStrip_ParameterRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Parameter
            // 
            this.dataGridView_Parameter.AllowUserToAddRows = false;
            this.dataGridView_Parameter.AllowUserToDeleteRows = false;
            this.dataGridView_Parameter.AllowUserToOrderColumns = true;
            this.dataGridView_Parameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Parameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Parameter.ContextMenuStrip = this.contextMenuStrip_Parameter;
            this.dataGridView_Parameter.Location = new System.Drawing.Point(0, 29);
            this.dataGridView_Parameter.Name = "dataGridView_Parameter";
            this.dataGridView_Parameter.ReadOnly = true;
            this.dataGridView_Parameter.RowTemplate.Height = 23;
            this.dataGridView_Parameter.Size = new System.Drawing.Size(540, 439);
            this.dataGridView_Parameter.TabIndex = 0;
            this.dataGridView_Parameter.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Parameter_CellContextMenuStripNeeded);
            // 
            // contextMenuStrip_Parameter
            // 
            this.contextMenuStrip_Parameter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ParameterAdd,
            this.toolStripSeparator3,
            this.toolStripMenuItem_ParameterRefresh});
            this.contextMenuStrip_Parameter.Name = "contextMenuStrip1";
            this.contextMenuStrip_Parameter.Size = new System.Drawing.Size(101, 54);
            this.contextMenuStrip_Parameter.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Parameter_Opening);
            // 
            // toolStripMenuItem_ParameterAdd
            // 
            this.toolStripMenuItem_ParameterAdd.Name = "toolStripMenuItem_ParameterAdd";
            this.toolStripMenuItem_ParameterAdd.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_ParameterAdd.Text = "添加";
            this.toolStripMenuItem_ParameterAdd.Click += new System.EventHandler(this.toolStripMenuItem_ParameterAdd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(97, 6);
            // 
            // toolStripMenuItem_ParameterRefresh
            // 
            this.toolStripMenuItem_ParameterRefresh.Name = "toolStripMenuItem_ParameterRefresh";
            this.toolStripMenuItem_ParameterRefresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_ParameterRefresh.Text = "刷新";
            this.toolStripMenuItem_ParameterRefresh.Click += new System.EventHandler(this.toolStripMenuItem_ParameterRowRefresh_Click);
            // 
            // label_Parameter
            // 
            this.label_Parameter.AutoSize = true;
            this.label_Parameter.Location = new System.Drawing.Point(8, 9);
            this.label_Parameter.Name = "label_Parameter";
            this.label_Parameter.Size = new System.Drawing.Size(41, 12);
            this.label_Parameter.TabIndex = 1;
            this.label_Parameter.Text = "参数：";
            // 
            // contextMenuStrip_ParameterRow
            // 
            this.contextMenuStrip_ParameterRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ParameterRowAdd,
            this.toolStripMenuItem_ParameterRowModify,
            this.toolStripMenuItem_ParameterRowDelete,
            this.toolStripSeparator1,
            this.toolStripMenuItem_ParameterRowRefresh,
            this.toolStripMenuItem_ParameterRowFrozenThisColumn,
            this.toolStripSeparator2,
            this.toolStripMenuItem_ParameterRowExport});
            this.contextMenuStrip_ParameterRow.Name = "contextMenuStrip_pWPSSequenceRow";
            this.contextMenuStrip_ParameterRow.Size = new System.Drawing.Size(153, 170);
            this.contextMenuStrip_ParameterRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_ParameterRow_Opening);
            // 
            // toolStripMenuItem_ParameterRowAdd
            // 
            this.toolStripMenuItem_ParameterRowAdd.Name = "toolStripMenuItem_ParameterRowAdd";
            this.toolStripMenuItem_ParameterRowAdd.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_ParameterRowAdd.Text = "添加";
            this.toolStripMenuItem_ParameterRowAdd.Click += new System.EventHandler(this.toolStripMenuItem_ParameterRowAdd_Click);
            // 
            // toolStripMenuItem_ParameterRowModify
            // 
            this.toolStripMenuItem_ParameterRowModify.Name = "toolStripMenuItem_ParameterRowModify";
            this.toolStripMenuItem_ParameterRowModify.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_ParameterRowModify.Text = "修改";
            this.toolStripMenuItem_ParameterRowModify.Click += new System.EventHandler(this.toolStripMenuItem_ParameterRowModify_Click);
            // 
            // toolStripMenuItem_ParameterRowDelete
            // 
            this.toolStripMenuItem_ParameterRowDelete.Name = "toolStripMenuItem_ParameterRowDelete";
            this.toolStripMenuItem_ParameterRowDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_ParameterRowDelete.Text = "删除";
            this.toolStripMenuItem_ParameterRowDelete.Click += new System.EventHandler(this.toolStripMenuItem_ParameterRowDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem_ParameterRowRefresh
            // 
            this.toolStripMenuItem_ParameterRowRefresh.Name = "toolStripMenuItem_ParameterRowRefresh";
            this.toolStripMenuItem_ParameterRowRefresh.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_ParameterRowRefresh.Text = "刷新";
            this.toolStripMenuItem_ParameterRowRefresh.Click += new System.EventHandler(this.toolStripMenuItem_ParameterRowRefresh_Click);
            // 
            // toolStripMenuItem_ParameterRowFrozenThisColumn
            // 
            this.toolStripMenuItem_ParameterRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_ParameterRowFrozenThisColumn.Name = "toolStripMenuItem_ParameterRowFrozenThisColumn";
            this.toolStripMenuItem_ParameterRowFrozenThisColumn.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_ParameterRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_ParameterRowFrozenThisColumn.Click += new System.EventHandler(this.toolStripMenuItem_ParameterRowFrozenThisColumn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem_ParameterRowExport
            // 
            this.toolStripMenuItem_ParameterRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ParameterRowExportExcel,
            this.toolStripMenuItem_ParameterRowExportEMSExcel});
            this.toolStripMenuItem_ParameterRowExport.Name = "toolStripMenuItem_ParameterRowExport";
            this.toolStripMenuItem_ParameterRowExport.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_ParameterRowExport.Text = "导出";
            // 
            // toolStripMenuItem_ParameterRowExportExcel
            // 
            this.toolStripMenuItem_ParameterRowExportExcel.Name = "toolStripMenuItem_ParameterRowExportExcel";
            this.toolStripMenuItem_ParameterRowExportExcel.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem_ParameterRowExportExcel.Text = "导出到Excel";
            this.toolStripMenuItem_ParameterRowExportExcel.Click += new System.EventHandler(this.toolStripMenuItem_ParameterRowExportExcel_Click);
            // 
            // button_Query
            // 
            this.button_Query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Query.Location = new System.Drawing.Point(444, 4);
            this.button_Query.Name = "button_Query";
            this.button_Query.Size = new System.Drawing.Size(75, 23);
            this.button_Query.TabIndex = 3;
            this.button_Query.Text = "检索";
            this.button_Query.UseVisualStyleBackColor = true;
            this.button_Query.Click += new System.EventHandler(this.button_Query_Click);
            // 
            // toolStripMenuItem_ParameterRowExportEMSExcel
            // 
            this.toolStripMenuItem_ParameterRowExportEMSExcel.Name = "toolStripMenuItem_ParameterRowExportEMSExcel";
            this.toolStripMenuItem_ParameterRowExportEMSExcel.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem_ParameterRowExportEMSExcel.Text = "导出EMSExcel文件";
            this.toolStripMenuItem_ParameterRowExportEMSExcel.Click += new System.EventHandler(this.toolStripMenuItem_ParameterRowExportEMSExcel_Click);
            // 
            // UserControl_Parameter_DataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Query);
            this.Controls.Add(this.label_Parameter);
            this.Controls.Add(this.dataGridView_Parameter);
            this.Name = "UserControl_Parameter_DataGridView";
            this.Size = new System.Drawing.Size(540, 468);
            this.Load += new System.EventHandler(this.UserControl_Parameter_DataGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Parameter)).EndInit();
            this.contextMenuStrip_Parameter.ResumeLayout(false);
            this.contextMenuStrip_ParameterRow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Parameter;
        private System.Windows.Forms.Label label_Parameter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ParameterRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterRowAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterRowModify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterRowDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterRowRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Parameter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterRowFrozenThisColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterRowExportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterRefresh;
        private System.Windows.Forms.Button button_Query;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterRowExportEMSExcel;
    }
}
