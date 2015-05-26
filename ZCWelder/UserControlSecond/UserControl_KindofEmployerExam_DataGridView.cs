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
using ZCCL.DataGridViewManager;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_KindofEmployerExam_DataGridView : UserControl
    {
        private EventArgs_KindofEmployer myEventArgs_KindofEmployer;
        private DataTable myDataTable;
        private DataView myDataView;

        public UserControl_KindofEmployerExam_DataGridView()
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
            Publisher_KindofEmployer.EventName += new EventHandler_KindofEmployer(InitDataGridView);
            this.button_Query.ForeColor = Button.DefaultForeColor;

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_KindofEmployer e)
        {
            this.myEventArgs_KindofEmployer = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.KindofEmployerExam.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.KindofEmployerExam.ToString()];

            if (this.myDataTable == null)
            {
                myClass_Data.SetFilter("1=1");
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_KindofEmployer.bool_JustFill);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.myDataView = new DataView(this.myDataTable);
                this.dataGridView_Data.DataSource = this.myDataView;
            }
            ((DataView)this.dataGridView_Data.DataSource).RowFilter = string.Format("KindofEmployer='{0}'" , this.myEventArgs_KindofEmployer.str_KindofEmployer ); ;
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }

            this.label_Data.Text = string.Format("考试记录，({0})：", this.dataGridView_Data.RowCount);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            this.myEventArgs_KindofEmployer.bool_JustFill = bool_JustFill;
            Publisher_KindofEmployer.OnEventName(this.myEventArgs_KindofEmployer);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridView_Data.DataSource = null;
            this.myDataView = null;
            this.myDataTable = null;
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
            if (this.myEventArgs_KindofEmployer == null)
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
            //this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Print);
        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_Data.Tag == null)
            {
                return;
            }
            Form_QueryFilter myForm = new Form_QueryFilter();
            myForm.InitControl(this.dataGridView_Data.Tag.ToString());
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                ((DataView)this.dataGridView_Data.DataSource).RowFilter = string.Format("KindofEmployer='{0}' And ({1})", this.myEventArgs_KindofEmployer.str_KindofEmployer, myForm.str_Filter ); ;
            }

        }

    }
}
