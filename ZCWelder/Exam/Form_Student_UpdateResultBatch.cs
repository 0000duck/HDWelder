using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using System.Data.SqlClient;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery;
using ZCCL.UpdateLog;

namespace ZCWelder.Exam
{
    public partial class Form_Student_UpdateResultBatch : Form
    {
        private bool bool_GXTheory;
        private string str_IssueNo;
        private DataTable myDataTable_WelderStudentQC;
        private DataTable myDataTable_SubjectPositionResult;

        public Form_Student_UpdateResultBatch()
        {
            InitializeComponent();
        }

        private void Form_Student_UpdateResultBatch_Load(object sender, EventArgs e)
        {
            for (int i = this.tabControl_SubjectPositionResult .TabCount - 1; i >= 0; i--)
            {
                this.tabControl_SubjectPositionResult.SelectedIndex = i;
            }

        }

        public void InitDataGridView(string str_IssueNo, bool bool_GXTheory)
        {
            this.str_IssueNo = str_IssueNo;
            this.bool_GXTheory = bool_GXTheory;
            this.Text = string.Format("批量输入成绩 - {0}", this.str_IssueNo);
            if (this.bool_GXTheory)
            {
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.GXTheoryWelderStudent.ToString(), false);
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_SubjectPositionResult, Enum_DataTable.SubjectPositionResult.ToString(), false);
                this.myDataTable_WelderStudentQC = Class_GXTheoryIssue.GetDataTable_WelderStudent  (str_IssueNo, null, "ExaminingNo");
                this.dataGridView_Data.DataSource = new DataView(this.myDataTable_WelderStudentQC);
            }
            else
            {
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.WelderStudentQC.ToString(), false);
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_SubjectPositionResult, Enum_DataTable.SubjectPositionResult.ToString(), false);
          
                this.myDataTable_WelderStudentQC = Class_Issue.GetDataTable_WelderStudentQC (str_IssueNo, null, "ExaminingNo");
                this.myDataTable_SubjectPositionResult = Class_Issue.GetDataTable_SubjectPositionResult(str_IssueNo, null, "ExaminingNo, WeldingPosition");
                this.dataGridView_SubjectPositionResult.DataSource = new DataView(this.myDataTable_SubjectPositionResult);
                this.dataGridView_Data.DataSource = new DataView(this.myDataTable_WelderStudentQC);
                this.dataGridView_Data.Columns["SkillResult"].ReadOnly = false;
                this.dataGridView_Data.Columns["SkillMakeupResult"].ReadOnly = false;
                this.dataGridView_Data.Columns["StudentMarked"].ReadOnly = false;
                this.dataGridView_Data.Columns["StudentAssemblage"].ReadOnly = false;
                this.dataGridView_Data.Columns["StudentMaterial"].ReadOnly = false;
                this.dataGridView_Data.Columns["StudentDimensionofMaterial"].ReadOnly = false;
                this.dataGridView_Data.Columns["StudentWeldingConsumable"].ReadOnly = false;
                this.dataGridView_Data.Columns["StudentThickness"].ReadOnly = false;
                this.dataGridView_Data.Columns["StudentExternalDiameter"].ReadOnly = false;
            
                this.dataGridView_SubjectPositionResult.Columns["isPassed"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["isMakeup"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["FaceDT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["RT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["BendDT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["UT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["DisjunctionDT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["Impact"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["MacroExamination"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["OtherDT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["Flaw"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["MakeupFaceDT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["MakeupRT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["MakeupBendDT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["MakeupUT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["MakeupDisjunctionDT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["MakeupImpact"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["MakeupMacroExamination"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["MakeupOtherDT"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["MakeupFlaw"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["WeldingPositionResultAssemblage"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["WeldingPositionResultThickness"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["WeldingPositionResultExternalDiameter"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["WeldingPositionResultRenderWeldingRodDiameter"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["WeldingPositionResultWeldingRodDiameter"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["WeldingPositionResultCoverWeldingRodDiameter"].ReadOnly = false;
                this.dataGridView_SubjectPositionResult.Columns["WeldingPositionResultRemark"].ReadOnly = false;
            }
            
            this.dataGridView_Data.Columns["StudentKindofExam"].ReadOnly = false;
            this.dataGridView_Data.Columns["ExamStatus"].ReadOnly = false;
            this.dataGridView_Data.Columns["TheoryResult"].ReadOnly = false;
            this.dataGridView_Data.Columns["TheoryMakeupResult"].ReadOnly = false;
            this.dataGridView_Data.Columns["StudentRemark"].ReadOnly = false;

            this.label_Data  .Text = string.Format("学员，({0})：", this.dataGridView_Data.RowCount);
            this.label_SubjectPositionResult .Text = string.Format("考试项目，({0})：", this.dataGridView_SubjectPositionResult .RowCount);
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.dataGridView_Data.CurrentCell = null;
            if (this.bool_GXTheory)
            {
                Class_GXTheoryStudent.myAdapter.Update(this.myDataTable_WelderStudentQC);

                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Exam_GXTheoryStudent", this.str_IssueNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "批量输入成绩");
            }
            else
            {
                Class_Student.myAdapter.Update(this.myDataTable_WelderStudentQC);
                this.dataGridView_SubjectPositionResult  .CurrentCell = null;
                Class_SubjectPositionResult.myAdapter.Update(this.myDataTable_SubjectPositionResult );

                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Exam_Student", this.str_IssueNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "批量输入成绩");
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Exam_SubjectPositionResult", this.str_IssueNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "批量输入成绩");

            }

        }

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.bool_GXTheory)
            {
                ((DataView)this.dataGridView_SubjectPositionResult.DataSource).RowFilter = string.Format("ExaminingNo='{0}'", this.dataGridView_Data.Rows[e.RowIndex].Cells["ExaminingNo"].Value.ToString());
                this.label_SubjectPositionResult.Text = string.Format("考试项目，({0})：", this.dataGridView_SubjectPositionResult.RowCount);
            }
            if (this.tabControl_SubjectPositionResult.SelectedTab.Text == "考试记录")
            {
                this.userControl_WelderExamBase1.InitDataGridView(this.dataGridView_Data.Rows[e.RowIndex].Cells["IdentificationCard"].Value.ToString());
            }
        }

        /// <summary>
        /// 导出数据到Excel电子表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true);

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
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void toolStripMenuItem_SubjectResultRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_SubjectPositionResult);

        }

        private void toolStripMenuItem_SubjectResultRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_SubjectPositionResult , true, true);

        }

        private void dataGridView_SubjectPositionResult_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_SubjectResultRow ;
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void tabControl_SubjectPositionResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dataGridView_Data.CurrentRow != null && this.tabControl_SubjectPositionResult .SelectedTab.Text == "考试记录")
            {
                this.userControl_WelderExamBase1.InitDataGridView(this.dataGridView_Data.CurrentRow .Cells["IdentificationCard"].Value.ToString());
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
            else if (this.dataGridView_Data.Columns[e.ColumnIndex].Name == "ExamStatus")
            {
                if (e.Value.ToString() != "顺利考试")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }

        }

        private void Form_Student_UpdateResultBatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                return;
            }
            if (MessageBox.Show("您选择不保存数据关闭窗口操作，确认关闭吗？", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }

        }

    }
}