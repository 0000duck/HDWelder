using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;

namespace ZCWelder.WPS
{
    public partial class Form_WPSLayerUpdate : Form
    {
        public Class_WPSWeldingLayer myClass_WPSWeldingLayer;
        public bool bool_Add;
        
        public Form_WPSLayerUpdate()
        {
            InitializeComponent();
        }

        private void Form_WPSLayerUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            this.userControl_pWPSLayerBase1 .InitControl(this.myClass_WPSWeldingLayer , this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_pWPSLayerBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_WPSWeldingLayer.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                this.myClass_WPSWeldingLayer.AddAndModify(Enum_zwjKindofUpdate.Add);
            }
            else
            {
                this.myClass_WPSWeldingLayer.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}