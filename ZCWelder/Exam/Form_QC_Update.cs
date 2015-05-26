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
    public partial class Form_QC_Update : Form
    {
        public Class_QC myClass_QC;
        public bool bool_Add;
        
        public Form_QC_Update()
        {
            InitializeComponent();
        }

        private void Form_QC_Update_Load(object sender, EventArgs e)
        {
            if (this.bool_Add)
            {
                if (Class_QC.ExistAndCanDeleteAndDelete(myClass_QC.ExaminingNo, Enum_zwjKindofUpdate.Exist))
                {
                    MessageBox.Show("已存在证书，不能添加！");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                else
                {
                    Class_Student myClass_Student = new Class_Student();
                    myClass_Student.ExaminingNo = this.myClass_QC.ExaminingNo;
                    if (myClass_Student.FillData())
                    {
                        if (!myClass_Student.isPassed )
                        {
                            MessageBox.Show("该学员不合格！");
                            this.DialogResult = DialogResult.Cancel;
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("不存在该项，可能已删除！");
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        return;
                    }
 
                }
            }
            else
            {
                if ( !Class_QC.ExistAndCanDeleteAndDelete(myClass_QC.ExaminingNo, Enum_zwjKindofUpdate.Exist))
                {
                    MessageBox.Show("不存在该项，可能已删除！");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
            }
            this.label_ErrMessage.Text = "";
            if (!Class_zwjPublic.myBackColor.IsEmpty)
            {
                this.BackColor = Class_zwjPublic.myBackColor;
            }
            this.userControl_QCBase1.InitControl(this.myClass_QC, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_QCBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_QC.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_QC.ExistAndCanDeleteAndDelete(this.myClass_QC.ExaminingNo , Enum_zwjKindofUpdate.Exist))
                {
                    this.label_ErrMessage.Text = "证书已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if ((!string.IsNullOrEmpty(this.myClass_QC.CertificateNo)) && Class_QC.ExistSecond(this.myClass_QC.CertificateNo , null, Enum_zwjKindofUpdate.Exist))
                {
                    this.label_ErrMessage.Text = "证号不能重复！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (!this.myClass_QC.AddAndModify(Enum_zwjKindofUpdate.Add))
                {
                    this.label_ErrMessage.Text = "添加不成功，可能是证号重复！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                if (Class_QC.ExistSecond(this.myClass_QC.CertificateNo, this.myClass_QC.ExaminingNo, Enum_zwjKindofUpdate.Modify))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "证号不能重复！";
                    return;
                }
                this.myClass_QC.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

        }
    }
}