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
    public partial class Form_EmployerQuery : Form
    {
        public Class_Employer myClass_Employer;

        public Form_EmployerQuery()
        {
            InitializeComponent();
        }

        private void Form_EmployerQuery_Load(object sender, EventArgs e)
        {
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.EmployerGroup.ToString()];
            Class_DataControlBind.InitializeComboBox(this.comboBox_EmployerGroup, myClass_Data.myDataView, "EmployerGroup", "EmployerGroup");

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Employer, Enum_DataTable.Employer.ToString(), false);
            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Employer.ToString()];
            this.dataGridView_Employer.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Employer.DataSource).Sort = myClass_Data.myDataView.Sort;
            if (!string.IsNullOrEmpty(this.myClass_Employer.EmployerHPID))
            {
                //object[] object_SortValue = new object[1] { this.myClass_Employer.EmployerHPID };
                //Class_Public.myclass_DataControlBind.SetDataGridViewSelectedPosition("EmployerHPID", object_SortValue, this.dataGridView_Employer);
                Class_DataControlBind.SetDataGridViewSelectedPosition("EmployerHPID", this.myClass_Employer.EmployerHPID, this.dataGridView_Employer);

            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_Employer.Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And Employer like '%{0}%'", this.textBox_Employer.Text);
            }
            if (this.textBox_EmployerHPID .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And EmployerHPID = '{0}'", this.textBox_EmployerHPID.Text);
            }
            if (this.comboBox_EmployerGroup .Text .Length  > 0)
            {
                str_Filter = str_Filter + string.Format(" And EmployerGroup = '{0}'", this.comboBox_EmployerGroup.Text);
            }
            ((DataView)this.dataGridView_Employer.DataSource).RowFilter = str_Filter;
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_Employer.CurrentRow == null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = "请选择一个公司！";
                return;
            }
            myClass_Employer.EmployerHPID = this.dataGridView_Employer.CurrentRow.Cells["EmployerHPID"].Value.ToString();
            myClass_Employer.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}