using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery;
using ZCWelder.Person;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_GXTheoryStudent_Base : UserControl
    {
        public Class_GXTheoryStudent myClass_GXTheoryStudent;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_GXTheoryStudent myClass_GXTheoryStudentDefault;

        public UserControl_GXTheoryStudent_Base()
        {
            InitializeComponent();
        }

        private void UserControl_GXTheoryStudent_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_GXTheoryStudent"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_GXTheoryStudent myClass_GXTheoryStudent, bool bool_Add)
        {
            Class_Public.InitializeComboBox(this.ComboBox_KindofExam, Enum_DataTable.KindofExam.ToString(), "KindofExam", "KindofExam");
            Class_Public.InitializeComboBox(this.ComboBox_ExamStatus, Enum_DataTable.ExamStatus.ToString(), "ExamStatus", "ExamStatus");
            this.ComboBox_ExamStatus.SelectedValue = "顺利考试";
            this.TextBox_IssueNo.Text = myClass_GXTheoryStudent.IssueNo;
            this.myClass_GXTheoryStudent = myClass_GXTheoryStudent;
            if (bool_Add)
            {
                Class_GXTheoryIssue myClass_GXTheoryIssue = new Class_GXTheoryIssue(myClass_GXTheoryStudent.IssueNo);
                this.textBox_WeldingProcessAb.Text = myClass_GXTheoryIssue.WeldingProcessAb;
                this.ComboBox_KindofExam .SelectedValue = myClass_GXTheoryIssue.KindofExam ;
                Class_Ship myClass_Ship = new Class_Ship(myClass_GXTheoryIssue.ShipboardNo);
                this.MaskedTextBox_ExaminingNo .Text = myClass_Ship.NextTheoryExaminingNo ;
                if (myClass_GXTheoryStudentDefault != null)
                {
                    this.InitControlWeldingSubject(new Class_WeldingSubject(myClass_GXTheoryStudentDefault.SubjectID));
                }
            }
            else
            {
                this.TextBox_StudentRemark.Text = myClass_GXTheoryStudent.StudentRemark;
                this.MaskedTextBox_ExaminingNo.Text = this.myClass_GXTheoryStudent.ExaminingNo;
                this.ComboBox_ExamStatus.SelectedValue = this.myClass_GXTheoryStudent.ExamStatus;
                this.NumericUpDown_TheoryResult.Value = this.myClass_GXTheoryStudent.TheoryResult;
                this.NumericUpDown_TheoryMakeupResult.Value = this.myClass_GXTheoryStudent.TheoryMakeupResult;

                this.InitControlWelder(new Class_Welder(this.myClass_GXTheoryStudent.IdentificationCard));
                this.InitControlWeldingSubject(new Class_WeldingSubject(this.myClass_GXTheoryStudent.SubjectID));

            }
        }

        public void InitControlWelder(Class_Welder myClass_Welder)
        {
            this.TextBox_WelderName.Text = myClass_Welder.WelderName;
            this.MaskedTextBox_IdentificationCard.Text = myClass_Welder.IdentificationCard;
            this.TextBox_Schooling.Text = myClass_Welder.Schooling;
            this.TextBox_WelderEnglishName.Text = myClass_Welder.WelderEnglishName;
            this.DateTimePicker_WeldingBeinning.Value = myClass_Welder.WeldingBeginning;
            this.TextBox_WorkerID.Text = myClass_Welder.myClass_BelongUnit.WorkerID;
            Class_Employer myClass_Employer = new Class_Employer(myClass_Welder.myClass_BelongUnit.EmployerHPID);
            this.TextBox_Employer.Text = myClass_Employer.Employer;
            Class_Department myClass_Department = new Class_Department(myClass_Welder.myClass_BelongUnit.DepartmentHPID);
            this.TextBox_Department.Text = myClass_Department.Department;
            Class_WorkPlace myClass_WorkPlace = new Class_WorkPlace(myClass_Welder.myClass_BelongUnit.WorkPlaceHPID);
            this.TextBox_WorkPlace.Text = myClass_WorkPlace.WorkPlace;
            Class_LaborServiceTeam myClass_LaborServiceTeam = new Class_LaborServiceTeam(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID);
            this.TextBox_LaborServiceTeam.Text = myClass_LaborServiceTeam.LaborServiceTeam;
            this.CheckBox_Sex.Checked = myClass_Welder.Sex == "男";
        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_GXTheoryStudent.IdentificationCard = this.MaskedTextBox_IdentificationCard.Text;
            myClass_GXTheoryStudent.KindofExam  = this.ComboBox_KindofExam .SelectedValue.ToString();
            myClass_GXTheoryStudent.ExamStatus = this.ComboBox_ExamStatus.SelectedValue.ToString();
            myClass_GXTheoryStudent.TheoryResult = (int)this.NumericUpDown_TheoryResult.Value;
            myClass_GXTheoryStudent.TheoryMakeupResult = (int)this.NumericUpDown_TheoryMakeupResult.Value;
            myClass_GXTheoryStudent.StudentRemark = this.TextBox_StudentRemark.Text;
            myClass_GXTheoryStudent.SubjectID = this.TextBox_SubjectID.Text;

            if (myClass_GXTheoryStudentDefault == null)
            {
                myClass_GXTheoryStudentDefault = new Class_GXTheoryStudent();
            }
            myClass_GXTheoryStudentDefault.SubjectID = myClass_GXTheoryStudent.SubjectID;
        }

        private void Button_WelderUpdate_Click(object sender, EventArgs e)
        {
            Form_Welder_Query myForm = new Form_Welder_Query();
            myForm.myClass_Welder = new Class_Welder();
            if (this.myClass_GXTheoryStudent .IdentificationCard != null)
            {
                myForm.myClass_Welder.IdentificationCard = this.myClass_GXTheoryStudent.IdentificationCard;
                myForm.myClass_Welder.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Class_GXTheoryIssue myClass_GXTheoryIssue = new Class_GXTheoryIssue(this.myClass_GXTheoryStudent.IssueNo);
                string str_ReturnMessage = Class_Welder.CanSignUp(myForm.myClass_Welder.IdentificationCard, myClass_GXTheoryIssue.WeldingProcessAb, null, myClass_GXTheoryIssue.ShipClassificationAb, myClass_GXTheoryIssue.ShipboardNo,null,null,null,null,true );
                if (string.IsNullOrEmpty(str_ReturnMessage))
                {
                    this.myClass_GXTheoryStudent.IdentificationCard = myForm.myClass_Welder.IdentificationCard;
                    this.InitControlWelder(myForm.myClass_Welder);
                }
                else
                {
                    MessageBox.Show(str_ReturnMessage);
                }
            }

        }

        private void Button_WelderModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.MaskedTextBox_IdentificationCard.Text))
            {
                MessageBox.Show("没有焊工信息修改！");
                return;
            }
            Form_Welder_Update myForm = new Form_Welder_Update();
            myForm.bool_Add = false;
            myForm.myClass_Welder = new Class_Welder(this.MaskedTextBox_IdentificationCard.Text);
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_GXTheoryStudent.IdentificationCard = myForm.myClass_Welder.IdentificationCard;
                this.InitControlWelder(myForm.myClass_Welder);
            }


        }

        private void Button_SubjectQuery_Click(object sender, EventArgs e)
        {
            Class_GXTheoryIssue myClass_Issue = new Class_GXTheoryIssue(this.myClass_GXTheoryStudent.IssueNo);
            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
            Form_WeldingSubject_Query myForm = new Form_WeldingSubject_Query();
            if (myClass_ShipClassification.WeldingStandardRestrict)
            {
                myForm.str_FilterRestrict = string.Format("WeldingStandard='{0}'", myClass_ShipClassification.WeldingStandard); ;
            }
            myForm.myClass_WeldingSubject = new Class_WeldingSubject();
            if (this.myClass_GXTheoryStudent.SubjectID != null)
            {
                myForm.myClass_WeldingSubject.SubjectID = this.myClass_GXTheoryStudent.SubjectID;
                myForm.myClass_WeldingSubject.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_GXTheoryStudent.SubjectID = myForm.myClass_WeldingSubject.SubjectID;
                this.InitControlWeldingSubject(myForm.myClass_WeldingSubject);
            }
        }

        public void InitControlWeldingSubject(Class_WeldingSubject myClass_Subject)
        {
            this.TextBox_SubjectID.Text = myClass_Subject.SubjectID;
            this.TextBox_WeldingStandard.Text = myClass_Subject.WeldingStandard;
            this.TextBox_WeldingProject.Text = myClass_Subject.WeldingProject;
            this.TextBox_WeldingClass.Text = myClass_Subject.WeldingClass;
            this.TextBox_WorkPieceType.Text = myClass_Subject.WorkPieceType;
            this.TextBox_JointType.Text = myClass_Subject.JointType;
            this.TextBox_Subject.Text = myClass_Subject.Subject;
        }

    }
}
