using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_Assemblage_Base : UserControl
    {
        public Class_Assemblage myClass_Assemblage;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_Assemblage myClass_AssemblageDefault;

        public UserControl_Assemblage_Base()
        {
            InitializeComponent();
        }

        private void UserControl_Assemblage_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_Assemblage"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_Assemblage myClass_Assemblage, bool bool_Add)
        {
            this.myClass_Assemblage = myClass_Assemblage;
            if (bool_Add)
            {
                if (myClass_AssemblageDefault != null)
                {
                    this.textBox_Assemblage.Text = myClass_AssemblageDefault.Assemblage;
                }
            }
            else
            {
                this.textBox_Assemblage.ReadOnly = true;
                this.textBox_Assemblage.Text = myClass_Assemblage.Assemblage;
                this.textBox_AssemblageEnglish.Text = myClass_Assemblage.AssemblageEnglish;
                this.textBox_ISOAssemblage.Text = myClass_Assemblage.ISOAssemblage;
                this.textBox_ISOWeldingSide.Text = myClass_Assemblage.ISOWeldingSide;
                this.textBox_KindofWeld.Text = myClass_Assemblage.KindofWeld;
                this.textBox_ScopeofCCSAssemblage.Text = myClass_Assemblage.ScopeofCCSAssemblage;
                this.textBox_ScopeofISOAssemblage.Text = myClass_Assemblage.ScopeofISOAssemblage;
                this.textBox_WeldingSide.Text = myClass_Assemblage.WeldingSide;
                if (myClass_Assemblage.AssemblageIndex >= this.numericUpDown_AssemblageIndex.Minimum && myClass_Assemblage.AssemblageIndex <= this.numericUpDown_AssemblageIndex.Maximum)
                {
                    this.numericUpDown_AssemblageIndex.Value = myClass_Assemblage.AssemblageIndex;
                }
                this.textBox_AssemblageRemark.Text = myClass_Assemblage.AssemblageRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_Assemblage.Assemblage = this.textBox_Assemblage.Text;
            myClass_Assemblage.AssemblageEnglish = this.textBox_AssemblageEnglish.Text;
            myClass_Assemblage.ISOAssemblage = this.textBox_ISOAssemblage.Text;
            myClass_Assemblage.ISOWeldingSide = this.textBox_ISOWeldingSide.Text;
            myClass_Assemblage.KindofWeld = this.textBox_KindofWeld.Text;
            myClass_Assemblage.ScopeofCCSAssemblage = this.textBox_ScopeofCCSAssemblage.Text;
            myClass_Assemblage.ScopeofISOAssemblage = this.textBox_ScopeofISOAssemblage.Text;
            myClass_Assemblage.WeldingSide = this.textBox_WeldingSide.Text;
            myClass_Assemblage.AssemblageIndex = (int)this.numericUpDown_AssemblageIndex.Value;
            myClass_Assemblage.AssemblageRemark = this.textBox_AssemblageRemark.Text;

            if (myClass_AssemblageDefault == null)
            {
                myClass_AssemblageDefault = new Class_Assemblage();
            }
            myClass_AssemblageDefault.Assemblage = this.textBox_Assemblage.Text;

        }

    }
}
