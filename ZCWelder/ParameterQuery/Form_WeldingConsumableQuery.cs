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
    public partial class Form_WeldingConsumableQuery : Form
    {
        public Class_WeldingConsumable myClass_WeldingConsumable;
        
        public Form_WeldingConsumableQuery()
        {
            InitializeComponent();
        }

        private void Form_WeldingConsumableQuery_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.WeldingConsumable.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingConsumable.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_WeldingConsumable.WeldingConsumable != null)
            {
                //object[] object_SortValue = new object[1] { this.myClass_WeldingConsumable.WeldingConsumable };
                //Class_Public.myclass_DataControlBind.SetDataGridViewSelectedPosition("WeldingConsumable", object_SortValue, this.dataGridView_Query);
                Class_DataControlBind.SetDataGridViewSelectedPosition("WeldingConsumable", this.myClass_WeldingConsumable.WeldingConsumable, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_WeldingConsumable.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingConsumable like '%{0}%'", this.textBox_WeldingConsumable.Text);
            }
            if (this.textBox_WeldingConsumableGBName.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingConsumableGBName like '%{0}%'", this.textBox_WeldingConsumableGBName.Text);
            }
            ((DataView)this.dataGridView_Query.DataSource).RowFilter = str_Filter;

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_Query.CurrentRow == null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = "????????????????";
                return;
            }
            myClass_WeldingConsumable.WeldingConsumable = this.dataGridView_Query.CurrentRow.Cells["WeldingConsumable"].Value.ToString();
            myClass_WeldingConsumable.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}