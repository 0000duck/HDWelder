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
using ZCCL.DataGridViewManager;
using ZCWelder.CrystalReports ;
using ZCCL.Report;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_ReviveQC_DataGridView : UserControl
    {
        private EventArgs_ReviveQC myEventArgs_ReviveQC;
        
        public UserControl_ReviveQC_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_ReviveQC_DataGridView_Load(object sender, EventArgs e)
        {
            if (Class_zwjPublic.mysplitContainerHeadBackColor != Color.Empty)
            {
                this.splitContainer1.Panel1.BackColor = Class_zwjPublic.mysplitContainerHeadBackColor;
            }
            if (Class_zwjPublic.mysplitContainerHeadForeColor != Color.Empty)
            {
                this.splitContainer1.Panel1.ForeColor = Class_zwjPublic.mysplitContainerHeadForeColor;
            }
            Publisher_ReviveQC.EventName += new EventHandler_ReviveQC(InitDataGridView);
   
            EventArgs_ReviveQC my_e = new EventArgs_ReviveQC( "1=1");
            Publisher_ReviveQC.OnEventName(my_e);

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_ReviveQC e)
        {
            this.myEventArgs_ReviveQC = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTableSecond.ReviveQC.ToString(),false );
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.ReviveQC.ToString()];
            myClass_Data.myDataView.RowFilter = this.myEventArgs_ReviveQC.str_Filter ;

            if (this.myEventArgs_ReviveQC.bool_JustFill)
            {
                myClass_Data.RefreshData(this.myEventArgs_ReviveQC.bool_JustFill);
            }
            else
            {
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_ReviveQC.bool_JustFill);
                this.dataGridView_Data.DataSource = myClass_Data.myDataView;
            }

            this.label_Data.Text = string.Format("激活证书考试记录，({0})：", this.dataGridView_Data.RowCount);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            this.myEventArgs_ReviveQC.bool_JustFill = bool_JustFill;
            //this.myEventArgs_ReviveQC.str_Filter = null;
            Publisher_ReviveQC.OnEventName(this.myEventArgs_ReviveQC);

        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_ReviveQC == null )
            {
                return;
            }
            Form_ReviveQC_Update myForm = new Form_ReviveQC_Update();
            myForm.myClass_ReviveQC = new Class_ReviveQC();
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(false);
                Class_DataControlBind.SetDataGridViewSelectedPosition("ReviveQCID", myForm.myClass_ReviveQC.ReviveQCID.ToString(), this.dataGridView_Data);
            }

        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_ReviveQC_Update myForm = new Form_ReviveQC_Update();
            myForm.myClass_ReviveQC = new Class_ReviveQC();
            myForm.myClass_ReviveQC.ReviveQCID =(int) this.dataGridView_Data.CurrentRow.Cells["ReviveQCID"].Value;
            if (myForm.myClass_ReviveQC.FillData())
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
            if (Class_ReviveQC.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["ReviveQCID"].Value, Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_ReviveQC.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["ReviveQCID"].Value, Enum_zwjKindofUpdate.Delete);
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
            if (this.myEventArgs_ReviveQC == null)
            {
                e.Cancel = true;
                return;
            }

            this.toolStripMenuItem_DataGridViewAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Add);
        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_DataGridViewRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Add);
            this.toolStripMenuItem_DataGridViewRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Modify);
            this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("考试权限"), Enum_zwjKindofUpdate.Delete);
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
                EventArgs_ReviveQC my_e = new EventArgs_ReviveQC(this.myEventArgs_ReviveQC.str_Filter);
                my_e.str_Filter = myForm.str_Filter;
                Publisher_ReviveQC.OnEventName(my_e);

            }

        }

        private void dataGridView_Data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView_Data.Columns[e.ColumnIndex].Name == "TheoryResult" || this.dataGridView_Data.Columns[e.ColumnIndex].Name == "TheoryMakeupResult")
            {
                if (e.Value != DBNull.Value && (int)e.Value < (int)this.dataGridView_Data.Rows[e.RowIndex].Cells["PassScore"].Value)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            else if (this.dataGridView_Data.Columns[e.ColumnIndex].Name == "ExamStatus")
            {
                if (e.Value.ToString() != "顺利考试")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }

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

        private void toolStripMenuItem_RowExportCrystalReport_Click(object sender, EventArgs e)
        {
            Form_ReportSelect myForm = new Form_ReportSelect();
            myForm.myClass_Report = new Class_Report();
            myForm.myClass_Report.ReportGroup = "启用证书";
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Form_CrystalReport myForm_Report = new Form_CrystalReport();
                System.Collections.ArrayList myArrayList = new System.Collections.ArrayList();
                foreach (DataGridViewRow myDataGridViewRow in this.dataGridView_Data.Rows)
                {
                    myArrayList.Add(myDataGridViewRow.Cells ["ExaminingNo"].Value .ToString());
                }
                string str_FileName = string.Format("{0}\\CrystalReports\\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), myForm.myClass_Report.ReportLocation);
                myForm_Report.InitCrystalReport(str_FileName, "ExaminingNo", myArrayList, null, myForm.str_Subhead);
                myForm_Report.ShowDialog();
            }

        }

    }
}
