using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCCL.AspNet;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_KindofEmployerBase : UserControl
    {
        private DataView myDataView_Employer;
        private DataView myDataView_Department;
        private DataView myDataView_WorkPlace;
        private DataView myDataView_LaborServiceTeam;
        
        public Class_KindofEmployer myClass_KindofEmployer;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_KindofEmployer myClass_KindofEmployerDefault;

        public UserControl_KindofEmployerBase()
        {
            InitializeComponent();
        }

        private void UserControl_KindofEmployer_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myKindofEmployer"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_KindofEmployer myClass_KindofEmployer, bool bool_Add)
        {
            Class_Data myClass_Data;
            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Employer.ToString()];
            this.myDataView_Employer = new DataView(myClass_Data.myDataTable);
            this.myDataView_Employer.Sort = myClass_Data.myDataView.Sort;

            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Department.ToString()];
            this.myDataView_Department = new DataView(myClass_Data.myDataTable);
            this.myDataView_Department.Sort = myClass_Data.myDataView.Sort;

            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WorkPlace.ToString()];
            this.myDataView_WorkPlace = new DataView(myClass_Data.myDataTable);
            this.myDataView_WorkPlace.Sort = myClass_Data.myDataView.Sort;

            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.LaborServiceTeam.ToString()];
            this.myDataView_LaborServiceTeam = new DataView(myClass_Data.myDataTable);
            this.myDataView_LaborServiceTeam.Sort = myClass_Data.myDataView.Sort;

            Class_DataControlBind.InitializeComboBox(this.ComboBox_LaborServiceTeam, this.myDataView_LaborServiceTeam, "LaborServiceTeamHPID", "LaborServiceTeam");
            Class_DataControlBind.InitializeComboBox(this.ComboBox_WorkPlace, this.myDataView_WorkPlace, "WorkPlaceHPID", "WorkPlace");
            Class_DataControlBind.InitializeComboBox(this.ComboBox_Department, this.myDataView_Department, "DepartmentHPID", "Department");
            Class_DataControlBind.InitializeComboBox(this.ComboBox_Employer, this.myDataView_Employer, "EmployerHPID", "Employer");

            this.myClass_KindofEmployer = myClass_KindofEmployer;
            if (bool_Add)
            {
                if (myClass_KindofEmployerDefault != null)
                {
                    this.TextBox_KindofEmployer.Text = myClass_KindofEmployerDefault.KindofEmployer;
                }
            }
            else
            {
                this.TextBox_KindofEmployer.ReadOnly = true;
                this.TextBox_KindofEmployer.Text = myClass_KindofEmployer.KindofEmployer;
                Class_CustomUser myClass_CustomUser = new Class_CustomUser();
                myClass_CustomUser.UserGUID =this.myClass_KindofEmployer.KindofEmployerManagerID ;
                if (myClass_CustomUser.FillData())
                {
                    this.textBox_KindofEmployerManager .Text = string.Format("{0}：{1}", myClass_CustomUser.Name, myClass_CustomUser.UserGUID.ToString());
                }
                if (myClass_KindofEmployer.KindofEmployerLevel >= this.NumericUpDown_KindofEmployerLevel.Minimum && myClass_KindofEmployer.KindofEmployerLevel <= this.NumericUpDown_KindofEmployerLevel.Maximum)
                {
                    this.NumericUpDown_KindofEmployerLevel .Value = myClass_KindofEmployer.KindofEmployerLevel;
                }
                this.ComboBox_Employer.SelectedValue = myClass_KindofEmployer.KindofEmployerEmployerHPID ;
                this.myDataView_Department.RowFilter = string.Format("EmployerHPID='{0}'", myClass_KindofEmployer.KindofEmployerEmployerHPID );
                this.myDataView_LaborServiceTeam.RowFilter = string.Format("EmployerHPID='{0}'", myClass_KindofEmployer.KindofEmployerEmployerHPID);
                if (string.IsNullOrEmpty(myClass_KindofEmployer.KindofEmployerDepartmentHPID))
                {
                    this.CheckBox_Department.Checked = false;
                    this.CheckBox_WorkPlace .Checked = false;
                }
                else
                {
                    this.ComboBox_Department.SelectedValue = myClass_KindofEmployer.KindofEmployerDepartmentHPID ;
                    this.CheckBox_Department.Checked = true;
                    this.myDataView_WorkPlace.RowFilter = string.Format("DepartmentHPID='{0}'", myClass_KindofEmployer.KindofEmployerDepartmentHPID );
                    if (!string.IsNullOrEmpty(myClass_KindofEmployer.KindofEmployerWorkPlaceHPID))
                    {
                        this.ComboBox_WorkPlace.SelectedValue = myClass_KindofEmployer.KindofEmployerWorkPlaceHPID ;
                        this.CheckBox_WorkPlace.Checked = true;
                    }
                    else
                    {
                        this.CheckBox_WorkPlace.Checked = false;
                    }
                }

                if (string.IsNullOrEmpty(myClass_KindofEmployer.KindofEmployerLaborServiceTeamHPID ))
                {
                    this.CheckBox_LaborServiceTeam.Checked = false;
                }
                else
                {
                    this.ComboBox_LaborServiceTeam.SelectedValue = myClass_KindofEmployer.KindofEmployerLaborServiceTeamHPID;
                    this.CheckBox_LaborServiceTeam.Checked = true;
                }
                this.checkBox_CanUpLoadWelderPicture.Checked = myClass_KindofEmployer.CanUpLoadWelderPicture;
                this.checkBox_CanModifyWelderPicture .Checked = myClass_KindofEmployer.CanModifyWelderPicture ;
                this.checkBox_CanDeleteWelderPicture .Checked = myClass_KindofEmployer.CanDeleteWelderPicture ;
                this.numericUpDown_KindofEmployerIndex.Value = this.myClass_KindofEmployer .KindofEmployerIndex;
                this.TextBox_KindofEmployerRemark.Text = myClass_KindofEmployer.KindofEmployerRemark;

                this.textBox_EmployerTel.Text=myClass_KindofEmployer.KindofEmployerTel;
                this.textBox_EmployerFax.Text=myClass_KindofEmployer.KindofEmployerFax ;
                this.textBox_EmployerMobile.Text=myClass_KindofEmployer.KindofEmployerMobile ;
                this.textBox_EmployerEmail.Text=myClass_KindofEmployer.KindofEmployerEmail ;

            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_KindofEmployer.KindofEmployer = this.TextBox_KindofEmployer.Text;
            myClass_KindofEmployer.KindofEmployerLevel=(int)this.NumericUpDown_KindofEmployerLevel .Value;
            if (!string.IsNullOrEmpty(this.textBox_KindofEmployerManager .Text))
            {
                this.myClass_KindofEmployer .KindofEmployerManagerID  = new Guid((this.textBox_KindofEmployerManager .Text.Split('：'))[1]);
            }

            myClass_KindofEmployer.KindofEmployerEmployerHPID = this.ComboBox_Employer.SelectedValue.ToString();
            if (this.CheckBox_Department.Checked && this.ComboBox_Department.SelectedValue != null)
            {
                myClass_KindofEmployer.KindofEmployerDepartmentHPID = this.ComboBox_Department.SelectedValue.ToString();
                if (this.CheckBox_WorkPlace.Checked && this.ComboBox_WorkPlace.SelectedValue != null)
                {
                    myClass_KindofEmployer.KindofEmployerWorkPlaceHPID = this.ComboBox_WorkPlace.SelectedValue.ToString();
                }
                else
                {
                    myClass_KindofEmployer.KindofEmployerWorkPlaceHPID = "";
                }
            }
            else
            {
                myClass_KindofEmployer.KindofEmployerDepartmentHPID = "";
            }
            if (this.CheckBox_LaborServiceTeam.Checked && this.ComboBox_LaborServiceTeam.SelectedValue != null)
            {
                myClass_KindofEmployer.KindofEmployerLaborServiceTeamHPID = this.ComboBox_LaborServiceTeam.SelectedValue.ToString();
            }
            else
            {
                myClass_KindofEmployer.KindofEmployerLaborServiceTeamHPID = "";
            }
            myClass_KindofEmployer.CanUpLoadWelderPicture = this.checkBox_CanUpLoadWelderPicture.Checked;
            myClass_KindofEmployer.CanModifyWelderPicture  = this.checkBox_CanModifyWelderPicture .Checked;
            myClass_KindofEmployer.CanDeleteWelderPicture  = this.checkBox_CanDeleteWelderPicture .Checked;
            myClass_KindofEmployer.KindofEmployerIndex = (int)this.numericUpDown_KindofEmployerIndex.Value;
            myClass_KindofEmployer.KindofEmployerRemark = this.TextBox_KindofEmployerRemark.Text;
            myClass_KindofEmployer.KindofEmployerTel = this.textBox_EmployerTel.Text;
            myClass_KindofEmployer.KindofEmployerFax = this.textBox_EmployerFax.Text;
            myClass_KindofEmployer.KindofEmployerMobile = this.textBox_EmployerMobile.Text;
            myClass_KindofEmployer.KindofEmployerEmail = this.textBox_EmployerEmail.Text;
            if (myClass_KindofEmployerDefault == null)
            {
                myClass_KindofEmployerDefault = new Class_KindofEmployer();
            }

        }

        private void textBox_KindofEmployerManager_DoubleClick(object sender, EventArgs e)
        {
            TextBox myTextBox = (TextBox)sender;
            Form_UserQuery myForm = new Form_UserQuery();
            Class_CustomUser myClass_CustomUser = new Class_CustomUser();
            if (!string.IsNullOrEmpty(myTextBox.Text))
            {
                myClass_CustomUser.UserGUID = new Guid(myTextBox.Text.Split('：')[1]);
                if (myClass_CustomUser.FillData())
                {
                }
            }
            myForm.myClass_CustomUser = myClass_CustomUser;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                if (myForm.myClass_CustomUser != null)
                {
                    myTextBox.Text = string.Format("{0}：{1}", myForm.myClass_CustomUser.Name, myForm.myClass_CustomUser.UserGUID.ToString());
                }
                else
                {
                    myTextBox.Text = "";
                }
            }
        }

        private void ComboBox_Employer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.myDataView_Department.RowFilter = string.Format("EmployerHPID='{0}'", this.ComboBox_Employer.SelectedValue.ToString());
            this.myDataView_LaborServiceTeam.RowFilter = string.Format("EmployerHPID='{0}'", this.ComboBox_Employer.SelectedValue.ToString());
            if (this.ComboBox_Department.SelectedValue != null)
            {
                this.myDataView_WorkPlace.RowFilter = string.Format("DepartmentHPID='{0}'", this.ComboBox_Department.SelectedValue.ToString());
            }
            else
            {
                this.myDataView_WorkPlace.RowFilter = "DepartmentHPID='0'";
            }

        }

        private void ComboBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ComboBox_Department.SelectedValue != null)
            {
                this.myDataView_WorkPlace.RowFilter = string.Format("DepartmentHPID='{0}'", this.ComboBox_Department.SelectedValue.ToString());
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


    }
}
