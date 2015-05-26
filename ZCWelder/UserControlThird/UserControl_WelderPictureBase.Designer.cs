namespace ZCWelder.UserControlThird
{
    partial class UserControl_WelderPictureBase
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_DeletePicture = new System.Windows.Forms.Button();
            this.button_DownLoadPicture = new System.Windows.Forms.Button();
            this.button_UploadPicture = new System.Windows.Forms.Button();
            this.pictureBox_Welder = new System.Windows.Forms.PictureBox();
            this.button_LoadImageFromHR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Welder)).BeginInit();
            this.SuspendLayout();
            // 
            // button_DeletePicture
            // 
            this.button_DeletePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_DeletePicture.Location = new System.Drawing.Point(126, 92);
            this.button_DeletePicture.Name = "button_DeletePicture";
            this.button_DeletePicture.Size = new System.Drawing.Size(92, 23);
            this.button_DeletePicture.TabIndex = 10;
            this.button_DeletePicture.Text = "删除照片";
            this.button_DeletePicture.UseVisualStyleBackColor = true;
            this.button_DeletePicture.Click += new System.EventHandler(this.button_DeletePicture_Click);
            // 
            // button_DownLoadPicture
            // 
            this.button_DownLoadPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_DownLoadPicture.Location = new System.Drawing.Point(126, 53);
            this.button_DownLoadPicture.Name = "button_DownLoadPicture";
            this.button_DownLoadPicture.Size = new System.Drawing.Size(92, 23);
            this.button_DownLoadPicture.TabIndex = 9;
            this.button_DownLoadPicture.Text = "下载照片";
            this.button_DownLoadPicture.UseVisualStyleBackColor = true;
            this.button_DownLoadPicture.Click += new System.EventHandler(this.button_DownLoadPicture_Click);
            // 
            // button_UploadPicture
            // 
            this.button_UploadPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_UploadPicture.Location = new System.Drawing.Point(126, 12);
            this.button_UploadPicture.Name = "button_UploadPicture";
            this.button_UploadPicture.Size = new System.Drawing.Size(92, 23);
            this.button_UploadPicture.TabIndex = 8;
            this.button_UploadPicture.Text = "上传照片";
            this.button_UploadPicture.UseVisualStyleBackColor = true;
            this.button_UploadPicture.Click += new System.EventHandler(this.button_UploadPicture_Click);
            // 
            // pictureBox_Welder
            // 
            this.pictureBox_Welder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox_Welder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Welder.Location = new System.Drawing.Point(7, 4);
            this.pictureBox_Welder.Name = "pictureBox_Welder";
            this.pictureBox_Welder.Size = new System.Drawing.Size(100, 150);
            this.pictureBox_Welder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Welder.TabIndex = 7;
            this.pictureBox_Welder.TabStop = false;
            // 
            // button_LoadImageFromHR
            // 
            this.button_LoadImageFromHR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LoadImageFromHR.Location = new System.Drawing.Point(126, 131);
            this.button_LoadImageFromHR.Name = "button_LoadImageFromHR";
            this.button_LoadImageFromHR.Size = new System.Drawing.Size(92, 23);
            this.button_LoadImageFromHR.TabIndex = 11;
            this.button_LoadImageFromHR.Text = "加载用友照片";
            this.button_LoadImageFromHR.UseVisualStyleBackColor = true;
            this.button_LoadImageFromHR.Click += new System.EventHandler(this.button_LoadImageFromHR_Click);
            // 
            // UserControl_WelderPictureBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_LoadImageFromHR);
            this.Controls.Add(this.button_DeletePicture);
            this.Controls.Add(this.button_DownLoadPicture);
            this.Controls.Add(this.button_UploadPicture);
            this.Controls.Add(this.pictureBox_Welder);
            this.Name = "UserControl_WelderPictureBase";
            this.Size = new System.Drawing.Size(224, 161);
            this.Load += new System.EventHandler(this.UserControl_WelderPictureBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Welder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Welder;
        public System.Windows.Forms.Button button_DeletePicture;
        public System.Windows.Forms.Button button_DownLoadPicture;
        public System.Windows.Forms.Button button_UploadPicture;
        private System.Windows.Forms.Button button_LoadImageFromHR;
    }
}
