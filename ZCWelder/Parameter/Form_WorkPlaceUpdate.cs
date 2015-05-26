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
    public partial class Form_WorkPlaceUpdate : Form
    {
        public Class_WorkPlace myClass_WorkPlace;
        public bool bool_Add;
        
        public Form_WorkPlaceUpdate()
        {
            InitializeComponent();
        }

        private void Form_WorkPlaceUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Class_zwjPublic.myBackColor;
            this.userControl_WorkPlaceBase1.InitControl(this.myClass_WorkPlace, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WorkPlaceBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_WorkPlace.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_WorkPlace.ExistSecond(this.myClass_WorkPlace.DepartmentHPID, this.myClass_WorkPlace.WorkPlace, null, Enum_zwjKindofUpdate.Add))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "作业区名称不能重复！";
                    return;
                }
                else
                {
                    if (!this.myClass_WorkPlace.AddAndModify(Enum_zwjKindofUpdate.Add))
                    {
                        this.label_ErrMessage.Text = "添加不成功！";
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
            }
            else
            {
                if (Class_WorkPlace.ExistSecond(this.myClass_WorkPlace.DepartmentHPID, this.myClass_WorkPlace.WorkPlace, this.myClass_WorkPlace.WorkPlaceHPID, Enum_zwjKindofUpdate.Modify))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "作业区名称不能重复！";
                    return;
                }
                else
                {
                    this.myClass_WorkPlace.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
        }
    }
}