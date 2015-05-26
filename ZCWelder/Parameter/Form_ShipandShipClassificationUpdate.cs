using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder.Parameter
{
    public partial class Form_ShipandShipClassificationUpdate : Form
    {
        public Class_ShipandShipClassification myClass_ShipandShipClassification;
        public bool bool_Add;
        
        public Form_ShipandShipClassificationUpdate()
        {
            InitializeComponent();
        }

        private void Form_ShipandShipClassification_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_ShipandShipClassification.ExistAndCanDeleteAndDelete(myClass_ShipandShipClassification.ShipClassificationAb, myClass_ShipandShipClassification.ShipboardNo , Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_ShipandShipClassificationBase1.InitControl(this.myClass_ShipandShipClassification, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_ShipandShipClassificationBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_ShipandShipClassification.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_ShipandShipClassification.ExistAndCanDeleteAndDelete(this.myClass_ShipandShipClassification.ShipClassificationAb, this.myClass_ShipandShipClassification.ShipboardNo , Enum_zwjKindofUpdate.Exist))
                {
                    this.myClass_ShipandShipClassification.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                else
                {
                    this.label_ErrMessage.Text = "该船级社和船舶系列已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_ShipandShipClassification.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

        }
    }
}