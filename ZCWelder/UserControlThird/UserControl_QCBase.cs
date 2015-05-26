using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_QCBase : UserControl
    {
        public Class_QC myClass_QC;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_QC myClass_QCDefault;

        public UserControl_QCBase()
        {
            InitializeComponent();
        }

        private void UserControl_QC_Base_Load(object sender, EventArgs e)
        {
            this.Button_CertificateNoModify.Visible = false;

            this.TextBox_StudentRemark.ReadOnly = true;
            this.NumericUpDown_TheoryResult.Enabled = false;
            this.NumericUpDown_TheoryMakeupResult.Enabled = false;
            this.ComboBox_ExamStatus.Enabled = false;
            this.CheckBox_SkillMakeupResult.Enabled = false;
            this.CheckBox_SkillResult.Enabled = false;
            this.Button_SubjectQuery.Visible = false;
            this.Button_WelderModify.Visible = false;
            this.Button_WelderUpdate.Visible = false;

            this.TextBox_Thickness.ReadOnly = true;
            this.TextBox_ExternalDiameter.ReadOnly = true;
            this.TextBox_CoverWeldingRodDiameter.ReadOnly = true;
            this.TextBox_WeldingRodDiameter.ReadOnly = true;
            this.TextBox_RenderWeldingRodDiameter.ReadOnly = true;
            this.ComboBox_WeldingProcess .Enabled = false;
            this.ComboBox_Assemblage.Enabled = false;
            this.ComboBox_KindofExam.Enabled = false;
            this.ComboBox_DimensionofMaterial .Enabled = false;

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_QC"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_QC myClass_QC, bool bool_Add)
        {
            this.myClass_QC = myClass_QC;
            Class_Public.InitializeComboBox(this.ComboBox_Assemblage, Enum_DataTable.Assemblage.ToString(), "Assemblage", "Assemblage");
            Class_Public.InitializeComboBox(this.ComboBox_KindofExam, Enum_DataTable.KindofExam.ToString(), "KindofExam", "KindofExam");
            Class_Public.InitializeComboBox(this.ComboBox_WeldingProcess, Enum_DataTable.WeldingProcess.ToString(), "WeldingProcessAb", "WeldingProcess");
            Class_Public.InitializeComboBox(this.ComboBox_ExamStatus, Enum_DataTable.ExamStatus.ToString(), "ExamStatus", "ExamStatus");
            Class_Student myClass_Student = new Class_Student(myClass_QC.ExaminingNo);
            this.TextBox_IssueNo.Text = myClass_Student.IssueNo;
            this.TextBox_StudentRemark.Text = myClass_Student.StudentRemark;
            this.MaskedTextBox_ExaminingNo.Text = myClass_Student.ExaminingNo;
            this.ComboBox_ExamStatus.SelectedValue = myClass_Student.ExamStatus;
            this.NumericUpDown_TheoryResult.Value = myClass_Student.TheoryResult;
            this.NumericUpDown_TheoryMakeupResult.Value = myClass_Student.TheoryMakeupResult;
            this.CheckBox_SkillResult.Checked = myClass_Student.SkillResult;
            this.CheckBox_SkillMakeupResult.Checked = myClass_Student.SkillMakeupResult;
            Class_Issue myClass_Issue = new Class_Issue(myClass_Student.IssueNo);
            this.ComboBox_WeldingProcess.SelectedValue = myClass_Issue.WeldingProcessAb;

            this.InitControlWelder(new Class_Welder(myClass_Student.IdentificationCard));
            this.InitControlWeldingParameter(myClass_Student.myClass_WeldingParameter);
            this.InitControlWeldingSubject(new Class_WeldingSubject(myClass_Student.SubjectID));
            if (string.IsNullOrEmpty(this.myClass_QC.QCSubjectID))
            {
                this.myClass_QC.QCSubjectID = myClass_Student.SubjectID;
            }
            if (bool_Add)
            {
                if (myClass_Issue.IssueIssuedOn != DateTime.MinValue)
                {
                    this.dateTimePicker_IssuedOn .Value = myClass_Issue.IssueIssuedOn;
                }
                else if (Properties.Settings.Default.IssuedOn != DateTime.MinValue)
                {
                    this.dateTimePicker_IssuedOn.Value = Properties.Settings.Default.IssuedOn;
                }
                string str_CertificateNo;
                Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
                if (myClass_ShipClassification.ShipRestrict)
                {
                    Class_Ship myClass_Ship = new Class_Ship(myClass_Issue.ShipboardNo);
                    str_CertificateNo = myClass_Ship.NextCertificateNo;   
                }
                else
                {
                    str_CertificateNo = myClass_ShipClassification.NextCertificateNo;   
                }
                this.Button_CertificateNoModify.Visible = false ;
                this.MaskedTextBox_CertificateNo.ReadOnly = !string.IsNullOrEmpty(str_CertificateNo);
                this.MaskedTextBox_CertificateNo.Text = str_CertificateNo;
                if (myClass_QCDefault != null)
                {
                }
            }
            else
            {
                this.Button_CertificateNoModify.Visible = true;
                this.MaskedTextBox_CertificateNo.ReadOnly = true;
                this.MaskedTextBox_CertificateNo.Text = this.myClass_QC.CertificateNo;
                this.TextBox_SupervisionPlace.Text = this.myClass_QC.SupervisionPlace;
                this.dateTimePicker_IssuedOn.Value = this.myClass_QC.IssuedOn;
                if (this.myClass_QC.OriginalPeriod >0)
                {
                    this.NumericUpDown_OriginalPeriod.Value = this.myClass_QC.OriginalPeriod;
                }
                if ((int)this.numericUpDown_PeriodofProlongation.Minimum <= this.myClass_QC.PeriodofProlongation && (int)this.numericUpDown_PeriodofProlongation.Maximum >= this.myClass_QC.PeriodofProlongation)
                {
                    this.numericUpDown_PeriodofProlongation.Value=this.myClass_QC.PeriodofProlongation;
                }
                this.TextBox_QCRemark.Text = this.myClass_QC.QCRemark;
                if ((int)this.numericUpDown_SupervisionCycle.Minimum <= this.myClass_QC.SupervisionCycle && (int)this.numericUpDown_SupervisionCycle.Maximum >= this.myClass_QC.SupervisionCycle)
                {
                    this.numericUpDown_SupervisionCycle.Value = this.myClass_QC.SupervisionCycle;
                }
                this.checkBox_isQCValid.Checked = this.myClass_QC.isQCValid;
                this.checkBox_SupervisionFirst.Checked = this.myClass_QC.SupervisionFirst;
                this.checkBox_SupervisionSecond.Checked = this.myClass_QC.SupervisionSecond;
                this.checkBox_SupervisionThird.Checked = this.myClass_QC.SupervisionThird;
                this.checkBox_SupervisionFourth.Checked = this.myClass_QC.SupervisionFourth;
                this.checkBox_SupervisionFifth.Checked = this.myClass_QC.SupervisionFifth;
                this.checkBox_SupervisionSixth.Checked = this.myClass_QC.SupervisionSixth;
                this.checkBox_SupervisionSeventh.Checked = this.myClass_QC.SupervisionSeventh;
                this.checkBox_SupervisionEighth.Checked = this.myClass_QC.SupervisionEighth;
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

        public void InitControlWeldingParameter(Class_WeldingParameter myClass_WeldingParameter)
        {
            this.ComboBox_KindofExam.SelectedValue = myClass_WeldingParameter.KindofExam;
            this.ComboBox_Assemblage.SelectedValue = myClass_WeldingParameter.Assemblage;
            this.textBox_Material.Text = myClass_WeldingParameter.Material;
            this.textBox_WeldingConsumable.Text = myClass_WeldingParameter.WeldingConsumable;
            this.ComboBox_DimensionofMaterial.Text = myClass_WeldingParameter.DimensionofMaterial;
            this.TextBox_Thickness.Text = myClass_WeldingParameter.Thickness;
            this.TextBox_ExternalDiameter.Text = myClass_WeldingParameter.ExternalDiameter;
            this.TextBox_RenderWeldingRodDiameter.Text = myClass_WeldingParameter.RenderWeldingRodDiameter.ToString();
            this.TextBox_WeldingRodDiameter.Text = myClass_WeldingParameter.WeldingRodDiameter.ToString();
            this.TextBox_CoverWeldingRodDiameter.Text = myClass_WeldingParameter.CoverWeldingRodDiameter.ToString();
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
            this.myClass_QC.CertificateNo = this.MaskedTextBox_CertificateNo.Text;
            this.myClass_QC.SupervisionPlace = this.TextBox_SupervisionPlace.Text;
            this.myClass_QC.IssuedOn = this.dateTimePicker_IssuedOn.Value;
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

            if (myClass_QCDefault == null)
            {
                myClass_QCDefault = new Class_QC();
            }
            Properties.Settings.Default.IssuedOn=this.dateTimePicker_IssuedOn.Value  ;

        }

    }
}
