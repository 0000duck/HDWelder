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
    public partial class UserControl_MaterialISOGroupBase : UserControl
    {
        public Class_MaterialISOGroup myClass_MaterialISOGroup;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_MaterialISOGroup myClass_MaterialISOGroupDefault;

        public UserControl_MaterialISOGroupBase()
        {
            InitializeComponent();
        }

        private void UserControl_MaterialISOGroup_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_MaterialISOGroup"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_MaterialISOGroup myClass_MaterialISOGroup, bool bool_Add)
        {
            this.myClass_MaterialISOGroup = myClass_MaterialISOGroup;
            if (bool_Add)
            {
                if (myClass_MaterialISOGroupDefault != null)
                {
                }
            }
            else
            {
                this.textBox_MaterialISOGroupAb.ReadOnly = true;
                this.textBox_MaterialISOGroupAb.Text = myClass_MaterialISOGroup.MaterialISOGroupAb;
                this.textBox_MaterialLRGroupAb.Text = myClass_MaterialISOGroup.MaterialLRGroupAb;
                this.textBox_MaterialISOGroup.Text = myClass_MaterialISOGroup.MaterialISOGroup;
                this.textBox_ScopeofMaterialISOGroup.Text = myClass_MaterialISOGroup.ScopeofMaterialISOGroup;
                this.numericUpDown_MaterialISOGroupIndex.Value = myClass_MaterialISOGroup.MaterialISOGroupIndex;
                this.textBox_MaterialISOGroupRemark.Text = myClass_MaterialISOGroup.MaterialISOGroupRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_MaterialISOGroup.MaterialISOGroupAb = this.textBox_MaterialISOGroupAb.Text;
            myClass_MaterialISOGroup.MaterialLRGroupAb = this.textBox_MaterialLRGroupAb.Text;
            myClass_MaterialISOGroup.MaterialISOGroup = this.textBox_MaterialISOGroup.Text;
            myClass_MaterialISOGroup.ScopeofMaterialISOGroup = this.textBox_ScopeofMaterialISOGroup.Text;
            myClass_MaterialISOGroup.MaterialISOGroupIndex = (int)this.numericUpDown_MaterialISOGroupIndex.Value;
            myClass_MaterialISOGroup.MaterialISOGroupRemark = this.textBox_MaterialISOGroupRemark.Text;

            if (myClass_MaterialISOGroupDefault == null)
            {
                myClass_MaterialISOGroupDefault = new Class_MaterialISOGroup();
            }

        }

    }
}
