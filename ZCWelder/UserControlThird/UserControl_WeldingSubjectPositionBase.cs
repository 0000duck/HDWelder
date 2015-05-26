using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WeldingSubjectPositionBase : UserControl
    {
        public Class_WeldingSubjectPosition myClass_WeldingSubjectPosition;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_WeldingSubjectPosition myClass_WeldingSubjectPositionDefault;

        public UserControl_WeldingSubjectPositionBase()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingSubjectPosition_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_WeldingSubjectPosition"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_WeldingSubjectPosition myClass_WeldingSubjectPosition, bool bool_Add)
        {
            this.myClass_WeldingSubjectPosition = myClass_WeldingSubjectPosition;
            this.MaskedTextBox_WeldingSubjectID.Text = this.myClass_WeldingSubjectPosition.SubjectID;
            Class_Public.InitializeComboBox(this.ComboBox_Assemblage, Enum_DataTable.Assemblage.ToString(), "Assemblage", "Assemblage");
            if (bool_Add)
            {
                if (myClass_WeldingSubjectPositionDefault != null)
                {
                    this.TextBox_WeldingPosition.Text = myClass_WeldingSubjectPositionDefault.WeldingPosition;
                    this.ComboBox_Assemblage.SelectedValue = myClass_WeldingSubjectPositionDefault.Assemblage;
                    this.TextBox_WeldingPositionContent.Text = myClass_WeldingSubjectPositionDefault.WeldingPositionContent;
                    this.TextBox_Thickness.Text = myClass_WeldingSubjectPositionDefault.Thickness.ToString();
                    this.TextBox_ExternalDiameter.Text = myClass_WeldingSubjectPositionDefault.ExternalDiameter.ToString();
                    this.TextBox_RenderWeldingRodDiameter.Text = myClass_WeldingSubjectPositionDefault.RenderWeldingRodDiameter.ToString();
                    this.TextBox_WeldingRodDiameter.Text = myClass_WeldingSubjectPositionDefault.WeldingRodDiameter.ToString();
                    this.TextBox_CoverWeldingRodDiameter.Text = myClass_WeldingSubjectPositionDefault.CoverWeldingRodDiameter.ToString();
                    this.CheckBox_FaceDT.Checked = myClass_WeldingSubjectPositionDefault.FaceDT;
                    this.CheckBox_RT.Checked = myClass_WeldingSubjectPositionDefault.RT;
                    this.CheckBox_UT.Checked = myClass_WeldingSubjectPositionDefault.UT;
                    this.CheckBox_BendDT.Checked = myClass_WeldingSubjectPositionDefault.BendDT;
                    this.CheckBox_DisjunctionDT.Checked = myClass_WeldingSubjectPositionDefault.DisjunctionDT;
                    this.CheckBox_MacroExamination.Checked = myClass_WeldingSubjectPositionDefault.MacroExamination;
                    this.CheckBox_OtherDT.Checked = myClass_WeldingSubjectPositionDefault.OtherDT;
                    this.TextBox_SubjectPositionRemark.Text = myClass_WeldingSubjectPositionDefault.SubjectPositionRemark;
                }
            }
            else
            {
                this.TextBox_WeldingPosition.ReadOnly = true ;
                this.TextBox_WeldingPosition.Text = this.myClass_WeldingSubjectPosition.WeldingPosition;
                this.ComboBox_Assemblage.SelectedValue = this.myClass_WeldingSubjectPosition.Assemblage;
                this.TextBox_WeldingPositionContent.Text = this.myClass_WeldingSubjectPosition.WeldingPositionContent;
                this.TextBox_Thickness.Text = this.myClass_WeldingSubjectPosition.Thickness.ToString();
                this.TextBox_ExternalDiameter.Text = this.myClass_WeldingSubjectPosition.ExternalDiameter.ToString();
                this.TextBox_RenderWeldingRodDiameter.Text = this.myClass_WeldingSubjectPosition.RenderWeldingRodDiameter.ToString();
                this.TextBox_WeldingRodDiameter.Text = this.myClass_WeldingSubjectPosition.WeldingRodDiameter.ToString();
                this.TextBox_CoverWeldingRodDiameter.Text = this.myClass_WeldingSubjectPosition.CoverWeldingRodDiameter.ToString();
                this.CheckBox_FaceDT.Checked = this.myClass_WeldingSubjectPosition.FaceDT;
                this.CheckBox_RT.Checked = this.myClass_WeldingSubjectPosition.RT;
                this.CheckBox_UT.Checked = this.myClass_WeldingSubjectPosition.UT;
                this.CheckBox_BendDT.Checked = this.myClass_WeldingSubjectPosition.BendDT;
                this.CheckBox_DisjunctionDT.Checked = this.myClass_WeldingSubjectPosition.DisjunctionDT;
                this.CheckBox_MacroExamination.Checked = this.myClass_WeldingSubjectPosition.MacroExamination;
                this.CheckBox_OtherDT.Checked = this.myClass_WeldingSubjectPosition.OtherDT;
                this.TextBox_SubjectPositionRemark.Text = this.myClass_WeldingSubjectPosition.SubjectPositionRemark;

            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            this.myClass_WeldingSubjectPosition.Assemblage = this.ComboBox_Assemblage.SelectedValue.ToString();
            this.myClass_WeldingSubjectPosition.WeldingPosition = this.TextBox_WeldingPosition.Text;
            this.myClass_WeldingSubjectPosition.WeldingPositionContent = this.TextBox_WeldingPositionContent.Text;
            double.TryParse(this.TextBox_Thickness.Text, out  this.myClass_WeldingSubjectPosition.Thickness);
            double.TryParse(this.TextBox_ExternalDiameter.Text, out  this.myClass_WeldingSubjectPosition.ExternalDiameter);
            double.TryParse(this.TextBox_RenderWeldingRodDiameter.Text, out  this.myClass_WeldingSubjectPosition.RenderWeldingRodDiameter);
            double.TryParse(this.TextBox_WeldingRodDiameter.Text, out  this.myClass_WeldingSubjectPosition.WeldingRodDiameter);
            double.TryParse(this.TextBox_CoverWeldingRodDiameter.Text, out  this.myClass_WeldingSubjectPosition.CoverWeldingRodDiameter);
            this.myClass_WeldingSubjectPosition.FaceDT = this.CheckBox_FaceDT.Checked;
            this.myClass_WeldingSubjectPosition.RT = this.CheckBox_RT.Checked;
            this.myClass_WeldingSubjectPosition.UT = this.CheckBox_UT.Checked;
            this.myClass_WeldingSubjectPosition.BendDT = this.CheckBox_BendDT.Checked;
            this.myClass_WeldingSubjectPosition.DisjunctionDT = this.CheckBox_DisjunctionDT.Checked;
            this.myClass_WeldingSubjectPosition.MacroExamination = this.CheckBox_MacroExamination.Checked;
            this.myClass_WeldingSubjectPosition.OtherDT = this.CheckBox_OtherDT.Checked;
            this.myClass_WeldingSubjectPosition.SubjectPositionRemark = this.TextBox_SubjectPositionRemark.Text;

            if (myClass_WeldingSubjectPositionDefault == null)
            {
                myClass_WeldingSubjectPositionDefault = new Class_WeldingSubjectPosition();
            }
            myClass_WeldingSubjectPositionDefault.Assemblage = myClass_WeldingSubjectPosition.Assemblage;
            myClass_WeldingSubjectPositionDefault.WeldingPosition = myClass_WeldingSubjectPosition.WeldingPosition;
            myClass_WeldingSubjectPositionDefault.WeldingPositionContent = myClass_WeldingSubjectPosition.WeldingPositionContent;
            myClass_WeldingSubjectPositionDefault.Thickness = myClass_WeldingSubjectPosition.Thickness;
            myClass_WeldingSubjectPositionDefault.ExternalDiameter = myClass_WeldingSubjectPosition.ExternalDiameter;
            myClass_WeldingSubjectPositionDefault.RenderWeldingRodDiameter = myClass_WeldingSubjectPosition.RenderWeldingRodDiameter;
            myClass_WeldingSubjectPositionDefault.WeldingRodDiameter = myClass_WeldingSubjectPosition.WeldingRodDiameter;
            myClass_WeldingSubjectPositionDefault.CoverWeldingRodDiameter = myClass_WeldingSubjectPosition.CoverWeldingRodDiameter;
            myClass_WeldingSubjectPositionDefault.FaceDT = myClass_WeldingSubjectPosition.FaceDT;
            myClass_WeldingSubjectPositionDefault.RT = myClass_WeldingSubjectPosition.RT;
            myClass_WeldingSubjectPositionDefault.UT = myClass_WeldingSubjectPosition.UT;
            myClass_WeldingSubjectPositionDefault.BendDT = myClass_WeldingSubjectPosition.BendDT;
            myClass_WeldingSubjectPositionDefault.DisjunctionDT = myClass_WeldingSubjectPosition.DisjunctionDT;
            myClass_WeldingSubjectPositionDefault.MacroExamination = myClass_WeldingSubjectPosition.MacroExamination;
            myClass_WeldingSubjectPositionDefault.OtherDT = myClass_WeldingSubjectPosition.OtherDT;
            myClass_WeldingSubjectPositionDefault.SubjectPositionRemark = myClass_WeldingSubjectPosition.SubjectPositionRemark;

        }

    }
}
