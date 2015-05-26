namespace ZCWelder.CrystalReports
{
    partial class Form_ReportSelect
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_Lister = new System.Windows.Forms.Label();
            this.Label_Corrector = new System.Windows.Forms.Label();
            this.Label_Assessor = new System.Windows.Forms.Label();
            this.Label_Rehear = new System.Windows.Forms.Label();
            this.TextBox_Lister = new System.Windows.Forms.TextBox();
            this.TextBox_Assessor = new System.Windows.Forms.TextBox();
            this.TextBox_Corrector = new System.Windows.Forms.TextBox();
            this.TextBox_Rehear = new System.Windows.Forms.TextBox();
            this.label_Company = new System.Windows.Forms.Label();
            this.label_Subhead = new System.Windows.Forms.Label();
            this.textBox_Company = new System.Windows.Forms.TextBox();
            this.textBox_Subhead = new System.Windows.Forms.TextBox();
            this.ListView_Report = new System.Windows.Forms.ListView();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.button_PageSet = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_PrinterName = new System.Windows.Forms.TextBox();
            this.label_PrinterName = new System.Windows.Forms.Label();
            this.TableLayoutPanel2.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 4;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.TableLayoutPanel2.Controls.Add(this.Label_Lister, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.Label_Corrector, 2, 0);
            this.TableLayoutPanel2.Controls.Add(this.Label_Assessor, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.Label_Rehear, 2, 1);
            this.TableLayoutPanel2.Controls.Add(this.TextBox_Lister, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.TextBox_Assessor, 1, 1);
            this.TableLayoutPanel2.Controls.Add(this.TextBox_Corrector, 3, 0);
            this.TableLayoutPanel2.Controls.Add(this.TextBox_Rehear, 3, 1);
            this.TableLayoutPanel2.Controls.Add(this.label_Company, 0, 2);
            this.TableLayoutPanel2.Controls.Add(this.label_Subhead, 0, 3);
            this.TableLayoutPanel2.Controls.Add(this.textBox_Company, 1, 2);
            this.TableLayoutPanel2.Controls.Add(this.textBox_Subhead, 1, 3);
            this.TableLayoutPanel2.Location = new System.Drawing.Point(12, 236);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 4;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(497, 123);
            this.TableLayoutPanel2.TabIndex = 3;
            // 
            // Label_Lister
            // 
            this.Label_Lister.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Lister.AutoSize = true;
            this.Label_Lister.Location = new System.Drawing.Point(29, 9);
            this.Label_Lister.Name = "Label_Lister";
            this.Label_Lister.Size = new System.Drawing.Size(41, 12);
            this.Label_Lister.TabIndex = 0;
            this.Label_Lister.Text = "制表：";
            // 
            // Label_Corrector
            // 
            this.Label_Corrector.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Corrector.AutoSize = true;
            this.Label_Corrector.Location = new System.Drawing.Point(272, 9);
            this.Label_Corrector.Name = "Label_Corrector";
            this.Label_Corrector.Size = new System.Drawing.Size(41, 12);
            this.Label_Corrector.TabIndex = 1;
            this.Label_Corrector.Text = "校对：";
            // 
            // Label_Assessor
            // 
            this.Label_Assessor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Assessor.AutoSize = true;
            this.Label_Assessor.Location = new System.Drawing.Point(29, 39);
            this.Label_Assessor.Name = "Label_Assessor";
            this.Label_Assessor.Size = new System.Drawing.Size(41, 12);
            this.Label_Assessor.TabIndex = 2;
            this.Label_Assessor.Text = "审核：";
            // 
            // Label_Rehear
            // 
            this.Label_Rehear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Rehear.AutoSize = true;
            this.Label_Rehear.Location = new System.Drawing.Point(272, 39);
            this.Label_Rehear.Name = "Label_Rehear";
            this.Label_Rehear.Size = new System.Drawing.Size(41, 12);
            this.Label_Rehear.TabIndex = 3;
            this.Label_Rehear.Text = "再审：";
            // 
            // TextBox_Lister
            // 
            this.TextBox_Lister.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZCWelder.Properties.Settings.Default, "Lister", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBox_Lister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Lister.Location = new System.Drawing.Point(76, 3);
            this.TextBox_Lister.Name = "TextBox_Lister";
            this.TextBox_Lister.Size = new System.Drawing.Size(178, 21);
            this.TextBox_Lister.TabIndex = 0;
            this.TextBox_Lister.Text = global::ZCWelder.Properties.Settings.Default.Lister;
            // 
            // TextBox_Assessor
            // 
            this.TextBox_Assessor.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZCWelder.Properties.Settings.Default, "Assessor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBox_Assessor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Assessor.Location = new System.Drawing.Point(76, 33);
            this.TextBox_Assessor.Name = "TextBox_Assessor";
            this.TextBox_Assessor.Size = new System.Drawing.Size(178, 21);
            this.TextBox_Assessor.TabIndex = 2;
            this.TextBox_Assessor.Text = global::ZCWelder.Properties.Settings.Default.Assessor;
            // 
            // TextBox_Corrector
            // 
            this.TextBox_Corrector.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZCWelder.Properties.Settings.Default, "Corrector", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBox_Corrector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Corrector.Location = new System.Drawing.Point(319, 3);
            this.TextBox_Corrector.Name = "TextBox_Corrector";
            this.TextBox_Corrector.Size = new System.Drawing.Size(175, 21);
            this.TextBox_Corrector.TabIndex = 1;
            this.TextBox_Corrector.Text = global::ZCWelder.Properties.Settings.Default.Corrector;
            // 
            // TextBox_Rehear
            // 
            this.TextBox_Rehear.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZCWelder.Properties.Settings.Default, "Rehear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBox_Rehear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Rehear.Location = new System.Drawing.Point(319, 33);
            this.TextBox_Rehear.Name = "TextBox_Rehear";
            this.TextBox_Rehear.Size = new System.Drawing.Size(175, 21);
            this.TextBox_Rehear.TabIndex = 3;
            this.TextBox_Rehear.Text = global::ZCWelder.Properties.Settings.Default.Rehear;
            // 
            // label_Company
            // 
            this.label_Company.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Company.AutoSize = true;
            this.label_Company.Location = new System.Drawing.Point(5, 69);
            this.label_Company.Name = "label_Company";
            this.label_Company.Size = new System.Drawing.Size(65, 12);
            this.label_Company.TabIndex = 2;
            this.label_Company.Text = "制表单位：";
            // 
            // label_Subhead
            // 
            this.label_Subhead.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Subhead.AutoSize = true;
            this.label_Subhead.Location = new System.Drawing.Point(17, 100);
            this.label_Subhead.Name = "label_Subhead";
            this.label_Subhead.Size = new System.Drawing.Size(53, 12);
            this.label_Subhead.TabIndex = 2;
            this.label_Subhead.Text = "副标题：";
            // 
            // textBox_Company
            // 
            this.TableLayoutPanel2.SetColumnSpan(this.textBox_Company, 3);
            this.textBox_Company.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZCWelder.Properties.Settings.Default, "Company", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_Company.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Company.Location = new System.Drawing.Point(76, 63);
            this.textBox_Company.Name = "textBox_Company";
            this.textBox_Company.Size = new System.Drawing.Size(418, 21);
            this.textBox_Company.TabIndex = 4;
            this.textBox_Company.Text = global::ZCWelder.Properties.Settings.Default.Company;
            // 
            // textBox_Subhead
            // 
            this.TableLayoutPanel2.SetColumnSpan(this.textBox_Subhead, 3);
            this.textBox_Subhead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Subhead.Location = new System.Drawing.Point(76, 93);
            this.textBox_Subhead.Name = "textBox_Subhead";
            this.textBox_Subhead.Size = new System.Drawing.Size(418, 21);
            this.textBox_Subhead.TabIndex = 5;
            // 
            // ListView_Report
            // 
            this.ListView_Report.Location = new System.Drawing.Point(12, 12);
            this.ListView_Report.MultiSelect = false;
            this.ListView_Report.Name = "ListView_Report";
            this.ListView_Report.Size = new System.Drawing.Size(497, 218);
            this.ListView_Report.TabIndex = 4;
            this.ListView_Report.UseCompatibleStateImageBehavior = false;
            this.ListView_Report.View = System.Windows.Forms.View.Details;
            this.ListView_Report.DoubleClick += new System.EventHandler(this.OK_Button_Click);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(363, 445);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 27);
            this.TableLayoutPanel1.TabIndex = 5;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.Location = new System.Drawing.Point(3, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(67, 21);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "确定";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(76, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(67, 21);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "取消";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // button_PageSet
            // 
            this.button_PageSet.Location = new System.Drawing.Point(12, 365);
            this.button_PageSet.Name = "button_PageSet";
            this.button_PageSet.Size = new System.Drawing.Size(111, 21);
            this.button_PageSet.TabIndex = 6;
            this.button_PageSet.Text = "选择打印机";
            this.button_PageSet.Visible = false;
            this.button_PageSet.Click += new System.EventHandler(this.button_PageSet_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 409F));
            this.tableLayoutPanel3.Controls.Add(this.textBox_PrinterName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_PrinterName, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 392);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(497, 36);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // textBox_PrinterName
            // 
            this.textBox_PrinterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_PrinterName.Location = new System.Drawing.Point(91, 3);
            this.textBox_PrinterName.Name = "textBox_PrinterName";
            this.textBox_PrinterName.Size = new System.Drawing.Size(403, 21);
            this.textBox_PrinterName.TabIndex = 0;
            this.textBox_PrinterName.Visible = false;
            // 
            // label_PrinterName
            // 
            this.label_PrinterName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_PrinterName.AutoSize = true;
            this.label_PrinterName.Location = new System.Drawing.Point(8, 12);
            this.label_PrinterName.Name = "label_PrinterName";
            this.label_PrinterName.Size = new System.Drawing.Size(77, 12);
            this.label_PrinterName.TabIndex = 0;
            this.label_PrinterName.Text = "打印机名称：";
            this.label_PrinterName.Visible = false;
            // 
            // Form_ReportSelect
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(521, 484);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.button_PageSet);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Controls.Add(this.ListView_Report);
            this.Controls.Add(this.TableLayoutPanel2);
            this.Name = "Form_ReportSelect";
            this.Text = "选择报表";
            this.Load += new System.EventHandler(this.Form_ReportSelect_Load);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Label Label_Lister;
        internal System.Windows.Forms.Label Label_Corrector;
        internal System.Windows.Forms.Label Label_Assessor;
        internal System.Windows.Forms.Label Label_Rehear;
        internal System.Windows.Forms.TextBox TextBox_Lister;
        internal System.Windows.Forms.TextBox TextBox_Assessor;
        internal System.Windows.Forms.TextBox TextBox_Corrector;
        internal System.Windows.Forms.TextBox TextBox_Rehear;
        internal System.Windows.Forms.ListView ListView_Report;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button OK_Button;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.Label label_Company;
        internal System.Windows.Forms.Label label_Subhead;
        internal System.Windows.Forms.TextBox textBox_Company;
        internal System.Windows.Forms.TextBox textBox_Subhead;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        internal System.Windows.Forms.Button button_PageSet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        internal System.Windows.Forms.TextBox textBox_PrinterName;
        internal System.Windows.Forms.Label label_PrinterName;
    }
}