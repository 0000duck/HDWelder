using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.AspNet;
using ZCCL.Report;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_EmployerBase : UserControl
    {
        private Class_Employer myClass_Employer;

        public UserControl_EmployerBase()
        {
            InitializeComponent();
        }

        private void UserControl_EmployerBase_Load(object sender, EventArgs e)
        {

        }

        public void InitControl(Class_Employer myClass_Employer, bool bool_Add)
        {
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.EmployerGroup  .ToString()];
            Class_DataControlBind.InitializeComboBox(this.ComboBox_EmployerGroup, myClass_Data.myDataView, "EmployerGroup", "EmployerGroup");
            this.myClass_Employer = myClass_Employer;

            if (bool_Add == false)
            {
                this.MaskedTextBox_EmployerHPID .ReadOnly = true;
                this.MaskedTextBox_EmployerHPID.Text = myClass_Employer.EmployerHPID ;
                this.TextBox_Employer .Text = myClass_Employer.Employer;
                this.textBox_EmployerAddress  .Text = myClass_Employer.EmployerAddress ;
                this.textBox_EmployerAddressEnglish.Text = myClass_Employer.EmployerAddressEnglish;
                this.textBox_EmployerEmail.Text = myClass_Employer.EmployerEmail;
                this.TextBox_EmployerEnglish.Text = myClass_Employer.EmployerEnglish;
                this.textBox_EmployerFax.Text = myClass_Employer.EmployerFax;
                this.textBox_EmployerLinkman.Text = myClass_Employer.EmployerLinkman;
                this.textBox_EmployerMobile.Text = myClass_Employer.EmployerMobile;
                this.textBox_EmployerPostalcode.Text = myClass_Employer.EmployerPostalcode;
                this.textBox_EmployerCity.Text = myClass_Employer.EmployerCity;
                this.TextBox_EmployerRemark.Text = myClass_Employer.EmployerRemark;
                this.textBox_EmployerTel.Text = myClass_Employer.EmployerTel;
                this.TextBox_ShortenedEmployer.Text = myClass_Employer.ShortenedEmployer;
                this.ComboBox_EmployerGroup.SelectedValue = myClass_Employer.EmployerGroup;
                this.NumericUpDown_EmployerIndex .Value = myClass_Employer.EmployerIndex;
            }
            else
            {
            }

        }

        public void FillClass()
        {
            myClass_Employer.EmployerHPID= this.MaskedTextBox_EmployerHPID.Text  ;
            myClass_Employer.Employer=this.TextBox_Employer.Text  ;
            myClass_Employer.EmployerAddress=this.textBox_EmployerAddress.Text  ;
            myClass_Employer.EmployerAddressEnglish = this.textBox_EmployerAddressEnglish.Text;
            myClass_Employer.EmployerEmail=this.textBox_EmployerEmail.Text ;
            myClass_Employer.EmployerEnglish=this.TextBox_EmployerEnglish.Text ;
            myClass_Employer.EmployerFax=this.textBox_EmployerFax.Text  ;
            myClass_Employer.EmployerLinkman=this.textBox_EmployerLinkman.Text  ;
            myClass_Employer.EmployerMobile= this.textBox_EmployerMobile.Text ;
            myClass_Employer.EmployerPostalcode=this.textBox_EmployerPostalcode.Text ;
            myClass_Employer.EmployerCity=this.textBox_EmployerCity.Text ;
            myClass_Employer.EmployerRemark=this.TextBox_EmployerRemark.Text  ;
            myClass_Employer.EmployerTel=this.textBox_EmployerTel.Text  ;
            myClass_Employer.ShortenedEmployer=this.TextBox_ShortenedEmployer.Text ;
            myClass_Employer.EmployerGroup=this.ComboBox_EmployerGroup.SelectedValue.ToString() ;
            myClass_Employer.EmployerIndex = (int)this.NumericUpDown_EmployerIndex.Value;
        }

    }
}
