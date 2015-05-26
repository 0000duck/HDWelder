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
    public partial class UserControl_WPSSequenceDataGridView : UserControl
    {
        private EventArgs_WPS myEventArgs_WPS;

        private DataTable myDataTable_WPSWeldingSequence;
        private DataView myDataView_WPSWeldingSequence;

        private DataTable myDataTable_WPSWeldingLayer;
        private DataView myDataView_WPSWeldingLayer;

        public UserControl_WPSSequenceDataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_WPSSequenceDataGridView_Load(object sender, EventArgs e)
        {
            Publisher_WPS.EventName += new EventHandler_WPS(InitDataGridView);
            
        }

        private void InitDataGridView(object sender,  EventArgs_WPS  e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_WPSWeldingSequence, Enum_DataTableSecond.WPSWeldingSequence.ToString(), false);
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_WPSWeldingLayer, Enum_DataTableSecond.WPSWeldingLayer.ToString(), false);
         
            this.myEventArgs_WPS  = e;
            Class_Data myClass_Data_WPSWeldingSequence = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.WPSWeldingSequence.ToString()];
            Class_Data myClass_Data_WPSWeldingLayer = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.WPSWeldingLayer.ToString()];
            myClass_Data_WPSWeldingSequence.SetFilter(string.Format("WPSID='{0}'", this.myEventArgs_WPS.str_WPSID ));
            myClass_Data_WPSWeldingLayer.SetFilter(string.Format("WPSID='{0}'", this.myEventArgs_WPS.str_WPSID));

            if (this.myEventArgs_WPS.bool_JustFill)
            {
                if (this.myDataTable_WPSWeldingSequence.Rows.Count == 0)
                {
                    this.dataGridView_WPSWeldingSequence .DataSource = null;
                    myClass_Data_WPSWeldingSequence.RefreshData(this.myEventArgs_WPS.bool_JustFill);
                    this.myDataTable_WPSWeldingSequence = myClass_Data_WPSWeldingSequence.myDataTable.Copy();
                    this.myDataView_WPSWeldingSequence = new DataView(this.myDataTable_WPSWeldingSequence);
                    this.dataGridView_WPSWeldingSequence.DataSource = this.myDataView_WPSWeldingSequence;
                }
                else
                {
                    myClass_Data_WPSWeldingSequence.RefreshData(this.myEventArgs_WPS.bool_JustFill, this.myDataTable_WPSWeldingSequence);
                }
            }
            else
            {
                this.dataGridView_WPSWeldingSequence.DataSource = null;
                myClass_Data_WPSWeldingSequence.RefreshData(this.myEventArgs_WPS.bool_JustFill);
                this.myDataTable_WPSWeldingSequence = myClass_Data_WPSWeldingSequence.myDataTable.Copy();
                this.myDataView_WPSWeldingSequence = new DataView(this.myDataTable_WPSWeldingSequence);
                this.dataGridView_WPSWeldingSequence.DataSource = this.myDataView_WPSWeldingSequence;
            }

            if (string.IsNullOrEmpty(((DataView)this.dataGridView_WPSWeldingSequence.DataSource).Sort))
            {
                ((DataView)this.dataGridView_WPSWeldingSequence.DataSource).Sort = myClass_Data_WPSWeldingSequence.myDataView.Sort;
            }

            if (this.myEventArgs_WPS.bool_JustFill)
            {
                if (this.myDataTable_WPSWeldingLayer.Rows.Count == 0)
                {
                    this.dataGridView_WPSWeldingLayer.DataSource = null;
                    myClass_Data_WPSWeldingLayer.RefreshData(this.myEventArgs_WPS.bool_JustFill);
                    this.myDataTable_WPSWeldingLayer = myClass_Data_WPSWeldingLayer.myDataTable.Copy();
                    this.myDataView_WPSWeldingLayer = new DataView(this.myDataTable_WPSWeldingLayer);
                    this.dataGridView_WPSWeldingLayer.DataSource = this.myDataView_WPSWeldingLayer;
                }
                else
                {
                    myClass_Data_WPSWeldingLayer.RefreshData(this.myEventArgs_WPS.bool_JustFill, this.myDataTable_WPSWeldingLayer);
                }
            }
            else
            {
                this.dataGridView_WPSWeldingLayer.DataSource = null;
                myClass_Data_WPSWeldingLayer.RefreshData(this.myEventArgs_WPS.bool_JustFill);
                this.myDataTable_WPSWeldingLayer = myClass_Data_WPSWeldingLayer.myDataTable.Copy();
                this.myDataView_WPSWeldingLayer = new DataView(this.myDataTable_WPSWeldingLayer);
                this.dataGridView_WPSWeldingLayer.DataSource = this.myDataView_WPSWeldingLayer;
            }

            if (string.IsNullOrEmpty(((DataView)this.dataGridView_WPSWeldingLayer.DataSource).Sort))
            {
                ((DataView)this.dataGridView_WPSWeldingLayer.DataSource).Sort = myClass_Data_WPSWeldingLayer.myDataView.Sort;
            }

            this.label_WPSSequence.Text = string.Format("焊接工艺道次类别：({0})", this.dataGridView_WPSWeldingSequence.RowCount);
            this.label_WPSLayer.Text = string.Format("焊接层次分布：({0})", this.dataGridView_WPSWeldingLayer.RowCount);
        }

        private void toolStripMenuItem_WPSSequenceAdd_Click(object sender, EventArgs e)
        {
            WPSSequenceAdd();
        }

        private void toolStripMenuItem_WPSSequenceRowAdd_Click(object sender, EventArgs e)
        {
            WPSSequenceAdd();
        }

        private void WPSSequenceAdd()
        {
            if (this.myEventArgs_WPS == null || string.IsNullOrEmpty(this.myEventArgs_WPS.str_WPSID))
            {
                 MessageBox.Show("请先选择焊接工艺！");
                 return;
            }
            Form_WPSWeldingSequenceUpdate myForm = new Form_WPSWeldingSequenceUpdate();
            myForm.myClass_WPSWeldingSequence = new Class_WPSWeldingSequence();
            myForm.myClass_WPSWeldingSequence.WPSID = this.myEventArgs_WPS.str_WPSID;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true );
            }

        }

        private void toolStripMenuItem_WPSSequenceRowModify_Click(object sender, EventArgs e)
        {
            Form_WPSWeldingSequenceUpdate myForm = new Form_WPSWeldingSequenceUpdate();
            myForm.myClass_WPSWeldingSequence = new Class_WPSWeldingSequence((int)this.dataGridView_WPSWeldingSequence.CurrentRow.Cells["WPSSequenceID"].Value);
            myForm.bool_Add = false ;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true  );
            }

        }

        private void RefreshData(bool bool_JustFill)
        {
            if (this.myEventArgs_WPS  == null)
            {
                this.myEventArgs_WPS = new EventArgs_WPS(null);
            }
            this.myEventArgs_WPS.bool_JustFill = bool_JustFill;
            Publisher_WPS.OnEventName(this.myEventArgs_WPS);
        }

        private void toolStripMenuItem_WPSSequenceDelete_Click(object sender, EventArgs e)
        {
            if (Class_WPSWeldingSequence.ExistAndCanDeleteAndDelete ((int)this.dataGridView_WPSWeldingSequence.CurrentRow.Cells["WPSSequenceID"].Value, Enum_zwjKindofUpdate.CanDelete ))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_WPSWeldingSequence.ExistAndCanDeleteAndDelete((int)this.dataGridView_WPSWeldingSequence.CurrentRow.Cells["WPSSequenceID"].Value, Enum_zwjKindofUpdate.Delete );
                    this.RefreshData(false );
                }
            }        

        }

        private void dataGridView_WPSSequence_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_WPSSequenceRow ;
                this.dataGridView_WPSWeldingSequence.CurrentCell = this.dataGridView_WPSWeldingSequence.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void toolStripMenuItem_WPSSequenceRowExportExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_WPSWeldingSequence, true, true);
        }

        private void contextMenuStrip_WPSSequence_Opening(object sender, CancelEventArgs e)
        {
            if (this.myEventArgs_WPS == null || string.IsNullOrEmpty(this.myEventArgs_WPS.str_WPSID))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                Class_WPS myClass_WPS = new Class_WPS(this.myEventArgs_WPS .str_WPSID);
                e.Cancel = myClass_WPS.WPSStatus <0 || (!(Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Modify) || (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.PossessorModify) && (new Class_WPS(this.myEventArgs_WPS .str_WPSID)).WPSPrincipal.Equals(Class_zwjPublic.myClass_CustomUser.UserGUID))));
            }

        }

        private void contextMenuStrip_WPSSequenceRow_Opening(object sender, CancelEventArgs e)
        {
            Class_WPS myClass_WPS = new Class_WPS(this.myEventArgs_WPS .str_WPSID);
            e.Cancel = myClass_WPS.WPSStatus < 0|| (!(Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Modify) || (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.PossessorModify) && (new Class_WPS(this.myEventArgs_WPS .str_WPSID)).WPSPrincipal.Equals(Class_zwjPublic.myClass_CustomUser.UserGUID))));
            this.toolStripMenuItem_DataGridViewRowExport.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Print);


        }

        private void toolStripMenuItem_WPSSequenceRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false  );
        }

        private void toolStripMenuItem_WPSSequenceRowFrozenThisColumn_CheckedChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_WPSWeldingSequence );

        }

        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            Form_WPSLayerUpdate myForm = new Form_WPSLayerUpdate();
            myForm.myClass_WPSWeldingLayer = new Class_WPSWeldingLayer();
            myForm.myClass_WPSWeldingLayer.WPSID = this.myEventArgs_WPS .str_WPSID;
            myForm.myClass_WPSWeldingLayer.WPSLayerNo = Class_WPSWeldingLayer.GetWPSLayerCount(myForm.myClass_WPSWeldingLayer.WPSID);
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
            }

        }

        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_WPSLayerUpdate myForm = new Form_WPSLayerUpdate();
            myForm.myClass_WPSWeldingLayer = new Class_WPSWeldingLayer((int)this.dataGridView_WPSWeldingLayer.CurrentRow.Cells["WPSLayerID"].Value);
            myForm.bool_Add = false;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
            }

        }

        private void toolStripMenuItem_DataGridViewRowDelete_Click(object sender, EventArgs e)
        {
            if (Class_WPSWeldingLayer.ExistAndCanDeleteAndDelete((int)this.dataGridView_WPSWeldingLayer.CurrentRow.Cells["WPSLayerID"].Value, Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_WPSWeldingLayer.ExistAndCanDeleteAndDelete((int)this.dataGridView_WPSWeldingLayer.CurrentRow.Cells["WPSLayerID"].Value, Enum_zwjKindofUpdate.Delete);
                    this.RefreshData(false);
                }
            }        

        }

        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_WPSWeldingLayer );

        }

        private void toolStripMenuItem_DataGridViewRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false);

        }

        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_WPSWeldingLayer, true, true);

        }

        private void dataGridView_WPSLayer_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_WPSLayerRow;
                this.dataGridView_WPSWeldingLayer.CurrentCell = this.dataGridView_WPSWeldingLayer.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void contextMenuStrip_WPSLayerRow_Opening(object sender, CancelEventArgs e)
        {
            Class_WPS myClass_WPS = new Class_WPS(this.myEventArgs_WPS .str_WPSID);
            e.Cancel = myClass_WPS.WPSStatus<0
                || (!(Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Modify) || (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.PossessorModify) && (new Class_WPS(this.myEventArgs_WPS .str_WPSID)).WPSPrincipal.Equals(Class_zwjPublic.myClass_CustomUser.UserGUID))));

            this.toolStripMenuItem_DataGridViewRowExport.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Print);
        }

        private void contextMenuStrip_WPSLayer_Opening(object sender, CancelEventArgs e)
        {
            if (this.myEventArgs_WPS==null ||  string.IsNullOrEmpty(this.myEventArgs_WPS .str_WPSID))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                Class_WPS myClass_WPS = new Class_WPS(this.myEventArgs_WPS .str_WPSID);
                e.Cancel = myClass_WPS.WPSStatus < 0
                        || (!(Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Modify) || (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.PossessorModify) && (new Class_WPS(this.myEventArgs_WPS .str_WPSID)).WPSPrincipal.Equals(Class_zwjPublic.myClass_CustomUser.UserGUID))));
            }
        }

        private void toolStripMenuItem_DataGridViewRowInsert_Click(object sender, EventArgs e)
        {
            Form_WPSLayerUpdate myForm = new Form_WPSLayerUpdate();
            myForm.myClass_WPSWeldingLayer = new Class_WPSWeldingLayer();
            myForm.myClass_WPSWeldingLayer.WPSID = this.myEventArgs_WPS .str_WPSID;
            myForm.myClass_WPSWeldingLayer.WPSLayerNo = (int)this.dataGridView_WPSWeldingLayer.CurrentRow.Cells["WPSLayerNo"].Value;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
            }

        }
    }
}
