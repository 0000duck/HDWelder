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
using ZCWelder.Parameter;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_Parameter_DataGridView : UserControl
    {
        private EventArgs_Parameter myEventArgs_Parameter;
        private DataView myDataView;

        public UserControl_Parameter_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_Parameter_DataGridView_Load(object sender, EventArgs e)
        {
            Publisher_Parameter.EventName += new EventHandler_Parameter(InitDataGridView);
        }

        private void InitDataGridView(object sender, EventArgs_Parameter e)
        {
            this.myEventArgs_Parameter = e;
            if (!Class_Public.myHashtable.Contains(e.str_Parameter))
            {
                return;
            }
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Parameter, e.str_Parameter, false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[e.str_Parameter];
            myDataView = new DataView(myClass_Data.myDataTable);

            if ((!e.bool_isFilter  ) || string.IsNullOrEmpty(e.str_Filter ))
            {
                if (this.myEventArgs_Parameter.str_Parameter == Enum_DataTable.Employer.ToString())
                {
                    myDataView.RowFilter = string.Format("EmployerGroup='{0}'", this.myEventArgs_Parameter.str_ParameterKey);
                }
                else if (this.myEventArgs_Parameter.str_Parameter == Enum_DataTable.Department.ToString())
                {
                    myDataView.RowFilter = string.Format("EmployerHPID='{0}'", this.myEventArgs_Parameter.str_ParameterKey);
                }
                else if (this.myEventArgs_Parameter.str_Parameter == Enum_DataTable.WorkPlace.ToString())
                {
                    myDataView.RowFilter = string.Format("DepartmentHPID='{0}'", this.myEventArgs_Parameter.str_ParameterKey);
                }
                else if (this.myEventArgs_Parameter.str_Parameter == Enum_DataTable.LaborServiceTeam.ToString())
                {
                    myDataView.RowFilter = string.Format("EmployerHPID='{0}'", this.myEventArgs_Parameter.str_ParameterKey);
                }
                else
                {
                    myDataView.RowFilter = e.str_Filter;
                }
            }
            else
            {
                if (this.myEventArgs_Parameter.str_Parameter == Enum_DataTable.Employer.ToString())
                {
                    myDataView.RowFilter = string.Format("EmployerGroup='{0}' and ({1})", this.myEventArgs_Parameter.str_ParameterKey, e.str_Filter);
                }
                else if (this.myEventArgs_Parameter.str_Parameter == Enum_DataTable.Department.ToString())
                {
                    myDataView.RowFilter = string.Format("EmployerHPID='{0}' and ({1})", this.myEventArgs_Parameter.str_ParameterKey, e.str_Filter);
                }
                else if (this.myEventArgs_Parameter.str_Parameter == Enum_DataTable.WorkPlace.ToString())
                {
                    myDataView.RowFilter = string.Format("DepartmentHPID='{0}' and ({1})", this.myEventArgs_Parameter.str_ParameterKey, e.str_Filter);
                }
                else if (this.myEventArgs_Parameter.str_Parameter == Enum_DataTable.LaborServiceTeam.ToString())
                {
                    myDataView.RowFilter = string.Format("EmployerHPID='{0}' and ({1})", this.myEventArgs_Parameter.str_ParameterKey, e.str_Filter);
                }
                else
                {
                    myDataView.RowFilter = e.str_Filter;
                }
            }
            
            this.dataGridView_Parameter.DataSource = myDataView;

            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Parameter.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Parameter.DataSource).Sort = myClass_Data.myDataView.Sort;
            }

            this.label_Parameter.Text = string.Format("{0}，（{1}）：", e.str_ParameterName , this.dataGridView_Parameter.RowCount);


        }

        private void toolStripMenuItem_ParameterAdd_Click(object sender, EventArgs e)
        {
            this.ParameterAdd();

        }

        private void ParameterAdd()
        {
            if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Department   .ToString())
            {
                Form_DepartmentUpdate myForm = new Form_DepartmentUpdate();
                myForm.myClass_Department = new Class_Department();
                myForm.myClass_Department.EmployerHPID = this.myEventArgs_Parameter .str_ParameterKey;
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingPosition .ToString())
            {
                Form_WeldingPositionUpdate myForm = new Form_WeldingPositionUpdate();
                myForm.myClass_WeldingPosition = new Class_WeldingPosition();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTableSecond.GasAndWeldingFlux.ToString())
            {
                Form_GasAndWeldingFluxUpdate myForm = new Form_GasAndWeldingFluxUpdate();
                myForm.myClass_GasAndWeldingFlux = new Class_GasAndWeldingFlux();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.LaborServiceTeam.ToString())
            {
                Form_LaborServiceTeamUpdate myForm = new Form_LaborServiceTeamUpdate();
                myForm.myClass_LaborServiceTeam = new Class_LaborServiceTeam();
                myForm.myClass_LaborServiceTeam.EmployerHPID = this.myEventArgs_Parameter.str_ParameterKey;
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WorkPlace   .ToString())
            {
                Form_WorkPlaceUpdate myForm = new Form_WorkPlaceUpdate();
                myForm.myClass_WorkPlace = new Class_WorkPlace();
                myForm.myClass_WorkPlace.DepartmentHPID = this.myEventArgs_Parameter.str_ParameterKey;
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Employer    .ToString())
            {
                Form_EmployerUpdate myForm = new Form_EmployerUpdate();
                myForm.myClass_Employer = new Class_Employer();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.EmployerGroup     .ToString())
            {
                Form_EmployerGroupUpdate myForm = new Form_EmployerGroupUpdate();
                myForm.myClass_EmployerGroup = new Class_EmployerGroup();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Schooling   .ToString())
            {
                Form_SchoolingUpdate myForm = new Form_SchoolingUpdate();
                myForm.myClass_Schooling = new Class_Schooling();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingProcess.ToString())
            {
                Parameter.Form_WeldingProcessUpdate myForm = new Parameter.Form_WeldingProcessUpdate();
                myForm.myClass_WeldingProcess = new Class_WeldingProcess();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingStandard.ToString())
            {
                Parameter.Form_WeldingStandardUpdate myForm = new Parameter.Form_WeldingStandardUpdate();
                myForm.myClass_WeldingStandard = new Class_WeldingStandard();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingStandardAndGroup.ToString())
            {
                Parameter.Form_WeldingStandardAndGroupUpdate myForm = new Parameter.Form_WeldingStandardAndGroupUpdate();
                myForm.myClass_WeldingStandardAndGroup = new Class_WeldingStandardAndGroup();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Material.ToString())
            {
                Parameter.Form_MaterialUpdate myForm = new Parameter.Form_MaterialUpdate();
                myForm.myClass_Material = new Class_Material();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.MaterialCCSGroup .ToString())
            {
                Parameter.Form_MaterialCCSGroupUpdate myForm = new Parameter.Form_MaterialCCSGroupUpdate();
                myForm.myClass_MaterialCCSGroup = new Class_MaterialCCSGroup();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.MaterialISOGroup  .ToString())
            {
                Parameter.Form_MaterialISOGroupUpdate myForm = new Parameter.Form_MaterialISOGroupUpdate();
                myForm.myClass_MaterialISOGroup = new Class_MaterialISOGroup();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingConsumable.ToString())
            {
                Parameter.Form_WeldingConsumableUpdate myForm = new Parameter.Form_WeldingConsumableUpdate();
                myForm.myClass_WeldingConsumable = new Class_WeldingConsumable();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingConsumableCCSGroup .ToString())
            {
                Parameter.Form_WeldingConsumableCCSGroupUpdate myForm = new Parameter.Form_WeldingConsumableCCSGroupUpdate();
                myForm.myClass_WeldingConsumableCCSGroup = new Class_WeldingConsumableCCSGroup();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingConsumableISOGroup  .ToString())
            {
                Parameter.Form_WeldingConsumableISOGroupUpdate myForm = new Parameter.Form_WeldingConsumableISOGroupUpdate();
                myForm.myClass_WeldingConsumableISOGroup = new Class_WeldingConsumableISOGroup();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.KindofEmployer  .ToString())
            {
                Parameter.Form_KindofEmployerUpdate myForm = new Parameter.Form_KindofEmployerUpdate();
                myForm.myClass_KindofEmployer = new Class_KindofEmployer();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.ShipClassification  .ToString())
            {
                Parameter.Form_ShipClassificationUpdate myForm = new Parameter.Form_ShipClassificationUpdate();
                myForm.myClass_ShipClassification = new Class_ShipClassification();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Ship  .ToString())
            {
                Parameter.Form_ShipUpdate myForm = new Parameter.Form_ShipUpdate();
                myForm.myClass_Ship = new Class_Ship();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.ShipandShipClassification  .ToString())
            {
                Parameter.Form_ShipandShipClassificationUpdate myForm = new Parameter.Form_ShipandShipClassificationUpdate();
                myForm.myClass_ShipandShipClassification = new Class_ShipandShipClassification();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.TestCommittee  .ToString())
            {
                Parameter.Form_TestCommitteeUpdate myForm = new Parameter.Form_TestCommitteeUpdate();
                myForm.myClass_TestCommittee = new Class_TestCommittee();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.KindofExam  .ToString())
            {
                Parameter.Form_KindofExamUpdate myForm = new Parameter.Form_KindofExamUpdate();
                myForm.myClass_KindofExam = new Class_KindofExam();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingSubjectApplicable   .ToString())
            {
                Parameter.Form_WeldingSubjectApplicableUpdate myForm = new Parameter.Form_WeldingSubjectApplicableUpdate();
                myForm.myClass_WeldingSubjectApplicable = new Class_WeldingSubjectApplicable();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Assemblage.ToString())
            {
                Parameter.Form_Assemblage_Update myForm = new Parameter.Form_Assemblage_Update();
                myForm.myClass_Assemblage = new Class_Assemblage();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTableSecond.WeldingEquipment .ToString())
            {
                Form_WeldingEquipment_Update myForm = new Form_WeldingEquipment_Update();
                myForm.myClass_WeldingEquipment = new Class_WeldingEquipment();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else
            {
                MessageBox.Show("不能添加！");
            }

        }

        private void toolStripMenuItem_ParameterRowAdd_Click(object sender, EventArgs e)
        {
            this.ParameterAdd();
        }

        private void toolStripMenuItem_ParameterRowModify_Click(object sender, EventArgs e)
        {
            if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Department .ToString())
            {
                Form_DepartmentUpdate myForm = new Form_DepartmentUpdate();
                myForm.myClass_Department = new Class_Department((string)this.dataGridView_Parameter.CurrentRow.Cells["DepartmentHPID"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.LaborServiceTeam .ToString())
            {
                Form_LaborServiceTeamUpdate myForm = new Form_LaborServiceTeamUpdate();
                myForm.myClass_LaborServiceTeam = new Class_LaborServiceTeam((string)this.dataGridView_Parameter.CurrentRow.Cells["LaborServiceTeamHPID"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingPosition .ToString())
            {
                Form_WeldingPositionUpdate myForm = new Form_WeldingPositionUpdate();
                myForm.myClass_WeldingPosition = new Class_WeldingPosition((string)this.dataGridView_Parameter.CurrentRow.Cells["WeldingPosition"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WorkPlace.ToString())
            {
                Form_WorkPlaceUpdate myForm = new Form_WorkPlaceUpdate();
                myForm.myClass_WorkPlace = new Class_WorkPlace((string)this.dataGridView_Parameter.CurrentRow.Cells["WorkPlaceHPID"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Employer .ToString())
            {
                Form_EmployerUpdate myForm = new Form_EmployerUpdate();
                myForm.myClass_Employer = new Class_Employer((string)this.dataGridView_Parameter.CurrentRow.Cells["EmployerHPID"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.EmployerGroup.ToString())
            {
                Form_EmployerGroupUpdate myForm = new Form_EmployerGroupUpdate();
                myForm.myClass_EmployerGroup = new Class_EmployerGroup((string)this.dataGridView_Parameter.CurrentRow.Cells["EmployerGroup"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Schooling  .ToString())
            {
                Form_SchoolingUpdate myForm = new Form_SchoolingUpdate();
                myForm.myClass_Schooling = new Class_Schooling((string)this.dataGridView_Parameter.CurrentRow.Cells["Schooling"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingProcess.ToString())
            {
                Parameter.Form_WeldingProcessUpdate myForm = new Parameter.Form_WeldingProcessUpdate();
                myForm.myClass_WeldingProcess = new Class_WeldingProcess((string)this.dataGridView_Parameter.CurrentRow.Cells["WeldingProcessAb"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingStandard.ToString())
            {
                Parameter.Form_WeldingStandardUpdate myForm = new Parameter.Form_WeldingStandardUpdate();
                myForm.myClass_WeldingStandard = new Class_WeldingStandard((string)this.dataGridView_Parameter.CurrentRow.Cells["WeldingStandard"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingStandardAndGroup.ToString())
            {
                Parameter.Form_WeldingStandardAndGroupUpdate myForm = new Parameter.Form_WeldingStandardAndGroupUpdate();
                myForm.myClass_WeldingStandardAndGroup = new Class_WeldingStandardAndGroup(this.dataGridView_Parameter.CurrentRow.Cells["WeldingStandard"].Value.ToString(), this.dataGridView_Parameter.CurrentRow.Cells["WeldingStandardGroup"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Material.ToString())
            {
                Parameter.Form_MaterialUpdate myForm = new Parameter.Form_MaterialUpdate();
                myForm.myClass_Material = new Class_Material((string)this.dataGridView_Parameter.CurrentRow.Cells["Material"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.MaterialISOGroup.ToString())
            {
                Parameter.Form_MaterialISOGroupUpdate myForm = new Parameter.Form_MaterialISOGroupUpdate();
                myForm.myClass_MaterialISOGroup = new Class_MaterialISOGroup(this.dataGridView_Parameter.CurrentRow.Cells["MaterialISOGroupAb"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.MaterialCCSGroup.ToString())
            {
                Parameter.Form_MaterialCCSGroupUpdate myForm = new Parameter.Form_MaterialCCSGroupUpdate();
                myForm.myClass_MaterialCCSGroup = new Class_MaterialCCSGroup(this.dataGridView_Parameter.CurrentRow.Cells["MaterialCCSGroupAb"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingConsumable.ToString())
            {
                Parameter.Form_WeldingConsumableUpdate myForm = new Parameter.Form_WeldingConsumableUpdate();
                myForm.myClass_WeldingConsumable = new Class_WeldingConsumable((string)this.dataGridView_Parameter.CurrentRow.Cells["WeldingConsumable"].Value);
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }         
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingConsumableISOGroup.ToString())
            {
                Parameter.Form_WeldingConsumableISOGroupUpdate myForm = new Parameter.Form_WeldingConsumableISOGroupUpdate();
                myForm.myClass_WeldingConsumableISOGroup = new Class_WeldingConsumableISOGroup(this.dataGridView_Parameter.CurrentRow.Cells["WeldingConsumableISOGroupAb"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingConsumableCCSGroup.ToString())
            {
                Parameter.Form_WeldingConsumableCCSGroupUpdate myForm = new Parameter.Form_WeldingConsumableCCSGroupUpdate();
                myForm.myClass_WeldingConsumableCCSGroup = new Class_WeldingConsumableCCSGroup(this.dataGridView_Parameter.CurrentRow.Cells["WeldingConsumableCCSGroupAb"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.KindofEmployer.ToString())
            {
                Parameter.Form_KindofEmployerUpdate myForm = new Parameter.Form_KindofEmployerUpdate();
                myForm.myClass_KindofEmployer = new Class_KindofEmployer(this.dataGridView_Parameter.CurrentRow.Cells["KindofEmployer"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.ShipClassification.ToString())
            {
                Parameter.Form_ShipClassificationUpdate myForm = new Parameter.Form_ShipClassificationUpdate();
                myForm.myClass_ShipClassification = new Class_ShipClassification(this.dataGridView_Parameter.CurrentRow.Cells["ShipClassificationAb"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Ship.ToString())
            {
                Parameter.Form_ShipUpdate myForm = new Parameter.Form_ShipUpdate();
                myForm.myClass_Ship = new Class_Ship(this.dataGridView_Parameter.CurrentRow.Cells["ShipboardNo"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.ShipandShipClassification.ToString())
            {
                Parameter.Form_ShipandShipClassificationUpdate myForm = new Parameter.Form_ShipandShipClassificationUpdate();
                myForm.myClass_ShipandShipClassification = new Class_ShipandShipClassification(this.dataGridView_Parameter.CurrentRow.Cells["ShipClassificationAb"].Value.ToString(), this.dataGridView_Parameter.CurrentRow.Cells["ShipboardNo"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.TestCommittee.ToString())
            {
                Parameter.Form_TestCommitteeUpdate myForm = new Parameter.Form_TestCommitteeUpdate();
                myForm.myClass_TestCommittee = new Class_TestCommittee(this.dataGridView_Parameter.CurrentRow.Cells["TestCommitteeID"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.KindofExam.ToString())
            {
                Parameter.Form_KindofExamUpdate myForm = new Parameter.Form_KindofExamUpdate();
                myForm.myClass_KindofExam = new Class_KindofExam(this.dataGridView_Parameter.CurrentRow.Cells["KindofExam"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingSubjectApplicable.ToString())
            {
                Parameter.Form_WeldingSubjectApplicableUpdate myForm = new Parameter.Form_WeldingSubjectApplicableUpdate();
                myForm.myClass_WeldingSubjectApplicable = new Class_WeldingSubjectApplicable(this.dataGridView_Parameter.CurrentRow.Cells["SubjectID"].Value.ToString(), this.dataGridView_Parameter.CurrentRow.Cells["ApplicableSubjectID"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Assemblage.ToString())
            {
                Parameter.Form_Assemblage_Update myForm = new Parameter.Form_Assemblage_Update();
                myForm.myClass_Assemblage = new Class_Assemblage(this.dataGridView_Parameter.CurrentRow.Cells["Assemblage"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTableSecond.WeldingEquipment.ToString())
            {
                Form_WeldingEquipment_Update myForm = new Form_WeldingEquipment_Update();
                myForm.myClass_WeldingEquipment = new Class_WeldingEquipment(this.dataGridView_Parameter.CurrentRow.Cells["WeldingEquipment"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTableSecond.GasAndWeldingFlux.ToString())
            {
                Form_GasAndWeldingFluxUpdate myForm = new Form_GasAndWeldingFluxUpdate();
                myForm.myClass_GasAndWeldingFlux = new Class_GasAndWeldingFlux(this.dataGridView_Parameter.CurrentRow.Cells["GasAndWeldingFlux"].Value.ToString());
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else
            {
                MessageBox.Show("不能修改！");
            }

        }

        private void toolStripMenuItem_ParameterRowDelete_Click(object sender, EventArgs e)
        {
            if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Schooling.ToString())
            {
                if (Class_Schooling.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["Schooling"].Value, Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_Schooling.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["Schooling"].Value, Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Department.ToString())
            {
                if (Class_Department.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["DepartmentHPID"].Value, Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_Department.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["DepartmentHPID"].Value, Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingPosition.ToString())
            {
                if (Class_WeldingPosition.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["WeldingPosition"].Value, Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_WeldingPosition.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["WeldingPosition"].Value, Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.LaborServiceTeam.ToString())
            {
                if (Class_LaborServiceTeam.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["LaborServiceTeamHPID"].Value, Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_LaborServiceTeam.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["LaborServiceTeamHPID"].Value, Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WorkPlace.ToString())
            {
                if (Class_WorkPlace.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["WorkPlaceHPID"].Value, Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_WorkPlace.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["WorkPlaceHPID"].Value, Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Employer.ToString())
            {
                if (Class_Employer.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["EmployerHPID"].Value, Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_Employer.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["EmployerHPID"].Value, Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.EmployerGroup.ToString())
            {
                if (Class_EmployerGroup.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["EmployerGroup"].Value, Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_EmployerGroup.ExistAndCanDeleteAndDelete((string)this.dataGridView_Parameter.CurrentRow.Cells["EmployerGroup"].Value, Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingProcess.ToString())
            {
                if (Class_WeldingProcess.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingProcessAb"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_WeldingProcess.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingProcessAb"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingStandard.ToString())
            {
                if (Class_WeldingStandard.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingStandard"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_WeldingStandard.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingStandard"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingStandardAndGroup.ToString())
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_WeldingStandardAndGroup.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingStandard"].Value.ToString(), this.dataGridView_Parameter.CurrentRow.Cells["WeldingStandardGroup"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                    this.RefreshData(false);
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Material.ToString())
            {
                if (Class_Material.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["Material"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_Material.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["Material"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.MaterialCCSGroup.ToString())
            {
                if (Class_MaterialCCSGroup.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["MaterialCCSGroupAb"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_MaterialCCSGroup.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["MaterialCCSGroupAb"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.MaterialISOGroup.ToString())
            {
                if (Class_MaterialISOGroup.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["MaterialISOGroupAb"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_MaterialISOGroup.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["MaterialISOGroupAb"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingConsumable.ToString())
            {
                if (Class_WeldingConsumable.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingConsumable"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_WeldingConsumable.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingConsumable"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingConsumableCCSGroup.ToString())
            {
                if (Class_WeldingConsumableCCSGroup.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingConsumableCCSGroupAb"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_WeldingConsumableCCSGroup.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingConsumableCCSGroupAb"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingConsumableISOGroup.ToString())
            {
                if (Class_WeldingConsumableISOGroup.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingConsumableISOGroupAb"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_WeldingConsumableISOGroup.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingConsumableISOGroupAb"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.KindofEmployer.ToString())
            {
                if (Class_KindofEmployer.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["KindofEmployer"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_KindofEmployer.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["KindofEmployer"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.ShipClassification.ToString())
            {
                if (Class_ShipClassification.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["ShipClassificationAb"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_ShipClassification.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["ShipClassificationAb"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Ship.ToString())
            {
                if (Class_Ship.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["ShipboardNo"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_Ship.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["ShipboardNo"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.ShipandShipClassification.ToString())
            {
                if (Class_ShipandShipClassification.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["ShipClassificationAb"].Value.ToString(), this.dataGridView_Parameter.CurrentRow.Cells["ShipboardNo"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_ShipandShipClassification.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["ShipClassificationAb"].Value.ToString(),this.dataGridView_Parameter.CurrentRow.Cells["ShipboardNo"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.TestCommittee.ToString())
            {
                if (Class_TestCommittee.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["TestCommitteeID"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_TestCommittee.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["TestCommitteeID"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.KindofExam.ToString())
            {
                if (Class_KindofExam.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["KindofExam"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_KindofExam.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["KindofExam"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.WeldingSubjectApplicable.ToString())
            {
                if (Class_WeldingSubjectApplicable.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["SubjectID"].Value.ToString(), this.dataGridView_Parameter.CurrentRow.Cells["ApplicableSubjectID"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_WeldingSubjectApplicable.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["SubjectID"].Value.ToString(), this.dataGridView_Parameter.CurrentRow.Cells["ApplicableSubjectID"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Assemblage.ToString())
            {
                if (Class_Assemblage.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["Assemblage"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_Assemblage.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["Assemblage"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTableSecond.WeldingEquipment.ToString())
            {
                if (Class_WeldingEquipment.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingEquipment"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_WeldingEquipment.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["WeldingEquipment"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else if ((string)this.dataGridView_Parameter.Tag == Enum_DataTableSecond.GasAndWeldingFlux.ToString())
            {
                if (Class_GasAndWeldingFlux.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["GasAndWeldingFlux"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_GasAndWeldingFlux.ExistAndCanDeleteAndDelete(this.dataGridView_Parameter.CurrentRow.Cells["GasAndWeldingFlux"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除!");
                }
            }
            else
            {
                MessageBox.Show("不能删除！");
            }
       }

        private void toolStripMenuItem_ParameterRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false );

        }

        private void dataGridView_Parameter_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_ParameterRow ;
                this.dataGridView_Parameter.CurrentCell = this.dataGridView_Parameter.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }


        }

        private void RefreshData(bool bool_JustFill)
        {
            if (this.dataGridView_Parameter.Tag != null)
            {
                Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[(string)this.dataGridView_Parameter.Tag];
                myClass_Data.RefreshData(bool_JustFill);
                this.label_Parameter.Text = string.Format("{0}，（{1}）：", this.myEventArgs_Parameter.str_ParameterName, this.dataGridView_Parameter.RowCount);                    
            }
        }

        private void contextMenuStrip_Parameter_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_ParameterAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Add);

        }

        private void contextMenuStrip_ParameterRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_ParameterRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Add);
            this.toolStripMenuItem_ParameterRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Delete);
            this.toolStripMenuItem_ParameterRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Modify);
            this.toolStripMenuItem_ParameterRowExport.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Print);
            if (this.myEventArgs_Parameter.str_Parameter == Enum_DataTable.Employer.ToString())
            {
                this.toolStripMenuItem_ParameterRowExportEMSExcel.Visible = true ;
            }
            else
            {
                this.toolStripMenuItem_ParameterRowExportEMSExcel.Visible = false;
            }
        }

        private void toolStripMenuItem_ParameterRowFrozenThisColumn_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem_ParameterRowFrozenThisColumn.Checked)
            {
                if (this.dataGridView_Parameter .CurrentCell != null)
                {
                    this.dataGridView_Parameter.Columns[this.dataGridView_Parameter.CurrentCell.ColumnIndex].Frozen = true;
                }
            }
            else
            {
                for (int i = 0; i < this.dataGridView_Parameter.Columns.Count; i++)
                {
                    this.dataGridView_Parameter.Columns[i].Frozen = false;
                }
            }

        }

        private void toolStripMenuItem_ParameterRowExportExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Parameter, true, true );

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_Parameter.Tag == null)
            {
                return;
            }
            Form_QueryFilter myForm = new Form_QueryFilter();
            myForm.InitControl(this.dataGridView_Parameter.Tag.ToString());
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                EventArgs_Parameter my_e = new EventArgs_Parameter(this.dataGridView_Parameter.Tag.ToString(), this.myEventArgs_Parameter.str_ParameterName);
                my_e.str_Filter = myForm.str_Filter;
                my_e.bool_isFilter = true;
                Publisher_Parameter.OnEventName(my_e);

            }

        }

        private void toolStripMenuItem_ParameterRowExportEMSExcel_Click(object sender, EventArgs e)
        {
             if ((string)this.dataGridView_Parameter.Tag == Enum_DataTable.Employer .ToString())
            {
                Class_Employer myClass_Employer = new Class_Employer((string)this.dataGridView_Parameter.CurrentRow.Cells["EmployerHPID"].Value);
                Class_Public.ExportEMSExcel(myClass_Employer.EmployerLinkman, myClass_Employer.Employer, myClass_Employer.EmployerAddress, myClass_Employer.EmployerTel, myClass_Employer.EmployerCity, myClass_Employer.EmployerPostalcode);
            }
        }

    }
}
