using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.AspNet;
using ZCCL.Report;
using ZCCL.ClassBase ;

namespace ZCWelder.CrystalReports
{
    public partial class Form_ReportSelect : Form
    {
        public  Class_Report myClass_Report;
        public string str_Subhead;
        public System.Drawing.Printing.PageSettings myPageSettings;
        public System.Drawing.Printing.PrinterSettings myPrinterSettings;


        public Form_ReportSelect()
        {
            InitializeComponent();
        }

        private void Form_ReportSelect_Load(object sender, EventArgs e)
        {
            this.textBox_Subhead.Text = str_Subhead;

            DataView myDataView_Report = new DataView(Class_Report.myClass_Data.myDataTable);
            myDataView_Report.RowFilter =string.Format( "ReportGroup='{0}'", myClass_Report.ReportGroup );
            myDataView_Report.Sort = Class_Report.myClass_Data.myDataView.Sort;
            ColumnHeader myColumnHeader;
            ListViewItem myListViewItem;
            myColumnHeader = new ColumnHeader();
            myColumnHeader.Name = "ColumnHeader_ReportName";
            myColumnHeader.Text = "报表名";
            myColumnHeader.Width = 200;
            this.ListView_Report .Columns.Add(myColumnHeader);
            myColumnHeader = new ColumnHeader();
            myColumnHeader.Name = "ColumnHeader_ReportLocation";
            myColumnHeader.Text = "存储位置";
            myColumnHeader.Width = 200;
            this.ListView_Report.Columns.Add(myColumnHeader);
            myColumnHeader = new ColumnHeader();
            myColumnHeader.Name = "ColumnHeader_ReportPaperSize";
            myColumnHeader.Text = "纸张大小";
            myColumnHeader.Width = 200;
            this.ListView_Report.Columns.Add(myColumnHeader);
            myColumnHeader = new ColumnHeader();
            myColumnHeader.Name = "ColumnHeader_ReportRemark";
            myColumnHeader.Text = "备注";
            myColumnHeader.Width = 200;
            this.ListView_Report.Columns.Add(myColumnHeader);

            foreach (DataRowView myDataRowView in myDataView_Report)
            {
                myListViewItem = new ListViewItem(myDataRowView["ReportName"].ToString());
                myListViewItem.SubItems.Add(myDataRowView["ReportLocation"].ToString());
                myListViewItem.SubItems.Add(myDataRowView["ReportPaperSize"].ToString());
                myListViewItem.SubItems.Add(myDataRowView["ReportRemark"].ToString());
                this.ListView_Report.Items.Add(myListViewItem);
            }

        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (this.ListView_Report .SelectedItems.Count == 0 )
            {
                MessageBox.Show ("请选择报表！");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return ;
            }
            myClass_Report.ReportName = this.ListView_Report.SelectedItems[0].Text;
            myClass_Report.ReportLocation = this.ListView_Report.SelectedItems[0].SubItems[1].Text;
            myClass_Report.ReportPaperSize = this.ListView_Report.SelectedItems[0].SubItems[2].Text;
            str_Subhead = this.textBox_Subhead.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        private void button_PageSet_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();

            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

            pageSetupDialog1.ShowNetwork = false;

            DialogResult result = pageSetupDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.textBox_PrinterName .Text=  pageSetupDialog1.PrinterSettings.PrinterName;
                this.myPageSettings = pageSetupDialog1.PageSettings;
                this.myPrinterSettings = pageSetupDialog1.PrinterSettings;

            }

        }
    }
}