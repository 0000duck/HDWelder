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
using ZCCL.Report;
using ZCWelder.CrystalReports;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WelderBelong_DataGridView : UserControl
    {
        private EventArgs_Unit myEventArgs_Unit;
        private DataTable myDataTable;
        private DataView myDataView;
        private bool bool_Refresh = false;
        private string str_Filter;

        public UserControl_WelderBelong_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_Unit_DataGridView_Load(object sender, EventArgs e)
        {
            Publisher_Unit.EventName += new EventHandler_Unit(InitDataGridView);

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_Unit e)
        {
            this.str_Filter = null;
            this.myEventArgs_Unit  = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.WelderBelong .ToString(),false );
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderBelong.ToString()];

            if (string.IsNullOrEmpty(this.myEventArgs_Unit.WorkPlaceHPID))
            {
                if (string.IsNullOrEmpty(this.myEventArgs_Unit.DepartmentHPID))
                {
                    if (string.IsNullOrEmpty(this.myEventArgs_Unit.EmployerHPID ))
                    {
                        if (string.IsNullOrEmpty(this.myEventArgs_Unit.EmployerGroup))
                        {
                            str_Filter = string.Format("1=1");
                        }
                        else
                        {
                            str_Filter = string.Format("WelderBelongEmployerGroup='{0}'", this.myEventArgs_Unit.EmployerGroup);
                        }
                    }
                    else
                    {
                        str_Filter = string.Format("WelderBelongEmployerHPID='{0}'", this.myEventArgs_Unit.EmployerHPID);
                    }
                }
                else
                {
                    str_Filter = string.Format("WelderBelongDepartmentHPID='{0}'", this.myEventArgs_Unit.DepartmentHPID);
                }
            }
            else
            {
                str_Filter = string.Format("WelderBelongWorkPlaceHPID='{0}'", this.myEventArgs_Unit.WorkPlaceHPID);
            }
            if (bool_Refresh)
            {
                myClass_Data.SetFilter(str_Filter);
                if (this.myEventArgs_Unit.bool_JustFill)
                {
                    if (this.myDataTable.Rows.Count == 0)
                    {
                        this.dataGridView_Data.DataSource = null;
                        myClass_Data.RefreshData(this.myEventArgs_Unit.bool_JustFill);
                        this.myDataTable = myClass_Data.myDataTable.Copy();
                        this.myDataView = new DataView(this.myDataTable);
                        this.dataGridView_Data.DataSource = this.myDataView;
                    }
                    else
                    {
                        myClass_Data.RefreshData(this.myEventArgs_Unit.bool_JustFill, this.myDataTable);
                    }
                }
                else
                {
                    this.dataGridView_Data.DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_Unit.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_Data.DataSource = this.myDataView;
                }
            }
            else
            {
                if (this.myDataTable == null)
                {
                    myClass_Data.SetFilter("1=1");
                    this.dataGridView_Data.DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_Unit.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_Data.DataSource = this.myDataView;
                }
                else
                {
                }
                ((DataView)this.dataGridView_Data.DataSource).RowFilter = str_Filter;
            }

            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }

            this.label_Data.Text = string.Format("焊工信息，({0})：", this.dataGridView_Data.RowCount);
            if (this.dataGridView_Data.RowCount == 0)
            {
                EventArgs_WelderBelong my_e = new EventArgs_WelderBelong("");
                Publisher_WelderBelong.OnEventName(my_e);

            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            if (this.myEventArgs_Unit == null)
            {
                return;
            }
            this.myEventArgs_Unit.bool_JustFill = bool_JustFill;
            Publisher_Unit.OnEventName(this.myEventArgs_Unit);

        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Unit==null || (string.IsNullOrEmpty(this.myEventArgs_Unit.EmployerHPID) && string.IsNullOrEmpty(this.myEventArgs_Unit.DepartmentHPID) && string.IsNullOrEmpty(this.myEventArgs_Unit.WorkPlaceHPID)))
            {
                MessageBox.Show("请选择单位！");
                return;
            }
            Form_WelderBelong_Update myForm = new Form_WelderBelong_Update();
            myForm.myClass_WelderBelong = new Class_WelderBelong();
            myForm.myClass_WelderBelong.myClass_BelongUnit.EmployerHPID = this.myEventArgs_Unit.EmployerHPID;
            myForm.myClass_WelderBelong.myClass_BelongUnit.DepartmentHPID = this.myEventArgs_Unit.DepartmentHPID;
            myForm.myClass_WelderBelong.myClass_BelongUnit.WorkPlaceHPID = this.myEventArgs_Unit.WorkPlaceHPID;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderBelong.ToString()];
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(false, this.myDataTable);
                this.dataGridView_Data.DataSource = this.myDataView;
                this.RefreshData(false);
                Class_DataControlBind.SetDataGridViewSelectedPosition("WelderBelongID",  myForm.myClass_WelderBelong.WelderBelongID .ToString(), this.dataGridView_Data);
            }

        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_WelderBelong_Update myForm = new Form_WelderBelong_Update();
            myForm.myClass_WelderBelong = new Class_WelderBelong();
            myForm.myClass_WelderBelong.WelderBelongID =(long ) this.dataGridView_Data.CurrentRow.Cells["WelderBelongID"].Value;
            if (myForm.myClass_WelderBelong.FillData())
            {
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderBelong.ToString()];
                    myClass_Data.RefreshData(true, this.myDataTable);
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
            if (Class_WelderBelong.ExistAndCanDeleteAndDelete((long)this.dataGridView_Data.CurrentRow.Cells["WelderBelongID"].Value, Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_WelderBelong.ExistAndCanDeleteAndDelete((long)this.dataGridView_Data.CurrentRow.Cells["WelderBelongID"].Value, Enum_zwjKindofUpdate.Delete);
                    Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderBelong.ToString()];
                    this.dataGridView_Data.DataSource = null;
                    myClass_Data.RefreshData(false , this.myDataTable);
                    this.dataGridView_Data.DataSource = this.myDataView ;
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
            EventArgs_WelderBelong my_e = new EventArgs_WelderBelong(this.dataGridView_Data.Rows[e.RowIndex].Cells["IdentificationCard"].Value.ToString());
            Publisher_WelderBelong.OnEventName(my_e);

        }

        private void toolStripMenuItem_RowStatisticWelderQC_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp;
            DataTable myDataTable_Temp=new DataTable();
            Class_Data myClass_Data;
            string  str_Unit = "统计单位：";
            Form_ReportSelect myForm = new Form_ReportSelect();
            myForm.myClass_Report = new Class_Report();
            myForm.myClass_Report.ReportGroup = "在册焊工持证统计";
            Form_CrystalReport myForm_Report = new Form_CrystalReport();
            string str_FileName;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                str_FileName = string.Format("{0}\\CrystalReports\\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), myForm.myClass_Report.ReportLocation);
                //myForm_Report.myDataView = this.myDataView;
                //myForm_Report.ShowDialog();
            }
            else
            {
                return;
            }

            if (string.IsNullOrEmpty(this.myEventArgs_Unit.WorkPlaceHPID))
            {
                if (string.IsNullOrEmpty(this.myEventArgs_Unit.DepartmentHPID))
                {
                    if (string.IsNullOrEmpty(this.myEventArgs_Unit.EmployerHPID))
                    {
                        if (string.IsNullOrEmpty(this.myEventArgs_Unit.EmployerGroup))
                        {
                            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Employer .ToString()];
                            myClass_Data.RefreshData(false, myDataTable_Temp);
                            myDataView_Temp = new DataView(myDataTable_Temp);
                            foreach (DataRowView myDataRowView in myDataView_Temp)
                            {
                                Class_Employer.StatisticWelderQC(myDataRowView["EmployerHPID"].ToString(), null, null);
                            }
                            myClass_Data.RefreshData(true, myDataTable_Temp);
                            myDataTable_Temp = myDataView_Temp.ToTable();
                            str_Unit = "统计单位：全部公司";
                        }
                        else
                        {
                            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Employer .ToString()];
                            myClass_Data.RefreshData(false, myDataTable_Temp);
                            myDataView_Temp = new DataView(myDataTable_Temp);
                            myDataView_Temp.RowFilter = string.Format("EmployerGroup='{0}'", this.myEventArgs_Unit.EmployerGroup);
                            foreach (DataRowView myDataRowView in myDataView_Temp)
                            {
                                Class_Employer.StatisticWelderQC(myDataRowView["EmployerHPID"].ToString(), null, null);
                            }
                            myClass_Data.RefreshData(true, myDataTable_Temp);
                            myDataTable_Temp = myDataView_Temp.ToTable();
                            str_Unit = string.Format("统计单位：{0}", this.myEventArgs_Unit.EmployerGroup);
                        }
                    }
                    else
                    {
                        myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Department .ToString()];
                        myClass_Data.RefreshData(false, myDataTable_Temp);
                        myDataView_Temp = new DataView(myDataTable_Temp);
                        myDataView_Temp.RowFilter = string.Format("EmployerHPID='{0}'", this.myEventArgs_Unit.EmployerHPID);
                        foreach (DataRowView myDataRowView in myDataView_Temp)
                        {
                            Class_Department.StatisticWelderQC(myDataRowView["DepartmentHPID"].ToString(), null, null);
                        }
                        Class_Employer myClass_Employer = new Class_Employer(this.myEventArgs_Unit.EmployerHPID);
                        myClass_Data.RefreshData(true, myDataTable_Temp);
                        myDataTable_Temp = myDataView_Temp.ToTable();
                        myDataTable_Temp.Columns.Remove("Employer");
                        myDataTable_Temp.Columns["Department"].ColumnName = "Employer";
                        str_Unit = string.Format("统计单位：{0}", myClass_Employer.Employer);
                    }
                }
                else
                {
                    myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WorkPlace .ToString()];
                    myClass_Data.RefreshData(false, myDataTable_Temp);
                    myDataView_Temp = new DataView(myDataTable_Temp);
                    myDataView_Temp.RowFilter = string.Format("DepartmentHPID='{0}'", this.myEventArgs_Unit.DepartmentHPID);
                    foreach (DataRowView myDataRowView in myDataView_Temp)
                    {
                        Class_WorkPlace.StatisticWelderQC(myDataRowView["WorkPlaceHPID"].ToString(), null, null);
                    }
                    Class_Department myClass_Department = new Class_Department(this.myEventArgs_Unit.DepartmentHPID );
                    Class_Employer myClass_Employer = new Class_Employer(myClass_Department.EmployerHPID );
                    myClass_Data.RefreshData(true, myDataTable_Temp);
                    myDataTable_Temp = myDataView_Temp.ToTable();
                    myDataTable_Temp.Columns.Remove("Employer");
                    myDataTable_Temp.Columns["WorkPlace"].ColumnName = "Employer";
                    str_Unit = string.Format("统计单位：{0} -> {1}", myClass_Employer.Employer, myClass_Department.Department);
                }
            }
            else
            {
                return;
            }
            myForm_Report.InitCrystalReport(str_FileName, null, null, new DataView(myDataTable_Temp), null);
            CrystalDecisions.CrystalReports.Engine.TextObject myTextbox ;
            myTextbox = (CrystalDecisions.CrystalReports.Engine.TextObject)myForm_Report.myReportDocument.ReportDefinition.ReportObjects["TextFirst"];
            myTextbox.Text = str_Unit;
            myTextbox = (CrystalDecisions.CrystalReports.Engine.TextObject)myForm_Report.myReportDocument.ReportDefinition.ReportObjects["TextSecond"];
            myTextbox.Text = string.Format("统计级别：全部");
            myForm_Report.ShowDialog();

        }

        private void toolStripMenuItem_RowImportFromExcel_Click(object sender, EventArgs e)
        {
            DataTable myDataTable = Class_DataControlBind.ImportExcelToDataTable();
            if (myDataTable != null)
            {
                Form_WelderBelong_ImportFromExcel myForm = new Form_WelderBelong_ImportFromExcel();
                myForm.InitDataGridView(this.myEventArgs_Unit.EmployerHPID,this.myEventArgs_Unit.DepartmentHPID,this.myEventArgs_Unit.WorkPlaceHPID, myDataTable);
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.dataGridView_Data.DataSource = null;
                    this.myDataView = null;
                    this.myDataTable = null;
                    this.RefreshData(false);
                }
            }

        }

        private void toolStripMenuItem_RowExportReport_Click(object sender, EventArgs e)
        {
            Form_ReportSelect myForm = new Form_ReportSelect();
            myForm.myClass_Report = new Class_Report();
            myForm.myClass_Report.ReportGroup = "在册焊工持证信息";
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Form_CrystalReport myForm_Report = new Form_CrystalReport();
                string  str_FileName = string.Format("{0}\\CrystalReports\\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), myForm.myClass_Report.ReportLocation);
                Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderBelongQC.ToString()];
                myClass_Data.SetFilter(this.str_Filter );
                myClass_Data.RefreshData(false);
                myForm_Report.InitCrystalReport(str_FileName, null, null, myClass_Data.myDataView, null);
                myForm_Report.ShowDialog();
            }

        }

        private void toolStripMenuItem_RowExportExcelofWelderBelongQC_Click(object sender, EventArgs e)
        {
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderBelongQC.ToString()];
            myClass_Data.SetFilter(this.str_Filter);
            myClass_Data.RefreshData(false);
            DataGridView myDataGridView = this.dataGridView_ExportExcelTemp ;
            Class_DataControlBind.InitializeDataGridView(myDataGridView, Enum_DataTable.WelderBelongExam .ToString(), false);
            myDataGridView.DataSource = myClass_Data.myDataView;
            Class_DataControlBind.DataGridViewExportExcel(myDataGridView, true, true);
        }

        private void toolStripMenuItem_RowExportWelderPicture_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp = new DataView(this.myDataView.ToTable());
            myDataView_Temp.Sort = "WelderName";
            Class_Welder.ExportWelderPictureToWord(myDataView_Temp);

        }

        private void toolStripMenuItem_RowExportWelderPictureExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.ExportExcelFromDataTable(Class_Welder.DetectWelderPictureisValid(this.myDataView.ToTable()), true, false);
        }

    }
}
