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
    public  class Class_WeldingParameter
    {
    #region "Fields"
        public string Material;
        public string DimensionofMaterial;
        public string WeldingConsumable ;
        public string KindofExam ;
        public string Assemblage ;
        public double RenderWeldingRodDiameter;
        public double WeldingRodDiameter ;
        public double CoverWeldingRodDiameter ;
        public string ExternalDiameter ;
        public string Thickness ;
        public double double_ExternalDiameter;
        public  double double_Thickness;
    #endregion
            
        public void ParametersAdd(SqlParameterCollection myParameters, string  str_Prefixion )
        {
            myParameters.Add("@" + str_Prefixion + "Material", SqlDbType.NVarChar, 50).Value = this.Material;
            myParameters.Add("@" + str_Prefixion + "DimensionofMaterial", SqlDbType.NVarChar, 50).Value = this.DimensionofMaterial;
            myParameters.Add("@" + str_Prefixion + "WeldingConsumable", SqlDbType.NVarChar, 50).Value = this.WeldingConsumable;
            myParameters.Add("@" + str_Prefixion + "Thickness", SqlDbType.NVarChar, 20).Value = this.Thickness;
            if (!string.IsNullOrEmpty(this.ExternalDiameter))
            {
                myParameters.Add("@" + str_Prefixion + "ExternalDiameter", SqlDbType.NVarChar, 20).Value = this.ExternalDiameter;
            }
            myParameters.Add("@" + str_Prefixion + "RenderWeldingRodDiameter", SqlDbType.Real).Value = this.RenderWeldingRodDiameter;
            myParameters.Add("@" + str_Prefixion + "WeldingRodDiameter", SqlDbType.Real).Value = this.WeldingRodDiameter;
            myParameters.Add("@" + str_Prefixion + "CoverWeldingRodDiameter", SqlDbType.Real).Value = this.CoverWeldingRodDiameter;
            myParameters.Add("@" + str_Prefixion + "Assemblage", SqlDbType.NVarChar, 10).Value = this.Assemblage;
            myParameters.Add("@" + str_Prefixion + "KindofExam", SqlDbType.NVarChar, 10).Value = this.KindofExam;

        }

        public void FillData(SqlDataReader myReader, string str_Prefixion )
        {
            this.KindofExam = myReader[str_Prefixion + "KindofExam"].ToString();
            this.Material = myReader[str_Prefixion + "Material"].ToString();
            this.DimensionofMaterial = myReader[str_Prefixion + "DimensionofMaterial"].ToString();
            this.WeldingConsumable = myReader[str_Prefixion + "WeldingConsumable"].ToString();
            this.RenderWeldingRodDiameter = double.Parse(myReader[str_Prefixion + "RenderWeldingRodDiameter"].ToString());
            this.WeldingRodDiameter = double.Parse(myReader[str_Prefixion + "WeldingRodDiameter"].ToString());
            this.CoverWeldingRodDiameter = double.Parse(myReader[str_Prefixion + "CoverWeldingRodDiameter"].ToString());
            this.Assemblage = myReader[str_Prefixion + "Assemblage"].ToString();
            this.Thickness = myReader[str_Prefixion + "Thickness"].ToString();
            this.ExternalDiameter = myReader[str_Prefixion + "ExternalDiameter"].ToString();

        }

        public string   CheckField()
       {
            if( string.IsNullOrEmpty(this.Assemblage))
                return  "装配方式不能为空";
            else if (string.IsNullOrEmpty(this.Material))
                return "母材不能为空";
            else if (string.IsNullOrEmpty(this.DimensionofMaterial))
                return "母材尺寸不能为空";
            else if( string.IsNullOrEmpty(this.WeldingConsumable))
                return "焊接材料不能为空";
            else if( string.IsNullOrEmpty(this.KindofExam ))
                return "考试方式不能为空";
            else if( string.IsNullOrEmpty(this.Thickness ))
                return "板(管壁)厚不能为空";
            return null;
        }
    }
    
    public class Class_Issue
    {
    #region "Fields"
        public Class_WeldingParameter myClass_WeldingParameter= new Class_WeldingParameter();

        public string  IssueNo;
        public  string ShipClassificationAb;
        public string   ShipboardNo ;
        public  string EmployerHPID;
        public  string KindofEmployer ;
        public  string WeldingProcessAb ;
        public uint  IssueStatus ;
        public  string PlaceofTest ;

        public DateTime  SignUpDate;
        public DateTime DateBeginningofTrain ;
        public DateTime DateEndingofTrain ;
        public DateTime TheoryExamDate ;
        public DateTime SkillExamDate ;
        public DateTime TheoryMakeupDate;
        public DateTime SkillMakeupDate;

        public  object  TheoryTeacherID;
        public object SkillTeacherID ;
        public  object SupervisorID;
        public object IssueQCTeacherID ;
        public object ArchiveTeacherID ;

        public DateTime VisualTestDate;
        public DateTime BendTestDate;
        public DateTime RTTestDate;
        public DateTime IssueIssuedOn;
        public  string SupervisionPlace ;
        public int PeriodofValidity;

        public string  IssueRemark;
    #endregion

        public Class_Issue()
        {
        }

        public Class_Issue(string IssueNo)
        {
            this.IssueNo = IssueNo;
            this.FillData();
            
        }

        public static void LockOut(string IssueNo, bool bool_LockOut)
        {
            Class_Issue myClass_Issue = new Class_Issue(IssueNo);
            if (bool_LockOut)
            {
                if (myClass_Issue.IssueStatus <= 2147483647)
                {
                    myClass_Issue.IssueStatus = (uint)(myClass_Issue.IssueStatus + 2147483648);
                    myClass_Issue.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
            else
            {
                if (myClass_Issue.IssueStatus > 2147483647)
                {
                    myClass_Issue.IssueStatus = (uint)(myClass_Issue.IssueStatus - 2147483648);
                    myClass_Issue.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
        }

        public static bool CheckFinished(string IssueNo)
        {
            Class_Issue myClass_Issue = new Class_Issue(IssueNo);
            if (myClass_Issue.IssueStatus > 2147483647)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataTable GetDataTable_WelderStudentQC(string str_IssueNo, string str_Filter, string str_Sort)
        {
            string str_SQL = string.Format("Select * From View_Union_Exam_WelderIssueStudentQCRegistrationNo Where IssueNo='{0}'", str_IssueNo);
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

        public static DataTable GetDataTable_SubjectPositionResult(string str_IssueNo, string str_Filter, string str_Sort)
        {
            string str_SQL = string.Format("Select * From View_Union_Exam_SubjectPositionResultRegistrationNo Where IssueNo='{0}'", str_IssueNo);
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

        public static void ExportSkillExamNeed(DataView myDataView_Temp)
        {
            myDataView_Temp.RowFilter = "ExamStatus = '顺利考试' and ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and (SkillResultNeed=true and (SkillResult=false and SkillMakeupResult=false))";
            myDataView_Temp.Sort = "IssueNo, ExaminingNo";

            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;
            int int_Index = 1;
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).ColumnWidth = 5;
            myExcelSheet.get_Range("B1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("C1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("D1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("E1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("F1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("G1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("H1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("I1", System.Reflection.Missing.Value).ColumnWidth = 18;

            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).RowHeight = 40;
            myExcelSheet.Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myExcelSheet.get_Range("A1", "I1").HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myExcelSheet.get_Range("A1", "I1").VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myExcelSheet.get_Range("A1", "I1").Merge(System.Reflection.Missing.Value);
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Font.Name = "黑体";
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Font.Size = 22;
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Value2 = "补考名单";
            int_Index = 2;
            myExcelSheet.get_Range("A" + int_Index, "I" + int_Index).Font.Name = "黑体";
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "序号";
            myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = "部门";
            myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "姓名";
            myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = "期数";
            myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = "焊接方法";
            myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = "考编号";
            myExcelSheet.get_Range("G" + int_Index, System.Reflection.Missing.Value).Value2 = "等级";
            myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = "项目";
            myExcelSheet.get_Range("I" + int_Index, System.Reflection.Missing.Value).Value2 = "备注";

            Class_Issue myClass_Issue=new Class_Issue();
            DataTable myDataTable_Temp=new DataTable() ;
            string str_WeldingPosition;
            string str_Flaw;
            
            foreach (DataRowView myDataRowView in myDataView_Temp)
            {
                if (myClass_Issue.IssueNo != myDataRowView["IssueNo"].ToString())
                {
                    myClass_Issue.IssueNo = myDataRowView["IssueNo"].ToString();
                    myDataTable_Temp = Class_Issue.GetDataTable_SubjectPositionResult(myClass_Issue.IssueNo,null,"ExaminingNo, WeldingPosition");
                    myClass_Issue.FillData();
                }

                int_Index++;
                str_WeldingPosition = "";
                str_Flaw = "";
                myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = int_Index - 2;
                myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WelderDepartment"].ToString();
                myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WelderName"].ToString();
                myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = myClass_Issue.IssueNo; ;
                myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = myClass_Issue.WeldingProcessAb;
                myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["ExaminingNo"].ToString();
                myExcelSheet.get_Range("G" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WeldingClass"].ToString();
                foreach (DataRow myDataRow in myDataTable_Temp.Select(string.Format("ExaminingNo='{0}' And isPassed =0", myDataRowView["ExaminingNo"])))
                {
                    if (!string.IsNullOrEmpty(str_WeldingPosition))
                    {
                        str_WeldingPosition += "、";
                        str_Flaw += "、";
                    }
                    str_WeldingPosition += myDataRow["WeldingPosition"].ToString();
                    str_Flaw += myDataRow["Flaw"].ToString();
                }
                myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = str_WeldingPosition;
                myExcelSheet.get_Range("I" + int_Index, System.Reflection.Missing.Value).Value2 = str_Flaw;

            }
            myRange = myExcelSheet.get_Range("A2", "I" + int_Index.ToString());
            myRange.RowHeight = 20;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            if (int_Index > 2)
            {
                myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlDot;
            }
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlDot;
            myRange = myExcelSheet.get_Range("A2", "I2");
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;

            int_Index++;
            int_Index++;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).RowHeight=20;
            myExcelSheet.get_Range("I" + int_Index, System.Reflection.Missing.Value).Value2 = DateTime.Today.ToShortDateString();
            myExcelSheet.get_Range("I" + int_Index, System.Reflection.Missing.Value).Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;

            myExcelApp.Application.Visible = true;
        }

        public static void UpdateIssueStatus(string IssueNo)
        {
            string str_SQL;
            SqlCommand myCmd_Temp;
            SqlCommand myCmd_Update = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Update.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20);
            myCmd_Update.Parameters.Add("@IssueStatus", SqlDbType.Int);
            if (string.IsNullOrEmpty(IssueNo))
            {
                str_SQL = "Select * From [Exam_Issue]";
                myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            }
            else
            {
                str_SQL = "Select * From [Exam_Issue] Where IssueNo=@IssueNo";
                myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
            }
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            myAdapter.SelectCommand = myCmd_Temp;
            DataTable myDataTable = new DataTable();
            myAdapter.Fill(myDataTable);
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                myCmd_Update.CommandText = "UPDATE [dbo].[Exam_Issue] SET [IssueStatus] = @IssueStatus WHERE [IssueNo] = @IssueNo";
                myCmd_Update.Parameters["@IssueNo"].Value = myDataRow["IssueNo"].ToString();
                myCmd_Update.Parameters["@IssueStatus"].Value = (int)Class_DataValidateTool.ConvertintTouint((int)myDataRow["IssueStatus"]);
                myCmd_Update.ExecuteNonQuery();
            }
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Exam_Issue] Where IssueNo=@IssueNo";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL,Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = this.IssueNo;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp=myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.myClass_WeldingParameter.FillData (myReader_Temp, "Issue");

                this.WeldingProcessAb = myReader_Temp["WeldingProcessAb"].ToString();
                this.ShipClassificationAb = myReader_Temp["ShipClassificationAb"].ToString();
                this.ShipboardNo = myReader_Temp["ShipboardNo"].ToString();
                this.EmployerHPID = myReader_Temp["IssueEmployerHPID"].ToString();
                //this.IssueStatus = Class_DataValidateTool.ConvertintTouint((int)myReader_Temp["IssueStatus"]);
                this.IssueStatus = (uint)(int)myReader_Temp["IssueStatus"];
                this.KindofEmployer = myReader_Temp["KindofEmployer"].ToString();
                this.IssueRemark = myReader_Temp["IssueRemark"].ToString();
                this.TheoryTeacherID = myReader_Temp["TheoryTeacherID"];
                this.SkillTeacherID = myReader_Temp["SkillTeacherID"];
                this.SupervisorID = myReader_Temp["SupervisorID"];
                this.IssueQCTeacherID = myReader_Temp["IssueQCTeacherID"];
               this.ArchiveTeacherID = myReader_Temp["ArchiveTeacherID"];
               this.SignUpDate = DateTime.Parse(myReader_Temp["SignUpDate"].ToString());
               this.PlaceofTest = myReader_Temp["PlaceofTest"].ToString();
                if  (myReader_Temp["TheoryExamDate"]!=DBNull.Value ) 
                {
                    this.TheoryExamDate = DateTime.Parse (myReader_Temp["TheoryExamDate"].ToString());
                }
                else
                {
                    this.TheoryExamDate = DateTime.MinValue ;
                }
                if (myReader_Temp["SkillExamDate"] != DBNull.Value) 
                {
                    this.SkillExamDate = DateTime.Parse (myReader_Temp["SkillExamDate"].ToString());
                }
                else
                {
                    this.SkillExamDate = DateTime.MinValue ;
                }
                if (myReader_Temp["TheoryMakeupDate"] != DBNull.Value) 
                {
                    this.TheoryMakeupDate = DateTime.Parse (myReader_Temp["TheoryMakeupDate"].ToString());
                }
                else
                {
                    this.TheoryMakeupDate = DateTime.MinValue ;
                }
                if (myReader_Temp["SkillMakeupDate"] != DBNull.Value) 
                {
                    this.SkillMakeupDate = DateTime.Parse (myReader_Temp["SkillMakeupDate"].ToString());
                }
                else
                {
                    this.SkillMakeupDate = DateTime.MinValue ;
                }
                if (myReader_Temp["DateBeginningofTrain"] != DBNull.Value) 
                {
                    this.DateBeginningofTrain = DateTime.Parse (myReader_Temp["DateBeginningofTrain"].ToString());
                }
                else
                {
                    this.DateBeginningofTrain = DateTime.MinValue ;
                }
                if (myReader_Temp["DateEndingofTrain"] != DBNull.Value) 
                {
                    this.DateEndingofTrain = DateTime.Parse (myReader_Temp["DateEndingofTrain"].ToString());
                }
                else
                {
                    this.DateEndingofTrain = DateTime.MinValue ;
                }
                if (myReader_Temp["VisualTestDate"] != DBNull.Value) 
                {
                    this.VisualTestDate = DateTime.Parse (myReader_Temp["VisualTestDate"].ToString());
                }
                else
                {
                    this.VisualTestDate = DateTime.MinValue ;
                }
                if (myReader_Temp["BendTestDate"] != DBNull.Value) 
                {
                    this.BendTestDate = DateTime.Parse (myReader_Temp["BendTestDate"].ToString());
                }
                else
                {
                    this.BendTestDate = DateTime.MinValue ;
                }
                if (myReader_Temp["RTTestDate"] != DBNull.Value) 
                {
                    this.RTTestDate = DateTime.Parse (myReader_Temp["RTTestDate"].ToString());
                }
                else
                {
                    this.RTTestDate = DateTime.MinValue ;
                }
                if (myReader_Temp["IssueIssuedOn"] != DBNull.Value) 
                {
                    this.IssueIssuedOn = DateTime.Parse(myReader_Temp["IssueIssuedOn"].ToString());
                }
                else
                {
                    this.IssueIssuedOn = DateTime.MinValue ;
                }
                this.SupervisionPlace = myReader_Temp["IssueSupervisionPlace"].ToString();
                //int.TryParse (myReader_Temp["IssuePeriodofValidity"].ToString(), out this.PeriodofValidity);
                if (myReader_Temp["IssuePeriodofValidity"] != DBNull.Value)
                {
                    this.PeriodofValidity =(int) myReader_Temp["IssuePeriodofValidity"];
                }
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
            //myParameters.Add("@IssueStatus", SqlDbType.Int).Value = Class_DataValidateTool.CouvertuintToint(this.IssueStatus);
            myParameters.Add("@IssueStatus", SqlDbType.Int).Value = (int)this.IssueStatus;
            myParameters.Add("@WeldingProcessAb", SqlDbType.NVarChar, 10).Value = this.WeldingProcessAb;
            myParameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = this.ShipClassificationAb;
            myParameters.Add("@ShipboardNo", SqlDbType.NVarChar, 10).Value = this.ShipboardNo;
            myParameters.Add("@PlaceofTest", SqlDbType.NVarChar, 50).Value = this.PlaceofTest;
            myParameters.Add("@SignUpDate", SqlDbType.DateTime).Value = this.SignUpDate;
            myParameters.Add("@IssueEmployerHPID", SqlDbType.NChar, 4).Value = this.EmployerHPID;
            myParameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = this.KindofEmployer;
            if ( this.TheoryExamDate != DateTime.MinValue ) 
            {
                myParameters.Add("@TheoryExamDate", SqlDbType.DateTime).Value = this.TheoryExamDate;
            }
            if ( this.SkillExamDate != DateTime.MinValue ) 
            {
                myParameters.Add("@SkillExamDate", SqlDbType.DateTime).Value = this.SkillExamDate;
            }
            if ( this.TheoryMakeupDate != DateTime.MinValue ) 
            {
                myParameters.Add("@TheoryMakeupDate", SqlDbType.DateTime).Value = this.TheoryMakeupDate;
            }
            if ( this.SkillMakeupDate != DateTime.MinValue ) 
            {
                myParameters.Add("@SkillMakeupDate", SqlDbType.DateTime).Value = this.SkillMakeupDate;
            }
            if ( this.DateBeginningofTrain != DateTime.MinValue ) 
            {
                myParameters.Add("@DateBeginningofTrain", SqlDbType.DateTime).Value = this.DateBeginningofTrain;
            }
            if ( this.DateEndingofTrain != DateTime.MinValue ) 
            {
                myParameters.Add("@DateEndingofTrain", SqlDbType.DateTime).Value = this.DateEndingofTrain;
            }
            if ( this.VisualTestDate != DateTime.MinValue ) 
            {
                myParameters.Add("@VisualTestDate", SqlDbType.DateTime).Value = this.VisualTestDate;
            }
            if ( this.BendTestDate != DateTime.MinValue ) 
            {
                myParameters.Add("@BendTestDate", SqlDbType.DateTime).Value = this.BendTestDate;
            }
            if ( this.RTTestDate != DateTime.MinValue ) 
            {
                myParameters.Add("@RTTestDate", SqlDbType.DateTime).Value = this.RTTestDate;
            }
            if ( this.IssueIssuedOn != DateTime.MinValue ) 
            {
                myParameters.Add("@IssueIssuedOn", SqlDbType.DateTime).Value = this.IssueIssuedOn;
            }
            myParameters.Add("@TheoryTeacherID", SqlDbType.UniqueIdentifier ).Value = this.TheoryTeacherID;
            myParameters.Add("@SkillTeacherID", SqlDbType.UniqueIdentifier ).Value = this.SkillTeacherID;
            myParameters.Add("@SupervisorID", SqlDbType.UniqueIdentifier ).Value = this.SupervisorID;
            myParameters.Add("@IssueQCTeacherID", SqlDbType.UniqueIdentifier ).Value = this.IssueQCTeacherID;
            myParameters.Add("@ArchiveTeacherID", SqlDbType.UniqueIdentifier ).Value = this.ArchiveTeacherID;
            myParameters.Add("@IssueSupervisionPlace", SqlDbType.NVarChar, 10).Value = this.SupervisionPlace;
            myParameters.Add("@IssuePeriodofValidity", SqlDbType.Int).Value = this.PeriodofValidity;
            myParameters.Add("@IssueRemark", SqlDbType.NVarChar, 255).Value = this.IssueRemark;
            myParameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Direction= ParameterDirection.InputOutput;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@IssueNo"].Value = this.IssueNo;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string IssueNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
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
            myCmd_Temp.CommandText = "Exam_Issue_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.IssueNo = myCmd_Temp.Parameters["@IssueNo"].Value.ToString();
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_Issue", this.IssueNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return !string.IsNullOrEmpty(this.IssueNo);

        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string IssueNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_Issue", string.Format("{0}", IssueNo), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_Issue_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Issue.ParametersAdd(myCmd_Temp.Parameters, IssueNo, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.EmployerHPID))
            {
                return "公司编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.KindofEmployer))
            {
                return "报考单位不能为空！";
            }
            else if (string.IsNullOrEmpty(this.PlaceofTest))
            {
                return "考试地点不能为空！";
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

        static public string CheckExamStatus(string IssueNo, uint IssueStatus)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_Issue_CheckExamStatus";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
            myCmd_Temp.Parameters.Add("@IssueStatus", SqlDbType.Int).Value = (int)IssueStatus;
            myCmd_Temp.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return myCmd_Temp.Parameters["@ReturnMessage"].Value.ToString();

        }

        static public void UpdateTheoryResult(string IssueNo)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_Issue_UpdateTheoryResult";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters .Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
        }
        
    }

    public  class Class_Student
    {
#region "Fields"
    public Class_WeldingParameter myClass_WeldingParameter =new Class_WeldingParameter();

    public string ExaminingNo;
    public string IdentificationCard;
    public string IssueNo;
    public string SubjectID;
    public string ExamSubjectCode;
    public string ExamStatus;
    public int  TheoryResult;
    public int TheoryMakeupResult ;
    public bool  SkillResult ;
    public bool SkillMakeupResult ;
    public bool StudentMarked ;
    public string WPSNo;
    public string StudentRemark;

    public bool isPassed
    {
        get
        {
            Class_KindofExam myClass_KindofExam = new Class_KindofExam(this.myClass_WeldingParameter.KindofExam);
            if (myClass_KindofExam.TheoryResultNeed && this.TheoryResult < myClass_KindofExam.PassScore && this.TheoryMakeupResult < myClass_KindofExam.PassScore)
            {
                return false;
            }
            if (myClass_KindofExam.SkillResultNeed && !this.SkillResult && !this.SkillMakeupResult)
            {
                return false;
            }
            return true;

        }
    }
    static public string str_Filter;
    static private SqlDataAdapter _myAdapter;
    static public SqlDataAdapter myAdapter
    {
        get
        {
            string str_SQL;
            if (string.IsNullOrEmpty(Class_Student.str_Filter))
            {
                str_SQL = "SELECT * From [View_Exam_WelderIssueStudentQC]";
            }
            else
            {
                str_SQL = "SELECT * From [View_Exam_WelderIssueStudentQC] Where " + Class_Student.str_Filter;
            }
            _myAdapter = new SqlDataAdapter(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);

            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_Student_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20, "IssueNo");
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18, "IdentificationCard");
            myCmd_Temp.Parameters.Add("@ExamSubjectID", SqlDbType.NChar, 4, "ExamSubjectID");
            myCmd_Temp.Parameters.Add("@ExamStatus", SqlDbType.NVarChar, 10, "ExamStatus");
            myCmd_Temp.Parameters.Add("@TheoryResult", SqlDbType.Int, 0, "TheoryResult");
            myCmd_Temp.Parameters.Add("@TheoryMakeupResult", SqlDbType.Int, 0, "TheoryMakeupResult");
            myCmd_Temp.Parameters.Add("@SkillResult", SqlDbType.Bit, 0, "SkillResult");
            myCmd_Temp.Parameters.Add("@SkillMakeupResult", SqlDbType.Bit, 0, "SkillMakeupResult");
            myCmd_Temp.Parameters.Add("@StudentMarked", SqlDbType.Bit, 0, "StudentMarked");
            myCmd_Temp.Parameters.Add("@StudentRemark", SqlDbType.NVarChar, 255, "StudentRemark");
            myCmd_Temp.Parameters.Add("@WPSNo", SqlDbType.NVarChar, 50, "WPSNo");
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
            myCmd_Temp.Parameters.Add("@StudentMaterial", SqlDbType.NVarChar, 50, "StudentMaterial");
            myCmd_Temp.Parameters.Add("@StudentDimensionofMaterial", SqlDbType.NVarChar, 50, "StudentDimensionofMaterial");
            myCmd_Temp.Parameters.Add("@StudentWeldingConsumable", SqlDbType.NVarChar, 50, "StudentWeldingConsumable");
            myCmd_Temp.Parameters.Add("@StudentThickness", SqlDbType.NVarChar, 20, "StudentThickness");
            myCmd_Temp.Parameters.Add("@StudentExternalDiameter", SqlDbType.NVarChar, 20, "StudentExternalDiameter");
            myCmd_Temp.Parameters.Add("@StudentRenderWeldingRodDiameter", SqlDbType.Real, 0, "StudentRenderWeldingRodDiameter");
            myCmd_Temp.Parameters.Add("@StudentWeldingRodDiameter", SqlDbType.Real, 0, "StudentWeldingRodDiameter");
            myCmd_Temp.Parameters.Add("@StudentCoverWeldingRodDiameter", SqlDbType.Real, 0, "StudentCoverWeldingRodDiameter");
            myCmd_Temp.Parameters.Add("@StudentAssemblage", SqlDbType.NVarChar, 10, "StudentAssemblage");
            myCmd_Temp.Parameters.Add("@StudentKindofExam", SqlDbType.NVarChar, 10, "StudentKindofExam");
            myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
            _myAdapter.InsertCommand = myCmd_Temp;

            myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_Student_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20, "IssueNo");
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18, "IdentificationCard");
            myCmd_Temp.Parameters.Add("@ExamSubjectID", SqlDbType.NChar, 4, "ExamSubjectID");
            myCmd_Temp.Parameters.Add("@ExamStatus", SqlDbType.NVarChar, 10, "ExamStatus");
            myCmd_Temp.Parameters.Add("@TheoryResult", SqlDbType.Int, 0, "TheoryResult");
            myCmd_Temp.Parameters.Add("@TheoryMakeupResult", SqlDbType.Int, 0, "TheoryMakeupResult");
            myCmd_Temp.Parameters.Add("@SkillResult", SqlDbType.Bit, 0, "SkillResult");
            myCmd_Temp.Parameters.Add("@SkillMakeupResult", SqlDbType.Bit, 0, "SkillMakeupResult");
            myCmd_Temp.Parameters.Add("@StudentMarked", SqlDbType.Bit, 0, "StudentMarked");
            myCmd_Temp.Parameters.Add("@StudentRemark", SqlDbType.NVarChar, 255, "StudentRemark");
            myCmd_Temp.Parameters.Add("@WPSNo", SqlDbType.NVarChar, 50, "WPSNo");
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
            myCmd_Temp.Parameters.Add("@StudentMaterial", SqlDbType.NVarChar, 50, "StudentMaterial");
            myCmd_Temp.Parameters.Add("@StudentDimensionofMaterial", SqlDbType.NVarChar, 50, "StudentDimensionofMaterial");
            myCmd_Temp.Parameters.Add("@StudentWeldingConsumable", SqlDbType.NVarChar, 50, "StudentWeldingConsumable");
            myCmd_Temp.Parameters.Add("@StudentThickness", SqlDbType.NVarChar, 20, "StudentThickness");
            myCmd_Temp.Parameters.Add("@StudentExternalDiameter", SqlDbType.NVarChar, 20, "StudentExternalDiameter");
            myCmd_Temp.Parameters.Add("@StudentRenderWeldingRodDiameter", SqlDbType.Real, 0, "StudentRenderWeldingRodDiameter");
            myCmd_Temp.Parameters.Add("@StudentWeldingRodDiameter", SqlDbType.Real, 0, "StudentWeldingRodDiameter");
            myCmd_Temp.Parameters.Add("@StudentCoverWeldingRodDiameter", SqlDbType.Real, 0, "StudentCoverWeldingRodDiameter");
            myCmd_Temp.Parameters.Add("@StudentAssemblage", SqlDbType.NVarChar, 10, "StudentAssemblage");
            myCmd_Temp.Parameters.Add("@StudentKindofExam", SqlDbType.NVarChar, 10, "StudentKindofExam");
            myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
            _myAdapter.UpdateCommand = myCmd_Temp;

            myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_Student_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
            myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            _myAdapter.DeleteCommand = myCmd_Temp;

            return _myAdapter;
        }
    }

    #endregion

        public Class_Student()
        {
        }

        public Class_Student(string str_ExaminingNo)
        {
            this.ExaminingNo = str_ExaminingNo;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Exam_Student] Where ExaminingNo=@ExaminingNo";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL,Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar,20).Value = this.ExaminingNo;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp= myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.myClass_WeldingParameter.FillData(myReader_Temp, "Student");
                this.IssueNo = myReader_Temp["IssueNo"].ToString();
                this.IdentificationCard = myReader_Temp["IdentificationCard"].ToString();
                this.ExamStatus = myReader_Temp["ExamStatus"].ToString();
                this.ExamSubjectCode = myReader_Temp["ExamSubjectCode"].ToString();
                int.TryParse(myReader_Temp["TheoryResult"].ToString(), out this.TheoryResult);
                int.TryParse(myReader_Temp["TheoryMakeupResult"].ToString(), out this.TheoryMakeupResult);
                this.SubjectID = myReader_Temp["ExamSubjectID"].ToString();
                this.SkillResult = (bool)myReader_Temp["SkillResult"];
                this.SkillMakeupResult = (bool)myReader_Temp["SkillMakeupResult"];
                this.StudentMarked = (bool)myReader_Temp["StudentMarked"];
                this.WPSNo = myReader_Temp["WPSNo"].ToString();
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
            this.myClass_WeldingParameter.ParametersAdd(myParameters, "Student");
            myParameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = this.IssueNo;
            myParameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = this.IdentificationCard;
            myParameters.Add("@ExamSubjectID", SqlDbType.NChar, 4).Value = this.SubjectID;
            myParameters.Add("@ExamStatus", SqlDbType.NVarChar, 10).Value = this.ExamStatus;
            if (this.TheoryResult > 0)
            {
                myParameters.Add("@TheoryResult", SqlDbType.Int).Value = this.TheoryResult;
            }
            if (this.TheoryMakeupResult > 0)
            {
                myParameters.Add("@TheoryMakeupResult", SqlDbType.Int).Value = this.TheoryMakeupResult;
            }
            myParameters.Add("@SkillResult", SqlDbType.Bit).Value = this.SkillResult;
            myParameters.Add("@SkillMakeupResult", SqlDbType.Bit).Value = this.SkillMakeupResult;
            myParameters.Add("@StudentMarked", SqlDbType.Bit).Value = this.StudentMarked;
            myParameters.Add("@WPSNo", SqlDbType.NVarChar, 50).Value = this.WPSNo;
            myParameters.Add("@StudentRemark", SqlDbType.NVarChar, 255).Value = this.StudentRemark;
            myParameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Direction = ParameterDirection.InputOutput;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@ExaminingNo"].Value = this.ExaminingNo;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string ExaminingNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = ExaminingNo;
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
            myCmd_Temp.CommandText = "Exam_Student_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.ExaminingNo = myCmd_Temp.Parameters["@ExaminingNo"].Value.ToString();
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_Student", this.ExaminingNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return !string.IsNullOrEmpty(this.ExaminingNo);
        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string ExaminingNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_Student", ExaminingNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_Student_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_Student.ParametersAdd(myCmd_Temp.Parameters, ExaminingNo, myEnum_zwjKindofUpdate);
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
 
        static public bool ExistSecond(string IssueNo, string IdentificationCard, string ExaminingNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_Student_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = ExaminingNo;
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
            if (string.IsNullOrEmpty(this.IssueNo))
            {
                return "期数编号不能为空！";
            }
            //else if (string.IsNullOrEmpty(this.ExamStatus))
            //{
            //    return "考试状态不能为空！";
            //}
            else if (string.IsNullOrEmpty(this.IdentificationCard ))
            {
                return "身份证号码不能为空！";
            }
            else if (!Class_WeldingSubject.ExistAndCanDeleteAndDelete( this.SubjectID , Enum_zwjKindofUpdate.Exist))
            {
                return "考试科目编号有误！";
            }
            string str_ReturnMessage;
            if (Class_Student.ExistAndCanDeleteAndDelete(this.ExaminingNo, Enum_zwjKindofUpdate.Exist))
            {
                Class_Student myClass_Student = new Class_Student(this.ExaminingNo);
                if (this.IdentificationCard != myClass_Student.IdentificationCard)
                {
                    Class_Issue myClass_Issue = new Class_Issue(this.IssueNo);
                    str_ReturnMessage = Class_Welder.CanSignUp(this.IdentificationCard, myClass_Issue.WeldingProcessAb, this.SubjectID, myClass_Issue.ShipClassificationAb, myClass_Issue.ShipboardNo, this.myClass_WeldingParameter.Material, this.myClass_WeldingParameter.WeldingConsumable, this.myClass_WeldingParameter.Thickness, this.myClass_WeldingParameter.ExternalDiameter , false);
                    if (!string.IsNullOrEmpty(str_ReturnMessage))
                    {
                        return str_ReturnMessage;
                    }            
                }
            }
            else
            {
                Class_Issue myClass_Issue = new Class_Issue(this.IssueNo);
                str_ReturnMessage = Class_Welder.CanSignUp(this.IdentificationCard, myClass_Issue.WeldingProcessAb, this.SubjectID, myClass_Issue.ShipClassificationAb, myClass_Issue.ShipboardNo, this.myClass_WeldingParameter.Material, this.myClass_WeldingParameter.WeldingConsumable, this.myClass_WeldingParameter.Thickness, this.myClass_WeldingParameter.ExternalDiameter, false);
                if (!string.IsNullOrEmpty(str_ReturnMessage))
                {
                    return str_ReturnMessage;
                }
            }

            str_ReturnMessage = this.myClass_WeldingParameter.CheckField();
            if (!string.IsNullOrEmpty(str_ReturnMessage))
            {
                return str_ReturnMessage;
            }
            if (Properties.Settings.Default.WebServiceStartUp)
            {
                if (!Class_Welder.ExistWelderPicture(this.IdentificationCard))
                {
                    return "该焊工没有电子照片！";
                }
            }

            return null;

        }

        public static DataTable GetDataTable_SubjectPositionResult(string str_ExaminingNo, string str_Filter, string str_Sort)
        {
            string str_SQL = string.Format("Select * From View_Exam_SubjectPositionResult Where ExaminingNo='{0}'", str_ExaminingNo);
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


        static public string GetScopeofCCSThickness(double dbl_Thickness)
        {
            string str_ScopeofCCSThickness;
            if (dbl_Thickness <= 3)
            {
                str_ScopeofCCSThickness = dbl_Thickness.ToString() + "≤t≤" + (2 * dbl_Thickness).ToString();
            }
            else if (dbl_Thickness <= 20)
            {
                str_ScopeofCCSThickness = "3<t≤" + (2 * dbl_Thickness).ToString();
            }
            else
            {
                str_ScopeofCCSThickness = "t>3";
            }
            return str_ScopeofCCSThickness;

        }

        static public string GetAlScopeofCCSThickness(double dbl_Thickness)
        {
            string str_AlScopeofCCSThickness;
            if (dbl_Thickness <= 6)
            {
                str_AlScopeofCCSThickness = (dbl_Thickness / 2).ToString() + "≤t≤" + (2 * dbl_Thickness).ToString();
            }
            else
            {
                str_AlScopeofCCSThickness = "t≥6";
            }
            return str_AlScopeofCCSThickness;

        }

        static public string GetCuScopeofCCSThickness(double dbl_Thickness)
        {
            string str_CuScopeofCCSThickness;
            str_CuScopeofCCSThickness = (dbl_Thickness / 2).ToString() + "≤t≤" + (1.5 * dbl_Thickness).ToString();
            return str_CuScopeofCCSThickness;

        }

        static public string GetScopeofCCSExternalDiameter(double dbl_ExternalDiameter)
        {
            string str_AlScopeofCCSExternalDiameter;
            if (dbl_ExternalDiameter <= 25)
            {
                str_AlScopeofCCSExternalDiameter = dbl_ExternalDiameter.ToString() + "≤d≤" + (2 * dbl_ExternalDiameter).ToString();
            }
            else
            {
                if (dbl_ExternalDiameter / 2 >= 25)
                {
                    str_AlScopeofCCSExternalDiameter = "d≥" + (dbl_ExternalDiameter / 2).ToString();
                }
                else
                {
                    str_AlScopeofCCSExternalDiameter = "d≥25";
                }
            }
            return str_AlScopeofCCSExternalDiameter;
        }

        static public string GetScopeofISOThickness(double dbl_Thickness)
        {
            string str_ScopeofISOThickness;
            if (dbl_Thickness <= 3)
            {
                str_ScopeofISOThickness = string.Format("{0}≤t≤{1}", dbl_Thickness, 2 * dbl_Thickness);
            }
            else if (dbl_Thickness <= 12)
            {
                str_ScopeofISOThickness = string.Format("3≤t≤{0}", 2 * dbl_Thickness);
            }
            else
            {
                str_ScopeofISOThickness = "t≥5";
            }
            return str_ScopeofISOThickness;
        }

        static public string GetScopeofISOExternalDiameter(double dbl_ExternalDiameter)
        {
            string str_ScopeofISOExternalDiameter;
            if (dbl_ExternalDiameter <= 25)
            {
                str_ScopeofISOExternalDiameter = string.Format("{0}≤d≤{1}", dbl_ExternalDiameter, 2 * dbl_ExternalDiameter);
            }
            else if (dbl_ExternalDiameter <= 150)
            {
                if (dbl_ExternalDiameter / 2 >= 25)
                {
                    str_ScopeofISOExternalDiameter = string.Format("{0}≤d≤{1}", dbl_ExternalDiameter / 2, 2 * dbl_ExternalDiameter);
                }
                else
                {
                    str_ScopeofISOExternalDiameter = string.Format("25≤d≤{0}", 2 * dbl_ExternalDiameter);
                }
            }
            else
            {
                str_ScopeofISOExternalDiameter = string.Format("d>{0}", dbl_ExternalDiameter / 2);
            }
            return str_ScopeofISOExternalDiameter;
        }

    }

    public  class Class_QC
    {
        #region "Fields"
        public string ExaminingNo;
        public string QCSubjectID;
        public bool isQCValid = true;
        public string CertificateNo;
        public DateTime IssuedOn;
        public DateTime ValidUntil;
        public int PeriodofValidity;
        public int OriginalPeriod;
        public int PeriodofProlongation;
        public string SupervisionPlace;
        public int SupervisionCycle;
        public bool SupervisionFirst;
        public bool SupervisionSecond;
        public bool SupervisionThird;
        public bool SupervisionFourth;
        public bool SupervisionFifth;
        public bool SupervisionSixth;
        public bool SupervisionSeventh;
        public bool SupervisionEighth;
        public string QCRemark;

        static public string str_Filter;
        static private SqlDataAdapter _myAdapter;
        static public SqlDataAdapter myAdapter
        {
            get
            {
                string str_SQL;
                if (string.IsNullOrEmpty(str_Filter))
                {
                    str_SQL = "SELECT * From [Exam_QC]";
                }
                else
                {
                    str_SQL = "SELECT * From [Exam_QC] Where " + str_Filter;
                }
                _myAdapter = new SqlDataAdapter(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);

                SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.CommandText = "Exam_QC_Update";
                myCmd_Temp.CommandType = CommandType.StoredProcedure;
                myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
                myCmd_Temp.Parameters.Add("@QCSubjectID", SqlDbType.NChar, 4, "QCSubjectID");
                myCmd_Temp.Parameters.Add("@IssuedOn", SqlDbType.DateTime,0, "IssuedOn");
                myCmd_Temp.Parameters.Add("@OriginalPeriod", SqlDbType.Int, 0, "OriginalPeriod");
                myCmd_Temp.Parameters.Add("@PeriodofProlongation", SqlDbType.Int, 0, "PeriodofProlongation");
                myCmd_Temp.Parameters.Add("@SupervisionPlace", SqlDbType.NVarChar, 10, "SupervisionPlace");
                myCmd_Temp.Parameters.Add("@SupervisionCycle", SqlDbType.Int , 0, "SupervisionCycle");
                myCmd_Temp.Parameters.Add("@SupervisionFirst", SqlDbType.Bit, 0, "SupervisionFirst");
                myCmd_Temp.Parameters.Add("@SupervisionSecond", SqlDbType.Bit, 0, "SupervisionSecond");
                myCmd_Temp.Parameters.Add("@SupervisionThird", SqlDbType.Bit, 0, "SupervisionThird");
                myCmd_Temp.Parameters.Add("@SupervisionFourth", SqlDbType.Bit, 0, "SupervisionFourth");
                myCmd_Temp.Parameters.Add("@SupervisionFifth", SqlDbType.Bit, 0, "SupervisionFifth");
                myCmd_Temp.Parameters.Add("@SupervisionSixth", SqlDbType.Bit, 0, "SupervisionSixth");
                myCmd_Temp.Parameters.Add("@SupervisionSeventh", SqlDbType.Bit, 0, "SupervisionSeventh");
                myCmd_Temp.Parameters.Add("@SupervisionEighth", SqlDbType.Bit, 0, "SupervisionEighth");
                myCmd_Temp.Parameters.Add("@isQCValid", SqlDbType.Bit,0,"isQCValid");
                myCmd_Temp.Parameters.Add("@QCRemark", SqlDbType.NVarChar, 255,"QCRemark");
                myCmd_Temp.Parameters.Add("@CertificateNo", SqlDbType.NVarChar, 20,"CertificateNo");
                myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                _myAdapter.InsertCommand = myCmd_Temp;

                myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.CommandText = "Exam_QC_Update";
                myCmd_Temp.CommandType = CommandType.StoredProcedure;
                myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
                myCmd_Temp.Parameters.Add("@QCSubjectID", SqlDbType.NChar, 4, "QCSubjectID");
                myCmd_Temp.Parameters.Add("@IssuedOn", SqlDbType.DateTime, 0, "IssuedOn");
                myCmd_Temp.Parameters.Add("@OriginalPeriod", SqlDbType.Int, 0, "OriginalPeriod");
                myCmd_Temp.Parameters.Add("@PeriodofProlongation", SqlDbType.Int, 0, "PeriodofProlongation");
                myCmd_Temp.Parameters.Add("@SupervisionPlace", SqlDbType.NVarChar, 10, "SupervisionPlace");
                myCmd_Temp.Parameters.Add("@SupervisionCycle", SqlDbType.Int , 0, "SupervisionCycle");
                myCmd_Temp.Parameters.Add("@SupervisionFirst", SqlDbType.Bit, 0, "SupervisionFirst");
                myCmd_Temp.Parameters.Add("@SupervisionSecond", SqlDbType.Bit, 0, "SupervisionSecond");
                myCmd_Temp.Parameters.Add("@SupervisionThird", SqlDbType.Bit, 0, "SupervisionThird");
                myCmd_Temp.Parameters.Add("@SupervisionFourth", SqlDbType.Bit, 0, "SupervisionFourth");
                myCmd_Temp.Parameters.Add("@SupervisionFifth", SqlDbType.Bit, 0, "SupervisionFifth");
                myCmd_Temp.Parameters.Add("@SupervisionSixth", SqlDbType.Bit, 0, "SupervisionSixth");
                myCmd_Temp.Parameters.Add("@SupervisionSeventh", SqlDbType.Bit, 0, "SupervisionSeventh");
                myCmd_Temp.Parameters.Add("@SupervisionEighth", SqlDbType.Bit, 0, "SupervisionEighth");
                myCmd_Temp.Parameters.Add("@isQCValid", SqlDbType.Bit, 0, "isQCValid");
                myCmd_Temp.Parameters.Add("@QCRemark", SqlDbType.NVarChar, 255, "QCRemark");
                myCmd_Temp.Parameters.Add("@CertificateNo", SqlDbType.NVarChar, 20, "CertificateNo");
                myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                _myAdapter.UpdateCommand = myCmd_Temp;

                myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.CommandText = "Exam_QC_Update";
                myCmd_Temp.CommandType = CommandType.StoredProcedure;
                myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
                myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
                _myAdapter.DeleteCommand = myCmd_Temp;

                return _myAdapter;
            }
        }

        #endregion

        public Class_QC()
        {
        }

        public Class_QC(string str_ExaminingNo)
        {
            this.ExaminingNo = str_ExaminingNo;
            this.FillData();
        }
        
        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Exam_QC] Where ExaminingNo=@ExaminingNo";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL,Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar,20).Value = this.ExaminingNo;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp= myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.CertificateNo = myReader_Temp["CertificateNo"].ToString();
                this.QCSubjectID = myReader_Temp["QCSubjectID"].ToString();
                this.IssuedOn =DateTime.Parse( myReader_Temp["IssuedOn"].ToString());
                this.ValidUntil =DateTime.Parse( myReader_Temp["ValidUntil"].ToString());
                this.PeriodofValidity =int.Parse( myReader_Temp["PeriodofValidity"].ToString());
                this.OriginalPeriod =int.Parse( myReader_Temp["OriginalPeriod"].ToString());
                this.PeriodofProlongation =int.Parse( myReader_Temp["PeriodofProlongation"].ToString());
                this.SupervisionPlace = myReader_Temp["SupervisionPlace"].ToString();
                this.QCRemark = myReader_Temp["QCRemark"].ToString();
                this.SupervisionCycle =(int)myReader_Temp["SupervisionCycle"];
                this.SupervisionFirst = bool.Parse(myReader_Temp["SupervisionFirst"].ToString());
                this.SupervisionSecond = bool.Parse(myReader_Temp["SupervisionSecond"].ToString());
                this.SupervisionThird = bool.Parse(myReader_Temp["SupervisionThird"].ToString());
                this.SupervisionFourth = bool.Parse(myReader_Temp["SupervisionFourth"].ToString());
                this.SupervisionFifth   = bool.Parse(myReader_Temp["SupervisionFifth"].ToString());
                this.SupervisionSixth = bool.Parse(myReader_Temp["SupervisionSixth"].ToString());
                this.SupervisionSeventh = bool.Parse(myReader_Temp["SupervisionSeventh"].ToString());
                this.SupervisionEighth = bool.Parse(myReader_Temp["SupervisionEighth"].ToString());
                this.isQCValid = bool.Parse(myReader_Temp["isQCValid"].ToString());
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
            myParameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = this.ExaminingNo;
            myParameters.Add("@QCSubjectID", SqlDbType.NChar, 4).Value = this.QCSubjectID;
            myParameters.Add("@IssuedOn", SqlDbType.DateTime).Value = this.IssuedOn;
            myParameters.Add("@OriginalPeriod", SqlDbType.Int).Value = this.OriginalPeriod;
            myParameters.Add("@PeriodofProlongation", SqlDbType.Int).Value = this.PeriodofProlongation;
            myParameters.Add("@SupervisionPlace", SqlDbType.NVarChar, 10).Value = this.SupervisionPlace;
            myParameters.Add("@SupervisionCycle", SqlDbType.Int ).Value = this.SupervisionCycle;
            myParameters.Add("@SupervisionFirst", SqlDbType.Bit).Value = this.SupervisionFirst;
            myParameters.Add("@SupervisionSecond", SqlDbType.Bit).Value = this.SupervisionSecond;
            myParameters.Add("@SupervisionThird", SqlDbType.Bit).Value = this.SupervisionThird;
            myParameters.Add("@SupervisionFourth", SqlDbType.Bit).Value = this.SupervisionFourth;
            myParameters.Add("@SupervisionFifth", SqlDbType.Bit).Value = this.SupervisionFifth;
            myParameters.Add("@SupervisionSixth", SqlDbType.Bit).Value = this.SupervisionSixth;
            myParameters.Add("@SupervisionSeventh", SqlDbType.Bit).Value = this.SupervisionSeventh;
            myParameters.Add("@SupervisionEighth", SqlDbType.Bit).Value = this.SupervisionEighth;
            myParameters.Add("@isQCValid", SqlDbType.Bit).Value = this.isQCValid;
            myParameters.Add("@QCRemark", SqlDbType.NVarChar, 255).Value = this.QCRemark;
            myParameters.Add("@CertificateNo", SqlDbType.NVarChar, 20).Value = this.CertificateNo;
            myParameters["@CertificateNo"].Direction = ParameterDirection.InputOutput; ;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    myParameters.Add("@RegistrationNo", SqlDbType.NVarChar, 20).Direction = ParameterDirection.InputOutput;
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
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string ExaminingNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = ExaminingNo;
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
            myCmd_Temp.CommandText = "Exam_QC_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.CertificateNo = myCmd_Temp.Parameters["@CertificateNo"].Value.ToString();
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_QC", this.ExaminingNo + " , " + this.CertificateNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return !string.IsNullOrEmpty(this.CertificateNo);
        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string ExaminingNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_QC", ExaminingNo , Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_QC_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_QC.ParametersAdd(myCmd_Temp.Parameters, ExaminingNo, myEnum_zwjKindofUpdate);
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

        static public bool ExistSecond(string CertificateNo, string ExaminingNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_QC_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@CertificateNo", SqlDbType.NVarChar, 20).Value = CertificateNo;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = ExaminingNo;
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

        static public void Overdue(string ExaminingNo)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_QC_Overdue";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = ExaminingNo;
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
            if (string.IsNullOrEmpty(this.ExaminingNo))
            {
                return "考编号不能为空！";
            }
            else if (this.IssuedOn == DateTime.MinValue )
            {
                return "发证日期不能为空！";
            }
            else if (this.OriginalPeriod <=0)
            {
                return "有效期必须为大于0的整数！";
            }
            else if (string.IsNullOrEmpty(this.SupervisionPlace  ))
            {
                return "考察地点不能为空！";
            }
            else if (string.IsNullOrEmpty(this.QCSubjectID  ))
            {
                return "合格考试科目不能为空！";
            }
            Class_Student myClass_Student=new Class_Student(this.ExaminingNo);
            Class_Issue myClass_Issue = new Class_Issue(myClass_Student.IssueNo);
            Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myClass_Issue.ShipClassificationAb);
            string str_CertificateNoRegex;
            if (myClass_ShipClassification.ShipRestrict)
            {
                Class_Ship myClass_Ship = new Class_Ship(myClass_Issue.ShipboardNo);
                str_CertificateNoRegex = myClass_Ship.CertificateNoRegex ;
            }
            else
            {
                str_CertificateNoRegex = myClass_ShipClassification.CertificateNoRegex;
            }
            if (!string.IsNullOrEmpty(this.CertificateNo) && !string.IsNullOrEmpty(str_CertificateNoRegex) && !System.Text.RegularExpressions.Regex.IsMatch(this.CertificateNo, str_CertificateNoRegex))
            {
                return "证号格式错误！";
            }

            return null;
        }

        public static void ExportSupervision(DataTable myDataTable)
        {
            DataView myDataView_Temp = new DataView(myDataTable);
            myDataView_Temp.RowFilter = "CertificateNo is not null";
            myDataView_Temp.Sort = "WelderName";

            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;
            int int_Index = 1;
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).ColumnWidth = 5;
            myExcelSheet.get_Range("B1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("C1", System.Reflection.Missing.Value).ColumnWidth = 20;
            myExcelSheet.get_Range("D1", System.Reflection.Missing.Value).ColumnWidth = 12;
            myExcelSheet.get_Range("E1", System.Reflection.Missing.Value).ColumnWidth = 12;
            myExcelSheet.get_Range("F1", System.Reflection.Missing.Value).ColumnWidth = 15;
            myExcelSheet.get_Range("G1", System.Reflection.Missing.Value).ColumnWidth = 10;

            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).RowHeight = 40;
            myExcelSheet.Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myExcelSheet.get_Range("A1", "G1").HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myExcelSheet.get_Range("A1", "G1").VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myExcelSheet.get_Range("A1", "G1").Merge(System.Reflection.Missing.Value);
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Font.Name = "黑体";
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Font.Size = 22;
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).Value2 = "焊工工作业绩表";
            int_Index = 2;
            myExcelSheet.get_Range("A2", System.Reflection.Missing.Value).RowHeight = 20;
            myExcelSheet.Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myExcelSheet.get_Range("A2", "G2").HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myExcelSheet.get_Range("A2", "G2").VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myExcelSheet.get_Range("A2", "G2").Merge(System.Reflection.Missing.Value);
            myExcelSheet.get_Range("A2", System.Reflection.Missing.Value).Value2 = string.Format("({0} - {1})", DateTime.Today.AddMonths( - 5).ToString("yyyy年M月"), DateTime.Today.ToString("yyyy年M月"));
            int_Index = 3;
            myExcelSheet.get_Range("A" + int_Index, "G" + int_Index).Font.Name = "黑体";
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "序号";
            myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = "姓名";
            myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "身份证号码";
            myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = "证书号";
            myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = "考委会号";
            myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = "主要工作内容";
            myExcelSheet.get_Range("G" + int_Index, System.Reflection.Missing.Value).Value2 = "质量状况";


            foreach (DataRowView myDataRowView in myDataView_Temp)
            {
                int_Index++;
                myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = int_Index - 3;
                myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WelderName"].ToString();
                myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 =string.Format("'{0}", myDataRowView["IdentificationCard"]);
                myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["CertificateNo"].ToString(); ;
                myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["RegistrationNo"].ToString();
            }
            myRange = myExcelSheet.get_Range("A3", "G" + int_Index.ToString());
            myRange.RowHeight = 20;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            if (int_Index > 3)
            {
                myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlDot;
            }
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlDot;
            myRange = myExcelSheet.get_Range("A3", "G3" );
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;

            int_Index++;
            int_Index++;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).RowHeight = 20;
            myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = "填表人：";
            myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;  
            myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = "部门公章";
            myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = "填表日期：";
            myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;  
            myExcelSheet.get_Range("G" + int_Index, System.Reflection.Missing.Value).Value2 = DateTime.Today.ToShortDateString();


            myExcelApp.Application.Visible = true;
        }
    }

    public class Class_IssueProcess
    {
        #region "Fields"
        public int IssueProcessID;
        public string IssueNo;
        public object IssueProcessPrincipal;
        public string IssueProcessStatus;
        public DateTime IssueProcessBeginDate;
        public DateTime IssueProcessEndDate;
        public string IssueProcessRemark;
        public bool IssueProcessFinished;
        /// <summary>
        /// Issue 或者 GXTheoryIssue
        /// </summary>
        public bool GXTheory = false ;
        #endregion

        public Class_IssueProcess()
        {
            IssueProcessBeginDate = new DateTime();
            IssueProcessEndDate = new DateTime();

        }

        public Class_IssueProcess(int IssueProcessID)
        {
            this.IssueProcessID = IssueProcessID;
            this.FillData();

        }

        public bool FillData()
        {
            string str_SQL;
            if (this.GXTheory)
            {
                str_SQL = "SELECT * FROM [dbo].[Exam_GXTheoryIssueProcess] Where [IssueProcessID]=@IssueProcessID";
           }
            else
            {
           str_SQL = "SELECT * FROM [dbo].[Exam_IssueProcess] Where [IssueProcessID]=@IssueProcessID";
            }
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.Parameters.Add("@IssueProcessID", SqlDbType.Int).Value = this.IssueProcessID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                myReader_Temp.Close();
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.IssueProcessBeginDate = (DateTime)myReader_Temp["IssueProcessBeginDate"];
            this.IssueProcessEndDate = (DateTime)myReader_Temp["IssueProcessEndDate"];
            this.IssueNo = myReader_Temp["IssueNo"].ToString();
            this.IssueProcessPrincipal = myReader_Temp["IssueProcessPrincipal"];
            this.IssueProcessFinished = (bool)myReader_Temp["IssueProcessFinished"];
            this.IssueProcessRemark = myReader_Temp["IssueProcessRemark"].ToString();
            this.IssueProcessStatus = myReader_Temp["IssueProcessStatus"].ToString();

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@GXTheory", SqlDbType.Bit ).Value = this.GXTheory;
            
            myParameters.Add("@IssueProcessBeginDate", SqlDbType.DateTime).Value = this.IssueProcessBeginDate;
            myParameters.Add("@IssueProcessEndDate", SqlDbType.DateTime).Value = this.IssueProcessEndDate;
            myParameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = this.IssueNo;
            myParameters.Add("@IssueProcessPrincipal", SqlDbType.UniqueIdentifier).Value = this.IssueProcessPrincipal;
            myParameters.Add("@IssueProcessFinished", SqlDbType.Bit).Value = this.IssueProcessFinished;
            myParameters.Add("@IssueProcessRemark", SqlDbType.NVarChar, 255).Value = this.IssueProcessRemark;
            myParameters.Add("@IssueProcessStatus", SqlDbType.NVarChar, 20).Value = this.IssueProcessStatus;
            myParameters.Add("@IssueProcessID", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            myParameters["@IssueProcessID"].Value = this.IssueProcessID;

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

        static public void ParametersAdd(SqlParameterCollection myParameters, int IssueProcessID, bool GXTheory, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@IssueProcessID", SqlDbType.Int).Value = IssueProcessID;
            myParameters.Add("@GXTheory", SqlDbType.Bit).Value = GXTheory;
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
            myCmd_Temp.CommandText = "Exam_IssueProcess_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.IssueProcessID = (int)myCmd_Temp.Parameters["@IssueProcessID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_IssueProcess", string.Format("{0}:{1}", this.IssueProcessID, this.IssueNo), Class_zwjPublic.myClass_CustomUser.UserGUID, "");

            return true;
        }

        static public bool ExistAndCanDeleteAndDelete(int IssueProcessID, bool GXTheory, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_IssueProcess myClass_IssueProcess = new Class_IssueProcess(IssueProcessID);
            myClass_IssueProcess.GXTheory = GXTheory;
            if (GXTheory)
            {
                Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_GXTheoryIssueProcess", string.Format("{0}:{1}", myClass_IssueProcess.IssueProcessID, myClass_IssueProcess.IssueNo), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            }
            else
            {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_IssueProcess", string.Format("{0}:{1}", myClass_IssueProcess.IssueProcessID, myClass_IssueProcess.IssueNo), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            }

            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_IssueProcess_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_IssueProcess.ParametersAdd(myCmd_Temp.Parameters, IssueProcessID, GXTheory, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.IssueNo))
            {
                return "班级编号不能为空！";
            }
            else if (this.IssueProcessPrincipal == null)
            {
                return "负责人不能为空！";
            }
            else if (string.IsNullOrEmpty(this.IssueProcessStatus))
            {
                return "状态不能为空！";
            }
            else if (this.IssueProcessBeginDate.Date  > this.IssueProcessEndDate.Date )
            {
                return "开始日期不能大于结束日期！";
            }

            return null;
        }

    }
    
    public class Class_GXTheoryIssue
    {
    #region "Fields"
        public string  IssueNo;
        public  string ShipClassificationAb;
        public string   ShipboardNo ;
        public  string EmployerHPID;
        public  string KindofEmployer ;
        public  string WeldingProcessAb ;
        public uint  IssueStatus ;
        public  string PlaceofTest ;
        public string KindofExam ;

        public DateTime  SignUpDate;
        public DateTime DateBeginningofTrain ;
        public DateTime DateEndingofTrain ;
        public DateTime TheoryExamDate ;
        public DateTime TheoryMakeupDate;

        public  object  TheoryTeacherID;
        public object ArchiveTeacherID ;

        public string  IssueRemark;
    #endregion

        public Class_GXTheoryIssue()
        {
        }

        public Class_GXTheoryIssue(string IssueNo)
        {
            this.IssueNo = IssueNo;
            this.FillData();
            
        }

        public static DataTable GetDataTable_WelderStudent(string str_IssueNo, string str_Filter, string str_Sort)
        {
            string str_SQL = string.Format("Select * From View_Exam_GXTheoryWelderStudent Where IssueNo='{0}'", str_IssueNo);
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

        public static void LockOut(string IssueNo, bool bool_LockOut)
        {
            Class_GXTheoryIssue myClass_GXTheoryIssue = new Class_GXTheoryIssue(IssueNo);
            if (bool_LockOut)
            {
                if (myClass_GXTheoryIssue.IssueStatus <= 2147483647)
                {
                    myClass_GXTheoryIssue.IssueStatus = (uint)(myClass_GXTheoryIssue.IssueStatus + 2147483648);
                    myClass_GXTheoryIssue.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
            else
            {
                if (myClass_GXTheoryIssue.IssueStatus > 2147483647)
                {
                    myClass_GXTheoryIssue.IssueStatus = (uint)(myClass_GXTheoryIssue.IssueStatus - 2147483648);
                    myClass_GXTheoryIssue.AddAndModify(Enum_zwjKindofUpdate.Modify);
                }
            }
        }

        public static bool CheckFinished(string IssueNo)
        {
            Class_GXTheoryIssue myClass_GXTheoryIssue = new Class_GXTheoryIssue(IssueNo);
            if (myClass_GXTheoryIssue.IssueStatus > 2147483647)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void UpdateIssueStatus(string IssueNo)
        {
            string str_SQL;
            SqlCommand myCmd_Temp;
            SqlCommand myCmd_Update = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Update.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20);
            myCmd_Update.Parameters.Add("@IssueStatus", SqlDbType.Int);
            if (string.IsNullOrEmpty(IssueNo))
            {
                str_SQL = "Select * From [Exam_GXTheoryIssue]";
                myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            }
            else
            {
                str_SQL = "Select * From [Exam_GXTheoryIssue] Where IssueNo=@IssueNo";
                myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
            }
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            myAdapter.SelectCommand = myCmd_Temp;
            DataTable myDataTable = new DataTable();
            myAdapter.Fill(myDataTable);
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                myCmd_Update.CommandText = "UPDATE [dbo].[Exam_GXTheoryIssue] SET [IssueStatus] = @IssueStatus WHERE [IssueNo] = @IssueNo";
                myCmd_Update.Parameters["@IssueNo"].Value = myDataRow["IssueNo"].ToString();
                myCmd_Update.Parameters["@IssueStatus"].Value = (int)Class_DataValidateTool.ConvertintTouint((int)myDataRow["IssueStatus"]);
                myCmd_Update.ExecuteNonQuery();
            }
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Exam_GXTheoryIssue] Where IssueNo=@IssueNo";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL,Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = this.IssueNo;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp=myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.WeldingProcessAb = myReader_Temp["WeldingProcessAb"].ToString();
                this.ShipClassificationAb = myReader_Temp["ShipClassificationAb"].ToString();
                this.ShipboardNo = myReader_Temp["ShipboardNo"].ToString();
                this.EmployerHPID = myReader_Temp["IssueEmployerHPID"].ToString();
                //this.IssueStatus = Class_DataValidateTool.ConvertintTouint((int)myReader_Temp["IssueStatus"]);
                this.IssueStatus = (uint)(int)myReader_Temp["IssueStatus"];
                this.KindofEmployer = myReader_Temp["KindofEmployer"].ToString();
                this.KindofExam = myReader_Temp["IssueKindofExam"].ToString();
                this.IssueRemark = myReader_Temp["IssueRemark"].ToString();
                this.TheoryTeacherID = myReader_Temp["TheoryTeacherID"];
               this.ArchiveTeacherID = myReader_Temp["ArchiveTeacherID"];
               this.SignUpDate = DateTime.Parse(myReader_Temp["SignUpDate"].ToString());
               this.PlaceofTest = myReader_Temp["PlaceofTest"].ToString();
                if  (myReader_Temp["TheoryExamDate"]!=DBNull.Value ) 
                {
                    this.TheoryExamDate = DateTime.Parse (myReader_Temp["TheoryExamDate"].ToString());
                }
                else
                {
                    this.TheoryExamDate = DateTime.MinValue ;
                }
                if (myReader_Temp["TheoryMakeupDate"] != DBNull.Value) 
                {
                    this.TheoryMakeupDate = DateTime.Parse (myReader_Temp["TheoryMakeupDate"].ToString());
                }
                else
                {
                    this.TheoryMakeupDate = DateTime.MinValue ;
                }
                if (myReader_Temp["DateBeginningofTrain"] != DBNull.Value) 
                {
                    this.DateBeginningofTrain = DateTime.Parse (myReader_Temp["DateBeginningofTrain"].ToString());
                }
                else
                {
                    this.DateBeginningofTrain = DateTime.MinValue ;
                }
                if (myReader_Temp["DateEndingofTrain"] != DBNull.Value) 
                {
                    this.DateEndingofTrain = DateTime.Parse (myReader_Temp["DateEndingofTrain"].ToString());
                }
                else
                {
                    this.DateEndingofTrain = DateTime.MinValue ;
                }
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
            //myParameters.Add("@IssueStatus", SqlDbType.Int).Value = Class_DataValidateTool.CouvertuintToint(this.IssueStatus);
            myParameters.Add("@IssueStatus", SqlDbType.Int).Value =(int)this.IssueStatus;
            myParameters.Add("@WeldingProcessAb", SqlDbType.NVarChar, 10).Value = this.WeldingProcessAb;
            myParameters.Add("@ShipClassificationAb", SqlDbType.NVarChar, 10).Value = this.ShipClassificationAb;
            myParameters.Add("@ShipboardNo", SqlDbType.NVarChar, 10).Value = this.ShipboardNo;
            myParameters.Add("@IssueKindofExam", SqlDbType.NVarChar, 10).Value = this.KindofExam;
            myParameters.Add("@PlaceofTest", SqlDbType.NVarChar, 50).Value = this.PlaceofTest;
            myParameters.Add("@SignUpDate", SqlDbType.DateTime).Value = this.SignUpDate;
            myParameters.Add("@IssueEmployerHPID", SqlDbType.NChar, 4).Value = this.EmployerHPID;
            myParameters.Add("@KindofEmployer", SqlDbType.NVarChar, 20).Value = this.KindofEmployer;
            if ( this.TheoryExamDate != DateTime.MinValue ) 
            {
                myParameters.Add("@TheoryExamDate", SqlDbType.DateTime).Value = this.TheoryExamDate;
            }
            if ( this.TheoryMakeupDate != DateTime.MinValue ) 
            {
                myParameters.Add("@TheoryMakeupDate", SqlDbType.DateTime).Value = this.TheoryMakeupDate;
            }
            if ( this.DateBeginningofTrain != DateTime.MinValue ) 
            {
                myParameters.Add("@DateBeginningofTrain", SqlDbType.DateTime).Value = this.DateBeginningofTrain;
            }
            if ( this.DateEndingofTrain != DateTime.MinValue ) 
            {
                myParameters.Add("@DateEndingofTrain", SqlDbType.DateTime).Value = this.DateEndingofTrain;
            }
            myParameters.Add("@TheoryTeacherID", SqlDbType.UniqueIdentifier ).Value = this.TheoryTeacherID;
            myParameters.Add("@ArchiveTeacherID", SqlDbType.UniqueIdentifier ).Value = this.ArchiveTeacherID;
            myParameters.Add("@IssueRemark", SqlDbType.NVarChar, 255).Value = this.IssueRemark;
            myParameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Direction= ParameterDirection.InputOutput;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@IssueNo"].Value = this.IssueNo;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string IssueNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
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
            myCmd_Temp.CommandText = "Exam_GXTheoryIssue_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.IssueNo = myCmd_Temp.Parameters["@IssueNo"].Value.ToString();
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_GXTheoryIssue", this.IssueNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return !string.IsNullOrEmpty(this.IssueNo);

        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string IssueNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_GXTheoryIssue", IssueNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_GXTheoryIssue_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_GXTheoryIssue.ParametersAdd(myCmd_Temp.Parameters, IssueNo, myEnum_zwjKindofUpdate);
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
            if (string.IsNullOrEmpty(this.EmployerHPID))
            {
                return "公司编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.KindofEmployer))
            {
                return "报考单位不能为空！";
            }
            else if (string.IsNullOrEmpty(this.PlaceofTest))
            {
                return "考试地点不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShipClassificationAb))
            {
                return "船级社不能为空！";
            }
            else if (string.IsNullOrEmpty(this.ShipboardNo ))
            {
                return "船舶系列不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingProcessAb))
            {
                return "焊接方法不能为空！";
            }
            else if (string.IsNullOrEmpty(this.KindofExam ))
            {
                return "考试方法不能为空！";
            }
            return null;
        }
        
        static public string CheckExamStatus(string IssueNo, uint IssueStatus)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_GXTheoryIssue_CheckExamStatus";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
            myCmd_Temp.Parameters.Add("@IssueStatus", SqlDbType.Int).Value = (int)IssueStatus;
            myCmd_Temp.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return myCmd_Temp.Parameters["@ReturnMessage"].Value.ToString();

        }

    }

    public  class Class_GXTheoryStudent
    {
#region "Fields"
    public string ExaminingNo;
    public string IdentificationCard;
    public string SubjectID;
    public string IssueNo;
    public string ExamStatus;
    public string KindofExam;
    public int  TheoryResult;
    public int TheoryMakeupResult ;
    public string StudentRemark;

    static public string str_Filter;
    static private SqlDataAdapter _myAdapter;
    static public SqlDataAdapter myAdapter
    {
        get
        {
            string str_SQL;
            if (string.IsNullOrEmpty(str_Filter))
            {
                str_SQL = "SELECT * From [View_Exam_GXTheoryWelderStudent]";
            }
            else
            {
                str_SQL = "SELECT * From [View_Exam_GXTheoryWelderStudent] Where " + str_Filter;
            }
            _myAdapter = new SqlDataAdapter(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);

            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_GXTheoryStudent_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20, "IssueNo");
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18, "IdentificationCard");
            myCmd_Temp.Parameters.Add("@StudentKindofExam", SqlDbType.NVarChar, 10, "StudentKindofExam");
            myCmd_Temp.Parameters.Add("@ExamSubjectID", SqlDbType.NChar, 4, "ExamSubjectID");
            myCmd_Temp.Parameters.Add("@ExamStatus", SqlDbType.NVarChar, 10, "ExamStatus");
            myCmd_Temp.Parameters.Add("@TheoryResult", SqlDbType.Int, 0, "TheoryResult");
            myCmd_Temp.Parameters.Add("@TheoryMakeupResult", SqlDbType.Int, 0, "TheoryMakeupResult");
            myCmd_Temp.Parameters.Add("@StudentRemark", SqlDbType.NVarChar, 255, "StudentRemark");
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
            myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
            _myAdapter.InsertCommand = myCmd_Temp;

            myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_GXTheoryStudent_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20, "IssueNo");
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18, "IdentificationCard");
            myCmd_Temp.Parameters.Add("@ExamStatus", SqlDbType.NVarChar, 10, "ExamStatus");
            myCmd_Temp.Parameters.Add("@ExamSubjectID", SqlDbType.NChar, 4, "ExamSubjectID");
            myCmd_Temp.Parameters.Add("@TheoryResult", SqlDbType.Int, 0, "TheoryResult");
            myCmd_Temp.Parameters.Add("@TheoryMakeupResult", SqlDbType.Int, 0, "TheoryMakeupResult");
            myCmd_Temp.Parameters.Add("@StudentRemark", SqlDbType.NVarChar, 255, "StudentRemark");
            myCmd_Temp.Parameters.Add("@StudentKindofExam", SqlDbType.NVarChar, 10, "StudentKindofExam");
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
            myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
            _myAdapter.UpdateCommand = myCmd_Temp;

            myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_GXTheoryStudent_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
            myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            _myAdapter.DeleteCommand = myCmd_Temp;

            return _myAdapter;
        }
    }
    #endregion

        public Class_GXTheoryStudent()
        {
        }

        public Class_GXTheoryStudent(string str_ExaminingNo)
        {
        this.ExaminingNo = str_ExaminingNo;
        this.FillData();
        }

                /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Exam_GXTheoryStudent] Where ExaminingNo=@ExaminingNo";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL,Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar,20).Value = this.ExaminingNo;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp= myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.IssueNo = myReader_Temp["IssueNo"].ToString();
                this.IdentificationCard = myReader_Temp["IdentificationCard"].ToString();
                this.ExamStatus = myReader_Temp["ExamStatus"].ToString();
                this.KindofExam = myReader_Temp["StudentKindofExam"].ToString();
                this.SubjectID = myReader_Temp["ExamSubjectID"].ToString();
                int.TryParse(myReader_Temp["TheoryResult"].ToString(), out this.TheoryResult);
                int.TryParse(myReader_Temp["TheoryMakeupResult"].ToString(), out this.TheoryMakeupResult);
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
            myParameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = this.IssueNo;
            myParameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = this.IdentificationCard;
            myParameters.Add("@ExamStatus", SqlDbType.NVarChar, 10).Value = this.ExamStatus;
            myParameters.Add("@StudentKindofExam", SqlDbType.NVarChar, 10).Value = this.KindofExam;
            myParameters.Add("@ExamSubjectID", SqlDbType.NChar, 4).Value = this.SubjectID;
            if (this.TheoryResult > 0)
            {
                myParameters.Add("@TheoryResult", SqlDbType.Int).Value = this.TheoryResult;
            }
            if (this.TheoryMakeupResult > 0)
            {
                myParameters.Add("@TheoryMakeupResult", SqlDbType.Int).Value = this.TheoryMakeupResult;
            }
            myParameters.Add("@StudentRemark", SqlDbType.NVarChar, 255).Value = this.StudentRemark;
            myParameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Direction = ParameterDirection.InputOutput;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@ExaminingNo"].Value = this.ExaminingNo;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string ExaminingNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = ExaminingNo;
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
            myCmd_Temp.CommandText = "Exam_GXTheoryStudent_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.ExaminingNo = myCmd_Temp.Parameters["@ExaminingNo"].Value.ToString();
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_GXTheoryStudent", this.ExaminingNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return !string.IsNullOrEmpty(this.ExaminingNo);
        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string ExaminingNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_GXTheoryStudent", ExaminingNo, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_GXTheoryStudent_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_GXTheoryStudent.ParametersAdd(myCmd_Temp.Parameters, ExaminingNo, myEnum_zwjKindofUpdate);
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

        static public bool ExistSecond(string IssueNo, string IdentificationCard, string ExaminingNo, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_GXTheoryStudent_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
            myCmd_Temp.Parameters.Add("@IdentificationCard", SqlDbType.NChar, 18).Value = IdentificationCard;
            myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = ExaminingNo;
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
            if (string.IsNullOrEmpty(this.IssueNo))
            {
                return "期数编号不能为空！";
            }
            //else if (string.IsNullOrEmpty(this.ExamStatus))
            //{
            //    return "考试状态不能为空！";
            //}
            else if (string.IsNullOrEmpty(this.IdentificationCard ))
            {
                return "身份证号码不能为空！";
            }
            else if (string.IsNullOrEmpty(this.KindofExam  ))
            {
                return "考试方式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.SubjectID))
            {
                return "考试科目编号不能为空！";
            }

            string str_ReturnMessage;
            if (Class_GXTheoryStudent.ExistAndCanDeleteAndDelete(this.ExaminingNo, Enum_zwjKindofUpdate.Exist))
            {
                Class_GXTheoryStudent myClass_Student = new Class_GXTheoryStudent(this.ExaminingNo);
                if (this.IdentificationCard != myClass_Student.IdentificationCard)
                {
                    Class_GXTheoryIssue myClass_Issue = new Class_GXTheoryIssue(this.IssueNo);
                    str_ReturnMessage = Class_Welder.CanSignUp(this.IdentificationCard, myClass_Issue.WeldingProcessAb, null, myClass_Issue.ShipClassificationAb, myClass_Issue.ShipboardNo,null,null,null,null, true);
                    if (!string.IsNullOrEmpty(str_ReturnMessage))
                    {
                        return str_ReturnMessage;
                    }
                }
            }
            else
            {
                Class_GXTheoryIssue myClass_Issue = new Class_GXTheoryIssue(this.IssueNo);
                str_ReturnMessage = Class_Welder.CanSignUp(this.IdentificationCard, myClass_Issue.WeldingProcessAb, null, myClass_Issue.ShipClassificationAb, myClass_Issue.ShipboardNo,null,null,null,null, true);
                if (!string.IsNullOrEmpty(str_ReturnMessage))
                {
                    return str_ReturnMessage;
                }
            }            

            if (Properties.Settings.Default.WebServiceStartUp)
            {
                if (!Class_Welder.ExistWelderPicture(this.IdentificationCard))
                {
                    return "该焊工没有电子照片！";
                }
            }

            return null;
        }

    }

    public class Class_SubjectPositionResult
    {
        /// <summary>
        /// 定义类的字段
        /// </summary>
        #region "Fields"
        public Class_WeldingParameter myClass_WeldingParameter =new Class_WeldingParameter();
        public string ExaminingNo;
        public string WeldingPosition;

        public bool isPassed;
        public bool FaceDT;
        public bool UT;
        public bool RT;
        public bool BendDT;
        public bool DisjunctionDT;
        public bool Impact;
        public bool MacroExamination;
        public bool OtherDT;
        public string Flaw;
        public bool isMakeup;
        public bool MakeupFaceDT;
        public bool MakeupUT;
        public bool MakeupRT;
        public bool MakeupBendDT;
        public bool MakeupDisjunctionDT;
        public bool MakeupImpact;
        public bool MakeupMacroExamination;
        public bool MakeupOtherDT;
        public string MakeupFlaw;

        public string WeldingPositionResultRemark;

        static public string str_Filter;
        static private SqlDataAdapter _myAdapter;
        static public SqlDataAdapter myAdapter
        {
            get
            {
                string str_SQL;
                if (string.IsNullOrEmpty(Class_SubjectPositionResult.str_Filter))
                {
                    str_SQL = "SELECT * From [View_Exam_SubjectPositionResult]";
                }
                else
                {
                    str_SQL = "SELECT * From [View_Exam_SubjectPositionResult] Where " + Class_SubjectPositionResult.str_Filter;
                }
                _myAdapter = new SqlDataAdapter(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);

                SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.CommandText = "Exam_SubjectPositionResult_Update";
                myCmd_Temp.CommandType = CommandType.StoredProcedure;
                myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
                myCmd_Temp.Parameters.Add("@WeldingPosition", SqlDbType.NVarChar, 10, "WeldingPosition");

                myCmd_Temp.Parameters.Add("@isPassed", SqlDbType.Bit,0,"isPassed");
                myCmd_Temp.Parameters.Add("@FaceDT", SqlDbType.Bit,0,"FaceDT");
                myCmd_Temp.Parameters.Add("@UT", SqlDbType.Bit,0,"UT");
                myCmd_Temp.Parameters.Add("@RT", SqlDbType.Bit,0,"RT");
                myCmd_Temp.Parameters.Add("@BendDT", SqlDbType.Bit,0,"BendDT");
                myCmd_Temp.Parameters.Add("@DisjunctionDT", SqlDbType.Bit,0,"DisjunctionDT");
                myCmd_Temp.Parameters.Add("@Impact", SqlDbType.Bit, 0, "Impact");
                myCmd_Temp.Parameters.Add("@MacroExamination", SqlDbType.Bit,0,"MacroExamination");
                myCmd_Temp.Parameters.Add("@OtherDT", SqlDbType.Bit,0,"OtherDT");
                myCmd_Temp.Parameters.Add("@Flaw", SqlDbType.NVarChar, 20,"Flaw");

                myCmd_Temp.Parameters.Add("@isMakeup", SqlDbType.Bit,0,"isMakeup");
                myCmd_Temp.Parameters.Add("@MakeupFaceDT", SqlDbType.Bit,0,"MakeupFaceDT");
                myCmd_Temp.Parameters.Add("@MakeupUT", SqlDbType.Bit,0,"MakeupUT");
                myCmd_Temp.Parameters.Add("@MakeupRT", SqlDbType.Bit,0,"MakeupRT");
                myCmd_Temp.Parameters.Add("@MakeupBendDT", SqlDbType.Bit,0,"MakeupBendDT");
                myCmd_Temp.Parameters.Add("@MakeupDisjunctionDT", SqlDbType.Bit,0,"MakeupDisjunctionDT");
                myCmd_Temp.Parameters.Add("@MakeupImpact", SqlDbType.Bit, 0, "MakeupImpact");
                myCmd_Temp.Parameters.Add("@MakeupMacroExamination", SqlDbType.Bit,0,"MakeupMacroExamination");
                myCmd_Temp.Parameters.Add("@MakeupOtherDT", SqlDbType.Bit,0,"MakeupOtherDT");
                myCmd_Temp.Parameters.Add("@MakeupFlaw", SqlDbType.NVarChar, 20,"MakeupFlaw");

                myCmd_Temp.Parameters.Add("@WeldingPositionResultThickness", SqlDbType.Real  ,0, "WeldingPositionResultThickness");
                myCmd_Temp.Parameters.Add("@WeldingPositionResultExternalDiameter", SqlDbType.Real,0, "WeldingPositionResultExternalDiameter");
                myCmd_Temp.Parameters.Add("@WeldingPositionResultRenderWeldingRodDiameter", SqlDbType.Real, 0, "WeldingPositionResultRenderWeldingRodDiameter");
                myCmd_Temp.Parameters.Add("@WeldingPositionResultWeldingRodDiameter", SqlDbType.Real,0, "WeldingPositionResultWeldingRodDiameter");
                myCmd_Temp.Parameters.Add("@WeldingPositionResultCoverWeldingRodDiameter", SqlDbType.Real,0, "WeldingPositionResultCoverWeldingRodDiameter");
                myCmd_Temp.Parameters.Add("@WeldingPositionResultAssemblage", SqlDbType.NVarChar, 10, "WeldingPositionResultAssemblage");

                myCmd_Temp.Parameters.Add("@WeldingPositionResultRemark", SqlDbType.NVarChar, 255,"WeldingPositionResultRemark");

                myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                _myAdapter.InsertCommand = myCmd_Temp;

                myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.CommandText = "Exam_SubjectPositionResult_Update";
                myCmd_Temp.CommandType = CommandType.StoredProcedure;
                myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
                myCmd_Temp.Parameters.Add("@WeldingPosition", SqlDbType.NVarChar, 10, "WeldingPosition");

                myCmd_Temp.Parameters.Add("@isPassed", SqlDbType.Bit, 0, "isPassed");
                myCmd_Temp.Parameters.Add("@FaceDT", SqlDbType.Bit, 0, "FaceDT");
                myCmd_Temp.Parameters.Add("@UT", SqlDbType.Bit, 0, "UT");
                myCmd_Temp.Parameters.Add("@RT", SqlDbType.Bit, 0, "RT");
                myCmd_Temp.Parameters.Add("@BendDT", SqlDbType.Bit, 0, "BendDT");
                myCmd_Temp.Parameters.Add("@DisjunctionDT", SqlDbType.Bit, 0, "DisjunctionDT");
                myCmd_Temp.Parameters.Add("@MacroExamination", SqlDbType.Bit, 0, "MacroExamination");
                myCmd_Temp.Parameters.Add("@Impact", SqlDbType.Bit, 0, "Impact");
                myCmd_Temp.Parameters.Add("@OtherDT", SqlDbType.Bit, 0, "OtherDT");
                myCmd_Temp.Parameters.Add("@Flaw", SqlDbType.NVarChar, 20, "Flaw");

                myCmd_Temp.Parameters.Add("@isMakeup", SqlDbType.Bit, 0, "isMakeup");
                myCmd_Temp.Parameters.Add("@MakeupFaceDT", SqlDbType.Bit, 0, "MakeupFaceDT");
                myCmd_Temp.Parameters.Add("@MakeupUT", SqlDbType.Bit, 0, "MakeupUT");
                myCmd_Temp.Parameters.Add("@MakeupRT", SqlDbType.Bit, 0, "MakeupRT");
                myCmd_Temp.Parameters.Add("@MakeupBendDT", SqlDbType.Bit, 0, "MakeupBendDT");
                myCmd_Temp.Parameters.Add("@MakeupDisjunctionDT", SqlDbType.Bit, 0, "MakeupDisjunctionDT");
                myCmd_Temp.Parameters.Add("@MakeupImpact", SqlDbType.Bit, 0, "MakeupImpact");
                myCmd_Temp.Parameters.Add("@MakeupMacroExamination", SqlDbType.Bit, 0, "MakeupMacroExamination");
                myCmd_Temp.Parameters.Add("@MakeupOtherDT", SqlDbType.Bit, 0, "MakeupOtherDT");
                myCmd_Temp.Parameters.Add("@MakeupFlaw", SqlDbType.NVarChar, 20, "MakeupFlaw");

                myCmd_Temp.Parameters.Add("@WeldingPositionResultThickness", SqlDbType.Real, 0, "WeldingPositionResultThickness");
                myCmd_Temp.Parameters.Add("@WeldingPositionResultExternalDiameter", SqlDbType.Real, 0, "WeldingPositionResultExternalDiameter");
                myCmd_Temp.Parameters.Add("@WeldingPositionResultRenderWeldingRodDiameter", SqlDbType.Real, 0, "WeldingPositionResultRenderWeldingRodDiameter");
                myCmd_Temp.Parameters.Add("@WeldingPositionResultWeldingRodDiameter", SqlDbType.Real, 0, "WeldingPositionResultWeldingRodDiameter");
                myCmd_Temp.Parameters.Add("@WeldingPositionResultCoverWeldingRodDiameter", SqlDbType.Real, 0, "WeldingPositionResultCoverWeldingRodDiameter");
                myCmd_Temp.Parameters.Add("@WeldingPositionResultAssemblage", SqlDbType.NVarChar, 10, "WeldingPositionResultAssemblage");

                myCmd_Temp.Parameters.Add("@WeldingPositionResultRemark", SqlDbType.NVarChar, 255, "WeldingPositionResultRemark");
                myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                _myAdapter.UpdateCommand = myCmd_Temp;

                myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
                myCmd_Temp.CommandText = "Exam_SubjectPositionResult_Update";
                myCmd_Temp.CommandType = CommandType.StoredProcedure;
                myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20, "ExaminingNo");
                myCmd_Temp.Parameters.Add("@WeldingPosition", SqlDbType.NVarChar, 10, "WeldingPosition");
                myCmd_Temp.Parameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                myCmd_Temp.Parameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
                _myAdapter.DeleteCommand = myCmd_Temp;

                return _myAdapter;
            }
        }

        #endregion

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public Class_SubjectPositionResult()
        {

        }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="SubjectPositionResult"></param>
        public Class_SubjectPositionResult(string ExaminingNo , string WeldingPosition)
        {
            this.ExaminingNo = ExaminingNo;
            this.WeldingPosition = WeldingPosition;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Exam_SubjectPositionResult] Where ExaminingNo=@ExaminingNo and WeldingPosition=@WeldingPosition";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = this.ExaminingNo;
            myCmd_Temp.Parameters.Add("@WeldingPosition", SqlDbType.NVarChar, 10).Value = this.WeldingPosition;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.isPassed = (bool)myReader_Temp["isPassed"];
                this.FaceDT = (bool)myReader_Temp["FaceDT"];
                this.UT = (bool)myReader_Temp["UT"];
                this.RT = (bool)myReader_Temp["RT"];
                this.BendDT = (bool)myReader_Temp["BendDT"];
                this.DisjunctionDT = (bool)myReader_Temp["DisjunctionDT"];
                this.Impact = (bool)myReader_Temp["Impact"];
                this.MacroExamination = (bool)myReader_Temp["MacroExamination"];
                this.OtherDT = (bool)myReader_Temp["OtherDT"];
                this.Flaw = myReader_Temp["Flaw"].ToString();
                this.isMakeup = (bool)myReader_Temp["isMakeup"];
                this.MakeupFaceDT = (bool)myReader_Temp["MakeupFaceDT"];
                this.MakeupUT = (bool)myReader_Temp["MakeupUT"];
                this.MakeupRT = (bool)myReader_Temp["MakeupRT"];
                this.MakeupBendDT = (bool)myReader_Temp["MakeupBendDT"];
                this.MakeupDisjunctionDT = (bool)myReader_Temp["MakeupDisjunctionDT"];
                this.MakeupMacroExamination = (bool)myReader_Temp["MakeupMacroExamination"];
                this.MakeupImpact = (bool)myReader_Temp["MakeupImpact"];
                this.MakeupOtherDT = (bool)myReader_Temp["MakeupDisjunctionDT"];
                this.MakeupFlaw = myReader_Temp["MakeupFlaw"].ToString();
                this.WeldingPositionResultRemark = myReader_Temp["WeldingPositionResultRemark"].ToString();

                string str_Prefixion  = "WeldingPositionResult";
                this.myClass_WeldingParameter.Assemblage = myReader_Temp[str_Prefixion + "Assemblage"].ToString();
                this.myClass_WeldingParameter.RenderWeldingRodDiameter = double.Parse(myReader_Temp[str_Prefixion + "RenderWeldingRodDiameter"].ToString());
                this.myClass_WeldingParameter.WeldingRodDiameter = double.Parse(myReader_Temp[str_Prefixion + "WeldingRodDiameter"].ToString());
                this.myClass_WeldingParameter.CoverWeldingRodDiameter = double.Parse(myReader_Temp[str_Prefixion + "CoverWeldingRodDiameter"].ToString());
                this.myClass_WeldingParameter.double_Thickness = (double)myReader_Temp[str_Prefixion + "Thickness"];
                if (myReader_Temp[str_Prefixion + "ExternalDiameter"] != DBNull.Value)
                {
                    this.myClass_WeldingParameter.double_ExternalDiameter = (double)myReader_Temp[str_Prefixion + "ExternalDiameter"];
                }                
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
            myParameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = this.ExaminingNo;
            myParameters.Add("@WeldingPosition", SqlDbType.NVarChar, 10).Value = this.WeldingPosition;

            myParameters.Add("@isPassed", SqlDbType.Bit).Value = this.isPassed;
            myParameters.Add("@FaceDT", SqlDbType.Bit).Value = this.FaceDT;
            myParameters.Add("@UT", SqlDbType.Bit).Value = this.UT;
            myParameters.Add("@RT", SqlDbType.Bit).Value = this.RT;
            myParameters.Add("@BendDT", SqlDbType.Bit).Value = this.BendDT;
            myParameters.Add("@DisjunctionDT", SqlDbType.Bit).Value = this.DisjunctionDT;
            myParameters.Add("@Impact", SqlDbType.Bit).Value = this.Impact;
            myParameters.Add("@MacroExamination", SqlDbType.Bit).Value = this.MacroExamination;
            myParameters.Add("@OtherDT", SqlDbType.Bit).Value = this.OtherDT;
            myParameters .Add("@Flaw", SqlDbType.NVarChar, 20).Value = this.Flaw;

            myParameters.Add("@isMakeup", SqlDbType.Bit).Value = this.isMakeup;
            myParameters.Add("@MakeupFaceDT", SqlDbType.Bit).Value = this.MakeupFaceDT;
            myParameters.Add("@MakeupUT", SqlDbType.Bit).Value = this.MakeupUT;
            myParameters.Add("@MakeupRT", SqlDbType.Bit).Value = this.MakeupRT;
            myParameters.Add("@MakeupBendDT", SqlDbType.Bit).Value = this.MakeupBendDT;
            myParameters.Add("@MakeupDisjunctionDT", SqlDbType.Bit).Value = this.MakeupDisjunctionDT;
            myParameters.Add("@MakeupImpact", SqlDbType.Bit).Value = this.MakeupImpact;
            myParameters.Add("@MakeupMacroExamination", SqlDbType.Bit).Value = this.MakeupMacroExamination;
            myParameters.Add("@MakeupOtherDT", SqlDbType.Bit).Value = this.MakeupOtherDT;
            myParameters.Add("@MakeupFlaw", SqlDbType.NVarChar, 20).Value = this.MakeupFlaw;

            string str_Prefixion = "WeldingPositionResult";
            myParameters.Add("@" + str_Prefixion + "Thickness", SqlDbType.Real ).Value = this.myClass_WeldingParameter.double_Thickness ;
            if (this.myClass_WeldingParameter.double_ExternalDiameter >0)
            {
                myParameters.Add("@" + str_Prefixion + "ExternalDiameter", SqlDbType.Real ).Value = this.myClass_WeldingParameter.double_ExternalDiameter ;
            }
            myParameters.Add("@" + str_Prefixion + "RenderWeldingRodDiameter", SqlDbType.Real).Value = this.myClass_WeldingParameter.RenderWeldingRodDiameter;
            myParameters.Add("@" + str_Prefixion + "WeldingRodDiameter", SqlDbType.Real).Value = this.myClass_WeldingParameter.WeldingRodDiameter;
            myParameters.Add("@" + str_Prefixion + "CoverWeldingRodDiameter", SqlDbType.Real).Value = this.myClass_WeldingParameter.CoverWeldingRodDiameter;
            myParameters.Add("@" + str_Prefixion + "Assemblage", SqlDbType.NVarChar, 10).Value = this.myClass_WeldingParameter.Assemblage;

            myParameters.Add("@WeldingPositionResultRemark", SqlDbType.NVarChar, 255).Value = this.WeldingPositionResultRemark;

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
        /// <param name="SubjectPositionResult"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, string ExaminingNo, string WeldingPosition, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = ExaminingNo;
            myParameters.Add("@WeldingPosition", SqlDbType.NVarChar, 10).Value = WeldingPosition;
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
            myCmd_Temp.CommandText = "Exam_SubjectPositionResult_Update";
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
        /// <param name="SubjectPositionResult"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(string ExaminingNo, string WeldingPosition, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_SubjectPositionResult_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_SubjectPositionResult.ParametersAdd(myCmd_Temp.Parameters, ExaminingNo, WeldingPosition, myEnum_zwjKindofUpdate);
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

        static public bool  ExistSecond(string IssueNo, string ExaminingNo)
        {
            string str_SQL;
            int int_Temp=0;
            str_SQL = "Select Count(Exam_SubjectPositionResult.ExaminingNo) FROM dbo.Exam_SubjectPositionResult INNER JOIN dbo.Exam_Student ON dbo.Exam_SubjectPositionResult.ExaminingNo = dbo.Exam_Student.ExaminingNo";
            if (string.IsNullOrEmpty(IssueNo))
            {
                str_SQL = str_SQL + " Where Exam_SubjectPositionResult.ExaminingNo='" + ExaminingNo + "'";
            }
            else
            {
                str_SQL = str_SQL + " Where Exam_Student.IssueNo='" + IssueNo + "'";
            }
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader mySqlDataReader;
            myCmd_Temp.CommandText = str_SQL;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            mySqlDataReader = myCmd_Temp.ExecuteReader();
            if (mySqlDataReader.Read())
            {
                int_Temp =(int) mySqlDataReader[0];
            }
            mySqlDataReader.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return (int_Temp > 0);

        }

        static public void SubjectPositionResultCreateBatch(string IssueNo, string ExaminingNo)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_SubjectPositionResult_CreateBatch";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            if (!string.IsNullOrEmpty(IssueNo))
            {
                myCmd_Temp.Parameters.Add("@IssueNo", SqlDbType.NVarChar, 20).Value = IssueNo;
            }
            if (!string.IsNullOrEmpty(ExaminingNo))
            {
                myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = ExaminingNo;
            }
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
            if (string.IsNullOrEmpty(this.ExaminingNo ))
            {
                return "考试编号不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WeldingPosition  ))
            {
                return "焊接位置不能为空！";
            }
            else if (string.IsNullOrEmpty(this.Flaw))
            {
                return "缺陷不能为空！";
            }
            else if (string.IsNullOrEmpty(this.MakeupFlaw))
            {
                return "补考缺陷不能为空！";
            }
            else if (string.IsNullOrEmpty(this.myClass_WeldingParameter.Assemblage))
            {
                return "装配方式不能为空";
            }

            return null;
        }

        static public  void ExportBendTestApply_JN(DataView myDataView_Temp)
        {
            Form_TestParameter_Input myForm = new Form_TestParameter_Input();
            if (myForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string str_Filter = "(ExamStatus = '顺利考试')";
            if (myForm.bool_FaceDT)
            {
                str_Filter += " And (FaceDT Or MakeupFaceDT)";
            }
            if (myForm.bool_RT)
            {
                str_Filter += " And (RT Or MakeupRT)";
            }
            myDataView_Temp.RowFilter = str_Filter;

            myDataView_Temp.Sort = "ExaminingNo, WeldingPosition";
            if (myDataView_Temp.Count == 0)
            {
                MessageBox.Show("没有考试项目！");
                return;
            }
            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\江南造船理化试验申请单.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            int i = 0;
            int j = 0;
            foreach (DataRowView myDataViewRow in myDataView_Temp)
            {
                if (i % 12 == 0)
                {
                    myWordDocument.Tables[1].Cell(1, 2).Range.Text = DateTime.Today.ToString("yyyy年M月d日");
                    myWordDocument.Tables[1].Cell(2, 5).Range.Text = myDataViewRow["IssueNo"].ToString();
                    myWordDocument.Tables[1].Cell(20, 6).Range.Text = myDataViewRow["SkillTeacherName"].ToString();
                    myWordDocument.Tables[1].Cell(20, 8).Range.Text = myForm.str_LinkTel;
                    myWordDocument.Tables[1].Cell(2, 7).Range.Text = myDataViewRow["IssueMaterial"].ToString();
                    if (myForm.bool_Supervisor)
                    {
                        myWordDocument.Tables[1].Cell(17, 7).Range.Text = "按CCS焊工考试方案试验\n验船师在场试验";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(17, 7).Range.Text = "按CCS焊工考试方案试验";
                    }
                    if (i > 0)
                    {
                        str_BookmarkName = "first";
                        Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                        str_BookmarkName = "last";
                        Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                        myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                        myRange.Copy();
                        myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                        myWordDocument.Application.Selection.Paste();
                    }
                }
                myWordDocument.Tables[1].Cell(4 + (i % 12), 4).Range.Text = myDataViewRow["ExaminingNo"].ToString() + "-" + myDataViewRow["WeldingPosition"].ToString();
                myWordDocument.Tables[1].Cell(4 + (i % 12), 5).Range.Text = myDataViewRow["IssueDimensionofMaterial"].ToString();
                myWordDocument.Tables[1].Cell(4 + (i % 12), 10).Range.Text = myForm.str_BendTestItem;
                i++;
            }
            while (i % 12 != 0)
            {
                myWordDocument.Tables[1].Cell(4 + (i % 12), 4).Range.Text = "";
                myWordDocument.Tables[1].Cell(4 + (i % 12), 5).Range.Text = "";
                myWordDocument.Tables[1].Cell(4 + (i % 12), 10).Range.Text = "";
                i++;
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
            myWordApp.Visible = true;
        }

        static public void ExportBendTestApply_AN(DataView myDataView_Temp)
        {
            Form_TestParameter_Input myForm = new Form_TestParameter_Input();
            if (myForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string str_Filter = "(ExamStatus = '顺利考试')";
            if (myForm.bool_FaceDT)
            {
                str_Filter += " And (FaceDT Or MakeupFaceDT)";
            }
            if (myForm.bool_RT)
            {
                str_Filter += " And (RT Or MakeupRT)";
            }
            myDataView_Temp.RowFilter = str_Filter;

            myDataView_Temp.Sort = "ExaminingNo, WeldingPosition";
            if (myDataView_Temp.Count == 0)
            {
                MessageBox.Show("没有考试项目！");
                return;
            }
            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\安装公司检验委托单.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            int i = 0;
            int j = 0;

            foreach (DataRowView myDataViewRow in myDataView_Temp)
            {
                if (i % 8 == 0)
                {
                    myWordDocument.Tables[1].Cell(5, 4).Range.Text = DateTime.Today.ToString("yyyy-M-d");
                    myWordDocument.Tables[1].Cell(6, 2).Range.Text = myDataViewRow["SkillTeacherName"].ToString() + "(" + myForm.str_LinkTel + ")";
                    if (myForm.bool_Supervisor)
                    {
                        myWordDocument.Tables[1].Cell(6, 4).Range.Text = "验船师在场试验，本周加工好";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(6, 4).Range.Text = "本周加工好";
                    }
                    myWordDocument.Tables[1].Cell(7, 2).Range.Text = myDataViewRow["IssueNo"].ToString();
                    myWordDocument.Tables[1].Cell(8, 2).Range.Text = myForm.str_BendTestItem;
                    if (i > 0)
                    {
                        str_BookmarkName = "first";
                        Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                        str_BookmarkName = "last";
                        Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                        myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                        myRange.Copy();
                        myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                        myWordDocument.Application.Selection.Paste();
                    }
                }

                myWordDocument.Tables[1].Cell(11 + (i % 8), 1).Range.Text = myDataViewRow["ExaminingNo"].ToString() + "-" + myDataViewRow["WeldingPosition"].ToString();
                if (myDataViewRow["WorkPieceType"].ToString() == "管")
                {
                    myWordDocument.Tables[1].Cell(11 + (i % 8), 2).Range.Text = myDataViewRow["WeldingPositionResultThickness"].ToString() + "×" + myDataViewRow["WeldingPositionResultExternalDiameter"].ToString();
                }
                else
                {
                    myWordDocument.Tables[1].Cell(11 + (i % 8), 2).Range.Text = myDataViewRow["WeldingPositionResultThickness"].ToString();
                }
                myWordDocument.Tables[1].Cell(11 + (i % 8), 3).Range.Text = myDataViewRow["IssueMaterial"].ToString();
                myWordDocument.Tables[1].Cell(11 + (i % 8), 4).Range.Text = myDataViewRow["IssueWeldingConsumable"].ToString();
                myWordDocument.Tables[1].Cell(11 + (i % 8), 5).Range.Text = myDataViewRow["WeldingProcessAb"].ToString();
                myWordDocument.Tables[1].Cell(11 + (i % 8), 6).Range.Text = myDataViewRow["WeldingPosition"].ToString();
                i++;
            }

            while (i % 8 != 0)
            {
                myWordDocument.Tables[1].Cell(11 + (i % 8), 1).Range.Text = "";
                myWordDocument.Tables[1].Cell(11 + (i % 8), 2).Range.Text = "";
                myWordDocument.Tables[1].Cell(11 + (i % 8), 3).Range.Text = "";
                myWordDocument.Tables[1].Cell(11 + (i % 8), 4).Range.Text = "";
                myWordDocument.Tables[1].Cell(11 + (i % 8), 5).Range.Text = "";
                myWordDocument.Tables[1].Cell(11 + (i % 8), 6).Range.Text = "";
                i++;
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
            myWordApp.Visible = true;
        }

        static public void ExportRTTestApply_JN(DataView myDataView_Excel)
        {
            myDataView_Excel.Sort = "ExaminingNo, WeldingPosition";
            myDataView_Excel.RowFilter = "(ExamStatus = '顺利考试') and (FaceDT Or MakeupFaceDT)";

            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;

            myExcelSheet.PageSetup.TopMargin  = 70;
            myExcelSheet.Cells.NumberFormatLocal = "@";
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).RowHeight = 65;
            myExcelSheet.get_Range("A:A", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("B:B", System.Reflection.Missing.Value).ColumnWidth = 15;
            myExcelSheet.get_Range("C:D", System.Reflection.Missing.Value).ColumnWidth = 12;
            myExcelSheet.get_Range("E:E", System.Reflection.Missing.Value).ColumnWidth = 22;
            myExcelSheet.get_Range("F:F", System.Reflection.Missing.Value).ColumnWidth = 30;
            myExcelSheet.get_Range("A2", "A7").RowHeight = 26;
            myExcelSheet.get_Range("A8", System.Reflection.Missing.Value).RowHeight = 35;

            myExcelSheet.get_Range("E8", System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
            myExcelSheet.get_Range("E8", System.Reflection.Missing.Value).VerticalAlignment = ZCExcel.XlVAlign.xlVAlignBottom;
            myExcelSheet.get_Range("B3", System.Reflection.Missing.Value).Value2 = "RT";
            myExcelSheet.get_Range("B6", System.Reflection.Missing.Value).Value2 = "JISZ3104-95-Ⅱ";
            myExcelSheet.get_Range("B7", System.Reflection.Missing.Value).Value2 = "焊接培训中心";

            int int_Index = 0;
            int i;
            string str_Column = "";
            foreach (DataRowView myDataRowView in myDataView_Excel)
            {
                int_Index++;
                if (int_Index == 1)
                {
                    Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myDataRowView["ShipClassificationAb"].ToString());
                    if (myClass_ShipClassification.ShipRestrict)
                    {
                        Class_Ship myClass_Ship = new Class_Ship(myDataRowView["ShipboardNo"].ToString());
                        myExcelSheet.get_Range("B2", System.Reflection.Missing.Value).Value2 = myClass_Ship.ShipboardNo;
                    }
                    else
                    {
                        myExcelSheet.get_Range("B2", System.Reflection.Missing.Value).Value2 = myClass_ShipClassification.ShipClassificationAb;
                    }
                    myExcelSheet.get_Range("E2", System.Reflection.Missing.Value).Value2 = myDataRowView["IssueNo"].ToString();
                    myExcelSheet.get_Range("B4", System.Reflection.Missing.Value).Value2 = myDataRowView["IssueDimensionofMaterial"].ToString();
                    myExcelSheet.get_Range("E4", System.Reflection.Missing.Value).Value2 = myDataRowView["IssueMaterial"].ToString();
                    myExcelSheet.get_Range("E7", System.Reflection.Missing.Value).Value2 = myDataRowView["SkillTeacherName"].ToString();
                    myExcelSheet.get_Range("E8", System.Reflection.Missing.Value).Value2 = DateTime.Today.ToString("yy   M    d");
                    if (myDataRowView["WorkPieceType"].ToString() == "板")
                    {
                        myExcelSheet.get_Range("E31", System.Reflection.Missing.Value).Value2 = "两端各去除20mm";
                    }
                }
                if (int_Index <= 20)
                {
                    str_Column = "B";
                    i = int_Index;
                }
                else if (int_Index <= 40)
                {
                    str_Column = "C";
                    i = int_Index - 20;
                }
                else if (int_Index <= 60)
                {
                    i = int_Index - 40;
                    str_Column = "D";
                }
                else if (int_Index <= 80)
                {
                    str_Column = "E";
                    i = int_Index - 60;
                }
                else if (int_Index <= 100)
                {
                    i = int_Index - 80;
                    str_Column = "F";
                }
                else
                {
                    i = int_Index - 100;
                    str_Column = "G";
                }

                myExcelSheet.get_Range(string.Format("{0}{1}", str_Column, i + 9), System.Reflection.Missing.Value).Value2 = myDataRowView["ExaminingNo"].ToString().Substring(myDataRowView["ExaminingNo"].ToString().Length - 7, 7) + "-" + myDataRowView["WeldingPosition"].ToString();
            }
            myExcelSheet.get_Range("E5", System.Reflection.Missing.Value).Value2 = int_Index;
            myExcelApp.Visible = true;
        }

        static public void ExportMTTestApply_JN(DataView myDataView_Excel)
        {
            myDataView_Excel.Sort = "ExaminingNo, WeldingPosition";
            myDataView_Excel.RowFilter = "(ExamStatus = '顺利考试') and (FaceDT Or MakeupFaceDT)";

            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;

            myExcelSheet.PageSetup.TopMargin = 70;
            myExcelSheet.Cells.NumberFormatLocal = "@";
            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).RowHeight = 65;
            myExcelSheet.get_Range("A:A", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("B:B", System.Reflection.Missing.Value).ColumnWidth = 15;
            myExcelSheet.get_Range("C:D", System.Reflection.Missing.Value).ColumnWidth = 12;
            myExcelSheet.get_Range("E:E", System.Reflection.Missing.Value).ColumnWidth = 18;
            myExcelSheet.get_Range("F:F", System.Reflection.Missing.Value).ColumnWidth = 30;
            myExcelSheet.get_Range("A2", "A7").RowHeight = 26;
            myExcelSheet.get_Range("A8", System.Reflection.Missing.Value).RowHeight = 35;

            myExcelSheet.get_Range("E8", System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
            myExcelSheet.get_Range("E8", System.Reflection.Missing.Value).VerticalAlignment = ZCExcel.XlVAlign.xlVAlignBottom;
            myExcelSheet.get_Range("B3", System.Reflection.Missing.Value).Value2 = "MT";
            myExcelSheet.get_Range("B6", System.Reflection.Missing.Value).Value2 = "JISG0565-1992";
            myExcelSheet.get_Range("B7", System.Reflection.Missing.Value).Value2 = "焊接培训中心";

            int int_Index = 0;
            int i;
            string str_Column = "";
            foreach (DataRowView myDataRowView in myDataView_Excel)
            {
                int_Index++;
                if (int_Index == 1)
                {
                    Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(myDataRowView["ShipClassificationAb"].ToString());
                    if (myClass_ShipClassification.ShipRestrict)
                    {
                        Class_Ship myClass_Ship = new Class_Ship(myDataRowView["ShipboardNo"].ToString());
                        myExcelSheet.get_Range("B2", System.Reflection.Missing.Value).Value2 = myClass_Ship.ShipboardNo;
                    }
                    else
                    {
                        myExcelSheet.get_Range("B2", System.Reflection.Missing.Value).Value2 = myClass_ShipClassification.ShipClassificationAb;
                    }
                    myExcelSheet.get_Range("E2", System.Reflection.Missing.Value).Value2 = myDataRowView["IssueNo"].ToString();
                    myExcelSheet.get_Range("B4", System.Reflection.Missing.Value).Value2 = myDataRowView["IssueDimensionofMaterial"].ToString();
                    myExcelSheet.get_Range("E4", System.Reflection.Missing.Value).Value2 = myDataRowView["IssueMaterial"].ToString();
                    myExcelSheet.get_Range("E7", System.Reflection.Missing.Value).Value2 = myDataRowView["SkillTeacherName"].ToString();
                    myExcelSheet.get_Range("E8", System.Reflection.Missing.Value).Value2 = DateTime.Today.ToString("yy   M    d");
                    if (myDataRowView["WorkPieceType"].ToString() == "板")
                    {
                        myExcelSheet.get_Range("E31", System.Reflection.Missing.Value).Value2 = "";
                    }
                }
                if (int_Index <= 20)
                {
                    str_Column = "B";
                    i = int_Index;
                }
                else if (int_Index <= 40)
                {
                    str_Column = "C";
                    i = int_Index - 20;
                }
                else if (int_Index <= 60)
                {
                    i = int_Index - 40;
                    str_Column = "D";
                }
                else if (int_Index <= 80)
                {
                    str_Column = "E";
                    i = int_Index - 60;
                }
                else if (int_Index <= 100)
                {
                    i = int_Index - 80;
                    str_Column = "F";
                }
                else
                {
                    i = int_Index - 100;
                    str_Column = "G";
                }

                myExcelSheet.get_Range(string.Format("{0}{1}", str_Column, i + 9), System.Reflection.Missing.Value).Value2 = myDataRowView["ExaminingNo"].ToString().Substring(myDataRowView["ExaminingNo"].ToString().Length - 7, 7) + "-" + myDataRowView["WeldingPosition"].ToString();
            }
            myExcelSheet.get_Range("E5", System.Reflection.Missing.Value).Value2 = int_Index;
            myExcelApp.Visible = true;
        }

    }
    
    public class Class_ReviveQC
    {
        #region "Fields"
        public int ReviveQCID;
        public string ExaminingNo;
        public object SkillTeacherID;
        public DateTime SkillExamDate;
        public string ExamStatus;
        public bool isPassed;
        public bool FaceDT;
        public bool UT;
        public bool RT;
        public bool BendDT;
        public bool DisjunctionDT;
        public bool Impact;
        public bool MacroExamination;
        public bool OtherDT;
        public string Flaw;
        public string ReviveQCRemark;

        #endregion

        public Class_ReviveQC()
        {
        }

        public Class_ReviveQC(int int_ReviveQCID)
        {
            this.ReviveQCID = int_ReviveQCID;
            this.FillData();
        }

        /// <summary>
        /// 类对象的数据填充函数
        /// </summary>
        /// <returns></returns>
        public bool FillData()
        {
            string str_SQL = "Select * From [Exam_ReviveQC] Where ReviveQCID=@ReviveQCID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@ReviveQCID", SqlDbType.Int ).Value = this.ReviveQCID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            SqlDataReader myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.ExaminingNo = myReader_Temp["ExaminingNo"].ToString();
                this.SkillTeacherID = myReader_Temp["SkillTeacherID"];
                this.SkillExamDate = DateTime.Parse(myReader_Temp["SkillExamDate"].ToString());
                this.ExamStatus = myReader_Temp["ExamStatus"].ToString();
                this.isPassed = (bool)myReader_Temp["isPassed"];
                this.FaceDT = (bool)myReader_Temp["FaceDT"];
                this.UT = (bool)myReader_Temp["UT"];
                this.RT = (bool)myReader_Temp["RT"];
                this.BendDT = (bool)myReader_Temp["BendDT"];
                this.DisjunctionDT = (bool)myReader_Temp["DisjunctionDT"];
                this.Impact = (bool)myReader_Temp["Impact"];
                this.MacroExamination = (bool)myReader_Temp["MacroExamination"];
                this.OtherDT = (bool)myReader_Temp["OtherDT"];
                this.Flaw = myReader_Temp["Flaw"].ToString();
                this.ReviveQCRemark = myReader_Temp["ReviveQCRemark"].ToString();
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
            myParameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = this.ExaminingNo;
            myParameters.Add("@SkillTeacherID", SqlDbType.UniqueIdentifier).Value = this.SkillTeacherID;
            myParameters.Add("@SkillExamDate", SqlDbType.DateTime).Value = this.SkillExamDate;
            myParameters.Add("@ExamStatus", SqlDbType.NVarChar, 10).Value = this.ExamStatus;
            myParameters.Add("@isPassed", SqlDbType.Bit).Value = this.isPassed;
            myParameters.Add("@FaceDT", SqlDbType.Bit).Value = this.FaceDT;
            myParameters.Add("@UT", SqlDbType.Bit).Value = this.UT;
            myParameters.Add("@RT", SqlDbType.Bit).Value = this.RT;
            myParameters.Add("@BendDT", SqlDbType.Bit).Value = this.BendDT;
            myParameters.Add("@DisjunctionDT", SqlDbType.Bit).Value = this.DisjunctionDT;
            myParameters.Add("@Impact", SqlDbType.Bit).Value = this.Impact;
            myParameters.Add("@MacroExamination", SqlDbType.Bit).Value = this.MacroExamination;
            myParameters.Add("@OtherDT", SqlDbType.Bit).Value = this.OtherDT;
            myParameters.Add("@Flaw", SqlDbType.NVarChar, 20).Value = this.Flaw;
            myParameters.Add("@ReviveQCRemark", SqlDbType.NVarChar, 255).Value = this.ReviveQCRemark;
            myParameters.Add("@ReviveQCID", SqlDbType.Int ).Direction = ParameterDirection.InputOutput;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters["@ReviveQCID"].Value = this.ReviveQCID;
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        /// <summary>
        /// 数据删除、判断是否可以删除和判断是否存在的统一参数填充
        /// </summary>
        /// <param name="myParameters"></param>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        static public void ParametersAdd(SqlParameterCollection myParameters, int ReviveQCID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@ReviveQCID", SqlDbType.Int ).Value = ReviveQCID;
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
            myCmd_Temp.CommandText = "Exam_ReviveQC_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.ReviveQCID = (int)myCmd_Temp.Parameters["@ReviveQCID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_ReviveQC",string.Format("{0};{1}", this.ExaminingNo,this.ReviveQCID ), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return !string.IsNullOrEmpty(this.ExaminingNo);
        }

        /// <summary>
        /// 集成数据删除、判断是否可以删除和判断是否存在的统一函数
        /// </summary>
        /// <param name="Template"></param>
        /// <param name="myEnum_zwjKindofUpdate"></param>
        /// <returns></returns>
        static public bool ExistAndCanDeleteAndDelete(int ReviveQCID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Exam_ReviveQC", ReviveQCID.ToString(), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_ReviveQC_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_ReviveQC.ParametersAdd(myCmd_Temp.Parameters, ReviveQCID, myEnum_zwjKindofUpdate);
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

        static public bool ExistSecond(string ExaminingNo)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Exam_ReviveQC_ExistSecond";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@ExaminingNo", SqlDbType.NVarChar, 20).Value = ExaminingNo;
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

        /// <summary>
        /// 校验数据字段的格式
        /// </summary>
        /// <returns></returns>
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.ExaminingNo ))
            {
                return "考试编号不能为空！";
            }
            else if (this.SkillTeacherID ==null )
            {
                return "技能老师不能为空！";
            }

            //else if (string.IsNullOrEmpty(this.ExamStatus))
            //{
            //    return "考试状态不能为空！";
            //}

            return null;

        }

    }
}





