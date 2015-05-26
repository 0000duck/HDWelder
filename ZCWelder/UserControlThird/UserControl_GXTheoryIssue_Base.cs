using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCCL.AspNet;
using ZCWelder.ClassBase;
using ZCWelder.Parameter;
using ZCCL.Tools;
using ZCWelder.ParameterQuery;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_GXTheoryIssue_Base : UserControl
    {
        public Class_GXTheoryIssue myClass_GXTheoryIssue;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_GXTheoryIssue myClass_GXTheoryIssueDefault;

        public UserControl_GXTheoryIssue_Base()
        {
            InitializeComponent();
        }

        private void UserControl_GXTheoryIssue_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_GXTheoryIssue"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_GXTheoryIssue myClass_GXTheoryIssue, bool bool_Add)
        {
            this.myClass_GXTheoryIssue = myClass_GXTheoryIssue;
            Class_Public.InitializeComboBox(this.ComboBox_KindofExam, Enum_DataTable.KindofExam.ToString(), "KindofExam", "KindofExam");
            Class_Public.InitializeComboBox(this.ComboBox_WeldingProcess, Enum_DataTable.WeldingProcess.ToString(), "WeldingProcessAb", "WeldingProcessAb");
            this.textBox_ShipClassificationAb.Text = this.myClass_GXTheoryIssue.ShipClassificationAb;
            this.TextBox_ShipboardNo.Text = this.myClass_GXTheoryIssue.ShipboardNo;

            if (bool_Add)
            {
                Class_Ship myClass_Ship = new Class_Ship(this.myClass_GXTheoryIssue.ShipboardNo);
                this.MaskedTextBox_IssueNo.Text = myClass_Ship.NextTheoryIssueNo;

                if (myClass_GXTheoryIssueDefault != null)
                {
                    this.ComboBox_WeldingProcess.SelectedValue = myClass_GXTheoryIssueDefault.WeldingProcessAb;
                    this.ComboBox_KindofExam.SelectedValue = myClass_GXTheoryIssueDefault.KindofExam;
                    this.TextBox_PlaceofTest.Text = myClass_GXTheoryIssueDefault.PlaceofTest;
                    this.textBox_KindofEmployer.Text = myClass_GXTheoryIssueDefault.KindofEmployer;
                    Class_Employer myClass_Employer = new Class_Employer(myClass_GXTheoryIssueDefault.EmployerHPID);
                    this.textBox_Employer.Text = string.Format("{0}:{1}", myClass_Employer.EmployerHPID, myClass_Employer.Employer);
                    this.myClass_GXTheoryIssue.KindofEmployer = myClass_GXTheoryIssueDefault.KindofEmployer;
                    this.myClass_GXTheoryIssue.EmployerHPID = myClass_GXTheoryIssueDefault.EmployerHPID;

                }

                Class_CustomUser myClass_CustomUser = new Class_CustomUser();
                if (!string.IsNullOrEmpty(Properties.Settings.Default.TheoryTeacherID))
                {
                    myClass_CustomUser.UserGUID = new Guid(Properties.Settings.Default.TheoryTeacherID);
                    if (myClass_CustomUser.FillData())
                    {
                        this.textBox_TheoryTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(Properties.Settings.Default.ArchiveTeacherID))
                {
                    myClass_CustomUser.UserGUID = new Guid(Properties.Settings.Default.ArchiveTeacherID);
                    if (myClass_CustomUser.FillData())
                    {
                        this.textBox_ArchiveTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                    }
                }
            }
            else
            {
                this.MaskedTextBox_IssueNo.Text = myClass_GXTheoryIssue.IssueNo;
                this.TextBox_IssueRemark.Text = myClass_GXTheoryIssue.IssueRemark;
                this.DateTimePicker_SignUpDate.Value = myClass_GXTheoryIssue.SignUpDate;
                this.textBox_KindofEmployer.Text = myClass_GXTheoryIssue.KindofEmployer;
                Class_Employer myClass_Employer = new Class_Employer(myClass_GXTheoryIssue.EmployerHPID);
                this.textBox_Employer.Text = string.Format("{0}:{1}", myClass_Employer.EmployerHPID, myClass_Employer.Employer);
                this.ComboBox_WeldingProcess.SelectedValue = myClass_GXTheoryIssue.WeldingProcessAb;
                this.ComboBox_KindofExam .SelectedValue = myClass_GXTheoryIssue.KindofExam ;

                Class_CustomUser myClass_CustomUser = new Class_CustomUser();
                myClass_CustomUser.UserGUID = myClass_GXTheoryIssue.TheoryTeacherID;
                if (myClass_CustomUser.FillData())
                {
                    this.textBox_TheoryTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                }
                myClass_CustomUser.UserGUID = myClass_GXTheoryIssue.ArchiveTeacherID;
                if (myClass_CustomUser.FillData())
                {
                    this.textBox_ArchiveTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                }
                this.TextBox_PlaceofTest.Text = myClass_GXTheoryIssue.PlaceofTest;


                if (myClass_GXTheoryIssue.TheoryExamDate != DateTime.MinValue)
                {
                    this.MaskedTextBox_TheoryExamDate.Text = myClass_GXTheoryIssue.TheoryExamDate.ToString("yyyy-MM-dd");
                }
                if (myClass_GXTheoryIssue.TheoryMakeupDate != DateTime.MinValue)
                {
                    this.MaskedTextBox_TheoryMakeupDate.Text = myClass_GXTheoryIssue.TheoryMakeupDate.ToString("yyyy-MM-dd");
                }
                if (myClass_GXTheoryIssue.DateBeginningofTrain != DateTime.MinValue)
                {
                    this.MaskedTextBox_DateBeginningofTrain.Text = myClass_GXTheoryIssue.DateBeginningofTrain.ToString("yyyy-MM-dd");
                }
                if (myClass_GXTheoryIssue.DateEndingofTrain != DateTime.MinValue)
                {
                    this.MaskedTextBox_DateEndingofTrain.Text = myClass_GXTheoryIssue.DateEndingofTrain.ToString("yyyy-MM-dd");
                }

                this.CheckBox_TheoryTrained.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_GXTheoryIssue.IssueStatus, 0);
                this.CheckBox_TheoryExam.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_GXTheoryIssue.IssueStatus, 1);
                this.CheckBox_TheoryExamMakeup.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_GXTheoryIssue.IssueStatus, 4);
                this.CheckBox_Finished.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_GXTheoryIssue.IssueStatus, 31);
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_GXTheoryIssue.IssueNo = this.MaskedTextBox_IssueNo.Text;
            myClass_GXTheoryIssue.IssueRemark = this.TextBox_IssueRemark.Text;

            myClass_GXTheoryIssue.WeldingProcessAb = this.ComboBox_WeldingProcess.SelectedValue.ToString();
            myClass_GXTheoryIssue.KindofExam  = this.ComboBox_KindofExam .SelectedValue.ToString();

            if (!string.IsNullOrEmpty(this.textBox_TheoryTeacherID.Text))
            {
                this.myClass_GXTheoryIssue.TheoryTeacherID = new Guid((this.textBox_TheoryTeacherID.Text.Split('：'))[1]);
            }
            if (!string.IsNullOrEmpty(this.textBox_ArchiveTeacherID.Text))
            {
                this.myClass_GXTheoryIssue.ArchiveTeacherID = new Guid((this.textBox_ArchiveTeacherID.Text.Split('：'))[1]);
            }

            myClass_GXTheoryIssue.SignUpDate = this.DateTimePicker_SignUpDate.Value;
            DateTime.TryParse(this.MaskedTextBox_TheoryExamDate.Text, out   myClass_GXTheoryIssue.TheoryExamDate);
            DateTime.TryParse(this.MaskedTextBox_TheoryMakeupDate.Text, out   myClass_GXTheoryIssue.TheoryMakeupDate);
            DateTime.TryParse(this.MaskedTextBox_DateBeginningofTrain.Text, out   myClass_GXTheoryIssue.DateBeginningofTrain);
            DateTime.TryParse(this.MaskedTextBox_DateEndingofTrain.Text, out   myClass_GXTheoryIssue.DateEndingofTrain);

            myClass_GXTheoryIssue.PlaceofTest = this.TextBox_PlaceofTest.Text;

            myClass_GXTheoryIssue.IssueStatus = 0;
            if (this.CheckBox_TheoryTrained.Checked)
            {
                myClass_GXTheoryIssue.IssueStatus = (uint)(myClass_GXTheoryIssue.IssueStatus + 1);
            }
            if (this.CheckBox_TheoryExam.Checked)
            {
                myClass_GXTheoryIssue.IssueStatus = (uint)(myClass_GXTheoryIssue.IssueStatus + 2);
            }
            if (this.CheckBox_TheoryExamMakeup.Checked)
            {
                myClass_GXTheoryIssue.IssueStatus = (uint)(myClass_GXTheoryIssue.IssueStatus + 16);
            }
            if (this.CheckBox_Finished.Checked)
            {
                myClass_GXTheoryIssue.IssueStatus = (uint)(myClass_GXTheoryIssue.IssueStatus + 2147483648);
            }

            if (myClass_GXTheoryIssueDefault == null)
            {
                myClass_GXTheoryIssueDefault = new Class_GXTheoryIssue ();
            }
            myClass_GXTheoryIssueDefault.WeldingProcessAb = myClass_GXTheoryIssue.WeldingProcessAb;
            myClass_GXTheoryIssueDefault.KindofExam  = myClass_GXTheoryIssue.KindofExam ;
            myClass_GXTheoryIssueDefault.PlaceofTest = myClass_GXTheoryIssue.PlaceofTest;
            myClass_GXTheoryIssueDefault.KindofEmployer = myClass_GXTheoryIssue.KindofEmployer;
            myClass_GXTheoryIssueDefault.EmployerHPID = myClass_GXTheoryIssue.EmployerHPID;
        }

        private void textBox_TheoryTeacherID_DoubleClick(object sender, EventArgs e)
        {
            TextBox myTextBox = (TextBox)sender;
            Form_UserQuery myForm = new Form_UserQuery();
            Class_CustomUser myClass_CustomUser = new Class_CustomUser();
            if (!string.IsNullOrEmpty(myTextBox.Text))
            {
                myClass_CustomUser.UserGUID = new Guid(myTextBox.Text.Split('：')[1]);
                if (myClass_CustomUser.FillData())
                {
                }
            }
            myForm.myClass_CustomUser = myClass_CustomUser;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                if (myForm.myClass_CustomUser != null && myForm.myClass_CustomUser.UserGUID!=null)
                {
                    myTextBox.Text = string.Format("{0}：{1}", myForm.myClass_CustomUser.Name, myForm.myClass_CustomUser.UserGUID.ToString());
                }
                else
                {
                    myTextBox.Text = "";
                }
            }

        }

        private void textBox_Employer_DoubleClick(object sender, EventArgs e)
        {
            Form_EmployerQuery myForm_EmployerQuery = new Form_EmployerQuery();
            myForm_EmployerQuery.myClass_Employer = new Class_Employer();
            if (this.myClass_GXTheoryIssue .EmployerHPID != null)
            {
                myForm_EmployerQuery.myClass_Employer.EmployerHPID = this.myClass_GXTheoryIssue.EmployerHPID;
                myForm_EmployerQuery.myClass_Employer.FillData();
            }
            if (myForm_EmployerQuery.ShowDialog() == DialogResult.OK)
            {
                this.myClass_GXTheoryIssue.EmployerHPID = myForm_EmployerQuery.myClass_Employer.EmployerHPID;
                this.textBox_Employer.Text = string.Format("{0}:{1}", myForm_EmployerQuery.myClass_Employer.EmployerHPID, myForm_EmployerQuery.myClass_Employer.Employer);
            }

        }

        private void textBox_KindofEmployer_DoubleClick(object sender, EventArgs e)
        {
            Form_KindofEmployerQuery myForm_KindofEmployerQuery = new Form_KindofEmployerQuery();
            myForm_KindofEmployerQuery.myClass_KindofEmployer = new Class_KindofEmployer();
            if (this.myClass_GXTheoryIssue.KindofEmployer != null)
            {
                myForm_KindofEmployerQuery.myClass_KindofEmployer.KindofEmployer = this.myClass_GXTheoryIssue.KindofEmployer;
                myForm_KindofEmployerQuery.myClass_KindofEmployer.FillData();
            }
            if (myForm_KindofEmployerQuery.ShowDialog() == DialogResult.OK)
            {
                this.myClass_GXTheoryIssue.KindofEmployer = myForm_KindofEmployerQuery.myClass_KindofEmployer.KindofEmployer;
                this.textBox_KindofEmployer.Text = myForm_KindofEmployerQuery.myClass_KindofEmployer.KindofEmployer;
            }

        }

    }
}
