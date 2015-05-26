namespace ZCWelder.Parameter
{
    partial class Form_KindofEmployerUpdate
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
            this.userControl_KindofEmployerBase1 = new ZCWelder.UserControlThird.UserControl_KindofEmployerBase();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.Button_KindofEmployerModify = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // userControl_KindofEmployerBase1
            // 
            this.userControl_KindofEmployerBase1.Location = new System.Drawing.Point(26, 22);
            this.userControl_KindofEmployerBase1.Name = "userControl_KindofEmployerBase1";
            this.userControl_KindofEmployerBase1.Size = new System.Drawing.Size(637, 304);
            this.userControl_KindofEmployerBase1.TabIndex = 0;
            // 
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(24, 385);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 18;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(485, 385);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel2.TabIndex = 17;
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
            // Button_KindofEmployerModify
            // 
            this.Button_KindofEmployerModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_KindofEmployerModify.Location = new System.Drawing.Point(26, 332);
            this.Button_KindofEmployerModify.Name = "Button_KindofEmployerModify";
            this.Button_KindofEmployerModify.Size = new System.Drawing.Size(127, 26);
            this.Button_KindofEmployerModify.TabIndex = 143;
            this.Button_KindofEmployerModify.Text = "修改报考单位名称";
            this.Button_KindofEmployerModify.UseVisualStyleBackColor = true;
            this.Button_KindofEmployerModify.Click += new System.EventHandler(this.Button_KindofEmployerModify_Click);
            // 
            // Form_KindofEmployerUpdate
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(675, 439);
            this.Controls.Add(this.Button_KindofEmployerModify);
            this.Controls.Add(this.label_ErrMessage);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.userControl_KindofEmployerBase1);
            this.Name = "Form_KindofEmployerUpdate";
            this.Text = "报考单位信息更新";
            this.Load += new System.EventHandler(this.Form_KindofEmployerUpdate_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZCWelder.UserControlThird.UserControl_KindofEmployerBase userControl_KindofEmployerBase1;
        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        internal System.Windows.Forms.Button Button_KindofEmployerModify;
    }
}