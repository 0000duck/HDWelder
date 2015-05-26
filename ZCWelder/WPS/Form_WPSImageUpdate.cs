using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.SystemInformation;
using System.IO;
using ZCCL.ClassBase;

namespace ZCWelder.WPS
{
    public partial class Form_WPSImageUpdate : Form
    {
        public Class_WPSImage myClass_WPSImage;
        public bool bool_Add;
        
        public Form_WPSImageUpdate()
        {
            InitializeComponent();
        }

        private void Form_WPSImageUpdate_Load(object sender, EventArgs e)
        {
            Class_Public.InitializeComboBox(this.comboBox_WPSImageGroup, Enum_DataTableSecond.ImageGroup.ToString(), "ImageGroup", "ImageGroup");
            this.textBox_WPSID.Text = myClass_WPSImage.WPSID;
            if (this.bool_Add)
            {
                
            }
            else
            {
                this.textBox_WPSImageID.Text = this.myClass_WPSImage.WPSImageID.ToString();
                this.textBox_WPSImageName.Text = this.myClass_WPSImage.WPSImageName;
                this.textBox_WPSImageRemark.Text = this.myClass_WPSImage.WPSImageRemark;
                this.comboBox_WPSImageGroup.SelectedValue = this.myClass_WPSImage.WPSImageGroup;
                this.pictureBox_WPSImage.Image = this.myClass_WPSImage.WPSImage;
            }

        }

        private void button_WPSImageUpLoad_Click(object sender, EventArgs e)
        {
            this.openFileDialog_WPSImage.FileName = "";
            this.openFileDialog_WPSImage.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            this.openFileDialog_WPSImage.RestoreDirectory = true;
            if (this.openFileDialog_WPSImage.ShowDialog() == DialogResult.OK)
            {
                //Stream myStream = File.Open(this.openFileDialog_WPSImage.FileName, FileMode.Open , FileAccess.Read );
                this.pictureBox_WPSImage.Image = Image.FromFile(this.openFileDialog_WPSImage.FileName);
                this.textBox_WPSImageName.Text = Path.GetFileName(this.openFileDialog_WPSImage.FileName);

            }
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            myClass_WPSImage.WPSImageGroup = this.comboBox_WPSImageGroup.SelectedValue.ToString();
            myClass_WPSImage.WPSImageName = this.textBox_WPSImageName.Text;
            myClass_WPSImage.WPSImageRemark = this.textBox_WPSImageRemark.Text;
            myClass_WPSImage.WPSImage = this.pictureBox_WPSImage.Image;
            this.pictureBox_WPSImage.Image = null;
            String str_ErrMessage;
            str_ErrMessage = myClass_WPSImage.CheckField();
            if (str_ErrMessage != null)
            {
                this.label_ErrMessage.Text = str_ErrMessage;
                this.DialogResult = DialogResult.None;
                return;
            }
            if (this.bool_Add)
            {
                myClass_WPSImage.AddAndModify(Enum_zwjKindofUpdate.Add );
            }
            else
            {
                myClass_WPSImage.AddAndModify(Enum_zwjKindofUpdate.Modify );
            }
        }
    }
}