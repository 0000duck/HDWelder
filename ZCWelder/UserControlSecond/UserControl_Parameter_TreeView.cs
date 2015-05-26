using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_Parameter_TreeView : UserControl
    {
        public UserControl_Parameter_TreeView()
        {
            InitializeComponent();
        }

        private void UserControl_Parameter_TreeView_Load(object sender, EventArgs e)
        {
            this.InitTreeView();
        }

        private void InitTreeView()
        {
            this.treeView_Parameter.Nodes.Clear();
            TreeNode myTreeNode;

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����";
            myTreeNode.Tag = Enum_DataTable.Material.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����CCS��";
            myTreeNode.Tag = Enum_DataTable.MaterialCCSGroup .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����ISO��";
            myTreeNode.Tag = Enum_DataTable.MaterialISOGroup  .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���Ӳ���";
            myTreeNode.Tag = Enum_DataTable.WeldingConsumable.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���Ӳ���CCS��";
            myTreeNode.Tag = Enum_DataTable.WeldingConsumableCCSGroup .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���Ӳ���ISO��";
            myTreeNode.Tag = Enum_DataTable.WeldingConsumableISOGroup  .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���ӷ���";
            myTreeNode.Tag = Enum_DataTable.WeldingProcess.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "��������";
            myTreeNode.Tag = Enum_DataTable.WorkPieceType.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "��������";
            myTreeNode.Tag = Enum_DataTable.JointType.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "װ�䷽ʽ";
            myTreeNode.Tag = Enum_DataTable.Assemblage.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���Կ�Ŀ���ù���";
            myTreeNode.Tag = Enum_DataTable.WeldingSubjectApplicable .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���ӱ�׼";
            myTreeNode.Tag = Enum_DataTable.WeldingStandard.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���ӱ�׼��";
            myTreeNode.Tag = Enum_DataTable.WeldingStandardGroup.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���ӱ�׼����";
            myTreeNode.Tag = Enum_DataTable.WeldingStandardAndGroup.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "ѧ��";
            myTreeNode.Tag = Enum_DataTable.Schooling.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "��˾Ŀ¼";
            myTreeNode.Tag = Enum_DataTable.EmployerGroup.ToString();

            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.EmployerGroup.ToString()];
            DataView myDataView_EmployerGroup = new DataView(myClass_Data.myDataTable);
            myDataView_EmployerGroup.Sort = "EmployerGroupIndex";

            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Employer.ToString()];
            DataView myDataView_Employer = new DataView(myClass_Data.myDataTable);
            myDataView_Employer.Sort = "EmployerIndex";

            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Department.ToString()];
            DataView myDataView_Department = new DataView(myClass_Data.myDataTable);
            myDataView_Department.Sort = "DepartmentIndex";

            TreeNode myTreeNode_EmployerGroup;
            TreeNode myTreeNode_Employer;
            TreeNode myTreeNode_Department;
            foreach (DataRowView myDataRowView_EmployerGroup in myDataView_EmployerGroup)
            {
                myTreeNode_EmployerGroup = new TreeNode();
                myTreeNode_EmployerGroup.Text = myDataRowView_EmployerGroup["EmployerGroup"].ToString();
                myTreeNode_EmployerGroup.Tag = Enum_DataTable.Employer .ToString();
                myTreeNode_EmployerGroup.Name = myDataRowView_EmployerGroup["EmployerGroup"].ToString();
                myDataView_Employer.RowFilter = string.Format("EmployerGroup='{0}'", myDataRowView_EmployerGroup["EmployerGroup"].ToString());
                foreach (DataRowView myDataRowView_Employer in myDataView_Employer)
                {
                    myTreeNode_Employer = new TreeNode();
                    myTreeNode_Employer.Text = myDataRowView_Employer["Employer"].ToString();
                    myTreeNode_Employer.Tag = Enum_DataTable.Department  .ToString();
                    myTreeNode_Employer.Name = myDataRowView_Employer["EmployerHPID"].ToString();
                    myDataView_Department.RowFilter = string.Format("EmployerHPID='{0}'", myDataRowView_Employer["EmployerHPID"].ToString());
                    foreach (DataRowView myDataRowView_Department in myDataView_Department)
                    {
                        myTreeNode_Department = new TreeNode();
                        myTreeNode_Department.Text = myDataRowView_Department["Department"].ToString();
                        myTreeNode_Department.Tag = Enum_DataTable.WorkPlace .ToString();
                        myTreeNode_Department.Name = myDataRowView_Department["DepartmentHPID"].ToString();
                        myTreeNode_Employer.Nodes.Add(myTreeNode_Department);
                    }
                    myTreeNode_EmployerGroup.Nodes.Add(myTreeNode_Employer);
                }
                myTreeNode.Nodes.Add(myTreeNode_EmployerGroup);
            }
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "��˾�������";
            myTreeNode.Tag ="";

            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.LaborServiceTeam.ToString()];
            DataView myDataView_LaborServiceTeam = new DataView(myClass_Data.myDataTable);
            myDataView_LaborServiceTeam.Sort = "LaborServiceTeamIndex";
            myDataView_Employer.RowFilter = null;
            foreach (DataRowView myDataRowView_Employer in myDataView_Employer)
            {
                myTreeNode_Employer = new TreeNode();
                myTreeNode_Employer.Text = myDataRowView_Employer["Employer"].ToString();
                myTreeNode_Employer.Tag = Enum_DataTable.LaborServiceTeam  .ToString();
                myTreeNode_Employer.Name = myDataRowView_Employer["EmployerHPID"].ToString();
                myTreeNode.Nodes.Add(myTreeNode_Employer);
            }
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "������λ";
            myTreeNode.Tag = Enum_DataTable.KindofEmployer.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "������";
            myTreeNode.Tag = Enum_DataTable.ShipClassification.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����ϵ��";
            myTreeNode.Tag = Enum_DataTable.Ship .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "������ʹ���ϵ��";
            myTreeNode.Tag = Enum_DataTable.ShipandShipClassification  .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����������";
            myTreeNode.Tag = Enum_DataTable.TestCommittee.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���Է�ʽ";
            myTreeNode.Tag = Enum_DataTable.KindofExam .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����״̬";
            myTreeNode.Tag = Enum_DataTable.ExamStatus.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "ȱ��";
            myTreeNode.Tag = Enum_DataTableSecond.Flaw.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "�����豸";
            myTreeNode.Tag = Enum_DataTableSecond.WeldingEquipment  .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "�¿���ʽ";
            myTreeNode.Tag = Enum_DataTable.GrooveType.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "��������";
            myTreeNode.Tag = Enum_DataTableSecond.KindofWeld.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "������ʽ";
            myTreeNode.Tag = Enum_DataTable.LayerWelding.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����λ��";
            myTreeNode.Tag = Enum_DataTable.WeldingPosition.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���ӵ�������";
            myTreeNode.Tag = Enum_DataTableSecond.TypeofCurrentAndPolarity.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���Ӹ���������";
            myTreeNode.Tag = Enum_DataTableSecond.GasAndWeldingFluxGroup .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���Ӹ������Ͻ���";
            myTreeNode.Tag = Enum_DataTableSecond.GasAndWeldingFlux .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "ͼƬ��";
            myTreeNode.Tag = Enum_DataTableSecond.ImageGroup .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "�ȴ���ʽ";
            myTreeNode.Tag = Enum_DataTableSecond.HeatTreatment  .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "���ȷ�ʽ";
            myTreeNode.Tag = Enum_DataTableSecond.HeatMethod .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "��������";
            myTreeNode.Tag = Enum_DataTableSecond.KindofLimit  .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����Ŀ";
            myTreeNode.Tag = Enum_DataTableSecond.Subject.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "�ж���";
            myTreeNode.Tag = Enum_DataTableSecond.Judgment   .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "ѡ����";
            myTreeNode.Tag = Enum_DataTableSecond.Choice .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����ѡ����";
            myTreeNode.Tag = Enum_DataTableSecond.MultiChoice.ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "�ʴ���";
            myTreeNode.Tag = Enum_DataTableSecond.EssayQuestion .ToString();
            this.treeView_Parameter.Nodes.Add(myTreeNode);

            this.label_Parameter.Text = string.Format("��������{0}����", this.treeView_Parameter.Nodes.Count);
        }

        private void toolStripMenuItem_ParameterRefresh_Click(object sender, EventArgs e)
        {
            this.InitTreeView();
        }

        private void treeView_Parameter_AfterSelect(object sender, TreeViewEventArgs e)
        {           
             EventArgs_Parameter  my_e = new EventArgs_Parameter((string)this.treeView_Parameter.SelectedNode.Tag, this.treeView_Parameter.SelectedNode.Text , this.treeView_Parameter.SelectedNode.Name );
             Publisher_Parameter.OnEventName(my_e);
        }

    }
}
