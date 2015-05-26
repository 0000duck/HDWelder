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
    public partial class Form_WeldingEquipment_Update : Form
    {
        public Class_WeldingEquipment myClass_WeldingEquipment;
        public bool bool_Add;
        
        public Form_WeldingEquipment_Update()
        {
            InitializeComponent();
        }

        private void Form_WeldingEquipmentUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            this.userControl_WeldingEquipmentBase1.InitControl(this.myClass_WeldingEquipment, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WeldingEquipmentBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_WeldingEquipment.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (!Class_WeldingEquipment.ExistAndCanDeleteAndDelete (this.myClass_WeldingEquipment.WeldingEquipment, Enum_zwjKindofUpdate.Exist ))
                {
                    this.myClass_WeldingEquipment.AddAndModify (Enum_zwjKindofUpdate.Add  );
                }
                else
                {
                    this.label_ErrMessage.Text = "该焊接设备已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_WeldingEquipment.AddAndModify ( Enum_zwjKindofUpdate.Modify );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}