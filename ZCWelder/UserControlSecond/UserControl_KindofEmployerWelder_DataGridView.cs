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
using ZCWelder.SignUp;
using ZCWelder.Person;
using System.Data.SqlClient;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_KindofEmployerWelder_DataGridView : UserControl
    {
        private EventArgs_KindofEmployer myEventArgs_KindofEmployer;
        private DataTable myDataTable;
        private DataView myDataView;

        public UserControl_KindofEmployerWelder_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_KindofEmployerWelder_DataGridView_Load(object sender, EventArgs e)
        {
            if (Class_zwjPublic.mysplitContainerHeadBackColor != Color.Empty)
            {
                this.splitContainer1.Panel1.BackColor = Class_zwjPublic.mysplitContainerHeadBackColor;
                this.splitContainer3.Panel1.BackColor = Class_zwjPublic.mysplitContainerHeadBackColor;
            }
            if (Class_zwjPublic.mysplitContainerHeadForeColor != Color.Empty)
            {
                this.splitContainer1.Panel1.ForeColor = Class_zwjPublic.mysplitContainerHeadForeColor;
                this.splitContainer3.Panel1.ForeColor = Class_zwjPublic.mysplitContainerHeadForeColor;
            }
            Publisher_KindofEmployer.EventName += new EventHandler_KindofEmployer(InitDataGridView);

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_KindofEmployer e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Exam, Enum_DataTable.IssueStudentQCRegistrationNo.ToString(), false);
            this.myEventArgs_KindofEmployer = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.KindofEmployerWelder.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.KindofEmployerWelder.ToString()];
            myClass_Data.SetFilter(string.Format("KindofEmployer='{0}'", this.myEventArgs_KindofEmployer.str_KindofEmployer));
            if (this.myEventArgs_KindofEmployer.bool_JustFill)
            {
                if (this.myDataTable.Rows.Count == 0)
                {
                    this.dataGridView_Data.DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_KindofEmployer.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_Data.DataSource = this.myDataView;
                }
                else
                {
                    myClass_Data.RefreshData(this.myEventArgs_KindofEmployer.bool_JustFill, this.myDataTable);
                }
            }
            else
            {
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_KindofEmployer.bool_JustFill);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.myDataView = new DataView(this.myDataTable);
                this.dataGridView_Data.DataSource = this.myDataView;
            }
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            this.label_Data.Text = string.Format("报考单位焊工信息，({0})：", this.dataGridView_Data.RowCount);
            if (this.dataGridView_Data.CurrentRow == null)
            {
                this.dataGridView_Exam.DataSource = null;
                this.label_Exam.Text = "考试记录：";
                this.userControl_WelderPictureBase1.InitWelderPicture(null);
            }

            Class_KindofEmployer myClass_KindofEmployer = new Class_KindofEmployer(e.str_KindofEmployer);
            this.userControl_WelderPictureBase1.button_UploadPicture.Visible  = myClass_KindofEmployer.CanUpLoadWelderPicture;
            this.userControl_WelderPictureBase1.button_DeletePicture .Visible = myClass_KindofEmployer.CanDeleteWelderPicture ;
            this.userControl_WelderPictureBase1.bool_CanModifyWelderPicture = myClass_KindofEmployer.CanModifyWelderPicture; 

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
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_KindofEmployer == null)
            {
                return;
            }
            Form_KindofEmployerWelder_Update myForm = new Form_KindofEmployerWelder_Update();
            myForm.myClass_KindofEmployerWelder = new Class_KindofEmployerWelder();
            myForm.myClass_KindofEmployerWelder.KindofEmployer = this.myEventArgs_KindofEmployer.str_KindofEmployer;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(false);
                Class_DataControlBind.SetDataGridViewSelectedPosition("KindofEmployerWelderID", myForm.myClass_KindofEmployerWelder.KindofEmployerWelderID.ToString(), this.dataGridView_Data);
            }

        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_KindofEmployerWelder_Update myForm = new Form_KindofEmployerWelder_Update();
            myForm.myClass_KindofEmployerWelder = new Class_KindofEmployerWelder();
            myForm.myClass_KindofEmployerWelder.KindofEmployerWelderID =(int) this.dataGridView_Data.CurrentRow.Cells["KindofEmployerWelderID"].Value;
            if (myForm.myClass_KindofEmployerWelder.FillData())
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
            if (Class_KindofEmployerWelder.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerWelderID"].Value, Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_KindofEmployerWelder.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerWelderID"].Value, Enum_zwjKindofUpdate.Delete);
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
            if (this.myEventArgs_KindofEmployer == null)
            {
                e.Cancel = true;
                return;
            }
            //this.toolStripMenuItem_DataGridViewAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Add);
            this.toolStripMenuItem_Synchronization .Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Add);
        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            //this.toolStripMenuItem_DataGridViewRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Add);
            //this.toolStripMenuItem_DataGridViewRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Modify);
            //this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Delete);
            //this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Print);
            this.toolStripMenuItem_RowSynchronization  .Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Delete);
        }

        private void toolStripMenuItem_ExamRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false);

        }

        private void toolStripMenuItem_ExamRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Exam, true, true);

        }

        private void toolStripMenuItem_ExamRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Exam );

        }

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string str_IdentificationCard=this.dataGridView_Data .Rows[e.RowIndex].Cells["IdentificationCard"].Value.ToString();
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ExamAll.ToString()];
            myClass_Data.SetFilter(string.Format("IdentificationCard='{0}'", str_IdentificationCard));
            this.dataGridView_Exam .DataSource = null;
            myClass_Data.RefreshData(false);
            this.dataGridView_Exam.DataSource = new DataView(myClass_Data.myDataTable.Copy());
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Exam .DataSource).Sort))
            {
                ((DataView)this.dataGridView_Exam.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            if (this.checkBox_QC.Checked)
            {
                ((DataView)this.dataGridView_Exam.DataSource).RowFilter = string.Format("ValidUntil >= '{0}' And isQCValid = 1", DateTime.Today.ToShortDateString());
            }
            else
            {
                ((DataView)this.dataGridView_Exam.DataSource).RowFilter = null;
            }
            this.label_Exam.Text = string.Format("身份证号码为 {0} 的考试记录，({1})：", str_IdentificationCard, this.dataGridView_Exam.RowCount);
            this.userControl_WelderPictureBase1.InitWelderPicture(str_IdentificationCard);

        }

        private void dataGridView_Exam_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_ExamRow ;
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void toolStripMenuItem_RowSynchronization_Click(object sender, EventArgs e)
        {
            Form_Welder_Synchronization myForm = new Form_Welder_Synchronization();
            Class_KindofEmployer myClass_KindofEmployer = new Class_KindofEmployer(this.myEventArgs_KindofEmployer.str_KindofEmployer);
            myForm.myClass_KindofEmployer = myClass_KindofEmployer;
            myForm.ShowDialog();
            if (myForm.bool_Updated )
            {
                this.RefreshData(false);
            }

        }

        private void toolStripMenuItem_RowWelderFluxion_Click(object sender, EventArgs e)
        {
            ZCCL.Tools.Form_DataView myForm = new ZCCL.Tools.Form_DataView();
            myForm.InitDataGridView("流失焊工考试记录",new DataView ( Class_KindofEmployer.GetDataTable_WelderFluxion(this.myEventArgs_KindofEmployer.str_KindofEmployer )), Enum_DataTable.WelderIssueStudentQCRegistrationNo.ToString());
            myForm.ShowDialog();

        }

        private void dataGridView_Exam_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView_Exam.Columns[e.ColumnIndex].Name == "TheoryResult" || this.dataGridView_Exam.Columns[e.ColumnIndex].Name == "TheoryMakeupResult")
            {
                if (e.Value != DBNull.Value && (int)e.Value < (int)this.dataGridView_Exam.Rows[e.RowIndex].Cells["PassScore"].Value)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }

        }

        private void checkBox_QC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dataGridView_Exam.DataSource != null)
            {
                if (this.checkBox_QC.Checked)
                {
                    ((DataView)this.dataGridView_Exam.DataSource).RowFilter = string.Format("ValidUntil >= '{0}' And isQCValid = 1", DateTime.Today.ToShortDateString());
                }
                else
                {
                    ((DataView)this.dataGridView_Exam.DataSource).RowFilter = null;
                }
                this.label_Exam .Text = string.Format("考试记录，({0})：", this.dataGridView_Exam.RowCount);
            }

        }

        private void toolStripMenuItem_RowSynchronizationhdhr_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认同步用友数据吗？", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            string str_SQL = "SELECT docname FROM [hdhr].[dbo].[v_defdoc_xueli]";
            SqlDataAdapter myAdapter = new SqlDataAdapter(str_SQL, Properties.Settings.Default.zwjConnhdhr);
            DataTable myDataTable_xueli = new DataTable();
            myAdapter.Fill(myDataTable_xueli);
            Class_Schooling myClass_Schooling = new Class_Schooling();
            foreach (DataRow myDataRow in myDataTable_xueli.Rows)
            {
                if(!Class_Schooling.ExistAndCanDeleteAndDelete(myDataRow["docname"].ToString(), Enum_zwjKindofUpdate.Exist ))
                {
                    myClass_Schooling.Schooling=myDataRow["docname"].ToString();
                    myClass_Schooling.AddAndModify(Enum_zwjKindofUpdate.Add);
                }
            }

            str_SQL = "SELECT [ryid],[ryxm],[ryxb],[xlmc],[rygh],[jcrq],[gsmc],[bmmc],[kscj],[lwgs] FROM [hdhr].[dbo].[v_psninfo_to_hangong]";
            Class_KindofEmployer myClass_KindofEmployer = new Class_KindofEmployer(this.myEventArgs_KindofEmployer.str_KindofEmployer);
            Class_Employer myClass_Employer = new Class_Employer(myClass_KindofEmployer.KindofEmployerEmployerHPID);
            Class_Department  myClass_Department = new Class_Department(myClass_KindofEmployer.KindofEmployerDepartmentHPID);
            Class_WorkPlace myClass_WorkPlace = new Class_WorkPlace(myClass_KindofEmployer.KindofEmployerWorkPlaceHPID);
            switch (myClass_KindofEmployer.KindofEmployerLevel)
            {
                case 1:
                    str_SQL += string.Format(" where gsmc='{0}'", myClass_Employer.Employer);
                    break;
                case 2:
                    str_SQL += string.Format(" where gsmc='{0}' and bmmc='{1}'", myClass_Employer.Employer, myClass_Department.Department );
                    break;
                case 3:
                    str_SQL += string.Format(" where gsmc='{0}' and bmmc='{1}' and kscj='{2}'", myClass_Employer.Employer, myClass_Department.Department, myClass_WorkPlace.WorkPlace );
                    break;
                default:
                    return;
            }
            myAdapter = new SqlDataAdapter(str_SQL, Properties.Settings.Default.zwjConnhdhr);
            DataTable myDataTable_hdhrhangong=new DataTable();
            myAdapter.Fill(myDataTable_hdhrhangong);
            Class_KindofEmployerWelder myClass_KindofEmployerWelder = new Class_KindofEmployerWelder();
            myClass_KindofEmployerWelder.KindofEmployer = myClass_KindofEmployer.KindofEmployer;
            string str_Err;
            int i_success = 0;
            int i_success_add = 0;
            int i_success_modify = 0;
            int i_success_delete = 0;
            int i_fail = 0;
            StringBuilder myStringBuilder_err = new StringBuilder();
            foreach (DataRow myDataRow in this.myDataTable.Rows)
            {
                if (myDataTable_hdhrhangong.Select(string.Format("ryid='{0}'", myDataRow["IdentificationCard"])).GetLength(0) == 0)
                {
                    Class_KindofEmployerWelder.ExistAndCanDeleteAndDelete((int)myDataRow["KindofEmployerWelderID"], Enum_zwjKindofUpdate.Delete);
                    i_success_delete++;
                }
            }

            foreach (DataRow myDataRow in myDataTable_hdhrhangong.Rows)
            {
                myClass_KindofEmployerWelder.IdentificationCard  = myDataRow["ryid"].ToString();
                myClass_KindofEmployerWelder.WelderName = myDataRow["ryxm"].ToString();
                myClass_KindofEmployerWelder.Sex  = myDataRow["ryxb"].ToString();
                myClass_KindofEmployerWelder.Schooling  = myDataRow["xlmc"].ToString();
                if (!DateTime.TryParse(myDataRow["jcrq"].ToString(), out myClass_KindofEmployerWelder.WeldingBeginning))
                {
                    myClass_KindofEmployerWelder.WeldingBeginning = DateTime.Now;
                }
                myClass_KindofEmployerWelder.myClass_BelongUnit.WorkerID = myDataRow["rygh"].ToString();
                myClass_KindofEmployerWelder.myClass_BelongUnit.EmployerHPID =Class_Employer.GetEmployerHPID( myDataRow["gsmc"].ToString());
                if (string.IsNullOrEmpty(myClass_KindofEmployerWelder.myClass_BelongUnit.EmployerHPID))
                {
                    i_fail++;
                    myStringBuilder_err.Append(string.Format("\n身份证号码：{0}, 错误信息：公司名称不符", myClass_KindofEmployerWelder.IdentificationCard));
                    continue;
                }
                else
                {
                    myClass_KindofEmployerWelder.myClass_BelongUnit.DepartmentHPID = Class_Department.GetDepartmentHPID(myClass_KindofEmployerWelder.myClass_BelongUnit.EmployerHPID,myDataRow["bmmc"].ToString());
                    if (string.IsNullOrEmpty(myClass_KindofEmployerWelder.myClass_BelongUnit.DepartmentHPID))
                    {
                        myClass_KindofEmployerWelder.myClass_BelongUnit.WorkPlaceHPID = null;
                    }
                    else
                    {
                        myClass_KindofEmployerWelder.myClass_BelongUnit.WorkPlaceHPID =Class_WorkPlace.GetWorkPlaceHPID(myClass_KindofEmployerWelder.myClass_BelongUnit.DepartmentHPID , myDataRow["kscj"].ToString());
                    }
                    myClass_KindofEmployerWelder.myClass_BelongUnit.LaborServiceTeamHPID =Class_LaborServiceTeam.GetLaborServiceTeamHPID(myClass_KindofEmployerWelder.myClass_BelongUnit.EmployerHPID, myDataRow["lwgs"].ToString());
                }
                str_Err=myClass_KindofEmployerWelder.CheckField();
                if (string.IsNullOrEmpty(str_Err))
                {
                    if (Class_KindofEmployerWelder.ExistSecond(myClass_KindofEmployerWelder.KindofEmployer, myClass_KindofEmployerWelder.IdentificationCard, 0, Enum_zwjKindofUpdate.Add))
                    {
                        myClass_KindofEmployerWelder.KindofEmployerWelderID = Class_KindofEmployerWelder.GetKindofEmployerWelderID(myClass_KindofEmployerWelder.KindofEmployer, myClass_KindofEmployerWelder.IdentificationCard);
                        myClass_KindofEmployerWelder.AddAndModify(Enum_zwjKindofUpdate.Modify );
                        i_success_modify++;
                        i_success++;
                    }
                    else
                    {
                        myClass_KindofEmployerWelder.AddAndModify(Enum_zwjKindofUpdate.Add );
                        i_success_add++;
                        i_success++;
                        if (!Class_Welder.ExistAndCanDeleteAndDelete(myClass_KindofEmployerWelder.IdentificationCard, Enum_zwjKindofUpdate.Exist))
                        {
                            Class_Welder myClass_Welder = new Class_Welder();
                            myClass_Welder.IdentificationCard = myClass_KindofEmployerWelder.IdentificationCard;
                            myClass_Welder.Schooling = myClass_KindofEmployerWelder.Schooling;
                            myClass_Welder.Sex = myClass_KindofEmployerWelder.Sex;
                            myClass_Welder.WelderName = myClass_KindofEmployerWelder.WelderName;
                            myClass_Welder.WeldingBeginning = myClass_KindofEmployerWelder.WeldingBeginning;
                            myClass_Welder.myClass_BelongUnit = myClass_KindofEmployerWelder.myClass_BelongUnit;
                            myClass_Welder.AddAndModify(Enum_zwjKindofUpdate.Add);
                        }
                    }
                }
                else
                {
                    i_fail++;
                    myStringBuilder_err.Append(string.Format("\n身份证号码：{0}, 错误信息：{1}",myClass_KindofEmployerWelder.IdentificationCard  ,str_Err));                    
                }
            }
            this.RefreshData(false);
            MessageBox.Show(string.Format("操作完成，其中同步成功{0}条，添加{1}条，删除{2}条，失败{3}条，失败原因如下：\n{4}", i_success,i_success_add,i_success_delete, i_fail, myStringBuilder_err.ToString()));

        }

    }
}
