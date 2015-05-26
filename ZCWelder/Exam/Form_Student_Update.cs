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
    public partial class Form_Student_Update : Form
    {
        public Class_Student myClass_Student;
        public bool bool_Add;

        public Form_Student_Update()
        {
            InitializeComponent();
        }

        private void Form_Student_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_Student.ExistAndCanDeleteAndDelete(myClass_Student.ExaminingNo , Enum_zwjKindofUpdate.Exist)))
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
            this.checkBox_Continuous.Visible  = this.bool_Add;
            this.userControl_StudentBase1.InitControl(this.myClass_Student, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_StudentBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_Student.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_Student.ExistSecond(this.myClass_Student.IssueNo, this.myClass_Student.IdentificationCard  , null, Enum_zwjKindofUpdate.Add))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "身份证号码不能重复！";
                    return;
                }
                else
                {
                    if (!this.myClass_Student.AddAndModify(Enum_zwjKindofUpdate.Add))
                    {
                        this.label_ErrMessage.Text = "添加不成功，可能是考编号重复！";
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    else
                    {
                        if (this.checkBox_Continuous.Checked)
                        {
                            EventArgs_Issue my_e = new EventArgs_Issue(this.myClass_Student.IssueNo, false);
                            Publisher_Issue.OnEventName(my_e);
                            this.label_ErrMessage.Text = "";
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK ;
                            return;
                        }
                    }
                }
            }
            else
            {
                if (Class_Student.ExistSecond(this.myClass_Student.IssueNo, this.myClass_Student.IdentificationCard, this.myClass_Student.ExaminingNo , Enum_zwjKindofUpdate.Modify ))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "身份证号码不能重复！";
                    return;
                }
                else
                {
                    this.myClass_Student.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }

        }
    }
}