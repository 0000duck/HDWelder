namespace ZCWelder.UserControlSecond
{
    partial class UserControl_WPS_Query
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
            this.label_Data = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_pWPSJointType = new System.Windows.Forms.Label();
            this.comboBox_pWPSJointType = new System.Windows.Forms.ComboBox();
            this.label_pWPSGrooveType = new System.Windows.Forms.Label();
            this.comboBox_pWPSGrooveType = new System.Windows.Forms.ComboBox();
            this.textBox_pWPSIDEnd = new System.Windows.Forms.TextBox();
            this.label_pWPSDenomination = new System.Windows.Forms.Label();
            this.label_pWPSIDBegin = new System.Windows.Forms.Label();
            this.textBox_pWPSIDBegin = new System.Windows.Forms.TextBox();
            this.textBox_pWPSWeldingConsumable = new System.Windows.Forms.TextBox();
            this.label_pWPSWeldingConsumable = new System.Windows.Forms.Label();
            this.textBox_pWPSDenomination = new System.Windows.Forms.TextBox();
            this.checkBox_Mistiness = new System.Windows.Forms.CheckBox();
            this.label_pWPSIDEnd = new System.Windows.Forms.Label();
            this.label_pWPSMaterial = new System.Windows.Forms.Label();
            this.textBox_pWPSMaterial = new System.Windows.Forms.TextBox();
            this.label_pWPSWeldingProcessAb = new System.Windows.Forms.Label();
            this.textBox_pWPSWeldingProcessAb = new System.Windows.Forms.TextBox();
            this.label_pWPSThickness = new System.Windows.Forms.Label();
            this.label_pWPSWeldingPosition = new System.Windows.Forms.Label();
            this.textBox_pWPSThickness = new System.Windows.Forms.TextBox();
            this.textBox_pWPSWeldingPosition = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_pWPSQuery = new System.Windows.Forms.Button();
            this.button_pWPSQueryAdvance = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Data
            // 
            this.label_Data.AutoSize = true;
            this.label_Data.Location = new System.Drawing.Point(3, 9);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(89, 12);
            this.label_Data.TabIndex = 2;
            this.label_Data.Text = "查询工艺条件：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel1.Controls.Add(this.label_pWPSJointType, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_pWPSJointType, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label_pWPSGrooveType, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_pWPSGrooveType, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBox_pWPSIDEnd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_pWPSDenomination, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_pWPSIDBegin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_pWPSIDBegin, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_pWPSWeldingConsumable, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label_pWPSWeldingConsumable, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBox_pWPSDenomination, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_Mistiness, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label_pWPSIDEnd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_pWPSMaterial, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_pWPSMaterial, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_pWPSWeldingProcessAb, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox_pWPSWeldingProcessAb, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label_pWPSThickness, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_pWPSWeldingPosition, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox_pWPSThickness, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_pWPSWeldingPosition, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333611F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333094F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333611F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333611F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333611F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333611F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333611F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333611F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.330508F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.331084F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.336114F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333923F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 378);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_pWPSJointType
            // 
            this.label_pWPSJointType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_pWPSJointType.AutoSize = true;
            this.label_pWPSJointType.Location = new System.Drawing.Point(8, 288);
            this.label_pWPSJointType.Name = "label_pWPSJointType";
            this.label_pWPSJointType.Size = new System.Drawing.Size(65, 12);
            this.label_pWPSJointType.TabIndex = 4;
            this.label_pWPSJointType.Text = "接头型式：";
            // 
            // comboBox_pWPSJointType
            // 
            this.comboBox_pWPSJointType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_pWPSJointType.FormattingEnabled = true;
            this.comboBox_pWPSJointType.Location = new System.Drawing.Point(79, 282);
            this.comboBox_pWPSJointType.Name = "comboBox_pWPSJointType";
            this.comboBox_pWPSJointType.Size = new System.Drawing.Size(178, 20);
            this.comboBox_pWPSJointType.TabIndex = 4;
            // 
            // label_pWPSGrooveType
            // 
            this.label_pWPSGrooveType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_pWPSGrooveType.AutoSize = true;
            this.label_pWPSGrooveType.Location = new System.Drawing.Point(8, 257);
            this.label_pWPSGrooveType.Name = "label_pWPSGrooveType";
            this.label_pWPSGrooveType.Size = new System.Drawing.Size(65, 12);
            this.label_pWPSGrooveType.TabIndex = 4;
            this.label_pWPSGrooveType.Text = "坡口类型：";
            // 
            // comboBox_pWPSGrooveType
            // 
            this.comboBox_pWPSGrooveType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_pWPSGrooveType.FormattingEnabled = true;
            this.comboBox_pWPSGrooveType.Location = new System.Drawing.Point(79, 251);
            this.comboBox_pWPSGrooveType.Name = "comboBox_pWPSGrooveType";
            this.comboBox_pWPSGrooveType.Size = new System.Drawing.Size(178, 20);
            this.comboBox_pWPSGrooveType.TabIndex = 4;
            // 
            // textBox_pWPSIDEnd
            // 
            this.textBox_pWPSIDEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pWPSIDEnd.Location = new System.Drawing.Point(79, 34);
            this.textBox_pWPSIDEnd.Name = "textBox_pWPSIDEnd";
            this.textBox_pWPSIDEnd.Size = new System.Drawing.Size(178, 21);
            this.textBox_pWPSIDEnd.TabIndex = 9;
            // 
            // label_pWPSDenomination
            // 
            this.label_pWPSDenomination.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_pWPSDenomination.AutoSize = true;
            this.label_pWPSDenomination.Location = new System.Drawing.Point(32, 71);
            this.label_pWPSDenomination.Name = "label_pWPSDenomination";
            this.label_pWPSDenomination.Size = new System.Drawing.Size(41, 12);
            this.label_pWPSDenomination.TabIndex = 4;
            this.label_pWPSDenomination.Text = "名称：";
            // 
            // label_pWPSIDBegin
            // 
            this.label_pWPSIDBegin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_pWPSIDBegin.AutoSize = true;
            this.label_pWPSIDBegin.Location = new System.Drawing.Point(20, 9);
            this.label_pWPSIDBegin.Name = "label_pWPSIDBegin";
            this.label_pWPSIDBegin.Size = new System.Drawing.Size(53, 12);
            this.label_pWPSIDBegin.TabIndex = 5;
            this.label_pWPSIDBegin.Text = "编号从：";
            // 
            // textBox_pWPSIDBegin
            // 
            this.textBox_pWPSIDBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pWPSIDBegin.Location = new System.Drawing.Point(79, 3);
            this.textBox_pWPSIDBegin.Name = "textBox_pWPSIDBegin";
            this.textBox_pWPSIDBegin.Size = new System.Drawing.Size(178, 21);
            this.textBox_pWPSIDBegin.TabIndex = 0;
            // 
            // textBox_pWPSWeldingConsumable
            // 
            this.textBox_pWPSWeldingConsumable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pWPSWeldingConsumable.Location = new System.Drawing.Point(79, 220);
            this.textBox_pWPSWeldingConsumable.Name = "textBox_pWPSWeldingConsumable";
            this.textBox_pWPSWeldingConsumable.Size = new System.Drawing.Size(178, 21);
            this.textBox_pWPSWeldingConsumable.TabIndex = 6;
            this.toolTip1.SetToolTip(this.textBox_pWPSWeldingConsumable, "双击修改");
            this.textBox_pWPSWeldingConsumable.DoubleClick += new System.EventHandler(this.textBox_pWPSWeldingConsumable_DoubleClick);
            // 
            // label_pWPSWeldingConsumable
            // 
            this.label_pWPSWeldingConsumable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_pWPSWeldingConsumable.AutoSize = true;
            this.label_pWPSWeldingConsumable.Location = new System.Drawing.Point(8, 226);
            this.label_pWPSWeldingConsumable.Name = "label_pWPSWeldingConsumable";
            this.label_pWPSWeldingConsumable.Size = new System.Drawing.Size(65, 12);
            this.label_pWPSWeldingConsumable.TabIndex = 16;
            this.label_pWPSWeldingConsumable.Text = "焊接材料：";
            // 
            // textBox_pWPSDenomination
            // 
            this.textBox_pWPSDenomination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pWPSDenomination.Location = new System.Drawing.Point(79, 65);
            this.textBox_pWPSDenomination.Name = "textBox_pWPSDenomination";
            this.textBox_pWPSDenomination.Size = new System.Drawing.Size(178, 21);
            this.textBox_pWPSDenomination.TabIndex = 1;
            // 
            // checkBox_Mistiness
            // 
            this.checkBox_Mistiness.AutoSize = true;
            this.checkBox_Mistiness.Checked = true;
            this.checkBox_Mistiness.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Mistiness.Location = new System.Drawing.Point(79, 344);
            this.checkBox_Mistiness.Name = "checkBox_Mistiness";
            this.checkBox_Mistiness.Size = new System.Drawing.Size(72, 16);
            this.checkBox_Mistiness.TabIndex = 17;
            this.checkBox_Mistiness.Text = "模糊匹配";
            this.checkBox_Mistiness.UseVisualStyleBackColor = true;
            // 
            // label_pWPSIDEnd
            // 
            this.label_pWPSIDEnd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_pWPSIDEnd.AutoSize = true;
            this.label_pWPSIDEnd.Location = new System.Drawing.Point(8, 40);
            this.label_pWPSIDEnd.Name = "label_pWPSIDEnd";
            this.label_pWPSIDEnd.Size = new System.Drawing.Size(65, 12);
            this.label_pWPSIDEnd.TabIndex = 5;
            this.label_pWPSIDEnd.Text = "(编号)到：";
            // 
            // label_pWPSMaterial
            // 
            this.label_pWPSMaterial.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_pWPSMaterial.AutoSize = true;
            this.label_pWPSMaterial.Location = new System.Drawing.Point(32, 102);
            this.label_pWPSMaterial.Name = "label_pWPSMaterial";
            this.label_pWPSMaterial.Size = new System.Drawing.Size(41, 12);
            this.label_pWPSMaterial.TabIndex = 10;
            this.label_pWPSMaterial.Text = "母材：";
            // 
            // textBox_pWPSMaterial
            // 
            this.textBox_pWPSMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pWPSMaterial.Location = new System.Drawing.Point(79, 96);
            this.textBox_pWPSMaterial.Name = "textBox_pWPSMaterial";
            this.textBox_pWPSMaterial.Size = new System.Drawing.Size(178, 21);
            this.textBox_pWPSMaterial.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBox_pWPSMaterial, "双击修改");
            this.textBox_pWPSMaterial.DoubleClick += new System.EventHandler(this.textBox_pWPSMaterial_DoubleClick);
            // 
            // label_pWPSWeldingProcessAb
            // 
            this.label_pWPSWeldingProcessAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_pWPSWeldingProcessAb.AutoSize = true;
            this.label_pWPSWeldingProcessAb.Location = new System.Drawing.Point(8, 195);
            this.label_pWPSWeldingProcessAb.Name = "label_pWPSWeldingProcessAb";
            this.label_pWPSWeldingProcessAb.Size = new System.Drawing.Size(65, 12);
            this.label_pWPSWeldingProcessAb.TabIndex = 7;
            this.label_pWPSWeldingProcessAb.Text = "焊接方法：";
            // 
            // textBox_pWPSWeldingProcessAb
            // 
            this.textBox_pWPSWeldingProcessAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pWPSWeldingProcessAb.Location = new System.Drawing.Point(79, 189);
            this.textBox_pWPSWeldingProcessAb.Name = "textBox_pWPSWeldingProcessAb";
            this.textBox_pWPSWeldingProcessAb.Size = new System.Drawing.Size(178, 21);
            this.textBox_pWPSWeldingProcessAb.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBox_pWPSWeldingProcessAb, "双击修改");
            this.textBox_pWPSWeldingProcessAb.DoubleClick += new System.EventHandler(this.textBox_pWPSWeldingProcessAb_DoubleClick);
            // 
            // label_pWPSThickness
            // 
            this.label_pWPSThickness.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_pWPSThickness.AutoSize = true;
            this.label_pWPSThickness.Location = new System.Drawing.Point(8, 133);
            this.label_pWPSThickness.Name = "label_pWPSThickness";
            this.label_pWPSThickness.Size = new System.Drawing.Size(65, 12);
            this.label_pWPSThickness.TabIndex = 10;
            this.label_pWPSThickness.Text = "母材板厚：";
            // 
            // label_pWPSWeldingPosition
            // 
            this.label_pWPSWeldingPosition.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_pWPSWeldingPosition.AutoSize = true;
            this.label_pWPSWeldingPosition.Location = new System.Drawing.Point(8, 164);
            this.label_pWPSWeldingPosition.Name = "label_pWPSWeldingPosition";
            this.label_pWPSWeldingPosition.Size = new System.Drawing.Size(65, 12);
            this.label_pWPSWeldingPosition.TabIndex = 10;
            this.label_pWPSWeldingPosition.Text = "焊接位置：";
            // 
            // textBox_pWPSThickness
            // 
            this.textBox_pWPSThickness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pWPSThickness.Location = new System.Drawing.Point(79, 127);
            this.textBox_pWPSThickness.Name = "textBox_pWPSThickness";
            this.textBox_pWPSThickness.Size = new System.Drawing.Size(178, 21);
            this.textBox_pWPSThickness.TabIndex = 5;
            // 
            // textBox_pWPSWeldingPosition
            // 
            this.textBox_pWPSWeldingPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pWPSWeldingPosition.Location = new System.Drawing.Point(79, 158);
            this.textBox_pWPSWeldingPosition.Name = "textBox_pWPSWeldingPosition";
            this.textBox_pWPSWeldingPosition.Size = new System.Drawing.Size(178, 21);
            this.textBox_pWPSWeldingPosition.TabIndex = 5;
            this.textBox_pWPSWeldingPosition.DoubleClick += new System.EventHandler(this.textBox_pWPSWeldingPosition_DoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_pWPSQuery, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_pWPSQueryAdvance, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(112, 417);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 31);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // button_pWPSQuery
            // 
            this.button_pWPSQuery.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_pWPSQuery.Location = new System.Drawing.Point(3, 3);
            this.button_pWPSQuery.Name = "button_pWPSQuery";
            this.button_pWPSQuery.Size = new System.Drawing.Size(69, 23);
            this.button_pWPSQuery.TabIndex = 0;
            this.button_pWPSQuery.Text = "查询";
            this.button_pWPSQuery.UseVisualStyleBackColor = true;
            this.button_pWPSQuery.Click += new System.EventHandler(this.button_pWPSQuery_Click);
            // 
            // button_pWPSQueryAdvance
            // 
            this.button_pWPSQueryAdvance.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_pWPSQueryAdvance.Location = new System.Drawing.Point(78, 3);
            this.button_pWPSQueryAdvance.Name = "button_pWPSQueryAdvance";
            this.button_pWPSQueryAdvance.Size = new System.Drawing.Size(69, 23);
            this.button_pWPSQueryAdvance.TabIndex = 1;
            this.button_pWPSQueryAdvance.Text = "高级";
            this.button_pWPSQueryAdvance.UseVisualStyleBackColor = true;
            this.button_pWPSQueryAdvance.Click += new System.EventHandler(this.button_pWPSQueryAdvance_Click);
            // 
            // UserControl_WPS_Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label_Data);
            this.Name = "UserControl_WPS_Query";
            this.Size = new System.Drawing.Size(268, 467);
            this.Load += new System.EventHandler(this.UserControl_ProjectFirst_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_pWPSIDBegin;
        private System.Windows.Forms.Label label_pWPSWeldingProcessAb;
        private System.Windows.Forms.Label label_pWPSMaterial;
        private System.Windows.Forms.TextBox textBox_pWPSIDBegin;
        private System.Windows.Forms.TextBox textBox_pWPSWeldingConsumable;
        private System.Windows.Forms.TextBox textBox_pWPSMaterial;
        private System.Windows.Forms.Label label_pWPSWeldingConsumable;
        private System.Windows.Forms.TextBox textBox_pWPSDenomination;
        private System.Windows.Forms.Label label_pWPSDenomination;
        private System.Windows.Forms.TextBox textBox_pWPSWeldingProcessAb;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox_Mistiness;
        private System.Windows.Forms.TextBox textBox_pWPSIDEnd;
        private System.Windows.Forms.Label label_pWPSIDEnd;
        private System.Windows.Forms.Label label_pWPSThickness;
        private System.Windows.Forms.Label label_pWPSWeldingPosition;
        private System.Windows.Forms.TextBox textBox_pWPSThickness;
        private System.Windows.Forms.TextBox textBox_pWPSWeldingPosition;
        private System.Windows.Forms.ComboBox comboBox_pWPSGrooveType;
        private System.Windows.Forms.Label label_pWPSGrooveType;
        private System.Windows.Forms.ComboBox comboBox_pWPSJointType;
        private System.Windows.Forms.Label label_pWPSJointType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_pWPSQuery;
        private System.Windows.Forms.Button button_pWPSQueryAdvance;
    }
}
