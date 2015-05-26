namespace ZCWelder.Exam
{
    partial class Form_TestParameter_Input
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_BendTestItem = new System.Windows.Forms.Label();
            this.comboBox_BendTestItem = new System.Windows.Forms.ComboBox();
            this.checkBox_Supervisor = new System.Windows.Forms.CheckBox();
            this.checkBox_FaceDT = new System.Windows.Forms.CheckBox();
            this.checkBox_RT = new System.Windows.Forms.CheckBox();
            this.label_Tel = new System.Windows.Forms.Label();
            this.textBox_Tel = new System.Windows.Forms.TextBox();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel1.Controls.Add(this.label_BendTestItem, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_BendTestItem, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_Supervisor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_FaceDT, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_RT, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_Tel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Tel, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(431, 158);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_BendTestItem
            // 
            this.label_BendTestItem.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_BendTestItem.AutoSize = true;
            this.label_BendTestItem.Location = new System.Drawing.Point(23, 9);
            this.label_BendTestItem.Name = "label_BendTestItem";
            this.label_BendTestItem.Size = new System.Drawing.Size(65, 12);
            this.label_BendTestItem.TabIndex = 0;
            this.label_BendTestItem.Text = "检测项目：";
            // 
            // comboBox_BendTestItem
            // 
            this.comboBox_BendTestItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_BendTestItem.FormattingEnabled = true;
            this.comboBox_BendTestItem.Items.AddRange(new object[] {
            "侧弯各两根",
            "正反弯各一根",
            "正反弯各两根",
            "折断"});
            this.comboBox_BendTestItem.Location = new System.Drawing.Point(94, 3);
            this.comboBox_BendTestItem.Name = "comboBox_BendTestItem";
            this.comboBox_BendTestItem.Size = new System.Drawing.Size(334, 20);
            this.comboBox_BendTestItem.TabIndex = 1;
            // 
            // checkBox_Supervisor
            // 
            this.checkBox_Supervisor.AutoSize = true;
            this.checkBox_Supervisor.Location = new System.Drawing.Point(94, 34);
            this.checkBox_Supervisor.Name = "checkBox_Supervisor";
            this.checkBox_Supervisor.Size = new System.Drawing.Size(84, 16);
            this.checkBox_Supervisor.TabIndex = 2;
            this.checkBox_Supervisor.Text = "验船师在场";
            this.checkBox_Supervisor.UseVisualStyleBackColor = true;
            // 
            // checkBox_FaceDT
            // 
            this.checkBox_FaceDT.AutoSize = true;
            this.checkBox_FaceDT.Checked = true;
            this.checkBox_FaceDT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_FaceDT.Location = new System.Drawing.Point(94, 65);
            this.checkBox_FaceDT.Name = "checkBox_FaceDT";
            this.checkBox_FaceDT.Size = new System.Drawing.Size(96, 16);
            this.checkBox_FaceDT.TabIndex = 2;
            this.checkBox_FaceDT.Text = "要求外观合格";
            this.checkBox_FaceDT.UseVisualStyleBackColor = true;
            // 
            // checkBox_RT
            // 
            this.checkBox_RT.AutoSize = true;
            this.checkBox_RT.Location = new System.Drawing.Point(94, 96);
            this.checkBox_RT.Name = "checkBox_RT";
            this.checkBox_RT.Size = new System.Drawing.Size(84, 16);
            this.checkBox_RT.TabIndex = 2;
            this.checkBox_RT.Text = "要求RT合格";
            this.checkBox_RT.UseVisualStyleBackColor = true;
            // 
            // label_Tel
            // 
            this.label_Tel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Tel.AutoSize = true;
            this.label_Tel.Location = new System.Drawing.Point(23, 135);
            this.label_Tel.Name = "label_Tel";
            this.label_Tel.Size = new System.Drawing.Size(65, 12);
            this.label_Tel.TabIndex = 0;
            this.label_Tel.Text = "联系电话：";
            // 
            // textBox_Tel
            // 
            this.textBox_Tel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ZCWelder.Properties.Settings.Default, "LinkTel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_Tel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Tel.Location = new System.Drawing.Point(94, 127);
            this.textBox_Tel.Name = "textBox_Tel";
            this.textBox_Tel.Size = new System.Drawing.Size(334, 21);
            this.textBox_Tel.TabIndex = 3;
            this.textBox_Tel.Text = global::ZCWelder.Properties.Settings.Default.LinkTel;
            // 
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(24, 191);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 16;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(282, 217);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel2.TabIndex = 15;
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
            // Form_TestParameter_Input
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(461, 260);
            this.Controls.Add(this.label_ErrMessage);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_TestParameter_Input";
            this.Text = "试验申请参数输入窗口";
            this.Load += new System.EventHandler(this.Form_TestParameter_Input_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_BendTestItem;
        private System.Windows.Forms.ComboBox comboBox_BendTestItem;
        private System.Windows.Forms.CheckBox checkBox_Supervisor;
        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.CheckBox checkBox_FaceDT;
        private System.Windows.Forms.CheckBox checkBox_RT;
        private System.Windows.Forms.Label label_Tel;
        private System.Windows.Forms.TextBox textBox_Tel;
    }
}