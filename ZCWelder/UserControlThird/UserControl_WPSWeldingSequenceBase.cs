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
using ZCWelder.ParameterQuery;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WPSSequenceBase : UserControl
    {
        public Class_WPSWeldingSequence myClass_WPSWeldingSequence;
        private static  Class_WPSWeldingSequence myClass_DefaultWPSWeldingSequence;
        
        public UserControl_WPSSequenceBase()
        {
            InitializeComponent();
        }

        private void UserControl_WPSSequenceBase_Load(object sender, EventArgs e)
        {
            this.textBox_WPSSequenceWeldingConsumable.BackColor = Properties.Settings.Default.textBoxDoubleClickColor;
            
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingProcess.ToString()];
            Class_DataControlBind.InitializeComboBox(this.comboBox_WPSSequenceWeldingProcessAb, myClass_Data.myDataView, "WeldingProcessAb", "WeldingProcessAb");
            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingPosition.ToString()];
            Class_DataControlBind.InitializeComboBox(this.comboBox_WPSSequenceWeldingPosition, myClass_Data.myDataView, "WeldingPosition", "WeldingPosition");
            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.TypeofCurrentAndPolarity.ToString()];
            Class_DataControlBind.InitializeComboBox(this.comboBox_WPSSequenceTypeofCurrentAndPolarity, myClass_Data.myDataView, "TypeofCurrentAndPolarity", "TypeofCurrentAndPolarity");

        }

        public void InitControl(Class_WPSWeldingSequence myClass_WPSWeldingSequence, bool bool_Add)
        {
            this.myClass_WPSWeldingSequence = myClass_WPSWeldingSequence;
            this.textBox_WPSID.Text = myClass_WPSWeldingSequence.WPSID;
            if (bool_Add == false)
            {
                this.textBox_WPSSequenceID.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceID);
                this.textBox_WPSSequenceRemark.Text = myClass_WPSWeldingSequence.WPSSequenceRemark;
                this.textBox_WPSSequenceCurrent.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceCurrent);
                this.textBox_WPSSequenceRateofAirFlow.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceRateofAirFlow);
                this.textBox_WPSSequenceSpeed.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceSpeed);
                this.textBox_WPSSequenceVoltage.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceVoltage);
                this.textBox_WPSSequenceCurrentAmplitude.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceCurrentAmplitude);
                this.textBox_WPSSequenceRateofAirFlowAmplitude.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceRateofAirFlowAmplitude);
                this.textBox_WPSSequenceSpeedAmplitude.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceSpeedAmplitude);
                this.textBox_WPSSequenceVoltageAmplitude.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceVoltageAmplitude);
                this.textBox_WPSSequenceWireFeedRate.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceWireFeedRate);
                this.textBox_WPSSequenceWireFeedRateAmplitude.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceWireFeedRateAmplitude);
                this.textBox_WPSSequenceHeatInput.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceHeatInput);
                this.textBox_WPSSequenceWeldingRodDiameter.Text = string.Format("{0}", myClass_WPSWeldingSequence.WPSSequenceWeldingRodDiameter);
                this.comboBox_WPSSequenceWeldingProcessAb.SelectedValue = myClass_WPSWeldingSequence.WPSSequenceWeldingProcessAb;
                this.comboBox_WPSSequenceWeldingPosition.SelectedValue = myClass_WPSWeldingSequence.WPSSequenceWeldingPosition;
                this.textBox_WPSSequenceWeldingConsumable.Text = myClass_WPSWeldingSequence.WPSSequenceWeldingConsumable;
                this.comboBox_WPSSequenceTypeofCurrentAndPolarity.SelectedValue = myClass_WPSWeldingSequence.WPSSequenceTypeofCurrentAndPolarity;
                this.numericUpDown_WPSSequencePassWeldingBegin.Value = myClass_WPSWeldingSequence.WPSSequencePassWeldingBegin;
                this.numericUpDown_WPSSequencePassWeldingEnd.Value = myClass_WPSWeldingSequence.WPSSequencePassWeldingEnd;
            }
            else
            {
                Class_WPS myClass_WPS = new Class_WPS(this.myClass_WPSWeldingSequence.WPSID);
                this.comboBox_WPSSequenceWeldingProcessAb.SelectedValue = myClass_WPS.WPSWeldingProcessAb ;
                this.comboBox_WPSSequenceWeldingPosition.SelectedValue = myClass_WPS.WPSWeldingPosition;
                this.textBox_WPSSequenceWeldingConsumable.Text = myClass_WPS.WPSWeldingConsumable;
                if (myClass_DefaultWPSWeldingSequence != null && myClass_DefaultWPSWeldingSequence.WPSID == this.myClass_WPSWeldingSequence.WPSID)
                {
                    this.comboBox_WPSSequenceWeldingProcessAb.SelectedValue = myClass_DefaultWPSWeldingSequence.WPSSequenceWeldingProcessAb;
                    this.comboBox_WPSSequenceWeldingPosition.SelectedValue = myClass_DefaultWPSWeldingSequence.WPSSequenceWeldingPosition;
                    this.textBox_WPSSequenceWeldingConsumable.Text = myClass_DefaultWPSWeldingSequence.WPSSequenceWeldingConsumable;
                  
                    this.textBox_WPSSequenceCurrent.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceCurrent);
                    this.textBox_WPSSequenceRateofAirFlow.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceRateofAirFlow);
                    this.textBox_WPSSequenceSpeed.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceSpeed);
                    this.textBox_WPSSequenceVoltage.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceVoltage);
                    this.textBox_WPSSequenceCurrentAmplitude.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceCurrentAmplitude);
                    this.textBox_WPSSequenceRateofAirFlowAmplitude.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceRateofAirFlowAmplitude);
                    this.textBox_WPSSequenceSpeedAmplitude.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceSpeedAmplitude);
                    this.textBox_WPSSequenceVoltageAmplitude.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceVoltageAmplitude);
                    this.textBox_WPSSequenceWeldingRodDiameter.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceWeldingRodDiameter);
                    this.textBox_WPSSequenceWireFeedRate.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceWireFeedRate);
                    this.textBox_WPSSequenceWireFeedRateAmplitude.Text = string.Format("{0}", myClass_DefaultWPSWeldingSequence.WPSSequenceWireFeedRateAmplitude);
                    this.comboBox_WPSSequenceTypeofCurrentAndPolarity.SelectedValue = myClass_DefaultWPSWeldingSequence.WPSSequenceTypeofCurrentAndPolarity;
                    this.numericUpDown_WPSSequencePassWeldingBegin.Value = myClass_DefaultWPSWeldingSequence .WPSSequencePassWeldingEnd + 1;
                    this.numericUpDown_WPSSequencePassWeldingEnd.Value = myClass_DefaultWPSWeldingSequence.WPSSequencePassWeldingEnd + 1;
                    //this.textBox_WPSSequenceRemark.Text = myClass_DefaultWPSWeldingSequence.WPSSequenceRemark;
                }
            }

        }

        public void FillClass()
        {
            if (double.TryParse(this.textBox_WPSSequenceCurrent.Text,  out myClass_WPSWeldingSequence.WPSSequenceCurrent) == false )
            {
                myClass_WPSWeldingSequence.WPSSequenceCurrent = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceRateofAirFlow.Text, out myClass_WPSWeldingSequence.WPSSequenceRateofAirFlow) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceRateofAirFlow = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceSpeed.Text, out myClass_WPSWeldingSequence.WPSSequenceSpeed) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceSpeed = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceVoltage.Text, out myClass_WPSWeldingSequence.WPSSequenceVoltage) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceVoltage = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceCurrentAmplitude.Text, out myClass_WPSWeldingSequence.WPSSequenceCurrentAmplitude) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceCurrentAmplitude = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceRateofAirFlowAmplitude.Text, out myClass_WPSWeldingSequence.WPSSequenceRateofAirFlowAmplitude) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceRateofAirFlowAmplitude = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceSpeedAmplitude.Text, out myClass_WPSWeldingSequence.WPSSequenceSpeedAmplitude) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceSpeedAmplitude = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceVoltageAmplitude.Text, out myClass_WPSWeldingSequence.WPSSequenceVoltageAmplitude) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceVoltageAmplitude = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceHeatInput.Text, out myClass_WPSWeldingSequence.WPSSequenceHeatInput) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceHeatInput = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceWeldingRodDiameter.Text, out myClass_WPSWeldingSequence.WPSSequenceWeldingRodDiameter) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceWeldingRodDiameter = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceWireFeedRate.Text, out myClass_WPSWeldingSequence.WPSSequenceWireFeedRate) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceWireFeedRate = 0;
            }
            if (double.TryParse(this.textBox_WPSSequenceWireFeedRateAmplitude.Text, out myClass_WPSWeldingSequence.WPSSequenceWireFeedRateAmplitude) == false)
            {
                myClass_WPSWeldingSequence.WPSSequenceWireFeedRateAmplitude = 0;
            }                        
            myClass_WPSWeldingSequence.WPSSequenceRemark= this.textBox_WPSSequenceRemark.Text;
            myClass_WPSWeldingSequence.WPSSequenceWeldingProcessAb=(string) this.comboBox_WPSSequenceWeldingProcessAb.SelectedValue  ;
            myClass_WPSWeldingSequence.WPSSequenceWeldingConsumable = this.textBox_WPSSequenceWeldingConsumable .Text ;
            myClass_WPSWeldingSequence.WPSSequenceWeldingPosition = this.comboBox_WPSSequenceWeldingPosition.SelectedValue.ToString();
            myClass_WPSWeldingSequence.WPSSequenceTypeofCurrentAndPolarity=(string)   this.comboBox_WPSSequenceTypeofCurrentAndPolarity.SelectedValue;
            myClass_WPSWeldingSequence.WPSSequencePassWeldingBegin=(int)this.numericUpDown_WPSSequencePassWeldingBegin.Value;
            myClass_WPSWeldingSequence.WPSSequencePassWeldingEnd= (int) this.numericUpDown_WPSSequencePassWeldingEnd.Value  ;
            if (myClass_DefaultWPSWeldingSequence == null)
            {
                myClass_DefaultWPSWeldingSequence = new Class_WPSWeldingSequence();
            }

            myClass_DefaultWPSWeldingSequence.WPSSequenceCurrent = myClass_WPSWeldingSequence.WPSSequenceCurrent;
            myClass_DefaultWPSWeldingSequence.WPSSequenceRateofAirFlow = myClass_WPSWeldingSequence.WPSSequenceRateofAirFlow;
            myClass_DefaultWPSWeldingSequence.WPSSequenceSpeed = myClass_WPSWeldingSequence.WPSSequenceSpeed;
            myClass_DefaultWPSWeldingSequence.WPSSequenceVoltage = myClass_WPSWeldingSequence.WPSSequenceVoltage;
            myClass_DefaultWPSWeldingSequence.WPSSequenceCurrentAmplitude = myClass_WPSWeldingSequence.WPSSequenceCurrentAmplitude;
            myClass_DefaultWPSWeldingSequence.WPSSequenceRateofAirFlowAmplitude = myClass_WPSWeldingSequence.WPSSequenceRateofAirFlowAmplitude;
            myClass_DefaultWPSWeldingSequence.WPSSequenceSpeedAmplitude = myClass_WPSWeldingSequence.WPSSequenceSpeedAmplitude;
            myClass_DefaultWPSWeldingSequence.WPSSequenceVoltageAmplitude = myClass_WPSWeldingSequence.WPSSequenceVoltageAmplitude;
            myClass_DefaultWPSWeldingSequence.WPSSequenceWireFeedRate = myClass_WPSWeldingSequence.WPSSequenceWireFeedRate;
            myClass_DefaultWPSWeldingSequence.WPSSequenceWireFeedRateAmplitude = myClass_WPSWeldingSequence.WPSSequenceWireFeedRateAmplitude;
            myClass_DefaultWPSWeldingSequence.WPSSequenceWeldingRodDiameter = myClass_WPSWeldingSequence.WPSSequenceWeldingRodDiameter;
            myClass_DefaultWPSWeldingSequence.WPSID  = this.myClass_WPSWeldingSequence.WPSID ;
            myClass_DefaultWPSWeldingSequence.WPSSequenceWeldingProcessAb = (string)this.comboBox_WPSSequenceWeldingProcessAb.SelectedValue;
            myClass_DefaultWPSWeldingSequence.WPSSequenceWeldingConsumable = this.textBox_WPSSequenceWeldingConsumable.Text;
            myClass_DefaultWPSWeldingSequence.WPSSequenceWeldingPosition = this.comboBox_WPSSequenceWeldingPosition.SelectedValue.ToString();
            myClass_DefaultWPSWeldingSequence.WPSSequenceTypeofCurrentAndPolarity = (string)this.comboBox_WPSSequenceTypeofCurrentAndPolarity.SelectedValue;
            myClass_DefaultWPSWeldingSequence.WPSSequencePassWeldingBegin = (int)this.numericUpDown_WPSSequencePassWeldingBegin.Value;
            myClass_DefaultWPSWeldingSequence.WPSSequencePassWeldingEnd = (int)this.numericUpDown_WPSSequencePassWeldingEnd.Value;
            myClass_DefaultWPSWeldingSequence.WPSSequenceRemark = myClass_WPSWeldingSequence.WPSSequenceRemark;

        }

        private void button_WPSSequenceHeatInput_Click(object sender, EventArgs e)
        {
            this.FillClass();
            this.textBox_WPSSequenceHeatInput.Text = this.myClass_WPSWeldingSequence.ComputeHeatInput().ToString();
        }

        private void textBox_WPSSequenceWeldingConsumable_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingConsumableQuery myForm = new Form_WeldingConsumableQuery();
            myForm.myClass_WeldingConsumable = new Class_WeldingConsumable();
            if (this.myClass_WPSWeldingSequence.WPSSequenceWeldingConsumable != null)
            {
                myForm.myClass_WeldingConsumable.WeldingConsumable = this.myClass_WPSWeldingSequence.WPSSequenceWeldingConsumable;
                myForm.myClass_WeldingConsumable.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_WPSWeldingSequence.WPSSequenceWeldingConsumable = myForm.myClass_WeldingConsumable.WeldingConsumable;
                this.textBox_WPSSequenceWeldingConsumable.Text = string.Format("{0}", myForm.myClass_WeldingConsumable.WeldingConsumable);
            }

        }

    }
}
