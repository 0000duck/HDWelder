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
using ZCWelder.Parameter;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WeldingSubjectApplicable_DataGridView : UserControl
    {
        private EventArgs_WeldingSubject myEventArgs_WeldingSubject;
        private DataView myDataView;

        public UserControl_WeldingSubjectApplicable_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingSubject_DataGridView_Load(object sender, EventArgs e)
        {
            if (Class_zwjPublic.mysplitContainerHeadBackColor != Color.Empty)
            {
                this.splitContainer1.Panel1.BackColor = Class_zwjPublic.mysplitContainerHeadBackColor;
            }
            if (Class_zwjPublic.mysplitContainerHeadForeColor != Color.Empty)
            {
                this.splitContainer1.Panel1.ForeColor = Class_zwjPublic.mysplitContainerHeadForeColor;
            }
            Publisher_WeldingSubject.EventName += new EventHandler_WeldingSubject(InitDataGridView);

        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_WeldingSubject e)
        {
            this.myEventArgs_WeldingSubject = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.WeldingSubjectApplicable.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingSubjectApplicable .ToString()];

            if (this.myEventArgs_WeldingSubject.bool_JustFill)
            {
                myClass_Data.RefreshData(this.myEventArgs_WeldingSubject.bool_JustFill);
                myDataView.RowFilter = string.Format("SubjectID='{0}'", this.myEventArgs_WeldingSubject.str_SubjectID);
            }
            else
            {
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_WeldingSubject.bool_JustFill);
                myDataView = new DataView(myClass_Data.myDataTable);
                myDataView.RowFilter = string.Format("SubjectID='{0}'", this.myEventArgs_WeldingSubject.str_SubjectID);
                this.dataGridView_Data.DataSource = myDataView;
            }

            this.label_Data.Text = string.Format("���Կ�Ŀ���÷�Χ��({0})��", this.dataGridView_Data.RowCount);

        }

        /// <summary>
        /// ˢ������
        /// </summary>
        /// <param name="bool_JustFill">true-ֻ��Ӻ��޸����ݣ�false-ˢ��ȫ������</param>
        private void RefreshData(bool bool_JustFill)
        {
            this.myEventArgs_WeldingSubject.bool_JustFill = bool_JustFill;
            Publisher_WeldingSubject.OnEventName(this.myEventArgs_WeldingSubject);

        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_WeldingSubject == null || string.IsNullOrEmpty(this.myEventArgs_WeldingSubject.str_SubjectID ))
            {
                return;
            }
            Form_WeldingSubjectApplicableUpdate myForm = new Form_WeldingSubjectApplicableUpdate();
            myForm.myClass_WeldingSubjectApplicable = new Class_WeldingSubjectApplicable();
            myForm.myClass_WeldingSubjectApplicable.SubjectID = this.myEventArgs_WeldingSubject.str_SubjectID;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(false);
            }

        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_WeldingSubjectApplicableUpdate myForm = new Form_WeldingSubjectApplicableUpdate();
            myForm.myClass_WeldingSubjectApplicable = new Class_WeldingSubjectApplicable();
            myForm.myClass_WeldingSubjectApplicable.SubjectID = this.myEventArgs_WeldingSubject.str_SubjectID;
            myForm.myClass_WeldingSubjectApplicable.ApplicableSubjectID  = this.dataGridView_Data.CurrentRow.Cells["ApplicableSubjectID"].Value.ToString();
            if (myForm.myClass_WeldingSubjectApplicable.FillData())
            {
                myForm.bool_Add = false;
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData(true);
                }
            }
            else
            {
                MessageBox.Show("���������ѱ�ɾ����");
            }

        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowDelete_Click(object sender, EventArgs e)
        {
            if (Class_WeldingSubjectApplicable.ExistAndCanDeleteAndDelete(this.myEventArgs_WeldingSubject.str_SubjectID,this.dataGridView_Data.CurrentRow.Cells["ApplicableSubjectID"].Value.ToString(), Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("ȷ��ɾ����", "ȷ�ϴ���", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_WeldingSubjectApplicable.ExistAndCanDeleteAndDelete(this.myEventArgs_WeldingSubject.str_SubjectID,this.dataGridView_Data.CurrentRow.Cells["ApplicableSubjectID"].Value.ToString(), Enum_zwjKindofUpdate.Delete);
                    this.RefreshData(false);
                }
            }
            else
            {
                MessageBox.Show("����ɾ����");
            }

        }

        /// <summary>
        /// ˢ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false);

        }

        /// <summary>
        /// �������ݵ�Excel���ӱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true);

        }

        /// <summary>
        /// �����ⶳ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Data);

        }

        /// <summary>
        /// ���ÿ�ݲ˵�
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
        /// ����Ȩ�����ù����б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridView_Opening(object sender, CancelEventArgs e)
        {
            if (this.myEventArgs_WeldingSubject == null)
            {
                e.Cancel = true;
                return;
            }

            this.toolStripMenuItem_DataGridViewAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Add);
        }

        /// <summary>
        /// ����Ȩ�����ù����б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_DataGridViewRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Add);
            this.toolStripMenuItem_DataGridViewRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Modify);
            this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Delete);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Print);
        }

    }
}
