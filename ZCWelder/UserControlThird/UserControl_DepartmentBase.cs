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
    public partial class UserControl_DepartmentBase : UserControl
    {
        private Class_Department myClass_Department;
        
        public UserControl_DepartmentBase()
        {
            InitializeComponent();
        }

        private void UserControl_DepartmentBase_Load(object sender, EventArgs e)
        {

        }

        public void InitControl(Class_Department myClass_Department, bool bool_Add)
        {
            this.myClass_Department = myClass_Department;
            this.textBox_EmployerHPID.Text  = myClass_Department.EmployerHPID ;
            if (bool_Add == false)
            {
                this.textBox_DepartmentHPID.Text   = myClass_Department.DepartmentHPID ;
                this.textBox_DepartmentEnglish .Text = myClass_Department.DepartmentEnglish ;
                this.textBox_ShortenedDepartment .Text = myClass_Department.ShortenedDepartment ;
                this.textBox_Department.Text = myClass_Department.Department;
                this.numericUpDown_DepartmentIndex.Value = myClass_Department.DepartmentIndex;
                this.textBox_DepartmentRemark.Text = myClass_Department.DepartmentRemark;
            }
            else
            {

            }

        }

        public void FillClass()
        {
            myClass_Department.Department = this.textBox_Department.Text;
            myClass_Department.DepartmentEnglish  = this.textBox_DepartmentEnglish .Text;
            myClass_Department.ShortenedDepartment  = this.textBox_ShortenedDepartment .Text;
            myClass_Department.DepartmentIndex = (int)this.numericUpDown_DepartmentIndex.Value;
            myClass_Department.DepartmentRemark = this.textBox_DepartmentRemark.Text;

        }

    }
}
