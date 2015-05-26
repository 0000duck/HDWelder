using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.AspNet;
using ZCCL.Report;
using ZCCL.ClassBase;
using ZCWelder.WPS;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WPSDataGridView : UserControl
    {
        private EventArgs_WPSQuery myEventArgs_WPSQuery;
        private DataTable myDataTable;
        private DataView myDataView;

        public UserControl_WPSDataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_WPSDataGridView_Load(object sender, EventArgs e)
        {
            Publisher_WPSQuery.EventName += new EventHandler_WPSQuery(InitDataGridView);
            if (this.myEventArgs_WPSQuery == null)
            {
                this.myEventArgs_WPSQuery = new EventArgs_WPSQuery(null);
            }
            Publisher_WPSQuery.OnEventName(this.myEventArgs_WPSQuery);
        }

        private void InitDataGridView(object sender, EventArgs_WPSQuery e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.WPS.ToString(), false);
            this.dataGridView_Data.Columns["isLocked"].DefaultCellStyle.ForeColor = Properties.Settings.Default.WPSLockedColor;
            this.dataGridView_Data.Columns["isLocked"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_Data.Columns["WPSMaterialSecond"].DefaultCellStyle.ForeColor = Properties.Settings.Default.WPSLockedColor;
            this.dataGridView_Data.Columns["WPSWorkPieceTypeSecond"].DefaultCellStyle.ForeColor = Properties.Settings.Default.WPSLockedColor;
            this.dataGridView_Data.Columns["WPSThicknessSecond"].DefaultCellStyle.ForeColor = Properties.Settings.Default.WPSLockedColor;
            this.dataGridView_Data.Columns["WPSExternalDiameterSecond"].DefaultCellStyle.ForeColor = Properties.Settings.Default.WPSLockedColor;
         
            this.myEventArgs_WPSQuery = e;
            Class_Data myClass_Data;
            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WPS.ToString()];
            myClass_Data.SetFilter(this.myEventArgs_WPSQuery.str_Filter );
            if (this.myEventArgs_WPSQuery.bool_JustFill)
            {
                if (this.myDataTable.Rows.Count == 0)
                {
                    this.dataGridView_Data.DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_WPSQuery.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_Data.DataSource = this.myDataView;
                }
                else
                {
                    myClass_Data.RefreshData(this.myEventArgs_WPSQuery.bool_JustFill, this.myDataTable);
                }
            }
            else
            {
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_WPSQuery.bool_JustFill);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.myDataView = new DataView(this.myDataTable);
                this.dataGridView_Data.DataSource = this.myDataView;
            }
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            this.label_Data.Text = string.Format("焊接工艺基本信息，({0})：", this.dataGridView_Data.RowCount);
            if (this.dataGridView_Data.RowCount == 0)
            {
                //EventArgs_Issue my_e = new EventArgs_Issue(null, this.myEventArgs_ShipClassification.bool_GXTheory);
                //Publisher_Issue.OnEventName(my_e);
            }
        }

        private void RefreshData(bool bool_JustFill)
        {
            if (this.myEventArgs_WPSQuery == null)
            {                
                this.myEventArgs_WPSQuery = new EventArgs_WPSQuery(null);
            }
            this.myEventArgs_WPSQuery.bool_JustFill = bool_JustFill;
            Publisher_WPSQuery.OnEventName(this.myEventArgs_WPSQuery);

        }

        private void toolStripMenuItem_WPSRowAdd_Click(object sender, EventArgs e)
        {
            Form_WPSUpdate myForm = new Form_WPSUpdate();
            myForm.myClass_WPS = new Class_WPS();
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(false );
                Class_DataControlBind.SetDataGridViewSelectedPosition("WPSID", myForm.myClass_WPS.WPSID , this.dataGridView_Data);
            }
        }

        private void toolStripMenuItem_WPSRowModify_Click(object sender, EventArgs e)
        {
            Form_WPSUpdate myForm = new Form_WPSUpdate();
            myForm.myClass_WPS = new Class_WPS(this.dataGridView_Data.CurrentRow.Cells["WPSID"].Value.ToString());
            myForm.bool_Add = false;
            myForm.myEventArgs_WPSQuery = this.myEventArgs_WPSQuery;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
            }

        }

        private void dataGridView_Data_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if( (e.RowIndex  >= 0) && (e.ColumnIndex >= 0) )
            {                
                e.ContextMenuStrip = this.contextMenuStrip_pWPSRow;
                this.dataGridView_Data .CurrentCell = this.dataGridView_Data.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void toolStripMenuItem_WPSRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false );
        }

        private void toolStripMenuItem_WPSRowDelete_Click(object sender, EventArgs e)
        {            
            Class_WPS myClass_WPS = new Class_WPS((string)this.dataGridView_Data.CurrentRow.Cells["WPSID"].Value);
            if (Class_WPS.ExistAndCanDeleteAndDelete (myClass_WPS.WPSID , Enum_zwjKindofUpdate.CanDelete ))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_WPS.ExistAndCanDeleteAndDelete (myClass_WPS.WPSID, Enum_zwjKindofUpdate.Delete );
                    this.RefreshData(false);
                }
            }
            else
            {
                MessageBox.Show("不能删除！");
            }
        }

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            EventArgs_WPS f = new EventArgs_WPS(this.dataGridView_Data.Rows[e.RowIndex].Cells["WPSID"].Value.ToString());
            Publisher_WPS.OnEventName(f);

        }

        private void contextMenuStrip_WPS_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_DataGridViewAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Add);

        }

        private void contextMenuStrip_WPSRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_DataGridViewRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Add);
            this.toolStripMenuItem_DataGridViewRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Modify ) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.PossessorModify );
            this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Delete ) || Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.PossessorDelete );
            
            this.toolStripMenuItem_RowExport.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Print );
          
            //int int_IssueStatus = (int)this.dataGridView_Data.CurrentRow.Cells["IssueStatus"].Value;
            //if (int_IssueStatus < 0)
            
            Class_WPS myClass_WPS=new Class_WPS(this.dataGridView_Data.CurrentRow.Cells["WPSID"].Value.ToString());
            if (myClass_WPS.WPSStatus<0) 
            {
                this.toolStripMenuItem_DataGridViewRowModify.Enabled = false;
                this.toolStripMenuItem_DataGridViewRowDelete.Enabled = false;
                this.toolStripMenuItem_WPSRowLockOut.Text = "解锁";
            }
            else
            {
                this.toolStripMenuItem_WPSRowLockOut.Text = "锁定";
            }

        }

        private void toolStripMenuItem_WPSRowLockOut_Click(object sender, EventArgs e)
        {
            Class_WPS myClass_WPS=new Class_WPS(this.dataGridView_Data.CurrentRow.Cells["WPSID"].Value.ToString());
            if (this.toolStripMenuItem_WPSRowLockOut.Text == "解锁")
            {
                myClass_WPS.WPSStatus = 0 ;
            }
            else
            {
                myClass_WPS.WPSStatus = int.MinValue ;
            }
            myClass_WPS.AddAndModify (Enum_zwjKindofUpdate.Modify );
            this.RefreshData(false);
            
        }
        
        private void toolStripMenuItem_WPSRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Data);

        }

        private void dataGridView_Data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if ((this.dataGridView_Data.Columns[e.ColumnIndex].Name == "isLocked") && ((int)this.dataGridView_Data.Rows[e.RowIndex].Cells["WPSStatus"].Value )<0)
            //{
            //    e.CellStyle.ForeColor = Properties.Settings.Default.WPSLockedColor ;
            //}

        }

        private void toolStripMenuItem_RowExportExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true);

        }
    }
}
