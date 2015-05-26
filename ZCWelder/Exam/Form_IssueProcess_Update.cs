using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder.Exam
{
    public partial class Form_IssueProcess_Update : Form
    {
        public Class_IssueProcess myClass_IssueProcess;
        public bool bool_Add;
        public string str_ProcessStatusGroup;

        public Form_IssueProcess_Update()
        {
            InitializeComponent();
        }

        private void Form_IssueProcess_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_IssueProcess.ExistAndCanDeleteAndDelete(myClass_IssueProcess.IssueProcessID, myClass_IssueProcess.GXTheory , Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_IssueProcessBase1.InitControl(this.myClass_IssueProcess, this.str_ProcessStatusGroup , this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_IssueProcessBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_IssueProcess.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                this.myClass_IssueProcess.AddAndModify(Enum_zwjKindofUpdate.Add);
            }
            else
            {
                this.myClass_IssueProcess.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

        }
    }
}