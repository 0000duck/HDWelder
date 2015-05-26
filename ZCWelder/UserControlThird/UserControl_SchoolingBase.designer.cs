namespace ZCWelder.UserControlThird
{
    partial class UserControl_SchoolingBase
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
            this.label_SchoolingRemark = new System.Windows.Forms.Label();
            this.label_SchoolingIndex = new System.Windows.Forms.Label();
            this.label_Schooling = new System.Windows.Forms.Label();
            this.textBox_Schooling = new System.Windows.Forms.TextBox();
            this.numericUpDown_SchoolingIndex = new System.Windows.Forms.NumericUpDown();
            this.textBox_SchoolingRemark = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SchoolingIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tableLayoutPanel1.Controls.Add(this.label_SchoolingRemark, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_SchoolingIndex, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_Schooling, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Schooling, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_SchoolingIndex, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_SchoolingRemark, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(294, 112);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label_SchoolingRemark
            // 
            this.label_SchoolingRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_SchoolingRemark.AutoSize = true;
            this.label_SchoolingRemark.Location = new System.Drawing.Point(35, 87);
            this.label_SchoolingRemark.Name = "label_SchoolingRemark";
            this.label_SchoolingRemark.Size = new System.Drawing.Size(41, 12);
            this.label_SchoolingRemark.TabIndex = 3;
            this.label_SchoolingRemark.Text = "备注：";
            // 
            // label_SchoolingIndex
            // 
            this.label_SchoolingIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_SchoolingIndex.AutoSize = true;
            this.label_SchoolingIndex.Location = new System.Drawing.Point(11, 49);
            this.label_SchoolingIndex.Name = "label_SchoolingIndex";
            this.label_SchoolingIndex.Size = new System.Drawing.Size(65, 12);
            this.label_SchoolingIndex.TabIndex = 5;
            this.label_SchoolingIndex.Text = "排序索引：";
            // 
            // label_Schooling
            // 
            this.label_Schooling.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Schooling.AutoSize = true;
            this.label_Schooling.Location = new System.Drawing.Point(35, 12);
            this.label_Schooling.Name = "label_Schooling";
            this.label_Schooling.Size = new System.Drawing.Size(41, 12);
            this.label_Schooling.TabIndex = 4;
            this.label_Schooling.Text = "学历：";
            // 
            // textBox_Schooling
            // 
            this.textBox_Schooling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Schooling.Location = new System.Drawing.Point(82, 3);
            this.textBox_Schooling.Name = "textBox_Schooling";
            this.textBox_Schooling.Size = new System.Drawing.Size(209, 21);
            this.textBox_Schooling.TabIndex = 0;
            // 
            // numericUpDown_SchoolingIndex
            // 
            this.numericUpDown_SchoolingIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_SchoolingIndex.Location = new System.Drawing.Point(82, 40);
            this.numericUpDown_SchoolingIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_SchoolingIndex.Name = "numericUpDown_SchoolingIndex";
            this.numericUpDown_SchoolingIndex.Size = new System.Drawing.Size(209, 21);
            this.numericUpDown_SchoolingIndex.TabIndex = 2;
            // 
            // textBox_SchoolingRemark
            // 
            this.textBox_SchoolingRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SchoolingRemark.Location = new System.Drawing.Point(82, 77);
            this.textBox_SchoolingRemark.Name = "textBox_SchoolingRemark";
            this.textBox_SchoolingRemark.Size = new System.Drawing.Size(209, 21);
            this.textBox_SchoolingRemark.TabIndex = 3;
            // 
            // UserControl_SchoolingBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControl_SchoolingBase";
            this.Size = new System.Drawing.Size(303, 120);
            this.Load += new System.EventHandler(this.UserControl_SchoolingBase_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SchoolingIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_SchoolingRemark;
        private System.Windows.Forms.Label label_SchoolingIndex;
        private System.Windows.Forms.Label label_Schooling;
        private System.Windows.Forms.TextBox textBox_Schooling;
        private System.Windows.Forms.NumericUpDown numericUpDown_SchoolingIndex;
        private System.Windows.Forms.TextBox textBox_SchoolingRemark;
    }
}
