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
    public partial class Form_WeldingEquipmentQuery : Form
    {
        public Class_WeldingEquipment myClass_WeldingEquipment;
        
        public Form_WeldingEquipmentQuery()
        {
            InitializeComponent();
        }

        private void Form_WeldingEquipmentQuery_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTableSecond.WeldingEquipment.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.WeldingEquipment.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_WeldingEquipment.WeldingEquipment != null)
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("WeldingEquipment", this.myClass_WeldingEquipment.WeldingEquipment, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_WeldingEquipment.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingEquipment like '%{0}%'", this.textBox_WeldingEquipment.Text);
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

            myClass_WeldingEquipment.WeldingEquipment = this.dataGridView_Query.CurrentRow.Cells["WeldingEquipment"].Value.ToString();
            myClass_WeldingEquipment.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            myClass_WeldingEquipment.WeldingEquipment = "";
            myClass_WeldingEquipment.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView_Query_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}