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
    public partial class Form_GasAndWeldingFluxQuery : Form
    {
        public Class_GasAndWeldingFlux myClass_GasAndWeldingFlux;
        
        public Form_GasAndWeldingFluxQuery()
        {
            InitializeComponent();
        }

        private void Form_GasAndWeldingFluxQuery_Load(object sender, EventArgs e)
        {
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.GasAndWeldingFluxGroup.ToString()];
            Class_DataControlBind.InitializeComboBox(this.comboBox_GasAndWeldingFluxGroup, myClass_Data.myDataView, "GasAndWeldingFluxGroup", "GasAndWeldingFluxGroup");

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTableSecond.GasAndWeldingFlux.ToString(), false);
            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.GasAndWeldingFlux.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query  .DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_GasAndWeldingFlux.GasAndWeldingFlux != null)
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("GasAndWeldingFlux", this.myClass_GasAndWeldingFlux.GasAndWeldingFlux, this.dataGridView_Query);
            }
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_Query.CurrentRow == null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = "请选择一条记录！";
                return;
            }

            myClass_GasAndWeldingFlux.GasAndWeldingFlux = this.dataGridView_Query.CurrentRow.Cells["GasAndWeldingFlux"].Value.ToString();
            myClass_GasAndWeldingFlux.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_GasAndWeldingFlux.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And GasAndWeldingFlux like '%{0}%'", this.textBox_GasAndWeldingFlux.Text);
            }
            if (this.comboBox_GasAndWeldingFluxGroup.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And GasAndWeldingFluxGroup like '%{0}%'", this.comboBox_GasAndWeldingFluxGroup.Text);
            }
            ((DataView)this.dataGridView_Query.DataSource).RowFilter = str_Filter;

        }
    }
}