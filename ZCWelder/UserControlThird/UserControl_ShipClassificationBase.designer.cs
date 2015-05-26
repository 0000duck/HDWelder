namespace ZCWelder.UserControlThird
{
    partial class UserControl_ShipClassificationBase
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
            this.Label_NextExaminingNo = new System.Windows.Forms.Label();
            this.Label_NextCertificateNo = new System.Windows.Forms.Label();
            this.Label_CertificateNoRegex = new System.Windows.Forms.Label();
            this.Label_ExaminingNoRegex = new System.Windows.Forms.Label();
            this.Label_IssueNoRegex = new System.Windows.Forms.Label();
            this.ComboBox_WeldingStandard = new System.Windows.Forms.ComboBox();
            this.Label_ShipClassificationEnglishName = new System.Windows.Forms.Label();
            this.TextBox_CertificateNoRegex = new System.Windows.Forms.TextBox();
            this.MaskedTextBox_NextExaminingNo = new System.Windows.Forms.MaskedTextBox();
            this.TextBox_ShipClassificationEnglishName = new System.Windows.Forms.TextBox();
            this.MaskedTextBox_NextCertificateNo = new System.Windows.Forms.MaskedTextBox();
            this.Label_CertificateNoSignificantDigit = new System.Windows.Forms.Label();
            this.TextBox_ShipClassificationRemark = new System.Windows.Forms.TextBox();
            this.Label_ShipClassificationRemark = new System.Windows.Forms.Label();
            this.ComboBox_TestCommitteeID = new System.Windows.Forms.ComboBox();
            this.CheckBox_WeldingStandardRestrict = new System.Windows.Forms.CheckBox();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_ShipClassificationAb = new System.Windows.Forms.Label();
            this.TextBox_ShipClassificationAb = new System.Windows.Forms.TextBox();
            this.Label_ShipClassification = new System.Windows.Forms.Label();
            this.TextBox_ShipClassification = new System.Windows.Forms.TextBox();
            this.label_TestCommitteeID = new System.Windows.Forms.Label();
            this.TextBox_IssueNoRegex = new System.Windows.Forms.TextBox();
            this.TextBox_ExaminingNoRegex = new System.Windows.Forms.TextBox();
            this.NumericUpDown_IssueNoSignificantDigit = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_ExaminingNoSignificantDigit = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_CertificateNoSignificantDigit = new System.Windows.Forms.NumericUpDown();
            this.Label_IssueNoSignificantDigit = new System.Windows.Forms.Label();
            this.Label_ExaminingNoSignificantDigit = new System.Windows.Forms.Label();
            this.checkBox_YearSeparate = new System.Windows.Forms.CheckBox();
            this.numericUpDown_YearBegin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_YearEnd = new System.Windows.Forms.NumericUpDown();
            this.label_YearEnd = new System.Windows.Forms.Label();
            this.CheckBox_ShipRestrict = new System.Windows.Forms.CheckBox();
            this.CheckBox_TheorySeparate = new System.Windows.Forms.CheckBox();
            this.MaskedTextBox_NextIssueNo = new System.Windows.Forms.MaskedTextBox();
            this.Label_NextIssueNo = new System.Windows.Forms.Label();
            this.label_ShipClassificationIndex = new System.Windows.Forms.Label();
            this.numericUpDown_ShipClassificationIndex = new System.Windows.Forms.NumericUpDown();
            this.checkBox_ProlongQCContinuous = new System.Windows.Forms.CheckBox();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_IssueNoSignificantDigit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_ExaminingNoSignificantDigit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CertificateNoSignificantDigit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YearBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YearEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ShipClassificationIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_NextExaminingNo
            // 
            this.Label_NextExaminingNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_NextExaminingNo.AutoSize = true;
            this.Label_NextExaminingNo.Location = new System.Drawing.Point(38, 109);
            this.Label_NextExaminingNo.Name = "Label_NextExaminingNo";
            this.Label_NextExaminingNo.Size = new System.Drawing.Size(101, 12);
            this.Label_NextExaminingNo.TabIndex = 7;
            this.Label_NextExaminingNo.Text = "下一个考试编号：";
            // 
            // Label_NextCertificateNo
            // 
            this.Label_NextCertificateNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_NextCertificateNo.AutoSize = true;
            this.Label_NextCertificateNo.Location = new System.Drawing.Point(38, 142);
            this.Label_NextCertificateNo.Name = "Label_NextCertificateNo";
            this.Label_NextCertificateNo.Size = new System.Drawing.Size(101, 12);
            this.Label_NextCertificateNo.TabIndex = 8;
            this.Label_NextCertificateNo.Text = "下一个证书编号：";
            // 
            // Label_CertificateNoRegex
            // 
            this.Label_CertificateNoRegex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_CertificateNoRegex.AutoSize = true;
            this.Label_CertificateNoRegex.Location = new System.Drawing.Point(14, 241);
            this.Label_CertificateNoRegex.Name = "Label_CertificateNoRegex";
            this.Label_CertificateNoRegex.Size = new System.Drawing.Size(125, 12);
            this.Label_CertificateNoRegex.TabIndex = 17;
            this.Label_CertificateNoRegex.Text = "证书编号正则表达式：";
            // 
            // Label_ExaminingNoRegex
            // 
            this.Label_ExaminingNoRegex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_ExaminingNoRegex.AutoSize = true;
            this.Label_ExaminingNoRegex.Location = new System.Drawing.Point(14, 208);
            this.Label_ExaminingNoRegex.Name = "Label_ExaminingNoRegex";
            this.Label_ExaminingNoRegex.Size = new System.Drawing.Size(125, 12);
            this.Label_ExaminingNoRegex.TabIndex = 16;
            this.Label_ExaminingNoRegex.Text = "考试编号正则表达式：";
            // 
            // Label_IssueNoRegex
            // 
            this.Label_IssueNoRegex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IssueNoRegex.AutoSize = true;
            this.Label_IssueNoRegex.Location = new System.Drawing.Point(14, 175);
            this.Label_IssueNoRegex.Name = "Label_IssueNoRegex";
            this.Label_IssueNoRegex.Size = new System.Drawing.Size(125, 12);
            this.Label_IssueNoRegex.TabIndex = 15;
            this.Label_IssueNoRegex.Text = "班级编号正则表达式：";
            // 
            // ComboBox_WeldingStandard
            // 
            this.ComboBox_WeldingStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_WeldingStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_WeldingStandard.FormattingEnabled = true;
            this.ComboBox_WeldingStandard.Location = new System.Drawing.Point(522, 3);
            this.ComboBox_WeldingStandard.Name = "ComboBox_WeldingStandard";
            this.ComboBox_WeldingStandard.Size = new System.Drawing.Size(168, 20);
            this.ComboBox_WeldingStandard.TabIndex = 29;
            // 
            // Label_ShipClassificationEnglishName
            // 
            this.Label_ShipClassificationEnglishName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_ShipClassificationEnglishName.AutoSize = true;
            this.Label_ShipClassificationEnglishName.Location = new System.Drawing.Point(74, 307);
            this.Label_ShipClassificationEnglishName.Name = "Label_ShipClassificationEnglishName";
            this.Label_ShipClassificationEnglishName.Size = new System.Drawing.Size(65, 12);
            this.Label_ShipClassificationEnglishName.TabIndex = 5;
            this.Label_ShipClassificationEnglishName.Text = "英文全称：";
            // 
            // TextBox_CertificateNoRegex
            // 
            this.TextBox_CertificateNoRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_CertificateNoRegex.Location = new System.Drawing.Point(145, 234);
            this.TextBox_CertificateNoRegex.Name = "TextBox_CertificateNoRegex";
            this.TextBox_CertificateNoRegex.Size = new System.Drawing.Size(224, 21);
            this.TextBox_CertificateNoRegex.TabIndex = 27;
            // 
            // MaskedTextBox_NextExaminingNo
            // 
            this.MaskedTextBox_NextExaminingNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_NextExaminingNo.Location = new System.Drawing.Point(145, 102);
            this.MaskedTextBox_NextExaminingNo.Name = "MaskedTextBox_NextExaminingNo";
            this.MaskedTextBox_NextExaminingNo.Size = new System.Drawing.Size(224, 21);
            this.MaskedTextBox_NextExaminingNo.TabIndex = 33;
            // 
            // TextBox_ShipClassificationEnglishName
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.TextBox_ShipClassificationEnglishName, 3);
            this.TextBox_ShipClassificationEnglishName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_ShipClassificationEnglishName.Location = new System.Drawing.Point(145, 300);
            this.TextBox_ShipClassificationEnglishName.Name = "TextBox_ShipClassificationEnglishName";
            this.TextBox_ShipClassificationEnglishName.Size = new System.Drawing.Size(545, 21);
            this.TextBox_ShipClassificationEnglishName.TabIndex = 19;
            // 
            // MaskedTextBox_NextCertificateNo
            // 
            this.MaskedTextBox_NextCertificateNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_NextCertificateNo.Location = new System.Drawing.Point(145, 135);
            this.MaskedTextBox_NextCertificateNo.Name = "MaskedTextBox_NextCertificateNo";
            this.MaskedTextBox_NextCertificateNo.Size = new System.Drawing.Size(224, 21);
            this.MaskedTextBox_NextCertificateNo.TabIndex = 32;
            // 
            // Label_CertificateNoSignificantDigit
            // 
            this.Label_CertificateNoSignificantDigit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_CertificateNoSignificantDigit.AutoSize = true;
            this.Label_CertificateNoSignificantDigit.Location = new System.Drawing.Point(415, 241);
            this.Label_CertificateNoSignificantDigit.Name = "Label_CertificateNoSignificantDigit";
            this.Label_CertificateNoSignificantDigit.Size = new System.Drawing.Size(101, 12);
            this.Label_CertificateNoSignificantDigit.TabIndex = 13;
            this.Label_CertificateNoSignificantDigit.Text = "证书编号数字位：";
            // 
            // TextBox_ShipClassificationRemark
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.TextBox_ShipClassificationRemark, 3);
            this.TextBox_ShipClassificationRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_ShipClassificationRemark.Location = new System.Drawing.Point(145, 333);
            this.TextBox_ShipClassificationRemark.Name = "TextBox_ShipClassificationRemark";
            this.TextBox_ShipClassificationRemark.Size = new System.Drawing.Size(545, 21);
            this.TextBox_ShipClassificationRemark.TabIndex = 28;
            // 
            // Label_ShipClassificationRemark
            // 
            this.Label_ShipClassificationRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_ShipClassificationRemark.AutoSize = true;
            this.Label_ShipClassificationRemark.Location = new System.Drawing.Point(98, 344);
            this.Label_ShipClassificationRemark.Name = "Label_ShipClassificationRemark";
            this.Label_ShipClassificationRemark.Size = new System.Drawing.Size(41, 12);
            this.Label_ShipClassificationRemark.TabIndex = 18;
            this.Label_ShipClassificationRemark.Text = "备注：";
            // 
            // ComboBox_TestCommitteeID
            // 
            this.ComboBox_TestCommitteeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_TestCommitteeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_TestCommitteeID.FormattingEnabled = true;
            this.ComboBox_TestCommitteeID.Location = new System.Drawing.Point(522, 36);
            this.ComboBox_TestCommitteeID.Name = "ComboBox_TestCommitteeID";
            this.ComboBox_TestCommitteeID.Size = new System.Drawing.Size(168, 20);
            this.ComboBox_TestCommitteeID.TabIndex = 38;
            // 
            // CheckBox_WeldingStandardRestrict
            // 
            this.CheckBox_WeldingStandardRestrict.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CheckBox_WeldingStandardRestrict.AutoSize = true;
            this.CheckBox_WeldingStandardRestrict.Checked = true;
            this.CheckBox_WeldingStandardRestrict.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_WeldingStandardRestrict.Location = new System.Drawing.Point(420, 8);
            this.CheckBox_WeldingStandardRestrict.Name = "CheckBox_WeldingStandardRestrict";
            this.CheckBox_WeldingStandardRestrict.Size = new System.Drawing.Size(96, 16);
            this.CheckBox_WeldingStandardRestrict.TabIndex = 39;
            this.CheckBox_WeldingStandardRestrict.Text = "限制考试标准";
            this.CheckBox_WeldingStandardRestrict.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 4;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.TableLayoutPanel1.Controls.Add(this.Label_ShipClassificationAb, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.TextBox_ShipClassificationAb, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.TextBox_ShipClassificationRemark, 1, 10);
            this.TableLayoutPanel1.Controls.Add(this.Label_ShipClassificationRemark, 0, 10);
            this.TableLayoutPanel1.Controls.Add(this.Label_ShipClassification, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.TextBox_ShipClassification, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.CheckBox_WeldingStandardRestrict, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.ComboBox_WeldingStandard, 3, 0);
            this.TableLayoutPanel1.Controls.Add(this.label_TestCommitteeID, 2, 1);
            this.TableLayoutPanel1.Controls.Add(this.ComboBox_TestCommitteeID, 3, 1);
            this.TableLayoutPanel1.Controls.Add(this.Label_IssueNoRegex, 0, 5);
            this.TableLayoutPanel1.Controls.Add(this.Label_ExaminingNoRegex, 0, 6);
            this.TableLayoutPanel1.Controls.Add(this.TextBox_IssueNoRegex, 1, 5);
            this.TableLayoutPanel1.Controls.Add(this.TextBox_ExaminingNoRegex, 1, 6);
            this.TableLayoutPanel1.Controls.Add(this.Label_CertificateNoRegex, 0, 7);
            this.TableLayoutPanel1.Controls.Add(this.TextBox_CertificateNoRegex, 1, 7);
            this.TableLayoutPanel1.Controls.Add(this.NumericUpDown_IssueNoSignificantDigit, 3, 5);
            this.TableLayoutPanel1.Controls.Add(this.NumericUpDown_ExaminingNoSignificantDigit, 3, 6);
            this.TableLayoutPanel1.Controls.Add(this.NumericUpDown_CertificateNoSignificantDigit, 3, 7);
            this.TableLayoutPanel1.Controls.Add(this.Label_IssueNoSignificantDigit, 2, 5);
            this.TableLayoutPanel1.Controls.Add(this.Label_ExaminingNoSignificantDigit, 2, 6);
            this.TableLayoutPanel1.Controls.Add(this.Label_CertificateNoSignificantDigit, 2, 7);
            this.TableLayoutPanel1.Controls.Add(this.checkBox_YearSeparate, 2, 2);
            this.TableLayoutPanel1.Controls.Add(this.numericUpDown_YearBegin, 3, 2);
            this.TableLayoutPanel1.Controls.Add(this.numericUpDown_YearEnd, 3, 3);
            this.TableLayoutPanel1.Controls.Add(this.label_YearEnd, 2, 3);
            this.TableLayoutPanel1.Controls.Add(this.CheckBox_ShipRestrict, 2, 4);
            this.TableLayoutPanel1.Controls.Add(this.CheckBox_TheorySeparate, 3, 4);
            this.TableLayoutPanel1.Controls.Add(this.MaskedTextBox_NextIssueNo, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.MaskedTextBox_NextExaminingNo, 1, 3);
            this.TableLayoutPanel1.Controls.Add(this.MaskedTextBox_NextCertificateNo, 1, 4);
            this.TableLayoutPanel1.Controls.Add(this.Label_NextIssueNo, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.Label_NextExaminingNo, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.Label_NextCertificateNo, 0, 4);
            this.TableLayoutPanel1.Controls.Add(this.label_ShipClassificationIndex, 2, 8);
            this.TableLayoutPanel1.Controls.Add(this.numericUpDown_ShipClassificationIndex, 3, 8);
            this.TableLayoutPanel1.Controls.Add(this.TextBox_ShipClassificationEnglishName, 1, 9);
            this.TableLayoutPanel1.Controls.Add(this.Label_ShipClassificationEnglishName, 0, 9);
            this.TableLayoutPanel1.Controls.Add(this.checkBox_ProlongQCContinuous, 1, 8);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 11;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091773F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090685F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091773F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091773F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091773F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.091773F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090698F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.087882F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090091F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090868F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(693, 370);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // Label_ShipClassificationAb
            // 
            this.Label_ShipClassificationAb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_ShipClassificationAb.AutoSize = true;
            this.Label_ShipClassificationAb.Location = new System.Drawing.Point(62, 10);
            this.Label_ShipClassificationAb.Name = "Label_ShipClassificationAb";
            this.Label_ShipClassificationAb.Size = new System.Drawing.Size(77, 12);
            this.Label_ShipClassificationAb.TabIndex = 0;
            this.Label_ShipClassificationAb.Text = "船级社缩写：";
            // 
            // TextBox_ShipClassificationAb
            // 
            this.TextBox_ShipClassificationAb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_ShipClassificationAb.Location = new System.Drawing.Point(145, 3);
            this.TextBox_ShipClassificationAb.Name = "TextBox_ShipClassificationAb";
            this.TextBox_ShipClassificationAb.Size = new System.Drawing.Size(224, 21);
            this.TextBox_ShipClassificationAb.TabIndex = 2;
            // 
            // Label_ShipClassification
            // 
            this.Label_ShipClassification.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_ShipClassification.AutoSize = true;
            this.Label_ShipClassification.Location = new System.Drawing.Point(86, 43);
            this.Label_ShipClassification.Name = "Label_ShipClassification";
            this.Label_ShipClassification.Size = new System.Drawing.Size(53, 12);
            this.Label_ShipClassification.TabIndex = 1;
            this.Label_ShipClassification.Text = "船级社：";
            // 
            // TextBox_ShipClassification
            // 
            this.TextBox_ShipClassification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_ShipClassification.Location = new System.Drawing.Point(145, 36);
            this.TextBox_ShipClassification.Name = "TextBox_ShipClassification";
            this.TextBox_ShipClassification.Size = new System.Drawing.Size(224, 21);
            this.TextBox_ShipClassification.TabIndex = 3;
            // 
            // label_TestCommitteeID
            // 
            this.label_TestCommitteeID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_TestCommitteeID.AutoSize = true;
            this.label_TestCommitteeID.Location = new System.Drawing.Point(451, 43);
            this.label_TestCommitteeID.Name = "label_TestCommitteeID";
            this.label_TestCommitteeID.Size = new System.Drawing.Size(65, 12);
            this.label_TestCommitteeID.TabIndex = 6;
            this.label_TestCommitteeID.Text = "存档组织：";
            // 
            // TextBox_IssueNoRegex
            // 
            this.TextBox_IssueNoRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_IssueNoRegex.Location = new System.Drawing.Point(145, 168);
            this.TextBox_IssueNoRegex.Name = "TextBox_IssueNoRegex";
            this.TextBox_IssueNoRegex.Size = new System.Drawing.Size(224, 21);
            this.TextBox_IssueNoRegex.TabIndex = 25;
            // 
            // TextBox_ExaminingNoRegex
            // 
            this.TextBox_ExaminingNoRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_ExaminingNoRegex.Location = new System.Drawing.Point(145, 201);
            this.TextBox_ExaminingNoRegex.Name = "TextBox_ExaminingNoRegex";
            this.TextBox_ExaminingNoRegex.Size = new System.Drawing.Size(224, 21);
            this.TextBox_ExaminingNoRegex.TabIndex = 30;
            // 
            // NumericUpDown_IssueNoSignificantDigit
            // 
            this.NumericUpDown_IssueNoSignificantDigit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumericUpDown_IssueNoSignificantDigit.Location = new System.Drawing.Point(522, 168);
            this.NumericUpDown_IssueNoSignificantDigit.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumericUpDown_IssueNoSignificantDigit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_IssueNoSignificantDigit.Name = "NumericUpDown_IssueNoSignificantDigit";
            this.NumericUpDown_IssueNoSignificantDigit.Size = new System.Drawing.Size(168, 21);
            this.NumericUpDown_IssueNoSignificantDigit.TabIndex = 34;
            this.NumericUpDown_IssueNoSignificantDigit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumericUpDown_ExaminingNoSignificantDigit
            // 
            this.NumericUpDown_ExaminingNoSignificantDigit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumericUpDown_ExaminingNoSignificantDigit.Location = new System.Drawing.Point(522, 201);
            this.NumericUpDown_ExaminingNoSignificantDigit.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumericUpDown_ExaminingNoSignificantDigit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_ExaminingNoSignificantDigit.Name = "NumericUpDown_ExaminingNoSignificantDigit";
            this.NumericUpDown_ExaminingNoSignificantDigit.Size = new System.Drawing.Size(168, 21);
            this.NumericUpDown_ExaminingNoSignificantDigit.TabIndex = 35;
            this.NumericUpDown_ExaminingNoSignificantDigit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumericUpDown_CertificateNoSignificantDigit
            // 
            this.NumericUpDown_CertificateNoSignificantDigit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumericUpDown_CertificateNoSignificantDigit.Location = new System.Drawing.Point(522, 234);
            this.NumericUpDown_CertificateNoSignificantDigit.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumericUpDown_CertificateNoSignificantDigit.Name = "NumericUpDown_CertificateNoSignificantDigit";
            this.NumericUpDown_CertificateNoSignificantDigit.Size = new System.Drawing.Size(168, 21);
            this.NumericUpDown_CertificateNoSignificantDigit.TabIndex = 36;
            this.NumericUpDown_CertificateNoSignificantDigit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label_IssueNoSignificantDigit
            // 
            this.Label_IssueNoSignificantDigit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IssueNoSignificantDigit.AutoSize = true;
            this.Label_IssueNoSignificantDigit.Location = new System.Drawing.Point(415, 175);
            this.Label_IssueNoSignificantDigit.Name = "Label_IssueNoSignificantDigit";
            this.Label_IssueNoSignificantDigit.Size = new System.Drawing.Size(101, 12);
            this.Label_IssueNoSignificantDigit.TabIndex = 12;
            this.Label_IssueNoSignificantDigit.Text = "班级编号数字位：";
            // 
            // Label_ExaminingNoSignificantDigit
            // 
            this.Label_ExaminingNoSignificantDigit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_ExaminingNoSignificantDigit.AutoSize = true;
            this.Label_ExaminingNoSignificantDigit.Location = new System.Drawing.Point(415, 208);
            this.Label_ExaminingNoSignificantDigit.Name = "Label_ExaminingNoSignificantDigit";
            this.Label_ExaminingNoSignificantDigit.Size = new System.Drawing.Size(101, 12);
            this.Label_ExaminingNoSignificantDigit.TabIndex = 14;
            this.Label_ExaminingNoSignificantDigit.Text = "考试编号数字位：";
            // 
            // checkBox_YearSeparate
            // 
            this.checkBox_YearSeparate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBox_YearSeparate.AutoSize = true;
            this.checkBox_YearSeparate.Location = new System.Drawing.Point(384, 74);
            this.checkBox_YearSeparate.Name = "checkBox_YearSeparate";
            this.checkBox_YearSeparate.Size = new System.Drawing.Size(132, 16);
            this.checkBox_YearSeparate.TabIndex = 39;
            this.checkBox_YearSeparate.Text = "年份限制开始年份：";
            this.checkBox_YearSeparate.UseVisualStyleBackColor = true;
            this.checkBox_YearSeparate.CheckedChanged += new System.EventHandler(this.checkBox_YearSeparate_CheckedChanged);
            // 
            // numericUpDown_YearBegin
            // 
            this.numericUpDown_YearBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_YearBegin.Location = new System.Drawing.Point(522, 69);
            this.numericUpDown_YearBegin.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_YearBegin.Minimum = new decimal(new int[] {
            1985,
            0,
            0,
            0});
            this.numericUpDown_YearBegin.Name = "numericUpDown_YearBegin";
            this.numericUpDown_YearBegin.Size = new System.Drawing.Size(168, 21);
            this.numericUpDown_YearBegin.TabIndex = 4;
            this.numericUpDown_YearBegin.Value = new decimal(new int[] {
            1985,
            0,
            0,
            0});
            // 
            // numericUpDown_YearEnd
            // 
            this.numericUpDown_YearEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_YearEnd.Location = new System.Drawing.Point(522, 102);
            this.numericUpDown_YearEnd.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_YearEnd.Minimum = new decimal(new int[] {
            1985,
            0,
            0,
            0});
            this.numericUpDown_YearEnd.Name = "numericUpDown_YearEnd";
            this.numericUpDown_YearEnd.Size = new System.Drawing.Size(168, 21);
            this.numericUpDown_YearEnd.TabIndex = 4;
            this.numericUpDown_YearEnd.Value = new decimal(new int[] {
            1985,
            0,
            0,
            0});
            // 
            // label_YearEnd
            // 
            this.label_YearEnd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_YearEnd.AutoSize = true;
            this.label_YearEnd.Location = new System.Drawing.Point(451, 109);
            this.label_YearEnd.Name = "label_YearEnd";
            this.label_YearEnd.Size = new System.Drawing.Size(65, 12);
            this.label_YearEnd.TabIndex = 12;
            this.label_YearEnd.Text = "结束年份：";
            // 
            // CheckBox_ShipRestrict
            // 
            this.CheckBox_ShipRestrict.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CheckBox_ShipRestrict.AutoSize = true;
            this.CheckBox_ShipRestrict.Location = new System.Drawing.Point(432, 140);
            this.CheckBox_ShipRestrict.Name = "CheckBox_ShipRestrict";
            this.CheckBox_ShipRestrict.Size = new System.Drawing.Size(84, 16);
            this.CheckBox_ShipRestrict.TabIndex = 39;
            this.CheckBox_ShipRestrict.Text = "分船舶管理";
            this.CheckBox_ShipRestrict.UseVisualStyleBackColor = true;
            // 
            // CheckBox_TheorySeparate
            // 
            this.CheckBox_TheorySeparate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CheckBox_TheorySeparate.AutoSize = true;
            this.CheckBox_TheorySeparate.Location = new System.Drawing.Point(582, 140);
            this.CheckBox_TheorySeparate.Name = "CheckBox_TheorySeparate";
            this.CheckBox_TheorySeparate.Size = new System.Drawing.Size(108, 16);
            this.CheckBox_TheorySeparate.TabIndex = 39;
            this.CheckBox_TheorySeparate.Text = "理论与技能分离";
            this.CheckBox_TheorySeparate.UseVisualStyleBackColor = true;
            // 
            // MaskedTextBox_NextIssueNo
            // 
            this.MaskedTextBox_NextIssueNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_NextIssueNo.Location = new System.Drawing.Point(145, 69);
            this.MaskedTextBox_NextIssueNo.Name = "MaskedTextBox_NextIssueNo";
            this.MaskedTextBox_NextIssueNo.Size = new System.Drawing.Size(224, 21);
            this.MaskedTextBox_NextIssueNo.TabIndex = 31;
            // 
            // Label_NextIssueNo
            // 
            this.Label_NextIssueNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_NextIssueNo.AutoSize = true;
            this.Label_NextIssueNo.Location = new System.Drawing.Point(38, 76);
            this.Label_NextIssueNo.Name = "Label_NextIssueNo";
            this.Label_NextIssueNo.Size = new System.Drawing.Size(101, 12);
            this.Label_NextIssueNo.TabIndex = 6;
            this.Label_NextIssueNo.Text = "下一个班级编号：";
            // 
            // label_ShipClassificationIndex
            // 
            this.label_ShipClassificationIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ShipClassificationIndex.AutoSize = true;
            this.label_ShipClassificationIndex.Location = new System.Drawing.Point(451, 274);
            this.label_ShipClassificationIndex.Name = "label_ShipClassificationIndex";
            this.label_ShipClassificationIndex.Size = new System.Drawing.Size(65, 12);
            this.label_ShipClassificationIndex.TabIndex = 3;
            this.label_ShipClassificationIndex.Text = "排序索引：";
            // 
            // numericUpDown_ShipClassificationIndex
            // 
            this.numericUpDown_ShipClassificationIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_ShipClassificationIndex.Location = new System.Drawing.Point(522, 267);
            this.numericUpDown_ShipClassificationIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_ShipClassificationIndex.Name = "numericUpDown_ShipClassificationIndex";
            this.numericUpDown_ShipClassificationIndex.Size = new System.Drawing.Size(168, 21);
            this.numericUpDown_ShipClassificationIndex.TabIndex = 4;
            // 
            // checkBox_ProlongQCContinuous
            // 
            this.checkBox_ProlongQCContinuous.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_ProlongQCContinuous.AutoSize = true;
            this.checkBox_ProlongQCContinuous.Location = new System.Drawing.Point(145, 272);
            this.checkBox_ProlongQCContinuous.Name = "checkBox_ProlongQCContinuous";
            this.checkBox_ProlongQCContinuous.Size = new System.Drawing.Size(132, 16);
            this.checkBox_ProlongQCContinuous.TabIndex = 40;
            this.checkBox_ProlongQCContinuous.Text = "允许证书无限次延期";
            this.checkBox_ProlongQCContinuous.UseVisualStyleBackColor = true;
            // 
            // UserControl_ShipClassificationBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPanel1);
            this.Name = "UserControl_ShipClassificationBase";
            this.Size = new System.Drawing.Size(699, 379);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_IssueNoSignificantDigit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_ExaminingNoSignificantDigit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CertificateNoSignificantDigit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YearBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YearEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ShipClassificationIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label_NextExaminingNo;
        internal System.Windows.Forms.Label Label_NextCertificateNo;
        internal System.Windows.Forms.Label Label_CertificateNoRegex;
        internal System.Windows.Forms.Label Label_ExaminingNoRegex;
        internal System.Windows.Forms.Label Label_IssueNoRegex;
        internal System.Windows.Forms.ComboBox ComboBox_WeldingStandard;
        internal System.Windows.Forms.Label Label_ShipClassificationEnglishName;
        internal System.Windows.Forms.TextBox TextBox_CertificateNoRegex;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_NextExaminingNo;
        internal System.Windows.Forms.TextBox TextBox_ShipClassificationEnglishName;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_NextCertificateNo;
        internal System.Windows.Forms.Label Label_CertificateNoSignificantDigit;
        internal System.Windows.Forms.TextBox TextBox_ShipClassificationRemark;
        internal System.Windows.Forms.Label Label_ShipClassificationRemark;
        internal System.Windows.Forms.ComboBox ComboBox_TestCommitteeID;
        internal System.Windows.Forms.CheckBox CheckBox_WeldingStandardRestrict;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label Label_ExaminingNoSignificantDigit;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_CertificateNoSignificantDigit;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_IssueNoSignificantDigit;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_ExaminingNoSignificantDigit;
        internal System.Windows.Forms.Label Label_ShipClassificationAb;
        internal System.Windows.Forms.Label Label_ShipClassification;
        internal System.Windows.Forms.Label Label_IssueNoSignificantDigit;
        internal System.Windows.Forms.TextBox TextBox_ShipClassificationAb;
        internal System.Windows.Forms.TextBox TextBox_ShipClassification;
        internal System.Windows.Forms.Label Label_NextIssueNo;
        internal System.Windows.Forms.TextBox TextBox_IssueNoRegex;
        internal System.Windows.Forms.TextBox TextBox_ExaminingNoRegex;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_NextIssueNo;
        internal System.Windows.Forms.CheckBox CheckBox_ShipRestrict;
        internal System.Windows.Forms.CheckBox CheckBox_TheorySeparate;
        internal System.Windows.Forms.CheckBox checkBox_YearSeparate;
        private System.Windows.Forms.NumericUpDown numericUpDown_YearBegin;
        private System.Windows.Forms.NumericUpDown numericUpDown_YearEnd;
        internal System.Windows.Forms.Label label_YearEnd;
        private System.Windows.Forms.Label label_ShipClassificationIndex;
        internal System.Windows.Forms.Label label_TestCommitteeID;
        private System.Windows.Forms.NumericUpDown numericUpDown_ShipClassificationIndex;
        private System.Windows.Forms.CheckBox checkBox_ProlongQCContinuous;

    }
}
