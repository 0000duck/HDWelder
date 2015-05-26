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
    public partial class UserControl_Welder : UserControl
    {
        public UserControl_Welder()
        {
            InitializeComponent();
        }

        private void UserControl_Welder_Load(object sender, EventArgs e)
        {
            Publisher_WelderFilter.EventName += new EventHandler_WelderFilter(InitstatusStrip);
            Publisher_Welder.EventName += new EventHandler_Welder(InitstatusStrip);
            Publisher_StudentSecond.EventName += new EventHandler_StudentSecond(InitstatusStrip);

        }

        private void InitstatusStrip(object sender, EventArgs_WelderFilter e)
        {
            if (string.IsNullOrEmpty(e.str_Filter))
            {
                this.toolStripStatusLabel_Filter.Text = string.Format("检索条件：直接检索");
            }
            else
            {
                this.toolStripStatusLabel_Filter.Text = string.Format("检索条件：{0}", e.str_Filter);
            }
        }

        private void InitstatusStrip(object sender, EventArgs_Welder e)
        {
            this.toolStripStatusLabel_IdentificationCard .Text = string.Format("身份证号码：{0}", e.str_IdentificationCard );
        }

        private void InitstatusStrip(object sender, EventArgs_StudentSecond e)
        {
            this.toolStripStatusLabel_ExaminingNo  .Text = string.Format("考编号：{0}", e.str_ExaminingNo  );
        }
    }
}
