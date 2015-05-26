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
using ZCWelder.Person;
using ZCWelder.CrystalReports;
using ZCCL.Report;
using ZCExcel = Microsoft.Office.Interop.Excel;
using ZCWord = Microsoft.Office.Interop.Word;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WelderStudentQC_DataGridView : UserControl
    {
        private EventArgs_Issue myEventArgs_Issue;
        private DataTable myDataTable;
        private DataView myDataView;

        public UserControl_WelderStudentQC_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_Student_DataGridView_Load(object sender, EventArgs e)
        {
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
            Class_Data myClass_Data;
            if (this.myEventArgs_Issue.bool_GXTheory == false)
            {
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.WelderStudentQC.ToString(), false);
                myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderStudentQC.ToString()];

                //Class_Data myClass_Data_SubjectPositionResult = (Class_Data)Class_Public.myHashtable[Enum_DataTable.SubjectPositionResult.ToString()];
                //myClass_Data_SubjectPositionResult.SetFilter(string.Format("IssueNo='{0}'", e.str_IssueNo));
                //myClass_Data_SubjectPositionResult.RefreshData(false);
            }
            else
            {
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.GXTheoryWelderStudent.ToString(), false);
                myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.GXTheoryWelderStudent.ToString()];
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
                    this.myDataView.Sort = myClass_Data.myDataView.Sort;
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
                this.myDataView.Sort = myClass_Data.myDataView.Sort;
                this.dataGridView_Data.DataSource = this.myDataView;
            }
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            if (this.dataGridView_Data.RowCount == 0)
            {
                EventArgs_Student my_e = new EventArgs_Student(null, null, this.myEventArgs_Issue.bool_GXTheory);
                Publisher_Student.OnEventName(my_e);
            }
            this.label_Data.Text = string.Format("学员，({0})：", this.dataGridView_Data.RowCount);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            if (this.myEventArgs_Issue == null)
            {
                return;
            }
            this.myEventArgs_Issue.bool_JustFill = bool_JustFill;
            Publisher_Issue.OnEventName(this.myEventArgs_Issue);

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
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true); ;

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
            if (this.myEventArgs_Issue == null || string.IsNullOrEmpty(this.myEventArgs_Issue.str_IssueNo))
            {
                e.Cancel = true;
                return;
            }
            this.toolStripMenuItem_StudentAddBatch .Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !Class_Issue.CheckFinished(this.myEventArgs_Issue.str_IssueNo);
            this.toolStripMenuItem_StudentImportFromExcel .Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !Class_Issue.CheckFinished(this.myEventArgs_Issue.str_IssueNo);
            this.toolStripMenuItem_StudentQCImportFromExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !Class_Issue.CheckFinished(this.myEventArgs_Issue.str_IssueNo);
            this.toolStripMenuItem_DataGridViewAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !Class_Issue.CheckFinished(this.myEventArgs_Issue.str_IssueNo);
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
            //this.toolStripMenuItem_DataGridViewRowExport.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Print);
            this.toolStripMenuItem_RowModifyBatch.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowModifyResultBatch.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowQCAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowQCAddBatch.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowQCAddBatchbyCCSAccess.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowQCDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowQCModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowStudentAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowStudentDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowStudentImportFromExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowStudentModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowSubjectPositionResultCreateBatch.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowUpdateTheoryResult.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;
            this.toolStripMenuItem_RowQCOverdue .Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !bool_Finished;

            this.toolStripMenuItem_RowExportTestApply.Enabled = true ;
            this.toolStripMenuItem_RowExportWeldingPositionResult.Enabled = true;
            this.toolStripMenuItem_RowExportCrystalReport.Enabled = true;
            this.toolStripMenuItem_RowExportGXTrainRecord.Enabled = true;
            this.toolStripMenuItem_RowExportLRTrainRecord.Enabled = true;
            this.toolStripMenuItem_RowExportTheorySignUp.Enabled = true;
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
                this.toolStripMenuItem_RowExportTestApply.Enabled = false;
                this.toolStripMenuItem_RowExportWeldingPositionResult.Enabled = false;
                //this.toolStripMenuItem_RowExportCrystalReport.Enabled = false;
                this.toolStripMenuItem_RowExportGXTrainRecord.Enabled = false;
                this.toolStripMenuItem_RowExportLRTrainRecord.Enabled = false;
           }
            else
            {
                this.toolStripMenuItem_RowExportTheorySignUp.Enabled = false;
            }


        }

        private void toolStripMenuItem_RowStudentAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue == null)
            {
                return;
            }
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
                Form_GXTheoryStudent_Update myForm = new Form_GXTheoryStudent_Update();
                myForm.myClass_GXTheoryStudent = new Class_GXTheoryStudent();
                myForm.myClass_GXTheoryStudent.IssueNo = this.myEventArgs_Issue.str_IssueNo;
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(false );
                    Class_DataControlBind.SetDataGridViewSelectedPosition("ExaminingNo", myForm.myClass_GXTheoryStudent.ExaminingNo, this.dataGridView_Data);
                }
            }
            else
            {
                Form_Student_Update myForm = new Form_Student_Update();
                myForm.myClass_Student = new Class_Student();
                myForm.myClass_Student.IssueNo = this.myEventArgs_Issue.str_IssueNo;
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(false);
                    Class_DataControlBind.SetDataGridViewSelectedPosition("ExaminingNo", myForm.myClass_Student.ExaminingNo, this.dataGridView_Data);
                }
            }
        }

        private void toolStripMenuItem_RowQCAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
            }
            else
            {
                Form_QC_Update myForm = new Form_QC_Update();
                myForm.myClass_QC = new Class_QC();
                myForm.myClass_QC.ExaminingNo = this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString();
                myForm.bool_Add = true;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                    Class_DataControlBind.SetDataGridViewSelectedPosition("ExaminingNo", myForm.myClass_QC.ExaminingNo, this.dataGridView_Data);
                }
            }

        }

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            EventArgs_Student my_e = new EventArgs_Student(this.dataGridView_Data.Rows[e.RowIndex].Cells["ExaminingNo"].Value.ToString(), this.dataGridView_Data.Rows[e.RowIndex].Cells["IdentificationCard"].Value.ToString(), this.myEventArgs_Issue.bool_GXTheory);
            Publisher_Student.OnEventName(my_e);

        }

        private void toolStripMenuItem_RowStudentModify_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
                Form_GXTheoryStudent_Update myForm = new Form_GXTheoryStudent_Update();
                myForm.myClass_GXTheoryStudent = new Class_GXTheoryStudent();
                myForm.myClass_GXTheoryStudent.ExaminingNo = this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString();
                if (myForm.myClass_GXTheoryStudent.FillData())
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
                Form_Student_Update myForm = new Form_Student_Update();
                myForm.myClass_Student = new Class_Student();
                myForm.myClass_Student.ExaminingNo = this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString();
                if (myForm.myClass_Student.FillData())
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

        private void toolStripMenuItem_RowQCModify_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
            }
            else
            {
                Form_QC_Update myForm = new Form_QC_Update();
                myForm.myClass_QC = new Class_QC();
                myForm.myClass_QC.ExaminingNo = this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString();
                if (myForm.myClass_QC.FillData())
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

        private void toolStripMenuItem_RowStudentDelete_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
                if (Class_GXTheoryStudent.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_GXTheoryStudent.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
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
                if (Class_Student.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_Student.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除！");
                }
            }
        }

        private void toolStripMenuItem_RowQCDelete_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
            }
            else
            {
                if (Class_QC.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
                {
                    if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Class_QC.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                        this.RefreshData(false);
                    }
                }
                else
                {
                    MessageBox.Show("不能删除！");
                }
            }
        }

        private void toolStripMenuItem_RowUpdateTheoryResult_Click(object sender, EventArgs e)
        {
            Class_Issue.UpdateTheoryResult(this.myEventArgs_Issue.str_IssueNo);
            this.RefreshData(true);

        }

        private void toolStripMenuItem_RowSubjectPositionResultCreateBatchbyIssueNo_Click(object sender, EventArgs e)
        {
            if (Class_SubjectPositionResult.ExistSecond(this.myEventArgs_Issue.str_IssueNo, null))
            {
                if (MessageBox.Show("已存在本班级考试项目，如果重置可能会丢失部分数据！是否重置？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                }
                else
                {
                    return;
                }
            }
            Class_SubjectPositionResult.SubjectPositionResultCreateBatch(this.myEventArgs_Issue.str_IssueNo, null);
            EventArgs_Issue my_e = new EventArgs_Issue(this.myEventArgs_Issue.str_IssueNo, this.myEventArgs_Issue.bool_GXTheory);
            Publisher_Issue.OnEventName(my_e);

        }

        private void toolStripMenuItem_RowSubjectPositionResultCreateBatchbyExaminingNo_Click(object sender, EventArgs e)
        {
            string str_ExaminingNo=this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString();
            if (Class_SubjectPositionResult.ExistSecond( null, str_ExaminingNo))
            {
                if (MessageBox.Show("已存在本学员考试项目，如果重置可能会丢失部分数据！是否重置？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                }
                else
                {
                    return;
                }
            }
            Class_SubjectPositionResult.SubjectPositionResultCreateBatch(null, str_ExaminingNo);
            EventArgs_Issue my_e = new EventArgs_Issue(this.myEventArgs_Issue.str_IssueNo, this.myEventArgs_Issue.bool_GXTheory);
            Publisher_Issue.OnEventName(my_e);

        }

        private void toolStripMenuItem_RowViewExam_Click(object sender, EventArgs e)
        {
            StringBuilder str_Filter = new StringBuilder();
            str_Filter.Append("1=0");
            foreach (DataGridViewRow myDataGridViewRow in this.dataGridView_Data.Rows)
            {
                str_Filter.Append(string.Format(" Or IdentificationCard='{0}'", myDataGridViewRow.Cells["IdentificationCard"].Value));
            }
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ExamAll.ToString()];
            myClass_Data.SetFilter(str_Filter.ToString());
            myClass_Data.RefreshData(false);
            ZCCL.Tools.Form_DataView myForm = new ZCCL.Tools.Form_DataView();
            myForm.InitDataGridView("考试记录", new DataView(myClass_Data.myDataTable.Copy()), Enum_DataTable.WelderIssueStudentQCRegistrationNo.ToString());
            myForm.ShowDialog();

        }

        private void toolStripMenuItem_RowModifyBatch_Click(object sender, EventArgs e)
        {
            Form_Student_UpdateBatch myForm = new Form_Student_UpdateBatch();
            myForm.InitDataGridView(((DataView)this.dataGridView_Data.DataSource).Table, this.myEventArgs_Issue.bool_GXTheory, this.myEventArgs_Issue.str_IssueNo);
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
            }
        }

        private void dataGridView_Data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView_Data.Columns[e.ColumnIndex].Name == "TheoryResult" || this.dataGridView_Data.Columns[e.ColumnIndex].Name == "TheoryMakeupResult")
            {
                if (e.Value != DBNull.Value && (int)e.Value < (int)this.dataGridView_Data.Rows[e.RowIndex].Cells["PassScore"].Value)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            else if (this.dataGridView_Data.Columns[e.ColumnIndex].Name == "ExamStatus" )
            {
                if (e.Value.ToString()!="顺利考试" )
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void toolStripMenuItem_RowStudentAddBatch_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue == null)
            {
                return;
            }

            if (this.myEventArgs_Issue.bool_GXTheory)
            {
                Form_GXTheoryStudent_AddBatch myForm = new Form_GXTheoryStudent_AddBatch();
                myForm.str_IssueNo = this.myEventArgs_Issue.str_IssueNo;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                }
                if (myForm.bool_Updated)
                {
                    this.RefreshData(true);
                }
            }
            else
            {
                Form_Student_AddBatch myForm = new Form_Student_AddBatch();
                myForm.str_IssueNo = this.myEventArgs_Issue.str_IssueNo;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                }
                if (myForm.bool_Updated)
                {
                    this.RefreshData(true);
                }
            }
        }

        private void toolStripMenuItem_RowStudentImportFromExcel_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
            }
            else
            {
                DataTable myDataTable = Class_DataControlBind.ImportExcelToDataTable();
                if (myDataTable != null)
                {
                    Form_Student_ImportFromExcel myForm = new Form_Student_ImportFromExcel();
                    myForm.InitDataGridView(this.myEventArgs_Issue.str_IssueNo, myDataTable);
                    if (myForm.ShowDialog() == DialogResult.OK)
                    {
                        this.RefreshData(true);
                    }
                }
            }
        }

        private void toolStripMenuItem_RowQCAddBatch_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
            }
            else
            {
                Form_QC_AddBatch myForm = new Form_QC_AddBatch();
                myForm.InitDataGridView(((DataView)this.dataGridView_Data.DataSource).Table, this.myEventArgs_Issue.str_IssueNo);
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
        }

        private void toolStripMenuItem_RowExportCrystalReport_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
                Form_ReportSelect myForm = new Form_ReportSelect();
                myForm.myClass_Report = new Class_Report();
                myForm.myClass_Report.ReportGroup = "理论学员";
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    Form_CrystalReport myForm_Report = new Form_CrystalReport();
                    System.Collections.ArrayList myArrayList = new System.Collections.ArrayList();
                    myArrayList.Add(this.myEventArgs_Issue.str_IssueNo);
                    string str_FileName = string.Format("{0}\\CrystalReports\\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), myForm.myClass_Report.ReportLocation);
                    myForm_Report.InitCrystalReport(str_FileName, "IssueNo", myArrayList, null, myForm.str_Subhead);
                    myForm_Report.ShowDialog();
                }
            }
            else
            {
                Form_ReportSelect myForm = new Form_ReportSelect();
                myForm.myClass_Report = new Class_Report();
                myForm.myClass_Report.ReportGroup = "学员";
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    Form_CrystalReport myForm_Report = new Form_CrystalReport();
                    System.Collections.ArrayList myArrayList = new System.Collections.ArrayList();
                    myArrayList.Add(this.myEventArgs_Issue.str_IssueNo);
                    string str_FileName = string.Format("{0}\\CrystalReports\\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), myForm.myClass_Report.ReportLocation);
                    if(myForm.myClass_Report.ReportPaperSize =="PaperFanfoldUS")
                    {
                        myForm_Report.myPaperSize = CrystalDecisions.Shared.PaperSize.PaperFanfoldUS;
                    }
                    myForm_Report.InitCrystalReport(str_FileName, "IssueNo", myArrayList, null, myForm.str_Subhead);
                    myForm_Report.ShowDialog();
                }
            }

        }

        private void toolStripMenuItem_RowExportBendTestApply_JN_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp;
            myDataView_Temp = new DataView(Class_Issue.GetDataTable_SubjectPositionResult(this.myEventArgs_Issue.str_IssueNo, null, null));
            Class_SubjectPositionResult.ExportBendTestApply_JN(myDataView_Temp);
        }

        private void toolStripMenuItem_RowExportBendTestApply_AN_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp;
            myDataView_Temp = new DataView(Class_Issue.GetDataTable_SubjectPositionResult(this.myEventArgs_Issue.str_IssueNo, null, null));
            Class_SubjectPositionResult.ExportBendTestApply_AN(myDataView_Temp);
        }

        private void toolStripMenuItem_RowExportRTTestApply_JN_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp;
            myDataView_Temp = new DataView(Class_Issue.GetDataTable_SubjectPositionResult(this.myEventArgs_Issue.str_IssueNo, null, null));
            Class_SubjectPositionResult.ExportRTTestApply_JN (myDataView_Temp);

        }

        private void toolStripMenuItem_RowExportTheoryResult_Click(object sender, EventArgs e)
        {
            Class_CustomUser myClass_CustomUser;
            string str_ShipClassificationAb;
            if (myEventArgs_Issue.bool_GXTheory)
            {
                Class_GXTheoryIssue myClass_GXTheoryIssue = new Class_GXTheoryIssue(this.myEventArgs_Issue.str_IssueNo);
                myClass_CustomUser = new Class_CustomUser(myClass_GXTheoryIssue.TheoryTeacherID);
                str_ShipClassificationAb = myClass_GXTheoryIssue.ShipboardNo;

            }
            else
            {
                Class_Issue myClass_Issue = new Class_Issue(this.myEventArgs_Issue.str_IssueNo);
                myClass_CustomUser = new Class_CustomUser(myClass_Issue.TheoryTeacherID);
                str_ShipClassificationAb = myClass_Issue.ShipClassificationAb;
            }

            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;
            int int_Index = 1;
            myExcelSheet.Name = this.myEventArgs_Issue.str_IssueNo;
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("B1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("C1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("D1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("E1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("F1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).RowHeight = 60;
            myExcelSheet.Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myExcelSheet.get_Range("A1", "F1").HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myExcelSheet.get_Range("A1", "F1").VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myExcelSheet.get_Range("A1", "F1").Merge(System.Reflection.Missing.Value);
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Font.Name = "黑体";
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Font.Size = 22;
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Value2 = str_ShipClassificationAb + "(" + myEventArgs_Issue.str_IssueNo + ")\n焊工理论培训人员成绩表";
            int_Index = 2;
            myExcelSheet.get_Range("A" + int_Index, "F" + int_Index).Font.Name = "黑体";
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "序号";
            myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = "部门";
            myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "姓名";
            myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = "性别";
            myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = "工号";
            myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = "成绩";
            foreach (DataGridViewRow myDataGridViewRow in this.dataGridView_Data.Rows)
            {
                int_Index++;
                myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = int_Index - 2;
                myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = myDataGridViewRow.Cells["WelderDepartment"].Value;
                myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = myDataGridViewRow.Cells["WelderName"].Value;
                myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = myDataGridViewRow.Cells["Sex"].Value;
                myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = myDataGridViewRow.Cells["WelderWorkerID"].Value;
                if (myDataGridViewRow.Cells["TheoryResult"].Value == DBNull.Value)
                {
                    myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = "缺席";
                }
                else
                {
                    myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = myDataGridViewRow.Cells["TheoryResult"].Value;
                    if ((int)myDataGridViewRow.Cells["TheoryResult"].Value < 60)
                        if (myDataGridViewRow.Cells["TheoryMakeupResult"].Value == DBNull.Value)
                        {
                            myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = myDataGridViewRow.Cells["TheoryResult"].Value;
                        }
                        else
                        {
                            myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = myDataGridViewRow.Cells["TheoryResult"].Value.ToString() + "/" + myDataGridViewRow.Cells["TheoryMakeupResult"].Value.ToString();
                        }
                    else
                    {
                        myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = myDataGridViewRow.Cells["TheoryResult"].Value;
                    }
                }
            }
            myRange = myExcelSheet.get_Range("A2", "F" + int_Index.ToString());
            myRange.RowHeight = 20;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            if (int_Index > 2)
            {
                myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            }
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            int_Index++;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).RowHeight = 20;
            myRange = myExcelSheet.get_Range("E" + int_Index, "F" + int_Index);
            myRange.Merge(System.Reflection.Missing.Value);
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignBottom;
            myRange.MergeCells = true;
            myRange.Value2 = "理论教师：" + myClass_CustomUser.Name;
            int_Index = int_Index + 2;
            myRange = myExcelSheet.get_Range("A" + int_Index, "F" + int_Index);
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value);
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
            myRange.Value2 = "江南造船焊工考试委员会";
            int_Index = int_Index + 1;
            myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = DateTime.Today.ToShortDateString();
            myExcelApp.Application.Visible = true;
        }

        private void toolStripMenuItem_RowExportWeldingPositionResult_Click(object sender, EventArgs e)
        {
            string str_ExaminingNo = "";
            DataView myDataView_Temp;
            myDataView_Temp = new DataView(Class_Issue.GetDataTable_SubjectPositionResult(this.myEventArgs_Issue.str_IssueNo, null, null));
            myDataView_Temp.RowFilter = "FaceDT=1 Or MakeupFaceDT=1";
            myDataView_Temp.Sort = "ExaminingNo";
            if (myDataView_Temp.Count == 0)
            {
                MessageBox.Show("没有名单！");
                return;
            }
            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;

            myExcelSheet.Name = this.myEventArgs_Issue.str_IssueNo;
            Class_Issue myClass_Issue = new Class_Issue(this.myEventArgs_Issue.str_IssueNo);
            Class_Employer myClass_Employer = new Class_Employer(myClass_Issue.EmployerHPID);

            int int_Index;
            myExcelSheet.Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange = myExcelSheet.get_Range("A1", "H1");
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange.Font.Name = "黑体";
            myRange.Font.Size = 22;
            myRange.Value2 = this.myEventArgs_Issue.str_IssueNo + "期外观合格焊工试板名单\n(" + myClass_Employer.ShortenedEmployer + ")";
            int_Index = 2;
            myRange = myExcelSheet.get_Range("A2", "B2");
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("C2", "D2");
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("E2", "F2");
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("G2", "H2");
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("A3", "B3");
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("C3", "D3");
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("E3", "F3");
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("G3", "H3");
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);

            myExcelSheet.get_Range("A2", System.Reflection.Missing.Value).Value2 = "理论考试日期";
            if (myClass_Issue.TheoryExamDate > DateTime.MinValue)
            {
                myExcelSheet.get_Range("C2", System.Reflection.Missing.Value).Value2 = myClass_Issue.TheoryExamDate.ToShortDateString();
            }
            myExcelSheet.get_Range("E2", System.Reflection.Missing.Value).Value2 = "技能考试日期";
            if (myClass_Issue.SkillExamDate > DateTime.MinValue)
            {
                myExcelSheet.get_Range("G2", System.Reflection.Missing.Value).Value2 = myClass_Issue.SkillExamDate.ToShortDateString();
            }
            myExcelSheet.get_Range("A3", System.Reflection.Missing.Value).Value2 = "理论补考日期";
            if (myClass_Issue.TheoryMakeupDate > DateTime.MinValue)
            {
                myExcelSheet.get_Range("C3", System.Reflection.Missing.Value).Value2 = myClass_Issue.TheoryMakeupDate.ToShortDateString();
            }
            myExcelSheet.get_Range("E3", System.Reflection.Missing.Value).Value2 = "技能补考日期";
            if (myClass_Issue.SkillMakeupDate > DateTime.MinValue)
            {
                myExcelSheet.get_Range("G3", System.Reflection.Missing.Value).Value2 = myClass_Issue.SkillMakeupDate.ToShortDateString();
            }
            
            int_Index = 4;
            myExcelSheet.get_Range("A4", "H4").Font.Name = "黑体";

            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "序号";
            myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = "试板编号";
            myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "姓名";
            myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = "理论\n成绩";
            myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = "理补\n成绩";
            myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = "技能\n成绩";
            myExcelSheet.get_Range("G" + int_Index, System.Reflection.Missing.Value).Value2 = "技补\n成绩";
            myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = "考试\n类别";
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("B1", System.Reflection.Missing.Value).ColumnWidth = 13;
            myExcelSheet.get_Range("C1", System.Reflection.Missing.Value).ColumnWidth = 9;
            myExcelSheet.get_Range("D1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("E1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("F1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("G1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("H1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).RowHeight = 60;
            myExcelSheet.get_Range("A3", System.Reflection.Missing.Value).RowHeight = 30;
            myExcelSheet.get_Range("A4", System.Reflection.Missing.Value).RowHeight = 30;

            //myDataView_Temp.RowFilter = "ExamSubjectID is Not Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            myDataView_Temp.RowFilter = "FaceDT = true or MakeupFaceDT = true";
      
            foreach (DataRowView myDataRowView in myDataView_Temp)
            {
                int_Index++;
                if (str_ExaminingNo != myDataRowView["ExaminingNo"].ToString())
                {
                    myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WelderName"];
                    if (myDataRowView["TheoryResult"] != DBNull.Value && (int)myDataRowView["TheoryResult"] >= (int)myDataRowView["PassScore"])
                    {
                        myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["TheoryResult"];
                    }
                    else
                    {
                        if (myDataRowView["TheoryMakeupResult"] != DBNull.Value && (int)myDataRowView["TheoryMakeupResult"] >= (int)myDataRowView["PassScore"])
                        {
                            myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["TheoryMakeupResult"];
                        }
                        else
                        {
                            myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["StudentKindofExam"];
                        }
                        myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WeldingClass"];
                    }
                }
                str_ExaminingNo = myDataRowView["ExaminingNo"].ToString();
                myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = int_Index - 4;
                myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = str_ExaminingNo + "-" + myDataRowView["WeldingPosition"].ToString();
                if ((bool)myDataRowView["FaceDT"])
                {
                    myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = "合格";
                }
                if ((bool)myDataRowView["MakeupFaceDT"])
                {
                    myExcelSheet.get_Range("G" + int_Index, System.Reflection.Missing.Value).Value2 = "合格";
                }               
            }
            myRange = myExcelSheet.get_Range("A4", "H" + int_Index);
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            if (int_Index > 4)
            {
                myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            }
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            int_Index++;
            myRange = myExcelSheet.get_Range("A" + int_Index, "H" + int_Index);
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignBottom;
            myRange.MergeCells = true;
            myRange = myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value);
            myRange.RowHeight = 50;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = Properties.Settings.Default.Company + "\n" + DateTime.Today.ToShortDateString();
            myExcelApp.Visible = true;
        }

        private void toolStripMenuItem_RowExportTheorySignUp_Click(object sender, EventArgs e)
        {
            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;
            int int_Index = 1;
            myExcelSheet.Name = this.myEventArgs_Issue.str_IssueNo;
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).ColumnWidth = 5;
            myExcelSheet.get_Range("B1", System.Reflection.Missing.Value).ColumnWidth = 9;
            myExcelSheet.get_Range("C1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("D1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("E1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("F1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("G1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("H1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("I1", System.Reflection.Missing.Value).ColumnWidth = 7;
            myExcelSheet.get_Range("J1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).RowHeight = 60;
            myExcelSheet.Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange = myExcelSheet.get_Range("A1", "J1");
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("A1", "J1");

            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Font.Size = 22;
            Class_GXTheoryIssue myClass_GXTheoryIssue = new Class_GXTheoryIssue(this.myEventArgs_Issue.str_IssueNo);
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Value2 = myClass_GXTheoryIssue.ShipboardNo + "(" + myClass_GXTheoryIssue.IssueNo + ")\n焊工理论培训人员签到表";
            int_Index = 2;

            myRange = myExcelSheet.get_Range("A2", "A3");
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignCenter;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("B2", "B3");

            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignCenter;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("C2", "C3");
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignCenter;
            myRange.Merge(System.Reflection.Missing.Value);

            myRange = myExcelSheet.get_Range("D2", "E2");
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignCenter;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("F2", "G2");
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignCenter;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("H2", "I2");
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignCenter;
            myRange.Merge(System.Reflection.Missing.Value);
            myRange = myExcelSheet.get_Range("J2", "J3");
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignCenter;
            myRange.Merge(System.Reflection.Missing.Value);

            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "序号";
            myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = "部门";
            myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "姓名";
            if (myClass_GXTheoryIssue.DateBeginningofTrain > DateTime.MinValue)
            {
                myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = myClass_GXTheoryIssue.DateBeginningofTrain.ToString("M月d日");
                myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = myClass_GXTheoryIssue.DateBeginningofTrain.AddDays(1).ToString("M月d日");
                myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = myClass_GXTheoryIssue.DateBeginningofTrain.AddDays(2).ToString("M月d日");
            }
            myExcelSheet.get_Range("D" + (int_Index + 1), System.Reflection.Missing.Value).Value2 = "上午";
            myExcelSheet.get_Range("E" + (int_Index + 1), System.Reflection.Missing.Value).Value2 = "下午";
            myExcelSheet.get_Range("F" + (int_Index + 1), System.Reflection.Missing.Value).Value2 = "上午";
            myExcelSheet.get_Range("G" + (int_Index + 1), System.Reflection.Missing.Value).Value2 = "下午";
            myExcelSheet.get_Range("H" + (int_Index + 1), System.Reflection.Missing.Value).Value2= "上午";
            myExcelSheet.get_Range("I" + (int_Index + 1), System.Reflection.Missing.Value).Value2 = "下午";

            myExcelSheet.get_Range("J" + int_Index, System.Reflection.Missing.Value).Value2 = "教材编号";
            int_Index = 3;
            foreach (DataGridViewRow myDataGridViewRow in this.dataGridView_Data.Rows)
            {
                int_Index++;
                myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = int_Index - 3;
                myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = myDataGridViewRow.Cells["WelderDepartment"].Value ;
                myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = myDataGridViewRow.Cells["WelderName"].Value;
            }

            myRange = myExcelSheet.get_Range("A2", "J" + int_Index);
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            if (int_Index > 2)
            {
                myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            }
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            int_Index++;
            myRange = myExcelSheet.get_Range("H" + int_Index, "J" + int_Index);
            myRange.Merge(System.Reflection.Missing.Value);
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignBottom;
            myRange.MergeCells = true;
            if (myClass_GXTheoryIssue.TheoryTeacherID != null)
            {
                Class_CustomUser myClass_CustomUser = new Class_CustomUser(myClass_GXTheoryIssue.TheoryTeacherID);
                myRange.Value2 = "理论教师：" + myClass_CustomUser.Name;
            }
            else
            {
                myRange.Value2 = "理论教师：";
            }
            int_Index = int_Index + 2;
            myRange = myExcelSheet.get_Range("A" + int_Index, "J" + int_Index);
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);

            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "江南造船焊工考试委员会";
            int_Index = int_Index + 1;
            myExcelSheet.get_Range("J" + int_Index, System.Reflection.Missing.Value).Value2 = DateTime.Today.ToShortDateString();
            myExcelSheet.get_Range("A2", "A" + int_Index).RowHeight = 20;

            myExcelSheet.Application.Visible = true;
        }

        private void toolStripMenuItem_RowExportGXTrainRecord_Click(object sender, EventArgs e)
        {
            DataView myDataView_GXSkillStudents = new DataView(this.myDataTable);
            myDataView_GXSkillStudents.Sort = "ExaminingNo";
            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\GX焊工培训记录.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_Range;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            Class_Issue myClass_Issue = new Class_Issue(this.myEventArgs_Issue.str_IssueNo);
            str_BookmarkName = "str_ShipboardNo";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = myClass_Issue.ShipboardNo;
            myRange.Select();
            object_Range = myWordDocument.Application.Selection.Range;
            myWordDocument.Bookmarks.Add("str_ShipboardNo", ref object_Range);
            str_BookmarkName = "str_ShipboardNoSecond";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = myClass_Issue.ShipboardNo;
            myRange.Select();
            object_Range = myWordDocument.Application.Selection.Range;
            myWordDocument.Bookmarks.Add("str_ShipboardNoSecond", ref object_Range);
            str_BookmarkName = "str_SkillIssueNo";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = myClass_Issue.IssueNo;
            myRange.Select();
            object_Range = myWordDocument.Application.Selection.Range;
            myWordDocument.Bookmarks.Add("str_SkillIssueNo", ref object_Range);
            myWordDocument.Tables[2].Cell(1, 2).Range.Text = myClass_Issue.IssueNo;
            if (myClass_Issue.DateBeginningofTrain > DateTime.MinValue && myClass_Issue.DateEndingofTrain > DateTime.MinValue)
            {
                myWordDocument.Tables[2].Cell(1, 4).Range.Text = myClass_Issue.DateBeginningofTrain.ToString("M.dd") + "-" + myClass_Issue.DateEndingofTrain .ToString("M.dd");
            }
            else
            {
                myWordDocument.Tables[2].Cell(1, 4).Range.Text = "";
            }
            myWordDocument.Tables[2].Cell(2, 2).Range.Text = myClass_Issue.WeldingProcessAb;
            myWordDocument.Tables[2].Cell(2, 4).Range.Text = myDataView_GXSkillStudents.Count.ToString();
            int i;
            string str_SQLSubjectPiece;
            str_SQLSubjectPiece = "SELECT DISTINCT WeldingPosition, WeldingPositionContent FROM dbo.View_Exam_SubjectPositionResult";
            str_SQLSubjectPiece += " Where IssueNo='" + myClass_Issue.IssueNo + "'";
            i = 5;
            DataTable myDataTable = Class_zwjPublic.myClass_SqlConnection.GetDataTable(str_SQLSubjectPiece);
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                myWordDocument.Tables[2].Cell(i, 1).Range.Text = (i - 4).ToString();
                myWordDocument.Tables[2].Cell(i, 2).Range.Text = myDataRow["WeldingPositionContent"].ToString();
                myWordDocument.Tables[2].Cell(i, 3).Range.Text = myDataRow["WeldingPosition"].ToString();
                i++;
            }
            int j;
            i = 1;
            j = 0;
            foreach (DataRowView myDataRowView in myDataView_GXSkillStudents)
            {
                if (j == 15)
                {
                    str_BookmarkName = "first";
                    Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                    str_BookmarkName = "last";
                    Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                    myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                    myRange.Copy();
                    myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                    myWordDocument.Application.Selection.Paste();
                    j = 0;
                }
                myWordDocument.Tables[1].Cell(3 + j, 1).Range.Text = i.ToString();
                myWordDocument.Tables[1].Cell(3 + j, 2).Range.Text = myDataRowView["ExaminingNo"].ToString();
                myWordDocument.Tables[1].Cell(3 + j, 3).Range.Text = myDataRowView["WelderName"].ToString();
                j++;
                i++;
            }
            for (i = j; i < 15; i++)
            {
                myWordDocument.Tables[1].Cell(3 + i, 1).Range.Text = "";
                myWordDocument.Tables[1].Cell(3 + i, 2).Range.Text = "";
                myWordDocument.Tables[1].Cell(3 + i, 3).Range.Text = "";
            }
            str_BookmarkName = "first";
            Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            str_BookmarkName = "last";
            Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            myRange.Copy();
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordDocument.Application.Selection.Paste();

            str_BookmarkName = "first";
            Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            str_BookmarkName = "last";
            Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            myRange.Delete(ref oMissing, ref oMissing);

            object object_Count = 1;
            object object_wdCharacter = ZCWord.WdUnits.wdCharacter;
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.Delete(ref object_wdCharacter, ref object_Count);
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;


        }

        private void toolStripMenuItem_RowModifyResultBatch_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
                Form_Student_UpdateResultBatch myForm = new Form_Student_UpdateResultBatch();
                myForm.InitDataGridView(this.myEventArgs_Issue.str_IssueNo, true  );
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    Publisher_Issue.OnEventName(this.myEventArgs_Issue);
                }
            }
            else
            {
                Form_Student_UpdateResultBatch myForm = new Form_Student_UpdateResultBatch();
                myForm.InitDataGridView(this.myEventArgs_Issue.str_IssueNo, false );
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    Publisher_Issue.OnEventName(this.myEventArgs_Issue);
                }
            }
        }

        private void toolStripMenuItem_RowExportByChecked_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue .bool_GXTheory)
            {

            }
            else
            {
                Form_SubjectPositionResult_UpdateBatch myForm = new Form_SubjectPositionResult_UpdateBatch();
                myForm.InitDataGridView(Class_Issue.GetDataTable_SubjectPositionResult(this.myEventArgs_Issue.str_IssueNo,null,"ExaminingNo, WeldingPosition"), false, this.myEventArgs_Issue.str_IssueNo );
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                }
           }

        }

        private void toolStripMenuItem_RowQCAddBatchbyCCSAccess_Click(object sender, EventArgs e)
        {
            Form_QC_AddBatchbyCCSAccess myForm = new Form_QC_AddBatchbyCCSAccess();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
            }
        }

        private void toolStripMenuItem_RowExportWelderPicture_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp = new DataView(this.myDataTable);
            myDataView_Temp.Sort = "ExaminingNo";
            Class_Welder.ExportWelderPictureToWord(myDataView_Temp);
       }

        private void ToolStripMenuItem_RowExportExcelofExamNeed_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue != null && this.myEventArgs_Issue.bool_GXTheory == false)
            {
                DataView myDataView_Temp = new DataView(((DataView)this.dataGridView_Data.DataSource ).ToTable());
                Class_Issue.ExportSkillExamNeed(myDataView_Temp);
            }

        }

        private void toolStripMenuItem_RowQCOverdue_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
            }
            else
            {

                if (MessageBox.Show("确认用该条焊工证书记录进行原有证书覆盖操作吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_QC.Overdue(this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString());
                }
            }
        }

        private void toolStripMenuItem_RowModifyWelder_Click(object sender, EventArgs e)
        {
            Form_Welder_Update myForm = new Form_Welder_Update();
            myForm.myClass_Welder = new Class_Welder();
            myForm.myClass_Welder.IdentificationCard = this.dataGridView_Data.CurrentRow.Cells["IdentificationCard"].Value.ToString();
            if (myForm.myClass_Welder.FillData())
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

        private void toolStripMenuItem_RowExportWelderPictureExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.ExportExcelFromDataTable(Class_Welder.DetectWelderPictureisValid(this.myDataView.ToTable()), true, false);

        }

        private void toolStripMenuItem_RowExportMTTestApply_JN_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp;
            myDataView_Temp = new DataView(Class_Issue.GetDataTable_SubjectPositionResult(this.myEventArgs_Issue.str_IssueNo, null, null));
            Class_SubjectPositionResult.ExportMTTestApply_JN(myDataView_Temp);

        }

        private void toolStripMenuItem_RowExportLRTrainRecord_Click(object sender, EventArgs e)
        {
            DataView myDataView_GXSkillStudents = new DataView(this.myDataTable);
            myDataView_GXSkillStudents.Sort = "ExaminingNo";
            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\GX焊工培训记录.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_Range;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            Class_Issue myClass_Issue = new Class_Issue(this.myEventArgs_Issue.str_IssueNo);
            str_BookmarkName = "str_ShipboardNo";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = myClass_Issue.ShipboardNo;
            myRange.Select();
            object_Range = myWordDocument.Application.Selection.Range;
            myWordDocument.Bookmarks.Add("str_ShipboardNo", ref object_Range);
            str_BookmarkName = "str_ShipboardNoSecond";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = myClass_Issue.ShipboardNo;
            myRange.Select();
            object_Range = myWordDocument.Application.Selection.Range;
            myWordDocument.Bookmarks.Add("str_ShipboardNoSecond", ref object_Range);
            str_BookmarkName = "str_SkillIssueNo";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = myClass_Issue.IssueNo;
            myRange.Select();
            object_Range = myWordDocument.Application.Selection.Range;
            myWordDocument.Bookmarks.Add("str_SkillIssueNo", ref object_Range);
            myWordDocument.Tables[2].Cell(1, 2).Range.Text = myClass_Issue.IssueNo;
            if (myClass_Issue.DateBeginningofTrain > DateTime.MinValue && myClass_Issue.DateEndingofTrain > DateTime.MinValue)
            {
                myWordDocument.Tables[2].Cell(1, 4).Range.Text = myClass_Issue.DateBeginningofTrain.ToString("M.dd") + "-" + myClass_Issue.DateEndingofTrain.ToString("M.dd");
            }
            else
            {
                myWordDocument.Tables[2].Cell(1, 4).Range.Text = "";
            }
            myWordDocument.Tables[2].Cell(2, 2).Range.Text = myClass_Issue.WeldingProcessAb;
            myWordDocument.Tables[2].Cell(2, 4).Range.Text = myDataView_GXSkillStudents.Count.ToString();
            int i;
            string str_SQLSubjectPiece;
            str_SQLSubjectPiece = "SELECT DISTINCT WeldingPosition, WeldingPositionContent FROM dbo.View_Exam_SubjectPositionResult";
            str_SQLSubjectPiece += " Where IssueNo='" + myClass_Issue.IssueNo + "'";
            i = 5;
            DataTable myDataTable = Class_zwjPublic.myClass_SqlConnection.GetDataTable(str_SQLSubjectPiece);
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                myWordDocument.Tables[2].Cell(i, 1).Range.Text = (i - 4).ToString();
                myWordDocument.Tables[2].Cell(i, 2).Range.Text = myDataRow["WeldingPositionContent"].ToString();
                myWordDocument.Tables[2].Cell(i, 3).Range.Text = myDataRow["WeldingPosition"].ToString();
                i++;
            }
            int j;
            i = 1;
            j = 0;
            foreach (DataRowView myDataRowView in myDataView_GXSkillStudents)
            {
                if (j == 15)
                {
                    str_BookmarkName = "first";
                    Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                    str_BookmarkName = "last";
                    Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                    myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                    myRange.Copy();
                    myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                    myWordDocument.Application.Selection.Paste();
                    j = 0;
                }
                myWordDocument.Tables[1].Cell(3 + j, 1).Range.Text = i.ToString();
                myWordDocument.Tables[1].Cell(3 + j, 2).Range.Text = myDataRowView["ExaminingNo"].ToString();
                myWordDocument.Tables[1].Cell(3 + j, 3).Range.Text = myDataRowView["WelderName"].ToString();
                myWordDocument.Tables[1].Cell(3 + j, 6).Range.Text = myDataRowView["Subject"].ToString();
                j++;
                i++;
            }
            for (i = j; i < 15; i++)
            {
                myWordDocument.Tables[1].Cell(3 + i, 1).Range.Text = "";
                myWordDocument.Tables[1].Cell(3 + i, 2).Range.Text = "";
                myWordDocument.Tables[1].Cell(3 + i, 3).Range.Text = "";
                myWordDocument.Tables[1].Cell(3 + i, 6).Range.Text = "";
           }
            str_BookmarkName = "first";
            Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            str_BookmarkName = "last";
            Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            myRange.Copy();
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordDocument.Application.Selection.Paste();

            str_BookmarkName = "first";
            Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            str_BookmarkName = "last";
            Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            myRange.Delete(ref oMissing, ref oMissing);

            object object_Count = 1;
            object object_wdCharacter = ZCWord.WdUnits.wdCharacter;
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.Delete(ref object_wdCharacter, ref object_Count);
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;
        }

        private void toolStripMenuItem_RowStudentQCImportFromExcel_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue.bool_GXTheory)
            {
            }
            else
            {
                DataTable myDataTable = Class_DataControlBind.ImportExcelToDataTable();
                if (myDataTable != null)
                {
                    Form_StudentQC_ImportFromExcel myForm = new Form_StudentQC_ImportFromExcel();
                    myForm.InitDataGridView(this.myEventArgs_Issue.str_IssueNo, myDataTable);
                    if (myForm.ShowDialog() == DialogResult.OK)
                    {
                        this.RefreshData(true);
                    }
                }
            }

        }

        private void toolStripMenuItem_RowRegistrationNoImportFromExcel_Click(object sender, EventArgs e)
        {
            DataTable myDataTable_Temp = Class_DataControlBind.ImportExcelToDataTable();
            if (myDataTable_Temp != null)
            {
                bool bool_ExistTestCommitteeID;
                if (!myDataTable_Temp.Columns.Contains("IdentificationCard"))
                {
                    MessageBox.Show("数据表中不存在 'IdentificationCard' 列！");
                    return ;
                }
                else if (!myDataTable_Temp.Columns.Contains("RegistrationNo"))
                {
                    MessageBox.Show("数据表中不存在 'RegistrationNo' 列！");
                    return;
                }
                bool_ExistTestCommitteeID = myDataTable_Temp.Columns.Contains("TestCommitteeID");
                Class_TestCommittee myClass_TestCommittee=null;
                if (!bool_ExistTestCommitteeID)
                {
                    myClass_TestCommittee=new Class_TestCommittee(Properties.Settings.Default.CCSTestCommitteeID);
                }
                Class_TestCommitteeRegistrationNo myClass_TestCommitteeRegistrationNo = new Class_TestCommitteeRegistrationNo();
                int i_success_add = 0;
                int i_erroneous = 0;
                int i_success_modify = 0;
                int i_exist = 0;
                foreach (DataRow myDataRow in myDataTable_Temp.Select("len(IdentificationCard)=18"))
                {
                    myClass_TestCommitteeRegistrationNo.IdentificationCard = myDataRow["IdentificationCard"].ToString();
                    myClass_TestCommitteeRegistrationNo.RegistrationNo = myDataRow["RegistrationNo"].ToString();
                   
                    if (!Class_Welder.ExistAndCanDeleteAndDelete(myClass_TestCommitteeRegistrationNo.IdentificationCard, Enum_zwjKindofUpdate.Exist))
                    {
                        i_exist ++;
                        continue;
                    }
                    
                    if (bool_ExistTestCommitteeID)
                    {
                        if (Class_TestCommittee.ExistAndCanDeleteAndDelete(myDataRow["TestCommitteeID"].ToString(), Enum_zwjKindofUpdate.Exist))
                        {
                            myClass_TestCommitteeRegistrationNo.TestCommitteeID = myDataRow["TestCommitteeID"].ToString();
                            myClass_TestCommittee = new Class_TestCommittee(myClass_TestCommitteeRegistrationNo.TestCommitteeID);
                        }
                        else
                        {
                            i_erroneous++;
                            continue;
                        }
                    }
                    else
                    {
                        myClass_TestCommitteeRegistrationNo.TestCommitteeID = Properties.Settings.Default.CCSTestCommitteeID;
                    }

                    if (myClass_TestCommittee != null)
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(myClass_TestCommitteeRegistrationNo.RegistrationNo, myClass_TestCommittee.RegistrationNoRegex))
                        {
                            i_erroneous++;
                            continue;
                        }
                    }
                    else
                    {
                        i_erroneous++;
                        continue;
                    }

                    if (!Class_TestCommitteeRegistrationNo.ExistAndCanDeleteAndDelete(myClass_TestCommitteeRegistrationNo.TestCommitteeID, myClass_TestCommitteeRegistrationNo.RegistrationNo, Enum_zwjKindofUpdate.Exist))
                    {
                        if (Class_TestCommitteeRegistrationNo.ExistSecond(myClass_TestCommitteeRegistrationNo.TestCommitteeID, myClass_TestCommitteeRegistrationNo.IdentificationCard, Enum_zwjKindofUpdate.Exist))
                        {
                            string str_SQL = "UPDATE Person_TestCommitteeRegistrationNo SET RegistrationNo = @RegistrationNo WHERE TestCommitteeID=@TestCommitteeID and IdentificationCard=@IdentificationCard";
                            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                            myCmd_Temp.Parameters.Add("@RegistrationNo", SqlDbType.NVarChar, 20).Value = myClass_TestCommitteeRegistrationNo.RegistrationNo;
                            myCmd_Temp.Parameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = myClass_TestCommitteeRegistrationNo.TestCommitteeID;
                            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = myClass_TestCommitteeRegistrationNo.IdentificationCard;
                            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
                            myCmd_Temp.ExecuteNonQuery();
                            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                            i_success_modify++;
                        }
                        else
                        {
                            string str_SQL = "INSERT INTO Person_TestCommitteeRegistrationNo (TestCommitteeID,RegistrationNo ,IdentificationCard) VALUES (@TestCommitteeID ,@RegistrationNo  ,@IdentificationCard) ";
                            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                            myCmd_Temp.Parameters.Add("@RegistrationNo", SqlDbType.NVarChar, 20).Value = myClass_TestCommitteeRegistrationNo.RegistrationNo;
                            myCmd_Temp.Parameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = myClass_TestCommitteeRegistrationNo.TestCommitteeID;
                            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = myClass_TestCommitteeRegistrationNo.IdentificationCard;
                            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
                            myCmd_Temp.ExecuteNonQuery();
                            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                            i_success_add++;
                        }
                    }
                    else
                    {
                        i_exist++;
                    }
                }
                MessageBox.Show(string.Format("导入完毕！其中新添加{0}条，修改{1}条，系统已存在{2}条，失败{3}条，失败条目只统计身份证号码为18位的数据！",i_success_add,i_success_modify,i_exist ,i_erroneous ));
            }
        }

    }
}
