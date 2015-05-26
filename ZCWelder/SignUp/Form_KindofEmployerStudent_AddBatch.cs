using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery;
using ZCWelder.Person;

namespace ZCWelder.SignUp
{
    public partial class Form_KindofEmployerStudent_AddBatch : Form
    {
        public int int_KindofEmployerIssueID;
        public bool bool_Updated = false;
        private DataTable myDataTable;
        
        public Form_KindofEmployerStudent_AddBatch()
        {
            InitializeComponent();
        }

        private void Form_KindofEmployerStudent_AddBatch_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.KindofEmployerWelder.ToString(), false);
            Class_KindofEmployerIssue myClass_KindofEmployerIssue = new Class_KindofEmployerIssue(this.int_KindofEmployerIssueID);
            this.TextBox_IssueNo.Text = myClass_KindofEmployerIssue.IssueNo  ;
            this.MaskedTextBox_KindofEmployerIssueID.Text = myClass_KindofEmployerIssue.KindofEmployerIssueID.ToString();
        }

        private void button_WelderAdd_Click(object sender, EventArgs e)
        {
            Form_KindofEmployerWelder_Query myForm = new Form_KindofEmployerWelder_Query();
            Class_KindofEmployerIssue myClass_KindofEmployerIssue = new Class_KindofEmployerIssue(this.int_KindofEmployerIssueID);
            myForm.str_KindofEmployer = myClass_KindofEmployerIssue.KindofEmployer;
            myForm.bool_QueryBatch = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                if (this.myDataTable == null)
                {
                    this.myDataTable = myForm.myDataTable;
                    this.dataGridView_Data.DataSource = new DataView(this.myDataTable);
                }
                else
                {
                    foreach (DataRow myDataRow in myForm.myDataTable.Rows)
                    {
                        if (this.myDataTable.Select(string.Format("KindofEmployerWelderID={0}", myDataRow["KindofEmployerWelderID"])).Length == 0)
                        {
                            this.myDataTable.ImportRow(myDataRow);
                        }
                    }
                }
                this.label_Data.Text = string.Format("学员，({0}):", this.myDataTable.Rows.Count);

            }

        }

        private void Button_SubjectQuery_Click(object sender, EventArgs e)
        {
            Class_KindofEmployerIssue myClass_KindofEmployerIssue = new Class_KindofEmployerIssue(this.int_KindofEmployerIssueID );
            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_KindofEmployerIssue.ShipClassificationAb);
            Form_WeldingSubject_Query myForm = new Form_WeldingSubject_Query();
            if (myClass_ShipClassification.WeldingStandardRestrict)
            {
                myForm.str_FilterRestrict = string.Format("WeldingStandard='{0}'", myClass_ShipClassification.WeldingStandard); ;
            }
            myForm.myClass_WeldingSubject = new Class_WeldingSubject();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.InitControlWeldingSubject(myForm.myClass_WeldingSubject);
            }
        }

        public void InitControlWeldingSubject(Class_WeldingSubject myClass_Subject)
        {
            this.TextBox_SubjectID.Text = myClass_Subject.SubjectID;
            this.TextBox_WeldingStandard.Text = myClass_Subject.WeldingStandard;
            this.TextBox_WeldingProject.Text = myClass_Subject.WeldingProject;
            this.TextBox_WeldingClass.Text = myClass_Subject.WeldingClass;
            this.TextBox_WorkPieceType.Text = myClass_Subject.WorkPieceType;
            this.TextBox_JointType.Text = myClass_Subject.JointType;
            this.TextBox_Subject.Text = myClass_Subject.Subject;
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (this.myDataTable == null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = "没有添加焊工！";
                return;
            }
            string str_ErrMessage;
            Class_KindofEmployerStudent myClass_KindofEmployerStudent;
            foreach (DataRow myDataRow in this.myDataTable.Rows)
            {
                myDataRow["WelderRemark"] = "";
                myClass_KindofEmployerStudent = new Class_KindofEmployerStudent();
                myClass_KindofEmployerStudent.KindofEmployerIssueID  = this.int_KindofEmployerIssueID ;
                myClass_KindofEmployerStudent.KindofEmployerWelderID =(int) myDataRow["KindofEmployerWelderID"];
                myClass_KindofEmployerStudent.ExamSubjectID  = this.TextBox_SubjectID.Text;
                if (Class_KindofEmployerStudent.ExistSecond(myClass_KindofEmployerStudent.KindofEmployerIssueID , myClass_KindofEmployerStudent.KindofEmployerWelderID , 0, Enum_zwjKindofUpdate.Add))
                {
                    myDataRow["WelderRemark"] = "学员不能重复！";
                }
                else
                {
                    str_ErrMessage = myClass_KindofEmployerStudent.CheckField();
                    if (string.IsNullOrEmpty(str_ErrMessage))
                    {
                        myClass_KindofEmployerStudent.AddAndModify(Enum_zwjKindofUpdate.Add);
                        this.bool_Updated = true;
                    }
                    else
                    {
                        myDataRow["WelderRemark"] = str_ErrMessage;
                    }
                }
            }
            DataRow[] myDataRowRange = this.myDataTable.Select("WelderRemark = '' or WelderRemark is null");
            if (myDataRowRange.Length < this.myDataTable.Rows.Count)
            {
                this.label_ErrMessage.Text = "有数据不合法！请查看备注信息";
                this.DialogResult = DialogResult.None;
            }
            foreach (DataRow myDataRow in myDataRowRange)
            {
                myDataRow.Delete();
            }
            this.myDataTable.AcceptChanges();
        }

        private void toolStripMenuItem_DataGridViewRowDelete_Click(object sender, EventArgs e)
        {
            DataRow myDataRow;
            myDataRow = this.myDataTable.Rows.Find(this.dataGridView_Data.CurrentRow.Cells["KindofEmployerWelderID"].Value);
            myDataRow.Delete();
            this.myDataTable.AcceptChanges();
        }

        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true);;

        }

        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Data);

        }

        private void dataGridView_Data_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_DataGridViewRow;
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
    }
}