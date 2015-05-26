using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery;
using ZCWelder.Person;

namespace ZCWelder.Exam
{
    public partial class Form_Student_AddBatch : Form
    {
        public string str_IssueNo;
        public bool bool_Updated = false;
        private DataTable myDataTable;

        public Form_Student_AddBatch()
        {
            InitializeComponent();
        }

        private void Form_Student_AddBatch_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.Welder.ToString(), false);
            Class_Public.InitializeComboBox(this.ComboBox_Assemblage, Enum_DataTable.Assemblage.ToString(), "Assemblage", "Assemblage");
            Class_Public.InitializeComboBox(this.ComboBox_KindofExam, Enum_DataTable.KindofExam.ToString(), "KindofExam", "KindofExam");
            Class_Public.InitializeComboBox(this.ComboBox_WeldingProcess, Enum_DataTable.WeldingProcess.ToString(), "WeldingProcessAb", "WeldingProcess");
            this.TextBox_IssueNo.Text =this.str_IssueNo ;
            Class_Issue myClass_Issue = new Class_Issue(this.str_IssueNo);
            this.ComboBox_WeldingProcess.SelectedValue = myClass_Issue.WeldingProcessAb;
            this.InitControlWeldingParameter(myClass_Issue.myClass_WeldingParameter);

            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
            if (myClass_ShipClassification.ShipRestrict)
            {
                Class_Ship myClass_Ship = new Class_Ship(myClass_Issue.ShipboardNo);
                this.MaskedTextBox_ExaminingNo.Text = myClass_Ship.NextSkillExaminingNo;
            }
            else
            {
                this.MaskedTextBox_ExaminingNo.Text = myClass_ShipClassification.NextExaminingNo;
            }

        }

        private void button_WelderAdd_Click(object sender, EventArgs e)
        {
            Form_Welder_Query myForm = new Form_Welder_Query();
            myForm.bool_QueryBatch = true;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                if (this.myDataTable == null)
                {
                    this.myDataTable = myForm.myDataTable;
                    this.dataGridView_Data.DataSource = new DataView(this.myDataTable);
                }
                else
                {
                    foreach (DataRow myDataRow in myForm.myDataTable.Rows)
                    {
                        if (this.myDataTable.Select(string.Format("IdentificationCard='{0}'", myDataRow["IdentificationCard"])).Length ==0)
                        {
                            this.myDataTable.ImportRow(myDataRow);
                        }
                    }
                }
                this.label_Data.Text = string.Format("学员，({0}):" ,this.myDataTable.Rows.Count );

            }

        }

        private void textBox_Material_DoubleClick(object sender, EventArgs e)
        {
            Form_MaterialQuery myForm = new Form_MaterialQuery();
            myForm.myClass_Material = new Class_Material();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.textBox_Material.Text = string.Format("{0}", myForm.myClass_Material.Material);
            }

        }

        private void textBox_WeldingConsumable_DoubleClick(object sender, EventArgs e)
        {
            Form_WeldingConsumableQuery myForm = new Form_WeldingConsumableQuery();
            myForm.myClass_WeldingConsumable = new Class_WeldingConsumable();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.textBox_WeldingConsumable.Text = string.Format("{0}", myForm.myClass_WeldingConsumable.WeldingConsumable);
            }

        }

        private void Button_SubjectQuery_Click(object sender, EventArgs e)
        {
            Class_Issue myClass_Issue = new Class_Issue(this.str_IssueNo);
            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
            Form_WeldingSubject_Query myForm = new Form_WeldingSubject_Query();
            if (myClass_ShipClassification.WeldingStandardRestrict)
            {
                myForm.str_FilterRestrict = string.Format("WeldingStandard='{0}'", myClass_ShipClassification.WeldingStandard); ;
            }
            myForm.myClass_WeldingSubject = new Class_WeldingSubject();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.InitControlWeldingSubject(myForm.myClass_WeldingSubject);
            }
        }

        public void InitControlWeldingSubject(Class_WeldingSubject myClass_Subject)
        {
            this.TextBox_SubjectID.Text = myClass_Subject.SubjectID;
            this.TextBox_WeldingStandard.Text = myClass_Subject.WeldingStandard;
            this.TextBox_WeldingProject.Text = myClass_Subject.WeldingProject;
            this.TextBox_WeldingClass.Text = myClass_Subject.WeldingClass;
            this.TextBox_WorkPieceType.Text = myClass_Subject.WorkPieceType;
            this.TextBox_JointType.Text = myClass_Subject.JointType;
            this.TextBox_Subject.Text = myClass_Subject.Subject;
        }

        public void InitControlWeldingParameter(Class_WeldingParameter myClass_WeldingParameter)
        {
            this.ComboBox_KindofExam.SelectedValue = myClass_WeldingParameter.KindofExam;
            this.ComboBox_Assemblage.SelectedValue = myClass_WeldingParameter.Assemblage;
            this.textBox_Material.Text = myClass_WeldingParameter.Material;
            this.textBox_WeldingConsumable.Text = myClass_WeldingParameter.WeldingConsumable;
            this.ComboBox_DimensionofMaterial.Text = myClass_WeldingParameter.DimensionofMaterial;
            this.TextBox_Thickness.Text = myClass_WeldingParameter.Thickness;
            this.TextBox_ExternalDiameter.Text = myClass_WeldingParameter.ExternalDiameter;
            this.TextBox_RenderWeldingRodDiameter.Text = myClass_WeldingParameter.RenderWeldingRodDiameter.ToString();
            this.TextBox_WeldingRodDiameter.Text = myClass_WeldingParameter.WeldingRodDiameter.ToString();
            this.TextBox_CoverWeldingRodDiameter.Text = myClass_WeldingParameter.CoverWeldingRodDiameter.ToString();
        }

        public void FillWeldingParameterClass(Class_WeldingParameter myClass_WeldingParameter)
        {
            myClass_WeldingParameter.KindofExam = this.ComboBox_KindofExam.SelectedValue.ToString();
            myClass_WeldingParameter.Assemblage = this.ComboBox_Assemblage.SelectedValue.ToString();
            myClass_WeldingParameter.Material = this.textBox_Material.Text;
            myClass_WeldingParameter.WeldingConsumable = this.textBox_WeldingConsumable.Text;
            myClass_WeldingParameter.Thickness = this.TextBox_Thickness.Text;
            myClass_WeldingParameter.ExternalDiameter = this.TextBox_ExternalDiameter.Text;
            double.TryParse(this.TextBox_RenderWeldingRodDiameter.Text, out myClass_WeldingParameter.RenderWeldingRodDiameter);
            double.TryParse(this.TextBox_WeldingRodDiameter.Text, out myClass_WeldingParameter.WeldingRodDiameter);
            double.TryParse(this.TextBox_CoverWeldingRodDiameter.Text, out myClass_WeldingParameter.CoverWeldingRodDiameter);
            myClass_WeldingParameter.DimensionofMaterial = this.ComboBox_DimensionofMaterial.Text;

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (this.myDataTable == null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = "没有添加焊工！";
                return;
            }
            string str_ErrMessage;
            Class_Student myClass_Student;
            foreach (DataRow myDataRow in this.myDataTable.Rows)
            {
                myDataRow["WelderRemark"] = "";
                myClass_Student = new Class_Student();
                myClass_Student.IssueNo = this.str_IssueNo;
                this.FillWeldingParameterClass(myClass_Student.myClass_WeldingParameter);
                myClass_Student.IdentificationCard = myDataRow["IdentificationCard"].ToString();
                myClass_Student.ExamStatus = "顺利考试";
                myClass_Student.SubjectID = this.TextBox_SubjectID.Text;
                if (Class_Student.ExistSecond(myClass_Student.IssueNo, myClass_Student.IdentificationCard, null, Enum_zwjKindofUpdate.Add))
                {
                    myDataRow["WelderRemark"]= "身份证号码不能重复！";
                }
                else
                {
                    str_ErrMessage = myClass_Student.CheckField();                    
                    if (string.IsNullOrEmpty(str_ErrMessage))
                    {
                        if (!myClass_Student.AddAndModify(Enum_zwjKindofUpdate.Add))
                        {
                            myDataRow["WelderRemark"] = "添加不成功，可能是考编号重复！";
                        }
                        else
                        {
                            this.bool_Updated = true;
                        }
                    }
                    else
                    {
                        myDataRow["WelderRemark"] = str_ErrMessage;
                    }
                }
            }
            DataRow[] myDataRowRange   =this.myDataTable.Select("WelderRemark = '' or WelderRemark is null");
            if (myDataRowRange.Length <this.myDataTable.Rows.Count )
            {
                this.label_ErrMessage.Text = "有数据不合法！请查看备注信息";
                this.DialogResult = DialogResult.None;
            }
            foreach (DataRow myDataRow in myDataRowRange)
            {
                myDataRow.Delete();
            }
            this.myDataTable.AcceptChanges();
        }

        private void toolStripMenuItem_DataGridViewRowDelete_Click(object sender, EventArgs e)
        {
            DataRow myDataRow;
            myDataRow = this.myDataTable.Rows.Find(this.dataGridView_Data.CurrentRow.Cells["IdentificationCard"].Value.ToString());
            myDataRow.Delete();
            this.myDataTable.AcceptChanges();
        }

        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true);;

        }

        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Data);

        }

        private void dataGridView_Data_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_DataGridViewRow;
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

    }
}