using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCCL.UpdateLog;

namespace ZCWelder.Person
{
    public partial class Form_WelderBelongExam_UpdateBatch : Form
    {
        private DataTable myDataTable_Origin;
        private DataTable myDataTable_Modified;
        
        public Form_WelderBelongExam_UpdateBatch()
        {
            InitializeComponent();
        }

        private void Form_WelderBelongExam_UpdateBatch_Load(object sender, EventArgs e)
        {

        }

        public void InitDataGridView(DataTable myDataTable)
        {
            myDataTable.AcceptChanges();
            this.myDataTable_Origin = myDataTable;
            this.myDataTable_Modified = this.myDataTable_Origin.Copy();

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.WelderBelongExam.ToString(), false);
            this.dataGridView_Data.Columns["isQCValid"].ReadOnly = false;
            this.dataGridView_Data.Columns["SupervisionCycle"].ReadOnly = false;
            this.dataGridView_Data .Columns["SupervisionFirst"].ReadOnly = false;
            this.dataGridView_Data.Columns ["SupervisionSecond"].ReadOnly = false;
            this.dataGridView_Data.Columns["SupervisionThird"].ReadOnly = false;
            this.dataGridView_Data.Columns["SupervisionFifth"].ReadOnly = false;
            this.dataGridView_Data.Columns ["SupervisionFourth"].ReadOnly = false;
            this.dataGridView_Data.Columns["SupervisionSixth"].ReadOnly = false;
            this.dataGridView_Data.Columns["SupervisionSeventh"].ReadOnly = false;
            this.dataGridView_Data.Columns["SupervisionEighth"].ReadOnly = false;
            this.dataGridView_Data.Columns["PeriodofProlongation"].ReadOnly = false;
            this.dataGridView_Data.Columns["QCRemark"].ReadOnly = false;

            this.dataGridView_Data .DataSource = new DataView(this.myDataTable_Modified );

            this.label_Data .Text = string.Format("证书，({0})：", this.dataGridView_Data .RowCount);

        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            this.InitDataGridView(this.myDataTable_Modified);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.dataGridView_Data .CurrentCell = null;
            Class_QC.myAdapter.Update(this.myDataTable_Modified);

            Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Exam_QC", "--", Class_zwjPublic.myClass_CustomUser.UserGUID, "批量修改证书信息");

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

        private void dataGridView_Data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {           
            if (this.dataGridView_Data.Columns[e.ColumnIndex].Name == "CertificateNo")
            {
                int int_Month = (int)this.dataGridView_Data.Rows[e.RowIndex].Cells["IssuedOnMonth"].Value - Class_ExamField.SupervisionOffset - ((int)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionCycle"].Value) * 48;
                switch (int_Month / 6)
                {
                    case 1:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionFirst"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 2:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionSecond"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 3:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionThird"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 4:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionFourth"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 5:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionFifth"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 6:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionSixth"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 7:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionSeventh"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 8:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionEighth"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    default:
                        break;
                }
            }            
        }

    }
}