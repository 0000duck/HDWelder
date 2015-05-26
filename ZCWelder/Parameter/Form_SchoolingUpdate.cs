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
    public partial class Form_SchoolingUpdate : Form
    {
        public Class_Schooling myClass_Schooling;
        public bool bool_Add;
        
        public Form_SchoolingUpdate()
        {
            InitializeComponent();
        }

        private void Form_SchoolingUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Class_zwjPublic.myBackColor;
            this.userControl_SchoolingBase1.InitControl(this.myClass_Schooling, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_SchoolingBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_Schooling.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_Schooling.ExistAndCanDeleteAndDelete(this.myClass_Schooling.Schooling, Enum_zwjKindofUpdate.Exist) == false)
                {
                    this.myClass_Schooling.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该学历已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_Schooling.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }
        }
    }
}