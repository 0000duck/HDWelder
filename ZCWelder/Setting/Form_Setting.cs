using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using System.Data.SqlClient;
using System.Configuration;
using ZCCL.ClassBase;

namespace ZCWelder.Setting
{
    public partial class Form_Setting : Form
    {
        public Form_Setting()
        {
            InitializeComponent();
        }

        private void Form_Setting_Load(object sender, EventArgs e)
        {
            Class_ExamField.RefreshData();

            for (int i = this.tabControl_Setting .TabCount - 1; i >= 0; i--)
            {
                this.tabControl_Setting.SelectedIndex = i;
            }

            if (Properties.Settings.Default.FormBackColor != Color.Empty)
            {
                this.PictureBox_BackColor.BackColor = Properties.Settings.Default.FormBackColor;
            }
            if (Properties.Settings.Default.textBoxDoubleClickColor != Color.Empty)
            {
                this.pictureBox_textBoxDoubleClickColor .BackColor = Properties.Settings.Default.textBoxDoubleClickColor ;
            }
            if (Properties.Settings.Default.GridColor != Color.Empty)
            {
                this.pictureBox_GridColor .BackColor = Properties.Settings.Default.GridColor ;
            }
            if (Properties.Settings.Default.DataGridViewBackColor != Color.Empty)
            {
                this.pictureBox_DataGridViewBackColor .BackColor = Properties.Settings.Default.DataGridViewBackColor ;
            }
            if (Properties.Settings.Default.DataGridViewAlternatingBackColor != Color.Empty)
            {
                this.pictureBox_DataGridViewAlternatingBackColor.BackColor = Properties.Settings.Default.DataGridViewAlternatingBackColor;
            }
            if (Properties.Settings.Default.notSupervisionColor  != Color.Empty)
            {
                this.pictureBox_notSupervisionColor.BackColor = Properties.Settings.Default.notSupervisionColor ;
            }

            this.label_FontSetting.Font = Properties.Settings.Default.FormFont;

            if (Class_ExamField.MonthsOfExamCheatRestrict >= this.NumericUpDown_TimesOfExamRestrict.Minimum && Class_ExamField.MonthsOfExamCheatRestrict <= this.NumericUpDown_MonthsOfExamCheatRestrict.Maximum)
            {
                this.NumericUpDown_MonthsOfExamCheatRestrict.Value = Class_ExamField.MonthsOfExamCheatRestrict;
            }
            if (Class_ExamField.MonthsOfExamRestrict >= this.NumericUpDown_MonthsOfExamRestrict.Minimum && Class_ExamField.MonthsOfExamRestrict <= this.NumericUpDown_MonthsOfExamRestrict.Maximum)
            {
                this.NumericUpDown_MonthsOfExamRestrict.Value = Class_ExamField.MonthsOfExamRestrict;
            }
            if (Class_ExamField.MonthsOfExamRestrictLast >= this.NumericUpDown_MonthsOfExamRestrictLast.Minimum && Class_ExamField.MonthsOfExamRestrictLast <= this.NumericUpDown_MonthsOfExamRestrictLast.Maximum)
            {
                this.NumericUpDown_MonthsOfExamRestrictLast.Value = Class_ExamField.MonthsOfExamRestrictLast;
            }
            if (Class_ExamField.SupervisionOffset >= this.NumericUpDown_SupervisionOffset.Minimum && Class_ExamField.SupervisionOffset <= this.NumericUpDown_SupervisionOffset.Maximum)
            {
                this.NumericUpDown_SupervisionOffset.Value = Class_ExamField.SupervisionOffset;
            }
            if (Class_ExamField.QCRegain >= this.numericUpDown_QCRegain.Minimum && Class_ExamField.QCRegain <= this.numericUpDown_QCRegain.Maximum)
            {
                this.numericUpDown_QCRegain.Value = Class_ExamField.QCRegain;
            }
            if (Class_ExamField.TimesOfExamRestrict >= this.NumericUpDown_TimesOfExamRestrict.Minimum && Class_ExamField.TimesOfExamRestrict <= this.NumericUpDown_TimesOfExamRestrict.Maximum)
            {
                this.NumericUpDown_TimesOfExamRestrict.Value = Class_ExamField.TimesOfExamRestrict;
            }
            this.CheckBox_OverdueSwitch.Checked = Class_ExamField.OverdueSwitch;
            this.CheckBox_UnFinishedExamRestrict.Checked = Class_ExamField.UnFinishedExamRestrict;
            this.checkBox_WelderUpdatebyLast.Checked = Class_ExamField.WelderUpdatebyLast;
            this.textBox_WebServiceWelderPicture.Text = Properties.Settings.Default.江南造船焊工信息管理软件_ZCWelderPicture_WelderPicture;
            this.checkBox_WebServiceStartUp.Checked=Properties.Settings.Default.WebServiceStartUp;

            this.textBox_CCSApplyNo.Text = Class_ExamField.CCSApplyNo;
            this.textBox_CCSSIGNNo.Text = Class_ExamField.CCSSIGNNo;

            SqlConnectionStringBuilder mySqlConnectionStringBuilder = new SqlConnectionStringBuilder(Properties.Settings.Default.zwjConnhdhr );
            this.TextBox_DataSource_HDHR.Text = mySqlConnectionStringBuilder.DataSource;
            this.TextBox_InitialCatalog_HDHR.Text = mySqlConnectionStringBuilder.InitialCatalog;
            if (mySqlConnectionStringBuilder.IntegratedSecurity)
            {
                this.CheckBox_IntegratedSecurity_HDHR.Checked = true;
                this.TextBox_UserID_HDHR.ReadOnly = true;
                this.TextBox_Password_HDHR.ReadOnly = true;
            }
            else
            {
                this.TextBox_UserID_HDHR.Text = mySqlConnectionStringBuilder.UserID;
                this.TextBox_Password_HDHR.Text = mySqlConnectionStringBuilder.Password;
            }

            this.label_ErrMessage.Text = "部分设置需重启软件后才能生效！";
        }

        private void PictureBox_BackColor_Click(object sender, EventArgs e)
        {
            PictureBox myPictureBox=(PictureBox)sender;
            if (this.ColorDialog_BackColor.ShowDialog() == DialogResult.OK )
            {
                myPictureBox.BackColor = this.ColorDialog_BackColor.Color;
                switch (myPictureBox.Name)
                {
                    case "PictureBox_BackColor":
                        Properties.Settings.Default.FormBackColor = this.ColorDialog_BackColor.Color;
                        break;
                    case "pictureBox_textBoxDoubleClickColor":
                        Properties.Settings.Default.textBoxDoubleClickColor = this.ColorDialog_BackColor.Color;
                        break;
                    case "pictureBox_GridColor":
                        Properties.Settings.Default.GridColor = this.ColorDialog_BackColor.Color;
                        break;
                    case "pictureBox_DataGridViewBackColor":
                        Properties.Settings.Default.DataGridViewBackColor = this.ColorDialog_BackColor.Color;
                        break;
                    case "pictureBox_DataGridViewAlternatingBackColor":
                        Properties.Settings.Default.DataGridViewAlternatingBackColor = this.ColorDialog_BackColor.Color;
                        break;
                    case "pictureBox_splitContainerHeadBackColor":
                        Properties.Settings.Default.splitContainerHeadBackColor  = this.ColorDialog_BackColor.Color;
                        break;
                    case "pictureBox_splitContainerHeadForeColor":
                        Properties.Settings.Default.splitContainerHeadForeColor  = this.ColorDialog_BackColor.Color;
                        break;
                    case "pictureBox_notSupervisionColor":
                        Properties.Settings.Default.notSupervisionColor   = this.ColorDialog_BackColor.Color;
                        break;
                }        
            }            
        }

        private void label_FontSetting_Click(object sender, EventArgs e)
        {
            if (this.fontDialog_FormFont.ShowDialog() == DialogResult.OK)
            {
                this.label_FontSetting.Font =  this.fontDialog_FormFont.Font;
                Properties.Settings.Default.FormFont = this.fontDialog_FormFont.Font;
            }

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.江南造船焊工信息管理软件_ZCWelderPicture_WelderPicture = this.textBox_WebServiceWelderPicture.Text;
            Properties.Settings.Default.WebServiceStartUp = this.checkBox_WebServiceStartUp.Checked;
            Properties.Settings.Default.Save();

            Class_ExamField.MonthsOfExamCheatRestrict =(int) this.NumericUpDown_MonthsOfExamCheatRestrict.Value;
            Class_ExamField.MonthsOfExamRestrict = (int)this.NumericUpDown_MonthsOfExamRestrict.Value;
            Class_ExamField.MonthsOfExamRestrictLast = (int)this.NumericUpDown_MonthsOfExamRestrictLast.Value;
            Class_ExamField.SupervisionOffset = (int)this.NumericUpDown_SupervisionOffset.Value;
            Class_ExamField.QCRegain = (int)this.numericUpDown_QCRegain.Value;
            Class_ExamField.TimesOfExamRestrict = (int)this.NumericUpDown_TimesOfExamRestrict.Value;
            Class_ExamField.OverdueSwitch = this.CheckBox_OverdueSwitch.Checked;
            Class_ExamField.UnFinishedExamRestrict = this.CheckBox_UnFinishedExamRestrict.Checked;
            Class_ExamField.WelderUpdatebyLast = this.checkBox_WelderUpdatebyLast .Checked;
            Class_ExamField.CCSApplyNo = this.textBox_CCSApplyNo.Text;
            Class_ExamField.CCSSIGNNo = this.textBox_CCSSIGNNo.Text;
            Class_ExamField.UpdateField();
            
            string str_ConnectionString = GetConnectionString();
            ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[1];
            SetConnectionString(ConnectionStringSettings.Name, str_ConnectionString);
            Class_SqlConnection.EncryptConnectionStrings();

        }

        public void SetConnectionString(string str_Key, string str_ConnectionString)
        {
            Configuration myConfig = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.ConnectionStringsSection mySection = (System.Configuration.ConnectionStringsSection)myConfig.GetSection("connectionStrings");
            mySection.ConnectionStrings[str_Key].ConnectionString = str_ConnectionString;
            myConfig.Save();

        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            string str_AppRole = Properties.Settings.Default.AppRole;
            string str_AppRolePassword = Properties.Settings.Default.AppRolePassword;
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.AppRole = str_AppRole;
            Properties.Settings.Default.AppRolePassword = str_AppRolePassword;
            Properties.Settings.Default.Save();

            Class_ExamField.MonthsOfExamCheatRestrict =6;
            Class_ExamField.MonthsOfExamRestrict =3;
            Class_ExamField.MonthsOfExamRestrictLast = 0;
            Class_ExamField.SupervisionOffset = -1;
            Class_ExamField.QCRegain  = -1;
            Class_ExamField.TimesOfExamRestrict =2;
            Class_ExamField.OverdueSwitch = true ;
            Class_ExamField.UnFinishedExamRestrict = true;
            Class_ExamField.WelderUpdatebyLast = true;
            //Class_ExamField.CCSApplyNo = string.Format("{0}-APPLY-{1}-00001", Properties.Settings.Default.CCSTestCommitteeID, DateTime.Today.Year.ToString().Substring(2, 2));
            //Class_ExamField.CCSSIGNNo = string.Format("{0}-SING-{1}-00001", Properties.Settings.Default.CCSTestCommitteeID, DateTime.Today.Year.ToString().Substring(2, 2));
            Class_ExamField.UpdateField();

            MessageBox.Show("还原设置成功！");
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private string GetConnectionString()
        {
            SqlConnectionStringBuilder mySqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            mySqlConnectionStringBuilder.DataSource = this.TextBox_DataSource_HDHR.Text;
            mySqlConnectionStringBuilder.InitialCatalog = this.TextBox_InitialCatalog_HDHR.Text;
            if (this.CheckBox_IntegratedSecurity_HDHR.Checked)
            {
                mySqlConnectionStringBuilder.PersistSecurityInfo = false;
                mySqlConnectionStringBuilder.IntegratedSecurity = true;
            }
            else
            {
                mySqlConnectionStringBuilder.PersistSecurityInfo = true;
                mySqlConnectionStringBuilder.UserID = this.TextBox_UserID_HDHR.Text;
                mySqlConnectionStringBuilder.Password = this.TextBox_Password_HDHR.Text;
            }
            return mySqlConnectionStringBuilder.ConnectionString;
        }

        private void Button_isConnectOK_HDHR_Click(object sender, EventArgs e)
        {
            string str_ConnectionString = GetConnectionString();
            SqlConnection myConn_Temp = new SqlConnection(str_ConnectionString);
            try
            {
                myConn_Temp.Open();
                if (myConn_Temp.State == ConnectionState.Open)
                {
                    MessageBox.Show("测试成功！");
                }
                myConn_Temp.Close();
            }
            catch
            {
                MessageBox.Show("测试失败！");
            }
        }

    }
}