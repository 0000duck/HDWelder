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

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WeldingSubjectApplicable_Base : UserControl
    {
        public Class_WeldingSubjectApplicable myClass_WeldingSubjectApplicable;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_WeldingSubjectApplicable myClass_WeldingSubjectApplicableDefault;

        public UserControl_WeldingSubjectApplicable_Base()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingSubjectApplicable_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_WeldingSubjectApplicable"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_WeldingSubjectApplicable myClass_WeldingSubjectApplicable, bool bool_Add)
        {
            this.myClass_WeldingSubjectApplicable = myClass_WeldingSubjectApplicable;
            if (bool_Add)
            {
                if (myClass_WeldingSubjectApplicableDefault != null)
                {
                }
                if (!string.IsNullOrEmpty(this.myClass_WeldingSubjectApplicable.SubjectID))
                {
                    this.InitControlWeldingSubject(new Class_WeldingSubject(this.myClass_WeldingSubjectApplicable.SubjectID), false);
                    this.Button_SubjectQuery.Visible = false;
                }
            }
            else
            {
                this.Button_SubjectQuery.Visible = false;
                this.Button_SubjectQueryApplicable.Visible = false;
                this.InitControlWeldingSubject(new Class_WeldingSubject(this.myClass_WeldingSubjectApplicable.SubjectID), false);
                this.InitControlWeldingSubject(new Class_WeldingSubject(this.myClass_WeldingSubjectApplicable.ApplicableSubjectID ), true );
                if (myClass_WeldingSubjectApplicable.PreIntervalMonth >= this.numericUpDown_PreIntervalMonth.Minimum && myClass_WeldingSubjectApplicable.PreIntervalMonth <= this.numericUpDown_PreIntervalMonth.Maximum)
                {
                    this.numericUpDown_PreIntervalMonth.Value = myClass_WeldingSubjectApplicable.PreIntervalMonth;
                }
                if (myClass_WeldingSubjectApplicable.ApplicableSubjectIndex >= this.numericUpDown_ApplicableSubjectIndex.Minimum && myClass_WeldingSubjectApplicable.ApplicableSubjectIndex  <= this.numericUpDown_ApplicableSubjectIndex.Maximum)
                {
                    this.numericUpDown_ApplicableSubjectIndex.Value = myClass_WeldingSubjectApplicable.ApplicableSubjectIndex;
                }
                this.textBox_ApplicableSubjectRemark.Text = myClass_WeldingSubjectApplicable.ApplicableSubjectRemark ;
            }

        }

        private void  InitControlWeldingSubject(Class_WeldingSubject  myClass_Subject , bool bool_Applicable)
        {
            if (bool_Applicable)
            {
                this.TextBox_WeldingStandardApplicable.Text = myClass_Subject.WeldingStandard;
                this.TextBox_WeldingProjectApplicable.Text = myClass_Subject.WeldingProject;
                this.TextBox_WeldingClassApplicable.Text = myClass_Subject.WeldingClass;
                this.TextBox_WorkPieceTypeApplicable.Text = myClass_Subject.WorkPieceType;
                this.TextBox_JointTypeApplicable.Text = myClass_Subject.JointType;
                this.TextBox_SubjectApplicable.Text = myClass_Subject.Subject;
                this.TextBox_SubjectIDApplicable.Text = myClass_Subject.SubjectID;
                this.TextBox_SubjectRemarkApplicable.Text = myClass_Subject.SubjectRemark;
            }
            else
            {
                this.TextBox_WeldingStandard.Text = myClass_Subject.WeldingStandard;
                this.TextBox_WeldingProject.Text = myClass_Subject.WeldingProject;
                this.TextBox_WeldingClass.Text = myClass_Subject.WeldingClass;
                this.TextBox_WorkPieceType.Text = myClass_Subject.WorkPieceType;
                this.TextBox_JointType.Text = myClass_Subject.JointType;
                this.TextBox_Subject.Text = myClass_Subject.Subject;
                this.TextBox_SubjectID.Text = myClass_Subject.SubjectID;
                this.TextBox_SubjectRemark.Text = myClass_Subject.SubjectRemark;
            }
        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_WeldingSubjectApplicable.SubjectID  = this.TextBox_SubjectID .Text;
            myClass_WeldingSubjectApplicable.ApplicableSubjectID   = this.TextBox_SubjectIDApplicable .Text;
            myClass_WeldingSubjectApplicable.PreIntervalMonth   = (int)this.numericUpDown_PreIntervalMonth.Value;
            myClass_WeldingSubjectApplicable.ApplicableSubjectIndex  = (int)this.numericUpDown_ApplicableSubjectIndex.Value;
            myClass_WeldingSubjectApplicable.ApplicableSubjectRemark = this.textBox_ApplicableSubjectRemark.Text;

            if (myClass_WeldingSubjectApplicableDefault == null)
            {
                myClass_WeldingSubjectApplicableDefault = new Class_WeldingSubjectApplicable();
            }

        }

        private void Button_SubjectQuery_Click(object sender, EventArgs e)
        {
            Form_WeldingSubject_Query myForm = new Form_WeldingSubject_Query();
            myForm.myClass_WeldingSubject = new Class_WeldingSubject();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.InitControlWeldingSubject(myForm.myClass_WeldingSubject, false);
            }

        }

        private void Button_SubjectQueryApplicable_Click(object sender, EventArgs e)
        {
            Form_WeldingSubject_Query myForm = new Form_WeldingSubject_Query();
            myForm.myClass_WeldingSubject = new Class_WeldingSubject();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.InitControlWeldingSubject(myForm.myClass_WeldingSubject, true);
            }

        }

    }
}
