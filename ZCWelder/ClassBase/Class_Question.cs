using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ZCCL.ClassBase;
using ZCCL.Tools;
using ZCCL.AspNet;
using ZCCL.UpdateLog;
using ZCCL.Report;
using ZCExcel = Microsoft.Office.Interop.Excel;
using ZCWord = Microsoft.Office.Interop.Word;
using System.IO;
using ZCWelder.Exam;
using System.Windows.Forms;

namespace ZCWelder.ClassBase
{
    public class Class_Subject
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public string Subject;
        public int SubjectIndex;
        public string SubjectRemark;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_Subject()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="Subject"></param>
        public Class_Subject(string Subject)
        {
            this.Subject = Subject;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Question_Subject] Where Subject=@Subject";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = this.Subject;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.SubjectIndex = (int)myReader_Temp["SubjectIndex"];
                this.SubjectRemark = myReader_Temp["SubjectRemark"].ToString();
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
            myParameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = this.Subject;
            myParameters.Add("@SubjectIndex", SqlDbType.Int).Value = this.SubjectIndex;
            myParameters.Add("@SubjectRemark", SqlDbType.NVarChar, 255).Value = this.SubjectRemark;

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
        /// <param name="Subject"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string Subject, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = Subject;
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
            myCmd_Temp.CommandText = "Question_Subject_Update";
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
        /// <param name="Subject"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string Subject, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Question_Subject_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Subject.ParametersAdd(myCmd_Temp.Parameters, Subject, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.Subject))
            {
                return "科目不能为空！";
            }

            return null;
        }

    }

    public class Class_Choice
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public int ChoiceID;
        public string Subject;
        public string QuestionText;
        public string Result;
        public string A;
        public string B;
        public string C;
        public string D;
        public string E;
        public int ResultQuantity;
        public double  DegreeOfDifficulty;
        public string ChoiceRemark;
        public bool  isValid;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_Choice()
        {

        }

        public Class_Choice(int ChoiceID)
        {
            this.ChoiceID = ChoiceID;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Question_Choice] Where ChoiceID=@ChoiceID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@ChoiceID", SqlDbType.Int).Value = this.ChoiceID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.Subject = myReader_Temp["Subject"].ToString();
                this.QuestionText = myReader_Temp["QuestionText"].ToString();
                this.Result = myReader_Temp["Result"].ToString();
                this.A = myReader_Temp["A"].ToString();
                this.B = myReader_Temp["B"].ToString();
                this.C = myReader_Temp["C"].ToString();
                this.D = myReader_Temp["D"].ToString();
                this.E = myReader_Temp["E"].ToString();
                this.ResultQuantity = (int)myReader_Temp["ResultQuantity"];
                this.DegreeOfDifficulty = (double )myReader_Temp["DegreeOfDifficulty"];
                this.ChoiceRemark = myReader_Temp["ChoiceRemark"].ToString();
                this.isValid = (bool)myReader_Temp["isValid"];
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
            myParameters.Add("@ChoiceID", SqlDbType.Int ).Direction= ParameterDirection.InputOutput ;
            myParameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = this.Subject;
            myParameters.Add("@QuestionText", SqlDbType.NVarChar, 255).Value = this.QuestionText;
            myParameters.Add("@Result", SqlDbType.NVarChar, 1).Value = this.Result;
            myParameters.Add("@A", SqlDbType.NVarChar, 255).Value = this.A;
            myParameters.Add("@B", SqlDbType.NVarChar, 255).Value = this.B;
            myParameters.Add("@C", SqlDbType.NVarChar, 255).Value = this.C;
            myParameters.Add("@D", SqlDbType.NVarChar, 255).Value = this.D;
            myParameters.Add("@E", SqlDbType.NVarChar, 255).Value = this.E;
            myParameters.Add("@ResultQuantity", SqlDbType.Int).Value = this.ResultQuantity;
            myParameters.Add("@DegreeOfDifficulty", SqlDbType.Real ).Value = this.DegreeOfDifficulty;
            myParameters.Add("@ChoiceRemark", SqlDbType.NVarChar, 255).Value = this.ChoiceRemark;
            myParameters.Add("@isValid", SqlDbType.Bit ).Value = this.isValid;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@ChoiceID"].Value = this.ChoiceID;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="Choice"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, int ChoiceID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ChoiceID", SqlDbType.Int).Value = ChoiceID;
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
            myCmd_Temp.CommandText = "Question_Choice_Update";
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
        /// <param name="Choice"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(int ChoiceID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Question_Choice_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Choice.ParametersAdd(myCmd_Temp.Parameters, ChoiceID, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.Subject))
            {
                return "科目不能为空！";
            }
            else if (string.IsNullOrEmpty(this.QuestionText))
            {
                return "题目内容不能为空！";
            }
            else if (this.DegreeOfDifficulty <= 0 || this.DegreeOfDifficulty>=1)
            {
                return "难度系数只能为0~1区间的小数！";
            }
            else
            {
                switch (this.ResultQuantity)
                {
                    case 2:
                        if (!(this.Result == "A" || this.Result == "B"))
                        {
                            return "没有改选项答案！";
                        }
                        break;
                    case 3:
                        if (!(this.Result == "A" || this.Result == "B" || this.Result == "C"))
                        {
                            return "没有改选项答案！";
                        }
                        break;
                    case 4:
                        if (!(this.Result == "A" || this.Result == "B" || this.Result == "C" || this.Result == "D"))
                        {
                            return "没有改选项答案！";
                        }
                        break;
                    case 5:
                        if (!(this.Result == "A" || this.Result == "B" || this.Result == "C" || this.Result == "D" || this.Result == "E"))
                        {
                            return "没有改选项答案！";
                        }
                        break;
                    default:
                        return "选项条数有误！";
                       break;
                }
            }

            return null;
        }

    }

    public class Class_EssayQuestion
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public int EssayQuestionID;
        public string Subject;
        public string QuestionText;
        public string Result;
        public double  DegreeOfDifficulty;
        public string EssayQuestionRemark;
        public bool  isValid;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_EssayQuestion()
        {

        }

        public Class_EssayQuestion(int EssayQuestionID)
        {
            this.EssayQuestionID = EssayQuestionID;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Question_EssayQuestion] Where EssayQuestionID=@EssayQuestionID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@EssayQuestionID", SqlDbType.Int).Value = this.EssayQuestionID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.Subject = myReader_Temp["Subject"].ToString();
                this.QuestionText = myReader_Temp["QuestionText"].ToString();
                this.Result = myReader_Temp["Result"].ToString();
                this.DegreeOfDifficulty = (double )myReader_Temp["DegreeOfDifficulty"];
                this.EssayQuestionRemark = myReader_Temp["EssayQuestionRemark"].ToString();
                this.isValid = (bool)myReader_Temp["isValid"];
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
            myParameters.Add("@EssayQuestionID", SqlDbType.Int ).Direction= ParameterDirection.InputOutput ;
            myParameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = this.Subject;
            myParameters.Add("@QuestionText", SqlDbType.NVarChar, 255).Value = this.QuestionText;
            myParameters.Add("@Result", SqlDbType.NVarChar, 1).Value = this.Result;
            myParameters.Add("@DegreeOfDifficulty", SqlDbType.Real ).Value = this.DegreeOfDifficulty;
            myParameters.Add("@EssayQuestionRemark", SqlDbType.NVarChar, 255).Value = this.EssayQuestionRemark;
            myParameters.Add("@isValid", SqlDbType.Bit ).Value = this.isValid;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@EssayQuestionID"].Value = this.EssayQuestionID;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="EssayQuestion"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, int EssayQuestionID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@EssayQuestionID", SqlDbType.Int).Value = EssayQuestionID;
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
            myCmd_Temp.CommandText = "Question_EssayQuestion_Update";
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
        /// <param name="EssayQuestion"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(int EssayQuestionID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Question_EssayQuestion_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_EssayQuestion.ParametersAdd(myCmd_Temp.Parameters, EssayQuestionID, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.Subject))
            {
                return "科目不能为空！";
            }
            else if (string.IsNullOrEmpty(this.QuestionText))
            {
                return "题目内容不能为空！";
            }
            else if (this.DegreeOfDifficulty <= 0 || this.DegreeOfDifficulty>=1)
            {
                return "难度系数只能为0~1区间的小数！";
            }


            return null;
        }

    }

    public class Class_Judgment
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public int JudgmentID;
        public string Subject;
        public string QuestionText;
        public bool  Result;
        public double DegreeOfDifficulty;
        public string JudgmentRemark;
        public bool isValid;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_Judgment()
        {

        }

        public Class_Judgment(int JudgmentID)
        {
            this.JudgmentID = JudgmentID;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Question_Judgment] Where JudgmentID=@JudgmentID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@JudgmentID", SqlDbType.Int).Value = this.JudgmentID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.Subject = myReader_Temp["Subject"].ToString();
                this.QuestionText = myReader_Temp["QuestionText"].ToString();
                this.Result = (bool)myReader_Temp["Result"];
                this.DegreeOfDifficulty = (double)myReader_Temp["DegreeOfDifficulty"];
                this.JudgmentRemark = myReader_Temp["JudgmentRemark"].ToString();
                this.isValid = (bool)myReader_Temp["isValid"];
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
            myParameters.Add("@JudgmentID", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            myParameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = this.Subject;
            myParameters.Add("@QuestionText", SqlDbType.NVarChar, 255).Value = this.QuestionText;
            myParameters.Add("@Result", SqlDbType.Bit ).Value = this.Result;
            myParameters.Add("@DegreeOfDifficulty", SqlDbType.Real).Value = this.DegreeOfDifficulty;
            myParameters.Add("@JudgmentRemark", SqlDbType.NVarChar, 255).Value = this.JudgmentRemark;
            myParameters.Add("@isValid", SqlDbType.Bit).Value = this.isValid;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@JudgmentID"].Value = this.JudgmentID;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="Judgment"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, int JudgmentID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@JudgmentID", SqlDbType.Int).Value = JudgmentID;
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
            myCmd_Temp.CommandText = "Question_Judgment_Update";
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
        /// <param name="Judgment"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(int JudgmentID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Question_Judgment_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Judgment.ParametersAdd(myCmd_Temp.Parameters, JudgmentID, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.Subject))
            {
                return "科目不能为空！";
            }
            else if (string.IsNullOrEmpty(this.QuestionText))
            {
                return "题目内容不能为空！";
            }
            else if (this.DegreeOfDifficulty <= 0 || this.DegreeOfDifficulty >= 1)
            {
                return "难度系数只能为0~1区间的小数！";
            }


            return null;
        }

    }

    public class Class_MultiChoice
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public int MultiChoiceID;
        public string Subject;
        public string QuestionText;
        public string Result;
        public string A;
        public string B;
        public string C;
        public string D;
        public string E;
        public string F;
        public string G;
        public bool ResultA;
        public bool ResultB;
        public bool ResultC;
        public bool ResultD;
        public bool ResultE;
        public bool ResultF;
        public bool ResultG;
        public int ResultQuantity;
        public double DegreeOfDifficulty;
        public string MultiChoiceRemark;
        public bool isValid;
        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_MultiChoice()
        {

        }

        public Class_MultiChoice(int MultiChoiceID)
        {
            this.MultiChoiceID = MultiChoiceID;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Question_MultiChoice] Where MultiChoiceID=@MultiChoiceID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@MultiChoiceID", SqlDbType.Int).Value = this.MultiChoiceID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.Subject = myReader_Temp["Subject"].ToString();
                this.QuestionText = myReader_Temp["QuestionText"].ToString();
                this.Result = myReader_Temp["Result"].ToString();
                this.A = myReader_Temp["A"].ToString();
                this.B = myReader_Temp["B"].ToString();
                this.C = myReader_Temp["C"].ToString();
                this.D = myReader_Temp["D"].ToString();
                this.E = myReader_Temp["E"].ToString();
                this.F = myReader_Temp["F"].ToString();
                this.G = myReader_Temp["G"].ToString();
                this.ResultA = (bool )myReader_Temp["ResultA"];
                this.ResultB = (bool)myReader_Temp["ResultB"];
                this.ResultC = (bool)myReader_Temp["ResultC"];
                this.ResultD = (bool)myReader_Temp["ResultD"];
                this.ResultE = (bool)myReader_Temp["ResultE"];
                this.ResultF = (bool)myReader_Temp["ResultF"];
                this.ResultG = (bool)myReader_Temp["ResultG"];
                this.ResultQuantity = (int)myReader_Temp["ResultQuantity"];
                this.DegreeOfDifficulty = (double)myReader_Temp["DegreeOfDifficulty"];
                this.MultiChoiceRemark = myReader_Temp["MultiChoiceRemark"].ToString();
                this.isValid = (bool)myReader_Temp["isValid"];
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
            myParameters.Add("@MultiChoiceID", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            myParameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = this.Subject;
            myParameters.Add("@QuestionText", SqlDbType.NVarChar, 255).Value = this.QuestionText;
            myParameters.Add("@Result", SqlDbType.NVarChar, 1).Value = this.Result;
            myParameters.Add("@A", SqlDbType.NVarChar, 255).Value = this.A;
            myParameters.Add("@B", SqlDbType.NVarChar, 255).Value = this.B;
            myParameters.Add("@C", SqlDbType.NVarChar, 255).Value = this.C;
            myParameters.Add("@D", SqlDbType.NVarChar, 255).Value = this.D;
            myParameters.Add("@E", SqlDbType.NVarChar, 255).Value = this.E;
            myParameters.Add("@F", SqlDbType.NVarChar, 255).Value = this.F;
            myParameters.Add("@G", SqlDbType.NVarChar, 255).Value = this.G;
            myParameters.Add("@ResultA", SqlDbType.Bit ).Value = this.ResultA;
            myParameters.Add("@ResultB", SqlDbType.Bit).Value = this.ResultB;
            myParameters.Add("@ResultC", SqlDbType.Bit).Value = this.ResultC;
            myParameters.Add("@ResultD", SqlDbType.Bit).Value = this.ResultD;
            myParameters.Add("@ResultE", SqlDbType.Bit).Value = this.ResultE;
            myParameters.Add("@ResultF", SqlDbType.Bit).Value = this.ResultF;
            myParameters.Add("@ResultG", SqlDbType.Bit).Value = this.ResultG;
            myParameters.Add("@ResultQuantity", SqlDbType.Int).Value = this.ResultQuantity;
            myParameters.Add("@DegreeOfDifficulty", SqlDbType.Real).Value = this.DegreeOfDifficulty;
            myParameters.Add("@MultiChoiceRemark", SqlDbType.NVarChar, 255).Value = this.MultiChoiceRemark;
            myParameters.Add("@isValid", SqlDbType.Bit).Value = this.isValid;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@MultiChoiceID"].Value = this.MultiChoiceID;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="MultiChoice"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, int MultiChoiceID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@MultiChoiceID", SqlDbType.Int ).Value = MultiChoiceID;
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
            myCmd_Temp.CommandText = "Question_MultiChoice_Update";
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
        /// <param name="MultiChoice"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(int MultiChoiceID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Question_MultiChoice_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_MultiChoice.ParametersAdd(myCmd_Temp.Parameters, MultiChoiceID, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.Subject))
            {
                return "科目不能为空！";
            }
            else if (string.IsNullOrEmpty(this.QuestionText))
            {
                return "题目内容不能为空！";
            }
            else if (this.DegreeOfDifficulty <= 0 || this.DegreeOfDifficulty >= 1)
            {
                return "难度系数只能为0~1区间的小数！";
            }
            else
            {
            }

            return null;
        }

    }



}
