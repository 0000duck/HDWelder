using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCCL.AspNet;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_KindofEmployer_TreeView : UserControl
    {
        public UserControl_KindofEmployer_TreeView()
        {
            InitializeComponent();
        }

        private void UserControl_KindofEmployer_TreeView_Load(object sender, EventArgs e)
        {
            if (Class_zwjPublic.mysplitContainerHeadBackColor != Color.Empty)
            {
                this.splitContainer1.Panel1.BackColor = Class_zwjPublic.mysplitContainerHeadBackColor;
            }
            if (Class_zwjPublic.mysplitContainerHeadForeColor != Color.Empty)
            {
                this.splitContainer1.Panel1.ForeColor = Class_zwjPublic.mysplitContainerHeadForeColor;
            }
            this.InitTreeView();
        }

        private void InitTreeView()
        {
            this.treeView_Data.Nodes.Clear();
            TreeNode myTreeNode;
            TreeNode myTreeNode_KindofEmployer;
            myTreeNode = new TreeNode();
            myTreeNode.Text = "报考单位";
            myTreeNode.Tag = "报考单位";

            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.KindofEmployer.ToString()];

            foreach (DataRowView myDataRowView_KindofEmployer in myClass_Data.myDataView)
            {
                myTreeNode_KindofEmployer = new TreeNode();
                myTreeNode_KindofEmployer.Text = myDataRowView_KindofEmployer["KindofEmployer"].ToString();
                myTreeNode_KindofEmployer.Tag = myDataRowView_KindofEmployer["KindofEmployer"].ToString();
                if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read))
                {
                    myTreeNode.Nodes.Add(myTreeNode_KindofEmployer);
                }
                else if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read))
                {
                    Class_KindofEmployer myClass_KindofEmployer = new Class_KindofEmployer(myDataRowView_KindofEmployer["KindofEmployer"].ToString());
                    if (myClass_KindofEmployer.KindofEmployerManagerID.Equals(Class_zwjPublic.myClass_CustomUser.UserGUID))
                    {
                        myTreeNode.Nodes.Add(myTreeNode_KindofEmployer);
                    }
                }
            }
            this.treeView_Data.Nodes.Add(myTreeNode);
            this.label_Data.Text = string.Format("报考单位：({0})", myTreeNode.Nodes.Count );
        }

        private void toolStripMenuItem_DataGridViewColumnGroupRefresh_Click(object sender, EventArgs e)
        {
            this.InitTreeView();
        }

        private void treeView_Data_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EventArgs_KindofEmployer myEventArgs_KindofEmployer = new EventArgs_KindofEmployer();
            switch (this.treeView_Data.SelectedNode.Level)
            {
                case 0:
                    break;
                case 1:
                    myEventArgs_KindofEmployer.str_KindofEmployer  = this.treeView_Data.SelectedNode.Tag .ToString();
                    Publisher_KindofEmployer.OnEventName(myEventArgs_KindofEmployer);
                    break;
            }

        }
    }
}
