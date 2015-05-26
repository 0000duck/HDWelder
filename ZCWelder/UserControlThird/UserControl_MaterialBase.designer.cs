namespace ZCWelder.UserControlThird
{
    partial class UserControl_MaterialBase
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
            this.label_Material = new System.Windows.Forms.Label();
            this.label_MaterialGBName = new System.Windows.Forms.Label();
            this.comboBox_MaterialDenominateWeldingStandard = new System.Windows.Forms.ComboBox();
            this.textBox_Material = new System.Windows.Forms.TextBox();
            this.label_MaterialRemark = new System.Windows.Forms.Label();
            this.textBox_MaterialRemark = new System.Windows.Forms.TextBox();
            this.label_MaterialIndex = new System.Windows.Forms.Label();
            this.numericUpDown_MaterialIndex = new System.Windows.Forms.NumericUpDown();
            this.textBox_MaterialCCSGroupAb = new System.Windows.Forms.TextBox();
            this.textBox_MaterialISOGroupAb = new System.Windows.Forms.TextBox();
            this.label_MaterialCCSGroupAb = new System.Windows.Forms.Label();
            this.label_MaterialISOGroupAb = new System.Windows.Forms.Label();
            this.textBox_MaterialGBName = new System.Windows.Forms.TextBox();
            this.label_MaterialDenominateWeldingStandard = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaterialIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel1.Controls.Add(this.label_Material, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_MaterialGBName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_MaterialDenominateWeldingStandard, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Material, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_MaterialRemark, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox_MaterialRemark, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label_MaterialIndex, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_MaterialIndex, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox_MaterialCCSGroupAb, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_MaterialISOGroupAb, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_MaterialCCSGroupAb, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_MaterialISOGroupAb, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_MaterialGBName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_MaterialDenominateWeldingStandard, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 227);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label_Material
            // 
            this.label_Material.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Material.AutoSize = true;
            this.label_Material.Location = new System.Drawing.Point(53, 10);
            this.label_Material.Name = "label_Material";
            this.label_Material.Size = new System.Drawing.Size(41, 12);
            this.label_Material.TabIndex = 0;
            this.label_Material.Text = "材料：";
            // 
            // label_MaterialGBName
            // 
            this.label_MaterialGBName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_MaterialGBName.AutoSize = true;
            this.label_MaterialGBName.Location = new System.Drawing.Point(29, 74);
            this.label_MaterialGBName.Name = "label_MaterialGBName";
            this.label_MaterialGBName.Size = new System.Drawing.Size(65, 12);
            this.label_MaterialGBName.TabIndex = 0;
            this.label_MaterialGBName.Text = "GB材料名：";
            // 
            // comboBox_MaterialDenominateWeldingStandard
            // 
            this.comboBox_MaterialDenominateWeldingStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MaterialDenominateWeldingStandard.FormattingEnabled = true;
            this.comboBox_MaterialDenominateWeldingStandard.Location = new System.Drawing.Point(100, 35);
            this.comboBox_MaterialDenominateWeldingStandard.Name = "comboBox_MaterialDenominateWeldingStandard";
            this.comboBox_MaterialDenominateWeldingStandard.Size = new System.Drawing.Size(205, 20);
            this.comboBox_MaterialDenominateWeldingStandard.TabIndex = 3;
            // 
            // textBox_Material
            // 
            this.textBox_Material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Material.Location = new System.Drawing.Point(100, 3);
            this.textBox_Material.Name = "textBox_Material";
            this.textBox_Material.Size = new System.Drawing.Size(205, 21);
            this.textBox_Material.TabIndex = 1;
            // 
            // label_MaterialRemark
            // 
            this.label_MaterialRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_MaterialRemark.AutoSize = true;
            this.label_MaterialRemark.Location = new System.Drawing.Point(53, 203);
            this.label_MaterialRemark.Name = "label_MaterialRemark";
            this.label_MaterialRemark.Size = new System.Drawing.Size(41, 12);
            this.label_MaterialRemark.TabIndex = 0;
            this.label_MaterialRemark.Text = "备注：";
            // 
            // textBox_MaterialRemark
            // 
            this.textBox_MaterialRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_MaterialRemark.Location = new System.Drawing.Point(100, 195);
            this.textBox_MaterialRemark.Name = "textBox_MaterialRemark";
            this.textBox_MaterialRemark.Size = new System.Drawing.Size(205, 21);
            this.textBox_MaterialRemark.TabIndex = 1;
            // 
            // label_MaterialIndex
            // 
            this.label_MaterialIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_MaterialIndex.AutoSize = true;
            this.label_MaterialIndex.Location = new System.Drawing.Point(29, 170);
            this.label_MaterialIndex.Name = "label_MaterialIndex";
            this.label_MaterialIndex.Size = new System.Drawing.Size(65, 12);
            this.label_MaterialIndex.TabIndex = 0;
            this.label_MaterialIndex.Text = "排序索引：";
            // 
            // numericUpDown_MaterialIndex
            // 
            this.numericUpDown_MaterialIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_MaterialIndex.Location = new System.Drawing.Point(100, 163);
            this.numericUpDown_MaterialIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_MaterialIndex.Name = "numericUpDown_MaterialIndex";
            this.numericUpDown_MaterialIndex.Size = new System.Drawing.Size(205, 21);
            this.numericUpDown_MaterialIndex.TabIndex = 2;
            // 
            // textBox_MaterialCCSGroupAb
            // 
            this.textBox_MaterialCCSGroupAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_MaterialCCSGroupAb.Location = new System.Drawing.Point(100, 99);
            this.textBox_MaterialCCSGroupAb.Name = "textBox_MaterialCCSGroupAb";
            this.textBox_MaterialCCSGroupAb.ReadOnly = true;
            this.textBox_MaterialCCSGroupAb.Size = new System.Drawing.Size(205, 21);
            this.textBox_MaterialCCSGroupAb.TabIndex = 1;
            this.textBox_MaterialCCSGroupAb.DoubleClick += new System.EventHandler(this.textBox_MaterialCCSGroupAb_DoubleClick);
            // 
            // textBox_MaterialISOGroupAb
            // 
            this.textBox_MaterialISOGroupAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_MaterialISOGroupAb.Location = new System.Drawing.Point(100, 131);
            this.textBox_MaterialISOGroupAb.Name = "textBox_MaterialISOGroupAb";
            this.textBox_MaterialISOGroupAb.ReadOnly = true;
            this.textBox_MaterialISOGroupAb.Size = new System.Drawing.Size(205, 21);
            this.textBox_MaterialISOGroupAb.TabIndex = 1;
            this.textBox_MaterialISOGroupAb.DoubleClick += new System.EventHandler(this.textBox_MaterialISOGroupAb_DoubleClick);
            // 
            // label_MaterialCCSGroupAb
            // 
            this.label_MaterialCCSGroupAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_MaterialCCSGroupAb.AutoSize = true;
            this.label_MaterialCCSGroupAb.Location = new System.Drawing.Point(23, 106);
            this.label_MaterialCCSGroupAb.Name = "label_MaterialCCSGroupAb";
            this.label_MaterialCCSGroupAb.Size = new System.Drawing.Size(71, 12);
            this.label_MaterialCCSGroupAb.TabIndex = 0;
            this.label_MaterialCCSGroupAb.Text = "材料CCS组：";
            // 
            // label_MaterialISOGroupAb
            // 
            this.label_MaterialISOGroupAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_MaterialISOGroupAb.AutoSize = true;
            this.label_MaterialISOGroupAb.Location = new System.Drawing.Point(23, 138);
            this.label_MaterialISOGroupAb.Name = "label_MaterialISOGroupAb";
            this.label_MaterialISOGroupAb.Size = new System.Drawing.Size(71, 12);
            this.label_MaterialISOGroupAb.TabIndex = 0;
            this.label_MaterialISOGroupAb.Text = "材料ISO组：";
            // 
            // textBox_MaterialGBName
            // 
            this.textBox_MaterialGBName.Location = new System.Drawing.Point(100, 67);
            this.textBox_MaterialGBName.Name = "textBox_MaterialGBName";
            this.textBox_MaterialGBName.Size = new System.Drawing.Size(205, 21);
            this.textBox_MaterialGBName.TabIndex = 1;
            // 
            // label_MaterialDenominateWeldingStandard
            // 
            this.label_MaterialDenominateWeldingStandard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_MaterialDenominateWeldingStandard.AutoSize = true;
            this.label_MaterialDenominateWeldingStandard.Location = new System.Drawing.Point(5, 42);
            this.label_MaterialDenominateWeldingStandard.Name = "label_MaterialDenominateWeldingStandard";
            this.label_MaterialDenominateWeldingStandard.Size = new System.Drawing.Size(89, 12);
            this.label_MaterialDenominateWeldingStandard.TabIndex = 0;
            this.label_MaterialDenominateWeldingStandard.Text = "采用命名标准：";
            // 
            // UserControl_MaterialBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControl_MaterialBase";
            this.Size = new System.Drawing.Size(317, 238);
            this.Load += new System.EventHandler(this.UserControl_MaterialBase_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaterialIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_Material;
        private System.Windows.Forms.TextBox textBox_Material;
        private System.Windows.Forms.Label label_MaterialGBName;
        private System.Windows.Forms.Label label_MaterialIndex;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaterialIndex;
        private System.Windows.Forms.Label label_MaterialRemark;
        private System.Windows.Forms.TextBox textBox_MaterialRemark;
        private System.Windows.Forms.Label label_MaterialDenominateWeldingStandard;
        private System.Windows.Forms.ComboBox comboBox_MaterialDenominateWeldingStandard;
        private System.Windows.Forms.TextBox textBox_MaterialGBName;
        private System.Windows.Forms.TextBox textBox_MaterialCCSGroupAb;
        private System.Windows.Forms.TextBox textBox_MaterialISOGroupAb;
        private System.Windows.Forms.Label label_MaterialCCSGroupAb;
        private System.Windows.Forms.Label label_MaterialISOGroupAb;
    }
}
