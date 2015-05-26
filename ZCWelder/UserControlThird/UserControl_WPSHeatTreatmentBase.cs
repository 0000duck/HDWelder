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
    public partial class UserControl_WPSHeatTreatmentBase : UserControl
    {
        public Class_WPSHeatTreatment myClass_WPSHeatTreatment;

        public UserControl_WPSHeatTreatmentBase()
        {
            InitializeComponent();
        }

        private void UserControl_WPSHeatTreatmentBase_Load(object sender, EventArgs e)
        {
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.HeatTreatment.ToString()];
            Class_DataControlBind.InitializeComboBox(this.comboBox_WPSHeatTreatment, myClass_Data.myDataView, "HeatTreatment", "HeatTreatment");

            Class_Public.InitializeComboBox(this.comboBox_WPSHeatKindofLimit, Enum_DataTableSecond.KindofLimit.ToString(), "KindofLimit", "KindofLimit");

            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.HeatMethod.ToString()];
            Class_DataControlBind.InitializeComboBox(this.comboBox_WPSHeatMethod, myClass_Data.myDataView, "HeatMethod", "HeatMethod");

        }

        public void InitControl(Class_WPSHeatTreatment myClass_WPSHeatTreatment, bool bool_Add)
        {
            this.myClass_WPSHeatTreatment = myClass_WPSHeatTreatment;
            this.textBox_WPSID.Text = myClass_WPSHeatTreatment.WPSID;
            if (bool_Add == false)
            {
                this.textBox_WPSHeatTreatmentID .Text = string.Format("{0}", myClass_WPSHeatTreatment.WPSHeatTreatmentID);
                this.textBox_WPSHeatTreatmentRemark .Text = myClass_WPSHeatTreatment.WPSHeatTreatmentRemark;
                this.textBox_WPSHeatTreatmentParameter.Text = myClass_WPSHeatTreatment.WPSHeatTreatmentParameter;
                this.textBox_WPSHeatTemperatureMin  .Text =string.Format ("{0}", myClass_WPSHeatTreatment.WPSHeatTemperatureMin) ;
                this.textBox_WPSHeatTemperatureMax  .Text =string.Format ("{0}", myClass_WPSHeatTreatment.WPSHeatTemperatureMax) ;
                this.comboBox_WPSHeatKindofLimit  .SelectedValue = myClass_WPSHeatTreatment.WPSHeatKindofLimit  ;
                this.comboBox_WPSHeatTreatment .SelectedValue = myClass_WPSHeatTreatment.WPSHeatTreatment ;
                this.comboBox_WPSHeatMethod.SelectedValue = myClass_WPSHeatTreatment.WPSHeatMethod;


            }

        }

        public void FillClass()
        {
            myClass_WPSHeatTreatment.WPSHeatTreatmentRemark  = this.textBox_WPSHeatTreatmentRemark .Text;
            myClass_WPSHeatTreatment.WPSHeatTreatmentParameter = this.textBox_WPSHeatTreatmentParameter.Text;
            double.TryParse(this.textBox_WPSHeatTemperatureMin.Text , out myClass_WPSHeatTreatment.WPSHeatTemperatureMin);
            double.TryParse(this.textBox_WPSHeatTemperatureMax.Text , out myClass_WPSHeatTreatment.WPSHeatTemperatureMax);
            myClass_WPSHeatTreatment.WPSHeatTreatment = (string)this.comboBox_WPSHeatTreatment.SelectedValue;
            myClass_WPSHeatTreatment.WPSHeatKindofLimit  = (string)this.comboBox_WPSHeatKindofLimit .SelectedValue;
            myClass_WPSHeatTreatment.WPSHeatMethod = (string)this.comboBox_WPSHeatMethod.SelectedValue;

        }
    }
}
