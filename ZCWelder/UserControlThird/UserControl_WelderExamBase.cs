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

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WelderExamBase : UserControl
    {
        private string str_IdentificationCard;

        public UserControl_WelderExamBase()
        {
            InitializeComponent();
        }

        private void UserControl_Template_DataGridView_Load(object sender, EventArgs e)
        {
            if (Class_zwjPublic.mysplitContainerHeadBackColor != Color.Empty)
            {
                this.splitContainer1.Panel1.BackColor = Class_zwjPublic.mysplitContainerHeadBackColor;
            }
            if (Class_zwjPublic.mysplitContainerHeadForeColor != Color.Empty)
            {
                this.splitContainer1.Panel1.ForeColor = Class_zwjPublic.mysplitContainerHeadForeColor;
            }

        }

        public  void InitDataGridView(string str_IdentificationCard)
        {
            this.str_IdentificationCard = str_IdentificationCard;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.IssueStudentQCRegistrationNo.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ExamAll.ToString()];
            myClass_Data.SetFilter(string.Format("IdentificationCard='{0}'", this.str_IdentificationCard));
            this.dataGridView_Data.DataSource = null;
            myClass_Data.RefreshData(false);
            this.dataGridView_Data.DataSource = new DataView(myClass_Data.myDataTable.Copy());
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            if (this.checkBox_QC.Checked)
            {
                ((DataView)this.dataGridView_Data.DataSource).RowFilter = string.Format("ValidUntil >= '{0}' And isQCValid=1", DateTime.Today.ToShortDateString());
            }
            else
            {
                ((DataView)this.dataGridView_Data.DataSource).RowFilter = null;
            }
            this.label_Data.Text = string.Format("考试记录，({0})：", this.dataGridView_Data.RowCount);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            this.InitDataGridView(this.str_IdentificationCard);
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
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true,true );
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

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridView_Opening(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty( this.str_IdentificationCard ))
            {
                e.Cancel = true;
                return;
            }

        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Print);
        }

        private void checkBox_QC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dataGridView_Data.DataSource != null)
            {
                if (this.checkBox_QC.Checked)
                {
                    ((DataView)this.dataGridView_Data.DataSource).RowFilter = string.Format("ValidUntil >= '{0}' And isQCValid = 1", DateTime.Today.ToShortDateString());
                }
                else
                {
                    ((DataView)this.dataGridView_Data.DataSource).RowFilter = null;
                }
                this.label_Data.Text = string.Format("考试记录，({0})：", this.dataGridView_Data.RowCount);
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

    }
}
