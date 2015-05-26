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
    public partial class UserControl_Unit_TreeView : UserControl
    {
        public UserControl_Unit_TreeView()
        {
            InitializeComponent();
        }

        private void UserControl_Unit_TreeView_Load(object sender, EventArgs e)
        {
            this.InitTreeView();
        }

        private void InitTreeView()
        {
            this.treeView_Data.Nodes.Clear();
            TreeNode myTreeNode;
            TreeNode myTreeNode_EmployerGroup;
            TreeNode myTreeNode_Employer;
            TreeNode myTreeNode_Department;
            TreeNode myTreeNode_WorkPlace;

            myTreeNode = new TreeNode();
            myTreeNode.Text = "公司目录";
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

            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WorkPlace.ToString()];
            DataView myDataView_WorkPlace = new DataView(myClass_Data.myDataTable);
            myDataView_WorkPlace.Sort = "WorkPlaceIndex";

            foreach (DataRowView myDataRowView_EmployerGroup in myDataView_EmployerGroup)
            {
                myTreeNode_EmployerGroup = new TreeNode();
                myTreeNode_EmployerGroup.Text = myDataRowView_EmployerGroup["EmployerGroup"].ToString();
                myTreeNode_EmployerGroup.Tag = Enum_DataTable.Employer.ToString();
                myTreeNode_EmployerGroup.Name = myDataRowView_EmployerGroup["EmployerGroup"].ToString();
                myDataView_Employer.RowFilter = string.Format("EmployerGroup='{0}'", myDataRowView_EmployerGroup["EmployerGroup"].ToString());
                foreach (DataRowView myDataRowView_Employer in myDataView_Employer)
                {
                    myTreeNode_Employer = new TreeNode();
                    myTreeNode_Employer.Text = myDataRowView_Employer["Employer"].ToString();
                    myTreeNode_Employer.Tag = Enum_DataTable.Department.ToString();
                    myTreeNode_Employer.Name = myDataRowView_Employer["EmployerHPID"].ToString();
                    myDataView_Department.RowFilter = string.Format("EmployerHPID='{0}'", myDataRowView_Employer["EmployerHPID"].ToString());
                    foreach (DataRowView myDataRowView_Department in myDataView_Department)
                    {
                        myTreeNode_Department = new TreeNode();
                        myTreeNode_Department.Text = myDataRowView_Department["Department"].ToString();
                        myTreeNode_Department.Tag = Enum_DataTable.WorkPlace.ToString();
                        myTreeNode_Department.Name = myDataRowView_Department["DepartmentHPID"].ToString();
                        myDataView_WorkPlace.RowFilter = string.Format("DepartmentHPID='{0}'", myDataRowView_Department["DepartmentHPID"].ToString());
                        foreach (DataRowView myDataRowView_WorkPlace in myDataView_WorkPlace)
                        {
                            myTreeNode_WorkPlace = new TreeNode();
                            myTreeNode_WorkPlace.Text = myDataRowView_WorkPlace["WorkPlace"].ToString();
                            myTreeNode_WorkPlace.Tag = Enum_DataTable.WorkPlace.ToString();
                            myTreeNode_WorkPlace.Name = myDataRowView_WorkPlace["WorkPlaceHPID"].ToString();
                            myTreeNode_Department.Nodes.Add(myTreeNode_WorkPlace);
                        }         
                        myTreeNode_Employer.Nodes.Add(myTreeNode_Department);
                    }
                    myTreeNode_EmployerGroup.Nodes.Add(myTreeNode_Employer);
                }
                myTreeNode.Nodes.Add(myTreeNode_EmployerGroup);
            }
            this.treeView_Data .Nodes.Add(myTreeNode);
            this.label_Data.Text = string.Format("公司目录，（{0}）：", myDataView_Employer.Count );
        }

        private void treeView_Data_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EventArgs_Unit myEventArgs_Unit = new EventArgs_Unit();
            switch (this.treeView_Data.SelectedNode.Level)
            {
                case 0:
                    break;
                case 1:
                    myEventArgs_Unit.EmployerGroup = this.treeView_Data.SelectedNode.Name.ToString();
                    break;
                case 2:
                    myEventArgs_Unit.EmployerHPID = this.treeView_Data.SelectedNode.Name.ToString();
                    break;
                case 3:
                    myEventArgs_Unit.DepartmentHPID = this.treeView_Data.SelectedNode.Name.ToString();
                    break;
                case 4:
                    myEventArgs_Unit.WorkPlaceHPID = this.treeView_Data.SelectedNode.Name.ToString();
                    break;
            }
            Publisher_Unit.OnEventName(myEventArgs_Unit);

        }

        private void toolStripMenuItem_DataGridViewColumnGroupRefresh_Click(object sender, EventArgs e)
        {
            this.InitTreeView();
        }
    }
}
