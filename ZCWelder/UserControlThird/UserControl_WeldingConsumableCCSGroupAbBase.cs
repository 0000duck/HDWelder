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
    public partial class UserControl_WeldingConsumableCCSGroupBase : UserControl
    {
        public Class_WeldingConsumableCCSGroup myClass_WeldingConsumableCCSGroup;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_WeldingConsumableCCSGroup myClass_WeldingConsumableCCSGroupDefault;

        public UserControl_WeldingConsumableCCSGroupBase()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingConsumableCCSGroup_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_WeldingConsumableCCSGroup"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_WeldingConsumableCCSGroup myClass_WeldingConsumableCCSGroup, bool bool_Add)
        {
            this.myClass_WeldingConsumableCCSGroup = myClass_WeldingConsumableCCSGroup;
            if (bool_Add)
            {
                if (myClass_WeldingConsumableCCSGroupDefault != null)
                {
                }
            }
            else
            {
                this.textBox_WeldingConsumableCCSGroupAb.ReadOnly = true;
                this.textBox_WeldingConsumableCCSGroupAb.Text = myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupAb;
                this.textBox_WeldingConsumableCCSGroup.Text = myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroup;
                this.textBox_ScopeofWeldingConsumableCCSGroup.Text = myClass_WeldingConsumableCCSGroup.ScopeofWeldingConsumableCCSGroup;
                this.numericUpDown_WeldingConsumableCCSGroupIndex.Value = myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupIndex;
                this.textBox_WeldingConsumableCCSGroupRemark.Text = myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupAb = this.textBox_WeldingConsumableCCSGroupAb.Text;
            myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroup = this.textBox_WeldingConsumableCCSGroup.Text;
            myClass_WeldingConsumableCCSGroup.ScopeofWeldingConsumableCCSGroup = this.textBox_ScopeofWeldingConsumableCCSGroup.Text;
            myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupIndex = (int)this.numericUpDown_WeldingConsumableCCSGroupIndex.Value;
            myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupRemark = this.textBox_WeldingConsumableCCSGroupRemark.Text;

            if (myClass_WeldingConsumableCCSGroupDefault == null)
            {
                myClass_WeldingConsumableCCSGroupDefault = new Class_WeldingConsumableCCSGroup();
            }

        }

    }
}
