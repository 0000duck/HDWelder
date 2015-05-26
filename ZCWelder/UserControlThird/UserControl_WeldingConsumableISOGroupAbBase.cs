using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WeldingConsumableISOGroupBase : UserControl
    {
        public Class_WeldingConsumableISOGroup myClass_WeldingConsumableISOGroup;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_WeldingConsumableISOGroup myClass_WeldingConsumableISOGroupDefault;

        public UserControl_WeldingConsumableISOGroupBase()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingConsumableISOGroup_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_WeldingConsumableISOGroup"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_WeldingConsumableISOGroup myClass_WeldingConsumableISOGroup, bool bool_Add)
        {
            this.myClass_WeldingConsumableISOGroup = myClass_WeldingConsumableISOGroup;
            if (bool_Add)
            {
                if (myClass_WeldingConsumableISOGroupDefault != null)
                {
                }
            }
            else
            {
                this.textBox_WeldingConsumableISOGroupAb.ReadOnly = true;
                this.textBox_WeldingConsumableISOGroupAb.Text = myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupAb;
                this.textBox_WeldingConsumableISOGroup.Text = myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroup;
                this.textBox_ScopeofWeldingConsumableISOGroup.Text = myClass_WeldingConsumableISOGroup.ScopeofWeldingConsumableISOGroup;
                this.numericUpDown_WeldingConsumableISOGroupIndex.Value = myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupIndex;
                this.textBox_WeldingConsumableISOGroupRemark.Text = myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupAb = this.textBox_WeldingConsumableISOGroupAb.Text;
            myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroup = this.textBox_WeldingConsumableISOGroup.Text;
            myClass_WeldingConsumableISOGroup.ScopeofWeldingConsumableISOGroup = this.textBox_ScopeofWeldingConsumableISOGroup.Text;
            myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupIndex = (int)this.numericUpDown_WeldingConsumableISOGroupIndex.Value;
            myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupRemark = this.textBox_WeldingConsumableISOGroupRemark.Text;

            if (myClass_WeldingConsumableISOGroupDefault == null)
            {
                myClass_WeldingConsumableISOGroupDefault = new Class_WeldingConsumableISOGroup();
            }

        }

    }
}
