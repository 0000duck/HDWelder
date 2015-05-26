namespace ZCWelder.CrystalReports
{
    partial class Form_CrystalReport
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
            this.crystalReportViewer_Container = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer_Container
            // 
            this.crystalReportViewer_Container.ActiveViewIndex = -1;
            this.crystalReportViewer_Container.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer_Container.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer_Container.Name = "crystalReportViewer_Container";
            this.crystalReportViewer_Container.SelectionFormula = "";
            this.crystalReportViewer_Container.Size = new System.Drawing.Size(645, 592);
            this.crystalReportViewer_Container.TabIndex = 0;
            this.crystalReportViewer_Container.ViewTimeSelectionFormula = "";
            // 
            // Form_CrystalReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 592);
            this.Controls.Add(this.crystalReportViewer_Container);
            this.Name = "Form_CrystalReport";
            this.Text = "显示报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_CrystalReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer_Container;
    }
}