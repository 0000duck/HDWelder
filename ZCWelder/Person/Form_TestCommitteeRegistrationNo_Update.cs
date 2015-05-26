using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder.Person
{
    public partial class Form_TestCommitteeRegistrationNo_Update : Form
    {
        public Class_TestCommitteeRegistrationNo myClass_TestCommitteeRegistrationNo;
        public bool bool_Add;
        
        public Form_TestCommitteeRegistrationNo_Update()
        {
            InitializeComponent();
        }

        private void Form_TestCommitteeRegistrationNo_Update_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            if (!Class_zwjPublic.myBackColor.IsEmpty)
            {
                this.BackColor = Class_zwjPublic.myBackColor;
            }            
            this.userControl_TestCommitteeRegistrationNo_Base1 .InitControl(this.myClass_TestCommitteeRegistrationNo, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_TestCommitteeRegistrationNo_Base1 .FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_TestCommitteeRegistrationNo.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (string.IsNullOrEmpty(Class_TestCommitteeRegistrationNo.AutoFill(this.myClass_TestCommitteeRegistrationNo.TestCommitteeID, this.myClass_TestCommitteeRegistrationNo.IdentificationCard) ))
                {
                    MessageBox.Show("操作失败，该存档编号已被使用，请修改下一个存档编号！");
                }
            }

        }
    }
}