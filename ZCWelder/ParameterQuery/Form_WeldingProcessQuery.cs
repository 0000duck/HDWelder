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
    public partial class Form_WeldingProcessQuery : Form
    {
        public Class_WeldingProcess myClass_WeldingProcess;

        public Form_WeldingProcessQuery()
        {
            InitializeComponent();
        }

        private void Form_WeldingProcessQuery_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.WeldingProcess.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingProcess.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_WeldingProcess.WeldingProcessAb != null)
            {
                //object[] object_SortValue = new object[1] { this.myClass_WeldingProcess.WeldingProcessAb  };
                //Class_Public.myclass_DataControlBind.SetDataGridViewSelectedPosition("WeldingProcessAb", object_SortValue, this.dataGridView_Query);
                Class_DataControlBind.SetDataGridViewSelectedPosition("WeldingProcessAb", this.myClass_WeldingProcess.WeldingProcessAb, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_WeldingProcess .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingProcess like '%{0}%'", this.textBox_WeldingProcess.Text);
            }
            if (this.textBox_WeldingProcessAb .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingProcessAb like '%{0}%'", this.textBox_WeldingProcessAb.Text);
            }
            ((DataView)this.dataGridView_Query.DataSource).RowFilter = str_Filter;


        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_Query.CurrentRow == null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = "��ѡ��һ����¼��";
                return;
            }
            myClass_WeldingProcess.WeldingProcessAb = this.dataGridView_Query.CurrentRow.Cells["WeldingProcessAb"].Value.ToString();
            myClass_WeldingProcess.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}