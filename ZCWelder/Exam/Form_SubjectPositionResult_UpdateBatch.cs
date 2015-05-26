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
using ZCWelder.CrystalReports;
using ZCCL.Report;
using ZCCL.UpdateLog;

namespace ZCWelder.Exam
{
    public partial class Form_SubjectPositionResult_UpdateBatch : Form
    {
        private DataTable myDataTable_Origin;
        private DataTable myDataTable_Modified;
        private string str_IssueNo;
        private bool bool_Update;

        public Form_SubjectPositionResult_UpdateBatch()
        {
            InitializeComponent();
        }

        private void Form_SubjectPositionResult_UpdateBatch_Load(object sender, EventArgs e)
        {

        }


        public void InitDataGridView(DataTable myDataTable, bool bool_Update, string str_IssueNo)
        {
            this.str_IssueNo = str_IssueNo;
            myDataTable.AcceptChanges();
            this.bool_Update = bool_Update;
            this.myDataTable_Origin = myDataTable;
            this.myDataTable_Modified = this.myDataTable_Origin.Copy();
            
            if (this.myDataTable_Modified.Columns.Contains("Checked"))
            {
                this.myDataTable_Modified.Columns.Remove("Checked");
            }
            DataColumn myDataColumn_Checked = new DataColumn("Checked");
            myDataColumn_Checked.DataType = System.Type.GetType("System.Boolean");
            myDataColumn_Checked.DefaultValue = false;
            this.myDataTable_Modified.Columns.Add(myDataColumn_Checked);

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.SubjectPositionResult.ToString(),! this.bool_Update );
            this.checkBox_CheckAll.Visible = !this.bool_Update;
            this.toolStripMenuItem_RowExportTestApply.Visible = !this.bool_Update;
            this.toolStripMenuItem_RowExportCrystalReport.Visible = !this.bool_Update;

            if (this.bool_Update)
            {
                this.Text = string.Format("批量输入学员考试项目成绩 - {0}", this.str_IssueNo);
                this.dataGridView_Data.Columns["isPassed"].ReadOnly = false;
                this.dataGridView_Data.Columns["isMakeup"].ReadOnly = false;
                this.dataGridView_Data.Columns["FaceDT"].ReadOnly = false;
                this.dataGridView_Data.Columns["RT"].ReadOnly = false;
                this.dataGridView_Data.Columns["BendDT"].ReadOnly = false;
                this.dataGridView_Data.Columns["UT"].ReadOnly = false;
                this.dataGridView_Data.Columns["DisjunctionDT"].ReadOnly = false;
                this.dataGridView_Data.Columns["Impact"].ReadOnly = false;
                this.dataGridView_Data.Columns["MacroExamination"].ReadOnly = false;
                this.dataGridView_Data.Columns["OtherDT"].ReadOnly = false;
                this.dataGridView_Data.Columns["Flaw"].ReadOnly = false;
                this.dataGridView_Data.Columns["MakeupFaceDT"].ReadOnly = false;
                this.dataGridView_Data.Columns["MakeupRT"].ReadOnly = false;
                this.dataGridView_Data.Columns["MakeupBendDT"].ReadOnly = false;
                this.dataGridView_Data.Columns["MakeupUT"].ReadOnly = false;
                this.dataGridView_Data.Columns["MakeupDisjunctionDT"].ReadOnly = false;
                this.dataGridView_Data.Columns["MakeupImpact"].ReadOnly = false;
                this.dataGridView_Data.Columns["MakeupMacroExamination"].ReadOnly = false;
                this.dataGridView_Data.Columns["MakeupOtherDT"].ReadOnly = false;
                this.dataGridView_Data.Columns["MakeupFlaw"].ReadOnly = false;
                this.dataGridView_Data.Columns["WeldingPositionResultAssemblage"].ReadOnly = false;
                this.dataGridView_Data.Columns["WeldingPositionResultThickness"].ReadOnly = false;
                this.dataGridView_Data.Columns["WeldingPositionResultExternalDiameter"].ReadOnly = false;
                this.dataGridView_Data.Columns["WeldingPositionResultRenderWeldingRodDiameter"].ReadOnly = false;
                this.dataGridView_Data.Columns["WeldingPositionResultWeldingRodDiameter"].ReadOnly = false;
                this.dataGridView_Data.Columns["WeldingPositionResultCoverWeldingRodDiameter"].ReadOnly = false;

                this.toolStripMenuItem_RowExportBendTestApply_AN.Visible = false;
                this.toolStripMenuItem_RowExportBendTestApply_JN.Visible = false;
                this.toolStripMenuItem_RowExportRTTestApply_JN.Visible = false;
                this.toolStripMenuItem_RowExportTestApply.Visible = false;
            }
            else
            {
            }

            this.dataGridView_Data .DataSource = new DataView(this.myDataTable_Modified);
            ((DataView)this.dataGridView_Data.DataSource).Sort = "ExaminingNo, WeldingPosition";
            this.label_Data .Text = string.Format("考试项目，({0})：", this.dataGridView_Data .RowCount);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (this.bool_Update)
            {
                this.dataGridView_Data.CurrentCell = null;
                Class_SubjectPositionResult.myAdapter.Update(this.myDataTable_Modified);

                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Exam_SubjectPositionResult", this.str_IssueNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "批量输入成绩");
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

        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {

        }

        private void checkBox_CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow myDataRow in this.myDataTable_Modified.Rows)
            {
                myDataRow["Checked"] = this.checkBox_CheckAll.Checked;
            }            

        }

        private void toolStripMenuItem_RowExportBendTestApply_JN_Click(object sender, EventArgs e)
        {
            this.dataGridView_Data.CurrentCell = null;
            DataView myDataView_Temp = new DataView(this.myDataTable_Modified);
            myDataView_Temp.RowFilter = "Checked=True";
            if (myDataView_Temp.Count == 0)
            {
                MessageBox.Show("请选择数据！");
                return;
            }
            Class_SubjectPositionResult.ExportBendTestApply_JN(new DataView(myDataView_Temp.ToTable()));
        }

        private void toolStripMenuItem_RowExportBendTestApply_AN_Click(object sender, EventArgs e)
        {
            this.dataGridView_Data.CurrentCell = null;
            DataTable myDataTable = this.myDataTable_Modified.Copy();
            DataView myDataView_Temp;
            myDataView_Temp = new DataView(myDataTable);
            myDataView_Temp.RowFilter = "Checked=True";
            if (myDataView_Temp.Count == 0)
            {
                MessageBox.Show("请选择数据！");
                return;
            }
            myDataTable = myDataView_Temp.ToTable();
            myDataView_Temp = new DataView(myDataTable);
            Class_SubjectPositionResult.ExportBendTestApply_AN(myDataView_Temp);
        }

        private void toolStripMenuItem_RowExportRTTestApply_JN_Click(object sender, EventArgs e)
        {
            this.dataGridView_Data.CurrentCell = null;
            DataTable myDataTable = this.myDataTable_Modified.Copy();
            DataView myDataView_Temp;
            myDataView_Temp = new DataView(myDataTable);
            myDataView_Temp.RowFilter = "Checked=True";
            if (myDataView_Temp.Count == 0)
            {
                MessageBox.Show("请选择数据！");
                return;
            }
            myDataTable = myDataView_Temp.ToTable();
            myDataView_Temp = new DataView(myDataTable);
            Class_SubjectPositionResult.ExportRTTestApply_JN(myDataView_Temp);

        }

        private void toolStripMenuItem_RowExportCrystalReport_Click(object sender, EventArgs e)
        {
            this.dataGridView_Data.CurrentCell = null;
            DataView myDataView_Temp = new DataView(this.myDataTable_Modified);
            myDataView_Temp.RowFilter = "Checked=True";
            if (myDataView_Temp.Count == 0)
            {
                MessageBox.Show("请选择数据！");
                return;
            }
            Form_ReportSelect myForm = new Form_ReportSelect();
            myForm.myClass_Report = new Class_Report();
            myForm.myClass_Report.ReportGroup = "学员二";
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Form_CrystalReport myForm_Report = new Form_CrystalReport();
                System.Collections.ArrayList myArrayList = new System.Collections.ArrayList();
                foreach (DataRowView myDataRowView in myDataView_Temp)
                {
                    myArrayList.Add(myDataRowView["ExaminingNo"].ToString());
                }
                string str_FileName = string.Format("{0}\\CrystalReports\\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), myForm.myClass_Report.ReportLocation);
                myForm_Report.InitCrystalReport(str_FileName, "ExaminingNo", myArrayList, null, myForm.str_Subhead);
                myForm_Report.ShowDialog();
            }

        }

        private void Form_SubjectPositionResult_UpdateBatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                return;
            }
            if (this.bool_Update)
            {
                if (MessageBox.Show("您选择不保存数据关闭窗口操作，确认关闭吗？", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }

        }

        private void toolStripMenuItem_RowExportMTTestApply_JN_Click(object sender, EventArgs e)
        {
            this.dataGridView_Data.CurrentCell = null;
            DataTable myDataTable = this.myDataTable_Modified.Copy();
            DataView myDataView_Temp;
            myDataView_Temp = new DataView(myDataTable);
            myDataView_Temp.RowFilter = "Checked=True";
            if (myDataView_Temp.Count == 0)
            {
                MessageBox.Show("请选择数据！");
                return;
            }
            myDataTable = myDataView_Temp.ToTable();
            myDataView_Temp = new DataView(myDataTable);
            Class_SubjectPositionResult.ExportMTTestApply_JN(myDataView_Temp);

        }
    }
}