namespace ZCWelder.ParameterQuery
{
    partial class Form_EmployerQuery
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Query = new System.Windows.Forms.Button();
            this.textBox_EmployerHPID = new System.Windows.Forms.TextBox();
            this.label_EmployerGroup = new System.Windows.Forms.Label();
            this.comboBox_EmployerGroup = new System.Windows.Forms.ComboBox();
            this.label_EmployerHPID = new System.Windows.Forms.Label();
            this.label_Employer = new System.Windows.Forms.Label();
            this.textBox_Employer = new System.Windows.Forms.TextBox();
            this.dataGridView_Employer = new System.Windows.Forms.DataGridView();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employer)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Employer);
            this.splitContainer1.Size = new System.Drawing.Size(677, 444);
            this.splitContainer1.SplitterDistance = 103;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.Controls.Add(this.button_Query, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_EmployerHPID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_EmployerGroup, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_EmployerGroup, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_EmployerHPID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_Employer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Employer, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(33, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(614, 66);
            this.tableLayoutPanel1.TabIndex = 0;
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
            // textBox_EmployerHPID
            // 
            this.textBox_EmployerHPID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_EmployerHPID.Location = new System.Drawing.Point(92, 3);
            this.textBox_EmployerHPID.Name = "textBox_EmployerHPID";
            this.textBox_EmployerHPID.Size = new System.Drawing.Size(220, 21);
            this.textBox_EmployerHPID.TabIndex = 0;
            // 
            // label_EmployerGroup
            // 
            this.label_EmployerGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_EmployerGroup.AutoSize = true;
            this.label_EmployerGroup.Location = new System.Drawing.Point(328, 10);
            this.label_EmployerGroup.Name = "label_EmployerGroup";
            this.label_EmployerGroup.Size = new System.Drawing.Size(53, 12);
            this.label_EmployerGroup.TabIndex = 3;
            this.label_EmployerGroup.Text = "公司组：";
            // 
            // comboBox_EmployerGroup
            // 
            this.comboBox_EmployerGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_EmployerGroup.FormattingEnabled = true;
            this.comboBox_EmployerGroup.Location = new System.Drawing.Point(387, 3);
            this.comboBox_EmployerGroup.Name = "comboBox_EmployerGroup";
            this.comboBox_EmployerGroup.Size = new System.Drawing.Size(224, 20);
            this.comboBox_EmployerGroup.TabIndex = 2;
            // 
            // label_EmployerHPID
            // 
            this.label_EmployerHPID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_EmployerHPID.AutoSize = true;
            this.label_EmployerHPID.Location = new System.Drawing.Point(45, 10);
            this.label_EmployerHPID.Name = "label_EmployerHPID";
            this.label_EmployerHPID.Size = new System.Drawing.Size(41, 12);
            this.label_EmployerHPID.TabIndex = 1;
            this.label_EmployerHPID.Text = "编号：";
            // 
            // label_Employer
            // 
            this.label_Employer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Employer.AutoSize = true;
            this.label_Employer.Location = new System.Drawing.Point(21, 43);
            this.label_Employer.Name = "label_Employer";
            this.label_Employer.Size = new System.Drawing.Size(65, 12);
            this.label_Employer.TabIndex = 1;
            this.label_Employer.Text = "公司名称：";
            // 
            // textBox_Employer
            // 
            this.textBox_Employer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Employer.Location = new System.Drawing.Point(92, 36);
            this.textBox_Employer.Name = "textBox_Employer";
            this.textBox_Employer.Size = new System.Drawing.Size(220, 21);
            this.textBox_Employer.TabIndex = 1;
            // 
            // dataGridView_Employer
            // 
            this.dataGridView_Employer.AllowUserToAddRows = false;
            this.dataGridView_Employer.AllowUserToDeleteRows = false;
            this.dataGridView_Employer.AllowUserToOrderColumns = true;
            this.dataGridView_Employer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Employer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Employer.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Employer.Name = "dataGridView_Employer";
            this.dataGridView_Employer.ReadOnly = true;
            this.dataGridView_Employer.RowTemplate.Height = 23;
            this.dataGridView_Employer.Size = new System.Drawing.Size(677, 337);
            this.dataGridView_Employer.TabIndex = 0;
            this.dataGridView_Employer.DoubleClick += new System.EventHandler(this.button_OnOK_Click);
            // 
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(31, 466);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 10;
            this.label_ErrMessage.Text = "错误信息：";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(500, 458);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel2.TabIndex = 9;
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
            // Form_EmployerQuery
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(677, 501);
            this.Controls.Add(this.label_ErrMessage);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_EmployerQuery";
            this.Text = "公司查询";
            this.Load += new System.EventHandler(this.Form_EmployerQuery_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employer)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_Query;
        private System.Windows.Forms.Label label_EmployerHPID;
        private System.Windows.Forms.TextBox textBox_EmployerHPID;
        private System.Windows.Forms.Label label_EmployerGroup;
        private System.Windows.Forms.ComboBox comboBox_EmployerGroup;
        private System.Windows.Forms.DataGridView dataGridView_Employer;
        private System.Windows.Forms.Label label_Employer;
        private System.Windows.Forms.TextBox textBox_Employer;
    }
}