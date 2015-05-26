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
    public partial class Form_GXTheoryStudent_Update : Form
    {
        public Class_GXTheoryStudent myClass_GXTheoryStudent;
        public bool bool_Add;

        public Form_GXTheoryStudent_Update()
        {
            InitializeComponent();
        }

        private void Form_GXTheoryStudent_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_GXTheoryStudent.ExistAndCanDeleteAndDelete(myClass_GXTheoryStudent.ExaminingNo, Enum_zwjKindofUpdate.Exist)))
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
            this.checkBox_Continuous.Visible = this.bool_Add;
            this.userControl_GXTheoryStudent_Base1.InitControl(this.myClass_GXTheoryStudent, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_GXTheoryStudent_Base1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_GXTheoryStudent.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_GXTheoryStudent.ExistSecond(this.myClass_GXTheoryStudent.IssueNo, this.myClass_GXTheoryStudent.IdentificationCard, null, Enum_zwjKindofUpdate.Add))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "身份证号码不能重复！";
                    return;
                }
                else
                {
                    if (!this.myClass_GXTheoryStudent.AddAndModify(Enum_zwjKindofUpdate.Add))
                    {
                        this.label_ErrMessage.Text = "添加不成功，可能是考编号重复！";
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    else
                    {
                        if (this.checkBox_Continuous.Checked)
                        {
                            EventArgs_Issue my_e = new EventArgs_Issue(this.myClass_GXTheoryStudent .IssueNo, true );
                            Publisher_Issue.OnEventName(my_e);
                            this.DialogResult = DialogResult.None;
                            this.label_ErrMessage.Text = "";
                            return;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                            return;
                        }
                    }
                }
            }
            else
            {
                if (Class_GXTheoryStudent.ExistSecond(this.myClass_GXTheoryStudent.IssueNo, this.myClass_GXTheoryStudent.IdentificationCard, this.myClass_GXTheoryStudent.ExaminingNo, Enum_zwjKindofUpdate.Modify))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "身份证号码不能重复！";
                    return;
                }
                else
                {
                    this.myClass_GXTheoryStudent.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }

        }
    }
}