using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery ;
using ZCCL.DataGridViewManager;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_MaterialBase : UserControl
    {
        private Class_Material myClass_Material;
        static private Class_Material myClass_MaterialDefault;

        public UserControl_MaterialBase()
        {
            InitializeComponent();
        }

        private void UserControl_MaterialBase_Load(object sender, EventArgs e)
        {

        }

        public void InitControl(Class_Material myClass_Material, bool bool_Add)
        {
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingStandardAndGroup.ToString()];
            DataView myDataView_WeldingStandardAndGroup = new DataView(myClass_Data.myDataTable);
            myDataView_WeldingStandardAndGroup.RowFilter = "WeldingStandardGroup='金属材料标准'";
            Class_DataControlBind.InitializeComboBox(this.comboBox_MaterialDenominateWeldingStandard, myDataView_WeldingStandardAndGroup, "WeldingStandard", "WeldingStandard");
         
            this.myClass_Material = myClass_Material;

            if (bool_Add)
            {
                if (myClass_MaterialDefault != null)
                {
                }

            }
            else
            {
                 this.textBox_Material.ReadOnly = true;
                this.textBox_Material.Text = myClass_Material.Material ;
                this.textBox_MaterialGBName.Text = myClass_Material.MaterialGBName ;
                this.comboBox_MaterialDenominateWeldingStandard .SelectedValue  = myClass_Material.MaterialDenominateWeldingStandard  ;
                this.textBox_MaterialCCSGroupAb.Text = myClass_Material.MaterialCCSGroupAb;
                this.textBox_MaterialISOGroupAb.Text = myClass_Material.MaterialISOGroupAb;
                this.textBox_MaterialRemark.Text = myClass_Material.MaterialRemark ;
                this.numericUpDown_MaterialIndex.Value = myClass_Material.MaterialIndex;
           }

        }

        public void FillClass()
        {
            myClass_Material.Material=this.textBox_Material.Text ;
            myClass_Material.MaterialGBName=this.textBox_MaterialGBName.Text  ;
            myClass_Material.MaterialDenominateWeldingStandard =this.comboBox_MaterialDenominateWeldingStandard.Text  ;
            myClass_Material.MaterialCCSGroupAb = this.textBox_MaterialCCSGroupAb.Text;
            myClass_Material.MaterialISOGroupAb = this.textBox_MaterialISOGroupAb.Text;
            myClass_Material.MaterialRemark=this.textBox_MaterialRemark.Text  ;
            myClass_Material.MaterialIndex=(int)this.numericUpDown_MaterialIndex.Value ;
            if (myClass_MaterialDefault == null)
            {
                myClass_MaterialDefault = new Class_Material();
            }
        }

        private void textBox_MaterialCCSGroupAb_DoubleClick(object sender, EventArgs e)
        {
            Form_MaterialCCSGroupQuery myForm = new Form_MaterialCCSGroupQuery();
            myForm.myClass_MaterialCCSGroup = new Class_MaterialCCSGroup();
            if (this.myClass_Material.MaterialCCSGroupAb != null)
            {
                myForm.myClass_MaterialCCSGroup.MaterialCCSGroupAb = this.myClass_Material .MaterialCCSGroupAb;
                myForm.myClass_MaterialCCSGroup.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_Material.MaterialCCSGroupAb = myForm.myClass_MaterialCCSGroup.MaterialCCSGroupAb;
                this.textBox_MaterialCCSGroupAb.Text = string.Format("{0}", myForm.myClass_MaterialCCSGroup.MaterialCCSGroupAb);
            }

        }

        private void textBox_MaterialISOGroupAb_DoubleClick(object sender, EventArgs e)
        {
            Form_MaterialISOGroupQuery myForm = new Form_MaterialISOGroupQuery();
            myForm.myClass_MaterialISOGroup = new Class_MaterialISOGroup();
            if (this.myClass_Material.MaterialISOGroupAb != null)
            {
                myForm.myClass_MaterialISOGroup.MaterialISOGroupAb = this.myClass_Material.MaterialISOGroupAb;
                myForm.myClass_MaterialISOGroup.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_Material.MaterialISOGroupAb = myForm.myClass_MaterialISOGroup.MaterialISOGroupAb;
                this.textBox_MaterialISOGroupAb.Text = string.Format("{0}", myForm.myClass_MaterialISOGroup.MaterialISOGroupAb);
            }

        }

    }
}
