using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using System.Data.SqlClient;
using ZCWelder.ClassBase;
using ZCCL.Tools;

namespace ZCWelder.Exam
{
    public partial class Form_QC_AddBatch : Form
    {
        private DataTable myDataTable_Origin;
        private string str_IssueNo;
        private DataTable myDataTable_Modified;

        public Form_QC_AddBatch()
        {
            InitializeComponent();
        }

        private void Form_QC_AddBatch_Load(object sender, EventArgs e)
        {

        }

        
        public void InitDataGridView(DataTable myDataTable, string str_IssueNo)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Origin, Enum_DataTable.WelderStudentQC.ToString(), true);
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Modified, Enum_DataTable.WelderStudentQC.ToString(), false);

            if (this.myDataTable_Origin == null)
            {
                this.dataGridView_Origin.ReadOnly = false;
                this.dataGridView_Origin.Columns["Checked"].ReadOnly = false;
                myDataTable.AcceptChanges();
                this.myDataTable_Origin = myDataTable;
                if (this.myDataTable_Origin.Columns.Contains("Checked"))
                {
                    this.myDataTable_Origin.Columns.Remove("Checked");
                }
                DataColumn myDataColumn_Checked = new DataColumn("Checked");
                myDataColumn_Checked.DataType = System.Type.GetType("System.Boolean");
                myDataColumn_Checked.DefaultValue = true ;
                this.myDataTable_Origin.Columns.Add(myDataColumn_Checked);

                this.dataGridView_Origin.DataSource = new DataView(this.myDataTable_Origin);
                ((DataView)this.dataGridView_Origin.DataSource).Sort = "ExaminingNo";
                this.label_Origin.Text = string.Format("原始数据，({0})：", this.dataGridView_Origin .RowCount);

            }

            this.myDataTable_Modified = this.myDataTable_Origin.Clone ();
            this.dataGridView_Modified .DataSource = new DataView(this.myDataTable_Modified );
            ((DataView)this.dataGridView_Modified.DataSource).Sort = "ExaminingNo";
                
            this.str_IssueNo = str_IssueNo;
            Class_Issue myClass_Issue=new Class_Issue(this.str_IssueNo);
            this.TextBox_IssueNo .Text = myClass_Issue.IssueNo;
            this.TextBox_WeldingProcessAb.Text = myClass_Issue.WeldingProcessAb;
            if (myClass_Issue.IssueIssuedOn != DateTime.MinValue)
            {
                this.DateTimePicker_IssuedOn   .Value = myClass_Issue.IssueIssuedOn;
            }
            else if (Properties.Settings.Default.IssuedOn != DateTime.MinValue)
            {
                this.DateTimePicker_IssuedOn .Value = Properties.Settings.Default.IssuedOn;
            }
            string str_CertificateNo;
            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
            if (myClass_ShipClassification.ShipRestrict)
            {
                Class_Ship myClass_Ship = new Class_Ship(myClass_Issue.ShipboardNo);
                str_CertificateNo = myClass_Ship.NextCertificateNo;   
            }
            else
            {
                str_CertificateNo = myClass_ShipClassification.NextCertificateNo;   
            }
            this.MaskedTextBox_NextCertificateNo.Text=str_CertificateNo;

        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            this.InitDataGridView(this.myDataTable_Origin , this.str_IssueNo);

        }

        private void button_Modify_Click(object sender, EventArgs e)
        {
            if (this.myDataTable_Modified.Rows.Count > 0)
            {
                MessageBox.Show("请先重置后再进行填充操作！");
                return;

            }
            if(string.IsNullOrEmpty(this.MaskedTextBox_NextCertificateNo .Text))
            {
                MessageBox.Show("证号起始不能为空！");
                return;
            }
            if(string.IsNullOrEmpty(this.TextBox_SupervisionPlace.Text))
            {
                MessageBox.Show("考察地点不能为空！");
                return;
            }
            Class_Issue myClass_Issue=new Class_Issue(this.str_IssueNo);
            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
             Class_Ship myClass_Ship=new Class_Ship ();
            if (myClass_ShipClassification.ShipRestrict)
            {
                myClass_Ship = new Class_Ship(myClass_Issue.ShipboardNo);
            }
            DataRow myDataRow;
            DataRow myNewRow;
            DataView myDataView_Temp = new DataView(this.myDataTable_Origin);
            myDataView_Temp.RowFilter = "Checked = true and ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false) And CertificateNo is Null";
            myDataView_Temp.Sort = "ExaminingNo";
            foreach (DataRowView myDataRowView in myDataView_Temp)
            {
                //if (Class_QC.ExistAndCanDeleteAndDelete (this.MaskedTextBox_NextCertificateNo.Text, Enum_zwjKindofUpdate.Exist)) 
                //{
                //    MessageBox.Show("该证号已使用！");
                //    return;
                //}
                if (Class_QC.ExistSecond (this.MaskedTextBox_NextCertificateNo.Text,null, Enum_zwjKindofUpdate.Add ))
                {
                    MessageBox.Show("该证号已使用！");
                    return;
                } 
                
                myDataRow = myDataTable_Origin.Rows.Find(myDataRowView["ExaminingNo"].ToString());
                this.myDataTable_Modified .ImportRow(myDataRow);
                myNewRow = myDataTable_Modified.Rows.Find(myDataRowView["ExaminingNo"].ToString());
                myNewRow["CertificateNo"] = this.MaskedTextBox_NextCertificateNo.Text;
                myNewRow["SupervisionPlace"] = this.TextBox_SupervisionPlace.Text;
                myNewRow["OriginalPeriod"] = this.NumericUpDown_OriginalPeriod.Value;
                myNewRow["PeriodofValidity"] = this.NumericUpDown_OriginalPeriod.Value;
                myNewRow["IssuedOn"] = this.DateTimePicker_IssuedOn.Value;
                if (myClass_ShipClassification.ShipRestrict)
                {
                    this.MaskedTextBox_NextCertificateNo.Text =Class_Tools.GetNextSequence  (this.MaskedTextBox_NextCertificateNo.Text, myClass_Ship.CertificateNoSignificantDigit);
                }
                else
                {
                     this.MaskedTextBox_NextCertificateNo.Text =Class_Tools.GetNextSequence  (this.MaskedTextBox_NextCertificateNo.Text, myClass_ShipClassification.CertificateNoSignificantDigit);
                }
            }
            this.label_Modified.Text  = string.Format("新证书：({0})", this.dataGridView_Modified.RowCount);
            MessageBox.Show("填充完毕！");
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            Class_Issue myClass_Issue = new Class_Issue(this.str_IssueNo);
            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
            Class_Ship myClass_Ship = new Class_Ship();
            Class_TestCommittee myClass_TestCommittee = new Class_TestCommittee();
            if (myClass_ShipClassification.ShipRestrict)
            {
                myClass_Ship = new Class_Ship(myClass_Issue.ShipboardNo);
                myClass_TestCommittee.TestCommitteeID = myClass_Ship.TestCommitteeID;
            }
            else
            {
                myClass_TestCommittee.TestCommitteeID = myClass_ShipClassification.TestCommitteeID;
            }
            myClass_TestCommittee.FillData();

            Class_QC myClass_QC;
            DataView myDataView_Temp = new DataView(this.myDataTable_Modified);
            myDataView_Temp.Sort = "ExaminingNo";
            foreach (DataRowView myDataRowView in myDataView_Temp)
            {
                myClass_QC = new Class_QC();
                myClass_QC.ExaminingNo = myDataRowView["ExaminingNo"].ToString();
                myClass_QC.IssuedOn = (DateTime)myDataRowView["IssuedOn"];
                int.TryParse(myDataRowView["OriginalPeriod"].ToString(), out myClass_QC.OriginalPeriod);
                myClass_QC.PeriodofProlongation = 0;
                myClass_QC.QCSubjectID = myDataRowView["ExamSubjectID"].ToString();
                myClass_QC.SupervisionPlace = myDataRowView["SupervisionPlace"].ToString();
                myClass_QC.AddAndModify(Enum_zwjKindofUpdate.Add);
            }
            string str_RegistrationNoRange;
            str_RegistrationNoRange = string.Format("初始存档号码为：{0}\n下一个存档号码为：", myClass_TestCommittee.NextRegistrationNo);
            myClass_TestCommittee.FillData();
            str_RegistrationNoRange += myClass_TestCommittee.NextRegistrationNo;
            MessageBox.Show(str_RegistrationNoRange);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Origin, true, true);

        }

        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Origin);

        }

        private void dataGridView_Data_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_DataGridViewRow;
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void toolStripMenuItem_ModifiedRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Modified, true, true);

        }

        private void toolStripMenuItem_ModifiedRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Modified);

        }

        private void dataGridView_Modified_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_ModifiedRow;
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

    }
}