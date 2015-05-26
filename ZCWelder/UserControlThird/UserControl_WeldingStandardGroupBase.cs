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
    public partial class UserControl_WeldingStandardGroupBase : UserControl
    {
        private Class_WeldingStandardGroup myClass_WeldingStandardGroup;
        
        public UserControl_WeldingStandardGroupBase()
        {
            InitializeComponent();
        }


        public void InitControl(Class_WeldingStandardGroup myClass_WeldingStandardGroup, bool bool_Add)
        {
            this.myClass_WeldingStandardGroup = myClass_WeldingStandardGroup;

            if (bool_Add == false)
            {
                this.textBox_WeldingStandardGroup.ReadOnly = true;
                this.textBox_WeldingStandardGroup.Text = myClass_WeldingStandardGroup.WeldingStandardGroup;
                this.textBox_WeldingStandardGroupRemark.Text = myClass_WeldingStandardGroup.WeldingStandardGroupRemark;
                this.numericUpDown_WeldingStandardGroupIndex.Value = myClass_WeldingStandardGroup.WeldingStandardGroupIndex;
            }
            else
            {
            }

        }

        public void FillClass()
        {
            myClass_WeldingStandardGroup.WeldingStandardGroup = this.textBox_WeldingStandardGroup.Text;
            myClass_WeldingStandardGroup.WeldingStandardGroupRemark = this.textBox_WeldingStandardGroupRemark.Text;
            myClass_WeldingStandardGroup.WeldingStandardGroupIndex = (int)this.numericUpDown_WeldingStandardGroupIndex.Value;
        }

    }
}
