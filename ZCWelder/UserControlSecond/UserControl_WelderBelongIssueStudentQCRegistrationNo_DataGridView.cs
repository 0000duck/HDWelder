using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCCL.AspNet;
using ZCWelder.ClassBase;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WelderBelongIssueStudentQCRegistrationNo_DataGridView : UserControl
    {
        private EventArgs_WelderBelong myEventArgs_WelderBelong;

        public UserControl_WelderBelongIssueStudentQCRegistrationNo_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_IssueStudentQCRegistrationNoSecond_DataGridView_Load(object sender, EventArgs e)
        {
            Publisher_WelderBelong.EventName += new EventHandler_WelderBelong(InitDataGridView);

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_WelderBelong e)
        {
            this.myEventArgs_WelderBelong = e;

            if (this.tabControl_WelderBelong_Auxiliary.SelectedTab.Text=="考试记录")
            {
                this.userControl_WelderExamBase1.InitDataGridView(this.myEventArgs_WelderBelong.str_IdentificationCard);
            }

            this.userControl_WelderPictureBase1.InitWelderPicture(this.myEventArgs_WelderBelong.str_IdentificationCard);

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            this.myEventArgs_WelderBelong.bool_JustFill = bool_JustFill;
            Publisher_WelderBelong.OnEventName(myEventArgs_WelderBelong);

        }

        private void tabControl_WelderBelong_Auxiliary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.myEventArgs_WelderBelong != null && this.tabControl_WelderBelong_Auxiliary.SelectedTab.Text == "考试记录")
            {
                this.userControl_WelderExamBase1 .InitDataGridView(this.myEventArgs_WelderBelong.str_IdentificationCard);
            }
        }
    }
}
