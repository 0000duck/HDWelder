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

namespace ZCWelder.Exam
{
    public partial class Form_GXTheoryStudent_AddBatch : Form
    {
        public string str_IssueNo;
        public bool bool_Updated = false;
        private DataTable myDataTable;
        
        public Form_GXTheoryStudent_AddBatch()
        {
            InitializeComponent();
        }

        private void Form_GXTheoryStudent_AddBatch_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.Welder.ToString(), false);
            this.TextBox_IssueNo.Text = this.str_IssueNo;
            Class_GXTheoryIssue myClass_GXTheoryIssue = new Class_GXTheoryIssue(this.str_IssueNo);

            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_GXTheoryIssue.ShipClassificationAb);
            if (myClass_ShipClassification.ShipRestrict)
            {
                Class_Ship myClass_Ship = new Class_Ship(myClass_GXTheoryIssue.ShipboardNo);
                this.MaskedTextBox_ExaminingNo.Text = myClass_Ship.NextTheoryExaminingNo ;
            }
            else
            {
                this.MaskedTextBox_ExaminingNo.Text = myClass_ShipClassification.NextExaminingNo;
            }

        }

        private void button_WelderAdd_Click(object sender, EventArgs e)
        {
            Form_Welder_Query myForm = new Form_Welder_Query();
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
                        if (this.myDataTable.Select(string.Format("IdentificationCard='{0}'", myDataRow["IdentificationCard"])).Length == 0)
                        {
                            this.myDataTable.ImportRow(myDataRow);
                        }
                    }
                }
                this.label_Data.Text = string.Format("学员，({0}):", this.myDataTable.Rows.Count);

            }

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
            Class_GXTheoryStudent myClass_GXTheoryStudent;
            Class_GXTheoryIssue myClass_GXTheoryIssue = new Class_GXTheoryIssue(this.str_IssueNo);
            foreach (DataRow myDataRow in this.myDataTable.Rows)
            {
                myDataRow["WelderRemark"] = "";
                myClass_GXTheoryStudent = new Class_GXTheoryStudent();
                myClass_GXTheoryStudent.IssueNo = this.str_IssueNo;
                myClass_GXTheoryStudent.IdentificationCard = myDataRow["IdentificationCard"].ToString();
                myClass_GXTheoryStudent.ExamStatus = "顺利考试";
                myClass_GXTheoryStudent.KindofExam = myClass_GXTheoryIssue.KindofExam ;
                if (Class_GXTheoryStudent.ExistSecond(myClass_GXTheoryStudent.IssueNo, myClass_GXTheoryStudent.IdentificationCard, null, Enum_zwjKindofUpdate.Add))
                {
                    myDataRow["WelderRemark"] = "身份证号码不能重复！";
                }
                else
                {
                    str_ErrMessage = myClass_GXTheoryStudent.CheckField();
                    if (string.IsNullOrEmpty(str_ErrMessage))
                    {
                        if (!myClass_GXTheoryStudent.AddAndModify(Enum_zwjKindofUpdate.Add))
                        {
                            myDataRow["WelderRemark"] = "添加不成功，可能是考编号重复！";
                        }
                        else
                        {
                            this.bool_Updated = true;
                        }
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
            myDataRow = this.myDataTable.Rows.Find(this.dataGridView_Data.CurrentRow.Cells["IdentificationCard"].Value.ToString());
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