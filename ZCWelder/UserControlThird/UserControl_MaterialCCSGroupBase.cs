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
    public partial class UserControl_MaterialCCSGroupBase : UserControl
    {
        public Class_MaterialCCSGroup myClass_MaterialCCSGroup;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_MaterialCCSGroup myClass_MaterialCCSGroupDefault;

        public UserControl_MaterialCCSGroupBase()
        {
            InitializeComponent();
        }

        private void UserControl_MaterialCCSGroup_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_MaterialCCSGroup"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_MaterialCCSGroup myClass_MaterialCCSGroup, bool bool_Add)
        {
            this.myClass_MaterialCCSGroup = myClass_MaterialCCSGroup;
            if (bool_Add)
            {
                if (myClass_MaterialCCSGroupDefault != null)
                {
                }
            }
            else
            {
                this.textBox_MaterialCCSGroupAb.ReadOnly = true;
                this.textBox_MaterialCCSGroupAb.Text = myClass_MaterialCCSGroup.MaterialCCSGroupAb;
                this.textBox_MaterialCCSGroup.Text = myClass_MaterialCCSGroup.MaterialCCSGroup;
                this.textBox_MaterialCCSGroupItemName.Text = myClass_MaterialCCSGroup.MaterialCCSGroupItemName;
                this.textBox_ScopeofMaterialCCSGroup.Text = myClass_MaterialCCSGroup.ScopeofMaterialCCSGroup;
                this.numericUpDown_MaterialCCSGroupIndex.Value = myClass_MaterialCCSGroup.MaterialCCSGroupIndex;
                this.textBox_MaterialCCSGroupRemark.Text = myClass_MaterialCCSGroup.MaterialCCSGroupRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_MaterialCCSGroup.MaterialCCSGroupAb = this.textBox_MaterialCCSGroupAb.Text;
            myClass_MaterialCCSGroup.MaterialCCSGroup = this.textBox_MaterialCCSGroup.Text;
            myClass_MaterialCCSGroup.MaterialCCSGroupItemName = this.textBox_MaterialCCSGroupItemName.Text;
            myClass_MaterialCCSGroup.ScopeofMaterialCCSGroup  = this.textBox_ScopeofMaterialCCSGroup.Text;
            myClass_MaterialCCSGroup.MaterialCCSGroupIndex = (int)this.numericUpDown_MaterialCCSGroupIndex.Value;
            myClass_MaterialCCSGroup.MaterialCCSGroupRemark = this.textBox_MaterialCCSGroupRemark.Text;

            if (myClass_MaterialCCSGroupDefault == null)
            {
                myClass_MaterialCCSGroupDefault = new Class_MaterialCCSGroup();
            }

        }

    }
}
