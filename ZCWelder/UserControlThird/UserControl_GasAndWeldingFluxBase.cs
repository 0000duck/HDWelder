using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_GasAndWeldingFluxBase : UserControl
    {
        private Class_GasAndWeldingFlux myClass_GasAndWeldingFlux;

        public UserControl_GasAndWeldingFluxBase()
        {
            InitializeComponent();
        }

        private void UserControl_GasAndWeldingFluxBase_Load(object sender, EventArgs e)
        {
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.GasAndWeldingFluxGroup.ToString()];
            Class_DataControlBind.InitializeComboBox(this.comboBox_GasAndWeldingFluxGroup, myClass_Data.myDataView, "GasAndWeldingFluxGroup", "GasAndWeldingFluxGroup");

        }

        public void InitControl(Class_GasAndWeldingFlux myClass_GasAndWeldingFlux, bool bool_Add)
        {
            this.myClass_GasAndWeldingFlux = myClass_GasAndWeldingFlux;

            if (bool_Add == false)
            {
                this.textBox_GasAndWeldingFlux.ReadOnly = true;
                this.textBox_GasAndWeldingFlux.Text = myClass_GasAndWeldingFlux.GasAndWeldingFlux;
                this.textBox_GasAndWeldingFluxParameter .Text = myClass_GasAndWeldingFlux.GasAndWeldingFluxParameter ;
                this.comboBox_GasAndWeldingFluxGroup.SelectedValue  = myClass_GasAndWeldingFlux.GasAndWeldingFluxGroup ;
                this.textBox_GasAndWeldingFluxRemark.Text = myClass_GasAndWeldingFlux.GasAndWeldingFluxRemark;
                this.numericUpDown_GasAndWeldingFluxIndex.Value = myClass_GasAndWeldingFlux.GasAndWeldingFluxIndex;
            }
            else
            {
            }

        }

        public void FillClass()
        {
            myClass_GasAndWeldingFlux.GasAndWeldingFlux = this.textBox_GasAndWeldingFlux.Text;
            myClass_GasAndWeldingFlux.GasAndWeldingFluxParameter = this.textBox_GasAndWeldingFluxParameter.Text;
            myClass_GasAndWeldingFlux.GasAndWeldingFluxGroup = this.comboBox_GasAndWeldingFluxGroup.SelectedValue.ToString();
            myClass_GasAndWeldingFlux.GasAndWeldingFluxRemark = this.textBox_GasAndWeldingFluxRemark.Text;
            myClass_GasAndWeldingFlux.GasAndWeldingFluxIndex = (int)this.numericUpDown_GasAndWeldingFluxIndex.Value;
        }

    }
}
