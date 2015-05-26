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
    public partial class UserControl_WeldingEquipmentBase : UserControl
    {
        private Class_WeldingEquipment myClass_WeldingEquipment;
        
        public UserControl_WeldingEquipmentBase()
        {
            InitializeComponent();
        }

        public void InitControl(Class_WeldingEquipment myClass_WeldingEquipment, bool bool_Add)
        {
            this.myClass_WeldingEquipment = myClass_WeldingEquipment;

            if (bool_Add == false)
            {
                this.textBox_WeldingEquipment.ReadOnly = true;
                this.textBox_WeldingEquipment.Text = myClass_WeldingEquipment.WeldingEquipment;
                this.textBox_WeldingEquipmentRemark.Text = myClass_WeldingEquipment.WeldingEquipmentRemark;
                this.numericUpDown_WeldingEquipmentIndex.Value = myClass_WeldingEquipment.WeldingEquipmentIndex;
            }
            else
            {
            }

        }

        public void FillClass()
        {
            myClass_WeldingEquipment.WeldingEquipment = this.textBox_WeldingEquipment.Text;
            myClass_WeldingEquipment.WeldingEquipmentRemark = this.textBox_WeldingEquipmentRemark.Text;
            myClass_WeldingEquipment.WeldingEquipmentIndex = (int)this.numericUpDown_WeldingEquipmentIndex.Value;
        }

    }
}
