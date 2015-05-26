using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_DataManager_TreeView : UserControl
    {
        public UserControl_DataManager_TreeView()
        {
            InitializeComponent();
        }

        private void UserControl_DataManager_TreeView_Load(object sender, EventArgs e)
        {
            this.InitTreeView();

        }

        private void InitTreeView()
        {
            this.treeView_Data .Nodes.Clear();
            TreeNode myTreeNode;

            myTreeNode = new TreeNode();
            myTreeNode.Text = "������¼";
            myTreeNode.Tag = Enum_DataTable.Welder .ToString();
            myTreeNode.Name  = Enum_DataTable.Welder .ToString();
            this.treeView_Data.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "�������Լ�¼";
            myTreeNode.Tag = Enum_DataTable.WelderIssueStudentQCRegistrationNo.ToString();
            myTreeNode.Name  = Enum_DataTable.ExamAll.ToString();
            this.treeView_Data.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����������Ŀ��¼";
            myTreeNode.Tag = Enum_DataTable.SubjectPositionResultSecond   .ToString();
            myTreeNode.Name  = Enum_DataTable.SubjectPositionResultSecond   .ToString();
            this.treeView_Data.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����֤���¼";
            myTreeNode.Tag = Enum_DataTable.WelderIssueStudentQCRegistrationNo .ToString();
            myTreeNode.Name = Enum_DataTable.WelderIssueStudentQCRegistrationNo.ToString();
            this.treeView_Data.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "�ڲẸ����¼";
            myTreeNode.Tag = Enum_DataTable.WelderBelong .ToString();
            myTreeNode.Name = Enum_DataTable.WelderBelong.ToString();
            this.treeView_Data.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "�ڲẸ�����Լ�¼";
            myTreeNode.Tag = Enum_DataTable.WelderBelongExam .ToString();
            myTreeNode.Name = Enum_DataTable.WelderBelongExam.ToString();
            this.treeView_Data.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "�༶���̼�¼";
            myTreeNode.Tag = Enum_DataTable.IssueProcessUnion.ToString();
            myTreeNode.Name  = Enum_DataTable.IssueProcessUnion.ToString();
            this.treeView_Data.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "������ż�¼";
            myTreeNode.Tag = Enum_DataTable.WelderTestCommitteeRegistrationNo.ToString();
            myTreeNode.Name  = Enum_DataTable.WelderTestCommitteeRegistrationNo.ToString();
            this.treeView_Data.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "������";
            myTreeNode.Tag = Enum_DataTable.BlackList .ToString();
            myTreeNode.Name = Enum_DataTable.BlackList.ToString();
            this.treeView_Data.Nodes.Add(myTreeNode);

            myTreeNode = new TreeNode();
            myTreeNode.Text = "����������¼";
            myTreeNode.Tag = Enum_DataTable.WelderBelongLog .ToString();
            myTreeNode.Name = Enum_DataTable.WelderBelongLog.ToString();
            this.treeView_Data.Nodes.Add(myTreeNode);

            this.label_Data.Text = string.Format("�������ݣ���{0}����", this.treeView_Data.Nodes.Count);
        }

        private void treeView_Data_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EventArgs_DataManager my_e = new EventArgs_DataManager((string)this.treeView_Data .SelectedNode.Text , this.treeView_Data .SelectedNode.Name , this.treeView_Data.SelectedNode.Tag .ToString () );
            Publisher_DataManager.OnEventName(my_e);

        }

    }
}
