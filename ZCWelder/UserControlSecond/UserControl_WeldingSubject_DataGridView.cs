using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;
using ZCWelder.Parameter;
using ZCCL.AspNet;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WeldingSubject_DataGridView : UserControl
    {
        private EventArgs_WeldingStandard myEventArgs_WeldingStandard;

        public UserControl_WeldingSubject_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingSubject_DataGridView_Load(object sender, EventArgs e)
        {
            Publisher_WeldingStandard.EventName += new EventHandler_WeldingStandard(InitDataGridView);

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_WeldingStandard e)
        {
            this.myEventArgs_WeldingStandard = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.WeldingSubject.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingSubject.ToString()];

            if (this.myEventArgs_WeldingStandard.bool_JustFill)
            {
                myClass_Data.RefreshData(this.myEventArgs_WeldingStandard.bool_JustFill);
            }
            else
            {
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_WeldingStandard.bool_JustFill);
                this.dataGridView_Data.DataSource = myClass_Data.myDataView;
            }
            if (string.IsNullOrEmpty(this.myEventArgs_WeldingStandard.str_WeldingStandard))
            {
                myClass_Data.myDataView.RowFilter = e.str_Filter ;
            }
            else
            {
                myClass_Data.myDataView.RowFilter = string.Format("WeldingStandard='{0}'", e.str_WeldingStandard );
            }
            if (this.dataGridView_Data.RowCount == 0)
            {
                EventArgs_WeldingSubject my_e = new EventArgs_WeldingSubject(null);
                Publisher_WeldingSubject.OnEventName(my_e);
            }
            this.label_Data.Text = string.Format("考试科目，({0})：", this.dataGridView_Data.RowCount);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            if (this.myEventArgs_WeldingStandard == null)
            {
                return;
            }
            this.myEventArgs_WeldingStandard.bool_JustFill = bool_JustFill;
            Publisher_WeldingStandard.OnEventName(this.myEventArgs_WeldingStandard);

        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_WeldingStandard == null)
            {
                return;
            }
            Form_WeldingSubject_Update myForm = new Form_WeldingSubject_Update();
            myForm.myClass_WeldingSubject = new Class_WeldingSubject();
            myForm.bool_Add = true;
            myForm.myClass_WeldingSubject.WeldingStandard = this.myEventArgs_WeldingStandard.str_WeldingStandard;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(false);
                Class_DataControlBind.SetDataGridViewSelectedPosition("SubjectID", myForm.myClass_WeldingSubject.SubjectID, this.dataGridView_Data);
            }

        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_WeldingSubject_Update myForm = new Form_WeldingSubject_Update();
            myForm.myClass_WeldingSubject = new Class_WeldingSubject();
            myForm.myClass_WeldingSubject.SubjectID = this.dataGridView_Data.CurrentRow.Cells["SubjectID"].Value.ToString();
            if (myForm.myClass_WeldingSubject.FillData())
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
            if (Class_WeldingSubject.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["SubjectID"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_WeldingSubject.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["SubjectID"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
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
                e.ContextMenuStrip = this.contextMenuStrip_DataGridViewRow ;
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
            this.toolStripMenuItem_DataGridViewAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Add );
        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_DataGridViewRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Add);
            this.toolStripMenuItem_DataGridViewRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Modify);
            this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Delete);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("参数权限"), Enum_zwjKindofUpdate.Print);
        }

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            EventArgs_WeldingSubject my_e = new EventArgs_WeldingSubject(this.dataGridView_Data.Rows[e.RowIndex].Cells["SubjectID"].Value.ToString());
            Publisher_WeldingSubject.OnEventName(my_e);

        }

    }
}
