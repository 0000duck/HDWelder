namespace ZCWelder.Person
{
    partial class Form_WelderBelong_ImportFromExcel
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_Employer = new System.Windows.Forms.Label();
            this.Label_Department = new System.Windows.Forms.Label();
            this.Label_WorkPlace = new System.Windows.Forms.Label();
            this.TextBox_Employer = new System.Windows.Forms.TextBox();
            this.TextBox_Department = new System.Windows.Forms.TextBox();
            this.TextBox_WorkPlace = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.checkBox_DeleteWelderBelongAll = new System.Windows.Forms.CheckBox();
            this.label_Data = new System.Windows.Forms.Label();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.toolStripMenuItem_DataGridViewRowExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DataGridViewRowExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DataGridViewRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TableLayoutPanel4.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStrip_DataGridViewRow.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.TableLayoutPanel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(628, 526);
            this.splitContainer1.SplitterDistance = 116;
            this.splitContainer1.TabIndex = 1;
            // 
            // TableLayoutPanel4
            // 
            this.TableLayoutPanel4.ColumnCount = 2;
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel4.Controls.Add(this.Label_Employer, 0, 0);
            this.TableLayoutPanel4.Controls.Add(this.Label_Department, 0, 1);
            this.TableLayoutPanel4.Controls.Add(this.Label_WorkPlace, 0, 2);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_Employer, 1, 0);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_Department, 1, 1);
            this.TableLayoutPanel4.Controls.Add(this.TextBox_WorkPlace, 1, 2);
            this.TableLayoutPanel4.Location = new System.Drawing.Point(12, 12);
            this.TableLayoutPanel4.Name = "TableLayoutPanel4";
            this.TableLayoutPanel4.RowCount = 3;
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel4.Size = new System.Drawing.Size(510, 99);
            this.TableLayoutPanel4.TabIndex = 1;
            // 
            // Label_Employer
            // 
            this.Label_Employer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Employer.AutoSize = true;
            this.Label_Employer.Location = new System.Drawing.Point(22, 10);
            this.Label_Employer.Name = "Label_Employer";
            this.Label_Employer.Size = new System.Drawing.Size(41, 12);
            this.Label_Employer.TabIndex = 126;
            this.Label_Employer.Text = "公司：";
            // 
            // Label_Department
            // 
            this.Label_Department.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Department.AutoSize = true;
            this.Label_Department.Location = new System.Drawing.Point(22, 43);
            this.Label_Department.Name = "Label_Department";
            this.Label_Department.Size = new System.Drawing.Size(41, 12);
            this.Label_Department.TabIndex = 153;
            this.Label_Department.Text = "部门：";
            // 
            // Label_WorkPlace
            // 
            this.Label_WorkPlace.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WorkPlace.AutoSize = true;
            this.Label_WorkPlace.Location = new System.Drawing.Point(10, 76);
            this.Label_WorkPlace.Name = "Label_WorkPlace";
            this.Label_WorkPlace.Size = new System.Drawing.Size(53, 12);
            this.Label_WorkPlace.TabIndex = 154;
            this.Label_WorkPlace.Text = "作业区：";
            // 
            // TextBox_Employer
            // 
            this.TextBox_Employer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Employer.Location = new System.Drawing.Point(69, 3);
            this.TextBox_Employer.Name = "TextBox_Employer";
            this.TextBox_Employer.ReadOnly = true;
            this.TextBox_Employer.Size = new System.Drawing.Size(438, 21);
            this.TextBox_Employer.TabIndex = 149;
            // 
            // TextBox_Department
            // 
            this.TextBox_Department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Department.Location = new System.Drawing.Point(69, 36);
            this.TextBox_Department.Name = "TextBox_Department";
            this.TextBox_Department.ReadOnly = true;
            this.TextBox_Department.Size = new System.Drawing.Size(438, 21);
            this.TextBox_Department.TabIndex = 150;
            // 
            // TextBox_WorkPlace
            // 
            this.TextBox_WorkPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WorkPlace.Location = new System.Drawing.Point(69, 69);
            this.TextBox_WorkPlace.Name = "TextBox_WorkPlace";
            this.TextBox_WorkPlace.ReadOnly = true;
            this.TextBox_WorkPlace.Size = new System.Drawing.Size(438, 21);
            this.TextBox_WorkPlace.TabIndex = 151;
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label_ErrMessage);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(628, 406);
            this.splitContainer2.SplitterDistance = 347;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.checkBox_DeleteWelderBelongAll);
            this.splitContainer3.Panel1.Controls.Add(this.label_Data);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView_Data);
            this.splitContainer3.Size = new System.Drawing.Size(628, 347);
            this.splitContainer3.SplitterDistance = 28;
            this.splitContainer3.TabIndex = 6;
            // 
            // checkBox_DeleteWelderBelongAll
            // 
            this.checkBox_DeleteWelderBelongAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_DeleteWelderBelongAll.AutoSize = true;
            this.checkBox_DeleteWelderBelongAll.Location = new System.Drawing.Point(469, 7);
            this.checkBox_DeleteWelderBelongAll.Name = "checkBox_DeleteWelderBelongAll";
            this.checkBox_DeleteWelderBelongAll.Size = new System.Drawing.Size(144, 16);
            this.checkBox_DeleteWelderBelongAll.TabIndex = 4;
            this.checkBox_DeleteWelderBelongAll.Text = "删除该单位下已有数据";
            this.checkBox_DeleteWelderBelongAll.UseVisualStyleBackColor = true;
            // 
            // label_Data
            // 
            this.label_Data.AutoSize = true;
            this.label_Data.Location = new System.Drawing.Point(17, 11);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(41, 12);
            this.label_Data.TabIndex = 3;
            this.label_Data.Text = "数据：";
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.AllowUserToAddRows = false;
            this.dataGridView_Data.AllowUserToDeleteRows = false;
            this.dataGridView_Data.AllowUserToOrderColumns = true;
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Data.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.ReadOnly = true;
            this.dataGridView_Data.RowTemplate.Height = 23;
            this.dataGridView_Data.Size = new System.Drawing.Size(628, 315);
            this.dataGridView_Data.TabIndex = 2;
            this.dataGridView_Data.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_Data_CellContextMenuStripNeeded);
            // 
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(29, 17);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 26;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(466, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel2.TabIndex = 25;
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
            // toolStripMenuItem_DataGridViewRowExport
            // 
            this.toolStripMenuItem_DataGridViewRowExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowExportToExcel});
            this.toolStripMenuItem_DataGridViewRowExport.Name = "toolStripMenuItem_DataGridViewRowExport";
            this.toolStripMenuItem_DataGridViewRowExport.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem_DataGridViewRowExport.Text = "导出";
            // 
            // toolStripMenuItem_DataGridViewRowExportToExcel
            // 
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Name = "toolStripMenuItem_DataGridViewRowExportToExcel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Text = "导出到Excel";
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowExportToExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(115, 6);
            // 
            // toolStripMenuItem_DataGridViewRowFrozenThisColumn
            // 
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckOnClick = true;
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Name = "toolStripMenuItem_DataGridViewRowFrozenThisColumn";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.Text = "冻结该列";
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged);
            // 
            // contextMenuStrip_DataGridViewRow
            // 
            this.contextMenuStrip_DataGridViewRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowFrozenThisColumn,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DataGridViewRowExport});
            this.contextMenuStrip_DataGridViewRow.Name = "contextMenuStrip_pWPSTestRow";
            this.contextMenuStrip_DataGridViewRow.Size = new System.Drawing.Size(119, 54);
            // 
            // Form_WelderBelong_ImportFromExcel
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(628, 526);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_WelderBelong_ImportFromExcel";
            this.Text = "从Excel导入焊工所属数据";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_WelderBelong_ImportFromExcel_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.TableLayoutPanel4.ResumeLayout(false);
            this.TableLayoutPanel4.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.contextMenuStrip_DataGridViewRow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowFrozenThisColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridViewRow;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel4;
        internal System.Windows.Forms.Label Label_Employer;
        internal System.Windows.Forms.Label Label_Department;
        internal System.Windows.Forms.Label Label_WorkPlace;
        internal System.Windows.Forms.TextBox TextBox_Employer;
        internal System.Windows.Forms.TextBox TextBox_Department;
        internal System.Windows.Forms.TextBox TextBox_WorkPlace;
        private System.Windows.Forms.CheckBox checkBox_DeleteWelderBelongAll;
    }
}