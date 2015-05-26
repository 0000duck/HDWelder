using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder.Exam
{
    public partial class Form_Issue_Query : Form
    {
        public Class_Issue myClass_Issue;
        public Form_Issue_Query()
        {
            InitializeComponent();
        }

        private void Form_Issue_Query_Load(object sender, EventArgs e)
        {
            Class_Public.InitializeComboBox(this.comboBox_KindofEmployer, Enum_DataTable.KindofEmployer.ToString(), "KindofEmployer", "KindofEmployer");
            Class_Public.InitializeComboBox(this.comboBox_ShipClassificationAb, Enum_DataTable.ShipClassification.ToString(), "ShipClassificationAb", "ShipClassificationAb");
            Class_Public.InitializeComboBox(this.comboBox_ShipboardNo, Enum_DataTable.Ship.ToString(), "ShipboardNo", "ShipboardNo");
            this.comboBox_KindofEmployer.Text = "";
            this.comboBox_ShipboardNo.Text = "";
            this.comboBox_ShipClassificationAb.Text = "";

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.Issue.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Issue.ToString()];
            myClass_Data.SetFilter("1=1");
            myClass_Data.RefreshData(false);
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable.Copy());
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (this.myClass_Issue.IssueNo != null)
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("IssueNo", this.myClass_Issue.IssueNo, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_IssueNo.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And IssueNo like '%{0}%'", this.textBox_IssueNo.Text);
            }
            if (this.comboBox_KindofEmployer .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And KindofEmployer like '%{0}%'", this.comboBox_KindofEmployer.Text);
            }
            if (this.comboBox_ShipClassificationAb  .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And ShipClassificationAb like '%{0}%'", this.comboBox_ShipClassificationAb.Text);
            }
            if (this.comboBox_ShipboardNo  .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And ShipboardNo like '%{0}%'", this.comboBox_ShipboardNo .Text);
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
            myClass_Issue.IssueNo = this.dataGridView_Query.CurrentRow.Cells["IssueNo"].Value.ToString();
            myClass_Issue.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}