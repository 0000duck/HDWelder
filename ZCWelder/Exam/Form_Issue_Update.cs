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
    public partial class Form_Issue_Update : Form
    {
        public Class_Issue myClass_Issue;
        public bool bool_Add;
        
        public Form_Issue_Update()
        {
            InitializeComponent();
        }

        private void Form_IssueUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_Issue.ExistAndCanDeleteAndDelete(myClass_Issue.IssueNo, Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_IssueBase1.InitControl(this.myClass_Issue, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_IssueBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_Issue.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage ))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            str_ErrMessage = Class_Issue.CheckExamStatus(this.myClass_Issue.IssueNo, this.myClass_Issue.IssueStatus  );
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.label_ErrMessage.Text = str_ErrMessage;
                this.DialogResult = DialogResult.None;
                return;
            }

            if (this.bool_Add)
            {
                if (!this.myClass_Issue .AddAndModify(Enum_zwjKindofUpdate.Add))
                {
                    this.label_ErrMessage.Text = "添加不成功，可能是班级编号重复！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_Issue.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }
        }
    }
}