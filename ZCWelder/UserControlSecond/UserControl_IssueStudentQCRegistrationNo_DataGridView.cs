using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCCL.AspNet;
using ZCWelder.ClassBase;
using ZCWelder.ZCWelderPicture ;
using System.IO;
using ZCWelder.Exam;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_IssueStudentQCRegistrationNo_DataGridView : UserControl
    {
        private EventArgs_Welder myEventArgs_Welder;

        public UserControl_IssueStudentQCRegistrationNo_DataGridView()
        {
            InitializeComponent();
        }

        private void UserControl_WelderIssueStudentQCRegistrationNo_DataGridView_Load(object sender, EventArgs e)
        {
            for (int i = this.tabControl_Student .TabCount - 1; i >= 0; i--)
            {
                this.tabControl_Student.SelectedIndex = i;
            }
            Publisher_Welder.EventName += new EventHandler_Welder(InitDataGridView);

            if (!Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Read) )
            {
                this.button_DeletePicture.Visible=false;
                this.button_DownLoadPicture .Visible=false;
                this.button_UploadPicture .Visible=false;
            }


        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitDataGridView(object sender, EventArgs_Welder e)
        {
            this.myEventArgs_Welder = e;
            Class_DataControlBind.InitializeDataGridView(this.dataGridView_Data, Enum_DataTable.IssueStudentQCRegistrationNo.ToString(), false);
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ExamAll.ToString()];
            myClass_Data.SetFilter(string.Format("IdentificationCard='{0}'", this.myEventArgs_Welder.str_IdentificationCard ));
            this.dataGridView_Data.DataSource = null;
            myClass_Data.RefreshData(false );
            this.dataGridView_Data.DataSource = new DataView(myClass_Data.myDataTable.Copy());
            if (string.IsNullOrEmpty(((DataView)this.dataGridView_Data.DataSource).Sort))
            {
                ((DataView)this.dataGridView_Data.DataSource).Sort = myClass_Data.myDataView.Sort;
            }
            if (this.checkBox_QC.Checked)
            {
                ((DataView)this.dataGridView_Data.DataSource).RowFilter = string.Format("ValidUntil >= '{0}' And isQCValid=1", DateTime.Today.ToShortDateString());
            }
            else
            {
                ((DataView)this.dataGridView_Data.DataSource).RowFilter = null;
            }
            this.label_Data.Text = string.Format("考试记录，({0})：", this.dataGridView_Data.RowCount);
            
            this.pictureBox_Welder.Image = Class_Welder.GetWelderPicture(this.myEventArgs_Welder.str_IdentificationCard);

            this.userControl_WelderTestCommitteeRegistrationNoBase1.InitDataGridView(this.myEventArgs_Welder.str_IdentificationCard);

            if (this.dataGridView_Data.RowCount == 0)
            {
                EventArgs_StudentSecond my_e = new EventArgs_StudentSecond(null);
                Publisher_StudentSecond.OnEventName(my_e);
            }

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="bool_JustFill">true-只添加和修改数据，false-刷新全部数据</param>
        private void RefreshData(bool bool_JustFill)
        {
            if (this.myEventArgs_Welder != null)
            {
                Publisher_Welder.OnEventName(this.myEventArgs_Welder);
            }

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData(false);

        }

        /// <summary>
        /// 导出数据到Excel电子表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowExportToExcel_Click(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewExportExcel(this.dataGridView_Data, true, true);;

        }

        /// <summary>
        /// 冻结或解冻任意数据列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DataGridViewRowFrozenThisColumn_CheckStateChanged(object sender, EventArgs e)
        {
            Class_DataControlBind.DataGridViewFrozenColumn((ToolStripMenuItem)sender, this.dataGridView_Data);

        }

        /// <summary>
        /// 设置快捷菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Data_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.ContextMenuStrip = this.contextMenuStrip_DataGridViewRow;
                this.dataGridView_Data.CurrentCell = this.dataGridView_Data.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }

        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridView_Opening(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// 根据权限设置功能列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_DataGridViewRow_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItem_RowSetQCValid.Visible = this.dataGridView_Data.CurrentRow.Cells["CertificateNo"].Value != DBNull.Value;
            this.toolStripMenuItem_DataGridViewRowExportToExcel.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Print);
            this.toolStripMenuItem_RowSetQCValid.Enabled = Class_CustomUser.GetSecurity(Class_zwjPublic.myClass_CustomUser.UserGUID, Class_CustomSecurity.GetSecurityGUID("焊工权限"), Enum_zwjKindofUpdate.Print);
        }

        private void checkBox_QC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dataGridView_Data.DataSource != null)
            {
                if (this.checkBox_QC.Checked)
                {
                    ((DataView)this.dataGridView_Data.DataSource).RowFilter = string.Format("isQCValid = true and ValidUntil >= '{0}'", DateTime.Today.ToShortDateString());
                }
                else
                {
                    ((DataView)this.dataGridView_Data.DataSource).RowFilter = null;
                }
                this.label_Data.Text = string.Format("考试记录，({0})：", this.dataGridView_Data.RowCount);
            }

        }

        private void dataGridView_Data_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            EventArgs_StudentSecond my_e = new EventArgs_StudentSecond(this.dataGridView_Data.Rows[e.RowIndex].Cells["ExaminingNo"].Value.ToString());
            Publisher_StudentSecond.OnEventName(my_e);

        }

        private void toolStripMenuItem_RowSetQCValid_Click(object sender, EventArgs e)
        {
            Class_QC myClass_QC = new Class_QC(this.dataGridView_Data.CurrentRow.Cells["ExaminingNo"].Value.ToString());
            Form_QC_Update myForm = new Form_QC_Update();
            myForm.myClass_QC=myClass_QC;
            if (myForm.ShowDialog()== DialogResult.OK)
            {
                Publisher_Welder.OnEventName(this.myEventArgs_Welder);
            }           

        }

        private void button_UploadPicture_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Welder == null)
            {
                return;
            }
            if (this.pictureBox_Welder.Image != null)
            {
                if (MessageBox.Show("该焊工已有照片，确认重新上传吗？", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            Class_Welder myClass_Welder = new Class_Welder();
            myClass_Welder.IdentificationCard = this.myEventArgs_Welder.str_IdentificationCard;
            if (myClass_Welder.FillData())
            {
                this.pictureBox_Welder.Image = Class_Welder.SetWelderPicture(this.myEventArgs_Welder.str_IdentificationCard );
            }
            else
            {
                MessageBox.Show("不存在该焊工！");
            }

            //OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            //myOpenFileDialog.FileName = "";
            //myOpenFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            //myOpenFileDialog.RestoreDirectory = true;
            //if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    this.pictureBox_Welder .Image = Image.FromFile(myOpenFileDialog.FileName);
            //    try
            //    {
            //        WelderPicture myWelderPicture = new WelderPicture();
            //        FileInfo myFileInfo = new FileInfo(myOpenFileDialog.FileName );
            //        FileStream myFileStream = myFileInfo.OpenRead();
            //        byte[] mybyte = new byte[myFileStream.Length];
            //        myFileStream.Read(mybyte, 0, mybyte.Length);
            //        myFileStream.Close();
            //        Class_Welder myClass_Welder=new Class_Welder(this.myEventArgs_Welder.str_IdentificationCard);
            //        myWelderPicture.SetWelderPicture(mybyte, this.myEventArgs_Welder.str_IdentificationCard, myClass_Welder.WelderName );
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //    finally
            //    {
            //    }
            //}

        }

        private void button_DownLoadPicture_Click(object sender, EventArgs e)
        {
            if (this.pictureBox_Welder.Image != null)
            {
                SaveFileDialog mySaveFileDialog = new SaveFileDialog();
                mySaveFileDialog.Filter = "All files (*.JPG)|*.JPG";
                Class_Welder myClass_Welder = new Class_Welder(this.myEventArgs_Welder.str_IdentificationCard);
                mySaveFileDialog.FileName = string.Format("{0}_{1}", myClass_Welder.WelderName, myClass_Welder.IdentificationCard );
                mySaveFileDialog.RestoreDirectory = true;
                if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBox_Welder.Image.Save(mySaveFileDialog.FileName);
                }
            }
        }

        private void button_DeletePicture_Click(object sender, EventArgs e)
        {
            if (this.myEventArgs_Welder == null)
            {
                return;
            }
            if (MessageBox.Show("确认删除吗？", "确认窗口", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Class_Welder.DeleteWelderPicture(this.myEventArgs_Welder.str_IdentificationCard);
                this.pictureBox_Welder.Image = null;
            }
        }

        private void dataGridView_Data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView_Data.Columns[e.ColumnIndex].Name == "TheoryResult" || this.dataGridView_Data.Columns[e.ColumnIndex].Name == "TheoryMakeupResult")
            {
                if (e.Value != DBNull.Value && (int)e.Value < (int)this.dataGridView_Data.Rows[e.RowIndex].Cells["PassScore"].Value)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            else if (this.dataGridView_Data.Columns[e.ColumnIndex].Name == "ExamStatus")
            {
                if (e.Value.ToString() != "顺利考试")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }

        }

    }
}
