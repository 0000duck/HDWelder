namespace ZCWelder
{
    partial class Form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.Label_ErrorMessage = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.button_ConnectionUpdate = new System.Windows.Forms.Button();
            this.checkBox_ResetSetting = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_ErrorMessage
            // 
            this.Label_ErrorMessage.AutoSize = true;
            this.Label_ErrorMessage.Location = new System.Drawing.Point(172, 137);
            this.Label_ErrorMessage.Name = "Label_ErrorMessage";
            this.Label_ErrorMessage.Size = new System.Drawing.Size(53, 12);
            this.Label_ErrorMessage.TabIndex = 14;
            this.Label_ErrorMessage.Text = "登录信息";
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(300, 161);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(94, 23);
            this.Cancel.TabIndex = 13;
            this.Cancel.Text = "取消(&C)";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(197, 161);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(94, 23);
            this.OK.TabIndex = 12;
            this.OK.Text = "确定(&O)";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(174, 101);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(220, 21);
            this.PasswordTextBox.TabIndex = 11;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(174, 44);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(220, 21);
            this.UsernameTextBox.TabIndex = 9;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(172, 81);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(220, 23);
            this.PasswordLabel.TabIndex = 10;
            this.PasswordLabel.Text = "密码(&P)";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Location = new System.Drawing.Point(172, 24);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(220, 23);
            this.UsernameLabel.TabIndex = 7;
            this.UsernameLabel.Text = "用户名(&U)";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(165, 242);
            this.LogoPictureBox.TabIndex = 8;
            this.LogoPictureBox.TabStop = false;
            // 
            // button_ConnectionUpdate
            // 
            this.button_ConnectionUpdate.Location = new System.Drawing.Point(48, 207);
            this.button_ConnectionUpdate.Name = "button_ConnectionUpdate";
            this.button_ConnectionUpdate.Size = new System.Drawing.Size(75, 23);
            this.button_ConnectionUpdate.TabIndex = 16;
            this.button_ConnectionUpdate.Text = "服务器设置";
            this.button_ConnectionUpdate.UseVisualStyleBackColor = true;
            this.button_ConnectionUpdate.Click += new System.EventHandler(this.button_ConnectionUpdate_Click);
            // 
            // checkBox_ResetSetting
            // 
            this.checkBox_ResetSetting.AutoSize = true;
            this.checkBox_ResetSetting.Location = new System.Drawing.Point(174, 211);
            this.checkBox_ResetSetting.Name = "checkBox_ResetSetting";
            this.checkBox_ResetSetting.Size = new System.Drawing.Size(120, 16);
            this.checkBox_ResetSetting.TabIndex = 17;
            this.checkBox_ResetSetting.Text = "重置所有程序设置";
            this.checkBox_ResetSetting.UseVisualStyleBackColor = true;
            // 
            // Form_Login
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(410, 242);
            this.Controls.Add(this.checkBox_ResetSetting);
            this.Controls.Add(this.button_ConnectionUpdate);
            this.Controls.Add(this.Label_ErrorMessage);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.LogoPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Login";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Form_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label_ErrorMessage;
        internal System.Windows.Forms.Button Cancel;
        internal System.Windows.Forms.Button OK;
        internal System.Windows.Forms.TextBox PasswordTextBox;
        internal System.Windows.Forms.TextBox UsernameTextBox;
        internal System.Windows.Forms.Label PasswordLabel;
        internal System.Windows.Forms.Label UsernameLabel;
        internal System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Button button_ConnectionUpdate;
        private System.Windows.Forms.CheckBox checkBox_ResetSetting;
    }
}