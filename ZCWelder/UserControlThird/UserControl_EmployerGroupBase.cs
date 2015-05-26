using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_EmployerGroupBase : UserControl
    {
        public Class_EmployerGroup myClass_EmployerGroup;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_EmployerGroup myClass_EmployerGroupDefault;

        public UserControl_EmployerGroupBase()
        {
            InitializeComponent();
        }

        private void UserControl_EmployerGroup_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_EmployerGroup"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_EmployerGroup myClass_EmployerGroup, bool bool_Add)
        {
            this.myClass_EmployerGroup = myClass_EmployerGroup;
            if (bool_Add)
            {
                if (myClass_EmployerGroupDefault != null)
                {
                    this.textBox_EmployerGroup.Text = myClass_EmployerGroupDefault.EmployerGroup;
                }
            }
            else
            {
                this.textBox_EmployerGroup.ReadOnly = true;
                this.textBox_EmployerGroup.Text = myClass_EmployerGroup.EmployerGroup;
                this.checkBox_OAVisible .Checked  = myClass_EmployerGroup.OAVisible;
                if (myClass_EmployerGroup.EmployerGroupIndex >= this.numericUpDown_EmployerGroupIndex.Minimum && myClass_EmployerGroup.EmployerGroupIndex <= this.numericUpDown_EmployerGroupIndex.Maximum)
                {
                    this.numericUpDown_EmployerGroupIndex.Value = myClass_EmployerGroup.EmployerGroupIndex;
                }
                this.textBox_EmployerGroupRemark.Text = myClass_EmployerGroup.EmployerGroupRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_EmployerGroup.EmployerGroup = this.textBox_EmployerGroup.Text;
            myClass_EmployerGroup.OAVisible = this.checkBox_OAVisible.Checked ;
            myClass_EmployerGroup.EmployerGroupIndex = (int)this.numericUpDown_EmployerGroupIndex.Value;
            myClass_EmployerGroup.EmployerGroupRemark = this.textBox_EmployerGroupRemark.Text;

            if (myClass_EmployerGroupDefault == null)
            {
                myClass_EmployerGroupDefault = new Class_EmployerGroup();
            }
            myClass_EmployerGroupDefault.EmployerGroup = this.textBox_EmployerGroup.Text;

        }

    }
}
