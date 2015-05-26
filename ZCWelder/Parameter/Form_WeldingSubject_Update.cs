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
    public partial class Form_WeldingSubject_Update : Form
    {
        public Class_WeldingSubject myClass_WeldingSubject;
        public bool bool_Add;
        
        public Form_WeldingSubject_Update()
        {
            InitializeComponent();
        }

        private void Form_WeldingSubjectUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_WeldingSubject.ExistAndCanDeleteAndDelete(myClass_WeldingSubject.SubjectID , Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_WeldingSubjectBase1.InitControl(this.myClass_WeldingSubject, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WeldingSubjectBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_WeldingSubject.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_WeldingSubject.ExistAndCanDeleteAndDelete(this.myClass_WeldingSubject.SubjectID, Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_WeldingSubject.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该科目编号已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_WeldingSubject.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

        }
    }
}