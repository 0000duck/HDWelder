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
    public partial class Form_WeldingSubjectApplicableUpdate : Form
    {
        public Class_WeldingSubjectApplicable myClass_WeldingSubjectApplicable;
        public bool bool_Add;
        
        public Form_WeldingSubjectApplicableUpdate()
        {
            InitializeComponent();
        }

        private void Form_WeldingSubjectApplicableUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_WeldingSubjectApplicable.ExistAndCanDeleteAndDelete(myClass_WeldingSubjectApplicable.SubjectID ,this.myClass_WeldingSubjectApplicable.ApplicableSubjectID , Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_WeldingSubjectApplicable_Base1.InitControl(this.myClass_WeldingSubjectApplicable, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WeldingSubjectApplicable_Base1 .FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_WeldingSubjectApplicable.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_WeldingSubjectApplicable.ExistAndCanDeleteAndDelete(this.myClass_WeldingSubjectApplicable.SubjectID ,this.myClass_WeldingSubjectApplicable.ApplicableSubjectID , Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_WeldingSubjectApplicable.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该考试科目适用范围已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_WeldingSubjectApplicable.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }
        }
    }
}