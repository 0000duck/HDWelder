using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.AspNet;
using ZCCL.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.ProcessStatus;
using ZCCL.Report;
using ZCCL.UpdateLog;
using ZCWelder.UserControlFirst;
using ZCCL.Tools;
using IWshRuntimeLibrary;
using ZCWelder.UserControlSecond;
using ZCCL;

namespace ZCWelder
{
    public partial class Form_Main : Form
    {       
        #region "Fields"

        UserControl_Users myUserControl_Users;
        internal UserControl_Users myUserControl_UsersPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_Users == null)
                //正在创建对象
                {
                    this.myUserControl_Users = new UserControl_Users();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_Users);
                    this.myUserControl_Users.Dock = DockStyle.Fill;
                }

                return this.myUserControl_Users;
            }
        }

        UserControl_SignUp myUserControl_KindofEmployer;
        internal UserControl_SignUp myUserControl_KindofEmployerPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_KindofEmployer == null)
                //正在创建对象
                {
                    this.myUserControl_KindofEmployer = new UserControl_SignUp();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_KindofEmployer);
                    this.myUserControl_KindofEmployer.Dock = DockStyle.Fill;
                }

                return this.myUserControl_KindofEmployer;
            }
        }

        UserControl_WelderBelong myUserControl_WelderBelong;
        internal UserControl_WelderBelong myUserControl_WelderBelongPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_WelderBelong == null)
                //正在创建对象
                {
                    this.myUserControl_WelderBelong = new UserControl_WelderBelong();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_WelderBelong);
                    this.myUserControl_WelderBelong.Dock = DockStyle.Fill;
                }

                return this.myUserControl_WelderBelong;
            }
        }

        UserControl_WelderPicture_View myUserControl_WelderPicture_View;
        internal UserControl_WelderPicture_View myUserControl_WelderPicture_ViewPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_WelderPicture_View == null)
                //正在创建对象
                {
                    this.myUserControl_WelderPicture_View = new UserControl_WelderPicture_View();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_WelderPicture_View);
                    this.myUserControl_WelderPicture_View.Dock = DockStyle.Fill;
                }

                return this.myUserControl_WelderPicture_View;
            }
        }

        UserControl_WeldingSubject myUserControl_WeldingSubject;
        internal UserControl_WeldingSubject myUserControl_WeldingSubjectPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_WeldingSubject == null)
                //正在创建对象
                {
                    this.myUserControl_WeldingSubject = new UserControl_WeldingSubject();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_WeldingSubject);
                    this.myUserControl_WeldingSubject.Dock = DockStyle.Fill;
                }

                return this.myUserControl_WeldingSubject;
            }
        }

        UserControl_ProcessApplication myUserControl_ProcessApplication;
        internal UserControl_ProcessApplication myUserControl_ProcessApplicationPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_ProcessApplication == null)
                //正在创建对象
                {
                    this.myUserControl_ProcessApplication = new UserControl_ProcessApplication();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_ProcessApplication);
                    this.myUserControl_ProcessApplication.Dock = DockStyle.Fill;
                }

                return this.myUserControl_ProcessApplication;
            }
        }

        UserControl_WPS myUserControl_WPS;
        internal UserControl_WPS myUserControl_WPSPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_WPS == null)
                //正在创建对象
                {
                    this.myUserControl_WPS = new UserControl_WPS();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_WPS);
                    this.myUserControl_WPS.Dock = DockStyle.Fill;
                }

                return this.myUserControl_WPS;
            }
        }

        UserControl_ReviveQC myUserControl_ReviveQC;
        internal UserControl_ReviveQC myUserControl_ReviveQCPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_ReviveQC == null)
                //正在创建对象
                {
                    this.myUserControl_ReviveQC = new UserControl_ReviveQC();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_ReviveQC);
                    this.myUserControl_ReviveQC.Dock = DockStyle.Fill;
                }

                return this.myUserControl_ReviveQC;
            }
        }

        UserControl_ProgrammeUpdate myUserControl_ProgrammeUpdate;
        internal UserControl_ProgrammeUpdate myUserControl_ProgrammeUpdatePart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_ProgrammeUpdate == null)
                //正在创建对象
                {
                    this.myUserControl_ProgrammeUpdate = new UserControl_ProgrammeUpdate();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_ProgrammeUpdate);
                    this.myUserControl_ProgrammeUpdate.Dock = DockStyle.Fill;
                }

                return this.myUserControl_ProgrammeUpdate;
            }
        }

        UserControl_UpdateLog myUserControl_UpdateLog;
        internal UserControl_UpdateLog myUserControl_UpdateLogPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_UpdateLog == null)
                //正在创建对象
                {
                    this.myUserControl_UpdateLog = new UserControl_UpdateLog();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_UpdateLog);
                    this.myUserControl_UpdateLog.Dock = DockStyle.Fill;
                }

                return this.myUserControl_UpdateLog;
            }
        }
                 
        UserControl_System myUserControl_System;
        internal UserControl_System myUserControl_SystemPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_System == null)
                //正在创建对象
                {
                    this.myUserControl_System = new UserControl_System();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_System);
                    this.myUserControl_System.Dock = DockStyle.Fill;
                }

                return this.myUserControl_System;
            }
        }

        UserControl_Parameter myUserControl_Parameter;
        internal UserControl_Parameter myUserControl_ParameterPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_Parameter == null)
                //正在创建对象
                {
                    this.myUserControl_Parameter = new UserControl_Parameter();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_Parameter);
                    this.myUserControl_Parameter.Dock = DockStyle.Fill;
                }

                return this.myUserControl_Parameter;
            }
        }

        UserControl_Exam myUserControl_Exam;
        internal UserControl_Exam myUserControl_ExamPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_Exam == null)
                //正在创建对象
                {
                    this.myUserControl_Exam = new UserControl_Exam();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_Exam);
                    this.myUserControl_Exam.Dock = DockStyle.Fill;
                }

                return this.myUserControl_Exam;
            }
        }

        UserControl_Welder myUserControl_Welder;
        internal UserControl_Welder myUserControl_WelderPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_Welder == null)
                //正在创建对象
                {
                    this.myUserControl_Welder = new UserControl_Welder();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_Welder);
                    this.myUserControl_Welder.Dock = DockStyle.Fill;
                }

                return this.myUserControl_Welder;
            }
        }

        UserControl_DataManager myUserControl_DataManager;
        internal UserControl_DataManager myUserControl_DataManagerPart
        {
            get
            {
                //如果变量为空，使用一个新的对象实例初始化该变量
                if (this.myUserControl_DataManager == null)
                //正在创建对象
                {
                    this.myUserControl_DataManager = new UserControl_DataManager();

                    //将此控件布置在宿主用户控件上，并停靠填充它。
                    this.panel_target.Controls.Add(this.myUserControl_DataManager);
                    this.myUserControl_DataManager.Dock = DockStyle.Fill;
                }

                return this.myUserControl_DataManager;
            }
        }

        #endregion

        #region "ShowUserControl"
        internal void SetUserControlInvisible()
        {
            this.toolStripButton_Welder.BackColor = Control.DefaultBackColor;
            this.toolStripButton_Exam.BackColor = Control.DefaultBackColor;
            this.toolStripButton_WelderBelong.BackColor = Control.DefaultBackColor;
            this.toolStripButton_KindofEmployer.BackColor = Control.DefaultBackColor;
            this.toolStripButton_DataManager.BackColor = Control.DefaultBackColor;
            this.toolStripButton_Parameter.BackColor = Control.DefaultBackColor;
            this.toolStripButton_WeldingSubject.BackColor = Control.DefaultBackColor;
            this.toolStripButton_UsersAndRoles.BackColor = Control.DefaultBackColor;
            this.toolStripButton_WPS.BackColor = Control.DefaultBackColor;
            this.toolStripButton_ReviveQC.BackColor = Control.DefaultBackColor;
            this.toolStripButton_System.BackColor = Control.DefaultBackColor;
            this.toolStripButton_WelderPicture.BackColor = Control.DefaultBackColor;

            this.myUserControl_WelderPart .Visible = false ;
            this.myUserControl_ExamPart .Visible = false ;
            this.myUserControl_WelderBelongPart.Visible = false;
            this.myUserControl_KindofEmployerPart.Visible = false;
            this.myUserControl_DataManagerPart .Visible = false ;
            this.myUserControl_ParameterPart .Visible = false ;
            this.myUserControl_WeldingSubjectPart.Visible = false;
            this.myUserControl_UsersPart.Visible = false;
            this.myUserControl_WPSPart.Visible = false;
            this.myUserControl_ReviveQCPart.Visible = false;
            this.myUserControl_SystemPart.Visible = false ;
            this.myUserControl_WelderPicture_ViewPart.Visible = false;

            this.myUserControl_ProcessApplicationPart.Visible = false;

        }

        internal void ShowmyUserControl_ParameterPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_Parameter.BackColor = Color.LightSteelBlue;
            
            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_Parameter.Visible = true;
            }
            else
            {
                this.toolStripButton_Parameter.Visible = false;
            }
        }

        internal void ShowmyUserControl_ExamPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_Exam.BackColor = Color.LightSteelBlue;

            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Read) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_Exam.Visible = true;
            }
            else
            {
                this.toolStripButton_Exam.Visible = false;
            }
        }
        
        internal void ShowmyUserControl_WelderPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_Welder.BackColor = Color.LightSteelBlue;

            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_Welder.Visible = true;
            }
            else
            {
                this.toolStripButton_Welder.Visible = false;
            }
            this.AcceptButton = this.myUserControl_Welder.userControl_WelderQuery1.button_OnOK;
            this.myUserControl_Welder.userControl_WelderQuery1.TextBox_WelderNameQuery.Select();
        }
        
        internal void ShowmyUserControl_DataManagerPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_DataManager.BackColor = Color.LightSteelBlue;
            
            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_DataManager.Visible = true;
            }
            else
            {
                this.toolStripButton_DataManager.Visible = false;
            }
        }

        internal void ShowmyUserControl_UsersPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_UsersAndRoles.BackColor = Color.LightSteelBlue;
            
            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("用户权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_UsersPart.Visible = true;
            }
            else
            {
                this.toolStripButton_UsersAndRoles.Visible = false;
            }

        }

        internal void ShowmyUserControl_KindofEmployerPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_KindofEmployer.BackColor = Color.LightSteelBlue;

            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_KindofEmployerPart.Visible = true;
            }
            else
            {
                this.toolStripButton_KindofEmployer.Visible = false;
            }

        }

        internal void ShowmyUserControl_WelderBelongPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_WelderBelong.BackColor = Color.LightSteelBlue;
            
            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_WelderBelongPart.Visible = true;
            }
            else
            {
                this.toolStripButton_WelderBelong.Visible = false;
            }

        }

        internal void ShowmyUserControl_WelderPicture_ViewPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_WelderPicture.BackColor = Color.LightSteelBlue;
            
            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_WelderPicture_ViewPart.Visible = true;
            }
            else
            {
                this.toolStripButton_WelderPicture.Visible = false;
            }

        }

        internal void ShowmyUserControl_WeldingSubjectPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_WeldingSubject.BackColor = Color.LightSteelBlue;
            
            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("用户权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_WeldingSubjectPart.Visible = true;
            }
            else
            {
                this.toolStripButton_WeldingSubject .Visible = false;
            }

        }

        internal void ShowmyUserControl_ProcessApplicationPart()
        {
            SetUserControlInvisible();
            
            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_ProcessApplicationPart.Visible = true;
            }
            else
            {
                this.myUserControl_ProcessApplicationPart.Visible = false;
            }
        }

        internal void ShowmyUserControl_WPSPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_WPS.BackColor = Color.LightSteelBlue;
            
            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_WPSPart.Visible = true;
            }
            else
            {
                this.toolStripButton_WPS.Visible = false;
            }

        }

        internal void ShowmyUserControl_SystemPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_System.BackColor = Color.LightSteelBlue;
            
            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_SystemPart.Visible = true;
            }
            else
            {
                this.toolStripButton_System.Visible = false;
            }

        }

        internal void ShowmyUserControl_ReviveQCPart()
        {
            SetUserControlInvisible();
            this.toolStripButton_ReviveQC .BackColor = Color.LightSteelBlue;
            
            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read))
            {
                this.myUserControl_ReviveQCPart.Visible = true;
            }
            else
            {
                this.toolStripButton_ReviveQC.Visible = false;
            }

        }
        #endregion

        public Form_Main()
        {
            InitializeComponent();
        }

        public void CreateDesktopLnk()
        {
            string str_FileName=System.Reflection.Assembly.GetExecutingAssembly().FullName.Split(',')[0];
            string  DesktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            WshShell shell  = new IWshRuntimeLibrary.WshShellClass();
            IWshShortcut shortcut  =(IWshShortcut) shell.CreateShortcut(DesktopPath + "\\" + str_FileName + ".lnk");
            shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            shortcut.Arguments = "";
            //shortcut.Description = My.Application.Info.Description;
            shortcut.WorkingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //shortcut.IconLocation = @"D:\software\cmpc\zy.exe,0";
            //shortcut.Hotkey = "CTRL+SHIFT+Z";
            shortcut.WindowStyle = 1;
            shortcut.Save();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            if (Class_zwjPublic.myBackColor!= Color.Empty)
            {
                this.BackColor = Class_zwjPublic.myBackColor;
            }
            this.Text = string.Format("{0} - {2}（{1}）", System.Reflection.Assembly.GetExecutingAssembly().FullName.Split(',')[0], Class_zwjPublic.myClass_CustomUser.UserName, Class_zwjPublic.myClass_CustomUser.Name);

            this.toolStripButton_UsersAndRoles.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("用户权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripButton_WPS.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripButton_ReviveQC.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripButton_System.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripButton_Parameter.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripButton_WeldingSubject .Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripButton_Exam.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Read) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripButton_DataManager.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripButton_WelderBelong.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripButton_WelderPicture.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read);

            this.toolStripButton_Welder.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripButton_KindofEmployer.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripMenuItem_File.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read);
            this.toolStripMenuItem_Setting.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read);

            this.ShowmyUserControl_WelderPart ();

        }

        private void toolStripMenuItem_SystemSetting_Click(object sender, EventArgs e)
        {
            Setting.Form_Setting myForm_Setting = new Setting.Form_Setting();
            myForm_Setting.ShowDialog();

        }

        private void toolStripMenuItem_DataBaseSetting_Click(object sender, EventArgs e)
        {
            Form_ConnectionUpdate myForm = new Form_ConnectionUpdate();
            myForm.str_AppRole = Properties.Settings.Default.AppRole;
            myForm.str_AppRolePassword = Properties.Settings.Default.AppRolePassword;
            DialogResult myDialogResult = myForm.ShowDialog();
            if (myDialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.AppRole = myForm.str_AppRole;
                Properties.Settings.Default.AppRolePassword = myForm.str_AppRolePassword;
                Properties.Settings.Default.Save();
                MessageBox.Show("程序将重新启动！");
                Application.Restart();
                return;
            }
            else if (myDialogResult == DialogResult.Cancel)
            {
            }
            else
            {
                MessageBox.Show("数据连接错误！");
                this.Close();
                return;
            }

        }

        private void toolStripMenuItem_AccountModifyPassword_Click(object sender, EventArgs e)
        {
            Form_UserPasswordModify myForm = new Form_UserPasswordModify();
            myForm.myClass_CustomUser = Class_zwjPublic.myClass_CustomUser;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
            }

        }

        private void toolStripMenuItem_AccountLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
            return; 
            
            Form_Login myForm = new Form_Login();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                myForm.Close();
                this.toolStripButton_UsersAndRoles.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("用户权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripButton_WPS.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripButton_WelderPicture.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripButton_ReviveQC.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripButton_System.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripButton_Parameter.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripButton_WeldingSubject.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripButton_Exam.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Read) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripButton_DataManager.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripButton_WelderBelong.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read);

                this.toolStripButton_Welder.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripButton_KindofEmployer.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripMenuItem_File.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read);
                this.toolStripMenuItem_Setting.Visible = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read);
                
                this.Text = string.Format("{0} - {2}（{1}）", System.Reflection.Assembly.GetExecutingAssembly().FullName.Split(',')[0], Class_zwjPublic.myClass_CustomUser.UserName, Class_zwjPublic.myClass_CustomUser.Name);
            }
            else
            {
                this.Close();
                return;
            }

        }

        private void toolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            Form_AboutBox myForm = new Form_AboutBox();
            myForm.ShowDialog();

        }

        private void toolStripButton_UsersAndRoles_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_UsersPart();

        }

        private void toolStripButton_ProgrammeUpdate_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_WelderPicture_ViewPart ();

        }

        private void toolStripButton_Parameter_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_ParameterPart();

        }

        private void toolStripButton_Issue_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_ExamPart();

        }

        private void toolStripButton_Welder_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_WelderPart();

        }

        private void toolStripButton_DataManager_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_DataManagerPart();
        }

        private void toolStripButton_WeldingSubject_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_WeldingSubjectPart();
        }

        private void toolStripButton_WelderBelong_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_WelderBelongPart();

        }

        private void toolStripButton_KindofEmployer_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_KindofEmployerPart();

        }

        private void ToolStripMenuItem_DataConvert_Click(object sender, EventArgs e)
        {
            Form_DataConvert myForm = new Form_DataConvert();
            myForm.ShowDialog();
        }

        private void toolStripButton_WPS_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_WPSPart();

        }

        private void toolStripButton_System_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_SystemPart();

        }

        private void toolStripButton_ReviveQC_Click(object sender, EventArgs e)
        {
            this.ShowmyUserControl_ReviveQCPart();

        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItem_ExportPaper_Click(object sender, EventArgs e)
        {
            Form myForm = new Question.Form_ExportPaper();
            myForm.ShowDialog();
        }
    }
}