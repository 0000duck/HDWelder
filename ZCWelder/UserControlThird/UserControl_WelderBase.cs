using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WelderBase : UserControl
    {
        private DataView myDataView_Employer;
        private DataView myDataView_Department;
        private DataView myDataView_WorkPlace;
        private DataView myDataView_LaborServiceTeam;

        public Class_Welder myClass_Welder;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_Welder myClass_WelderDefault;

        public UserControl_WelderBase()
        {
            InitializeComponent();
        }

        private void UserControl_Welder_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_Welder"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_Welder myClass_Welder, bool bool_Add)
        {
            Class_Data myClass_Data;
            myClass_Data=(Class_Data)Class_Public.myHashtable[Enum_DataTable.Employer.ToString()];
            this.myDataView_Employer = new DataView(myClass_Data.myDataTable );
            this.myDataView_Employer.Sort=myClass_Data.myDataView.Sort ;
            
            myClass_Data=(Class_Data)Class_Public.myHashtable[Enum_DataTable.Department.ToString()];
            this.myDataView_Department = new DataView(myClass_Data.myDataTable );
            this.myDataView_Department.Sort=myClass_Data.myDataView.Sort ;
            
            myClass_Data=(Class_Data)Class_Public.myHashtable[Enum_DataTable.WorkPlace.ToString()];
            this.myDataView_WorkPlace = new DataView(myClass_Data.myDataTable );
            this.myDataView_WorkPlace.Sort=myClass_Data.myDataView.Sort ;
           
            myClass_Data=(Class_Data)Class_Public.myHashtable[Enum_DataTable.LaborServiceTeam.ToString()];
            this.myDataView_LaborServiceTeam = new DataView(myClass_Data.myDataTable );
            this.myDataView_LaborServiceTeam.Sort=myClass_Data.myDataView.Sort ;
            
            Class_DataControlBind.InitializeComboBox(this.ComboBox_LaborServiceTeam, this.myDataView_LaborServiceTeam,"LaborServiceTeamHPID", "LaborServiceTeam");
            Class_DataControlBind.InitializeComboBox(this.ComboBox_WorkPlace, this.myDataView_WorkPlace,"WorkPlaceHPID", "WorkPlace");
            Class_DataControlBind.InitializeComboBox(this.ComboBox_Department, this.myDataView_Department,"DepartmentHPID", "Department");
            Class_DataControlBind.InitializeComboBox(this.ComboBox_Employer, this.myDataView_Employer,"EmployerHPID", "Employer");
            Class_Public .InitializeComboBox(this.ComboBox_Schooling , Enum_DataTable.Schooling.ToString(),"Schooling", "Schooling");

            this.myClass_Welder = myClass_Welder;
            this.MaskedTextBox_IdentificationCard.Text = myClass_Welder.IdentificationCard;
            this.TextBox_WelderName.Text = myClass_Welder.WelderName;
            this.TextBox_WorkerID.Text = myClass_Welder.myClass_BelongUnit.WorkerID;
            if (bool_Add)
            {
                if (myClass_WelderDefault != null)
                {
                    this.CheckBox_Sex.Checked = myClass_WelderDefault.Sex == "男";
                    this.DateTimePicker_WeldingBeinning.Value = myClass_WelderDefault.WeldingBeginning;
                    this.ComboBox_Schooling.SelectedValue = myClass_WelderDefault.Schooling;
                    this.ComboBox_Employer.SelectedValue = myClass_WelderDefault.myClass_BelongUnit.EmployerHPID;
                    this.myDataView_Department.RowFilter = string.Format("EmployerHPID='{0}'", myClass_WelderDefault.myClass_BelongUnit.EmployerHPID);
                    this.myDataView_LaborServiceTeam.RowFilter = string.Format("EmployerHPID='{0}'", myClass_WelderDefault.myClass_BelongUnit.EmployerHPID);
                    if (string.IsNullOrEmpty(myClass_WelderDefault.myClass_BelongUnit.DepartmentHPID))
                    {
                        this.CheckBox_Department.Checked = false;
                    }
                    else
                    {
                        this.ComboBox_Department.SelectedValue = myClass_WelderDefault.myClass_BelongUnit.DepartmentHPID;
                        this.CheckBox_Department.Checked = true;
                        this.myDataView_WorkPlace.RowFilter = string.Format("DepartmentHPID='{0}'", myClass_WelderDefault.myClass_BelongUnit.DepartmentHPID);
                        if (!string.IsNullOrEmpty(myClass_WelderDefault.myClass_BelongUnit.WorkPlaceHPID))
                        {
                            this.ComboBox_WorkPlace.SelectedValue = myClass_WelderDefault.myClass_BelongUnit.WorkPlaceHPID;
                            this.CheckBox_WorkPlace.Checked = true;
                        }
                        else
                        {
                            this.CheckBox_WorkPlace.Checked = false;
                        }
                    }

                    if (string.IsNullOrEmpty(myClass_WelderDefault.myClass_BelongUnit.LaborServiceTeamHPID))
                    {
                        this.CheckBox_LaborServiceTeam.Checked = false;
                    }
                    else
                    {
                        this.ComboBox_LaborServiceTeam.SelectedValue = myClass_WelderDefault.myClass_BelongUnit.LaborServiceTeamHPID;
                        this.CheckBox_LaborServiceTeam.Checked = true;
                    }

                }
            }
            else
            {
                this.Button_IdentificationCardConvert.Enabled = false;
                this.MaskedTextBox_IdentificationCard.ReadOnly = true;
                this.textBox_WelderEnglishName.Text = myClass_Welder.WelderEnglishName;
                this.CheckBox_Sex.Checked =myClass_Welder.Sex == "男";
                this.DateTimePicker_WeldingBeinning.Value = myClass_Welder.WeldingBeginning;
                this.TextBox_WelderRemark.Text = myClass_Welder.WelderRemark;
                this.ComboBox_Schooling.SelectedValue = myClass_Welder.Schooling;
                this.ComboBox_Employer.SelectedValue = myClass_Welder.myClass_BelongUnit.EmployerHPID;
                this.myDataView_Department.RowFilter = string.Format("EmployerHPID='{0}'", myClass_Welder.myClass_BelongUnit.EmployerHPID);
                this.myDataView_LaborServiceTeam.RowFilter = string.Format("EmployerHPID='{0}'", myClass_Welder.myClass_BelongUnit.EmployerHPID);
                if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.DepartmentHPID))
                {
                    this.CheckBox_Department .Checked = false;
                }
                else
                {
                    this.ComboBox_Department.SelectedValue = myClass_Welder.myClass_BelongUnit.DepartmentHPID;
                    this.CheckBox_Department.Checked = true;
                    this.myDataView_WorkPlace.RowFilter = string.Format("DepartmentHPID='{0}'", myClass_Welder.myClass_BelongUnit.DepartmentHPID);
                    if (!string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.WorkPlaceHPID))
                    {
                        this.ComboBox_WorkPlace.SelectedValue = myClass_Welder.myClass_BelongUnit.WorkPlaceHPID;
                        this.CheckBox_WorkPlace.Checked = true;
                    }
                    else
                    {
                        this.CheckBox_WorkPlace.Checked = false;
                    }
                }

                if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID))
                {
                    this.CheckBox_LaborServiceTeam.Checked = false;
                }
                else
                {
                    this.ComboBox_LaborServiceTeam.SelectedValue = myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID;
                    this.CheckBox_LaborServiceTeam.Checked = true;
                }

            }
        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_Welder.IdentificationCard = this.MaskedTextBox_IdentificationCard.Text;
            myClass_Welder.WelderName = this.TextBox_WelderName.Text;
            myClass_Welder.WelderEnglishName = this.textBox_WelderEnglishName.Text;
            myClass_Welder.Sex = this.CheckBox_Sex.Checked ? "男" : "女";
            myClass_Welder.Schooling = this.ComboBox_Schooling.SelectedValue.ToString();
            myClass_Welder.WeldingBeginning = this.DateTimePicker_WeldingBeinning.Value;
            myClass_Welder.myClass_BelongUnit.EmployerHPID = this.ComboBox_Employer.SelectedValue.ToString();
            if (this.CheckBox_Department.Checked && this.ComboBox_Department.SelectedValue != null)
            {
                myClass_Welder.myClass_BelongUnit.DepartmentHPID = this.ComboBox_Department.SelectedValue.ToString();
                if (this.CheckBox_WorkPlace.Checked && this.ComboBox_WorkPlace.SelectedValue != null)
                {
                    myClass_Welder.myClass_BelongUnit.WorkPlaceHPID = this.ComboBox_WorkPlace.SelectedValue.ToString();
                }
                else
                {
                    myClass_Welder.myClass_BelongUnit.WorkPlaceHPID = "";
                }
            }
            else
            {
                myClass_Welder.myClass_BelongUnit.DepartmentHPID = "";
            }
            if (this.CheckBox_LaborServiceTeam.Checked && this.ComboBox_LaborServiceTeam.SelectedValue != null)
            {
                myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID = this.ComboBox_LaborServiceTeam.SelectedValue.ToString();
            }
            else
            {
                myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID = "";
            }
            myClass_Welder.myClass_BelongUnit.WorkerID = this.TextBox_WorkerID.Text;
            myClass_Welder.WelderRemark = this.TextBox_WelderRemark.Text;

            if (myClass_WelderDefault == null)
            {
                myClass_WelderDefault = new Class_Welder();
            }
            myClass_WelderDefault.Schooling = myClass_Welder.Schooling;
            myClass_WelderDefault.Sex  = myClass_Welder.Sex ;
            myClass_WelderDefault.WeldingBeginning = myClass_Welder.WeldingBeginning;
            myClass_WelderDefault.myClass_BelongUnit.EmployerHPID = myClass_Welder.myClass_BelongUnit.EmployerHPID ;
            myClass_WelderDefault.myClass_BelongUnit.DepartmentHPID = myClass_Welder.myClass_BelongUnit.DepartmentHPID;
            myClass_WelderDefault.myClass_BelongUnit.WorkPlaceHPID = myClass_Welder.myClass_BelongUnit.WorkPlaceHPID;
            myClass_WelderDefault.myClass_BelongUnit.LaborServiceTeamHPID = myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID;

        }

        private void ComboBox_Employer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.myDataView_Department.RowFilter = string .Format("EmployerHPID='{0}'", this.ComboBox_Employer.SelectedValue.ToString ());
            this.myDataView_LaborServiceTeam.RowFilter = string .Format("EmployerHPID='{0}'", this.ComboBox_Employer.SelectedValue.ToString ());
            if (this.ComboBox_Department.SelectedValue!=null)
            {
                this.myDataView_WorkPlace.RowFilter = string.Format("DepartmentHPID='{0}'" , this.ComboBox_Department.SelectedValue.ToString());
            }
            else
            {
                this.myDataView_WorkPlace.RowFilter = "DepartmentHPID='0'";
            }

        }

        private void ComboBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ComboBox_Department.SelectedValue!=null)
            {
                this.myDataView_WorkPlace.RowFilter = string.Format("DepartmentHPID='{0}'" , this.ComboBox_Department.SelectedValue.ToString());
            }
            else
            {
                this.myDataView_WorkPlace.RowFilter = "DepartmentHPID='0'";
            }

        }

        private void CheckBox_Department_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.CheckBox_Department.Checked)
            {
                this.CheckBox_WorkPlace.Checked = false;
            }

        }

        private void CheckBox_WorkPlace_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.CheckBox_Department.Checked)
            {
                this.CheckBox_WorkPlace.Checked = false;
            }
        }

        private void Button_IdentificationCardConvert_Click(object sender, EventArgs e)
        {
            this.MaskedTextBox_IdentificationCard.Text = ZCCL.Tools.Class_DataValidateTool.CovertIdentificationCard(this.MaskedTextBox_IdentificationCard.Text);

        }

    }
}
