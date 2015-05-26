using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;
using ZCCL.DataGridViewManager;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WeldingSubject_TreeView : UserControl
    {
        public UserControl_WeldingSubject_TreeView()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingSubject_TreeView_Load(object sender, EventArgs e)
        {
            this.InitTreeView();
        }

        private void InitTreeView()
        {
            this.treeView_Data .Nodes.Clear();
            TreeNode myTreeNode;
            TreeNode myTreeNode_WeldingStandard;
            DataView myDataView_WeldingStandard = new DataView(((Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingStandardAndGroup.ToString()]).myDataTable);
            myDataView_WeldingStandard.RowFilter = "WeldingStandardGroup='焊工考试标准'";

            myTreeNode = new TreeNode();
            myTreeNode.Text = "全部";
            myTreeNode.Tag = "全部";

            foreach (DataRowView myDataRowView in myDataView_WeldingStandard)
            {
                myTreeNode_WeldingStandard = new TreeNode();
                myTreeNode_WeldingStandard.Text = myDataRowView["WeldingStandard"].ToString();
                myTreeNode_WeldingStandard.Tag = myDataRowView["WeldingStandard"].ToString();
                myTreeNode.Nodes .Add(myTreeNode_WeldingStandard);
            }

            this.treeView_Data.Nodes.Add(myTreeNode);
            if (this.treeView_Data.SelectedNode != null)
            {
                if (this.treeView_Data.SelectedNode.Level == 0)
                {
                    EventArgs_WeldingStandard my_e = new EventArgs_WeldingStandard(null);
                    Publisher_WeldingStandard.OnEventName(my_e);
                }
                else
                {
                    EventArgs_WeldingStandard my_e = new EventArgs_WeldingStandard(this.treeView_Data.SelectedNode.Tag.ToString());
                    Publisher_WeldingStandard.OnEventName(my_e);
                }
            }
            else
            {
                EventArgs_WeldingStandard my_e = new EventArgs_WeldingStandard(null);
                Publisher_WeldingStandard.OnEventName(my_e);
            }
            this.label_Data.Text = string.Format("焊工考试标准，（{0}）：", myDataView_WeldingStandard.Count );
        }

        private void treeView_Data_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeView_Data.SelectedNode.Level == 0)
            {
                EventArgs_WeldingStandard my_e = new EventArgs_WeldingStandard(null);
                Publisher_WeldingStandard.OnEventName(my_e);
            }
            else
            {
                EventArgs_WeldingStandard my_e = new EventArgs_WeldingStandard(this.treeView_Data .SelectedNode.Tag.ToString());
                Publisher_WeldingStandard.OnEventName(my_e);
            }

        }

        private void toolStripMenuItem_DataGridViewColumnGroupRefresh_Click(object sender, EventArgs e)
        {
            this.InitTreeView();
        }
    }
}
