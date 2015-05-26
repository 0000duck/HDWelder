namespace ZCWelder.UserControlThird
{
    partial class UserControl_WeldingPositionBase
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
            this.numericUpDown_WeldingPositionIndex = new System.Windows.Forms.NumericUpDown();
            this.label_WeldingPositionIndex = new System.Windows.Forms.Label();
            this.label_WeldingPosition = new System.Windows.Forms.Label();
            this.textBox_WeldingPosition = new System.Windows.Forms.TextBox();
            this.label_WeldingPositionDenomination = new System.Windows.Forms.Label();
            this.textBox_WeldingPositionDenomination = new System.Windows.Forms.TextBox();
            this.label_WeldingPositionCCS = new System.Windows.Forms.Label();
            this.textBox_WeldingPositionCCS = new System.Windows.Forms.TextBox();
            this.label_WeldingPositionISO = new System.Windows.Forms.Label();
            this.label_WeldingPositionABS = new System.Windows.Forms.Label();
            this.label_WeldingPositionRemark = new System.Windows.Forms.Label();
            this.textBox_WeldingPositionISO = new System.Windows.Forms.TextBox();
            this.textBox_WeldingPositionABS = new System.Windows.Forms.TextBox();
            this.textBox_WeldingPositionRemark = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WeldingPositionIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_WeldingPositionIndex, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingPositionIndex, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingPosition, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingPosition, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingPositionDenomination, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingPositionDenomination, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingPositionCCS, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingPositionCCS, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingPositionISO, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingPositionABS, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingPositionRemark, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingPositionISO, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingPositionABS, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingPositionRemark, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(277, 213);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDown_WeldingPositionIndex
            // 
            this.numericUpDown_WeldingPositionIndex.Location = new System.Drawing.Point(108, 153);
            this.numericUpDown_WeldingPositionIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_WeldingPositionIndex.Name = "numericUpDown_WeldingPositionIndex";
            this.numericUpDown_WeldingPositionIndex.Size = new System.Drawing.Size(166, 21);
            this.numericUpDown_WeldingPositionIndex.TabIndex = 4;
            // 
            // label_WeldingPositionIndex
            // 
            this.label_WeldingPositionIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingPositionIndex.AutoSize = true;
            this.label_WeldingPositionIndex.Location = new System.Drawing.Point(37, 159);
            this.label_WeldingPositionIndex.Name = "label_WeldingPositionIndex";
            this.label_WeldingPositionIndex.Size = new System.Drawing.Size(65, 12);
            this.label_WeldingPositionIndex.TabIndex = 3;
            this.label_WeldingPositionIndex.Text = "排序索引：";
            // 
            // label_WeldingPosition
            // 
            this.label_WeldingPosition.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingPosition.AutoSize = true;
            this.label_WeldingPosition.Location = new System.Drawing.Point(13, 9);
            this.label_WeldingPosition.Name = "label_WeldingPosition";
            this.label_WeldingPosition.Size = new System.Drawing.Size(89, 12);
            this.label_WeldingPosition.TabIndex = 0;
            this.label_WeldingPosition.Text = "焊接位置符号：";
            // 
            // textBox_WeldingPosition
            // 
            this.textBox_WeldingPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingPosition.Location = new System.Drawing.Point(108, 3);
            this.textBox_WeldingPosition.Name = "textBox_WeldingPosition";
            this.textBox_WeldingPosition.Size = new System.Drawing.Size(166, 21);
            this.textBox_WeldingPosition.TabIndex = 1;
            // 
            // label_WeldingPositionDenomination
            // 
            this.label_WeldingPositionDenomination.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingPositionDenomination.AutoSize = true;
            this.label_WeldingPositionDenomination.Location = new System.Drawing.Point(37, 39);
            this.label_WeldingPositionDenomination.Name = "label_WeldingPositionDenomination";
            this.label_WeldingPositionDenomination.Size = new System.Drawing.Size(65, 12);
            this.label_WeldingPositionDenomination.TabIndex = 0;
            this.label_WeldingPositionDenomination.Text = "焊接位置：";
            // 
            // textBox_WeldingPositionDenomination
            // 
            this.textBox_WeldingPositionDenomination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingPositionDenomination.Location = new System.Drawing.Point(108, 33);
            this.textBox_WeldingPositionDenomination.Name = "textBox_WeldingPositionDenomination";
            this.textBox_WeldingPositionDenomination.Size = new System.Drawing.Size(166, 21);
            this.textBox_WeldingPositionDenomination.TabIndex = 1;
            // 
            // label_WeldingPositionCCS
            // 
            this.label_WeldingPositionCCS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingPositionCCS.AutoSize = true;
            this.label_WeldingPositionCCS.Location = new System.Drawing.Point(43, 69);
            this.label_WeldingPositionCCS.Name = "label_WeldingPositionCCS";
            this.label_WeldingPositionCCS.Size = new System.Drawing.Size(59, 12);
            this.label_WeldingPositionCCS.TabIndex = 0;
            this.label_WeldingPositionCCS.Text = "CCS符号：";
            // 
            // textBox_WeldingPositionCCS
            // 
            this.textBox_WeldingPositionCCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingPositionCCS.Location = new System.Drawing.Point(108, 63);
            this.textBox_WeldingPositionCCS.Name = "textBox_WeldingPositionCCS";
            this.textBox_WeldingPositionCCS.Size = new System.Drawing.Size(166, 21);
            this.textBox_WeldingPositionCCS.TabIndex = 1;
            // 
            // label_WeldingPositionISO
            // 
            this.label_WeldingPositionISO.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingPositionISO.AutoSize = true;
            this.label_WeldingPositionISO.Location = new System.Drawing.Point(43, 99);
            this.label_WeldingPositionISO.Name = "label_WeldingPositionISO";
            this.label_WeldingPositionISO.Size = new System.Drawing.Size(59, 12);
            this.label_WeldingPositionISO.TabIndex = 0;
            this.label_WeldingPositionISO.Text = "ISO符号：";
            // 
            // label_WeldingPositionABS
            // 
            this.label_WeldingPositionABS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingPositionABS.AutoSize = true;
            this.label_WeldingPositionABS.Location = new System.Drawing.Point(43, 129);
            this.label_WeldingPositionABS.Name = "label_WeldingPositionABS";
            this.label_WeldingPositionABS.Size = new System.Drawing.Size(59, 12);
            this.label_WeldingPositionABS.TabIndex = 0;
            this.label_WeldingPositionABS.Text = "ABS符号：";
            // 
            // label_WeldingPositionRemark
            // 
            this.label_WeldingPositionRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingPositionRemark.AutoSize = true;
            this.label_WeldingPositionRemark.Location = new System.Drawing.Point(61, 190);
            this.label_WeldingPositionRemark.Name = "label_WeldingPositionRemark";
            this.label_WeldingPositionRemark.Size = new System.Drawing.Size(41, 12);
            this.label_WeldingPositionRemark.TabIndex = 0;
            this.label_WeldingPositionRemark.Text = "备注：";
            // 
            // textBox_WeldingPositionISO
            // 
            this.textBox_WeldingPositionISO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingPositionISO.Location = new System.Drawing.Point(108, 93);
            this.textBox_WeldingPositionISO.Name = "textBox_WeldingPositionISO";
            this.textBox_WeldingPositionISO.Size = new System.Drawing.Size(166, 21);
            this.textBox_WeldingPositionISO.TabIndex = 1;
            // 
            // textBox_WeldingPositionABS
            // 
            this.textBox_WeldingPositionABS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingPositionABS.Location = new System.Drawing.Point(108, 123);
            this.textBox_WeldingPositionABS.Name = "textBox_WeldingPositionABS";
            this.textBox_WeldingPositionABS.Size = new System.Drawing.Size(166, 21);
            this.textBox_WeldingPositionABS.TabIndex = 1;
            // 
            // textBox_WeldingPositionRemark
            // 
            this.textBox_WeldingPositionRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingPositionRemark.Location = new System.Drawing.Point(108, 183);
            this.textBox_WeldingPositionRemark.Name = "textBox_WeldingPositionRemark";
            this.textBox_WeldingPositionRemark.Size = new System.Drawing.Size(166, 21);
            this.textBox_WeldingPositionRemark.TabIndex = 1;
            // 
            // UserControl_WeldingPositionBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControl_WeldingPositionBase";
            this.Size = new System.Drawing.Size(285, 221);
            this.Load += new System.EventHandler(this.UserControl_WeldingPositionBase_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WeldingPositionIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_WeldingPosition;
        private System.Windows.Forms.TextBox textBox_WeldingPosition;
        private System.Windows.Forms.Label label_WeldingPositionDenomination;
        private System.Windows.Forms.TextBox textBox_WeldingPositionDenomination;
        private System.Windows.Forms.Label label_WeldingPositionCCS;
        private System.Windows.Forms.TextBox textBox_WeldingPositionCCS;
        private System.Windows.Forms.Label label_WeldingPositionISO;
        private System.Windows.Forms.Label label_WeldingPositionABS;
        private System.Windows.Forms.Label label_WeldingPositionRemark;
        private System.Windows.Forms.TextBox textBox_WeldingPositionISO;
        private System.Windows.Forms.TextBox textBox_WeldingPositionABS;
        private System.Windows.Forms.TextBox textBox_WeldingPositionRemark;
        private System.Windows.Forms.NumericUpDown numericUpDown_WeldingPositionIndex;
        private System.Windows.Forms.Label label_WeldingPositionIndex;
    }
}
