using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;

namespace ZCWelder
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Class_zwjPublic.myClass_SqlConnection = new Class_SqlConnection(Properties.Settings.Default.zwjConn, Properties.Settings.Default.AppRole, Properties.Settings.Default.AppRolePassword);

            Form_Login myForm = new Form_Login();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                myForm.Close();
            }
            else
            {
                return;
            }

            Class_zwjPublic.InitializeData();
            Class_zwjPublic.myFormFont = Properties.Settings.Default.FormFont;
            Class_zwjPublic.myBackColor = Properties.Settings.Default.FormBackColor;
            Class_zwjPublic.mytextBoxDoubleClickColor = Properties.Settings.Default.textBoxDoubleClickColor;
            Class_zwjPublic.myGridColor = Properties.Settings.Default.GridColor;
            Class_zwjPublic.myDataGridViewBackColor = Properties.Settings.Default.DataGridViewBackColor;
            Class_zwjPublic.myDataGridViewAlternatingBackColor = Properties.Settings.Default.DataGridViewAlternatingBackColor;
            Class_zwjPublic.mysplitContainerHeadBackColor = Properties.Settings.Default.splitContainerHeadBackColor ;
            Class_zwjPublic.mysplitContainerHeadForeColor  = Properties.Settings.Default.splitContainerHeadForeColor ;

            Class_Public.InitializeData();
            Class_DataControlBind.myHashtable = Class_Public.myHashtable;

            Application.Run(new Form_Main());
        }
    }
}