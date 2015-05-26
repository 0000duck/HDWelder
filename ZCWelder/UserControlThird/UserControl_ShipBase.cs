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
    public partial class UserControl_ShipBase : UserControl
    {
        public Class_Ship myClass_Ship;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_Ship myClass_ShipDefault;

        public UserControl_ShipBase()
        {
            InitializeComponent();
        }

        private void UserControl_Ship_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_Ship"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_Ship myClass_Ship, bool bool_Add)
        {
            for (int i =0 ;i<=25 ;i++)
            {
                this.ComboBox_Leter.Items.Add((char )(97 + i));
            }
            this.ComboBox_Leter.Text = "a";
            Class_Public.InitializeComboBox(this.ComboBox_TestCommitteeID, Enum_DataTable.TestCommittee.ToString(), "TestCommitteeID", "TestCommitteeID");

            this.myClass_Ship= myClass_Ship;
            if (bool_Add)
            {
                if (myClass_ShipDefault != null)
                {
                    this.ComboBox_TestCommitteeID.SelectedValue = myClass_ShipDefault.TestCommitteeID;
                    this.MaskedTextBox_NextSkillIssueNo.Text = myClass_ShipDefault.NextSkillIssueNo;
                    this.MaskedTextBox_NextSkillExaminingNo.Text = myClass_ShipDefault.NextSkillExaminingNo;
                    this.MaskedTextBox_NextCertificateNo.Text = myClass_ShipDefault.NextCertificateNo;
                    this.MaskedTextBox_NextTheoryIssueNo.Text = myClass_ShipDefault.NextTheoryIssueNo;
                    this.MaskedTextBox_NextTheoryExaminingNo.Text = myClass_ShipDefault.NextTheoryExaminingNo;

                    if (myClass_ShipDefault.SkillIssueNoSignificantDigit >= this.NumericUpDown_SkillIssueNoSignificantDigit.Minimum && myClass_ShipDefault.SkillIssueNoSignificantDigit <= this.NumericUpDown_SkillIssueNoSignificantDigit.Maximum)
                    {
                        this.NumericUpDown_SkillIssueNoSignificantDigit.Value = myClass_ShipDefault.SkillIssueNoSignificantDigit;
                    }
                    if (myClass_ShipDefault.SkillExaminingNoSignificantDigit  >= this.NumericUpDown_SkillExaminingNoSignificantDigit.Minimum && myClass_ShipDefault.SkillExaminingNoSignificantDigit <= this.NumericUpDown_SkillExaminingNoSignificantDigit.Maximum)
                    {
                        this.NumericUpDown_SkillExaminingNoSignificantDigit.Value =myClass_ShipDefault.SkillExaminingNoSignificantDigit;
                    }
                    if (myClass_ShipDefault.CertificateNoSignificantDigit >= this.NumericUpDown_CertificateNoSignificantDigit.Minimum && myClass_ShipDefault.CertificateNoSignificantDigit <= this.NumericUpDown_CertificateNoSignificantDigit.Maximum)
                    {
                        this.NumericUpDown_CertificateNoSignificantDigit.Value =myClass_ShipDefault.CertificateNoSignificantDigit;
                    }
                    if (myClass_ShipDefault.TheoryIssueNoSignificantDigit >= this.NumericUpDown_TheoryIssueNoSignificantDigit.Minimum && myClass_ShipDefault.TheoryIssueNoSignificantDigit <= this.NumericUpDown_TheoryIssueNoSignificantDigit.Maximum)
                    {
                        this.NumericUpDown_TheoryIssueNoSignificantDigit.Value = myClass_ShipDefault.TheoryIssueNoSignificantDigit;
                    }
                    if (myClass_ShipDefault.TheoryExaminingNoSignificantDigit >= this.NumericUpDown_TheoryExaminingNoSignificantDigit.Minimum && myClass_ShipDefault.TheoryExaminingNoSignificantDigit <= this.NumericUpDown_TheoryExaminingNoSignificantDigit.Maximum)
                    {
                        this.NumericUpDown_TheoryExaminingNoSignificantDigit.Value = myClass_ShipDefault.TheoryExaminingNoSignificantDigit;
                    }

                    this.TextBox_SkillIssueNoRegex.Text = myClass_ShipDefault.SkillIssueNoRegex;
                    this.TextBox_SkillExaminingNoRegex.Text = myClass_ShipDefault.SkillExaminingNoRegex;
                    this.TextBox_CertificateNoRegex.Text = myClass_ShipDefault.CertificateNoRegex;
                    this.TextBox_TheoryIssueNoRegex.Text = myClass_ShipDefault.TheoryIssueNoRegex;
                    this.TextBox_TheoryExaminingNoRegex.Text = myClass_ShipDefault.TheoryExaminingNoRegex;
                }
            }
            else
            {
                this.TextBox_ShipboardNo.ReadOnly=true;
                this.TextBox_ShipboardNo.Text = this.myClass_Ship.ShipboardNo;
                this.TextBox_ModelNo.Text = this.myClass_Ship.ModelNo;
                this.ComboBox_Leter.Text = this.myClass_Ship.ShipLetter;
                this.TextBox_ShipCompetence.Text = this.myClass_Ship.ShipCompetence;
                this.TextBox_ShipRemark.Text = this.myClass_Ship.ShipRemark;
                if (myClass_Ship.ShipIndex >= this.numericUpDown_ShipIndex.Minimum && myClass_Ship.ShipIndex <= this.numericUpDown_ShipIndex.Maximum)
                {
                    this.numericUpDown_ShipIndex.Value = this.myClass_Ship.ShipIndex;
                }

                this.ComboBox_TestCommitteeID.SelectedValue = this.myClass_Ship.TestCommitteeID;
                this.MaskedTextBox_NextSkillIssueNo.Text = this.myClass_Ship.NextSkillIssueNo;
                this.MaskedTextBox_NextSkillExaminingNo.Text = this.myClass_Ship.NextSkillExaminingNo;
                this.MaskedTextBox_NextCertificateNo.Text = this.myClass_Ship.NextCertificateNo;
                this.MaskedTextBox_NextTheoryIssueNo.Text = this.myClass_Ship.NextTheoryIssueNo;
                this.MaskedTextBox_NextTheoryExaminingNo.Text = this.myClass_Ship.NextTheoryExaminingNo;

                if (myClass_Ship.SkillIssueNoSignificantDigit >= this.NumericUpDown_SkillIssueNoSignificantDigit.Minimum && myClass_Ship.SkillIssueNoSignificantDigit <= this.NumericUpDown_SkillIssueNoSignificantDigit.Maximum)
                {
                    this.NumericUpDown_SkillIssueNoSignificantDigit.Value = myClass_Ship.SkillIssueNoSignificantDigit;
                }
                if (myClass_Ship.SkillExaminingNoSignificantDigit >= this.NumericUpDown_SkillExaminingNoSignificantDigit.Minimum && myClass_Ship.SkillExaminingNoSignificantDigit <= this.NumericUpDown_SkillExaminingNoSignificantDigit.Maximum)
                {
                    this.NumericUpDown_SkillExaminingNoSignificantDigit.Value = myClass_Ship.SkillExaminingNoSignificantDigit;
                }
                if (myClass_Ship.CertificateNoSignificantDigit >= this.NumericUpDown_CertificateNoSignificantDigit.Minimum && myClass_Ship.CertificateNoSignificantDigit <= this.NumericUpDown_CertificateNoSignificantDigit.Maximum)
                {
                    this.NumericUpDown_CertificateNoSignificantDigit.Value = myClass_Ship.CertificateNoSignificantDigit;
                }
                if (myClass_Ship.TheoryIssueNoSignificantDigit >= this.NumericUpDown_TheoryIssueNoSignificantDigit.Minimum && myClass_Ship.TheoryIssueNoSignificantDigit <= this.NumericUpDown_TheoryIssueNoSignificantDigit.Maximum)
                {
                    this.NumericUpDown_TheoryIssueNoSignificantDigit.Value = myClass_Ship.TheoryIssueNoSignificantDigit;
                }
                if (myClass_Ship.TheoryExaminingNoSignificantDigit >= this.NumericUpDown_TheoryExaminingNoSignificantDigit.Minimum && myClass_Ship.TheoryExaminingNoSignificantDigit <= this.NumericUpDown_TheoryExaminingNoSignificantDigit.Maximum)
                {
                    this.NumericUpDown_TheoryExaminingNoSignificantDigit.Value = myClass_Ship.TheoryExaminingNoSignificantDigit;
                }

                this.TextBox_SkillIssueNoRegex.Text = this.myClass_Ship.SkillIssueNoRegex;
                this.TextBox_SkillExaminingNoRegex.Text = this.myClass_Ship.SkillExaminingNoRegex;
                this.TextBox_CertificateNoRegex.Text = this.myClass_Ship.CertificateNoRegex;
                this.TextBox_TheoryIssueNoRegex.Text = this.myClass_Ship.TheoryIssueNoRegex;
                this.TextBox_TheoryExaminingNoRegex.Text = this.myClass_Ship.TheoryExaminingNoRegex;

                if (myClass_Ship.ShipIndex >= this.numericUpDown_ShipIndex.Minimum && myClass_Ship.ShipIndex <= this.numericUpDown_ShipIndex.Maximum)
                {
                    this.numericUpDown_ShipIndex.Value = myClass_Ship.ShipIndex;
                }
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            this.myClass_Ship.ShipboardNo = this.TextBox_ShipboardNo.Text;
            this.myClass_Ship.TestCommitteeID = this.myClass_Ship.ShipboardNo;
            this.myClass_Ship.ModelNo = this.TextBox_ModelNo.Text;
            this.myClass_Ship.ShipLetter = this.ComboBox_Leter.Text;
            this.myClass_Ship.ShipCompetence = this.TextBox_ShipCompetence.Text;
            this.myClass_Ship.ShipRemark = this.TextBox_ShipRemark.Text;
           
            this.myClass_Ship.TestCommitteeID = this.ComboBox_TestCommitteeID.SelectedValue.ToString();
            this.myClass_Ship.NextSkillIssueNo = this.MaskedTextBox_NextSkillIssueNo.Text;
            this.myClass_Ship.NextSkillExaminingNo = this.MaskedTextBox_NextSkillExaminingNo.Text;
            this.myClass_Ship.NextCertificateNo = this.MaskedTextBox_NextCertificateNo.Text;
            this.myClass_Ship.NextTheoryIssueNo = this.MaskedTextBox_NextTheoryIssueNo.Text;
            this.myClass_Ship.NextTheoryExaminingNo = this.MaskedTextBox_NextTheoryExaminingNo.Text;

            this.myClass_Ship.SkillIssueNoSignificantDigit =(int)this.NumericUpDown_SkillIssueNoSignificantDigit.Value;
            this.myClass_Ship.SkillExaminingNoSignificantDigit =(int)this.NumericUpDown_SkillExaminingNoSignificantDigit.Value;
            this.myClass_Ship.CertificateNoSignificantDigit =(int)this.NumericUpDown_CertificateNoSignificantDigit.Value;
            this.myClass_Ship.TheoryIssueNoSignificantDigit = (int)this.NumericUpDown_TheoryIssueNoSignificantDigit.Value;
            this.myClass_Ship.TheoryExaminingNoSignificantDigit =(int)this.NumericUpDown_TheoryExaminingNoSignificantDigit.Value;

            this.myClass_Ship.SkillIssueNoRegex = this.TextBox_SkillIssueNoRegex.Text;
            this.myClass_Ship.SkillExaminingNoRegex = this.TextBox_SkillExaminingNoRegex.Text;
            this.myClass_Ship.CertificateNoRegex = this.TextBox_CertificateNoRegex.Text;
            this.myClass_Ship.TheoryIssueNoRegex = this.TextBox_TheoryIssueNoRegex.Text;
            this.myClass_Ship.TheoryExaminingNoRegex = this.TextBox_TheoryExaminingNoRegex.Text;

            myClass_Ship.ShipIndex  = (int)this.numericUpDown_ShipIndex .Value;

            if (myClass_ShipDefault == null)
            {
                myClass_ShipDefault = new Class_Ship();
            }
            myClass_ShipDefault.TestCommitteeID = this.myClass_Ship.TestCommitteeID;
            myClass_ShipDefault.NextSkillIssueNo = this.myClass_Ship.NextSkillIssueNo;
            myClass_ShipDefault.NextSkillExaminingNo = this.myClass_Ship.NextSkillExaminingNo;
            myClass_ShipDefault.NextCertificateNo = this.myClass_Ship.NextCertificateNo;
            myClass_ShipDefault.NextTheoryIssueNo = this.myClass_Ship.NextTheoryIssueNo;
            myClass_ShipDefault.NextTheoryExaminingNo = this.myClass_Ship.NextTheoryExaminingNo;

            myClass_ShipDefault.SkillIssueNoSignificantDigit = this.myClass_Ship.SkillIssueNoSignificantDigit;
            myClass_ShipDefault.SkillExaminingNoSignificantDigit = this.myClass_Ship.SkillExaminingNoSignificantDigit;
            myClass_ShipDefault.CertificateNoSignificantDigit = this.myClass_Ship.CertificateNoSignificantDigit;
            myClass_ShipDefault.TheoryIssueNoSignificantDigit = this.myClass_Ship.TheoryIssueNoSignificantDigit;
            myClass_ShipDefault.TheoryExaminingNoSignificantDigit = this.myClass_Ship.TheoryExaminingNoSignificantDigit;

            myClass_ShipDefault.SkillIssueNoRegex = this.myClass_Ship.SkillIssueNoRegex;
            myClass_ShipDefault.SkillExaminingNoRegex = this.myClass_Ship.SkillExaminingNoRegex;
            myClass_ShipDefault.CertificateNoRegex = this.myClass_Ship.CertificateNoRegex;
            myClass_ShipDefault.TheoryIssueNoRegex = this.myClass_Ship.TheoryIssueNoRegex;
            myClass_ShipDefault.TheoryExaminingNoRegex = this.myClass_Ship.TheoryExaminingNoRegex;

        }

        private void Button_Leter_Click(object sender, EventArgs e)
        {
            this.MaskedTextBox_NextSkillIssueNo.Text =string.Format( "J{0}{1}-001" , this.ComboBox_Leter.Text , DateTime.Today.Year  );
            this.MaskedTextBox_NextSkillExaminingNo.Text =string.Format(  "J{0}-0001" ,this.ComboBox_Leter.Text);
            this.MaskedTextBox_NextCertificateNo.Text = string.Format("GX{0}0001" , this.ComboBox_Leter.Text);
            this.MaskedTextBox_NextTheoryIssueNo.Text = string.Format("JT{0}{1}-001", this.ComboBox_Leter.Text, DateTime.Today.Year);
            this.MaskedTextBox_NextTheoryExaminingNo.Text = string.Format("JT{0}{1}0001" , this.ComboBox_Leter.Text , DateTime.Today.Year.ToString().Substring (2));

            this.NumericUpDown_SkillIssueNoSignificantDigit.Value = 3;
            this.NumericUpDown_SkillExaminingNoSignificantDigit.Value = 4;
            this.NumericUpDown_CertificateNoSignificantDigit.Value = 4;
            this.NumericUpDown_TheoryIssueNoSignificantDigit.Value = 3;
            this.NumericUpDown_TheoryExaminingNoSignificantDigit.Value = 4;

            this.TextBox_SkillIssueNoRegex.Text =string .Format( "^J{0}\\d{{4}}-\\d{{3}}$", this.ComboBox_Leter.Text );
            this.TextBox_SkillExaminingNoRegex.Text =string.Format( "^J{0}-\\d{{4}}$" , this.ComboBox_Leter.Text);
            this.TextBox_CertificateNoRegex.Text =string.Format( "^GX{0}\\d{{4}}$", this.ComboBox_Leter.Text );
            this.TextBox_TheoryIssueNoRegex.Text = string.Format("^JT{0}\\d{{4}}-\\d{{3}}$" , this.ComboBox_Leter.Text );
            this.TextBox_TheoryExaminingNoRegex.Text = string.Format("^JT{0}\\d{{6}}$", this.ComboBox_Leter.Text );

        }

    }
}
