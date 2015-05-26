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
    public partial class UserControl_WPS : UserControl
    {
        public UserControl_WPS()
        {
            InitializeComponent();
        }

        private void UserControl_WPS_Load(object sender, EventArgs e)
        {
            for (int i = this.tabControl_WPS .TabCount - 1; i >= 0; i--)
            {
                this.tabControl_WPS.SelectedIndex = i;
            }

            Publisher_WPS.EventName += new EventHandler_WPS(InitstatusStrip);

        }

        private void InitstatusStrip(object sender, EventArgs_WPS e)
        {
            this.toolStripStatusLabel_WPSID.Text = string.Format("焊接工艺编号：{0}",e.str_WPSID );
        }

    }
}
