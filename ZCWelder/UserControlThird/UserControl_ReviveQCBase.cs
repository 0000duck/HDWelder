using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;
using ZCWelder.Person;
using ZCCL.AspNet;
using ZCCL.Tools;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_ReviveQCBase : UserControl
    {
        public Class_ReviveQC myClass_ReviveQC;
        public Class_QC myClass_QC;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_ReviveQC myClass_ReviveQCDefault;

        public UserControl_ReviveQCBase()
        {
            InitializeComponent();
        }

        private void UserControl_ReviveQCBase_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_Template"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_ReviveQC myClass_ReviveQC, bool bool_Add)
        {
            Class_Public.InitializeComboBox(this.ComboBox_ExamStatus, Enum_DataTable.ExamStatus.ToString(), "ExamStatus", "ExamStatus");
            Class_Public.InitializeComboBox(this.comboBox_Flaw, Enum_DataTableSecond.Flaw.ToString(), "Flaw", "Flaw");
            this.ComboBox_ExamStatus.SelectedValue = "顺利考试";
            this.comboBox_Flaw.SelectedValue = "-";
            this.myClass_ReviveQC = myClass_ReviveQC;
            if (bool_Add)
            {
                this.button_StudentQuery.Visible = true;
                this.myClass_QC = new Class_QC();
                if (myClass_ReviveQCDefault != null)
                {
                    if (myClass_ReviveQCDefault.SkillTeacherID != null)
                    {
                        Class_CustomUser myClass_CustomUser = new Class_CustomUser();
                        myClass_CustomUser.UserGUID = myClass_ReviveQCDefault.SkillTeacherID;
                        if (myClass_CustomUser.FillData())
                        {
                            this.textBox_SkillTeacher.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                        }
                    }
                    if (myClass_ReviveQCDefault.SkillExamDate > DateTime.MinValue)
                    {
                        this.dateTimePicker_SkillExamDate.Value = myClass_ReviveQCDefault.SkillExamDate;
                    }
                }
            }
            else
            {
                this.button_StudentQuery.Visible = false ;
                Class_Student myClass_Student = new Class_Student(this.myClass_ReviveQC.ExaminingNo);
                this.InitControlStudent(myClass_Student);
                this.textBox_ReviveQCID.Text = this.myClass_ReviveQC.ReviveQCID.ToString();
                Class_CustomUser myClass_CustomUser = new Class_CustomUser();
                myClass_CustomUser.UserGUID = this.myClass_ReviveQC.SkillTeacherID ;
                if (myClass_CustomUser.FillData())
                {
                    this.textBox_SkillTeacher .Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                }
                this.dateTimePicker_SkillExamDate.Value = this.myClass_ReviveQC.SkillExamDate;
                this.ComboBox_ExamStatus.SelectedValue = this.myClass_ReviveQC.ExamStatus;
                this.comboBox_Flaw.SelectedValue = this.myClass_ReviveQC.Flaw;
                this.textBox_ReviveQCRemark.Text = this.myClass_ReviveQC.ReviveQCRemark;
                this.CheckBox_isPassed.Checked = this.myClass_ReviveQC.isPassed ;
                this.checkBox_FaceDT.Checked = this.myClass_ReviveQC.FaceDT;
                this.checkBox_RT.Checked = this.myClass_ReviveQC.RT;
                this.checkBox_BendDT.Checked = this.myClass_ReviveQC.BendDT;
                this.checkBox_DisjunctionDT.Checked = this.myClass_ReviveQC.DisjunctionDT;
                this.checkBox_MacroExamination.Checked = this.myClass_ReviveQC.MacroExamination;
                this.checkBox_Impact.Checked = this.myClass_ReviveQC.Impact;
                this.checkBox_OtherDT.Checked = this.myClass_ReviveQC.OtherDT;
                this.checkBox_UT.Checked = this.myClass_ReviveQC.UT;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            this.myClass_QC.OriginalPeriod = (int)this.NumericUpDown_OriginalPeriod.Value;
            this.myClass_QC.PeriodofProlongation = (int)this.numericUpDown_PeriodofProlongation.Value;
            this.myClass_QC.QCRemark = this.TextBox_QCRemark.Text;
            this.myClass_QC.isQCValid = this.checkBox_isQCValid.Checked;
            this.myClass_QC.SupervisionCycle = (int)this.numericUpDown_SupervisionCycle.Value;
            this.myClass_QC.SupervisionFirst = this.checkBox_SupervisionFirst.Checked;
            this.myClass_QC.SupervisionSecond = this.checkBox_SupervisionSecond.Checked;
            this.myClass_QC.SupervisionThird = this.checkBox_SupervisionThird.Checked;
            this.myClass_QC.SupervisionFourth = this.checkBox_SupervisionFourth.Checked;
            this.myClass_QC.SupervisionFifth = this.checkBox_SupervisionFifth.Checked;
            this.myClass_QC.SupervisionSixth = this.checkBox_SupervisionSixth.Checked;
            this.myClass_QC.SupervisionSeventh = this.checkBox_SupervisionSeventh.Checked;
            this.myClass_QC.SupervisionEighth = this.checkBox_SupervisionEighth.Checked;

            myClass_ReviveQC.ExaminingNo = this.textBox_ExaminingNo .Text;
            myClass_ReviveQC.SkillExamDate = this.dateTimePicker_SkillExamDate.Value;
            myClass_ReviveQC.ExamStatus = this.ComboBox_ExamStatus.SelectedValue.ToString();
            myClass_ReviveQC.Flaw = this.comboBox_Flaw.SelectedValue.ToString();
            myClass_ReviveQC.ReviveQCRemark = this.textBox_ReviveQCRemark.Text;

            myClass_ReviveQC.isPassed = this.CheckBox_isPassed.Checked;
            myClass_ReviveQC.BendDT = this.checkBox_BendDT.Checked;
            myClass_ReviveQC.DisjunctionDT  = this.checkBox_DisjunctionDT .Checked;
            myClass_ReviveQC.FaceDT = this.checkBox_FaceDT.Checked;
            myClass_ReviveQC.Impact = this.checkBox_Impact.Checked;
            myClass_ReviveQC.MacroExamination = this.checkBox_MacroExamination.Checked;
            myClass_ReviveQC.OtherDT = this.checkBox_OtherDT.Checked;
            myClass_ReviveQC.RT = this.checkBox_RT.Checked;
            myClass_ReviveQC.UT = this.checkBox_UT.Checked;

            if (!string.IsNullOrEmpty(this.textBox_SkillTeacher.Text))
            {
                this.myClass_ReviveQC.SkillTeacherID = new Guid((this.textBox_SkillTeacher.Text.Split('：'))[1]);
            }

            if (myClass_ReviveQCDefault == null)
            {
                myClass_ReviveQCDefault = new Class_ReviveQC();
            }
            myClass_ReviveQCDefault.SkillTeacherID = myClass_ReviveQC.SkillTeacherID ;
            myClass_ReviveQCDefault.SkillExamDate = myClass_ReviveQC.SkillExamDate;

        }

        public void InitControlStudent(Class_Student myClass_Student)
        {
            Class_Welder myClass_Welder = new Class_Welder(myClass_Student.IdentificationCard);
            this.TextBox_Welder.Text = string.Format("{0}，{1}，{2}，{3}", myClass_Welder.WelderName, myClass_Welder.IdentificationCard, myClass_Welder.Sex, myClass_Welder.WelderEnglishName);
            Class_Employer myClass_Employer = new Class_Employer(myClass_Welder.myClass_BelongUnit.EmployerHPID);
            Class_Department myClass_Department = new Class_Department(myClass_Welder.myClass_BelongUnit.DepartmentHPID);
            Class_WorkPlace myClass_WorkPlace = new Class_WorkPlace(myClass_Welder.myClass_BelongUnit.WorkPlaceHPID);
            Class_LaborServiceTeam myClass_LaborServiceTeam = new Class_LaborServiceTeam(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID);
            this.TextBox_Employer.Text = string.Format("{0}->{1}->{2}，{3}", myClass_Employer.Employer, myClass_Department.Department, myClass_WorkPlace.WorkPlace, myClass_LaborServiceTeam.LaborServiceTeam);
            this.TextBox_WorkerID.Text = myClass_Welder.myClass_BelongUnit.WorkerID;
            this.TextBox_Schooling.Text = myClass_Welder.Schooling;
            this.textBox_WeldingBeginning.Text = myClass_Welder.WeldingBeginning.ToShortDateString();
            
            Class_Issue myClass_Issue = new Class_Issue(myClass_Student.IssueNo);
            Class_WeldingSubject  myClass_WeldingSubject = new Class_WeldingSubject(myClass_Student.SubjectID);
            this.textBox_ExaminingNo.Text = myClass_Student.ExaminingNo;
            this.textBox_IssueNo.Text = myClass_Student.IssueNo;
            this.textBox_TheoryResult.Text = string.Format("{0}/{1}", myClass_Student.TheoryResult, myClass_Student.TheoryMakeupResult);
            this.textBox_SkillResult.Text = string.Format("{0}/{1}", myClass_Student.SkillResult ? "√" : "×", myClass_Student.SkillMakeupResult ? "√" : "×");
            this.textBox_WeldingProcess.Text = string.Format("{0}({1}，{2}，{3})", myClass_Issue.WeldingProcessAb, myClass_Student.myClass_WeldingParameter.Material, myClass_Student.myClass_WeldingParameter.WeldingConsumable, myClass_Student.myClass_WeldingParameter.Assemblage);
            this.TextBox_Subject.Text = string.Format("{0}，{1}，{2}，{3}，{4}({5})", myClass_WeldingSubject.Subject, myClass_WeldingSubject.WeldingClass, myClass_WeldingSubject.JointType, myClass_WeldingSubject.WorkPieceType, myClass_WeldingSubject.WeldingProject, myClass_WeldingSubject.SubjectID);
            this.TextBox_Thickness.Text = myClass_Student.myClass_WeldingParameter.Thickness.ToString();
            this.TextBox_ExternalDiameter.Text = myClass_Student.myClass_WeldingParameter.ExternalDiameter .ToString();
            this.TextBox_StudentRemark.Text = myClass_Student.StudentRemark;

            this.myClass_QC = new Class_QC(myClass_Student.ExaminingNo);
            this.textBox_CertificateNo .Text = myClass_QC.CertificateNo;
            this.textBox_IssuedOn.Text  = myClass_QC.IssuedOn.ToShortDateString();
            if ((int)this.NumericUpDown_OriginalPeriod.Minimum <= myClass_QC.OriginalPeriod && (int)this.NumericUpDown_OriginalPeriod.Maximum >= myClass_QC.OriginalPeriod)
            {
                this.NumericUpDown_OriginalPeriod.Value = myClass_QC.OriginalPeriod;
            }
            if ((int)this.numericUpDown_PeriodofProlongation.Minimum <= myClass_QC.PeriodofProlongation && (int)this.numericUpDown_PeriodofProlongation.Maximum >= myClass_QC.PeriodofProlongation)
            {
                this.numericUpDown_PeriodofProlongation.Value = myClass_QC.PeriodofProlongation;
            }
            if ((int)this.numericUpDown_SupervisionCycle.Minimum <= myClass_QC.SupervisionCycle && (int)this.numericUpDown_SupervisionCycle.Maximum >= myClass_QC.SupervisionCycle)
            {
                this.numericUpDown_SupervisionCycle.Value = myClass_QC.SupervisionCycle;
            }
            this.TextBox_QCRemark.Text = myClass_QC.QCRemark;
            this.checkBox_isQCValid.Checked = myClass_QC.isQCValid;
            this.checkBox_SupervisionFirst.Checked = myClass_QC.SupervisionFirst;
            this.checkBox_SupervisionSecond.Checked = myClass_QC.SupervisionSecond;
            this.checkBox_SupervisionThird.Checked = myClass_QC.SupervisionThird;
            this.checkBox_SupervisionFourth.Checked = myClass_QC.SupervisionFourth;
            this.checkBox_SupervisionFifth.Checked = myClass_QC.SupervisionFifth;
            this.checkBox_SupervisionSixth.Checked = myClass_QC.SupervisionSixth;
            this.checkBox_SupervisionSeventh.Checked = myClass_QC.SupervisionSeventh;
            this.checkBox_SupervisionEighth.Checked = myClass_QC.SupervisionEighth;

        }

        private void button_StudentQuery_Click(object sender, EventArgs e)
        {
            string str_ExaminingNo = "";
            Form_InputBox myForm = new Form_InputBox();
            myForm.str_DefaultResponse = this.textBox_ExaminingNo.Text ;
            myForm.str_Prompt = "请输入考试编号：";
            myForm.str_Title = "输入考试编号";
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                str_ExaminingNo = myForm.str_DefaultResponse;
            }
            else
            {
                return;
            }
            Class_QC myClass_QC = new Class_QC();
            myClass_QC.ExaminingNo = str_ExaminingNo;
            if (myClass_QC.FillData())
            {
                if (myClass_QC.ValidUntil > DateTime.Today)
                {
                    Class_Student myClass_Student = new Class_Student(str_ExaminingNo);
                    this.InitControlStudent(myClass_Student);
                }
                else
                {
                    MessageBox.Show(string.Format("考试编号为“{0}”的焊工证书已过有效期，不能重新启用！", str_ExaminingNo));
                }
            }
            else
            {
                MessageBox.Show(string.Format("没有找到考试编号为“{0}”焊工证书！",str_ExaminingNo));
            }

        }

        private void textBox_SkillTeacher_DoubleClick(object sender, EventArgs e)
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
                if (myForm.myClass_CustomUser != null && myForm.myClass_CustomUser.UserGUID != null)
                {
                    myTextBox.Text = string.Format("{0}：{1}", myForm.myClass_CustomUser.Name, myForm.myClass_CustomUser.UserGUID.ToString());
                }
                else
                {
                    myTextBox.Text = "";
                }
            }
        }
    }
}
