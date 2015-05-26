using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery;
using ZCWelder.Person;
using ZCWelder.SignUp;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_KindofEmployerStudent_Base : UserControl
    {
        public Class_KindofEmployerStudent myClass_KindofEmployerStudent;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_KindofEmployerStudent myClass_KindofEmployerStudentDefault;

        public UserControl_KindofEmployerStudent_Base()
        {
            InitializeComponent();
        }

        private void UserControl_KindofEmployerStudent_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_KindofEmployerStudent"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_KindofEmployerStudent myClass_KindofEmployerStudent, bool bool_Add)
        {
            Class_Public.InitializeComboBox(this.ComboBox_KindofExam, Enum_DataTable.KindofExam.ToString(), "KindofExam", "KindofExam");
            Class_KindofEmployerIssue myClass_KindofEmployerIssue = new Class_KindofEmployerIssue(myClass_KindofEmployerStudent.KindofEmployerIssueID);
            this.TextBox_IssueNo.Text = myClass_KindofEmployerIssue.IssueNo;
            this.textBox_WeldingProcessAb.Text  = myClass_KindofEmployerIssue.WeldingProcessAb;
            this.textBox_KindofEmployerIssueID.Text = myClass_KindofEmployerIssue.KindofEmployerIssueID.ToString() ;
            this.myClass_KindofEmployerStudent = myClass_KindofEmployerStudent;
            if (bool_Add)
            {
                if (myClass_KindofEmployerStudentDefault != null)
                {
                    this.ComboBox_KindofExam.SelectedValue = myClass_KindofEmployerStudentDefault.StudentKindofExam;
                    this.InitControlWeldingSubject(new Class_WeldingSubject(myClass_KindofEmployerStudentDefault.ExamSubjectID));
                }
                else
                {
                    this.ComboBox_KindofExam.SelectedValue = myClass_KindofEmployerIssue.myClass_WeldingParameter.KindofExam ;
                }
            }
            else
            {
                this.ComboBox_KindofExam.SelectedValue = this.myClass_KindofEmployerStudent.StudentKindofExam;
                this.TextBox_StudentRemark.Text = myClass_KindofEmployerStudent.StudentRemark;
                this.textBox_KindofEmployerStudentID.Text = this.myClass_KindofEmployerStudent.KindofEmployerStudentID.ToString() ;

                this.InitControlWelder(new Class_KindofEmployerWelder(this.myClass_KindofEmployerStudent.KindofEmployerWelderID ));
                this.InitControlWeldingSubject(new Class_WeldingSubject(this.myClass_KindofEmployerStudent.ExamSubjectID ));

            }
        }

        public void InitControlWelder(Class_KindofEmployerWelder myClass_KindofEmployerWelder)
        {
            this.TextBox_WelderName.Text = myClass_KindofEmployerWelder.WelderName;
            this.MaskedTextBox_IdentificationCard.Text = myClass_KindofEmployerWelder.IdentificationCard;
            this.TextBox_Schooling.Text = myClass_KindofEmployerWelder.Schooling;
            this.TextBox_KindofEmployerWelderID .Text = myClass_KindofEmployerWelder.KindofEmployerWelderID.ToString() ;
            this.DateTimePicker_WeldingBeinning.Value = myClass_KindofEmployerWelder.WeldingBeginning;
            this.TextBox_WorkerID.Text = myClass_KindofEmployerWelder.myClass_BelongUnit.WorkerID;
            Class_Employer myClass_Employer = new Class_Employer(myClass_KindofEmployerWelder.myClass_BelongUnit.EmployerHPID);
            this.TextBox_Employer.Text = myClass_Employer.Employer;
            Class_Department myClass_Department = new Class_Department(myClass_KindofEmployerWelder.myClass_BelongUnit.DepartmentHPID);
            this.TextBox_Department.Text = myClass_Department.Department;
            Class_WorkPlace myClass_WorkPlace = new Class_WorkPlace(myClass_KindofEmployerWelder.myClass_BelongUnit.WorkPlaceHPID);
            this.TextBox_WorkPlace.Text = myClass_WorkPlace.WorkPlace;
            Class_LaborServiceTeam myClass_LaborServiceTeam = new Class_LaborServiceTeam(myClass_KindofEmployerWelder.myClass_BelongUnit.LaborServiceTeamHPID);
            this.TextBox_LaborServiceTeam.Text = myClass_LaborServiceTeam.LaborServiceTeam;
            this.CheckBox_Sex.Checked = myClass_KindofEmployerWelder.Sex == "男";
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

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            int.TryParse(  this.TextBox_KindofEmployerWelderID .Text,out myClass_KindofEmployerStudent.KindofEmployerWelderID);
            myClass_KindofEmployerStudent.ExamSubjectID  = this.TextBox_SubjectID.Text;
            myClass_KindofEmployerStudent.StudentKindofExam = this.ComboBox_KindofExam.SelectedValue.ToString();
            myClass_KindofEmployerStudent.StudentRemark = this.TextBox_StudentRemark.Text;

            if (myClass_KindofEmployerStudentDefault == null)
            {
                myClass_KindofEmployerStudentDefault = new Class_KindofEmployerStudent();
            }
            myClass_KindofEmployerStudentDefault.ExamSubjectID = this.myClass_KindofEmployerStudent.ExamSubjectID;
            myClass_KindofEmployerStudentDefault.StudentKindofExam = this.myClass_KindofEmployerStudent.StudentKindofExam;
        }

        private void Button_WelderUpdate_Click(object sender, EventArgs e)
        {
            Form_KindofEmployerWelder_Query myForm = new Form_KindofEmployerWelder_Query();
            Class_KindofEmployerIssue myClass_KindofEmployerIssue = new Class_KindofEmployerIssue(myClass_KindofEmployerStudent.KindofEmployerIssueID  );
            myForm.str_KindofEmployer = myClass_KindofEmployerIssue.KindofEmployer;
            myForm.myClass_KindofEmployerWelder = new Class_KindofEmployerWelder();
            myForm.myClass_KindofEmployerWelder.KindofEmployer = myClass_KindofEmployerIssue.KindofEmployer;
            if (this.myClass_KindofEmployerStudent.KindofEmployerWelderID >0)
            {
                myForm.myClass_KindofEmployerWelder .KindofEmployerWelderID = this.myClass_KindofEmployerStudent.KindofEmployerWelderID;
                myForm.myClass_KindofEmployerWelder.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_KindofEmployerStudent.KindofEmployerWelderID = myForm.myClass_KindofEmployerWelder.KindofEmployerWelderID;
                this.InitControlWelder(myForm.myClass_KindofEmployerWelder );
            }
        }

        private void Button_SubjectQuery_Click(object sender, EventArgs e)
        {
            Class_KindofEmployerIssue myClass_KindofEmployerIssue = new Class_KindofEmployerIssue(this.myClass_KindofEmployerStudent .KindofEmployerIssueID );
            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_KindofEmployerIssue.ShipClassificationAb);
            Form_WeldingSubject_Query myForm = new Form_WeldingSubject_Query();
            if (myClass_ShipClassification.WeldingStandardRestrict)
            {
                myForm.str_FilterRestrict = string.Format("WeldingStandard='{0}'", myClass_ShipClassification.WeldingStandard); ;
            }
            myForm.myClass_WeldingSubject = new Class_WeldingSubject();
            if (this.myClass_KindofEmployerStudent.ExamSubjectID  != null)
            {
                myForm.myClass_WeldingSubject.SubjectID = this.myClass_KindofEmployerStudent.ExamSubjectID;
                myForm.myClass_WeldingSubject.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_KindofEmployerStudent.ExamSubjectID = myForm.myClass_WeldingSubject.SubjectID;
                this.InitControlWeldingSubject(myForm.myClass_WeldingSubject);
            }
        }

        private void Button_WelderModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.MaskedTextBox_IdentificationCard.Text))
            {
                MessageBox.Show("没有焊工信息修改！");
                return;
            }
            Form_KindofEmployerWelder_Update myForm = new Form_KindofEmployerWelder_Update();
            myForm.bool_Add = false;
            myForm.myClass_KindofEmployerWelder = new Class_KindofEmployerWelder(int.Parse(this.TextBox_KindofEmployerWelderID .Text));
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_KindofEmployerStudent.KindofEmployerWelderID = myForm.myClass_KindofEmployerWelder.KindofEmployerWelderID;
                this.InitControlWelder(myForm.myClass_KindofEmployerWelder);
            }

        }

    }
}
