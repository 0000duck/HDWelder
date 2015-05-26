namespace ZCWelder.Person
{
    partial class Form_Welder_Synchronization
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
            this.label_KindofSynchronization = new System.Windows.Forms.Label();
            this.comboBox_KindofSynchronization = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label_WelderBelong = new System.Windows.Forms.Label();
            this.dataGridView_WelderBelong = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.button_Add = new System.Windows.Forms.Button();
            this.label_Add = new System.Windows.Forms.Label();
            this.dataGridView_Add = new System.Windows.Forms.DataGridView();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.button_Modify = new System.Windows.Forms.Button();
            this.label_Modify = new System.Windows.Forms.Label();
            this.dataGridView_Modify = new System.Windows.Forms.DataGridView();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label_Delete = new System.Windows.Forms.Label();
            this.dataGridView_Delete = new System.Windows.Forms.DataGridView();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.label_KindofEmployerWelder = new System.Windows.Forms.Label();
            this.dataGridView_KindofEmployerWelder = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WelderBelong)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Add)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Modify)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Delete)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_KindofEmployerWelder)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label_KindofSynchronization);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_KindofSynchronization);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(663, 530);
            this.splitContainer1.SplitterDistance = 29;
            this.splitContainer1.TabIndex = 0;
            // 
            // label_KindofSynchronization
            // 
            this.label_KindofSynchronization.AutoSize = true;
            this.label_KindofSynchronization.Location = new System.Drawing.Point(234, 6);
            this.label_KindofSynchronization.Name = "label_KindofSynchronization";
            this.label_KindofSynchronization.Size = new System.Drawing.Size(89, 12);
            this.label_KindofSynchronization.TabIndex = 1;
            this.label_KindofSynchronization.Text = "同步数据类型：";
            // 
            // comboBox_KindofSynchronization
            // 
            this.comboBox_KindofSynchronization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_KindofSynchronization.FormattingEnabled = true;
            this.comboBox_KindofSynchronization.Items.AddRange(new object[] {
            "报考单位 -> 本系统",
            "本系统   -> 报考单位"});
            this.comboBox_KindofSynchronization.Location = new System.Drawing.Point(13, 3);
            this.comboBox_KindofSynchronization.Name = "comboBox_KindofSynchronization";
            this.comboBox_KindofSynchronization.Size = new System.Drawing.Size(186, 20);
            this.comboBox_KindofSynchronization.TabIndex = 0;
            this.comboBox_KindofSynchronization.SelectedIndexChanged += new System.EventHandler(this.comboBox_KindofSynchronization_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer7);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(663, 497);
            this.splitContainer2.SplitterDistance = 325;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label_WelderBelong);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView_WelderBelong);
            this.splitContainer3.Size = new System.Drawing.Size(323, 247);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.TabIndex = 0;
            // 
            // label_WelderBelong
            // 
            this.label_WelderBelong.AutoSize = true;
            this.label_WelderBelong.Location = new System.Drawing.Point(11, 5);
            this.label_WelderBelong.Name = "label_WelderBelong";
            this.label_WelderBelong.Size = new System.Drawing.Size(41, 12);
            this.label_WelderBelong.TabIndex = 4;
            this.label_WelderBelong.Text = "数据：";
            // 
            // dataGridView_WelderBelong
            // 
            this.dataGridView_WelderBelong.AllowUserToAddRows = false;
            this.dataGridView_WelderBelong.AllowUserToDeleteRows = false;
            this.dataGridView_WelderBelong.AllowUserToOrderColumns = true;
            this.dataGridView_WelderBelong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_WelderBelong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_WelderBelong.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_WelderBelong.Name = "dataGridView_WelderBelong";
            this.dataGridView_WelderBelong.ReadOnly = true;
            this.dataGridView_WelderBelong.RowTemplate.Height = 23;
            this.dataGridView_WelderBelong.Size = new System.Drawing.Size(321, 216);
            this.dataGridView_WelderBelong.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer6, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 495);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.button_Add);
            this.splitContainer4.Panel1.Controls.Add(this.label_Add);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridView_Add);
            this.splitContainer4.Size = new System.Drawing.Size(326, 159);
            this.splitContainer4.SplitterDistance = 25;
            this.splitContainer4.TabIndex = 0;
            // 
            // button_Add
            // 
            this.button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Add.Location = new System.Drawing.Point(242, 0);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 5;
            this.button_Add.Text = "添加";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label_Add
            // 
            this.label_Add.AutoSize = true;
            this.label_Add.Location = new System.Drawing.Point(23, 6);
            this.label_Add.Name = "label_Add";
            this.label_Add.Size = new System.Drawing.Size(41, 12);
            this.label_Add.TabIndex = 4;
            this.label_Add.Text = "数据：";
            // 
            // dataGridView_Add
            // 
            this.dataGridView_Add.AllowUserToAddRows = false;
            this.dataGridView_Add.AllowUserToDeleteRows = false;
            this.dataGridView_Add.AllowUserToOrderColumns = true;
            this.dataGridView_Add.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Add.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Add.Name = "dataGridView_Add";
            this.dataGridView_Add.ReadOnly = true;
            this.dataGridView_Add.RowTemplate.Height = 23;
            this.dataGridView_Add.Size = new System.Drawing.Size(324, 128);
            this.dataGridView_Add.TabIndex = 3;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer5.Location = new System.Drawing.Point(3, 168);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.button_Modify);
            this.splitContainer5.Panel1.Controls.Add(this.label_Modify);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.dataGridView_Modify);
            this.splitContainer5.Size = new System.Drawing.Size(326, 159);
            this.splitContainer5.SplitterDistance = 27;
            this.splitContainer5.TabIndex = 1;
            // 
            // button_Modify
            // 
            this.button_Modify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Modify.Location = new System.Drawing.Point(242, 0);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(75, 23);
            this.button_Modify.TabIndex = 5;
            this.button_Modify.Text = "修改";
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // label_Modify
            // 
            this.label_Modify.AutoSize = true;
            this.label_Modify.Location = new System.Drawing.Point(23, 5);
            this.label_Modify.Name = "label_Modify";
            this.label_Modify.Size = new System.Drawing.Size(41, 12);
            this.label_Modify.TabIndex = 4;
            this.label_Modify.Text = "数据：";
            // 
            // dataGridView_Modify
            // 
            this.dataGridView_Modify.AllowUserToAddRows = false;
            this.dataGridView_Modify.AllowUserToDeleteRows = false;
            this.dataGridView_Modify.AllowUserToOrderColumns = true;
            this.dataGridView_Modify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Modify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Modify.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Modify.Name = "dataGridView_Modify";
            this.dataGridView_Modify.ReadOnly = true;
            this.dataGridView_Modify.RowTemplate.Height = 23;
            this.dataGridView_Modify.Size = new System.Drawing.Size(324, 126);
            this.dataGridView_Modify.TabIndex = 3;
            // 
            // splitContainer6
            // 
            this.splitContainer6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer6.Location = new System.Drawing.Point(3, 333);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.button_Delete);
            this.splitContainer6.Panel1.Controls.Add(this.label_Delete);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.dataGridView_Delete);
            this.splitContainer6.Size = new System.Drawing.Size(326, 159);
            this.splitContainer6.SplitterDistance = 25;
            this.splitContainer6.TabIndex = 2;
            // 
            // button_Delete
            // 
            this.button_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Delete.Location = new System.Drawing.Point(242, 0);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 5;
            this.button_Delete.Text = "删除";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label_Delete
            // 
            this.label_Delete.AutoSize = true;
            this.label_Delete.Location = new System.Drawing.Point(23, 4);
            this.label_Delete.Name = "label_Delete";
            this.label_Delete.Size = new System.Drawing.Size(41, 12);
            this.label_Delete.TabIndex = 4;
            this.label_Delete.Text = "数据：";
            // 
            // dataGridView_Delete
            // 
            this.dataGridView_Delete.AllowUserToAddRows = false;
            this.dataGridView_Delete.AllowUserToDeleteRows = false;
            this.dataGridView_Delete.AllowUserToOrderColumns = true;
            this.dataGridView_Delete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Delete.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Delete.Name = "dataGridView_Delete";
            this.dataGridView_Delete.ReadOnly = true;
            this.dataGridView_Delete.RowTemplate.Height = 23;
            this.dataGridView_Delete.Size = new System.Drawing.Size(324, 128);
            this.dataGridView_Delete.TabIndex = 3;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer8);
            this.splitContainer7.Size = new System.Drawing.Size(323, 495);
            this.splitContainer7.SplitterDistance = 247;
            this.splitContainer7.TabIndex = 1;
            // 
            // splitContainer8
            // 
            this.splitContainer8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer8.Location = new System.Drawing.Point(0, 0);
            this.splitContainer8.Name = "splitContainer8";
            this.splitContainer8.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.label_KindofEmployerWelder);
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.dataGridView_KindofEmployerWelder);
            this.splitContainer8.Size = new System.Drawing.Size(323, 244);
            this.splitContainer8.SplitterDistance = 25;
            this.splitContainer8.TabIndex = 1;
            // 
            // label_KindofEmployerWelder
            // 
            this.label_KindofEmployerWelder.AutoSize = true;
            this.label_KindofEmployerWelder.Location = new System.Drawing.Point(11, 5);
            this.label_KindofEmployerWelder.Name = "label_KindofEmployerWelder";
            this.label_KindofEmployerWelder.Size = new System.Drawing.Size(41, 12);
            this.label_KindofEmployerWelder.TabIndex = 4;
            this.label_KindofEmployerWelder.Text = "数据：";
            // 
            // dataGridView_KindofEmployerWelder
            // 
            this.dataGridView_KindofEmployerWelder.AllowUserToAddRows = false;
            this.dataGridView_KindofEmployerWelder.AllowUserToDeleteRows = false;
            this.dataGridView_KindofEmployerWelder.AllowUserToOrderColumns = true;
            this.dataGridView_KindofEmployerWelder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_KindofEmployerWelder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_KindofEmployerWelder.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_KindofEmployerWelder.Name = "dataGridView_KindofEmployerWelder";
            this.dataGridView_KindofEmployerWelder.ReadOnly = true;
            this.dataGridView_KindofEmployerWelder.RowTemplate.Height = 23;
            this.dataGridView_KindofEmployerWelder.Size = new System.Drawing.Size(321, 213);
            this.dataGridView_KindofEmployerWelder.TabIndex = 3;
            // 
            // Form_Welder_Synchronization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 530);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_Welder_Synchronization";
            this.Text = "同步焊工数据";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Welder_Synchronization_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WelderBelong)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Add)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Modify)).EndInit();
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Delete)).EndInit();
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            this.splitContainer7.ResumeLayout(false);
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel1.PerformLayout();
            this.splitContainer8.Panel2.ResumeLayout(false);
            this.splitContainer8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_KindofEmployerWelder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox_KindofSynchronization;
        private System.Windows.Forms.Label label_KindofSynchronization;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.DataGridView dataGridView_WelderBelong;
        private System.Windows.Forms.DataGridView dataGridView_Add;
        private System.Windows.Forms.DataGridView dataGridView_Modify;
        private System.Windows.Forms.DataGridView dataGridView_Delete;
        private System.Windows.Forms.Label label_WelderBelong;
        private System.Windows.Forms.Label label_Add;
        private System.Windows.Forms.Label label_Modify;
        private System.Windows.Forms.Label label_Delete;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.Label label_KindofEmployerWelder;
        private System.Windows.Forms.DataGridView dataGridView_KindofEmployerWelder;
    }
}