namespace ZCWelder.UserControlThird
{
    partial class UserControl_WeldingStandardBase
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_WeldingStandard = new System.Windows.Forms.Label();
            this.textBox_WeldingStandard = new System.Windows.Forms.TextBox();
            this.label_WeldingStandardTitle = new System.Windows.Forms.Label();
            this.textBox_WeldingStandardTitle = new System.Windows.Forms.TextBox();
            this.label_WeldingStandardRemark = new System.Windows.Forms.Label();
            this.textBox_WeldingStandardRemark = new System.Windows.Forms.TextBox();
            this.label_WeldingStandardIndex = new System.Windows.Forms.Label();
            this.numericUpDown_WeldingStandardIndex = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog_WeldingStandardFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_pWPSAccessory = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WeldingStandardIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 310F));
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingStandard, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingStandard, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingStandardTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingStandardTitle, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingStandardRemark, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingStandardRemark, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingStandardIndex, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_WeldingStandardIndex, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00001F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 134);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label_WeldingStandard
            // 
            this.label_WeldingStandard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingStandard.AutoSize = true;
            this.label_WeldingStandard.Location = new System.Drawing.Point(27, 10);
            this.label_WeldingStandard.Name = "label_WeldingStandard";
            this.label_WeldingStandard.Size = new System.Drawing.Size(65, 12);
            this.label_WeldingStandard.TabIndex = 0;
            this.label_WeldingStandard.Text = "焊接标准：";
            // 
            // textBox_WeldingStandard
            // 
            this.textBox_WeldingStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingStandard.Location = new System.Drawing.Point(98, 3);
            this.textBox_WeldingStandard.Name = "textBox_WeldingStandard";
            this.textBox_WeldingStandard.Size = new System.Drawing.Size(304, 21);
            this.textBox_WeldingStandard.TabIndex = 1;
            // 
            // label_WeldingStandardTitle
            // 
            this.label_WeldingStandardTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingStandardTitle.AutoSize = true;
            this.label_WeldingStandardTitle.Location = new System.Drawing.Point(3, 43);
            this.label_WeldingStandardTitle.Name = "label_WeldingStandardTitle";
            this.label_WeldingStandardTitle.Size = new System.Drawing.Size(89, 12);
            this.label_WeldingStandardTitle.TabIndex = 0;
            this.label_WeldingStandardTitle.Text = "焊接标准名称：";
            // 
            // textBox_WeldingStandardTitle
            // 
            this.textBox_WeldingStandardTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingStandardTitle.Location = new System.Drawing.Point(98, 36);
            this.textBox_WeldingStandardTitle.Name = "textBox_WeldingStandardTitle";
            this.textBox_WeldingStandardTitle.Size = new System.Drawing.Size(304, 21);
            this.textBox_WeldingStandardTitle.TabIndex = 1;
            // 
            // label_WeldingStandardRemark
            // 
            this.label_WeldingStandardRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingStandardRemark.AutoSize = true;
            this.label_WeldingStandardRemark.Location = new System.Drawing.Point(51, 110);
            this.label_WeldingStandardRemark.Name = "label_WeldingStandardRemark";
            this.label_WeldingStandardRemark.Size = new System.Drawing.Size(41, 12);
            this.label_WeldingStandardRemark.TabIndex = 0;
            this.label_WeldingStandardRemark.Text = "备注：";
            // 
            // textBox_WeldingStandardRemark
            // 
            this.textBox_WeldingStandardRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingStandardRemark.Location = new System.Drawing.Point(98, 102);
            this.textBox_WeldingStandardRemark.Name = "textBox_WeldingStandardRemark";
            this.textBox_WeldingStandardRemark.Size = new System.Drawing.Size(304, 21);
            this.textBox_WeldingStandardRemark.TabIndex = 1;
            // 
            // label_WeldingStandardIndex
            // 
            this.label_WeldingStandardIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingStandardIndex.AutoSize = true;
            this.label_WeldingStandardIndex.Location = new System.Drawing.Point(27, 76);
            this.label_WeldingStandardIndex.Name = "label_WeldingStandardIndex";
            this.label_WeldingStandardIndex.Size = new System.Drawing.Size(65, 12);
            this.label_WeldingStandardIndex.TabIndex = 0;
            this.label_WeldingStandardIndex.Text = "排序索引：";
            // 
            // numericUpDown_WeldingStandardIndex
            // 
            this.numericUpDown_WeldingStandardIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_WeldingStandardIndex.Location = new System.Drawing.Point(98, 69);
            this.numericUpDown_WeldingStandardIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_WeldingStandardIndex.Name = "numericUpDown_WeldingStandardIndex";
            this.numericUpDown_WeldingStandardIndex.Size = new System.Drawing.Size(304, 21);
            this.numericUpDown_WeldingStandardIndex.TabIndex = 2;
            // 
            // openFileDialog_WeldingStandardFile
            // 
            this.openFileDialog_WeldingStandardFile.FileName = "openFileDialog1";
            // 
            // UserControl_WeldingStandardBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControl_WeldingStandardBase";
            this.Size = new System.Drawing.Size(415, 144);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WeldingStandardIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_WeldingStandard;
        private System.Windows.Forms.TextBox textBox_WeldingStandard;
        private System.Windows.Forms.Label label_WeldingStandardTitle;
        private System.Windows.Forms.TextBox textBox_WeldingStandardTitle;
        private System.Windows.Forms.Label label_WeldingStandardRemark;
        private System.Windows.Forms.TextBox textBox_WeldingStandardRemark;
        private System.Windows.Forms.Label label_WeldingStandardIndex;
        private System.Windows.Forms.NumericUpDown numericUpDown_WeldingStandardIndex;
        private System.Windows.Forms.OpenFileDialog openFileDialog_WeldingStandardFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_pWPSAccessory;
    }
}
