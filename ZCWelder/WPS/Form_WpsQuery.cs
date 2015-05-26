using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder.WPS
{
    public partial class Form_WpsQuery : Form
    {
        public Class_WPS myClass_WPS;

        public Form_WpsQuery()
        {
            InitializeComponent();
        }

        private void Form_WpsQuery_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.WPS .ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WPS.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_WPS.WPSID   != null)
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("WPSID", this.myClass_WPS.WPSID, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_WPSID.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WPSID like '%{0}%'", this.textBox_WPSID.Text);
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
            myClass_WPS.WPSID = this.dataGridView_Query.CurrentRow.Cells["WPSID"].Value.ToString();
            myClass_WPS.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            myClass_WPS.WPSID  = "";
            myClass_WPS.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
