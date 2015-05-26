namespace ZCWelder.UserControlSecond
{
    partial class UserControl_WeldingSubject_TreeView
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
            this.toolStripMenuItem_DataGridViewColumnGroupRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label_Data = new System.Windows.Forms.Label();
            this.treeView_Data = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_TreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip_TreeView.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.treeView_Data);
            this.splitContainer1.Size = new System.Drawing.Size(275, 428);
            this.splitContainer1.SplitterDistance = 35;
            this.splitContainer1.TabIndex = 8;
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
            this.treeView_Data.Size = new System.Drawing.Size(275, 389);
            this.treeView_Data.TabIndex = 4;
            this.treeView_Data.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Data_AfterSelect);
            // 
            // contextMenuStrip_TreeView
            // 
            this.contextMenuStrip_TreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewColumnGroupRefresh});
            this.contextMenuStrip_TreeView.Name = "contextMenuStrip_Parameter";
            this.contextMenuStrip_TreeView.Size = new System.Drawing.Size(101, 26);
            // 
            // UserControl_WeldingSubject_TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_WeldingSubject_TreeView";
            this.Size = new System.Drawing.Size(275, 428);
            this.Load += new System.EventHandler(this.UserControl_WeldingSubject_TreeView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip_TreeView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewColumnGroupRefresh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.TreeView treeView_Data;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_TreeView;
    }
}
