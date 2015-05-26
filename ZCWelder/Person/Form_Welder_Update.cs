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

namespace ZCWelder.Person
{
    public partial class Form_Welder_Update : Form
    {
        public Class_Welder myClass_Welder;
        public bool bool_Add;
        
        public Form_Welder_Update()
        {
            InitializeComponent();
        }

        private void Form_Welder_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_Welder.ExistAndCanDeleteAndDelete(myClass_Welder.IdentificationCard , Enum_zwjKindofUpdate.Exist)))
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
            this.Button_IdentificationCardModify.Visible = !this.bool_Add;
            this.userControl_WelderBase1.InitControl(this.myClass_Welder, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WelderBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_Welder.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage ))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_Welder.ExistAndCanDeleteAndDelete(this.myClass_Welder.IdentificationCard  , Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_Welder.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "�����֤��������ӣ�";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_Welder.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }
        }

        private void Button_IdentificationCardModify_Click(object sender, EventArgs e)
        {
            this.userControl_WelderBase1.FillClass();
            string str_NewIdentificationCard = "";
            Form_InputBox myForm = new Form_InputBox();
            myForm.str_DefaultResponse = this.myClass_Welder .IdentificationCard;
            myForm.str_Prompt = "���������֤���룺";
            myForm.str_Title = "�������֤����";
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                str_NewIdentificationCard = myForm.str_DefaultResponse;
            }
            else
            {
                return ;
            }
            if (!Class_DataValidateTool.CheckIdentificationCard(str_NewIdentificationCard,this.myClass_Welder.Sex ))
            {
                MessageBox.Show("���֤�����ʽ���󣬲���ʧ�ܣ�");
                return;
            }
            if (Class_Welder.ExistAndCanDeleteAndDelete(str_NewIdentificationCard, ZCCL.ClassBase.Enum_zwjKindofUpdate.Exist) == true)
            {
                MessageBox.Show("���֤�����ظ�������ʧ�ܣ�");
                return;
            }
            this.myClass_Welder.IdentificationCardModify (str_NewIdentificationCard, this.myClass_Welder.Sex );
            this.userControl_WelderBase1 .InitControl(this.myClass_Welder , false);

        }
    }
}