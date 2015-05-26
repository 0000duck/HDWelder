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
using System.Data.SqlClient;
using ZCCL.Tools;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_Welder_DataGridView : UserControl
    {
        public UserControl_Welder_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_Welder_DataGridView_Load(object sender, EventArgs e)
        {
            Publisher_WelderFilter.EventName += new EventHandler_WelderFilter(InitDataGridView);

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_WelderFilter e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.Welder.ToString(), false);
            SqlCommand myCmd_Temp = new SqlCommand("Person_Welder_Query", Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = ZCCL.Tools.Class_DataValidateTool.CovertIdentificationCard(e.str_IdentificationCard );
            myCmd_Temp.Parameters.Add("@WelderName", SqlDbType.NVarChar, 10).Value = e.str_WelderName;
            myCmd_Temp.Parameters.Add("@WelderWorkerID", SqlDbType.NVarChar, 10).Value = e.str_WelderWorkerID;
            myCmd_Temp.Parameters.Add("@RegistrationNo", SqlDbType.NVarChar, 20).Value = e.str_RegistrationNo;
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = e.str_ExaminingNo;
            myCmd_Temp.Parameters.Add("@CertificateNo", SqlDbType.NVarChar, 20).Value = e.str_CertificateNo;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = e.str_IssueNo;
            if (!string.IsNullOrEmpty(e.str_Filter))
            {
                myCmd_Temp.Parameters.Add("@Filter", SqlDbType.NVarChar).Value = e.str_Filter ;
            }
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCmd_Temp);
            DataTable myDataTable = new DataTable();
            myAdapter.Fill(myDataTable);
            this.dataGridView_Data.DataSource =new DataView (myDataTable);
            this.label_Data.Text = string.Format("焊工，({0})：", this.dataGridView_Data.RowCount);
            if (this.dataGridView_Data.RowCount == 0)
            {
                EventArgs_Welder my_e = new EventArgs_Welder(null);
                Publisher_Welder.OnEventName(my_e);
                MessageBox.Show("没有找到符合条件的焊工！");
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            Form_Welder_Update myForm = new Form_Welder_Update();
            myForm.myClass_Welder = new Class_Welder();
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                EventArgs_WelderFilter my_e = new EventArgs_WelderFilter(null);
                my_e.str_IdentificationCard = myForm.myClass_Welder.IdentificationCard ;
                Publisher_WelderFilter.OnEventName(my_e);
            }

        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_Welder_Update myForm = new Form_Welder_Update();
            myForm.myClass_Welder = new Class_Welder();
            myForm.myClass_Welder.IdentificationCard = this.dataGridView_Data.CurrentRow.Cells["IdentificationCard"].Value.ToString();
            if (myForm.myClass_Welder.FillData())
            {
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    EventArgs_WelderFilter my_e = new EventArgs_WelderFilter(null);
                    my_e.str_IdentificationCard = myForm.myClass_Welder.IdentificationCard;
                    Publisher_WelderFilter.OnEventName(my_e);
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
            if (Class_Welder.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["IdentificationCard"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_Welder.ExistAndCanDeleteAndDelete(this.dataGridView_Data.CurrentRow.Cells["IdentificationCard"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                    EventArgs_WelderFilter my_e = new EventArgs_WelderFilter(null);
                    my_e.str_IdentificationCard = this.dataGridView_Data.CurrentRow.Cells["IdentificationCard"].Value.ToString();
                    Publisher_WelderFilter.OnEventName(my_e);
                }
            }
            else
            {
                MessageBox.Show("不能删除！");
            }

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

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
             EventArgs_Welder my_e = new EventArgs_Welder(this.dataGridView_Data.Rows[e.RowIndex].Cells["IdentificationCard"].Value.ToString());
            Publisher_Welder.OnEventName(my_e);

       }

        private void toolStripMenuItem_RowViewExam_Click(object sender, EventArgs e)
        {
            StringBuilder  str_Filter=new StringBuilder();
            str_Filter.Append("1=0");
            foreach (DataGridViewRow myDataGridViewRow in this.dataGridView_Data.Rows)
            {
                str_Filter.Append(string.Format(" Or IdentificationCard='{0}'", myDataGridViewRow.Cells["IdentificationCard"].Value));
            }
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ExamAll.ToString()];
            myClass_Data.SetFilter(str_Filter.ToString());
            myClass_Data.RefreshData(false);
            ZCCL.Tools.Form_DataView myForm = new ZCCL.Tools.Form_DataView();
            myForm.InitDataGridView("考试记录", new DataView(myClass_Data.myDataTable.Copy()), Enum_DataTable.WelderIssueStudentQCRegistrationNo .ToString());
            myForm.ShowDialog();
        }

        private void toolStripMenuItem_RowAddByExcel_Click(object sender, EventArgs e)
        {
            DataTable myDataTable = Class_DataControlBind.ImportExcelToDataTable();
            if (myDataTable != null)
            {
                if (!myDataTable.Columns.Contains("IdentificationCard"))
                {
                    MessageBox.Show( "数据表中不存在 'IdentificationCard' 列！");
                    return;
                }
                DataRow[] myDataRow_Range;
                myDataRow_Range = myDataTable.Select("len(IdentificationCard)>0");
                StringBuilder myStringBuilder = new StringBuilder();
                myStringBuilder.Append("1=0");
                foreach (DataRow myDataRow in myDataRow_Range)
                {
                    myStringBuilder.Append(string.Format(" Or IdentificationCard='{0}'",Class_DataValidateTool.CovertIdentificationCard( myDataRow["IdentificationCard"].ToString())));
                }
                EventArgs_WelderFilter g = new EventArgs_WelderFilter(myStringBuilder.ToString());
                Publisher_WelderFilter.OnEventName(g);

            }

        }

    }
}
