using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.DataGridViewManager;
using ZCCL.AspNet;
using ZCCL.Report;
using ZCCL.ClassBase;
using System.Data.SqlClient;
using ZCCL.Tools;
using ZCCL.SystemInformation;

namespace ZCWelder
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            this.Label_ErrorMessage.Text = "";
            this.UsernameTextBox.Text = Properties.Settings.Default.DefaultUsername ;
            if ( !string.IsNullOrEmpty(this.UsernameTextBox.Text))
            {
                this.PasswordTextBox.Select ();
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private bool TestConnection()
        {
            bool bool_ConnnectOK = false;
            SqlConnection myConn_Temp = new SqlConnection(Properties.Settings.Default.zwjConn);
            try
            {
                myConn_Temp.Open();
                if (myConn_Temp.State == ConnectionState.Open)
                {
                    if (!string.IsNullOrEmpty(Properties.Settings.Default.AppRole))
                    {
                        SqlCommand myCmd = new SqlCommand(string.Format("sp_setapprole {0}, {1}", Properties.Settings.Default.AppRole, Class_CryptoGraph.Decode(Properties.Settings.Default.AppRolePassword)), myConn_Temp);
                        myCmd.ExecuteNonQuery();
                        bool_ConnnectOK = true;
                    }
                    else
                    {
                        bool_ConnnectOK = true;
                    }
                }
            }
            catch
            {
                bool_ConnnectOK=false;
            }
            finally
            {
                if (myConn_Temp.State == ConnectionState.Open)
                {
                    if (string.IsNullOrEmpty(Properties.Settings.Default.AppRole))
                    {
                        myConn_Temp.Close();
                    }
                }
            }
            return bool_ConnnectOK;

        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (this.checkBox_ResetSetting.Checked)
            {
                string str_AppRole = Properties.Settings.Default.AppRole;
                string str_AppRolePassword = Properties.Settings.Default.AppRolePassword;
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
                Properties.Settings.Default.AppRole = str_AppRole;
                Properties.Settings.Default.AppRolePassword = str_AppRolePassword;
                Properties.Settings.Default.Save();
            }

            if (!this.TestConnection())
            {
                MessageBox.Show("数据连接错误！");
                this.DialogResult = DialogResult.None;
                return;
            }

            if (!Class_SystemInformationField.isRelease)
            {
                DateTime myDateTime = new DateTime(2015, 1, 1);
                if (DateTime.Today > myDateTime)
                {
                    MessageBox.Show("本软件为测试版，且已过试用期，您无权继续使用本软件，如继续使用，本软件开发者将追究您的法律责任！");
                    if (DateTime.Today > myDateTime.AddYears(3))
                    {
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
            }


            if (!Class_CustomUser.isInitialized())
            {
                Form_UserUpdate myForm = new Form_UserUpdate();
                myForm.bool_Add = true;
                myForm.bool_isInit = true;
                myForm.myClass_CustomUser = new Class_CustomUser();
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    return;
                }
            } 
            
            if (Class_CustomUser.ValidateUser(this.UsernameTextBox.Text, this.PasswordTextBox.Text))
            {
                object UserGUID = Class_CustomUser.GetUserGUID(this.UsernameTextBox.Text);
                Class_zwjPublic.myClass_CustomUser = new Class_CustomUser(UserGUID);
                Properties.Settings.Default.DefaultUsername=this.UsernameTextBox.Text;
                Properties.Settings.Default.Save();
                if (Class_CustomUser.GetSecurity(UserGUID, Class_CustomSecurity.GetSecurityGUID("系统权限"), Enum_zwjKindofUpdate.Read)
                    || Class_CustomUser.GetSecurity(UserGUID, Class_CustomSecurity.GetSecurityGUID("用户权限"), Enum_zwjKindofUpdate.Read)
                    || Class_CustomUser.GetSecurity(UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Read)
                    || Class_CustomUser.GetSecurity(UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read))
                {
                }
                else
                {
                    this.Label_ErrorMessage.Text = "你无权登录！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.Label_ErrorMessage .Text = "你无权登录！";
                this.DialogResult = DialogResult.None;
            }

        }

        private void button_ConnectionUpdate_Click(object sender, EventArgs e)
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
    }
}