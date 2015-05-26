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
    public partial class UserControl_ReviveQC : UserControl
    {
        public UserControl_ReviveQC()
        {
            InitializeComponent();
        }

        private void UserControl_ReviveQC_Load(object sender, EventArgs e)
        {
            Publisher_ReviveQC.EventName += new EventHandler_ReviveQC(InitstatusStrip);

        }

        private void InitstatusStrip(object sender, EventArgs_ReviveQC e)
        {
            this.toolStripStatusLabel_Filter.Text = string.Format("检索条件：{0}", e.str_Filter);
        }
    }
}
