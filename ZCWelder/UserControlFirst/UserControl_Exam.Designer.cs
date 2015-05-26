namespace ZCWelder.UserControlFirst
{
    partial class UserControl_Exam
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
            this.toolStripStatusLabel_ShipClassification = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_IssueNo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ExaminingNo = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.userControl_ShipClassification_TreeView1 = new ZCWelder.UserControlSecond.UserControl_ShipClassification_TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.userControl_Issue_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_Issue_DataGridView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.tabControl_Student = new System.Windows.Forms.TabControl();
            this.tabPage_WelderStudentQC = new System.Windows.Forms.TabPage();
            this.userControl_WelderStudentQC_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_WelderStudentQC_DataGridView();
            this.tabPage_IssueProcess = new System.Windows.Forms.TabPage();
            this.userControl_IssueProcess_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_IssueProcess_DataGridView();
            this.userControl_SubjectPositionResult_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_SubjectPositionResult_DataGridView();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tabControl_Student.SuspendLayout();
            this.tabPage_WelderStudentQC.SuspendLayout();
            this.tabPage_IssueProcess.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(768, 567);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(768, 614);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_ShipClassification,
            this.toolStripStatusLabel_IssueNo,
            this.toolStripStatusLabel_ExaminingNo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(768, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // toolStripStatusLabel_ShipClassification
            // 
            this.toolStripStatusLabel_ShipClassification.AutoSize = false;
            this.toolStripStatusLabel_ShipClassification.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_ShipClassification.Name = "toolStripStatusLabel_ShipClassification";
            this.toolStripStatusLabel_ShipClassification.Size = new System.Drawing.Size(500, 17);
            this.toolStripStatusLabel_ShipClassification.Text = "船级社：";
            this.toolStripStatusLabel_ShipClassification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_IssueNo
            // 
            this.toolStripStatusLabel_IssueNo.AutoSize = false;
            this.toolStripStatusLabel_IssueNo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_IssueNo.Name = "toolStripStatusLabel_IssueNo";
            this.toolStripStatusLabel_IssueNo.Size = new System.Drawing.Size(150, 17);
            this.toolStripStatusLabel_IssueNo.Text = "班级编号：";
            this.toolStripStatusLabel_IssueNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_ExaminingNo
            // 
            this.toolStripStatusLabel_ExaminingNo.AutoSize = false;
            this.toolStripStatusLabel_ExaminingNo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_ExaminingNo.Name = "toolStripStatusLabel_ExaminingNo";
            this.toolStripStatusLabel_ExaminingNo.Size = new System.Drawing.Size(150, 17);
            this.toolStripStatusLabel_ExaminingNo.Text = "钢印号:";
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
            this.splitContainer1.Panel1.Controls.Add(this.userControl_ShipClassification_TreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(768, 567);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 0;
            // 
            // userControl_ShipClassification_TreeView1
            // 
            this.userControl_ShipClassification_TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_ShipClassification_TreeView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_ShipClassification_TreeView1.Name = "userControl_ShipClassification_TreeView1";
            this.userControl_ShipClassification_TreeView1.Size = new System.Drawing.Size(218, 565);
            this.userControl_ShipClassification_TreeView1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.userControl_Issue_DataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(544, 567);
            this.splitContainer2.SplitterDistance = 255;
            this.splitContainer2.TabIndex = 0;
            // 
            // userControl_Issue_DataGridView1
            // 
            this.userControl_Issue_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_Issue_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_Issue_DataGridView1.Name = "userControl_Issue_DataGridView1";
            this.userControl_Issue_DataGridView1.Size = new System.Drawing.Size(542, 253);
            this.userControl_Issue_DataGridView1.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.tabControl_Student);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.userControl_SubjectPositionResult_DataGridView1);
            this.splitContainer4.Size = new System.Drawing.Size(544, 308);
            this.splitContainer4.SplitterDistance = 84;
            this.splitContainer4.TabIndex = 0;
            // 
            // tabControl_Student
            // 
            this.tabControl_Student.Controls.Add(this.tabPage_WelderStudentQC);
            this.tabControl_Student.Controls.Add(this.tabPage_IssueProcess);
            this.tabControl_Student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Student.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Student.Name = "tabControl_Student";
            this.tabControl_Student.SelectedIndex = 0;
            this.tabControl_Student.Size = new System.Drawing.Size(542, 82);
            this.tabControl_Student.TabIndex = 1;
            // 
            // tabPage_WelderStudentQC
            // 
            this.tabPage_WelderStudentQC.Controls.Add(this.userControl_WelderStudentQC_DataGridView1);
            this.tabPage_WelderStudentQC.Location = new System.Drawing.Point(4, 21);
            this.tabPage_WelderStudentQC.Name = "tabPage_WelderStudentQC";
            this.tabPage_WelderStudentQC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_WelderStudentQC.Size = new System.Drawing.Size(534, 57);
            this.tabPage_WelderStudentQC.TabIndex = 0;
            this.tabPage_WelderStudentQC.Text = "学员";
            this.tabPage_WelderStudentQC.UseVisualStyleBackColor = true;
            // 
            // userControl_WelderStudentQC_DataGridView1
            // 
            this.userControl_WelderStudentQC_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WelderStudentQC_DataGridView1.Location = new System.Drawing.Point(3, 3);
            this.userControl_WelderStudentQC_DataGridView1.Name = "userControl_WelderStudentQC_DataGridView1";
            this.userControl_WelderStudentQC_DataGridView1.Size = new System.Drawing.Size(528, 51);
            this.userControl_WelderStudentQC_DataGridView1.TabIndex = 0;
            // 
            // tabPage_IssueProcess
            // 
            this.tabPage_IssueProcess.Controls.Add(this.userControl_IssueProcess_DataGridView1);
            this.tabPage_IssueProcess.Location = new System.Drawing.Point(4, 21);
            this.tabPage_IssueProcess.Name = "tabPage_IssueProcess";
            this.tabPage_IssueProcess.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_IssueProcess.Size = new System.Drawing.Size(482, 57);
            this.tabPage_IssueProcess.TabIndex = 1;
            this.tabPage_IssueProcess.Text = "班级进程";
            this.tabPage_IssueProcess.UseVisualStyleBackColor = true;
            // 
            // userControl_IssueProcess_DataGridView1
            // 
            this.userControl_IssueProcess_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_IssueProcess_DataGridView1.Location = new System.Drawing.Point(3, 3);
            this.userControl_IssueProcess_DataGridView1.Name = "userControl_IssueProcess_DataGridView1";
            this.userControl_IssueProcess_DataGridView1.Size = new System.Drawing.Size(476, 51);
            this.userControl_IssueProcess_DataGridView1.TabIndex = 0;
            // 
            // userControl_SubjectPositionResult_DataGridView1
            // 
            this.userControl_SubjectPositionResult_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_SubjectPositionResult_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_SubjectPositionResult_DataGridView1.Name = "userControl_SubjectPositionResult_DataGridView1";
            this.userControl_SubjectPositionResult_DataGridView1.Size = new System.Drawing.Size(542, 218);
            this.userControl_SubjectPositionResult_DataGridView1.TabIndex = 0;
            // 
            // UserControl_Exam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_Exam";
            this.Size = new System.Drawing.Size(768, 614);
            this.Load += new System.EventHandler(this.UserControl_Exam_Load);
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
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.tabControl_Student.ResumeLayout(false);
            this.tabPage_WelderStudentQC.ResumeLayout(false);
            this.tabPage_IssueProcess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ZCWelder.UserControlSecond.UserControl_Issue_DataGridView userControl_Issue_DataGridView1;
        private ZCWelder.UserControlSecond.UserControl_ShipClassification_TreeView userControl_ShipClassification_TreeView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ShipClassification;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_IssueNo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ExaminingNo;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private ZCWelder.UserControlSecond.UserControl_WelderStudentQC_DataGridView userControl_WelderStudentQC_DataGridView1;
        private ZCWelder.UserControlSecond.UserControl_SubjectPositionResult_DataGridView userControl_SubjectPositionResult_DataGridView1;
        private System.Windows.Forms.TabControl tabControl_Student;
        private System.Windows.Forms.TabPage tabPage_WelderStudentQC;
        private System.Windows.Forms.TabPage tabPage_IssueProcess;
        private ZCWelder.UserControlSecond.UserControl_IssueProcess_DataGridView userControl_IssueProcess_DataGridView1;
    }
}
