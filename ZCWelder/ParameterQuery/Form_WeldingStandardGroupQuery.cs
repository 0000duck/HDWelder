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
    public partial class Form_WeldingStandardGroupQuery : Form
    {
        public Class_WeldingStandardGroup myClass_WeldingStandardGroup;
        
        public Form_WeldingStandardGroupQuery()
        {
            InitializeComponent();
        }

        private void Form_WeldingStandardGroupQuery_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.WeldingStandardGroup.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingStandardGroup.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_WeldingStandardGroup.WeldingStandardGroup != null)
            {
                //object[] object_SortValue = new object[1] { this.myClass_WeldingStandardGroup.WeldingStandardGroup };
                //Class_Public.myclass_DataControlBind.SetDataGridViewSelectedPosition("WeldingStandardGroup", object_SortValue, this.dataGridView_Query);
                Class_DataControlBind.SetDataGridViewSelectedPosition("WeldingStandardGroup", this.myClass_WeldingStandardGroup.WeldingStandardGroup, this.dataGridView_Query);
            }
        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_WeldingStandardGroup.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingStandardGroup like '%{0}%'", this.textBox_WeldingStandardGroup.Text);
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

            myClass_WeldingStandardGroup.WeldingStandardGroup = this.dataGridView_Query.CurrentRow.Cells["WeldingStandardGroup"].Value.ToString();
            myClass_WeldingStandardGroup.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}