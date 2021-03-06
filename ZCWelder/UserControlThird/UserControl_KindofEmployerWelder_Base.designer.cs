namespace ZCWelder.UserControlThird
{
    partial class UserControl_KindofEmployerWelder_Base
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
            this.Label_WorkerID = new System.Windows.Forms.Label();
            this.TextBox_WorkerID = new System.Windows.Forms.TextBox();
            this.Label_Sex = new System.Windows.Forms.Label();
            this.Label_WelderEnglishName = new System.Windows.Forms.Label();
            this.CheckBox_LaborServiceTeam = new System.Windows.Forms.CheckBox();
            this.CheckBox_WorkPlace = new System.Windows.Forms.CheckBox();
            this.CheckBox_Department = new System.Windows.Forms.CheckBox();
            this.Label_Employer = new System.Windows.Forms.Label();
            this.ComboBox_LaborServiceTeam = new System.Windows.Forms.ComboBox();
            this.ComboBox_WorkPlace = new System.Windows.Forms.ComboBox();
            this.ComboBox_Department = new System.Windows.Forms.ComboBox();
            this.ComboBox_Employer = new System.Windows.Forms.ComboBox();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CheckBox_Sex = new System.Windows.Forms.CheckBox();
            this.Label_WelderName = new System.Windows.Forms.Label();
            this.MaskedTextBox_IdentificationCard = new System.Windows.Forms.MaskedTextBox();
            this.TextBox_WelderName = new System.Windows.Forms.TextBox();
            this.Label_WeldingBeginning = new System.Windows.Forms.Label();
            this.TextBox_WelderRemark = new System.Windows.Forms.TextBox();
            this.Label_WelderRemark = new System.Windows.Forms.Label();
            this.DateTimePicker_WeldingBeinning = new System.Windows.Forms.DateTimePicker();
            this.Label_IdentificationCard = new System.Windows.Forms.Label();
            this.ComboBox_Schooling = new System.Windows.Forms.ComboBox();
            this.Label_Schooling = new System.Windows.Forms.Label();
            this.Button_IdentificationCardConvert = new System.Windows.Forms.Button();
            this.textBox_WelderEnglishName = new System.Windows.Forms.TextBox();
            this.label_KindofEmployerWelderID = new System.Windows.Forms.Label();
            this.label_KindofEmployer = new System.Windows.Forms.Label();
            this.textBox_KindofEmployerWelderID = new System.Windows.Forms.TextBox();
            this.textBox_KindofEmployer = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_WorkerID
            // 
            this.Label_WorkerID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WorkerID.AutoSize = true;
            this.Label_WorkerID.Location = new System.Drawing.Point(30, 147);
            this.Label_WorkerID.Name = "Label_WorkerID";
            this.Label_WorkerID.Size = new System.Drawing.Size(41, 12);
            this.Label_WorkerID.TabIndex = 133;
            this.Label_WorkerID.Text = "工号：";
            // 
            // TextBox_WorkerID
            // 
            this.TextBox_WorkerID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WorkerID.Location = new System.Drawing.Point(77, 139);
            this.TextBox_WorkerID.MaxLength = 10;
            this.TextBox_WorkerID.Name = "TextBox_WorkerID";
            this.TextBox_WorkerID.Size = new System.Drawing.Size(140, 21);
            this.TextBox_WorkerID.TabIndex = 4;
            // 
            // Label_Sex
            // 
            this.Label_Sex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Sex.AutoSize = true;
            this.Label_Sex.Location = new System.Drawing.Point(30, 113);
            this.Label_Sex.Name = "Label_Sex";
            this.Label_Sex.Size = new System.Drawing.Size(41, 12);
            this.Label_Sex.TabIndex = 139;
            this.Label_Sex.Text = "性别：";
            // 
            // Label_WelderEnglishName
            // 
            this.Label_WelderEnglishName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WelderEnglishName.AutoSize = true;
            this.Label_WelderEnglishName.Location = new System.Drawing.Point(6, 215);
            this.Label_WelderEnglishName.Name = "Label_WelderEnglishName";
            this.Label_WelderEnglishName.Size = new System.Drawing.Size(65, 12);
            this.Label_WelderEnglishName.TabIndex = 149;
            this.Label_WelderEnglishName.Text = "英文名称：";
            // 
            // CheckBox_LaborServiceTeam
            // 
            this.CheckBox_LaborServiceTeam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CheckBox_LaborServiceTeam.AutoSize = true;
            this.CheckBox_LaborServiceTeam.Location = new System.Drawing.Point(267, 213);
            this.CheckBox_LaborServiceTeam.Name = "CheckBox_LaborServiceTeam";
            this.CheckBox_LaborServiceTeam.Size = new System.Drawing.Size(72, 16);
            this.CheckBox_LaborServiceTeam.TabIndex = 13;
            this.CheckBox_LaborServiceTeam.Text = "劳务队：";
            this.CheckBox_LaborServiceTeam.UseVisualStyleBackColor = true;
            // 
            // CheckBox_WorkPlace
            // 
            this.CheckBox_WorkPlace.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CheckBox_WorkPlace.AutoSize = true;
            this.CheckBox_WorkPlace.Checked = true;
            this.CheckBox_WorkPlace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_WorkPlace.Location = new System.Drawing.Point(267, 179);
            this.CheckBox_WorkPlace.Name = "CheckBox_WorkPlace";
            this.CheckBox_WorkPlace.Size = new System.Drawing.Size(72, 16);
            this.CheckBox_WorkPlace.TabIndex = 11;
            this.CheckBox_WorkPlace.Text = "作业区：";
            this.CheckBox_WorkPlace.UseVisualStyleBackColor = true;
            this.CheckBox_WorkPlace.CheckedChanged += new System.EventHandler(this.CheckBox_WorkPlace_CheckedChanged);
            // 
            // CheckBox_Department
            // 
            this.CheckBox_Department.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CheckBox_Department.AutoSize = true;
            this.CheckBox_Department.Checked = true;
            this.CheckBox_Department.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Department.Location = new System.Drawing.Point(279, 145);
            this.CheckBox_Department.Name = "CheckBox_Department";
            this.CheckBox_Department.Size = new System.Drawing.Size(60, 16);
            this.CheckBox_Department.TabIndex = 9;
            this.CheckBox_Department.Text = "部门：";
            this.CheckBox_Department.UseVisualStyleBackColor = true;
            this.CheckBox_Department.CheckedChanged += new System.EventHandler(this.CheckBox_Department_CheckedChanged);
            // 
            // Label_Employer
            // 
            this.Label_Employer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Employer.AutoSize = true;
            this.Label_Employer.Location = new System.Drawing.Point(298, 113);
            this.Label_Employer.Name = "Label_Employer";
            this.Label_Employer.Size = new System.Drawing.Size(41, 12);
            this.Label_Employer.TabIndex = 126;
            this.Label_Employer.Text = "公司：";
            // 
            // ComboBox_LaborServiceTeam
            // 
            this.ComboBox_LaborServiceTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_LaborServiceTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_LaborServiceTeam.FormattingEnabled = true;
            this.ComboBox_LaborServiceTeam.Location = new System.Drawing.Point(345, 207);
            this.ComboBox_LaborServiceTeam.Name = "ComboBox_LaborServiceTeam";
            this.ComboBox_LaborServiceTeam.Size = new System.Drawing.Size(178, 20);
            this.ComboBox_LaborServiceTeam.TabIndex = 14;
            // 
            // ComboBox_WorkPlace
            // 
            this.ComboBox_WorkPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_WorkPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_WorkPlace.FormattingEnabled = true;
            this.ComboBox_WorkPlace.Location = new System.Drawing.Point(345, 173);
            this.ComboBox_WorkPlace.Name = "ComboBox_WorkPlace";
            this.ComboBox_WorkPlace.Size = new System.Drawing.Size(178, 20);
            this.ComboBox_WorkPlace.TabIndex = 12;
            // 
            // ComboBox_Department
            // 
            this.ComboBox_Department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Department.FormattingEnabled = true;
            this.ComboBox_Department.Location = new System.Drawing.Point(345, 139);
            this.ComboBox_Department.Name = "ComboBox_Department";
            this.ComboBox_Department.Size = new System.Drawing.Size(178, 20);
            this.ComboBox_Department.TabIndex = 10;
            this.ComboBox_Department.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Department_SelectedIndexChanged);
            // 
            // ComboBox_Employer
            // 
            this.ComboBox_Employer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_Employer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Employer.DropDownWidth = 250;
            this.ComboBox_Employer.FormattingEnabled = true;
            this.ComboBox_Employer.Location = new System.Drawing.Point(345, 105);
            this.ComboBox_Employer.Name = "ComboBox_Employer";
            this.ComboBox_Employer.Size = new System.Drawing.Size(178, 20);
            this.ComboBox_Employer.TabIndex = 8;
            this.ComboBox_Employer.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Employer_SelectedIndexChanged);
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 4;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.TableLayoutPanel2.Controls.Add(this.CheckBox_Sex, 1, 3);
            this.TableLayoutPanel2.Controls.Add(this.Label_WelderName, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.MaskedTextBox_IdentificationCard, 1, 2);
            this.TableLayoutPanel2.Controls.Add(this.TextBox_WelderName, 1, 1);
            this.TableLayoutPanel2.Controls.Add(this.Label_WeldingBeginning, 2, 1);
            this.TableLayoutPanel2.Controls.Add(this.TextBox_WelderRemark, 1, 7);
            this.TableLayoutPanel2.Controls.Add(this.Label_WelderRemark, 0, 7);
            this.TableLayoutPanel2.Controls.Add(this.DateTimePicker_WeldingBeinning, 3, 1);
            this.TableLayoutPanel2.Controls.Add(this.Label_IdentificationCard, 0, 2);
            this.TableLayoutPanel2.Controls.Add(this.ComboBox_Schooling, 1, 5);
            this.TableLayoutPanel2.Controls.Add(this.Label_Schooling, 0, 5);
            this.TableLayoutPanel2.Controls.Add(this.Label_WorkerID, 0, 4);
            this.TableLayoutPanel2.Controls.Add(this.TextBox_WorkerID, 1, 4);
            this.TableLayoutPanel2.Controls.Add(this.Label_Sex, 0, 3);
            this.TableLayoutPanel2.Controls.Add(this.Label_WelderEnglishName, 0, 6);
            this.TableLayoutPanel2.Controls.Add(this.CheckBox_LaborServiceTeam, 2, 6);
            this.TableLayoutPanel2.Controls.Add(this.CheckBox_WorkPlace, 2, 5);
            this.TableLayoutPanel2.Controls.Add(this.CheckBox_Department, 2, 4);
            this.TableLayoutPanel2.Controls.Add(this.Label_Employer, 2, 3);
            this.TableLayoutPanel2.Controls.Add(this.ComboBox_LaborServiceTeam, 3, 6);
            this.TableLayoutPanel2.Controls.Add(this.ComboBox_WorkPlace, 3, 5);
            this.TableLayoutPanel2.Controls.Add(this.ComboBox_Department, 3, 4);
            this.TableLayoutPanel2.Controls.Add(this.ComboBox_Employer, 3, 3);
            this.TableLayoutPanel2.Controls.Add(this.Button_IdentificationCardConvert, 2, 2);
            this.TableLayoutPanel2.Controls.Add(this.textBox_WelderEnglishName, 1, 6);
            this.TableLayoutPanel2.Controls.Add(this.label_KindofEmployerWelderID, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.label_KindofEmployer, 2, 0);
            this.TableLayoutPanel2.Controls.Add(this.textBox_KindofEmployerWelderID, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.textBox_KindofEmployer, 3, 0);
            this.TableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 8;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50328F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50167F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(526, 279);
            this.TableLayoutPanel2.TabIndex = 0;
            // 
            // CheckBox_Sex
            // 
            this.CheckBox_Sex.AutoSize = true;
            this.CheckBox_Sex.Checked = true;
            this.CheckBox_Sex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Sex.Location = new System.Drawing.Point(77, 105);
            this.CheckBox_Sex.Name = "CheckBox_Sex";
            this.CheckBox_Sex.Size = new System.Drawing.Size(102, 16);
            this.CheckBox_Sex.TabIndex = 3;
            this.CheckBox_Sex.Text = "男 (选空为女)";
            this.CheckBox_Sex.UseVisualStyleBackColor = true;
            // 
            // Label_WelderName
            // 
            this.Label_WelderName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WelderName.AutoSize = true;
            this.Label_WelderName.Location = new System.Drawing.Point(30, 45);
            this.Label_WelderName.Name = "Label_WelderName";
            this.Label_WelderName.Size = new System.Drawing.Size(41, 12);
            this.Label_WelderName.TabIndex = 114;
            this.Label_WelderName.Text = "姓名：";
            // 
            // MaskedTextBox_IdentificationCard
            // 
            this.MaskedTextBox_IdentificationCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_IdentificationCard.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaskedTextBox_IdentificationCard.Location = new System.Drawing.Point(77, 71);
            this.MaskedTextBox_IdentificationCard.Mask = "00000000000000000A";
            this.MaskedTextBox_IdentificationCard.Name = "MaskedTextBox_IdentificationCard";
            this.MaskedTextBox_IdentificationCard.Size = new System.Drawing.Size(140, 21);
            this.MaskedTextBox_IdentificationCard.TabIndex = 1;
            // 
            // TextBox_WelderName
            // 
            this.TextBox_WelderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WelderName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_WelderName.Location = new System.Drawing.Point(77, 37);
            this.TextBox_WelderName.MaxLength = 10;
            this.TextBox_WelderName.Name = "TextBox_WelderName";
            this.TextBox_WelderName.Size = new System.Drawing.Size(140, 21);
            this.TextBox_WelderName.TabIndex = 0;
            // 
            // Label_WeldingBeginning
            // 
            this.Label_WeldingBeginning.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WeldingBeginning.AutoSize = true;
            this.Label_WeldingBeginning.Location = new System.Drawing.Point(226, 45);
            this.Label_WeldingBeginning.Name = "Label_WeldingBeginning";
            this.Label_WeldingBeginning.Size = new System.Drawing.Size(113, 12);
            this.Label_WeldingBeginning.TabIndex = 118;
            this.Label_WeldingBeginning.Text = "从事焊接开始日期：";
            // 
            // TextBox_WelderRemark
            // 
            this.TableLayoutPanel2.SetColumnSpan(this.TextBox_WelderRemark, 3);
            this.TextBox_WelderRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WelderRemark.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_WelderRemark.Location = new System.Drawing.Point(77, 241);
            this.TextBox_WelderRemark.MaxLength = 250;
            this.TextBox_WelderRemark.Name = "TextBox_WelderRemark";
            this.TextBox_WelderRemark.Size = new System.Drawing.Size(446, 21);
            this.TextBox_WelderRemark.TabIndex = 15;
            // 
            // Label_WelderRemark
            // 
            this.Label_WelderRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WelderRemark.AutoSize = true;
            this.Label_WelderRemark.Location = new System.Drawing.Point(30, 252);
            this.Label_WelderRemark.Name = "Label_WelderRemark";
            this.Label_WelderRemark.Size = new System.Drawing.Size(41, 12);
            this.Label_WelderRemark.TabIndex = 137;
            this.Label_WelderRemark.Text = "备注：";
            // 
            // DateTimePicker_WeldingBeinning
            // 
            this.DateTimePicker_WeldingBeinning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTimePicker_WeldingBeinning.Location = new System.Drawing.Point(345, 37);
            this.DateTimePicker_WeldingBeinning.Name = "DateTimePicker_WeldingBeinning";
            this.DateTimePicker_WeldingBeinning.Size = new System.Drawing.Size(178, 21);
            this.DateTimePicker_WeldingBeinning.TabIndex = 7;
            // 
            // Label_IdentificationCard
            // 
            this.Label_IdentificationCard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IdentificationCard.AutoSize = true;
            this.Label_IdentificationCard.Location = new System.Drawing.Point(18, 79);
            this.Label_IdentificationCard.Name = "Label_IdentificationCard";
            this.Label_IdentificationCard.Size = new System.Drawing.Size(53, 12);
            this.Label_IdentificationCard.TabIndex = 115;
            this.Label_IdentificationCard.Text = "身份证：";
            // 
            // ComboBox_Schooling
            // 
            this.ComboBox_Schooling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_Schooling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Schooling.FormattingEnabled = true;
            this.ComboBox_Schooling.Location = new System.Drawing.Point(77, 173);
            this.ComboBox_Schooling.Name = "ComboBox_Schooling";
            this.ComboBox_Schooling.Size = new System.Drawing.Size(140, 20);
            this.ComboBox_Schooling.TabIndex = 5;
            // 
            // Label_Schooling
            // 
            this.Label_Schooling.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_Schooling.AutoSize = true;
            this.Label_Schooling.Location = new System.Drawing.Point(30, 181);
            this.Label_Schooling.Name = "Label_Schooling";
            this.Label_Schooling.Size = new System.Drawing.Size(41, 12);
            this.Label_Schooling.TabIndex = 117;
            this.Label_Schooling.Text = "学历：";
            // 
            // Button_IdentificationCardConvert
            // 
            this.Button_IdentificationCardConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_IdentificationCardConvert.Location = new System.Drawing.Point(223, 71);
            this.Button_IdentificationCardConvert.Name = "Button_IdentificationCardConvert";
            this.Button_IdentificationCardConvert.Size = new System.Drawing.Size(116, 28);
            this.Button_IdentificationCardConvert.TabIndex = 2;
            this.Button_IdentificationCardConvert.Text = "转为18位身份证号";
            this.Button_IdentificationCardConvert.UseVisualStyleBackColor = true;
            this.Button_IdentificationCardConvert.Click += new System.EventHandler(this.Button_IdentificationCardConvert_Click);
            // 
            // textBox_WelderEnglishName
            // 
            this.textBox_WelderEnglishName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WelderEnglishName.Location = new System.Drawing.Point(77, 207);
            this.textBox_WelderEnglishName.MaxLength = 10;
            this.textBox_WelderEnglishName.Name = "textBox_WelderEnglishName";
            this.textBox_WelderEnglishName.Size = new System.Drawing.Size(140, 21);
            this.textBox_WelderEnglishName.TabIndex = 6;
            // 
            // label_KindofEmployerWelderID
            // 
            this.label_KindofEmployerWelderID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_KindofEmployerWelderID.AutoSize = true;
            this.label_KindofEmployerWelderID.Location = new System.Drawing.Point(30, 11);
            this.label_KindofEmployerWelderID.Name = "label_KindofEmployerWelderID";
            this.label_KindofEmployerWelderID.Size = new System.Drawing.Size(41, 12);
            this.label_KindofEmployerWelderID.TabIndex = 114;
            this.label_KindofEmployerWelderID.Text = "编号：";
            // 
            // label_KindofEmployer
            // 
            this.label_KindofEmployer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_KindofEmployer.AutoSize = true;
            this.label_KindofEmployer.Location = new System.Drawing.Point(274, 11);
            this.label_KindofEmployer.Name = "label_KindofEmployer";
            this.label_KindofEmployer.Size = new System.Drawing.Size(65, 12);
            this.label_KindofEmployer.TabIndex = 114;
            this.label_KindofEmployer.Text = "报考单位：";
            // 
            // textBox_KindofEmployerWelderID
            // 
            this.textBox_KindofEmployerWelderID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_KindofEmployerWelderID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_KindofEmployerWelderID.Location = new System.Drawing.Point(77, 3);
            this.textBox_KindofEmployerWelderID.MaxLength = 10;
            this.textBox_KindofEmployerWelderID.Name = "textBox_KindofEmployerWelderID";
            this.textBox_KindofEmployerWelderID.ReadOnly = true;
            this.textBox_KindofEmployerWelderID.Size = new System.Drawing.Size(140, 21);
            this.textBox_KindofEmployerWelderID.TabIndex = 16;
            // 
            // textBox_KindofEmployer
            // 
            this.textBox_KindofEmployer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_KindofEmployer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_KindofEmployer.Location = new System.Drawing.Point(345, 3);
            this.textBox_KindofEmployer.MaxLength = 10;
            this.textBox_KindofEmployer.Name = "textBox_KindofEmployer";
            this.textBox_KindofEmployer.ReadOnly = true;
            this.textBox_KindofEmployer.Size = new System.Drawing.Size(178, 21);
            this.textBox_KindofEmployer.TabIndex = 17;
            // 
            // UserControl_KindofEmployerWelder_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPanel2);
            this.Name = "UserControl_KindofEmployerWelder_Base";
            this.Size = new System.Drawing.Size(535, 288);
            this.Load += new System.EventHandler(this.UserControl_KindofEmployerWelder_Base_Load);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label_WorkerID;
        internal System.Windows.Forms.TextBox TextBox_WorkerID;
        internal System.Windows.Forms.Label Label_Sex;
        internal System.Windows.Forms.Label Label_WelderEnglishName;
        internal System.Windows.Forms.CheckBox CheckBox_LaborServiceTeam;
        internal System.Windows.Forms.CheckBox CheckBox_WorkPlace;
        internal System.Windows.Forms.CheckBox CheckBox_Department;
        internal System.Windows.Forms.Label Label_Employer;
        internal System.Windows.Forms.ComboBox ComboBox_LaborServiceTeam;
        internal System.Windows.Forms.ComboBox ComboBox_WorkPlace;
        internal System.Windows.Forms.ComboBox ComboBox_Department;
        internal System.Windows.Forms.ComboBox ComboBox_Employer;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.CheckBox CheckBox_Sex;
        internal System.Windows.Forms.Label Label_WelderName;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_IdentificationCard;
        internal System.Windows.Forms.TextBox TextBox_WelderName;
        internal System.Windows.Forms.Label Label_WeldingBeginning;
        internal System.Windows.Forms.TextBox TextBox_WelderRemark;
        internal System.Windows.Forms.Label Label_WelderRemark;
        internal System.Windows.Forms.DateTimePicker DateTimePicker_WeldingBeinning;
        internal System.Windows.Forms.Label Label_IdentificationCard;
        internal System.Windows.Forms.ComboBox ComboBox_Schooling;
        internal System.Windows.Forms.Label Label_Schooling;
        internal System.Windows.Forms.Button Button_IdentificationCardConvert;
        internal System.Windows.Forms.TextBox textBox_WelderEnglishName;
        internal System.Windows.Forms.Label label_KindofEmployerWelderID;
        internal System.Windows.Forms.Label label_KindofEmployer;
        internal System.Windows.Forms.TextBox textBox_KindofEmployerWelderID;
        internal System.Windows.Forms.TextBox textBox_KindofEmployer;

    }
}
