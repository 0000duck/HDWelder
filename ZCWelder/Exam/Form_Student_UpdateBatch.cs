using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using System.Data.SqlClient;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery;
using ZCCL.UpdateLog;
using ZCWelder.WPS;

namespace ZCWelder.Exam
{
    public partial class Form_Student_UpdateBatch : Form
    {
        private DataTable myDataTable_Origin;
        private bool bool_GXTheory;
        private string str_IssueNo;
        private DataTable myDataTable_Modified;

        public Form_Student_UpdateBatch()
        {
            InitializeComponent();
        }

        private void Form_Student_UpdateBatch_Load(object sender, EventArgs e)
        {
            Class_Public.InitializeComboBox(this.ComboBox_Assemblage, Enum_DataTable.Assemblage.ToString(), "Assemblage", "Assemblage");
            Class_Public.InitializeComboBox(this.ComboBox_KindofExam, Enum_DataTable.KindofExam.ToString(), "KindofExam", "KindofExam");
            Class_Public.InitializeComboBox(this.ComboBox_ExamStatus, Enum_DataTable.ExamStatus.ToString(), "ExamStatus", "ExamStatus");
    
        }

        public void InitDataGridView(DataTable myDataTable, bool bool_GXTheory, string str_IssueNo)
        {
            myDataTable.AcceptChanges();
            this.myDataTable_Origin = myDataTable;
            this.myDataTable_Modified = this.myDataTable_Origin.Copy();

            if (this.myDataTable_Modified.Columns.Contains("Checked"))
            {
                this.myDataTable_Modified.Columns.Remove("Checked");
            }
            DataColumn myDataColumn_Checked = new DataColumn("Checked");
            myDataColumn_Checked.DataType = System.Type.GetType("System.Boolean");
            myDataColumn_Checked.DefaultValue = false;
            this.myDataTable_Modified.Columns.Add(myDataColumn_Checked);

            this.bool_GXTheory = bool_GXTheory;
            this.str_IssueNo = str_IssueNo;

            if (this.bool_GXTheory )
            {
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Origin, Enum_DataTable.GXTheoryWelderStudent.ToString(), false);
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Modified, Enum_DataTable.GXTheoryWelderStudent.ToString(), true );
                this.checkBox_Assemblage.Enabled = false;
                this.checkBox_CoverWeldingRodDiameter.Enabled = false;
                this.checkBox_DimensionofMaterial.Enabled = false;
                this.checkBox_ExternalDiameter.Enabled = false;
                this.checkBox_Material.Enabled = false;
                this.checkBox_RenderWeldingRodDiameter.Enabled = false;
                this.checkBox_Thickness.Enabled = false;
                this.checkBox_WeldingConsumable.Enabled = false;
                this.checkBox_WeldingRodDiameter.Enabled = false;                
            }
            else
            {
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Origin, Enum_DataTable.WelderStudentQC.ToString(), false);
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Modified, Enum_DataTable.WelderStudentQC.ToString(), true);
                this.dataGridView_Modified.Columns["SkillResult"].ReadOnly = false;
                this.dataGridView_Modified.Columns["SkillMakeupResult"].ReadOnly = false;
                this.dataGridView_Modified.Columns["StudentMarked"].ReadOnly = false;
                this.dataGridView_Modified.Columns["StudentAssemblage"].ReadOnly = false;
                this.dataGridView_Modified.Columns["StudentMaterial"].ReadOnly = false;
                this.dataGridView_Modified.Columns["StudentDimensionofMaterial"].ReadOnly = false;
                this.dataGridView_Modified.Columns["StudentThickness"].ReadOnly = false;
                this.dataGridView_Modified.Columns["StudentExternalDiameter"].ReadOnly = false;

            }
            this.dataGridView_Modified.Columns["Checked"].ReadOnly = false;
            this.dataGridView_Modified.Columns["StudentKindofExam"].ReadOnly = false;
            this.dataGridView_Modified.Columns["ExamStatus"].ReadOnly = false;
            this.dataGridView_Modified.Columns["TheoryResult"].ReadOnly = false;
            this.dataGridView_Modified.Columns["TheoryMakeupResult"].ReadOnly = false;
            this.dataGridView_Modified.Columns["StudentRemark"].ReadOnly = false;

            this.dataGridView_Origin.DataSource = new DataView(this.myDataTable_Origin);
            this.dataGridView_Modified .DataSource = new DataView(this.myDataTable_Modified );
            
            ((DataView)this.dataGridView_Origin.DataSource).Sort = "ExaminingNo";
            ((DataView)this.dataGridView_Modified.DataSource).Sort = "ExaminingNo";
            this.label_Origin.Text = string.Format("原始数据，({0})：", this.dataGridView_Origin .RowCount);
        }

        private void textBox_Material_DoubleClick(object sender, EventArgs e)
        {
            if (this.bool_GXTheory)
            {
                return;
            }
            Form_MaterialQuery myForm = new Form_MaterialQuery();
            myForm.myClass_Material = new Class_Material();
            if (!string.IsNullOrEmpty (this.textBox_Material.Text))
            {
                myForm.myClass_Material.Material = this.textBox_Material.Text;
                myForm.myClass_Material.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.textBox_Material.Text = string.Format("{0}", myForm.myClass_Material.Material);
            }

        }

        private void textBox_WeldingConsumable_DoubleClick(object sender, EventArgs e)
        {
            if (this.bool_GXTheory)
            {
                return;
            }
            Form_WeldingConsumableQuery myForm = new Form_WeldingConsumableQuery();
            myForm.myClass_WeldingConsumable = new Class_WeldingConsumable();
            if (!string .IsNullOrEmpty( this.textBox_WeldingConsumable.Text))
            {
                myForm.myClass_WeldingConsumable.WeldingConsumable = this.textBox_WeldingConsumable.Text;
                myForm.myClass_WeldingConsumable.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.textBox_WeldingConsumable.Text = string.Format("{0}", myForm.myClass_WeldingConsumable.WeldingConsumable);
            }

        }

        private void Button_SubjectQuery_Click(object sender, EventArgs e)
        {
            Class_ShipClassification myClass_ShipClassification;
            if (this.bool_GXTheory)
            {
                Class_GXTheoryIssue myClass_GXTheoryIssue = new Class_GXTheoryIssue(this.str_IssueNo);
                myClass_ShipClassification = new Class_ShipClassification(myClass_GXTheoryIssue.ShipClassificationAb);
            }
            else
            {
                Class_Issue myClass_Issue = new Class_Issue(this.str_IssueNo);
                myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
            }
            Form_WeldingSubject_Query myForm = new Form_WeldingSubject_Query();
            if (myClass_ShipClassification.WeldingStandardRestrict)
            {
                myForm.str_FilterRestrict = string.Format("WeldingStandard='{0}'", myClass_ShipClassification.WeldingStandard); ;
            }
            myForm.myClass_WeldingSubject = new Class_WeldingSubject();
            if (!string.IsNullOrEmpty(this.TextBox_SubjectID.Text ))
            {
                myForm.myClass_WeldingSubject.SubjectID = this.TextBox_SubjectID.Text;
                myForm.myClass_WeldingSubject.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.TextBox_SubjectID.Text = myForm.myClass_WeldingSubject.SubjectID;
                this.TextBox_WeldingStandard.Text = myForm.myClass_WeldingSubject.WeldingStandard;
                this.TextBox_WeldingProject.Text = myForm.myClass_WeldingSubject.WeldingProject;
                this.TextBox_WeldingClass.Text = myForm.myClass_WeldingSubject.WeldingClass;
                this.TextBox_WorkPieceType.Text = myForm.myClass_WeldingSubject.WorkPieceType;
                this.TextBox_JointType.Text = myForm.myClass_WeldingSubject.JointType;
                this.TextBox_Subject.Text = myForm.myClass_WeldingSubject.Subject;
            }
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            //this.dataGridView_Modified.CurrentCell = this.dataGridView_Modified.Rows[this.dataGridView_Modified.RowCount-1].Cells[this.dataGridView_Modified.Columns.Count - 1];
            this.dataGridView_Modified .CurrentCell = null;

            if (this.bool_GXTheory)
            {
                Class_GXTheoryStudent.myAdapter.Update(this.myDataTable_Modified );
            
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Exam_GXTheoryStudent", this.str_IssueNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "批量修改学员信息");
            }
            else
            {
                Class_Student.myAdapter.Update(this.myDataTable_Modified );

                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Exam_Student", this.str_IssueNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "批量修改学员信息");

            }

        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            this.InitDataGridView(this.myDataTable_Origin , this.bool_GXTheory, this.str_IssueNo);

        }

        private void button_Modify_Click(object sender, EventArgs e)
        {
            double dbl_Temp;
            foreach (DataRow myDataRow in this.myDataTable_Modified.Rows )
            {
                if (myDataRow["Checked"] != null && (bool)myDataRow["Checked"] == true)
                {
                    if (this.checkBox_Assemblage.Checked)
                    {
                        myDataRow["StudentAssemblage"] = this.ComboBox_Assemblage.SelectedValue.ToString();
                    }
                    if (this.checkBox_Material.Checked && !string.IsNullOrEmpty(this.textBox_Material.Text))
                    {
                        myDataRow["StudentMaterial"] = this.textBox_Material.Text;
                    }
                    if (this.checkBox_CoverWeldingRodDiameter.Checked)
                    {
                        dbl_Temp = 0;
                        double.TryParse(this.TextBox_CoverWeldingRodDiameter.Text, out  dbl_Temp);
                        myDataRow["StudentCoverWeldingRodDiameter"] = dbl_Temp;
                    }
                    if (this.checkBox_DimensionofMaterial.Checked && !string.IsNullOrEmpty(this.ComboBox_DimensionofMaterial.Text))
                    {
                        myDataRow["StudentDimensionofMaterial"] = this.ComboBox_DimensionofMaterial.Text;
                    }
                    if (this.checkBox_ExamStatus.Checked)
                    {
                        myDataRow["ExamStatus"] = this.ComboBox_ExamStatus.SelectedValue.ToString();
                    }
                    if (this.checkBox_ExternalDiameter.Checked)
                    {
                        myDataRow["StudentExternalDiameter"] = this.TextBox_ExternalDiameter.Text;
                    }
                    if (this.checkBox_KindofExam.Checked)
                    {
                        myDataRow["StudentKindofExam"] = this.ComboBox_KindofExam.SelectedValue.ToString();
                    }
                    if (this.checkBox_RenderWeldingRodDiameter.Checked)
                    {
                        dbl_Temp = 0;
                        double.TryParse(this.TextBox_RenderWeldingRodDiameter.Text, out  dbl_Temp);
                        myDataRow["StudentRenderWeldingRodDiameter"] = dbl_Temp;
                    }
                    if (this.checkBox_SubjectID.Checked && !string.IsNullOrEmpty(this.TextBox_SubjectID.Text))
                    {
                        myDataRow["ExamSubjectID"]= this.TextBox_SubjectID.Text;
                    }
                    if (this.checkBox_Thickness.Checked)
                    {
                        myDataRow["StudentThickness"] = this.TextBox_Thickness.Text;
                    }
                    if (this.checkBox_WPSNo.Checked)
                    {
                        myDataRow["WPSNo"] = this.textBox_WPSNo.Text;
                    }
                    if (this.checkBox_WeldingConsumable.Checked && !string.IsNullOrEmpty(this.textBox_WeldingConsumable.Text))
                    {
                        myDataRow["StudentWeldingConsumable"] = this.textBox_WeldingConsumable.Text;
                    }
                    if (this.checkBox_WeldingRodDiameter.Checked)
                    {
                        dbl_Temp = 0;
                        double.TryParse(this.TextBox_WeldingRodDiameter.Text, out  dbl_Temp);
                        myDataRow["StudentWeldingRodDiameter"]= dbl_Temp;
                    }
                }
            }
            MessageBox.Show("修改完毕！");
            //foreach (DataGridViewRow myDataGridViewRow in this.dataGridView_Modified.Rows)
            //{
            //    if (myDataGridViewRow.Cells["Checked"].Value != null && (bool)myDataGridViewRow.Cells["Checked"].Value == true)
            //    {
            //        if (this.checkBox_Assemblage.Checked)
            //        {
            //            myDataGridViewRow.Cells["StudentAssemblage"].Value = this.ComboBox_Assemblage.SelectedValue.ToString();
            //        }
            //        if (this.checkBox_Material.Checked && !string.IsNullOrEmpty(this.textBox_Material.Text))
            //        {
            //            myDataGridViewRow.Cells["StudentMaterial"].Value = this.textBox_Material.Text;
            //        }
            //        if (this.checkBox_CoverWeldingRodDiameter.Checked)
            //        {
            //            dbl_Temp = 0;
            //            double.TryParse(this.TextBox_CoverWeldingRodDiameter.Text, out  dbl_Temp);
            //            myDataGridViewRow.Cells["StudentCoverWeldingRodDiameter"].Value = dbl_Temp;
            //        }
            //        if (this.checkBox_DimensionofMaterial.Checked && !string.IsNullOrEmpty(this.ComboBox_DimensionofMaterial.Text))
            //        {
            //            myDataGridViewRow.Cells["StudentDimensionofMaterial"].Value = this.ComboBox_DimensionofMaterial.Text;
            //        }
            //        if (this.checkBox_ExamStatus.Checked)
            //        {
            //            myDataGridViewRow.Cells["StudentExamStatus"].Value = this.ComboBox_ExamStatus.SelectedValue.ToString();
            //        }
            //        if (this.checkBox_ExternalDiameter.Checked)
            //        {
            //            myDataGridViewRow.Cells["StudentExternalDiameter"].Value = this.TextBox_ExternalDiameter.Text;
            //        }
            //        if (this.checkBox_KindofExam.Checked)
            //        {
            //            myDataGridViewRow.Cells["StudentKindofExam"].Value = this.ComboBox_KindofExam.SelectedValue.ToString();
            //        }
            //        if (this.checkBox_RenderWeldingRodDiameter.Checked)
            //        {
            //            dbl_Temp = 0;
            //            double.TryParse(this.TextBox_RenderWeldingRodDiameter.Text, out  dbl_Temp);
            //            myDataGridViewRow.Cells["StudentRenderWeldingRodDiameter"].Value = dbl_Temp;
            //        }
            //        if (this.checkBox_SubjectID.Checked && !string.IsNullOrEmpty(this.TextBox_SubjectID.Text))
            //        {
            //            myDataGridViewRow.Cells["ExamSubjectID"].Value = this.TextBox_SubjectID.Text;
            //        }
            //        if (this.checkBox_Thickness.Checked)
            //        {
            //            myDataGridViewRow.Cells["StudentThickness"].Value = this.TextBox_Thickness.Text;
            //        }
            //        if (this.checkBox_WeldingConsumable.Checked && !string.IsNullOrEmpty(this.textBox_WeldingConsumable.Text))
            //        {
            //            myDataGridViewRow.Cells["StudentWeldingConsumable"].Value = this.textBox_WeldingConsumable.Text;
            //        }
            //        if (this.checkBox_WeldingRodDiameter.Checked)
            //        {
            //            dbl_Temp = 0;
            //            double.TryParse(this.TextBox_WeldingRodDiameter.Text, out  dbl_Temp);
            //            myDataGridViewRow.Cells["StudentWeldingRodDiameter"].Value = dbl_Temp;
            //        }
            //    }
            //}
        }

        private void checkBox_CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow myDataRow in this.myDataTable_Modified  .Rows)
            {
                myDataRow["Checked"] = this.checkBox_CheckAll.Checked;
            }            
            //foreach (DataGridViewRow myDataGridViewRow in this.dataGridView_Modified.Rows)
            //{
            //    myDataGridViewRow.Cells["Checked"].Value = this.checkBox_CheckAll.Checked;
            //}            
        }

        /// <summary>
        /// 导出数据到Excel电子表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Origin , true, true);

        }

        /// <summary>
        /// 冻结或解冻任意数据列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Origin );

        }

        /// <summary>
        /// 设置快捷菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Data_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_DataGridViewRow;
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void toolStripMenuItem_ModifiedRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Modified , true, true);

        }

        private void toolStripMenuItem_ModifiedRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Modified);

        }

        private void dataGridView_Modified_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_ModifiedRow ;
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        private void textBox_WPSNo_DoubleClick(object sender, EventArgs e)
        {
            Form_WpsQuery myForm = new Form_WpsQuery();
            myForm.myClass_WPS = new Class_WPS();
            if (!string.IsNullOrEmpty(this.textBox_WPSNo.Text  ))
            {
                myForm.myClass_WPS.WPSID = this.textBox_WPSNo.Text;
                myForm.myClass_WPS.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.textBox_WPSNo.Text = string.Format("{0}", myForm.myClass_WPS.WPSID);
            }

        }

    }
}