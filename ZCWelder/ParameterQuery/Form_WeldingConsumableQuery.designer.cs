namespace ZCWelder.ParameterQuery
{
    partial class Form_WeldingConsumableQuery
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
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.dataGridView_Query = new System.Windows.Forms.DataGridView();
            this.button_Query = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_WeldingConsumable = new System.Windows.Forms.TextBox();
            this.label_WeldingConsumable = new System.Windows.Forms.Label();
            this.textBox_WeldingConsumableGBName = new System.Windows.Forms.TextBox();
            this.label_WeldingConsumableGBName = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Query)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(18, 507);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 19;
            this.label_ErrMessage.Text = "错误信息：";
            // 
            // dataGridView_Query
            // 
            this.dataGridView_Query.AllowUserToAddRows = false;
            this.dataGridView_Query.AllowUserToDeleteRows = false;
            this.dataGridView_Query.AllowUserToOrderColumns = true;
            this.dataGridView_Query.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Query.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Query.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Query.Name = "dataGridView_Query";
            this.dataGridView_Query.ReadOnly = true;
            this.dataGridView_Query.RowTemplate.Height = 23;
            this.dataGridView_Query.Size = new System.Drawing.Size(667, 390);
            this.dataGridView_Query.TabIndex = 0;
            this.dataGridView_Query.DoubleClick += new System.EventHandler(this.button_OnOK_Click);
            // 
            // button_Query
            // 
            this.button_Query.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_Query.Location = new System.Drawing.Point(536, 38);
            this.button_Query.Name = "button_Query";
            this.button_Query.Size = new System.Drawing.Size(75, 23);
            this.button_Query.TabIndex = 3;
            this.button_Query.Text = "查询";
            this.button_Query.UseVisualStyleBackColor = true;
            this.button_Query.Click += new System.EventHandler(this.button_Query_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel1.Controls.Add(this.button_Query, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingConsumable, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingConsumable, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WeldingConsumableGBName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_WeldingConsumableGBName, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(614, 66);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox_WeldingConsumable
            // 
            this.textBox_WeldingConsumable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingConsumable.Location = new System.Drawing.Point(92, 3);
            this.textBox_WeldingConsumable.Name = "textBox_WeldingConsumable";
            this.textBox_WeldingConsumable.Size = new System.Drawing.Size(202, 21);
            this.textBox_WeldingConsumable.TabIndex = 0;
            // 
            // label_WeldingConsumable
            // 
            this.label_WeldingConsumable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingConsumable.AutoSize = true;
            this.label_WeldingConsumable.Location = new System.Drawing.Point(21, 10);
            this.label_WeldingConsumable.Name = "label_WeldingConsumable";
            this.label_WeldingConsumable.Size = new System.Drawing.Size(65, 12);
            this.label_WeldingConsumable.TabIndex = 1;
            this.label_WeldingConsumable.Text = "焊接材料：";
            // 
            // textBox_WeldingConsumableGBName
            // 
            this.textBox_WeldingConsumableGBName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WeldingConsumableGBName.Location = new System.Drawing.Point(403, 3);
            this.textBox_WeldingConsumableGBName.Name = "textBox_WeldingConsumableGBName";
            this.textBox_WeldingConsumableGBName.Size = new System.Drawing.Size(208, 21);
            this.textBox_WeldingConsumableGBName.TabIndex = 1;
            // 
            // label_WeldingConsumableGBName
            // 
            this.label_WeldingConsumableGBName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WeldingConsumableGBName.AutoSize = true;
            this.label_WeldingConsumableGBName.Location = new System.Drawing.Point(308, 10);
            this.label_WeldingConsumableGBName.Name = "label_WeldingConsumableGBName";
            this.label_WeldingConsumableGBName.Size = new System.Drawing.Size(89, 12);
            this.label_WeldingConsumableGBName.TabIndex = 1;
            this.label_WeldingConsumableGBName.Text = "GB焊接材料名：";
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(78, 3);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(69, 23);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Query);
            this.splitContainer1.Size = new System.Drawing.Size(667, 482);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 17;
            // 
            // button_OnOK
            // 
            this.button_OnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OnOK.Location = new System.Drawing.Point(3, 3);
            this.button_OnOK.Name = "button_OnOK";
            this.button_OnOK.Size = new System.Drawing.Size(69, 23);
            this.button_OnOK.TabIndex = 0;
            this.button_OnOK.Text = "确定";
            this.button_OnOK.UseVisualStyleBackColor = true;
            this.button_OnOK.Click += new System.EventHandler(this.button_OnOK_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(497, 499);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // Form_WeldingConsumableQuery
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(667, 542);
            this.Controls.Add(this.label_ErrMessage);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Form_WeldingConsumableQuery";
            this.Text = "焊接材料查询";
            this.Load += new System.EventHandler(this.Form_WeldingConsumableQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Query)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.DataGridView dataGridView_Query;
        private System.Windows.Forms.Button button_Query;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_WeldingConsumable;
        private System.Windows.Forms.Label label_WeldingConsumable;
        private System.Windows.Forms.TextBox textBox_WeldingConsumableGBName;
        private System.Windows.Forms.Label label_WeldingConsumableGBName;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}