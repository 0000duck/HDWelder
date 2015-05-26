using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZCCL.ClassBase;
using ZCCL.UpdateLog;
using ZCCL.Tools;

namespace ZCWelder.ClassBase
{
    public class Class_KindofEmployerWelder
    {
        #region "Fields"
        public int KindofEmployerWelderID;
        public string KindofEmployer;
        public Class_BelongUnit myClass_BelongUnit = new Class_BelongUnit();
        public string IdentificationCard;
        public string WelderName;
        public string WelderEnglishName;
        public string Sex;
        public DateTime WeldingBeginning;
        public string Schooling;
        public string WelderRemark;
        public string Postcode;
        public string WelderAddress;
        public string WelderTel;
        public string WeldingExperiences;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_KindofEmployerWelder()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="Welder"></param>
        public Class_KindofEmployerWelder(int KindofEmployerWelderID)
        {
            this.KindofEmployerWelderID = KindofEmployerWelderID;
            this.FillData();
        }

        static public int GetKindofEmployerWelderID(string KindofEmployer, string IdentificationCard)
        {
            string str_SQL = "Select * From [SignUp_KindofEmployerWelder] Where KindofEmployer=@KindofEmployer And IdentificationCard=@IdentificationCard";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = KindofEmployer;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();

            int int_KindofEmployerWelderID=0;
            if (myReader_Temp.Read())
            {
                int_KindofEmployerWelderID=(int)myReader_Temp["KindofEmployerWelderID"];
            }
            else
            {
            }
            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return int_KindofEmployerWelderID;
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [SignUp_KindofEmployerWelder] Where KindofEmployerWelderID=@KindofEmployerWelderID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL,Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@KindofEmployerWelderID", SqlDbType.Int).Value = this.KindofEmployerWelderID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp= myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.myClass_BelongUnit.FillData(myReader_Temp, "Welder");

                this.KindofEmployer = myReader_Temp["KindofEmployer"].ToString();
                this.IdentificationCard = myReader_Temp["IdentificationCard"].ToString();
                this.WelderName = myReader_Temp["WelderName"].ToString();
                this.Sex = myReader_Temp["Sex"].ToString();
                this.WeldingBeginning = DateTime.Parse(myReader_Temp["WeldingBeginning"].ToString());
                this.Schooling = myReader_Temp["Schooling"].ToString();               
                this.WelderRemark = myReader_Temp["WelderRemark"].ToString();
                this.Postcode = myReader_Temp["Postcode"].ToString();
                this.WelderAddress = myReader_Temp["WelderAddress"].ToString();
                this.WelderTel = myReader_Temp["WelderTel"].ToString();
                this.WeldingExperiences = myReader_Temp["WeldingExperiences"].ToString();
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
            myParameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = this.KindofEmployer;
            myParameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = this.IdentificationCard;
            myParameters.Add("@WelderName", SqlDbType.NVarChar, 10).Value = this.WelderName;
            myParameters.Add("@Schooling", SqlDbType.NVarChar,20).Value = this.Schooling;
            myParameters.Add("@Sex", SqlDbType.NChar, 1).Value = this.Sex;
            myParameters.Add("@WeldingBeginning", SqlDbType.DateTime).Value = this.WeldingBeginning;
            myParameters.Add("@WelderRemark", SqlDbType.NVarChar, 255).Value = this.WelderRemark;
            myParameters.Add("@Postcode", SqlDbType.NVarChar, 10).Value = this.Postcode;
            myParameters.Add("@WelderAddress", SqlDbType.NVarChar, 255).Value = this.WelderAddress;
            myParameters.Add("@WelderTel", SqlDbType.NVarChar, 255).Value = this.WelderTel;
            myParameters.Add("@WeldingExperiences", SqlDbType.NVarChar, 255).Value = this.WeldingExperiences;
            myParameters.Add("@KindofEmployerWelderID", SqlDbType.Int ).Direction= ParameterDirection.InputOutput ;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@KindofEmployerWelderID"].Value = this.KindofEmployerWelderID;
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
        static public void ParametersAdd(SqlParameterCollection myParameters, int KindofEmployerWelderID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@KindofEmployerWelderID", SqlDbType.Int).Value = KindofEmployerWelderID;
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
            myCmd_Temp.CommandText = "SignUp_KindofEmployerWelder_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.KindofEmployerWelderID = (int)myCmd_Temp.Parameters["@KindofEmployerWelderID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "SignUp_KindofEmployerWelder", string.Format("{0}, {1}, {2}", this.KindofEmployerWelderID, this.KindofEmployer, this.IdentificationCard), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return true;
        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="Welder"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(int KindofEmployerWelderID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Delete)
            {
                Class_KindofEmployerWelder myClass_KindofEmployerWelder = new Class_KindofEmployerWelder(KindofEmployerWelderID);
                Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "SignUp_KindofEmployerWelder", string.Format("{0}, {1}, {2}", KindofEmployerWelderID, myClass_KindofEmployerWelder.KindofEmployer , myClass_KindofEmployerWelder.IdentificationCard), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            }

            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerWelder_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_KindofEmployerWelder.ParametersAdd(myCmd_Temp.Parameters, KindofEmployerWelderID, myEnum_zwjKindofUpdate);
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

        static public bool ExistSecond(string KindofEmployer, string IdentificationCard, int KindofEmployerWelderID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerWelder_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = KindofEmployer;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@KindofEmployerWelderID", SqlDbType.Int ).Value = KindofEmployerWelderID;
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
            else if (string.IsNullOrEmpty(this.KindofEmployer ))
            {
                return "报考单位不能为空！";
            }
            return this.myClass_BelongUnit .CheckField();

        }

        static public void TransferWelder(int KindofEmployerWelderID)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerWelder_Transfer";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@KindofEmployerWelderID", SqlDbType.Int).Value = KindofEmployerWelderID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
        }

    }
        
    public class Class_KindofEmployerIssue
    {
    #region "Fields"
        public Class_WeldingParameter myClass_WeldingParameter= new Class_WeldingParameter();

        public int KindofEmployerIssueID;
        public string IssueNo;
        public  string ShipClassificationAb;
        public string   ShipboardNo ;
        public DateTime  SignUpDate;
        public  string EmployerHPID;
        public  string KindofEmployer ;
        public  string WeldingProcessAb ;
        public string IssueWPSNo;
        public uint  IssueStatus ;
        public string  IssueRemark;
    #endregion

        public Class_KindofEmployerIssue()
        {
        }

        public Class_KindofEmployerIssue(int KindofEmployerIssueID)
        {
            this.KindofEmployerIssueID = KindofEmployerIssueID;
            this.FillData();
            
        }

        public static DataTable GetDataTable_KindofEmployerWelderStudent(int KindofEmployerIssueID, string str_Filter, string str_Sort)
        {
            string str_SQL = string.Format("Select * From View_SignUp_KindofEmployerStudent Where KindofEmployerIssueID={0}", KindofEmployerIssueID);
            if (str_Filter != null)
            {
                str_SQL = str_SQL + " And " + str_Filter;
            }
            if (str_Sort != null)
            {
                str_SQL = str_SQL + " Order by " + str_Sort;
            }
            return Class_zwjPublic.myClass_SqlConnection.GetDataTable(str_SQL);

        }
  
        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [SignUp_KindofEmployerIssue] Where KindofEmployerIssueID=@KindofEmployerIssueID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL,Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@KindofEmployerIssueID", SqlDbType.Int ).Value = this.KindofEmployerIssueID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp=myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.myClass_WeldingParameter.FillData (myReader_Temp, "Issue");

                this.IssueNo = myReader_Temp["IssueNo"].ToString();
                this.WeldingProcessAb = myReader_Temp["WeldingProcessAb"].ToString();
                this.ShipClassificationAb = myReader_Temp["ShipClassificationAb"].ToString();
                this.ShipboardNo = myReader_Temp["ShipboardNo"].ToString();
                this.SignUpDate =(DateTime ) myReader_Temp["SignUpDate"];
                this.EmployerHPID = myReader_Temp["IssueEmployerHPID"].ToString();
                //this.IssueStatus = Class_DataValidateTool.ConvertintTouint((int)myReader_Temp["IssueStatus"]);
                this.IssueStatus = (uint)(int)myReader_Temp["IssueStatus"];
                this.KindofEmployer = myReader_Temp["KindofEmployer"].ToString();
                this.IssueWPSNo = myReader_Temp["IssueWPSNo"].ToString();
                this.IssueRemark = myReader_Temp["IssueRemark"].ToString();
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
            this.myClass_WeldingParameter.ParametersAdd(myParameters, "Issue");
            myParameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = this.IssueNo;
            //myParameters.Add("@IssueStatus", SqlDbType.Int).Value = Class_DataValidateTool.CouvertuintToint(this.IssueStatus);
            myParameters.Add("@IssueStatus", SqlDbType.Int).Value = (int)this.IssueStatus;
            myParameters.Add("@SignUpDate", SqlDbType.DateTime).Value = this.SignUpDate;
            myParameters.Add("@WeldingProcessAb", SqlDbType.NVarChar, 10).Value = this.WeldingProcessAb;
            myParameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = this.ShipClassificationAb;
            myParameters.Add("@ShipboardNo", SqlDbType.NVarChar, 10).Value = this.ShipboardNo;
            myParameters.Add("@IssueEmployerHPID", SqlDbType.NChar, 4).Value = this.EmployerHPID;
            myParameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = this.KindofEmployer;
            myParameters.Add("@IssueWPSNo", SqlDbType.NVarChar,50).Value = this.IssueWPSNo;
            myParameters.Add("@IssueRemark", SqlDbType.NVarChar, 255).Value = this.IssueRemark;
            myParameters.Add("@KindofEmployerIssueID", SqlDbType.Int ).Direction = ParameterDirection.InputOutput;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@KindofEmployerIssueID"].Value = this.KindofEmployerIssueID;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="KindofEmployerStudent"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, int KindofEmployerIssueID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@KindofEmployerIssueID", SqlDbType.Int).Value = KindofEmployerIssueID;
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
            myCmd_Temp.CommandText = "SignUp_KindofEmployerIssue_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.KindofEmployerIssueID =(int) myCmd_Temp.Parameters["@KindofEmployerIssueID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "SignUp_KindofEmployerIssue", string.Format("{0}, {1}, {2}", this.KindofEmployerIssueID , this.KindofEmployer, this.IssueNo ), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return true ;

        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="KindofEmployerStudent"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(int KindofEmployerIssueID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Delete)
            {
                Class_KindofEmployerIssue myClass_KindofEmployerIssue = new Class_KindofEmployerIssue(KindofEmployerIssueID);
                Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "SignUp_KindofEmployerIssue", string.Format("{0}, {1}, {2}", KindofEmployerIssueID, myClass_KindofEmployerIssue.KindofEmployer, myClass_KindofEmployerIssue.IssueNo ), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            }
            
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerIssue_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_KindofEmployerIssue.ParametersAdd(myCmd_Temp.Parameters, KindofEmployerIssueID, myEnum_zwjKindofUpdate);
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

        static public bool ExistSecond(string KindofEmployer, string IssueNo, int KindofEmployerIssueID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerIssue_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = KindofEmployer;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@KindofEmployerIssueID", SqlDbType.Int).Value = KindofEmployerIssueID;
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

        /// <summary>
        /// 校验数据字段的格式
        /// </summary>
        /// <returns></returns>
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.EmployerHPID))
            {
                return "公司编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.IssueNo ))
            {
                return "班级名称不能为空！";
            }
            else if (string.IsNullOrEmpty(this.KindofEmployer))
            {
                return "报考单位不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShipClassificationAb))
            {
                return "船级社不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingProcessAb))
            {
                return "焊接方法不能为空！";
            }
            return this.myClass_WeldingParameter.CheckField();
        }

        static public int CheckSignUp(int KindofEmployerIssueID, bool GXTheory)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerIssue_CheckSignUp";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@KindofEmployerIssueID", SqlDbType.Int ).Value = KindofEmployerIssueID;
            myCmd_Temp.Parameters.Add("@GXTheory", SqlDbType.Bit).Value = GXTheory;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction= ParameterDirection.Output ;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return (int)myCmd_Temp.Parameters["@ReturnNum"].Value;
        }

        static public string TransferIssue(int KindofEmployerIssueID)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerIssue_TransferIssue";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@KindofEmployerIssueID", SqlDbType.Int ).Value = KindofEmployerIssueID;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar ,20).Direction = ParameterDirection.Output;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return myCmd_Temp.Parameters["@IssueNo"].Value.ToString();
        }

        static public string TransferGXTheoryIssue(int KindofEmployerIssueID)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerIssue_TransferGXTheoryIssue";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@KindofEmployerIssueID", SqlDbType.Int).Value = KindofEmployerIssueID;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return myCmd_Temp.Parameters["@IssueNo"].Value.ToString();
        }
    }

    public class Class_KindofEmployerStudent
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public int KindofEmployerStudentID;
        public int KindofEmployerIssueID;
        public int KindofEmployerWelderID;
        public string ExamSubjectID;
        public string StudentKindofExam;
        public string StudentRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_KindofEmployerStudent()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="KindofEmployerStudent"></param>
        public Class_KindofEmployerStudent(int KindofEmployerStudentID)
        {
            this.KindofEmployerStudentID = KindofEmployerStudentID;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [SignUp_KindofEmployerStudent] Where KindofEmployerStudentID=@KindofEmployerStudentID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@KindofEmployerStudentID", SqlDbType.Int).Value = this.KindofEmployerStudentID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.KindofEmployerIssueID = (int)myReader_Temp["KindofEmployerIssueID"];
                this.KindofEmployerWelderID = (int)myReader_Temp["KindofEmployerWelderID"];
                this.ExamSubjectID = myReader_Temp["ExamSubjectID"].ToString();
                this.StudentKindofExam = myReader_Temp["StudentKindofExam"].ToString();
                this.StudentRemark = myReader_Temp["StudentRemark"].ToString();
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
            myParameters.Add("@KindofEmployerIssueID", SqlDbType.Int).Value = this.KindofEmployerIssueID;
            myParameters.Add("@KindofEmployerWelderID", SqlDbType.Int).Value = this.KindofEmployerWelderID;
            myParameters.Add("@ExamSubjectID", SqlDbType.NChar, 4).Value = this.ExamSubjectID;
            myParameters.Add("@StudentKindofExam", SqlDbType.NVarChar, 10).Value = this.StudentKindofExam;
            myParameters.Add("@StudentRemark", SqlDbType.NVarChar, 255).Value = this.StudentRemark;
            myParameters.Add("@KindofEmployerStudentID", SqlDbType.Int).Direction= ParameterDirection.InputOutput ;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@KindofEmployerStudentID"].Value = this.KindofEmployerStudentID ;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="KindofEmployerStudent"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, int KindofEmployerStudentID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@KindofEmployerStudentID", SqlDbType.Int).Value = KindofEmployerStudentID;
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
            myCmd_Temp.CommandText = "SignUp_KindofEmployerStudent_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.KindofEmployerStudentID = (int)myCmd_Temp.Parameters["@KindofEmployerStudentID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "SignUp_KindofEmployerStudent", string.Format("{0}, {1}, {2}", this.KindofEmployerStudentID , this.KindofEmployerIssueID , this.KindofEmployerWelderID ), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return true;
        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="KindofEmployerStudent"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(int KindofEmployerStudentID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Delete)
            {
                Class_KindofEmployerStudent myClass_KindofEmployerStudent = new Class_KindofEmployerStudent(KindofEmployerStudentID);
                Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "SignUp_KindofEmployerStudent", string.Format("{0}, {1}, {2}", myClass_KindofEmployerStudent.KindofEmployerStudentID, myClass_KindofEmployerStudent.KindofEmployerIssueID, myClass_KindofEmployerStudent.KindofEmployerWelderID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            }
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerStudent_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_KindofEmployerStudent.ParametersAdd(myCmd_Temp.Parameters, KindofEmployerStudentID, myEnum_zwjKindofUpdate);
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
        static public bool ExistSecond(int KindofEmployerIssueID, int KindofEmployerWelderID, int KindofEmployerStudentID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerStudent_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@KindofEmployerIssueID", SqlDbType.Int).Value = KindofEmployerIssueID;
            myCmd_Temp.Parameters.Add("@KindofEmployerWelderID", SqlDbType.Int).Value = KindofEmployerWelderID;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@KindofEmployerStudentID", SqlDbType.Int).Value = KindofEmployerStudentID;
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

        /// <summary>
        /// 校验数据字段的格式
        /// </summary>
        /// <returns></returns>
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.ExamSubjectID))
            {
                return "考试科目编号不能为空！";
            }
            else if (this.KindofEmployerIssueID<=0)
            {
                return "班级编号不能为空！";
            }
            else if (this.KindofEmployerWelderID  <=0)
            {
                return "焊工编号不能为空！";
            }

            return null;
        }

    }


}
