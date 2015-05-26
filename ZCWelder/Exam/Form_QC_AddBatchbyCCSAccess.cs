using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;

namespace ZCWelder.Exam
{
    public partial class Form_QC_AddBatchbyCCSAccess : Form
    {
        private  DataTable myDataTable;
        private DataTable myDataTable_NotValid;

        public Form_QC_AddBatchbyCCSAccess()
        {
            InitializeComponent();
        }

        private void Form_QC_AddBatchbyCCSAccess_Load(object sender, EventArgs e)
        {

        }

        private void InitDataGridView()
        {
            OpenFileDialog myForm = new OpenFileDialog();
            myForm.Filter = "Access files (*.mdb)|*.mdb";
            myForm.RestoreDirectory = true;
            if (myForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string str_Conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + myForm.FileName + ";Persist Security Info=True";
            string str_SQL;
            str_SQL = "Select * From TB_Certificate_Info";
            DataTable myDataTable_Temp = new DataTable();
            OleDbDataAdapter myAdapter = new OleDbDataAdapter(str_SQL, str_Conn);
            myAdapter.Fill(myDataTable_Temp);

            this.myDataTable = myDataTable_Temp.Clone ();
            this.myDataTable_NotValid = myDataTable_Temp.Clone();
            bool bool_Valid;
            foreach (DataRow myDataRow in myDataTable_Temp.Rows )
            {
                bool_Valid = true;
                if (string.IsNullOrEmpty(myDataRow["CerNo"].ToString()))
                {
                    bool_Valid = false;
                }
                if (!Class_Student.ExistAndCanDeleteAndDelete(myDataRow["WelderMarkNo"].ToString(), Enum_zwjKindofUpdate.Exist))
                {
                    bool_Valid = false;
                }
                else
                {
                    if (Class_QC.ExistAndCanDeleteAndDelete(myDataRow["WelderMarkNo"].ToString(), Enum_zwjKindofUpdate.Exist))
                    {
                        bool_Valid = false;
                    }
                    else
                    {
                        if (Class_QC.ExistSecond(myDataRow["CerNo"].ToString(), null, Enum_zwjKindofUpdate.Add))
                        {
                            bool_Valid = false;
                        }
                        else
                        {
                        }
                    }
                }
                if (bool_Valid)
                {
                    this.myDataTable.ImportRow(myDataRow);
                }
                else
                {
                    this.myDataTable_NotValid .ImportRow(myDataRow);
                }
            }
            this.dataGridView_Data.DataSource = this.myDataTable;
            this.dataGridView_NotValid.DataSource = this.myDataTable_NotValid;
            this.label_Data.Text = string.Format("可以导入的数据，{0}", this.dataGridView_Data.RowCount );
            this.label_NotValid .Text = string.Format("不能导入的数据，{0}", this.dataGridView_NotValid .RowCount );
        }

        private void InitDataGridView2015()
        {
            OpenFileDialog myForm = new OpenFileDialog();
            myForm.Filter = "data files (*.data)|*.data|All files (*.*)|*.*";
            myForm.RestoreDirectory = true;
            if (myForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DataTable myDataTable_Temp = new DataTable();
            ADODB.Recordset rs = new ADODB.Recordset();
            rs.Open(myForm.FileName, Type.Missing, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, 0);
            OleDbDataAdapter myAdapter = new OleDbDataAdapter();
            myAdapter.Fill(myDataTable_Temp, rs);
            rs.Close();

            this.myDataTable = myDataTable_Temp.Clone();
            this.myDataTable_NotValid = myDataTable_Temp.Clone();
            bool bool_Valid;
            foreach (DataRow myDataRow in myDataTable_Temp.Rows)
            {
                bool_Valid = true;
                if (string.IsNullOrEmpty(myDataRow["CerNo"].ToString()))
                {
                    bool_Valid = false;
                }
                if (!Class_Student.ExistAndCanDeleteAndDelete(myDataRow["WelderMarkNo"].ToString(), Enum_zwjKindofUpdate.Exist))
                {
                    bool_Valid = false;
                }
                else
                {
                    if (Class_QC.ExistAndCanDeleteAndDelete(myDataRow["WelderMarkNo"].ToString(), Enum_zwjKindofUpdate.Exist))
                    {
                        bool_Valid = false;
                    }
                    else
                    {
                        if (Class_QC.ExistSecond(myDataRow["CerNo"].ToString(), null, Enum_zwjKindofUpdate.Add))
                        {
                            bool_Valid = false;
                        }
                        else
                        {
                        }
                    }
                }
                if (bool_Valid)
                {
                    this.myDataTable.ImportRow(myDataRow);
                }
                else
                {
                    this.myDataTable_NotValid.ImportRow(myDataRow);
                }
            }
            this.dataGridView_Data.DataSource = this.myDataTable;
            this.dataGridView_NotValid.DataSource = this.myDataTable_NotValid;
            this.label_Data.Text = string.Format("可以导入的数据，{0}", this.dataGridView_Data.RowCount);
            this.label_NotValid.Text = string.Format("不能导入的数据，{0}", this.dataGridView_NotValid.RowCount);
        }

        private void button_InitData_Click(object sender, EventArgs e)
        {
            this.InitDataGridView();
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TextBox_SupervisionPlace.Text))
            {
                MessageBox.Show("必须输入考察地点！");
                this.DialogResult = DialogResult.None;
                return;
            }
            if (this.myDataTable_NotValid.Rows.Count > 0)
            {
                if (MessageBox.Show("有数据不能导入，是否只导入合格的数据？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            Class_QC myClass_QC ;
            foreach (DataRow myDataRow in this.myDataTable.Rows)
            {
                myClass_QC = new Class_QC();
                myClass_QC.ExaminingNo = myDataRow["WelderMarkNo"].ToString();
                myClass_QC.CertificateNo  = myDataRow["CerNo"].ToString();
                myClass_QC.isQCValid = true;
                DateTime.TryParse(myDataRow["IssuedOn"].ToString(), out myClass_QC.IssuedOn);
                DateTime.TryParse(myDataRow["ValidDate"].ToString(), out myClass_QC.ValidUntil);
                if (myClass_QC.ValidUntil.Year - myClass_QC.IssuedOn.Year > 20)
                {
                    myClass_QC.OriginalPeriod = 100;
                }
                else
                {
                    myClass_QC.OriginalPeriod = myClass_QC.ValidUntil.Year - myClass_QC.IssuedOn.Year ;
                }
                myClass_QC.SupervisionPlace = this.TextBox_SupervisionPlace.Text ;
                myClass_QC.AddAndModify(Enum_zwjKindofUpdate.Add);
            }
        }

        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckedChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Data);

        }

        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true);

        }

        private void dataGridView_Data_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_DataGridViewRow;
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void toolStripMenuItem_NotValidRowFrozenThisColumn_CheckedChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_NotValid );

        }

        private void toolStripMenuItem_NotValidRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_NotValid , true, true);

        }

        private void dataGridView_NotValid_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_NotValidRow ;
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void button_InitData2015_Click(object sender, EventArgs e)
        {
            this.InitDataGridView2015();

        }
    }
}