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
    public partial class Form_ShipQuery : Form
    {
        public Class_Ship myClass_Ship;
        
        public Form_ShipQuery()
        {
            InitializeComponent();
        }

        private void Form_ShipQuery_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.Ship.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Ship.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_Ship.ShipboardNo  != null)
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("ShipboardNo", this.myClass_Ship.ShipboardNo, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_ShipboardNo.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And ShipboardNo like '%{0}%'", this.textBox_ShipboardNo.Text);
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
            myClass_Ship.ShipboardNo = this.dataGridView_Query.CurrentRow.Cells["ShipboardNo"].Value.ToString();
            myClass_Ship.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}