using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCWelder.Person;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WelderBelong_Base : UserControl
    {
        private DataView myDataView_LaborServiceTeam;
        public Class_WelderBelong myClass_WelderBelong;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_WelderBelong myClass_WelderBelongDefault;

        public UserControl_WelderBelong_Base()
        {
            InitializeComponent();
        }

        private void UserControl_WelderBelong_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_WelderBelong"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_WelderBelong myClass_WelderBelong, bool bool_Add)
        {
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.LaborServiceTeam.ToString()];
            this.myDataView_LaborServiceTeam = new DataView(myClass_Data.myDataTable);
            this.myDataView_LaborServiceTeam.Sort = myClass_Data.myDataView.Sort;
            Class_DataControlBind.InitializeComboBox(this.ComboBox_LaborServiceTeam, this.myDataView_LaborServiceTeam, "LaborServiceTeamHPID", "LaborServiceTeam");
            this.CheckBox_Sex.Enabled = false;
            this.DateTimePicker_WeldingBeinning.Enabled = false;
            this.myClass_WelderBelong = myClass_WelderBelong;

            if (string.IsNullOrEmpty(myClass_WelderBelong.myClass_BelongUnit.WorkPlaceHPID))
            {
                if (string.IsNullOrEmpty(myClass_WelderBelong.myClass_BelongUnit.DepartmentHPID))
                {
                    Class_Employer myClass_Employer = new Class_Employer(myClass_WelderBelong.myClass_BelongUnit.EmployerHPID);
                    this.TextBox_Employer.Text = myClass_Employer.Employer;
                }
                else
                {
                    Class_Department myClass_Department = new Class_Department(myClass_WelderBelong.myClass_BelongUnit.DepartmentHPID);
                    this.TextBox_Department.Text = myClass_Department.Department;
                    Class_Employer myClass_Employer = new Class_Employer(myClass_Department.EmployerHPID );
                    this.TextBox_Employer.Text = myClass_Employer.Employer;
                    this.myClass_WelderBelong.myClass_BelongUnit.EmployerHPID = myClass_Employer.EmployerHPID;
                }
            }
            else
            {
                Class_WorkPlace myClass_WorkPlace = new Class_WorkPlace(myClass_WelderBelong.myClass_BelongUnit.WorkPlaceHPID);
                this.TextBox_WorkPlace.Text = myClass_WorkPlace.WorkPlace;
                Class_Department myClass_Department = new Class_Department(myClass_WorkPlace.DepartmentHPID );
                this.TextBox_Department.Text = myClass_Department.Department;
                Class_Employer myClass_Employer = new Class_Employer(myClass_Department.EmployerHPID );
                this.TextBox_Employer.Text = myClass_Employer.Employer;
                this.myClass_WelderBelong.myClass_BelongUnit.DepartmentHPID = myClass_Department.DepartmentHPID;
                this.myClass_WelderBelong.myClass_BelongUnit.EmployerHPID = myClass_Employer.EmployerHPID;
            }

            this.myDataView_LaborServiceTeam.RowFilter = string.Format("EmployerHPID='{0}'", this.myClass_WelderBelong.myClass_BelongUnit.EmployerHPID );

            if (bool_Add)
            {
                if (myClass_WelderBelongDefault != null)
                {
                }
            }
            else
            {
                myDataView_LaborServiceTeam.RowFilter = string.Format("EmployerHPID='{0}'", this.myClass_WelderBelong.myClass_BelongUnit.EmployerHPID);
                this.textBox_WelderBelongID.Text = this.myClass_WelderBelong.WelderBelongID.ToString();
                this.textBox_WelderBelongRemark.Text = myClass_WelderBelong.WelderBelongRemark;
               
                this.InitControlWelder(new Class_Welder(this.myClass_WelderBelong.IdentificationCard));
               

                if (string.IsNullOrEmpty(myClass_WelderBelong.myClass_BelongUnit.LaborServiceTeamHPID))
                {
                    this.CheckBox_LaborServiceTeam.Checked = false;
                }
                else
                {
                    this.CheckBox_LaborServiceTeam.Checked = true;
                    this.ComboBox_LaborServiceTeam.SelectedValue = myClass_WelderBelong.myClass_BelongUnit.LaborServiceTeamHPID ;
                }
                this.TextBox_WorkerID.Text = myClass_WelderBelong.myClass_BelongUnit.WorkerID;
            }

        }

        public void InitControlWelder(Class_Welder myClass_Welder)
        {
            this.TextBox_WelderName.Text = myClass_Welder.WelderName;
            this.MaskedTextBox_IdentificationCard.Text = myClass_Welder.IdentificationCard;
            this.TextBox_Schooling.Text = myClass_Welder.Schooling;
            this.textBox_WelderEnglishName.Text = myClass_Welder.WelderEnglishName;
            this.DateTimePicker_WeldingBeinning.Value = myClass_Welder.WeldingBeginning;
            this.CheckBox_Sex.Checked = myClass_Welder.Sex == "男";

            if (string.IsNullOrEmpty(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID))
            {
                this.CheckBox_LaborServiceTeam.Checked = false;
            }
            else
            {
                this.CheckBox_LaborServiceTeam.Checked = true;
                this.ComboBox_LaborServiceTeam.SelectedValue = myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID;
            }
            this.TextBox_WorkerID.Text = myClass_Welder.myClass_BelongUnit.WorkerID;
        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_WelderBelong.WelderBelongRemark = this.textBox_WelderBelongRemark.Text;
            myClass_WelderBelong.myClass_BelongUnit.WorkerID = this.TextBox_WorkerID.Text;
            if (this.CheckBox_LaborServiceTeam.Checked && this.ComboBox_LaborServiceTeam.SelectedValue != null)
            {
                myClass_WelderBelong.myClass_BelongUnit.LaborServiceTeamHPID = this.ComboBox_LaborServiceTeam.SelectedValue.ToString();
            }
            else
            {
                myClass_WelderBelong.myClass_BelongUnit.LaborServiceTeamHPID = null;
            }
            if (myClass_WelderBelongDefault == null)
            {
                myClass_WelderBelongDefault = new Class_WelderBelong();
            }

        }

        private void Button_WelderUpdate_Click(object sender, EventArgs e)
        {
            Form_Welder_Query myForm = new Form_Welder_Query();
            myForm.myClass_Welder = new Class_Welder();
            if (this.myClass_WelderBelong .IdentificationCard != null)
            {
                myForm.myClass_Welder.IdentificationCard = this.myClass_WelderBelong.IdentificationCard;
                myForm.myClass_Welder.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_WelderBelong.IdentificationCard = myForm.myClass_Welder .IdentificationCard;
                this.InitControlWelder(myForm.myClass_Welder);
            }

        }

    }
}
