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

namespace ZCWelder.Person
{
    public partial class Form_Welder_Query : Form
    {
        public Class_Welder myClass_Welder;
        public bool bool_QueryBatch = false;
        public DataTable myDataTable;
   
        public Form_Welder_Query()
        {
            InitializeComponent();
        }

        private void Form_Welder_Query_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.Welder.ToString(),this.bool_QueryBatch );
            this.dataGridView_Query.ReadOnly = !bool_QueryBatch;
            this.checkBox_CheckAll.Visible = bool_QueryBatch;
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (bool_QueryBatch)
            {
                if (this.myDataTable == null)
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "请选择一条记录！";
                    return;
                }
                DataView myDataView = new DataView(myDataTable);
                myDataView.RowFilter = "Checked=true";
                if (myDataView.Count  == 0)
                {
                    this.DialogResult = DialogResult.None;
                    this.label_ErrMessage.Text = "请选择一条记录！";
                    return;
                }

                this.myDataTable = myDataView.ToTable();
                DataColumn[] keys = new DataColumn[1];
                keys[0] = this.myDataTable.Columns["IdentificationCard"];
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
                myClass_Welder.IdentificationCard = this.dataGridView_Query.CurrentRow.Cells["IdentificationCard"].Value.ToString();
                myClass_Welder.FillData();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void checkBox_CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.myDataTable == null)
            {
                return;
            }
            foreach (DataRow myDataRow in this.myDataTable.Rows )
            {
                myDataRow["Checked"] = this.checkBox_CheckAll.Checked;
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            SqlCommand myCmd_Temp = new SqlCommand("Person_Welder_Query", Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = ZCCL.Tools.Class_DataValidateTool.CovertIdentificationCard(this.TextBox_IdentificationCard .Text );
            myCmd_Temp.Parameters.Add("@WelderName", SqlDbType.NVarChar, 10).Value = this.textBox_WelderName .Text ;
            myCmd_Temp.Parameters.Add("@WelderWorkerID", SqlDbType.NVarChar, 10).Value =this.TextBox_WorkerID.Text ;
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCmd_Temp);
            this. myDataTable = new DataTable();
            myAdapter.Fill(myDataTable);
            this.dataGridView_Query.DataSource = new DataView(myDataTable);

            if (bool_QueryBatch)
            {
                DataColumn myDataColumn = new DataColumn("Checked");
                myDataColumn.DataType = System.Type.GetType("System.Boolean");
                myDataColumn.DefaultValue = true;
                myDataTable.Columns.Add(myDataColumn);
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Form_Welder_Update myForm = new Form_Welder_Update();
            myForm.myClass_Welder = new Class_Welder();
            myForm.myClass_Welder.IdentificationCard = this.TextBox_IdentificationCard.Text;
            myForm.myClass_Welder.WelderName = this.textBox_WelderName.Text;
            myForm.myClass_Welder.myClass_BelongUnit.WorkerID = this.TextBox_WorkerID.Text;
            myForm.bool_Add = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                SqlCommand myCmd_Temp = new SqlCommand("Person_Welder_Query", Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.CommandType = CommandType.StoredProcedure;
                myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = myForm.myClass_Welder.IdentificationCard;
                SqlDataAdapter myAdapter = new SqlDataAdapter(myCmd_Temp);
                DataTable myDataTable = new DataTable();
                myAdapter.Fill(myDataTable);
                this.dataGridView_Query.DataSource = new DataView(myDataTable);
                if (bool_QueryBatch)
                {
                    DataColumn myDataColumn = new DataColumn("Checked");
                    myDataColumn.DataType = System.Type.GetType("System.Boolean");
                    myDataColumn.DefaultValue = true;
                    myDataTable.Columns.Add(myDataColumn);
                }
            }
        }

        private void button_QueryFilter_Click(object sender, EventArgs e)
        {
            Form_QueryFilter myForm = new Form_QueryFilter();
            myForm.InitControl(Enum_DataTable.Welder.ToString());
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                SqlCommand myCmd_Temp = new SqlCommand("Person_Welder_Query", Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.CommandType = CommandType.StoredProcedure;
                myCmd_Temp.Parameters.Add("@Filter", SqlDbType.NVarChar, 4000).Value = myForm.str_Filter;
                SqlDataAdapter myAdapter = new SqlDataAdapter(myCmd_Temp);
                this.myDataTable = new DataTable();
                myAdapter.Fill(myDataTable);
                this.dataGridView_Query.DataSource = new DataView(myDataTable);

                if (bool_QueryBatch)
                {
                    DataColumn myDataColumn = new DataColumn("Checked");
                    myDataColumn.DataType = System.Type.GetType("System.Boolean");
                    myDataColumn.DefaultValue = true ;
                    myDataTable.Columns.Add(myDataColumn);
                }
            }
        }

        private void textBox_WelderName_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_WelderName .Text.Length == 0)
            {
                return;
            }
            SqlCommand myCmd_Temp = new SqlCommand("Person_Welder_Query", Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@Filter", SqlDbType.NVarChar, 4000).Value = string.Format("WelderName like '%{0}%'", this.textBox_WelderName .Text.Replace("%", ""));
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCmd_Temp);
            this.myDataTable = new DataTable();
            myAdapter.Fill(myDataTable);
            this.dataGridView_Query.DataSource = new DataView(myDataTable);

            if (bool_QueryBatch)
            {
                DataColumn myDataColumn = new DataColumn("Checked");
                myDataColumn.DataType = System.Type.GetType("System.Boolean");
                myDataColumn.DefaultValue = true;
                myDataTable.Columns.Add(myDataColumn);
            }

        }

        private void TextBox_WorkerID_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox_WorkerID.Text.Length == 0)
            {
                return;
            }

            SqlCommand myCmd_Temp = new SqlCommand("Person_Welder_Query", Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@Filter", SqlDbType.NVarChar, 4000).Value = string.Format("WelderWorkerID like '%{0}%'", this.TextBox_WorkerID.Text.Replace("%", ""));
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCmd_Temp);
            this.myDataTable = new DataTable();
            myAdapter.Fill(myDataTable);
            this.dataGridView_Query.DataSource = new DataView(myDataTable);

            if (bool_QueryBatch)
            {
                DataColumn myDataColumn = new DataColumn("Checked");
                myDataColumn.DataType = System.Type.GetType("System.Boolean");
                myDataColumn.DefaultValue = true;
                myDataTable.Columns.Add(myDataColumn);
            }

        }

        private void TextBox_IdentificationCard_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox_IdentificationCard.Text.Length == 18)
            {
                SqlCommand myCmd_Temp = new SqlCommand("Person_Welder_Query", Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.CommandType = CommandType.StoredProcedure;
                myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NVarChar, 4000).Value =  this.TextBox_IdentificationCard .Text;
                SqlDataAdapter myAdapter = new SqlDataAdapter(myCmd_Temp);
                this.myDataTable = new DataTable();
                myAdapter.Fill(myDataTable);
                this.dataGridView_Query.DataSource = new DataView(myDataTable);

                if (bool_QueryBatch)
                {
                    DataColumn myDataColumn = new DataColumn("Checked");
                    myDataColumn.DataType = System.Type.GetType("System.Boolean");
                    myDataColumn.DefaultValue = true;
                    myDataTable.Columns.Add(myDataColumn);
                }
            }
        }
    }
}