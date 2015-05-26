using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using System.IO;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WeldingStandardBase : UserControl
    {
        private Class_WeldingStandard myClass_WeldingStandard;
        
        public UserControl_WeldingStandardBase()
        {
            InitializeComponent();
        }

        public void InitControl(Class_WeldingStandard myClass_WeldingStandard, bool bool_Add)
        {
            this.myClass_WeldingStandard = myClass_WeldingStandard;

            if (bool_Add == false)
            {
                this.textBox_WeldingStandard.ReadOnly = true;
                this.textBox_WeldingStandard.Text = myClass_WeldingStandard.WeldingStandard;
                this.textBox_WeldingStandardTitle .Text = myClass_WeldingStandard.WeldingStandardTitle ;
                this.textBox_WeldingStandardRemark.Text = myClass_WeldingStandard.WeldingStandardRemark;
                this.numericUpDown_WeldingStandardIndex.Value = myClass_WeldingStandard.WeldingStandardIndex;
            }
            else
            {
            }

        }

        public void FillClass()
        {
            myClass_WeldingStandard.WeldingStandard = this.textBox_WeldingStandard.Text;
            myClass_WeldingStandard.WeldingStandardTitle  = this.textBox_WeldingStandardTitle .Text;
            myClass_WeldingStandard.WeldingStandardRemark = this.textBox_WeldingStandardRemark.Text;
            myClass_WeldingStandard.WeldingStandardIndex = (int)this.numericUpDown_WeldingStandardIndex.Value;

        }

    }
}
