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
    public partial class Form_WeldingConsumableCCSGroupUpdate : Form
    {
        public Class_WeldingConsumableCCSGroup myClass_WeldingConsumableCCSGroup;
        public bool bool_Add;

        public Form_WeldingConsumableCCSGroupUpdate()
        {
            InitializeComponent();
        }

        private void Form_WeldingConsumableCCSGroupUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_WeldingConsumableCCSGroup.ExistAndCanDeleteAndDelete(myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupAb, Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_WeldingConsumableCCSGroupBase1.InitControl(this.myClass_WeldingConsumableCCSGroup, this.bool_Add);
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WeldingConsumableCCSGroupBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_WeldingConsumableCCSGroup.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_WeldingConsumableCCSGroup.ExistAndCanDeleteAndDelete(this.myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroup, Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_WeldingConsumableCCSGroup.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该焊接材料CCS组已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_WeldingConsumableCCSGroup.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();


        }
    }
}