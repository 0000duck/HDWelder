namespace ZCWelder.WPS
{
    partial class Form_WPSImageUpdate
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBox_WPSImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OnOK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_ErrMessage = new System.Windows.Forms.Label();
            this.label_WPSImageUpLoad = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_WPSImageRemark = new System.Windows.Forms.TextBox();
            this.textBox_WPSImageID = new System.Windows.Forms.TextBox();
            this.label_WPSImageGroup = new System.Windows.Forms.Label();
            this.label_WPSImageRemark = new System.Windows.Forms.Label();
            this.label_WPSImageID = new System.Windows.Forms.Label();
            this.comboBox_WPSImageGroup = new System.Windows.Forms.ComboBox();
            this.label_WPSID = new System.Windows.Forms.Label();
            this.textBox_WPSID = new System.Windows.Forms.TextBox();
            this.label_WPSImageName = new System.Windows.Forms.Label();
            this.textBox_WPSImageName = new System.Windows.Forms.TextBox();
            this.button_WPSImageUpLoad = new System.Windows.Forms.Button();
            this.openFileDialog_WPSImage = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WPSImage)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox_WPSImage);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel2.Controls.Add(this.label_ErrMessage);
            this.splitContainer2.Panel2.Controls.Add(this.label_WPSImageUpLoad);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Panel2.Controls.Add(this.button_WPSImageUpLoad);
            this.splitContainer2.Size = new System.Drawing.Size(515, 655);
            this.splitContainer2.SplitterDistance = 396;
            this.splitContainer2.TabIndex = 5;
            // 
            // pictureBox_WPSImage
            // 
            this.pictureBox_WPSImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_WPSImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_WPSImage.Name = "pictureBox_WPSImage";
            this.pictureBox_WPSImage.Size = new System.Drawing.Size(513, 394);
            this.pictureBox_WPSImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_WPSImage.TabIndex = 0;
            this.pictureBox_WPSImage.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_OnOK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(333, 198);
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
            // label_ErrMessage
            // 
            this.label_ErrMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ErrMessage.AutoSize = true;
            this.label_ErrMessage.Location = new System.Drawing.Point(20, 171);
            this.label_ErrMessage.Name = "label_ErrMessage";
            this.label_ErrMessage.Size = new System.Drawing.Size(65, 12);
            this.label_ErrMessage.TabIndex = 8;
            this.label_ErrMessage.Text = "错误信息：";
            // 
            // label_WPSImageUpLoad
            // 
            this.label_WPSImageUpLoad.AutoSize = true;
            this.label_WPSImageUpLoad.Location = new System.Drawing.Point(13, 21);
            this.label_WPSImageUpLoad.Name = "label_WPSImageUpLoad";
            this.label_WPSImageUpLoad.Size = new System.Drawing.Size(161, 12);
            this.label_WPSImageUpLoad.TabIndex = 1;
            this.label_WPSImageUpLoad.Text = "请选择一个新图片进行上传：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_WPSImageRemark, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WPSImageID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_WPSImageGroup, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_WPSImageRemark, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_WPSImageID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_WPSImageGroup, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_WPSID, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WPSID, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_WPSImageName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WPSImageName, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(483, 108);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // textBox_WPSImageRemark
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_WPSImageRemark, 3);
            this.textBox_WPSImageRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WPSImageRemark.Location = new System.Drawing.Point(76, 75);
            this.textBox_WPSImageRemark.Name = "textBox_WPSImageRemark";
            this.textBox_WPSImageRemark.Size = new System.Drawing.Size(404, 21);
            this.textBox_WPSImageRemark.TabIndex = 15;
            // 
            // textBox_WPSImageID
            // 
            this.textBox_WPSImageID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WPSImageID.Location = new System.Drawing.Point(76, 3);
            this.textBox_WPSImageID.Name = "textBox_WPSImageID";
            this.textBox_WPSImageID.ReadOnly = true;
            this.textBox_WPSImageID.Size = new System.Drawing.Size(146, 21);
            this.textBox_WPSImageID.TabIndex = 12;
            // 
            // label_WPSImageGroup
            // 
            this.label_WPSImageGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WPSImageGroup.AutoSize = true;
            this.label_WPSImageGroup.Location = new System.Drawing.Point(17, 48);
            this.label_WPSImageGroup.Name = "label_WPSImageGroup";
            this.label_WPSImageGroup.Size = new System.Drawing.Size(53, 12);
            this.label_WPSImageGroup.TabIndex = 10;
            this.label_WPSImageGroup.Text = "图片组：";
            // 
            // label_WPSImageRemark
            // 
            this.label_WPSImageRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WPSImageRemark.AutoSize = true;
            this.label_WPSImageRemark.Location = new System.Drawing.Point(29, 84);
            this.label_WPSImageRemark.Name = "label_WPSImageRemark";
            this.label_WPSImageRemark.Size = new System.Drawing.Size(41, 12);
            this.label_WPSImageRemark.TabIndex = 9;
            this.label_WPSImageRemark.Text = "备注：";
            // 
            // label_WPSImageID
            // 
            this.label_WPSImageID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WPSImageID.AutoSize = true;
            this.label_WPSImageID.Location = new System.Drawing.Point(29, 12);
            this.label_WPSImageID.Name = "label_WPSImageID";
            this.label_WPSImageID.Size = new System.Drawing.Size(41, 12);
            this.label_WPSImageID.TabIndex = 11;
            this.label_WPSImageID.Text = "编号：";
            // 
            // comboBox_WPSImageGroup
            // 
            this.comboBox_WPSImageGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_WPSImageGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WPSImageGroup.FormattingEnabled = true;
            this.comboBox_WPSImageGroup.Location = new System.Drawing.Point(76, 39);
            this.comboBox_WPSImageGroup.Name = "comboBox_WPSImageGroup";
            this.comboBox_WPSImageGroup.Size = new System.Drawing.Size(146, 20);
            this.comboBox_WPSImageGroup.TabIndex = 14;
            // 
            // label_WPSID
            // 
            this.label_WPSID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WPSID.AutoSize = true;
            this.label_WPSID.Location = new System.Drawing.Point(232, 12);
            this.label_WPSID.Name = "label_WPSID";
            this.label_WPSID.Size = new System.Drawing.Size(65, 12);
            this.label_WPSID.TabIndex = 8;
            this.label_WPSID.Text = "WPS编号：";
            // 
            // textBox_WPSID
            // 
            this.textBox_WPSID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WPSID.Location = new System.Drawing.Point(303, 3);
            this.textBox_WPSID.Name = "textBox_WPSID";
            this.textBox_WPSID.ReadOnly = true;
            this.textBox_WPSID.Size = new System.Drawing.Size(177, 21);
            this.textBox_WPSID.TabIndex = 13;
            // 
            // label_WPSImageName
            // 
            this.label_WPSImageName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_WPSImageName.AutoSize = true;
            this.label_WPSImageName.Location = new System.Drawing.Point(232, 48);
            this.label_WPSImageName.Name = "label_WPSImageName";
            this.label_WPSImageName.Size = new System.Drawing.Size(65, 12);
            this.label_WPSImageName.TabIndex = 9;
            this.label_WPSImageName.Text = "图片名称：";
            // 
            // textBox_WPSImageName
            // 
            this.textBox_WPSImageName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WPSImageName.Location = new System.Drawing.Point(303, 39);
            this.textBox_WPSImageName.Name = "textBox_WPSImageName";
            this.textBox_WPSImageName.Size = new System.Drawing.Size(177, 21);
            this.textBox_WPSImageName.TabIndex = 15;
            // 
            // button_WPSImageUpLoad
            // 
            this.button_WPSImageUpLoad.Location = new System.Drawing.Point(195, 16);
            this.button_WPSImageUpLoad.Name = "button_WPSImageUpLoad";
            this.button_WPSImageUpLoad.Size = new System.Drawing.Size(75, 23);
            this.button_WPSImageUpLoad.TabIndex = 2;
            this.button_WPSImageUpLoad.Text = "选择图片";
            this.button_WPSImageUpLoad.UseVisualStyleBackColor = true;
            this.button_WPSImageUpLoad.Click += new System.EventHandler(this.button_WPSImageUpLoad_Click);
            // 
            // openFileDialog_WPSImage
            // 
            this.openFileDialog_WPSImage.FileName = "openFileDialog1";
            // 
            // Form_WPSImageUpdate
            // 
            this.AcceptButton = this.button_OnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(515, 655);
            this.Controls.Add(this.splitContainer2);
            this.Name = "Form_WPSImageUpdate";
            this.Text = "图片更新";
            this.Load += new System.EventHandler(this.Form_WPSImageUpdate_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WPSImage)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pictureBox_WPSImage;
        private System.Windows.Forms.Label label_ErrMessage;
        private System.Windows.Forms.Label label_WPSImageUpLoad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_WPSImageRemark;
        private System.Windows.Forms.TextBox textBox_WPSID;
        private System.Windows.Forms.Label label_WPSID;
        private System.Windows.Forms.TextBox textBox_WPSImageID;
        private System.Windows.Forms.Label label_WPSImageGroup;
        private System.Windows.Forms.Label label_WPSImageRemark;
        private System.Windows.Forms.Label label_WPSImageID;
        private System.Windows.Forms.ComboBox comboBox_WPSImageGroup;
        private System.Windows.Forms.Label label_WPSImageName;
        private System.Windows.Forms.TextBox textBox_WPSImageName;
        private System.Windows.Forms.Button button_WPSImageUpLoad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_OnOK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog_WPSImage;
    }
}