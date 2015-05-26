namespace ZCWelder.UserControlSecond
{
    partial class UserControl_WelderBelongIssueStudentQCRegistrationNo_DataGridView
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
            this.tabControl_WelderBelong_Auxiliary = new System.Windows.Forms.TabControl();
            this.tabPage_Exam = new System.Windows.Forms.TabPage();
            this.tabPage_WelderPicture = new System.Windows.Forms.TabPage();
            this.userControl_WelderPictureBase1 = new ZCWelder.UserControlThird.UserControl_WelderPictureBase();
            this.userControl_WelderExamBase1 = new ZCWelder.UserControlThird.UserControl_WelderExamBase();
            this.tabControl_WelderBelong_Auxiliary.SuspendLayout();
            this.tabPage_Exam.SuspendLayout();
            this.tabPage_WelderPicture.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_WelderBelong_Auxiliary
            // 
            this.tabControl_WelderBelong_Auxiliary.Controls.Add(this.tabPage_Exam);
            this.tabControl_WelderBelong_Auxiliary.Controls.Add(this.tabPage_WelderPicture);
            this.tabControl_WelderBelong_Auxiliary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_WelderBelong_Auxiliary.Location = new System.Drawing.Point(0, 0);
            this.tabControl_WelderBelong_Auxiliary.Name = "tabControl_WelderBelong_Auxiliary";
            this.tabControl_WelderBelong_Auxiliary.SelectedIndex = 0;
            this.tabControl_WelderBelong_Auxiliary.Size = new System.Drawing.Size(578, 437);
            this.tabControl_WelderBelong_Auxiliary.TabIndex = 7;
            this.tabControl_WelderBelong_Auxiliary.SelectedIndexChanged += new System.EventHandler(this.tabControl_WelderBelong_Auxiliary_SelectedIndexChanged);
            // 
            // tabPage_Exam
            // 
            this.tabPage_Exam.Controls.Add(this.userControl_WelderExamBase1);
            this.tabPage_Exam.Location = new System.Drawing.Point(4, 21);
            this.tabPage_Exam.Name = "tabPage_Exam";
            this.tabPage_Exam.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Exam.Size = new System.Drawing.Size(570, 412);
            this.tabPage_Exam.TabIndex = 0;
            this.tabPage_Exam.Text = "考试记录";
            this.tabPage_Exam.UseVisualStyleBackColor = true;
            // 
            // tabPage_WelderPicture
            // 
            this.tabPage_WelderPicture.Controls.Add(this.userControl_WelderPictureBase1);
            this.tabPage_WelderPicture.Location = new System.Drawing.Point(4, 21);
            this.tabPage_WelderPicture.Name = "tabPage_WelderPicture";
            this.tabPage_WelderPicture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_WelderPicture.Size = new System.Drawing.Size(570, 412);
            this.tabPage_WelderPicture.TabIndex = 1;
            this.tabPage_WelderPicture.Text = "焊工照片";
            this.tabPage_WelderPicture.UseVisualStyleBackColor = true;
            // 
            // userControl_WelderPictureBase1
            // 
            this.userControl_WelderPictureBase1.Location = new System.Drawing.Point(6, 6);
            this.userControl_WelderPictureBase1.Name = "userControl_WelderPictureBase1";
            this.userControl_WelderPictureBase1.Size = new System.Drawing.Size(197, 161);
            this.userControl_WelderPictureBase1.TabIndex = 0;
            // 
            // userControl_WelderExamBase1
            // 
            this.userControl_WelderExamBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WelderExamBase1.Location = new System.Drawing.Point(3, 3);
            this.userControl_WelderExamBase1.Name = "userControl_WelderExamBase1";
            this.userControl_WelderExamBase1.Size = new System.Drawing.Size(564, 406);
            this.userControl_WelderExamBase1.TabIndex = 0;
            // 
            // UserControl_WelderBelongIssueStudentQCRegistrationNo_DataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl_WelderBelong_Auxiliary);
            this.Name = "UserControl_WelderBelongIssueStudentQCRegistrationNo_DataGridView";
            this.Size = new System.Drawing.Size(578, 437);
            this.Load += new System.EventHandler(this.UserControl_IssueStudentQCRegistrationNoSecond_DataGridView_Load);
            this.tabControl_WelderBelong_Auxiliary.ResumeLayout(false);
            this.tabPage_Exam.ResumeLayout(false);
            this.tabPage_WelderPicture.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_WelderBelong_Auxiliary;
        private System.Windows.Forms.TabPage tabPage_Exam;
        private System.Windows.Forms.TabPage tabPage_WelderPicture;
        private ZCWelder.UserControlThird.UserControl_WelderPictureBase userControl_WelderPictureBase1;
        private ZCWelder.UserControlThird.UserControl_WelderExamBase userControl_WelderExamBase1;

    }
}
