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

namespace ZCWelder.SignUp
{
    public partial class Form_KindofEmployerWelder_Update : Form
    {
        public Class_KindofEmployerWelder myClass_KindofEmployerWelder;
        public bool bool_Add;
        
        public Form_KindofEmployerWelder_Update()
        {
            InitializeComponent();
        }

        private void Form_KindofEmployerWelder_Update_Load(object sender, EventArgs e)
        {
            if (!(this.bool_Add || Class_KindofEmployerWelder.ExistAndCanDeleteAndDelete(myClass_KindofEmployerWelder.KindofEmployerWelderID , Enum_zwjKindofUpdate.Exist)))
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
            this.userControl_KindofEmployerWelder_Base1 .InitControl(this.myClass_KindofEmployerWelder, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_KindofEmployerWelder_Base1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_KindofEmployerWelder.CheckField();
            if (!string.IsNullOrEmpty(str_ErrMessage))
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_KindofEmployerWelder.ExistSecond(this.myClass_KindofEmployerWelder .KindofEmployer , this.myClass_KindofEmployerWelder.IdentificationCard , 0, Enum_zwjKindofUpdate.Add))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "身份证号码不能重复！";
                    return;
                }
                else
                {
                    this.myClass_KindofEmployerWelder.AddAndModify(Enum_zwjKindofUpdate.Add);
                    if (!Class_Welder.ExistAndCanDeleteAndDelete(myClass_KindofEmployerWelder.IdentificationCard, Enum_zwjKindofUpdate.Exist))
                    {
                        Class_Welder myClass_Welder = new Class_Welder();
                        myClass_Welder.IdentificationCard = myClass_KindofEmployerWelder.IdentificationCard;
                        myClass_Welder.Schooling = myClass_KindofEmployerWelder.Schooling;
                        myClass_Welder.Sex = myClass_KindofEmployerWelder.Sex;
                        myClass_Welder.WelderName = myClass_KindofEmployerWelder.WelderName;
                        myClass_Welder.WeldingBeginning = myClass_KindofEmployerWelder.WeldingBeginning;
                        myClass_Welder.myClass_BelongUnit = myClass_KindofEmployerWelder.myClass_BelongUnit;
                        myClass_Welder.AddAndModify(Enum_zwjKindofUpdate.Add);
                   }
                }
            }
            else
            {
                if (Class_KindofEmployerWelder.ExistSecond(this.myClass_KindofEmployerWelder.KindofEmployer, this.myClass_KindofEmployerWelder.IdentificationCard, this.myClass_KindofEmployerWelder.KindofEmployerWelderID , Enum_zwjKindofUpdate.Modify ))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "身份证号码不能重复！";
                    return;
                }
                else
                {
                    this.myClass_KindofEmployerWelder.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
        }
    }
}