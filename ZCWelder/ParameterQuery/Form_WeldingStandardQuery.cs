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
    public partial class Form_WeldingStandardQuery : Form
    {
        public Class_WeldingStandard myClass_WeldingStandard;
        
        public Form_WeldingStandardQuery()
        {
            InitializeComponent();
        }

        private void Form_WeldingStandardQuery_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.WeldingStandard.ToString(), false);
            Class_Data  myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingStandard.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_WeldingStandard.WeldingStandard != null)
            {
                //object[] object_SortValue = new object[1] { this.myClass_WeldingStandard.WeldingStandard };
                //Class_Public.myclass_DataControlBind.SetDataGridViewSelectedPosition("WeldingStandard", object_SortValue, this.dataGridView_Query);
                Class_DataControlBind.SetDataGridViewSelectedPosition("WeldingStandard", this.myClass_WeldingStandard.WeldingStandard, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_WeldingStandard.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingStandard like '%{0}%'", this.textBox_WeldingStandard.Text);
            }
            if (this.textBox_WeldingStandardTitle.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingStandardTitle like '%{0}%'", this.textBox_WeldingStandardTitle.Text);
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

            myClass_WeldingStandard.WeldingStandard = this.dataGridView_Query.CurrentRow.Cells["WeldingStandard"].Value.ToString();
            myClass_WeldingStandard.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();


        }
    }
}