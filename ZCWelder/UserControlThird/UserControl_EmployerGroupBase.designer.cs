namespace ZCWelder.UserControlThird
{
    partial class UserControl_EmployerGroupBase
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
            this.label_EmployerGroupRemark = new System.Windows.Forms.Label();
            this.label_EmployerGroupIndex = new System.Windows.Forms.Label();
            this.label_EmployerGroup = new System.Windows.Forms.Label();
            this.textBox_EmployerGroup = new System.Windows.Forms.TextBox();
            this.numericUpDown_EmployerGroupIndex = new System.Windows.Forms.NumericUpDown();
            this.textBox_EmployerGroupRemark = new System.Windows.Forms.TextBox();
            this.checkBox_OAVisible = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_EmployerGroupIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.Controls.Add(this.label_EmployerGroupRemark, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_EmployerGroupIndex, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_EmployerGroup, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_EmployerGroup, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_EmployerGroupIndex, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_EmployerGroupRemark, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_OAVisible, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(251, 137);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_EmployerGroupRemark
            // 
            this.label_EmployerGroupRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_EmployerGroupRemark.AutoSize = true;
            this.label_EmployerGroupRemark.Location = new System.Drawing.Point(27, 113);
            this.label_EmployerGroupRemark.Name = "label_EmployerGroupRemark";
            this.label_EmployerGroupRemark.Size = new System.Drawing.Size(41, 12);
            this.label_EmployerGroupRemark.TabIndex = 3;
            this.label_EmployerGroupRemark.Text = "备注：";
            // 
            // label_EmployerGroupIndex
            // 
            this.label_EmployerGroupIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_EmployerGroupIndex.AutoSize = true;
            this.label_EmployerGroupIndex.Location = new System.Drawing.Point(3, 79);
            this.label_EmployerGroupIndex.Name = "label_EmployerGroupIndex";
            this.label_EmployerGroupIndex.Size = new System.Drawing.Size(65, 12);
            this.label_EmployerGroupIndex.TabIndex = 5;
            this.label_EmployerGroupIndex.Text = "排序索引：";
            // 
            // label_EmployerGroup
            // 
            this.label_EmployerGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_EmployerGroup.AutoSize = true;
            this.label_EmployerGroup.Location = new System.Drawing.Point(15, 11);
            this.label_EmployerGroup.Name = "label_EmployerGroup";
            this.label_EmployerGroup.Size = new System.Drawing.Size(53, 12);
            this.label_EmployerGroup.TabIndex = 4;
            this.label_EmployerGroup.Text = "公司组：";
            // 
            // textBox_EmployerGroup
            // 
            this.textBox_EmployerGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_EmployerGroup.Location = new System.Drawing.Point(74, 3);
            this.textBox_EmployerGroup.Name = "textBox_EmployerGroup";
            this.textBox_EmployerGroup.Size = new System.Drawing.Size(174, 21);
            this.textBox_EmployerGroup.TabIndex = 0;
            // 
            // numericUpDown_EmployerGroupIndex
            // 
            this.numericUpDown_EmployerGroupIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_EmployerGroupIndex.Location = new System.Drawing.Point(74, 71);
            this.numericUpDown_EmployerGroupIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_EmployerGroupIndex.Name = "numericUpDown_EmployerGroupIndex";
            this.numericUpDown_EmployerGroupIndex.Size = new System.Drawing.Size(174, 21);
            this.numericUpDown_EmployerGroupIndex.TabIndex = 1;
            // 
            // textBox_EmployerGroupRemark
            // 
            this.textBox_EmployerGroupRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_EmployerGroupRemark.Location = new System.Drawing.Point(74, 105);
            this.textBox_EmployerGroupRemark.Name = "textBox_EmployerGroupRemark";
            this.textBox_EmployerGroupRemark.Size = new System.Drawing.Size(174, 21);
            this.textBox_EmployerGroupRemark.TabIndex = 2;
            // 
            // checkBox_OAVisible
            // 
            this.checkBox_OAVisible.AutoSize = true;
            this.checkBox_OAVisible.Location = new System.Drawing.Point(74, 37);
            this.checkBox_OAVisible.Name = "checkBox_OAVisible";
            this.checkBox_OAVisible.Size = new System.Drawing.Size(72, 16);
            this.checkBox_OAVisible.TabIndex = 6;
            this.checkBox_OAVisible.Text = "OA网可见";
            this.checkBox_OAVisible.UseVisualStyleBackColor = true;
            // 
            // UserControl_EmployerGroupBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControl_EmployerGroupBase";
            this.Size = new System.Drawing.Size(257, 143);
            this.Load += new System.EventHandler(this.UserControl_EmployerGroup_Base_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_EmployerGroupIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_EmployerGroupRemark;
        private System.Windows.Forms.Label label_EmployerGroupIndex;
        private System.Windows.Forms.Label label_EmployerGroup;
        private System.Windows.Forms.TextBox textBox_EmployerGroup;
        private System.Windows.Forms.NumericUpDown numericUpDown_EmployerGroupIndex;
        private System.Windows.Forms.TextBox textBox_EmployerGroupRemark;
        private System.Windows.Forms.CheckBox checkBox_OAVisible;
    }
}
