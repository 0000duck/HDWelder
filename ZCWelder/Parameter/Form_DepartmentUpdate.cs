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
    public partial class Form_DepartmentUpdate : Form
    {
        public Class_Department myClass_Department;
        public bool bool_Add;
        
        public Form_DepartmentUpdate()
        {
            InitializeComponent();
        }

        private void Form_DepartmentUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Class_zwjPublic.myBackColor;
            this.userControl_DepartmentBase1.InitControl(this.myClass_Department, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_DepartmentBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_Department.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_Department.ExistSecond(this.myClass_Department.EmployerHPID, this.myClass_Department.Department, null, Enum_zwjKindofUpdate.Add))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "部门名称不能重复！";
                    return;
                }
                else
                {
                    if (!this.myClass_Department.AddAndModify(Enum_zwjKindofUpdate.Add))
                    {
                        this.label_ErrMessage.Text = "添加不成功！";
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
            }
            else
            {
                if (Class_Department.ExistSecond(this.myClass_Department.EmployerHPID, this.myClass_Department.Department, this.myClass_Department.DepartmentHPID , Enum_zwjKindofUpdate.Modify ))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "部门名称不能重复！";
                    return;
                }
                else
                {
                    this.myClass_Department.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
        }
    }
}