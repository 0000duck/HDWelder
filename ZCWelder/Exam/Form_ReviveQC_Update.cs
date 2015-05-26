using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;

namespace ZCWelder.Exam
{
    public partial class Form_ReviveQC_Update : Form
    {
        public Class_ReviveQC  myClass_ReviveQC;
        public bool bool_Add;
        
        public Form_ReviveQC_Update()
        {
            InitializeComponent();
        }

        private void Form_ReviveQC_Update_Load(object sender, EventArgs e)
        {
            if (this.bool_Add)
            {
            }
            else
            {
                if (!Class_ReviveQC.ExistAndCanDeleteAndDelete(myClass_ReviveQC.ReviveQCID , Enum_zwjKindofUpdate.Exist))
                {
                    MessageBox.Show("不存在该项，可能已删除！");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
            }
            this.label_ErrMessage.Text = "";
            if (!Class_zwjPublic.myBackColor.IsEmpty)
            {
                this.BackColor = Class_zwjPublic.myBackColor;
            }
            this.userControl_ReviveQCBase1 .InitControl(this.myClass_ReviveQC, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_ReviveQCBase1 .FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_ReviveQC.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_ReviveQC.ExistSecond(this.myClass_ReviveQC.ExaminingNo))
                {
                    this.label_ErrMessage.Text = "同一张证书不能重复激活！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (this.myClass_ReviveQC.AddAndModify(Enum_zwjKindofUpdate.Add))
                {
                    this.userControl_ReviveQCBase1.myClass_QC.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
                else
                {
                    this.label_ErrMessage.Text = "添加不成功！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_ReviveQC.AddAndModify(Enum_zwjKindofUpdate.Modify);
                this.userControl_ReviveQCBase1.myClass_QC.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

        }
    }
}
