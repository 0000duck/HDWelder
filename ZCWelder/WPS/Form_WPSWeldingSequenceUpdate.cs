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
    public partial class Form_WPSWeldingSequenceUpdate : Form
    {
        public Class_WPSWeldingSequence myClass_WPSWeldingSequence;
        public bool bool_Add;
        
        public Form_WPSWeldingSequenceUpdate()
        {
            InitializeComponent();
        }

        private void Form_pWPSWeldingSequenceUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            this.userControl_pWPSSequenceBase1.InitControl(this.myClass_WPSWeldingSequence, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_pWPSSequenceBase1 .FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_WPSWeldingSequence.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                this.myClass_WPSWeldingSequence.AddAndModify(Enum_zwjKindofUpdate.Add);
            }
            else
            {
                this.myClass_WPSWeldingSequence.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}