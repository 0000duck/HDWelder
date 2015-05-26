using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.AspNet;
using ZCCL.Report;
using ZCCL.Tools;
using ZCCL.ClassBase;

namespace ZCWelder.Parameter
{
    public partial class Form_EmployerUpdate : Form
    {
        public Class_Employer myClass_Employer;
        public bool bool_Add;
        
        public Form_EmployerUpdate()
        {
            InitializeComponent();
        }

        private void Form_EmployerUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            this.userControl_EmployerBase1.InitControl(this.myClass_Employer, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_EmployerBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = myClass_Employer.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_Employer.ExistSecond(this.myClass_Employer.Employer , null, Enum_zwjKindofUpdate.Add))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "公司名称不能重复！";
                    return;
                }
                else
                {
                    if (!this.myClass_Employer.AddAndModify(Enum_zwjKindofUpdate.Add))
                    {
                        this.label_ErrMessage.Text = "添加不成功！";
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
            }
            else
            {
                if (Class_Employer.ExistSecond(this.myClass_Employer.Employer, this.myClass_Employer.EmployerHPID, Enum_zwjKindofUpdate.Modify))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "公司名称不能重复！";
                    return;
                }
                else
                {
                    this.myClass_Employer.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    } 
}