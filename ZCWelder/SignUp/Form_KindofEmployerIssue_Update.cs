using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;
using ZCCL.Tools;

namespace ZCWelder.SignUp
{
    public partial class Form_KindofEmployerIssue_Update : Form
    {
        public Class_KindofEmployerIssue myClass_KindofEmployerIssue;
        public bool bool_Add;
        
        public Form_KindofEmployerIssue_Update()
        {
            InitializeComponent();
        }

        private void Form_KindofEmployerIssue_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_KindofEmployerIssue.ExistAndCanDeleteAndDelete(myClass_KindofEmployerIssue.KindofEmployerIssueID , Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_KindofEmployerIssue_Base1.InitControl(this.myClass_KindofEmployerIssue, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_KindofEmployerIssue_Base1 .FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_KindofEmployerIssue.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_KindofEmployerIssue.ExistSecond(this.myClass_KindofEmployerIssue.KindofEmployer, this.myClass_KindofEmployerIssue.IssueNo , 0, Enum_zwjKindofUpdate.Add))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "班级名称不能重复！";
                    return;
                }
                else
                {
                    this.myClass_KindofEmployerIssue.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
            }
            else
            {
                if (Class_KindofEmployerIssue.ExistSecond(this.myClass_KindofEmployerIssue.KindofEmployer, this.myClass_KindofEmployerIssue.IssueNo, this.myClass_KindofEmployerIssue.KindofEmployerIssueID , Enum_zwjKindofUpdate.Modify))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "班级名称不能重复！";
                    return;
                }
                else
                {
                    this.myClass_KindofEmployerIssue.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
        }
    }
}