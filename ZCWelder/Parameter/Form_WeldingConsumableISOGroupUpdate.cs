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
    public partial class Form_WeldingConsumableISOGroupUpdate : Form
    {
        public Class_WeldingConsumableISOGroup myClass_WeldingConsumableISOGroup;
        public bool bool_Add;

        public Form_WeldingConsumableISOGroupUpdate()
        {
            InitializeComponent();
        }

        private void Form_WeldingConsumableISOGroupUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_WeldingConsumableISOGroup.ExistAndCanDeleteAndDelete(myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupAb, Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_WeldingConsumableISOGroupBase1.InitControl(this.myClass_WeldingConsumableISOGroup, this.bool_Add);
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WeldingConsumableISOGroupBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_WeldingConsumableISOGroup.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_WeldingConsumableISOGroup.ExistAndCanDeleteAndDelete(this.myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroup, Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_WeldingConsumableISOGroup.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该焊接材料ISO组已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_WeldingConsumableISOGroup.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();


        }
    }
}