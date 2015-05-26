namespace ZCWelder.UserControlFirst
{
    partial class UserControl_SignUp
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
            this.userControl_KindofEmployer_TreeView1 = new ZCWelder.UserControlSecond.UserControl_KindofEmployer_TreeView();
            this.tabControl_SignUp = new System.Windows.Forms.TabControl();
            this.tabPage_Welder = new System.Windows.Forms.TabPage();
            this.userControl_KindofEmployerWelder_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_KindofEmployerWelder_DataGridView();
            this.tabPage_SignUpExam = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.userControl_KindofEmployerIssue_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_KindofEmployerIssue_DataGridView();
            this.userControl_KindofEmployerStudent_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_KindofEmployerStudent_DataGridView();
            this.tabPage_Exam = new System.Windows.Forms.TabPage();
            this.userControl_KindofEmployerExam_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_KindofEmployerExam_DataGridView();
            this.statusStrip_Parameter = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_KindofEmployer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl_SignUp.SuspendLayout();
            this.tabPage_Welder.SuspendLayout();
            this.tabPage_SignUpExam.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage_Exam.SuspendLayout();
            this.statusStrip_Parameter.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.userControl_KindofEmployer_TreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl_SignUp);
            this.splitContainer1.Size = new System.Drawing.Size(633, 484);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 0;
            // 
            // userControl_KindofEmployer_TreeView1
            // 
            this.userControl_KindofEmployer_TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_KindofEmployer_TreeView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_KindofEmployer_TreeView1.Name = "userControl_KindofEmployer_TreeView1";
            this.userControl_KindofEmployer_TreeView1.Size = new System.Drawing.Size(261, 482);
            this.userControl_KindofEmployer_TreeView1.TabIndex = 0;
            // 
            // tabControl_SignUp
            // 
            this.tabControl_SignUp.Controls.Add(this.tabPage_Welder);
            this.tabControl_SignUp.Controls.Add(this.tabPage_SignUpExam);
            this.tabControl_SignUp.Controls.Add(this.tabPage_Exam);
            this.tabControl_SignUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_SignUp.Location = new System.Drawing.Point(0, 0);
            this.tabControl_SignUp.Name = "tabControl_SignUp";
            this.tabControl_SignUp.SelectedIndex = 0;
            this.tabControl_SignUp.Size = new System.Drawing.Size(364, 482);
            this.tabControl_SignUp.TabIndex = 0;
            this.tabControl_SignUp.SelectedIndexChanged += new System.EventHandler(this.tabControl_SignUp_SelectedIndexChanged);
            // 
            // tabPage_Welder
            // 
            this.tabPage_Welder.Controls.Add(this.userControl_KindofEmployerWelder_DataGridView1);
            this.tabPage_Welder.Location = new System.Drawing.Point(4, 21);
            this.tabPage_Welder.Name = "tabPage_Welder";
            this.tabPage_Welder.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Welder.Size = new System.Drawing.Size(356, 457);
            this.tabPage_Welder.TabIndex = 0;
            this.tabPage_Welder.Text = "焊工信息";
            this.tabPage_Welder.UseVisualStyleBackColor = true;
            // 
            // userControl_KindofEmployerWelder_DataGridView1
            // 
            this.userControl_KindofEmployerWelder_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_KindofEmployerWelder_DataGridView1.Location = new System.Drawing.Point(3, 3);
            this.userControl_KindofEmployerWelder_DataGridView1.Name = "userControl_KindofEmployerWelder_DataGridView1";
            this.userControl_KindofEmployerWelder_DataGridView1.Size = new System.Drawing.Size(350, 451);
            this.userControl_KindofEmployerWelder_DataGridView1.TabIndex = 0;
            // 
            // tabPage_SignUpExam
            // 
            this.tabPage_SignUpExam.Controls.Add(this.splitContainer2);
            this.tabPage_SignUpExam.Location = new System.Drawing.Point(4, 21);
            this.tabPage_SignUpExam.Name = "tabPage_SignUpExam";
            this.tabPage_SignUpExam.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SignUpExam.Size = new System.Drawing.Size(356, 457);
            this.tabPage_SignUpExam.TabIndex = 1;
            this.tabPage_SignUpExam.Text = "报考信息";
            this.tabPage_SignUpExam.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.userControl_KindofEmployerIssue_DataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.userControl_KindofEmployerStudent_DataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(350, 451);
            this.splitContainer2.SplitterDistance = 335;
            this.splitContainer2.TabIndex = 1;
            // 
            // userControl_KindofEmployerIssue_DataGridView1
            // 
            this.userControl_KindofEmployerIssue_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_KindofEmployerIssue_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_KindofEmployerIssue_DataGridView1.Name = "userControl_KindofEmployerIssue_DataGridView1";
            this.userControl_KindofEmployerIssue_DataGridView1.Size = new System.Drawing.Size(348, 333);
            this.userControl_KindofEmployerIssue_DataGridView1.TabIndex = 0;
            // 
            // userControl_KindofEmployerStudent_DataGridView1
            // 
            this.userControl_KindofEmployerStudent_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_KindofEmployerStudent_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_KindofEmployerStudent_DataGridView1.Name = "userControl_KindofEmployerStudent_DataGridView1";
            this.userControl_KindofEmployerStudent_DataGridView1.Size = new System.Drawing.Size(348, 110);
            this.userControl_KindofEmployerStudent_DataGridView1.TabIndex = 0;
            // 
            // tabPage_Exam
            // 
            this.tabPage_Exam.Controls.Add(this.userControl_KindofEmployerExam_DataGridView1);
            this.tabPage_Exam.Location = new System.Drawing.Point(4, 21);
            this.tabPage_Exam.Name = "tabPage_Exam";
            this.tabPage_Exam.Size = new System.Drawing.Size(356, 457);
            this.tabPage_Exam.TabIndex = 2;
            this.tabPage_Exam.Text = "考试记录";
            this.tabPage_Exam.UseVisualStyleBackColor = true;
            // 
            // userControl_KindofEmployerExam_DataGridView1
            // 
            this.userControl_KindofEmployerExam_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_KindofEmployerExam_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_KindofEmployerExam_DataGridView1.Name = "userControl_KindofEmployerExam_DataGridView1";
            this.userControl_KindofEmployerExam_DataGridView1.Size = new System.Drawing.Size(356, 457);
            this.userControl_KindofEmployerExam_DataGridView1.TabIndex = 0;
            // 
            // statusStrip_Parameter
            // 
            this.statusStrip_Parameter.AutoSize = false;
            this.statusStrip_Parameter.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip_Parameter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_KindofEmployer});
            this.statusStrip_Parameter.Location = new System.Drawing.Point(0, 0);
            this.statusStrip_Parameter.Name = "statusStrip_Parameter";
            this.statusStrip_Parameter.Size = new System.Drawing.Size(633, 22);
            this.statusStrip_Parameter.TabIndex = 0;
            // 
            // toolStripStatusLabel_KindofEmployer
            // 
            this.toolStripStatusLabel_KindofEmployer.AutoSize = false;
            this.toolStripStatusLabel_KindofEmployer.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_KindofEmployer.Name = "toolStripStatusLabel_KindofEmployer";
            this.toolStripStatusLabel_KindofEmployer.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel_KindofEmployer.Text = "报考单位：";
            this.toolStripStatusLabel_KindofEmployer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(633, 484);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(633, 531);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // UserControl_SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_SignUp";
            this.Size = new System.Drawing.Size(633, 531);
            this.Load += new System.EventHandler(this.UserControl_KindofEmployer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl_SignUp.ResumeLayout(false);
            this.tabPage_Welder.ResumeLayout(false);
            this.tabPage_SignUpExam.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabPage_Exam.ResumeLayout(false);
            this.statusStrip_Parameter.ResumeLayout(false);
            this.statusStrip_Parameter.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip_Parameter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_KindofEmployer;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private ZCWelder.UserControlSecond.UserControl_KindofEmployer_TreeView userControl_KindofEmployer_TreeView1;
        private System.Windows.Forms.TabControl tabControl_SignUp;
        private System.Windows.Forms.TabPage tabPage_Welder;
        private System.Windows.Forms.TabPage tabPage_SignUpExam;
        private System.Windows.Forms.TabPage tabPage_Exam;
        private ZCWelder.UserControlSecond.UserControl_KindofEmployerWelder_DataGridView userControl_KindofEmployerWelder_DataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ZCWelder.UserControlSecond.UserControl_KindofEmployerIssue_DataGridView userControl_KindofEmployerIssue_DataGridView1;
        private ZCWelder.UserControlSecond.UserControl_KindofEmployerStudent_DataGridView userControl_KindofEmployerStudent_DataGridView1;
        private ZCWelder.UserControlSecond.UserControl_KindofEmployerExam_DataGridView userControl_KindofEmployerExam_DataGridView1;
    }
}
