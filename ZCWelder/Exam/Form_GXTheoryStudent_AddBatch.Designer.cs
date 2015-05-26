namespace ZCWelder.Exam
{
    partial class Form_GXTheoryStudent_AddBatch
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
            this.components = new System.ComponentModel.Container();
            this.button_WelderAdd = new System.Windows.Forms.Button();
            this.MaskedTextBox_ExaminingNo = new System.Windows.Forms.MaskedTextBox();
            this.Label_ExaminingNo = new System.Windows.Forms.Label();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Data = new System.Windows.Forms.Label();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Label_IssueNo = new System.Windows.Forms.Label();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.TextBox_IssueNo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_WelderAdd
            // 
            this.button_WelderAdd.Location = new System.Drawing.Point(646, 3);
            this.button_WelderAdd.Name = "button_WelderAdd";
            this.button_WelderAdd.Size = new System.Drawing.Size(89, 21);
            this.button_WelderAdd.TabIndex = 482;
            this.button_WelderAdd.Text = "添加学员";
            this.button_WelderAdd.UseVisualStyleBackColor = true;
            this.button_WelderAdd.Click += new System.EventHandler(this.button_WelderAdd_Click);
            // 
            // MaskedTextBox_ExaminingNo
            // 
            this.MaskedTextBox_ExaminingNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_ExaminingNo.Location = new System.Drawing.Point(534, 3);
            this.MaskedTextBox_ExaminingNo.Name = "MaskedTextBox_ExaminingNo";
            this.MaskedTextBox_ExaminingNo.ReadOnly = true;
            this.MaskedTextBox_ExaminingNo.Size = new System.Drawing.Size(106, 21);
            this.MaskedTextBox_ExaminingNo.TabIndex = 483;
            // 
            // Label_ExaminingNo
            // 
            this.Label_ExaminingNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_ExaminingNo.AutoSize = true;
            this.Label_ExaminingNo.Location = new System.Drawing.Point(475, 7);
            this.Label_ExaminingNo.Name = "Label_ExaminingNo";
            this.Label_ExaminingNo.Size = new System.Drawing.Size(53, 12);
            this.Label_ExaminingNo.TabIndex = 484;
            this.Label_ExaminingNo.Text = "考编号：";
            // 
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(18, 356);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 490;
            this.label_ErrMessage.Text = "错误信息：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(607, 356);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel1.TabIndex = 489;
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
            // label_Data
            // 
            this.label_Data.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Data.AutoSize = true;
            this.label_Data.Location = new System.Drawing.Point(3, 7);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(41, 12);
            this.label_Data.TabIndex = 3;
            this.label_Data.Text = "数据：";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(123, 6);
            // 
            // toolStripMenuItem_DataGridViewRowFrozenThisColumn
            // 
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Name = "toolStripMenuItem_DataGridViewRowFrozenThisColumn";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(123, 6);
            // 
            // toolStripMenuItem_DataGridViewRowExport
            // 
            this.toolStripMenuItem_DataGridViewRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowExportToExcel});
            this.toolStripMenuItem_DataGridViewRowExport.Name = "toolStripMenuItem_DataGridViewRowExport";
            this.toolStripMenuItem_DataGridViewRowExport.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowExport.Text = "导出";
            // 
            // toolStripMenuItem_DataGridViewRowExportToExcel
            // 
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Name = "toolStripMenuItem_DataGridViewRowExportToExcel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // toolStripMenuItem_DataGridViewRowDelete
            // 
            this.toolStripMenuItem_DataGridViewRowDelete.Name = "toolStripMenuItem_DataGridViewRowDelete";
            this.toolStripMenuItem_DataGridViewRowDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowDelete.Text = "删除";
            this.toolStripMenuItem_DataGridViewRowDelete.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowDelete_Click);
            // 
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowDelete,
            this.toolStripSeparator2,
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(127, 82);
            // 
            // Label_IssueNo
            // 
            this.Label_IssueNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IssueNo.AutoSize = true;
            this.Label_IssueNo.Location = new System.Drawing.Point(292, 7);
            this.Label_IssueNo.Name = "Label_IssueNo";
            this.Label_IssueNo.Size = new System.Drawing.Size(65, 12);
            this.Label_IssueNo.TabIndex = 478;
            this.Label_IssueNo.Text = "班级编号：";
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.AllowUserToAddRows = false;
            this.dataGridView_Data.AllowUserToDeleteRows = false;
            this.dataGridView_Data.AllowUserToOrderColumns = true;
            this.dataGridView_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.Location = new System.Drawing.Point(20, 36);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.ReadOnly = true;
            this.dataGridView_Data.RowTemplate.Height = 23;
            this.dataGridView_Data.Size = new System.Drawing.Size(741, 302);
            this.dataGridView_Data.TabIndex = 486;
            this.dataGridView_Data.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 283F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel4.Controls.Add(this.button_WelderAdd, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.MaskedTextBox_ExaminingNo, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.Label_ExaminingNo, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label_Data, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Label_IssueNo, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.TextBox_IssueNo, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(20, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(741, 27);
            this.tableLayoutPanel4.TabIndex = 491;
            // 
            // TextBox_IssueNo
            // 
            this.TextBox_IssueNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_IssueNo.Location = new System.Drawing.Point(363, 3);
            this.TextBox_IssueNo.Name = "TextBox_IssueNo";
            this.TextBox_IssueNo.ReadOnly = true;
            this.TextBox_IssueNo.Size = new System.Drawing.Size(104, 21);
            this.TextBox_IssueNo.TabIndex = 1;
            // 
            // Form_GXTheoryStudent_AddBatch
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(779, 390);
            this.Controls.Add(this.label_ErrMessage);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView_Data);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "Form_GXTheoryStudent_AddBatch";
            this.Text = "批量添加学员";
            this.Load += new System.EventHandler(this.Form_GXTheoryStudent_AddBatch_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_WelderAdd;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_ExaminingNo;
        internal System.Windows.Forms.Label Label_ExaminingNo;
        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowFrozenThisColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridViewRow;
        internal System.Windows.Forms.Label Label_IssueNo;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        internal System.Windows.Forms.TextBox TextBox_IssueNo;
    }
}