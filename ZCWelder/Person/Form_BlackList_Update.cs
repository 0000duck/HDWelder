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
    public partial class Form_BlackList_Update : Form
    {
        public Class_BlackList myClass_BlackList;
        public bool bool_Add;

        public Form_BlackList_Update()
        {
            InitializeComponent();
        }

        private void Form_BlackList_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_BlackList.ExistAndCanDeleteAndDelete(myClass_BlackList.BlackListID , Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_BlackListBase1.InitControl(this.myClass_BlackList, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_BlackListBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_BlackList.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                this.myClass_BlackList.AddAndModify(Enum_zwjKindofUpdate.Add);
            }
            else
            {
                this.myClass_BlackList.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }
        }
    }
}