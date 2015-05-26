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
    public partial class Form_WeldingPositionUpdate : Form
    {
        public Class_WeldingPosition myClass_WeldingPosition;
        public bool bool_Add;
        
        public Form_WeldingPositionUpdate()
        {
            InitializeComponent();
        }

        private void Form_WeldingPositionUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            this.userControl_WeldingPositionBase1.InitControl(this.myClass_WeldingPosition, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WeldingPositionBase1 .FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_WeldingPosition.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_WeldingPosition.ExistAndCanDeleteAndDelete  (this.myClass_WeldingPosition.WeldingPosition, Enum_zwjKindofUpdate.Exist ))
                {
                    this.myClass_WeldingPosition.AddAndModify (Enum_zwjKindofUpdate.Add );
                }
                else
                {
                    this.label_ErrMessage.Text = "该焊接位置已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_WeldingPosition.AddAndModify(Enum_zwjKindofUpdate.Modify );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}