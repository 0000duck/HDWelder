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
    public partial class Form_WeldingSubject_Query : Form
    {
        public Class_WeldingSubject myClass_WeldingSubject;
        public string str_FilterRestrict;
        public Form_WeldingSubject_Query()
        {
            InitializeComponent();
        }

        private void Form_WeldingSubject_Query_Load(object sender, EventArgs e)
        {
            DataView myDataView_WeldingStandard = new DataView(((Class_Data )Class_Public.myHashtable[Enum_DataTable.WeldingStandardAndGroup.ToString()]).myDataTable );
            myDataView_WeldingStandard.RowFilter = "WeldingStandardGroup='焊工考试标准'";
            Class_DataControlBind.InitializeComboBox(this.ComboBox_WeldingStandard,myDataView_WeldingStandard,"WeldingStandard", "WeldingStandard");

            Class_Public.InitializeComboBox(this.ComboBox_JointType, Enum_DataTable.JointType.ToString(), "JointType", "JointType");
            Class_Public.InitializeComboBox(this.ComboBox_WorkPieceType, Enum_DataTable.WorkPieceType.ToString(), "WorkPieceType", "WorkPieceType");
            this.ComboBox_JointType.Text = "";
            this.ComboBox_WeldingStandard.Text = "";
            this.ComboBox_WorkPieceType.Text = "";
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Query, Enum_DataTable.WeldingSubject.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WeldingSubject.ToString()];
            this.dataGridView_Query.DataSource = new DataView(myClass_Data.myDataTable);
            ((DataView)this.dataGridView_Query.DataSource).RowFilter = this.str_FilterRestrict ;
            ((DataView)this.dataGridView_Query.DataSource).Sort = myClass_Data.myDataView.Sort;

            if (!string.IsNullOrEmpty(this.myClass_WeldingSubject.SubjectID ))
            {
                Class_DataControlBind.SetDataGridViewSelectedPosition("SubjectID", this.myClass_WeldingSubject.SubjectID, this.dataGridView_Query);
            }

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.textBox_SubjectID .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And SubjectID like '%{0}%'", this.textBox_SubjectID.Text);
            }
            if (this.ComboBox_JointType  .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And JointType = '{0}'", this.ComboBox_JointType .Text);
            }
            if (this.ComboBox_WeldingStandard   .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingStandard = '{0}'", this.ComboBox_WeldingStandard.Text);
            }
            if (this.ComboBox_WorkPieceType   .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WorkPieceType = '{0}'", this.ComboBox_WorkPieceType.Text);
            }
            if (!string.IsNullOrEmpty(this.str_FilterRestrict))
            {
                str_Filter = str_Filter + " And " + this.str_FilterRestrict ;
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
            myClass_WeldingSubject.SubjectID = this.dataGridView_Query.CurrentRow.Cells["SubjectID"].Value.ToString();
            myClass_WeldingSubject.FillData();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }    }
}