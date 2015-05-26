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
using ZCCL.ProcessStatus;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_IssueProcessBase : UserControl
    {
        private  Class_IssueProcess myClass_IssueProcess;
        private string str_ProcessStatusGroup;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_IssueProcess myClass_IssueProcessDefault;

        public UserControl_IssueProcessBase()
        {
            InitializeComponent();
        }

        private void UserControl_IssueProcess_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_IssueProcess"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_IssueProcess myClass_IssueProcess, string str_ProcessStatusGroup, bool bool_Add)
        {
            this.myClass_IssueProcess = myClass_IssueProcess;
            this.str_ProcessStatusGroup = str_ProcessStatusGroup;
            this.textBox_ProcessStatusGroup.Text = this.str_ProcessStatusGroup;
            this.textBox_IssueNo.Text = myClass_IssueProcess.IssueNo;
            if (this.myClass_IssueProcess.IssueProcessPrincipal == null)
            {
                this.myClass_IssueProcess.IssueProcessPrincipal = Class_zwjPublic.myClass_CustomUser.UserGUID;
            }
            Class_CustomUser myClass_CustomUser = new Class_CustomUser(this.myClass_IssueProcess.IssueProcessPrincipal);
            this.textBox_IssueProcessPrincipal.Text = string.Format("{0}：{1}", myClass_CustomUser.UserName, myClass_CustomUser.Name);

            DataView myDataView = new DataView(Class_ProcessStatus.myClass_Data.myDataTable);
            myDataView.Sort = Class_ProcessStatus.myClass_Data.myDataView.Sort;
            myDataView.RowFilter = string.Format("ProcessStatusGroup='{0}'", this.str_ProcessStatusGroup);
            Class_DataControlBind.InitializeComboBox(this.comboBox_IssueProcessStatus, myDataView, "ProcessStatus", "ProcessStatus");
            
            if (bool_Add)
            {
                if (myClass_IssueProcessDefault != null)
                {
                }
            }
            else
            {
                this.textBox_IssueProcessID.Text = myClass_IssueProcess.IssueProcessID.ToString();
                this.DateTimePicker_IssueProcessBeginDate.Value = myClass_IssueProcess.IssueProcessBeginDate;
                this.DateTimePicker_IssueProcessEndDate.Value = myClass_IssueProcess.IssueProcessEndDate;
                this.CheckBox_IssueProcessFinished.Checked = myClass_IssueProcess.IssueProcessFinished;
                this.comboBox_IssueProcessStatus.SelectedValue = myClass_IssueProcess.IssueProcessStatus;
                this.textBox_IssueProcessRemark.Text = myClass_IssueProcess.IssueProcessRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_IssueProcess.IssueProcessBeginDate = this.DateTimePicker_IssueProcessBeginDate.Value;
            myClass_IssueProcess.IssueProcessEndDate = this.DateTimePicker_IssueProcessEndDate.Value;
            myClass_IssueProcess.IssueProcessFinished = this.CheckBox_IssueProcessFinished.Checked;
            myClass_IssueProcess.IssueProcessStatus = this.comboBox_IssueProcessStatus.SelectedValue.ToString();
            myClass_IssueProcess.IssueProcessRemark = this.textBox_IssueProcessRemark.Text;

            if (myClass_IssueProcessDefault == null)
            {
                myClass_IssueProcessDefault = new Class_IssueProcess();
            }

        }

        private void textBox_IssueProcessPrincipal_DoubleClick(object sender, EventArgs e)
        {
            Form_UserQuery myForm = new Form_UserQuery();
            if (this.myClass_IssueProcess.IssueProcessPrincipal != null)
            {
                myForm.myClass_CustomUser = new Class_CustomUser(this.myClass_IssueProcess.IssueProcessPrincipal);
            }
            else
            {
                myForm.myClass_CustomUser = new Class_CustomUser();
            }

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                if (myForm.myClass_CustomUser.UserGUID != null)
                {
                    this.myClass_IssueProcess.IssueProcessPrincipal = myForm.myClass_CustomUser.UserGUID;
                    this.textBox_IssueProcessPrincipal.Text = string.Format("{0}：{1}", myForm.myClass_CustomUser.UserName, myForm.myClass_CustomUser.Name);
                }
                
            }

        }

    }
}
