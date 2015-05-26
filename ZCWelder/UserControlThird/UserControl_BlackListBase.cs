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
    public partial class UserControl_BlackListBase : UserControl
    {
        public Class_BlackList myClass_BlackList;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_BlackList myClass_BlackListDefault;

        public UserControl_BlackListBase()
        {
            InitializeComponent();
        }

        private void UserControl_BlackList_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_BlackList"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_BlackList myClass_BlackList, bool bool_Add)
        {
            this.myClass_BlackList = myClass_BlackList;
            if (!string.IsNullOrEmpty(this.myClass_BlackList.IdentificationCard))
            {
                this.InitControlWelder(new Class_Welder(this.myClass_BlackList.IdentificationCard));
                this.Button_WelderModify.Visible = false;
                this.Button_WelderUpdate.Visible = false;
            }
            if (bool_Add)
            {
                if (myClass_BlackListDefault != null)
                {
                }
            }
            else
            {
                this.textBox_BlackListID.Text = this.myClass_BlackList.BlackListID.ToString();
                this.DateTimePicker_BlackListBeginDate.Value = this.myClass_BlackList.BlackListBeginDate;
                this.DateTimePicker_BlackListEndDate.Value = this.myClass_BlackList.BlackListEndDate;
                this.textBox_BlackListCausation .Text = myClass_BlackList.BlackListCausation;
                this.textBox_BlackListRemark.Text = myClass_BlackList.BlackListRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_BlackList.BlackListBeginDate  = this.DateTimePicker_BlackListBeginDate .Value;
            myClass_BlackList.BlackListEndDate = this.DateTimePicker_BlackListEndDate.Value;
            myClass_BlackList.BlackListCausation = this.textBox_BlackListCausation.Text;
            myClass_BlackList.IdentificationCard = this.MaskedTextBox_IdentificationCard.Text;
            myClass_BlackList.BlackListRemark = this.textBox_BlackListRemark.Text;

            if (myClass_BlackListDefault == null)
            {
                myClass_BlackListDefault = new Class_BlackList();
            }

        }

        public void InitControlWelder(Class_Welder myClass_Welder)
        {
            this.TextBox_WelderName.Text = myClass_Welder.WelderName;
            this.MaskedTextBox_IdentificationCard.Text = myClass_Welder.IdentificationCard;
            this.TextBox_Schooling.Text = myClass_Welder.Schooling;
            this.TextBox_WelderEnglishName.Text = myClass_Welder.WelderEnglishName;
            this.DateTimePicker_WeldingBeinning.Value = myClass_Welder.WeldingBeginning;
            this.TextBox_WorkerID.Text = myClass_Welder.myClass_BelongUnit.WorkerID;
            Class_Employer myClass_Employer = new Class_Employer(myClass_Welder.myClass_BelongUnit.EmployerHPID);
            this.TextBox_Employer.Text = myClass_Employer.Employer;
            Class_Department myClass_Department = new Class_Department(myClass_Welder.myClass_BelongUnit.DepartmentHPID);
            this.TextBox_Department.Text = myClass_Department.Department;
            Class_WorkPlace myClass_WorkPlace = new Class_WorkPlace(myClass_Welder.myClass_BelongUnit.WorkPlaceHPID);
            this.TextBox_WorkPlace.Text = myClass_WorkPlace.WorkPlace;
            Class_LaborServiceTeam myClass_LaborServiceTeam = new Class_LaborServiceTeam(myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID);
            this.TextBox_LaborServiceTeam.Text = myClass_LaborServiceTeam.LaborServiceTeam;
            this.CheckBox_Sex.Checked = myClass_Welder.Sex == "男";
        }

        private void Button_WelderUpdate_Click(object sender, EventArgs e)
        {
            Form_Welder_Query myForm = new Form_Welder_Query();
            myForm.myClass_Welder = new Class_Welder();
            if (this.myClass_BlackList.IdentificationCard != null)
            {
                myForm.myClass_Welder.IdentificationCard = this.myClass_BlackList .IdentificationCard;
                myForm.myClass_Welder.FillData();
            }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_BlackList .IdentificationCard = myForm.myClass_Welder.IdentificationCard;
                this.InitControlWelder(myForm.myClass_Welder);
            }
        }

        private void Button_WelderModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.MaskedTextBox_IdentificationCard.Text))
            {
                MessageBox.Show("没有焊工信息修改！");
                return;
            }
            Form_Welder_Update myForm = new Form_Welder_Update();
            myForm.bool_Add = false;
            myForm.myClass_Welder = new Class_Welder(this.MaskedTextBox_IdentificationCard.Text);
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_BlackList .IdentificationCard = myForm.myClass_Welder.IdentificationCard;
                this.InitControlWelder(myForm.myClass_Welder);
            }

        }


    }
}
