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
    public partial class UserControl_TestCommitteeRegistrationNo_Base : UserControl
    {
        public Class_TestCommitteeRegistrationNo myClass_TestCommitteeRegistrationNo;
        /// <summary>
        /// �洢���һ�����������
        /// </summary>
        static private Class_TestCommitteeRegistrationNo myClass_TestCommitteeRegistrationNoDefault;

        public UserControl_TestCommitteeRegistrationNo_Base()
        {
            InitializeComponent();
        }

        private void UserControl_TestCommitteeRegistrationNo_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="myClass_TestCommitteeRegistrationNo"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_TestCommitteeRegistrationNo myClass_TestCommitteeRegistrationNo, bool bool_Add)
        {
            Class_Public.InitializeComboBox(this.ComboBox_TestCommitteeID, Enum_DataTable.TestCommittee.ToString(), "TestCommitteeID", "TestCommitteeID");

            this.myClass_TestCommitteeRegistrationNo = myClass_TestCommitteeRegistrationNo;
            Class_Welder myClass_Welder = new Class_Welder(this.myClass_TestCommitteeRegistrationNo.IdentificationCard);
            this.TextBox_WelderName.Text = myClass_Welder.WelderName;
            this.MaskedTextBox_IdentificationCard.Text = myClass_Welder.IdentificationCard;
            if (bool_Add)
            {
                if (myClass_TestCommitteeRegistrationNoDefault != null)
                {
                }
            }
            else
            {
            }

        }

        /// <summary>
        /// �������ݵ�������
        /// </summary>
        public void FillClass()
        {
            this.myClass_TestCommitteeRegistrationNo.TestCommitteeID = this.ComboBox_TestCommitteeID.SelectedValue.ToString();
            if (myClass_TestCommitteeRegistrationNoDefault == null)
            {
                myClass_TestCommitteeRegistrationNoDefault = new Class_TestCommitteeRegistrationNo();
            }

        }

        private void ComboBox_TestCommitteeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class_TestCommittee myClass_TestCommittee = new Class_TestCommittee(this.ComboBox_TestCommitteeID.SelectedValue.ToString());
            this.MaskedTextBox_RegistrationNo.Text = myClass_TestCommittee.NextRegistrationNo;
        }

    }
}
