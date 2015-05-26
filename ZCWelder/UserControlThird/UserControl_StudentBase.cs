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
using ZCWelder.WPS;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_StudentBase : UserControl
    {
        public Class_Student myClass_Student;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_Student myClass_StudentDefault;

        public UserControl_StudentBase()
        {
            InitializeComponent();
        }

        private void UserControl_Student_Base_Load(object sender, EventArgs e)
        {
            this.ComboBox_WeldingProcess.Enabled = false;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_Student"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_Student myClass_Student, bool bool_Add)
        {
            Class_Public.InitializeComboBox(this.ComboBox_Assemblage, Enum_DataTable.Assemblage.ToString(), "Assemblage", "Assemblage");
            Class_Public.InitializeComboBox(this.ComboBox_KindofExam, Enum_DataTable.KindofExam.ToString(), "KindofExam", "KindofExam");
            Class_Public.InitializeComboBox(this.ComboBox_WeldingProcess, Enum_DataTable.WeldingProcess.ToString(), "WeldingProcessAb", "WeldingProcess");
            Class_Public.InitializeComboBox(this.ComboBox_ExamStatus, Enum_DataTable.ExamStatus.ToString(), "ExamStatus", "ExamStatus");
            this.ComboBox_ExamStatus.SelectedValue = "顺利考试";
            this.TextBox_IssueNo.Text = myClass_Student.IssueNo;
            Class_Issue myClass_Issue = new Class_Issue(myClass_Student.IssueNo);
            this.ComboBox_WeldingProcess.SelectedValue = myClass_Issue.WeldingProcessAb;
            this.myClass_Student = myClass_Student;
            if (bool_Add)
            {
                Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
                if (myClass_ShipClassification.ShipRestrict)
                {
                    Class_Ship myClass_Ship=new Class_Ship(myClass_Issue.ShipboardNo);
                    this.MaskedTextBox_ExaminingNo .Text=myClass_Ship.NextSkillExaminingNo  ;
                }
                else
                {
                    this.MaskedTextBox_ExaminingNo.Text=myClass_ShipClassification.NextExaminingNo ;
                }
                if (myClass_StudentDefault != null)
                {
                    this.InitControlWeldingSubject(new Class_WeldingSubject(myClass_StudentDefault.SubjectID));
                }
                this.InitControlWeldingParameter(myClass_Issue.myClass_WeldingParameter);
            }
            else
            {
                this.TextBox_StudentRemark.Text = myClass_Student.StudentRemark;
                this.textBox_WPSNo.Text = myClass_Student.WPSNo;
                this.MaskedTextBox_ExaminingNo.Text = this.myClass_Student.ExaminingNo;
                this.ComboBox_ExamStatus.SelectedValue = this.myClass_Student.ExamStatus;
                this.NumericUpDown_TheoryResult.Value = this.myClass_Student.TheoryResult;
                this.NumericUpDown_TheoryMakeupResult.Value = this.myClass_Student.TheoryMakeupResult;
                this.CheckBox_SkillResult.Checked = this.myClass_Student.SkillResult;
                this.CheckBox_SkillMakeupResult.Checked = this.myClass_Student.SkillMakeupResult;
      
                this.InitControlWeldingParameter(this.myClass_Student.myClass_WeldingParameter);
                this.InitControlWelder(new Class_Welder(this.myClass_Student.IdentificationCard));
                this.InitControlWeldingSubject(new Class_WeldingSubject(this.myClass_Student.SubjectID));

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
            if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.EmployerHPID))
            {
                this.TextBox_Employer.Text = "";
            }
            else
            {
                Class_Employer myClass_Employer = new Class_Employer(myClass_Welder.myClass_BelongUnit.EmployerHPID);
                this.TextBox_Employer.Text = myClass_Employer.Employer;
            }
            if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.DepartmentHPID))
            {
                this.TextBox_Department.Text = "";
            }
            else
            {
                Class_Department myClass_Department = new Class_Department(myClass_Welder.myClass_BelongUnit.DepartmentHPID);
                this.TextBox_Department.Text = myClass_Department.Department;
            }
            if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.WorkPlaceHPID))
            {
                this.TextBox_WorkPlace.Text = "";
            }
            else
            {
                Class_WorkPlace myClass_WorkPlace = new Class_WorkPlace(myClass_Welder.myClass_BelongUnit.WorkPlaceHPID);
                this.TextBox_WorkPlace.Text = myClass_WorkPlace.WorkPlace;
            }
            if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID))
            {
                this.TextBox_LaborServiceTeam.Text = "";
            }
            else
            {
                Class_LaborServiceTeam myClass_LaborServiceTeam = new Class_LaborServiceTeam(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID);
                this.TextBox_LaborServiceTeam.Text = myClass_LaborServiceTeam.LaborServiceTeam;
            }
            this.CheckBox_Sex.Checked = myClass_Welder.Sex == "男";
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

        public void FillWeldingParameterClass(Class_WeldingParameter myClass_WeldingParameter)
        {
            myClass_WeldingParameter.KindofExam = this.ComboBox_KindofExam.SelectedValue.ToString();
            myClass_WeldingParameter.Assemblage = this.ComboBox_Assemblage.SelectedValue.ToString();
            myClass_WeldingParameter.Material = this.textBox_Material.Text;
            myClass_WeldingParameter.WeldingConsumable = this.textBox_WeldingConsumable.Text;
            myClass_WeldingParameter.Thickness = this.TextBox_Thickness.Text;
            myClass_WeldingParameter.ExternalDiameter = this.TextBox_ExternalDiameter.Text;
            double.TryParse(this.TextBox_RenderWeldingRodDiameter.Text, out myClass_WeldingParameter.RenderWeldingRodDiameter);
            double.TryParse(this.TextBox_WeldingRodDiameter.Text, out myClass_WeldingParameter.WeldingRodDiameter);
            double.TryParse(this.TextBox_CoverWeldingRodDiameter.Text, out myClass_WeldingParameter.CoverWeldingRodDiameter);
            myClass_WeldingParameter.DimensionofMaterial = this.ComboBox_DimensionofMaterial.Text;

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            this.FillWeldingParameterClass(this.myClass_Student.myClass_WeldingParameter);
            myClass_Student.IdentificationCard = this.MaskedTextBox_IdentificationCard.Text;
            myClass_Student.ExamStatus = this.ComboBox_ExamStatus.SelectedValue.ToString();
            myClass_Student.SubjectID = this.TextBox_SubjectID.Text;
            myClass_Student.TheoryResult =(int)this.NumericUpDown_TheoryResult.Value;
            myClass_Student.TheoryMakeupResult = (int)this.NumericUpDown_TheoryMakeupResult.Value;
            myClass_Student.SkillResult = this.CheckBox_SkillResult.Checked;
            myClass_Student.SkillMakeupResult = this.CheckBox_SkillMakeupResult.Checked;
            myClass_Student.StudentRemark = this.TextBox_StudentRemark.Text;
            myClass_Student.WPSNo = this.textBox_WPSNo.Text;

            if (myClass_StudentDefault == null)
            {
                myClass_StudentDefault = new Class_Student();
            }
            myClass_StudentDefault.SubjectID = myClass_Student.SubjectID;

        }

        private void textBox_Material_DoubleClick(object sender, EventArgs e)
        {
            Form_MaterialQuery myForm = new Form_MaterialQuery();
            myForm.myClass_Material = new Class_Material();
            if (this.myClass_Student .myClass_WeldingParameter.Material != null)
            {
                myForm.myClass_Material.Material = this.myClass_Student.myClass_WeldingParameter.Material;
                myForm.myClass_Material.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_Student.myClass_WeldingParameter.Material = myForm.myClass_Material.Material;
                this.textBox_Material.Text = string.Format("{0}", myForm.myClass_Material.Material);
            }

        }

        private void textBox_WeldingConsumable_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingConsumableQuery myForm = new Form_WeldingConsumableQuery();
            myForm.myClass_WeldingConsumable = new Class_WeldingConsumable();
            if (this.myClass_Student.myClass_WeldingParameter.WeldingConsumable != null)
            {
                myForm.myClass_WeldingConsumable.WeldingConsumable = this.myClass_Student.myClass_WeldingParameter.WeldingConsumable;
                myForm.myClass_WeldingConsumable.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_Student.myClass_WeldingParameter.WeldingConsumable = myForm.myClass_WeldingConsumable.WeldingConsumable;
                this.textBox_WeldingConsumable.Text = string.Format("{0}", myForm.myClass_WeldingConsumable.WeldingConsumable);
            }

        }

        private void Button_SubjectQuery_Click(object sender, EventArgs e)
        {
            Class_Issue myClass_Issue = new Class_Issue(this.myClass_Student.IssueNo);
            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
            Form_WeldingSubject_Query myForm = new Form_WeldingSubject_Query();
            if (myClass_ShipClassification.WeldingStandardRestrict)
            {
                myForm.str_FilterRestrict = string.Format("WeldingStandard='{0}'", myClass_ShipClassification.WeldingStandard); ;
            }
            myForm.myClass_WeldingSubject = new Class_WeldingSubject();
            if (this.myClass_Student.SubjectID   != null)
            {
                myForm.myClass_WeldingSubject.SubjectID = this.myClass_Student.SubjectID;
                myForm.myClass_WeldingSubject.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_Student.SubjectID = myForm.myClass_WeldingSubject.SubjectID;
                this.InitControlWeldingSubject(myForm.myClass_WeldingSubject);
            }
        }

        private void Button_WelderUpdate_Click(object sender, EventArgs e)
        {
            Form_Welder_Query myForm = new Form_Welder_Query();
            myForm.myClass_Welder = new Class_Welder();
            if (!string.IsNullOrEmpty(this.myClass_Student.IdentificationCard ))
            {
                myForm.myClass_Welder.IdentificationCard = this.myClass_Student.IdentificationCard;
                myForm.myClass_Welder.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Class_Issue myClass_Issue=new Class_Issue(this.myClass_Student.IssueNo);
                if (this.myClass_Student.myClass_WeldingParameter.Material  == null)
                {
                    this.myClass_Student.myClass_WeldingParameter = myClass_Issue.myClass_WeldingParameter;
                }
                string str_ReturnMessage = Class_Welder.CanSignUp(myForm.myClass_Welder.IdentificationCard, myClass_Issue.WeldingProcessAb, this.myClass_Student.SubjectID, myClass_Issue.ShipClassificationAb, myClass_Issue.ShipboardNo, this.myClass_Student .myClass_WeldingParameter.Material, this.myClass_Student .myClass_WeldingParameter.WeldingConsumable, this.myClass_Student .myClass_WeldingParameter.Thickness ,this.myClass_Student .myClass_WeldingParameter.ExternalDiameter , false);
                if (string.IsNullOrEmpty(str_ReturnMessage))
                {
                    this.myClass_Student.IdentificationCard = myForm.myClass_Welder .IdentificationCard;
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
            if (string.IsNullOrEmpty(this.MaskedTextBox_IdentificationCard .Text ))
            {
                MessageBox.Show("没有焊工信息修改！");
                return;
            }
            Form_Welder_Update myForm= new Form_Welder_Update();
            myForm.bool_Add = false;
            myForm.myClass_Welder = new Class_Welder(this.MaskedTextBox_IdentificationCard .Text);
            if ( myForm.ShowDialog() == DialogResult.OK )
            {
                this.myClass_Student.IdentificationCard = myForm.myClass_Welder.IdentificationCard;
                this.InitControlWelder(myForm.myClass_Welder);
            }

        }

        private void textBox_WPSNo_DoubleClick(object sender, EventArgs e)
        {
            Form_WpsQuery myForm = new Form_WpsQuery();
            myForm.myClass_WPS = new Class_WPS();
            if (!string.IsNullOrEmpty(this.myClass_Student.WPSNo))
            {
                myForm.myClass_WPS.WPSID = this.myClass_Student.WPSNo;
                myForm.myClass_WPS.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_Student.WPSNo = myForm.myClass_WPS.WPSID;
                this.textBox_WPSNo.Text = string.Format("{0}", myForm.myClass_WPS.WPSID);
            }

        }

    }
}
