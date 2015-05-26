using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.Tools;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_WelderQuery : UserControl
    {
        public UserControl_WelderQuery()
        {
            InitializeComponent();
        }

        private void UserControl_WelderQuery_Load(object sender, EventArgs e)
        {

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            EventArgs_WelderFilter my_e = new EventArgs_WelderFilter(null);
            my_e.str_IdentificationCard =Class_DataValidateTool.CovertIdentificationCard( this.TextBox_IdentificationCardQuery.Text);
            my_e.str_WelderName = this.TextBox_WelderNameQuery.Text;
            my_e.str_RegistrationNo = this.TextBox_RegistrationNoQuery.Text;
            my_e.str_WelderWorkerID = this.TextBox_WorkerIDQuery.Text;
            my_e.str_ExaminingNo = this.TextBox_ExaminingNoQuery.Text;
            my_e.str_CertificateNo = this.TextBox_CertificateNoQuery.Text;
            my_e.str_IssueNo = this.textBox_IssueNoQuery.Text;
            Publisher_WelderFilter.OnEventName(my_e);

        }

        private void button_QueryAdvance_Click(object sender, EventArgs e)
        {
            Form_QueryFilter myForm = new Form_QueryFilter();
            myForm.InitControl(Enum_DataTable.Welder .ToString());
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                EventArgs_WelderFilter g = new EventArgs_WelderFilter(myForm.str_Filter);
                Publisher_WelderFilter.OnEventName(g);
            }

        }
    }
}
