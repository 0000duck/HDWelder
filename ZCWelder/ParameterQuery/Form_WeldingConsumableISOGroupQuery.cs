using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder.ParameterQuery
{
    public partial class Form_WeldingConsumableISOGroupQuery : Form
    {
        public Class_WeldingConsumableISOGroup myClass_WeldingConsumableISOGroup;
        public Form_WeldingConsumableISOGroupQuery()
        {
            InitializeComponent();
        }

        private void Form_WeldingConsumableISOGroupQuery_Load(object sender, EventArgs e)
        {

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.WeldingConsumableISOGroup.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingConsumableISOGroup.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupAb != null)
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("WeldingConsumableISOGroupAb", this.myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupAb, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_WeldingConsumableISOGroupAb.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingConsumableISOGroupAb like '%{0}%'", this.textBox_WeldingConsumableISOGroupAb.Text);
            }
            if (this.textBox_WeldingConsumableISOGroup.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingConsumableISOGroup like '%{0}%'", this.textBox_WeldingConsumableISOGroup.Text);
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
            myClass_WeldingConsumableISOGroup.WeldingConsumableISOGroupAb = this.dataGridView_Query.CurrentRow.Cells["WeldingConsumableISOGroupAb"].Value.ToString();
            myClass_WeldingConsumableISOGroup.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}