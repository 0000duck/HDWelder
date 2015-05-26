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
    public partial class Form_WeldingSubjectPosition_Update : Form
    {
        public Class_WeldingSubjectPosition myClass_WeldingSubjectPosition;
        public bool bool_Add;
        
        public Form_WeldingSubjectPosition_Update()
        {
            InitializeComponent();
        }

        private void Form_WeldingSubjectPositionUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_WeldingSubjectPosition.ExistAndCanDeleteAndDelete(myClass_WeldingSubjectPosition.SubjectID ,myClass_WeldingSubjectPosition.WeldingPosition , Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_WeldingSubjectPositionBase1.InitControl(this.myClass_WeldingSubjectPosition, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WeldingSubjectPositionBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_WeldingSubjectPosition.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_WeldingSubjectPosition.ExistAndCanDeleteAndDelete(this.myClass_WeldingSubjectPosition.SubjectID, myClass_WeldingSubjectPosition.WeldingPosition, Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_WeldingSubjectPosition.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该考试项目已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_WeldingSubjectPosition.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

        }
    }
}