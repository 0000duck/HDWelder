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
    public partial class Form_WeldingStandardUpdate : Form
    {
        public Class_WeldingStandard myClass_WeldingStandard;
        public bool bool_Add;
        
        public Form_WeldingStandardUpdate()
        {
            InitializeComponent();
        }

        private void Form_WeldingStandardUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            this.userControl_WeldingStandardBase1.InitControl(this.myClass_WeldingStandard, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WeldingStandardBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_WeldingStandard.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_WeldingStandard.ExistAndCanDeleteAndDelete (this.myClass_WeldingStandard.WeldingStandard, Enum_zwjKindofUpdate.Exist ))
                {
                    this.myClass_WeldingStandard.AddAndModify (Enum_zwjKindofUpdate .Add );
                }
                else
                {
                    this.label_ErrMessage.Text = "该焊接标准已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {                
                this.myClass_WeldingStandard.AddAndModify (Enum_zwjKindofUpdate.Modify );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}