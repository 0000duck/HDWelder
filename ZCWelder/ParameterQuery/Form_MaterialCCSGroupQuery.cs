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
    public partial class Form_MaterialCCSGroupQuery : Form
    {
        public Class_MaterialCCSGroup myClass_MaterialCCSGroup;
        public Form_MaterialCCSGroupQuery()
        {
            InitializeComponent();
        }

        private void Form_MaterialCCSGroupQuery_Load(object sender, EventArgs e)
        {

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.MaterialCCSGroup.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.MaterialCCSGroup.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_MaterialCCSGroup.MaterialCCSGroupAb != null)
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("MaterialCCSGroupAb", this.myClass_MaterialCCSGroup.MaterialCCSGroupAb, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_MaterialCCSGroupAb.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And MaterialCCSGroupAb like '%{0}%'", this.textBox_MaterialCCSGroupAb.Text);
            }
            if (this.textBox_MaterialCCSGroup.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And MaterialCCSGroup like '%{0}%'", this.textBox_MaterialCCSGroup.Text);
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
            myClass_MaterialCCSGroup.MaterialCCSGroupAb = this.dataGridView_Query.CurrentRow.Cells["MaterialCCSGroupAb"].Value.ToString();
            myClass_MaterialCCSGroup.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}