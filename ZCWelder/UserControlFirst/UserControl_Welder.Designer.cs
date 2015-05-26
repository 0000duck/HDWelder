namespace ZCWelder.UserControlFirst
{
    partial class UserControl_Welder
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Filter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_IdentificationCard = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ExaminingNo = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.userControl_WelderQuery1 = new ZCWelder.UserControlSecond.UserControl_WelderQuery();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.userControl_Welder_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_Welder_DataGridView();
            this.userControl_WelderIssueStudentQCRegistrationNo_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_IssueStudentQCRegistrationNo_DataGridView();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(745, 565);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(745, 612);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Filter,
            this.toolStripStatusLabel_IdentificationCard,
            this.toolStripStatusLabel_ExaminingNo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(745, 22);
            this.statusStrip1.TabIndex = 0;
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
            // toolStripStatusLabel_IdentificationCard
            // 
            this.toolStripStatusLabel_IdentificationCard.AutoSize = false;
            this.toolStripStatusLabel_IdentificationCard.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_IdentificationCard.Name = "toolStripStatusLabel_IdentificationCard";
            this.toolStripStatusLabel_IdentificationCard.Size = new System.Drawing.Size(250, 17);
            this.toolStripStatusLabel_IdentificationCard.Text = "身份证号码：";
            this.toolStripStatusLabel_IdentificationCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_ExaminingNo
            // 
            this.toolStripStatusLabel_ExaminingNo.AutoSize = false;
            this.toolStripStatusLabel_ExaminingNo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_ExaminingNo.Name = "toolStripStatusLabel_ExaminingNo";
            this.toolStripStatusLabel_ExaminingNo.Size = new System.Drawing.Size(200, 13);
            this.toolStripStatusLabel_ExaminingNo.Text = "钢印号：";
            this.toolStripStatusLabel_ExaminingNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(745, 565);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.userControl_WelderQuery1);
            this.splitContainer2.Size = new System.Drawing.Size(272, 565);
            this.splitContainer2.SplitterDistance = 311;
            this.splitContainer2.TabIndex = 0;
            // 
            // userControl_WelderQuery1
            // 
            this.userControl_WelderQuery1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WelderQuery1.Location = new System.Drawing.Point(0, 0);
            this.userControl_WelderQuery1.Name = "userControl_WelderQuery1";
            this.userControl_WelderQuery1.Size = new System.Drawing.Size(270, 309);
            this.userControl_WelderQuery1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.userControl_Welder_DataGridView1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.userControl_WelderIssueStudentQCRegistrationNo_DataGridView1);
            this.splitContainer3.Size = new System.Drawing.Size(469, 565);
            this.splitContainer3.SplitterDistance = 230;
            this.splitContainer3.TabIndex = 1;
            // 
            // userControl_Welder_DataGridView1
            // 
            this.userControl_Welder_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_Welder_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_Welder_DataGridView1.Name = "userControl_Welder_DataGridView1";
            this.userControl_Welder_DataGridView1.Size = new System.Drawing.Size(467, 228);
            this.userControl_Welder_DataGridView1.TabIndex = 0;
            // 
            // userControl_WelderIssueStudentQCRegistrationNo_DataGridView1
            // 
            this.userControl_WelderIssueStudentQCRegistrationNo_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WelderIssueStudentQCRegistrationNo_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_WelderIssueStudentQCRegistrationNo_DataGridView1.Name = "userControl_WelderIssueStudentQCRegistrationNo_DataGridView1";
            this.userControl_WelderIssueStudentQCRegistrationNo_DataGridView1.Size = new System.Drawing.Size(467, 329);
            this.userControl_WelderIssueStudentQCRegistrationNo_DataGridView1.TabIndex = 0;
            // 
            // UserControl_Welder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_Welder";
            this.Size = new System.Drawing.Size(745, 612);
            this.Load += new System.EventHandler(this.UserControl_Welder_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Filter;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ZCWelder.UserControlSecond.UserControl_Welder_DataGridView userControl_Welder_DataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_IdentificationCard;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private ZCWelder.UserControlSecond.UserControl_IssueStudentQCRegistrationNo_DataGridView userControl_WelderIssueStudentQCRegistrationNo_DataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ExaminingNo;
        public ZCWelder.UserControlSecond.UserControl_WelderQuery userControl_WelderQuery1;
    }
}
