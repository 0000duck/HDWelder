using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using System.Text.RegularExpressions;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WelderPicture_View : UserControl
    {
        private string[] str_FileNameRange;
        private DataTable myDataTable;
        private DataView myDataView;
            
        public UserControl_WelderPicture_View()
        {
            InitializeComponent();
        }

        private void UserControl_WelderPicture_View_Load(object sender, EventArgs e)
        {
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, "WelderPictureFileName", false);
            this.myDataTable = new DataTable("WelderPictureFileName");
            
            DataColumn myDataColumn_WelderPictureFileName = new DataColumn("WelderPictureFileName");
            myDataColumn_WelderPictureFileName.DataType = System.Type.GetType("System.String");
            myDataColumn_WelderPictureFileName.MaxLength = 255;
            myDataColumn_WelderPictureFileName.AllowDBNull = true;
            myDataTable.Columns.Add(myDataColumn_WelderPictureFileName);

            DataColumn myDataColumn_isValid = new DataColumn("WelderPictureisValid");
            myDataColumn_isValid.DataType = System.Type.GetType("System.Int32");
            myDataColumn_isValid.AllowDBNull = true;
            myDataTable.Columns.Add(myDataColumn_isValid);
            this.myDataView = new DataView(this.myDataTable);
        }

        private void InitDataGridView()
        {
            this.dataGridView_Data.DataSource = null;
            str_FileNameRange = Class_Welder.GetWelderPictureFileNames();
            myDataTable.Rows.Clear();
            DataRow myDataRow;
            bool b = true;
            foreach (string str_FileName in str_FileNameRange)
            {
                myDataRow = myDataTable.NewRow();
                myDataRow["WelderPictureFileName"] = str_FileName;
                myDataTable.Rows.Add(myDataRow);
            }
            this.myDataView = new DataView(this.myDataTable);
            this.dataGridView_Data.DataSource = this.myDataView;
            this.label_Data.Text = string.Format("焊工照片文件名：({0})", this.dataGridView_Data.RowCount  );
            
        }

        private void toolStripMenuItem_ListViewRefresh_Click(object sender, EventArgs e)
        {
            this.InitDataGridView();
            this.DetectValid();
        }

        public void InitControlWelder(Class_Welder myClass_Welder)
        {
            this.TextBox_WelderName.Text = myClass_Welder.WelderName;
            this.MaskedTextBox_IdentificationCard.Text = myClass_Welder.IdentificationCard;
            this.TextBox_Schooling.Text = myClass_Welder.Schooling;
            this.TextBox_WelderEnglishName.Text = myClass_Welder.WelderEnglishName;
            this.textBox_WeldingBeginning .Text  = myClass_Welder.WeldingBeginning.ToShortDateString ();
            this.TextBox_WorkerID.Text = myClass_Welder.myClass_BelongUnit.WorkerID;
            if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.EmployerHPID))
            {
                this.TextBox_Employer.Text = "";
            }
            else
            {
                Class_Employer myClass_Employer = new Class_Employer(myClass_Welder.myClass_BelongUnit.EmployerHPID);
                this.TextBox_Employer.Text = myClass_Employer.Employer;
            }
            if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.DepartmentHPID))
            {
                this.TextBox_Department.Text = "";
            }
            else
            {
                Class_Department myClass_Department = new Class_Department(myClass_Welder.myClass_BelongUnit.DepartmentHPID);
                this.TextBox_Department.Text = myClass_Department.Department;
            }
            if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.WorkPlaceHPID))
            {
                this.TextBox_WorkPlace.Text = "";
            }
            else
            {
                Class_WorkPlace myClass_WorkPlace = new Class_WorkPlace(myClass_Welder.myClass_BelongUnit.WorkPlaceHPID);
                this.TextBox_WorkPlace.Text = myClass_WorkPlace.WorkPlace;
            }
            if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID))
            {
                this.TextBox_LaborServiceTeam.Text = "";
            }
            else
            {
                Class_LaborServiceTeam myClass_LaborServiceTeam = new Class_LaborServiceTeam(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID);
                this.TextBox_LaborServiceTeam.Text = myClass_LaborServiceTeam.LaborServiceTeam;
            }
            this.CheckBox_Sex.Checked = myClass_Welder.Sex == "男";
        }

        private void toolStripMenuItem_ExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.ExportExcelFromDataTable(this.myDataTable, true, false);

        }

        private void button_DownLoadPicture_Click(object sender, EventArgs e)
        {
            if (this.pictureBox_Data .Image != null)
            {
                SaveFileDialog mySaveFileDialog = new SaveFileDialog();
                mySaveFileDialog.Filter = "All files (*.JPG)|*.JPG";
                mySaveFileDialog.FileName = this.textBox_FileName.Text;
                mySaveFileDialog.RestoreDirectory = true;
                if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBox_Data.Image.Save(mySaveFileDialog.FileName);
                }
            }

        }

        private void button_DeletePicture_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox_FileName.Text))
            {
                return;
            }
            if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Class_Welder.DeleteWelderPicturebyFileName(this.textBox_FileName.Text);
                this.pictureBox_Data.Image = null;
            }

        }

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string str_FileName = this.dataGridView_Data.Rows[e.RowIndex].Cells["WelderPictureFileName"].Value.ToString();
            this.textBox_FileName.Text = str_FileName;
            string str_IdentificationCard = null;
            Regex myRegex = new Regex("\\d{17}[0-9Xx]");
            Match myMatch = myRegex.Match(str_FileName);
            if (myMatch.Success)
            {
                str_IdentificationCard = myMatch.Value;
            }
            if (!string.IsNullOrEmpty(str_IdentificationCard))
            {
                this.InitControlWelder(new Class_Welder(str_IdentificationCard));
            }
            else
            {
                this.InitControlWelder(new Class_Welder());
            }
            if (Regex.IsMatch(str_FileName, "\\.[jJ][pP][Gg]$"))
            {
                this.pictureBox_Data.Image = Class_Welder.GetWelderPicturebyFileName (str_FileName);
            }
            else
            {
                this.pictureBox_Data.Image = null;
            }
        }

        private void DetectValid()
        {
            Regex myRegex = new Regex("\\d{17}[0-9Xx]");
            Match myMatch;
            foreach (DataRow myDataRow in  this.myDataTable.Rows)
            {
                myMatch = myRegex.Match(myDataRow["WelderPictureFileName"].ToString());
                if (myMatch.Success)
                {
                    if (Class_Welder.ExistAndCanDeleteAndDelete(myMatch.Value, Enum_zwjKindofUpdate.Exist))
                    {
                        myDataRow["WelderPictureisValid"] = 1;
                    }
                    else
                    {
                        myDataRow["WelderPictureisValid"] = 0;
                    }
                }
                else
                {
                    myDataRow["WelderPictureisValid"] = 0;
                }
            }
        
        }

        private void toolStripMenuItem_DetectValid_Click(object sender, EventArgs e)
        {
            this.DetectValid();
            MessageBox.Show("操作完成！");  
        }

    }
}
