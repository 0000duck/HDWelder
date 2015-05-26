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
    public partial class Form_ShipClassificationQuery : Form
    {
        public Class_ShipClassification myClass_ShipClassification;
        
        public Form_ShipClassificationQuery()
        {
            InitializeComponent();
        }

        private void Form_ShipClassificationQuery_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.ShipClassification.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ShipClassification.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (!string.IsNullOrEmpty( this.myClass_ShipClassification.ShipClassificationAb ))
            {
                //object[] object_SortValue = new object[1] { this.myClass_ShipClassification.ShipClassificationAb };
                //Class_Public.myclass_DataControlBind.SetDataGridViewSelectedPosition("ShipClassificationAb", object_SortValue, this.dataGridView_Query);
                Class_DataControlBind.SetDataGridViewSelectedPosition("ShipClassificationAb", this.myClass_ShipClassification.ShipClassificationAb, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_ShipClassification.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And ShipClassification like '%{0}%'", this.textBox_ShipClassification.Text);
            }
            if (this.textBox_ShipClassificationAb.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And ShipClassificationAb like '%{0}%'", this.textBox_ShipClassificationAb.Text);
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
            myClass_ShipClassification.ShipClassificationAb = this.dataGridView_Query.CurrentRow.Cells["ShipClassificationAb"].Value.ToString();
            myClass_ShipClassification.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}