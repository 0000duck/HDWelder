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
    public partial class Form_EmployerGroupUpdate : Form
    {
        public Class_EmployerGroup myClass_EmployerGroup;
        public bool bool_Add;

        public Form_EmployerGroupUpdate()
        {
            InitializeComponent();
        }

        private void Form_EmployerGroup_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_EmployerGroup.ExistAndCanDeleteAndDelete(myClass_EmployerGroup.EmployerGroup, Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_EmployerGroupBase1.InitControl(this.myClass_EmployerGroup, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_EmployerGroupBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_EmployerGroup.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_EmployerGroup.ExistAndCanDeleteAndDelete(this.myClass_EmployerGroup.EmployerGroup, Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_EmployerGroup.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该公司组已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_EmployerGroup.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

        }
    }
}