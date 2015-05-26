namespace ZCWelder.SignUp
{
    partial class Form_KindofEmployerWelder_Query
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.TextBox_IdentificationCard = new System.Windows.Forms.TextBox();
            this.textBox_WelderName = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_Query = new System.Windows.Forms.DataGridView();
            this.button_QueryFilter = new System.Windows.Forms.Button();
            this.checkBox_CheckAll = new System.Windows.Forms.CheckBox();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.TextBox_WorkerID = new System.Windows.Forms.TextBox();
            this.label_WelderName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_WorkerID = new System.Windows.Forms.Label();
            this.label_IdentificationCard = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Query = new System.Windows.Forms.Button();
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(504, 26);
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
            // TextBox_IdentificationCard
            // 
            this.TextBox_IdentificationCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_IdentificationCard.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TextBox_IdentificationCard.Location = new System.Drawing.Point(92, 36);
            this.TextBox_IdentificationCard.Name = "TextBox_IdentificationCard";
            this.TextBox_IdentificationCard.Size = new System.Drawing.Size(200, 21);
            this.TextBox_IdentificationCard.TabIndex = 1;
            // 
            // textBox_WelderName
            // 
            this.textBox_WelderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WelderName.Location = new System.Drawing.Point(92, 3);
            this.textBox_WelderName.Name = "textBox_WelderName";
            this.textBox_WelderName.Size = new System.Drawing.Size(200, 21);
            this.textBox_WelderName.TabIndex = 0;
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
            this.splitContainer2.Panel2.Controls.Add(this.button_QueryFilter);
            this.splitContainer2.Panel2.Controls.Add(this.checkBox_CheckAll);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel2.Controls.Add(this.label_ErrMessage);
            this.splitContainer2.Size = new System.Drawing.Size(673, 430);
            this.splitContainer2.SplitterDistance = 354;
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
            this.dataGridView_Query.Size = new System.Drawing.Size(673, 354);
            this.dataGridView_Query.TabIndex = 0;
            this.dataGridView_Query.DoubleClick += new System.EventHandler(this.button_OnOK_Click);
            // 
            // button_QueryFilter
            // 
            this.button_QueryFilter.Location = new System.Drawing.Point(89, 9);
            this.button_QueryFilter.Name = "button_QueryFilter";
            this.button_QueryFilter.Size = new System.Drawing.Size(75, 23);
            this.button_QueryFilter.TabIndex = 25;
            this.button_QueryFilter.Text = "高级查询";
            this.button_QueryFilter.UseVisualStyleBackColor = true;
            this.button_QueryFilter.Click += new System.EventHandler(this.button_QueryFilter_Click);
            // 
            // checkBox_CheckAll
            // 
            this.checkBox_CheckAll.AutoSize = true;
            this.checkBox_CheckAll.Location = new System.Drawing.Point(25, 13);
            this.checkBox_CheckAll.Name = "checkBox_CheckAll";
            this.checkBox_CheckAll.Size = new System.Drawing.Size(48, 16);
            this.checkBox_CheckAll.TabIndex = 24;
            this.checkBox_CheckAll.Text = "全选";
            this.checkBox_CheckAll.UseVisualStyleBackColor = true;
            this.checkBox_CheckAll.CheckedChanged += new System.EventHandler(this.checkBox_CheckAll_CheckedChanged);
            // 
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(23, 41);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 0;
            this.label_ErrMessage.Text = "错误信息：";
            // 
            // TextBox_WorkerID
            // 
            this.TextBox_WorkerID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WorkerID.Location = new System.Drawing.Point(353, 3);
            this.TextBox_WorkerID.Name = "TextBox_WorkerID";
            this.TextBox_WorkerID.Size = new System.Drawing.Size(194, 21);
            this.TextBox_WorkerID.TabIndex = 2;
            // 
            // label_WelderName
            // 
            this.label_WelderName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WelderName.AutoSize = true;
            this.label_WelderName.Location = new System.Drawing.Point(45, 10);
            this.label_WelderName.Name = "label_WelderName";
            this.label_WelderName.Size = new System.Drawing.Size(41, 12);
            this.label_WelderName.TabIndex = 1;
            this.label_WelderName.Text = "姓名：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.Controls.Add(this.TextBox_WorkerID, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_IdentificationCard, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WelderName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_WelderName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_WorkerID, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_IdentificationCard, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Add, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Query, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(629, 66);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_WorkerID
            // 
            this.label_WorkerID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WorkerID.AutoSize = true;
            this.label_WorkerID.Location = new System.Drawing.Point(306, 10);
            this.label_WorkerID.Name = "label_WorkerID";
            this.label_WorkerID.Size = new System.Drawing.Size(41, 12);
            this.label_WorkerID.TabIndex = 1;
            this.label_WorkerID.Text = "工号：";
            // 
            // label_IdentificationCard
            // 
            this.label_IdentificationCard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_IdentificationCard.AutoSize = true;
            this.label_IdentificationCard.Location = new System.Drawing.Point(9, 43);
            this.label_IdentificationCard.Name = "label_IdentificationCard";
            this.label_IdentificationCard.Size = new System.Drawing.Size(77, 12);
            this.label_IdentificationCard.TabIndex = 1;
            this.label_IdentificationCard.Text = "身份证号码：";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(553, 36);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(73, 27);
            this.button_Add.TabIndex = 4;
            this.button_Add.Text = "添加";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Query
            // 
            this.button_Query.Location = new System.Drawing.Point(553, 3);
            this.button_Query.Name = "button_Query";
            this.button_Query.Size = new System.Drawing.Size(73, 27);
            this.button_Query.TabIndex = 3;
            this.button_Query.Text = "查询";
            this.button_Query.UseVisualStyleBackColor = true;
            this.button_Query.Click += new System.EventHandler(this.button_Query_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(673, 520);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.TabIndex = 1;
            // 
            // Form_KindofEmployerWelder_Query
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(673, 520);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_KindofEmployerWelder_Query";
            this.Text = "焊工信息查询";
            this.Load += new System.EventHandler(this.Form_KindofEmployerWelder_Query_Load);
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

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        internal System.Windows.Forms.TextBox TextBox_IdentificationCard;
        private System.Windows.Forms.TextBox textBox_WelderName;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView_Query;
        private System.Windows.Forms.Label label_ErrMessage;
        internal System.Windows.Forms.TextBox TextBox_WorkerID;
        private System.Windows.Forms.Label label_WelderName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_WorkerID;
        private System.Windows.Forms.Label label_IdentificationCard;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Query;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_QueryFilter;
        private System.Windows.Forms.CheckBox checkBox_CheckAll;
    }
}