using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery;
using ZCCL.DataGridViewManager;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WeldingConsumableBase : UserControl
    {
        private Class_WeldingConsumable myClass_WeldingConsumable;
        static private Class_WeldingConsumable myClass_WeldingConsumableDefault;

        public UserControl_WeldingConsumableBase()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingConsumableBase_Load(object sender, EventArgs e)
        {

        }

        public void InitControl(Class_WeldingConsumable myClass_WeldingConsumable, bool bool_Add)
        {
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingStandardAndGroup.ToString()];
            DataView myDataView_WeldingStandardAndGroup = new DataView(myClass_Data.myDataTable);
            myDataView_WeldingStandardAndGroup.RowFilter = "WeldingStandardGroup='焊接材料标准'";
            Class_DataControlBind.InitializeComboBox(this.comboBox_WeldingConsumableDenominateWeldingStandard, myDataView_WeldingStandardAndGroup, "WeldingStandard", "WeldingStandard");

            this.myClass_WeldingConsumable = myClass_WeldingConsumable;

            if (bool_Add)
            {
                if (myClass_WeldingConsumableDefault != null)
                {
                }

            }
            else
            {
                this.textBox_WeldingConsumable.ReadOnly = true;
                this.textBox_WeldingConsumable.Text = myClass_WeldingConsumable.WeldingConsumable;
                this.textBox_WeldingConsumableGBName.Text = myClass_WeldingConsumable.WeldingConsumableGBName;
                this.textBox_WeldingConsumableAWSName.Text = myClass_WeldingConsumable.WeldingConsumableAWSName;
                this.comboBox_WeldingConsumableDenominateWeldingStandard.SelectedValue = myClass_WeldingConsumable.WeldingConsumableDenominateWeldingStandard;
                this.textBox_WeldingConsumableCCSGroupAb.Text = myClass_WeldingConsumable.WeldingConsumableCCSGroupAb;
                this.textBox_WeldingConsumableISOGroupAb.Text = myClass_WeldingConsumable.WeldingConsumableISOGroupAb;
                this.textBox_WeldingConsumableRemark.Text = myClass_WeldingConsumable.WeldingConsumableRemark;
                this.numericUpDown_WeldingConsumableIndex.Value = myClass_WeldingConsumable.WeldingConsumableIndex;
            }

        }

        public void FillClass()
        {
            myClass_WeldingConsumable.WeldingConsumable = this.textBox_WeldingConsumable.Text;
            myClass_WeldingConsumable.WeldingConsumableGBName = this.textBox_WeldingConsumableGBName.Text;
            myClass_WeldingConsumable.WeldingConsumableAWSName = this.textBox_WeldingConsumableAWSName.Text;
            myClass_WeldingConsumable.WeldingConsumableDenominateWeldingStandard = this.comboBox_WeldingConsumableDenominateWeldingStandard.Text;
            myClass_WeldingConsumable.WeldingConsumableCCSGroupAb = this.textBox_WeldingConsumableCCSGroupAb.Text;
            myClass_WeldingConsumable.WeldingConsumableISOGroupAb = this.textBox_WeldingConsumableISOGroupAb.Text;
            myClass_WeldingConsumable.WeldingConsumableRemark = this.textBox_WeldingConsumableRemark.Text;
            myClass_WeldingConsumable.WeldingConsumableIndex = (int)this.numericUpDown_WeldingConsumableIndex.Value;
            if (myClass_WeldingConsumableDefault == null)
            {
                myClass_WeldingConsumableDefault = new Class_WeldingConsumable();
            }
        }

        private void textBox_WeldingConsumableCCSGroupAb_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingConsumableCCSGroupQuery myForm = new Form_WeldingConsumableCCSGroupQuery();
            myForm.myClass_WeldingConsumableCCSGroup = new Class_WeldingConsumableCCSGroup();
            if (this.myClass_WeldingConsumable.WeldingConsumableCCSGroupAb != null)
            {
                myForm.myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupAb = this.myClass_WeldingConsumable.WeldingConsumableCCSGroupAb;
                myForm.myClass_WeldingConsumableCCSGroup.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_WeldingConsumable.WeldingConsumableCCSGroupAb = myForm.myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupAb;
                this.textBox_WeldingConsumableCCSGroupAb.Text = string.Format("{0}", myForm.myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupAb);
            }

        }

        private void textBox_WeldingConsumableISOGroupAb_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingConsumableISOGroupQuery myForm = new Form_WeldingConsumableISOGroupQuery();
            myForm.myClass_WeldingConsumableISOGroup = new Class_WeldingConsumableISOGroup();
            if (this.myClass_WeldingConsumable.WeldingConsumableISOGroupAb != null)
            {
                myForm.myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupAb = this.myClass_WeldingConsumable.WeldingConsumableISOGroupAb;
                myForm.myClass_WeldingConsumableISOGroup.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_WeldingConsumable.WeldingConsumableISOGroupAb = myForm.myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupAb;
                this.textBox_WeldingConsumableISOGroupAb.Text = string.Format("{0}", myForm.myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupAb);
            }

        }

    }
}
