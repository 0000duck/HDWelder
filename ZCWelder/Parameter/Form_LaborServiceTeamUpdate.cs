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
    public partial class Form_LaborServiceTeamUpdate : Form
    {
        public Class_LaborServiceTeam myClass_LaborServiceTeam;
        public bool bool_Add;

        public Form_LaborServiceTeamUpdate()
        {
            InitializeComponent();
        }

        private void Form_LaborServiceTeamUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Class_zwjPublic.myBackColor;
            this.userControl_LaborServiceTeamBase1.InitControl(this.myClass_LaborServiceTeam, this.bool_Add);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_LaborServiceTeamBase1.FillClass();
            String str_ErrMessage;
            str_ErrMessage = this.myClass_LaborServiceTeam.CheckField();
            if (str_ErrMessage != null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = str_ErrMessage;
                return;
            }
            if (this.bool_Add)
            {
                if (Class_LaborServiceTeam.ExistSecond(this.myClass_LaborServiceTeam.EmployerHPID, this.myClass_LaborServiceTeam.LaborServiceTeam, null, Enum_zwjKindofUpdate.Add))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "劳务队名称不能重复！";
                    return;
                }
                else
                {
                    if (!this.myClass_LaborServiceTeam.AddAndModify(Enum_zwjKindofUpdate.Add))
                    {
                        this.label_ErrMessage.Text = "添加不成功！";
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
            }
            else
            {
                if (Class_LaborServiceTeam.ExistSecond(this.myClass_LaborServiceTeam.EmployerHPID, this.myClass_LaborServiceTeam.LaborServiceTeam, this.myClass_LaborServiceTeam.LaborServiceTeamHPID, Enum_zwjKindofUpdate.Modify))
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "劳务队名称不能重复！";
                    return;
                }
                else
                {
                    this.myClass_LaborServiceTeam.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
        }
    }
}