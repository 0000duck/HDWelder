using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;
using System.Data.SqlClient;
using ZCCL.DataGridViewManager;

namespace ZCWelder.SignUp
{
    public partial class Form_KindofEmployerWelder_Query : Form
    {
        public string str_KindofEmployer;
        public Class_KindofEmployerWelder myClass_KindofEmployerWelder;
        public bool bool_QueryBatch = false;
        public DataTable myDataTable;
   
        public Form_KindofEmployerWelder_Query()
        {
            InitializeComponent();
        }

        private void Form_KindofEmployerWelder_Query_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.KindofEmployerWelder.ToString(), false);
            DataGridViewCheckBoxColumn myDataGridViewColumn = new DataGridViewCheckBoxColumn();
            myDataGridViewColumn.HeaderText = "选中";
            myDataGridViewColumn.Name = "zwjQueryCheck";
            myDataGridViewColumn.DataPropertyName = "zwjQueryCheck";
            myDataGridViewColumn.Width = 40;
            myDataGridViewColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            myDataGridViewColumn.ReadOnly = false;
            this.dataGridView_Query.Columns.Insert(0, myDataGridViewColumn);
            this.dataGridView_Query.ReadOnly = !bool_QueryBatch;
            this.checkBox_CheckAll.Visible = bool_QueryBatch;
           
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.KindofEmployerWelder.ToString()];
            myClass_Data.SetFilter(string.Format("KindofEmployer='{0}'", this.str_KindofEmployer));
            myClass_Data.RefreshData(false );
            this.myDataTable = myClass_Data.myDataTable.Copy();
            this.dataGridView_Query.DataSource = new DataView(this.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
           
            if (bool_QueryBatch)
            {
                DataColumn myDataColumn = new DataColumn("zwjQueryCheck");
                myDataColumn.DataType = System.Type.GetType("System.Boolean");
                myDataTable.Columns.Add(myDataColumn);
            }

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (bool_QueryBatch)
            {
                DataView myDataView = new DataView(myDataTable);
                myDataView.RowFilter = "zwjQueryCheck=true";
                myDataTable = myDataView.ToTable();

                DataColumn[] keys = new DataColumn[1];
                keys[0] = this.myDataTable.Columns["KindofEmployerWelderID"];
                this.myDataTable.PrimaryKey = keys;
            }
            else
            {
                if (this.dataGridView_Query.CurrentRow == null)
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "请选择一条记录！";
                    return;
                }
                myClass_KindofEmployerWelder.KindofEmployerWelderID = (int)this.dataGridView_Query.CurrentRow.Cells["KindofEmployerWelderID"].Value;
                myClass_KindofEmployerWelder.FillData();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = string.Format("KindofEmployer='{0}'", this.str_KindofEmployer );
            if (this.textBox_WelderName .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WelderName like '%{0}%'", this.textBox_WelderName.Text);
            }
            if (this.TextBox_IdentificationCard .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And IdentificationCard like '%{0}%'", this.TextBox_IdentificationCard .Text);
            }
            if (this.TextBox_WorkerID  .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WelderWorkerID like '%{0}%'", this.TextBox_WorkerID .Text);
            }
            ((DataView)this.dataGridView_Query.DataSource).RowFilter = str_Filter;

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Form_KindofEmployerWelder_Update myForm = new Form_KindofEmployerWelder_Update();
            myForm.myClass_KindofEmployerWelder = new Class_KindofEmployerWelder();
            myForm.myClass_KindofEmployerWelder.KindofEmployer = this.str_KindofEmployer;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.KindofEmployerWelder.ToString()];
                myClass_Data.SetFilter(string.Format("KindofEmployer='{0}'", this.str_KindofEmployer));
                myClass_Data.RefreshData(false);
                this.myDataTable = myClass_Data.myDataTable.Copy();
                this.dataGridView_Query.DataSource = new DataView(this.myDataTable);
                ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
                if (bool_QueryBatch)
                {
                    DataColumn myDataColumn = new DataColumn("zwjQueryCheck");
                    myDataColumn.DataType = System.Type.GetType("System.Boolean");
                    myDataTable.Columns.Add(myDataColumn);
                }
                ((DataView)this.dataGridView_Query.DataSource).RowFilter=string.Format("KindofEmployerWelderID={0}", myForm.myClass_KindofEmployerWelder.KindofEmployerWelderID);
            }

        }

        private void button_QueryFilter_Click(object sender, EventArgs e)
        {
            Form_QueryFilter myForm = new Form_QueryFilter();
            myForm.InitControl(Enum_DataTable.KindofEmployerWelder .ToString());
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                ((DataView)this.dataGridView_Query.DataSource).RowFilter = myForm.str_Filter;
            }

        }

        private void checkBox_CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.myDataTable == null)
            {
                return;
            }
            foreach (DataRow myDataRow in this.myDataTable.Rows)
            {
                myDataRow["zwjQueryCheck"] =false;
            }
            foreach (DataGridViewRow myDataGridViewRow in this.dataGridView_Query.Rows )
            {
                myDataGridViewRow.Cells["zwjQueryCheck"].Value  = this.checkBox_CheckAll.Checked;
            }
            this.dataGridView_Query.CurrentCell = null;

        }
    }
}