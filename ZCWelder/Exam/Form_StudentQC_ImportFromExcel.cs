using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;

namespace ZCWelder.Exam
{
    public partial class Form_StudentQC_ImportFromExcel : Form
    {
        private string str_IssueNo;
        private DataTable myDataTable;

        public Form_StudentQC_ImportFromExcel()
        {
            InitializeComponent();
        }

        private void Form_StudentQC_ImportFromExcel_Load(object sender, EventArgs e)
        {
            string str_ErrMessage;
            str_ErrMessage=this.CheckSchema_DataTable();
            if (!string.IsNullOrEmpty(this.CheckSchema_DataTable()))
            {
                MessageBox.Show(str_ErrMessage);
                this.Close();
                return;
            }
            DataRow[] myDataRow_Range;
            //myDataRow_Range = this.myDataTable.Select("(len(IdentificationCard)=15 or len(IdentificationCard)=18) and len(WelderName)>0 and (Sex='男' or Sex='女') and len(Schooling)>0 and len(WelderEmployer)>0 and len(ExamSubjectID)=4");
            myDataRow_Range = this.myDataTable.Select("len(IdentificationCard)>0 and len(WelderName)>0 and len(Schooling)>0 and len(WelderEmployer)>0");
            DataTable myDataTable_Temp = this.myDataTable.Clone();
            foreach (DataRow myDataRow in myDataRow_Range)
            {
                myDataTable_Temp.ImportRow(myDataRow);
            }
            this.myDataTable = myDataTable_Temp;

            string[] str_fieldNameArray=new string [2];
            str_fieldNameArray[0] = "IssueNo";
            str_fieldNameArray[1] = "IdentificationCard";
            if (Class_Data.GetDistinctField(this.myDataTable, str_fieldNameArray).Rows.Count != this.myDataTable.Rows.Count)
            {
                MessageBox.Show("数据表中同一班级编号下有重复的身份证号码！");
                this.Close();
            }
            this.dataGridView_Data.DataSource = new DataView(this.myDataTable);
            this.label_Data.Text = string.Format("报名学员，({0})：", this.dataGridView_Data.RowCount);

        }

        public  void InitDataGridView(string  str_IssueNo, DataTable myDataTable)
        {
            Class_Public.InitializeComboBox(this.ComboBox_Assemblage, Enum_DataTable.Assemblage.ToString(), "Assemblage", "Assemblage");
            Class_Public.InitializeComboBox(this.ComboBox_KindofExam, Enum_DataTable.KindofExam.ToString(), "KindofExam", "KindofExam");
            Class_Public.InitializeComboBox(this.ComboBox_WeldingProcess, Enum_DataTable.WeldingProcess.ToString(), "WeldingProcessAb", "WeldingProcess");
            
            this.str_IssueNo = str_IssueNo;
            this.myDataTable = myDataTable;
            Class_Issue myClass_Issue = new Class_Issue(this.str_IssueNo);

            this.MaskedTextBox_IssueNo.Text = myClass_Issue.IssueNo;
            this.DateTimePicker_SignUpDate.Value = myClass_Issue.SignUpDate;
            this.textBox_KindofEmployer.Text = myClass_Issue.KindofEmployer;
            Class_Employer myClass_Employer = new Class_Employer(myClass_Issue.EmployerHPID);
            this.textBox_Employer.Text = string.Format("{0}:{1}", myClass_Employer.EmployerHPID, myClass_Employer.Employer);
            this.ComboBox_WeldingProcess.SelectedValue = myClass_Issue.WeldingProcessAb;
            this.textBox_ShipClassificationAb.Text = myClass_Issue.ShipClassificationAb;
            this.TextBox_ShipboardNo.Text = myClass_Issue.ShipboardNo;

            this.InitControlWeldingParameter(myClass_Issue.myClass_WeldingParameter);

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

        private string CheckSchema_DataTable()
        {
            if (!this.myDataTable.Columns.Contains("IdentificationCard"))
            {
                return "数据表中不存在 'IdentificationCard' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WelderName"))
            {
                return "数据表中不存在 'WelderName' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("Sex"))
            {
                return "数据表中不存在 'Sex' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("Schooling"))
            {
                return "数据表中不存在 'Schooling' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WeldingBeginning"))
            {
                return "数据表中不存在 'WeldingBeginning' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WelderWorkerID"))
            {
                return "数据表中不存在 'WelderWorkerID' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WelderEmployer"))
            {
                return "数据表中不存在 'WelderEmployer' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WelderDepartment"))
            {
                return "数据表中不存在 'WelderDepartment' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WelderWorkPlace"))
            {
                return "数据表中不存在 'WelderWorkPlace' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WelderLaborServiceTeam"))
            {
                return "数据表中不存在 'WelderLaborServiceTeam' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("ExamSubjectID"))
            {
                return "数据表中不存在 'ExamSubjectID' 列！";
            }
            else if (this.myDataTable.Columns["IdentificationCard"].DataType != System.Type.GetType("System.String"))
            {
                return " 'IdentificationCard' 列必须为字符串值！";
            }
            else if (this.myDataTable.Columns["ExamSubjectID"].DataType != System.Type.GetType("System.String"))
            {
                return " 'ExamSubjectID' 列必须为字符串值！";
            }

            if (this.myDataTable.Columns.Contains("WelderEmployerHPID"))
            {
                this.myDataTable.Columns.Remove("WelderEmployerHPID");
            }
            DataColumn myDataColumn_EmployerHPID = new DataColumn("WelderEmployerHPID");
            myDataColumn_EmployerHPID.DataType = System.Type.GetType("System.String");
            myDataColumn_EmployerHPID.MaxLength = 4;
            myDataColumn_EmployerHPID.AllowDBNull = true;
            this.myDataTable.Columns.Add(myDataColumn_EmployerHPID);

            if (this.myDataTable.Columns.Contains("WelderDepartmentHPID"))
            {
                this.myDataTable.Columns.Remove("WelderDepartmentHPID");
            }
            DataColumn myDataColumn_DepartmentHPID = new DataColumn("WelderDepartmentHPID");
            myDataColumn_DepartmentHPID.DataType = System.Type.GetType("System.String");
            myDataColumn_DepartmentHPID.MaxLength = 6;
            myDataColumn_DepartmentHPID.AllowDBNull = true;
            this.myDataTable.Columns.Add(myDataColumn_DepartmentHPID);

            if (this.myDataTable.Columns.Contains("WelderWorkPlaceHPID"))
            {
                this.myDataTable.Columns.Remove("WelderWorkPlaceHPID");
            }
            DataColumn myDataColumn_WorkPlaceHPID = new DataColumn("WelderWorkPlaceHPID");
            myDataColumn_WorkPlaceHPID.DataType = System.Type.GetType("System.String");
            myDataColumn_WorkPlaceHPID.MaxLength = 8;
            myDataColumn_WorkPlaceHPID.AllowDBNull = true;
            this.myDataTable.Columns.Add(myDataColumn_WorkPlaceHPID);

            if (this.myDataTable.Columns.Contains("WelderLaborServiceTeamHPID"))
            {
                this.myDataTable.Columns.Remove("WelderLaborServiceTeamHPID");
            }
            DataColumn myDataColumn_LaborServiceTeamHPID = new DataColumn("WelderLaborServiceTeamHPID");
            myDataColumn_LaborServiceTeamHPID.DataType = System.Type.GetType("System.String");
            myDataColumn_LaborServiceTeamHPID.MaxLength = 7;
            myDataColumn_LaborServiceTeamHPID.AllowDBNull = true;
            this.myDataTable.Columns.Add(myDataColumn_LaborServiceTeamHPID);

            if (this.myDataTable.Columns.Contains("ErrMessage"))
            {
                if (this.myDataTable.Columns["ErrMessage"].DataType != System.Type.GetType("System.String"))
                {
                    this.myDataTable.Columns.Remove("ErrMessage");
                    DataColumn myDataColumn_ErrMessage = new DataColumn("ErrMessage");
                    myDataColumn_ErrMessage.DataType = System.Type.GetType("System.String");
                    myDataColumn_ErrMessage.MaxLength = 255;
                    myDataColumn_ErrMessage.AllowDBNull = true;
                    this.myDataTable.Columns.Add(myDataColumn_ErrMessage);
                }
            }
            else
            {
                DataColumn myDataColumn_ErrMessage = new DataColumn("ErrMessage");
                myDataColumn_ErrMessage.DataType = System.Type.GetType("System.String");
                myDataColumn_ErrMessage.MaxLength = 255;
                myDataColumn_ErrMessage.AllowDBNull = true;
                this.myDataTable.Columns.Add(myDataColumn_ErrMessage);
            }
         
            if (this.myDataTable.Columns.Contains("isImport"))
            {
                this.myDataTable.Columns.Remove("isImport");
            }
            DataColumn myDataColumn_isImport = new DataColumn("isImport");
            myDataColumn_isImport.DataType = System.Type.GetType("System.Boolean");
            myDataColumn_isImport.DefaultValue = false;
            this.myDataTable.Columns.Add(myDataColumn_isImport);

            return null;

        }

        private void  CheckData_DataTable()
        {
            Class_Welder myClass_Welder;
            Class_Student myClass_Student;
            Class_Issue myClass_Issue = new Class_Issue(this.str_IssueNo);
            string str_ErrMessage;
            DateTime myDateTime;
            foreach (DataRow myDataRow in this.myDataTable.Rows)
            {
                myDataRow["ErrMessage"] = "";
                str_ErrMessage = "";

                myClass_Welder = new Class_Welder();
                myClass_Welder.IdentificationCard = myDataRow["IdentificationCard"].ToString().Trim();
                myClass_Welder.WelderName = myDataRow["WelderName"].ToString().Trim();
                myClass_Welder.Schooling = myDataRow["Schooling"].ToString().Trim();
                myClass_Welder.Sex = myDataRow["Sex"].ToString().Trim();
                DateTime.TryParse(myDataRow["WeldingBeginning"].ToString().Trim(), out myClass_Welder.WeldingBeginning);
                myClass_Welder.myClass_BelongUnit.WorkerID = myDataRow["WelderWorkerID"].ToString().Trim();
                
                //myClass_Welder.myClass_BelongUnit.EmployerHPID = Class_Employer.GetEmployerHPID(myDataRow["WelderBelongEmployer"].ToString());
                myClass_Welder.myClass_BelongUnit.EmployerHPID = Class_Employer.GetEmployerHPIDbyDataTable(myDataRow["WelderEmployer"].ToString().Trim());
                myDataRow["WelderEmployerHPID"] = myClass_Welder.myClass_BelongUnit.EmployerHPID;
                if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.EmployerHPID))
                {
                    str_ErrMessage = "公司数据有误！";
                }
                else
                {
                    if (!string.IsNullOrEmpty(myDataRow["WelderDepartment"].ToString().Trim()))
                    {
                        //myClass_Welder.myClass_BelongUnit.DepartmentHPID = Class_Department.GetDepartmentHPID(myClass_Welder.myClass_BelongUnit.EmployerHPID, myDataRow["WelderBelongDepartment"].ToString());
                        myClass_Welder.myClass_BelongUnit.DepartmentHPID = Class_Department.GetDepartmentHPIDbyDataTable(myClass_Welder.myClass_BelongUnit.EmployerHPID, myDataRow["WelderDepartment"].ToString().Trim());
                        myDataRow["WelderDepartmentHPID"] = myClass_Welder.myClass_BelongUnit.DepartmentHPID;
                        if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.DepartmentHPID))
                        {
                            str_ErrMessage = "部门数据有误！";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(myDataRow["WelderWorkPlace"].ToString().Trim()))
                            {
                                //myClass_Welder.myClass_BelongUnit.WorkPlaceHPID = Class_WorkPlace.GetWorkPlaceHPID(myClass_Welder.myClass_BelongUnit.DepartmentHPID, myDataRow["WelderBelongWorkPlace"].ToString());
                                myClass_Welder.myClass_BelongUnit.WorkPlaceHPID = Class_WorkPlace.GetWorkPlaceHPIDbyDataTable(myClass_Welder.myClass_BelongUnit.DepartmentHPID, myDataRow["WelderWorkPlace"].ToString().Trim());
                                myDataRow["WelderWorkPlaceHPID"] = myClass_Welder.myClass_BelongUnit.WorkPlaceHPID;
                                if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.WorkPlaceHPID))
                                {
                                    str_ErrMessage = "作业区数据有误！";
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(myDataRow["WelderLaborServiceTeam"].ToString().Trim()))
                    {
                        //myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID = Class_LaborServiceTeam.GetLaborServiceTeamHPID(myClass_Welder.myClass_BelongUnit.EmployerHPID, myDataRow["WelderBelongLaborServiceTeam"].ToString());
                        myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID = Class_LaborServiceTeam.GetLaborServiceTeamHPIDbyDataTable(myClass_Welder.myClass_BelongUnit.EmployerHPID, myDataRow["WelderLaborServiceTeam"].ToString().Trim());
                        myDataRow["WelderLaborServiceTeamHPID"] = myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID;
                        if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID))
                        {
                            str_ErrMessage = "劳务队数据有误！";
                        }
                    }
                } 

                if(!Class_Material .ExistAndCanDeleteAndDelete(myDataRow["StudentMaterial"].ToString(), Enum_zwjKindofUpdate.Exist))
                {
                    str_ErrMessage = "母材数据有误！";
                }
                if (!Class_WeldingConsumable .ExistAndCanDeleteAndDelete(myDataRow["StudentWeldingConsumable"].ToString(), Enum_zwjKindofUpdate.Exist))
                {
                    str_ErrMessage = "焊接材料数据有误！";
                }

                if (!DateTime.TryParse(myDataRow["IssuedOn"].ToString().Trim(), out myDateTime))
                {
                    str_ErrMessage = "发证日期数据有误！";
                }
                
                if (!string.IsNullOrEmpty(str_ErrMessage))
                {
                    myDataRow["ErrMessage"] = str_ErrMessage;
                    continue;
                }
                else
                {
                    str_ErrMessage = myClass_Welder.CheckField();
                    if (!string.IsNullOrEmpty(str_ErrMessage))
                    {
                        myDataRow["ErrMessage"] = str_ErrMessage;
                        continue;
                    }
                    string str_WelderName_Temp = Class_Welder.GetWelderName(myClass_Welder.IdentificationCard);
                    if (!string.IsNullOrEmpty(str_WelderName_Temp) && str_WelderName_Temp != myClass_Welder.WelderName)
                    {
                        myDataRow["ErrMessage"] = "姓名与数据库中该焊工不符！";
                        continue;
                    }
                }

                myClass_Student = new Class_Student();
                myClass_Student.IdentificationCard = myClass_Welder.IdentificationCard ;
                myClass_Student.IssueNo = this.str_IssueNo ;
                myClass_Student.SubjectID = myDataRow["ExamSubjectID"].ToString().Trim();
                myClass_Student.ExamStatus ="顺利考试";
                myClass_Student.myClass_WeldingParameter = myClass_Issue.myClass_WeldingParameter;
                str_ErrMessage = myClass_Student.CheckField();
                if (!string.IsNullOrEmpty(str_ErrMessage))
                {
                    myDataRow["ErrMessage"] = str_ErrMessage;
                    continue;
                }
            }
        }

        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true,false  );

        }

        /// <summary>
        /// 冻结或解冻任意数据列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Data);

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

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.CheckData_DataTable();
            if (this.myDataTable.Select("Len(ErrMessage)>0").Length > 0)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text = "有数据不合法，请查看 ErrMessage 字段返回信息！ ";
                return;
            }
            else
            {
                if (MessageBox.Show("确认导入吗？", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            Class_Welder myClass_Welder;
            Class_Student myClass_Student;
            Class_Issue myClass_Issue ;
            //string str_ErrMessage;
            bool bool_WelderFilled;
            foreach (DataRow myDataRow in this.myDataTable.Rows)
            {
                //myDataRow["ErrMessage"] = "";
                //str_ErrMessage = "";
                myClass_Issue = new Class_Issue(myDataRow["IssueNo"].ToString().Trim());

                myClass_Welder = new Class_Welder();
                myClass_Welder.IdentificationCard = myDataRow["IdentificationCard"].ToString().Trim();
                bool_WelderFilled = myClass_Welder.FillData();

                myClass_Welder.WelderName = myDataRow["WelderName"].ToString().Trim();
                myClass_Welder.Schooling = myDataRow["Schooling"].ToString().Trim();
                myClass_Welder.Sex = myDataRow["Sex"].ToString().Trim();
                DateTime.TryParse(myDataRow["WeldingBeginning"].ToString().Trim(), out myClass_Welder.WeldingBeginning);
                myClass_Welder.myClass_BelongUnit.WorkerID = myDataRow["WelderWorkerID"].ToString().Trim();

                myClass_Welder.myClass_BelongUnit.EmployerHPID = myDataRow["WelderEmployerHPID"].ToString();
                myClass_Welder.myClass_BelongUnit.DepartmentHPID = myDataRow["WelderDepartmentHPID"].ToString();
                myClass_Welder.myClass_BelongUnit.WorkPlaceHPID = myDataRow["WelderWorkPlaceHPID"].ToString();
                myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID = myDataRow["WelderLaborServiceTeamHPID"].ToString();

                //str_ErrMessage = myClass_Welder.CheckField();
                //if (!string.IsNullOrEmpty(str_ErrMessage))
                //{
                //    myDataRow["ErrMessage"] = str_ErrMessage;
                //    continue;
                //}

                if (bool_WelderFilled)
                {
                    myClass_Welder.AddAndModify(Enum_zwjKindofUpdate.Modify );
                }
                else
                {
                    myClass_Welder.AddAndModify(Enum_zwjKindofUpdate.Add);
                }              
                Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb );
                if (!Class_TestCommitteeRegistrationNo.ExistSecond(myClass_ShipClassification.TestCommitteeID, myClass_Welder.IdentificationCard, Enum_zwjKindofUpdate.Exist))
                {
                    Class_TestCommittee myClass_TestCommittee=new Class_TestCommittee(myClass_ShipClassification.TestCommitteeID);
                    if (System.Text.RegularExpressions.Regex.IsMatch(myDataRow["RegistrationNo"].ToString().Trim() , myClass_TestCommittee.RegistrationNoRegex))
                    {
                        myClass_TestCommittee.NextRegistrationNo  = myDataRow["RegistrationNo"].ToString().Trim();
                        myClass_TestCommittee.AddAndModify(Enum_zwjKindofUpdate.Modify);
                    }
                }

                myClass_ShipClassification.NextExaminingNo = myDataRow["ExaminingNo"].ToString().Trim();
                myClass_ShipClassification.NextCertificateNo = myDataRow["CertificateNo"].ToString().Trim();
                myClass_ShipClassification.AddAndModify(Enum_zwjKindofUpdate.Modify);
                myClass_Student = new Class_Student();
                myClass_Student.IdentificationCard = myClass_Welder.IdentificationCard ;
                myClass_Student.IssueNo = myClass_Issue.IssueNo ;
                myClass_Student.SubjectID = myDataRow["ExamSubjectID"].ToString().Trim();
                myClass_Student.ExamStatus = "顺利考试";
                int.TryParse(myDataRow["TheoryResult"].ToString(), out myClass_Student.TheoryResult);
                myClass_Student.SkillResult = true;
                myClass_Student.myClass_WeldingParameter = myClass_Issue.myClass_WeldingParameter;
                if(!string.IsNullOrEmpty( myDataRow["StudentMaterial"].ToString().Trim()))
                {
                    myClass_Student.myClass_WeldingParameter.Material = myDataRow["StudentMaterial"].ToString().Trim();
                }
                if (!string.IsNullOrEmpty(myDataRow["StudentWeldingConsumable"].ToString().Trim()))
                {
                    myClass_Student.myClass_WeldingParameter.WeldingConsumable = myDataRow["StudentWeldingConsumable"].ToString().Trim();
                }
                myClass_Student.AddAndModify(Enum_zwjKindofUpdate.Add);

                Class_QC myClass_QC = new Class_QC();
                myClass_QC.ExaminingNo = myClass_Student.ExaminingNo;
                myClass_QC.isQCValid = true;
                DateTime.TryParse(myDataRow["IssuedOn"].ToString().Trim(), out myClass_QC.IssuedOn);
                int.TryParse(myDataRow["OriginalPeriod"].ToString(), out myClass_QC.OriginalPeriod);
                int.TryParse(myDataRow["PeriodofProlongation"].ToString(), out myClass_QC.PeriodofProlongation);
                myClass_QC.SupervisionPlace ="沪东造船";
                myClass_QC.AddAndModify(Enum_zwjKindofUpdate.Add);
                
                //str_ErrMessage = myClass_Student.CheckField();
                //if (!string.IsNullOrEmpty(str_ErrMessage))
                //{
                //    myDataRow["ErrMessage"] = str_ErrMessage;
                //    continue;
                //}
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
