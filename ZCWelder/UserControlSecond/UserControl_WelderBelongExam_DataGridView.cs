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
    public partial class UserControl_WelderBelongExam_DataGridView : UserControl
    {
        private EventArgs_Unit myEventArgs_Unit;
        private DataTable myDataTable;
        private DataView myDataView;
        /// <summary>
        /// true - 实时刷新数据
        /// </summary>
        private bool bool_Refresh = false;

        public string str_ShipClassificationAb;
        public string str_ShipboardNo;
        public string str_KindofQC="全部证书";

        public UserControl_WelderBelongExam_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_Unit_DataGridView_Load(object sender, EventArgs e)
        {
            this.InitTreeView();
            Publisher_Unit.EventName += new EventHandler_Unit(InitDataGridView);

        }
        private void InitTreeView()
        {
            this.treeView_Data.Nodes.Clear();
            TreeNode myTreeNode;
            TreeNode myTreeNode_ShipClassification;
            TreeNode myTreeNode_Ship;

            myTreeNode = new TreeNode();
            myTreeNode.Text = "全部";
            myTreeNode.Tag = "全部";

            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ShipClassification.ToString()];
            //myClass_Data.RefreshData(false);
            //myClass_ShipandShipClassification.RefreshData(false);
            Class_Data myClass_ShipandShipClassification = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ShipandShipClassification.ToString()];
            DataView myDataView_ShipandShipClassification = new DataView(myClass_ShipandShipClassification.myDataTable);
            myDataView_ShipandShipClassification.Sort = myClass_ShipandShipClassification.myDataView.Sort;

            foreach (DataRowView myDataRowView in myClass_Data.myDataView)
            {
                myTreeNode_ShipClassification = new TreeNode();
                myTreeNode_ShipClassification.Text = myDataRowView["ShipClassification"].ToString();
                myTreeNode_ShipClassification.Tag = myDataRowView["ShipClassificationAb"].ToString();
                if ((bool)myDataRowView["ShipRestrict"])
                {
                    myDataView_ShipandShipClassification.RowFilter = string.Format("ShipClassificationAb='{0}'", myDataRowView["ShipClassificationAb"].ToString());
                    foreach (DataRowView myDataRowView_Ship in myDataView_ShipandShipClassification)
                    {
                        myTreeNode_Ship = new TreeNode();
                        myTreeNode_Ship.Text = myDataRowView_Ship["ShipboardNo"].ToString();
                        myTreeNode_Ship.Tag = "ShipboardNo";
                        myTreeNode_ShipClassification.Nodes.Add(myTreeNode_Ship);
                    }
                }
                myTreeNode.Nodes.Add(myTreeNode_ShipClassification);
            }
            this.treeView_Data.Nodes.Add(myTreeNode);
            myTreeNode.Expand();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_Unit e)
        {
            if (e == null)
            {
                return;
            }
            this.myEventArgs_Unit = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.WelderBelongExam.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderBelongQC.ToString()];

            string str_Filter;
            string str_FilterShipClassification;
            if (string.IsNullOrEmpty(this.myEventArgs_Unit.WorkPlaceHPID))
            {
                if (string.IsNullOrEmpty(this.myEventArgs_Unit.DepartmentHPID))
                {
                    if (string.IsNullOrEmpty(this.myEventArgs_Unit.EmployerHPID))
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
            
            //str_Filter += string .Format (" And isQCValid =1");//已在数据库视图中设置
            if (string.IsNullOrEmpty(this.str_ShipClassificationAb))
            {
                str_FilterShipClassification = "1=1";
            }
            else
            {
                str_FilterShipClassification =string.Format("ShipClassificationAb = '{0}'", this.str_ShipClassificationAb);
                if (string.IsNullOrEmpty(this.str_ShipboardNo))
                {
                }
                else
                {
                    str_FilterShipClassification += string.Format(" And ShipboardNo = '{0}'", this.str_ShipboardNo);
                }
            }
            DateTime myDataTime_Begin;
            switch (this.str_KindofQC)
            {
                case "全部证书":
                    str_FilterShipClassification += string.Format(" And isQCValid=1 And ValidUntil>=#{0}#", DateTime.Now);
                    break;
                case "签证证书":
                    string str_FilterSupervision;
                    str_FilterSupervision = string.Format("(IssuedOnMonth - SupervisionCycle*48 - {0})%6=0 and (IssuedOnMonth - {0}>0) And (not (ProlongQCContinuous=0 and PeriodofProlongation>0 and ValidUntil<#{1}#))", Class_ExamField.SupervisionOffset, DateTime.Today.AddMonths(3));
                    str_FilterShipClassification += string.Format(" And isQCValid=1 And ValidUntil>=#{0}# And ({1})", DateTime.Now.Date.AddDays(0 - DateTime.Now.Day).AddMonths(0 - Class_ExamField.SupervisionOffset), str_FilterSupervision);
                    break;
                case "延期证书":
                    myDataTime_Begin = DateTime.Now.Date.AddDays(1 - DateTime.Now.Day).AddMonths(0-Class_ExamField.SupervisionOffset);
                    str_FilterShipClassification += string.Format(" And isQCValid=1 And (ProlongQCContinuous=1 or (ProlongQCContinuous=0 and PeriodofProlongation=0)) And ValidUntil>=#{0}# And ValidUntil<#{1}#", myDataTime_Begin.AddDays(-1), myDataTime_Begin.AddMonths(1).AddDays(-1));
                    break;
                case "复训证书":
                    myDataTime_Begin = DateTime.Now.Date.AddDays(1 - DateTime.Now.Day).AddMonths(0 - Class_ExamField.QCRegain );
                    str_FilterShipClassification += string.Format(" And isQCValid=1 And ProlongQCContinuous=0 and PeriodofProlongation>0 And ValidUntil>=#{0}# And ValidUntil<#{1}#", myDataTime_Begin, myDataTime_Begin.AddMonths(1));
                    break;
                case "失效证书":
                    str_FilterShipClassification += string.Format(" And ((ValidUntil>=#{0}# And ValidUntil<#{1}#) Or (isQCValid = 0 and ValidUntil>#{1}#))", DateTime.Now.AddMonths(-12), DateTime.Now);
                    break;
            }
            str_Filter = string.Format("({0}) And ({1})", str_Filter, str_FilterShipClassification);
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
                ((DataView)this.dataGridView_Data.DataSource).RowFilter = str_Filter;
            }

            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            this.label_Data.Text = string.Format("焊工证书，({0})：", this.dataGridView_Data.RowCount);
            this.toolStripStatusLabel_ShipClassificationAb.Text = string.Format("船级社：{0}", this.str_ShipClassificationAb);
            this.toolStripStatusLabel_ShipboardNo .Text = string.Format("船舶系列：{0}", this.str_ShipboardNo );
            this.toolStripStatusLabel_KindofQC .Text = this.str_KindofQC ;
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            this.myEventArgs_Unit.bool_JustFill = bool_JustFill;
            Publisher_Unit.OnEventName(this.myEventArgs_Unit);

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
            if (this.myEventArgs_Unit == null)
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
            if (this.myEventArgs_Unit == null)
            {
                e.Cancel = true;
                return;
            }

            this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Print);
            this.toolStripMenuItem_RowExportSupervisionExcel.Visible = this.str_KindofQC == "签证证书";
        }

        private void treeView_Data_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.str_ShipClassificationAb = "";
            this.str_ShipboardNo = "";
            switch (this.treeView_Data.SelectedNode.Level)
            {
                case 0:
                    break;
                case 1:
                    this.str_ShipClassificationAb = this.treeView_Data.SelectedNode.Tag.ToString();
                    break;
                case 2:
                    this.str_ShipClassificationAb = this.treeView_Data.SelectedNode.Parent.Tag.ToString();
                    this.str_ShipboardNo = this.treeView_Data.SelectedNode.Text;
                    break;
            }
            this.InitDataGridView(sender, this.myEventArgs_Unit);
        }

        private void toolStripButton_QCAll_Click(object sender, EventArgs e)
        {
            ToolStripButton myToolStripButton = (ToolStripButton)sender;
            this.str_KindofQC = myToolStripButton.Text;
            this.toolStripButton_QCAll .BackColor = Control.DefaultBackColor;
            this.toolStripButton_QCOverdue  .BackColor = Control.DefaultBackColor;
            this.toolStripButton_QCProlongation  .BackColor = Control.DefaultBackColor;
            this.toolStripButton_QCRegain  .BackColor = Control.DefaultBackColor;
            this.toolStripButton_QCSupervision   .BackColor = Control.DefaultBackColor;
            myToolStripButton.BackColor = Color.LightSteelBlue;
            this.InitDataGridView(sender, this.myEventArgs_Unit);
        }

        private void toolStripMenuItem_RowModifyBatch_Click(object sender, EventArgs e)
        {
            Form_WelderBelongExam_UpdateBatch myForm = new Form_WelderBelongExam_UpdateBatch();
            DataView myDataView=(DataView)this.dataGridView_Data.DataSource;
            myForm.InitDataGridView(myDataView.ToTable());
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.dataGridView_Data.DataSource = null;
                this.myDataView = null;
                this.myDataTable = null;
                this.RefreshData(false);
            }

        }

        private void toolStripMenuItem_RowExportEmployerStat_Click(object sender, EventArgs e)
        {
            Form_ReportSelect myForm = new Form_ReportSelect();
            myForm.myClass_Report = new Class_Report();
            myForm.myClass_Report.ReportGroup = "在册焊工持证信息";
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Form_CrystalReport myForm_Report = new Form_CrystalReport();
                string str_FileName = string.Format("{0}\\CrystalReports\\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), myForm.myClass_Report.ReportLocation);
                //string str_Subhead = string.Format("{0} : {1}", this.GetstrUnit() , this.GetstrShipClassification() );
                string str_Subhead = string.Format("{0}", this.GetstrShipClassification());
                //myForm_Report.str_Parameter_Field_Name = "IssueNo";
                //myForm_Report.myArrayList = new System.Collections.ArrayList();
                //myForm_Report.myArrayList.Add(this.myEventArgs_Issue.str_IssueNo);
                myForm_Report.InitCrystalReport(str_FileName, null, null, this.myDataView, str_Subhead);
                myForm_Report.ShowDialog();
            }

        }

        private string GetstrUnit()
        {
            string str_Unit = "统计单位：全部";
            if (string.IsNullOrEmpty(this.myEventArgs_Unit.WorkPlaceHPID))
            {
                if (string.IsNullOrEmpty(this.myEventArgs_Unit.DepartmentHPID))
                {
                    if (string.IsNullOrEmpty(this.myEventArgs_Unit.EmployerHPID))
                    {
                        if (string.IsNullOrEmpty(this.myEventArgs_Unit.EmployerGroup))
                        {
                            str_Unit = "统计单位：全部公司";
                        }
                        else
                        {
                            str_Unit = string.Format("统计单位：{0}", this.myEventArgs_Unit.EmployerGroup);
                        }
                    }
                    else
                    {
                        Class_Employer myClass_Employer = new Class_Employer(this.myEventArgs_Unit.EmployerHPID);
                        str_Unit = string.Format("统计单位：{0}", myClass_Employer.Employer);
                    }
                }
                else
                {
                    Class_Department myClass_Department = new Class_Department(this.myEventArgs_Unit.DepartmentHPID);
                    Class_Employer myClass_Employer = new Class_Employer(myClass_Department.EmployerHPID);
                    str_Unit = string.Format("统计单位：{0} -> {1}", myClass_Employer.Employer, myClass_Department.Department);
                }
            }
            else
            {
                Class_WorkPlace myClass_WorkPlace = new Class_WorkPlace(this.myEventArgs_Unit.WorkPlaceHPID);
                Class_Department myClass_Department = new Class_Department(myClass_WorkPlace.DepartmentHPID);
                Class_Employer myClass_Employer = new Class_Employer(myClass_Department.EmployerHPID);
                str_Unit = string.Format("统计单位：{0} -> {1} -> {2}", myClass_Employer.Employer, myClass_Department.Department, myClass_WorkPlace.WorkPlace );
            }
            return str_Unit ;
        }

        private string GetstrShipClassification()
        {
            string str_ShipClassification = "统计级别：全部";
            if (!string.IsNullOrEmpty(this.str_ShipClassificationAb))
            {
                str_ShipClassification = string.Format("统计级别：{0}", this.str_ShipClassificationAb);
                if (!string.IsNullOrEmpty(this.str_ShipboardNo))
                {
                    str_ShipClassification = string.Format("统计级别：{0} -> {1}", this.str_ShipClassificationAb, this.str_ShipboardNo);
                }
            }
            return str_ShipClassification;
        }

        private void toolStripMenuItem_RowStatisticWelderQC_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp;
            DataTable myDataTable_Temp = new DataTable();
            Class_Data myClass_Data;
            string str_Unit = "统计单位：";
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
                            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Employer.ToString()];
                            myClass_Data.RefreshData(false, myDataTable_Temp);
                            myDataView_Temp = new DataView(myDataTable_Temp);
                            foreach (DataRowView myDataRowView in myDataView_Temp)
                            {
                                Class_Employer.StatisticWelderQC(myDataRowView["EmployerHPID"].ToString(),this.str_ShipClassificationAb , this.str_ShipboardNo );
                            }
                            myClass_Data.RefreshData(true   , myDataTable_Temp);
                            myDataTable_Temp = myDataView_Temp.ToTable();
                            str_Unit = "统计单位：全部公司";
                        }
                        else
                        {
                            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Employer.ToString()];
                            myClass_Data.RefreshData(false, myDataTable_Temp);
                            myDataView_Temp = new DataView(myDataTable_Temp);
                            myDataView_Temp.RowFilter = string.Format("EmployerGroup='{0}'", this.myEventArgs_Unit.EmployerGroup);
                            foreach (DataRowView myDataRowView in myDataView_Temp)
                            {
                                Class_Employer.StatisticWelderQC(myDataRowView["EmployerHPID"].ToString(), this.str_ShipClassificationAb, this.str_ShipboardNo);
                            }
                            myClass_Data.RefreshData(true, myDataTable_Temp);
                            myDataTable_Temp = myDataView_Temp.ToTable();
                            str_Unit = string.Format("统计单位：{0}", this.myEventArgs_Unit.EmployerGroup);
                        }
                    }
                    else
                    {
                        myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Department.ToString()];
                        myClass_Data.RefreshData(false, myDataTable_Temp);
                        myDataView_Temp = new DataView(myDataTable_Temp);
                        myDataView_Temp.RowFilter = string.Format("EmployerHPID='{0}'", this.myEventArgs_Unit.EmployerHPID);
                        foreach (DataRowView myDataRowView in myDataView_Temp)
                        {
                            Class_Department.StatisticWelderQC(myDataRowView["DepartmentHPID"].ToString(), this.str_ShipClassificationAb, this.str_ShipboardNo);
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
                    myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WorkPlace.ToString()];
                    myClass_Data.RefreshData(false, myDataTable_Temp);
                    myDataView_Temp = new DataView(myDataTable_Temp);
                    myDataView_Temp.RowFilter = string.Format("DepartmentHPID='{0}'", this.myEventArgs_Unit.DepartmentHPID);
                    foreach (DataRowView myDataRowView in myDataView_Temp)
                    {
                        Class_WorkPlace.StatisticWelderQC(myDataRowView["WorkPlaceHPID"].ToString(),this.str_ShipClassificationAb , this.str_ShipboardNo);
                    }
                    Class_Department myClass_Department = new Class_Department(this.myEventArgs_Unit.DepartmentHPID);
                    Class_Employer myClass_Employer = new Class_Employer(myClass_Department.EmployerHPID);
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
            CrystalDecisions.CrystalReports.Engine.TextObject myTextbox;
            myTextbox = (CrystalDecisions.CrystalReports.Engine.TextObject)myForm_Report.myReportDocument.ReportDefinition.ReportObjects["TextFirst"];
            myTextbox.Text = str_Unit;
            myTextbox = (CrystalDecisions.CrystalReports.Engine.TextObject)myForm_Report.myReportDocument.ReportDefinition.ReportObjects["TextSecond"];
            if (!string.IsNullOrEmpty(this.str_ShipClassificationAb))
            {
                myTextbox.Text = string.Format("统计级别：{0}", this.str_ShipClassificationAb);
                if (!string.IsNullOrEmpty(this.str_ShipboardNo))
                {
                    myTextbox.Text = string.Format("统计级别：{0} -> {1}", this.str_ShipClassificationAb, this.str_ShipboardNo);
                }
            }
            else
            {
                myTextbox.Text = string.Format("统计级别：全部");
            }
            myForm_Report.ShowDialog();
        }

        private void dataGridView_Data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView_Data.Columns[e.ColumnIndex].Name == "CertificateNo")
            {
                int int_Month = (int)this.dataGridView_Data.Rows[e.RowIndex].Cells["IssuedOnMonth"].Value - Class_ExamField.SupervisionOffset - ((int)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionCycle"].Value) * 48;
                switch (int_Month / 6)
                {
                    case 1:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionFirst"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 2:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionSecond"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 3:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionThird"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 4:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionFourth"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 5:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionFifth"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 6:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionSixth"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 7:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionSeventh"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    case 8:
                        if (!(bool)this.dataGridView_Data.Rows[e.RowIndex].Cells["SupervisionEighth"].Value)
                        {
                            e.CellStyle.ForeColor = Properties.Settings.Default.notSupervisionColor;
                        }
                        break;
                    default:
                        break;
                }
            }            

        }

        private void toolStripMenuItem_RowExportSupervisionExcel_Click(object sender, EventArgs e)
        {
            Class_QC.ExportSupervision( this.myDataView.ToTable());
        }
    }
}
