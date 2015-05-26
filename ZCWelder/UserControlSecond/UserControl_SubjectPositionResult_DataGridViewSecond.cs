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

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_SubjectPositionResult_DataGridViewSecond : UserControl
    {
        private string str_ExaminingNo;

        public UserControl_SubjectPositionResult_DataGridViewSecond()
        {
            InitializeComponent();
        }

        private void UserControl_SubjectPositionResult_DataGridView_Load(object sender, EventArgs e)
        {
            Publisher_StudentSecond.EventName += new EventHandler_StudentSecond(InitDataGridView);

        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_StudentSecond e)
        {
            this.str_ExaminingNo = e.str_ExaminingNo;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.SubjectPositionResult.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.SubjectPositionResultSecond.ToString()];
            myClass_Data.SetFilter(string.Format("ExaminingNo='{0}'", this.str_ExaminingNo));
            this.dataGridView_Data.DataSource = null;
            myClass_Data.RefreshData(false);
            this.dataGridView_Data.DataSource = new DataView(myClass_Data.myDataTable.Copy());
            ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            this.label_Data.Text = string.Format("������Ŀ��({0})��", this.dataGridView_Data.RowCount);

        }

        /// <summary>
        /// ˢ������
        /// </summary>
        /// <param name="bool_JustFill">true-ֻ��Ӻ��޸����ݣ�false-ˢ��ȫ������</param>
        private void RefreshData(bool bool_JustFill)
        {
            EventArgs_StudentSecond my_e = new EventArgs_StudentSecond(this.str_ExaminingNo );
            Publisher_StudentSecond.OnEventName(my_e);

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
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true);;

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
                this.dataGridView_Data.CurrentCell = this.dataGridView_Data.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        /// <summary>
        /// ����Ȩ�����ù����б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridView_Opening(object sender, CancelEventArgs e)
        {
        }

        /// <summary>
        /// ����Ȩ�����ù����б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Print);
        }

    }
}
