namespace ZCWelder.UserControlFirst
{
    partial class UserControl_ReviveQC
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
            this.statusStrip_Filter = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Filter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.userControl_ReviveQC_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_ReviveQC_DataGridView();
            this.statusStrip_Filter.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip_Filter
            // 
            this.statusStrip_Filter.AutoSize = false;
            this.statusStrip_Filter.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip_Filter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Filter});
            this.statusStrip_Filter.Location = new System.Drawing.Point(0, 0);
            this.statusStrip_Filter.Name = "statusStrip_Filter";
            this.statusStrip_Filter.Size = new System.Drawing.Size(609, 22);
            this.statusStrip_Filter.TabIndex = 0;
            // 
            // toolStripStatusLabel_Filter
            // 
            this.toolStripStatusLabel_Filter.AutoSize = false;
            this.toolStripStatusLabel_Filter.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Filter.Name = "toolStripStatusLabel_Filter";
            this.toolStripStatusLabel_Filter.Size = new System.Drawing.Size(500, 17);
            this.toolStripStatusLabel_Filter.Text = "检索条件：";
            this.toolStripStatusLabel_Filter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip_Filter);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.userControl_ReviveQC_DataGridView1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(609, 446);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(609, 468);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // userControl_ReviveQC_DataGridView1
            // 
            this.userControl_ReviveQC_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_ReviveQC_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_ReviveQC_DataGridView1.Name = "userControl_ReviveQC_DataGridView1";
            this.userControl_ReviveQC_DataGridView1.Size = new System.Drawing.Size(609, 446);
            this.userControl_ReviveQC_DataGridView1.TabIndex = 0;
            // 
            // UserControl_ReviveQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_ReviveQC";
            this.Size = new System.Drawing.Size(609, 468);
            this.Load += new System.EventHandler(this.UserControl_ReviveQC_Load);
            this.statusStrip_Filter.ResumeLayout(false);
            this.statusStrip_Filter.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_Filter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Filter;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private ZCWelder.UserControlSecond.UserControl_ReviveQC_DataGridView userControl_ReviveQC_DataGridView1;
    }
}
