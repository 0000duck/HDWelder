using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace ZCWelder.Reports
{
    public partial class Form_Report : Form
    { 
        public Form_Report()
        {
            InitializeComponent();
        }

        private void Form_Report_Load(object sender, EventArgs e)
        {      
        }

        public void InitReport(string str_ReportEmbeddedResource, ReportDataSource[] myReportDataSourceRange, ReportParameter[] myReportParameterRange)
        {
            this.reportViewer_frame.LocalReport.DataSources.Clear();
            foreach (ReportDataSource myReportDataSource in myReportDataSourceRange)
            {
                this.reportViewer_frame.LocalReport.DataSources.Add(myReportDataSource);
            }
            this.reportViewer_frame.LocalReport.ReportEmbeddedResource = str_ReportEmbeddedResource;
            this.reportViewer_frame.LocalReport.SetParameters(myReportParameterRange);
            this.reportViewer_frame.RefreshReport();
        }
    }
}