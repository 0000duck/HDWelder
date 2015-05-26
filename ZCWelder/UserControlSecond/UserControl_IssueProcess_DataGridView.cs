using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCCL.AspNet;
using ZCWelder.ClassBase;
using ZCWelder.Exam;
using ZCCL.ProcessStatus;
using ZCCL.Report;
using ZCWelder.CrystalReports;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_IssueProcess_DataGridView : UserControl
    {
        private EventArgs_Issue myEventArgs_Issue;
        private DataTable myDataTable;
        private DataView myDataView;
        private string str_ProcessApplication = "焊工考试";
        private string str_IssueProcessStatusGroup;

        public UserControl_IssueProcess_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_IssueProcess_DataGridView_Load(object sender, EventArgs e)
        {
            DataView myDataView = new DataView(Class_ProcessStatusGroup.myClass_Data.myDataTable);
            myDataView.RowFilter = string.Format("ProcessApplication='{0}'", this.str_ProcessApplication);
            myDataView.Sort = "ProcessStatusGroupIndex";

            TreeNode myTreeNode_ProcessStatusGroup;
            TreeNode myTreeNode;
            myTreeNode = new TreeNode();
            myTreeNode.Text = "全部";
            myTreeNode.Tag = "全部";
            foreach (DataRowView myDataRowView in myDataView)
            {
                myTreeNode_ProcessStatusGroup = new TreeNode();
                myTreeNode_ProcessStatusGroup.Text = myDataRowView["ProcessStatusGroup"].ToString();
                myTreeNode_ProcessStatusGroup.Tag = myDataRowView["ProcessStatusGroup"].ToString();
                myTreeNode.Nodes.Add(myTreeNode_ProcessStatusGroup);
            }
            this.treeView_IssueProcess.Nodes.Add(myTreeNode);
            Publisher_Issue.EventName += new EventHandler_Issue(InitDataGridView);

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_Issue e)
        {
            this.myEventArgs_Issue = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.IssueProcess.ToString(), false);
            Class_Data myClass_Data;
            if (this.myEventArgs_Issue.bool_GXTheory == false)
            {
                myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.IssueProcess.ToString()];
            }
            else
            {
                myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.GXTheoryIssueProcess.ToString()];
            }
            myClass_Data.SetFilter(string.Format("IssueNo='{0}'", e.str_IssueNo));
          
            if (this.myEventArgs_Issue.bool_JustFill)
            {
                if (this.myDataTable.Rows.Count == 0)
                {
                    this.dataGridView_Data.DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_Issue.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_Data.DataSource = this.myDataView;
                }
                else
                {
                    myClass_Data.RefreshData(this.myEventArgs_Issue.bool_JustFill, this.myDataTable);
                }
            }
            else
            {
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_Issue.bool_JustFill);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.myDataView = new DataView(this.myDataTable);
                this.dataGridView_Data.DataSource = this.myDataView;
            }
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            if (this.treeView_IssueProcess.SelectedNode == null || this.treeView_IssueProcess.SelectedNode.Level == 0)
            {
                ((DataView)this.dataGridView_Data.DataSource).RowFilter = null;
                this.label_Data.Text = string.Format("全部({0})：",  this.dataGridView_Data.RowCount);
            }
            else
            {
                ((DataView)this.dataGridView_Data.DataSource).RowFilter = string.Format("IssueProcessStatusGroup='{0}'", this.treeView_IssueProcess.SelectedNode.Tag.ToString());
                this.label_Data.Text = string.Format("{0}({1})：", this.treeView_IssueProcess.SelectedNode.Text, this.dataGridView_Data.RowCount);
            }

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            this.myEventArgs_Issue.bool_JustFill = bool_JustFill;
            Publisher_Issue.OnEventName(this.myEventArgs_Issue);

        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue==null || string.IsNullOrEmpty(this.myEventArgs_Issue.str_IssueNo) || this.treeView_IssueProcess.SelectedNode == null || this.treeView_IssueProcess.SelectedNode.Level == 0)
            {
                MessageBox.Show("不能添加，请确认是否选择某一个班级或班级进程类别！");
                return;
            }
            Form_IssueProcess_Update myForm = new Form_IssueProcess_Update();
            myForm.myClass_IssueProcess = new Class_IssueProcess();
            myForm.myClass_IssueProcess.IssueNo = this.myEventArgs_Issue.str_IssueNo;
            myForm.myClass_IssueProcess.GXTheory = this.myEventArgs_Issue.bool_GXTheory;
            myForm.str_ProcessStatusGroup = this.treeView_IssueProcess.SelectedNode.Tag.ToString();
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
                Class_DataControlBind.SetDataGridViewSelectedPosition("IssueProcessID", myForm.myClass_IssueProcess.IssueProcessID.ToString(), this.dataGridView_Data);
            }

        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_IssueProcess_Update myForm = new Form_IssueProcess_Update();
            myForm.myClass_IssueProcess = new Class_IssueProcess();
            myForm.myClass_IssueProcess.GXTheory = this.myEventArgs_Issue.bool_GXTheory;
            myForm.myClass_IssueProcess.IssueProcessID =(int) this.dataGridView_Data.CurrentRow.Cells["IssueProcessID"].Value;
            if (myForm.myClass_IssueProcess.FillData())
            {
                Class_ProcessStatus myClass_ProcessStatus = new Class_ProcessStatus(myForm.myClass_IssueProcess.IssueProcessStatus);
                myForm.str_ProcessStatusGroup = myClass_ProcessStatus.ProcessStatusGroup;
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else
            {
                MessageBox.Show("该行数据已被删除！");
            }

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowDelete_Click(object sender, EventArgs e)
        {
            if (Class_IssueProcess.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["IssueProcessID"].Value, this.myEventArgs_Issue.bool_GXTheory  , Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_IssueProcess.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["IssueProcessID"].Value, this.myEventArgs_Issue.bool_GXTheory, Enum_zwjKindofUpdate.Delete);
                    this.RefreshData(false);
                }
            }
            else
            {
                MessageBox.Show("不能删除！");
            }

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowRefresh_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue == null)
            {
                return;
            }
            this.RefreshData(false);

        }

        /// <summary>
        /// 导出数据到Excel电子表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true);;

        }

        /// <summary>
        /// 冻结或解冻任意数据列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Data);

        }

        /// <summary>
        /// 设置快捷菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Data_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_DataGridViewRow;
                this.dataGridView_Data.CurrentCell = this.dataGridView_Data.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridView_Opening(object sender, CancelEventArgs e)
        {
            if (this.myEventArgs_Issue==null)
            {
                return;
            }
            bool bool_Finished;
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
                bool_Finished = Class_GXTheoryIssue.CheckFinished(this.myEventArgs_Issue.str_IssueNo);
            }
            else
            {
                bool_Finished = Class_Issue.CheckFinished(this.myEventArgs_Issue.str_IssueNo);
            }

            this.toolStripMenuItem_DataGridViewAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Add) && !bool_Finished;
            this.toolStripMenuItem_DataGridViewAddBatch.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Add) && !bool_Finished;
        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            bool bool_Finished;
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
                bool_Finished = Class_GXTheoryIssue.CheckFinished(this.myEventArgs_Issue.str_IssueNo);
            }
            else
            {
                bool_Finished = Class_Issue.CheckFinished(this.myEventArgs_Issue.str_IssueNo);
            }

            this.toolStripMenuItem_DataGridViewRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Add) && !bool_Finished;
            this.toolStripMenuItem_DataGridViewRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Delete) && !bool_Finished;
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Print);
        }

        private void treeView_IssueProcess_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.str_IssueProcessStatusGroup = null;
            if (this.dataGridView_Data .DataSource != null)
            {
                switch (this.treeView_IssueProcess.SelectedNode.Level)
                {
                    case 0:
                        ((DataView)this.dataGridView_Data.DataSource).RowFilter = null;
                        break;
                    case 1 :
                        ((DataView)this.dataGridView_Data.DataSource).RowFilter = string.Format("IssueProcessStatusGroup='{0}'",  this.treeView_IssueProcess.SelectedNode.Tag.ToString());
                        this.str_IssueProcessStatusGroup = this.treeView_IssueProcess.SelectedNode.Tag.ToString();
                        break;
                }
                this.label_Data .Text = string.Format("{0}({1})：", e.Node.Text, this.dataGridView_Data.RowCount);
            }
        }

        private void toolStripMenuItem_DataGridViewRowExportToIssueArchive_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
                Form_CrystalReport myForm_Report = new Form_CrystalReport();
                System.Collections.ArrayList myArrayList = new System.Collections.ArrayList();
                myArrayList.Add(this.myEventArgs_Issue.str_IssueNo);
                string str_FileName = string.Format("{0}\\CrystalReports\\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "GXTheoryIssueArchive档案袋_大.rpt");
                myForm_Report.InitCrystalReport(str_FileName, "IssueNo", myArrayList, null, null);
                myForm_Report.ShowDialog();
            }
            else
            {
                Form_CrystalReport myForm_Report = new Form_CrystalReport();
                System.Collections.ArrayList myArrayList = new System.Collections.ArrayList();
                myArrayList.Add(this.myEventArgs_Issue.str_IssueNo);
                string str_FileName = string.Format("{0}\\CrystalReports\\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "IssueArchive档案袋_大.rpt");
                myForm_Report.InitCrystalReport(str_FileName, "IssueNo", myArrayList, null, null);
                myForm_Report.ShowDialog();
            }

        }

        private void toolStripMenuItem_DataGridViewAddBatch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.str_IssueProcessStatusGroup) || this.myEventArgs_Issue == null ||string.IsNullOrEmpty( this.myEventArgs_Issue.str_IssueNo))
            {
                return;
            }
            Form_ProcessStatusQuery myForm = new Form_ProcessStatusQuery();
            myForm.InitDataGridView(this.treeView_IssueProcess.SelectedNode.Tag.ToString(), true);
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Class_IssueProcess myClass_IssueProcess = new Class_IssueProcess();
                foreach (DataRow myDataRow in myForm.myDataTable.Rows)
                {
                    myClass_IssueProcess.IssueProcessBeginDate =DateTime.Today ;
                    myClass_IssueProcess.IssueProcessEndDate = DateTime.Today;
                    myClass_IssueProcess.IssueProcessFinished = true ;
                    myClass_IssueProcess.IssueProcessStatus = myDataRow["ProcessStatus"].ToString();
                    myClass_IssueProcess.GXTheory = this.myEventArgs_Issue.bool_GXTheory;
                    myClass_IssueProcess.IssueNo = this.myEventArgs_Issue.str_IssueNo;
                    myClass_IssueProcess.IssueProcessPrincipal = Class_zwjPublic.myClass_CustomUser.UserGUID;
                    myClass_IssueProcess.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
                this.RefreshData(true);
            }

        }

    }
}
