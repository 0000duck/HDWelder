using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_KindofExamBase : UserControl
    {
        public Class_KindofExam myClass_KindofExam;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_KindofExam myClass_KindofExamDefault;

        public UserControl_KindofExamBase()
        {
            InitializeComponent();
        }

        private void UserControl_KindofExam_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_KindofExam"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_KindofExam myClass_KindofExam, bool bool_Add)
        {
            this.myClass_KindofExam = myClass_KindofExam;
            if (bool_Add)
            {
                if (myClass_KindofExamDefault != null)
                {
                }
            }
            else
            {
                this.textBox_KindofExam.ReadOnly = true;
                this.textBox_KindofExam.Text = myClass_KindofExam.KindofExam;
                this.checkBox_TheoryResultNeed.Checked = myClass_KindofExam.TheoryResultNeed;
                this.checkBox_SkillResultNeed.Checked = myClass_KindofExam.SkillResultNeed;
                if (myClass_KindofExam.KindofExamIndex >= this.numericUpDown_KindofExamIndex.Minimum && myClass_KindofExam.KindofExamIndex <= this.numericUpDown_KindofExamIndex.Maximum)
                {
                    this.numericUpDown_KindofExamIndex.Value = myClass_KindofExam.KindofExamIndex;
                }
                if (myClass_KindofExam.PassScore >= this.numericUpDown_PassScore.Minimum && myClass_KindofExam.PassScore <= this.numericUpDown_PassScore.Maximum)
                {
                    this.numericUpDown_PassScore.Value = myClass_KindofExam.PassScore;
                }
                this.textBox_KindofExamRemark.Text = myClass_KindofExam.KindofExamRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_KindofExam.KindofExam = this.textBox_KindofExam.Text;
            myClass_KindofExam.TheoryResultNeed = this.checkBox_TheoryResultNeed.Checked;
            myClass_KindofExam.SkillResultNeed = this.checkBox_SkillResultNeed.Checked;
            myClass_KindofExam.PassScore = (int)this.numericUpDown_PassScore.Value;
            myClass_KindofExam.KindofExamIndex = (int)this.numericUpDown_KindofExamIndex.Value;
            myClass_KindofExam.KindofExamRemark = this.textBox_KindofExamRemark.Text;

            if (myClass_KindofExamDefault == null)
            {
                myClass_KindofExamDefault = new Class_KindofExam();
            }

        }

    }
}
