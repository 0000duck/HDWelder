using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ZCWelder.Report
{
    public partial class Form_Report_WelderQC : Form
    {
        public DataTable myDataTable;
        public ReportParameter[] myReportParameterRange;

        public Form_Report_WelderQC()
        {
            InitializeComponent();
        }

        private void Form_Report_WelderQC_Load(object sender, EventArgs e)
        {
            ReportDataSource myReportDataSource = new ReportDataSource("ZCWelderQC", myDataTable);
            this.reportViewer_frame.LocalReport.DataSources.Clear();
            this.reportViewer_frame.LocalReport.DataSources.Add(myReportDataSource);
            this.reportViewer_frame.LocalReport.ReportEmbeddedResource = "ZCWelder.Report.焊工证书信息汇总表.rdlc";
            if (myReportParameterRange != null)
            {
                this.reportViewer_frame.LocalReport.SetParameters(myReportParameterRange);
            }
            this.reportViewer_frame.RefreshReport();
        }
    }
}
