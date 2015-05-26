using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ParameterQuery;
using ZCWelder.ClassBase ;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WeldingStandardAndGroupBase : UserControl
    {
        public  Class_WeldingStandardAndGroup myClass_WeldingStandardAndGroup;
        public bool bool_Add;
        
        public UserControl_WeldingStandardAndGroupBase()
        {
            InitializeComponent();
        }

        public void InitControl(Class_WeldingStandardAndGroup myClass_WeldingStandardAndGroup, bool bool_Add)
        {
            this.myClass_WeldingStandardAndGroup = myClass_WeldingStandardAndGroup;
            this.bool_Add = bool_Add;
            if (bool_Add == false)
            {
                this.button_WeldingStandardQuery.Visible = false;
                this.button_WeldingStandardGroupQuery .Visible = false;
                Class_WeldingStandardGroup myClass_WeldingStandardGroup = new Class_WeldingStandardGroup(this.myClass_WeldingStandardAndGroup.WeldingStandardGroup);
                this.textBox_WeldingStandardGroup.Text= string.Format("{0}", myClass_WeldingStandardGroup.WeldingStandardGroup);
                this.textBox_WeldingStandardGroupRemark .Text = string.Format("{0}", myClass_WeldingStandardGroup.WeldingStandardGroupRemark );
               
                Class_WeldingStandard myClass_WeldingStandard = new Class_WeldingStandard(this.myClass_WeldingStandardAndGroup.WeldingStandard);
                this.textBox_WeldingStandard.Text = string.Format("{0}", myClass_WeldingStandard.WeldingStandard);
                this.textBox_WeldingStandardRemark.Text = string.Format("{0}", myClass_WeldingStandard.WeldingStandardRemark);
                this.textBox_WeldingStandardTitle.Text = string.Format("{0}", myClass_WeldingStandard.WeldingStandardTitle);
            }
            else
            {
            }

        }

        private void button_WeldingStandardGroupQuery_Click(object sender, EventArgs e)
        {
            Form_WeldingStandardGroupQuery myForm = new Form_WeldingStandardGroupQuery();
            if (this.myClass_WeldingStandardAndGroup .WeldingStandardGroup  != null)
            {
                myForm.myClass_WeldingStandardGroup = new Class_WeldingStandardGroup(this.myClass_WeldingStandardAndGroup.WeldingStandardGroup);
            }
            else
            {
                myForm.myClass_WeldingStandardGroup = new Class_WeldingStandardGroup();
            }

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_WeldingStandardAndGroup.WeldingStandardGroup = myForm.myClass_WeldingStandardGroup.WeldingStandardGroup;
                this.textBox_WeldingStandardGroup.Text= string.Format("{0}", myForm.myClass_WeldingStandardGroup.WeldingStandardGroup);
                this.textBox_WeldingStandardGroupRemark .Text = string.Format("{0}", myForm.myClass_WeldingStandardGroup.WeldingStandardGroupRemark );
            }

        }

        private void button_WeldingStandardQuery_Click(object sender, EventArgs e)
        {
            Form_WeldingStandardQuery myForm = new Form_WeldingStandardQuery();
            if (this.myClass_WeldingStandardAndGroup .WeldingStandard  != null)
            {
                myForm.myClass_WeldingStandard = new Class_WeldingStandard(this.myClass_WeldingStandardAndGroup.WeldingStandard);
            }
            else
            {
                myForm.myClass_WeldingStandard = new Class_WeldingStandard();
            }

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_WeldingStandardAndGroup.WeldingStandard = myForm.myClass_WeldingStandard.WeldingStandard;
                this.textBox_WeldingStandard.Text = string.Format("{0}", myForm.myClass_WeldingStandard.WeldingStandard);
                this.textBox_WeldingStandardRemark .Text= string.Format("{0}", myForm.myClass_WeldingStandard.WeldingStandardRemark );
                this.textBox_WeldingStandardTitle.Text = string.Format("{0}", myForm.myClass_WeldingStandard.WeldingStandardTitle);
            }

        }

        public void FillClass()
        {
            this.myClass_WeldingStandardAndGroup.WeldingStandardAndGroupIndex = (int)this.numericUpDown_WeldingStandardAndGroupIndex.Value;
            this.myClass_WeldingStandardAndGroup.WeldingStandardAndGroupRemark = this.textBox_WeldingStandardAndGroupRemark.Text;
        }

    }
}
