using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCCL.UpdateLog;

namespace ZCWelder.Person
{
    /// <summary>
    /// 本窗口程序仅支持锁定单位级别为1，2，3的报考单位
    /// </summary>
    public partial class Form_Welder_Synchronization : Form
    {
        private DataTable myDataTable_WelderBelong;
        private DataTable myDataTable_KindofEmployerWelder;
        private DataTable myDataTable_Add;
        private DataTable myDataTable_Modify;
        private DataTable myDataTable_Delete;
        public  Class_KindofEmployer myClass_KindofEmployer;
        public bool  bool_Updated=false;

        public Form_Welder_Synchronization()
        {
            InitializeComponent();
        }

        private void Form_Welder_Synchronization_Load(object sender, EventArgs e)
        {
            if (this.myClass_KindofEmployer == null || this.myClass_KindofEmployer.KindofEmployerLevel == 0 || this.myClass_KindofEmployer.KindofEmployerLevel == 4)
            {
                MessageBox.Show("本窗口程序仅支持锁定单位级别为 1，2，3 的报考单位!");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            this.comboBox_KindofSynchronization.SelectedIndex = 0;
            this.InitDataGridView();
        }

        private  void InitDataGridView()
        {
            string str_Unit;
            string str_WelderBelongFilter;
            Class_Employer myClass_Employer;
            Class_Department myClass_Department;
            Class_WorkPlace myClass_WorkPlace;
            switch (this.myClass_KindofEmployer.KindofEmployerLevel)
            {
                case 1:
                     myClass_Employer = new Class_Employer(this.myClass_KindofEmployer.KindofEmployerEmployerHPID);
                    str_Unit = myClass_Employer.Employer;
                    str_WelderBelongFilter = string.Format("WelderBelongEmployerHPID='{0}'", myClass_Employer.EmployerHPID);
                    break;
                case 2:
                     myClass_Department = new Class_Department(this.myClass_KindofEmployer.KindofEmployerDepartmentHPID);
                     myClass_Employer = new Class_Employer(myClass_Department.EmployerHPID);
                    str_Unit = string.Format("{0} , {1}", myClass_Employer.Employer, myClass_Department.Department);
                    str_WelderBelongFilter = string.Format("WelderBelongDepartmentHPID='{0}'", myClass_Department.DepartmentHPID);
                    break;
                case 3:
                     myClass_WorkPlace = new Class_WorkPlace(this.myClass_KindofEmployer.KindofEmployerWorkPlaceHPID);
                     myClass_Department = new Class_Department(myClass_WorkPlace.DepartmentHPID);
                     myClass_Employer = new Class_Employer(myClass_Department.EmployerHPID);
                    str_Unit = string.Format("{0} , {1} , {2}", myClass_Employer.Employer, myClass_Department.Department, myClass_WorkPlace.WorkPlace);
                    str_WelderBelongFilter = string.Format("WelderBelongWorkPlaceHPID='{0}'", myClass_WorkPlace.WorkPlaceHPID);
                    break;
                default:
                    return;
            }

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_WelderBelong, Enum_DataTable.WelderBelong.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WelderBelong.ToString()];
            myClass_Data.SetFilter(str_WelderBelongFilter);
            myClass_Data.RefreshData(false);
            this.myDataTable_WelderBelong = myClass_Data.myDataTable.Copy();
            this.dataGridView_WelderBelong.DataSource = new DataView(this.myDataTable_WelderBelong);
            ((DataView)this.dataGridView_WelderBelong.DataSource).Sort = myClass_Data.myDataView.Sort;
            this.label_WelderBelong.Text = string.Format("本系统：  {0}，({1})", str_Unit, this.dataGridView_WelderBelong.RowCount);

            Class_DataControlBind.InitializeDataGridView(this.dataGridView_KindofEmployerWelder, Enum_DataTable.KindofEmployerWelder.ToString(), false);
            myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.KindofEmployerWelder.ToString()];
            myClass_Data.SetFilter(string.Format("KindofEmployer='{0}'", this.myClass_KindofEmployer.KindofEmployer));
            myClass_Data.RefreshData(false);
            this.myDataTable_KindofEmployerWelder = myClass_Data.myDataTable.Copy();
            this.dataGridView_KindofEmployerWelder.DataSource = new DataView(this.myDataTable_KindofEmployerWelder);
            ((DataView)this.dataGridView_KindofEmployerWelder.DataSource).Sort = myClass_Data.myDataView.Sort;
            this.label_KindofEmployerWelder.Text = string.Format("报考单位：  {0}，({1})", this.myClass_KindofEmployer.KindofEmployer, this.dataGridView_KindofEmployerWelder.RowCount);
            
            if (this.comboBox_KindofSynchronization.SelectedIndex == 0)
            {
                this.label_KindofSynchronization.Text = string.Format("同步数据类型：{0} -> {1}", this.myClass_KindofEmployer.KindofEmployer, str_Unit);
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Add, Enum_DataTable.KindofEmployerWelder.ToString(), false);
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Modify, Enum_DataTable.KindofEmployerWelder.ToString(), false);
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Delete, Enum_DataTable.WelderBelong.ToString(), false);
                this.myDataTable_Add = myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Add, true,false );
                this.myDataTable_Modify = myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Modify, true, false);
                this.myDataTable_Delete = myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Delete, true, false);
            }
            else
            {
                this.label_KindofSynchronization.Text = string.Format("同步数据类型：{1} -> {0}", this.myClass_KindofEmployer.KindofEmployer, str_Unit);
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Add, Enum_DataTable.WelderBelong.ToString(), false);
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Modify, Enum_DataTable.WelderBelong.ToString(), false);
                Class_DataControlBind.InitializeDataGridView(this.dataGridView_Delete, Enum_DataTable.KindofEmployerWelder.ToString(), false);
                this.myDataTable_Add = myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Add, false, false);
                this.myDataTable_Modify = myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Modify, false, false);
                this.myDataTable_Delete = myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Delete, false, false);
            }
            this.dataGridView_Add.DataSource = new DataView(this.myDataTable_Add );
            this.label_Add.Text = string.Format("添加后的数据，({0})：", this.dataGridView_Add.RowCount);
            this.dataGridView_Modify .DataSource = new DataView(this.myDataTable_Modify  );
            this.label_Modify .Text = string.Format("修改后的数据，({0})：", this.dataGridView_Modify .RowCount);
            this.dataGridView_Delete .DataSource = new DataView(this.myDataTable_Delete  );
            this.label_Delete .Text = string.Format("删除前的数据，({0})：", this.dataGridView_Delete .RowCount);
            
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (this.comboBox_KindofSynchronization.SelectedIndex == 0)
            {
                myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Add, true, true);
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Person_WelderBelong", this.myClass_KindofEmployer.KindofEmployer, Class_zwjPublic.myClass_CustomUser.UserGUID, "同步添加数据");
            }
            else
            {
                myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Add, false, true);
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "SignUp_KindofEmployerWelder", this.myClass_KindofEmployer.KindofEmployer, Class_zwjPublic.myClass_CustomUser.UserGUID, "同步添加数据");
            }
            this.InitDataGridView();
            this.bool_Updated = true;

        }

        private void button_Modify_Click(object sender, EventArgs e)
        {
            if (this.comboBox_KindofSynchronization.SelectedIndex == 0)
            {
                myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Modify , true, true);
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Person_WelderBelong", this.myClass_KindofEmployer.KindofEmployer, Class_zwjPublic.myClass_CustomUser.UserGUID, "同步修改数据");
            }
            else
            {
                myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Modify, false, true);
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "SignUp_KindofEmployerWelder", this.myClass_KindofEmployer.KindofEmployer, Class_zwjPublic.myClass_CustomUser.UserGUID, "同步修改数据");
            }
            this.InitDataGridView();
            this.bool_Updated = true;
            MessageBox.Show("修改数据结束！");

            //foreach (DataRow myDataRow in this.myDataTable_Modify.Rows)
            //{
            //    if (this.comboBox_KindofSynchronization.SelectedIndex == 0)
            //    {
            //        Class_Welder myClass_Welder = new Class_Welder(myDataRow["IdentificationCard"].ToString());
            //        myClass_Welder.WelderName = myDataRow["WelderName"].ToString();
            //        myClass_Welder.myClass_BelongUnit.EmployerHPID = myDataRow["WelderEmployerHPID"].ToString();
            //        myClass_Welder.myClass_BelongUnit.DepartmentHPID = myDataRow["WelderDepartmentHPID"].ToString();
            //        myClass_Welder.myClass_BelongUnit.WorkPlaceHPID = myDataRow["WelderWorkPlaceHPID"].ToString();
            //        myClass_Welder.myClass_BelongUnit.LaborServiceTeamHPID = myDataRow["WelderLaborServiceTeamHPID"].ToString();
            //        myClass_Welder.myClass_BelongUnit.WorkerID = myDataRow["WelderWorkerID"].ToString();

            //        myClass_Welder.AddAndModify(Enum_zwjKindofUpdate.Modify);
            //    }
            //    else
            //    {
            //        Class_KindofEmployerWelder myClass_KindofEmployerWelder = new Class_KindofEmployerWelder(Class_KindofEmployerWelder.GetKindofEmployerWelderID(myDataRow["KindofEmployer"].ToString(),myDataRow["IdentificationCard"].ToString()));
            //        myClass_KindofEmployerWelder.WelderName = myDataRow["WelderName"].ToString();
            //        myClass_KindofEmployerWelder.AddAndModify(Enum_zwjKindofUpdate.Modify);
            //    }
            //}
            //this.InitDataGridView();
            //this.bool_Updated = true;

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (this.comboBox_KindofSynchronization.SelectedIndex == 0)
            {
                myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Delete , true, true);
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Person_WelderBelong", this.myClass_KindofEmployer.KindofEmployer, Class_zwjPublic.myClass_CustomUser.UserGUID, "同步删除数据");
            }
            else
            {
                myClass_KindofEmployer.GetDataTable_Synchronization(Enum_zwjKindofUpdate.Delete, false, true);
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "SignUp_KindofEmployerWelder", this.myClass_KindofEmployer.KindofEmployer, Class_zwjPublic.myClass_CustomUser.UserGUID, "同步删除数据");
            }
            this.InitDataGridView();
            this.bool_Updated = true;

        }

        private void comboBox_KindofSynchronization_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitDataGridView();
        }
    }
}