namespace ZCWelder.UserControlFirst
{
    partial class UserControl_Parameter
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.userControl_Parameter_TreeView1 = new ZCWelder.UserControlSecond.UserControl_Parameter_TreeView();
            this.userControl_Parameter_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_Parameter_DataGridView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip_Parameter = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Parameter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Filter = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip_Parameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.userControl_Parameter_TreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.userControl_Parameter_DataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(626, 483);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 0;
            // 
            // userControl_Parameter_TreeView1
            // 
            this.userControl_Parameter_TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_Parameter_TreeView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_Parameter_TreeView1.Name = "userControl_Parameter_TreeView1";
            this.userControl_Parameter_TreeView1.Size = new System.Drawing.Size(209, 481);
            this.userControl_Parameter_TreeView1.TabIndex = 0;
            // 
            // userControl_Parameter_DataGridView1
            // 
            this.userControl_Parameter_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_Parameter_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_Parameter_DataGridView1.Name = "userControl_Parameter_DataGridView1";
            this.userControl_Parameter_DataGridView1.Size = new System.Drawing.Size(409, 481);
            this.userControl_Parameter_DataGridView1.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip_Parameter);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(626, 483);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(626, 530);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip_Parameter
            // 
            this.statusStrip_Parameter.AutoSize = false;
            this.statusStrip_Parameter.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip_Parameter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Parameter,
            this.toolStripStatusLabel_Filter});
            this.statusStrip_Parameter.Location = new System.Drawing.Point(0, 0);
            this.statusStrip_Parameter.Name = "statusStrip_Parameter";
            this.statusStrip_Parameter.Size = new System.Drawing.Size(626, 22);
            this.statusStrip_Parameter.TabIndex = 0;
            // 
            // toolStripStatusLabel_Parameter
            // 
            this.toolStripStatusLabel_Parameter.AutoSize = false;
            this.toolStripStatusLabel_Parameter.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Parameter.Name = "toolStripStatusLabel_Parameter";
            this.toolStripStatusLabel_Parameter.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel_Parameter.Text = "参数：";
            this.toolStripStatusLabel_Parameter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_Filter
            // 
            this.toolStripStatusLabel_Filter.Name = "toolStripStatusLabel_Filter";
            this.toolStripStatusLabel_Filter.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel_Filter.Text = "检索条件：";
            // 
            // UserControl_Parameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_Parameter";
            this.Size = new System.Drawing.Size(626, 530);
            this.Load += new System.EventHandler(this.UserControl_Parameter_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip_Parameter.ResumeLayout(false);
            this.statusStrip_Parameter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZCWelder.UserControlSecond.UserControl_Parameter_TreeView userControl_Parameter_TreeView1;
        private ZCWelder.UserControlSecond.UserControl_Parameter_DataGridView userControl_Parameter_DataGridView1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip_Parameter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Parameter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Filter;
    }
}
