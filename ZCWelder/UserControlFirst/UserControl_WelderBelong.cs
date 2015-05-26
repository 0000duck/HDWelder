using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;

namespace ZCWelder.UserControlFirst
{
    public partial class UserControl_WelderBelong : UserControl
    {
        public UserControl_WelderBelong()
        {
            InitializeComponent();
        }

        private void UserControl_WelderBelong_Load(object sender, EventArgs e)
        {
            for (int i = this.tabControl_WelderBelong .TabCount - 1; i >= 0; i--)
            {
                this.tabControl_WelderBelong.SelectedIndex = i;
            }
            Publisher_Unit.EventName += new EventHandler_Unit(InitstatusStrip);

        }

        private void InitstatusStrip(object sender, EventArgs_Unit e)
        {
            Class_WorkPlace myClass_WorkPlace = new Class_WorkPlace();
            Class_Department myClass_Department = new Class_Department();
            Class_Employer myClass_Employer = new Class_Employer();

            if (string.IsNullOrEmpty(e.WorkPlaceHPID))
            {
                if (string.IsNullOrEmpty(e.DepartmentHPID))
                {
                    if (string.IsNullOrEmpty(e.EmployerHPID))
                    {
                        if (string.IsNullOrEmpty(e.EmployerGroup))
                        {
                            myClass_Employer.EmployerGroup = "全部";
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        myClass_Employer.EmployerHPID = e.EmployerHPID;
                        myClass_Employer.FillData();
                        e.EmployerGroup = myClass_Employer.EmployerGroup;
                    }
                }
                else
                {
                    myClass_Department.DepartmentHPID = e.DepartmentHPID;
                    myClass_Department.FillData();
                    myClass_Employer.EmployerHPID = myClass_Department.EmployerHPID;
                    myClass_Employer.FillData();
                    e.EmployerGroup = myClass_Employer.EmployerGroup;
                }
            }
            else
            {
                myClass_WorkPlace.WorkPlaceHPID = e.WorkPlaceHPID;
                myClass_WorkPlace.FillData();
                myClass_Department.DepartmentHPID = myClass_WorkPlace.DepartmentHPID;
                myClass_Department.FillData();
                myClass_Employer.EmployerHPID = myClass_Department.EmployerHPID;
                myClass_Employer.FillData();
                e.EmployerGroup = myClass_Employer.EmployerGroup;
            }
            this.toolStripStatusLabel_EmployerGroup.Text = string.Format("公司组：{0}", e.EmployerGroup);
            this.toolStripStatusLabel_Employer .Text = string.Format("公司：{0}", myClass_Employer.Employer  );
            this.toolStripStatusLabel_Department .Text = string.Format("部门：{0}", myClass_Department.Department  );
            this.toolStripStatusLabel_WorkPlace .Text = string.Format("作业区：{0}", myClass_WorkPlace.WorkPlace );
        }

    }
}
