namespace ZCWelder.ParameterQuery
{
    partial class Form_WeldingSubject_Query
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ComboBox_JointType = new System.Windows.Forms.ComboBox();
            this.Label_JointType = new System.Windows.Forms.Label();
            this.ComboBox_WorkPieceType = new System.Windows.Forms.ComboBox();
            this.textBox_SubjectID = new System.Windows.Forms.TextBox();
            this.Label_WorkPieceType = new System.Windows.Forms.Label();
            this.label_SubjectID = new System.Windows.Forms.Label();
            this.Label_WeldingStandard = new System.Windows.Forms.Label();
            this.ComboBox_WeldingStandard = new System.Windows.Forms.ComboBox();
            this.button_Query = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_Query = new System.Windows.Forms.DataGridView();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Query)).BeginInit();
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(505, 23);
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
            this.splitContainer1.Size = new System.Drawing.Size(674, 484);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 19;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_JointType, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label_JointType, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_WorkPieceType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_SubjectID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_WorkPieceType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_SubjectID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_WeldingStandard, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_WeldingStandard, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Query, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(627, 66);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ComboBox_JointType
            // 
            this.ComboBox_JointType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_JointType.FormattingEnabled = true;
            this.ComboBox_JointType.Location = new System.Drawing.Point(366, 36);
            this.ComboBox_JointType.Name = "ComboBox_JointType";
            this.ComboBox_JointType.Size = new System.Drawing.Size(179, 20);
            this.ComboBox_JointType.TabIndex = 25;
            // 
            // Label_JointType
            // 
            this.Label_JointType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_JointType.AutoSize = true;
            this.Label_JointType.Location = new System.Drawing.Point(295, 43);
            this.Label_JointType.Name = "Label_JointType";
            this.Label_JointType.Size = new System.Drawing.Size(65, 12);
            this.Label_JointType.TabIndex = 24;
            this.Label_JointType.Text = "焊缝类型：";
            // 
            // ComboBox_WorkPieceType
            // 
            this.ComboBox_WorkPieceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_WorkPieceType.FormattingEnabled = true;
            this.ComboBox_WorkPieceType.Location = new System.Drawing.Point(92, 36);
            this.ComboBox_WorkPieceType.Name = "ComboBox_WorkPieceType";
            this.ComboBox_WorkPieceType.Size = new System.Drawing.Size(193, 20);
            this.ComboBox_WorkPieceType.TabIndex = 23;
            // 
            // textBox_SubjectID
            // 
            this.textBox_SubjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SubjectID.Location = new System.Drawing.Point(92, 3);
            this.textBox_SubjectID.Name = "textBox_SubjectID";
            this.textBox_SubjectID.Size = new System.Drawing.Size(193, 21);
            this.textBox_SubjectID.TabIndex = 0;
            // 
            // Label_WorkPieceType
            // 
            this.Label_WorkPieceType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WorkPieceType.AutoSize = true;
            this.Label_WorkPieceType.Location = new System.Drawing.Point(21, 43);
            this.Label_WorkPieceType.Name = "Label_WorkPieceType";
            this.Label_WorkPieceType.Size = new System.Drawing.Size(65, 12);
            this.Label_WorkPieceType.TabIndex = 22;
            this.Label_WorkPieceType.Text = "工件类型：";
            // 
            // label_SubjectID
            // 
            this.label_SubjectID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_SubjectID.AutoSize = true;
            this.label_SubjectID.Location = new System.Drawing.Point(21, 10);
            this.label_SubjectID.Name = "label_SubjectID";
            this.label_SubjectID.Size = new System.Drawing.Size(65, 12);
            this.label_SubjectID.TabIndex = 1;
            this.label_SubjectID.Text = "科目编号：";
            // 
            // Label_WeldingStandard
            // 
            this.Label_WeldingStandard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingStandard.AutoSize = true;
            this.Label_WeldingStandard.Location = new System.Drawing.Point(319, 10);
            this.Label_WeldingStandard.Name = "Label_WeldingStandard";
            this.Label_WeldingStandard.Size = new System.Drawing.Size(41, 12);
            this.Label_WeldingStandard.TabIndex = 20;
            this.Label_WeldingStandard.Text = "标准：";
            // 
            // ComboBox_WeldingStandard
            // 
            this.ComboBox_WeldingStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_WeldingStandard.FormattingEnabled = true;
            this.ComboBox_WeldingStandard.Location = new System.Drawing.Point(366, 3);
            this.ComboBox_WeldingStandard.Name = "ComboBox_WeldingStandard";
            this.ComboBox_WeldingStandard.Size = new System.Drawing.Size(179, 20);
            this.ComboBox_WeldingStandard.TabIndex = 21;
            // 
            // button_Query
            // 
            this.button_Query.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Query.Location = new System.Drawing.Point(551, 36);
            this.button_Query.Name = "button_Query";
            this.button_Query.Size = new System.Drawing.Size(73, 27);
            this.button_Query.TabIndex = 3;
            this.button_Query.Text = "查询";
            this.button_Query.UseVisualStyleBackColor = true;
            this.button_Query.Click += new System.EventHandler(this.button_Query_Click);
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
            this.splitContainer2.Size = new System.Drawing.Size(674, 392);
            this.splitContainer2.SplitterDistance = 319;
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
            this.dataGridView_Query.Size = new System.Drawing.Size(674, 319);
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
            // Form_WeldingSubject_Query
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(674, 484);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_WeldingSubject_Query";
            this.Text = "考试科目查询";
            this.Load += new System.EventHandler(this.Form_WeldingSubject_Query_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Query)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.ComboBox ComboBox_JointType;
        internal System.Windows.Forms.Label Label_JointType;
        internal System.Windows.Forms.ComboBox ComboBox_WorkPieceType;
        private System.Windows.Forms.TextBox textBox_SubjectID;
        internal System.Windows.Forms.Label Label_WorkPieceType;
        private System.Windows.Forms.Label label_SubjectID;
        internal System.Windows.Forms.Label Label_WeldingStandard;
        internal System.Windows.Forms.ComboBox ComboBox_WeldingStandard;
        private System.Windows.Forms.Button button_Query;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView_Query;
        private System.Windows.Forms.Label label_ErrMessage;
    }
}