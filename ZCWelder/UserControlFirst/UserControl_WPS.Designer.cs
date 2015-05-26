namespace ZCWelder.UserControlFirst
{
    partial class UserControl_WPS
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip_WPS = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_WPSID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.userControl_WPS_Query1 = new ZCWelder.UserControlSecond.UserControl_WPS_Query();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.userControl_WPSDataGridView1 = new ZCWelder.UserControlSecond.UserControl_WPSDataGridView();
            this.tabControl_WPS = new System.Windows.Forms.TabControl();
            this.tabPage_WPSWeldingSequence = new System.Windows.Forms.TabPage();
            this.userControl_WPSSequenceDataGridView1 = new ZCWelder.UserControlSecond.UserControl_WPSSequenceDataGridView();
            this.tabPage_WPSGasAndWeldingFlux = new System.Windows.Forms.TabPage();
            this.tabPage_WPSHeatTreatment = new System.Windows.Forms.TabPage();
            this.tabPage_WPSImage = new System.Windows.Forms.TabPage();
            this.userControl_WPSImageDataGridView1 = new ZCWelder.UserControlSecond.UserControl_WPSImageDataGridView();
            this.userControl_WPSHeatTreatmentDataGridView1 = new ZCWelder.UserControlSecond.UserControl_WPSHeatTreatmentDataGridView();
            this.userControl_WPSGasAndWeldingFluxDataGridView1 = new ZCWelder.UserControlSecond.UserControl_WPSGasAndWeldingFluxDataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip_WPS.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl_WPS.SuspendLayout();
            this.tabPage_WPSWeldingSequence.SuspendLayout();
            this.tabPage_WPSGasAndWeldingFlux.SuspendLayout();
            this.tabPage_WPSHeatTreatment.SuspendLayout();
            this.tabPage_WPSImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.userControl_WPS_Query1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(592, 465);
            this.splitContainer1.SplitterDistance = 278;
            this.splitContainer1.TabIndex = 0;
            // 
            // statusStrip_WPS
            // 
            this.statusStrip_WPS.AutoSize = false;
            this.statusStrip_WPS.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip_WPS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_WPSID});
            this.statusStrip_WPS.Location = new System.Drawing.Point(0, 0);
            this.statusStrip_WPS.Name = "statusStrip_WPS";
            this.statusStrip_WPS.Size = new System.Drawing.Size(592, 22);
            this.statusStrip_WPS.TabIndex = 0;
            // 
            // toolStripStatusLabel_WPSID
            // 
            this.toolStripStatusLabel_WPSID.AutoSize = false;
            this.toolStripStatusLabel_WPSID.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_WPSID.Name = "toolStripStatusLabel_WPSID";
            this.toolStripStatusLabel_WPSID.Size = new System.Drawing.Size(300, 17);
            this.toolStripStatusLabel_WPSID.Text = "参数：";
            this.toolStripStatusLabel_WPSID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip_WPS);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(592, 465);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(592, 512);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // userControl_WPS_Query1
            // 
            this.userControl_WPS_Query1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WPS_Query1.Location = new System.Drawing.Point(0, 0);
            this.userControl_WPS_Query1.Name = "userControl_WPS_Query1";
            this.userControl_WPS_Query1.Size = new System.Drawing.Size(276, 463);
            this.userControl_WPS_Query1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.userControl_WPSDataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl_WPS);
            this.splitContainer2.Size = new System.Drawing.Size(308, 463);
            this.splitContainer2.SplitterDistance = 230;
            this.splitContainer2.TabIndex = 1;
            // 
            // userControl_WPSDataGridView1
            // 
            this.userControl_WPSDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WPSDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_WPSDataGridView1.Name = "userControl_WPSDataGridView1";
            this.userControl_WPSDataGridView1.Size = new System.Drawing.Size(308, 230);
            this.userControl_WPSDataGridView1.TabIndex = 0;
            // 
            // tabControl_WPS
            // 
            this.tabControl_WPS.Controls.Add(this.tabPage_WPSWeldingSequence);
            this.tabControl_WPS.Controls.Add(this.tabPage_WPSGasAndWeldingFlux);
            this.tabControl_WPS.Controls.Add(this.tabPage_WPSHeatTreatment);
            this.tabControl_WPS.Controls.Add(this.tabPage_WPSImage);
            this.tabControl_WPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_WPS.Location = new System.Drawing.Point(0, 0);
            this.tabControl_WPS.Name = "tabControl_WPS";
            this.tabControl_WPS.SelectedIndex = 0;
            this.tabControl_WPS.Size = new System.Drawing.Size(308, 229);
            this.tabControl_WPS.TabIndex = 0;
            // 
            // tabPage_WPSWeldingSequence
            // 
            this.tabPage_WPSWeldingSequence.Controls.Add(this.userControl_WPSSequenceDataGridView1);
            this.tabPage_WPSWeldingSequence.Location = new System.Drawing.Point(4, 21);
            this.tabPage_WPSWeldingSequence.Name = "tabPage_WPSWeldingSequence";
            this.tabPage_WPSWeldingSequence.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_WPSWeldingSequence.Size = new System.Drawing.Size(300, 204);
            this.tabPage_WPSWeldingSequence.TabIndex = 0;
            this.tabPage_WPSWeldingSequence.Text = "焊接参数";
            this.tabPage_WPSWeldingSequence.UseVisualStyleBackColor = true;
            // 
            // userControl_WPSSequenceDataGridView1
            // 
            this.userControl_WPSSequenceDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WPSSequenceDataGridView1.Location = new System.Drawing.Point(3, 3);
            this.userControl_WPSSequenceDataGridView1.Name = "userControl_WPSSequenceDataGridView1";
            this.userControl_WPSSequenceDataGridView1.Size = new System.Drawing.Size(294, 198);
            this.userControl_WPSSequenceDataGridView1.TabIndex = 0;
            // 
            // tabPage_WPSGasAndWeldingFlux
            // 
            this.tabPage_WPSGasAndWeldingFlux.Controls.Add(this.userControl_WPSGasAndWeldingFluxDataGridView1);
            this.tabPage_WPSGasAndWeldingFlux.Location = new System.Drawing.Point(4, 21);
            this.tabPage_WPSGasAndWeldingFlux.Name = "tabPage_WPSGasAndWeldingFlux";
            this.tabPage_WPSGasAndWeldingFlux.Size = new System.Drawing.Size(300, 204);
            this.tabPage_WPSGasAndWeldingFlux.TabIndex = 1;
            this.tabPage_WPSGasAndWeldingFlux.Text = "焊接辅助材料";
            this.tabPage_WPSGasAndWeldingFlux.UseVisualStyleBackColor = true;
            // 
            // tabPage_WPSHeatTreatment
            // 
            this.tabPage_WPSHeatTreatment.Controls.Add(this.userControl_WPSHeatTreatmentDataGridView1);
            this.tabPage_WPSHeatTreatment.Location = new System.Drawing.Point(4, 21);
            this.tabPage_WPSHeatTreatment.Name = "tabPage_WPSHeatTreatment";
            this.tabPage_WPSHeatTreatment.Size = new System.Drawing.Size(300, 204);
            this.tabPage_WPSHeatTreatment.TabIndex = 2;
            this.tabPage_WPSHeatTreatment.Text = "热处理方式";
            this.tabPage_WPSHeatTreatment.UseVisualStyleBackColor = true;
            // 
            // tabPage_WPSImage
            // 
            this.tabPage_WPSImage.Controls.Add(this.userControl_WPSImageDataGridView1);
            this.tabPage_WPSImage.Location = new System.Drawing.Point(4, 21);
            this.tabPage_WPSImage.Name = "tabPage_WPSImage";
            this.tabPage_WPSImage.Size = new System.Drawing.Size(300, 204);
            this.tabPage_WPSImage.TabIndex = 3;
            this.tabPage_WPSImage.Text = "图片";
            this.tabPage_WPSImage.UseVisualStyleBackColor = true;
            // 
            // userControl_WPSImageDataGridView1
            // 
            this.userControl_WPSImageDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WPSImageDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_WPSImageDataGridView1.Name = "userControl_WPSImageDataGridView1";
            this.userControl_WPSImageDataGridView1.Size = new System.Drawing.Size(300, 204);
            this.userControl_WPSImageDataGridView1.TabIndex = 0;
            // 
            // userControl_WPSHeatTreatmentDataGridView1
            // 
            this.userControl_WPSHeatTreatmentDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WPSHeatTreatmentDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_WPSHeatTreatmentDataGridView1.Name = "userControl_WPSHeatTreatmentDataGridView1";
            this.userControl_WPSHeatTreatmentDataGridView1.Size = new System.Drawing.Size(300, 204);
            this.userControl_WPSHeatTreatmentDataGridView1.TabIndex = 0;
            // 
            // userControl_WPSGasAndWeldingFluxDataGridView1
            // 
            this.userControl_WPSGasAndWeldingFluxDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_WPSGasAndWeldingFluxDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.userControl_WPSGasAndWeldingFluxDataGridView1.Name = "userControl_WPSGasAndWeldingFluxDataGridView1";
            this.userControl_WPSGasAndWeldingFluxDataGridView1.Size = new System.Drawing.Size(300, 204);
            this.userControl_WPSGasAndWeldingFluxDataGridView1.TabIndex = 0;
            // 
            // UserControl_WPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_WPS";
            this.Size = new System.Drawing.Size(592, 512);
            this.Load += new System.EventHandler(this.UserControl_WPS_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip_WPS.ResumeLayout(false);
            this.statusStrip_WPS.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabControl_WPS.ResumeLayout(false);
            this.tabPage_WPSWeldingSequence.ResumeLayout(false);
            this.tabPage_WPSGasAndWeldingFlux.ResumeLayout(false);
            this.tabPage_WPSHeatTreatment.ResumeLayout(false);
            this.tabPage_WPSImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip_WPS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_WPSID;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private ZCWelder.UserControlSecond.UserControl_WPS_Query userControl_WPS_Query1;
        private ZCWelder.UserControlSecond.UserControl_WPSDataGridView userControl_WPSDataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl_WPS;
        private System.Windows.Forms.TabPage tabPage_WPSWeldingSequence;
        private ZCWelder.UserControlSecond.UserControl_WPSSequenceDataGridView userControl_WPSSequenceDataGridView1;
        private System.Windows.Forms.TabPage tabPage_WPSGasAndWeldingFlux;
        private System.Windows.Forms.TabPage tabPage_WPSHeatTreatment;
        private System.Windows.Forms.TabPage tabPage_WPSImage;
        private ZCWelder.UserControlSecond.UserControl_WPSGasAndWeldingFluxDataGridView userControl_WPSGasAndWeldingFluxDataGridView1;
        private ZCWelder.UserControlSecond.UserControl_WPSHeatTreatmentDataGridView userControl_WPSHeatTreatmentDataGridView1;
        private ZCWelder.UserControlSecond.UserControl_WPSImageDataGridView userControl_WPSImageDataGridView1;
    }
}
