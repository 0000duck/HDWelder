namespace ZCWelder.UserControlThird
{
    partial class UserControl_KindofExamBase
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_PassScore = new System.Windows.Forms.NumericUpDown();
            this.label_KindofExamRemark = new System.Windows.Forms.Label();
            this.label_KindofExamIndex = new System.Windows.Forms.Label();
            this.label_KindofExam = new System.Windows.Forms.Label();
            this.textBox_KindofExam = new System.Windows.Forms.TextBox();
            this.numericUpDown_KindofExamIndex = new System.Windows.Forms.NumericUpDown();
            this.textBox_KindofExamRemark = new System.Windows.Forms.TextBox();
            this.checkBox_TheoryResultNeed = new System.Windows.Forms.CheckBox();
            this.checkBox_SkillResultNeed = new System.Windows.Forms.CheckBox();
            this.label_PassScore = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PassScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_KindofExamIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_PassScore, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_KindofExamRemark, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label_KindofExamIndex, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_KindofExam, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_KindofExam, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_KindofExamIndex, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_KindofExamRemark, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_TheoryResultNeed, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_SkillResultNeed, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_PassScore, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66733F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66567F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66567F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66733F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66733F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(251, 208);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // numericUpDown_PassScore
            // 
            this.numericUpDown_PassScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_PassScore.Location = new System.Drawing.Point(74, 105);
            this.numericUpDown_PassScore.Name = "numericUpDown_PassScore";
            this.numericUpDown_PassScore.Size = new System.Drawing.Size(174, 21);
            this.numericUpDown_PassScore.TabIndex = 2;
            this.numericUpDown_PassScore.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label_KindofExamRemark
            // 
            this.label_KindofExamRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_KindofExamRemark.AutoSize = true;
            this.label_KindofExamRemark.Location = new System.Drawing.Point(27, 183);
            this.label_KindofExamRemark.Name = "label_KindofExamRemark";
            this.label_KindofExamRemark.Size = new System.Drawing.Size(41, 12);
            this.label_KindofExamRemark.TabIndex = 3;
            this.label_KindofExamRemark.Text = "备注：";
            // 
            // label_KindofExamIndex
            // 
            this.label_KindofExamIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_KindofExamIndex.AutoSize = true;
            this.label_KindofExamIndex.Location = new System.Drawing.Point(3, 147);
            this.label_KindofExamIndex.Name = "label_KindofExamIndex";
            this.label_KindofExamIndex.Size = new System.Drawing.Size(65, 12);
            this.label_KindofExamIndex.TabIndex = 5;
            this.label_KindofExamIndex.Text = "排序索引：";
            // 
            // label_KindofExam
            // 
            this.label_KindofExam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_KindofExam.AutoSize = true;
            this.label_KindofExam.Location = new System.Drawing.Point(3, 11);
            this.label_KindofExam.Name = "label_KindofExam";
            this.label_KindofExam.Size = new System.Drawing.Size(65, 12);
            this.label_KindofExam.TabIndex = 4;
            this.label_KindofExam.Text = "考试方式：";
            // 
            // textBox_KindofExam
            // 
            this.textBox_KindofExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_KindofExam.Location = new System.Drawing.Point(74, 3);
            this.textBox_KindofExam.Name = "textBox_KindofExam";
            this.textBox_KindofExam.Size = new System.Drawing.Size(174, 21);
            this.textBox_KindofExam.TabIndex = 0;
            // 
            // numericUpDown_KindofExamIndex
            // 
            this.numericUpDown_KindofExamIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_KindofExamIndex.Location = new System.Drawing.Point(74, 139);
            this.numericUpDown_KindofExamIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_KindofExamIndex.Name = "numericUpDown_KindofExamIndex";
            this.numericUpDown_KindofExamIndex.Size = new System.Drawing.Size(174, 21);
            this.numericUpDown_KindofExamIndex.TabIndex = 1;
            // 
            // textBox_KindofExamRemark
            // 
            this.textBox_KindofExamRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_KindofExamRemark.Location = new System.Drawing.Point(74, 173);
            this.textBox_KindofExamRemark.Name = "textBox_KindofExamRemark";
            this.textBox_KindofExamRemark.Size = new System.Drawing.Size(174, 21);
            this.textBox_KindofExamRemark.TabIndex = 2;
            // 
            // checkBox_TheoryResultNeed
            // 
            this.checkBox_TheoryResultNeed.AutoSize = true;
            this.checkBox_TheoryResultNeed.Location = new System.Drawing.Point(74, 37);
            this.checkBox_TheoryResultNeed.Name = "checkBox_TheoryResultNeed";
            this.checkBox_TheoryResultNeed.Size = new System.Drawing.Size(96, 16);
            this.checkBox_TheoryResultNeed.TabIndex = 6;
            this.checkBox_TheoryResultNeed.Text = "需要理论考试";
            this.checkBox_TheoryResultNeed.UseVisualStyleBackColor = true;
            // 
            // checkBox_SkillResultNeed
            // 
            this.checkBox_SkillResultNeed.AutoSize = true;
            this.checkBox_SkillResultNeed.Location = new System.Drawing.Point(74, 71);
            this.checkBox_SkillResultNeed.Name = "checkBox_SkillResultNeed";
            this.checkBox_SkillResultNeed.Size = new System.Drawing.Size(96, 16);
            this.checkBox_SkillResultNeed.TabIndex = 6;
            this.checkBox_SkillResultNeed.Text = "需要技能考试";
            this.checkBox_SkillResultNeed.UseVisualStyleBackColor = true;
            // 
            // label_PassScore
            // 
            this.label_PassScore.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_PassScore.AutoSize = true;
            this.label_PassScore.Location = new System.Drawing.Point(3, 113);
            this.label_PassScore.Name = "label_PassScore";
            this.label_PassScore.Size = new System.Drawing.Size(65, 12);
            this.label_PassScore.TabIndex = 5;
            this.label_PassScore.Text = "合格分数：";
            // 
            // UserControl_KindofExamBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControl_KindofExamBase";
            this.Size = new System.Drawing.Size(259, 216);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PassScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_KindofExamIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_KindofExamRemark;
        private System.Windows.Forms.Label label_KindofExamIndex;
        private System.Windows.Forms.Label label_KindofExam;
        private System.Windows.Forms.TextBox textBox_KindofExam;
        private System.Windows.Forms.NumericUpDown numericUpDown_KindofExamIndex;
        private System.Windows.Forms.TextBox textBox_KindofExamRemark;
        private System.Windows.Forms.CheckBox checkBox_TheoryResultNeed;
        private System.Windows.Forms.CheckBox checkBox_SkillResultNeed;
        private System.Windows.Forms.NumericUpDown numericUpDown_PassScore;
        private System.Windows.Forms.Label label_PassScore;
    }
}
