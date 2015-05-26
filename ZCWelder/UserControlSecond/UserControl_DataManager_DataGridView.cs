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
using ZCCL.DataGridViewManager ;
using ZCWelder.Exam;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_DataManager_DataGridView : UserControl
    {
        private EventArgs_DataManager myEventArgs_DataManager;

        public UserControl_DataManager_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_DataManager_DataGridView_Load(object sender, EventArgs e)
        {
            Publisher_DataManager.EventName += new EventHandler_DataManager(InitDataGridView);

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_DataManager e)
        {
            this.myEventArgs_DataManager = e;
            if (!this.checkBox_All.Checked && string.IsNullOrEmpty(this.myEventArgs_DataManager.str_Filter))
            {
                this.myEventArgs_DataManager.str_Filter = "1=0";
            }
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, this.myEventArgs_DataManager.str_DataManagerTag, false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[this.myEventArgs_DataManager.str_DataManagerName  ];
            if (this.myEventArgs_DataManager.str_DataManagerName == Enum_DataTable.WelderIssueStudentQCRegistrationNo.ToString())
            {
                int i_SupervisionOffset = Class_ExamField.SupervisionOffset + 1;
                if (string.IsNullOrEmpty(this.myEventArgs_DataManager.str_Filter))
                {
                    //e.str_Filter = string.Format("CertificateNo is Not Null And ValidUntil>'{0}' And isQCValid=1",DateTime.Today);
                    e.str_Filter = string.Format("ValidUntil>'{0}' And isQCValid=1 and (",DateTime.Today );
                    e.str_Filter += string.Format(" (SupervisionFirst=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=1) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionSecond=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=2) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionThird=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=3) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionFourth=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=4) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionFifth=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=5) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionSixth=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=6) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionSeventh=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=7) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or ((SupervisionSeventh=1 or SupervisionEighth=1) and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=8) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or ((IssuedOnMonth - SupervisionCycle*48 - {0})/6=0) ", i_SupervisionOffset);
                    e.str_Filter += ")";
                }
                else
                {
                    //e.str_Filter = string.Format("({0}) And CertificateNo is Not Null And ValidUntil>'{1}' And isQCValid=1", this.myEventArgs_DataManager.str_Filter, DateTime.Today);
                    e.str_Filter = string.Format("({0}) And ValidUntil>'{1}' And isQCValid=1 and (", this.myEventArgs_DataManager.str_Filter, DateTime.Today);
                    e.str_Filter += string.Format(" (SupervisionFirst=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=1) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionSecond=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=2) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionThird=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=3) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionFourth=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=4) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionFifth=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=5) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionSixth=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=6) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or (SupervisionSeventh=1 and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=7) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or ((SupervisionSeventh=1 or SupervisionEighth=1) and (IssuedOnMonth - SupervisionCycle*48 - {0})/6=8) ", i_SupervisionOffset);
                    e.str_Filter += string.Format(" or ((IssuedOnMonth - SupervisionCycle*48 - {0})/6=0) ", i_SupervisionOffset);
                    e.str_Filter += ")";
                }
            }
            myClass_Data.SetFilter(this.myEventArgs_DataManager.str_Filter);
            myClass_Data.RefreshData(false );
            this.dataGridView_Data.DataSource =new DataView ( myClass_Data.myDataTable.Copy());
            ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            this.label_Data.Text = string.Format("{0}，({1})：", this.myEventArgs_DataManager .str_DataManagerText , this.dataGridView_Data.RowCount);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            if (this.myEventArgs_DataManager!=null)
            {
                Publisher_DataManager.OnEventName(this.myEventArgs_DataManager );
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
            if (this.myEventArgs_DataManager == null)
            {
                e.Cancel = true;
                return;
            }
            if (this.myEventArgs_DataManager.str_DataManagerTag == Enum_DataTable.WelderIssueStudentQCRegistrationNo.ToString() || this.myEventArgs_DataManager.str_DataManagerTag == Enum_DataTable.WelderBelongExam .ToString())
            {
                this.toolStripMenuItem_AddByExcel.Enabled  = true ;
            }
            else
            {
                this.toolStripMenuItem_AddByExcel.Enabled = false;
            }
        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            if (this.myEventArgs_DataManager.str_DataManagerTag == Enum_DataTable.WelderIssueStudentQCRegistrationNo.ToString() || this.myEventArgs_DataManager.str_DataManagerTag == Enum_DataTable.WelderBelongExam .ToString())
            {
                this.toolStripMenuItem_RowAddByExcel.Enabled = true;
                this.toolStripMenuItem_RowExportQC.Enabled = true;
            }
            else
            {
                this.toolStripMenuItem_RowAddByExcel.Enabled = false;
                this.toolStripMenuItem_RowExportQC.Enabled = false;
            }
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Print);
        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_Data .Tag == null)
            {
                return;
            }
            Form_QueryFilter myForm = new Form_QueryFilter();
            myForm.InitControl(this.dataGridView_Data.Tag.ToString());
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                EventArgs_DataManager my_e = new EventArgs_DataManager(this.myEventArgs_DataManager.str_DataManagerText , this.myEventArgs_DataManager.str_DataManagerName   , this.myEventArgs_DataManager.str_DataManagerTag );
                my_e.str_Filter = myForm.str_Filter;
                Publisher_DataManager.OnEventName(my_e);
            }

        }

        private void toolStripMenuItem_RowExportQC_Click(object sender, EventArgs e)
        {
            Form_ExportQC myForm = new Form_ExportQC();
            DataTable myDataTable = ((DataView)this.dataGridView_Data.DataSource).ToTable();
            if (myDataTable.Columns.Contains("WelderBelongEmployer") && !myDataTable.Columns.Contains("WelderEmployer"))
            {
                myDataTable.Columns["WelderBelongEmployer"].ColumnName = "WelderEmployer";
                myDataTable.Columns["WelderBelongDepartment"].ColumnName = "WelderDepartment";
                myDataTable.Columns["WelderBelongWorkPlace"].ColumnName = "WelderWorkPlace";
                myDataTable.Columns["WelderBelongLaborServiceTeam"].ColumnName = "WelderLaborServiceTeam";
            }
            myForm.myDataTable = myDataTable;
            myForm.ShowDialog();
        }

        private void toolStripMenuItem_RowAddByExcel_Click(object sender, EventArgs e)
        {
            DataTable myDataTable = Class_DataControlBind.ImportExcelToDataTable();
            if (myDataTable != null)
            {
                StringBuilder myStringBuilder = new StringBuilder();
                if (myDataTable.Columns.Contains("CertificateNo"))
                {
                    DataRow[] myDataRow_Range;
                    myDataRow_Range = myDataTable.Select("len(CertificateNo)>0");
                    myStringBuilder.Append("1=0");
                    foreach (DataRow myDataRow in myDataRow_Range)
                    {
                        myStringBuilder.Append(string.Format(" Or CertificateNo='{0}'", myDataRow["CertificateNo"].ToString()));
                    }
                }
                else if (myDataTable.Columns.Contains("ExaminingNo"))
                {
                    DataRow[] myDataRow_Range;
                    myDataRow_Range = myDataTable.Select("len(ExaminingNo)>0");
                    myStringBuilder.Append("1=0");
                    foreach (DataRow myDataRow in myDataRow_Range)
                    {
                        myStringBuilder.Append(string.Format(" Or ExaminingNo='{0}'", myDataRow["ExaminingNo"].ToString()));
                    }
                }
                else
                {
                    MessageBox.Show("数据表中不存在 'CertificateNo'或'ExaminingNo' 列！");
                    return;
                }
                EventArgs_DataManager my_e = new EventArgs_DataManager(this.myEventArgs_DataManager.str_DataManagerText, this.myEventArgs_DataManager.str_DataManagerName, this.myEventArgs_DataManager.str_DataManagerTag);
                my_e.str_Filter = myStringBuilder.ToString();
                Publisher_DataManager.OnEventName(my_e);
            }
        }

    }
}
