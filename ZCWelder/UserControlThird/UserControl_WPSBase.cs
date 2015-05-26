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
    public partial class UserControl_WPSBase : UserControl
    {
        public    Class_WPS myClass_WPS;
        private static Class_WPS myClass_WPSDefault;

        public UserControl_WPSBase()
        {
            InitializeComponent();
        }

        private void UserControl_WPSBase_Load(object sender, EventArgs e)
        {

        }

        public void  InitControl(Class_WPS myClass_WPS, bool bool_Add)
        {
            this.textBox_WPSMaterial.BackColor = Properties.Settings.Default.textBoxDoubleClickColor;
            this.textBox_WPSMaterialSecond .BackColor = Properties.Settings.Default.textBoxDoubleClickColor;
            this.textBox_WPSWeldingConsumable .BackColor = Properties.Settings.Default.textBoxDoubleClickColor;
            this.textBox_WPSWeldingEquipment .BackColor = Properties.Settings.Default.textBoxDoubleClickColor;

            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Assemblage.ToString()];
            DataView myDataView_Assemblage = new DataView(myClass_Data.myDataTable);
            myDataView_Assemblage.Sort = myClass_Data.myDataView.Sort;
            Class_DataControlBind.InitializeComboBox(this.comboBox_WPSAssemblage, myDataView_Assemblage, "Assemblage", "Assemblage");
            Class_Public.InitializeComboBox(this.comboBox_WPSJointType, Enum_DataTable.JointType.ToString(), "KindofWeld", "JointType");
            Class_Public.InitializeComboBox(this.comboBox_WPSLayerWelding, Enum_DataTable.LayerWelding.ToString(), "LayerWelding", "LayerWelding");
            Class_Public.InitializeComboBox(this.comboBox_WPSWeldingProcessAb, Enum_DataTable.WeldingProcess.ToString(), "WeldingProcessAb", "WeldingProcessAb");
            Class_Public.InitializeComboBox(this.comboBox_WPSWorkPieceType, Enum_DataTable.WorkPieceType.ToString(), "WorkPieceType", "WorkPieceType");
            Class_Public.InitializeComboBox(this.comboBox_WPSWeldingPosition, Enum_DataTable.WeldingPosition.ToString(), "WeldingPosition", "WeldingPosition");
            Class_Public.InitializeComboBox(this.comboBox_WPSGrooveType, Enum_DataTable.GrooveType.ToString(), "GrooveType", "GrooveType");
            Class_Public.InitializeComboBox(this.comboBox_WPSWorkPieceTypeSecond, Enum_DataTable.WorkPieceType.ToString(), "WorkPieceType", "WorkPieceType");
        
            this.myClass_WPS=myClass_WPS ;
            if (bool_Add)
            {
                this.textBox_WPSID.ReadOnly = false ;
                this.textBox_WPSPrincipal.Text = string.Format("{0}£º{1}", Class_zwjPublic.myClass_CustomUser.Name, Class_zwjPublic.myClass_CustomUser.UserGUID.ToString());
                this.myClass_WPS.WPSPrincipal = Class_zwjPublic.myClass_CustomUser.UserGUID;
                if (myClass_WPSDefault != null)
                {
                    this.myClass_WPS.WPSMaterial = myClass_WPSDefault.WPSMaterial;
                    this.myClass_WPS.WPSMaterialSecond = myClass_WPSDefault.WPSMaterialSecond;
                    this.myClass_WPS.WPSWeldingConsumable = myClass_WPSDefault.WPSWeldingConsumable;
                    this.myClass_WPS.WPSWeldingEquipment = myClass_WPSDefault.WPSWeldingEquipment;
                    this.myClass_WPS.WPSMaterialHeterogeneity = myClass_WPSDefault.WPSMaterialHeterogeneity;


                    this.textBox_WPSMaterial.Text = myClass_WPSDefault.WPSMaterial;
                    this.comboBox_WPSWorkPieceType.SelectedValue = myClass_WPSDefault.WPSWorkPieceType;
                    this.textBox_WPSThickness.Text = string.Format("{0}", myClass_WPSDefault.WPSThickness);
                    if (myClass_WPSDefault.WPSExternalDiameter > 0)
                    {
                        this.textBox_WPSExternalDiameter.Text = string.Format("{0}", myClass_WPSDefault.WPSExternalDiameter);
                    }
                    this.checkBox_WPSMaterialHeterogeneity.Checked = this.myClass_WPS.WPSMaterialHeterogeneity;
                    this.textBox_WPSWeldingConsumable.Text = myClass_WPSDefault.WPSWeldingConsumable;
                    this.textBox_WPSID.Text = myClass_WPSDefault.WPSID;
                    this.textBox_WPSDenomination.Text = myClass_WPSDefault.WPSDenomination;
                    this.textBox_WPSWeldingEquipment.Text = myClass_WPSDefault.WPSWeldingEquipment;
                    this.comboBox_WPSWeldingPosition.SelectedValue = myClass_WPSDefault.WPSWeldingPosition;
                    this.comboBox_WPSLayerWelding.SelectedValue = myClass_WPSDefault.WPSLayerWelding;
                    this.comboBox_WPSWeldingProcessAb.SelectedValue = myClass_WPSDefault.WPSWeldingProcessAb;
                    this.comboBox_WPSGrooveType.SelectedValue = myClass_WPSDefault.WPSGrooveType;
                    this.textBox_WPSTemperature.Text = string.Format("{0}", myClass_WPSDefault.WPSTemperature);
                    this.textBox_WPSHumidity.Text = string.Format("{0}", myClass_WPSDefault.WPSHumidity);
                    this.comboBox_WPSJointType.Text = myClass_WPSDefault.WPSJointType;
                    this.comboBox_WPSAssemblage.SelectedValue = myClass_WPSDefault.WPSAssemblage;
                    if (myClass_WPSDefault.WPSMaterialHeterogeneity)
                    {
                        this.textBox_WPSMaterialSecond.Text = myClass_WPSDefault.WPSMaterialSecond;
                        this.comboBox_WPSWorkPieceTypeSecond.SelectedValue = myClass_WPSDefault.WPSWorkPieceTypeSecond;
                        this.textBox_WPSThicknessSecond.Text = string.Format("{0}", myClass_WPSDefault.WPSThicknessSecond);
                        if (myClass_WPSDefault.WPSExternalDiameterSecond > 0)
                        {
                            this.textBox_WPSExternalDiameterSecond.Text = string.Format("{0}", myClass_WPSDefault.WPSExternalDiameterSecond);
                        }
                    }

                }

            }
            else
            {
                this.textBox_WPSID.ReadOnly = true;
                this.textBox_WPSMaterial.Text = myClass_WPS.WPSMaterial;
                this.comboBox_WPSWorkPieceType.SelectedValue = myClass_WPS.WPSWorkPieceType;
                this.textBox_WPSThickness.Text=string.Format("{0}",myClass_WPS.WPSThickness );
                if (myClass_WPS.WPSExternalDiameter > 0)
                {
                    this.textBox_WPSExternalDiameter .Text=string.Format("{0}",myClass_WPS.WPSExternalDiameter)  ;
                }
                this.checkBox_WPSMaterialHeterogeneity.Checked = this.myClass_WPS.WPSMaterialHeterogeneity;
                if (this.myClass_WPS.WPSMaterialHeterogeneity)
                {
                    this.textBox_WPSMaterialSecond.Text = myClass_WPS.WPSMaterialSecond;
                    this.comboBox_WPSWorkPieceTypeSecond.SelectedValue = myClass_WPS.WPSWorkPieceTypeSecond;
                    this.textBox_WPSThicknessSecond.Text = string.Format("{0}", myClass_WPS.WPSThicknessSecond);
                    if (myClass_WPS.WPSExternalDiameterSecond > 0)
                    {
                        this.textBox_WPSExternalDiameterSecond.Text = string.Format("{0}", myClass_WPS.WPSExternalDiameterSecond);
                    }
                }
                this.textBox_WPSWeldingConsumable.Text = myClass_WPS.WPSWeldingConsumable;
                this.textBox_WPSID.Text =myClass_WPS.WPSID ;
                this.textBox_WPSDenomination.Text=myClass_WPS.WPSDenomination ;
                this.textBox_WPSWeldingEquipment.Text = myClass_WPS.WPSWeldingEquipment;
                this.textBox_WPSRemark.Text=myClass_WPS.WPSRemark ;
                this.comboBox_WPSWeldingPosition.SelectedValue =myClass_WPS.WPSWeldingPosition ;
                this.comboBox_WPSLayerWelding.SelectedValue = myClass_WPS.WPSLayerWelding;
                this.comboBox_WPSWeldingProcessAb.SelectedValue = myClass_WPS.WPSWeldingProcessAb;
                this.comboBox_WPSGrooveType.SelectedValue = myClass_WPS.WPSGrooveType;
                this.textBox_WPSTemperature.Text = string.Format("{0}", myClass_WPS.WPSTemperature);
                this.textBox_WPSHumidity.Text = string.Format("{0}", myClass_WPS.WPSHumidity);

                this.comboBox_WPSJointType.Text   = myClass_WPS.WPSJointType;
                this.comboBox_WPSAssemblage.SelectedValue=myClass_WPS.WPSAssemblage ;
               
                Class_CustomUser myClass_CustomUser = new Class_CustomUser();
                myClass_CustomUser.UserGUID = myClass_WPS.WPSPrincipal ;
                if (myClass_CustomUser.FillData())
                {
                    this.textBox_WPSPrincipal .Text = string.Format("{0}£º{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                }
            }
            this.SetMaterialHeterogeneityVisible();

        }

        public void FillClass()
        {
            myClass_WPS.WPSID= this.textBox_WPSID.Text  ;
            myClass_WPS.WPSDenomination = this.textBox_WPSDenomination.Text;
            myClass_WPS.WPSWeldingEquipment = this.textBox_WPSWeldingEquipment.Text;
            myClass_WPS.WPSWorkPieceType = (string)this.comboBox_WPSWorkPieceType.SelectedValue;
            double.TryParse(this.textBox_WPSThickness.Text, out myClass_WPS.WPSThickness);
            if (this.textBox_WPSExternalDiameter.Text.Length>0 )
            {
                double.TryParse(this.textBox_WPSExternalDiameter.Text, out myClass_WPS.WPSExternalDiameter );
            }
            this.myClass_WPS.WPSMaterialHeterogeneity = this.checkBox_WPSMaterialHeterogeneity.Checked;
            if (this.myClass_WPS.WPSMaterialHeterogeneity)
            {
                myClass_WPS.WPSWorkPieceTypeSecond = (string)this.comboBox_WPSWorkPieceTypeSecond.SelectedValue;
                double.TryParse(this.textBox_WPSThicknessSecond.Text, out myClass_WPS.WPSThicknessSecond);
                if (this.textBox_WPSExternalDiameterSecond.Text.Length > 0)
                {
                    double.TryParse(this.textBox_WPSExternalDiameterSecond.Text, out myClass_WPS.WPSExternalDiameterSecond);
                }
            }
            myClass_WPS.WPSRemark=   this.textBox_WPSRemark.Text ;
            myClass_WPS.WPSWeldingPosition = (string)this.comboBox_WPSWeldingPosition.SelectedValue ;
            myClass_WPS.WPSAssemblage= (string)this.comboBox_WPSAssemblage.SelectedValue ;
            myClass_WPS.WPSLayerWelding = (string)this.comboBox_WPSLayerWelding.SelectedValue;
            myClass_WPS.WPSWeldingProcessAb = (string)this.comboBox_WPSWeldingProcessAb.SelectedValue;
            myClass_WPS.WPSGrooveType = (string)this.comboBox_WPSGrooveType.SelectedValue;
            if (this.textBox_WPSTemperature.Text.Length > 0)
            {
                double.TryParse(this.textBox_WPSTemperature.Text, out myClass_WPS.WPSTemperature);
            }
            else
            {
                myClass_WPS.WPSTemperature = 0;
            }
            if (this.textBox_WPSHumidity.Text.Length > 0)
            {
                double.TryParse(this.textBox_WPSHumidity.Text, out myClass_WPS.WPSHumidity);
            }
            myClass_WPS.WPSJointType = (string)this.comboBox_WPSJointType.Text  ;
            if (myClass_WPSDefault == null)
            {
                myClass_WPSDefault = new Class_WPS();
            }
            myClass_WPSDefault.WPSAssemblage = myClass_WPS.WPSAssemblage;
            myClass_WPSDefault.WPSDenomination = myClass_WPS.WPSDenomination;
            myClass_WPSDefault.WPSExternalDiameter = myClass_WPS.WPSExternalDiameter;
            myClass_WPSDefault.WPSExternalDiameterSecond = myClass_WPS.WPSExternalDiameterSecond;
            myClass_WPSDefault.WPSGrooveType = myClass_WPS.WPSGrooveType;
            myClass_WPSDefault.WPSHumidity = myClass_WPS.WPSHumidity;
            myClass_WPSDefault.WPSID = myClass_WPS.WPSID;
            myClass_WPSDefault.WPSJointType = myClass_WPS.WPSJointType;
            myClass_WPSDefault.WPSLayerWelding = myClass_WPS.WPSLayerWelding;
            myClass_WPSDefault.WPSMaterial = myClass_WPS.WPSMaterial;
            myClass_WPSDefault.WPSMaterialHeterogeneity = myClass_WPS.WPSMaterialHeterogeneity;
            myClass_WPSDefault.WPSMaterialSecond = myClass_WPS.WPSMaterialSecond;
            myClass_WPSDefault.WPSPrincipal = myClass_WPS.WPSPrincipal;
            myClass_WPSDefault.WPSTemperature = myClass_WPS.WPSTemperature;
            myClass_WPSDefault.WPSThickness = myClass_WPS.WPSThickness;
            myClass_WPSDefault.WPSThicknessSecond = myClass_WPS.WPSThicknessSecond;
            myClass_WPSDefault.WPSWeldingConsumable = myClass_WPS.WPSWeldingConsumable;
            myClass_WPSDefault.WPSWeldingEquipment = myClass_WPS.WPSWeldingEquipment;
            myClass_WPSDefault.WPSWeldingPosition = myClass_WPS.WPSWeldingPosition;
            myClass_WPSDefault.WPSWeldingProcessAb = myClass_WPS.WPSWeldingProcessAb;
            myClass_WPSDefault.WPSWorkPieceType = myClass_WPS.WPSWorkPieceType;
            myClass_WPSDefault.WPSWorkPieceTypeSecond = myClass_WPS.WPSWorkPieceTypeSecond;

        }

        private void textBox_WPSWeldingConsumable_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingConsumableQuery myForm = new Form_WeldingConsumableQuery();
            myForm.myClass_WeldingConsumable = new Class_WeldingConsumable();
            if (this.myClass_WPS.WPSWeldingConsumable != null)
            {
                myForm.myClass_WeldingConsumable.WeldingConsumable  = this.myClass_WPS.WPSWeldingConsumable ;
                myForm.myClass_WeldingConsumable.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_WPS.WPSWeldingConsumable = myForm.myClass_WeldingConsumable.WeldingConsumable ;
                this.textBox_WPSWeldingConsumable.Text = string.Format("{0}", myForm.myClass_WeldingConsumable .WeldingConsumable );
            }

        }

        private void textBox_WPSMaterial_DoubleClick(object sender, EventArgs e)
        {
            Form_MaterialQuery myForm = new Form_MaterialQuery();
            myForm.myClass_Material = new Class_Material();
            if (this.myClass_WPS.WPSMaterial != null)
            {
                myForm.myClass_Material.Material  = this.myClass_WPS.WPSMaterial ;
                myForm.myClass_Material.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_WPS.WPSMaterial = myForm.myClass_Material.Material ;
                this.textBox_WPSMaterial.Text = string.Format("{0}", myForm.myClass_Material .Material );
            }

        }

        private void textBox_WPSWeldingEquipment_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingEquipmentQuery myForm = new Form_WeldingEquipmentQuery();
            myForm.myClass_WeldingEquipment = new Class_WeldingEquipment();
            if (!string.IsNullOrEmpty(this.myClass_WPS.WPSWeldingEquipment))
            {
                myForm.myClass_WeldingEquipment.WeldingEquipment = this.myClass_WPS.WPSWeldingEquipment;
                myForm.myClass_WeldingEquipment.FillData();
            }
            DialogResult myDialogResult = myForm.ShowDialog();
            if (myDialogResult == DialogResult.OK)
            {
                this.myClass_WPS.WPSWeldingEquipment = myForm.myClass_WeldingEquipment.WeldingEquipment;
                this.textBox_WPSWeldingEquipment.Text = string.Format("{0}", myForm.myClass_WeldingEquipment.WeldingEquipment);
            }


        }

        private void textBox_WPSMaterialSecond_DoubleClick(object sender, EventArgs e)
        {
            Form_MaterialQuery myForm = new Form_MaterialQuery();
            myForm.myClass_Material = new Class_Material();
            if (!string.IsNullOrEmpty(this.myClass_WPS.WPSMaterialSecond))
            {
                myForm.myClass_Material.Material  = this.myClass_WPS.WPSMaterialSecond ;
                myForm.myClass_Material.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_WPS.WPSMaterialSecond = myForm.myClass_Material.Material;
                this.textBox_WPSMaterialSecond.Text = string.Format("{0}", myForm.myClass_Material.Material);
            }

        }

        private void SetMaterialHeterogeneityVisible()
        {
            if (this.checkBox_WPSMaterialHeterogeneity.Checked)
            {
                this.comboBox_WPSWorkPieceTypeSecond.Visible = true;
                this.textBox_WPSMaterialSecond.Visible = true;
                this.textBox_WPSThicknessSecond.Visible = true;
                this.textBox_WPSExternalDiameterSecond.Visible = true;
            }
            else
            {
                this.comboBox_WPSWorkPieceTypeSecond.Visible = false;
                this.textBox_WPSMaterialSecond.Visible = false;
                this.textBox_WPSThicknessSecond.Visible = false;
                this.textBox_WPSExternalDiameterSecond.Visible = false;
            }    
        }

        private void checkBox_WPSMaterialHeterogeneity_CheckedChanged(object sender, EventArgs e)
        {
            this.SetMaterialHeterogeneityVisible();

        }

        private void comboBox_WPSJointType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((DataView)this.comboBox_WPSAssemblage.DataSource).RowFilter =string .Format ( "KindofWeld='{0}'", this.comboBox_WPSJointType.SelectedValue.ToString ());
        }

        private void textBox_WPSPrincipal_DoubleClick(object sender, EventArgs e)
        {
            TextBox myTextBox = (TextBox)sender;
            Form_UserQuery myForm = new Form_UserQuery();
            Class_CustomUser myClass_CustomUser = new Class_CustomUser();
            if (!string.IsNullOrEmpty(myTextBox.Text))
            {
                myClass_CustomUser.UserGUID = new Guid(myTextBox.Text.Split('£º')[1]);
                if (myClass_CustomUser.FillData())
                {
                }
            }
            myForm.myClass_CustomUser = myClass_CustomUser;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                if (myForm.myClass_CustomUser != null && myForm.myClass_CustomUser.UserGUID != null)
                {
                    this.myClass_WPS.WPSPrincipal = myForm.myClass_CustomUser.UserGUID;
                    myTextBox.Text = string.Format("{0}£º{1}", myForm.myClass_CustomUser.Name, myForm.myClass_CustomUser.UserGUID.ToString());
                }
                else
                {
                    myTextBox.Text = "";
                }
            }
        }


    }
}
