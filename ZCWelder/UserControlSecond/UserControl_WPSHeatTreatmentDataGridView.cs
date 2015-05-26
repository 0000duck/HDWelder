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

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WPSHeatTreatmentDataGridView : UserControl
    {
        private EventArgs_WPS myEventArgs_WPS;

        private DataTable myDataTable;
        private DataView myDataView;
        
        public UserControl_WPSHeatTreatmentDataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_WPSHeatTreatmentDataGridView_Load(object sender, EventArgs e)
        {
            Publisher_WPS.EventName += new EventHandler_WPS(InitDataGridView);

        }

        private void InitDataGridView(object sender, EventArgs_WPS e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_WPSHeatTreatment, Enum_DataTableSecond.WPSHeatTreatment.ToString(), false);
            this.myEventArgs_WPS   = e;
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.WPSHeatTreatment.ToString()];
            myClass_Data.SetFilter(string.Format("WPSID='{0}'", this.myEventArgs_WPS .str_WPSID));
          
            if (this.myEventArgs_WPS.bool_JustFill)
            {
                if (this.myDataTable.Rows.Count == 0)
                {
                    this.dataGridView_WPSHeatTreatment .DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_WPS.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_WPSHeatTreatment.DataSource = this.myDataView;
                }
                else
                {
                    myClass_Data.RefreshData(this.myEventArgs_WPS.bool_JustFill, this.myDataTable);
                }
            }
            else
            {
                this.dataGridView_WPSHeatTreatment.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_WPS.bool_JustFill);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.myDataView = new DataView(this.myDataTable);
                this.dataGridView_WPSHeatTreatment.DataSource = this.myDataView;
            }
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_WPSHeatTreatment.DataSource).Sort))
            {
                ((DataView)this.dataGridView_WPSHeatTreatment.DataSource).Sort = myClass_Data.myDataView.Sort;
            } 
            
            this.label_WPSHeatTreatment.Text = string.Format("热处理方式({0})：", this.dataGridView_WPSHeatTreatment.RowCount);
        }

        private void toolStripMenuItem_WPSHeatTreatmentAdd_Click(object sender, EventArgs e)
        {
            this.WPSHeatTreatmentAdd();
        }

        private void WPSHeatTreatmentAdd()
        {
            WPS.Form_WPSHeatTreatmentUpdate myForm = new WPS.Form_WPSHeatTreatmentUpdate();
            myForm.myClass_WPSHeatTreatment = new Class_WPSHeatTreatment();
            myForm.myClass_WPSHeatTreatment.WPSID = this.myEventArgs_WPS .str_WPSID;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true );
            }


        }

        private void toolStripMenuItem_WPSHeatTreatmentRowAdd_Click(object sender, EventArgs e)
        {
            this.WPSHeatTreatmentAdd();
            
        }

        private void toolStripMenuItem_WPSHeatTreatmentRowModify_Click(object sender, EventArgs e)
        {
            WPS.Form_WPSHeatTreatmentUpdate myForm = new WPS.Form_WPSHeatTreatmentUpdate();
            myForm.myClass_WPSHeatTreatment = new Class_WPSHeatTreatment((int)this.dataGridView_WPSHeatTreatment.CurrentRow.Cells["WPSHeatTreatmentID"].Value);
            myForm.bool_Add = false ;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true );
            }

        }

        private void toolStripMenuItem_WPSHeatTreatmentRowDelete_Click(object sender, EventArgs e)
        {
            if (Class_WPSHeatTreatment.ExistAndCanDeleteAndDelete ((int)this.dataGridView_WPSHeatTreatment.CurrentRow.Cells["WPSHeatTreatmentID"].Value, Enum_zwjKindofUpdate.CanDelete ))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_WPSHeatTreatment.ExistAndCanDeleteAndDelete((int)this.dataGridView_WPSHeatTreatment.CurrentRow.Cells["WPSHeatTreatmentID"].Value, Enum_zwjKindofUpdate.Delete );
                    this.RefreshData(false );
                }
            }        

        }

        private void toolStripMenuItem_WPSHeatTreatmentRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false );

        }

        private void RefreshData(bool bool_JustFill)
        {
            if (this.myEventArgs_WPS == null)
            {
                this.myEventArgs_WPS = new EventArgs_WPS(null);
            }
            this.myEventArgs_WPS.bool_JustFill = bool_JustFill;
            Publisher_WPS.OnEventName(this.myEventArgs_WPS);

        }

        private void dataGridView_WPSHeatTreatment_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_WPSHeatTreatmentRow ;
                this.dataGridView_WPSHeatTreatment.CurrentCell = this.dataGridView_WPSHeatTreatment.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void contextMenuStrip_WPSHeatTreatment_Opening(object sender, CancelEventArgs e)
        {
            if (this.myEventArgs_WPS == null || string.IsNullOrEmpty(this.myEventArgs_WPS.str_WPSID))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                Class_WPS myClass_WPS = new Class_WPS(this.myEventArgs_WPS.str_WPSID);
                e.Cancel = myClass_WPS.WPSStatus < 0 || (!(Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Modify) || (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.PossessorModify) && (new Class_WPS(this.myEventArgs_WPS.str_WPSID)).WPSPrincipal.Equals(Class_zwjPublic.myClass_CustomUser.UserGUID))));
            }

        }

        private void contextMenuStrip_WPSHeatTreatmentRow_Opening(object sender, CancelEventArgs e)
        {
            Class_WPS myClass_WPS = new Class_WPS(this.myEventArgs_WPS.str_WPSID);
            e.Cancel = myClass_WPS.WPSStatus < 0 || (!(Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Modify) || (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.PossessorModify) && (new Class_WPS(this.myEventArgs_WPS.str_WPSID)).WPSPrincipal.Equals(Class_zwjPublic.myClass_CustomUser.UserGUID))));
            this.toolStripMenuItem_DataGridViewRowExport.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Print);

        }

        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_WPSHeatTreatment, true, true);

        }


    }
}
