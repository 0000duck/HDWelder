using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;

namespace ZCWelder.Parameter
{
    public partial class Form_GasAndWeldingFluxUpdate : Form
    {
        public Class_GasAndWeldingFlux myClass_GasAndWeldingFlux;
        public bool bool_Add;
        
        public Form_GasAndWeldingFluxUpdate()
        {
            InitializeComponent();
        }

        private void Form_GasAndWeldingFluxUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            this.userControl_GasAndWeldingFluxBase1.InitControl(this.myClass_GasAndWeldingFlux, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_GasAndWeldingFluxBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_GasAndWeldingFlux.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_GasAndWeldingFlux.ExistAndCanDeleteAndDelete (this.myClass_GasAndWeldingFlux.GasAndWeldingFlux, Enum_zwjKindofUpdate.Exist ) == false)
                {
                    this.myClass_GasAndWeldingFlux.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该保护介质已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_GasAndWeldingFlux.AddAndModify( Enum_zwjKindofUpdate.Modify );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}