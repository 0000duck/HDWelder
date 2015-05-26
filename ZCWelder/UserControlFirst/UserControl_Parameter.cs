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
    public partial class UserControl_Parameter : UserControl
    {
        public UserControl_Parameter()
        {
            InitializeComponent();
        }

        private void UserControl_Parameter_Load(object sender, EventArgs e)
        {
            Publisher_Parameter.EventName += new EventHandler_Parameter(InitstatusStrip);

        }

        private void InitstatusStrip(object sender, EventArgs_Parameter e)
        {
            this.toolStripStatusLabel_Parameter .Text = string.Format("参数：{0}", e.str_ParameterName );
            this.toolStripStatusLabel_Filter .Text = string.Format("检索条件：{0}", e.str_Filter);
        }

    }
}
