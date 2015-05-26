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
    public partial class Form_WelderBelong_Update : Form
    {
        public Class_WelderBelong myClass_WelderBelong;
        public bool bool_Add;

        public Form_WelderBelong_Update()
        {
            InitializeComponent();
        }

        private void Form_WelderBelong_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_WelderBelong.ExistAndCanDeleteAndDelete(myClass_WelderBelong.WelderBelongID  , Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_WelderBelong_Base1.InitControl(this.myClass_WelderBelong, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WelderBelong_Base1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_WelderBelong.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_WelderBelong.ExistSecond(this.myClass_WelderBelong.IdentificationCard, this.myClass_WelderBelong.myClass_BelongUnit.EmployerHPID, this.myClass_WelderBelong.myClass_BelongUnit.DepartmentHPID, this.myClass_WelderBelong.myClass_BelongUnit.WorkPlaceHPID, 0, Enum_zwjKindofUpdate.Add))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "本单位已有该焊工，不能重复添加！";
                    return;
                }
                else
                {
                    this.myClass_WelderBelong.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
            }
            else
            {
                if (Class_WelderBelong.ExistSecond(this.myClass_WelderBelong.IdentificationCard, this.myClass_WelderBelong.myClass_BelongUnit.EmployerHPID, this.myClass_WelderBelong.myClass_BelongUnit.DepartmentHPID, this.myClass_WelderBelong.myClass_BelongUnit.WorkPlaceHPID,this.myClass_WelderBelong.WelderBelongID , Enum_zwjKindofUpdate.Modify ))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "本单位已有该焊工，不能重复添加！";
                    return;
                }
                else
                {
                    this.myClass_WelderBelong.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
            if (this.checkBox_UpdateWelder.Checked)
            {
                Class_Welder myClass_Welder = new Class_Welder(this.myClass_WelderBelong.IdentificationCard);
                myClass_Welder.myClass_BelongUnit = this.myClass_WelderBelong.myClass_BelongUnit;
                myClass_Welder.AddAndModify(Enum_zwjKindofUpdate.Modify);
            }

        }
    }
}