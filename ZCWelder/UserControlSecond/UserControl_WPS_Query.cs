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

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WPS_Query : UserControl
    {
        public UserControl_WPS_Query()
        {
            InitializeComponent();
        }

        private void UserControl_ProjectFirst_Load(object sender, EventArgs e)
        {
            this.textBox_pWPSWeldingProcessAb.BackColor = Properties.Settings.Default.textBoxDoubleClickColor;
            this.textBox_pWPSWeldingPosition.BackColor = Properties.Settings.Default.textBoxDoubleClickColor;
            this.textBox_pWPSMaterial.BackColor = Properties.Settings.Default.textBoxDoubleClickColor;
            this.textBox_pWPSWeldingConsumable.BackColor = Properties.Settings.Default.textBoxDoubleClickColor;
            Class_Public.InitializeComboBox(this.comboBox_pWPSGrooveType, Enum_DataTable.GrooveType.ToString(), "GrooveType", "GrooveType");
            Class_Public.InitializeComboBox(this.comboBox_pWPSJointType, Enum_DataTable.JointType.ToString(), "JointType", "JointType");
            this.comboBox_pWPSGrooveType.Text = "";
            this.comboBox_pWPSJointType.Text = "";

        }

        private void textBox_pWPSWeldingProcessAb_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingProcessQuery myForm = new Form_WeldingProcessQuery();
            myForm.myClass_WeldingProcess = new Class_WeldingProcess();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.textBox_pWPSWeldingProcessAb.Text = string.Format("{0}", myForm.myClass_WeldingProcess.WeldingProcessAb);
            }
          
        }

        private void textBox_pWPSMaterial_DoubleClick(object sender, EventArgs e)
        {
            Form_MaterialQuery myForm = new Form_MaterialQuery();
            myForm.myClass_Material = new Class_Material();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.textBox_pWPSMaterial.Text = string.Format("{0}", myForm.myClass_Material.Material);
            }


        }

        private void textBox_pWPSWeldingConsumable_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingConsumableQuery myForm = new Form_WeldingConsumableQuery();
            myForm.myClass_WeldingConsumable = new Class_WeldingConsumable();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.textBox_pWPSWeldingConsumable.Text = string.Format("{0}", myForm.myClass_WeldingConsumable.WeldingConsumable);
            }

        }

        private void textBox_pWPSWeldingPosition_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingPositionQuery myForm = new Form_WeldingPositionQuery();
            myForm.myClass_WeldingPosition = new Class_WeldingPosition();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.textBox_pWPSWeldingPosition.Text = string.Format("{0}", myForm.myClass_WeldingPosition.WeldingPosition);
            }

        }

        private void button_pWPSQuery_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.checkBox_Mistiness.Checked)
            {
                if (this.textBox_pWPSIDBegin.Text.Length > 0)
                {
                     if (string.IsNullOrEmpty(this.textBox_pWPSIDEnd.Text))
                    {
                        str_Filter = str_Filter + string.Format(" And WPSID like '%{0}%'", this.textBox_pWPSIDBegin.Text);
                    }
                    else
                    {
                        str_Filter = str_Filter + string.Format(" And (WPSID >= '{0}' And WPSID <= '{1}')", this.textBox_pWPSIDBegin.Text, this.textBox_pWPSIDEnd.Text);
                    }
                }
                if (this.textBox_pWPSDenomination.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSDenomination like '%{0}%'", this.textBox_pWPSDenomination.Text);
                }
                if (this.textBox_pWPSWeldingProcessAb.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSWeldingProcessAb like '%{0}%'", this.textBox_pWPSWeldingProcessAb.Text);
                }
                if (this.textBox_pWPSMaterial.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And (WPSMaterial like '%{0}%' Or WPSMaterialSecond like '%{0}%')", this.textBox_pWPSMaterial.Text);
                }
                if (this.textBox_pWPSWeldingConsumable.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSWeldingConsumable like '%{0}%'", this.textBox_pWPSWeldingConsumable.Text);
                }
                if (this.textBox_pWPSWeldingPosition.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSWeldingPosition like '%{0}%'", this.textBox_pWPSWeldingPosition.Text);
                }
                if (this.comboBox_pWPSGrooveType.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSGrooveType like '%{0}%'", this.comboBox_pWPSGrooveType.Text);
                }
                if (this.comboBox_pWPSJointType .Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSJointType like '%{0}%'", this.comboBox_pWPSJointType.Text);
                }
                double dbl_pWPSThickness=0;
                double.TryParse(this.textBox_pWPSThickness.Text, out dbl_pWPSThickness);
                if (dbl_pWPSThickness > 0)
                {
                    str_Filter = str_Filter + string.Format(" And (WPSThickness = {0} or WPSThicknessSecond = {0})", dbl_pWPSThickness);
                }
            }
            else
            {
                if (this.textBox_pWPSIDBegin.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSID = '{0}'", this.textBox_pWPSIDBegin.Text);
                }
                if (this.textBox_pWPSDenomination.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSDenomination = '{0}'", this.textBox_pWPSDenomination.Text);
                }
                if (this.textBox_pWPSWeldingProcessAb.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSWeldingProcessAb = '{0}'", this.textBox_pWPSWeldingProcessAb.Text);
                }
                if (this.textBox_pWPSMaterial.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And (WPSMaterial = '{0}' Or WPSMaterialSecond = '{0}')", this.textBox_pWPSMaterial.Text);
                }
                if (this.textBox_pWPSWeldingConsumable.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSWeldingConsumable = '{0}'", this.textBox_pWPSWeldingConsumable.Text);
                }
                if (this.textBox_pWPSWeldingPosition.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSWeldingPosition = '{0}'", this.textBox_pWPSWeldingPosition.Text);
                }
                if (this.comboBox_pWPSGrooveType.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSGrooveType = '{0}'", this.comboBox_pWPSGrooveType.Text);
                }
                if (this.comboBox_pWPSJointType.Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And WPSJointType = '{0}'", this.comboBox_pWPSJointType.Text);
                }
                double dbl_pWPSThickness = 0;
                double.TryParse(this.textBox_pWPSThickness.Text, out dbl_pWPSThickness);
                if (dbl_pWPSThickness > 0)
                {
                    str_Filter = str_Filter + string.Format(" And (WPSThickness = {0} or WPSThicknessSecond = {0})", dbl_pWPSThickness);
                }
            }

            EventArgs_WPSQuery g = new EventArgs_WPSQuery(str_Filter);
            Publisher_WPSQuery.OnEventName(g);

        }

        private void button_pWPSQueryAdvance_Click(object sender, EventArgs e)
        {
            Form_QueryFilter myForm = new Form_QueryFilter();
            myForm.InitControl(Enum_DataTable.WPS.ToString());
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                EventArgs_WPSQuery g = new EventArgs_WPSQuery(myForm.str_Filter);
                Publisher_WPSQuery.OnEventName(g);
            }

        }
                
    }
}
