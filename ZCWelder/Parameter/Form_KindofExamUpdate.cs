using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder.Parameter
{
    public partial class Form_KindofExamUpdate : Form
    {
        public Class_KindofExam myClass_KindofExam;
        public bool bool_Add;
        
        public Form_KindofExamUpdate()
        {
            InitializeComponent();
        }

        private void Form_KindofExamUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_KindofExam.ExistAndCanDeleteAndDelete(myClass_KindofExam.KindofExam, Enum_zwjKindofUpdate.Exist)))
            {
                MessageBox.Show("不存在该项，可能已删除！");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            this.label_ErrMessage.Text = "";
            if (!Class_zwjPublic.myBackColor.IsEmpty)
            {
                this.BackColor = Class_zwjPublic.myBackColor;
            }
            this.userControl_KindofExamBase1.InitControl(this.myClass_KindofExam, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_KindofExamBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_KindofExam.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_KindofExam.ExistAndCanDeleteAndDelete(this.myClass_KindofExam.KindofExam, Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_KindofExam.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该考试方式已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_KindofExam.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

        }
    }
}