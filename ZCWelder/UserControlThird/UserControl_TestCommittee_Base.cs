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
    public partial class UserControl_TestCommittee_Base : UserControl
    {
        public Class_TestCommittee myClass_TestCommittee;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_TestCommittee myClass_TestCommitteeDefault;

        public UserControl_TestCommittee_Base()
        {
            InitializeComponent();
        }

        private void UserControl_TestCommittee_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_TestCommittee"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_TestCommittee myClass_TestCommittee, bool bool_Add)
        {
            this.myClass_TestCommittee = myClass_TestCommittee;
            if (bool_Add)
            {
                if (myClass_TestCommitteeDefault != null)
                {
                    this.MaskedTextBox_NextRegistrationNo.Text = myClass_TestCommitteeDefault.NextRegistrationNo;
                    this.TextBox_RegistrationNoRegex.Text = myClass_TestCommitteeDefault.RegistrationNoRegex;
                    if (myClass_TestCommitteeDefault.RegistrationNoSignificantDigit >= this.NumericUpDown_RegistrationNoSignificantDigit.Minimum && myClass_TestCommitteeDefault.RegistrationNoSignificantDigit <= this.NumericUpDown_RegistrationNoSignificantDigit.Maximum)
                    {
                        this.NumericUpDown_RegistrationNoSignificantDigit.Value = myClass_TestCommitteeDefault.RegistrationNoSignificantDigit;
                    }
                }
            }
            else
            {
                this.TextBox_TestCommitteeID.ReadOnly = true;
                this.TextBox_TestCommitteeID.Text = myClass_TestCommittee.TestCommitteeID;
                this.TextBox_TestCommittee.Text = myClass_TestCommittee.TestCommittee;
                this.MaskedTextBox_NextRegistrationNo .Text = myClass_TestCommittee.NextRegistrationNo;
                this.TextBox_RegistrationNoRegex.Text = myClass_TestCommittee.RegistrationNoRegex;
                if (myClass_TestCommittee.RegistrationNoSignificantDigit >= this.NumericUpDown_RegistrationNoSignificantDigit.Minimum && myClass_TestCommittee.RegistrationNoSignificantDigit <= this.NumericUpDown_RegistrationNoSignificantDigit.Maximum)
                {
                    this.NumericUpDown_RegistrationNoSignificantDigit.Value = myClass_TestCommittee.RegistrationNoSignificantDigit;
                }
                if (myClass_TestCommittee.TestCommitteeIndex >= this.numericUpDown_TestCommitteeIndex.Minimum && myClass_TestCommittee.TestCommitteeIndex <= this.numericUpDown_TestCommitteeIndex.Maximum)
                {
                    this.numericUpDown_TestCommitteeIndex.Value = myClass_TestCommittee.TestCommitteeIndex;
                }
                this.TextBox_TestCommitteeRemark.Text = myClass_TestCommittee.TestCommitteeRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_TestCommittee.TestCommitteeID = this.TextBox_TestCommitteeID.Text;
            myClass_TestCommittee.TestCommittee = this.TextBox_TestCommittee.Text;
            myClass_TestCommittee.TestCommitteeIndex = (int)this.numericUpDown_TestCommitteeIndex.Value;
            myClass_TestCommittee.TestCommitteeRemark = this.TextBox_TestCommitteeRemark.Text;

            myClass_TestCommittee.NextRegistrationNo = this.MaskedTextBox_NextRegistrationNo .Text;
            myClass_TestCommittee.RegistrationNoRegex = this.TextBox_RegistrationNoRegex.Text;
            myClass_TestCommittee.RegistrationNoSignificantDigit  = (int)this.NumericUpDown_RegistrationNoSignificantDigit .Value;

            if (myClass_TestCommitteeDefault == null)
            {
                myClass_TestCommitteeDefault = new Class_TestCommittee();
            }
            myClass_TestCommitteeDefault.NextRegistrationNo = myClass_TestCommittee.NextRegistrationNo;
            myClass_TestCommitteeDefault.RegistrationNoRegex = myClass_TestCommittee.RegistrationNoRegex;
            myClass_TestCommitteeDefault.RegistrationNoSignificantDigit = myClass_TestCommittee.RegistrationNoSignificantDigit;

        }

    }
}
