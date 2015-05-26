using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_SchoolingBase : UserControl
    {
        private Class_Schooling myClass_Schooling;
        
        public UserControl_SchoolingBase()
        {
            InitializeComponent();
        }

        private void UserControl_SchoolingBase_Load(object sender, EventArgs e)
        {

        }

        public void InitControl(Class_Schooling myClass_Schooling, bool bool_Add)
        {
            this.myClass_Schooling = myClass_Schooling;
            if (bool_Add == false)
            {
                this.textBox_Schooling.Text = myClass_Schooling.Schooling;
                this.numericUpDown_SchoolingIndex.Value = myClass_Schooling.SchoolingIndex;
                this.textBox_SchoolingRemark.Text = myClass_Schooling.SchoolingRemark;
                this.textBox_Schooling.ReadOnly = true;
            }
            else
            {
            }

        }

        public void FillClass()
        {
            myClass_Schooling.Schooling = this.textBox_Schooling.Text;
            myClass_Schooling.SchoolingIndex = (int)this.numericUpDown_SchoolingIndex.Value;
            myClass_Schooling.SchoolingRemark = this.textBox_SchoolingRemark.Text;

        }

    }
}
