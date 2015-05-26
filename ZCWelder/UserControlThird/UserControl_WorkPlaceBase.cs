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
    public partial class UserControl_WorkPlaceBase : UserControl
    {
        private Class_WorkPlace myClass_WorkPlace;
        
        public UserControl_WorkPlaceBase()
        {
            InitializeComponent();
        }

        private void UserControl_WorkPlaceBase_Load(object sender, EventArgs e)
        {

        }

        public void InitControl(Class_WorkPlace myClass_WorkPlace, bool bool_Add)
        {
            this.myClass_WorkPlace = myClass_WorkPlace;
            this.textBox_DepartmentHPID .Text = myClass_WorkPlace.DepartmentHPID ;
            if (bool_Add == false)
            {
                this.textBox_WorkPlaceHPID.Text = myClass_WorkPlace.WorkPlaceHPID;
                this.textBox_WorkPlaceEnglish.Text = myClass_WorkPlace.WorkPlaceEnglish;
                this.textBox_ShortenedWorkPlace.Text = myClass_WorkPlace.ShortenedWorkPlace;
                this.textBox_WorkPlace.Text = myClass_WorkPlace.WorkPlace;
                this.numericUpDown_WorkPlaceIndex.Value = myClass_WorkPlace.WorkPlaceIndex;
                this.textBox_WorkPlaceRemark.Text = myClass_WorkPlace.WorkPlaceRemark;
            }
            else
            {

            }

        }

        public void FillClass()
        {
            myClass_WorkPlace.WorkPlace = this.textBox_WorkPlace.Text;
            myClass_WorkPlace.WorkPlaceEnglish = this.textBox_WorkPlaceEnglish.Text;
            myClass_WorkPlace.ShortenedWorkPlace = this.textBox_ShortenedWorkPlace.Text;
            myClass_WorkPlace.WorkPlaceIndex = (int)this.numericUpDown_WorkPlaceIndex.Value;
            myClass_WorkPlace.WorkPlaceRemark = this.textBox_WorkPlaceRemark.Text;

        }

    }
}
