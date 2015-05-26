namespace ZCWelder.UserControlSecond
{
    partial class UserControl_WPSImageDataGridView
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label_WPSImage = new System.Windows.Forms.Label();
            this.dataGridView_WPSImage = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_DataGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DataGridViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox_WPSImage = new System.Windows.Forms.PictureBox();
            this.openFileDialog_WPSImage = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip_WPSImageRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DataGridViewRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WPSImageRowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_WPSImageRowDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_WPSImageRowRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog_WPSImage = new System.Windows.Forms.SaveFileDialog();
            this.toolStripMenuItem_DataGridViewRowModify = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WPSImage)).BeginInit();
            this.contextMenuStrip_DataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WPSImage)).BeginInit();
            this.contextMenuStrip_WPSImageRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label_WPSImage);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_WPSImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox_WPSImage);
            this.splitContainer1.Size = new System.Drawing.Size(610, 599);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 0;
            // 
            // label_WPSImage
            // 
            this.label_WPSImage.AutoSize = true;
            this.label_WPSImage.Location = new System.Drawing.Point(18, 13);
            this.label_WPSImage.Name = "label_WPSImage";
            this.label_WPSImage.Size = new System.Drawing.Size(65, 12);
            this.label_WPSImage.TabIndex = 1;
            this.label_WPSImage.Text = "附加图片：";
            // 
            // dataGridView_WPSImage
            // 
            this.dataGridView_WPSImage.AllowUserToAddRows = false;
            this.dataGridView_WPSImage.AllowUserToDeleteRows = false;
            this.dataGridView_WPSImage.AllowUserToOrderColumns = true;
            this.dataGridView_WPSImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_WPSImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_WPSImage.ContextMenuStrip = this.contextMenuStrip_DataGridView;
            this.dataGridView_WPSImage.Location = new System.Drawing.Point(0, 31);
            this.dataGridView_WPSImage.Name = "dataGridView_WPSImage";
            this.dataGridView_WPSImage.ReadOnly = true;
            this.dataGridView_WPSImage.RowTemplate.Height = 23;
            this.dataGridView_WPSImage.Size = new System.Drawing.Size(289, 566);
            this.dataGridView_WPSImage.TabIndex = 0;
            this.dataGridView_WPSImage.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_WPSImage_RowEnter);
            this.dataGridView_WPSImage.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView_WPSImage_CellContextMenuStripNeeded);
            // 
            // contextMenuStrip_DataGridView
            // 
            this.contextMenuStrip_DataGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewAdd,
            this.toolStripSeparator2,
            this.toolStripMenuItem_DataGridViewRefresh});
            this.contextMenuStrip_DataGridView.Name = "contextMenuStrip_DataGridView";
            this.contextMenuStrip_DataGridView.Size = new System.Drawing.Size(101, 54);
            this.contextMenuStrip_DataGridView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_DataGridView_Opening);
            // 
            // toolStripMenuItem_DataGridViewAdd
            // 
            this.toolStripMenuItem_DataGridViewAdd.Name = "toolStripMenuItem_DataGridViewAdd";
            this.toolStripMenuItem_DataGridViewAdd.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_DataGridViewAdd.Text = "添加";
            this.toolStripMenuItem_DataGridViewAdd.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(97, 6);
            // 
            // toolStripMenuItem_DataGridViewRefresh
            // 
            this.toolStripMenuItem_DataGridViewRefresh.Name = "toolStripMenuItem_DataGridViewRefresh";
            this.toolStripMenuItem_DataGridViewRefresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_DataGridViewRefresh.Text = "刷新";
            this.toolStripMenuItem_DataGridViewRefresh.Click += new System.EventHandler(this.toolStripMenuItem_WPSImageRowRefresh_Click);
            // 
            // pictureBox_WPSImage
            // 
            this.pictureBox_WPSImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_WPSImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_WPSImage.Name = "pictureBox_WPSImage";
            this.pictureBox_WPSImage.Size = new System.Drawing.Size(313, 597);
            this.pictureBox_WPSImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_WPSImage.TabIndex = 0;
            this.pictureBox_WPSImage.TabStop = false;
            // 
            // openFileDialog_WPSImage
            // 
            this.openFileDialog_WPSImage.FileName = "openFileDialog1";
            // 
            // contextMenuStrip_WPSImageRow
            // 
            this.contextMenuStrip_WPSImageRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DataGridViewRowAdd,
            this.toolStripMenuItem_DataGridViewRowModify,
            this.toolStripMenuItem_WPSImageRowDelete,
            this.toolStripMenuItem_WPSImageRowDownload,
            this.toolStripSeparator1,
            this.toolStripMenuItem_WPSImageRowRefresh});
            this.contextMenuStrip_WPSImageRow.Name = "contextMenuStrip_WPSImageRow";
            this.contextMenuStrip_WPSImageRow.Size = new System.Drawing.Size(153, 142);
            this.contextMenuStrip_WPSImageRow.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_WPSImageRow_Opening);
            // 
            // toolStripMenuItem_DataGridViewRowAdd
            // 
            this.toolStripMenuItem_DataGridViewRowAdd.Name = "toolStripMenuItem_DataGridViewRowAdd";
            this.toolStripMenuItem_DataGridViewRowAdd.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowAdd.Text = "添加";
            this.toolStripMenuItem_DataGridViewRowAdd.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowAdd_Click);
            // 
            // toolStripMenuItem_WPSImageRowDelete
            // 
            this.toolStripMenuItem_WPSImageRowDelete.Name = "toolStripMenuItem_WPSImageRowDelete";
            this.toolStripMenuItem_WPSImageRowDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSImageRowDelete.Text = "删除";
            this.toolStripMenuItem_WPSImageRowDelete.Click += new System.EventHandler(this.toolStripMenuItem_WPSImageRowDelete_Click);
            // 
            // toolStripMenuItem_WPSImageRowDownload
            // 
            this.toolStripMenuItem_WPSImageRowDownload.Name = "toolStripMenuItem_WPSImageRowDownload";
            this.toolStripMenuItem_WPSImageRowDownload.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSImageRowDownload.Text = "下载图像";
            this.toolStripMenuItem_WPSImageRowDownload.Click += new System.EventHandler(this.toolStripMenuItem_WPSImageRowDownload_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem_WPSImageRowRefresh
            // 
            this.toolStripMenuItem_WPSImageRowRefresh.Name = "toolStripMenuItem_WPSImageRowRefresh";
            this.toolStripMenuItem_WPSImageRowRefresh.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_WPSImageRowRefresh.Text = "刷新";
            this.toolStripMenuItem_WPSImageRowRefresh.Click += new System.EventHandler(this.toolStripMenuItem_WPSImageRowRefresh_Click);
            // 
            // toolStripMenuItem_DataGridViewRowModify
            // 
            this.toolStripMenuItem_DataGridViewRowModify.Name = "toolStripMenuItem_DataGridViewRowModify";
            this.toolStripMenuItem_DataGridViewRowModify.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DataGridViewRowModify.Text = "修改";
            this.toolStripMenuItem_DataGridViewRowModify.Click += new System.EventHandler(this.toolStripMenuItem_DataGridViewRowModify_Click);
            // 
            // UserControl_WPSImageDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_WPSImageDataGridView";
            this.Size = new System.Drawing.Size(610, 599);
            this.Load += new System.EventHandler(this.UserControl_WPSImageDataGridView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WPSImage)).EndInit();
            this.contextMenuStrip_DataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WPSImage)).EndInit();
            this.contextMenuStrip_WPSImageRow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label_WPSImage;
        private System.Windows.Forms.DataGridView dataGridView_WPSImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog_WPSImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_WPSImageRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSImageRowDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSImageRowDownload;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_WPSImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_WPSImageRowRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataGridView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRefresh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowAdd;
        private System.Windows.Forms.PictureBox pictureBox_WPSImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DataGridViewRowModify;
    }
}
