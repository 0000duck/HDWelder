using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.SystemInformation;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_LaborServiceTeamBase : UserControl
    {
        private Class_LaborServiceTeam myClass_LaborServiceTeam;

        public UserControl_LaborServiceTeamBase()
        {
            InitializeComponent();
        }

        private void UserControl_LaborServiceTeamBase_Load(object sender, EventArgs e)
        {

        }

        public void InitControl(Class_LaborServiceTeam myClass_LaborServiceTeam, bool bool_Add)
        {
            this.myClass_LaborServiceTeam = myClass_LaborServiceTeam;
            this.textBox_EmployerHPID.Text = myClass_LaborServiceTeam.EmployerHPID;
            if (bool_Add == false)
            {
                this.textBox_LaborServiceTeamHPID.Text = myClass_LaborServiceTeam.LaborServiceTeamHPID;
                this.textBox_LaborServiceTeamEnglish.Text = myClass_LaborServiceTeam.LaborServiceTeamEnglish;
                this.textBox_ShortenedLaborServiceTeam.Text = myClass_LaborServiceTeam.ShortenedLaborServiceTeam;
                this.textBox_LaborServiceTeam.Text = myClass_LaborServiceTeam.LaborServiceTeam;
                this.numericUpDown_LaborServiceTeamIndex.Value = myClass_LaborServiceTeam.LaborServiceTeamIndex;
                this.textBox_LaborServiceTeamRemark.Text = myClass_LaborServiceTeam.LaborServiceTeamRemark;
            }
            else
            {

            }

        }

        public void FillClass()
        {
            myClass_LaborServiceTeam.LaborServiceTeam = this.textBox_LaborServiceTeam.Text;
            myClass_LaborServiceTeam.LaborServiceTeamEnglish = this.textBox_LaborServiceTeamEnglish.Text;
            myClass_LaborServiceTeam.ShortenedLaborServiceTeam = this.textBox_ShortenedLaborServiceTeam.Text;
            myClass_LaborServiceTeam.LaborServiceTeamIndex = (int)this.numericUpDown_LaborServiceTeamIndex.Value;
            myClass_LaborServiceTeam.LaborServiceTeamRemark = this.textBox_LaborServiceTeamRemark.Text;

        }

    }
}
