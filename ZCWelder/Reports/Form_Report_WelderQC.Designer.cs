namespace ZCWelder.Reports
{
    partial class Form_Report_WelderQC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer_frame = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer_frame
            // 
            this.reportViewer_frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer_frame.Location = new System.Drawing.Point(0, 0);
            this.reportViewer_frame.Name = "reportViewer_frame";
            this.reportViewer_frame.Size = new System.Drawing.Size(540, 506);
            this.reportViewer_frame.TabIndex = 0;
            // 
            // Form_Report_WelderQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 506);
            this.Controls.Add(this.reportViewer_frame);
            this.Name = "Form_Report_WelderQC";
            this.Text = "显示报表";
            this.Load += new System.EventHandler(this.Form_Report_WelderQC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_frame;
    }
}