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

namespace ZCWelder.Parameter
{
    public partial class Form_KindofEmployerUpdate : Form
    {
        public Class_KindofEmployer myClass_KindofEmployer;
        public bool bool_Add;
        
        public Form_KindofEmployerUpdate()
        {
            InitializeComponent();
        }

        private void Form_KindofEmployerUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_KindofEmployer.ExistAndCanDeleteAndDelete(myClass_KindofEmployer.KindofEmployer, Enum_zwjKindofUpdate.Exist)))
            {
                MessageBox.Show("�����ڸ��������ɾ����");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            this.label_ErrMessage.Text = "";
            if (!Class_zwjPublic.myBackColor.IsEmpty)
            {
                this.BackColor = Class_zwjPublic.myBackColor;
            }
            this.userControl_KindofEmployerBase1.InitControl(this.myClass_KindofEmployer, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_KindofEmployerBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_KindofEmployer.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage ))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_KindofEmployer.ExistAndCanDeleteAndDelete(this.myClass_KindofEmployer.KindofEmployer, Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_KindofEmployer.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "�ñ�����λ����ӣ�";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_KindofEmployer.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();


        }

        private void Button_KindofEmployerModify_Click(object sender, EventArgs e)
        {
            string str_NewKindofEmployer = "";
            Form_InputBox myForm = new Form_InputBox();
            myForm.str_DefaultResponse = this.myClass_KindofEmployer.KindofEmployer;
            myForm.str_Prompt = "�����뱨����λ���ƣ�";
            myForm.str_Title = "���뱨����λ����";
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                str_NewKindofEmployer = myForm.str_DefaultResponse;
            }
            else
            {
                return;
            }
            if (Class_KindofEmployer.ExistAndCanDeleteAndDelete(str_NewKindofEmployer, ZCCL.ClassBase.Enum_zwjKindofUpdate.Exist) == true)
            {
                MessageBox.Show("������λ�����ظ�������ʧ�ܣ�");
                return;
            }
            this.myClass_KindofEmployer .KindofEmployerModify(str_NewKindofEmployer);
            this.userControl_KindofEmployerBase1 .InitControl(this.myClass_KindofEmployer , false);
        }
    }
}