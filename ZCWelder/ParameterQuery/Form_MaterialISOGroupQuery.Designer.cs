namespace ZCWelder.ParameterQuery
{
    partial class Form_MaterialISOGroupQuery
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
            this.button_Query = new System.Windows.Forms.Button();
            this.textBox_MaterialISOGroupAb = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_Query = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.label_MaterialISOGroupAb = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_MaterialISOGroup = new System.Windows.Forms.Label();
            this.textBox_MaterialISOGroup = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Query)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Query
            // 
            this.button_Query.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_Query.Location = new System.Drawing.Point(544, 38);
            this.button_Query.Name = "button_Query";
            this.button_Query.Size = new System.Drawing.Size(75, 23);
            this.button_Query.TabIndex = 3;
            this.button_Query.Text = "查询";
            this.button_Query.UseVisualStyleBackColor = true;
            this.button_Query.Click += new System.EventHandler(this.button_Query_Click);
            // 
            // textBox_MaterialISOGroupAb
            // 
            this.textBox_MaterialISOGroupAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_MaterialISOGroupAb.Location = new System.Drawing.Point(105, 3);
            this.textBox_MaterialISOGroupAb.Name = "textBox_MaterialISOGroupAb";
            this.textBox_MaterialISOGroupAb.Size = new System.Drawing.Size(199, 21);
            this.textBox_MaterialISOGroupAb.TabIndex = 0;
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
            this.splitContainer2.Size = new System.Drawing.Size(671, 415);
            this.splitContainer2.SplitterDistance = 342;
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
            this.dataGridView_Query.Size = new System.Drawing.Size(671, 342);
            this.dataGridView_Query.TabIndex = 0;
            this.dataGridView_Query.DoubleClick += new System.EventHandler(this.button_OnOK_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(502, 23);
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
            // label_MaterialISOGroupAb
            // 
            this.label_MaterialISOGroupAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_MaterialISOGroupAb.AutoSize = true;
            this.label_MaterialISOGroupAb.Location = new System.Drawing.Point(4, 10);
            this.label_MaterialISOGroupAb.Name = "label_MaterialISOGroupAb";
            this.label_MaterialISOGroupAb.Size = new System.Drawing.Size(95, 12);
            this.label_MaterialISOGroupAb.TabIndex = 1;
            this.label_MaterialISOGroupAb.Text = "材料ISO组缩写：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel1.Controls.Add(this.button_Query, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_MaterialISOGroupAb, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_MaterialISOGroupAb, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_MaterialISOGroup, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_MaterialISOGroup, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 66);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_MaterialISOGroup
            // 
            this.label_MaterialISOGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_MaterialISOGroup.AutoSize = true;
            this.label_MaterialISOGroup.Location = new System.Drawing.Point(334, 10);
            this.label_MaterialISOGroup.Name = "label_MaterialISOGroup";
            this.label_MaterialISOGroup.Size = new System.Drawing.Size(71, 12);
            this.label_MaterialISOGroup.TabIndex = 1;
            this.label_MaterialISOGroup.Text = "材料ISO组：";
            // 
            // textBox_MaterialISOGroup
            // 
            this.textBox_MaterialISOGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_MaterialISOGroup.Location = new System.Drawing.Point(411, 3);
            this.textBox_MaterialISOGroup.Name = "textBox_MaterialISOGroup";
            this.textBox_MaterialISOGroup.Size = new System.Drawing.Size(208, 21);
            this.textBox_MaterialISOGroup.TabIndex = 4;
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
            this.splitContainer1.Size = new System.Drawing.Size(671, 507);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 20;
            // 
            // Form_MaterialISOGroupQuery
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(671, 507);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_MaterialISOGroupQuery";
            this.Text = "材料ISO组信息查询";
            this.Load += new System.EventHandler(this.Form_MaterialISOGroupQuery_Load);
            this.DoubleClick += new System.EventHandler(this.button_OnOK_Click);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Query)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Query;
        private System.Windows.Forms.TextBox textBox_MaterialISOGroupAb;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView_Query;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.Label label_MaterialISOGroupAb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_MaterialISOGroup;
        private System.Windows.Forms.TextBox textBox_MaterialISOGroup;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}