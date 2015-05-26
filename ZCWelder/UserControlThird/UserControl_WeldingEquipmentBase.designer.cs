namespace ZCWelder.UserControlThird
{
    partial class UserControl_WeldingEquipmentBase
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
            this.label_WeldingEquipment = new System.Windows.Forms.Label();
            this.textBox_WeldingEquipment = new System.Windows.Forms.TextBox();
            this.label_WeldingEquipmentRemark = new System.Windows.Forms.Label();
            this.textBox_WeldingEquipmentRemark = new System.Windows.Forms.TextBox();
            this.label_WeldingEquipmentIndex = new System.Windows.Forms.Label();
            this.numericUpDown_WeldingEquipmentIndex = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WeldingEquipmentIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingEquipment, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingEquipment, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingEquipmentRemark, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingEquipmentRemark, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingEquipmentIndex, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_WeldingEquipmentIndex, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 98);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label_WeldingEquipment
            // 
            this.label_WeldingEquipment.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingEquipment.AutoSize = true;
            this.label_WeldingEquipment.Location = new System.Drawing.Point(4, 10);
            this.label_WeldingEquipment.Name = "label_WeldingEquipment";
            this.label_WeldingEquipment.Size = new System.Drawing.Size(65, 12);
            this.label_WeldingEquipment.TabIndex = 0;
            this.label_WeldingEquipment.Text = "焊接设备：";
            // 
            // textBox_WeldingEquipment
            // 
            this.textBox_WeldingEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingEquipment.Location = new System.Drawing.Point(75, 3);
            this.textBox_WeldingEquipment.Name = "textBox_WeldingEquipment";
            this.textBox_WeldingEquipment.Size = new System.Drawing.Size(230, 21);
            this.textBox_WeldingEquipment.TabIndex = 1;
            // 
            // label_WeldingEquipmentRemark
            // 
            this.label_WeldingEquipmentRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingEquipmentRemark.AutoSize = true;
            this.label_WeldingEquipmentRemark.Location = new System.Drawing.Point(28, 75);
            this.label_WeldingEquipmentRemark.Name = "label_WeldingEquipmentRemark";
            this.label_WeldingEquipmentRemark.Size = new System.Drawing.Size(41, 12);
            this.label_WeldingEquipmentRemark.TabIndex = 0;
            this.label_WeldingEquipmentRemark.Text = "备注：";
            // 
            // textBox_WeldingEquipmentRemark
            // 
            this.textBox_WeldingEquipmentRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingEquipmentRemark.Location = new System.Drawing.Point(75, 67);
            this.textBox_WeldingEquipmentRemark.Name = "textBox_WeldingEquipmentRemark";
            this.textBox_WeldingEquipmentRemark.Size = new System.Drawing.Size(230, 21);
            this.textBox_WeldingEquipmentRemark.TabIndex = 1;
            // 
            // label_WeldingEquipmentIndex
            // 
            this.label_WeldingEquipmentIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingEquipmentIndex.AutoSize = true;
            this.label_WeldingEquipmentIndex.Location = new System.Drawing.Point(4, 42);
            this.label_WeldingEquipmentIndex.Name = "label_WeldingEquipmentIndex";
            this.label_WeldingEquipmentIndex.Size = new System.Drawing.Size(65, 12);
            this.label_WeldingEquipmentIndex.TabIndex = 0;
            this.label_WeldingEquipmentIndex.Text = "排序索引：";
            // 
            // numericUpDown_WeldingEquipmentIndex
            // 
            this.numericUpDown_WeldingEquipmentIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_WeldingEquipmentIndex.Location = new System.Drawing.Point(75, 35);
            this.numericUpDown_WeldingEquipmentIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_WeldingEquipmentIndex.Name = "numericUpDown_WeldingEquipmentIndex";
            this.numericUpDown_WeldingEquipmentIndex.Size = new System.Drawing.Size(230, 21);
            this.numericUpDown_WeldingEquipmentIndex.TabIndex = 2;
            // 
            // UserControl_WeldingEquipmentBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControl_WeldingEquipmentBase";
            this.Size = new System.Drawing.Size(316, 106);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WeldingEquipmentIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_WeldingEquipment;
        private System.Windows.Forms.TextBox textBox_WeldingEquipment;
        private System.Windows.Forms.Label label_WeldingEquipmentRemark;
        private System.Windows.Forms.TextBox textBox_WeldingEquipmentRemark;
        private System.Windows.Forms.Label label_WeldingEquipmentIndex;
        private System.Windows.Forms.NumericUpDown numericUpDown_WeldingEquipmentIndex;
    }
}
