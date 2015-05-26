using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ZCWelder.DataSet;
using ZCWelder.DataSet.DataSet_ExamTableAdapters;
using System.Data.SqlClient;

namespace ZCWelder.Report
{
    public partial class Form_Report : Form
    {
        public ReportParameter[] myReportParameterRange;
 
        public Form_Report()
        {
            InitializeComponent();
        }

        private void Form_Report_Load(object sender, EventArgs e)
        {
            DataSet_Exam myDataSet_Exam = new DataSet_Exam();
            IssueTableAdapter   myIssueTableAdapter = new  IssueTableAdapter();
            myIssueTableAdapter.Connection = new SqlConnection(Properties.Settings.Default.zwjConn);
            myIssueTableAdapter.Fill(myDataSet_Exam.Issue);
            ReportDataSource myReportDataSource = new ReportDataSource("ZCWelderSQL", myDataSet_Exam.Issue );
            this.reportViewer_frame.LocalReport.DataSources.Clear();
            this.reportViewer_frame.LocalReport.DataSources.Add(myReportDataSource);
            this.reportViewer_frame.LocalReport.ReportEmbeddedResource = "ZCWelder.Report.焊工考试班级统计报表.rdlc";
            this.reportViewer_frame.LocalReport.SetParameters(myReportParameterRange);
            this.reportViewer_frame.RefreshReport();

        }
    }
}