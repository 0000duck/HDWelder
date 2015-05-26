using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.AspNet;
using ZCCL.Report;
using ZCWelder.ParameterQuery;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WPSGasAndWeldingFluxBase : UserControl
    {
        public Class_WPSGasAndWeldingFlux myClass_WPSGasAndWeldingFlux;
        
        public UserControl_WPSGasAndWeldingFluxBase()
        {
            InitializeComponent();
        }

        private void UserControl_WPSGasAndWeldingFluxBase_Load(object sender, EventArgs e)
        {
            this.textBox_WPSGasAndWeldingFlux .BackColor = Properties.Settings.Default.textBoxDoubleClickColor;

        }

        public void InitControl(Class_WPSGasAndWeldingFlux myClass_WPSGasAndWeldingFlux, bool bool_Add)
        {
            this.myClass_WPSGasAndWeldingFlux = myClass_WPSGasAndWeldingFlux;
            this.textBox_WPSID.Text = myClass_WPSGasAndWeldingFlux.WPSID;
            if (bool_Add == false)
            {
                this.textBox_WPSGasAndWeldingFluxID.Text = string.Format("{0}", myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFluxID);
                this.textBox_WPSGasAndWeldingFluxRemark.Text = myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFluxRemark;
                Class_GasAndWeldingFlux myClass_GasAndWeldingFlux=new Class_GasAndWeldingFlux(myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFlux);
                this.textBox_WPSGasAndWeldingFluxGroup.Text  = myClass_GasAndWeldingFlux.GasAndWeldingFluxGroup;
                this.textBox_WPSGasAndWeldingFluxParameter.Text = myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFluxParameter;
                this.textBox_WPSGasAndWeldingFlux .Text  = myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFlux;
            }
        }

        public void FillClass()
        {
            myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFluxRemark = this.textBox_WPSGasAndWeldingFluxRemark.Text;
            myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFluxParameter = this.textBox_WPSGasAndWeldingFluxParameter.Text;
            myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFlux =this.textBox_WPSGasAndWeldingFlux .Text ;

        }

        private void textBox_WPSGasAndWeldingFlux_DoubleClick(object sender, EventArgs e)
        {
            Form_GasAndWeldingFluxQuery myForm = new Form_GasAndWeldingFluxQuery();
            myForm.myClass_GasAndWeldingFlux = new Class_GasAndWeldingFlux();
            if (this.myClass_WPSGasAndWeldingFlux .WPSGasAndWeldingFlux != null)
            {
                myForm.myClass_GasAndWeldingFlux.GasAndWeldingFlux = this.myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFlux;
                myForm.myClass_GasAndWeldingFlux.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFlux = myForm.myClass_GasAndWeldingFlux.GasAndWeldingFlux;
                this.textBox_WPSGasAndWeldingFlux.Text = string.Format("{0}", myForm.myClass_GasAndWeldingFlux.GasAndWeldingFlux);
                Class_GasAndWeldingFlux myClass_GasAndWeldingFlux = new Class_GasAndWeldingFlux(myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFlux);
                this.textBox_WPSGasAndWeldingFluxGroup.Text = myClass_GasAndWeldingFlux.GasAndWeldingFluxGroup;
            }

        }

    }
}
