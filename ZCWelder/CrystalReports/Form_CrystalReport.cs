using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;
using System.Collections;

namespace ZCWelder.CrystalReports
{
    public partial class Form_CrystalReport : Form
    {
        private   string  str_FileName ;
        private string str_Parameter_Field_Name;
        private System.Collections.ArrayList myArrayList;
        private DataView myDataView;
        private  string str_Subhead;
        public PaperSize myPaperSize;
        public PaperOrientation myPaperOrientation;
        public System.Drawing.Printing.PageSettings myPageSettings;
        public System.Drawing.Printing.PrinterSettings myPrinterSettings;
        public ReportDocument myReportDocument;   

        public Form_CrystalReport()
        {
            InitializeComponent();
        }

        private void Form_CrystalReport_Load(object sender, EventArgs e)
        {            


        }

        public void InitCrystalReport(string  str_FileName, string str_Parameter_Field_Name,ArrayList myArrayList, DataView myDataView, string str_Subhead)
        {
            this.str_FileName = str_FileName;
            this.str_Parameter_Field_Name=str_Parameter_Field_Name ;
            this.myArrayList=myArrayList ;
            this.myDataView=myDataView;
            this.str_Subhead=str_Subhead;                   
            if (myReportDocument==null)
            {
                myReportDocument = new ReportDocument();   
            }

            myReportDocument.Load(str_FileName);
            if ( this.myDataView != null )
            {
                myReportDocument.SetDataSource(this.myDataView);
            }
            else 
            {
                ConfigureCrystalReports(myReportDocument);
            }
            SetCurrentValuesForParameterField(myReportDocument, myArrayList);

            if (myPaperSize != PaperSize.DefaultPaperSize)
            {
                myReportDocument.PrintOptions.PaperSize = myPaperSize;
                myReportDocument.PrintOptions.PaperOrientation = myPaperOrientation;
            }

            if (this.myPrinterSettings != null)
            {

            }
            this.crystalReportViewer_Container  .ReportSource = myReportDocument;   
        }
        
        private void   ConfigureCrystalReports(ReportDocument myReportDocument  )
        {
            SqlConnectionStringBuilder mySqlConnectionStringBuilder = new SqlConnectionStringBuilder(Class_zwjPublic.myClass_SqlConnection.mySqlConn.ConnectionString);
            ConnectionInfo myConnectionInfo = new ConnectionInfo();
            myConnectionInfo.ServerName = mySqlConnectionStringBuilder.DataSource;
            myConnectionInfo.DatabaseName = mySqlConnectionStringBuilder.InitialCatalog;
            if (mySqlConnectionStringBuilder.IntegratedSecurity)
            {
                myConnectionInfo.IntegratedSecurity = true;
            }
            else
            {
                myConnectionInfo.UserID = mySqlConnectionStringBuilder.UserID;
                myConnectionInfo.Password = mySqlConnectionStringBuilder.Password;
            }
            SetDBLogonForReport(myConnectionInfo, myReportDocument);
            
        }
        
        private void  SetDBLogonForReport(ConnectionInfo myConnectionInfo , ReportDocument subReportDocument  )
        {
              Tables myTableLogOnInfos= subReportDocument.Database.Tables;
             foreach(Table myTable in myTableLogOnInfos)
             {
                 TableLogOnInfo myTableLogonInfo = myTable.LogOnInfo;
                myTableLogonInfo.ConnectionInfo = myConnectionInfo;
                myTable.ApplyLogOnInfo(myTableLogonInfo);
            }
        }
                    
        private void  SetCurrentValuesForParameterField(ReportDocument myReportDocument  , System.Collections . ArrayList myArrayList  )
        {
            ParameterDiscreteValue myParameterDiscreteValue;
            ParameterFieldDefinitions myParameterFieldDefinitions;
            ParameterFieldDefinition myParameterFieldDefinition;
            ParameterValues currentParameterValues;

            if (!string.IsNullOrEmpty(str_Parameter_Field_Name))
            {
                currentParameterValues = new ParameterValues();
                foreach (Object submittedValue in myArrayList)
                {
                    myParameterDiscreteValue = new ParameterDiscreteValue();
                    myParameterDiscreteValue.Value = submittedValue.ToString();
                    currentParameterValues.Add(myParameterDiscreteValue);
                }
                myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
                myParameterFieldDefinition = myParameterFieldDefinitions[str_Parameter_Field_Name];
                myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
            }

           if (!string.IsNullOrEmpty(Properties.Settings.Default.Lister))
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = Properties.Settings.Default.Lister;
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Lister"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
           }
           else
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = "____________________";
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Lister"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
           }

           if (!string.IsNullOrEmpty(Properties.Settings.Default.Corrector))
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = Properties.Settings.Default.Corrector;
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Corrector"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
           }
           else
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = "____________________";
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Corrector"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);

           }

           if (!string.IsNullOrEmpty(Properties.Settings.Default.Assessor))
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = Properties.Settings.Default.Assessor;
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Assessor"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
           }
           else
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = "____________________";
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Assessor"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);

           }

           if (!string.IsNullOrEmpty(Properties.Settings.Default.Rehear))
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = Properties.Settings.Default.Rehear;
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Rehear"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
           }
           else
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = "____________________";
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Rehear"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
           }


           if (!string.IsNullOrEmpty(Properties.Settings.Default.Company))
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = Properties.Settings.Default.Company;
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Company"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
           }
           else
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = "____________________";
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Company"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);

           }

           if (!string.IsNullOrEmpty(this.str_Subhead))
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = str_Subhead;
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Subhead"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
           }
           else
           {
               currentParameterValues = new ParameterValues();
               myParameterDiscreteValue = new ParameterDiscreteValue();
               myParameterDiscreteValue.Value = "____________________";
               currentParameterValues.Add(myParameterDiscreteValue);
               myParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
               myParameterFieldDefinition = myParameterFieldDefinitions["Subhead"];
               myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
           }

        }
            
        private void  SetDBLogonForSubreports(ConnectionInfo myConnectionInfo  , ReportDocument myReportDocument )
        {
            Sections mySections  = myReportDocument.ReportDefinition.Sections;
            foreach ( Section mySection in mySections)
            {
                 ReportObjects myReportObjects   = mySection.ReportObjects;
                foreach ( ReportObject myReportObject in myReportObjects)
                {
                    if (myReportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject mySubreportObject  = (SubreportObject)myReportObject;
                        ReportDocument subReportDocument = mySubreportObject.OpenSubreport(mySubreportObject.SubreportName);
                        SetDBLogonForReport(myConnectionInfo, subReportDocument);
                    }
                }

            }

        }

    }
}