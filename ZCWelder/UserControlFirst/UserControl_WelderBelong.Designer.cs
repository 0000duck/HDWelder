namespace ZCWelder.UserControlFirst
{
    partial class UserControl_WelderBelong
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
            this.userControl_Unit_TreeView1 = new ZCWelder.UserControlSecond.UserControl_Unit_TreeView();
            this.tabControl_WelderBelong = new System.Windows.Forms.TabControl();
            this.tabPage_WelderBelong = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.userControl_WelderBelong_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_WelderBelong_DataGridView();
            this.userControl_IssueStudentQCRegistrationNoSecond_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_WelderBelongIssueStudentQCRegistrationNo_DataGridView();
            this.tabPage_WelderBelongExam = new System.Windows.Forms.TabPage();
            this.userControl_WelderBelongExam_DataGridView1 = new ZCWelder.UserControlSecond.UserControl_WelderBelongExam_DataGridView();
            this.statusStrip_WelderBelong = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_EmployerGroup = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Employer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Department = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_WorkPlace = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl_WelderBelong.SuspendLayout();
            this.tabPage_WelderBelong.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage_WelderBelongExam.SuspendLayout();
            this.statusStrip_WelderBelong.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.userControl_Unit_TreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl_WelderBelong);
            this.splitContainer1.Size = new System.Drawing.Size(726, 463);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 0;
            // 
            // userControl_Unit_TreeView1
            // 
            this.userControl_Unit_TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_Unit_TreeView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_Unit_TreeView1.Name = "userControl_Unit_TreeView1";
            this.userControl_Unit_TreeView1.Size = new System.Drawing.Size(222, 461);
            this.userControl_Unit_TreeView1.TabIndex = 0;
            // 
            // tabControl_WelderBelong
            // 
            this.tabControl_WelderBelong.Controls.Add(this.tabPage_WelderBelong);
            this.tabControl_WelderBelong.Controls.Add(this.tabPage_WelderBelongExam);
            this.tabControl_WelderBelong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_WelderBelong.Location = new System.Drawing.Point(0, 0);
            this.tabControl_WelderBelong.Name = "tabControl_WelderBelong";
            this.tabControl_WelderBelong.SelectedIndex = 0;
            this.tabControl_WelderBelong.Size = new System.Drawing.Size(496, 461);
            this.tabControl_WelderBelong.TabIndex = 0;
            // 
            // tabPage_WelderBelong
            // 
            this.tabPage_WelderBelong.Controls.Add(this.splitContainer2);
            this.tabPage_WelderBelong.Location = new System.Drawing.Point(4, 21);
            this.tabPage_WelderBelong.Name = "tabPage_WelderBelong";
            this.tabPage_WelderBelong.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_WelderBelong.Size = new System.Drawing.Size(488, 436);
            this.tabPage_WelderBelong.TabIndex = 0;
            this.tabPage_WelderBelong.Text = "焊工信息";
            this.tabPage_WelderBelong.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.userControl_WelderBelong_DataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.userControl_IssueStudentQCRegistrationNoSecond_DataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(482, 430);
            this.splitContainer2.SplitterDistance = 215;
            this.splitContainer2.TabIndex = 1;
            // 
            // userControl_WelderBelong_DataGridView1
            // 
            this.userControl_WelderBelong_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WelderBelong_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_WelderBelong_DataGridView1.Name = "userControl_WelderBelong_DataGridView1";
            this.userControl_WelderBelong_DataGridView1.Size = new System.Drawing.Size(480, 213);
            this.userControl_WelderBelong_DataGridView1.TabIndex = 0;
            // 
            // userControl_IssueStudentQCRegistrationNoSecond_DataGridView1
            // 
            this.userControl_IssueStudentQCRegistrationNoSecond_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_IssueStudentQCRegistrationNoSecond_DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_IssueStudentQCRegistrationNoSecond_DataGridView1.Name = "userControl_IssueStudentQCRegistrationNoSecond_DataGridView1";
            this.userControl_IssueStudentQCRegistrationNoSecond_DataGridView1.Size = new System.Drawing.Size(480, 209);
            this.userControl_IssueStudentQCRegistrationNoSecond_DataGridView1.TabIndex = 0;
            // 
            // tabPage_WelderBelongExam
            // 
            this.tabPage_WelderBelongExam.Controls.Add(this.userControl_WelderBelongExam_DataGridView1);
            this.tabPage_WelderBelongExam.Location = new System.Drawing.Point(4, 21);
            this.tabPage_WelderBelongExam.Name = "tabPage_WelderBelongExam";
            this.tabPage_WelderBelongExam.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_WelderBelongExam.Size = new System.Drawing.Size(488, 436);
            this.tabPage_WelderBelongExam.TabIndex = 1;
            this.tabPage_WelderBelongExam.Text = "焊工持证信息";
            this.tabPage_WelderBelongExam.UseVisualStyleBackColor = true;
            // 
            // userControl_WelderBelongExam_DataGridView1
            // 
            this.userControl_WelderBelongExam_DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WelderBelongExam_DataGridView1.Location = new System.Drawing.Point(3, 3);
            this.userControl_WelderBelongExam_DataGridView1.Name = "userControl_WelderBelongExam_DataGridView1";
            this.userControl_WelderBelongExam_DataGridView1.Size = new System.Drawing.Size(422, 430);
            this.userControl_WelderBelongExam_DataGridView1.TabIndex = 0;
            // 
            // statusStrip_WelderBelong
            // 
            this.statusStrip_WelderBelong.AutoSize = false;
            this.statusStrip_WelderBelong.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip_WelderBelong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_EmployerGroup,
            this.toolStripStatusLabel_Employer,
            this.toolStripStatusLabel_Department,
            this.toolStripStatusLabel_WorkPlace});
            this.statusStrip_WelderBelong.Location = new System.Drawing.Point(0, 0);
            this.statusStrip_WelderBelong.Name = "statusStrip_WelderBelong";
            this.statusStrip_WelderBelong.Size = new System.Drawing.Size(726, 22);
            this.statusStrip_WelderBelong.TabIndex = 0;
            // 
            // toolStripStatusLabel_EmployerGroup
            // 
            this.toolStripStatusLabel_EmployerGroup.AutoSize = false;
            this.toolStripStatusLabel_EmployerGroup.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_EmployerGroup.Name = "toolStripStatusLabel_EmployerGroup";
            this.toolStripStatusLabel_EmployerGroup.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel_EmployerGroup.Text = "公司组：";
            this.toolStripStatusLabel_EmployerGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_Employer
            // 
            this.toolStripStatusLabel_Employer.AutoSize = false;
            this.toolStripStatusLabel_Employer.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Employer.Name = "toolStripStatusLabel_Employer";
            this.toolStripStatusLabel_Employer.Size = new System.Drawing.Size(300, 17);
            this.toolStripStatusLabel_Employer.Text = "公司：";
            this.toolStripStatusLabel_Employer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_Department
            // 
            this.toolStripStatusLabel_Department.AutoSize = false;
            this.toolStripStatusLabel_Department.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Department.Name = "toolStripStatusLabel_Department";
            this.toolStripStatusLabel_Department.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel_Department.Text = "部门：";
            this.toolStripStatusLabel_Department.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_WorkPlace
            // 
            this.toolStripStatusLabel_WorkPlace.AutoSize = false;
            this.toolStripStatusLabel_WorkPlace.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_WorkPlace.Name = "toolStripStatusLabel_WorkPlace";
            this.toolStripStatusLabel_WorkPlace.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel_WorkPlace.Text = "作业区：";
            this.toolStripStatusLabel_WorkPlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip_WelderBelong);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(726, 463);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(726, 510);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // UserControl_WelderBelong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_WelderBelong";
            this.Size = new System.Drawing.Size(726, 510);
            this.Load += new System.EventHandler(this.UserControl_WelderBelong_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl_WelderBelong.ResumeLayout(false);
            this.tabPage_WelderBelong.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabPage_WelderBelongExam.ResumeLayout(false);
            this.statusStrip_WelderBelong.ResumeLayout(false);
            this.statusStrip_WelderBelong.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip_WelderBelong;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_EmployerGroup;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Employer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Department;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_WorkPlace;
        private ZCWelder.UserControlSecond.UserControl_Unit_TreeView userControl_Unit_TreeView1;
        private System.Windows.Forms.TabControl tabControl_WelderBelong;
        private System.Windows.Forms.TabPage tabPage_WelderBelong;
        private System.Windows.Forms.TabPage tabPage_WelderBelongExam;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ZCWelder.UserControlSecond.UserControl_WelderBelong_DataGridView userControl_WelderBelong_DataGridView1;
        private ZCWelder.UserControlSecond.UserControl_WelderBelongExam_DataGridView userControl_WelderBelongExam_DataGridView1;
        private ZCWelder.UserControlSecond.UserControl_WelderBelongIssueStudentQCRegistrationNo_DataGridView userControl_IssueStudentQCRegistrationNoSecond_DataGridView1;
    }
}
