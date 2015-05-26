namespace ZCWelder.Exam
{
    partial class Form_GXTheoryIssue_Query
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
            this.label_KindofEmployer = new System.Windows.Forms.Label();
            this.label_ShipClassificationAb = new System.Windows.Forms.Label();
            this.comboBox_KindofEmployer = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.textBox_IssueNo = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_Query = new System.Windows.Forms.DataGridView();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.label_IssueNo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_ShipClassificationAb = new System.Windows.Forms.ComboBox();
            this.button_Query = new System.Windows.Forms.Button();
            this.comboBox_ShipboardNo = new System.Windows.Forms.ComboBox();
            this.label_ShipboardNo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Query)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_KindofEmployer
            // 
            this.label_KindofEmployer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_KindofEmployer.AutoSize = true;
            this.label_KindofEmployer.Location = new System.Drawing.Point(8, 43);
            this.label_KindofEmployer.Name = "label_KindofEmployer";
            this.label_KindofEmployer.Size = new System.Drawing.Size(65, 12);
            this.label_KindofEmployer.TabIndex = 37;
            this.label_KindofEmployer.Text = "报考单位：";
            // 
            // label_ShipClassificationAb
            // 
            this.label_ShipClassificationAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ShipClassificationAb.AutoSize = true;
            this.label_ShipClassificationAb.Location = new System.Drawing.Point(271, 10);
            this.label_ShipClassificationAb.Name = "label_ShipClassificationAb";
            this.label_ShipClassificationAb.Size = new System.Drawing.Size(53, 12);
            this.label_ShipClassificationAb.TabIndex = 38;
            this.label_ShipClassificationAb.Text = "船级社：";
            // 
            // comboBox_KindofEmployer
            // 
            this.comboBox_KindofEmployer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_KindofEmployer.DropDownWidth = 200;
            this.comboBox_KindofEmployer.FormattingEnabled = true;
            this.comboBox_KindofEmployer.Location = new System.Drawing.Point(79, 36);
            this.comboBox_KindofEmployer.Name = "comboBox_KindofEmployer";
            this.comboBox_KindofEmployer.Size = new System.Drawing.Size(180, 20);
            this.comboBox_KindofEmployer.TabIndex = 36;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(498, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel2.TabIndex = 18;
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
            // textBox_IssueNo
            // 
            this.textBox_IssueNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_IssueNo.Location = new System.Drawing.Point(79, 3);
            this.textBox_IssueNo.Name = "textBox_IssueNo";
            this.textBox_IssueNo.Size = new System.Drawing.Size(180, 21);
            this.textBox_IssueNo.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView_Query);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel2.Controls.Add(this.label_ErrMessage);
            this.splitContainer2.Size = new System.Drawing.Size(667, 445);
            this.splitContainer2.SplitterDistance = 372;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGridView_Query
            // 
            this.dataGridView_Query.AllowUserToAddRows = false;
            this.dataGridView_Query.AllowUserToDeleteRows = false;
            this.dataGridView_Query.AllowUserToOrderColumns = true;
            this.dataGridView_Query.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Query.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Query.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Query.Name = "dataGridView_Query";
            this.dataGridView_Query.ReadOnly = true;
            this.dataGridView_Query.RowTemplate.Height = 23;
            this.dataGridView_Query.Size = new System.Drawing.Size(667, 372);
            this.dataGridView_Query.TabIndex = 0;
            this.dataGridView_Query.DoubleClick += new System.EventHandler(this.button_OnOK_Click);
            // 
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(23, 17);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 19;
            this.label_ErrMessage.Text = "错误信息：";
            // 
            // label_IssueNo
            // 
            this.label_IssueNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_IssueNo.AutoSize = true;
            this.label_IssueNo.Location = new System.Drawing.Point(8, 10);
            this.label_IssueNo.Name = "label_IssueNo";
            this.label_IssueNo.Size = new System.Drawing.Size(65, 12);
            this.label_IssueNo.TabIndex = 1;
            this.label_IssueNo.Text = "班级编号：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Controls.Add(this.label_KindofEmployer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_ShipClassificationAb, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_KindofEmployer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_IssueNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_IssueNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_ShipClassificationAb, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Query, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_ShipboardNo, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_ShipboardNo, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(615, 66);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBox_ShipClassificationAb
            // 
            this.comboBox_ShipClassificationAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_ShipClassificationAb.DropDownWidth = 200;
            this.comboBox_ShipClassificationAb.FormattingEnabled = true;
            this.comboBox_ShipClassificationAb.Location = new System.Drawing.Point(330, 3);
            this.comboBox_ShipClassificationAb.Name = "comboBox_ShipClassificationAb";
            this.comboBox_ShipClassificationAb.Size = new System.Drawing.Size(208, 20);
            this.comboBox_ShipClassificationAb.TabIndex = 36;
            // 
            // button_Query
            // 
            this.button_Query.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_Query.Location = new System.Drawing.Point(544, 38);
            this.button_Query.Name = "button_Query";
            this.button_Query.Size = new System.Drawing.Size(68, 23);
            this.button_Query.TabIndex = 3;
            this.button_Query.Text = "查询";
            this.button_Query.UseVisualStyleBackColor = true;
            this.button_Query.Click += new System.EventHandler(this.button_Query_Click);
            // 
            // comboBox_ShipboardNo
            // 
            this.comboBox_ShipboardNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_ShipboardNo.DropDownWidth = 200;
            this.comboBox_ShipboardNo.FormattingEnabled = true;
            this.comboBox_ShipboardNo.Location = new System.Drawing.Point(330, 36);
            this.comboBox_ShipboardNo.Name = "comboBox_ShipboardNo";
            this.comboBox_ShipboardNo.Size = new System.Drawing.Size(208, 20);
            this.comboBox_ShipboardNo.TabIndex = 37;
            // 
            // label_ShipboardNo
            // 
            this.label_ShipboardNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ShipboardNo.AutoSize = true;
            this.label_ShipboardNo.Location = new System.Drawing.Point(283, 43);
            this.label_ShipboardNo.Name = "label_ShipboardNo";
            this.label_ShipboardNo.Size = new System.Drawing.Size(41, 12);
            this.label_ShipboardNo.TabIndex = 39;
            this.label_ShipboardNo.Text = "船号：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(667, 537);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 20;
            // 
            // Form_GXTheoryIssue_Query
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(667, 537);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_GXTheoryIssue_Query";
            this.Text = "理论班级信息查询";
            this.Load += new System.EventHandler(this.Form_GXTheoryIssue_Query_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Query)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label_KindofEmployer;
        internal System.Windows.Forms.Label label_ShipClassificationAb;
        internal System.Windows.Forms.ComboBox comboBox_KindofEmployer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TextBox textBox_IssueNo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView_Query;
        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.Label label_IssueNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.ComboBox comboBox_ShipClassificationAb;
        private System.Windows.Forms.Button button_Query;
        internal System.Windows.Forms.ComboBox comboBox_ShipboardNo;
        internal System.Windows.Forms.Label label_ShipboardNo;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}