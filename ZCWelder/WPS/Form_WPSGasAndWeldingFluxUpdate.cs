using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;

namespace ZCWelder.WPS
{
    public partial class Form_WPSGasAndWeldingFluxUpdate : Form
    {
        public Class_WPSGasAndWeldingFlux myClass_WPSGasAndWeldingFlux;
        public bool bool_Add;
        
        public Form_WPSGasAndWeldingFluxUpdate()
        {
            InitializeComponent();
        }

        private void Form_WPSGasAndWeldingFluxUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            this.userControl_WPSGasAndWeldingFluxBase1.InitControl(this.myClass_WPSGasAndWeldingFlux, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WPSGasAndWeldingFluxBase1 .FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_WPSGasAndWeldingFlux.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                this.myClass_WPSGasAndWeldingFlux.AddAndModify(ZCCL.ClassBase.Enum_zwjKindofUpdate.Add );
            }
            else
            {
                this.myClass_WPSGasAndWeldingFlux.AddAndModify(ZCCL.ClassBase.Enum_zwjKindofUpdate.Modify );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}