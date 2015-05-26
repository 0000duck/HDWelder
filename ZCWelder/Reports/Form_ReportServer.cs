using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZCWelder.Reports
{
    public partial class Form_ReportServer : Form
    {
        public Form_ReportServer()
        {
            InitializeComponent();
        }

        private void Form_ReportServer_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
