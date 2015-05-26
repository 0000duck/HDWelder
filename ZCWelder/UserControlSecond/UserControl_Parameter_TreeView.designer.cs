namespace ZCWelder.UserControlSecond
{
    partial class UserControl_Parameter_TreeView
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
            this.treeView_Parameter = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_Parameter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ParameterRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.label_Parameter = new System.Windows.Forms.Label();
            this.contextMenuStrip_Parameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_Parameter
            // 
            this.treeView_Parameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_Parameter.ContextMenuStrip = this.contextMenuStrip_Parameter;
            this.treeView_Parameter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView_Parameter.Location = new System.Drawing.Point(0, 25);
            this.treeView_Parameter.Name = "treeView_Parameter";
            this.treeView_Parameter.Size = new System.Drawing.Size(196, 337);
            this.treeView_Parameter.TabIndex = 0;
            this.treeView_Parameter.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Parameter_AfterSelect);
            // 
            // contextMenuStrip_Parameter
            // 
            this.contextMenuStrip_Parameter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ParameterRefresh});
            this.contextMenuStrip_Parameter.Name = "contextMenuStrip_Parameter";
            this.contextMenuStrip_Parameter.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem_ParameterRefresh
            // 
            this.toolStripMenuItem_ParameterRefresh.Name = "toolStripMenuItem_ParameterRefresh";
            this.toolStripMenuItem_ParameterRefresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_ParameterRefresh.Text = "刷新";
            this.toolStripMenuItem_ParameterRefresh.Click += new System.EventHandler(this.toolStripMenuItem_ParameterRefresh_Click);
            // 
            // label_Parameter
            // 
            this.label_Parameter.AutoSize = true;
            this.label_Parameter.Location = new System.Drawing.Point(12, 7);
            this.label_Parameter.Name = "label_Parameter";
            this.label_Parameter.Size = new System.Drawing.Size(41, 12);
            this.label_Parameter.TabIndex = 1;
            this.label_Parameter.Text = "参数：";
            // 
            // UserControl_Parameter_TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Parameter);
            this.Controls.Add(this.treeView_Parameter);
            this.Name = "UserControl_Parameter_TreeView";
            this.Size = new System.Drawing.Size(196, 362);
            this.Load += new System.EventHandler(this.UserControl_Parameter_TreeView_Load);
            this.contextMenuStrip_Parameter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_Parameter;
        private System.Windows.Forms.Label label_Parameter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Parameter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ParameterRefresh;
    }
}
