namespace ZCWelder.UserControlThird
{
    partial class UserControl_ShipandShipClassificationBase
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
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label_ShipClassificationAb = new System.Windows.Forms.Label();
            this.textBox_ShipClassificationAb = new System.Windows.Forms.TextBox();
            this.button_ShipClassificationAb = new System.Windows.Forms.Button();
            this.label_ShipClassification = new System.Windows.Forms.Label();
            this.textBox_ShipClassification = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label_ShipandShipClassificationRemark = new System.Windows.Forms.Label();
            this.textBox_ShipandShipClassificationRemark = new System.Windows.Forms.TextBox();
            this.label_ShipandShipClassificationIndex = new System.Windows.Forms.Label();
            this.numericUpDown_ShipandShipClassificationIndex = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label_ShipboardNo = new System.Windows.Forms.Label();
            this.textBox_ShipboardNo = new System.Windows.Forms.TextBox();
            this.button_ShipboardNo = new System.Windows.Forms.Button();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ShipandShipClassificationIndex)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.tableLayoutPanel5.Controls.Add(this.label_ShipClassificationAb, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBox_ShipClassificationAb, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.button_ShipClassificationAb, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.label_ShipClassification, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBox_ShipClassification, 1, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(8, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33112F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(409, 103);
            this.tableLayoutPanel5.TabIndex = 21;
            // 
            // label_ShipClassificationAb
            // 
            this.label_ShipClassificationAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ShipClassificationAb.AutoSize = true;
            this.label_ShipClassificationAb.Location = new System.Drawing.Point(14, 11);
            this.label_ShipClassificationAb.Name = "label_ShipClassificationAb";
            this.label_ShipClassificationAb.Size = new System.Drawing.Size(77, 12);
            this.label_ShipClassificationAb.TabIndex = 0;
            this.label_ShipClassificationAb.Text = "船级社缩写：";
            // 
            // textBox_ShipClassificationAb
            // 
            this.textBox_ShipClassificationAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ShipClassificationAb.Location = new System.Drawing.Point(97, 3);
            this.textBox_ShipClassificationAb.Name = "textBox_ShipClassificationAb";
            this.textBox_ShipClassificationAb.ReadOnly = true;
            this.textBox_ShipClassificationAb.Size = new System.Drawing.Size(309, 21);
            this.textBox_ShipClassificationAb.TabIndex = 1;
            // 
            // button_ShipClassificationAb
            // 
            this.button_ShipClassificationAb.Location = new System.Drawing.Point(97, 71);
            this.button_ShipClassificationAb.Name = "button_ShipClassificationAb";
            this.button_ShipClassificationAb.Size = new System.Drawing.Size(181, 23);
            this.button_ShipClassificationAb.TabIndex = 3;
            this.button_ShipClassificationAb.Text = "选择船级社";
            this.button_ShipClassificationAb.UseVisualStyleBackColor = true;
            this.button_ShipClassificationAb.Click += new System.EventHandler(this.button_ShipClassificationAb_Click);
            // 
            // label_ShipClassification
            // 
            this.label_ShipClassification.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ShipClassification.AutoSize = true;
            this.label_ShipClassification.Location = new System.Drawing.Point(38, 45);
            this.label_ShipClassification.Name = "label_ShipClassification";
            this.label_ShipClassification.Size = new System.Drawing.Size(53, 12);
            this.label_ShipClassification.TabIndex = 0;
            this.label_ShipClassification.Text = "船级社：";
            // 
            // textBox_ShipClassification
            // 
            this.textBox_ShipClassification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ShipClassification.Location = new System.Drawing.Point(97, 37);
            this.textBox_ShipClassification.Name = "textBox_ShipClassification";
            this.textBox_ShipClassification.ReadOnly = true;
            this.textBox_ShipClassification.Size = new System.Drawing.Size(309, 21);
            this.textBox_ShipClassification.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.tableLayoutPanel7.Controls.Add(this.label_ShipandShipClassificationRemark, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.textBox_ShipandShipClassificationRemark, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.label_ShipandShipClassificationIndex, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.numericUpDown_ShipandShipClassificationIndex, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(8, 213);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(409, 71);
            this.tableLayoutPanel7.TabIndex = 24;
            // 
            // label_ShipandShipClassificationRemark
            // 
            this.label_ShipandShipClassificationRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ShipandShipClassificationRemark.AutoSize = true;
            this.label_ShipandShipClassificationRemark.Location = new System.Drawing.Point(50, 47);
            this.label_ShipandShipClassificationRemark.Name = "label_ShipandShipClassificationRemark";
            this.label_ShipandShipClassificationRemark.Size = new System.Drawing.Size(41, 12);
            this.label_ShipandShipClassificationRemark.TabIndex = 0;
            this.label_ShipandShipClassificationRemark.Text = "备注：";
            // 
            // textBox_ShipandShipClassificationRemark
            // 
            this.textBox_ShipandShipClassificationRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ShipandShipClassificationRemark.Location = new System.Drawing.Point(97, 38);
            this.textBox_ShipandShipClassificationRemark.Name = "textBox_ShipandShipClassificationRemark";
            this.textBox_ShipandShipClassificationRemark.Size = new System.Drawing.Size(309, 21);
            this.textBox_ShipandShipClassificationRemark.TabIndex = 1;
            // 
            // label_ShipandShipClassificationIndex
            // 
            this.label_ShipandShipClassificationIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ShipandShipClassificationIndex.AutoSize = true;
            this.label_ShipandShipClassificationIndex.Location = new System.Drawing.Point(26, 11);
            this.label_ShipandShipClassificationIndex.Name = "label_ShipandShipClassificationIndex";
            this.label_ShipandShipClassificationIndex.Size = new System.Drawing.Size(65, 12);
            this.label_ShipandShipClassificationIndex.TabIndex = 0;
            this.label_ShipandShipClassificationIndex.Text = "排序索引：";
            // 
            // numericUpDown_ShipandShipClassificationIndex
            // 
            this.numericUpDown_ShipandShipClassificationIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_ShipandShipClassificationIndex.Location = new System.Drawing.Point(97, 3);
            this.numericUpDown_ShipandShipClassificationIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_ShipandShipClassificationIndex.Name = "numericUpDown_ShipandShipClassificationIndex";
            this.numericUpDown_ShipandShipClassificationIndex.Size = new System.Drawing.Size(309, 21);
            this.numericUpDown_ShipandShipClassificationIndex.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 314F));
            this.tableLayoutPanel6.Controls.Add(this.label_ShipboardNo, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.textBox_ShipboardNo, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.button_ShipboardNo, 1, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(8, 123);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(409, 72);
            this.tableLayoutPanel6.TabIndex = 25;
            // 
            // label_ShipboardNo
            // 
            this.label_ShipboardNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ShipboardNo.AutoSize = true;
            this.label_ShipboardNo.Location = new System.Drawing.Point(27, 12);
            this.label_ShipboardNo.Name = "label_ShipboardNo";
            this.label_ShipboardNo.Size = new System.Drawing.Size(65, 12);
            this.label_ShipboardNo.TabIndex = 0;
            this.label_ShipboardNo.Text = "船舶系列：";
            // 
            // textBox_ShipboardNo
            // 
            this.textBox_ShipboardNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ShipboardNo.Location = new System.Drawing.Point(98, 3);
            this.textBox_ShipboardNo.Name = "textBox_ShipboardNo";
            this.textBox_ShipboardNo.ReadOnly = true;
            this.textBox_ShipboardNo.Size = new System.Drawing.Size(308, 21);
            this.textBox_ShipboardNo.TabIndex = 1;
            // 
            // button_ShipboardNo
            // 
            this.button_ShipboardNo.Location = new System.Drawing.Point(98, 39);
            this.button_ShipboardNo.Name = "button_ShipboardNo";
            this.button_ShipboardNo.Size = new System.Drawing.Size(180, 23);
            this.button_ShipboardNo.TabIndex = 3;
            this.button_ShipboardNo.Text = "选择船舶系列";
            this.button_ShipboardNo.UseVisualStyleBackColor = true;
            this.button_ShipboardNo.Click += new System.EventHandler(this.button_ShipboardNo_Click);
            // 
            // UserControl_ShipandShipClassificationBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.tableLayoutPanel7);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Name = "UserControl_ShipandShipClassificationBase";
            this.Size = new System.Drawing.Size(424, 291);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ShipandShipClassificationIndex)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label_ShipClassificationAb;
        private System.Windows.Forms.TextBox textBox_ShipClassificationAb;
        private System.Windows.Forms.Button button_ShipClassificationAb;
        private System.Windows.Forms.Label label_ShipClassification;
        private System.Windows.Forms.TextBox textBox_ShipClassification;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label_ShipandShipClassificationRemark;
        private System.Windows.Forms.TextBox textBox_ShipandShipClassificationRemark;
        private System.Windows.Forms.Label label_ShipandShipClassificationIndex;
        private System.Windows.Forms.NumericUpDown numericUpDown_ShipandShipClassificationIndex;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label_ShipboardNo;
        private System.Windows.Forms.TextBox textBox_ShipboardNo;
        private System.Windows.Forms.Button button_ShipboardNo;

    }
}
