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
    public partial class UserControl_WeldingSubjectBase : UserControl
    {
        public Class_WeldingSubject myClass_WeldingSubject;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_WeldingSubject myClass_WeldingSubjectDefault;

        public UserControl_WeldingSubjectBase()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingSubject_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_WeldingSubject"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_WeldingSubject myClass_WeldingSubject, bool bool_Add)
        {
            DataView myDataView_WeldingStandard = new DataView(((Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingStandardAndGroup.ToString()]).myDataTable);
            myDataView_WeldingStandard.RowFilter = "WeldingStandardGroup='焊工考试标准'";
            Class_DataControlBind.InitializeComboBox(this.ComboBox_WeldingStandard, myDataView_WeldingStandard, "WeldingStandard", "WeldingStandard");
            Class_Public.InitializeComboBox(this.ComboBox_JointType, Enum_DataTable.JointType.ToString(), "JointType", "JointType");
            Class_Public.InitializeComboBox(this.ComboBox_WorkPieceType, Enum_DataTable.WorkPieceType.ToString(), "WorkPieceType", "WorkPieceType");
            this.ComboBox_SubjectClass.Text = "0";

            this.myClass_WeldingSubject = myClass_WeldingSubject;
            if (bool_Add)
            {
                if (myClass_WeldingSubjectDefault != null)
                {
                    this.MaskedTextBox_SubjectID.Text = myClass_WeldingSubjectDefault.SubjectID ;
                    this.ComboBox_WeldingStandard.SelectedValue = myClass_WeldingSubjectDefault.WeldingStandard;
                    this.ComboBox_JointType.SelectedValue = myClass_WeldingSubjectDefault.JointType;
                    this.ComboBox_WorkPieceType.SelectedValue = myClass_WeldingSubjectDefault.WorkPieceType;
                    this.TextBox_WeldingProject.Text = myClass_WeldingSubjectDefault.WeldingProject;
                    this.TextBox_WeldingProjectAb.Text = myClass_WeldingSubjectDefault.WeldingProjectAb;
                    this.TextBox_ScopeofWeldingProject.Text = myClass_WeldingSubjectDefault.ScopeofWeldingProject;
                    this.TextBox_WeldingClass.Text = myClass_WeldingSubjectDefault.WeldingClass;
                    this.TextBox_WeldingClassAb.Text = myClass_WeldingSubjectDefault.WeldingClassAb;
                    this.TextBox_ScopeofWeldingClass.Text = myClass_WeldingSubjectDefault.ScopeofWeldingClass;
                    this.ComboBox_SubjectClass.Text = myClass_WeldingSubjectDefault.SubjectClass.ToString();
                    this.TextBox_Subject.Text = myClass_WeldingSubjectDefault.Subject;
                    this.TextBox_ScopeofSubject.Text = myClass_WeldingSubjectDefault.ScopeofSubject;
                    this.TextBox_SubjectThickness.Text = myClass_WeldingSubjectDefault.SubjectThickness;
                    this.TextBox_SubjectExternalDiameter.Text = myClass_WeldingSubjectDefault.SubjectExternalDiameter;
                    this.textBox_HardestWeldingPosition.Text = myClass_WeldingSubjectDefault.HardestWeldingPosition;
                }
                if (!string.IsNullOrEmpty(myClass_WeldingSubject.WeldingStandard))
                {
                    this.ComboBox_WeldingStandard.SelectedValue = myClass_WeldingSubject.WeldingStandard;
                }
            }
            else
            {                
                this.MaskedTextBox_SubjectID.ReadOnly = true;
                this.MaskedTextBox_SubjectID.Text = this.myClass_WeldingSubject.SubjectID;
                this.checkBox_NeedPreSubject.Checked = this.myClass_WeldingSubject.NeedPreSubject;
                this.ComboBox_WeldingStandard.SelectedValue = this.myClass_WeldingSubject.WeldingStandard;
                this.ComboBox_JointType.SelectedValue = this.myClass_WeldingSubject.JointType;
                this.ComboBox_WorkPieceType.SelectedValue = this.myClass_WeldingSubject.WorkPieceType;
                this.TextBox_WeldingProject.Text = this.myClass_WeldingSubject.WeldingProject;
                this.TextBox_WeldingProjectAb.Text = this.myClass_WeldingSubject.WeldingProjectAb;
                this.TextBox_ScopeofWeldingProject.Text = this.myClass_WeldingSubject.ScopeofWeldingProject;
                this.TextBox_WeldingClass.Text = this.myClass_WeldingSubject.WeldingClass;
                this.TextBox_WeldingClassAb.Text = this.myClass_WeldingSubject.WeldingClassAb;
                this.TextBox_ScopeofWeldingClass.Text = this.myClass_WeldingSubject.ScopeofWeldingClass;
                this.ComboBox_SubjectClass.Text = this.myClass_WeldingSubject.SubjectClass.ToString();
                this.TextBox_Subject.Text = this.myClass_WeldingSubject.Subject;
                this.TextBox_ScopeofSubject.Text = this.myClass_WeldingSubject.ScopeofSubject;
                this.TextBox_SubjectThickness.Text = this.myClass_WeldingSubject.SubjectThickness;
                this.TextBox_SubjectExternalDiameter.Text = this.myClass_WeldingSubject.SubjectExternalDiameter;
                this.TextBox_SubjectRemark.Text = this.myClass_WeldingSubject.SubjectRemark;
                this.textBox_CCSSubject.Text = this.myClass_WeldingSubject.CCSSubject;
                this.textBox_CCSSubjectTestNo.Text = this.myClass_WeldingSubject.CCSSubjectTestNo;
                this.textBox_HardestWeldingPosition.Text = this.myClass_WeldingSubject.HardestWeldingPosition;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            this.myClass_WeldingSubject.SubjectID = this.MaskedTextBox_SubjectID.Text;
            this.myClass_WeldingSubject.NeedPreSubject = this.checkBox_NeedPreSubject.Checked;
            this.myClass_WeldingSubject.WeldingStandard = this.ComboBox_WeldingStandard.SelectedValue.ToString();
            this.myClass_WeldingSubject.JointType = this.ComboBox_JointType.SelectedValue.ToString();
            this.myClass_WeldingSubject.WorkPieceType = this.ComboBox_WorkPieceType.SelectedValue.ToString();
            this.myClass_WeldingSubject.WeldingProject = this.TextBox_WeldingProject.Text;
            this.myClass_WeldingSubject.WeldingProjectAb = this.TextBox_WeldingProjectAb.Text;
            this.myClass_WeldingSubject.ScopeofWeldingProject = this.TextBox_ScopeofWeldingProject.Text;
            this.myClass_WeldingSubject.WeldingClass = this.TextBox_WeldingClass.Text;
            this.myClass_WeldingSubject.WeldingClassAb = this.TextBox_WeldingClassAb.Text;
            this.myClass_WeldingSubject.ScopeofWeldingClass = this.TextBox_ScopeofWeldingClass.Text;
            int.TryParse(this.ComboBox_SubjectClass.Text, out this.myClass_WeldingSubject.SubjectClass);
            this.myClass_WeldingSubject.Subject = this.TextBox_Subject.Text;
            this.myClass_WeldingSubject.ScopeofSubject = this.TextBox_ScopeofSubject.Text;
            this.myClass_WeldingSubject.SubjectThickness = this.TextBox_SubjectThickness.Text;
            this.myClass_WeldingSubject.SubjectExternalDiameter = this.TextBox_SubjectExternalDiameter.Text;
            this.myClass_WeldingSubject.SubjectRemark = this.TextBox_SubjectRemark.Text;
            this.myClass_WeldingSubject.CCSSubject = this.textBox_CCSSubject.Text;
            this.myClass_WeldingSubject.CCSSubjectTestNo = this.textBox_CCSSubjectTestNo.Text;
            this.myClass_WeldingSubject.HardestWeldingPosition = this.textBox_HardestWeldingPosition.Text;

            if (myClass_WeldingSubjectDefault == null)
            {
                myClass_WeldingSubjectDefault = new Class_WeldingSubject();
            }
            myClass_WeldingSubjectDefault.SubjectID = myClass_WeldingSubject.SubjectID;
            myClass_WeldingSubjectDefault.WeldingStandard = myClass_WeldingSubject.WeldingStandard;
            myClass_WeldingSubjectDefault.JointType = myClass_WeldingSubject.JointType;
            myClass_WeldingSubjectDefault.WorkPieceType = myClass_WeldingSubject.WorkPieceType;
            myClass_WeldingSubjectDefault.WeldingProject = myClass_WeldingSubject.WeldingProject;
            myClass_WeldingSubjectDefault.WeldingProjectAb = myClass_WeldingSubject.WeldingProjectAb;
            myClass_WeldingSubjectDefault.ScopeofWeldingProject = myClass_WeldingSubject.ScopeofWeldingProject;
            myClass_WeldingSubjectDefault.WeldingClass = myClass_WeldingSubject.WeldingClass;
            myClass_WeldingSubjectDefault.WeldingClassAb = myClass_WeldingSubject.WeldingClassAb;
            myClass_WeldingSubjectDefault.ScopeofWeldingClass = myClass_WeldingSubject.ScopeofWeldingClass;
            myClass_WeldingSubjectDefault.SubjectClass = myClass_WeldingSubject.SubjectClass;
            myClass_WeldingSubjectDefault.Subject = myClass_WeldingSubject.Subject;
            myClass_WeldingSubjectDefault.ScopeofSubject = myClass_WeldingSubject.ScopeofSubject;
            myClass_WeldingSubjectDefault.SubjectThickness = myClass_WeldingSubject.SubjectThickness;
            myClass_WeldingSubjectDefault.SubjectExternalDiameter = myClass_WeldingSubject.SubjectExternalDiameter;
            myClass_WeldingSubjectDefault.SubjectRemark = myClass_WeldingSubject.SubjectRemark;
            myClass_WeldingSubjectDefault.HardestWeldingPosition = myClass_WeldingSubject.HardestWeldingPosition;

        }

    }
}
