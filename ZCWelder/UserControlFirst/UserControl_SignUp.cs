using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;

namespace ZCWelder.UserControlFirst
{
    public partial class UserControl_SignUp : UserControl
    {
        private EventArgs_KindofEmployer myEventArgs_KindofEmployer;
        private bool bool_Exam_First=true;
        
        public UserControl_SignUp()
        {
            InitializeComponent();
        }

        private void UserControl_KindofEmployer_Load(object sender, EventArgs e)
        {
            for (int i = this.tabControl_SignUp.TabCount - 1; i >= 0; i--)
            {
                if (this.tabControl_SignUp.TabPages[i].Text != "考试记录")
                {
                    this.tabControl_SignUp.SelectedIndex = i;
                }
            }
            Publisher_KindofEmployer.EventName += new EventHandler_KindofEmployer(InitstatusStrip);
        }

        private void InitstatusStrip(object sender, EventArgs_KindofEmployer e)
        {
            this.myEventArgs_KindofEmployer = e;
            this.toolStripStatusLabel_KindofEmployer .Text = string.Format("报考单位：{0}", e.str_KindofEmployer );
        }

        private void tabControl_SignUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bool_Exam_First && this.tabControl_SignUp.SelectedTab .Text == "考试记录")
            {
                bool_Exam_First = false;
                if (myEventArgs_KindofEmployer != null)
                {
                    Publisher_KindofEmployer.OnEventName(myEventArgs_KindofEmployer);
                }
            }
        }

    }
}
