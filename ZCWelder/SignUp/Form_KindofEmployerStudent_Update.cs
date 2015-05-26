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

    public partial class Form_KindofEmployerStudent_Update : Form
    {
        public Class_KindofEmployerStudent myClass_KindofEmployerStudent;
        public bool bool_Add;

        public Form_KindofEmployerStudent_Update()
        {
            InitializeComponent();
        }

        private void Form_KindofEmployerStudent_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_KindofEmployerStudent.ExistAndCanDeleteAndDelete(myClass_KindofEmployerStudent.KindofEmployerStudentID, Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_KindofEmployerStudent_Base1.InitControl(this.myClass_KindofEmployerStudent, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_KindofEmployerStudent_Base1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_KindofEmployerStudent.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_KindofEmployerStudent.ExistSecond(this.myClass_KindofEmployerStudent.KindofEmployerIssueID, this.myClass_KindofEmployerStudent.KindofEmployerWelderID, 0, Enum_zwjKindofUpdate.Add))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "焊工编号不能重复！";
                    return;
                }
                else
                {
                    this.myClass_KindofEmployerStudent.AddAndModify(Enum_zwjKindofUpdate.Add);
 
                    if (this.checkBox_Continuous.Checked)
                    {
                        EventArgs_KindofEmployerIssue my_e = new EventArgs_KindofEmployerIssue(this.myClass_KindofEmployerStudent.KindofEmployerIssueID);
                        Publisher_KindofEmployerIssue.OnEventName(my_e);
                        this.label_ErrMessage.Text = "";
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        return;
                    }                  
                }
            }
            else
            {
                if (Class_KindofEmployerStudent.ExistSecond(this.myClass_KindofEmployerStudent.KindofEmployerIssueID , this.myClass_KindofEmployerStudent.KindofEmployerWelderID , this.myClass_KindofEmployerStudent.KindofEmployerStudentID, Enum_zwjKindofUpdate.Modify))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "焊工编号不能重复！";
                    return;
                }
                else
                {
                    this.myClass_KindofEmployerStudent.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
        }
    }
}