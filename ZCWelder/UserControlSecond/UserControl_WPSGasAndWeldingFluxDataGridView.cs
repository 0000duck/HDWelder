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
    public partial class UserControl_WPSGasAndWeldingFluxDataGridView : UserControl
    {
        private EventArgs_WPS myEventArgs_WPS;

        private DataTable myDataTable;
        private DataView myDataView;
        
        public UserControl_WPSGasAndWeldingFluxDataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_WPSGasAndWeldingFluxDataGridView_Load(object sender, EventArgs e)
        {
            Publisher_WPS.EventName += new EventHandler_WPS(InitDataGridView);

        }

        private void InitDataGridView(object sender, EventArgs_WPS e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_WPSGasAndWeldingFlux, Enum_DataTableSecond.WPSGasAndWeldingFlux.ToString(), false);
            this.myEventArgs_WPS  = e;
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.WPSGasAndWeldingFlux.ToString()];
            myClass_Data.SetFilter(string.Format("WPSID='{0}'", this.myEventArgs_WPS .str_WPSID));

            if (this.myEventArgs_WPS.bool_JustFill)
            {
                if (this.myDataTable.Rows.Count == 0)
                {
                    this.dataGridView_WPSGasAndWeldingFlux .DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_WPS.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_WPSGasAndWeldingFlux.DataSource = this.myDataView;
                }
                else
                {
                    myClass_Data.RefreshData(this.myEventArgs_WPS.bool_JustFill, this.myDataTable);
                }
            }
            else
            {
                this.dataGridView_WPSGasAndWeldingFlux.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_WPS.bool_JustFill);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.myDataView = new DataView(this.myDataTable);
                this.dataGridView_WPSGasAndWeldingFlux.DataSource = this.myDataView;
            }
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_WPSGasAndWeldingFlux.DataSource).Sort))
            {
                ((DataView)this.dataGridView_WPSGasAndWeldingFlux .DataSource).Sort = myClass_Data.myDataView.Sort;
            }
        
            this.label_WPSGasAndWeldingFlux.Text = string.Format("保护介质({0})：", this.dataGridView_WPSGasAndWeldingFlux.RowCount);
        }

        private void toolStripMenuItem_WPSGasAndWeldingFluxAdd_Click(object sender, EventArgs e)
        {
            this.WPSGasAndWeldingFluxAdd();
        }

        private void WPSGasAndWeldingFluxAdd()
        {
            WPS.Form_WPSGasAndWeldingFluxUpdate myForm = new WPS.Form_WPSGasAndWeldingFluxUpdate();
            myForm.myClass_WPSGasAndWeldingFlux = new Class_WPSGasAndWeldingFlux();
            myForm.myClass_WPSGasAndWeldingFlux.WPSID = this.myEventArgs_WPS .str_WPSID;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true );
            }


        }

        private void toolStripMenuItem_WPSGasAndWeldingFluxRowAdd_Click(object sender, EventArgs e)
        {
            this.WPSGasAndWeldingFluxAdd();

        }

        private void toolStripMenuItem_WPSGasAndWeldingFluxRowModify_Click(object sender, EventArgs e)
        {
            Form_WPSGasAndWeldingFluxUpdate myForm = new Form_WPSGasAndWeldingFluxUpdate();
            myForm.myClass_WPSGasAndWeldingFlux = new Class_WPSGasAndWeldingFlux((int)this.dataGridView_WPSGasAndWeldingFlux.CurrentRow.Cells["WPSGasAndWeldingFluxID"].Value);
            myForm.bool_Add = false;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true );
            }

        }

        private void toolStripMenuItem_WPSGasAndWeldingFluxRowDelete_Click(object sender, EventArgs e)
        {
            if (Class_WPSGasAndWeldingFlux.ExistAndCanDeleteAndDelete ((int)this.dataGridView_WPSGasAndWeldingFlux.CurrentRow.Cells["WPSGasAndWeldingFluxID"].Value, Enum_zwjKindofUpdate.CanDelete ))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_WPSGasAndWeldingFlux.ExistAndCanDeleteAndDelete((int)this.dataGridView_WPSGasAndWeldingFlux.CurrentRow.Cells["WPSGasAndWeldingFluxID"].Value, Enum_zwjKindofUpdate.Delete );
                    this.RefreshData(false);
                }
            }        

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

        private void dataGridView_WPSGasAndWeldingFlux_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_WPSGasAndWeldingFluxRow;
                this.dataGridView_WPSGasAndWeldingFlux.CurrentCell = this.dataGridView_WPSGasAndWeldingFlux.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }


        }

        private void contextMenuStrip_WPSGasAndWeldingFlux_Opening(object sender, CancelEventArgs e)
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

        private void contextMenuStrip_WPSGasAndWeldingFluxRow_Opening(object sender, CancelEventArgs e)
        {
            Class_WPS myClass_WPS = new Class_WPS(this.myEventArgs_WPS.str_WPSID);
            e.Cancel = myClass_WPS.WPSStatus < 0 || (!(Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Modify) || (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.PossessorModify) && (new Class_WPS(this.myEventArgs_WPS.str_WPSID)).WPSPrincipal.Equals(Class_zwjPublic.myClass_CustomUser.UserGUID))));
            this.toolStripMenuItem_DataGridViewRowExport.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Print);


        }

        private void toolStripMenuItem_WPSGasAndWeldingFluxRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false  );
        }

        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_WPSGasAndWeldingFlux, true, true);

        }

    }
}
