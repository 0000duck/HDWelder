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
    public partial class Form_WeldingProcessUpdate : Form
    {
        public Class_WeldingProcess  myClass_WeldingProcess;
        public bool bool_Add;
        
        public Form_WeldingProcessUpdate()
        {
            InitializeComponent();
        }

        private void Form_WeldingProcessUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_WeldingProcess.ExistAndCanDeleteAndDelete(myClass_WeldingProcess.WeldingProcessAb , Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_WeldingProcessBase1.InitControl(this.myClass_WeldingProcess, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WeldingProcessBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_WeldingProcess.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_WeldingProcess.ExistAndCanDeleteAndDelete(this.myClass_WeldingProcess.WeldingProcessAb, Enum_zwjKindofUpdate.Exist ) )
                {
                    this.myClass_WeldingProcess.AddAndModify (Enum_zwjKindofUpdate.Add );
                }
                else
                {
                    this.label_ErrMessage.Text = "�ú��ӷ�������ӣ�";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_WeldingProcess.AddAndModify(Enum_zwjKindofUpdate.Modify );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}