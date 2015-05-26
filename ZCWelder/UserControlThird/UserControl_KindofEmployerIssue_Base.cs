using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery;
using ZCWelder.WPS;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_KindofEmployerIssue_Base : UserControl
    {
        private DataView myDataView_ShipandShipClassification;
        public Class_KindofEmployerIssue myClass_KindofEmployerIssue;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_KindofEmployerIssue myClass_KindofEmployerIssueDefault;

        public UserControl_KindofEmployerIssue_Base()
        {
            InitializeComponent();
        }

        private void UserControl_KindofEmployerIssue_Base_Load(object sender, EventArgs e)
        {

        }

        public void InitControl(Class_KindofEmployerIssue myClass_KindofEmployerIssue, bool bool_Add)
        {
            Class_Data myClass_ShipandShipClassification = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ShipandShipClassification.ToString()];
            myDataView_ShipandShipClassification = new DataView(myClass_ShipandShipClassification.myDataTable);
            myDataView_ShipandShipClassification.Sort = myClass_ShipandShipClassification.myDataView.Sort;
            Class_DataControlBind.InitializeComboBox(this.comboBox_ShipboardNo,this.myDataView_ShipandShipClassification,"ShipboardNo", "ShipboardNo");

            Class_Public.InitializeComboBox(this.comboBox_Employer, Enum_DataTable.Employer.ToString(), "EmployerHPID", "Employer");
            Class_Public.InitializeComboBox(this.comboBox_ShipClassificationAb, Enum_DataTable.ShipClassification.ToString(), "ShipClassificationAb", "ShipClassificationAb");
            Class_Public.InitializeComboBox(this.ComboBox_Assemblage, Enum_DataTable.Assemblage.ToString(), "Assemblage", "Assemblage");
            Class_Public.InitializeComboBox(this.ComboBox_KindofExam, Enum_DataTable.KindofExam.ToString(), "KindofExam", "KindofExam");
            Class_Public.InitializeComboBox(this.ComboBox_WeldingProcess, Enum_DataTable.WeldingProcess.ToString(), "WeldingProcessAb", "WeldingProcessAb");
            this.myClass_KindofEmployerIssue = myClass_KindofEmployerIssue;
            this.textBox_KindofEmployer.Text = this.myClass_KindofEmployerIssue.KindofEmployer;

            Class_KindofEmployer myClass_KindofEmployer = new Class_KindofEmployer(this.myClass_KindofEmployerIssue.KindofEmployer);
            switch (myClass_KindofEmployer.KindofEmployerLevel)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    this.comboBox_Employer.Enabled = false;
                    break;
            }
            if (bool_Add)
            {
                if (!string.IsNullOrEmpty(myClass_KindofEmployer.KindofEmployerEmployerHPID))
                {
                    this.comboBox_Employer .SelectedValue = myClass_KindofEmployer.KindofEmployerEmployerHPID;
                }
                if (myClass_KindofEmployerIssueDefault != null)
                {
                    this.InitControlWeldingParameter (myClass_KindofEmployerIssueDefault.myClass_WeldingParameter);
                    this.ComboBox_WeldingProcess .SelectedValue  = myClass_KindofEmployerIssueDefault.WeldingProcessAb;
                    if (this.comboBox_Employer.Enabled)
                    {
                        this.comboBox_Employer.SelectedValue = myClass_KindofEmployerIssueDefault.EmployerHPID;
                    }
                    this.myClass_KindofEmployerIssue.EmployerHPID = myClass_KindofEmployerIssueDefault.EmployerHPID;
                    this.comboBox_ShipClassificationAb.SelectedValue = myClass_KindofEmployerIssueDefault.ShipClassificationAb;
                    this.comboBox_ShipboardNo.SelectedValue = myClass_KindofEmployerIssueDefault.ShipboardNo;
                }
            }
            else
            {
                this.textBox_KindofEmployerIssueID.Text = this.myClass_KindofEmployerIssue.KindofEmployerIssueID.ToString();
                this.MaskedTextBox_IssueNo.Text = myClass_KindofEmployerIssue.IssueNo;
                this.textBox_WPSNo.Text = myClass_KindofEmployerIssue.IssueWPSNo;
                this.TextBox_IssueRemark.Text = myClass_KindofEmployerIssue.IssueRemark;
                this.DateTimePicker_SignUpDate.Value = myClass_KindofEmployerIssue.SignUpDate;
                this.textBox_KindofEmployer.Text = myClass_KindofEmployerIssue.KindofEmployer;
                this.comboBox_Employer.SelectedValue = myClass_KindofEmployerIssue.EmployerHPID;
                this.ComboBox_WeldingProcess.SelectedValue = myClass_KindofEmployerIssue.WeldingProcessAb;
                this.comboBox_ShipClassificationAb.SelectedValue = this.myClass_KindofEmployerIssue.ShipClassificationAb;
                this.comboBox_ShipboardNo.SelectedValue = this.myClass_KindofEmployerIssue.ShipboardNo;

                this.InitControlWeldingParameter(this.myClass_KindofEmployerIssue.myClass_WeldingParameter);

            }
        }

        public void InitControlWeldingParameter(Class_WeldingParameter myClass_WeldingParameter)
        {
            this.ComboBox_KindofExam.SelectedValue = myClass_WeldingParameter.KindofExam;
            this.ComboBox_Assemblage.SelectedValue = myClass_WeldingParameter.Assemblage;
            this.textBox_Material.Text = myClass_WeldingParameter.Material;
            this.textBox_WeldingConsumable.Text = myClass_WeldingParameter.WeldingConsumable;
            this.ComboBox_DimensionofMaterial.Text = myClass_WeldingParameter.DimensionofMaterial;
            this.TextBox_Thickness.Text = myClass_WeldingParameter.Thickness;
            this.TextBox_ExternalDiameter.Text = myClass_WeldingParameter.ExternalDiameter;
            this.TextBox_RenderWeldingRodDiameter.Text = myClass_WeldingParameter.RenderWeldingRodDiameter.ToString();
            this.TextBox_WeldingRodDiameter.Text = myClass_WeldingParameter.WeldingRodDiameter.ToString();
            this.TextBox_CoverWeldingRodDiameter.Text = myClass_WeldingParameter.CoverWeldingRodDiameter.ToString();
        }

        public void FillWeldingParameterClass(Class_WeldingParameter myClass_WeldingParameter)
        {
            myClass_WeldingParameter.KindofExam = this.ComboBox_KindofExam.SelectedValue.ToString();
            myClass_WeldingParameter.Assemblage = this.ComboBox_Assemblage.SelectedValue.ToString();
            myClass_WeldingParameter.Material = this.textBox_Material.Text;
            myClass_WeldingParameter.WeldingConsumable = this.textBox_WeldingConsumable.Text;
            myClass_WeldingParameter.Thickness = this.TextBox_Thickness.Text;
            myClass_WeldingParameter.ExternalDiameter = this.TextBox_ExternalDiameter.Text;
            double.TryParse(this.TextBox_RenderWeldingRodDiameter.Text, out myClass_WeldingParameter.RenderWeldingRodDiameter);
            double.TryParse(this.TextBox_WeldingRodDiameter.Text, out myClass_WeldingParameter.WeldingRodDiameter);
            double.TryParse(this.TextBox_CoverWeldingRodDiameter.Text, out myClass_WeldingParameter.CoverWeldingRodDiameter);
            myClass_WeldingParameter.DimensionofMaterial = this.ComboBox_DimensionofMaterial.Text;

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            this.FillWeldingParameterClass(this.myClass_KindofEmployerIssue.myClass_WeldingParameter);
            myClass_KindofEmployerIssue.IssueNo = this.MaskedTextBox_IssueNo.Text;
            myClass_KindofEmployerIssue.IssueRemark = this.TextBox_IssueRemark.Text;
            this.myClass_KindofEmployerIssue.ShipClassificationAb = this.comboBox_ShipClassificationAb.SelectedValue.ToString();
            if (this.comboBox_ShipboardNo.SelectedValue != null)
            {
                this.myClass_KindofEmployerIssue.ShipboardNo=this.comboBox_ShipboardNo.SelectedValue.ToString();
            }
            else
            {
                this.myClass_KindofEmployerIssue.ShipboardNo="";
            }
            myClass_KindofEmployerIssue.WeldingProcessAb = this.ComboBox_WeldingProcess.SelectedValue.ToString();
            myClass_KindofEmployerIssue.EmployerHPID  = this.comboBox_Employer .SelectedValue.ToString();

            myClass_KindofEmployerIssue.SignUpDate = this.DateTimePicker_SignUpDate.Value;

            if (myClass_KindofEmployerIssueDefault == null)
            {
                myClass_KindofEmployerIssueDefault = new Class_KindofEmployerIssue();
            }
            this.FillWeldingParameterClass(myClass_KindofEmployerIssueDefault.myClass_WeldingParameter);
            myClass_KindofEmployerIssueDefault.WeldingProcessAb = myClass_KindofEmployerIssue.WeldingProcessAb;
            myClass_KindofEmployerIssueDefault.EmployerHPID = myClass_KindofEmployerIssue.EmployerHPID;
            myClass_KindofEmployerIssueDefault.ShipClassificationAb = myClass_KindofEmployerIssue.ShipClassificationAb;
            myClass_KindofEmployerIssueDefault.ShipboardNo = myClass_KindofEmployerIssue.ShipboardNo;
            
        }

        private void textBox_Material_DoubleClick(object sender, EventArgs e)
        {
            Form_MaterialQuery myForm = new Form_MaterialQuery();
            myForm.myClass_Material = new Class_Material();
            if (this.myClass_KindofEmployerIssue.myClass_WeldingParameter.Material != null)
            {
                myForm.myClass_Material.Material = this.myClass_KindofEmployerIssue.myClass_WeldingParameter.Material;
                myForm.myClass_Material.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_KindofEmployerIssue.myClass_WeldingParameter.Material = myForm.myClass_Material.Material;
                this.textBox_Material.Text = string.Format("{0}", myForm.myClass_Material.Material);
            }

        }

        private void textBox_WeldingConsumable_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingConsumableQuery myForm = new Form_WeldingConsumableQuery();
            myForm.myClass_WeldingConsumable = new Class_WeldingConsumable();
            if (this.myClass_KindofEmployerIssue.myClass_WeldingParameter.WeldingConsumable  != null)
            {
                myForm.myClass_WeldingConsumable.WeldingConsumable = this.myClass_KindofEmployerIssue.myClass_WeldingParameter.WeldingConsumable;
                myForm.myClass_WeldingConsumable.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_KindofEmployerIssue.myClass_WeldingParameter.WeldingConsumable = myForm.myClass_WeldingConsumable.WeldingConsumable;
                this.textBox_WeldingConsumable.Text = string.Format("{0}", myForm.myClass_WeldingConsumable.WeldingConsumable);
            }

        }

        private void comboBox_ShipClassificationAb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.myDataView_ShipandShipClassification != null)
            {
                this.myDataView_ShipandShipClassification.RowFilter = string.Format("ShipClassificationAb='{0}'", this.comboBox_ShipClassificationAb.SelectedValue);
            }
        }

        private void textBox_WPSNo_DoubleClick(object sender, EventArgs e)
        {
            Form_WpsQuery myForm = new Form_WpsQuery();
            myForm.myClass_WPS = new Class_WPS();
            if (!string.IsNullOrEmpty(this.myClass_KindofEmployerIssue .IssueWPSNo))
            {
                myForm.myClass_WPS.WPSID = this.myClass_KindofEmployerIssue.IssueWPSNo;
                myForm.myClass_WPS.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_KindofEmployerIssue.IssueWPSNo = myForm.myClass_WPS.WPSID;
                this.textBox_WPSNo.Text = string.Format("{0}", myForm.myClass_WPS.WPSID);
            }


        }

    }
}
