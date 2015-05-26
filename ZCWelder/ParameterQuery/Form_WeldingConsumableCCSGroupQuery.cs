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
    public partial class Form_WeldingConsumableCCSGroupQuery : Form
    {
        public Class_WeldingConsumableCCSGroup myClass_WeldingConsumableCCSGroup;
        public Form_WeldingConsumableCCSGroupQuery()
        {
            InitializeComponent();
        }

        private void Form_WeldingConsumableCCSGroupQuery_Load(object sender, EventArgs e)
        {

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.WeldingConsumableCCSGroup.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingConsumableCCSGroup.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupAb != null)
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("WeldingConsumableCCSGroupAb", this.myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupAb, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_WeldingConsumableCCSGroupAb.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingConsumableCCSGroupAb like '%{0}%'", this.textBox_WeldingConsumableCCSGroupAb.Text);
            }
            if (this.textBox_WeldingConsumableCCSGroup.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingConsumableCCSGroup like '%{0}%'", this.textBox_WeldingConsumableCCSGroup.Text);
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
            myClass_WeldingConsumableCCSGroup.WeldingConsumableCCSGroupAb = this.dataGridView_Query.CurrentRow.Cells["WeldingConsumableCCSGroupAb"].Value.ToString();
            myClass_WeldingConsumableCCSGroup.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}