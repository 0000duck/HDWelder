namespace ZCWelder
{
    partial class Form_Main
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Welder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Exam = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_WelderBelong = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_KindofEmployer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_DataManager = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Parameter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_WeldingSubject = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_UsersAndRoles = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_WPS = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ReviveQC = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_System = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_WelderPicture = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel_target = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ExportPaper = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SystemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataBaseSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_DataConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_myAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AccountModifyPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AccountLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Welder,
            this.toolStripButton_Exam,
            this.toolStripButton_WelderBelong,
            this.toolStripButton_KindofEmployer,
            this.toolStripButton_DataManager,
            this.toolStripButton_Parameter,
            this.toolStripButton_WeldingSubject,
            this.toolStripButton_UsersAndRoles,
            this.toolStripButton_WPS,
            this.toolStripButton_ReviveQC,
            this.toolStripButton_System,
            this.toolStripButton_WelderPicture});
            this.toolStrip1.Location = new System.Drawing.Point(3, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(747, 49);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripButton_Welder
            // 
            this.toolStripButton_Welder.Image = global::ZCWelder.Properties.Resources.焊工信息管理;
            this.toolStripButton_Welder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Welder.Name = "toolStripButton_Welder";
            this.toolStripButton_Welder.Size = new System.Drawing.Size(108, 46);
            this.toolStripButton_Welder.Text = "焊工信息查询";
            this.toolStripButton_Welder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_Welder.Click += new System.EventHandler(this.toolStripButton_Welder_Click);
            // 
            // toolStripButton_Exam
            // 
            this.toolStripButton_Exam.Image = global::ZCWelder.Properties.Resources.班级管理;
            this.toolStripButton_Exam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Exam.Name = "toolStripButton_Exam";
            this.toolStripButton_Exam.Size = new System.Drawing.Size(108, 46);
            this.toolStripButton_Exam.Text = "焊工考试管理";
            this.toolStripButton_Exam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_Exam.Click += new System.EventHandler(this.toolStripButton_Issue_Click);
            // 
            // toolStripButton_WelderBelong
            // 
            this.toolStripButton_WelderBelong.Image = global::ZCWelder.Properties.Resources.焊工人力资源管理;
            this.toolStripButton_WelderBelong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_WelderBelong.Name = "toolStripButton_WelderBelong";
            this.toolStripButton_WelderBelong.Size = new System.Drawing.Size(108, 46);
            this.toolStripButton_WelderBelong.Text = "在册焊工管理";
            this.toolStripButton_WelderBelong.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButton_WelderBelong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_WelderBelong.Click += new System.EventHandler(this.toolStripButton_WelderBelong_Click);
            // 
            // toolStripButton_KindofEmployer
            // 
            this.toolStripButton_KindofEmployer.Image = global::ZCWelder.Properties.Resources.报考申请;
            this.toolStripButton_KindofEmployer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_KindofEmployer.Name = "toolStripButton_KindofEmployer";
            this.toolStripButton_KindofEmployer.Size = new System.Drawing.Size(108, 46);
            this.toolStripButton_KindofEmployer.Text = "报考单位管理";
            this.toolStripButton_KindofEmployer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_KindofEmployer.Click += new System.EventHandler(this.toolStripButton_KindofEmployer_Click);
            // 
            // toolStripButton_DataManager
            // 
            this.toolStripButton_DataManager.Image = global::ZCWelder.Properties.Resources.班级查询2;
            this.toolStripButton_DataManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DataManager.Name = "toolStripButton_DataManager";
            this.toolStripButton_DataManager.Size = new System.Drawing.Size(108, 46);
            this.toolStripButton_DataManager.Text = "分类数据管理";
            this.toolStripButton_DataManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_DataManager.Click += new System.EventHandler(this.toolStripButton_DataManager_Click);
            // 
            // toolStripButton_Parameter
            // 
            this.toolStripButton_Parameter.Image = global::ZCWelder.Properties.Resources.参数设置;
            this.toolStripButton_Parameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Parameter.Name = "toolStripButton_Parameter";
            this.toolStripButton_Parameter.Size = new System.Drawing.Size(76, 46);
            this.toolStripButton_Parameter.Text = "参数管理";
            this.toolStripButton_Parameter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_Parameter.Click += new System.EventHandler(this.toolStripButton_Parameter_Click);
            // 
            // toolStripButton_WeldingSubject
            // 
            this.toolStripButton_WeldingSubject.Image = global::ZCWelder.Properties.Resources.系统设置;
            this.toolStripButton_WeldingSubject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_WeldingSubject.Name = "toolStripButton_WeldingSubject";
            this.toolStripButton_WeldingSubject.Size = new System.Drawing.Size(108, 46);
            this.toolStripButton_WeldingSubject.Text = "考试科目管理";
            this.toolStripButton_WeldingSubject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_WeldingSubject.Click += new System.EventHandler(this.toolStripButton_WeldingSubject_Click);
            // 
            // toolStripButton_UsersAndRoles
            // 
            this.toolStripButton_UsersAndRoles.Image = global::ZCWelder.Properties.Resources.分类数据管理;
            this.toolStripButton_UsersAndRoles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_UsersAndRoles.Name = "toolStripButton_UsersAndRoles";
            this.toolStripButton_UsersAndRoles.Size = new System.Drawing.Size(76, 46);
            this.toolStripButton_UsersAndRoles.Text = "权限管理";
            this.toolStripButton_UsersAndRoles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_UsersAndRoles.Click += new System.EventHandler(this.toolStripButton_UsersAndRoles_Click);
            // 
            // toolStripButton_WPS
            // 
            this.toolStripButton_WPS.Image = global::ZCWelder.Properties.Resources.WPS;
            this.toolStripButton_WPS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_WPS.Name = "toolStripButton_WPS";
            this.toolStripButton_WPS.Size = new System.Drawing.Size(76, 46);
            this.toolStripButton_WPS.Text = "WPS管理";
            this.toolStripButton_WPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_WPS.Click += new System.EventHandler(this.toolStripButton_WPS_Click);
            // 
            // toolStripButton_ReviveQC
            // 
            this.toolStripButton_ReviveQC.Image = global::ZCWelder.Properties.Resources.焊接参数设置;
            this.toolStripButton_ReviveQC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ReviveQC.Name = "toolStripButton_ReviveQC";
            this.toolStripButton_ReviveQC.Size = new System.Drawing.Size(108, 46);
            this.toolStripButton_ReviveQC.Text = "激活证书管理";
            this.toolStripButton_ReviveQC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_ReviveQC.Click += new System.EventHandler(this.toolStripButton_ReviveQC_Click);
            // 
            // toolStripButton_System
            // 
            this.toolStripButton_System.Image = global::ZCWelder.Properties.Resources.考试科目设置;
            this.toolStripButton_System.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_System.Name = "toolStripButton_System";
            this.toolStripButton_System.Size = new System.Drawing.Size(76, 46);
            this.toolStripButton_System.Text = "系统管理";
            this.toolStripButton_System.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_System.Click += new System.EventHandler(this.toolStripButton_System_Click);
            // 
            // toolStripButton_WelderPicture
            // 
            this.toolStripButton_WelderPicture.Image = global::ZCWelder.Properties.Resources.导入外部数据;
            this.toolStripButton_WelderPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_WelderPicture.Name = "toolStripButton_WelderPicture";
            this.toolStripButton_WelderPicture.Size = new System.Drawing.Size(108, 46);
            this.toolStripButton_WelderPicture.Text = "焊工照片管理";
            this.toolStripButton_WelderPicture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_WelderPicture.Click += new System.EventHandler(this.toolStripButton_ProgrammeUpdate_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel_target);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(750, 478);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(750, 551);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // panel_target
            // 
            this.panel_target.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_target.Location = new System.Drawing.Point(0, 0);
            this.panel_target.Name = "panel_target";
            this.panel_target.Size = new System.Drawing.Size(750, 478);
            this.panel_target.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File,
            this.toolStripMenuItem_Setting,
            this.toolStripMenuItem_myAccount,
            this.toolStripMenuItem_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(750, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ExportPaper});
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItem_File.Text = "文件(&F)";
            // 
            // toolStripMenuItem_ExportPaper
            // 
            this.toolStripMenuItem_ExportPaper.Name = "toolStripMenuItem_ExportPaper";
            this.toolStripMenuItem_ExportPaper.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_ExportPaper.Text = "导出试卷";
            this.toolStripMenuItem_ExportPaper.Click += new System.EventHandler(this.toolStripMenuItem_ExportPaper_Click);
            // 
            // toolStripMenuItem_Setting
            // 
            this.toolStripMenuItem_Setting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_SystemSetting,
            this.toolStripMenuItem_DataBaseSetting,
            this.ToolStripMenuItem_DataConvert});
            this.toolStripMenuItem_Setting.Name = "toolStripMenuItem_Setting";
            this.toolStripMenuItem_Setting.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItem_Setting.Text = "工具(&T)";
            // 
            // toolStripMenuItem_SystemSetting
            // 
            this.toolStripMenuItem_SystemSetting.Name = "toolStripMenuItem_SystemSetting";
            this.toolStripMenuItem_SystemSetting.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem_SystemSetting.Text = "设置";
            this.toolStripMenuItem_SystemSetting.Click += new System.EventHandler(this.toolStripMenuItem_SystemSetting_Click);
            // 
            // toolStripMenuItem_DataBaseSetting
            // 
            this.toolStripMenuItem_DataBaseSetting.Name = "toolStripMenuItem_DataBaseSetting";
            this.toolStripMenuItem_DataBaseSetting.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem_DataBaseSetting.Text = "数据库连接设置";
            this.toolStripMenuItem_DataBaseSetting.Click += new System.EventHandler(this.toolStripMenuItem_DataBaseSetting_Click);
            // 
            // ToolStripMenuItem_DataConvert
            // 
            this.ToolStripMenuItem_DataConvert.Name = "ToolStripMenuItem_DataConvert";
            this.ToolStripMenuItem_DataConvert.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItem_DataConvert.Text = "数据校验工具集";
            this.ToolStripMenuItem_DataConvert.Click += new System.EventHandler(this.ToolStripMenuItem_DataConvert_Click);
            // 
            // toolStripMenuItem_myAccount
            // 
            this.toolStripMenuItem_myAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_AccountModifyPassword,
            this.toolStripMenuItem_AccountLogout});
            this.toolStripMenuItem_myAccount.Name = "toolStripMenuItem_myAccount";
            this.toolStripMenuItem_myAccount.Size = new System.Drawing.Size(83, 20);
            this.toolStripMenuItem_myAccount.Text = "我的帐号(&A)";
            // 
            // toolStripMenuItem_AccountModifyPassword
            // 
            this.toolStripMenuItem_AccountModifyPassword.Name = "toolStripMenuItem_AccountModifyPassword";
            this.toolStripMenuItem_AccountModifyPassword.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_AccountModifyPassword.Text = "修改密码";
            this.toolStripMenuItem_AccountModifyPassword.Click += new System.EventHandler(this.toolStripMenuItem_AccountModifyPassword_Click);
            // 
            // toolStripMenuItem_AccountLogout
            // 
            this.toolStripMenuItem_AccountLogout.Name = "toolStripMenuItem_AccountLogout";
            this.toolStripMenuItem_AccountLogout.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_AccountLogout.Text = "注销";
            this.toolStripMenuItem_AccountLogout.Click += new System.EventHandler(this.toolStripMenuItem_AccountLogout_Click);
            // 
            // toolStripMenuItem_Help
            // 
            this.toolStripMenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_About});
            this.toolStripMenuItem_Help.Name = "toolStripMenuItem_Help";
            this.toolStripMenuItem_Help.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItem_Help.Text = "帮助(&H)";
            // 
            // toolStripMenuItem_About
            // 
            this.toolStripMenuItem_About.Name = "toolStripMenuItem_About";
            this.toolStripMenuItem_About.Size = new System.Drawing.Size(214, 22);
            this.toolStripMenuItem_About.Text = "关于 焊工信息管理软件(&A)";
            this.toolStripMenuItem_About.Click += new System.EventHandler(this.toolStripMenuItem_About_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 551);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Exam;
        private System.Windows.Forms.ToolStripButton toolStripButton_WelderBelong;
        private System.Windows.Forms.ToolStripButton toolStripButton_UsersAndRoles;
        private System.Windows.Forms.ToolStripButton toolStripButton_WPS;
        private System.Windows.Forms.ToolStripButton toolStripButton_System;
        private System.Windows.Forms.ToolStripButton toolStripButton_WelderPicture;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Panel panel_target;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Setting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SystemSetting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataBaseSetting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_myAccount;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AccountModifyPassword;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AccountLogout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_About;
        private System.Windows.Forms.ToolStripButton toolStripButton_Parameter;
        private System.Windows.Forms.ToolStripButton toolStripButton_ReviveQC;
        private System.Windows.Forms.ToolStripButton toolStripButton_Welder;
        private System.Windows.Forms.ToolStripButton toolStripButton_DataManager;
        private System.Windows.Forms.ToolStripButton toolStripButton_WeldingSubject;
        private System.Windows.Forms.ToolStripButton toolStripButton_KindofEmployer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DataConvert;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ExportPaper;
    }
}

