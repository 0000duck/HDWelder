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
using System.Data.SqlClient;
using ZCWelder.Reports;
using ZCWelder.CrystalReports;
using ZCCL.Report;
using Microsoft.Reporting.WinForms;
using ZCCL.Tools;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_Issue_DataGridView : UserControl
    {
        private EventArgs_ShipClassification myEventArgs_ShipClassification;
        private DataTable myDataTable;
        private DataView myDataView;

        public UserControl_Issue_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_Issue_DataGridView_Load(object sender, EventArgs e)
        {
            Publisher_ShipClassification.EventName += new EventHandler_ShipClassification(this.InitDataGridView);

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_ShipClassification e)
        {
            this.myEventArgs_ShipClassification = e;
            string str_Filter;
            if (!string.IsNullOrEmpty(this.myEventArgs_ShipClassification.str_ShipClassificationAb))
            {
                str_Filter = string.Format("ShipClassificationAb='{0}'", this.myEventArgs_ShipClassification.str_ShipClassificationAb);
                if (!string.IsNullOrEmpty(this.myEventArgs_ShipClassification.str_ShipboardNo))
                {
                    str_Filter += string.Format(" And ShipboardNo='{0}'", this.myEventArgs_ShipClassification.str_ShipboardNo);
                    //if (this.myEventArgs_ShipClassification.bool_GXTheory)
                    //{
                    //    Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.GXTheoryIssue.ToString());
                    //    myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.GXTheoryIssue.ToString()];
                    //}
                }
                else if (!string.IsNullOrEmpty(this.myEventArgs_ShipClassification.str_Year))
                {
                    str_Filter += string.Format(" And (SignUpDate >= '{0}-1-1' and SignUpDate<='{0}-12-31 23:59:59.997')", this.myEventArgs_ShipClassification.str_Year);
                }
            }
            else
            {
                str_Filter = this.myEventArgs_ShipClassification.str_Filter;
            }
            Class_Data myClass_Data;
            if (this.myEventArgs_ShipClassification.bool_GXTheory)
            {
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.GXTheoryIssue.ToString(), false);
                myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.GXTheoryIssue.ToString()];
            }
            else
            {
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.Issue.ToString(), false);
                myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Issue.ToString()];
            }

            if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read))
            {
            }
            else if (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("报考权限"), Enum_zwjKindofUpdate.Read))
            {
                Class_Data myClass_Data_KindofEmployer = (Class_Data)Class_Public.myHashtable[Enum_DataTable.KindofEmployer.ToString()];
                string str_Filter_KindofEmployer="(1=0";
                foreach (DataRowView myDataRowView_KindofEmployer in myClass_Data_KindofEmployer.myDataView)
                {
                    Class_KindofEmployer myClass_KindofEmployer = new Class_KindofEmployer(myDataRowView_KindofEmployer["KindofEmployer"].ToString());
                    if (myClass_KindofEmployer.KindofEmployerManagerID.Equals(Class_zwjPublic.myClass_CustomUser.UserGUID))
                    {
                        str_Filter_KindofEmployer += string.Format(" or KindofEmployer='{0}'", myClass_KindofEmployer.KindofEmployer) ;
                    }
                }
                str_Filter_KindofEmployer += ")";
                str_Filter = str_Filter_KindofEmployer + " and ("  + str_Filter + ")";
            }


            myClass_Data.SetFilter(str_Filter);
            if (this.myEventArgs_ShipClassification.bool_JustFill)
            {
                if (this.myDataTable.Rows.Count == 0)
                {
                    this.dataGridView_Data.DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_ShipClassification.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_Data.DataSource = this.myDataView;
                    if (this.dataGridView_Data.Rows.Count >0)
                    {
                        this.dataGridView_Data.CurrentCell = this.dataGridView_Data.Rows[this.dataGridView_Data.Rows.Count-1].Cells["IssueNo"];
                    }
                }
                else
                {
                    myClass_Data.RefreshData(this.myEventArgs_ShipClassification.bool_JustFill, this.myDataTable);
                }
            }
            else
            {
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_ShipClassification.bool_JustFill);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.myDataView = new DataView(this.myDataTable);
                this.dataGridView_Data.DataSource = this.myDataView;
                if (this.dataGridView_Data.Rows.Count >0)
                {
                    this.dataGridView_Data.CurrentCell = this.dataGridView_Data.Rows[this.dataGridView_Data.Rows.Count-1].Cells["IssueNo"];
                }
            }
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            this.label_Data.Text = string.Format("班级，({0})：", this.dataGridView_Data.RowCount);
            if (this.dataGridView_Data.RowCount == 0)
            {
                EventArgs_Issue my_e = new EventArgs_Issue(null, this.myEventArgs_ShipClassification.bool_GXTheory);
                Publisher_Issue.OnEventName(my_e);
            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            if (this.myEventArgs_ShipClassification == null)
            {
                return;
            }
            this.myEventArgs_ShipClassification.bool_JustFill = bool_JustFill;
            Publisher_ShipClassification.OnEventName(this.myEventArgs_ShipClassification );

        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_ShipClassification.bool_GXTheory)
            {
                Form_GXTheoryIssue_Update myForm = new Form_GXTheoryIssue_Update();
                myForm.myClass_GXTheoryIssue = new Class_GXTheoryIssue();
                myForm.myClass_GXTheoryIssue.IssueNo = this.dataGridView_Data.CurrentRow.Cells["IssueNo"].Value.ToString();
                if (myForm.myClass_GXTheoryIssue.FillData())
                {
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
            else
            {
                Form_Issue_Update myForm = new Form_Issue_Update();
                myForm.myClass_Issue = new Class_Issue();
                myForm.myClass_Issue.IssueNo = this.dataGridView_Data.CurrentRow.Cells["IssueNo"].Value.ToString();
                if (myForm.myClass_Issue.FillData())
                {
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

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowDelete_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_ShipClassification.bool_GXTheory)
            {
                if (Class_GXTheoryIssue.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["IssueNo"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_GXTheoryIssue.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["IssueNo"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除！");
                }
            }
            else
            {
                if (Class_Issue.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["IssueNo"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_Issue.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["IssueNo"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除！");
                }
            }

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowRefresh_Click(object sender, EventArgs e)
        {
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
            if (this.myEventArgs_ShipClassification == null)
            {
                e.Cancel = true;
            }
            this.toolStripMenuItem_DataGridViewAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Add);
        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_DataGridViewRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Add);
            this.toolStripMenuItem_DataGridViewRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify);
            this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Delete);
            //this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Print);
            this.toolStripMenuItem_RowLockOut.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.LockOut);

            if (this.myEventArgs_ShipClassification.bool_GXTheory)
            {
                if (Class_GXTheoryIssue.CheckFinished(this.dataGridView_Data.CurrentRow.Cells["IssueNo"].Value.ToString()))
                {
                    this.toolStripMenuItem_DataGridViewRowModify.Enabled = false;
                    this.toolStripMenuItem_DataGridViewRowDelete.Enabled = false;
                }
            }
            else
            {
                if (Class_Issue.CheckFinished(this.dataGridView_Data .CurrentRow.Cells["IssueNo"].Value.ToString()))
                {
                    this.toolStripMenuItem_DataGridViewRowModify.Enabled = false;
                    this.toolStripMenuItem_DataGridViewRowDelete.Enabled = false;
                }
            }
        }

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            EventArgs_Issue my_e = new EventArgs_Issue(this.dataGridView_Data.Rows[e.RowIndex].Cells["IssueNo"].Value.ToString(), this.myEventArgs_ShipClassification.bool_GXTheory);
            Publisher_Issue.OnEventName(my_e);

        }

        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            Class_ShipClassification myClass_ShipClassification;
            if (string.IsNullOrEmpty(this.myEventArgs_ShipClassification.str_ShipClassificationAb))
            {
                MessageBox.Show("请先选择船级社！");
                return;
            }
            else
            {
                myClass_ShipClassification = new Class_ShipClassification(this.myEventArgs_ShipClassification.str_ShipClassificationAb);
                if (myClass_ShipClassification.ShipRestrict && string.IsNullOrEmpty( this.myEventArgs_ShipClassification.str_ShipboardNo ))
                {
                    MessageBox.Show("请先选择船号！");
                    return;
                }
            }

            if (this.myEventArgs_ShipClassification.bool_GXTheory)
            {
                Form_GXTheoryIssue_Update myForm = new Form_GXTheoryIssue_Update();
                myForm.myClass_GXTheoryIssue = new Class_GXTheoryIssue();
                myForm.bool_Add = true;
                myForm.myClass_GXTheoryIssue.ShipClassificationAb = this.myEventArgs_ShipClassification.str_ShipClassificationAb;
                myForm.myClass_GXTheoryIssue.ShipboardNo = this.myEventArgs_ShipClassification.str_ShipboardNo;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                    Class_DataControlBind.SetDataGridViewSelectedPosition("IssueNo", myForm.myClass_GXTheoryIssue.IssueNo, this.dataGridView_Data);
                }
            }
            else
            {
                Form_Issue_Update myForm = new Form_Issue_Update();
                myForm.myClass_Issue = new Class_Issue();
                myForm.bool_Add = true;
                myForm.myClass_Issue.ShipClassificationAb = this.myEventArgs_ShipClassification.str_ShipClassificationAb;
                myForm.myClass_Issue.ShipboardNo = this.myEventArgs_ShipClassification.str_ShipboardNo;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                    Class_DataControlBind.SetDataGridViewSelectedPosition("IssueNo", myForm.myClass_Issue.IssueNo, this.dataGridView_Data);
                }
            }

        }

        private void toolStripMenuItem_UpdateIssueStatus_Click(object sender, EventArgs e)
        {
            return;
            Class_Issue.UpdateIssueStatus(null);
            Class_GXTheoryIssue.UpdateIssueStatus(null);
            this.RefreshData(true);
        }

        private void toolStripMenuItem_RowExportCrystalReports_Click(object sender, EventArgs e)
        {
            Form_ReportSelect myForm = new Form_ReportSelect();
            myForm.myClass_Report = new Class_Report();
            myForm.myClass_Report.ReportGroup = "班级";
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Form_CrystalReport myForm_Report = new Form_CrystalReport();
                System.Collections.ArrayList myArrayList = new System.Collections.ArrayList();
                foreach (DataRowView myDataRowView in (DataView)this.dataGridView_Data .DataSource)
                {
                    myArrayList.Add(myDataRowView["IssueNo"].ToString());
                }
                string str_FileName = string.Format("{0}\\CrystalReports\\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), myForm.myClass_Report.ReportLocation);
                myForm_Report.InitCrystalReport(str_FileName, "IssueNo", myArrayList, null, myForm.str_Subhead);

                myForm_Report.ShowDialog();
            }

        }

        private void toolStripMenuItem_RowLockOut_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem_RowLockOut.Text == "解锁")
            {
                if (this.myEventArgs_ShipClassification != null)
                {
                    if (this.myEventArgs_ShipClassification.bool_GXTheory)
                    {
                        Class_GXTheoryIssue.LockOut(this.dataGridView_Data.CurrentRow.Cells["IssueNo"].Value.ToString(), false);
                        this.RefreshData(true);
                    }
                    else
                    {
                        Class_Issue.LockOut(this.dataGridView_Data.CurrentRow.Cells["IssueNo"].Value.ToString(), false);
                        this.RefreshData(true);
                    }
                }
            }
            else
            {
            }

        }

        private void toolStripMenuItem_RowIssueStat_Click(object sender, EventArgs e)
        {
            string[] str_IssueNo = new string[this.myDataView.Count];
            for (int i = 0; i < this.myDataView.Count; i++)
            {
                str_IssueNo[i] = this.myDataView[i]["IssueNo"].ToString();
            }
            ReportParameter myReportParameter = new ReportParameter("Report_Parameter_IssueNo", str_IssueNo);
            ReportParameter[] myReportParameterRange = new ReportParameter[] { myReportParameter };
            Form_Report_IssueStat myForm = new Form_Report_IssueStat();
            myForm.myReportParameterRange = myReportParameterRange;
            myForm.ShowDialog();
        }

        private void toolStripMenuItem_RowIssueStatSecond_Click(object sender, EventArgs e)
        {
            if (myEventArgs_ShipClassification.bool_GXTheory)
            {
                return;
            }
            string str_Subhead;
            Form_InputBox myForm_InputBox = new Form_InputBox();
            myForm_InputBox.str_Title = "报表副标题输入";
            myForm_InputBox.str_Prompt = "请输入报表的副标题：";
            if (myForm_InputBox.ShowDialog() == DialogResult.OK)
            {
                str_Subhead = myForm_InputBox.str_DefaultResponse;
            }
            else
            {
                return;
            }
            StringBuilder str_IssueStat=new StringBuilder();
            str_IssueStat.Append("select t4.WeldingClass, t4.WeldingClassCount, t5.* from dbo.Exam_Issue as t5 left join");
            str_IssueStat.Append(" (select t1.issueno, t3.WeldingClass, count(t3.WeldingClass) as WeldingClassCount from dbo.Exam_Issue as t1 inner join dbo.Exam_Student as t2 on t1.issueno=t2.issueno");
            str_IssueStat.Append(" inner join dbo.Parameter_WeldingSubject as t3 on t2.ExamSubjectID = t3.SubjectID");
            str_IssueStat.Append(" where t2.SkillResult=1 or t2.SkillMakeupResult=1");
            str_IssueStat.Append(" group by t1.issueno, t3.WeldingClass) as t4 on t5.issueno=t4.issueno");
            str_IssueStat.Append(" where ");
            bool b_Flag = false  ;
            foreach (DataRow myDataRow in this.myDataTable.Rows)
            {
                if (b_Flag)
                {
                    str_IssueStat.Append(" Or ");
                }
                else
                {
                     b_Flag = true;
                }
                str_IssueStat.Append(string.Format(" t5.IssueNo = '{0}'", myDataRow["IssueNo"].ToString()));
            }
            ReportDataSource[] myReportDataSourceRange = new ReportDataSource[2];
            myReportDataSourceRange[0] = new ReportDataSource("DataSet_IssueStat", Class_zwjPublic.myClass_SqlConnection.GetDataTable(str_IssueStat.ToString()));
            myReportDataSourceRange[1] = new ReportDataSource("DataSet_IssueStatSecond", this.myDataView );
            ReportParameter myReportParameter_Subhead = new ReportParameter("Report_Parameter_Subhead", str_Subhead);
            ReportParameter[] myReportParameterRange = new ReportParameter[] { myReportParameter_Subhead };
            Form_Report myForm = new Form_Report();
            myForm.InitReport("ZCWelder.Reports.焊工考试班级统计汇总表.rdlc", myReportDataSourceRange, myReportParameterRange);
            myForm.ShowDialog();

        }

    }
}
