using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;

namespace ZCWelder.Person
{
    public partial class Form_WelderBelong_ImportFromExcel : Form
    {
        private string str_EmployerHPID;
        private string str_DepartmentHPID;
        private string str_WorkPlaceHPID;
        private DataTable myDataTable;
        
        public Form_WelderBelong_ImportFromExcel()
        {
            InitializeComponent();
        }

        private void Form_WelderBelong_ImportFromExcel_Load(object sender, EventArgs e)
        {
            string str_ErrMessage;
            str_ErrMessage = this.CheckSchema_DataTable();
            if (!string.IsNullOrEmpty(this.CheckSchema_DataTable()))
            {
                MessageBox.Show(str_ErrMessage);
                this.Close();
                return;
            }
            DataRow[] myDataRow_Range;
            //myDataRow_Range = this.myDataTable.Select("(len(IdentificationCard)=15 or len(IdentificationCard)=18) and len(WelderName)>0 and (Sex='男' or Sex='女') and len(Schooling)>0 and len(WelderBelongEmployer)>0");
            myDataRow_Range = this.myDataTable.Select("len(IdentificationCard)>0 and len(WelderName)>0 and len(Schooling)>0 and len(WelderBelongEmployer)>0");
            DataTable myDataTable_Temp = this.myDataTable.Clone();
            foreach (DataRow myDataRow in myDataRow_Range)
            {
                myDataTable_Temp.ImportRow(myDataRow);
            }
            this.myDataTable = myDataTable_Temp;

            if (Class_Data.GetDistinctField(this.myDataTable, "IdentificationCard").Rows.Count != this.myDataTable.Rows.Count)
            {
                MessageBox.Show("数据表中有重复的身份证号码！");
                this.Close();
            }
            DataColumn[] keys = new DataColumn[1];
            keys[0] = this.myDataTable.Columns["IdentificationCard"];
            this.myDataTable.PrimaryKey = keys;
            this.dataGridView_Data.DataSource = new DataView(this.myDataTable);
            this.label_Data.Text = string.Format("焊工信息，({0})：", this.dataGridView_Data.RowCount);

        }

        public void InitDataGridView(string str_EmployerHPID, string str_DepartmentHPID, string str_WorkPlaceHPID, DataTable myDataTable)
        {
            Class_Employer myClass_Employer;
            Class_Department myClass_Department;
            Class_WorkPlace myClass_WorkPlace;
            this.str_EmployerHPID = str_EmployerHPID;
            this.str_DepartmentHPID = str_DepartmentHPID;
            this.str_WorkPlaceHPID = str_WorkPlaceHPID;
            this.myDataTable = myDataTable;
            if (string.IsNullOrEmpty(this.str_WorkPlaceHPID))
            {
                if (string.IsNullOrEmpty(this.str_DepartmentHPID))
                {
                    myClass_Employer = new Class_Employer(this.str_EmployerHPID );
                    this.TextBox_Employer.Text = string.Format("{0} : {1}", myClass_Employer.EmployerHPID, myClass_Employer.Employer);
                }
                else
                {
                    myClass_Department = new Class_Department(this.str_DepartmentHPID);
                    this.TextBox_Department.Text = string.Format("{0} : {1}", myClass_Department.DepartmentHPID, myClass_Department.Department);
                    myClass_Employer = new Class_Employer(myClass_Department.EmployerHPID);
                    this.TextBox_Employer.Text = string.Format("{0} : {1}", myClass_Employer.EmployerHPID, myClass_Employer.Employer);
                    this.str_EmployerHPID = myClass_Employer.EmployerHPID;
                }
            }
            else
            {
                myClass_WorkPlace = new Class_WorkPlace(this.str_WorkPlaceHPID);
                this.TextBox_WorkPlace.Text = string.Format("{0} : {1}", myClass_WorkPlace.WorkPlaceHPID, myClass_WorkPlace.WorkPlace);
                myClass_Department = new Class_Department(myClass_WorkPlace.DepartmentHPID );
                this.TextBox_Department.Text = string.Format("{0} : {1}", myClass_Department.DepartmentHPID, myClass_Department.Department);
                myClass_Employer = new Class_Employer(myClass_Department.EmployerHPID);
                this.TextBox_Employer.Text = string.Format("{0} : {1}", myClass_Employer.EmployerHPID, myClass_Employer.Employer);
                this.str_DepartmentHPID = myClass_Department.DepartmentHPID;
                this.str_EmployerHPID = myClass_Employer.EmployerHPID;
           }

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
            else if (!this.myDataTable.Columns.Contains("WelderBelongWorkerID"))
            {
                return "数据表中不存在 'WelderBelongWorkerID' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WelderBelongEmployer"))
            {
                return "数据表中不存在 'WelderBelongEmployer' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WelderBelongDepartment"))
            {
                return "数据表中不存在 'WelderBelongDepartment' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WelderBelongWorkPlace"))
            {
                return "数据表中不存在 'WelderBelongWorkPlace' 列！";
            }
            else if (!this.myDataTable.Columns.Contains("WelderBelongLaborServiceTeam"))
            {
                return "数据表中不存在 'WelderBelongLaborServiceTeam' 列！";
            }
            else if (this.myDataTable.Columns["IdentificationCard"].DataType != System.Type.GetType("System.String"))
            {
                return " 'IdentificationCard' 列必须为字符串值！";
            }

            if (this.myDataTable.Columns.Contains("WelderBelongEmployerHPID"))
            {
                this.myDataTable.Columns.Remove("WelderBelongEmployerHPID");
            }
            DataColumn myDataColumn_EmployerHPID = new DataColumn("WelderBelongEmployerHPID");
            myDataColumn_EmployerHPID.DataType = System.Type.GetType("System.String");
            myDataColumn_EmployerHPID.MaxLength = 4;
            myDataColumn_EmployerHPID.AllowDBNull = true;
            this.myDataTable.Columns.Add(myDataColumn_EmployerHPID);

            if (this.myDataTable.Columns.Contains("WelderBelongDepartmentHPID"))
            {
                this.myDataTable.Columns.Remove("WelderBelongDepartmentHPID");
            }
            DataColumn myDataColumn_DepartmentHPID = new DataColumn("WelderBelongDepartmentHPID");
            myDataColumn_DepartmentHPID.DataType = System.Type.GetType("System.String");
            myDataColumn_DepartmentHPID.MaxLength = 6;
            myDataColumn_DepartmentHPID.AllowDBNull = true;
            this.myDataTable.Columns.Add(myDataColumn_DepartmentHPID);

            if (this.myDataTable.Columns.Contains("WelderBelongWorkPlaceHPID"))
            {
                this.myDataTable.Columns.Remove("WelderBelongWorkPlaceHPID");
            }
            DataColumn myDataColumn_WorkPlaceHPID = new DataColumn("WelderBelongWorkPlaceHPID");
            myDataColumn_WorkPlaceHPID.DataType = System.Type.GetType("System.String");
            myDataColumn_WorkPlaceHPID.MaxLength = 8;
            myDataColumn_WorkPlaceHPID.AllowDBNull = true;
            this.myDataTable.Columns.Add(myDataColumn_WorkPlaceHPID);

            if (this.myDataTable.Columns.Contains("WelderBelongLaborServiceTeamHPID"))
            {
                this.myDataTable.Columns.Remove("WelderBelongLaborServiceTeamHPID");
            }
            DataColumn myDataColumn_LaborServiceTeamHPID = new DataColumn("WelderBelongLaborServiceTeamHPID");
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
                this.myDataTable.Columns.Add (myDataColumn_ErrMessage);
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

        private void CheckData_DataTable()
        {
            Class_Welder myClass_Welder;
            string str_ErrMessage;
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
                myClass_Welder.myClass_BelongUnit.WorkerID = myDataRow["WelderBelongWorkerID"].ToString().Trim();

                //myClass_Welder.myClass_BelongUnit.EmployerHPID = Class_Employer.GetEmployerHPID(myDataRow["WelderBelongEmployer"].ToString());
                myClass_Welder.myClass_BelongUnit.EmployerHPID = Class_Employer.GetEmployerHPIDbyDataTable(myDataRow["WelderBelongEmployer"].ToString().Trim());
                myDataRow["WelderBelongEmployerHPID"] = myClass_Welder.myClass_BelongUnit.EmployerHPID;
                if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.EmployerHPID))
                {
                    str_ErrMessage = "公司数据有误！";
                }
                else
                {
                    if (!string.IsNullOrEmpty(myDataRow["WelderBelongDepartment"].ToString()))
                    {
                        //myClass_Welder.myClass_BelongUnit.DepartmentHPID = Class_Department.GetDepartmentHPID(myClass_Welder.myClass_BelongUnit.EmployerHPID, myDataRow["WelderBelongDepartment"].ToString());
                        myClass_Welder.myClass_BelongUnit.DepartmentHPID = Class_Department.GetDepartmentHPIDbyDataTable(myClass_Welder.myClass_BelongUnit.EmployerHPID, myDataRow["WelderBelongDepartment"].ToString().Trim());
                        myDataRow["WelderBelongDepartmentHPID"] = myClass_Welder.myClass_BelongUnit.DepartmentHPID;
                        if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.DepartmentHPID))
                        {
                            str_ErrMessage = "部门数据有误！";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(myDataRow["WelderBelongWorkPlace"].ToString()))
                            {
                                //myClass_Welder.myClass_BelongUnit.WorkPlaceHPID = Class_WorkPlace.GetWorkPlaceHPID(myClass_Welder.myClass_BelongUnit.DepartmentHPID, myDataRow["WelderBelongWorkPlace"].ToString());
                                myClass_Welder.myClass_BelongUnit.WorkPlaceHPID = Class_WorkPlace.GetWorkPlaceHPIDbyDataTable(myClass_Welder.myClass_BelongUnit.DepartmentHPID, myDataRow["WelderBelongWorkPlace"].ToString().Trim());
                                myDataRow["WelderBelongWorkPlaceHPID"] = myClass_Welder.myClass_BelongUnit.WorkPlaceHPID;
                                if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.WorkPlaceHPID))
                                {
                                    str_ErrMessage = "作业区数据有误！";
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(myDataRow["WelderBelongLaborServiceTeam"].ToString()))
                    {
                        //myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID = Class_LaborServiceTeam.GetLaborServiceTeamHPID(myClass_Welder.myClass_BelongUnit.EmployerHPID, myDataRow["WelderBelongLaborServiceTeam"].ToString());
                        myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID = Class_LaborServiceTeam.GetLaborServiceTeamHPIDbyDataTable(myClass_Welder.myClass_BelongUnit.EmployerHPID, myDataRow["WelderBelongLaborServiceTeam"].ToString().Trim());
                        myDataRow["WelderBelongLaborServiceTeamHPID"] = myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID;
                        if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID))
                        {
                            str_ErrMessage = "劳务队数据有误！";
                        }
                    }          
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

                if (!Class_Schooling.ExistAndCanDeleteAndDelete(myClass_Welder.Schooling, Enum_zwjKindofUpdate.Exist))
                {
                    myDataRow["ErrMessage"] = "学历有误！";
                    continue;
                }

                if (!string.IsNullOrEmpty(this.str_WorkPlaceHPID))
                {
                    if (myClass_Welder.myClass_BelongUnit.WorkPlaceHPID != this.str_WorkPlaceHPID)
                    {
                        myDataRow["ErrMessage"] = "作业区超出导入数据范围，请重新选择导入单位！";
                        continue;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.str_DepartmentHPID))
                    {
                        if (myClass_Welder.myClass_BelongUnit.DepartmentHPID != this.str_DepartmentHPID)
                        {
                            myDataRow["ErrMessage"] = "部门超出导入数据范围，请重新选择导入单位！";
                            continue;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(this.str_EmployerHPID ))
                        {
                            if (myClass_Welder.myClass_BelongUnit.EmployerHPID != this.str_EmployerHPID)
                            {
                                myDataRow["ErrMessage"] = "公司超出导入数据范围，请重新选择导入单位！";
                                continue;
                            }
                        }
                    }
                }
                //if (Class_WelderBelong.GetWelderBelong(myClass_Welder.IdentificationCard, this.str_EmployerHPID, this.str_DepartmentHPID, this.str_WorkPlaceHPID).Rows.Count > 1)
                //{
                //    myDataRow["ErrMessage"] = "数据库中该单位下该焊工有两条记录！";
                //    continue;
                //}
                //if (Class_WelderBelong.GetWelderBelong(myClass_Welder.IdentificationCard, this.str_EmployerHPID, this.str_DepartmentHPID, this.str_WorkPlaceHPID).Rows.Count > 0)
                //{
                //    myDataRow["ErrMessage"] = "数据库中该单位下已存在该焊工！";
                //    continue;
                //}
            }
        }

        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, false);

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
            //删除数据库中该单位下多余的焊工名单(不在Excel文件中的焊工)
            if (this.checkBox_DeleteWelderBelongAll.Checked)
            {
                //Class_WelderBelong.DeleteBatch(this.str_EmployerHPID, this.str_DepartmentHPID, this.str_WorkPlaceHPID);
                DataTable myDataTable_Temp = Class_WelderBelong.GetWelderBelong("", this.str_EmployerHPID, this.str_DepartmentHPID, this.str_WorkPlaceHPID);
                foreach (DataRow myDataRow_Temp in myDataTable_Temp.Rows)
                {
                    if (this.myDataTable.Rows.Find(myDataRow_Temp["IdentificationCard"].ToString()) == null)
                    {
                        Class_WelderBelong.ExistAndCanDeleteAndDelete((long)myDataRow_Temp["WelderBelongID"], Enum_zwjKindofUpdate.Delete);
                    }
                }
            }
            Class_Welder myClass_Welder;
            Class_WelderBelong myClass_WelderBelong;
            bool bool_WelderFilled;
            //string str_ErrMessage;
            foreach (DataRow myDataRow in this.myDataTable.Rows)
            {
                //myDataRow["ErrMessage"] = "";
                //str_ErrMessage = "";
                myClass_Welder = new Class_Welder();
                myClass_Welder.IdentificationCard = myDataRow["IdentificationCard"].ToString().Trim();
                bool_WelderFilled=myClass_Welder.FillData();

                myClass_Welder.WelderName = myDataRow["WelderName"].ToString().Trim();
                myClass_Welder.Schooling = myDataRow["Schooling"].ToString().Trim();
                myClass_Welder.Sex = myDataRow["Sex"].ToString().Trim();
                DateTime.TryParse(myDataRow["WeldingBeginning"].ToString().Trim(), out myClass_Welder.WeldingBeginning);
                myClass_Welder.myClass_BelongUnit.WorkerID = myDataRow["WelderBelongWorkerID"].ToString().Trim();

                myClass_Welder.myClass_BelongUnit.EmployerHPID = myDataRow["WelderBelongEmployerHPID"].ToString();
                myClass_Welder.myClass_BelongUnit.DepartmentHPID = myDataRow["WelderBelongDepartmentHPID"].ToString();
                myClass_Welder.myClass_BelongUnit.WorkPlaceHPID = myDataRow["WelderBelongWorkPlaceHPID"].ToString();
                myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID = myDataRow["WelderBelongLaborServiceTeamHPID"].ToString();

                if (bool_WelderFilled)
                {
                    myClass_Welder.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
                else
                {
                    myClass_Welder.AddAndModify(Enum_zwjKindofUpdate.Add);
                }

                //如果该单位下已存在该焊工，则修改相应信息
                DataTable myDataTable_Temp = Class_WelderBelong.GetWelderBelong(myClass_Welder.IdentificationCard, this.str_EmployerHPID, this.str_DepartmentHPID, this.str_WorkPlaceHPID);
                myClass_WelderBelong = new Class_WelderBelong();
                if (myDataTable_Temp.Rows.Count > 0)
                {
                    foreach (DataRow myDataRow_Temp in myDataTable_Temp.Rows)
                    {
                        myClass_WelderBelong.WelderBelongID = (long)myDataRow_Temp["WelderBelongID"];
                        myClass_WelderBelong.IdentificationCard = myClass_Welder.IdentificationCard;
                        myClass_WelderBelong.myClass_BelongUnit = myClass_Welder.myClass_BelongUnit;
                        myClass_WelderBelong.AddAndModify(Enum_zwjKindofUpdate.Modify );
                    }
                }
                else
                {
                    myClass_WelderBelong.IdentificationCard = myClass_Welder.IdentificationCard;
                    myClass_WelderBelong.myClass_BelongUnit = myClass_Welder.myClass_BelongUnit;
                    myClass_WelderBelong.AddAndModify(Enum_zwjKindofUpdate.Add);
                }

            }
        }

    }
}