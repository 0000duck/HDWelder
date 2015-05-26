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
using ZCWelder.SignUp;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_KindofEmployerIssue_DataGridView : UserControl
    {
        private DataTable myDataTable;
        private DataView myDataView;
        private EventArgs_KindofEmployer myEventArgs_KindofEmployer;

        public UserControl_KindofEmployerIssue_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_Template_DataGridView_Load(object sender, EventArgs e)
        {
            if (Class_zwjPublic.mysplitContainerHeadBackColor != Color.Empty)
            {
                this.splitContainer1.Panel1.BackColor = Class_zwjPublic.mysplitContainerHeadBackColor;
            }
            if (Class_zwjPublic.mysplitContainerHeadForeColor != Color.Empty)
            {
                this.splitContainer1.Panel1.ForeColor = Class_zwjPublic.mysplitContainerHeadForeColor;
            }
            Publisher_KindofEmployer.EventName += new EventHandler_KindofEmployer(InitDataGridView);

        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_KindofEmployer e)
        {
            this.myEventArgs_KindofEmployer = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.KindofEmployerIssue.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.KindofEmployerIssue.ToString()];
            myClass_Data.SetFilter(string.Format("KindofEmployer='{0}'", this.myEventArgs_KindofEmployer.str_KindofEmployer));
            if (this.myEventArgs_KindofEmployer.bool_JustFill)
            {
                if (this.myDataTable.Rows.Count == 0)
                {
                    this.dataGridView_Data.DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_KindofEmployer.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_Data.DataSource = this.myDataView;
                }
                else
                {
                    myClass_Data.RefreshData(this.myEventArgs_KindofEmployer.bool_JustFill, this.myDataTable);
                }
            }
            else
            {
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_KindofEmployer.bool_JustFill);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.myDataView = new DataView(this.myDataTable);
                this.dataGridView_Data.DataSource = this.myDataView;
            }
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            this.label_Data.Text = string.Format("������λ�༶��Ϣ��({0})��", this.dataGridView_Data.RowCount);
            if (this.dataGridView_Data.Rows.Count == 0)
            {
                EventArgs_KindofEmployerIssue myEventArgs_KindofEmployerIssue = new EventArgs_KindofEmployerIssue();
                myEventArgs_KindofEmployerIssue.int_KindofEmployerIssueID = 0;
                Publisher_KindofEmployerIssue.OnEventName(myEventArgs_KindofEmployerIssue);
            }

        }

        /// <summary>
        /// ˢ������
        /// </summary>
        /// <param name="bool_JustFill">true-ֻ��Ӻ��޸����ݣ�false-ˢ��ȫ������</param>
        private void RefreshData(bool bool_JustFill)
        {
            this.myEventArgs_KindofEmployer.bool_JustFill = bool_JustFill;
            Publisher_KindofEmployer.OnEventName(this.myEventArgs_KindofEmployer);

        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_KindofEmployer == null)
            {
                return;
            }
            Form_KindofEmployerIssue_Update myForm = new Form_KindofEmployerIssue_Update();
            myForm.myClass_KindofEmployerIssue = new Class_KindofEmployerIssue();
            myForm.myClass_KindofEmployerIssue.KindofEmployer = this.myEventArgs_KindofEmployer.str_KindofEmployer;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
                Class_DataControlBind.SetDataGridViewSelectedPosition("KindofEmployerIssueID", myForm.myClass_KindofEmployerIssue.KindofEmployerIssueID.ToString(), this.dataGridView_Data);
            }

        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_KindofEmployerIssue_Update myForm = new Form_KindofEmployerIssue_Update();
            myForm.myClass_KindofEmployerIssue  = new Class_KindofEmployerIssue();
            myForm.myClass_KindofEmployerIssue.KindofEmployerIssueID =(int) this.dataGridView_Data.CurrentRow.Cells["KindofEmployerIssueID"].Value;
            if (myForm.myClass_KindofEmployerIssue.FillData())
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
            if (Class_KindofEmployerIssue.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerIssueID"].Value, Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("ȷ��ɾ����", "ȷ�ϴ���", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_KindofEmployerIssue.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerIssueID"].Value, Enum_zwjKindofUpdate.Delete);
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
            if (this.myEventArgs_KindofEmployer == null)
            {
                e.Cancel = true;
                return;
            }

            //this.toolStripMenuItem_DataGridViewAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Add);
        }

        /// <summary>
        /// ����Ȩ�����ù����б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            if (this.myEventArgs_KindofEmployer == null)
            {
                e.Cancel = true;
                return;
            }
            //this.toolStripMenuItem_DataGridViewRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Add);
            //this.toolStripMenuItem_DataGridViewRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Modify);
            //this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Delete);
            //this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Print);
            this.toolStripMenuItem_RowTransferGXTheoryIssue.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Print);
            this.toolStripMenuItem_RowTransferIssue.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Print);
        }

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            EventArgs_KindofEmployerIssue myEventArgs_KindofEmployerIssue = new EventArgs_KindofEmployerIssue();
            myEventArgs_KindofEmployerIssue.int_KindofEmployerIssueID = (int)this.dataGridView_Data.Rows[e.RowIndex].Cells["KindofEmployerIssueID"].Value;
            Publisher_KindofEmployerIssue.OnEventName(myEventArgs_KindofEmployerIssue);

        }

        private void toolStripMenuItem_RowTransferIssue_Click(object sender, EventArgs e)
        {
            bool bool_Transfer = false;
            int int_CheckSignUp= Class_KindofEmployerIssue.CheckSignUp((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerIssueID"].Value,false );
           
            if (Properties.Settings.Default.WebServiceStartUp)
            {
                DataView myDataView_Temp = new DataView(Class_KindofEmployerIssue.GetDataTable_KindofEmployerWelderStudent((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerIssueID"].Value, "StudentRemark is Null or StudentRemark=''", null));
                foreach (DataRowView myDataRowView in myDataView_Temp)
                {
                    if (!Class_Welder.ExistWelderPicture(myDataRowView["IdentificationCard"].ToString()))
                    {
                        int_CheckSignUp++;
                        Class_KindofEmployerStudent myClass_KindofEmployerStudent = new Class_KindofEmployerStudent((int)myDataRowView["KindofEmployerStudentID"]);
                        myClass_KindofEmployerStudent.StudentRemark = "�ú���û�е�����Ƭ";
                        myClass_KindofEmployerStudent.AddAndModify(Enum_zwjKindofUpdate.Modify);
                    }
                }
            }

            if (int_CheckSignUp > 0)
            {
                if (MessageBox.Show(string.Format("�ð༶�� {0} ��ѧԱ�����ϱ����ʸ���ϸ��Ϣ�����ѧԱ�ı�ע�ֶΡ�ȷ�ϰ�ֻ���б����ʸ��ѧԱ����༶��", int_CheckSignUp), "ȷ�ϴ���", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    bool_Transfer = true;
                }
            }
            else
            {
                if (MessageBox.Show("ȷ�ϱ���༶��", "ȷ�ϴ���", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    bool_Transfer = true;
                }
            }
            if (bool_Transfer)
            {
                string str_IssueNo = Class_KindofEmployerIssue.TransferIssue((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerIssueID"].Value);
                if (string.IsNullOrEmpty(str_IssueNo))
                {
                    MessageBox.Show("�����°༶ʧ�ܣ���������һ���༶��Ż��Ա�����ô���");
                }
                else
                {
                    MessageBox.Show(string.Format("�°༶���Ϊ {0} ������뿼�Թ�������ѯ��ϸ��Ϣ��",str_IssueNo));
                }
            }
            EventArgs_KindofEmployerIssue myEventArgs_KindofEmployerIssue = new EventArgs_KindofEmployerIssue();
            myEventArgs_KindofEmployerIssue.int_KindofEmployerIssueID = (int)this.dataGridView_Data.CurrentRow .Cells["KindofEmployerIssueID"].Value;
            Publisher_KindofEmployerIssue.OnEventName(myEventArgs_KindofEmployerIssue);
        }

        private void toolStripMenuItem_RowTransferGXTheoryIssue_Click(object sender, EventArgs e)
        {
            bool bool_Transfer = false;
            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(this.dataGridView_Data.CurrentRow.Cells["ShipClassificationAb"].Value.ToString());
            if (myClass_ShipClassification.ShipRestrict && myClass_ShipClassification.TheorySeparate)
            {
                if (!Class_ShipandShipClassification.ExistAndCanDeleteAndDelete(myClass_ShipClassification.ShipClassificationAb ,this.dataGridView_Data.CurrentRow.Cells["ShipboardNo"].Value.ToString(), Enum_zwjKindofUpdate.Exist ))
                {
                    MessageBox.Show("���༶���������۰༶�������������������ô�����ʹ���ϵ���ֶ���Ϣ��");
                    return;
                }
            }
            else
            {
                MessageBox.Show("���༶���������۰༶�������������������ô�����ʹ���ϵ���ֶ���Ϣ��");
                return;
            }
            
            int int_CheckSignUp= Class_KindofEmployerIssue.CheckSignUp((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerIssueID"].Value,true );

            if (Properties.Settings.Default.WebServiceStartUp)
            {
                DataView myDataView_Temp = new DataView(Class_KindofEmployerIssue.GetDataTable_KindofEmployerWelderStudent((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerIssueID"].Value, "StudentRemark is Null or StudentRemark=''", null));
                foreach (DataRowView myDataRowView in myDataView_Temp)
                {
                    if (!Class_Welder.ExistWelderPicture(myDataRowView["IdentificationCard"].ToString()))
                    {
                        int_CheckSignUp++;
                        Class_KindofEmployerStudent myClass_KindofEmployerStudent = new Class_KindofEmployerStudent((int)myDataRowView["KindofEmployerStudentID"]);
                        myClass_KindofEmployerStudent.StudentRemark = "�ú���û�е�����Ƭ";
                        myClass_KindofEmployerStudent.AddAndModify(Enum_zwjKindofUpdate.Modify);
                    }
                }
            }
            
            if (int_CheckSignUp > 0)
            {
                if (MessageBox.Show(string.Format("�ð༶�� {0} ��ѧԱ�����ϱ����ʸ���ϸ��Ϣ�����ѧԱ�ı�ע�ֶΡ�ȷ�ϰ�ֻ���б����ʸ��ѧԱ����༶��", int_CheckSignUp), "ȷ�ϴ���", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    bool_Transfer = true;
                }
            }
            else
            {
                if (MessageBox.Show("ȷ�ϱ���༶��", "ȷ�ϴ���", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    bool_Transfer = true;
                }
            }

            if (bool_Transfer)
            {
                string str_IssueNo = Class_KindofEmployerIssue.TransferGXTheoryIssue((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerIssueID"].Value);
                if (string.IsNullOrEmpty(str_IssueNo))
                {
                    MessageBox.Show("���������۰༶ʧ�ܣ���������һ�����۰༶��Ż����ۿ��Ա�����ô���");
                }
                else
                {
                    MessageBox.Show(string.Format("�����۰༶���Ϊ {0} ������뿼�Թ�������ѯ��ϸ��Ϣ��", str_IssueNo));
                }
            }
            EventArgs_KindofEmployerIssue myEventArgs_KindofEmployerIssue = new EventArgs_KindofEmployerIssue();
            myEventArgs_KindofEmployerIssue.int_KindofEmployerIssueID = (int)this.dataGridView_Data.CurrentRow .Cells["KindofEmployerIssueID"].Value;
            Publisher_KindofEmployerIssue.OnEventName(myEventArgs_KindofEmployerIssue);

        }

    }
}
