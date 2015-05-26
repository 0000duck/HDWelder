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
    public partial class Form_ShipClassificationUpdate : Form
    {
        public Class_ShipClassification myClass_ShipClassification;
        public bool bool_Add;
        
        public Form_ShipClassificationUpdate()
        {
            InitializeComponent();
        }

        private void Form_ShipClassificationUpdate_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_ShipClassification.ExistAndCanDeleteAndDelete(myClass_ShipClassification.ShipClassificationAb, Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_ShipClassificationBase1.InitControl(this.myClass_ShipClassification, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_ShipClassificationBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_ShipClassification.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_ShipClassification.ExistAndCanDeleteAndDelete(this.myClass_ShipClassification.ShipClassificationAb, Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_ShipClassification.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该船级社已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_ShipClassification.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();


        }
    }
}