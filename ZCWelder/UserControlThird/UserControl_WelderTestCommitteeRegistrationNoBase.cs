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

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WelderTestCommitteeRegistrationNoBase : UserControl
    {
        private string  str_IdentificationCard;

        public UserControl_WelderTestCommitteeRegistrationNoBase()
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

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InitDataGridView(string str_IdentificationCard)
        {
            this.str_IdentificationCard = str_IdentificationCard;
            Class_Data myClass_Data;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.WelderTestCommitteeRegistrationNo.ToString(), false);
            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderTestCommitteeRegistrationNo.ToString()];
            myClass_Data.SetFilter(string.Format("IdentificationCard ='{0}'", this.str_IdentificationCard));
            this.dataGridView_Data .DataSource = null;
            myClass_Data.RefreshData(false);
            this.dataGridView_Data.DataSource = new DataView(myClass_Data.myDataTable.Copy());
            ((DataView)this.dataGridView_Data .DataSource).Sort = myClass_Data.myDataView.Sort;
            this.label_Data.Text = string.Format("存档组织编号，({0})：", this.dataGridView_Data.RowCount);
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
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.str_IdentificationCard))
            {
                return;
            }
            Form_TestCommitteeRegistrationNo_Update myForm = new Form_TestCommitteeRegistrationNo_Update();
            myForm.myClass_TestCommitteeRegistrationNo = new Class_TestCommitteeRegistrationNo();
            myForm.myClass_TestCommitteeRegistrationNo.IdentificationCard = this.str_IdentificationCard;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
            }

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowDelete_Click(object sender, EventArgs e)
        {
            if (Class_TestCommitteeRegistrationNo.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["TestCommitteeID"].Value.ToString(), this.dataGridView_Data.CurrentRow.Cells["RegistrationNo"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_TestCommitteeRegistrationNo.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["TestCommitteeID"].Value.ToString(), this.dataGridView_Data.CurrentRow.Cells["RegistrationNo"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
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
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true );

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
            if (string.IsNullOrEmpty(this.str_IdentificationCard))
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
            this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Delete);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Print);
        }

    }
}
