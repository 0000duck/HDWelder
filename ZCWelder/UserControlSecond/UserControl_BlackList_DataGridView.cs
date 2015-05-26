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
using ZCWelder.Person;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_BlackList_DataGridView : UserControl
    {
        private EventArgs_Welder myEventArgs_Welder;

        public UserControl_BlackList_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_BlackList_DataGridView_Load(object sender, EventArgs e)
        {
            if (Class_zwjPublic.mysplitContainerHeadBackColor != Color.Empty)
            {
                this.splitContainer1.Panel1.BackColor = Class_zwjPublic.mysplitContainerHeadBackColor;
            }
            if (Class_zwjPublic.mysplitContainerHeadForeColor != Color.Empty)
            {
                this.splitContainer1.Panel1.ForeColor = Class_zwjPublic.mysplitContainerHeadForeColor;
            }
            Publisher_Welder.EventName += new EventHandler_Welder(InitDataGridView);

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_Welder e)
        {
            this.myEventArgs_Welder  = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.BlackList.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.BlackList.ToString()];
            myClass_Data.SetFilter(string.Format("IdentificationCard = '{0}'", this.myEventArgs_Welder.str_IdentificationCard));

            this.dataGridView_Data.DataSource = null;
            myClass_Data.RefreshData(false);
            this.dataGridView_Data.DataSource = new DataView(myClass_Data.myDataTable.Copy());
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            this.label_Data.Text = string.Format("黑名单记录，({0})：", this.dataGridView_Data.RowCount);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            Publisher_Welder.OnEventName(this.myEventArgs_Welder);

        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Welder==null || string.IsNullOrEmpty(this.myEventArgs_Welder.str_IdentificationCard ))
            {
                return;
            }
            Form_BlackList_Update myForm = new Form_BlackList_Update();
            myForm.myClass_BlackList = new Class_BlackList();
            myForm.myClass_BlackList.IdentificationCard = this.myEventArgs_Welder.str_IdentificationCard;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
            }

        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_BlackList_Update myForm = new Form_BlackList_Update();
            myForm.myClass_BlackList = new Class_BlackList();
            myForm.myClass_BlackList.BlackListID =(int) this.dataGridView_Data.CurrentRow.Cells["BlackListID"].Value;
            if (myForm.myClass_BlackList.FillData())
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

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowDelete_Click(object sender, EventArgs e)
        {
            if (Class_BlackList.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["BlackListID"].Value, Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_BlackList.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["BlackListID"].Value, Enum_zwjKindofUpdate.Delete);
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
            this.RefreshData(false);

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

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridView_Opening(object sender, CancelEventArgs e)
        {
            if (this.myEventArgs_Welder == null)
            {
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(this.myEventArgs_Welder.str_IdentificationCard))
            {
                e.Cancel = true;
                return;
            }
            this.toolStripMenuItem_DataGridViewAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Add);
        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_DataGridViewRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Add);
            this.toolStripMenuItem_DataGridViewRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Modify);
            this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Delete);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Print);
        }

    }
}
