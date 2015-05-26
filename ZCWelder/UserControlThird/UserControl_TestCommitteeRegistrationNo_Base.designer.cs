namespace ZCWelder.UserControlThird
{
    partial class UserControl_TestCommitteeRegistrationNo_Base
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_WelderName = new System.Windows.Forms.Label();
            this.TextBox_WelderName = new System.Windows.Forms.TextBox();
            this.MaskedTextBox_IdentificationCard = new System.Windows.Forms.MaskedTextBox();
            this.Label_IdentificationCard = new System.Windows.Forms.Label();
            this.Label_RegistrationNo = new System.Windows.Forms.Label();
            this.MaskedTextBox_RegistrationNo = new System.Windows.Forms.MaskedTextBox();
            this.Label_TestCommitteeID = new System.Windows.Forms.Label();
            this.ComboBox_TestCommitteeID = new System.Windows.Forms.ComboBox();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.TableLayoutPanel1.Controls.Add(this.Label_WelderName, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.TextBox_WelderName, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.MaskedTextBox_IdentificationCard, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.Label_IdentificationCard, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.Label_RegistrationNo, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.MaskedTextBox_RegistrationNo, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.Label_TestCommitteeID, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.ComboBox_TestCommitteeID, 1, 3);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 4;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(283, 135);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // Label_WelderName
            // 
            this.Label_WelderName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_WelderName.AutoSize = true;
            this.Label_WelderName.Location = new System.Drawing.Point(31, 10);
            this.Label_WelderName.Name = "Label_WelderName";
            this.Label_WelderName.Size = new System.Drawing.Size(41, 12);
            this.Label_WelderName.TabIndex = 144;
            this.Label_WelderName.Text = "姓名：";
            // 
            // TextBox_WelderName
            // 
            this.TextBox_WelderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_WelderName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TextBox_WelderName.Location = new System.Drawing.Point(78, 3);
            this.TextBox_WelderName.MaxLength = 10;
            this.TextBox_WelderName.Name = "TextBox_WelderName";
            this.TextBox_WelderName.ReadOnly = true;
            this.TextBox_WelderName.Size = new System.Drawing.Size(202, 21);
            this.TextBox_WelderName.TabIndex = 146;
            // 
            // MaskedTextBox_IdentificationCard
            // 
            this.MaskedTextBox_IdentificationCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_IdentificationCard.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaskedTextBox_IdentificationCard.Location = new System.Drawing.Point(78, 36);
            this.MaskedTextBox_IdentificationCard.Mask = "00000000000000000A";
            this.MaskedTextBox_IdentificationCard.Name = "MaskedTextBox_IdentificationCard";
            this.MaskedTextBox_IdentificationCard.ReadOnly = true;
            this.MaskedTextBox_IdentificationCard.Size = new System.Drawing.Size(202, 21);
            this.MaskedTextBox_IdentificationCard.TabIndex = 147;
            // 
            // Label_IdentificationCard
            // 
            this.Label_IdentificationCard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_IdentificationCard.AutoSize = true;
            this.Label_IdentificationCard.Location = new System.Drawing.Point(19, 43);
            this.Label_IdentificationCard.Name = "Label_IdentificationCard";
            this.Label_IdentificationCard.Size = new System.Drawing.Size(53, 12);
            this.Label_IdentificationCard.TabIndex = 148;
            this.Label_IdentificationCard.Text = "身份证：";
            // 
            // Label_RegistrationNo
            // 
            this.Label_RegistrationNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_RegistrationNo.AutoSize = true;
            this.Label_RegistrationNo.Location = new System.Drawing.Point(7, 76);
            this.Label_RegistrationNo.Name = "Label_RegistrationNo";
            this.Label_RegistrationNo.Size = new System.Drawing.Size(65, 12);
            this.Label_RegistrationNo.TabIndex = 149;
            this.Label_RegistrationNo.Text = "存档编号：";
            // 
            // MaskedTextBox_RegistrationNo
            // 
            this.MaskedTextBox_RegistrationNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskedTextBox_RegistrationNo.Location = new System.Drawing.Point(78, 69);
            this.MaskedTextBox_RegistrationNo.Name = "MaskedTextBox_RegistrationNo";
            this.MaskedTextBox_RegistrationNo.ReadOnly = true;
            this.MaskedTextBox_RegistrationNo.Size = new System.Drawing.Size(202, 21);
            this.MaskedTextBox_RegistrationNo.TabIndex = 150;
            // 
            // Label_TestCommitteeID
            // 
            this.Label_TestCommitteeID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label_TestCommitteeID.AutoSize = true;
            this.Label_TestCommitteeID.Location = new System.Drawing.Point(7, 111);
            this.Label_TestCommitteeID.Name = "Label_TestCommitteeID";
            this.Label_TestCommitteeID.Size = new System.Drawing.Size(65, 12);
            this.Label_TestCommitteeID.TabIndex = 151;
            this.Label_TestCommitteeID.Text = "存档组织：";
            // 
            // ComboBox_TestCommitteeID
            // 
            this.ComboBox_TestCommitteeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox_TestCommitteeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_TestCommitteeID.FormattingEnabled = true;
            this.ComboBox_TestCommitteeID.Location = new System.Drawing.Point(78, 102);
            this.ComboBox_TestCommitteeID.Name = "ComboBox_TestCommitteeID";
            this.ComboBox_TestCommitteeID.Size = new System.Drawing.Size(202, 20);
            this.ComboBox_TestCommitteeID.TabIndex = 152;
            this.ComboBox_TestCommitteeID.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TestCommitteeID_SelectedIndexChanged);
            // 
            // UserControl_TestCommitteeRegistrationNo_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPanel1);
            this.Name = "UserControl_TestCommitteeRegistrationNo_Base";
            this.Size = new System.Drawing.Size(291, 145);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label Label_WelderName;
        internal System.Windows.Forms.TextBox TextBox_WelderName;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_IdentificationCard;
        internal System.Windows.Forms.Label Label_IdentificationCard;
        internal System.Windows.Forms.Label Label_RegistrationNo;
        internal System.Windows.Forms.MaskedTextBox MaskedTextBox_RegistrationNo;
        internal System.Windows.Forms.Label Label_TestCommitteeID;
        internal System.Windows.Forms.ComboBox ComboBox_TestCommitteeID;

    }
}
