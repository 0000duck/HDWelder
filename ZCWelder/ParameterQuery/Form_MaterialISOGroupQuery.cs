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
    public partial class Form_MaterialISOGroupQuery : Form
    {
        public Class_MaterialISOGroup myClass_MaterialISOGroup;
        public Form_MaterialISOGroupQuery()
        {
            InitializeComponent();
        }

        private void Form_MaterialISOGroupQuery_Load(object sender, EventArgs e)
        {

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.MaterialISOGroup.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.MaterialISOGroup.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_MaterialISOGroup.MaterialISOGroupAb != null)
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("MaterialISOGroupAb", this.myClass_MaterialISOGroup.MaterialISOGroupAb, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_MaterialISOGroupAb.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And MaterialISOGroupAb like '%{0}%'", this.textBox_MaterialISOGroupAb.Text);
            }
            if (this.textBox_MaterialISOGroup.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And MaterialISOGroup like '%{0}%'", this.textBox_MaterialISOGroup.Text);
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
            myClass_MaterialISOGroup.MaterialISOGroupAb = this.dataGridView_Query.CurrentRow.Cells["MaterialISOGroupAb"].Value.ToString();
            myClass_MaterialISOGroup.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}