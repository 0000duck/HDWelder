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
    public partial class Form_GXTheoryIssue_Update : Form
    {
        public Class_GXTheoryIssue myClass_GXTheoryIssue;
        public bool bool_Add;
        
        public Form_GXTheoryIssue_Update()
        {
            InitializeComponent();
        }

        private void Form_GXTheoryIssue_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_GXTheoryIssue.ExistAndCanDeleteAndDelete(myClass_GXTheoryIssue.IssueNo, Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_GXTheoryIssue_Base1.InitControl(this.myClass_GXTheoryIssue, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_GXTheoryIssue_Base1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_GXTheoryIssue.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            str_ErrMessage = Class_GXTheoryIssue.CheckExamStatus(this.myClass_GXTheoryIssue.IssueNo, this.myClass_GXTheoryIssue.IssueStatus);
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.label_ErrMessage.Text = str_ErrMessage;
                this.DialogResult = DialogResult.None;
                return;
            }
            if (this.bool_Add)
            {
                if (!this.myClass_GXTheoryIssue.AddAndModify(Enum_zwjKindofUpdate.Add))
                {
                    this.label_ErrMessage.Text = "添加不成功，可能是班级编号重复！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_GXTheoryIssue.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }
        }
    }
}