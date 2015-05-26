using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using System.Data.SqlClient;
using ZCCL.ClassBase;
using ZCWelder.ZCWelderPicture;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WelderPictureBase : UserControl
    {
        private string str_IdentificationCard;
        public bool bool_CanModifyWelderPicture=true;

        public UserControl_WelderPictureBase()
        {
            InitializeComponent();
        }

        private void UserControl_WelderPictureBase_Load(object sender, EventArgs e)
        {

        }

        public void InitWelderPicture(string str_IdentificationCard)
        {
            this.str_IdentificationCard = str_IdentificationCard;
            if (string.IsNullOrEmpty(this.str_IdentificationCard))
            {
                this.pictureBox_Welder.Image = null;
            }
            else
            {
                this.pictureBox_Welder.Image = Class_Welder.GetWelderPicture(str_IdentificationCard);
            }
        }

        private void button_UploadPicture_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.str_IdentificationCard))
            {
                return;
            }
            if (this.pictureBox_Welder.Image != null)
            {
                if (this.bool_CanModifyWelderPicture)
                {
                    if (MessageBox.Show("�ú���������Ƭ��ȷ�������ϴ���", "ȷ�ϴ���", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("�ñ�����λ�����޸���Ƭ��");
                    return;
                }
            }
            
            this.pictureBox_Welder.Image = Class_Welder.SetWelderPicture(this.str_IdentificationCard );
        }

        private void button_DownLoadPicture_Click(object sender, EventArgs e)
        {
            if (this.pictureBox_Welder.Image != null)
            {
                SaveFileDialog mySaveFileDialog = new SaveFileDialog();
                mySaveFileDialog.Filter = "JPG files (*.JPG)|*.JPG";
                Class_Welder myClass_Welder = new Class_Welder(this.str_IdentificationCard);
                mySaveFileDialog.FileName = string.Format("{0}_{1}", myClass_Welder.WelderName, myClass_Welder.IdentificationCard);
                mySaveFileDialog.RestoreDirectory = true;
                if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBox_Welder.Image.Save(mySaveFileDialog.FileName);
                }
            }

        }

        private void button_DeletePicture_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.str_IdentificationCard))
            {
                return;
            }
            if (MessageBox.Show("ȷ��ɾ����", "ȷ�ϴ���", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Class_Welder.DeleteWelderPicture(this.str_IdentificationCard);
                this.pictureBox_Welder.Image = null;
            }

        }

        private void button_LoadImageFromHR_Click(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.WebServiceStartUp)
            {
                return;
            }
            if (string.IsNullOrEmpty(this.str_IdentificationCard))
            {
                return;
            }
            if (this.pictureBox_Welder.Image != null)
            {
                if (this.bool_CanModifyWelderPicture)
                {
                    if (MessageBox.Show("�ú���������Ƭ��ȷ�������ϴ���", "ȷ�ϴ���", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("�ñ�����λ�����޸���Ƭ��");
                    return;
                }
            }

            SqlConnection myconn_hdhr =new SqlConnection(Properties.Settings.Default.zwjConnhdhr);
            SqlCommand myCmd_Temp = new SqlCommand(null,myconn_hdhr);
            myCmd_Temp.CommandText = "select photo from v_psninfo_to_hangong where ryid='" + this.str_IdentificationCard + "'";
            myconn_hdhr.Open();
            SqlDataReader mySqlDataReader= myCmd_Temp.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                Class_Welder myClass_Welder = new Class_Welder();
                myClass_Welder.IdentificationCard = str_IdentificationCard;
                if (myClass_Welder.FillData() == false)
                {
                    MessageBox.Show("�ú���Ŀǰ��δ��ʽ�Ǽǵ�ϵͳ�У�����ڱ�����λ����Ӻ�����Ƭ������ͬ���������ݣ�");
                    break; ;
                }               
                if (mySqlDataReader["photo"]==DBNull.Value )
                {
                    MessageBox.Show("����Դû����Ƭ��");
                    break;
                }
                byte[] mybyte;
                mybyte = (byte[])mySqlDataReader["photo"];
                System.IO.MemoryStream myMemoryStream = new System.IO.MemoryStream();
                myMemoryStream.Write(mybyte, 0, mybyte.Length);
                this.pictureBox_Welder.Image  = Image.FromStream(myMemoryStream);

                WelderPicture myWelderPicture = new WelderPicture();
                myWelderPicture.SetWelderPicture(mybyte, str_IdentificationCard, myClass_Welder.WelderName);
                break;
            }
            myconn_hdhr.Close();

        }
    }
}
