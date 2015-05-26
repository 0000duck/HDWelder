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

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_SubjectPositionResult_DataGridView : UserControl
    {
        private EventArgs_Issue myEventArgs_Issue;
        private EventArgs_Student myEventArgs_Student;

        public UserControl_SubjectPositionResult_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_Student_DataGridView_Load(object sender, EventArgs e)
        {
            for (int i = this.tabControl_Auxiliary .TabCount - 1; i >= 0; i--)
            {
                this.tabControl_Auxiliary.SelectedIndex = i;
            }

            Publisher_Issue.EventName += new EventHandler_Issue(InitDataGridView);
            Publisher_Student.EventName += new EventHandler_Student(InitDataGridView);

            if (!Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read))
            {
                this.button_DeletePicture.Visible = false;
                this.button_DownLoadPicture.Visible = false;
                this.button_UploadPicture.Visible = false;
            }

        }

        private void InitDataGridView(object sender, EventArgs_Issue e)
        {
            this.myEventArgs_Issue = e;
            Class_Data myClass_Data;
            if (this.myEventArgs_Issue.bool_GXTheory == false)
            {
                myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.SubjectPositionResult.ToString()];
                this.dataGridView_Data.DataSource = null;
                myClass_Data.SetFilter(string.Format("IssueNo='{0}'", e.str_IssueNo));
                myClass_Data.RefreshData(false);
                this.dataGridView_Data.DataSource = new DataView(myClass_Data.myDataTable.Copy());
                if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
                {
                    ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
                }
                //((DataView)this.dataGridView_Data.DataSource).RowFilter = string.Format("ExaminingNo='{0}'", this.myEventArgs_Student .str_ExaminingNo);
            }
            else
            {
                this.dataGridView_Data.DataSource = null;
            }
            //this.label_Data.Text = string.Format("考试项目，({0})：", this.dataGridView_Data.RowCount);
            this.RefreshData(true   );
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_Student e)
        {
            this.myEventArgs_Student = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.SubjectPositionResult.ToString(), false);
            if (this.dataGridView_Data.DataSource != null)
            {
                if (this.myEventArgs_Student.bool_GXTheory == false)
                {
                    ((DataView)this.dataGridView_Data.DataSource).RowFilter = string.Format("ExaminingNo='{0}'", this.myEventArgs_Student.str_ExaminingNo);
                }
                else
                {
                }
            }
            this.label_Data.Text = string.Format("考试项目，({0})：", this.dataGridView_Data.RowCount);

            if (this.tabControl_Auxiliary.SelectedTab.Text == "考试记录")
            {
                this.userControl_WelderExamBase1.InitDataGridView(this.myEventArgs_Student.str_IdentificationCard);
            }

            Class_Data myClass_Data;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_TestCommitteeRegistrationNo, Enum_DataTable.WelderTestCommitteeRegistrationNo.ToString(), false);
            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderTestCommitteeRegistrationNo.ToString()];
            myClass_Data.SetFilter(string.Format("IdentificationCard ='{0}'", this.myEventArgs_Student.str_IdentificationCard));
            this.dataGridView_TestCommitteeRegistrationNo.DataSource = null;
            myClass_Data.RefreshData(false);
            this.dataGridView_TestCommitteeRegistrationNo.DataSource = new DataView(myClass_Data.myDataTable.Copy());
            ((DataView)this.dataGridView_TestCommitteeRegistrationNo.DataSource).Sort = myClass_Data.myDataView.Sort;
            this.label_TestCommitteeRegistrationNo .Text = string.Format("存档组织编号，({0})：", this.dataGridView_TestCommitteeRegistrationNo .RowCount);

            this.pictureBox_Welder.Image = Class_Welder.GetWelderPicture(this.myEventArgs_Student .str_IdentificationCard);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            if (this.myEventArgs_Student == null)
            {
                return;
            }
            this.myEventArgs_Student .bool_JustFill = bool_JustFill;
            Publisher_Student.OnEventName(this.myEventArgs_Student);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowRefresh_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue == null)
            {
                return;
            }
            this.myEventArgs_Issue.bool_JustFill = false;
            this.InitDataGridView(this.dataGridView_Data, this.myEventArgs_Issue);

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
        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            if (this.myEventArgs_Issue == null || string.IsNullOrEmpty(this.myEventArgs_Issue.str_IssueNo))
            {
                e.Cancel = true;
                return;
            }
            //this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Print);
            this.toolStripMenuItem_RowModifyBatch.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify) && !Class_Issue.CheckFinished(this.myEventArgs_Issue.str_IssueNo);
        }

        private void toolStripMenuItem_TestCommitteeRegistrationNoRowAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Student==null || string.IsNullOrEmpty(this.myEventArgs_Student.str_IdentificationCard))
            {
                return;
            }
            Form_TestCommitteeRegistrationNo_Update myForm = new Form_TestCommitteeRegistrationNo_Update();
            myForm.myClass_TestCommitteeRegistrationNo = new Class_TestCommitteeRegistrationNo();
            myForm.myClass_TestCommitteeRegistrationNo.IdentificationCard  = this.myEventArgs_Student.str_IdentificationCard ;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
            }

        }

        private void toolStripMenuItem_TestCommitteeRegistrationNoRowDelete_Click(object sender, EventArgs e)
        {
            if (Class_TestCommitteeRegistrationNo.ExistAndCanDeleteAndDelete(this.dataGridView_TestCommitteeRegistrationNo.CurrentRow.Cells["TestCommitteeID"].Value.ToString(), this.dataGridView_TestCommitteeRegistrationNo.CurrentRow.Cells["RegistrationNo"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_TestCommitteeRegistrationNo.ExistAndCanDeleteAndDelete(this.dataGridView_TestCommitteeRegistrationNo.CurrentRow.Cells["TestCommitteeID"].Value.ToString(), this.dataGridView_TestCommitteeRegistrationNo.CurrentRow.Cells["RegistrationNo"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                    this.RefreshData(false);
                }
            }
            else
            {
                MessageBox.Show("不能删除！");
            }

        }

        private void toolStripMenuItem_TestCommitteeRegistrationNoRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false );
        }

        private void toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_TestCommitteeRegistrationNo, true, true);

        }

        private void contextMenuStrip_TestCommitteeRegistrationNo_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_TestCommitteeRegistrationNoAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Add);

        }

        private void contextMenuStrip_TestCommitteeRegistrationNoRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Add);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowDelete .Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Delete);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowExportToExcel .Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Print);
            this.toolStripMenuItem_TestCommitteeRegistrationNoRowDelete.Enabled = false;
        }

        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Data  );

        }

        private void toolStripMenuItem_TestCommitteeRegistrationNoRowFrozenThisColumn_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_TestCommitteeRegistrationNo );

        }

        private void dataGridView_TestCommitteeRegistrationNo_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_TestCommitteeRegistrationNoRow ;
                this.dataGridView_TestCommitteeRegistrationNo.CurrentCell = this.dataGridView_TestCommitteeRegistrationNo.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void toolStripMenuItem_RowModifyBatch_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Issue == null)
            {
                return;
            }
            if (this.myEventArgs_Student.bool_GXTheory)
            {
                return;
            }
            Form_SubjectPositionResult_UpdateBatch myForm = new Form_SubjectPositionResult_UpdateBatch();
            myForm.InitDataGridView(((DataView)this.dataGridView_Data.DataSource).Table, true, this.myEventArgs_Issue.str_IssueNo);
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myEventArgs_Issue.bool_JustFill = false;
                this.InitDataGridView(this.dataGridView_Data, this.myEventArgs_Issue);
            }

        }

        private void button_UploadPicture_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Student  == null)
            {
                return;
            }
            if (this.pictureBox_Welder.Image != null)
            {
                if (MessageBox.Show("该焊工已有照片，确认重新上传吗？", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            this.pictureBox_Welder.Image = Class_Welder.SetWelderPicture(this.myEventArgs_Student.str_IdentificationCard);
        }

        private void button_DownLoadPicture_Click(object sender, EventArgs e)
        {
            if (this.pictureBox_Welder.Image != null)
            {
                SaveFileDialog mySaveFileDialog = new SaveFileDialog();
                mySaveFileDialog.Filter = "All files (*.JPG)|*.JPG";
                Class_Welder myClass_Welder = new Class_Welder(this.myEventArgs_Student .str_IdentificationCard);
                mySaveFileDialog.FileName = string.Format("{0}_{1}", myClass_Welder.WelderName, myClass_Welder.IdentificationCard);
                mySaveFileDialog.RestoreDirectory = true;
                if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBox_Welder.Image.Save(mySaveFileDialog.FileName);
                }
            }

        }

        private void button_DeletePicture_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Student  == null)
            {
                return;
            }
            if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Class_Welder.DeleteWelderPicture(this.myEventArgs_Student.str_IdentificationCard);
                this.pictureBox_Welder.Image = null;
            }

        }

        private void tabControl_Auxiliary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.myEventArgs_Student != null && this.tabControl_Auxiliary.SelectedTab.Text=="考试记录")
            {
                this.userControl_WelderExamBase1.InitDataGridView(this.myEventArgs_Student.str_IdentificationCard);
            }
        }

    }
}
