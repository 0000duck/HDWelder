 using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ZCCL.ClassBase;

namespace ZCWelder.ClassBase
{
    public class Class_EmployerGroup
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string EmployerGroup;
        public bool  OAVisible;
        public int EmployerGroupIndex;
        public string EmployerGroupRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_EmployerGroup()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="EmployerGroup"></param>
        public Class_EmployerGroup(string EmployerGroup)
        {
            this.EmployerGroup = EmployerGroup;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Unit_EmployerGroup] Where EmployerGroup=@EmployerGroup";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@EmployerGroup", SqlDbType.NVarChar, 10).Value = this.EmployerGroup;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.OAVisible = (bool )myReader_Temp["OAVisible"];
                this.EmployerGroupIndex = (int)myReader_Temp["EmployerGroupIndex"];
                this.EmployerGroupRemark = myReader_Temp["EmployerGroupRemark"].ToString();
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
            myParameters.Add("@EmployerGroup", SqlDbType.NVarChar, 10).Value = this.EmployerGroup;
            myParameters.Add("@OAVisible", SqlDbType.Bit ).Value = this.OAVisible;
            myParameters.Add("@EmployerGroupIndex", SqlDbType.Int).Value = this.EmployerGroupIndex;
            myParameters.Add("@EmployerGroupRemark", SqlDbType.NVarChar, 255).Value = this.EmployerGroupRemark;

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
        /// <param name="EmployerGroup"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string EmployerGroup, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@EmployerGroup", SqlDbType.NVarChar, 10).Value = EmployerGroup;
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
            myCmd_Temp.CommandText = "Unit_EmployerGroup_Update";
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
        /// <param name="EmployerGroup"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string EmployerGroup, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_EmployerGroup_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_EmployerGroup.ParametersAdd(myCmd_Temp.Parameters, EmployerGroup, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.EmployerGroup))
            {
                return "数据网格控件组不能为空！";
            }

            return null;
        }

    }

    public class Class_Employer
    {
        #region "Fields"
        public string EmployerHPID;
        public string Employer;
        public string EmployerEnglish;
        public string ShortenedEmployer;
        public string EmployerGroup;
        public string EmployerAddress;
        public string EmployerAddressEnglish;
        public string EmployerTel;
        public string EmployerFax;
        public string EmployerMobile;
        public string EmployerEmail;
        public string EmployerPostalcode;
        public string EmployerCity;
        public string EmployerRemark;
        public string EmployerLinkman;
        public int EmployerIndex;
        static public Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Employer .ToString()];
        #endregion

        public Class_Employer()
        {

        }

        public Class_Employer(string EmployerHPID)
        {
            this.EmployerHPID = EmployerHPID;
            this.FillData();
        }

        static public string GetEmployerHPIDbyDataTable(string str_Employer)
        {
            DataRow [] myDataRow_Range ;
            string str_EmployerHPID = "";
            myDataRow_Range = Class_Employer.myClass_Data.myDataTable.Select(string.Format("Employer='{0}'", str_Employer ));
            if (myDataRow_Range.Length > 0)
            {
                str_EmployerHPID = myDataRow_Range[0]["EmployerHPID"].ToString();
            }
            return str_EmployerHPID;
        }

        static public string GetEmployerHPID(string str_Employer)
        {
            string str_EmployerHPID = "";
            string str_SQL = "Select EmployerHPID From [Unit_Employer] Where Employer=@Employer";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@Employer", SqlDbType.NVarChar, 50).Value = str_Employer;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.Read())
            {
                str_EmployerHPID = myReader_Temp["EmployerHPID"].ToString();
            }
            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return str_EmployerHPID;
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Unit_Employer] Where EmployerHPID=@EmployerHPID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Value = this.EmployerHPID;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.EmployerEnglish = myReader_Temp["EmployerEnglish"].ToString();
                this.Employer = myReader_Temp["Employer"].ToString();
                this.ShortenedEmployer = myReader_Temp["ShortenedEmployer"].ToString();
                this.EmployerGroup = myReader_Temp["EmployerGroup"].ToString();
                this.EmployerAddress = myReader_Temp["EmployerAddress"].ToString();
                this.EmployerAddressEnglish = myReader_Temp["EmployerAddressEnglish"].ToString();
                this.EmployerTel = myReader_Temp["EmployerTel"].ToString();
                this.EmployerFax = myReader_Temp["EmployerFax"].ToString();
                this.EmployerMobile = myReader_Temp["EmployerMobile"].ToString();
                this.EmployerEmail = myReader_Temp["EmployerEmail"].ToString();
                this.EmployerCity = myReader_Temp["EmployerCity"].ToString();
                this.EmployerPostalcode = myReader_Temp["EmployerPostalcode"].ToString();
                this.EmployerLinkman = myReader_Temp["EmployerLinkman"].ToString();
                this.EmployerRemark = myReader_Temp["EmployerRemark"].ToString();
                this.EmployerIndex = (int)myReader_Temp["EmployerIndex"];
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

        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@Employer", SqlDbType.NVarChar, 50).Value = this.Employer;
            myParameters.Add("@EmployerEnglish", SqlDbType.NVarChar, 100).Value = this.EmployerEnglish;
            myParameters.Add("@ShortenedEmployer", SqlDbType.NVarChar, 10).Value = this.ShortenedEmployer;
            myParameters.Add("@EmployerGroup", SqlDbType.NVarChar, 10).Value = this.EmployerGroup;
            myParameters.Add("@EmployerAddress", SqlDbType.NVarChar, 255).Value = this.EmployerAddress;
            myParameters.Add("@EmployerAddressEnglish", SqlDbType.NVarChar, 255).Value = this.EmployerAddressEnglish;
            myParameters.Add("@EmployerFax", SqlDbType.NVarChar, 50).Value = this.EmployerFax;
            myParameters.Add("@EmployerTel", SqlDbType.NVarChar, 50).Value = this.EmployerTel;
            myParameters.Add("@EmployerMobile", SqlDbType.NVarChar, 50).Value = this.EmployerMobile;
            myParameters.Add("@EmployerEmail", SqlDbType.NVarChar, 100).Value = this.EmployerEmail;
            myParameters.Add("@EmployerCity", SqlDbType.NVarChar, 50).Value = this.EmployerCity;
            myParameters.Add("@EmployerPostalcode", SqlDbType.NVarChar, 50).Value = this.EmployerPostalcode;
            myParameters.Add("@EmployerLinkman", SqlDbType.NVarChar, 50).Value = this.EmployerLinkman;
            myParameters.Add("@EmployerRemark", SqlDbType.NVarChar, 255).Value = this.EmployerRemark;
            myParameters.Add("@EmployerIndex", SqlDbType.Int).Value = this.EmployerIndex;
            myParameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Direction = ParameterDirection.InputOutput;
            myParameters["@EmployerHPID"].Value = this.EmployerHPID;

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

        static public void ParametersAdd(SqlParameterCollection myParameters, string EmployerHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Value = EmployerHPID;
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

        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_Employer_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if (myCmd_Temp.Parameters["@EmployerHPID"].Value == DBNull.Value)
            {
                return false;
            }
            else
            {
                this.EmployerHPID = (string)myCmd_Temp.Parameters["@EmployerHPID"].Value;
                return true;
            }
        }

        static public bool ExistAndCanDeleteAndDelete(string EmployerHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_Employer_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Employer.ParametersAdd(myCmd_Temp.Parameters, EmployerHPID, myEnum_zwjKindofUpdate);
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

        static public bool ExistSecond(string Employer, string EmployerHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_Employer_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@Employer", SqlDbType.NVarChar, 20).Value = Employer;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Value = EmployerHPID;
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

        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.EmployerGroup))
            {
                return "公司组不能为空！";
            }
            //else if (string.IsNullOrEmpty(this.EmployerHPID))
            //{
            //    return "公司编号不能为空！";
            //}
            else if (string.IsNullOrEmpty(this.Employer))
            {
                return "公司名称不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShortenedEmployer))
            {
                return "公司简称不能为空！";
            }

            return null;
        }

        static public void StatisticWelderQC(string EmployerHPID, string ShipClassificationAb, string ShipboardNo)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_Employer_StatisticWelderQC";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Value = EmployerHPID;
            if (!string.IsNullOrEmpty(ShipClassificationAb))
            {
                myCmd_Temp.Parameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = ShipClassificationAb;
            }
            if (!string.IsNullOrEmpty(ShipboardNo))
            {
                myCmd_Temp.Parameters.Add("@ShipboardNo", SqlDbType.NVarChar, 20).Value = ShipboardNo;
            }
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);

        }

    }

    public class Class_Department
    {
        #region "Fields"
        public string DepartmentHPID;
        public string EmployerHPID;
        public string Department;
        public string DepartmentEnglish;
        public string ShortenedDepartment;
        public int DepartmentIndex;
        public string DepartmentRemark;
        static public Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Department.ToString()];
        #endregion

        public Class_Department()
        {

        }

        public Class_Department(string DepartmentHPID)
        {
            this.DepartmentHPID = DepartmentHPID;
            this.FillData();
        }

        static public string GetDepartmentHPIDbyDataTable(string EmployerHPID, string Department)
        {
            DataRow[] myDataRow_Range;
            string str_DepartmentHPID = "";
            myDataRow_Range = Class_Department.myClass_Data.myDataTable.Select(string.Format("EmployerHPID='{0}' And Department='{1}'", EmployerHPID, Department));
            if (myDataRow_Range.Length > 0)
            {
                str_DepartmentHPID = myDataRow_Range[0]["DepartmentHPID"].ToString();
            }
            return str_DepartmentHPID;
        }

        static public string GetDepartmentHPID(string EmployerHPID, string Department)
        {
            string DepartmentHPID;
            string str_SQL = "Select DepartmentHPID From [Unit_Department] Where EmployerHPID=@EmployerHPID And Department=@Department";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Value = EmployerHPID;
            myCmd_Temp.Parameters.Add("@Department", SqlDbType.NVarChar, 20).Value = Department;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.Read())
            {
                DepartmentHPID = myReader_Temp["DepartmentHPID"].ToString();
            }
            else
            {
                DepartmentHPID = null;
            }
            myReader_Temp.Close ();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return DepartmentHPID;
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Unit_Department] Where DepartmentHPID=@DepartmentHPID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@DepartmentHPID", SqlDbType.NChar, 6).Value = this.DepartmentHPID;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.EmployerHPID = myReader_Temp["EmployerHPID"].ToString();
                this.Department = myReader_Temp["Department"].ToString();
                this.DepartmentEnglish = myReader_Temp["DepartmentEnglish"].ToString();
                this.ShortenedDepartment = myReader_Temp["ShortenedDepartment"].ToString();
                this.DepartmentRemark = myReader_Temp["DepartmentRemark"].ToString();
                this.DepartmentIndex = (int)myReader_Temp["DepartmentIndex"];
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

        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Value = this.EmployerHPID;
            myParameters.Add("@Department", SqlDbType.NVarChar, 20).Value = this.Department;
            myParameters.Add("@DepartmentEnglish", SqlDbType.NVarChar, 100).Value = this.DepartmentEnglish;
            myParameters.Add("@ShortenedDepartment", SqlDbType.NVarChar, 10).Value = this.ShortenedDepartment;
            myParameters.Add("@DepartmentIndex", SqlDbType.Int).Value = this.DepartmentIndex;
            myParameters.Add("@DepartmentRemark", SqlDbType.NVarChar, 255).Value = this.DepartmentRemark;
            myParameters.Add("@DepartmentHPID", SqlDbType.NChar, 6).Direction = ParameterDirection.InputOutput;
            myParameters["@DepartmentHPID"].Value = this.DepartmentHPID;

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

        static public void ParametersAdd(SqlParameterCollection myParameters, string DepartmentHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@DepartmentHPID", SqlDbType.NChar, 6).Value = DepartmentHPID;
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

        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_Department_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if (myCmd_Temp.Parameters["@DepartmentHPID"].Value == DBNull.Value)
            {
                return false;
            }
            else
            {
                this.DepartmentHPID = (string)myCmd_Temp.Parameters["@DepartmentHPID"].Value;
                return true;
            }
        }

        static public bool ExistAndCanDeleteAndDelete(string DepartmentHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_Department_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Department.ParametersAdd(myCmd_Temp.Parameters, DepartmentHPID, myEnum_zwjKindofUpdate);
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

        static public bool ExistSecond(string EmployerHPID, string Department, string DepartmentHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_Department_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Value = EmployerHPID;
            myCmd_Temp.Parameters.Add("@Department", SqlDbType.NVarChar, 20).Value = Department;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@DepartmentHPID", SqlDbType.NChar, 6).Value = DepartmentHPID;
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

        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.EmployerHPID))
            {
                return "公司编号不能为空！";
            }
            else if (!Class_Employer.ExistAndCanDeleteAndDelete(this.EmployerHPID, Enum_zwjKindofUpdate.Exist))
            {
                return "公司编号不存在！";
            }
            //else if (string.IsNullOrEmpty(this.DepartmentHPID))
            //{
            //    return "部门编号不能为空！";
            //}
            else if (string.IsNullOrEmpty(this.Department))
            {
                return "部门名称不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShortenedDepartment))
            {
                return "部门简称不能为空！";
            }

            return null;
        }

        static public void StatisticWelderQC(string DepartmentHPID, string ShipClassificationAb, string ShipboardNo)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_Department_StatisticWelderQC";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@DepartmentHPID", SqlDbType.NChar, 6).Value = DepartmentHPID;
            if (!string.IsNullOrEmpty(ShipClassificationAb))
            {
                myCmd_Temp.Parameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = ShipClassificationAb;
            }
            if (!string.IsNullOrEmpty(ShipboardNo))
            {
                myCmd_Temp.Parameters.Add("@ShipboardNo", SqlDbType.NVarChar, 20).Value = ShipboardNo;
            }
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);

        }

    }

    public class Class_WorkPlace
    {
        #region "Fields"
        public string WorkPlaceHPID;
        public string DepartmentHPID;
        public string WorkPlace;
        public string WorkPlaceEnglish;
        public string ShortenedWorkPlace;
        public int WorkPlaceIndex;
        public string WorkPlaceRemark;
        static public Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.WorkPlace.ToString()];
        #endregion

        public Class_WorkPlace()
        {

        }

        public Class_WorkPlace(string WorkPlaceHPID)
        {
            this.WorkPlaceHPID = WorkPlaceHPID;
            this.FillData();
        }

        static public string GetWorkPlaceHPIDbyDataTable(string DepartmentHPID, string WorkPlace)
        {
            DataRow[] myDataRow_Range;
            string str_WorkPlaceHPID = "";
            myDataRow_Range = Class_WorkPlace.myClass_Data.myDataTable.Select(string.Format("DepartmentHPID='{0}' And WorkPlace='{1}'", DepartmentHPID, WorkPlace));
            if (myDataRow_Range.Length > 0)
            {
                str_WorkPlaceHPID = myDataRow_Range[0]["WorkPlaceHPID"].ToString();
            }
            return str_WorkPlaceHPID;
        }

        static public string GetWorkPlaceHPID(string DepartmentHPID, string WorkPlace)
        {
            string WorkPlaceHPID;
            string str_SQL = "Select WorkPlaceHPID From [Unit_WorkPlace] Where DepartmentHPID=@DepartmentHPID And WorkPlace=@WorkPlace";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@DepartmentHPID", SqlDbType.NChar, 6).Value = DepartmentHPID;
            myCmd_Temp.Parameters.Add("@WorkPlace", SqlDbType.NVarChar, 20).Value = WorkPlace;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.Read())
            {
                WorkPlaceHPID = myReader_Temp["WorkPlaceHPID"].ToString();
            }
            else
            {
                WorkPlaceHPID = null;
            }
            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return WorkPlaceHPID;
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Unit_WorkPlace] Where WorkPlaceHPID=@WorkPlaceHPID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WorkPlaceHPID", SqlDbType.NChar, 8).Value = this.WorkPlaceHPID;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.DepartmentHPID = myReader_Temp["DepartmentHPID"].ToString();
                this.WorkPlace = myReader_Temp["WorkPlace"].ToString();
                this.WorkPlaceEnglish = myReader_Temp["WorkPlaceEnglish"].ToString();
                this.ShortenedWorkPlace = myReader_Temp["ShortenedWorkPlace"].ToString();
                this.WorkPlaceRemark = myReader_Temp["WorkPlaceRemark"].ToString();
                this.WorkPlaceIndex = (int)myReader_Temp["WorkPlaceIndex"];
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

        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@DepartmentHPID", SqlDbType.NChar, 6).Value = this.DepartmentHPID;
            myParameters.Add("@WorkPlace", SqlDbType.NVarChar, 20).Value = this.WorkPlace;
            myParameters.Add("@WorkPlaceEnglish", SqlDbType.NVarChar, 100).Value = this.WorkPlaceEnglish;
            myParameters.Add("@ShortenedWorkPlace", SqlDbType.NVarChar, 10).Value = this.ShortenedWorkPlace;
            myParameters.Add("@WorkPlaceIndex", SqlDbType.Int).Value = this.WorkPlaceIndex;
            myParameters.Add("@WorkPlaceRemark", SqlDbType.NVarChar, 255).Value = this.WorkPlaceRemark;
            myParameters.Add("@WorkPlaceHPID", SqlDbType.NChar, 8).Direction = ParameterDirection.InputOutput;
            myParameters["@WorkPlaceHPID"].Value = this.WorkPlaceHPID;

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

        static public void ParametersAdd(SqlParameterCollection myParameters, string WorkPlaceHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WorkPlaceHPID", SqlDbType.NChar, 8).Value = WorkPlaceHPID;
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

        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_WorkPlace_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if (myCmd_Temp.Parameters["@WorkPlaceHPID"].Value == DBNull.Value)
            {
                return false;
            }
            else
            {
                this.DepartmentHPID = (string)myCmd_Temp.Parameters["@WorkPlaceHPID"].Value;
                return true;
            }
        }

        static public bool ExistAndCanDeleteAndDelete(string WorkPlace, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_WorkPlace_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WorkPlace.ParametersAdd(myCmd_Temp.Parameters, WorkPlace, myEnum_zwjKindofUpdate);
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

        static public bool ExistSecond(string DepartmentHPID, string WorkPlace, string WorkPlaceHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_WorkPlace_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@DepartmentHPID", SqlDbType.NChar, 6).Value = DepartmentHPID;
            myCmd_Temp.Parameters.Add("@WorkPlace", SqlDbType.NVarChar, 20).Value = WorkPlace;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@WorkPlaceHPID", SqlDbType.NChar, 8).Value = WorkPlaceHPID;
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

        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.DepartmentHPID))
            {
                return "部门编号不能为空！";
            }
            else if (!Class_Department.ExistAndCanDeleteAndDelete(this.DepartmentHPID, Enum_zwjKindofUpdate.Exist))
            {
                return "部门编号不存在！";
            }
            //else if (string.IsNullOrEmpty(this.WorkPlaceHPID))
            //{
            //    return "作业区编号不能为空！";
            //}
            else if (string.IsNullOrEmpty(this.WorkPlace))
            {
                return "作业区名称不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShortenedWorkPlace))
            {
                return "作业区简称不能为空！";
            }

            return null;
        }

        static public void StatisticWelderQC(string WorkPlaceHPID, string ShipClassificationAb, string ShipboardNo)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_WorkPlace_StatisticWelderQC";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@WorkPlaceHPID", SqlDbType.NChar, 8).Value = WorkPlaceHPID;
            if (!string.IsNullOrEmpty(ShipClassificationAb))
            {
                myCmd_Temp.Parameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = ShipClassificationAb;
            }
            if (!string.IsNullOrEmpty(ShipboardNo))
            {
                myCmd_Temp.Parameters.Add("@ShipboardNo", SqlDbType.NVarChar, 20).Value = ShipboardNo;
            }
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);

        }

    }

    public class Class_LaborServiceTeam
    {
        #region "Fields"
        public string LaborServiceTeamHPID;
        public string EmployerHPID;
        public string LaborServiceTeam;
        public string LaborServiceTeamEnglish;
        public string ShortenedLaborServiceTeam;
        public int LaborServiceTeamIndex;
        public string LaborServiceTeamRemark;
        static public Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.LaborServiceTeam.ToString()];
        #endregion

        public Class_LaborServiceTeam()
        {

        }

        public Class_LaborServiceTeam(string LaborServiceTeamHPID)
        {
            this.LaborServiceTeamHPID = LaborServiceTeamHPID;
            this.FillData();
        }

        static public string GetLaborServiceTeamHPIDbyDataTable(string EmployerHPID, string LaborServiceTeam)
        {
            DataRow[] myDataRow_Range;
            string str_LaborServiceTeamHPID = "";
            myDataRow_Range = Class_LaborServiceTeam.myClass_Data.myDataTable.Select(string.Format("EmployerHPID='{0}' And LaborServiceTeam='{1}'", EmployerHPID, LaborServiceTeam));
            if (myDataRow_Range.Length > 0)
            {
                str_LaborServiceTeamHPID = myDataRow_Range[0]["LaborServiceTeamHPID"].ToString();
            }
            return str_LaborServiceTeamHPID;
        }

        static public string GetLaborServiceTeamHPID(string EmployerHPID, string LaborServiceTeam)
        {
            string LaborServiceTeamHPID;
            string str_SQL = "Select LaborServiceTeamHPID From [Unit_LaborServiceTeam] Where EmployerHPID=@EmployerHPID And LaborServiceTeam=@LaborServiceTeam";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Value = EmployerHPID;
            myCmd_Temp.Parameters.Add("@LaborServiceTeam", SqlDbType.NVarChar, 20).Value = LaborServiceTeam;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.Read())
            {
                LaborServiceTeamHPID = myReader_Temp["LaborServiceTeamHPID"].ToString();
            }
            else
            {
                LaborServiceTeamHPID = null;
            }
            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return LaborServiceTeamHPID;
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Unit_LaborServiceTeam] Where LaborServiceTeamHPID=@LaborServiceTeamHPID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@LaborServiceTeamHPID", SqlDbType.NChar, 7).Value = this.LaborServiceTeamHPID;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.EmployerHPID = myReader_Temp["EmployerHPID"].ToString();
                this.LaborServiceTeam = myReader_Temp["LaborServiceTeam"].ToString();
                this.LaborServiceTeamEnglish = myReader_Temp["LaborServiceTeamEnglish"].ToString();
                this.ShortenedLaborServiceTeam = myReader_Temp["ShortenedLaborServiceTeam"].ToString();
                this.LaborServiceTeamRemark = myReader_Temp["LaborServiceTeamRemark"].ToString();
                this.LaborServiceTeamIndex = (int)myReader_Temp["LaborServiceTeamIndex"];
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

        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Value = this.EmployerHPID;
            myParameters.Add("@LaborServiceTeam", SqlDbType.NVarChar, 20).Value = this.LaborServiceTeam;
            myParameters.Add("@LaborServiceTeamEnglish", SqlDbType.NVarChar, 100).Value = this.LaborServiceTeamEnglish;
            myParameters.Add("@ShortenedLaborServiceTeam", SqlDbType.NVarChar, 10).Value = this.ShortenedLaborServiceTeam;
            myParameters.Add("@LaborServiceTeamIndex", SqlDbType.Int).Value = this.LaborServiceTeamIndex;
            myParameters.Add("@LaborServiceTeamRemark", SqlDbType.NVarChar, 255).Value = this.LaborServiceTeamRemark;
            myParameters.Add("@LaborServiceTeamHPID", SqlDbType.NChar, 7).Direction = ParameterDirection.InputOutput;
            myParameters["@LaborServiceTeamHPID"].Value = this.LaborServiceTeamHPID;

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

        static public void ParametersAdd(SqlParameterCollection myParameters, string LaborServiceTeamHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@LaborServiceTeamHPID", SqlDbType.NChar, 7).Value = LaborServiceTeamHPID;
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

        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_LaborServiceTeam_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if (myCmd_Temp.Parameters["@LaborServiceTeamHPID"].Value == DBNull.Value)
            {
                return false;
            }
            else
            {
                this.LaborServiceTeamHPID = (string)myCmd_Temp.Parameters["@LaborServiceTeamHPID"].Value;
                return true;
            }
        }

        static public bool ExistAndCanDeleteAndDelete(string LaborServiceTeamHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_LaborServiceTeam_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_LaborServiceTeam.ParametersAdd(myCmd_Temp.Parameters, LaborServiceTeamHPID, myEnum_zwjKindofUpdate);
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

        static public bool ExistSecond(string EmployerHPID, string LaborServiceTeam, string LaborServiceTeamHPID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_LaborServiceTeam_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@EmployerHPID", SqlDbType.NChar, 4).Value = EmployerHPID;
            myCmd_Temp.Parameters.Add("@LaborServiceTeam", SqlDbType.NVarChar, 20).Value = LaborServiceTeam;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@LaborServiceTeamHPID", SqlDbType.NChar, 7).Value = LaborServiceTeamHPID;
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

        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.EmployerHPID))
            {
                return "公司编号不能为空！";
            }
            else if (!Class_Employer.ExistAndCanDeleteAndDelete(this.EmployerHPID, Enum_zwjKindofUpdate.Exist))
            {
                return "公司编号不存在！";
            }
            //else if (string.IsNullOrEmpty(this.LaborServiceTeamHPID))
            //{
            //    return "部门编号不能为空！";
            //}
            else if (string.IsNullOrEmpty(this.LaborServiceTeam))
            {
                return "劳务队名称不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShortenedLaborServiceTeam))
            {
                return "劳务队简称不能为空！";
            }

            return null;
        }

    }

    public class Class_Schooling
    {
        #region "Fields"
        public string Schooling;
        public int SchoolingIndex;
        public string SchoolingRemark;
        static public Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.Schooling .ToString()];
        #endregion

        public Class_Schooling()
        {

        }

        public Class_Schooling(string Schooling)
        {
            this.Schooling = Schooling;
            this.FillData();
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_Schooling] Where Schooling=@Schooling";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@Schooling", SqlDbType.NVarChar, 20).Value = this.Schooling;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.SchoolingRemark = myReader_Temp["SchoolingRemark"].ToString();
                this.SchoolingIndex = (int)myReader_Temp["SchoolingIndex"];
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

        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@Schooling", SqlDbType.NVarChar, 20).Value = this.Schooling;
            myParameters.Add("@SchoolingIndex", SqlDbType.Int).Value = this.SchoolingIndex;
            myParameters.Add("@SchoolingRemark", SqlDbType.NVarChar, 255).Value = this.SchoolingRemark;

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

        static public void ParametersAdd(SqlParameterCollection myParameters, string Schooling, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@Schooling", SqlDbType.NVarChar, 20).Value = Schooling;
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

        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_Schooling_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        static public bool ExistAndCanDeleteAndDelete(string Schooling, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_Schooling_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Schooling.ParametersAdd(myCmd_Temp.Parameters, Schooling, myEnum_zwjKindofUpdate);
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

        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.Schooling))
            {
                return "学历不能为空！";
            }

            return null;
        }

    }

    public class Class_WeldingProcess
    {
        #region "Fields"
        public string WeldingProcessAb;
        public string WeldingProcessNo;
        public string WeldingProcess;
        public bool MultiWeldingProcess;
        public string WeldingProcessEnglishName;
        public string ProtectGas;
        public string KindofCCSWeldingProcess;
        public string CCSWeldingProcess;
        public string ScopeofCCSWeldingProcess;
        public string WeldingProcessRemark;
        public int WeldingProcessIndex;
        #endregion

        public Class_WeldingProcess()
        {

        }

        public Class_WeldingProcess(string WeldingProcessAb)
        {
            this.WeldingProcessAb = WeldingProcessAb;
            this.FillData();
        }

        static public bool Exist(string WeldingProcessAb)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingProcess_Exist";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@WeldingProcessAb", SqlDbType.NVarChar, 10).Value = WeldingProcessAb;
            myCmd_Temp.Parameters.Add("@NumRows", SqlDbType.Int).Direction = ParameterDirection.Output;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@NumRows"].Value > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_WeldingProcess] Where WeldingProcessAb=@WeldingProcessAb";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WeldingProcessAb", SqlDbType.NVarChar, 10).Value = this.WeldingProcessAb;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;
            if (myReader_Temp.Read())
            {
                this.WeldingProcessAb = myReader_Temp["WeldingProcessAb"].ToString();
                this.WeldingProcessRemark = myReader_Temp["WeldingProcessRemark"].ToString();
                this.WeldingProcessNo = myReader_Temp["WeldingProcessNo"].ToString();
                this.WeldingProcess = myReader_Temp["WeldingProcess"].ToString();
                this.MultiWeldingProcess = (bool)myReader_Temp["MultiWeldingProcess"];
                this.WeldingProcessEnglishName = myReader_Temp["WeldingProcessEnglishName"].ToString();
                this.ProtectGas = myReader_Temp["ProtectGas"].ToString();
                this.KindofCCSWeldingProcess = myReader_Temp["KindofCCSWeldingProcess"].ToString();
                this.CCSWeldingProcess = myReader_Temp["CCSWeldingProcess"].ToString();
                this.ScopeofCCSWeldingProcess = myReader_Temp["ScopeofCCSWeldingProcess"].ToString();
                this.WeldingProcessIndex = (int)myReader_Temp["WeldingProcessIndex"];
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

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingProcessAb", SqlDbType.NVarChar, 10).Value = this.WeldingProcessAb;
            myParameters.Add("@WeldingProcessNo", SqlDbType.NVarChar, 10).Value = this.WeldingProcessNo;
            myParameters.Add("@WeldingProcess", SqlDbType.NVarChar, 50).Value = this.WeldingProcess;
            myParameters.Add("@WeldingProcessEnglishName", SqlDbType.NVarChar, 50).Value = this.WeldingProcessEnglishName;
            myParameters.Add("@ProtectGas", SqlDbType.NVarChar, 50).Value = this.ProtectGas;
            myParameters.Add("@KindofCCSWeldingProcess", SqlDbType.NVarChar, 10).Value = this.KindofCCSWeldingProcess;
            myParameters.Add("@CCSWeldingProcess", SqlDbType.NVarChar, 50).Value = this.CCSWeldingProcess;
            myParameters.Add("@ScopeofCCSWeldingProcess", SqlDbType.NVarChar, 100).Value = this.ScopeofCCSWeldingProcess;
            myParameters.Add("@MultiWeldingProcess", SqlDbType.Bit).Value = this.MultiWeldingProcess;
            myParameters.Add("@WeldingProcessIndex", SqlDbType.Int).Value = this.WeldingProcessIndex;
            myParameters.Add("@WeldingProcessRemark", SqlDbType.NVarChar, 255).Value = this.WeldingProcessRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string WeldingProcessAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingProcessAb", SqlDbType.NVarChar, 10).Value = WeldingProcessAb;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingProcess_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string WeldingProcessAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingProcess_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingProcess.ParametersAdd(myCmd_Temp.Parameters, WeldingProcessAb, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式             
        public string CheckField()
        {
            if (this.WeldingProcess == null || this.WeldingProcess.Length == 0)
            {
                return "焊接方法不能为空！";
            }
            else if (this.WeldingProcessAb == null || this.WeldingProcessAb.Length == 0)
            {
                return "焊接方法缩写不能为空！";
            }
            else if (this.WeldingProcessNo == null || this.WeldingProcessNo.Length == 0)
            {
                return "焊接方法编号不能为空！";
            }

            return null;
        }

    }

    public class Class_WeldingStandard
    {
        #region "Fields"
        public string WeldingStandard;
        public string WeldingStandardTitle;
        public string WeldingStandardFileName;
        public string WeldingStandardRemark;
        public int WeldingStandardIndex;
        #endregion

        public Class_WeldingStandard()
        {

        }

        public Class_WeldingStandard(string WeldingStandard)
        {
            this.WeldingStandard = WeldingStandard;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_WeldingStandard] Where WeldingStandard=@WeldingStandard";
            myCmd_Temp.Parameters.Add("@WeldingStandard", SqlDbType.NVarChar, 50).Value = this.WeldingStandard;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.WeldingStandardTitle = myReader_Temp["WeldingStandardTitle"].ToString();
            this.WeldingStandardRemark = myReader_Temp["WeldingStandardRemark"].ToString();
            this.WeldingStandardIndex = (int)myReader_Temp["WeldingStandardIndex"];

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingStandard", SqlDbType.NVarChar, 50).Value = this.WeldingStandard;
            myParameters.Add("@WeldingStandardTitle", SqlDbType.NVarChar, 50).Value = this.WeldingStandardTitle;
            myParameters.Add("@WeldingStandardIndex", SqlDbType.Int).Value = this.WeldingStandardIndex;
            myParameters.Add("@WeldingStandardRemark", SqlDbType.NVarChar, 255).Value = this.WeldingStandardRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string WeldingStandard, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingStandard", SqlDbType.NVarChar, 50).Value = WeldingStandard;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingStandard_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string WeldingStandard, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingStandard_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingStandard.ParametersAdd(myCmd_Temp.Parameters, WeldingStandard, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式         
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.WeldingStandard))
            {
                return "焊接标准不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingStandardTitle))
            {
                return "焊接标准名称不能为空！";
            }

            return null;
        }

    }

    public class Class_WeldingStandardGroup
    {
        #region "Fields"
        public string WeldingStandardGroup;
        public string WeldingStandardGroupRemark;
        public int WeldingStandardGroupIndex;
        #endregion

        public Class_WeldingStandardGroup()
        {

        }

        public Class_WeldingStandardGroup(string WeldingStandardGroup)
        {
            this.WeldingStandardGroup = WeldingStandardGroup;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_WeldingStandardGroup] Where WeldingStandardGroup=@WeldingStandardGroup";
            myCmd_Temp.Parameters.Add("@WeldingStandardGroup", SqlDbType.NVarChar, 10).Value = this.WeldingStandardGroup;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.WeldingStandardGroupRemark = myReader_Temp["WeldingStandardGroupRemark"].ToString();
            this.WeldingStandardGroupIndex = (int)myReader_Temp["WeldingStandardGroupIndex"];

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingStandardGroup", SqlDbType.NVarChar, 10).Value = this.WeldingStandardGroup;
            myParameters.Add("@WeldingStandardGroupIndex", SqlDbType.Int).Value = this.WeldingStandardGroupIndex;
            myParameters.Add("@WeldingStandardGroupRemark", SqlDbType.NVarChar, 255).Value = this.WeldingStandardGroupRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string WeldingStandardGroup, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingStandardGroup", SqlDbType.NVarChar, 10).Value = WeldingStandardGroup;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingStandardGroup_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string WeldingStandardGroup, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingStandardGroup_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingStandardGroup.ParametersAdd(myCmd_Temp.Parameters, WeldingStandardGroup, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式            
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.WeldingStandardGroup))
            {
                return "焊接标准组不能为空！";
            }

            return null;
        }

    }

    public class Class_WeldingStandardAndGroup
    {
        #region "Fields"
        public string WeldingStandard;
        public string WeldingStandardGroup;
        public string WeldingStandardAndGroupRemark;
        public int WeldingStandardAndGroupIndex;
        #endregion

        public Class_WeldingStandardAndGroup()
        {

        }

        public Class_WeldingStandardAndGroup(string WeldingStandard, string WeldingStandardGroup)
        {
            this.WeldingStandard = WeldingStandard;
            this.WeldingStandardGroup = WeldingStandardGroup;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_WeldingStandardAndGroup] Where WeldingStandardGroup=@WeldingStandardGroup And WeldingStandard=@WeldingStandard";
            myCmd_Temp.Parameters.Add("@WeldingStandardGroup", SqlDbType.NVarChar, 10).Value = this.WeldingStandardGroup;
            myCmd_Temp.Parameters.Add("@WeldingStandard", SqlDbType.NVarChar, 50).Value = WeldingStandard;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.WeldingStandardAndGroupRemark = myReader_Temp["WeldingStandardAndGroupRemark"].ToString();
            this.WeldingStandardAndGroupIndex = (int)myReader_Temp["WeldingStandardAndGroupIndex"];

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }
        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingStandard", SqlDbType.NVarChar, 50).Value = this.WeldingStandard;
            myParameters.Add("@WeldingStandardGroup", SqlDbType.NVarChar, 10).Value = this.WeldingStandardGroup;
            myParameters.Add("@WeldingStandardAndGroupIndex", SqlDbType.Int).Value = this.WeldingStandardAndGroupIndex;
            myParameters.Add("@WeldingStandardAndGroupRemark", SqlDbType.NVarChar, 255).Value = this.WeldingStandardAndGroupRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string WeldingStandard, string WeldingStandardGroup, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingStandard", SqlDbType.NVarChar, 50).Value = WeldingStandard;
            myParameters.Add("@WeldingStandardGroup", SqlDbType.NVarChar, 10).Value = WeldingStandardGroup;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingStandardAndGroup_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string WeldingStandard, string WeldingStandardGroup, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingStandardAndGroup_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingStandardAndGroup.ParametersAdd(myCmd_Temp.Parameters, WeldingStandard, WeldingStandardGroup, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式            
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.WeldingStandard))
            {
                return "焊接标准不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingStandardGroup))
            {
                return "焊接标准组不能为空！";
            }

            return null;
        }

    }

    public class Class_KindofEmployer
    {
        #region "Fields"
        public string KindofEmployer;
        public object KindofEmployerManagerID;
        public string KindofEmployerEmployerHPID;
        public string KindofEmployerDepartmentHPID;
        public string KindofEmployerWorkPlaceHPID;
        public string KindofEmployerLaborServiceTeamHPID;
        public int KindofEmployerLevel;
        public bool CanUpLoadWelderPicture;
        public bool CanModifyWelderPicture;
        public bool CanDeleteWelderPicture;
        public string KindofEmployerTel;
        public string KindofEmployerFax;
        public string KindofEmployerMobile;
        public string KindofEmployerEmail;
        public int KindofEmployerIndex;
        public string KindofEmployerRemark;
        #endregion

        public Class_KindofEmployer()
        {

        }

        public Class_KindofEmployer(string KindofEmployer)
        {
            this.KindofEmployer = KindofEmployer;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Unit_KindofEmployer] Where KindofEmployer=@KindofEmployer";
            myCmd_Temp.Parameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = this.KindofEmployer;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.KindofEmployerManagerID = myReader_Temp["KindofEmployerManagerID"];
            this.KindofEmployerEmployerHPID = myReader_Temp["KindofEmployerEmployerHPID"].ToString();
            this.KindofEmployerDepartmentHPID = myReader_Temp["KindofEmployerDepartmentHPID"].ToString();
            this.KindofEmployerWorkPlaceHPID = myReader_Temp["KindofEmployerWorkPlaceHPID"].ToString();
            this.KindofEmployerLaborServiceTeamHPID = myReader_Temp["KindofEmployerLaborServiceTeamHPID"].ToString();
            this.KindofEmployerLevel = (int)myReader_Temp["KindofEmployerLevel"];
            this.KindofEmployerRemark = myReader_Temp["KindofEmployerRemark"].ToString();
            this.CanUpLoadWelderPicture = (bool)myReader_Temp["CanUpLoadWelderPicture"];
            this.CanModifyWelderPicture = (bool)myReader_Temp["CanModifyWelderPicture"];
            this.CanDeleteWelderPicture = (bool)myReader_Temp["CanDeleteWelderPicture"];
            this.KindofEmployerTel = myReader_Temp["KindofEmployerTel"].ToString();
            this.KindofEmployerFax = myReader_Temp["KindofEmployerFax"].ToString();
            this.KindofEmployerMobile = myReader_Temp["KindofEmployerMobile"].ToString();
            this.KindofEmployerEmail = myReader_Temp["KindofEmployerEmail"].ToString();
            this.KindofEmployerIndex = (int)myReader_Temp["KindofEmployerIndex"];

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = this.KindofEmployer;
            myParameters.Add("@KindofEmployerManagerID", SqlDbType.UniqueIdentifier).Value = this.KindofEmployerManagerID;
            myParameters.Add("@KindofEmployerEmployerHPID", SqlDbType.NChar, 4).Value = this.KindofEmployerEmployerHPID;
            myParameters.Add("@KindofEmployerDepartmentHPID", SqlDbType.NChar, 6).Value = this.KindofEmployerDepartmentHPID;
            myParameters.Add("@KindofEmployerWorkPlaceHPID", SqlDbType.NChar, 8).Value = this.KindofEmployerWorkPlaceHPID;
            myParameters.Add("@KindofEmployerLaborServiceTeamHPID", SqlDbType.NChar, 7).Value = this.KindofEmployerLaborServiceTeamHPID;
            myParameters.Add("@KindofEmployerLevel", SqlDbType.Int).Value = this.KindofEmployerLevel;
            myParameters.Add("@CanUpLoadWelderPicture", SqlDbType.Bit ).Value = this.CanUpLoadWelderPicture;
            myParameters.Add("@CanModifyWelderPicture", SqlDbType.Bit).Value = this.CanModifyWelderPicture;
            myParameters.Add("@CanDeleteWelderPicture", SqlDbType.Bit).Value = this.CanDeleteWelderPicture;
            myParameters.Add("@KindofEmployerFax", SqlDbType.NVarChar, 50).Value = this.KindofEmployerFax;
            myParameters.Add("@KindofEmployerTel", SqlDbType.NVarChar, 50).Value = this.KindofEmployerTel;
            myParameters.Add("@KindofEmployerMobile", SqlDbType.NVarChar, 50).Value = this.KindofEmployerMobile;
            myParameters.Add("@KindofEmployerEmail", SqlDbType.NVarChar, 100).Value = this.KindofEmployerEmail;
            myParameters.Add("@KindofEmployerIndex", SqlDbType.Int).Value = this.KindofEmployerIndex;
            myParameters.Add("@KindofEmployerRemark", SqlDbType.NVarChar, 255).Value = this.KindofEmployerRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string KindofEmployer, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = KindofEmployer;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_KindofEmployer_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string KindofEmployer, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_KindofEmployer_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_KindofEmployer.ParametersAdd(myCmd_Temp.Parameters, KindofEmployer, myEnum_zwjKindofUpdate);
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

        public bool KindofEmployerModify(string NewKindofEmployer)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_KindofEmployer_UpdateKindofEmployer";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@OldKindofEmployer", SqlDbType.NVarChar ,20).Value = this.KindofEmployer;
            myCmd_Temp.Parameters.Add("@NewKindofEmployer", SqlDbType.NVarChar, 20).Value = NewKindofEmployer;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.KindofEmployer = NewKindofEmployer;
            return true;

        }

        //校验数据字段的格式              
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.KindofEmployer))
            {
                return "报考单位不能为空！";
            }
            else if (string.IsNullOrEmpty(this.KindofEmployerEmployerHPID))
            {
                return "公司编号不能为空！";
            }
            else if (this.KindofEmployerManagerID == null)
            {
                return "负责人不能为空！";
            }
            else if (this.KindofEmployerLevel < 0 || this.KindofEmployerLevel > 4)
            {
                return "锁定单位级别范围为0~4！";
            }
            return this.CanUpdateLevel();
        }

        public string CanUpdateLevel()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_KindofEmployer_CanUpdateLevel";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = this.KindofEmployer;
            myCmd_Temp.Parameters.Add("@KindofEmployerLevel", SqlDbType.Int).Value = this.KindofEmployerLevel;
            myCmd_Temp.Parameters.Add("@KindofEmployerEmployerHPID", SqlDbType.NChar, 4).Value = this.KindofEmployerEmployerHPID;
            myCmd_Temp.Parameters.Add("@KindofEmployerDepartmentHPID", SqlDbType.NChar, 6).Value = this.KindofEmployerDepartmentHPID;
            myCmd_Temp.Parameters.Add("@KindofEmployerWorkPlaceHPID", SqlDbType.NChar, 8).Value = this.KindofEmployerWorkPlaceHPID;
            myCmd_Temp.Parameters.Add("@KindofEmployerLaborServiceTeamHPID", SqlDbType.NChar, 7).Value = this.KindofEmployerLaborServiceTeamHPID;
            myCmd_Temp.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 255).Direction= ParameterDirection.Output ;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return myCmd_Temp.Parameters["@ReturnMessage"].Value.ToString();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <param name="bool_KindofEmployerWelderToWelderBelong">true:从报考单位同步到焊工所属</param>
        /// <param name="bool_Update">true:更新数据</param>
        /// <returns></returns>
        public DataTable GetDataTable_Synchronization(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate, bool bool_KindofEmployerWelderToWelderBelong, bool bool_Update)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "SignUp_KindofEmployerWelder_Synchronization";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters .Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value =this. KindofEmployer;
            myCmd_Temp.Parameters.Add("@KindofEmployerWelderToWelderBelong", SqlDbType.Bit).Value = bool_KindofEmployerWelderToWelderBelong;
            myCmd_Temp.Parameters.Add("@Update", SqlDbType.Bit).Value = bool_Update;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
                case Enum_zwjKindofUpdate.Delete :
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
            }
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = myCmd_Temp;
            DataTable myDataTable=new DataTable ();
            mySqlDataAdapter.Fill(myDataTable);
            return myDataTable;

        }

        public static DataTable GetDataTable_WelderFluxion(string str_KindofEmployer)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Unit_KindofEmployer_WelderFluxion";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = str_KindofEmployer;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = myCmd_Temp;
            DataTable myDataTable = new DataTable();
            mySqlDataAdapter.Fill(myDataTable);
            return myDataTable;

        }
    }

    public class Class_WeldingSubject
    {
        #region "Fields"
        public string SubjectID;
        public bool  NeedPreSubject;
        public string WeldingStandard;
        public string WeldingProject;
        public string WeldingProjectAb;
        public string ScopeofWeldingProject;

        public string WeldingClass;
        public string WeldingClassAb;
        public string ScopeofWeldingClass;
        public int SubjectClass;

        public string WorkPieceType;
        public string JointType;

        public string Subject;
        public string SubjectThickness;
        public string SubjectExternalDiameter;
        public string ScopeofSubject;

        public string SubjectRemark;
        public string CCSSubject;
        public string CCSSubjectTestNo;
        public string HardestWeldingPosition;
        #endregion

        public Class_WeldingSubject()
        {

        }

        public Class_WeldingSubject(string SubjectID)
        {
            this.SubjectID = SubjectID;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_WeldingSubject] Where SubjectID=@SubjectID";
            myCmd_Temp.Parameters.Add("@SubjectID", SqlDbType.NVarChar, 20).Value = this.SubjectID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.NeedPreSubject =(bool ) myReader_Temp["NeedPreSubject"];
            this.WeldingStandard = myReader_Temp["WeldingStandard"].ToString();
            this.WeldingProject = myReader_Temp["WeldingProject"].ToString();
            this.WeldingProjectAb = myReader_Temp["WeldingProjectAb"].ToString();
            this.ScopeofWeldingProject = myReader_Temp["ScopeofWeldingProject"].ToString();
            this.JointType = myReader_Temp["JointType"].ToString();
            this.WorkPieceType = myReader_Temp["WorkPieceType"].ToString();
            this.WeldingClass = myReader_Temp["WeldingClass"].ToString();
            this.WeldingClassAb = myReader_Temp["WeldingClassAb"].ToString();
            this.ScopeofWeldingClass = myReader_Temp["ScopeofWeldingClass"].ToString();
            int.TryParse(myReader_Temp["SubjectClass"].ToString(), out this.SubjectClass);
            this.Subject = myReader_Temp["Subject"].ToString();
            this.ScopeofSubject = myReader_Temp["ScopeofSubject"].ToString();
            this.SubjectRemark = myReader_Temp["SubjectRemark"].ToString();
            this.SubjectThickness = myReader_Temp["SubjectThickness"].ToString();
            this.SubjectExternalDiameter = myReader_Temp["SubjectExternalDiameter"].ToString();
            this.CCSSubject = myReader_Temp["CCSSubject"].ToString();
            this.CCSSubjectTestNo = myReader_Temp["CCSSubjectTestNo"].ToString();
            this.HardestWeldingPosition = myReader_Temp["HardestWeldingPosition"].ToString();
            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@SubjectID", SqlDbType.NChar, 4).Value = this.SubjectID;
            myParameters.Add("@NeedPreSubject", SqlDbType.Bit ).Value = this.NeedPreSubject;
            myParameters.Add("@WeldingStandard", SqlDbType.NVarChar, 50).Value = this.WeldingStandard;
            myParameters.Add("@WeldingProject", SqlDbType.NVarChar, 50).Value = this.WeldingProject;
            myParameters.Add("@WeldingProjectAb", SqlDbType.NVarChar, 10).Value = this.WeldingProjectAb;
            myParameters.Add("@ScopeofWeldingProject", SqlDbType.NVarChar, 255).Value = this.ScopeofWeldingProject;
            myParameters.Add("@JointType", SqlDbType.NVarChar, 10).Value = this.JointType;
            myParameters.Add("@WorkPieceType", SqlDbType.NVarChar, 10).Value = this.WorkPieceType;
            myParameters.Add("@WeldingClass", SqlDbType.NVarChar, 50).Value = this.WeldingClass;
            myParameters.Add("@WeldingClassAb", SqlDbType.NVarChar, 10).Value = this.WeldingClassAb;
            myParameters.Add("@ScopeofWeldingClass", SqlDbType.NVarChar, 255).Value = this.ScopeofWeldingClass;
            myParameters.Add("@SubjectClass", SqlDbType.Int).Value = this.SubjectClass;
            myParameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = this.Subject;
            myParameters.Add("@ScopeofSubject", SqlDbType.NVarChar, 255).Value = this.ScopeofSubject;
            myParameters.Add("@SubjectThickness", SqlDbType.NVarChar, 50).Value = this.SubjectThickness;
            myParameters.Add("@SubjectExternalDiameter", SqlDbType.NVarChar, 50).Value = this.SubjectExternalDiameter;
            myParameters.Add("@SubjectRemark", SqlDbType.NVarChar, 255).Value = this.SubjectRemark;
            myParameters.Add("@CCSSubject", SqlDbType.NVarChar, 50).Value = this.CCSSubject;
            myParameters.Add("@CCSSubjectTestNo", SqlDbType.NVarChar, 50).Value = this.CCSSubjectTestNo;
            myParameters.Add("@HardestWeldingPosition", SqlDbType.NVarChar, 10).Value = this.HardestWeldingPosition;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string SubjectID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@SubjectID", SqlDbType.NVarChar, 20).Value = SubjectID;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingSubject_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string SubjectID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingSubject_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingSubject.ParametersAdd(myCmd_Temp.Parameters, SubjectID, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式              
        public string CheckField()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.SubjectID, "^\\d{4}$"))
            {
                return "考试科目编号格式错误！";
            }
            else if (string.IsNullOrEmpty(this.WeldingStandard))
            {
                return "考试标准不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingProject))
            {
                return "工程不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingProjectAb))
            {
                return "工程缩写不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ScopeofWeldingProject))
            {
                return "工程适用范围不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingClass))
            {
                return "等级不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingClassAb))
            {
                return "等级缩写不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ScopeofWeldingClass))
            {
                return "等级适用范围不能为空！";
            }
            else if (string.IsNullOrEmpty(this.JointType))
            {
                return "焊缝类型不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WorkPieceType))
            {
                return "工件类型不能为空！";
            }
            else if (string.IsNullOrEmpty(this.Subject))
            {
                return "考试科目不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ScopeofSubject))
            {
                return "考试科目适用范围不能为空！";
            }
            else if (string.IsNullOrEmpty(this.SubjectThickness))
            {
                return "板(管壁)厚不能为空！";
            }
            return null;
        }

    }

    public class Class_WeldingSubjectPosition
    {
        #region "Fields"
        public string SubjectID;
        public string WeldingPosition;
        public string WeldingPositionContent;
        public string Assemblage;
        public bool FaceDT;
        public bool UT;
        public bool RT;
        public bool BendDT;
        public bool DisjunctionDT;
        public bool MacroExamination;
        public bool OtherDT;
        public double RenderWeldingRodDiameter;
        public double WeldingRodDiameter;
        public double CoverWeldingRodDiameter;
        public double ExternalDiameter;
        public double Thickness;
        public string SubjectPositionRemark;
        #endregion

        public Class_WeldingSubjectPosition()
        {

        }

        public Class_WeldingSubjectPosition(string SubjectID, string WeldingPosition)
        {
            this.SubjectID = SubjectID;
            this.WeldingPosition = WeldingPosition;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_WeldingSubjectPosition] Where SubjectID=@SubjectID and WeldingPosition=@WeldingPosition";
            myCmd_Temp.Parameters.Add("@SubjectID", SqlDbType.NChar, 4).Value = this.SubjectID;
            myCmd_Temp.Parameters.Add("@WeldingPosition", SqlDbType.NVarChar, 20).Value = this.WeldingPosition;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.WeldingPositionContent = myReader_Temp["WeldingPositionContent"].ToString();
            this.Assemblage = myReader_Temp["Assemblage"].ToString();
            double.TryParse(myReader_Temp["RenderWeldingRodDiameter"].ToString(), out this.RenderWeldingRodDiameter);
            double.TryParse(myReader_Temp["WeldingRodDiameter"].ToString(), out this.WeldingRodDiameter);
            double.TryParse(myReader_Temp["CoverWeldingRodDiameter"].ToString(), out this.CoverWeldingRodDiameter);
            double.TryParse(myReader_Temp["Thickness"].ToString(), out this.Thickness);
            if (myReader_Temp["ExternalDiameter"] != DBNull.Value)
            {
                double.TryParse(myReader_Temp["ExternalDiameter"].ToString(), out this.ExternalDiameter);
            }
            this.FaceDT = (bool)myReader_Temp["FaceDT"];
            this.RT = (bool)myReader_Temp["RT"];
            this.UT = (bool)myReader_Temp["UT"];
            this.BendDT = (bool)myReader_Temp["BendDT"];
            this.DisjunctionDT = (bool)myReader_Temp["DisjunctionDT"];
            this.MacroExamination = (bool)myReader_Temp["MacroExamination"];
            this.OtherDT = (bool)myReader_Temp["OtherDT"];
            this.SubjectPositionRemark = myReader_Temp["SubjectPositionRemark"].ToString();

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@SubjectID", SqlDbType.NChar, 4).Value = this.SubjectID;
            myParameters.Add("@WeldingPosition", SqlDbType.NVarChar, 10).Value = this.WeldingPosition;
            myParameters.Add("@WeldingPositionContent", SqlDbType.NVarChar, 50).Value = this.WeldingPositionContent;
            myParameters.Add("@Assemblage", SqlDbType.NVarChar, 10).Value = this.Assemblage;
            myParameters.Add("@FaceDT", SqlDbType.Bit).Value = this.FaceDT;
            myParameters.Add("@UT", SqlDbType.Bit).Value = this.UT;
            myParameters.Add("@RT", SqlDbType.Bit).Value = this.RT;
            myParameters.Add("@BendDT", SqlDbType.Bit).Value = this.BendDT;
            myParameters.Add("@DisjunctionDT", SqlDbType.Bit).Value = this.DisjunctionDT;
            myParameters.Add("@MacroExamination", SqlDbType.Bit).Value = this.MacroExamination;
            myParameters.Add("@OtherDT", SqlDbType.Bit).Value = this.OtherDT;
            myParameters.Add("@RenderWeldingRodDiameter", SqlDbType.Real).Value = this.RenderWeldingRodDiameter;
            myParameters.Add("@WeldingRodDiameter", SqlDbType.Real).Value = this.WeldingRodDiameter;
            myParameters.Add("@CoverWeldingRodDiameter", SqlDbType.Real).Value = this.CoverWeldingRodDiameter;
            myParameters.Add("@Thickness", SqlDbType.Real).Value = this.Thickness;
            myParameters.Add("@ExternalDiameter", SqlDbType.Real).Value = this.ExternalDiameter;
            myParameters.Add("@SubjectPositionRemark", SqlDbType.NVarChar, 255).Value = this.SubjectPositionRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string SubjectID, string WeldingPosition, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@SubjectID", SqlDbType.NChar, 4).Value = SubjectID;
            myParameters.Add("@WeldingPosition", SqlDbType.NVarChar, 20).Value = WeldingPosition;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingSubjectPosition_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string SubjectID, string WeldingPosition, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingSubjectPosition_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingSubjectPosition.ParametersAdd(myCmd_Temp.Parameters, SubjectID, WeldingPosition, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式              
        public string CheckField()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.SubjectID, "^\\d{4}$"))
            {
                return "考试科目编号格式错误！";
            }
            else if (string.IsNullOrEmpty(this.WeldingPosition))
            {
                return "考试项目位置不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingPositionContent))
            {
                return "考试项目描述不能为空！";
            }
            else if (string.IsNullOrEmpty(this.Assemblage))
            {
                return "装配方式不能为空！";
            }
            return null;
        }
    }

    public class Class_WeldingSubjectApplicable
    {
        #region "Fields"
        public string SubjectID;
        public string ApplicableSubjectID;
        public int PreIntervalMonth;
        public int ApplicableSubjectIndex;
        public string ApplicableSubjectRemark;
        #endregion

        public Class_WeldingSubjectApplicable()
        {

        }

        public Class_WeldingSubjectApplicable(string SubjectID, string ApplicableSubjectID)
        {
            this.SubjectID = SubjectID;
            this.ApplicableSubjectID = ApplicableSubjectID;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_WeldingSubjectApplicable] Where SubjectID=@SubjectID and ApplicableSubjectID=@ApplicableSubjectID";
            myCmd_Temp.Parameters.Add("@SubjectID", SqlDbType.NChar, 4).Value = this.SubjectID;
            myCmd_Temp.Parameters.Add("@ApplicableSubjectID", SqlDbType.NChar , 4).Value = this.ApplicableSubjectID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.PreIntervalMonth = (int)myReader_Temp["PreIntervalMonth"];
            this.ApplicableSubjectIndex = (int)myReader_Temp["ApplicableSubjectIndex"];
            this.ApplicableSubjectRemark = myReader_Temp["ApplicableSubjectRemark"].ToString();

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@SubjectID", SqlDbType.NChar, 4).Value = this.SubjectID;
            myParameters.Add("@ApplicableSubjectID", SqlDbType.NChar, 4).Value = this.ApplicableSubjectID;
            myParameters.Add("@PreIntervalMonth", SqlDbType.Int ).Value = this.PreIntervalMonth;
            myParameters.Add("@ApplicableSubjectIndex", SqlDbType.Int).Value = this.ApplicableSubjectIndex;
            myParameters.Add("@ApplicableSubjectRemark", SqlDbType.NVarChar, 255).Value = this.ApplicableSubjectRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string SubjectID, string ApplicableSubjectID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@SubjectID", SqlDbType.NChar, 4).Value = SubjectID;
            myParameters.Add("@ApplicableSubjectID", SqlDbType.NChar, 4).Value = ApplicableSubjectID;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingSubjectApplicable_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string SubjectID, string ApplicableSubjectID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingSubjectApplicable_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingSubjectApplicable.ParametersAdd(myCmd_Temp.Parameters, SubjectID, ApplicableSubjectID, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式              
        public string CheckField()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.SubjectID, "^\\d{4}$"))
            {
                return "考试科目编号格式错误！";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.ApplicableSubjectID, "^\\d{4}$"))
            {
                return "考试科目编号格式错误！";
            }
            return null;
        }
    }

    public class Class_Material
    {
        #region "Fields"
        public string Material;
        public string MaterialGBName;
        public string MaterialDenominateWeldingStandard;
        public string MaterialCCSGroupAb;
        public string MaterialISOGroupAb;
        public string MaterialRemark;
        public int MaterialIndex;
        #endregion

        public Class_Material()
        {

        }

        public Class_Material(string Material)
        {
            this.Material = Material;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_Material] Where Material=@Material";
            myCmd_Temp.Parameters.Add("@Material", SqlDbType.NVarChar, 50).Value = this.Material;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.MaterialGBName = myReader_Temp["MaterialGBName"].ToString();
            this.MaterialDenominateWeldingStandard = myReader_Temp["MaterialDenominateWeldingStandard"].ToString();
            this.MaterialCCSGroupAb = myReader_Temp["MaterialCCSGroupAb"].ToString();
            this.MaterialISOGroupAb = myReader_Temp["MaterialISOGroupAb"].ToString();
            this.MaterialRemark = myReader_Temp["MaterialRemark"].ToString();
            this.MaterialIndex = (int)myReader_Temp["MaterialIndex"];

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@Material", SqlDbType.NVarChar, 50).Value = this.Material;
            if (!string.IsNullOrEmpty(this.MaterialGBName))
            {
                myParameters.Add("@MaterialGBName", SqlDbType.NVarChar, 50).Value = this.MaterialGBName;
            }
            myParameters.Add("@MaterialDenominateWeldingStandard", SqlDbType.NVarChar, 50).Value = this.MaterialDenominateWeldingStandard;
            myParameters.Add("@MaterialCCSGroupAb", SqlDbType.NVarChar, 50).Value = this.MaterialCCSGroupAb;
            myParameters.Add("@MaterialISOGroupAb", SqlDbType.NVarChar, 50).Value = this.MaterialISOGroupAb;
            myParameters.Add("@MaterialIndex", SqlDbType.Int).Value = this.MaterialIndex;
            myParameters.Add("@MaterialRemark", SqlDbType.NVarChar, 255).Value = this.MaterialRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string Material, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@Material", SqlDbType.NVarChar, 50).Value = Material;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_Material_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string Material, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_Material_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Material.ParametersAdd(myCmd_Temp.Parameters, Material, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式              
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.Material))
            {
                return "材料不能为空！";
            }
            else if (string.IsNullOrEmpty(this.MaterialDenominateWeldingStandard))
            {
                return "命名标准不能为空！";
            }
            else if (string.IsNullOrEmpty(this.MaterialCCSGroupAb))
            {
                return "材料CCS组不能为空！";
            }
            else if (string.IsNullOrEmpty(this.MaterialISOGroupAb))
            {
                return "材料ISO组不能为空！";
            }

            return null;
        }

    }

    public class Class_MaterialCCSGroup
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string MaterialCCSGroupAb;
        public string MaterialCCSGroup;
        public string MaterialCCSGroupItemName;
        public string ScopeofMaterialCCSGroup;
        public int MaterialCCSGroupIndex;
        public string MaterialCCSGroupRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_MaterialCCSGroup()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="MaterialCCSGroup"></param>
        public Class_MaterialCCSGroup(string MaterialCCSGroupAb)
        {
            this.MaterialCCSGroupAb = MaterialCCSGroupAb;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_MaterialCCSGroup] Where MaterialCCSGroupAb=@MaterialCCSGroupAb";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@MaterialCCSGroupAb", SqlDbType.NVarChar, 50).Value = this.MaterialCCSGroupAb;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.MaterialCCSGroup = myReader_Temp["MaterialCCSGroup"].ToString();
                this.MaterialCCSGroupItemName = myReader_Temp["MaterialCCSGroupItemName"].ToString();
                this.ScopeofMaterialCCSGroup = myReader_Temp["ScopeofMaterialCCSGroup"].ToString();
                this.MaterialCCSGroupIndex = (int)myReader_Temp["MaterialCCSGroupIndex"];
                this.MaterialCCSGroupRemark = myReader_Temp["MaterialCCSGroupRemark"].ToString();
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
            myParameters.Add("@MaterialCCSGroupAb", SqlDbType.NVarChar, 50).Value = this.MaterialCCSGroupAb;
            myParameters.Add("@MaterialCCSGroup", SqlDbType.NVarChar, 255).Value = this.MaterialCCSGroup;
            myParameters.Add("@MaterialCCSGroupItemName", SqlDbType.NVarChar, 255).Value = this.MaterialCCSGroupItemName;
            myParameters.Add("@ScopeofMaterialCCSGroup", SqlDbType.NVarChar, 255).Value = this.ScopeofMaterialCCSGroup;
            myParameters.Add("@MaterialCCSGroupIndex", SqlDbType.Int).Value = this.MaterialCCSGroupIndex;
            myParameters.Add("@MaterialCCSGroupRemark", SqlDbType.NVarChar, 255).Value = this.MaterialCCSGroupRemark;

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
        /// <param name="MaterialCCSGroup"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string MaterialCCSGroupAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@MaterialCCSGroupAb", SqlDbType.NVarChar, 50).Value = MaterialCCSGroupAb;
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
            myCmd_Temp.CommandText = "Parameter_MaterialCCSGroup_Update";
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
        /// <param name="MaterialCCSGroup"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string MaterialCCSGroupAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_MaterialCCSGroup_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_MaterialCCSGroup.ParametersAdd(myCmd_Temp.Parameters, MaterialCCSGroupAb, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.MaterialCCSGroupAb))
            {
                return "材料CCS组缩写不能为空！";
            }
            else if (string.IsNullOrEmpty(this.MaterialCCSGroup))
            {
                return "材料CCS组不能为空！";
            }
            else if (string.IsNullOrEmpty(this.MaterialCCSGroupItemName))
            {
                return "材料CCS组值不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ScopeofMaterialCCSGroup))
            {
                return "适用范围不能为空！";
            }

            return null;
        }

    }

    public class Class_MaterialISOGroup
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string MaterialISOGroupAb;
        public string MaterialLRGroupAb;
        public string MaterialISOGroup;
        public string ScopeofMaterialISOGroup;
        public int MaterialISOGroupIndex;
        public string MaterialISOGroupRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_MaterialISOGroup()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="MaterialISOGroup"></param>
        public Class_MaterialISOGroup(string MaterialISOGroupAb)
        {
            this.MaterialISOGroupAb = MaterialISOGroupAb;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_MaterialISOGroup] Where MaterialISOGroupAb=@MaterialISOGroupAb";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@MaterialISOGroupAb", SqlDbType.NVarChar, 50).Value = this.MaterialISOGroupAb;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.MaterialISOGroup = myReader_Temp["MaterialISOGroup"].ToString();
                this.MaterialLRGroupAb = myReader_Temp["MaterialLRGroupAb"].ToString();
                this.ScopeofMaterialISOGroup = myReader_Temp["ScopeofMaterialISOGroup"].ToString();
                this.MaterialISOGroupIndex = (int)myReader_Temp["MaterialISOGroupIndex"];
                this.MaterialISOGroupRemark = myReader_Temp["MaterialISOGroupRemark"].ToString();
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
            myParameters.Add("@MaterialISOGroupAb", SqlDbType.NVarChar, 50).Value = this.MaterialISOGroupAb;
            myParameters.Add("@MaterialISOGroup", SqlDbType.NVarChar, 255).Value = this.MaterialISOGroup;
            myParameters.Add("@MaterialLRGroupAb", SqlDbType.NVarChar, 50).Value = this.MaterialLRGroupAb;
            myParameters.Add("@ScopeofMaterialISOGroup", SqlDbType.NVarChar, 255).Value = this.ScopeofMaterialISOGroup;
            myParameters.Add("@MaterialISOGroupIndex", SqlDbType.Int).Value = this.MaterialISOGroupIndex;
            myParameters.Add("@MaterialISOGroupRemark", SqlDbType.NVarChar, 255).Value = this.MaterialISOGroupRemark;

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
        /// <param name="MaterialISOGroup"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string MaterialISOGroupAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@MaterialISOGroupAb", SqlDbType.NVarChar, 50).Value = MaterialISOGroupAb;
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
            myCmd_Temp.CommandText = "Parameter_MaterialISOGroup_Update";
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
        /// <param name="MaterialISOGroup"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string MaterialISOGroupAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_MaterialISOGroup_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_MaterialISOGroup.ParametersAdd(myCmd_Temp.Parameters, MaterialISOGroupAb, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.MaterialISOGroupAb))
            {
                return "材料ISO组缩写不能为空！";
            }
            else if (string.IsNullOrEmpty(this.MaterialISOGroup))
            {
                return "材料ISO组不能为空！";
            }
            else if (string.IsNullOrEmpty(this.MaterialLRGroupAb))
            {
                return "材料LR组不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ScopeofMaterialISOGroup))
            {
                return "适用范围不能为空！";
            }

            return null;
        }

    }

    public class Class_WeldingConsumable
    {
        #region "Fields"
        public string WeldingConsumable;
        public string WeldingConsumableGBName;
        public string WeldingConsumableAWSName;
        public string WeldingConsumableDenominateWeldingStandard;
        public string WeldingConsumableCCSGroupAb;
        public string WeldingConsumableISOGroupAb;
        public string WeldingConsumableRemark;
        public int WeldingConsumableIndex;
        #endregion

        public Class_WeldingConsumable()
        {

        }

        public Class_WeldingConsumable(string WeldingConsumable)
        {
            this.WeldingConsumable = WeldingConsumable;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_WeldingConsumable] Where WeldingConsumable=@WeldingConsumable";
            myCmd_Temp.Parameters.Add("@WeldingConsumable", SqlDbType.NVarChar, 50).Value = this.WeldingConsumable;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.WeldingConsumableGBName = myReader_Temp["WeldingConsumableGBName"].ToString();
            this.WeldingConsumableAWSName = myReader_Temp["WeldingConsumableAWSName"].ToString();
            this.WeldingConsumableDenominateWeldingStandard = myReader_Temp["WeldingConsumableDenominateWeldingStandard"].ToString();
            this.WeldingConsumableCCSGroupAb = myReader_Temp["WeldingConsumableCCSGroupAb"].ToString();
            this.WeldingConsumableISOGroupAb = myReader_Temp["WeldingConsumableISOGroupAb"].ToString();
            this.WeldingConsumableRemark = myReader_Temp["WeldingConsumableRemark"].ToString();
            this.WeldingConsumableIndex = (int)myReader_Temp["WeldingConsumableIndex"];

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingConsumable", SqlDbType.NVarChar, 50).Value = this.WeldingConsumable;
            myParameters.Add("@WeldingConsumableGBName", SqlDbType.NVarChar, 50).Value = this.WeldingConsumableGBName;
            myParameters.Add("@WeldingConsumableAWSName", SqlDbType.NVarChar, 50).Value = this.WeldingConsumableAWSName;
            myParameters.Add("@WeldingConsumableDenominateWeldingStandard", SqlDbType.NVarChar, 50).Value = this.WeldingConsumableDenominateWeldingStandard;
            myParameters.Add("@WeldingConsumableCCSGroupAb", SqlDbType.NVarChar, 50).Value = this.WeldingConsumableCCSGroupAb;
            myParameters.Add("@WeldingConsumableISOGroupAb", SqlDbType.NVarChar, 50).Value = this.WeldingConsumableISOGroupAb;
            myParameters.Add("@WeldingConsumableIndex", SqlDbType.Int).Value = this.WeldingConsumableIndex;
            myParameters.Add("@WeldingConsumableRemark", SqlDbType.NVarChar, 255).Value = this.WeldingConsumableRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string WeldingConsumable, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingConsumable", SqlDbType.NVarChar, 50).Value = WeldingConsumable;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingConsumable_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string WeldingConsumable, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingConsumable_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingConsumable.ParametersAdd(myCmd_Temp.Parameters, WeldingConsumable, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式              
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.WeldingConsumable))
            {
                return "焊接材料不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingConsumableDenominateWeldingStandard))
            {
                return "焊接命名标准不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingConsumableCCSGroupAb))
            {
                return "焊接材料CCS组不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingConsumableISOGroupAb))
            {
                return "焊接材料ISO组不能为空！";
            }

            return null;
        }

    }

    public class Class_WeldingConsumableCCSGroup
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string WeldingConsumableCCSGroupAb;
        public string WeldingConsumableCCSGroup;
        public string ScopeofWeldingConsumableCCSGroup;
        public int WeldingConsumableCCSGroupIndex;
        public string WeldingConsumableCCSGroupRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_WeldingConsumableCCSGroup()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="WeldingConsumableCCSGroup"></param>
        public Class_WeldingConsumableCCSGroup(string WeldingConsumableCCSGroupAb)
        {
            this.WeldingConsumableCCSGroupAb = WeldingConsumableCCSGroupAb;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_WeldingConsumableCCSGroup] Where WeldingConsumableCCSGroupAb=@WeldingConsumableCCSGroupAb";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WeldingConsumableCCSGroupAb", SqlDbType.NVarChar, 50).Value = this.WeldingConsumableCCSGroupAb;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.WeldingConsumableCCSGroup = myReader_Temp["WeldingConsumableCCSGroup"].ToString();
                this.ScopeofWeldingConsumableCCSGroup = myReader_Temp["ScopeofWeldingConsumableCCSGroup"].ToString();
                this.WeldingConsumableCCSGroupIndex = (int)myReader_Temp["WeldingConsumableCCSGroupIndex"];
                this.WeldingConsumableCCSGroupRemark = myReader_Temp["WeldingConsumableCCSGroupRemark"].ToString();
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
            myParameters.Add("@WeldingConsumableCCSGroupAb", SqlDbType.NVarChar, 50).Value = this.WeldingConsumableCCSGroupAb;
            myParameters.Add("@WeldingConsumableCCSGroup", SqlDbType.NVarChar, 255).Value = this.WeldingConsumableCCSGroup;
            myParameters.Add("@ScopeofWeldingConsumableCCSGroup", SqlDbType.NVarChar, 255).Value = this.ScopeofWeldingConsumableCCSGroup;
            myParameters.Add("@WeldingConsumableCCSGroupIndex", SqlDbType.Int).Value = this.WeldingConsumableCCSGroupIndex;
            myParameters.Add("@WeldingConsumableCCSGroupRemark", SqlDbType.NVarChar, 255).Value = this.WeldingConsumableCCSGroupRemark;

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
        /// <param name="WeldingConsumableCCSGroup"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string WeldingConsumableCCSGroupAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingConsumableCCSGroupAb", SqlDbType.NVarChar, 50).Value = WeldingConsumableCCSGroupAb;
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
            myCmd_Temp.CommandText = "Parameter_WeldingConsumableCCSGroup_Update";
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
        /// <param name="WeldingConsumableCCSGroup"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string WeldingConsumableCCSGroupAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingConsumableCCSGroup_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingConsumableCCSGroup.ParametersAdd(myCmd_Temp.Parameters, WeldingConsumableCCSGroupAb, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.WeldingConsumableCCSGroupAb))
            {
                return "焊接材料CCS组缩写不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingConsumableCCSGroup))
            {
                return "焊接材料CCS组不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ScopeofWeldingConsumableCCSGroup))
            {
                return "适用范围不能为空！";
            }

            return null;
        }

    }

    public class Class_WeldingConsumableISOGroup
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string WeldingConsumableISOGroupAb;
        public string WeldingConsumableISOGroup;
        public string ScopeofWeldingConsumableISOGroup;
        public int WeldingConsumableISOGroupIndex;
        public string WeldingConsumableISOGroupRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_WeldingConsumableISOGroup()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="WeldingConsumableISOGroup"></param>
        public Class_WeldingConsumableISOGroup(string WeldingConsumableISOGroupAb)
        {
            this.WeldingConsumableISOGroupAb = WeldingConsumableISOGroupAb;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_WeldingConsumableISOGroup] Where WeldingConsumableISOGroupAb=@WeldingConsumableISOGroupAb";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WeldingConsumableISOGroupAb", SqlDbType.NVarChar, 50).Value = this.WeldingConsumableISOGroupAb;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.WeldingConsumableISOGroup = myReader_Temp["WeldingConsumableISOGroup"].ToString();
                this.ScopeofWeldingConsumableISOGroup = myReader_Temp["ScopeofWeldingConsumableISOGroup"].ToString();
                this.WeldingConsumableISOGroupIndex = (int)myReader_Temp["WeldingConsumableISOGroupIndex"];
                this.WeldingConsumableISOGroupRemark = myReader_Temp["WeldingConsumableISOGroupRemark"].ToString();
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
            myParameters.Add("@WeldingConsumableISOGroupAb", SqlDbType.NVarChar, 50).Value = this.WeldingConsumableISOGroupAb;
            myParameters.Add("@WeldingConsumableISOGroup", SqlDbType.NVarChar, 255).Value = this.WeldingConsumableISOGroup;
            myParameters.Add("@ScopeofWeldingConsumableISOGroup", SqlDbType.NVarChar, 255).Value = this.ScopeofWeldingConsumableISOGroup;
            myParameters.Add("@WeldingConsumableISOGroupIndex", SqlDbType.Int).Value = this.WeldingConsumableISOGroupIndex;
            myParameters.Add("@WeldingConsumableISOGroupRemark", SqlDbType.NVarChar, 255).Value = this.WeldingConsumableISOGroupRemark;

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
        /// <param name="WeldingConsumableISOGroup"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string WeldingConsumableISOGroupAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingConsumableISOGroupAb", SqlDbType.NVarChar, 50).Value = WeldingConsumableISOGroupAb;
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
            myCmd_Temp.CommandText = "Parameter_WeldingConsumableISOGroup_Update";
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
        /// <param name="WeldingConsumableISOGroup"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string WeldingConsumableISOGroupAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingConsumableISOGroup_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingConsumableISOGroup.ParametersAdd(myCmd_Temp.Parameters, WeldingConsumableISOGroupAb, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.WeldingConsumableISOGroupAb))
            {
                return "焊接材料ISO组缩写不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingConsumableISOGroup))
            {
                return "焊接材料ISO组不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ScopeofWeldingConsumableISOGroup))
            {
                return "适用范围不能为空！";
            }

            return null;
        }

    }

    public class Class_ShipClassification
    {
        #region "Fields"
        public string ShipClassification;
        public string ShipClassificationAb;
        public string WeldingStandard;
        public bool WeldingStandardRestrict;
        /// <summary>
        /// 条件一：!(YearSeparate & ShipRestrict)
        /// 条件二：!(!ShipRestrict & TheorySeparate)
        /// </summary>
        public bool YearSeparate;
        public int YearBegin;
        public int YearEnd;
        public bool ShipRestrict;
        public bool TheorySeparate;
        public string TestCommitteeID;
        public bool ProlongQCContinuous;
        public string ShipClassificationEnglishName;
        public string NextIssueNo;
        public string NextExaminingNo;
        public string NextCertificateNo;
        public int IssueNoSignificantDigit;
        public int ExaminingNoSignificantDigit;
        public int CertificateNoSignificantDigit;
        public string IssueNoRegex;
        public string ExaminingNoRegex;
        public string CertificateNoRegex;
        public string ShipClassificationRemark;
        public int ShipClassificationIndex;
        #endregion

        public Class_ShipClassification()
        {

        }

        public Class_ShipClassification(string ShipClassificationAb)
        {
            this.ShipClassificationAb = ShipClassificationAb;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_ShipClassification] Where ShipClassificationAb=@ShipClassificationAb";
            myCmd_Temp.Parameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = this.ShipClassificationAb;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.ShipClassification = myReader_Temp["ShipClassification"].ToString();
            this.WeldingStandard = myReader_Temp["WeldingStandard"].ToString();
            this.ShipClassificationEnglishName = myReader_Temp["ShipClassificationEnglishName"].ToString();
            this.YearBegin = int.Parse(myReader_Temp["YearBegin"].ToString());
            this.YearEnd = int.Parse(myReader_Temp["YearEnd"].ToString());

            this.WeldingStandardRestrict = (bool)myReader_Temp["WeldingStandardRestrict"];
            this.YearSeparate = (bool)myReader_Temp["YearSeparate"];
            this.ShipRestrict = (bool)myReader_Temp["ShipRestrict"];
            this.TheorySeparate = (bool)myReader_Temp["TheorySeparate"];

            this.TestCommitteeID = myReader_Temp["TestCommitteeID"].ToString();
            this.ProlongQCContinuous = (bool)myReader_Temp["ProlongQCContinuous"];
            this.NextIssueNo = myReader_Temp["NextIssueNo"].ToString();
            this.NextExaminingNo = myReader_Temp["NextExaminingNo"].ToString();
            this.NextCertificateNo = myReader_Temp["NextCertificateNo"].ToString();

            this.IssueNoSignificantDigit = int.Parse(myReader_Temp["IssueNoSignificantDigit"].ToString());
            this.ExaminingNoSignificantDigit = int.Parse(myReader_Temp["ExaminingNoSignificantDigit"].ToString());
            this.CertificateNoSignificantDigit = int.Parse(myReader_Temp["CertificateNoSignificantDigit"].ToString());

            this.IssueNoRegex = myReader_Temp["IssueNoRegex"].ToString();
            this.ExaminingNoRegex = myReader_Temp["ExaminingNoRegex"].ToString();
            this.CertificateNoRegex = myReader_Temp["CertificateNoRegex"].ToString();

            this.ShipClassificationRemark = myReader_Temp["ShipClassificationRemark"].ToString();
            this.ShipClassificationIndex = (int)myReader_Temp["ShipClassificationIndex"];

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = this.ShipClassificationAb;
            myParameters.Add("@ShipClassification", SqlDbType.NVarChar, 50).Value = this.ShipClassification;
            myParameters.Add("@WeldingStandard", SqlDbType.NVarChar, 50).Value = this.WeldingStandard;
            myParameters.Add("@ShipClassificationEnglishName", SqlDbType.NVarChar, 255).Value = this.ShipClassificationEnglishName;
            myParameters.Add("@ShipClassificationIndex", SqlDbType.Int).Value = this.ShipClassificationIndex;
            myParameters.Add("@ShipClassificationRemark", SqlDbType.NVarChar, 255).Value = this.ShipClassificationRemark;

            myParameters.Add("@YearBegin", SqlDbType.Int).Value = this.YearBegin;
            myParameters.Add("@YearEnd", SqlDbType.Int).Value = this.YearEnd;
            myParameters.Add("@WeldingStandardRestrict", SqlDbType.Bit).Value = this.WeldingStandardRestrict;
            myParameters.Add("@YearSeparate", SqlDbType.Bit).Value = this.YearSeparate;
            myParameters.Add("@ShipRestrict", SqlDbType.Bit).Value = this.ShipRestrict;
            myParameters.Add("@TheorySeparate", SqlDbType.Bit).Value = this.TheorySeparate;
            myParameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = this.TestCommitteeID;
            myParameters.Add("@ProlongQCContinuous", SqlDbType.Bit).Value = this.ProlongQCContinuous;
            myParameters.Add("@NextIssueNo", SqlDbType.NVarChar, 20).Value = this.NextIssueNo;
            myParameters.Add("@NextExaminingNo", SqlDbType.NVarChar, 20).Value = this.NextExaminingNo;
            myParameters.Add("@NextCertificateNo", SqlDbType.NVarChar, 20).Value = this.NextCertificateNo;
            myParameters.Add("@IssueNoSignificantDigit", SqlDbType.Int).Value = this.IssueNoSignificantDigit;
            myParameters.Add("@ExaminingNoSignificantDigit", SqlDbType.Int).Value = this.ExaminingNoSignificantDigit;
            myParameters.Add("@CertificateNoSignificantDigit", SqlDbType.Int).Value = this.CertificateNoSignificantDigit;
            myParameters.Add("@IssueNoRegex", SqlDbType.NVarChar, 255).Value = this.IssueNoRegex;
            myParameters.Add("@ExaminingNoRegex", SqlDbType.NVarChar, 255).Value = this.ExaminingNoRegex;
            myParameters.Add("@CertificateNoRegex", SqlDbType.NVarChar, 255).Value = this.CertificateNoRegex;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string ShipClassificationAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = ShipClassificationAb;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_ShipClassification_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string ShipClassificationAb, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_ShipClassification_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_ShipClassification.ParametersAdd(myCmd_Temp.Parameters, ShipClassificationAb, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式           
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.ShipClassification))
            {
                return "船级社(认证机构)不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShipClassificationAb))
            {
                return "船级社(认证机构)缩写不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingStandard))
            {
                return "采用标准不能为空！";
            }
            else if (string.IsNullOrEmpty(this.TestCommitteeID))
            {
                return "存档组织不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShipClassificationEnglishName))
            {
                return "英文名称不能为空！";
            }
            else if (YearSeparate & ShipRestrict)
            {
                return "年份控制与船号控制不能同时使用！";
            }
            else if (!ShipRestrict & TheorySeparate)
            {
                return "理论控制只适用于船号控制！";
            }
            else if (string.IsNullOrEmpty(this.NextIssueNo))
            {
                return "下一个班级编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.NextExaminingNo))
            {
                return "下一个考试编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.IssueNoRegex))
            {
                return "班级编号正则表达式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ExaminingNoRegex))
            {
                return "考试编号正则表达式不能为空！";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.NextIssueNo , this.IssueNoRegex ))
            {
                return "下一个班级编号格式错误！";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.NextExaminingNo  , this.ExaminingNoRegex   ))
            {
                return "下一个考编号格式错误！";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.NextCertificateNo  , this.CertificateNoRegex  ))
            {
                return "下一个证号格式错误！";
            }

            return null;
        }

    }

    public class Class_Ship
    {
        #region "Fields"
        public string ShipboardNo;
        public string ModelNo;
        public string ShipCompetence;
        public string ShipLetter;
        public string TestCommitteeID;
        public string NextSkillIssueNo;
        public string NextSkillExaminingNo;
        public string NextCertificateNo;
        public string NextTheoryIssueNo;
        public string NextTheoryExaminingNo;
        public int SkillIssueNoSignificantDigit;
        public int SkillExaminingNoSignificantDigit;
        public int CertificateNoSignificantDigit;
        public int TheoryIssueNoSignificantDigit;
        public int TheoryExaminingNoSignificantDigit;
        public string SkillIssueNoRegex;
        public string SkillExaminingNoRegex;
        public string CertificateNoRegex;
        public string TheoryIssueNoRegex;
        public string TheoryExaminingNoRegex;
        public string ShipRemark;
        public int ShipIndex;
        #endregion

        public Class_Ship()
        {

        }

        public Class_Ship(string ShipboardNo)
        {
            this.ShipboardNo = ShipboardNo;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_Ship] Where ShipboardNo=@ShipboardNo";
            myCmd_Temp.Parameters.Add("@ShipboardNo", SqlDbType.NVarChar, 20).Value = this.ShipboardNo;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.ModelNo = myReader_Temp["ModelNo"].ToString();
            this.ShipCompetence = myReader_Temp["ShipCompetence"].ToString();
            this.ShipLetter = myReader_Temp["ShipLetter"].ToString();

            this.TestCommitteeID = myReader_Temp["TestCommitteeID"].ToString();
            this.NextSkillIssueNo = myReader_Temp["NextSkillIssueNo"].ToString();
            this.NextSkillExaminingNo = myReader_Temp["NextSkillExaminingNo"].ToString();
            this.NextCertificateNo = myReader_Temp["NextCertificateNo"].ToString();
            this.NextTheoryIssueNo = myReader_Temp["NextTheoryIssueNo"].ToString();
            this.NextTheoryExaminingNo = myReader_Temp["NextTheoryExaminingNo"].ToString();

            this.SkillIssueNoSignificantDigit = int.Parse(myReader_Temp["SkillIssueNoSignificantDigit"].ToString());
            this.SkillExaminingNoSignificantDigit = int.Parse(myReader_Temp["SkillExaminingNoSignificantDigit"].ToString());
            this.CertificateNoSignificantDigit = int.Parse(myReader_Temp["CertificateNoSignificantDigit"].ToString());
            this.TheoryIssueNoSignificantDigit = int.Parse(myReader_Temp["TheoryIssueNoSignificantDigit"].ToString());
            this.TheoryExaminingNoSignificantDigit = int.Parse(myReader_Temp["TheoryExaminingNoSignificantDigit"].ToString());

            this.SkillIssueNoRegex = myReader_Temp["SkillIssueNoRegex"].ToString();
            this.SkillExaminingNoRegex = myReader_Temp["SkillExaminingNoRegex"].ToString();
            this.CertificateNoRegex = myReader_Temp["CertificateNoRegex"].ToString();
            this.TheoryIssueNoRegex = myReader_Temp["TheoryIssueNoRegex"].ToString();
            this.TheoryExaminingNoRegex = myReader_Temp["TheoryExaminingNoRegex"].ToString();

            this.ShipRemark = myReader_Temp["ShipRemark"].ToString();
            this.ShipIndex = (int)myReader_Temp["ShipIndex"];

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ShipboardNo", SqlDbType.NVarChar, 20).Value = this.ShipboardNo;
            myParameters.Add("@ModelNo", SqlDbType.NVarChar, 20).Value = this.ModelNo;
            myParameters.Add("@ShipCompetence", SqlDbType.NVarChar, 50).Value = this.ShipCompetence;
            myParameters.Add("@ShipLetter", SqlDbType.NVarChar, 20).Value = this.ShipLetter;
            myParameters.Add("@ShipIndex", SqlDbType.Int).Value = this.ShipIndex;
            myParameters.Add("@ShipRemark", SqlDbType.NVarChar, 255).Value = this.ShipRemark;

            myParameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = this.TestCommitteeID;
            myParameters.Add("@NextSkillIssueNo", SqlDbType.NVarChar, 20).Value = this.NextSkillIssueNo;
            myParameters.Add("@NextSkillExaminingNo", SqlDbType.NVarChar, 20).Value = this.NextSkillExaminingNo;
            myParameters.Add("@NextCertificateNo", SqlDbType.NVarChar, 20).Value = this.NextCertificateNo;
            myParameters.Add("@NextTheoryIssueNo", SqlDbType.NVarChar, 20).Value = this.NextTheoryIssueNo;
            myParameters.Add("@NextTheoryExaminingNo", SqlDbType.NVarChar, 20).Value = this.NextTheoryExaminingNo;

            myParameters.Add("@SkillIssueNoSignificantDigit", SqlDbType.Int).Value = this.SkillIssueNoSignificantDigit;
            myParameters.Add("@SkillExaminingNoSignificantDigit", SqlDbType.Int).Value = this.SkillExaminingNoSignificantDigit;
            myParameters.Add("@CertificateNoSignificantDigit", SqlDbType.Int).Value = this.CertificateNoSignificantDigit;
            myParameters.Add("@TheoryIssueNoSignificantDigit", SqlDbType.Int).Value = this.TheoryIssueNoSignificantDigit;
            myParameters.Add("@TheoryExaminingNoSignificantDigit", SqlDbType.Int).Value = this.TheoryExaminingNoSignificantDigit;

            myParameters.Add("@SkillIssueNoRegex", SqlDbType.NVarChar, 255).Value = this.SkillIssueNoRegex;
            myParameters.Add("@SkillExaminingNoRegex", SqlDbType.NVarChar, 255).Value = this.SkillExaminingNoRegex;
            myParameters.Add("@CertificateNoRegex", SqlDbType.NVarChar, 255).Value = this.CertificateNoRegex;
            myParameters.Add("@TheoryIssueNoRegex", SqlDbType.NVarChar, 255).Value = this.TheoryIssueNoRegex;
            myParameters.Add("@TheoryExaminingNoRegex", SqlDbType.NVarChar, 255).Value = this.TheoryExaminingNoRegex;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string ShipboardNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ShipboardNo", SqlDbType.NVarChar, 20).Value = ShipboardNo;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_Ship_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string ShipboardNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_Ship_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Ship.ParametersAdd(myCmd_Temp.Parameters, ShipboardNo, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式           
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.ShipboardNo))
            {
                return "船舶系列不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ModelNo))
            {
                return "船舶型号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShipCompetence))
            {
                return "同类船舶不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShipLetter))
            {
                return "序列字母不能为空！";
            }
            else if (string.IsNullOrEmpty(this.TestCommitteeID))
            {
                return "存档组织不能为空！";
            }
            else if (string.IsNullOrEmpty(this.NextSkillIssueNo))
            {
                return "下一个技能班级编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.NextSkillExaminingNo))
            {
                return "下一个技能考试编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.SkillIssueNoRegex))
            {
                return "技能班级编号正则表达式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.SkillExaminingNoRegex))
            {
                return "技能考试编号正则表达式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.NextTheoryIssueNo))
            {
                return "下一个理论班级编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.NextTheoryExaminingNo))
            {
                return "下一个理论考试编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.TheoryIssueNoRegex))
            {
                return "理论班级编号正则表达式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.TheoryExaminingNoRegex))
            {
                return "理论考试编号正则表达式不能为空！";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.NextSkillIssueNo, this.SkillIssueNoRegex))
            {
                return "下一个技能班级编号格式错误！";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.NextSkillExaminingNo, this.SkillExaminingNoRegex ))
            {
                return "下一个技能考试编号格式错误！";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.NextCertificateNo, this.CertificateNoRegex))
            {
                return "下一个证号格式错误！";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.NextTheoryIssueNo, this.TheoryIssueNoRegex))
            {
                return "下一个理论班级编号格式错误！";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.NextTheoryExaminingNo, this.TheoryExaminingNoRegex ))
            {
                return "下一个理论考试编号格式错误！";
            }

            return null;
        }

    }

    public class Class_TestCommittee
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string TestCommitteeID;
        public string TestCommittee;
        public string NextRegistrationNo;
        public int RegistrationNoSignificantDigit;
        public string RegistrationNoRegex;
        public int TestCommitteeIndex;
        public string TestCommitteeRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_TestCommittee()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="TestCommittee"></param>
        public Class_TestCommittee(string TestCommitteeID)
        {
            this.TestCommitteeID = TestCommitteeID;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_TestCommittee] Where TestCommitteeID=@TestCommitteeID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = this.TestCommitteeID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.TestCommittee = myReader_Temp["TestCommittee"].ToString();
                this.NextRegistrationNo = myReader_Temp["NextRegistrationNo"].ToString();
                this.RegistrationNoRegex = myReader_Temp["RegistrationNoRegex"].ToString();
                this.RegistrationNoSignificantDigit = (int)myReader_Temp["RegistrationNoSignificantDigit"];
                this.TestCommitteeIndex = (int)myReader_Temp["TestCommitteeIndex"];
                this.TestCommitteeRemark = myReader_Temp["TestCommitteeRemark"].ToString();
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
            myParameters.Add("@TestCommittee", SqlDbType.NVarChar, 50).Value = this.TestCommittee;
            myParameters.Add("@NextRegistrationNo", SqlDbType.NVarChar, 20).Value = this.NextRegistrationNo;
            myParameters.Add("@RegistrationNoRegex", SqlDbType.NVarChar, 255).Value = this.RegistrationNoRegex;
            myParameters.Add("@RegistrationNoSignificantDigit", SqlDbType.Int).Value = this.RegistrationNoSignificantDigit;
            myParameters.Add("@TestCommitteeIndex", SqlDbType.Int).Value = this.TestCommitteeIndex;
            myParameters.Add("@TestCommitteeRemark", SqlDbType.NVarChar, 255).Value = this.TestCommitteeRemark;

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
        /// <param name="TestCommittee"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string TestCommitteeID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@TestCommitteeID", SqlDbType.NVarChar, 20).Value = TestCommitteeID;
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
            myCmd_Temp.CommandText = "Parameter_TestCommittee_Update";
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
        /// <param name="TestCommittee"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string TestCommitteeID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_TestCommittee_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_TestCommittee.ParametersAdd(myCmd_Temp.Parameters, TestCommitteeID, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.TestCommitteeID))
            {
                return "存档组织不能为空！";
            }
            else if (string.IsNullOrEmpty(this.TestCommittee))
            {
                return "存档组织名称不能为空！";
            }
            else if (string.IsNullOrEmpty(this.NextRegistrationNo))
            {
                return "下一个存档编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.RegistrationNoRegex))
            {
                return "存档编号正则表达式不能为空！";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.NextRegistrationNo , this.RegistrationNoRegex))
            {
                return "下一个存档编号格式错误！";
            }
            return null;
        }

    }

    public class Class_ShipandShipClassification
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string ShipClassificationAb;
        public string ShipboardNo;
        public int ShipandShipClassificationIndex;
        public string ShipandShipClassificationRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_ShipandShipClassification()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="ShipandShipClassification"></param>
        public Class_ShipandShipClassification(string ShipClassificationAb, string ShipboardNo)
        {
            this.ShipClassificationAb = ShipClassificationAb;
            this.ShipboardNo = ShipboardNo;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_ShipandShipClassification] Where ShipClassificationAb=@ShipClassificationAb And ShipboardNo=@ShipboardNo";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = this.ShipClassificationAb;
            myCmd_Temp.Parameters.Add("@ShipboardNo", SqlDbType.NVarChar, 20).Value = this.ShipboardNo;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.ShipandShipClassificationIndex = (int)myReader_Temp["ShipandShipClassificationIndex"];
                this.ShipandShipClassificationRemark = myReader_Temp["ShipandShipClassificationRemark"].ToString();
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
            myParameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = this.ShipClassificationAb;
            myParameters.Add("@ShipboardNo", SqlDbType.NVarChar, 20).Value = this.ShipboardNo;
            myParameters.Add("@ShipandShipClassificationIndex", SqlDbType.Int).Value = this.ShipandShipClassificationIndex;
            myParameters.Add("@ShipandShipClassificationRemark", SqlDbType.NVarChar, 255).Value = this.ShipandShipClassificationRemark;

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
        /// <param name="ShipandShipClassification"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string ShipClassificationAb, string ShipboardNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = ShipClassificationAb;
            myParameters.Add("@ShipboardNo", SqlDbType.NVarChar, 20).Value = ShipboardNo;
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
            myCmd_Temp.CommandText = "Parameter_ShipandShipClassification_Update";
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
        /// <param name="ShipandShipClassification"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string ShipClassificationAb, string ShipboardNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_ShipandShipClassification_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_ShipandShipClassification.ParametersAdd(myCmd_Temp.Parameters, ShipClassificationAb, ShipboardNo, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.ShipClassificationAb ))
            {
                return "船级社不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShipboardNo  ))
            {
                return "船舶系列不能为空！";
            }

            return null;
        }

    }

    public class Class_KindofExam
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string KindofExam;
        public bool TheoryResultNeed;
        public bool SkillResultNeed;
        public int PassScore;
        public int KindofExamIndex;
        public string KindofExamRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_KindofExam()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="KindofExam"></param>
        public Class_KindofExam(string KindofExam)
        {
            this.KindofExam = KindofExam;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_KindofExam] Where KindofExam=@KindofExam";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@KindofExam", SqlDbType.NVarChar, 10).Value = this.KindofExam;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.TheoryResultNeed = (bool)myReader_Temp["TheoryResultNeed"];
                this.SkillResultNeed = (bool)myReader_Temp["SkillResultNeed"];
                this.PassScore = (int)myReader_Temp["PassScore"];
                this.KindofExamIndex = (int)myReader_Temp["KindofExamIndex"];
                this.KindofExamRemark = myReader_Temp["KindofExamRemark"].ToString();
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
            myParameters.Add("@KindofExam", SqlDbType.NVarChar, 10).Value = this.KindofExam;
            myParameters.Add("@TheoryResultNeed", SqlDbType.Bit ).Value = this.TheoryResultNeed;
            myParameters.Add("@SkillResultNeed", SqlDbType.Bit).Value = this.SkillResultNeed;
            myParameters.Add("@PassScore", SqlDbType.Int).Value = this.PassScore;
            myParameters.Add("@KindofExamIndex", SqlDbType.Int).Value = this.KindofExamIndex;
            myParameters.Add("@KindofExamRemark", SqlDbType.NVarChar, 255).Value = this.KindofExamRemark;

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
        /// <param name="KindofExam"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string KindofExam, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@KindofExam", SqlDbType.NVarChar, 10).Value = KindofExam;
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
            myCmd_Temp.CommandText = "Parameter_KindofExam_Update";
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
        /// <param name="KindofExam"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string KindofExam, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_KindofExam_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_KindofExam.ParametersAdd(myCmd_Temp.Parameters, KindofExam, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.KindofExam))
            {
                return "考试方式不能为空！";
            }

            return null;
        }

    }

    public class Class_Assemblage
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string Assemblage;
        public string ISOAssemblage;
        public string ISOWeldingSide;
        public string WeldingSide;
        public string ScopeofCCSAssemblage;
        public string ScopeofISOAssemblage;
        public string KindofWeld;
        public string AssemblageEnglish;
        public int AssemblageIndex;
        public string AssemblageRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_Assemblage()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="Assemblage"></param>
        public Class_Assemblage(string Assemblage)
        {
            this.Assemblage = Assemblage;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_Assemblage] Where Assemblage=@Assemblage";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@Assemblage", SqlDbType.NVarChar, 10).Value = this.Assemblage;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.ISOAssemblage = myReader_Temp["ISOAssemblage"].ToString();
                this.ISOWeldingSide = myReader_Temp["ISOWeldingSide"].ToString();
                this.WeldingSide = myReader_Temp["WeldingSide"].ToString();
                this.ScopeofCCSAssemblage = myReader_Temp["ScopeofCCSAssemblage"].ToString();
                this.ScopeofISOAssemblage = myReader_Temp["ScopeofISOAssemblage"].ToString();
                this.KindofWeld = myReader_Temp["KindofWeld"].ToString();
                this.AssemblageEnglish = myReader_Temp["AssemblageEnglish"].ToString();
                this.AssemblageIndex = (int)myReader_Temp["AssemblageIndex"];
                this.AssemblageRemark = myReader_Temp["AssemblageRemark"].ToString();
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
            myParameters.Add("@Assemblage", SqlDbType.NVarChar, 10).Value = this.Assemblage;
            myParameters.Add("@ISOAssemblage", SqlDbType.NVarChar, 20).Value = this.ISOAssemblage;
            myParameters.Add("@ISOWeldingSide", SqlDbType.NVarChar, 20).Value = this.ISOWeldingSide;
            myParameters.Add("@WeldingSide", SqlDbType.NVarChar, 20).Value = this.WeldingSide;
            myParameters.Add("@ScopeofCCSAssemblage", SqlDbType.NVarChar, 100).Value = this.ScopeofCCSAssemblage;
            myParameters.Add("@ScopeofISOAssemblage", SqlDbType.NVarChar, 100).Value = this.ScopeofISOAssemblage;
            myParameters.Add("@KindofWeld", SqlDbType.NVarChar, 50).Value = this.KindofWeld;
            myParameters.Add("@AssemblageEnglish", SqlDbType.NVarChar, 100).Value = this.AssemblageEnglish;
            myParameters.Add("@AssemblageIndex", SqlDbType.Int).Value = this.AssemblageIndex;
            myParameters.Add("@AssemblageRemark", SqlDbType.NVarChar, 255).Value = this.AssemblageRemark;

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
        /// <param name="Assemblage"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string Assemblage, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@Assemblage", SqlDbType.NVarChar, 10).Value = Assemblage;
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
            myCmd_Temp.CommandText = "Parameter_Assemblage_Update";
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
        /// <param name="Assemblage"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string Assemblage, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_Assemblage_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Assemblage.ParametersAdd(myCmd_Temp.Parameters, Assemblage, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.Assemblage))
            {
                return "装配方式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ISOAssemblage))
            {
                return "ISO装配方式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ISOWeldingSide))
            {
                return "ISO焊接方式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingSide))
            {
                return "焊接方式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ScopeofCCSAssemblage))
            {
                return "CCS适用范围不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ScopeofISOAssemblage))
            {
                return "ISO适用范围不能为空！";
            }
            else if (string.IsNullOrEmpty(this.KindofWeld))
            {
                return "焊缝类型不能为空！";
            }
            else if (string.IsNullOrEmpty(this.AssemblageEnglish))
            {
                return "英文名称不能为空！";
            }

            return null;
        }

    }

    public class Class_WeldingEquipment
    {
        #region "Fields"
        public string WeldingEquipment;
        public string WeldingEquipmentRemark;
        public int WeldingEquipmentIndex;
        #endregion

        public Class_WeldingEquipment()
        {

        }

        public Class_WeldingEquipment(string WeldingEquipment)
        {
            this.WeldingEquipment = WeldingEquipment;
            this.FillData();
        }

        public bool FillData()
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.CommandText = "Select * From [Parameter_WeldingEquipment] Where WeldingEquipment=@WeldingEquipment";
            myCmd_Temp.Parameters.Add("@WeldingEquipment", SqlDbType.NVarChar, 50).Value = this.WeldingEquipment;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.WeldingEquipmentRemark = myReader_Temp["WeldingEquipmentRemark"].ToString();
            this.WeldingEquipmentIndex = (int)myReader_Temp["WeldingEquipmentIndex"];

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingEquipment", SqlDbType.NVarChar, 50).Value = this.WeldingEquipment;
            myParameters.Add("@WeldingEquipmentIndex", SqlDbType.Int).Value = this.WeldingEquipmentIndex;
            myParameters.Add("@WeldingEquipmentRemark", SqlDbType.NVarChar, 255).Value = this.WeldingEquipmentRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string WeldingEquipment, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingEquipment", SqlDbType.NVarChar, 50).Value = WeldingEquipment;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingEquipment_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string WeldingEquipment, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingEquipment_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingEquipment.ParametersAdd(myCmd_Temp.Parameters, WeldingEquipment, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式                
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.WeldingEquipment))
            {
                return "焊接设备不能为空！";
            }

            return null;
        }

    }

    public class Class_WeldingPosition
    {
        #region "Fields"
        public string WeldingPosition;
        public string WeldingPositionDenomination;
        public string WeldingPositionRemark;
        public string WeldingPositionCCS;
        public string WeldingPositionISO;
        public string WeldingPositionABS;
        public int WeldingPositionIndex;
        #endregion

        public Class_WeldingPosition()
        {

        }

        public Class_WeldingPosition(string WeldingPosition)
        {
            this.WeldingPosition = WeldingPosition;
            this.FillData();
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_WeldingPosition] Where WeldingPosition=@WeldingPosition";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WeldingPosition", SqlDbType.NVarChar, 20).Value = this.WeldingPosition;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;
            if (myReader_Temp.Read())
            {
                this.WeldingPositionDenomination = (string)myReader_Temp["WeldingPositionDenomination"];
                if (myReader_Temp["WeldingPositionRemark"] == DBNull.Value)
                {
                    this.WeldingPositionRemark = "";
                }
                else
                {
                    this.WeldingPositionRemark = (string)myReader_Temp["WeldingPositionRemark"];
                }
                this.WeldingPositionCCS = myReader_Temp["WeldingPositionCCS"].ToString();
                this.WeldingPositionISO = myReader_Temp["WeldingPositionISO"].ToString();
                this.WeldingPositionABS = myReader_Temp["WeldingPositionABS"].ToString();
                this.WeldingPositionIndex = (int)myReader_Temp["WeldingPositionIndex"];
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

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingPosition", SqlDbType.NVarChar, 20).Value = this.WeldingPosition;
            myParameters.Add("@WeldingPositionDenomination", SqlDbType.NVarChar, 50).Value = this.WeldingPositionDenomination;
            myParameters.Add("@WeldingPositionCCS", SqlDbType.NVarChar, 20).Value = this.WeldingPositionCCS;
            myParameters.Add("@WeldingPositionISO", SqlDbType.NVarChar, 20).Value = this.WeldingPositionISO;
            myParameters.Add("@WeldingPositionABS", SqlDbType.NVarChar, 20).Value = this.WeldingPositionABS;
            myParameters.Add("@WeldingPositionRemark", SqlDbType.NVarChar, 255).Value = this.WeldingPositionRemark;
            myParameters.Add("@WeldingPositionIndex", SqlDbType.Int).Value = this.WeldingPositionIndex;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string WeldingPosition, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WeldingPosition", SqlDbType.NVarChar, 20).Value = WeldingPosition;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingPosition_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string WeldingPosition, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_WeldingPosition_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WeldingPosition.ParametersAdd(myCmd_Temp.Parameters, WeldingPosition, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式            
        public string CheckField()
        {
            if (this.WeldingPosition == null || this.WeldingPosition.Length == 0)
            {
                return "焊接位置符号不能为空！";
            }
            else if (this.WeldingPositionDenomination == null || this.WeldingPositionDenomination.Length == 0)
            {
                return "焊接位置不能为空！";
            }

            return null;
        }

    }
    
    public class Class_GasAndWeldingFlux
    {
        #region "Fields"
        public string GasAndWeldingFlux;
        public string GasAndWeldingFluxGroup;
        public string GasAndWeldingFluxParameter;
        public string GasAndWeldingFluxRemark;
        public int GasAndWeldingFluxIndex;
        #endregion

        public Class_GasAndWeldingFlux()
        {

        }

        public Class_GasAndWeldingFlux(string GasAndWeldingFlux)
        {
            this.GasAndWeldingFlux = GasAndWeldingFlux;
            this.FillData();
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Parameter_GasAndWeldingFlux] Where GasAndWeldingFlux=@GasAndWeldingFlux";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@GasAndWeldingFlux", SqlDbType.NVarChar, 50).Value = this.GasAndWeldingFlux;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;
            if (myReader_Temp.Read())
            {
                this.GasAndWeldingFlux = myReader_Temp["GasAndWeldingFlux"].ToString();
                this.GasAndWeldingFluxRemark = myReader_Temp["GasAndWeldingFluxRemark"].ToString();
                this.GasAndWeldingFluxGroup = myReader_Temp["GasAndWeldingFluxGroup"].ToString();
                this.GasAndWeldingFluxParameter = myReader_Temp["GasAndWeldingFluxParameter"].ToString();
                this.GasAndWeldingFluxIndex = (int)myReader_Temp["GasAndWeldingFluxIndex"];
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

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@GasAndWeldingFlux", SqlDbType.NVarChar, 50).Value = this.GasAndWeldingFlux;
            myParameters.Add("@GasAndWeldingFluxGroup", SqlDbType.NVarChar, 20).Value = this.GasAndWeldingFluxGroup;
            myParameters.Add("@GasAndWeldingFluxParameter", SqlDbType.NVarChar, 20).Value = this.GasAndWeldingFluxParameter;
            myParameters.Add("@GasAndWeldingFluxIndex", SqlDbType.Int).Value = this.GasAndWeldingFluxIndex;
            myParameters.Add("@GasAndWeldingFluxRemark", SqlDbType.NVarChar, 255).Value = this.GasAndWeldingFluxRemark;

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
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, string GasAndWeldingFlux, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@GasAndWeldingFlux", SqlDbType.NVarChar, 50).Value = GasAndWeldingFlux;
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

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_GasAndWeldingFlux_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(string GasAndWeldingFlux, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Parameter_GasAndWeldingFlux_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_GasAndWeldingFlux.ParametersAdd(myCmd_Temp.Parameters, GasAndWeldingFlux, myEnum_zwjKindofUpdate);
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

        //校验数据字段的格式       
        public string CheckField()
        {
            if (this.GasAndWeldingFlux == null || this.GasAndWeldingFlux.Length == 0)
            {
                return "焊接辅助材料不能为空！";
            }
            else if (this.GasAndWeldingFluxGroup == null || this.GasAndWeldingFluxGroup.Length == 0)
            {
                return "焊接辅助材料属性不能为空！";
            }

            return null;
        }

    }


}

