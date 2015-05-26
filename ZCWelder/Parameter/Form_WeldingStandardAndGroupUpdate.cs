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
    public partial class Form_WeldingStandardAndGroupUpdate : Form
    {
        public Class_WeldingStandardAndGroup myClass_WeldingStandardAndGroup;
        public bool bool_Add;
        
        public Form_WeldingStandardAndGroupUpdate()
        {
            InitializeComponent();
        }

        private void Form_WeldingStandardAndGroupUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            this.userControl_WeldingStandardAndGroupBase1.InitControl(this.myClass_WeldingStandardAndGroup, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WeldingStandardAndGroupBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_WeldingStandardAndGroup.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {

                if (!Class_WeldingStandardAndGroup.ExistAndCanDeleteAndDelete (this.myClass_WeldingStandardAndGroup.WeldingStandard,this.myClass_WeldingStandardAndGroup.WeldingStandardGroup , Enum_zwjKindofUpdate.Exist ) )
                {
                    this.myClass_WeldingStandardAndGroup.AddAndModify (Enum_zwjKindofUpdate .Add );
                }
                else
                {
                    this.label_ErrMessage.Text = "该焊接标准和组已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_WeldingStandardAndGroup.AddAndModify (Enum_zwjKindofUpdate.Modify );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}