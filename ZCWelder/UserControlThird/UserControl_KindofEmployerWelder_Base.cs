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
    public partial class UserControl_KindofEmployerWelder_Base : UserControl
    {
        private DataView myDataView_Employer;
        private DataView myDataView_Department;
        private DataView myDataView_WorkPlace;
        private DataView myDataView_LaborServiceTeam;

        public Class_KindofEmployerWelder myClass_KindofEmployerWelder;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_KindofEmployerWelder myClass_KindofEmployerWelderDefault;

        public UserControl_KindofEmployerWelder_Base()
        {
            InitializeComponent();
        }

        private void UserControl_KindofEmployerWelder_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_KindofEmployerWelder"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_KindofEmployerWelder myClass_KindofEmployerWelder, bool bool_Add)
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

            this.myClass_KindofEmployerWelder = myClass_KindofEmployerWelder;
            this.textBox_KindofEmployer.Text = this.myClass_KindofEmployerWelder.KindofEmployer;
         
            Class_KindofEmployer myClass_KindofEmployer = new Class_KindofEmployer(this.myClass_KindofEmployerWelder.KindofEmployer);
            switch (myClass_KindofEmployer.KindofEmployerLevel)
            {
                case 0:
                    break;
                case 1:
                    this.ComboBox_Employer.Enabled = false;
                    break;
                case 2:
                    this.ComboBox_Employer.Enabled = false;
                    this.ComboBox_Department.Enabled = false;
                    this.CheckBox_Department.Enabled = false;
                    break;
                case 3:
                    this.ComboBox_Employer.Enabled = false;
                    this.ComboBox_Department.Enabled = false;
                    this.CheckBox_Department.Enabled = false;
                    this.ComboBox_WorkPlace.Enabled = false;
                    this.CheckBox_WorkPlace.Enabled = false;
                    break;
                case 4:
                    this.ComboBox_Employer.Enabled = false;
                    this.ComboBox_LaborServiceTeam .Enabled = false;
                    this.CheckBox_LaborServiceTeam .Enabled = false;
                    break;

            }
            if (bool_Add)
            {
                if (!string.IsNullOrEmpty(myClass_KindofEmployer.KindofEmployerEmployerHPID))
                {
                    this.ComboBox_Employer.SelectedValue = myClass_KindofEmployer.KindofEmployerEmployerHPID;
                    if (!string.IsNullOrEmpty(myClass_KindofEmployer.KindofEmployerDepartmentHPID))
                    {
                        this.ComboBox_Department.SelectedValue = myClass_KindofEmployer.KindofEmployerDepartmentHPID;
                        if (!string.IsNullOrEmpty(myClass_KindofEmployer.KindofEmployerWorkPlaceHPID))
                        {
                            this.ComboBox_WorkPlace.SelectedValue = myClass_KindofEmployer.KindofEmployerWorkPlaceHPID;
                        }
                    }
                    if (!string.IsNullOrEmpty(myClass_KindofEmployer.KindofEmployerLaborServiceTeamHPID))
                    {
                        this.ComboBox_LaborServiceTeam.SelectedValue = myClass_KindofEmployer.KindofEmployerLaborServiceTeamHPID;
                    }

                }

                if (myClass_KindofEmployerWelderDefault != null)
                {
                    this.CheckBox_Sex.Checked = myClass_KindofEmployerWelderDefault.Sex == "男";
                    this.DateTimePicker_WeldingBeinning.Value = myClass_KindofEmployerWelderDefault.WeldingBeginning;
                    this.ComboBox_Schooling.SelectedValue = myClass_KindofEmployerWelderDefault.Schooling;
                    this.ComboBox_Employer.SelectedValue = myClass_KindofEmployerWelderDefault.myClass_BelongUnit.EmployerHPID;
                    this.myDataView_Department.RowFilter = string.Format("EmployerHPID='{0}'", myClass_KindofEmployerWelderDefault.myClass_BelongUnit.EmployerHPID);
                    this.myDataView_LaborServiceTeam.RowFilter = string.Format("EmployerHPID='{0}'", myClass_KindofEmployerWelderDefault.myClass_BelongUnit.EmployerHPID);
                    if (string.IsNullOrEmpty(myClass_KindofEmployerWelderDefault.myClass_BelongUnit.DepartmentHPID))
                    {
                        this.CheckBox_Department.Checked = false;
                    }
                    else
                    {
                        this.ComboBox_Department.SelectedValue = myClass_KindofEmployerWelderDefault.myClass_BelongUnit.DepartmentHPID;
                        this.CheckBox_Department.Checked = true;
                        this.myDataView_WorkPlace.RowFilter = string.Format("DepartmentHPID='{0}'", myClass_KindofEmployerWelderDefault.myClass_BelongUnit.DepartmentHPID);
                        if (!string.IsNullOrEmpty(myClass_KindofEmployerWelderDefault.myClass_BelongUnit.WorkPlaceHPID))
                        {
                            this.ComboBox_WorkPlace.SelectedValue = myClass_KindofEmployerWelderDefault.myClass_BelongUnit.WorkPlaceHPID;
                            this.CheckBox_WorkPlace.Checked = true;
                        }
                        else
                        {
                            this.CheckBox_WorkPlace.Checked = false;
                        }
                    }

                    if (string.IsNullOrEmpty(myClass_KindofEmployerWelderDefault.myClass_BelongUnit.LaborServiceTeamHPID))
                    {
                        this.CheckBox_LaborServiceTeam.Checked = false;
                    }
                    else
                    {
                        this.ComboBox_LaborServiceTeam.SelectedValue = myClass_KindofEmployerWelderDefault.myClass_BelongUnit.LaborServiceTeamHPID;
                        this.CheckBox_LaborServiceTeam.Checked = true;
                    }

                }
            }
            else
            {
                this.textBox_KindofEmployerWelderID.Text = this.myClass_KindofEmployerWelder.KindofEmployerWelderID.ToString();
                this.Button_IdentificationCardConvert.Enabled = false;
                this.MaskedTextBox_IdentificationCard.Text = myClass_KindofEmployerWelder.IdentificationCard;
                this.TextBox_WelderName.Text = myClass_KindofEmployerWelder.WelderName;
                this.textBox_WelderEnglishName.Text = myClass_KindofEmployerWelder.WelderEnglishName;
                this.CheckBox_Sex.Checked =myClass_KindofEmployerWelder.Sex == "男";
                this.DateTimePicker_WeldingBeinning.Value = myClass_KindofEmployerWelder.WeldingBeginning;
                this.TextBox_WorkerID.Text = myClass_KindofEmployerWelder.myClass_BelongUnit.WorkerID;
                this.TextBox_WelderRemark.Text = myClass_KindofEmployerWelder.WelderRemark;
                this.ComboBox_Schooling.SelectedValue = myClass_KindofEmployerWelder.Schooling;
                this.ComboBox_Employer.SelectedValue = myClass_KindofEmployerWelder.myClass_BelongUnit.EmployerHPID;
                this.myDataView_Department.RowFilter = string.Format("EmployerHPID='{0}'", myClass_KindofEmployerWelder.myClass_BelongUnit.EmployerHPID);
                this.myDataView_LaborServiceTeam.RowFilter = string.Format("EmployerHPID='{0}'", myClass_KindofEmployerWelder.myClass_BelongUnit.EmployerHPID);
                if (string.IsNullOrEmpty(myClass_KindofEmployerWelder.myClass_BelongUnit.DepartmentHPID))
                {
                    this.CheckBox_Department .Checked = false;
                }
                else
                {
                    this.ComboBox_Department.SelectedValue = myClass_KindofEmployerWelder.myClass_BelongUnit.DepartmentHPID;
                    this.CheckBox_Department.Checked = true;
                    this.myDataView_WorkPlace.RowFilter = string.Format("DepartmentHPID='{0}'", myClass_KindofEmployerWelder.myClass_BelongUnit.DepartmentHPID);
                    if (!string.IsNullOrEmpty(myClass_KindofEmployerWelder.myClass_BelongUnit.WorkPlaceHPID))
                    {
                        this.ComboBox_WorkPlace.SelectedValue = myClass_KindofEmployerWelder.myClass_BelongUnit.WorkPlaceHPID;
                        this.CheckBox_WorkPlace.Checked = true;
                    }
                    else
                    {
                        this.CheckBox_WorkPlace.Checked = false;
                    }
                }

                if (string.IsNullOrEmpty(myClass_KindofEmployerWelder.myClass_BelongUnit.LaborServiceTeamHPID))
                {
                    this.CheckBox_LaborServiceTeam.Checked = false;
                }
                else
                {
                    this.ComboBox_LaborServiceTeam.SelectedValue = myClass_KindofEmployerWelder.myClass_BelongUnit.LaborServiceTeamHPID;
                    this.CheckBox_LaborServiceTeam.Checked = true;
                }

            }
        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_KindofEmployerWelder.IdentificationCard = this.MaskedTextBox_IdentificationCard.Text;
            myClass_KindofEmployerWelder.WelderName = this.TextBox_WelderName.Text;
            myClass_KindofEmployerWelder.WelderEnglishName = this.textBox_WelderEnglishName.Text;
            myClass_KindofEmployerWelder.Sex = this.CheckBox_Sex.Checked ? "男" : "女";
            myClass_KindofEmployerWelder.Schooling = this.ComboBox_Schooling.SelectedValue.ToString();
            myClass_KindofEmployerWelder.WeldingBeginning = this.DateTimePicker_WeldingBeinning.Value;
            myClass_KindofEmployerWelder.myClass_BelongUnit.EmployerHPID = this.ComboBox_Employer.SelectedValue.ToString();
            if (this.CheckBox_Department.Checked && this.ComboBox_Department.SelectedValue != null)
            {
                myClass_KindofEmployerWelder.myClass_BelongUnit.DepartmentHPID = this.ComboBox_Department.SelectedValue.ToString();
                if (this.CheckBox_WorkPlace.Checked && this.ComboBox_WorkPlace.SelectedValue != null)
                {
                    myClass_KindofEmployerWelder.myClass_BelongUnit.WorkPlaceHPID = this.ComboBox_WorkPlace.SelectedValue.ToString();
                }
                else
                {
                    myClass_KindofEmployerWelder.myClass_BelongUnit.WorkPlaceHPID = "";
                }
            }
            else
            {
                myClass_KindofEmployerWelder.myClass_BelongUnit.DepartmentHPID = "";
            }
            if (this.CheckBox_LaborServiceTeam.Checked && this.ComboBox_LaborServiceTeam.SelectedValue != null)
            {
                myClass_KindofEmployerWelder.myClass_BelongUnit.LaborServiceTeamHPID = this.ComboBox_LaborServiceTeam.SelectedValue.ToString();
            }
            else
            {
                myClass_KindofEmployerWelder.myClass_BelongUnit.LaborServiceTeamHPID = "";
            }
            myClass_KindofEmployerWelder.myClass_BelongUnit.WorkerID = this.TextBox_WorkerID.Text;
            myClass_KindofEmployerWelder.WelderRemark = this.TextBox_WelderRemark.Text;

            if (myClass_KindofEmployerWelderDefault == null)
            {
                myClass_KindofEmployerWelderDefault = new Class_KindofEmployerWelder();
            }
            myClass_KindofEmployerWelderDefault.Schooling = myClass_KindofEmployerWelder.Schooling;
            myClass_KindofEmployerWelderDefault.Sex  = myClass_KindofEmployerWelder.Sex ;
            myClass_KindofEmployerWelderDefault.WeldingBeginning = myClass_KindofEmployerWelder.WeldingBeginning;
            myClass_KindofEmployerWelderDefault.myClass_BelongUnit.EmployerHPID = myClass_KindofEmployerWelder.myClass_BelongUnit.EmployerHPID ;
            myClass_KindofEmployerWelderDefault.myClass_BelongUnit.DepartmentHPID = myClass_KindofEmployerWelder.myClass_BelongUnit.DepartmentHPID;
            myClass_KindofEmployerWelderDefault.myClass_BelongUnit.WorkPlaceHPID = myClass_KindofEmployerWelder.myClass_BelongUnit.WorkPlaceHPID;
            myClass_KindofEmployerWelderDefault.myClass_BelongUnit.LaborServiceTeamHPID = myClass_KindofEmployerWelder.myClass_BelongUnit.LaborServiceTeamHPID;

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

        private void Button_IdentificationCardConvert_Click(object sender, EventArgs e)
        {
            this.MaskedTextBox_IdentificationCard.Text = ZCCL.Tools.Class_DataValidateTool.CovertIdentificationCard(this.MaskedTextBox_IdentificationCard.Text);

        }

        private void CheckBox_WorkPlace_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.CheckBox_Department.Checked)
            {
                this.CheckBox_WorkPlace.Checked = false;
            }
        }


    }
}
