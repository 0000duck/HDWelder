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
    public partial class UserControl_ShipClassificationBase : UserControl
    {
        public Class_ShipClassification myClass_ShipClassification;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_ShipClassification myClass_ShipClassificationDefault;

        public UserControl_ShipClassificationBase()
        {
            InitializeComponent();
        }

        private void UserControl_ShipClassification_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_ShipClassification"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_ShipClassification myClass_ShipClassification, bool bool_Add)
        {
            Class_Public.InitializeComboBox(this.ComboBox_TestCommitteeID, Enum_DataTable.TestCommittee.ToString(), "TestCommitteeID", "TestCommitteeID");
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingStandardAndGroup.ToString()];
            DataView myDataView_WeldingStandardAndGroup = new DataView(myClass_Data.myDataTable);
            myDataView_WeldingStandardAndGroup.RowFilter = "WeldingStandardGroup='焊工考试标准'";
            Class_DataControlBind.InitializeComboBox(this.ComboBox_WeldingStandard , myDataView_WeldingStandardAndGroup, "WeldingStandard", "WeldingStandard");
            this.myClass_ShipClassification = myClass_ShipClassification;
            if (bool_Add)
            {
                if (myClass_ShipClassificationDefault != null)
                {
                    this.CheckBox_WeldingStandardRestrict.Checked = myClass_ShipClassificationDefault.WeldingStandardRestrict;
                    this.checkBox_YearSeparate.Checked = myClass_ShipClassificationDefault.YearSeparate;
                    this.CheckBox_ShipRestrict.Checked = myClass_ShipClassificationDefault.ShipRestrict;
                    this.CheckBox_TheorySeparate.Checked = myClass_ShipClassificationDefault.TheorySeparate;
                    this.checkBox_ProlongQCContinuous.Checked = myClass_ShipClassificationDefault.ProlongQCContinuous;
                    this.ComboBox_WeldingStandard.SelectedValue = myClass_ShipClassificationDefault.WeldingStandard;
                    this.MaskedTextBox_NextIssueNo.Text = myClass_ShipClassificationDefault.NextIssueNo;
                    this.MaskedTextBox_NextExaminingNo.Text = myClass_ShipClassificationDefault.NextExaminingNo;
                    this.MaskedTextBox_NextCertificateNo.Text = myClass_ShipClassificationDefault.NextCertificateNo;
                    if (myClass_ShipClassificationDefault.IssueNoSignificantDigit >= this.NumericUpDown_IssueNoSignificantDigit.Minimum && myClass_ShipClassificationDefault.IssueNoSignificantDigit <= this.NumericUpDown_IssueNoSignificantDigit.Maximum)
                    {
                        this.NumericUpDown_IssueNoSignificantDigit.Value = myClass_ShipClassificationDefault.IssueNoSignificantDigit;
                    }
                    if (myClass_ShipClassificationDefault.ExaminingNoSignificantDigit >= this.NumericUpDown_ExaminingNoSignificantDigit.Minimum && myClass_ShipClassificationDefault.ExaminingNoSignificantDigit <= this.NumericUpDown_ExaminingNoSignificantDigit.Maximum)
                    {
                        this.NumericUpDown_ExaminingNoSignificantDigit.Value = myClass_ShipClassificationDefault.ExaminingNoSignificantDigit;
                    }
                    if (myClass_ShipClassificationDefault.CertificateNoSignificantDigit >= this.NumericUpDown_CertificateNoSignificantDigit.Minimum && myClass_ShipClassificationDefault.CertificateNoSignificantDigit <= this.NumericUpDown_CertificateNoSignificantDigit.Maximum)
                    {
                        this.NumericUpDown_CertificateNoSignificantDigit.Value = myClass_ShipClassificationDefault.CertificateNoSignificantDigit;
                    }
                    this.TextBox_IssueNoRegex.Text = myClass_ShipClassificationDefault.IssueNoRegex;
                    this.TextBox_ExaminingNoRegex.Text = myClass_ShipClassificationDefault.ExaminingNoRegex;
                    this.TextBox_CertificateNoRegex.Text = myClass_ShipClassificationDefault.CertificateNoRegex;
                    this.ComboBox_TestCommitteeID.SelectedValue = myClass_ShipClassificationDefault.TestCommitteeID;
                    if (myClass_ShipClassificationDefault.YearBegin >= this.numericUpDown_YearBegin.Minimum && myClass_ShipClassificationDefault.YearBegin <= this.numericUpDown_YearBegin.Maximum)
                    {
                        this.numericUpDown_YearBegin.Value = myClass_ShipClassificationDefault.YearBegin;
                    }
                    if (myClass_ShipClassificationDefault.YearEnd >= this.numericUpDown_YearEnd.Minimum && myClass_ShipClassificationDefault.YearEnd <= this.numericUpDown_YearEnd.Maximum)
                    {
                        this.numericUpDown_YearEnd.Value = myClass_ShipClassificationDefault.YearEnd ;
                    }
                }
            }
            else
            {
                this.TextBox_ShipClassificationAb.ReadOnly=true;
                this.TextBox_ShipClassificationAb.Text = this.myClass_ShipClassification.ShipClassificationAb;
                this.TextBox_ShipClassification.Text = this.myClass_ShipClassification.ShipClassification;
                if (myClass_ShipClassification.ShipClassificationIndex >= this.numericUpDown_ShipClassificationIndex.Minimum && myClass_ShipClassification.ShipClassificationIndex <= this.numericUpDown_ShipClassificationIndex.Maximum)
                {
                    this.numericUpDown_ShipClassificationIndex   .Value = this.myClass_ShipClassification.ShipClassificationIndex;
                }
                this.TextBox_ShipClassificationEnglishName .Text = this.myClass_ShipClassification.ShipClassificationEnglishName;
                this.TextBox_ShipClassificationRemark.Text = this.myClass_ShipClassification.ShipClassificationRemark;

                this.CheckBox_WeldingStandardRestrict.Checked = this.myClass_ShipClassification.WeldingStandardRestrict;
                this.checkBox_YearSeparate.Checked=this.myClass_ShipClassification.YearSeparate;
                this.CheckBox_ShipRestrict.Checked = this.myClass_ShipClassification.ShipRestrict;
                this.CheckBox_TheorySeparate.Checked = this.myClass_ShipClassification.TheorySeparate;
                this.checkBox_ProlongQCContinuous .Checked = this.myClass_ShipClassification.ProlongQCContinuous;
                this.ComboBox_WeldingStandard.SelectedValue = this.myClass_ShipClassification.WeldingStandard;
                this.MaskedTextBox_NextIssueNo.Text = this.myClass_ShipClassification.NextIssueNo;
                this.MaskedTextBox_NextExaminingNo.Text = this.myClass_ShipClassification.NextExaminingNo;
                this.MaskedTextBox_NextCertificateNo.Text = this.myClass_ShipClassification.NextCertificateNo;
                if (myClass_ShipClassification.IssueNoSignificantDigit >= this.NumericUpDown_IssueNoSignificantDigit.Minimum && myClass_ShipClassification.IssueNoSignificantDigit <= this.NumericUpDown_IssueNoSignificantDigit.Maximum)
                {
                    this.NumericUpDown_IssueNoSignificantDigit.Value = myClass_ShipClassification.IssueNoSignificantDigit;
                }
                if (myClass_ShipClassification.ExaminingNoSignificantDigit >= this.NumericUpDown_ExaminingNoSignificantDigit.Minimum && myClass_ShipClassification.ExaminingNoSignificantDigit <= this.NumericUpDown_ExaminingNoSignificantDigit.Maximum)
                {
                    this.NumericUpDown_ExaminingNoSignificantDigit.Value = myClass_ShipClassification.ExaminingNoSignificantDigit;
                }
                if (myClass_ShipClassification.CertificateNoSignificantDigit >= this.NumericUpDown_CertificateNoSignificantDigit.Minimum && myClass_ShipClassification.CertificateNoSignificantDigit <= this.NumericUpDown_CertificateNoSignificantDigit.Maximum)
                {
                    this.NumericUpDown_CertificateNoSignificantDigit.Value = myClass_ShipClassification.CertificateNoSignificantDigit;
                }
                this.TextBox_IssueNoRegex.Text = this.myClass_ShipClassification.IssueNoRegex;
                this.TextBox_ExaminingNoRegex.Text = this.myClass_ShipClassification.ExaminingNoRegex;
                this.TextBox_CertificateNoRegex.Text = this.myClass_ShipClassification.CertificateNoRegex;
                this.ComboBox_TestCommitteeID.SelectedValue = this.myClass_ShipClassification.TestCommitteeID;

                if (myClass_ShipClassification.YearBegin >= this.numericUpDown_YearBegin.Minimum && myClass_ShipClassification.YearBegin <= this.numericUpDown_YearBegin.Maximum)
                {
                    this.numericUpDown_YearBegin .Value = this.myClass_ShipClassification.YearBegin ;
                }
                if (myClass_ShipClassification.YearEnd >= this.numericUpDown_YearEnd.Minimum && myClass_ShipClassification.YearEnd <= this.numericUpDown_YearEnd.Maximum)
                {
                    this.numericUpDown_YearEnd.Value = this.myClass_ShipClassification.YearEnd ;
                }

           }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            this.myClass_ShipClassification.ShipClassification = this.TextBox_ShipClassification.Text;
            this.myClass_ShipClassification.ShipClassificationAb = this.TextBox_ShipClassificationAb.Text;
            this.myClass_ShipClassification.ShipClassificationEnglishName = this.TextBox_ShipClassificationEnglishName.Text;
            this.myClass_ShipClassification.ShipClassificationIndex  = (int)this.numericUpDown_ShipClassificationIndex .Value;
            this.myClass_ShipClassification.ShipClassificationRemark = this.TextBox_ShipClassificationRemark.Text;
        
            this.myClass_ShipClassification.TestCommitteeID = this.ComboBox_TestCommitteeID.SelectedValue.ToString();
            this.myClass_ShipClassification.WeldingStandardRestrict = this.CheckBox_WeldingStandardRestrict.Checked;
            this.myClass_ShipClassification.YearSeparate  = this.checkBox_YearSeparate .Checked;
            this.myClass_ShipClassification.ShipRestrict = this.CheckBox_ShipRestrict.Checked;
            this.myClass_ShipClassification.TheorySeparate = this.CheckBox_TheorySeparate.Checked;
            this.myClass_ShipClassification.ProlongQCContinuous = this.checkBox_ProlongQCContinuous .Checked;
            this.myClass_ShipClassification.WeldingStandard = this.ComboBox_WeldingStandard.SelectedValue.ToString();
            this.myClass_ShipClassification.NextIssueNo = this.MaskedTextBox_NextIssueNo.Text;
            this.myClass_ShipClassification.NextExaminingNo = this.MaskedTextBox_NextExaminingNo.Text;
            this.myClass_ShipClassification.NextCertificateNo = this.MaskedTextBox_NextCertificateNo.Text;
            this.myClass_ShipClassification.CertificateNoSignificantDigit = (int )this.NumericUpDown_CertificateNoSignificantDigit.Value;
            this.myClass_ShipClassification.ExaminingNoSignificantDigit =(int)this.NumericUpDown_ExaminingNoSignificantDigit.Value;
            this.myClass_ShipClassification.IssueNoSignificantDigit = (int)this.NumericUpDown_IssueNoSignificantDigit.Value;
            this.myClass_ShipClassification.IssueNoRegex = this.TextBox_IssueNoRegex.Text;
            this.myClass_ShipClassification.ExaminingNoRegex = this.TextBox_ExaminingNoRegex.Text;
            this.myClass_ShipClassification.CertificateNoRegex = this.TextBox_CertificateNoRegex.Text;
            this.myClass_ShipClassification.YearBegin  = (int)this.numericUpDown_YearBegin .Value;
            this.myClass_ShipClassification.YearEnd  = (int)this.numericUpDown_YearEnd .Value;
          
            if (myClass_ShipClassificationDefault == null)
            {
                myClass_ShipClassificationDefault = new Class_ShipClassification();
            }
            myClass_ShipClassificationDefault.TestCommitteeID = this.myClass_ShipClassification.TestCommitteeID;
            myClass_ShipClassificationDefault.WeldingStandardRestrict = this.myClass_ShipClassification.WeldingStandardRestrict;
            myClass_ShipClassificationDefault.YearSeparate = this.myClass_ShipClassification.YearSeparate;
            myClass_ShipClassificationDefault.ShipRestrict = this.myClass_ShipClassification.ShipRestrict;
            myClass_ShipClassificationDefault.TheorySeparate = this.myClass_ShipClassification.TheorySeparate;
            myClass_ShipClassificationDefault.ProlongQCContinuous = this.myClass_ShipClassification.ProlongQCContinuous;
            myClass_ShipClassificationDefault.WeldingStandard = this.myClass_ShipClassification.WeldingStandard;
            myClass_ShipClassificationDefault.NextIssueNo = this.myClass_ShipClassification.NextIssueNo;
            myClass_ShipClassificationDefault.NextExaminingNo = this.myClass_ShipClassification.NextExaminingNo;
            myClass_ShipClassificationDefault.NextCertificateNo = this.myClass_ShipClassification.NextCertificateNo;
            myClass_ShipClassificationDefault.CertificateNoSignificantDigit = this.myClass_ShipClassification.CertificateNoSignificantDigit;
            myClass_ShipClassificationDefault.ExaminingNoSignificantDigit = this.myClass_ShipClassification.ExaminingNoSignificantDigit;
            myClass_ShipClassificationDefault.IssueNoSignificantDigit = this.myClass_ShipClassification.IssueNoSignificantDigit;
            myClass_ShipClassificationDefault.IssueNoRegex = this.myClass_ShipClassification.IssueNoRegex;
            myClass_ShipClassificationDefault.ExaminingNoRegex = this.myClass_ShipClassification.ExaminingNoRegex;
            myClass_ShipClassificationDefault.CertificateNoRegex = this.myClass_ShipClassification.CertificateNoRegex;
            myClass_ShipClassificationDefault.YearBegin = this.myClass_ShipClassification.YearBegin;
            myClass_ShipClassificationDefault.YearEnd = this.myClass_ShipClassification.YearEnd;

        }

        private void checkBox_YearSeparate_CheckedChanged(object sender, EventArgs e)
        {
            this.numericUpDown_YearBegin.Enabled = this.checkBox_YearSeparate.Checked;
            this.numericUpDown_YearEnd.Enabled = this.checkBox_YearSeparate.Checked;
        }

    }
}
