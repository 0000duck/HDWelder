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
    public partial class Form_MaterialQuery : Form
    {
        public Class_Material myClass_Material;
        
        public Form_MaterialQuery()
        {
            InitializeComponent();
        }

        private void Form_MaterialQuery_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.Material.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Material.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_Material.Material != null)
            {
                //object[] object_SortValue = new object[1] { this.myClass_Material.Material };
                //Class_Public.myclass_DataControlBind.SetDataGridViewSelectedPosition("Material", object_SortValue, this.dataGridView_Query);
                Class_DataControlBind.SetDataGridViewSelectedPosition("Material", this.myClass_Material.Material, this.dataGridView_Query);
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
            myClass_Material.Material = this.dataGridView_Query.CurrentRow.Cells["Material"].Value.ToString();
            myClass_Material.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_Material .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And Material like '%{0}%'", this.textBox_Material.Text);
            }
            if (this.textBox_MaterialGBName .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And MaterialGBName like '%{0}%'", this.textBox_MaterialGBName.Text);
            }
            ((DataView)this.dataGridView_Query.DataSource).RowFilter = str_Filter;

        }
    }
}