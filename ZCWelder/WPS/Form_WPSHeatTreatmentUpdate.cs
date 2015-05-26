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
    public partial class Form_WPSHeatTreatmentUpdate : Form
    {
        public Class_WPSHeatTreatment myClass_WPSHeatTreatment;
        public bool bool_Add;
        
        public Form_WPSHeatTreatmentUpdate()
        {
            InitializeComponent();
        }

        private void Form_WPSHeatTreatmentUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            this.userControl_WPSHeatTreatmentBase1.InitControl(this.myClass_WPSHeatTreatment, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WPSHeatTreatmentBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_WPSHeatTreatment.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                this.myClass_WPSHeatTreatment.AddAndModify (ZCCL.ClassBase.Enum_zwjKindofUpdate.Add );
            }
            else
            {
                this.myClass_WPSHeatTreatment.AddAndModify(ZCCL.ClassBase.Enum_zwjKindofUpdate.Modify );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}