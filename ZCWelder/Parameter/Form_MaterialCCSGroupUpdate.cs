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
    public partial class Form_MaterialCCSGroupUpdate : Form
    {
        public Class_MaterialCCSGroup myClass_MaterialCCSGroup;
        public bool bool_Add;
        
        public Form_MaterialCCSGroupUpdate()
        {
            InitializeComponent();
        }

        private void Form_MaterialCCSGroupUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_MaterialCCSGroup.ExistAndCanDeleteAndDelete(myClass_MaterialCCSGroup.MaterialCCSGroupAb, Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_MaterialCCSGroupBase1.InitControl(this.myClass_MaterialCCSGroup, this.bool_Add);
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_MaterialCCSGroupBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_MaterialCCSGroup.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_MaterialCCSGroup.ExistAndCanDeleteAndDelete(this.myClass_MaterialCCSGroup.MaterialCCSGroup, Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_MaterialCCSGroup.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该材料CCS组已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_MaterialCCSGroup.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();


        }
    }
}