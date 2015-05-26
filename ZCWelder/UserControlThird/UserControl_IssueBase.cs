using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.AspNet;
using ZCCL.ClassBase;
using ZCWelder.ParameterQuery;
using ZCCL.Tools;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_IssueBase : UserControl
    {
        public Class_Issue myClass_Issue;
        static private Class_Issue myClass_IssueDefault;

        public UserControl_IssueBase()
        {
            InitializeComponent();
        }

        private void UserControl_IssueBase_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_Issue"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_Issue myClass_Issue, bool bool_Add)
        {
            Class_Public.InitializeComboBox(this.ComboBox_Assemblage, Enum_DataTable.Assemblage.ToString(), "Assemblage", "Assemblage");
            Class_Public.InitializeComboBox(this.ComboBox_KindofExam, Enum_DataTable.KindofExam.ToString(), "KindofExam", "KindofExam");
            Class_Public.InitializeComboBox(this.ComboBox_WeldingProcess, Enum_DataTable.WeldingProcess.ToString(), "WeldingProcessAb", "WeldingProcessAb");
            this.myClass_Issue = myClass_Issue;
            this.textBox_ShipClassificationAb.Text = this.myClass_Issue.ShipClassificationAb;
            this.TextBox_ShipboardNo.Text = this.myClass_Issue.ShipboardNo;
            if (bool_Add)
            {
                Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(this.myClass_Issue.ShipClassificationAb);
                if (myClass_ShipClassification.ShipRestrict)
                {
                    Class_Ship myClass_Ship=new Class_Ship(this.myClass_Issue.ShipboardNo);
                    this.MaskedTextBox_IssueNo.Text=myClass_Ship.NextSkillIssueNo ;
                }
                else
                {
                    this.MaskedTextBox_IssueNo.Text=myClass_ShipClassification.NextIssueNo;
                }
                if (myClass_IssueDefault != null)
                {
                    this.InitControlWeldingParameter (myClass_IssueDefault.myClass_WeldingParameter);
                    this.ComboBox_WeldingProcess .SelectedValue  = myClass_IssueDefault.WeldingProcessAb;
                    this.TextBox_PlaceofTest .Text  = myClass_IssueDefault.PlaceofTest;
                    this.TextBox_SupervisionPlace .Text  = myClass_IssueDefault.SupervisionPlace;
                    this.NumericUpDown_OriginalPeriod .Value   = myClass_IssueDefault.PeriodofValidity;
                    this.textBox_KindofEmployer.Text = myClass_IssueDefault.KindofEmployer;
                    if (!string.IsNullOrEmpty(myClass_IssueDefault.EmployerHPID))
                    {
                        Class_Employer myClass_Employer = new Class_Employer(myClass_IssueDefault.EmployerHPID);
                        this.textBox_Employer.Text = string.Format("{0}:{1}", myClass_Employer.EmployerHPID, myClass_Employer.Employer);
                    }
                    this.myClass_Issue.KindofEmployer = myClass_IssueDefault.KindofEmployer;
                    this.myClass_Issue.EmployerHPID = myClass_IssueDefault.EmployerHPID;

                }

                Class_CustomUser myClass_CustomUser = new Class_CustomUser();
                if (!string.IsNullOrEmpty(Properties.Settings.Default.TheoryTeacherID ))
                {
                    myClass_CustomUser.UserGUID = new Guid(Properties.Settings.Default.TheoryTeacherID);
                    if (myClass_CustomUser.FillData())
                    {
                        this.textBox_TheoryTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(Properties.Settings.Default.SkillTeacherID) )
                {
                    myClass_CustomUser.UserGUID = new Guid(Properties.Settings.Default.SkillTeacherID);
                    if (myClass_CustomUser.FillData())
                    {
                        this.textBox_SkillTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(Properties.Settings.Default.SupervisorID ))
                {
                    myClass_CustomUser.UserGUID = new Guid(Properties.Settings.Default.SupervisorID);
                    if (myClass_CustomUser.FillData())
                    {
                        this.textBox_SupervisorID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(Properties.Settings.Default.IssueQCTeacherID ))
                {
                    myClass_CustomUser.UserGUID = new Guid(Properties.Settings.Default.IssueQCTeacherID);
                    if (myClass_CustomUser.FillData())
                    {
                        this.textBox_IssueQCTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(Properties.Settings.Default.ArchiveTeacherID ))
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
                this.MaskedTextBox_IssueNo.Text = myClass_Issue.IssueNo;
                this.TextBox_IssueRemark.Text = myClass_Issue.IssueRemark;
                this.DateTimePicker_SignUpDate.Value = myClass_Issue.SignUpDate;
                this.textBox_KindofEmployer.Text = myClass_Issue.KindofEmployer;
                Class_Employer myClass_Employer = new Class_Employer(myClass_Issue.EmployerHPID);
                this.textBox_Employer.Text = string.Format("{0}:{1}", myClass_Employer.EmployerHPID, myClass_Employer.Employer);
                this.ComboBox_WeldingProcess.SelectedValue = myClass_Issue.WeldingProcessAb;

                this.InitControlWeldingParameter(this.myClass_Issue.myClass_WeldingParameter);

                Class_CustomUser myClass_CustomUser = new Class_CustomUser();
                myClass_CustomUser.UserGUID = myClass_Issue.TheoryTeacherID;
                if (myClass_CustomUser.FillData())
                {
                    this.textBox_TheoryTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                }
                myClass_CustomUser.UserGUID = myClass_Issue.ArchiveTeacherID;
                if (myClass_CustomUser.FillData())
                {
                    this.textBox_ArchiveTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                }
                myClass_CustomUser.UserGUID = myClass_Issue.SkillTeacherID;
                if (myClass_CustomUser.FillData())
                {
                    this.textBox_SkillTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                }
                myClass_CustomUser.UserGUID = myClass_Issue.SupervisorID;
                if (myClass_CustomUser.FillData())
                {
                    this.textBox_SupervisorID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                }
                myClass_CustomUser.UserGUID = myClass_Issue.IssueQCTeacherID;
                if (myClass_CustomUser.FillData())
                {
                    this.textBox_IssueQCTeacherID.Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                }
                this.TextBox_PlaceofTest.Text = myClass_Issue.PlaceofTest;


                if (myClass_Issue.TheoryExamDate != DateTime.MinValue)
                {
                    this.MaskedTextBox_TheoryExamDate.Text = myClass_Issue.TheoryExamDate.ToString("yyyy-MM-dd");
                }
                if (myClass_Issue.TheoryMakeupDate != DateTime.MinValue)
                {
                    this.MaskedTextBox_TheoryMakeupDate.Text = myClass_Issue.TheoryMakeupDate.ToString("yyyy-MM-dd");
                }
                if (myClass_Issue.SkillExamDate != DateTime.MinValue)
                {
                    this.MaskedTextBox_SkillExamDate.Text = myClass_Issue.SkillExamDate.ToString("yyyy-MM-dd");
                }
                if (myClass_Issue.SkillMakeupDate != DateTime.MinValue)
                {
                    this.MaskedTextBox_SkillMakeupDate.Text = myClass_Issue.SkillMakeupDate.ToString("yyyy-MM-dd");
                }
                if (myClass_Issue.DateBeginningofTrain != DateTime.MinValue)
                {
                    this.MaskedTextBox_DateBeginningofTrain.Text = myClass_Issue.DateBeginningofTrain.ToString("yyyy-MM-dd");
                }
                if (myClass_Issue.DateEndingofTrain != DateTime.MinValue)
                {
                    this.MaskedTextBox_DateEndingofTrain.Text = myClass_Issue.DateEndingofTrain.ToString("yyyy-MM-dd");
                }
                if (myClass_Issue.VisualTestDate != DateTime.MinValue)
                {
                    this.MaskedTextBox_VisualTestDate.Text = myClass_Issue.VisualTestDate.ToString("yyyy-MM-dd");
                }
                if (myClass_Issue.BendTestDate != DateTime.MinValue)
                {
                    this.MaskedTextBox_BendTestDate.Text = myClass_Issue.BendTestDate.ToString("yyyy-MM-dd");
                }
                if (myClass_Issue.RTTestDate != DateTime.MinValue)
                {
                    this.MaskedTextBox_RTTestDate.Text = myClass_Issue.RTTestDate.ToString("yyyy-MM-dd");
                }
                if (myClass_Issue.IssueIssuedOn != DateTime.MinValue)
                {
                    this.MaskedTextBox_IssuedOn.Text = myClass_Issue.IssueIssuedOn.ToString("yyyy-MM-dd");
                }
                this.TextBox_SupervisionPlace.Text = myClass_Issue.SupervisionPlace;
                if (myClass_Issue.PeriodofValidity >= this.NumericUpDown_OriginalPeriod.Minimum && myClass_Issue.PeriodofValidity <= this.NumericUpDown_OriginalPeriod.Maximum)
                {
                    this.NumericUpDown_OriginalPeriod .Value  = myClass_Issue.PeriodofValidity;
                }

                this.CheckBox_TheoryTrained.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_Issue.IssueStatus, 0);
                this.CheckBox_TheoryExam.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_Issue.IssueStatus, 1);
                this.CheckBox_TheoryExamMakeup.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_Issue.IssueStatus, 4);
                this.CheckBox_SkillTrained.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_Issue.IssueStatus, 6);
                this.CheckBox_SkillExam.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_Issue.IssueStatus, 7);
                this.CheckBox_SkillExamMakeup.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_Issue.IssueStatus, 10);
                this.CheckBox_Certificated.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_Issue.IssueStatus, 14);
                this.CheckBox_Finished.Checked = Class_DataValidateTool.CheckUintBit(this.myClass_Issue.IssueStatus, 31);
            }
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
            this.FillWeldingParameterClass(this.myClass_Issue.myClass_WeldingParameter);
            myClass_Issue.IssueNo = this.MaskedTextBox_IssueNo.Text;
            myClass_Issue.IssueRemark = this.TextBox_IssueRemark.Text;

            myClass_Issue.WeldingProcessAb = this.ComboBox_WeldingProcess.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(this.textBox_TheoryTeacherID.Text))
            {
                this.myClass_Issue.TheoryTeacherID = new Guid((this.textBox_TheoryTeacherID.Text.Split('：'))[1]);
            }
            if (!string.IsNullOrEmpty(this.textBox_SkillTeacherID.Text))
            {
                this.myClass_Issue.SkillTeacherID = new Guid((this.textBox_SkillTeacherID.Text.Split('：'))[1]);
            }
            if (!string.IsNullOrEmpty(this.textBox_ArchiveTeacherID.Text))
            {
                this.myClass_Issue.ArchiveTeacherID = new Guid((this.textBox_ArchiveTeacherID.Text.Split('：'))[1]);
            }
            if (!string.IsNullOrEmpty(this.textBox_SupervisorID.Text))
            {
                this.myClass_Issue.SupervisorID = new Guid((this.textBox_SupervisorID.Text.Split('：'))[1]);
            }
            if (!string.IsNullOrEmpty(this.textBox_IssueQCTeacherID.Text))
            {
                this.myClass_Issue.IssueQCTeacherID = new Guid((this.textBox_IssueQCTeacherID.Text.Split('：'))[1]);
            }

            myClass_Issue.SignUpDate = this.DateTimePicker_SignUpDate.Value;
            DateTime.TryParse(this.MaskedTextBox_TheoryExamDate.Text, out   myClass_Issue.TheoryExamDate );
            DateTime.TryParse(this.MaskedTextBox_TheoryMakeupDate.Text, out   myClass_Issue.TheoryMakeupDate );
            DateTime.TryParse(this.MaskedTextBox_SkillExamDate.Text, out   myClass_Issue.SkillExamDate );
            DateTime.TryParse(this.MaskedTextBox_SkillMakeupDate.Text, out   myClass_Issue.SkillMakeupDate );
            DateTime.TryParse(this.MaskedTextBox_DateBeginningofTrain.Text, out   myClass_Issue.DateBeginningofTrain );
            DateTime.TryParse(this.MaskedTextBox_DateEndingofTrain.Text, out   myClass_Issue.DateEndingofTrain );
            DateTime.TryParse(this.MaskedTextBox_IssuedOn.Text, out   myClass_Issue.IssueIssuedOn);
            DateTime.TryParse(this.MaskedTextBox_VisualTestDate.Text, out   myClass_Issue.VisualTestDate );
            DateTime.TryParse(this.MaskedTextBox_BendTestDate.Text, out   myClass_Issue.BendTestDate );
            DateTime.TryParse(this.MaskedTextBox_RTTestDate.Text, out   myClass_Issue.RTTestDate );

            myClass_Issue.SupervisionPlace = this.TextBox_SupervisionPlace.Text;
            myClass_Issue.PeriodofValidity =(int) this.NumericUpDown_OriginalPeriod.Value;
            myClass_Issue.PlaceofTest = this.TextBox_PlaceofTest.Text;

            myClass_Issue.IssueStatus = 0;
            if (this.CheckBox_TheoryTrained.Checked)
            {
                myClass_Issue.IssueStatus=(uint)(myClass_Issue.IssueStatus+1);
            }
            if ( this.CheckBox_TheoryExam.Checked )
            {
                myClass_Issue.IssueStatus=(uint)(myClass_Issue.IssueStatus+2);
            }
            if ( this.CheckBox_TheoryExamMakeup.Checked )
            {
                myClass_Issue.IssueStatus=(uint)(myClass_Issue.IssueStatus+16);
            }
            if ( this.CheckBox_SkillTrained.Checked )
            {
                myClass_Issue.IssueStatus=(uint)(myClass_Issue.IssueStatus+64);
            }
            if ( this.CheckBox_SkillExam.Checked )
            {
                myClass_Issue.IssueStatus=(uint)(myClass_Issue.IssueStatus+128);
            }
            if ( this.CheckBox_SkillExamMakeup.Checked )
            {
                myClass_Issue.IssueStatus=(uint)(myClass_Issue.IssueStatus+1024);
            }
            if ( this.CheckBox_Certificated.Checked )
            {
                myClass_Issue.IssueStatus=(uint)(myClass_Issue.IssueStatus+16384);
            }
            if ( this.CheckBox_Finished.Checked )
            {
                myClass_Issue.IssueStatus=(uint)(myClass_Issue.IssueStatus+2147483648);
            }

            if (myClass_IssueDefault == null)
            {
                myClass_IssueDefault = new Class_Issue();
            }
            this.FillWeldingParameterClass(myClass_IssueDefault.myClass_WeldingParameter);
            myClass_IssueDefault.WeldingProcessAb = myClass_Issue.WeldingProcessAb;
            myClass_IssueDefault.PlaceofTest = myClass_Issue.PlaceofTest;
            myClass_IssueDefault.SupervisionPlace = myClass_Issue.SupervisionPlace;
            myClass_IssueDefault.PeriodofValidity = myClass_Issue.PeriodofValidity;
            myClass_IssueDefault.KindofEmployer = myClass_Issue.KindofEmployer;
            myClass_IssueDefault.EmployerHPID = myClass_Issue.EmployerHPID;
            
        }

        private void textBox_TheoryTeacher_DoubleClick(object sender, EventArgs e)
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

        private void textBox_Material_DoubleClick(object sender, EventArgs e)
        {
            Form_MaterialQuery myForm = new Form_MaterialQuery();
            myForm.myClass_Material = new Class_Material();
            if (this.myClass_Issue.myClass_WeldingParameter.Material != null)
            {
                myForm.myClass_Material.Material = this.myClass_Issue.myClass_WeldingParameter.Material;
                myForm.myClass_Material.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_Issue.myClass_WeldingParameter.Material = myForm.myClass_Material.Material;
                this.textBox_Material.Text = string.Format("{0}", myForm.myClass_Material.Material);
            }

        }

        private void textBox_WeldingConsumable_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingConsumableQuery myForm = new Form_WeldingConsumableQuery();
            myForm.myClass_WeldingConsumable = new Class_WeldingConsumable();
            if (this.myClass_Issue.myClass_WeldingParameter.WeldingConsumable  != null)
            {
                myForm.myClass_WeldingConsumable.WeldingConsumable = this.myClass_Issue.myClass_WeldingParameter.WeldingConsumable;
                myForm.myClass_WeldingConsumable.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_Issue.myClass_WeldingParameter.WeldingConsumable = myForm.myClass_WeldingConsumable.WeldingConsumable;
                this.textBox_WeldingConsumable.Text = string.Format("{0}", myForm.myClass_WeldingConsumable.WeldingConsumable);
            }

        }

        private void textBox_Employer_DoubleClick(object sender, EventArgs e)
        {
            Form_EmployerQuery myForm_EmployerQuery = new Form_EmployerQuery();
            myForm_EmployerQuery.myClass_Employer = new Class_Employer();
            if (this.myClass_Issue .EmployerHPID  != null)
            {
                myForm_EmployerQuery.myClass_Employer.EmployerHPID = this.myClass_Issue.EmployerHPID;
                myForm_EmployerQuery.myClass_Employer.FillData();
            }
            if (myForm_EmployerQuery.ShowDialog() == DialogResult.OK)
            {
                this.myClass_Issue.EmployerHPID = myForm_EmployerQuery.myClass_Employer.EmployerHPID;
                this.textBox_Employer .Text = string.Format("{0}:{1}", myForm_EmployerQuery.myClass_Employer.EmployerHPID, myForm_EmployerQuery.myClass_Employer.Employer);
            }

        }

        private void textBox_KindofEmployer_DoubleClick(object sender, EventArgs e)
        {
            Form_KindofEmployerQuery myForm_KindofEmployerQuery = new Form_KindofEmployerQuery();
            myForm_KindofEmployerQuery.myClass_KindofEmployer = new Class_KindofEmployer();
            if (this.myClass_Issue .KindofEmployer  != null)
            {
                myForm_KindofEmployerQuery.myClass_KindofEmployer.KindofEmployer = this.myClass_Issue.KindofEmployer;
                myForm_KindofEmployerQuery.myClass_KindofEmployer.FillData();
            }
            if (myForm_KindofEmployerQuery.ShowDialog() == DialogResult.OK)
            {
                this.myClass_Issue.KindofEmployer = myForm_KindofEmployerQuery.myClass_KindofEmployer.KindofEmployer;
                this.textBox_KindofEmployer .Text =  myForm_KindofEmployerQuery.myClass_KindofEmployer.KindofEmployer;
            }

        }

    }
}
