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
    public partial class UserControl_WeldingSubject : UserControl
    {
        public UserControl_WeldingSubject()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingSubject_Load(object sender, EventArgs e)
        {
            Publisher_WeldingStandard.EventName += new EventHandler_WeldingStandard(InitstatusStrip);
            Publisher_WeldingSubject.EventName += new EventHandler_WeldingSubject(InitstatusStrip);
            for (int i = this.tabControl_WeldingSubject .TabCount - 1; i >= 0; i--)
            {
                this.tabControl_WeldingSubject.SelectedIndex = i;
            }

        }

        private void InitstatusStrip(object sender, EventArgs_WeldingStandard e)
        {
            if (string.IsNullOrEmpty(e.str_WeldingStandard))
            {
                this.toolStripStatusLabel_Filter.Text = string.Format("检索条件：{0}", e.str_Filter);
            }
            else
            {
                this.toolStripStatusLabel_Filter.Text = string.Format("焊工考试标准：{0}", e.str_WeldingStandard );
            }
        }

        private void InitstatusStrip(object sender, EventArgs_WeldingSubject e)
        {
            this.toolStripStatusLabel_SubjectID .Text = string.Format("考试科目编号：{0}", e.str_SubjectID );
        }
    }
}
