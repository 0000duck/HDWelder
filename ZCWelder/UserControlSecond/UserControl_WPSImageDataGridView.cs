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
using ZCWelder.WPS;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WPSImageDataGridView : UserControl
    {
        private EventArgs_WPS myEventArgs_WPS;

        private DataTable myDataTable;
        private DataView myDataView;
        
        public UserControl_WPSImageDataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_WPSImageDataGridView_Load(object sender, EventArgs e)
        {           
            Publisher_WPS.EventName += new EventHandler_WPS(InitDataGridView);

        }

        private void InitDataGridView(object sender, EventArgs_WPS e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_WPSImage, Enum_DataTableSecond.WPSImage.ToString(), false);
            this.pictureBox_WPSImage.Image = null;

            this.myEventArgs_WPS = e;
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.WPSImage .ToString()];
            myClass_Data.SetFilter(string.Format("WPSID='{0}'", this.myEventArgs_WPS.str_WPSID));

            if (this.myEventArgs_WPS.bool_JustFill)
            {
                if (this.myDataTable.Rows.Count == 0)
                {
                    this.dataGridView_WPSImage.DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_WPS.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_WPSImage.DataSource = this.myDataView;
                }
                else
                {
                    myClass_Data.RefreshData(this.myEventArgs_WPS.bool_JustFill, this.myDataTable);
                }
            }
            else
            {
                this.dataGridView_WPSImage.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_WPS.bool_JustFill);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.myDataView = new DataView(this.myDataTable);
                this.dataGridView_WPSImage.DataSource = this.myDataView;
            }
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_WPSImage.DataSource).Sort))
            {
                ((DataView)this.dataGridView_WPSImage.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            
            this.label_WPSImage.Text = string.Format("附加图片({0})：", this.dataGridView_WPSImage.RowCount);
        }

        private void dataGridView_WPSImage_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Class_WPSImage myClass_WPSImage = new Class_WPSImage((int)this.dataGridView_WPSImage.Rows[e.RowIndex].Cells["WPSImageID"].Value);
            this.pictureBox_WPSImage.Image = myClass_WPSImage.WPSImage;
             
        }

        private void toolStripMenuItem_WPSImageRowDelete_Click(object sender, EventArgs e)
        {
            if (Class_WPSImage.ExistAndCanDeleteAndDelete ((int)this.dataGridView_WPSImage.CurrentRow.Cells["WPSImageID"].Value, Enum_zwjKindofUpdate.CanDelete ))
             {
                 if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                 {
                     Class_WPSImage.ExistAndCanDeleteAndDelete ((int)this.dataGridView_WPSImage.CurrentRow.Cells["WPSImageID"].Value, Enum_zwjKindofUpdate.Delete );
                     this.RefreshData(false );                     
                     this.pictureBox_WPSImage.Image = null;                                       

                 }
             }        

        }

        private void toolStripMenuItem_WPSImageRowDownload_Click(object sender, EventArgs e)
        {
            Class_WPSImage myClass_WPSImage = new Class_WPSImage((int)this.dataGridView_WPSImage.CurrentRow.Cells["WPSImageID"].Value);
            this.saveFileDialog_WPSImage.FileName = myClass_WPSImage.WPSImageName ;
             this.saveFileDialog_WPSImage.Filter = "All files (*.*)|*.*";
             this.saveFileDialog_WPSImage.RestoreDirectory = true;
             if (this.saveFileDialog_WPSImage.ShowDialog() == DialogResult.OK)
             {
                 myClass_WPSImage.WPSImage.Save(this.saveFileDialog_WPSImage.FileName);
             }

        }

        private void dataGridView_WPSImage_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_WPSImageRow ;
                this.dataGridView_WPSImage.CurrentCell = this.dataGridView_WPSImage.Rows[e.RowIndex].Cells[e.ColumnIndex];
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

        private void toolStripMenuItem_WPSImageRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false);
        }

        private void toolStripMenuItem_DataGridViewAdd_Click(object sender, EventArgs e)
        {
            this.WPSImageAdd();
        }

        private void WPSImageAdd()
        {
            Form_WPSImageUpdate myForm = new Form_WPSImageUpdate();
            myForm.myClass_WPSImage = new Class_WPSImage();
            myForm.myClass_WPSImage.WPSID = this.myEventArgs_WPS .str_WPSID;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
            }


        }

        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            this.WPSImageAdd();
        }

        private void contextMenuStrip_DataGridView_Opening(object sender, CancelEventArgs e)
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

        private void contextMenuStrip_WPSImageRow_Opening(object sender, CancelEventArgs e)
        {
            Class_WPS myClass_WPS = new Class_WPS(this.myEventArgs_WPS.str_WPSID);
            e.Cancel = myClass_WPS.WPSStatus < 0 || (!(Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.Modify) || (Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("工艺权限"), Enum_zwjKindofUpdate.PossessorModify) && (new Class_WPS(this.myEventArgs_WPS.str_WPSID)).WPSPrincipal.Equals(Class_zwjPublic.myClass_CustomUser.UserGUID))));

        }

        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_WPSImageUpdate myForm = new Form_WPSImageUpdate();
            myForm.myClass_WPSImage = new Class_WPSImage((int)this.dataGridView_WPSImage .CurrentRow.Cells["WPSImageID"].Value);
            myForm.bool_Add = false;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(false );
            }

        }


    }
}
