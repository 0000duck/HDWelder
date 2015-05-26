using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.DataGridViewManager;
using ZCCL.AspNet;
using ZCCL.Report;
using ZCCL.Tools;
using ZCCL.ClassBase;

namespace ZCWelder.WPS
{
    public partial class Form_WPSUpdate : Form
    {
        public  Class_WPS myClass_WPS;
        public bool bool_Add;
        public EventArgs_WPSQuery myEventArgs_WPSQuery;

        public Form_WPSUpdate()
        {
            InitializeComponent();
        }

        private void Form_WPSUpdate_Load(object sender, EventArgs e)
        {
            this.label_ErrMessage.Text = "";
            this.BackColor = Properties.Settings.Default.FormBackColor;
            this.Font = Properties.Settings.Default.FormFont;
            if (this.bool_Add == true)
            {
                this.Button_WPSIDModify.Visible = false;
                this.userControl_WPSBase1.InitControl(this.myClass_WPS, this.bool_Add);
            }
            else
            {
                if (!Class_WPS.ExistAndCanDeleteAndDelete(myClass_WPS.WPSID, ZCCL.ClassBase.Enum_zwjKindofUpdate.Exist))
                {
                    MessageBox.Show("该条数据已被删除！");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                this.Button_WPSIDModify.Visible = true ;
                this.userControl_WPSBase1.InitControl(this.myClass_WPS, this.bool_Add);
            }

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            this.userControl_WPSBase1.FillClass();
            String str_ErrMessage ;
            str_ErrMessage = myClass_WPS.CheckField();
            if (str_ErrMessage !=null)
            {
                this.DialogResult = DialogResult.None;
                this.label_ErrMessage.Text=str_ErrMessage ;
                return;
            }
            if (this.bool_Add )
            {
                if (Class_WPS.ExistAndCanDeleteAndDelete (this.myClass_WPS.WPSID, ZCCL.ClassBase.Enum_zwjKindofUpdate.Exist  ) == false)
                {
                    this.myClass_WPS.AddAndModify (ZCCL.ClassBase.Enum_zwjKindofUpdate.Add );
                }
                else
                {
                    this.label_ErrMessage.Text = "该焊接工艺编号已添加！";
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.myClass_WPS.AddAndModify (ZCCL.ClassBase.Enum_zwjKindofUpdate.Modify );
            }

            this.DialogResult = DialogResult.OK ;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel  ;
            this.Close();
        }

        private void Button_WPSIDModify_Click(object sender, EventArgs e)
        {
            string  str_NewWPSID="" ;
            Form_InputBox myForm = new Form_InputBox();
            myForm.str_DefaultResponse = this.myClass_WPS.WPSID;
            myForm.str_Prompt = "请输入焊接工艺编号：";
            myForm.str_Title = "输入焊接工艺编号";
            if (myForm.ShowDialog()== DialogResult.OK )
            {
                str_NewWPSID=myForm.str_DefaultResponse;
            }
            if ( str_NewWPSID.Length==0)
            {
                MessageBox.Show("你没有输入焊接工艺编号，操作失败！");
               return ;
            }
            if (Class_WPS.ExistAndCanDeleteAndDelete  (str_NewWPSID, ZCCL.ClassBase.Enum_zwjKindofUpdate.Exist )==true  )
            {
                MessageBox.Show("焊接工艺编号重复，操作失败！");
               return ;
            }
            this.myClass_WPS .ModifyWPSID (str_NewWPSID);
            if (this.myEventArgs_WPSQuery != null)
            {
                this.myEventArgs_WPSQuery.bool_JustFill = false;
                Publisher_WPSQuery.OnEventName(this.myEventArgs_WPSQuery);
            }
            this.userControl_WPSBase1.InitControl(this.myClass_WPS, false);

        }
    }
}