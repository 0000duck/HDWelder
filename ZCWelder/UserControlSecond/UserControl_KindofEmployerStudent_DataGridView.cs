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
using ZCCL.Tools;
using ZCWelder.Exam;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_KindofEmployerStudent_DataGridView : UserControl
    {
        private EventArgs_KindofEmployerIssue myEventArgs_KindofEmployerIssue;
        private DataTable myDataTable;
        private DataView myDataView;
        /// <summary>
        /// ���ڱ���༶���ܵ�Ĭ�ϰ༶���
        /// </summary>
        private  string str_IssueNo = "";

        public UserControl_KindofEmployerStudent_DataGridView()
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
            Publisher_KindofEmployerIssue.EventName += new EventHandler_KindofEmployerIssue(InitDataGridView);

        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_KindofEmployerIssue e)
        {
            this.myEventArgs_KindofEmployerIssue = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.KindofEmployerStudent.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.KindofEmployerStudent.ToString()];
            myClass_Data.SetFilter(string.Format("KindofEmployerIssueID={0}", this.myEventArgs_KindofEmployerIssue.int_KindofEmployerIssueID ));
            if (this.myEventArgs_KindofEmployerIssue.bool_JustFill)
            {
                if (this.myDataTable.Rows.Count == 0)
                {
                    this.dataGridView_Data.DataSource = null;
                    myClass_Data.RefreshData(this.myEventArgs_KindofEmployerIssue.bool_JustFill);
                    this.myDataTable = myClass_Data.myDataTable.Copy();
                    this.myDataView = new DataView(this.myDataTable);
                    this.dataGridView_Data.DataSource = this.myDataView;
                }
                else
                {
                    myClass_Data.RefreshData(this.myEventArgs_KindofEmployerIssue.bool_JustFill, this.myDataTable);
                }
            }
            else
            {
                this.dataGridView_Data.DataSource = null;
                myClass_Data.RefreshData(this.myEventArgs_KindofEmployerIssue.bool_JustFill);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.myDataView = new DataView(this.myDataTable);
                this.dataGridView_Data.DataSource = this.myDataView;
            }
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }

            this.label_Data.Text = string.Format("�༶���Ϊ {0} ��ѧԱ��Ϣ��({1})��",this.myEventArgs_KindofEmployerIssue.int_KindofEmployerIssueID , this.dataGridView_Data.RowCount);
            if (this.dataGridView_Data.RowCount == 0)
            {
                this.userControl_WelderExamBase1.InitDataGridView(null);
            }
        }

        /// <summary>
        /// ˢ������
        /// </summary>
        /// <param name="bool_JustFill">true-ֻ��Ӻ��޸����ݣ�false-ˢ��ȫ������</param>
        private void RefreshData(bool bool_JustFill)
        {
            this.myEventArgs_KindofEmployerIssue.bool_JustFill = bool_JustFill;
            Publisher_KindofEmployerIssue.OnEventName(this.myEventArgs_KindofEmployerIssue);

        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_KindofEmployerIssue  == null || this.myEventArgs_KindofEmployerIssue.int_KindofEmployerIssueID<=0)
            {
                return;
            }
            Form_KindofEmployerStudent_Update myForm = new Form_KindofEmployerStudent_Update();
            myForm.myClass_KindofEmployerStudent  = new Class_KindofEmployerStudent();
            myForm.myClass_KindofEmployerStudent.KindofEmployerIssueID = this.myEventArgs_KindofEmployerIssue.int_KindofEmployerIssueID;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshData(true);
                Class_DataControlBind.SetDataGridViewSelectedPosition("KindofEmployerStudentID", myForm.myClass_KindofEmployerStudent.KindofEmployerStudentID.ToString(), this.dataGridView_Data);
            }

        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowModify_Click(object sender, EventArgs e)
        {
            Form_KindofEmployerStudent_Update myForm = new Form_KindofEmployerStudent_Update();
            myForm.myClass_KindofEmployerStudent = new Class_KindofEmployerStudent();
            myForm.myClass_KindofEmployerStudent.KindofEmployerStudentID = (int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerStudentID"].Value;
            if (myForm.myClass_KindofEmployerStudent.FillData())
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
            if (Class_KindofEmployerStudent.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerStudentID"].Value, Enum_zwjKindofUpdate.CanDelete))
            {
                if (MessageBox.Show("ȷ��ɾ����", "ȷ�ϴ���", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Class_KindofEmployerStudent.ExistAndCanDeleteAndDelete((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerStudentID"].Value, Enum_zwjKindofUpdate.Delete);
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
            if (this.myEventArgs_KindofEmployerIssue == null)
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
            if (this.myEventArgs_KindofEmployerIssue == null)
            {
                e.Cancel = true;
                return;
            }
            //this.toolStripMenuItem_DataGridViewRowAdd.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Add);
            //this.toolStripMenuItem_DataGridViewRowModify.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Modify);
            //this.toolStripMenuItem_DataGridViewRowDelete.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Delete);
            //this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Print);
      
            this.toolStripMenuItem_RowTransferToGXTheoryIssue.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Print);
            this.toolStripMenuItem_RowTransferToIssue.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("����Ȩ��"), Enum_zwjKindofUpdate.Print);
        }

        private void toolStripMenuItem_RowTransferToIssue_Click(object sender, EventArgs e)
        {
            //Form_InputBox myForm = new Form_InputBox();
            //myForm.str_DefaultResponse = this.str_IssueNo;
            //myForm.str_Prompt = "������༶��ţ�";
            //myForm.str_Title = "����༶���";
            //if (myForm.ShowDialog() == DialogResult.OK)
            //{
            //    this.str_IssueNo = myForm.str_DefaultResponse;
            //}
            //else
            //{
            //    return;
            //}
            Form_Issue_Query myForm = new Form_Issue_Query();
            myForm.myClass_Issue = new Class_Issue();
            if (!string.IsNullOrEmpty(this.str_IssueNo ))
            {
                myForm.myClass_Issue.IssueNo = this.str_IssueNo ;
                myForm.myClass_Issue.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.str_IssueNo = myForm.myClass_Issue.IssueNo;
            }
            else
            {
                return;
            }

            if (Class_Issue.ExistAndCanDeleteAndDelete(this.str_IssueNo, Enum_zwjKindofUpdate.Exist))
            {
                Class_KindofEmployerStudent myClass_KindofEmployerStudent = new Class_KindofEmployerStudent((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerStudentID"].Value);
                Class_KindofEmployerWelder myClass_KindofEmployerWelder=new Class_KindofEmployerWelder(myClass_KindofEmployerStudent.KindofEmployerWelderID);
                Class_Student myClass_Student = new Class_Student();
                myClass_Student.IssueNo = this.str_IssueNo;
                myClass_Student.IdentificationCard = myClass_KindofEmployerWelder.IdentificationCard;
                myClass_Student.SubjectID = myClass_KindofEmployerStudent.ExamSubjectID;
                Class_Issue myClass_Issue = new Class_Issue(myClass_Student.IssueNo);
                myClass_Student.myClass_WeldingParameter = myClass_Issue.myClass_WeldingParameter;
                myClass_Student.myClass_WeldingParameter.KindofExam = myClass_KindofEmployerStudent.StudentKindofExam;
                Class_KindofEmployerIssue myClass_KindofEmployerIssue = new Class_KindofEmployerIssue(myClass_KindofEmployerStudent.KindofEmployerIssueID);
                myClass_Student.WPSNo = myClass_KindofEmployerIssue.IssueWPSNo;
                string str_ReturnMessage;
                str_ReturnMessage = myClass_Student.CheckField();
                if (string.IsNullOrEmpty(str_ReturnMessage))
                {
                    Class_KindofEmployerWelder.TransferWelder(myClass_KindofEmployerStudent.KindofEmployerWelderID);
                    myClass_Student.AddAndModify(Enum_zwjKindofUpdate.Add);
                    if (string.IsNullOrEmpty(myClass_Student.ExaminingNo))
                    {
                         MessageBox.Show("����༶ʧ�ܣ���������һ����������ô���");
                    }
                    else
                    {
                        Class_KindofEmployerStudent.ExistAndCanDeleteAndDelete(myClass_KindofEmployerStudent.KindofEmployerStudentID, Enum_zwjKindofUpdate.Delete);
                        this.myEventArgs_KindofEmployerIssue.bool_JustFill = false;
                        Publisher_KindofEmployerIssue.OnEventName(this.myEventArgs_KindofEmployerIssue);
                        MessageBox.Show(string.Format("����༶�ɹ����༶���Ϊ {0}�������Ϊ {1}", this.str_IssueNo, myClass_Student.ExaminingNo));
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("����༶ʧ�ܣ�{0}��", str_ReturnMessage));
                }
            }
            else
            {
                MessageBox.Show(string.Format("�����ڰ༶���Ϊ {0} �İ༶!", this.str_IssueNo));
            }

            
        }

        private void toolStripMenuItem_RowTransferToGXTheoryIssue_Click(object sender, EventArgs e)
        {
            Form_GXTheoryIssue_Query myForm = new Form_GXTheoryIssue_Query();
            myForm.myClass_GXTheoryIssue = new Class_GXTheoryIssue();
            if (!string.IsNullOrEmpty(this.str_IssueNo))
            {
                myForm.myClass_GXTheoryIssue.IssueNo = this.str_IssueNo;
                myForm.myClass_GXTheoryIssue.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.str_IssueNo = myForm.myClass_GXTheoryIssue.IssueNo;
            }
            else
            {
                return;
            }

            if (Class_GXTheoryIssue.ExistAndCanDeleteAndDelete(this.str_IssueNo, Enum_zwjKindofUpdate.Exist))
            {
                Class_KindofEmployerStudent myClass_KindofEmployerStudent = new Class_KindofEmployerStudent((int)this.dataGridView_Data.CurrentRow.Cells["KindofEmployerStudentID"].Value);
                Class_KindofEmployerWelder myClass_KindofEmployerWelder = new Class_KindofEmployerWelder(myClass_KindofEmployerStudent.KindofEmployerWelderID);
                Class_GXTheoryStudent myClass_GXTheoryStudent = new Class_GXTheoryStudent();
                myClass_GXTheoryStudent.IssueNo = this.str_IssueNo;
                myClass_GXTheoryStudent.IdentificationCard = myClass_KindofEmployerWelder.IdentificationCard;
                myClass_GXTheoryStudent.SubjectID = myClass_KindofEmployerStudent.ExamSubjectID ;
                Class_GXTheoryIssue myClass_GXTheoryIssue = new Class_GXTheoryIssue(myClass_GXTheoryStudent.IssueNo);
                myClass_GXTheoryStudent.KindofExam = myClass_GXTheoryIssue.KindofExam;
                string str_ReturnMessage ;
                str_ReturnMessage = myClass_GXTheoryStudent.CheckField();
                if (string.IsNullOrEmpty(str_ReturnMessage))
                {
                    Class_KindofEmployerWelder.TransferWelder(myClass_KindofEmployerStudent.KindofEmployerWelderID);
                    myClass_GXTheoryStudent.AddAndModify(Enum_zwjKindofUpdate.Add);
                    if (string.IsNullOrEmpty(myClass_GXTheoryStudent.ExaminingNo))
                    {
                        MessageBox.Show("�������۰༶ʧ�ܣ���������һ�����ۿ�������ô���");
                    }
                    else
                    {
                        Class_KindofEmployerStudent.ExistAndCanDeleteAndDelete(myClass_KindofEmployerStudent.KindofEmployerStudentID, Enum_zwjKindofUpdate.Delete);
                        this.myEventArgs_KindofEmployerIssue.bool_JustFill = false;
                        Publisher_KindofEmployerIssue.OnEventName(this.myEventArgs_KindofEmployerIssue);
                        MessageBox.Show(string.Format("����༶�ɹ������۰༶���Ϊ {0}�����ۿ����Ϊ {1}", this.str_IssueNo, myClass_GXTheoryStudent.ExaminingNo));
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("�������۰༶ʧ�ܣ�{0}��", str_ReturnMessage));
                }
            }
            else
            {
                MessageBox.Show(string.Format("���������۰༶���Ϊ {0} �İ༶!", this.str_IssueNo));
            }
        }

        private void toolStripMenuItem_RowViewExam_Click(object sender, EventArgs e)
        {
            StringBuilder str_Filter = new StringBuilder();
            str_Filter.Append("1=0");
            foreach (DataGridViewRow myDataGridViewRow in this.dataGridView_Data.Rows)
            {
                str_Filter.Append(string.Format(" Or IdentificationCard='{0}'", myDataGridViewRow.Cells["IdentificationCard"].Value));
            }
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ExamAll.ToString()];
            myClass_Data.SetFilter(str_Filter.ToString());
            myClass_Data.RefreshData(false);
            ZCCL.Tools.Form_DataView myForm = new ZCCL.Tools.Form_DataView();
            myForm.InitDataGridView("���Լ�¼", new DataView(myClass_Data.myDataTable.Copy()), Enum_DataTable.WelderIssueStudentQCRegistrationNo.ToString());
            myForm.ShowDialog();

        }

        private void toolStripMenuItem_RowStudentAddBatch_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_KindofEmployerIssue  == null)
            {
                return;
            }
            Form_KindofEmployerStudent_AddBatch myForm = new Form_KindofEmployerStudent_AddBatch();
            myForm.int_KindofEmployerIssueID  = this.myEventArgs_KindofEmployerIssue.int_KindofEmployerIssueID ;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
            }
            if (myForm.bool_Updated)
            {
                this.RefreshData(true);
            }

        }

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.userControl_WelderExamBase1.InitDataGridView(this.dataGridView_Data.Rows[e.RowIndex].Cells["IdentificationCard"].Value.ToString());
        }

    }
}
