using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.AspNet;
using ZCCL.Report;
using ZCCL.ClassBase;

namespace ZCWelder.ParameterQuery
{
    public partial class Form_WeldingPositionQuery : Form
    {
        public Class_WeldingPosition myClass_WeldingPosition;
        
        public Form_WeldingPositionQuery()
        {
            InitializeComponent();
        }

        private void Form_WeldingPositionQuery_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.WeldingPosition.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingPosition.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_WeldingPosition.WeldingPosition != null)
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("WeldingPosition", this.myClass_WeldingPosition.WeldingPosition, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_WeldingPosition.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingPosition like '%{0}%'", this.textBox_WeldingPosition.Text);
            }
            ((DataView)this.dataGridView_Query.DataSource).RowFilter = str_Filter;

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_Query.CurrentRow == null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = "请选择一条记录！";
                return;
            }
            myClass_WeldingPosition.WeldingPosition = this.dataGridView_Query.CurrentRow.Cells["WeldingPosition"].Value.ToString();
            myClass_WeldingPosition.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}