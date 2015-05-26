using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZCCL.ClassBase;
using ZCCL.UpdateLog;
using ZCCL.Tools;
using System.IO;
using System.Drawing;
using ZCWelder.ZCWelderPicture;
using System.Windows.Forms;
using System.Collections;
using ZCWord = Microsoft.Office.Interop.Word;

namespace ZCWelder.ClassBase
{
    /// <summary>
    /// 焊工所属部门类，记录公司、部门、作业区、劳务队、工号等信息
    /// </summary>
    public  class Class_BelongUnit
    {
#region "Fields"
    public  string EmployerHPID;//公司编号
    public string DepartmentHPID ;//部门编号
    public string WorkPlaceHPID ;//作业区编号
    public string LaborServiceTeamHPID ;//劳务队编号
    public string WorkerID ;//工号
#endregion

    public void ParametersAdd(SqlParameterCollection myParameters, string str_Prefixion)
    {
        myParameters.Add("@" + str_Prefixion + "EmployerHPID", SqlDbType.NChar, 4).Value = this.EmployerHPID;
        myParameters.Add("@" + str_Prefixion + "DepartmentHPID", SqlDbType.NChar, 6).Value = this.DepartmentHPID;
        myParameters.Add("@" + str_Prefixion + "WorkPlaceHPID", SqlDbType.NChar, 8).Value = this.WorkPlaceHPID;
        myParameters.Add("@" + str_Prefixion + "LaborServiceTeamHPID", SqlDbType.NChar, 7).Value = this.LaborServiceTeamHPID;
        myParameters.Add("@" + str_Prefixion + "WorkerID", SqlDbType.NVarChar, 10).Value = this.WorkerID;

    }

    public void FillData(SqlDataReader myReader, string str_Prefixion)
    {
        this.EmployerHPID = myReader[str_Prefixion + "EmployerHPID"].ToString();
        this.DepartmentHPID = myReader[str_Prefixion + "DepartmentHPID"].ToString();
        this.WorkPlaceHPID = myReader[str_Prefixion + "WorkPlaceHPID"].ToString();
        this.LaborServiceTeamHPID = myReader[str_Prefixion + "LaborServiceTeamHPID"].ToString();
        this.WorkerID = myReader[str_Prefixion + "WorkerID"].ToString();

    }

    public string CheckField()
    {
        if (string.IsNullOrEmpty(this.EmployerHPID))
        {
            return "公司编号不能为空";
        }
        return null;
    }

    }
   
    /// <summary>
    /// 焊工信息类
    /// </summary>
    public class Class_Welder
    {
        #region "Fields"
        public Class_BelongUnit myClass_BelongUnit = new Class_BelongUnit();
        public string IdentificationCard;//身份证号码
        public string WelderName;//姓名
        public string WelderEnglishName;//英文名称
        public string Sex;//性别
        public DateTime WeldingBeginning;//开始从事焊接日期
        public string Schooling;//学历
        public string WelderRemark;//备注
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_Welder()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="Welder"></param>
        public Class_Welder(string IdentificationCard)
        {
            this.IdentificationCard = IdentificationCard;
            this.FillData();
        }

        //导出焊工照片到Word文件中
        public static void ExportWelderPictureToWord(DataView myDataView_Temp)
        {
            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\焊工照片.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_Range;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            int i = 0;
            int j = 0;
            Image myImage_WelderPicture;
            string str_TempFileName;
            foreach (DataRowView myDataRowView in myDataView_Temp)
            {
                if (i == 35)
                {
                    str_BookmarkName = "first";
                    Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                    str_BookmarkName = "last";
                    Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                    myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                    myRange.Copy();
                    myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                    myWordDocument.Application.Selection.Paste();
                    i = 0;
                }
                j = i / 7;

                myImage_WelderPicture = Class_Welder.GetWelderPicture(myDataRowView["IdentificationCard"].ToString());
                myWordDocument.Tables[1].Cell(j * 2 + 1, i % 7 + 1).Range.Select();
                myWordApp.Selection.Delete(ref oMissing, ref oMissing);
                if (myImage_WelderPicture != null)
                {
                    str_TempFileName = Path.Combine(Path.GetTempPath(), myDataRowView["WelderName"].ToString() + "_" + myDataRowView["IdentificationCard"].ToString() + ".JPG");
                    File.Delete(str_TempFileName);
                    myImage_WelderPicture.Save(str_TempFileName);
                    myWordDocument.Tables[1].Cell(j * 2 + 1, i % 7 + 1).Select();
                    ZCWord.InlineShape myInlineShape = myWordApp.Selection.InlineShapes.AddPicture(str_TempFileName, ref oMissing, ref oMissing, ref oMissing);
                    myInlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                }
                myWordDocument.Tables[1].Cell(j * 2 + 2, i % 7 + 1).Range.Text = myDataRowView["WelderName"].ToString() + "_" + myDataRowView["IdentificationCard"].ToString();
                i++;
            }
            for (; i < 35; i++)
            {
                j = i / 7;
                myWordDocument.Tables[1].Cell(j * 2 + 1, i % 7 + 1).Range.Select();
                myWordApp.Selection.Delete(ref oMissing, ref oMissing);
                myWordDocument.Tables[1].Cell(j * 2 + 2, i % 7 + 1).Range.Text = "";
            }
            str_BookmarkName = "first";
            Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            str_BookmarkName = "last";
            Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            myRange.Copy();
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordDocument.Application.Selection.Paste();

            str_BookmarkName = "first";
            Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            str_BookmarkName = "last";
            Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            myRange.Delete(ref oMissing, ref oMissing);

            object object_Count = 1;
            object object_wdCharacter = ZCWord.WdUnits.wdCharacter;
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.Delete(ref object_wdCharacter, ref object_Count);
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;
        }

        //获取焊工照片
        public static Hashtable GetWelderPictureHashtableBinary(DataTable myDataTable)
        {
            if (!myDataTable.Columns.Contains("IdentificationCard"))
            {
                return null;
            }
            Hashtable myHashtable = new Hashtable();
            byte[] mybyte=null;
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                if (myHashtable.ContainsKey(myDataRow["IdentificationCard"].ToString()))
                {
                    continue;
                }
                mybyte = Class_Welder.GetWelderPictureBinary(myDataRow["IdentificationCard"].ToString());
                if (Class_Welder.CheckImagebyteDataValid(mybyte))
                {
                    myHashtable.Add(myDataRow["IdentificationCard"].ToString(),mybyte);
                }
            }
            return myHashtable ;

        }

        public static Hashtable GetWelderPictureHashtable(DataTable myDataTable)
        {
            if (!myDataTable.Columns.Contains("IdentificationCard"))
            {
                return null;
            }
            Hashtable myHashtable = new Hashtable();
            Image myImage = null;
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                myImage = Class_Welder.GetWelderPicture(myDataRow["IdentificationCard"].ToString());
                if (myImage != null)
                {
                    myHashtable.Add(myDataRow["IdentificationCard"].ToString(), myImage);
                }
            }
            return myHashtable ;

        }

        public static byte[] GetWelderPictureBinary(string str_IdentificationCard)
        {
            if (!Properties.Settings.Default.WebServiceStartUp)
            {
                return null;
            }
            byte[] mybyte=null;
            try
            {
                WelderPicture myWelderPicture = new WelderPicture();
                mybyte = (byte[])myWelderPicture.GetWelderPicture(str_IdentificationCard);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            return mybyte;

        }

        public static bool CheckImagebyteDataValid(byte[] mybyte)
        {
            if (mybyte == null || mybyte.Length == 0)
            {
                return false; 
            }
            Image myImage = null;
            try
            {
                MemoryStream myMemoryStream = new MemoryStream();
                myMemoryStream.Write(mybyte, 0, mybyte.Length);
                myImage = Image.FromStream(myMemoryStream);
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return myImage!=null;
        }

        public static Image GetWelderPicture(string str_IdentificationCard)
        {
            if (!Properties.Settings.Default.WebServiceStartUp)
            {
                return null;
            }
            Image myImage = null;
            try
            {
                WelderPicture myWelderPicture = new WelderPicture();
                byte[] mybyte;
                mybyte = (byte[])myWelderPicture.GetWelderPicture(str_IdentificationCard);
                if (mybyte == null || mybyte.Length == 0)
                {
                    Exception myException = new Exception("该焊工没有照片！");
                    throw (myException);
                }
                MemoryStream myMemoryStream = new MemoryStream();
                myMemoryStream.Write(mybyte, 0, mybyte.Length);
                myImage = Image.FromStream(myMemoryStream);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            return myImage;

        }

        public static Image SetWelderPicture(string str_IdentificationCard)
        {
            if (!Properties.Settings.Default.WebServiceStartUp)
            {
                return null;
            }
            Image myImage = null;
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            myOpenFileDialog.FileName = "";
            myOpenFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            myOpenFileDialog.RestoreDirectory = true;
            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo myFileInfo = new FileInfo(myOpenFileDialog.FileName);
                if (myFileInfo.Length > Class_ExamField.WelderPictureFileLength )
                {
                    MessageBox.Show(string.Format("本文件长度为{0}，已超过允许大小：{1}", myFileInfo.Length, Class_ExamField.WelderPictureFileLength ));
                    return null;
                }

                try
                {
                    myImage = Image.FromFile(myOpenFileDialog.FileName);
                    WelderPicture myWelderPicture = new WelderPicture();
                    FileStream myFileStream = myFileInfo.OpenRead();
                    byte[] mybyte = new byte[myFileStream.Length];
                    myFileStream.Read(mybyte, 0, mybyte.Length);
                    myFileStream.Close();
                    Class_Welder myClass_Welder = new Class_Welder();
                    myClass_Welder.IdentificationCard = str_IdentificationCard;
                    if (myClass_Welder.FillData()==false )
                    {
                        MessageBox.Show("没有该焊工，如果在报考单位中添加焊工照片，请先同步焊工数据！");
                        return null;
                    }
                    bool bool_Modify=false ;
                    if (Class_Welder.ExistWelderPicture(str_IdentificationCard))
                    {
                        bool_Modify = true;
                    }
                    myWelderPicture.SetWelderPicture(mybyte, str_IdentificationCard, myClass_Welder.WelderName );
                    myImage.Dispose();
                    if (bool_Modify)
                    {
                        Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify  , "Person_WelderPicture", string.Format("{0}", str_IdentificationCard), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
                    }
                    else
                    {
                        Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Add , "Person_WelderPicture", string.Format("{0}", str_IdentificationCard), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                }
            }

            return Class_Welder.GetWelderPicture(str_IdentificationCard);
        }

        public static void  DeleteWelderPicture(string str_IdentificationCard)
        {
            if (!Properties.Settings.Default.WebServiceStartUp)
            {
                return;
            }

            try
            {
                WelderPicture myWelderPicture = new WelderPicture();
                myWelderPicture.DeleteWelderPicture (str_IdentificationCard);
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Delete , "Person_WelderPicture", string.Format("{0}", str_IdentificationCard), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        public static void DeleteWelderPicturebyFileName(string str_FileName)
        {
            if (!Properties.Settings.Default.WebServiceStartUp)
            {
                return;
            }

            try
            {
                WelderPicture myWelderPicture = new WelderPicture();
                myWelderPicture.DeleteWelderPicturebyFileName(str_FileName);
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Delete, "Person_WelderPicture", string.Format("{0}", str_FileName), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        public static Image GetWelderPicturebyFileName(string str_FileName)
        {
            if (!Properties.Settings.Default.WebServiceStartUp)
            {
                return null;
            }
            Image myImage = null;
            try
            {
                WelderPicture myWelderPicture = new WelderPicture();
                byte[] mybyte;
                mybyte = (byte[])myWelderPicture.GetWelderPicturebyFileName(str_FileName);
                if (mybyte == null || mybyte.Length == 0)
                {
                    Exception myException = new Exception("该焊工没有照片！");
                    throw (myException);
                }
                MemoryStream myMemoryStream = new MemoryStream();
                myMemoryStream.Write(mybyte, 0, mybyte.Length);
                myImage = Image.FromStream(myMemoryStream);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            return myImage;

        }

        public static string[] GetWelderPictureFileNames()
        {
            if (!Properties.Settings.Default.WebServiceStartUp)
            {
                return null;
            }
            string[] str_FileNameRange=null ;
            try
            {
                WelderPicture myWelderPicture = new WelderPicture();
                str_FileNameRange=myWelderPicture.GetWelderPictureFileNames();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            return str_FileNameRange;

        }

        public static bool ExistWelderPicture(string str_IdentificationCard)
        {
            if (!Properties.Settings.Default.WebServiceStartUp)
            {
                return false ;
            }
            bool bool_ExistWelderPicture=false ;
            try
            {
                //WelderPicture myWelderPicture = new WelderPicture();
                //if (myWelderPicture.ExistWelderPicture(str_IdentificationCard))
                //{
                //    bool_ExistWelderPicture = Class_Welder.GetWelderPicture(str_IdentificationCard) != null;
                //}
                //else
                //{
                //    bool_ExistWelderPicture = false ;
                //}
                bool_ExistWelderPicture = Class_Welder.GetWelderPicture(str_IdentificationCard) != null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            return bool_ExistWelderPicture;

        }

        public static DataTable  DetectWelderPictureisValid(DataTable myDataTable)
        {
            if (!myDataTable.Columns.Contains("IdentificationCard"))
            {
                return myDataTable;
            }
            if (!myDataTable.Columns.Contains("WelderPictureisValid"))
            {
                DataColumn myDataColumn_isValid = new DataColumn("WelderPictureisValid");
                myDataColumn_isValid.DataType = System.Type.GetType("System.Int32");
                myDataColumn_isValid.AllowDBNull = true;
                myDataTable.Columns.Add(myDataColumn_isValid);
            }
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                if (Class_Welder.ExistWelderPicture(myDataRow["IdentificationCard"].ToString()))
                {
                    myDataRow["WelderPictureisValid"] = 1;
                }
                else
                {
                    myDataRow["WelderPictureisValid"] = 0;
                }
            }
            return myDataTable;
        }

        public static string GetWelderName(string str_IdentificationCard)
        {
            string str_SQL = "Select WelderName From [Person_Welder] Where IdentificationCard=@IdentificationCard";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = str_IdentificationCard;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            string  str_WelderName=null;
            if (myReader_Temp.Read())
            {
                str_WelderName = myReader_Temp["WelderName"].ToString();
            }
            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return str_WelderName;
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Person_Welder] Where IdentificationCard=@IdentificationCard";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL,Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = this.IdentificationCard;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp= myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.myClass_BelongUnit.FillData(myReader_Temp, "Welder");

                this.WelderEnglishName = myReader_Temp["WelderEnglishName"].ToString();
                this.WelderName = myReader_Temp["WelderName"].ToString();
                this.Sex = myReader_Temp["Sex"].ToString();
                this.WeldingBeginning = DateTime.Parse(myReader_Temp["WeldingBeginning"].ToString());
                this.Schooling = myReader_Temp["Schooling"].ToString();               
                this.WelderRemark = myReader_Temp["WelderRemark"].ToString();
                bool_Return = true;
            }
            else
            {
                bool_Return = false;
            }

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return bool_Return;
        }

        /// <summary>
        /// 数据添加和修改函数的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            this.myClass_BelongUnit.ParametersAdd(myParameters, "Welder");
            myParameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = this.IdentificationCard;
            myParameters.Add("@WelderName", SqlDbType.NVarChar, 10).Value = this.WelderName;
            myParameters.Add("@WelderEnglishName", SqlDbType.NVarChar, 50).Value = this.WelderEnglishName;
            myParameters.Add("@Schooling", SqlDbType.NVarChar, 20).Value = this.Schooling;
            myParameters.Add("@Sex", SqlDbType.NChar, 1).Value = this.Sex;
            myParameters.Add("@WeldingBeginning", SqlDbType.DateTime).Value = this.WeldingBeginning;
            myParameters.Add("@WelderRemark", SqlDbType.NVarChar, 255).Value = this.WelderRemark;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="Welder"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string IdentificationCard, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Delete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
                case Enum_zwjKindofUpdate.CanDelete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.CanDelete.ToString();
                    break;
                case Enum_zwjKindofUpdate.Exist:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Exist.ToString();
                    break;
            }
        }

        /// <summary>
        /// 集成数据添加和修改的统一函数
        /// </summary>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_Welder_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);

            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Person_Welder", string.Format("{0}", IdentificationCard), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return true;
        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="Welder"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string IdentificationCard, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Person_Welder", string.Format("{0}", IdentificationCard), Class_zwjPublic.myClass_CustomUser.UserGUID, "");

            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_Welder_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Welder.ParametersAdd(myCmd_Temp.Parameters, IdentificationCard, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// 修改焊工身份证号码
        /// </summary>
        /// <param name="NewIdentificationCard">新的身份证号码</param>
        /// <returns></returns>
        public bool IdentificationCardModify(string NewIdentificationCard, string NewSex)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_Welder_UpdateIdentificationCard";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@OldIdentificationCard", SqlDbType.NChar, 18).Value = this.IdentificationCard;
            myCmd_Temp.Parameters.Add("@NewIdentificationCard", SqlDbType.NChar, 18).Value = NewIdentificationCard;
            myCmd_Temp.Parameters.Add("@NewSex", SqlDbType.NChar, 1).Value = NewSex;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.IdentificationCard = NewIdentificationCard;
            this.Sex = NewSex;
            Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Person_Welder", this.IdentificationCard, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return true;

        }

        /// <summary>
        /// 校验数据字段的格式
        /// </summary>
        /// <returns></returns>
        public string CheckField()
        {
            if (!ZCCL.Tools.Class_DataValidateTool.CheckIdentificationCard(this.IdentificationCard,this.Sex))
            {
                return "身份证号码格式或性别有误！";
            }
            else if (string.IsNullOrEmpty(this.WelderName))
            {
                return "姓名不能为空！";
            }
            else if (string.IsNullOrEmpty(this.Schooling))
            {
                return "学历不能为空！";
            }
            else if (this.Sex != "男" && this.Sex != "女")
            {
                return "性别必须为 '男' 或 '女'！";
            }
            else if (!Class_Schooling.ExistAndCanDeleteAndDelete(this.Schooling, Enum_zwjKindofUpdate.Exist))
            {
                return "学历有误！";
            }
            else if (this.WeldingBeginning < Class_DataValidateTool.GetBirthdaybyIdentificationCard(this.IdentificationCard).AddYears(14))
            {
                return "从事焊接开始日期有误！";
            }
            return this.myClass_BelongUnit .CheckField();

        }

        //审核焊工的报名考试资格
        static public string CanSignUp(string IdentificationCard, string WeldingProcessAb, string SubjectID, string ShipClassificationAb, string ShipboardNo, string Material, string WeldingConsumable, string Thickness, string ExternalDiameter, bool GXTheory)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_Welder_CanSignUp";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            myCmd_Temp.Parameters.Add("@WeldingProcessAb", SqlDbType.NVarChar, 10).Value = WeldingProcessAb;
            myCmd_Temp.Parameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = ShipClassificationAb;
            myCmd_Temp.Parameters.Add("@ShipboardNo", SqlDbType.NVarChar, 20).Value = ShipboardNo;
            myCmd_Temp.Parameters.Add("@GXTheory", SqlDbType.Bit).Value = GXTheory;
            if (!string.IsNullOrEmpty(SubjectID))
            {
                myCmd_Temp.Parameters.Add("@SubjectID", SqlDbType.NChar, 4).Value = SubjectID;
                myCmd_Temp.Parameters.Add("@Material", SqlDbType.NVarChar, 50).Value = Material;
                myCmd_Temp.Parameters.Add("@WeldingConsumable", SqlDbType.NVarChar, 50).Value = WeldingConsumable;
                myCmd_Temp.Parameters.Add("@Thickness", SqlDbType.NVarChar, 20).Value = Thickness;
                myCmd_Temp.Parameters.Add("@ExternalDiameter", SqlDbType.NVarChar, 20).Value = ExternalDiameter;            
            }
            myCmd_Temp.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 255).Direction= ParameterDirection.Output ;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return myCmd_Temp.Parameters["@ReturnMessage"].Value.ToString();
        }

        static public string[] GetWeldingProcessAndWeldingClass(string str_IdentificationCard, string str_ShipClassificationAb, string str_ShipboardNo)
        {
            string str_SQL;
            str_SQL = "SELECT WeldingProcessAb, StudentMaterial, WeldingClass, ValidUntil, ScopeofWeldingClass FROM View_Exam_WelderIssueStudentQC";
            str_SQL +=string.Format( " Where IdentificationCard='{0}' And CertificateNo is not Null And ValidUntil>'{1}' And isQCValid = 1",str_IdentificationCard,DateTime.Today  );
            if (!string.IsNullOrEmpty(str_ShipClassificationAb))
            {
                str_SQL += " And ShipClassificationAb='" + str_ShipClassificationAb + "'";
                if (!string.IsNullOrEmpty(str_ShipboardNo))
                {
                    str_SQL += " And ShipboardNo='" + str_ShipboardNo + "'";
                }
            }
            str_SQL += " Order by ExaminingNo";
            DataTable myDataTable = Class_zwjPublic.myClass_SqlConnection.GetDataTable(str_SQL);

            string[] myArray_string = new string[3];
            myArray_string[0] = "";
            myArray_string[1] = "";
            myArray_string[2] = "";
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                if (string.IsNullOrEmpty(myArray_string[0]))
                {
                    myArray_string[0] = myDataRow["WeldingClass"].ToString() + "(" + myDataRow["WeldingProcessAb"].ToString() + ")";
                    myArray_string[1] = ((DateTime)myDataRow["ValidUntil"]).ToString("yyyy-M-d");
                    myArray_string[2] = myDataRow["WeldingProcessAb"].ToString() + "(" + myDataRow["StudentMaterial"].ToString() + ")" + "：" + myDataRow["ScopeofWeldingClass"].ToString();
                }
                else
                {
                    myArray_string[0] += "\n" + myDataRow["WeldingClass"].ToString() + "(" + myDataRow["WeldingProcessAb"].ToString() + ")";
                    myArray_string[1] += "/" + ((DateTime)myDataRow["ValidUntil"]).ToString("yyyy-M-d");
                    myArray_string[2] += "\n" + myDataRow["WeldingProcessAb"].ToString() + "(" + myDataRow["StudentMaterial"].ToString() + ")" + "：" + myDataRow["ScopeofWeldingClass"].ToString();
                }
            }
            return myArray_string;
        }

    }

    public class Class_TestCommitteeRegistrationNo
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string TestCommitteeID;
        public string RegistrationNo;
        public string IdentificationCard;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_TestCommitteeRegistrationNo()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="TestCommitteeRegistrationNo"></param>
        public Class_TestCommitteeRegistrationNo(string TestCommitteeID, string RegistrationNo)
        {
            this.TestCommitteeID = TestCommitteeID;
            this.RegistrationNo = RegistrationNo;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Person_TestCommitteeRegistrationNo] Where TestCommitteeID=@TestCommitteeID and RegistrationNo=@RegistrationNo";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = this.TestCommitteeID;
            myCmd_Temp.Parameters.Add("@RegistrationNo", SqlDbType.NVarChar, 20).Value = this.RegistrationNo;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.IdentificationCard = myReader_Temp["IdentificationCard"].ToString();
                bool_Return = true;
            }
            else
            {
                bool_Return = false;
            }

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return bool_Return;
        }

        /// <summary>
        /// 数据添加和修改函数的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = this.TestCommitteeID;
            myParameters.Add("@RegistrationNo", SqlDbType.NVarChar, 20).Value = this.RegistrationNo;
            myParameters.Add("@IdentificationCard", SqlDbType.NChar , 18).Value = this.IdentificationCard;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="TestCommitteeRegistrationNo"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string TestCommitteeID, string RegistrationNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = TestCommitteeID;
            myParameters.Add("@RegistrationNo", SqlDbType.NVarChar, 20).Value = RegistrationNo;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Delete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
                case Enum_zwjKindofUpdate.CanDelete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.CanDelete.ToString();
                    break;
                case Enum_zwjKindofUpdate.Exist:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Exist.ToString();
                    break;
            }
        }

        /// <summary>
        /// 集成数据添加和修改的统一函数
        /// </summary>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_TestCommitteeRegistrationNo_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Person_TestCommitteeRegistrationNo",this.TestCommitteeID + " , " + this.RegistrationNo + " , "  +this.IdentificationCard, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return true;
        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="TestCommitteeRegistrationNo"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string TestCommitteeID, string RegistrationNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Person_TestCommitteeRegistrationNo", TestCommitteeID + " , " + RegistrationNo , Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_TestCommitteeRegistrationNo_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_TestCommitteeRegistrationNo.ParametersAdd(myCmd_Temp.Parameters, TestCommitteeID, RegistrationNo, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        static public bool ExistSecond(string TestCommitteeID, string IdentificationCard, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_TestCommitteeRegistrationNo_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = TestCommitteeID;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
            }

            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public string  AutoFill(string TestCommitteeID, string IdentificationCard)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_TestCommitteeRegistrationNo_AutoFill";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = TestCommitteeID;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            myCmd_Temp.Parameters.Add("@RegistrationNo", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;

            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if (myCmd_Temp.Parameters["@RegistrationNo"].Value != DBNull.Value )
            {
                Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Add, "Person_TestCommitteeRegistrationNo", TestCommitteeID + " , " + myCmd_Temp.Parameters["@RegistrationNo"].Value .ToString() + " , " + IdentificationCard, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
                return myCmd_Temp.Parameters["@RegistrationNo"].Value .ToString();
            }
            else
            {
                return null ;
            }
        }

        /// <summary>
        /// 校验数据字段的格式
        /// </summary>
        /// <returns></returns>
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.TestCommitteeID ))
            {
                return "存档号码不能为空！";
            }
            else if (string.IsNullOrEmpty(this.IdentificationCard ))
            {
                return "身份证号码不能为空！";
            }
            //else if (string.IsNullOrEmpty(this.RegistrationNo))
            //{
            //    return "存档组织号码不能为空！";
            //}

            return null;
        }

    }
    
    public class Class_WelderBelong
    {
        #region "Fields"
        public Class_BelongUnit myClass_BelongUnit = new Class_BelongUnit();
        public long  WelderBelongID ;
        public string IdentificationCard;
        public string WelderBelongRemark;
        #endregion

                /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_WelderBelong()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="Welder"></param>
        public Class_WelderBelong(long WelderBelongID)
        {
            this.WelderBelongID = WelderBelongID;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Person_WelderBelong] Where WelderBelongID=@WelderBelongID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL,Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WelderBelongID", SqlDbType.BigInt ).Value = this.WelderBelongID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp= myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.myClass_BelongUnit.FillData(myReader_Temp, "WelderBelong");
                this.IdentificationCard = myReader_Temp["IdentificationCard"].ToString();
                this.WelderBelongRemark = myReader_Temp["WelderBelongRemark"].ToString();
                bool_Return = true;
            }
            else
            {
                bool_Return = false;
            }

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return bool_Return;
        }

        /// <summary>
        /// 数据添加和修改函数的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            this.myClass_BelongUnit.ParametersAdd(myParameters, "WelderBelong");
            myParameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = this.IdentificationCard;
            myParameters.Add("@WelderBelongRemark", SqlDbType.NVarChar, 255).Value = this.WelderBelongRemark;
            myParameters.Add("@WelderBelongID", SqlDbType.BigInt).Direction= ParameterDirection.InputOutput ;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@WelderBelongID"].Value = this.WelderBelongID;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="Welder"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, long  WelderBelongID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WelderBelongID", SqlDbType.BigInt).Value = WelderBelongID;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Delete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
                case Enum_zwjKindofUpdate.CanDelete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.CanDelete.ToString();
                    break;
                case Enum_zwjKindofUpdate.Exist:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Exist.ToString();
                    break;
            }
        }

        /// <summary>
        /// 集成数据添加和修改的统一函数
        /// </summary>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_WelderBelong_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.WelderBelongID =(long) myCmd_Temp.Parameters["@WelderBelongID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Person_WelderBelong",string.Format("{0}, {1}", this.WelderBelongID, this.IdentificationCard  ), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return true;
        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="Welder"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(long  WelderBelongID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Person_WelderBelong", WelderBelongID.ToString(), Class_zwjPublic.myClass_CustomUser.UserGUID, "");

            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_WelderBelong_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WelderBelong.ParametersAdd(myCmd_Temp.Parameters, WelderBelongID, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        static public bool ExistSecond(string IdentificationCard, string WelderBelongEmployerHPID, string WelderBelongDepartmentHPID, string WelderBelongWorkPlaceHPID, long WelderBelongID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_WelderBelong_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            myCmd_Temp.Parameters.Add("@WelderBelongEmployerHPID", SqlDbType.NChar, 4).Value = WelderBelongEmployerHPID;
            myCmd_Temp.Parameters.Add("@WelderBelongDepartmentHPID", SqlDbType.NChar, 6).Value = WelderBelongDepartmentHPID;
            myCmd_Temp.Parameters.Add("@WelderBelongWorkPlaceHPID", SqlDbType.NChar, 8).Value = WelderBelongWorkPlaceHPID;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@WelderBelongID", SqlDbType.BigInt ).Value = WelderBelongID;
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }

            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public DataTable  GetWelderBelong(string IdentificationCard, string WelderBelongEmployerHPID, string WelderBelongDepartmentHPID, string WelderBelongWorkPlaceHPID)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_WelderBelong_Get";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            myCmd_Temp.Parameters.Add("@WelderBelongEmployerHPID", SqlDbType.NChar, 4).Value = WelderBelongEmployerHPID;
            myCmd_Temp.Parameters.Add("@WelderBelongDepartmentHPID", SqlDbType.NChar, 6).Value = WelderBelongDepartmentHPID;
            myCmd_Temp.Parameters.Add("@WelderBelongWorkPlaceHPID", SqlDbType.NChar, 8).Value = WelderBelongWorkPlaceHPID;
            myCmd_Temp.Connection=Class_zwjPublic.myClass_SqlConnection.mySqlConn;
            DataTable myDataTable = new DataTable();
            SqlDataAdapter myAdapter_Temp = new SqlDataAdapter(myCmd_Temp);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myAdapter_Temp.Fill(myDataTable);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return myDataTable;

        }

        static public bool ExistIdentificationCard(string IdentificationCard)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_WelderBelong_ExistIdentificationCard";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;

            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public void DeleteBatch(string EmployerHPID, string DepartmentHPID, string WorkPlaceHPID)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_WelderBelong_DeleteBatch";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters .Add("EmployerHPID", SqlDbType.NChar, 4).Value = EmployerHPID;
            myCmd_Temp.Parameters .Add("DepartmentHPID", SqlDbType.NChar, 6).Value = DepartmentHPID;
            myCmd_Temp.Parameters .Add("WorkPlaceHPID", SqlDbType.NChar, 8).Value = WorkPlaceHPID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
        }

        /// <summary>
        /// 校验数据字段的格式
        /// </summary>
        /// <returns></returns>
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.IdentificationCard))
            {
                return "身份证号码不能为空！";
            }
            return this.myClass_BelongUnit .CheckField();

        }

    }

    public class Class_BlackList
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public int BlackListID;
        public string IdentificationCard;
        public DateTime BlackListBeginDate;
        public DateTime BlackListEndDate;
        public string BlackListCausation;
        public string BlackListRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_BlackList()
        {

        }

        public Class_BlackList(int BlackListID)
        {
            this.BlackListID = BlackListID;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Person_BlackList] Where BlackListID=@BlackListID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@BlackListID", SqlDbType.Int ).Value = this.BlackListID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.BlackListBeginDate = (DateTime )myReader_Temp["BlackListBeginDate"];
                this.BlackListEndDate = (DateTime )myReader_Temp["BlackListEndDate"];
                this.IdentificationCard = myReader_Temp["IdentificationCard"].ToString();
                this.BlackListCausation = myReader_Temp["BlackListCausation"].ToString();
                this.BlackListRemark = myReader_Temp["BlackListRemark"].ToString();
                bool_Return = true;
            }
            else
            {
                bool_Return = false;
            }

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return bool_Return;
        }

        /// <summary>
        /// 数据添加和修改函数的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@BlackListBeginDate", SqlDbType.DateTime).Value = this.BlackListBeginDate;
            myParameters.Add("@BlackListEndDate", SqlDbType.DateTime).Value = this.BlackListEndDate;
            myParameters.Add("@BlackListCausation", SqlDbType.NVarChar, 1000).Value = this.BlackListCausation ;
            myParameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = this.IdentificationCard ;
            myParameters.Add("@BlackListRemark", SqlDbType.NVarChar, 255).Value = this.BlackListRemark;
            myParameters.Add("@BlackListID", SqlDbType.Int ).Direction= ParameterDirection.InputOutput ;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@BlackListID"].Value = this.BlackListID;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="BlackList"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, int BlackListID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@BlackListID", SqlDbType.Int ).Value = BlackListID;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Delete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
                case Enum_zwjKindofUpdate.CanDelete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.CanDelete.ToString();
                    break;
                case Enum_zwjKindofUpdate.Exist:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Exist.ToString();
                    break;
            }
        }

        /// <summary>
        /// 集成数据添加和修改的统一函数
        /// </summary>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_BlackList_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="BlackList"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(int BlackListID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Person_BlackList_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_BlackList.ParametersAdd(myCmd_Temp.Parameters, BlackListID, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// 校验数据字段的格式
        /// </summary>
        /// <returns></returns>
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.IdentificationCard ))
            {
                return "身份证号码不能为空！";
            }
            else if (string.IsNullOrEmpty(this.BlackListCausation))
            {
                return "黑名单事由不能为空！";
            }
            else if (this.BlackListBeginDate== DateTime.MinValue )
            {
                return "开始日期不能为空！";
            }
            else if (this.BlackListBeginDate  > this.BlackListEndDate )
            {
                return "开始日期不能大于结束日期！";
            }

            return null;
        }

    }

}
