using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using ZCCL.ClassBase;
using ZCCL.Tools;
using ZCExcel = Microsoft.Office.Interop.Excel;
using ZCWord = Microsoft.Office.Interop.Word;
using ZCWelder.ClassBase;
using System.Collections;
using Microsoft.Reporting.WinForms;
using ZCWelder.Reports;
using System.Text.RegularExpressions;

namespace ZCWelder.Exam
{
    public partial class Form_ExportQC : Form
    {
        public DataTable myDataTable;

        public Form_ExportQC()
        {
            InitializeComponent();
        }

        private void Form_ExportQC_Load(object sender, EventArgs e)
        {

        }

        private void button_ExportCCSAccess_Click(object sender, EventArgs e)
        {
            string str_SQL;
            //string str_Regex = string.Format("^{0}-APPLY-{1}-\\d{{5}}$", Properties.Settings.Default.CCSTestCommitteeID, DateTime.Today.Year.ToString().Substring(2, 2));
            string str_Regex = string.Format("^{0}-APPLY-\\d{{2}}-\\d{{5}}$", Properties.Settings.Default.CCSTestCommitteeID);
            string str_Conn;
            string str_FileName;
            OleDbConnection myConn_Temp;
            OleDbCommand myCmd_Temp;
            
            DataView myDataView = new DataView(this.myDataTable);
            if (this.checkBox_ExportCCSMustQCAccess.Checked)
            {
                myDataView.RowFilter = "ExamSubjectID is Not Null And CertificateNo is Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            }
            else
            {
                myDataView.RowFilter = "ExamSubjectID is Not Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            }
            myDataView.Sort = "IssueNo, ExaminingNo";
            //确定所有需要办证的焊工电子照片是否齐全
            Hashtable myHashtable_WelderPicture = Class_Welder.GetWelderPictureHashtableBinary(myDataView.ToTable());            ;
            if (myHashtable_WelderPicture.Count < Class_Data.GetDistinctField(myDataView.ToTable(), "IdentificationCard").Rows.Count)
            {
                if (MessageBox.Show("有部分焊工没有照片，确认导出“Access办证文件”吗？", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }

            Class_ExamField.RefreshData();
            if (System.Text.RegularExpressions.Regex.IsMatch(Class_ExamField.CCSApplyNo, str_Regex))
            {
                Class_ExamField.CCSApplyNo = string.Format("{0}-APPLY-{1}-{2}", Properties.Settings.Default.CCSTestCommitteeID, DateTime.Today.Year.ToString().Substring(2, 2), Class_ExamField.CCSApplyNo.Substring(Class_ExamField.CCSApplyNo.Length-5, 5));
            }
            else
            {
                Class_ExamField.CCSApplyNo = string.Format("{0}-APPLY-{1}-00001", Properties.Settings.Default.CCSTestCommitteeID, DateTime.Today.Year.ToString().Substring(2, 2));
            }
            SaveFileDialog myForm = new SaveFileDialog();
            myForm.Filter = "Access files (*.mdb)|*.mdb";
            myForm.FileName = string.Format("{0}({1})-{2}人", Class_ExamField.CCSApplyNo, DateTime.Today.ToShortDateString(), myDataView.Count );
            myForm.RestoreDirectory = true;
            if (myForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            str_FileName = string.Format("{0}\\Data\\Vacancy.mdb", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            File.Copy(str_FileName, myForm.FileName, true);
            FileInfo fileInfo = new FileInfo(myForm.FileName);
            if (!fileInfo.Exists)
            {
                MessageBox.Show("创建文件失败，请确认是否具有相应权限！");
                return;
            }

            str_Conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + myForm.FileName + ";Persist Security Info=True";
            myConn_Temp = new OleDbConnection(str_Conn);
            try
            {
                myConn_Temp.Open();
                myCmd_Temp = new OleDbCommand("Delete FROM TB_Certificate_Sqs", myConn_Temp);
                myCmd_Temp.ExecuteNonQuery();
                myCmd_Temp = new OleDbCommand("Delete FROM TB_Welder_Info", myConn_Temp);
                myCmd_Temp.ExecuteNonQuery();
                myCmd_Temp = new OleDbCommand("Delete FROM TB_Commit_Info", myConn_Temp);
                myCmd_Temp.ExecuteNonQuery();
                myCmd_Temp = new OleDbCommand("Delete FROM TB_People_Info", myConn_Temp);
                myCmd_Temp.ExecuteNonQuery();

                str_SQL = "Insert Into TB_Certificate_Sqs ( ApplyNo, ApplyRq, HwhNo, HwhName, PNum, ExportFlag, Employer, DateofTest, FinishFlag, WishDate) Values(?,?,?,?,?,?,?,?,?,?)";
                myCmd_Temp = new OleDbCommand(str_SQL, myConn_Temp);
                myCmd_Temp.Parameters.Add("@ApplyNo", OleDbType.Char, 20).Value = Class_ExamField.CCSApplyNo;
                myCmd_Temp.Parameters.Add("@ApplyRq", OleDbType.Date).Value = DateTime.Today.Date;
                myCmd_Temp.Parameters.Add("@HwhNo", OleDbType.Char, 20).Value = Properties.Settings.Default.CCSTestCommitteeID;
                myCmd_Temp.Parameters.Add("@HwhName", OleDbType.Char, 50).Value = Properties.Settings.Default.CCSTestCommittee;
                myCmd_Temp.Parameters.Add("@PNum", OleDbType.Integer).Value = myDataView.Count ;
                myCmd_Temp.Parameters.Add("@ExportFlag", OleDbType.Boolean).Value = false;
                myCmd_Temp.Parameters.Add("@Employer", OleDbType.Char, 50).Value = Properties.Settings.Default.CCSTestCommittee;
                myCmd_Temp.Parameters.Add("@DateofTest", OleDbType.Date).Value = DateTime.Today.Date;
                myCmd_Temp.Parameters.Add("@FinishFlag", OleDbType.Boolean).Value = false;
                myCmd_Temp.Parameters.Add("@WishDate", OleDbType.Date).Value = DateTime.Today.Date;
                myCmd_Temp.ExecuteNonQuery();

                double dbl_StudentThickness;
                double dbl_StudentExternalDiameter;

                foreach (DataRowView myDataRowView in myDataView)
                {
                    if (string.IsNullOrEmpty(myDataRowView["RegistrationNo"].ToString()))
                    {
                        myDataRowView["RegistrationNo"]=Class_TestCommitteeRegistrationNo.AutoFill(Properties.Settings.Default.CCSTestCommitteeID , myDataRowView["IdentificationCard"].ToString());
                    }
                    byte[] mybyte = Class_Welder.GetWelderPictureBinary(myDataRowView["IdentificationCard"].ToString());

                    str_SQL = "Insert Into TB_Welder_Info ( WelderNo, WelderName, WelderSex, WelderIDNo, Employer, Education, TestCommitteeNo, WorkType, WelderPic) Values(?,?,?,?,?,?,?,?,?)";
                    myCmd_Temp = new OleDbCommand(str_SQL, myConn_Temp);
                    myCmd_Temp.Parameters.Add("@WelderNo", OleDbType.Char, 20).Value = myDataRowView["RegistrationNo"];
                    myCmd_Temp.Parameters.Add("@WelderName", OleDbType.Char, 10).Value = myDataRowView["WelderName"];
                    myCmd_Temp.Parameters.Add("@WelderSex", OleDbType.Char, 1).Value = myDataRowView["Sex"];
                    myCmd_Temp.Parameters.Add("@WelderIDNo", OleDbType.Char, 18).Value = myDataRowView["IdentificationCard"];
                    myCmd_Temp.Parameters.Add("@Employer", OleDbType.Char, 50).Value = string.Format("{0} {1} {2}", myDataRowView["WelderEmployer"], myDataRowView["WelderDepartment"], myDataRowView["WelderLaborServiceTeam"]);
                    myCmd_Temp.Parameters.Add("@Education", OleDbType.Char, 4).Value = myDataRowView["Schooling"];
                    myCmd_Temp.Parameters.Add("@TestCommitteeNo", OleDbType.Char, 20).Value=Properties.Settings.Default.CCSTestCommitteeID ;
                    myCmd_Temp.Parameters.Add("@WorkType", OleDbType.Char, 20).Value = myDataRowView["WeldingProject"];
                    if (mybyte == null)
                    {
                        myCmd_Temp.Parameters.Add("@WelderPic", OleDbType.Binary).Value = DBNull.Value;
                    }
                    else
                    {
                        myCmd_Temp.Parameters.Add("@WelderPic", OleDbType.Binary).Value = mybyte;
                    }
                    myCmd_Temp.ExecuteNonQuery();

                    str_SQL = "Insert Into TB_Commit_Info (TestActionRemark, WelderNo, WelderName, WelderSex, WelderIDNo, Employer, Education, TestCommitteeNo, WorkType, TestGrade, ApplyKind, BaseMetal, FillerMetal, ThickNess, ButtWelding, TestType, TestBasicScore, TestActionScore, TestTestScore1, TestTestScore2, ApplyNo, WelderMarkNo, PipeThickNess, PipeOutSide, TestNo, WelderPic, WPSNo) Values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                    myCmd_Temp = new OleDbCommand(str_SQL, myConn_Temp);
                    myCmd_Temp.Parameters.Add("@TestActionRemark", OleDbType.Char,40).Value = string.Format("{0} : {1}", myDataRowView["IssueNo"], myDataRowView["ExaminingNo"]);
                    myCmd_Temp.Parameters.Add("@WelderNo", OleDbType.Char, 20).Value = myDataRowView["RegistrationNo"];
                    myCmd_Temp.Parameters.Add("@WelderName", OleDbType.Char, 10).Value = myDataRowView["WelderName"];
                    myCmd_Temp.Parameters.Add("@WelderSex", OleDbType.Char, 1).Value = myDataRowView["Sex"];
                    myCmd_Temp.Parameters.Add("@WelderIDNo", OleDbType.Char, 18).Value = myDataRowView["IdentificationCard"];
                    myCmd_Temp.Parameters.Add("@Employer", OleDbType.Char, 50).Value = string.Format("{0} {1} {2}", myDataRowView["WelderEmployer"], myDataRowView["WelderDepartment"], myDataRowView["WelderLaborServiceTeam"]); ;
                    myCmd_Temp.Parameters.Add("@Education", OleDbType.Char, 4).Value = myDataRowView["Schooling"];
                    myCmd_Temp.Parameters.Add("@TestCommitteeNo", OleDbType.Char, 20).Value=Properties.Settings.Default.CCSTestCommitteeID ;
                    myCmd_Temp.Parameters.Add("@WorkType", OleDbType.Char, 20).Value = myDataRowView["WeldingProject"];

                    myCmd_Temp.Parameters.Add("@TestGrade", OleDbType.Char, 40).Value = myDataRowView["CCSSubject"].ToString();
                    //myCmd_Temp.Parameters.Add("@TestGrade", OleDbType.Char, 40).Value = myDataRowView["WeldingClass"].ToString() + myDataRowView["Subject"].ToString();
                    myCmd_Temp.Parameters.Add("@ApplyKind", OleDbType.Char, 10).Value = "新证";
                    myCmd_Temp.Parameters.Add("@BaseMetal", OleDbType.Char, 255).Value = myDataRowView["MaterialCCSGroupItemName"];
                    myCmd_Temp.Parameters.Add("@FillerMetal", OleDbType.Char, 255).Value = myDataRowView["ScopeofWeldingConsumableCCSGroup"];
                    if (!double.TryParse(myDataRowView["StudentThickness"].ToString().Trim(), out dbl_StudentThickness))
                    {
                        dbl_StudentThickness = 22;
                    }
                    if (!double.TryParse(myDataRowView["StudentExternalDiameter"].ToString().Trim(), out dbl_StudentExternalDiameter))
                    {
                        dbl_StudentExternalDiameter =0;
                    }
                    if (myDataRowView["WorkPieceType"].ToString() == "板")
                    {
                        myCmd_Temp.Parameters.Add("@ThickNess", OleDbType.Integer).Value =(int) dbl_StudentThickness;
                    }
                    else
                    {
                        myCmd_Temp.Parameters.Add("@ThickNess", OleDbType.Integer).Value =DBNull.Value ;
                    }
                    myCmd_Temp.Parameters.Add("@ButtWelding", OleDbType.Char, 255).Value = myDataRowView["ScopeofCCSAssemblage"];
                    myCmd_Temp.Parameters.Add("@TestType", OleDbType.Char, 255).Value = myDataRowView["CCSWeldingProcess"];
                    myCmd_Temp.Parameters.Add("@TestBasicScore", OleDbType.Char, 20);
                    if (myDataRowView["TheoryResult"]!=DBNull.Value && (int)myDataRowView["TheoryResult"] >= (int)myDataRowView["PassScore"])
                    {
                        myCmd_Temp.Parameters["@TestBasicScore"].Value = myDataRowView["TheoryResult"];
                    }
                    else if (myDataRowView["TheoryMakeupResult"] != DBNull.Value && (int)myDataRowView["TheoryMakeupResult"] >= (int)myDataRowView["PassScore"])
                    {
                        myCmd_Temp.Parameters["@TestBasicScore"].Value = myDataRowView["TheoryMakeupResult"];
                    }
                    else
                    {
                        //myCmd_Temp.Parameters["@TestBasicScore"].Value = (int)myDataRowView["PassScore"];
                        myCmd_Temp.Parameters["@TestBasicScore"].Value =DBNull.Value ;
                    }
                    myCmd_Temp.Parameters.Add("@TestActionScore", OleDbType.Char, 50).Value = "合格";
                    if (myDataRowView["RTTestDate"] == DBNull.Value)
                    {
                        myCmd_Temp.Parameters.Add("@TestTestScore1", OleDbType.Char, 50).Value = "合格";
                        myCmd_Temp.Parameters.Add("@TestTestScore2", OleDbType.Char, 50).Value = "";
                    }
                    else
                    {
                        myCmd_Temp.Parameters.Add("@TestTestScore1", OleDbType.Char, 50).Value = "";
                        myCmd_Temp.Parameters.Add("@TestTestScore2", OleDbType.Char, 50).Value = "合格";
                    }
                    myCmd_Temp.Parameters.Add("@ApplyNo", OleDbType.Char, 50).Value = Class_ExamField.CCSApplyNo;
                    myCmd_Temp.Parameters.Add("@WelderMarkNo", OleDbType.Char, 20).Value = myDataRowView["ExaminingNo"];
                    if (myDataRowView["WorkPieceType"].ToString() == "板")
                    {
                        myCmd_Temp.Parameters.Add("@PipeThickNess", OleDbType.Integer).Value = DBNull.Value ;
                        myCmd_Temp.Parameters.Add("@PipeOutSide", OleDbType.Integer).Value = DBNull.Value;
                    }
                    else
                    {
                        myCmd_Temp.Parameters.Add("@PipeThickNess", OleDbType.Integer).Value = (int)dbl_StudentThickness;
                        myCmd_Temp.Parameters.Add("@PipeOutSide", OleDbType.Integer).Value = (int)dbl_StudentExternalDiameter;
                    }
                    myCmd_Temp.Parameters.Add("@TestNo", OleDbType.Char, 50).Value = myDataRowView["CCSSubjectTestNo"].ToString();
                    if (mybyte == null)
                    {
                        myCmd_Temp.Parameters.Add("@WelderPic", OleDbType.Binary).Value = DBNull.Value ;
                    }
                    else
                    {
                        myCmd_Temp.Parameters.Add("@WelderPic", OleDbType.Binary).Value = mybyte; 
                    }
                    //myCmd_Temp.Parameters.Add("@WPSNo", OleDbType.Char, 200).Value = string.Format("WPS-{0}-{1}-{2}", myDataRowView["WeldingProcessAb"], myDataRowView["StudentMaterial"], myDataRowView["WeldingClass"]);
                    myCmd_Temp.Parameters.Add("@WPSNo", OleDbType.Char, 200).Value = myDataRowView["WPSNo"].ToString();

                    myCmd_Temp.ExecuteNonQuery();

                    str_SQL = "Insert Into TB_People_Info (TestActionRemark, WelderNo, WelderName, WelderSex, WelderIDNo, Employer, Education, TestCommitteeNo, WorkType, TestGrade, ApplyKind, BaseMetal, FillerMetal, ThickNess, ButtWelding, TestType, TestBasicScore, TestActionScore, TestTestScore1, TestTestScore2, ApplyNo, WelderMarkNo, PipeThickNess, PipeOutSide, TestNo, WelderPic, WPSNo) Values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                    myCmd_Temp.CommandText = str_SQL;
                    myCmd_Temp.ExecuteNonQuery(); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConn_Temp.Close();
            }

            Class_ExamField.CCSApplyNo = Class_Tools.GetNextSequence(Class_ExamField.CCSApplyNo, 5);
            Class_ExamField.UpdateField();
            MessageBox.Show("操作完毕！");
        }

        private void button_ExportCCSExcel_Click(object sender, EventArgs e)
        {
            DataView myDataView = new DataView(this.myDataTable);
            if (this.checkBox_ExportCCSMustQCAccess.Checked)
            {
                myDataView.RowFilter = "ExamSubjectID is Not Null And CertificateNo is Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            }
            else
            {
                myDataView.RowFilter = "ExamSubjectID is Not Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            }
            myDataView.Sort = "IssueNo, ExaminingNo";

            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;
            int int_Index;

            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("B1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("C1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("D1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("E1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("F1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("G1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("H1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("I1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("J1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("K1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("L1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("M1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("N1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("O1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("P1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("Q1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("R1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("S1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("T1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("U1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("V1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myRange = myExcelSheet.get_Range("A1", "V1");
            myRange.RowHeight = 32;
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignCenter;
            myRange.WrapText = true;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlContinuous;

            int_Index = 1;
            myExcelSheet.get_Range("A" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "考编号";
            myExcelSheet.get_Range("B" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "期数";
            myExcelSheet.get_Range("C" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "焊接方法";
            myExcelSheet.get_Range("D" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "姓名";
            myExcelSheet.get_Range("E" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "性别";
            myExcelSheet.get_Range("F" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "部门";
            myExcelSheet.get_Range("G" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "劳务队";
            myExcelSheet.get_Range("H" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "母材";
            myExcelSheet.get_Range("I" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "焊接材料";
            myExcelSheet.get_Range("J" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "装配";
            myExcelSheet.get_Range("K" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "焊工等级";
            myExcelSheet.get_Range("L" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "厚度";
            myExcelSheet.get_Range("M" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "管径";
            myExcelSheet.get_Range("N" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "考委会号";
            myExcelSheet.get_Range("O" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "科目";
            myExcelSheet.get_Range("P" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "理论成绩";
            myExcelSheet.get_Range("Q" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "理补成绩";
            myExcelSheet.get_Range("R" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "考试方式";
            myExcelSheet.get_Range("S" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "身份证";
            myExcelSheet.get_Range("T" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "作业区";
            myExcelSheet.get_Range("U" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "公司";
            myExcelSheet.get_Range("V" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "工号";
            myExcelSheet.get_Range("S:S", System.Reflection.Missing.Value).NumberFormatLocal = "@";

            foreach (DataRowView myDataRowView in myDataView)
            {
                if (string.IsNullOrEmpty(myDataRowView["RegistrationNo"].ToString()))
                {
                    myDataRowView["RegistrationNo"] = Class_TestCommitteeRegistrationNo.AutoFill(Properties.Settings.Default.CCSTestCommitteeID, myDataRowView["IdentificationCard"].ToString());
                }
                int_Index++;
                myExcelSheet.get_Range("A" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["ExaminingNo"];
                myExcelSheet.get_Range("B" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["IssueNo"];
                myExcelSheet.get_Range("C" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WeldingProcessAb"];
                myExcelSheet.get_Range("D" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderName"];
                myExcelSheet.get_Range("E" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["Sex"];
                myExcelSheet.get_Range("F" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderDepartment"];
                myExcelSheet.get_Range("G" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderLaborServiceTeam"];
                myExcelSheet.get_Range("H" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentMaterial"];
                myExcelSheet.get_Range("I" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentWeldingConsumable"];
                myExcelSheet.get_Range("J" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentAssemblage"];
                myExcelSheet.get_Range("K" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WeldingProjectAb"].ToString() + myDataRowView["WeldingClassAb"].ToString();
                myExcelSheet.get_Range("L" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentThickness"].ToString();
                myExcelSheet.get_Range("M" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentExternalDiameter"].ToString();
                myExcelSheet.get_Range("N" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["RegistrationNo"];
                //myExcelSheet.get_Range("O" + int_Index.ToString(), System.Reflection.Missing.Value).Value2  = myDataRowView["CertificateNo"];
                //myExcelSheet.get_Range("P" + int_Index.ToString(), System.Reflection.Missing.Value).Value2  = ((DateTime)myDataRowView["IssuedOn"]).ToShortDateString ();
                //myExcelSheet.get_Range("Q" + int_Index.ToString(), System.Reflection.Missing.Value).Value2  = myDataRowView["PeriodofValidity"];
                //myExcelSheet.get_Range("R" + int_Index.ToString(), System.Reflection.Missing.Value).Value2  = myDataRowView["SupervisionPlace"];
                myExcelSheet.get_Range("O" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["Subject"];
                myExcelSheet.get_Range("P" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["TheoryResult"];
                myExcelSheet.get_Range("Q" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["TheoryMakeupResult"];
                myExcelSheet.get_Range("R" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentKindofExam"];
                myExcelSheet.get_Range("S" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["IdentificationCard"];
                myExcelSheet.get_Range("T" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderWorkPlace"];
                myExcelSheet.get_Range("U" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderEmployer"];
                myExcelSheet.get_Range("V" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderWorkerID"];
            }

            myRange = myExcelSheet.get_Range("A2", "V" + int_Index.ToString());
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            if (int_Index > 2)
            {
                myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlDot;
            }
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlDot;

            myExcelApp.Visible = true;
        }

        private void button_ExportCCSWord_Click(object sender, EventArgs e)
        {
            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document  myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\CCS焊工资格证书背面.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            
            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            myWordDocument.Tables[1].Cell( 23, 1).Range.Text = "江南造船";
            myWordDocument.Tables[1].Cell(24, 1).Range.Text = "江南造船";
            myWordDocument.Tables[1].Cell(25, 1).Range.Text = "江南造船";
            myWordDocument.Tables[1].Cell(23, 5).Range.Text = "江南造船";
            myWordDocument.Tables[1].Cell(24, 5).Range.Text = "江南造船";
            myWordDocument.Tables[1].Cell(25, 5).Range.Text = "江南造船";
            myWordDocument.Tables[1].Cell(28, 1).Range.Text = "江南造船";
            myWordDocument.Tables[1].Cell(23, 2).Range.Text = DateTime.Today.AddMonths(6 ).ToString("yyyy年M月");
            myWordDocument.Tables[1].Cell(24, 2).Range.Text = DateTime.Today.AddMonths(12 ).ToString("yyyy年M月");
            myWordDocument.Tables[1].Cell(25, 2).Range.Text = DateTime.Today.AddMonths(18 ).ToString("yyyy年M月");
            myWordDocument.Tables[1].Cell(23, 6).Range.Text = DateTime.Today.AddMonths(24).ToString("yyyy年M月");
            myWordDocument.Tables[1].Cell(24, 6).Range.Text = DateTime.Today.AddMonths(30).ToString("yyyy年M月");
            myWordDocument.Tables[1].Cell(25, 6).Range.Text = DateTime.Today.AddMonths(42).ToString("yyyy年M月");
            myWordDocument.Tables[1].Cell(28, 2).Range.Text = DateTime.Today.AddMonths(36 ).ToString("yyyy年M月");
            //myWordDocument.Tables[1].Cell(23, 2).Range.Text = DateTime.Today.AddMonths(6+ Class_ExamField.SupervisionOffset).ToString("yyyy年M月");
            //myWordDocument.Tables[1].Cell(24, 2).Range.Text = DateTime.Today.AddMonths(12 + Class_ExamField.SupervisionOffset).ToString("yyyy年M月");
            //myWordDocument.Tables[1].Cell(25, 2).Range.Text = DateTime.Today.AddMonths(18 + Class_ExamField.SupervisionOffset).ToString("yyyy年M月");
            //myWordDocument.Tables[1].Cell(23, 6).Range.Text = DateTime.Today.AddMonths(24 + Class_ExamField.SupervisionOffset).ToString("yyyy年M月");
            //myWordDocument.Tables[1].Cell(24, 6).Range.Text = DateTime.Today.AddMonths(30 + Class_ExamField.SupervisionOffset).ToString("yyyy年M月");
            //myWordDocument.Tables[1].Cell(25, 6).Range.Text = DateTime.Today.AddMonths(42 + Class_ExamField.SupervisionOffset).ToString("yyyy年M月");
            myWordApp.Visible = true;

        }

        private void ExportGXWordHD()
        {
            DataView myDataView = new DataView(this.myDataTable);
            DataView myDataView_SubjectPositionResult;
            myDataView.RowFilter = "CertificateNo is Not Null";
            myDataView.Sort = "IssueNo, ExaminingNo";
            if (myDataView.Count == 0)
            {
                MessageBox.Show("没有证书！");
                return;
            }

            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\GX焊工资格证书HD.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            int i;
            string str_WeldingPosition;
            string str_WeldingConsumables;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_Range;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            Image myImage_WelderPicture;
            string str_TempFileName;

            foreach (DataRowView myDataRowView in myDataView)
            {
                myImage_WelderPicture = Class_Welder.GetWelderPicture(myDataRowView["IdentificationCard"].ToString());
                myWordDocument.Tables[1].Cell(1, 3).Range.Select();
                myWordApp.Selection.Delete(ref oMissing, ref oMissing);
                if (myImage_WelderPicture != null)
                {
                    str_TempFileName = Path.Combine(Path.GetTempPath(), myDataRowView["WelderName"].ToString() + "_" + myDataRowView["IdentificationCard"].ToString() + ".JPG");
                    File.Delete(str_TempFileName);
                    myImage_WelderPicture.Save(str_TempFileName);
                    myWordDocument.Tables[1].Cell(1, 3).Select();
                    ZCWord.InlineShape myInlineShape = myWordApp.Selection.InlineShapes.AddPicture(str_TempFileName, ref oMissing, ref oMissing, ref oMissing);
                    myInlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                }

                str_WeldingPosition = "";
                myWordDocument.Tables[1].Cell(1, 2).Range.Text = myDataRowView["WelderName"].ToString();
                myWordDocument.Tables[1].Cell(2, 2).Range.Text = myDataRowView["Sex"].ToString();
                myWordDocument.Tables[1].Cell(3, 2).Range.Text = myDataRowView["IdentificationCard"].ToString();
                myWordDocument.Tables[1].Cell(4, 2).Range.Text = myDataRowView["WeldingClass"].ToString() + "(" + myDataRowView["WeldingProcessAb"].ToString() + ")";
                myWordDocument.Tables[1].Cell(5, 2).Range.Text = myDataRowView["WeldingStandard"].ToString();
                //myWordDocument.Tables[1].Cell(6, 2).Range.Text = myDataRowView["RegistrationNo"].ToString();

                str_BookmarkName = "CertificateNo";
                myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
                myRange.Text = "证书号：" + myDataRowView["CertificateNo"].ToString();
                myRange.Select();
                object_Range = myWordDocument.Application.Selection.Range;
                myWordDocument.Bookmarks.Add("CertificateNo", ref object_Range);

                myWordDocument.Tables[1].Cell(21, 1).Range.Text = "说明：";
                myDataView_SubjectPositionResult = new DataView(Class_Student.GetDataTable_SubjectPositionResult(myDataRowView["ExaminingNo"].ToString(), null, "WeldingPosition"));
                i = 0;
                foreach (DataRowView myDataRowView_SubjectPositionResult in myDataView_SubjectPositionResult)
                {
                    if (!string.IsNullOrEmpty(str_WeldingPosition))
                    {
                        str_WeldingPosition += "；";
                    }
                    str_WeldingPosition += myDataRowView_SubjectPositionResult["WeldingPosition"].ToString() + "-" + myDataRowView_SubjectPositionResult["WeldingPositionContent"].ToString();

                    myWordDocument.Tables[1].Cell(7 + i, 1).Range.Text = myDataRowView_SubjectPositionResult["WeldingPosition"].ToString();
                    myWordDocument.Tables[1].Cell(7 + i, 2).Range.Text = myDataRowView["WeldingProcessAb"].ToString();
                    myWordDocument.Tables[1].Cell(7 + i, 3).Range.Text = myDataRowView["IssueMaterial"].ToString();
                    if (myDataRowView_SubjectPositionResult["WorkPieceType"].ToString() == "管")
                    {
                        myWordDocument.Tables[1].Cell(7 + i, 4).Range.Text = myDataRowView_SubjectPositionResult["WeldingPositionResultExternalDiameter"].ToString() + "×" + myDataRowView_SubjectPositionResult["WeldingPositionResultThickness"].ToString();
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(7 + i, 4).Range.Text = myDataRowView_SubjectPositionResult["WeldingPositionResultThickness"].ToString();
                    }

                    str_WeldingConsumables = myDataRowView["StudentWeldingConsumable"].ToString();
                    if ((float)myDataRowView_SubjectPositionResult["WeldingPositionResultRenderWeldingRodDiameter"] > 0)
                    {
                        str_WeldingConsumables += "/Φ" + myDataRowView_SubjectPositionResult["WeldingPositionResultRenderWeldingRodDiameter"].ToString();
                    }
                    if ((float)myDataRowView_SubjectPositionResult["WeldingPositionResultWeldingRodDiameter"] > 0)
                    {
                        str_WeldingConsumables += "/Φ" + myDataRowView_SubjectPositionResult["WeldingPositionResultWeldingRodDiameter"].ToString();
                    }
                    if ((float)myDataRowView_SubjectPositionResult["WeldingPositionResultCoverWeldingRodDiameter"] > 0)
                    {
                        str_WeldingConsumables += "/Φ" + myDataRowView_SubjectPositionResult["WeldingPositionResultCoverWeldingRodDiameter"].ToString();
                    }
                    myWordDocument.Tables[1].Cell(7 + i, 5).Range.Text = str_WeldingConsumables;
                    if (string.IsNullOrEmpty(myDataRowView["ProtectGas"].ToString()))
                    {
                        myWordDocument.Tables[1].Cell(7 + i, 6).Range.Text = "----";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(7 + i, 6).Range.Text = myDataRowView["ProtectGas"].ToString();
                    }
                    if (myDataRowView_SubjectPositionResult["WeldingPositionResultAssemblage"].ToString() == "单面焊双面成型")
                    {
                        myWordDocument.Tables[1].Cell(7 + i, 7).Range.Text = "----";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(7 + i, 7).Range.Text = myDataRowView_SubjectPositionResult["WeldingPositionResultAssemblage"].ToString();
                    }
                    myWordDocument.Tables[1].Cell(15, 2 + i).Range.Text = myDataRowView_SubjectPositionResult["WeldingPosition"].ToString();
                    if ((bool)myDataRowView_SubjectPositionResult["FaceDT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupFaceDT"] == true)
                    {
                        myWordDocument.Tables[1].Cell(16, 2 + i).Range.Text = "合格";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(16, 2 + i).Range.Text = "----";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["RT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupRT"] == true)
                    {
                        myWordDocument.Tables[1].Cell(17, 2 + i).Range.Text = "合格";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(17, 2 + i).Range.Text = "----";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["BendDT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupBendDT"] == true)
                    {
                        myWordDocument.Tables[1].Cell(18, 2 + i).Range.Text = "合格";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(18, 2 + i).Range.Text = "----";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["UT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupUT"] == true)
                    {
                        myWordDocument.Tables[1].Cell(19, 2 + i).Range.Text = "合格";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(19, 2 + i).Range.Text = "----";
                    }
                    myWordDocument.Tables[1].Cell(20, 2 + i).Range.Text = "----";
                    if ((bool)myDataRowView_SubjectPositionResult["DisjunctionDT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupDisjunctionDT"] == true)
                    {
                        myWordDocument.Tables[1].Cell(20, 2 + i).Range.Text = "合格";
                        myWordDocument.Tables[1].Cell(21, 1).Range.Text = "说明：其他检验—折断";
                    }
                    else
                    {
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["OtherDT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupOtherDT"] == true)
                    {
                        myWordDocument.Tables[1].Cell(20, 2 + i).Range.Text = "合格";
                    }
                    else
                    {
                    }
                    i += 1;
                }


                myWordDocument.Tables[1].Cell(13, 1).Range.Text = "说明：" + str_WeldingPosition;

                while (i < 6)
                {
                    myWordDocument.Tables[1].Cell(7 + i, 1).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(7 + i, 2).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(7 + i, 3).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(7 + i, 4).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(7 + i, 5).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(7 + i, 6).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(7 + i, 7).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(15, 2 + i).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(16, 2 + i).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(17, 2 + i).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(18, 2 + i).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(19, 2 + i).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(20, 2 + i).Range.Text = "----";
                    i = i + 1;
                }
                myWordDocument.Tables[1].Cell(22, 2).Range.Text = myDataRowView["Subject"].ToString();
                myWordDocument.Tables[1].Cell(22, 4).Range.Text = myDataRowView["ScopeofSubject"].ToString();
                myWordDocument.Tables[1].Cell(23, 2).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).ToShortDateString();
                myWordDocument.Tables[1].Cell(24, 2).Range.Text = ((DateTime)myDataRowView["ValidUntil"]).ToShortDateString();

                str_BookmarkName = "first";
                Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                str_BookmarkName = "last";
                Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                myRange.Copy();
                myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                myWordDocument.Application.Selection.Paste();
            }



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
            myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;
        }

        private void button_ExportGXWord_Click(object sender, EventArgs e)
        {
            this.ExportGXWordHD();
            return;

            DataView myDataView = new DataView(this.myDataTable);
            DataView myDataView_SubjectPositionResult;
            myDataView.RowFilter = "CertificateNo is Not Null";
            myDataView.Sort = "IssueNo, ExaminingNo";
            if (myDataView.Count == 0)
            {
                MessageBox.Show("没有证书！");
                return;
            }

            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\GX焊工资格证书.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            int i;
            string str_WeldingPosition;
            string str_WeldingConsumables;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_Range;
            object object_wdStory= ZCWord.WdUnits.wdStory   ;
            Image myImage_WelderPicture;
            string str_TempFileName;

            foreach (DataRowView myDataRowView in myDataView)
            {
                myImage_WelderPicture=Class_Welder.GetWelderPicture(myDataRowView["IdentificationCard"].ToString());
                myWordDocument.Tables[1].Cell(1, 3).Range.Select();
                myWordApp.Selection.Delete(ref oMissing,ref oMissing);
                if (myImage_WelderPicture != null)
                {
                    str_TempFileName = Path.Combine(Path.GetTempPath(), myDataRowView["WelderName"].ToString() + "_" + myDataRowView["IdentificationCard"].ToString() + ".JPG");
                    File.Delete(str_TempFileName);
                    myImage_WelderPicture.Save(str_TempFileName);
                    myWordDocument.Tables[1].Cell(1, 3).Select();
                    ZCWord.InlineShape myInlineShape = myWordApp.Selection.InlineShapes.AddPicture(str_TempFileName, ref oMissing, ref oMissing, ref oMissing);
                    myInlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                }
                
                str_WeldingPosition = "";
                myWordDocument.Tables[1].Cell(1, 2).Range.Text = myDataRowView["WelderName"].ToString();
                myWordDocument.Tables[1].Cell(2, 2).Range.Text = myDataRowView["Sex"].ToString();
                myWordDocument.Tables[1].Cell(3, 2).Range.Text = myDataRowView["IdentificationCard"].ToString();
                myWordDocument.Tables[1].Cell(4, 2).Range.Text = myDataRowView["WeldingClass"].ToString() + "(" + myDataRowView["WeldingProcessAb"].ToString() + ")";
                myWordDocument.Tables[1].Cell(5, 2).Range.Text = myDataRowView["WeldingStandard"].ToString();
                myWordDocument.Tables[1].Cell(6, 2).Range.Text = myDataRowView["RegistrationNo"].ToString();

                str_BookmarkName = "CertificateNo";
                myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
                myRange.Text = "证书流水号：" + myDataRowView["CertificateNo"].ToString();
                myRange.Select();
                object_Range=myWordDocument.Application.Selection.Range;
                myWordDocument.Bookmarks.Add("CertificateNo", ref object_Range);

                myWordDocument.Tables[1].Cell(21, 1).Range.Text = "说明：";
                myDataView_SubjectPositionResult = new DataView(Class_Student.GetDataTable_SubjectPositionResult(myDataRowView["ExaminingNo"].ToString(), null, "WeldingPosition"));
                i = 0;
                foreach (DataRowView myDataRowView_SubjectPositionResult in myDataView_SubjectPositionResult)
                {
                    if (!string.IsNullOrEmpty(str_WeldingPosition))
                    {
                        str_WeldingPosition += "；";
                    }
                    str_WeldingPosition += myDataRowView_SubjectPositionResult["WeldingPosition"].ToString() + "-" + myDataRowView_SubjectPositionResult["WeldingPositionContent"].ToString();

                    myWordDocument.Tables[1].Cell(8 + i, 1).Range.Text = myDataRowView_SubjectPositionResult["WeldingPosition"].ToString();
                    myWordDocument.Tables[1].Cell(8 + i, 2).Range.Text = myDataRowView["WeldingProcessAb"].ToString();
                    myWordDocument.Tables[1].Cell(8 + i, 3).Range.Text = myDataRowView["IssueMaterial"].ToString();
                    if (myDataRowView_SubjectPositionResult["WorkPieceType"].ToString() == "管")
                    {
                        myWordDocument.Tables[1].Cell(8 + i, 4).Range.Text = myDataRowView_SubjectPositionResult["WeldingPositionResultExternalDiameter"].ToString() + "×" + myDataRowView_SubjectPositionResult["WeldingPositionResultThickness"].ToString();
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(8 + i, 4).Range.Text = myDataRowView_SubjectPositionResult["WeldingPositionResultThickness"].ToString();
                    }

                    str_WeldingConsumables = myDataRowView["StudentWeldingConsumable"].ToString();
                    if ((float )myDataRowView_SubjectPositionResult["WeldingPositionResultRenderWeldingRodDiameter"] > 0)
                    {
                        str_WeldingConsumables += "/Φ" + myDataRowView_SubjectPositionResult["WeldingPositionResultRenderWeldingRodDiameter"].ToString();
                    }
                    if ((float)myDataRowView_SubjectPositionResult["WeldingPositionResultWeldingRodDiameter"] > 0)
                    {
                        str_WeldingConsumables += "/Φ" + myDataRowView_SubjectPositionResult["WeldingPositionResultWeldingRodDiameter"].ToString();
                    }
                    if ((float)myDataRowView_SubjectPositionResult["WeldingPositionResultCoverWeldingRodDiameter"] > 0)
                    {
                        str_WeldingConsumables += "/Φ" + myDataRowView_SubjectPositionResult["WeldingPositionResultCoverWeldingRodDiameter"].ToString();
                    }
                    myWordDocument.Tables[1].Cell(8 + i, 5).Range.Text = str_WeldingConsumables;
                    if (string.IsNullOrEmpty(myDataRowView["ProtectGas"].ToString()))
                    {
                        myWordDocument.Tables[1].Cell(8 + i, 6).Range.Text = "----";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(8 + i, 6).Range.Text = myDataRowView["ProtectGas"].ToString();
                    }
                    if (myDataRowView_SubjectPositionResult["WeldingPositionResultAssemblage"].ToString() == "单面焊双面成型")
                    {
                        myWordDocument.Tables[1].Cell(8 + i, 7).Range.Text = "----";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(8 + i, 7).Range.Text = myDataRowView_SubjectPositionResult["WeldingPositionResultAssemblage"].ToString();
                    }
                    myWordDocument.Tables[1].Cell(15, 2 + i).Range.Text = myDataRowView_SubjectPositionResult["WeldingPosition"].ToString();
                    if ((bool)myDataRowView_SubjectPositionResult["FaceDT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupFaceDT"] == true)
                    {
                        myWordDocument.Tables[1].Cell(16, 2 + i).Range.Text = "合格";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(16, 2 + i).Range.Text = "----";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["RT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupRT"] == true)
                    {
                        myWordDocument.Tables[1].Cell(17, 2 + i).Range.Text = "合格";
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(17, 2 + i).Range.Text = "----";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["BendDT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupBendDT"] == true)
                    { 
                        myWordDocument.Tables[1].Cell(18, 2 + i).Range.Text = "合格"; 
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(18, 2 + i).Range.Text = "----";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["UT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupUT"] == true)
                    { 
                        myWordDocument.Tables[1].Cell(19, 2 + i).Range.Text = "合格"; 
                    }
                    else
                    {
                        myWordDocument.Tables[1].Cell(19, 2 + i).Range.Text = "----";
                    }
                    myWordDocument.Tables[1].Cell(20, 2 + i).Range.Text = "----";
                    if ((bool)myDataRowView_SubjectPositionResult["DisjunctionDT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupDisjunctionDT"] == true)
                    {
                        myWordDocument.Tables[1].Cell(20, 2 + i).Range.Text = "合格";
                        myWordDocument.Tables[1].Cell(21, 1).Range.Text = "说明：其他检验—折断";
                    }
                    else
                    {
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["OtherDT"] == true || (bool)myDataRowView_SubjectPositionResult["MakeupOtherDT"] == true)
                    {
                        myWordDocument.Tables[1].Cell(20, 2 + i).Range.Text = "合格";
                    }
                    else
                    {
                    } 
                    i += 1;
                }


                myWordDocument.Tables[1].Cell(13, 1).Range.Text = "说明：" + str_WeldingPosition;

                while (i < 5)
                {
                    myWordDocument.Tables[1].Cell(8 + i, 1).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(8 + i, 2).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(8 + i, 3).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(8 + i, 4).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(8 + i, 5).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(8 + i, 6).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(8 + i, 7).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(15, 2 + i).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(16, 2 + i).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(17, 2 + i).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(18, 2 + i).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(19, 2 + i).Range.Text = "----";
                    myWordDocument.Tables[1].Cell(20, 2 + i).Range.Text = "----";
                    i = i + 1;
                }
                myWordDocument.Tables[1].Cell(22, 2).Range.Text = myDataRowView["Subject"].ToString();
                myWordDocument.Tables[1].Cell(22, 4).Range.Text = myDataRowView["ScopeofSubject"].ToString();
                myWordDocument.Tables[1].Cell(23, 2).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).ToShortDateString();
                myWordDocument.Tables[1].Cell(24, 2).Range.Text = ((DateTime)myDataRowView["ValidUntil"]).ToShortDateString();

                str_BookmarkName = "first";
                Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                str_BookmarkName = "last";
                Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                myRange.Copy();
                myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                myWordDocument.Application.Selection.Paste();
            }



            str_BookmarkName = "first";
            Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            str_BookmarkName = "last";
            Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            myRange.Delete(ref oMissing, ref oMissing);

            object object_Count=1;
            object object_wdCharacter = ZCWord.WdUnits.wdCharacter ;
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.Delete(ref object_wdCharacter, ref object_Count);
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.TypeBackspace();
            myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;
        }

        private void button_ExportGXGuardQC_Click(object sender, EventArgs e)
        {
            DataView myDataView = new DataView(this.myDataTable);
            myDataView.RowFilter = "CertificateNo is Not Null";
            myDataView.Sort = "IssueNo, ExaminingNo";
            if (myDataView.Count == 0)
            {
                MessageBox.Show("没有证书！");
                return;
            }

            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\GX焊工上岗证.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);


            int i;
            int int_Page;
            int int_Line;
            int u;
            int v;
            Class_QC myClass_QC = new Class_QC();

            int_Page = 0;
            int_Line = 0;
            u = 0;
            Image myImage_WelderPicture;
            string str_TempFileName;
            
            foreach (DataRowView myDataRowView in myDataView)
            {
                if (int_Page == 10)
                {
                    str_BookmarkName = "first";
                    Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                    str_BookmarkName = "last";
                    Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                    myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                    myRange.Copy();
                    myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                    myWordDocument.Application.Selection.Paste();
                    int_Page = 0;
                    int_Line = 0;
                }
                if ((int_Page % 2) == 0)
                {
                    u = 0;
                    v = 1;
                }
                else
                {
                    u = 1;
                    v = 0;
                }
                myImage_WelderPicture = Class_Welder.GetWelderPicture(myDataRowView["IdentificationCard"].ToString());
                myWordDocument.Tables[1].Cell(2 + 5 * int_Line, 2 + u * 6 + 1*v).Range.Select();
                myWordApp.Selection.Delete(ref oMissing, ref oMissing);
                if (myImage_WelderPicture != null)
                {
                    str_TempFileName = Path.Combine(Path.GetTempPath(), myDataRowView["WelderName"].ToString() + "_" + myDataRowView["IdentificationCard"].ToString() + ".JPG");
                    File.Delete(str_TempFileName);
                    myImage_WelderPicture.Save(str_TempFileName);
                    myWordDocument.Tables[1].Cell(2 + 5 * int_Line, 2 + u * 6 + 1 * v).Select();
                    ZCWord.InlineShape myInlineShape = myWordApp.Selection.InlineShapes.AddPicture(str_TempFileName, ref oMissing, ref oMissing, ref oMissing);
                    myInlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                }
                myWordDocument.Tables[1].Cell(2 + 5 * int_Line, 4 + u * 6 + 1 * v).Range.Text = myDataRowView["WelderName"].ToString();
                myWordDocument.Tables[1].Cell(4 + 5 * int_Line, 4 + u * 6 + 1 * v).Range.Text = myDataRowView["RegistrationNo"].ToString();
                string[] myArray_string = Class_Welder.GetWeldingProcessAndWeldingClass(myDataRowView["IdentificationCard"].ToString(), myDataRowView["ShipClassificationAb"].ToString(), myDataRowView["ShipboardNo"].ToString());
                myWordDocument.Tables[1].Cell(3 + 5 * int_Line, 4 + u * 6 + 1 * v).Range.Text = myArray_string[0];
           
                myWordDocument.Tables[2].Cell(1 + 4 * int_Line, 1 + v * 1).Range.Text = "";
                myWordDocument.Tables[2].Cell(2 + 4 * int_Line, 2 + v * 2).Range.Text = myArray_string[1];
                myWordDocument.Tables[2].Cell(3 + 4 * int_Line, 2 + v * 2).Range.Text = myArray_string[2];
                int_Page++;
                if (int_Page % 2 == 0)
                {
                    int_Line++;
                }
            }

            object myWdDeleteCells=ZCWord.WdDeleteCells.wdDeleteCellsEntireRow;
            if (int_Page % 2 == 1)
            {
                u = 1;
                v = 0;
                myWordDocument.Tables[1].Cell(2 + 5 * int_Line, 4 + u * 6 + 1 * v).Range.Text = "";
                myWordDocument.Tables[1].Cell(3 + 5 * int_Line, 4 + u * 6 + 1 * v).Range.Text = "";
                myWordDocument.Tables[1].Cell(4 + 5 * int_Line, 4 + u * 6 + 1 * v).Range.Text = "";
                myWordDocument.Tables[1].Cell(2 + 5 * int_Line, 3 + u * 6 + 1 * v).Range.Text = "";
                myWordDocument.Tables[1].Cell(3 + 5 * int_Line, 3 + u * 6 + 1 * v).Range.Text = "";
                myWordDocument.Tables[1].Cell(4 + 5 * int_Line, 3 + u * 6 + 1 * v).Range.Text = "";

                myWordDocument.Tables[1].Cell(2 + 5 * int_Line, 2 + u * 6 + 1 * v).Range.Select();
                myWordApp.Selection.Delete(ref oMissing, ref oMissing);
                myWordDocument.Tables[1].Cell(1 + 5 * int_Line, 1 + u * 2 + 1 * v).Range.Select();
                myWordApp.Selection.Delete(ref oMissing, ref oMissing);

                myWordDocument.Tables[2].Cell(1 + 4 * int_Line, 1 + v * 1).Range.Text = "";
                myWordDocument.Tables[2].Cell(2 + 4 * int_Line, 2 + v * 2).Range.Text = "";
                myWordDocument.Tables[2].Cell(3 + 4 * int_Line, 2 + v * 2).Range.Text = "";
                myWordDocument.Tables[2].Cell(2 + 4 * int_Line, 1 + v * 2).Range.Text = "";
                myWordDocument.Tables[2].Cell(3 + 4 * int_Line, 1 + v * 2).Range.Text = "";
                myWordDocument.Tables[2].Cell(4 + 4 * int_Line, 1 + v * 1).Range.Text = "";

                int_Line++;
            }
            for (i = int_Line; i <= 4; i++)
            {
                myWordDocument.Tables[1].Cell (5 + 5 * int_Line, 2).Delete(ref myWdDeleteCells);
                myWordDocument.Tables[1].Cell (4 + 5 * int_Line, 5).Delete(ref myWdDeleteCells);
                myWordDocument.Tables[1].Cell (3 + 5 * int_Line, 5).Delete(ref myWdDeleteCells);
                myWordDocument.Tables[1].Cell (2 + 5 * int_Line, 5).Delete(ref myWdDeleteCells);
                myWordDocument.Tables[1].Cell (1 + 5 * int_Line, 2).Delete(ref myWdDeleteCells);
             
                myWordDocument.Tables[2].Cell (4 + 4 * int_Line, 1).Delete(ref myWdDeleteCells);
                myWordDocument.Tables[2].Cell (3 + 4 * int_Line, 1).Delete(ref myWdDeleteCells);
                myWordDocument.Tables[2].Cell (2 + 4 * int_Line, 1).Delete(ref myWdDeleteCells);
                myWordDocument.Tables[2].Cell (1 + 4 * int_Line, 1).Delete(ref myWdDeleteCells);
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
            myWordDocument.Application.Selection.HomeKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.Delete(ref object_wdCharacter, ref object_Count);
            myWordApp.Selection.Delete(ref object_wdCharacter, ref object_Count);
            myWordApp.Selection.Delete(ref object_wdCharacter, ref object_Count);
            //myWordDocument.Application.Selection.HomeKey (ref object_wdStory, ref oMissing);
            //myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;
        }

        private void button_ExportGXCollectTable_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp = new DataView(this.myDataTable);
            myDataView_Temp.RowFilter = "CertificateNo is Not Null";
            myDataView_Temp.Sort = "IssueNo, ExaminingNo";
            if (myDataView_Temp.Count == 0)
            {
                MessageBox.Show("没有证书！");
                return;
            }
            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;
            int int_Index = 0;
            string str_IssueNo = "";
            foreach (DataRowView myDataRowView in myDataView_Temp)
            {
                if (str_IssueNo != myDataRowView["IssueNo"].ToString())
                {
                    if (!string.IsNullOrEmpty(str_IssueNo))
                    {
                        myExcelSheet.get_Range("A2", "A" + int_Index).RowHeight = 20;
                        myRange = myExcelSheet.get_Range("A2", "H" + int_Index);
                        myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
                        myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
                        myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
                        myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
                        if (int_Index > 2)
                        {
                            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
                        }
                        myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlContinuous;

                        int_Index++;
                        myRange = myExcelSheet.get_Range("A" + int_Index, "H" + int_Index);
                        myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
                        myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
                        myRange.Merge(System.Reflection.Missing.Value);
                        myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignLeft;
                        myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "注：姓名后有#号为一次合格。";
                        int_Index = int_Index + 2;
                        myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "编制：";
                        myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "校对：";
                        myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = "军代表：";

                        int_Index = int_Index + 2;
                        myRange = myExcelSheet.get_Range("A" + int_Index, "H" + int_Index);
                        myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
                        myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
                        myRange.Merge(System.Reflection.Missing.Value);
                        myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
                        myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "江南造船(集团)焊工考试委员会";
                        int_Index++;
                        myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = DateTime.Today.ToShortDateString();

                    }
                    myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets.Add(System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    int_Index = 1;
                    myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).ColumnWidth = 6;
                    myExcelSheet.get_Range("B1", System.Reflection.Missing.Value).ColumnWidth = 10;
                    myExcelSheet.get_Range("C1", System.Reflection.Missing.Value).ColumnWidth = 6;
                    myExcelSheet.get_Range("D1", System.Reflection.Missing.Value).ColumnWidth = 10;
                    myExcelSheet.get_Range("E1", System.Reflection.Missing.Value).ColumnWidth = 11;
                    myExcelSheet.get_Range("F1", System.Reflection.Missing.Value).ColumnWidth = 11;
                    myExcelSheet.get_Range("G1", System.Reflection.Missing.Value).ColumnWidth = 12;
                    myExcelSheet.get_Range("H1", System.Reflection.Missing.Value).ColumnWidth = 11;
                    myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).RowHeight = 60;
                    myExcelSheet.Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
                    myRange = myExcelSheet.get_Range("A1", "H1");
                    myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
                    myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
                    myRange.Merge(System.Reflection.Missing.Value);
                    int_Index = 2;
                    myExcelSheet.get_Range("A" + int_Index, "G" + int_Index).Font.Name = "黑体";
                    myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "序号";
                    myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = "姓名";
                    myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "性别";
                    myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = "类别";
                    myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = "证书存档号";
                    myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = "证书流水号";
                    myExcelSheet.get_Range("G" + int_Index, System.Reflection.Missing.Value).Value2 = "有效期至";
                    myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = "部门";
                    myRange = myExcelSheet.get_Range("A1", System.Reflection.Missing.Value);
                    myRange.Font.Name = "黑体";
                    myRange.Font.Size = 22;
                    myRange.Value2 = myDataRowView["ShipboardNo"].ToString() + "焊工上岗证名单\n(" + myDataRowView["IssueNo"].ToString() + ")";
                    str_IssueNo = myDataRowView["IssueNo"].ToString();
                    myExcelSheet.Name =str_IssueNo ;
                }
                int_Index++;
                myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = int_Index - 2;
                if ((bool)myDataRowView["SkillResult"])
                {
                    myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WelderName"].ToString() + "#";
                }
                else
                {
                    myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WelderName"].ToString();
                }
                myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["Sex"];
                myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WeldingProcessAb"].ToString() + "(" + myDataRowView["WeldingClass"].ToString() + ")";
                myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["RegistrationNo"];
                myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["CertificateNo"];
                myExcelSheet.get_Range("G" + int_Index, System.Reflection.Missing.Value).Value2 = ((DateTime)myDataRowView["ValidUntil"]).ToShortDateString();
                myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WelderDepartment"];
            }

            myExcelSheet.get_Range("A2", "A" + int_Index).RowHeight = 20;
            myRange = myExcelSheet.get_Range("A2", "H" + int_Index);
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            if (int_Index > 2)
            {
                myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            }
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlContinuous;

            int_Index++;
            myRange = myExcelSheet.get_Range("A" + int_Index, "H" + int_Index);
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignLeft;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "注：姓名后有#号为一次合格。";
            int_Index = int_Index + 2;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "编制：";
            myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "校对：";
            myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = "军代表：";

            int_Index = int_Index + 2;
            myRange = myExcelSheet.get_Range("A" + int_Index, "H" + int_Index);
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "江南造船(集团)焊工考试委员会";
            int_Index++;
            myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = DateTime.Today.ToShortDateString();

            myExcelSheet.Application.Visible = true;
        }

        private void button_ExportBVQCWord_Click(object sender, EventArgs e)
        {
            DataView myDataView = new DataView(this.myDataTable);
            myDataView.RowFilter = "CertificateNo is Not Null";
            myDataView.Sort = "IssueNo, ExaminingNo";
            if (myDataView.Count == 0)
            {
                MessageBox.Show("没有证书！");
                return;
            }

            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\BV焊工证书.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            int i;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            string str_Thickness="";
            string str_ExternalDiameter="";
            Image myImage_WelderPicture;
            string str_TempFileName;

            foreach (DataRowView myDataRowView in myDataView)
            {
                myImage_WelderPicture=Class_Welder.GetWelderPicture(myDataRowView["IdentificationCard"].ToString());
                myWordDocument.Tables[1].Cell(1, 3).Range.Select();
                myWordApp.Selection.Delete(ref oMissing,ref oMissing);
                if (myImage_WelderPicture != null)
                {
                    str_TempFileName = Path.Combine(Path.GetTempPath(), myDataRowView["WelderName"].ToString() + "_" + myDataRowView["IdentificationCard"].ToString() + ".JPG");
                    File.Delete(str_TempFileName);
                    myImage_WelderPicture.Save(str_TempFileName);
                    myWordDocument.Tables[1].Cell(1, 3).Select();
                    ZCWord.InlineShape myInlineShape = myWordApp.Selection.InlineShapes.AddPicture(str_TempFileName, ref oMissing, ref oMissing, ref oMissing);
                    myInlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                }

                myWordDocument.Tables[1].Cell(2, 2).Range.Text = myDataRowView["WelderEmployerEnglish"].ToString();
                if (myDataRowView["WelderEnglishName"] == DBNull.Value)
                {
                    myWordDocument.Tables[1].Cell(3, 2).Range.Text = myDataRowView["WelderName"].ToString();
                }
                else
                {
                    myWordDocument.Tables[1].Cell(3, 2).Range.Text = myDataRowView["WelderEnglishName"].ToString();
                }
                myWordDocument.Tables[1].Cell(4, 2).Range.Text = myDataRowView["IdentificationCard"].ToString();

                myWordDocument.Tables[1].Cell(6, 2).Range.Text = Class_DataValidateTool.GetBirthdaybyIdentificationCard(myDataRowView["IdentificationCard"].ToString()).ToShortDateString() + ",China";

                myWordDocument.Tables[3].Cell(2, 1).Range.Text = myDataRowView["ExaminingNo"].ToString();

                myWordDocument.Tables[3].Cell(13, 2).Range.Text = myDataRowView["WeldingProcessAb"].ToString();
                myWordDocument.Tables[3].Cell(14, 2).Range.Text = myDataRowView["StudentWeldingConsumable"].ToString() + "(at approval test)";
                myWordDocument.Tables[3].Cell(15, 2).Range.Text = myDataRowView["ScopeofMaterialISOGroup"].ToString();
                myWordDocument.Tables[3].Cell(20, 2).Range.Text = myDataRowView["ScopeofSubject"].ToString() + " positions in butt / fillet welding";
                myWordDocument.Tables[3].Cell(21, 2).Range.Text = myDataRowView["ScopeofISOAssemblage"].ToString();

                if (myDataRowView["WorkPieceType"].ToString() == "板")
                {
                    double dbl_StudentThickness;
                    double.TryParse(myDataRowView["StudentThickness"].ToString(), out dbl_StudentThickness);
                    if (dbl_StudentThickness > 0)
                    {
                        str_Thickness = Class_Student.GetScopeofISOThickness(dbl_StudentThickness);
                    }
                    else
                    {
                        str_Thickness = "t≥5mm";
                    }
                    str_ExternalDiameter = "";
                }
                else
                {
                    double dbl_StudentThickness;
                    double dbl_ExternalDiameter;
                    double.TryParse(myDataRowView["StudentThickness"].ToString(), out dbl_StudentThickness);
                    if (dbl_StudentThickness > 0)
                    {
                        str_Thickness = Class_Student.GetScopeofISOThickness(dbl_StudentThickness);
                    }
                    else
                    {
                        str_Thickness = "t≥5mm";
                    }
                    double.TryParse(myDataRowView["StudentExternalDiameter"].ToString(), out dbl_ExternalDiameter);
                    str_ExternalDiameter = Class_Student.GetScopeofISOExternalDiameter(dbl_ExternalDiameter);
                }

                myWordDocument.Tables[3].Cell(18, 2).Range.Text = str_Thickness;
                myWordDocument.Tables[3].Cell(19, 2).Range.Text = str_ExternalDiameter;

                if (myDataRowView["IssuedOn"] != DBNull.Value)
                {
                    myWordDocument.Tables[4].Cell(1, 2).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).ToShortDateString() + ", China";
                    myWordDocument.Tables[4].Cell(1, 4).Range.Text = ((DateTime)myDataRowView["ValidUntil"]).ToShortDateString();
                }

                str_BookmarkName = "first";
                Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                str_BookmarkName = "last";
                Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                myRange.Copy();
                myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                myWordDocument.Application.Selection.Paste();
            }

            str_BookmarkName = "first";
            Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            str_BookmarkName = "last";
            Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            myRange.Delete(ref oMissing, ref oMissing);

            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;

        }

        private void button_ExportABSQCWord_Click(object sender, EventArgs e)
        {
            DataView myDataView = new DataView(this.myDataTable);
            myDataView.RowFilter = "CertificateNo is Not Null";
            myDataView.Sort = "IssueNo, ExaminingNo";
            if (myDataView.Count == 0)
            {
                MessageBox.Show("没有证书！");
                return;
            }

            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\ABS焊工证书.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            int i;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            Image myImage_WelderPicture;
            string str_TempFileName;

            foreach (DataRowView myDataRowView in myDataView)
            {
                myImage_WelderPicture = Class_Welder.GetWelderPicture(myDataRowView["IdentificationCard"].ToString());
                myWordDocument.Tables[1].Cell(1, 4).Range.Select();
                myWordApp.Selection.Delete(ref oMissing, ref oMissing);
                if (myImage_WelderPicture != null)
                {
                    str_TempFileName = Path.Combine(Path.GetTempPath(), myDataRowView["WelderName"].ToString() + "_" + myDataRowView["IdentificationCard"].ToString() + ".JPG");
                    File.Delete(str_TempFileName);
                    myImage_WelderPicture.Save(str_TempFileName);
                    myWordDocument.Tables[1].Cell(1, 4).Select();
                    ZCWord.InlineShape myInlineShape = myWordApp.Selection.InlineShapes.AddPicture(str_TempFileName, ref oMissing, ref oMissing, ref oMissing);
                    myInlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                }

                if (myDataRowView["WelderEnglishName"] == DBNull.Value)
                {
                    myWordDocument.Tables[1].Cell(3, 2).Range.Text = myDataRowView["WelderName"].ToString();
                }
                else
                {
                    myWordDocument.Tables[1].Cell(3, 2).Range.Text = myDataRowView["WelderEnglishName"].ToString();
                }                
                myWordDocument.Tables[1].Cell(4, 2).Range.Text = myDataRowView["IdentificationCard"].ToString();
                myWordDocument.Tables[1].Cell(9, 2).Range.Text = myDataRowView["WeldingProcessAb"].ToString();
                myWordDocument.Tables[1].Cell(9, 3).Range.Text = myDataRowView["WeldingProcessAb"].ToString();
                myWordDocument.Tables[1].Cell(12, 2).Range.Text = myDataRowView["Subject"].ToString();
                myWordDocument.Tables[1].Cell(12, 3).Range.Text = myDataRowView["Subject"].ToString();
                switch (myDataRowView["StudentAssemblage"].ToString())
                {
                    case "清根":
                    case "衬垫":
                        myWordDocument.Tables[1].Cell(13, 2).Range.Text = "Yes";
                        myWordDocument.Tables[1].Cell(13, 3).Range.Text = "Backing/Gouging";
                        break;
                    default:
                        myWordDocument.Tables[1].Cell(13, 2).Range.Text = "NO";
                        myWordDocument.Tables[1].Cell(13, 3).Range.Text = "With Or Without";
                        break;
                }

                myWordDocument.Tables[1].Cell(14, 2).Range.Text = myDataRowView["StudentMaterial"].ToString();
                myWordDocument.Tables[1].Cell(16, 2).Range.Text = myDataRowView["StudentThickness"].ToString() + "mm";
                if (myDataRowView["WorkPieceType"].ToString() == "管")
                {
                    myWordDocument.Tables[1].Cell(17, 2).Range.Text = myDataRowView["StudentExternalDiameter"].ToString() + "mm";
                }
                myWordDocument.Tables[1].Cell(19, 2).Range.Text = myDataRowView["StudentWeldingConsumable"].ToString();
                myWordDocument.Tables[1].Cell(20, 2).Range.Text = myDataRowView["StudentWeldingConsumable"].ToString();
                myWordDocument.Tables[1].Cell(33, 4).Range.Text = myDataRowView["ExaminingNo"].ToString();

                str_BookmarkName = "first";
                Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                str_BookmarkName = "last";
                Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                myRange.Copy();
                myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                myWordDocument.Application.Selection.Paste();
            }
            str_BookmarkName = "first";
            Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            str_BookmarkName = "last";
            Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            myRange.Delete(ref oMissing, ref oMissing);

            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;
        }

        private void button_ExportGXOverdueExcel_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp = new DataView(this.myDataTable);
            myDataView_Temp.RowFilter = "CertificateNo is Not Null";
            myDataView_Temp.Sort = "IssueNo, ExaminingNo";
            if (myDataView_Temp.Count == 0)
            {
                MessageBox.Show("没有证书！");
                return;
            }
            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;
            int int_Index = 0;
            string str_IssueNo = "";
            foreach (DataRowView myDataRowView in myDataView_Temp)
            {
                if (str_IssueNo != myDataRowView["IssueNo"].ToString())
                {
                    if (!string.IsNullOrEmpty(str_IssueNo))
                    {
                        myExcelSheet.get_Range("A2", "A" + int_Index).RowHeight = 20;
                        myRange = myExcelSheet.get_Range("A2", "H" + int_Index);
                        myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
                        myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
                        myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
                        myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
                        if (int_Index > 2)
                        {
                            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
                        }
                        myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlContinuous;

                        int_Index++;
                        myRange = myExcelSheet.get_Range("A" + int_Index, "H" + int_Index);
                        myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
                        myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
                        myRange.Merge(System.Reflection.Missing.Value);
                        myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignLeft;
                        myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "";
                        int_Index = int_Index + 2;
                        myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "编制：";
                        myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "校对：";
                        myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = "军代表：";

                        int_Index = int_Index + 2;
                        myRange = myExcelSheet.get_Range("A" + int_Index, "H" + int_Index);
                        myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
                        myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
                        myRange.Merge(System.Reflection.Missing.Value);
                        myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
                        myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "江南造船焊工考试委员会";
                        int_Index++;
                        myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = DateTime.Today.ToShortDateString();

                    }
                    myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets.Add(System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    int_Index = 1;
                    myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).ColumnWidth = 6;
                    myExcelSheet.get_Range("B1", System.Reflection.Missing.Value).ColumnWidth = 10;
                    myExcelSheet.get_Range("C1", System.Reflection.Missing.Value).ColumnWidth = 6;
                    myExcelSheet.get_Range("D1", System.Reflection.Missing.Value).ColumnWidth = 10;
                    myExcelSheet.get_Range("E1", System.Reflection.Missing.Value).ColumnWidth = 11;
                    myExcelSheet.get_Range("F1", System.Reflection.Missing.Value).ColumnWidth = 11;
                    myExcelSheet.get_Range("G1", System.Reflection.Missing.Value).ColumnWidth = 12;
                    myExcelSheet.get_Range("H1", System.Reflection.Missing.Value).ColumnWidth = 11;
                    myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).RowHeight = 60;
                    myExcelSheet.Cells.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
                    myRange = myExcelSheet.get_Range("A1", "H1");
                    myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
                    myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
                    myRange.Merge(System.Reflection.Missing.Value);
                    int_Index = 2;
                    myExcelSheet.get_Range("A" + int_Index, "G" + int_Index).Font.Name = "黑体";
                    myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "序号";
                    myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = "姓名";
                    myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "性别";
                    myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = "类别";
                    myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = "证书存档号";
                    myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = "证书流水号";
                    myExcelSheet.get_Range("G" + int_Index, System.Reflection.Missing.Value).Value2 = "有效期至";
                    myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = "部门";
                    myRange = myExcelSheet.get_Range("A1", System.Reflection.Missing.Value);
                    myRange.Font.Name = "黑体";
                    myRange.Font.Size = 22;
                    myRange.Value2 = myDataRowView["ShipboardNo"].ToString() + "焊工延期名单\n(" + myDataRowView["IssueNo"].ToString() + ")";
                    str_IssueNo = myDataRowView["IssueNo"].ToString();
                    myExcelSheet.Name = str_IssueNo;
                }
                int_Index++;
                myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = int_Index - 2;
                if ((bool)myDataRowView["SkillResult"])
                {
                    myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WelderName"].ToString();
                }
                else
                {
                    myExcelSheet.get_Range("B" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WelderName"].ToString();
                }
                myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["Sex"];
                myExcelSheet.get_Range("D" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WeldingProcessAb"].ToString() + "(" + myDataRowView["WeldingClass"].ToString() + ")";
                myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["RegistrationNo"];
                myExcelSheet.get_Range("F" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["CertificateNo"];
                myExcelSheet.get_Range("G" + int_Index, System.Reflection.Missing.Value).Value2 = ((DateTime)myDataRowView["ValidUntil"]).ToShortDateString();
                myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = myDataRowView["WelderDepartment"];
            }

            myExcelSheet.get_Range("A2", "A" + int_Index).RowHeight = 20;
            myRange = myExcelSheet.get_Range("A2", "H" + int_Index);
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            if (int_Index > 2)
            {
                myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            }
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlContinuous;

            int_Index++;
            myRange = myExcelSheet.get_Range("A" + int_Index, "H" + int_Index);
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignLeft;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "";
            int_Index = int_Index + 2;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "编制：";
            myExcelSheet.get_Range("C" + int_Index, System.Reflection.Missing.Value).Value2 = "校对：";
            myExcelSheet.get_Range("E" + int_Index, System.Reflection.Missing.Value).Value2 = "军代表：";

            int_Index = int_Index + 2;
            myRange = myExcelSheet.get_Range("A" + int_Index, "H" + int_Index);
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignTop;
            myRange.Merge(System.Reflection.Missing.Value);
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignRight;
            myExcelSheet.get_Range("A" + int_Index, System.Reflection.Missing.Value).Value2 = "江南造船焊工考试委员会";
            int_Index++;
            myExcelSheet.get_Range("H" + int_Index, System.Reflection.Missing.Value).Value2 = DateTime.Today.ToShortDateString();

            myExcelSheet.Application.Visible = true;
        }

        private void button_ExportWelderPictureToWord_Click(object sender, EventArgs e)
        {
            DataView  myDataView_Temp=new DataView( this.myDataTable );
            if (this.checkBox_ExportWelderPictureWithPassed.Checked)
            {
                myDataView_Temp.RowFilter = "ExamSubjectID is Not Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            }
            if (this.checkBox_SortbyWelderName.Checked)
            {
                myDataView_Temp.Sort = "WelderName";
            }
            else
            {
                myDataView_Temp.Sort = "IssueNo, ExaminingNo";
            }
            Class_Welder.ExportWelderPictureToWord(myDataView_Temp);

        }

        private void button_ExportWelderPictureToFile_Click(object sender, EventArgs e)
        {
            DataView myDataView_Temp = new DataView(this.myDataTable);
            //myDataView_Temp.RowFilter = "ExamSubjectID is Not Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            myDataView_Temp.Sort = "IssueNo, ExaminingNo";
            SaveFileDialog myForm = new SaveFileDialog();
            myForm.Filter = "JPG files (*.JPG)|*.JPG";
            myForm.RestoreDirectory = true;
            myForm.FileName = "身份证号码-证号-姓名";
            if (myForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string str_Path = Path.GetDirectoryName(myForm.FileName);
            string str_TempFileName;
            Image myImage_WelderPicture;

            //获取所有焊工照片文件名
            //string[] str_FileNames = Class_Welder.GetWelderPictureFileNames();
            //Random myRandom = new Random();
            //ArrayList myArrayList = new ArrayList();
            //string str_IdentificationCard;
            //Regex myRegex=new Regex("\\d{17}[0-9X]");
            //Match myMatch;
            //int i_Random;
            //foreach (string str_FileName in str_FileNames)
            //{
            //    myMatch=myRegex.Match(str_FileName);
            //    if(myMatch.Success)
            //    {
            //        str_IdentificationCard = myMatch.Value;
            //        if (this.myDataTable.Select(string.Format("IdentificationCard='{0}'", str_IdentificationCard)).Length == 0)
            //        {
            //            myArrayList.Add(str_FileName);
            //        }
            //    }                
            //}

            foreach (DataRowView myDataRowView in myDataView_Temp)
            {
                myImage_WelderPicture = Class_Welder.GetWelderPicture(myDataRowView["IdentificationCard"].ToString());
                if (myImage_WelderPicture != null)
                {
                    str_TempFileName = Path.Combine(str_Path, myDataRowView["IdentificationCard"].ToString() + "-" + myDataRowView["CertificateNo"].ToString() + "-" + myDataRowView["WelderName"].ToString() + ".JPG");
                    File.Delete(str_TempFileName);
                    myImage_WelderPicture.Save(str_TempFileName);
                }
                else
                {
                    //如果没有该焊工照片文件，则随机抽取一个文件作为本焊工的照片文件
                    //i_Random = myRandom.Next(myArrayList.Count );
                    //myImage_WelderPicture = Class_Welder.GetWelderPicturebyFileName(myArrayList[i_Random].ToString());
                    //myArrayList.RemoveAt (i_Random);
                    //str_TempFileName = Path.Combine(str_Path, myDataRowView["IdentificationCard"].ToString() + "-" + myDataRowView["CertificateNo"].ToString() + "-" + myDataRowView["WelderName"].ToString() + ".JPG");
                    //File.Delete(str_TempFileName);
                    //myImage_WelderPicture.Save(str_TempFileName);
                }
            }
            MessageBox.Show("导出成功！");

        }

        private void button_ExportExcel_Click(object sender, EventArgs e)
        {
            DataView myDataView = new DataView(this.myDataTable);
            myDataView.RowFilter = "ExamSubjectID is Not Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            myDataView.Sort = "IssueNo, ExaminingNo";

            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Add(ZCExcel.XlWBATemplate.xlWBATWorksheet);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];
            ZCExcel.Range myRange;
            int int_Index;

            myExcelSheet.get_Range("A1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("B1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("C1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("D1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("E1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("F1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("G1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("H1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("I1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("J1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("K1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("L1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("M1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("N1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("O1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("P1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("Q1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("R1", System.Reflection.Missing.Value).ColumnWidth = 6;
            myExcelSheet.get_Range("S1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("T1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("U1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("V1", System.Reflection.Missing.Value).ColumnWidth = 8;
            myExcelSheet.get_Range("W1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("X1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myExcelSheet.get_Range("Y1", System.Reflection.Missing.Value).ColumnWidth = 4;
            myExcelSheet.get_Range("Z1", System.Reflection.Missing.Value).ColumnWidth = 10;
            myRange = myExcelSheet.get_Range("A1", "Z1");
            myRange.RowHeight = 32;
            myRange.HorizontalAlignment = ZCExcel.XlHAlign.xlHAlignCenter;
            myRange.VerticalAlignment = ZCExcel.XlVAlign.xlVAlignCenter;
            myRange.WrapText = true;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlContinuous;

            int_Index = 1;
            myExcelSheet.get_Range("A" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "考编号";
            myExcelSheet.get_Range("B" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "期数";
            myExcelSheet.get_Range("C" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "焊接方法";
            myExcelSheet.get_Range("D" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "姓名";
            myExcelSheet.get_Range("E" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "性别";
            myExcelSheet.get_Range("F" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "部门";
            myExcelSheet.get_Range("G" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "劳务队";
            myExcelSheet.get_Range("H" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "母材";
            myExcelSheet.get_Range("I" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "焊接材料";
            myExcelSheet.get_Range("J" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "装配";
            myExcelSheet.get_Range("K" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "焊工等级";
            myExcelSheet.get_Range("L" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "厚度";
            myExcelSheet.get_Range("M" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "管径";
            myExcelSheet.get_Range("N" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "考委会号";
            myExcelSheet.get_Range("O" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "科目";
            myExcelSheet.get_Range("P" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "理论成绩";
            myExcelSheet.get_Range("Q" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "理补成绩";
            myExcelSheet.get_Range("R" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "考试方式";
            myExcelSheet.get_Range("S" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "身份证";
            myExcelSheet.get_Range("T" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "作业区";
            myExcelSheet.get_Range("U" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "公司";
            myExcelSheet.get_Range("V" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "工号";
            myExcelSheet.get_Range("W" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "证号";
            myExcelSheet.get_Range("X" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "发证日期";
            myExcelSheet.get_Range("Y" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "有效期";
            myExcelSheet.get_Range("Z" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = "有效期至";
            myExcelSheet.get_Range("S:S", System.Reflection.Missing.Value).NumberFormatLocal = "@";

            foreach (DataRowView myDataRowView in myDataView)
            {
                if (string.IsNullOrEmpty(myDataRowView["RegistrationNo"].ToString()))
                {
                    myDataRowView["RegistrationNo"] = Class_TestCommitteeRegistrationNo.AutoFill(Properties.Settings.Default.CCSTestCommitteeID, myDataRowView["IdentificationCard"].ToString());
                }
                int_Index++;
                myExcelSheet.get_Range("A" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["ExaminingNo"];
                myExcelSheet.get_Range("B" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["IssueNo"];
                myExcelSheet.get_Range("C" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WeldingProcessAb"];
                myExcelSheet.get_Range("D" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderName"];
                myExcelSheet.get_Range("E" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["Sex"];
                myExcelSheet.get_Range("F" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderDepartment"];
                myExcelSheet.get_Range("G" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderLaborServiceTeam"];
                myExcelSheet.get_Range("H" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentMaterial"];
                myExcelSheet.get_Range("I" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentWeldingConsumable"];
                myExcelSheet.get_Range("J" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentAssemblage"];
                myExcelSheet.get_Range("K" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WeldingProjectAb"].ToString() + myDataRowView["WeldingClassAb"].ToString();
                myExcelSheet.get_Range("L" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentThickness"].ToString();
                myExcelSheet.get_Range("M" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentExternalDiameter"].ToString();
                myExcelSheet.get_Range("N" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["RegistrationNo"];
                myExcelSheet.get_Range("O" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["Subject"];
                myExcelSheet.get_Range("P" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["TheoryResult"];
                myExcelSheet.get_Range("Q" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["TheoryMakeupResult"];
                myExcelSheet.get_Range("R" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["StudentKindofExam"];
                myExcelSheet.get_Range("S" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["IdentificationCard"];
                myExcelSheet.get_Range("T" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderWorkPlace"];
                myExcelSheet.get_Range("U" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderEmployer"];
                myExcelSheet.get_Range("V" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["WelderWorkerID"];
                if (myDataRowView["CertificateNo"] != DBNull.Value)
                {
                    myExcelSheet.get_Range("W" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["CertificateNo"];
                    myExcelSheet.get_Range("X" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = ((DateTime)myDataRowView["IssuedOn"]).ToShortDateString();
                    myExcelSheet.get_Range("Y" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = myDataRowView["PeriodofValidity"];
                    myExcelSheet.get_Range("Z" + int_Index.ToString(), System.Reflection.Missing.Value).Value2 = ((DateTime)myDataRowView["ValidUntil"]).ToShortDateString();
                }
            }

            myRange = myExcelSheet.get_Range("A2", "Z" + int_Index.ToString());
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeLeft].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeTop].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeBottom].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            myRange.Borders[ZCExcel.XlBordersIndex.xlEdgeRight].LineStyle = ZCExcel.XlLineStyle.xlContinuous;
            if (int_Index > 2)
            {
                myRange.Borders[ZCExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = ZCExcel.XlLineStyle.xlDot;
            }
            myRange.Borders[ZCExcel.XlBordersIndex.xlInsideVertical].LineStyle = ZCExcel.XlLineStyle.xlDot;

            myExcelApp.Visible = true;
        }

        private void button_ExportCCSWordOld_Click(object sender, EventArgs e)
        {
            DataView myDataView = new DataView(this.myDataTable);
            myDataView.RowFilter = "CertificateNo is Not Null";
            myDataView.Sort = "IssueNo, ExaminingNo";
            if (myDataView.Count == 0)
            {
                MessageBox.Show("没有证书！");
                return;
            }

            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\CCS焊工资格证书.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            int i;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            Image myImage_WelderPicture;
            string str_TempFileName;

            string   str_Thickness ;
            string str_ExternalDiameter ;
            double dbl_Thickness;
            double dbl_ExternalDiameter ;

            foreach (DataRowView myDataRowView in myDataView)
            {
                myImage_WelderPicture = Class_Welder.GetWelderPicture(myDataRowView["IdentificationCard"].ToString());
                myWordDocument.Tables[2].Cell(1, 5).Range.Select();
                myWordApp.Selection.Delete(ref oMissing, ref oMissing);
                if (myImage_WelderPicture != null)
                {
                    str_TempFileName = Path.Combine(Path.GetTempPath(), myDataRowView["WelderName"].ToString() + "_" + myDataRowView["IdentificationCard"].ToString() + ".JPG");
                    File.Delete(str_TempFileName);
                    myImage_WelderPicture.Save(str_TempFileName);
                    myWordDocument.Tables[2].Cell(1, 5).Select();
                    ZCWord.InlineShape myInlineShape = myWordApp.Selection.InlineShapes.AddPicture(str_TempFileName, ref oMissing, ref oMissing, ref oMissing);
                    myInlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                }

                myWordDocument.Tables[1].Cell(2, 2).Range.Text = myDataRowView["CertificateNo"].ToString();
                myWordDocument.Tables[2].Cell(1, 2).Range.Text = myDataRowView["WelderName"].ToString();
                myWordDocument.Tables[2].Cell(2, 2).Range.Text = myDataRowView["IdentificationCard"].ToString();
                myWordDocument.Tables[2].Cell(3, 2).Range.Text = myDataRowView["WelderEmployer"].ToString();
                myWordDocument.Tables[2].Cell(1, 4).Range.Text = myDataRowView["Sex"].ToString();
                myWordDocument.Tables[2].Cell(2, 4).Range.Text = Class_DataValidateTool.GetBirthdaybyIdentificationCard(myDataRowView["IdentificationCard"].ToString()).ToString("yyyy-M-d");
                myWordDocument.Tables[2].Cell(3, 4).Range.Text = myDataRowView["WeldingProjectAb"].ToString() + myDataRowView["WeldingClassAb"].ToString();
                myWordDocument.Tables[2].Cell(4, 4).Range.Text = myDataRowView["RegistrationNo"].ToString();
                myWordDocument.Tables[2].Cell(7, 2).Range.Text = myDataRowView["ScopeofWeldingProject"].ToString();
                myWordDocument.Tables[2].Cell(8, 2).Range.Text = myDataRowView["ScopeofCCSWeldingProcess"].ToString();
                myWordDocument.Tables[2].Cell(9, 2).Range.Text = myDataRowView["ScopeofSubject"].ToString();
                myWordDocument.Tables[2].Cell(10, 2).Range.Text = myDataRowView["ScopeofMaterialCCSGroup"].ToString();
                myWordDocument.Tables[2].Cell(11, 2).Range.Text = myDataRowView["ScopeofWeldingConsumableCCSGroup"].ToString();
                if (myDataRowView["JointType"].ToString() == "对接接头")
                {
                    myWordDocument.Tables[2].Cell(14, 2).Range.Text = myDataRowView["ScopeofCCSAssemblage"].ToString();
                }
                else
                {
                    myWordDocument.Tables[2].Cell(14, 2).Range.Text = "";
                }
                if (myDataRowView["WeldingClass"].ToString() == "TW")
                {
                    myWordDocument.Tables[2].Cell(14, 2).Range.Text = "";
                }
                if ((int)myDataRowView["PeriodofValidity"] >= 100)
                {
                    myWordDocument.Tables[2].Cell(15, 2).Range.Text = "长期有效";
                }
                else
                {
                    myWordDocument.Tables[2].Cell(15, 2).Range.Text = ((DateTime)myDataRowView["ValidUntil"]).ToString("yyyy-M-d");
                }
                myWordDocument.Tables[2].Cell(19, 2).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).ToString("yyyy-M-d");
                str_Thickness = "";
                str_ExternalDiameter = "";
                dbl_Thickness = 0;
                dbl_ExternalDiameter = 0;
                double.TryParse(myDataRowView["StudentThickness"].ToString(), out dbl_Thickness);
                double.TryParse(myDataRowView["StudentExternalDiameter"].ToString(), out dbl_ExternalDiameter);

                switch (myDataRowView["WorkPieceType"].ToString())
                {
                    case "板":
                        if (System.Text.RegularExpressions.Regex.IsMatch(myDataRowView["MaterialCCSGroupAb"].ToString(), "铝"))
                        {
                            str_Thickness = Class_Student.GetAlScopeofCCSThickness(dbl_Thickness);
                        }
                        else if (System.Text.RegularExpressions.Regex.IsMatch(myDataRowView["MaterialCCSGroupAb"].ToString(), "W3"))
                        {
                            str_Thickness = Class_Student.GetCuScopeofCCSThickness(dbl_Thickness);
                        }
                        else
                        {
                            str_Thickness = Class_Student.GetScopeofCCSThickness(dbl_Thickness);
                        }
                        if (myDataRowView["WeldingClass"].ToString() == "TW")
                        {
                            str_Thickness = "";
                        }
                        if (myDataRowView["WeldingProcessAb"].ToString() == "SAW")
                        {
                            str_Thickness = "厚度范围不限";
                        }
                        break;                        
                    default:
                        if (System.Text.RegularExpressions.Regex.IsMatch(myDataRowView["MaterialCCSGroup"].ToString(), "铝"))
                        {
                            str_Thickness = Class_Student.GetAlScopeofCCSThickness(dbl_Thickness);
                        }
                        else
                        {
                            str_Thickness = Class_Student.GetScopeofCCSThickness(dbl_Thickness);
                        }
                        str_ExternalDiameter = Class_Student.GetScopeofCCSExternalDiameter(dbl_ExternalDiameter);
                        break;
                }

                myWordDocument.Tables[2].Cell(12, 2).Range.Text = str_Thickness;
                myWordDocument.Tables[2].Cell(13, 2).Range.Text = str_ExternalDiameter;

                myWordDocument.Tables[3].Cell(23, 1).Range.Text = myDataRowView["SupervisionPlace"].ToString();
                myWordDocument.Tables[3].Cell(24, 1).Range.Text = myDataRowView["SupervisionPlace"].ToString();
                myWordDocument.Tables[3].Cell(25, 1).Range.Text = myDataRowView["SupervisionPlace"].ToString();
                myWordDocument.Tables[3].Cell(23, 5).Range.Text = myDataRowView["SupervisionPlace"].ToString();
                myWordDocument.Tables[3].Cell(24, 5).Range.Text = myDataRowView["SupervisionPlace"].ToString();
                myWordDocument.Tables[3].Cell(25, 5).Range.Text = myDataRowView["SupervisionPlace"].ToString();
                myWordDocument.Tables[3].Cell(28, 1).Range.Text = myDataRowView["SupervisionPlace"].ToString();
                myWordDocument.Tables[3].Cell(23, 2).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).AddMonths(6 ).ToString("yyyy年M月");
                myWordDocument.Tables[3].Cell(24, 2).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).AddMonths(12).ToString("yyyy年M月");
                myWordDocument.Tables[3].Cell(25, 2).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).AddMonths(18 ).ToString("yyyy年M月");
                myWordDocument.Tables[3].Cell(23, 6).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).AddMonths(24).ToString("yyyy年M月");
                myWordDocument.Tables[3].Cell(24, 6).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).AddMonths(30 ).ToString("yyyy年M月");
                myWordDocument.Tables[3].Cell(25, 6).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).AddMonths(42).ToString("yyyy年M月");
                myWordDocument.Tables[3].Cell(28, 2).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).AddMonths(36).ToString("yyyy年M月");

                str_BookmarkName = "first";
                Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                str_BookmarkName = "last";
                Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                myRange.Copy();
                myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                myWordDocument.Application.Selection.Paste();
            }

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
            myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;
        }

        private void button_ExportDNVQCWord_Click(object sender, EventArgs e)
        {
            DataView myDataView = new DataView(this.myDataTable);
            myDataView.RowFilter = "CertificateNo is Not Null";
            myDataView.Sort = "IssueNo, ExaminingNo";
            if (myDataView.Count == 0)
            {
                MessageBox.Show("没有证书！");
                return;
            }

            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\DNV焊工证书.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            int i;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            string str_Thickness = "";
            string str_ExternalDiameter = "";
            Image myImage_WelderPicture;
            string str_TempFileName;

            foreach (DataRowView myDataRowView in myDataView)
            {
                //myImage_WelderPicture = Class_Welder.GetWelderPicture(myDataRowView["IdentificationCard"].ToString());
                //myWordDocument.Tables[1].Cell(1, 3).Range.Select();
                //myWordApp.Selection.Delete(ref oMissing, ref oMissing);
                //if (myImage_WelderPicture != null)
                //{
                //    str_TempFileName = Path.Combine(Path.GetTempPath(), myDataRowView["WelderName"].ToString() + "_" + myDataRowView["IdentificationCard"].ToString() + ".JPG");
                //    File.Delete(str_TempFileName);
                //    myImage_WelderPicture.Save(str_TempFileName);
                //    myWordDocument.Tables[1].Cell(1, 3).Select();
                //    ZCWord.InlineShape myInlineShape = myWordApp.Selection.InlineShapes.AddPicture(str_TempFileName, ref oMissing, ref oMissing, ref oMissing);
                //    myInlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                //}

                //myWordDocument.Tables[2].Cell(3, 2).Range.Text = myDataRowView["WelderEnglishName"].ToString() + ", "+ myDataRowView["IdentificationCard"].ToString();
                //myWordDocument.Tables[1].Cell(2, 2).Range.Text = myDataRowView["WelderEmployerEnglish"].ToString();
                //if (myDataRowView["WelderEnglishName"] == DBNull.Value)
                //{
                //    myWordDocument.Tables[1].Cell(3, 2).Range.Text = myDataRowView["WelderName"].ToString();
                //}
                //else
                //{
                //    myWordDocument.Tables[1].Cell(3, 2).Range.Text = myDataRowView["WelderEnglishName"].ToString();
                //}
                //myWordDocument.Tables[1].Cell(4, 2).Range.Text = myDataRowView["IdentificationCard"].ToString();

                //myWordDocument.Tables[1].Cell(6, 2).Range.Text = Class_DataValidateTool.GetBirthdaybyIdentificationCard(myDataRowView["IdentificationCard"].ToString()).ToShortDateString() + ",China";

                //myWordDocument.Tables[3].Cell(2, 1).Range.Text = myDataRowView["ExaminingNo"].ToString();

                //myWordDocument.Tables[3].Cell(13, 2).Range.Text = myDataRowView["WeldingProcessAb"].ToString();
                //myWordDocument.Tables[3].Cell(14, 2).Range.Text = myDataRowView["StudentWeldingConsumable"].ToString() + "(at approval test)";
                //myWordDocument.Tables[3].Cell(15, 2).Range.Text = myDataRowView["ScopeofMaterialISOGroup"].ToString();
                //myWordDocument.Tables[3].Cell(20, 2).Range.Text = myDataRowView["ScopeofSubject"].ToString() + " positions in butt / fillet welding";
                //myWordDocument.Tables[3].Cell(21, 2).Range.Text = myDataRowView["ScopeofISOAssemblage"].ToString();

                //if (myDataRowView["WorkPieceType"].ToString() == "板")
                //{
                //    double dbl_StudentThickness;
                //    double.TryParse(myDataRowView["StudentThickness"].ToString(), out dbl_StudentThickness);
                //    if (dbl_StudentThickness > 0)
                //    {
                //        str_Thickness = Class_Student.GetScopeofISOThickness(dbl_StudentThickness);
                //    }
                //    else
                //    {
                //        str_Thickness = "t≥5mm";
                //    }
                //    str_ExternalDiameter = "";
                //}
                //else
                //{
                //    double dbl_StudentThickness;
                //    double dbl_ExternalDiameter;
                //    double.TryParse(myDataRowView["StudentThickness"].ToString(), out dbl_StudentThickness);
                //    if (dbl_StudentThickness > 0)
                //    {
                //        str_Thickness = Class_Student.GetScopeofISOThickness(dbl_StudentThickness);
                //    }
                //    else
                //    {
                //        str_Thickness = "t≥5mm";
                //    }
                //    double.TryParse(myDataRowView["StudentExternalDiameter"].ToString(), out dbl_ExternalDiameter);
                //    str_ExternalDiameter = Class_Student.GetScopeofISOExternalDiameter(dbl_ExternalDiameter);
                //}

                //myWordDocument.Tables[3].Cell(18, 2).Range.Text = str_Thickness;
                //myWordDocument.Tables[3].Cell(19, 2).Range.Text = str_ExternalDiameter;

                //if (myDataRowView["IssuedOn"] != DBNull.Value)
                //{
                //    myWordDocument.Tables[4].Cell(1, 2).Range.Text = ((DateTime)myDataRowView["IssuedOn"]).ToShortDateString() + ", China";
                //    myWordDocument.Tables[4].Cell(1, 4).Range.Text = ((DateTime)myDataRowView["ValidUntil"]).ToShortDateString();
                //}

                break;
                //str_BookmarkName = "first";
                //Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                //str_BookmarkName = "last";
                //Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                //myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                //myRange.Copy();
                //myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                //myWordDocument.Application.Selection.Paste();
            }

            //str_BookmarkName = "first";
            //Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            //str_BookmarkName = "last";
            //Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            //myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            //myRange.Delete(ref oMissing, ref oMissing);

            //myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            //myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;
        }

        private void button_ExportCCSSignAccess_Click(object sender, EventArgs e)
        {
            string str_SQL;
            //string str_Regex = string.Format("^{0}-SING-{1}-\\d{{5}}$", Properties.Settings.Default.CCSTestCommitteeID, DateTime.Today.Year.ToString().Substring(2, 2));
            string str_Regex = string.Format("^{0}-SING-\\d{{2}}-\\d{{5}}$", Properties.Settings.Default.CCSTestCommitteeID);
            string str_Conn;
            string str_FileName;
            OleDbConnection myConn_Temp;
            OleDbCommand myCmd_Temp;

            DataView myDataView = new DataView(this.myDataTable);
            myDataView.RowFilter = "CertificateNo is not Null";
            myDataView.Sort = "CertificateNo";

            Class_ExamField.RefreshData();
            if (System.Text.RegularExpressions.Regex.IsMatch(Class_ExamField.CCSSIGNNo, str_Regex))
            {
                Class_ExamField.CCSSIGNNo = string.Format("{0}-SING-{1}-{2}", Properties.Settings.Default.CCSTestCommitteeID, DateTime.Today.Year.ToString().Substring(2, 2), Class_ExamField.CCSSIGNNo.Substring(Class_ExamField.CCSSIGNNo .Length-5,5));
            }
            else
            {
                Class_ExamField.CCSSIGNNo = string.Format("{0}-SING-{1}-00001", Properties.Settings.Default.CCSTestCommitteeID, DateTime.Today.Year.ToString().Substring(2, 2));
            }
            SaveFileDialog myForm = new SaveFileDialog();
            myForm.Filter = "Access files (*.mdb)|*.mdb";
            myForm.FileName =string.Format("{0}({1})-{2}人",Class_ExamField.CCSSIGNNo , DateTime.Today.ToShortDateString() ,myDataView.Count) ;
            myForm.RestoreDirectory = true;
            if (myForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            str_FileName = string.Format("{0}\\Data\\CCSSIGN.mdb", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            File.Copy(str_FileName, myForm.FileName, true);
            FileInfo fileInfo = new FileInfo(myForm.FileName);
            if (!fileInfo.Exists)
            {
                MessageBox.Show("创建文件失败，请确认是否具有相应权限！");
                return;
            }

            str_Conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + myForm.FileName + ";Persist Security Info=True";
            myConn_Temp = new OleDbConnection(str_Conn);
            try
            {
                myConn_Temp.Open();
                myCmd_Temp = new OleDbCommand("Delete FROM TB_Certificate_Record", myConn_Temp);
                myCmd_Temp.ExecuteNonQuery();
                myCmd_Temp = new OleDbCommand("Delete FROM TB_Visa_Details", myConn_Temp);
                myCmd_Temp.ExecuteNonQuery();
                myCmd_Temp = new OleDbCommand("Delete FROM TB_Visa_Info", myConn_Temp);
                myCmd_Temp.ExecuteNonQuery();

                str_SQL = "Insert Into TB_Visa_Info ( QID, Workno, HWHName, ApplyDate) Values(?,?,?,?)";
                myCmd_Temp = new OleDbCommand(str_SQL, myConn_Temp);
                myCmd_Temp.Parameters.Add("@QID", OleDbType.Char, 20).Value = Class_ExamField.CCSSIGNNo;
                myCmd_Temp.Parameters.Add("@Workno", OleDbType.Char, 50).Value = DBNull.Value;
                myCmd_Temp.Parameters.Add("@HWHName", OleDbType.Char, 50).Value = Properties.Settings.Default.CCSTestCommittee;
                myCmd_Temp.Parameters.Add("@ApplyDate", OleDbType.Date).Value = DateTime.Today.Date;
                myCmd_Temp.ExecuteNonQuery();
                
                str_SQL = "Insert Into TB_Visa_Details ( QID, CerNo, WelderName) Values(?,?,?)";
                myCmd_Temp = new OleDbCommand(str_SQL, myConn_Temp);
                myCmd_Temp.Parameters.Add("@QID", OleDbType.Char, 20);
                myCmd_Temp.Parameters.Add("@CerNo", OleDbType.Char, 20);
                myCmd_Temp.Parameters.Add("@WelderName", OleDbType.Char, 10);
                foreach (DataRowView myDataRowView in myDataView)
                {
                    myCmd_Temp.Parameters["@QID"].Value = Class_ExamField.CCSSIGNNo;
                    myCmd_Temp.Parameters["@CerNo"].Value = myDataRowView["CertificateNo"];
                    myCmd_Temp.Parameters["@WelderName"].Value = myDataRowView["WelderName"];
                    myCmd_Temp.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConn_Temp.Close();
            }

            Class_ExamField.CCSSIGNNo = Class_Tools.GetNextSequence(Class_ExamField.CCSSIGNNo, 5);
            Class_ExamField.UpdateField();
            MessageBox.Show("操作完毕！");
        }

        private void button_ExcelofExamNeed_Click(object sender, EventArgs e)
        {
            Class_Issue.ExportSkillExamNeed(new DataView( this.myDataTable ));

        }

        private void button_ExportWelderQC_Click(object sender, EventArgs e)
        {
            Form_Report_WelderQC myForm = new Form_Report_WelderQC();
            myForm.myDataTable = this.myDataTable;
            myForm.ShowDialog();

        }

        private void button_LR_Click(object sender, EventArgs e)
        {
            DataView myDataView_SubjectPositionResult;
            DataView myDataView = new DataView(this.myDataTable);
            //myDataView.RowFilter = "CertificateNo is Not Null";
            myDataView.RowFilter = "SkillResult or SkillMakeupResult";
            myDataView.Sort = "IssueNo, ExaminingNo";
            if (myDataView.Count == 0)
            {
                MessageBox.Show("没有证书！");
                return;
            }

            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\LR焊工证书.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            int i;
            object str_BookmarkName;
            object Bookmark_Start;
            object Bookmark_End;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            Image myImage_WelderPicture;
            string str_TempFileName;

            string str_Thickness;
            string str_ExternalDiameter;
            double dbl_Thickness;
            double dbl_ExternalDiameter;

            foreach (DataRowView myDataRowView in myDataView)
            {
                myImage_WelderPicture = Class_Welder.GetWelderPicture(myDataRowView["IdentificationCard"].ToString());
                myWordDocument.Tables[5].Cell(2, 3).Range.Select();
                myWordApp.Selection.Delete(ref oMissing, ref oMissing);
                if (myImage_WelderPicture != null)
                {
                    str_TempFileName = Path.Combine(Path.GetTempPath(), myDataRowView["WelderName"].ToString() + "_" + myDataRowView["IdentificationCard"].ToString() + ".JPG");
                    File.Delete(str_TempFileName);
                    myImage_WelderPicture.Save(str_TempFileName);
                    myWordDocument.Tables[5].Cell(2, 3).Select();
                    ZCWord.InlineShape myInlineShape = myWordApp.Selection.InlineShapes.AddPicture(str_TempFileName, ref oMissing, ref oMissing, ref oMissing);
                    myInlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                }

                myWordDocument.Tables[1].Cell(1, 3).Range.Text = myDataRowView["CertificateNo"].ToString();
                myWordDocument.Tables[1].Cell(5, 2).Range.Text = myDataRowView["WelderEmployerEnglish"].ToString();
                myWordDocument.Tables[1].Cell(7, 1).Range.Text =  myDataRowView["WelderEmployerAddressEnglish"].ToString();
                myWordDocument.Tables[1].Cell(7, 3).Range.Text = DateTime.Today.ToString("d MMMM yyyy",System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                myWordDocument.Tables[1].Cell(8, 3).Range.Text = myDataRowView["WelderEnglishName"].ToString();
                myWordDocument.Tables[1].Cell(9, 3).Range.Text = myDataRowView["WelderWorkerID"].ToString();
                myWordDocument.Tables[1].Cell(10, 3).Range.Text = myDataRowView["ExaminingNo"].ToString();
                myWordDocument.Tables[1].Cell(12, 2).Range.Text = Class_DataValidateTool.GetBirthdaybyIdentificationCard(myDataRowView["IdentificationCard"].ToString()).ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) + " / " + myDataRowView["IdentificationCard"].ToString();
                myWordDocument.Tables[1].Cell(13, 2).Range.Text = myDataRowView["WPSNo"].ToString();
                myWordDocument.Tables[1].Cell(13, 4).Range.Text = "0";
                //myWordDocument.Tables[1].Cell(13, 6).Range.Text = myDataRowView["WelderName"].ToString();
                if (myDataRowView["IssuedOn"] == DBNull.Value)
                {
                    if (((bool)myDataRowView["SkillResult"] == true) && (myDataRowView["SkillExamDate"]!=DBNull.Value ))
                    {
                        myWordDocument.Tables[1].Cell(14, 2).Range.Text = DateTime.Parse(myDataRowView["SkillExamDate"].ToString()).AddYears(2).AddDays(-1).ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                        myWordDocument.Tables[1].Cell(15, 4).Range.Text = DateTime.Parse(myDataRowView["SkillExamDate"].ToString()).ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                    }
                    else if (((bool)myDataRowView["SkillMakeupResult"] == true) && (myDataRowView["SkillMakeupDate"] != DBNull.Value))
                    {
                        myWordDocument.Tables[1].Cell(14, 2).Range.Text = DateTime.Parse(myDataRowView["SkillMakeupDate"].ToString()).AddYears(2).AddDays(-1).ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                        myWordDocument.Tables[1].Cell(15, 4).Range.Text = DateTime.Parse(myDataRowView["SkillMakeupDate"].ToString()).ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                    }
                }
                else
                {
                    myWordDocument.Tables[1].Cell(14, 2).Range.Text = DateTime.Parse(myDataRowView["ValidUntil"].ToString()).ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                    myWordDocument.Tables[1].Cell(15, 4).Range.Text = DateTime.Parse(myDataRowView["IssuedOn"].ToString()).ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                }

                myWordDocument.Tables[1].Cell(19, 1).Range.Text = string.Format("{0} / {1}", myDataRowView["StudentMaterial"], myDataRowView["MaterialLRGroupAb"]);
                myWordDocument.Tables[1].Cell(19, 2).Range.Text = string.Format("{0} / {1}", myDataRowView["StudentMaterial"], myDataRowView["MaterialLRGroupAb"]);
                if (!string.IsNullOrEmpty(myDataRowView["WeldingConsumableGBName"].ToString()))
                {
                    myWordDocument.Tables[1].Cell(21, 1).Range.Text = string.Format("{0} / GB {1}", myDataRowView["StudentWeldingConsumable"], myDataRowView["WeldingConsumableGBName"]);
                }
                else if (!string.IsNullOrEmpty(myDataRowView["WeldingConsumableAWSName"].ToString()))
                {
                    myWordDocument.Tables[1].Cell(21, 1).Range.Text = string.Format("{0} / AWS {1}", myDataRowView["StudentWeldingConsumable"], myDataRowView["WeldingConsumableAWSName"]);
                }
                else
                {
                    myWordDocument.Tables[1].Cell(21, 1).Range.Text = string.Format("{0}", myDataRowView["StudentWeldingConsumable"]);
                }
                myWordDocument.Tables[1].Cell(21, 2).Range.Text = string.Format("{0}", myDataRowView["ProtectGas"]);

                myWordDocument.Tables[2].Cell(1, 1).Range.Select();
                myWordApp.Selection.Delete(ref oMissing, ref oMissing);
                if (myDataRowView["WPSNo"] != DBNull.Value)
                {
                    Class_WPS myClass_WPS = new Class_WPS(myDataRowView["WPSNo"].ToString());
                    myDataTable = myClass_WPS.GetpWPSImage(null, "WPSImageID");
                    if (myDataTable.Select("WPSImageGroup='坡口装配图'").Length > 0)
                    {
                        Class_WPSImage myClass_WPSImage = new Class_WPSImage((int)myDataTable.Select("WPSImageGroup='坡口装配图'")[0]["WPSImageID"]);
                        str_TempFileName = Path.Combine(Path.GetTempPath(), myClass_WPSImage.WPSImageName);
                        myClass_WPSImage.WPSImage.Save(str_TempFileName);
                        myWordDocument.Tables[2].Cell(1, 1).Select();
                        ZCWord.InlineShape myInlineShape = myWordApp.Selection.InlineShapes.AddPicture(str_TempFileName, ref oMissing, ref oMissing, ref oMissing);
                        myInlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                        //myInlineShape.Height =200;
                    }
                }

                myWordDocument.Tables[3].Cell(3, 2).Range.Text = string.Format("{0}", myDataRowView["WeldingProcessNo"]);
                myWordDocument.Tables[3].Cell(3, 3).Range.Text = string.Format("{0}", myDataRowView["WeldingProcessNo"]);
                if (myDataRowView["WorkPieceType"].ToString() == "板")
                {
                    myWordDocument.Tables[3].Cell(4, 2).Range.Text = "Plate";
                    myWordDocument.Tables[3].Cell(4, 3).Range.Text = "Plate";
                    myWordDocument.Tables[3].Cell(3, 5).Range.Text ="";
                }
                else
                {
                    myWordDocument.Tables[3].Cell(4, 2).Range.Text = "Pipe";
                    myWordDocument.Tables[3].Cell(4, 3).Range.Text = "Pipe";
                    myWordDocument.Tables[3].Cell(3, 5).Range.Text = myDataRowView["StudentExternalDiameter"].ToString();
                }
                myWordDocument.Tables[3].Cell(5, 2).Range.Text = myDataRowView["StudentThickness"].ToString();
                myWordDocument.Tables[3].Cell(5, 3).Range.Text = ">=5";
                if (myDataRowView["ISOJointType"].ToString() == "BW")
                {
                    myWordDocument.Tables[3].Cell(7, 2).Range.Text = "Butt";
                    myWordDocument.Tables[3].Cell(7, 3).Range.Text = "Butt and Fillet";
                }
                else
                {
                    myWordDocument.Tables[3].Cell(7, 2).Range.Text = "Fillet";
                    myWordDocument.Tables[3].Cell(7, 3).Range.Text = "Fillet";
                }
                myWordDocument.Tables[3].Cell(3, 5).Range.Text = "N/A";
                myWordDocument.Tables[3].Cell(3, 6).Range.Text = ">=500";

                myWordDocument.Tables[3].Cell(4, 5).Range.Text = myDataRowView["Subject"].ToString();
                myWordDocument.Tables[3].Cell(4, 6).Range.Text = myDataRowView["ScopeofSubject"].ToString();
                switch (myDataRowView["ISOAssemblage"].ToString())
                {
                    case "mb":
                        myWordDocument.Tables[3].Cell(5, 5).Range.Text = "Temporary Backing";
                        myWordDocument.Tables[3].Cell(5, 6).Range.Text = "Backing & Gouging";
                        break;
                    case "gg":
                        myWordDocument.Tables[3].Cell(5, 5).Range.Text = "Gouging";
                        myWordDocument.Tables[3].Cell(5, 6).Range.Text = "Backing & Gouging";
                        break;
                    default:
                        myWordDocument.Tables[3].Cell(5, 5).Range.Text = "N/A";
                        myWordDocument.Tables[3].Cell(5, 6).Range.Text = "All";
                        break;
                }
                if (myDataRowView["ISOWeldingSide"].ToString() == "ss")
                {
                    myWordDocument.Tables[3].Cell(6, 5).Range.Text = "One Side";
                    myWordDocument.Tables[3].Cell(6, 6).Range.Text = "One / Both Sides";
                }
                else
                {
                    myWordDocument.Tables[3].Cell(6, 5).Range.Text = "Both Side";
                    myWordDocument.Tables[3].Cell(6, 6).Range.Text = "Both Sides";
                }

                myDataView_SubjectPositionResult = new DataView(Class_Student.GetDataTable_SubjectPositionResult(myDataRowView["ExaminingNo"].ToString(), null, "WeldingPosition"));
                myWordDocument.Tables[3].Cell(12, 2).Range.Text = "";
                myWordDocument.Tables[3].Cell(13, 2).Range.Text = "";
                myWordDocument.Tables[3].Cell(13, 5).Range.Text = "";
                myWordDocument.Tables[3].Cell(14, 5).Range.Text = "";
                foreach (DataRowView myDataRowView_SubjectPositionResult in myDataView_SubjectPositionResult)
                {
                    if ((bool)myDataRowView_SubjectPositionResult["FaceDT"] || (bool)myDataRowView_SubjectPositionResult["MakeupFaceDT"])
                    {
                        myWordDocument.Tables[3].Cell(11, 2).Range.Text = "Satisfactory";
                    }
                    else
                    {
                        myWordDocument.Tables[3].Cell(11, 2).Range.Text = "";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["MacroExamination"] || (bool)myDataRowView_SubjectPositionResult["MakeupMacroExamination"])
                    {
                        myWordDocument.Tables[3].Cell(11, 5).Range.Text = "Satisfactory";
                    }
                    else
                    {
                        myWordDocument.Tables[3].Cell(11, 5).Range.Text = "";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["RT"] || (bool)myDataRowView_SubjectPositionResult["MakeupRT"])
                    {
                        myWordDocument.Tables[3].Cell(14, 2).Range.Text = "Satisfactory";
                    }
                    else
                    {
                        myWordDocument.Tables[3].Cell(14, 2).Range.Text = "";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["UT"] || (bool)myDataRowView_SubjectPositionResult["MakeupUT"])
                    {
                        myWordDocument.Tables[3].Cell(15, 2).Range.Text = "Satisfactory";
                    }
                    else
                    {
                        myWordDocument.Tables[3].Cell(15, 2).Range.Text = "";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["BendDT"] || (bool)myDataRowView_SubjectPositionResult["MakeupBendDT"])
                    {
                        myWordDocument.Tables[3].Cell(12, 4).Range.Text = "1";
                        myWordDocument.Tables[3].Cell(12, 5).Range.Text = "Satisfactory";
                    }
                    else
                    {
                        myWordDocument.Tables[3].Cell(12, 4).Range.Text = "";
                        myWordDocument.Tables[3].Cell(12, 5).Range.Text = "";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["DisjunctionDT"] || (bool)myDataRowView_SubjectPositionResult["MakeupDisjunctionDT"])
                    {
                        myWordDocument.Tables[3].Cell(15, 5).Range.Text = "Satisfactory";
                    }
                    else
                    {
                        myWordDocument.Tables[3].Cell(15, 5).Range.Text = "";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["Impact"] || (bool)myDataRowView_SubjectPositionResult["MakeupImpact"])
                    {
                        //myWordDocument.Tables[3].Cell(16, 4).Range.Text = "Impact tests at -60℃";
                        myWordDocument.Tables[3].Cell(16, 4).Range.Text = "Impact -60℃/C.L.";
                        myWordDocument.Tables[3].Cell(16, 5).Range.Text = "Satisfactory";
                    }
                    else
                    {
                        myWordDocument.Tables[3].Cell(16, 4).Range.Text = "";
                        myWordDocument.Tables[3].Cell(16, 5).Range.Text = "";
                    }
                    if ((bool)myDataRowView_SubjectPositionResult["OtherDT"] || (bool)myDataRowView_SubjectPositionResult["MakeupOtherDT"])
                    {
                        myWordDocument.Tables[3].Cell(16, 2).Range.Text = "Satisfactory";
                    }
                    else
                    {
                        myWordDocument.Tables[3].Cell(16, 2).Range.Text = "";
                    }
                }
                myWordDocument.Tables[3].Cell(19, 2).Range.Text = myDataRowView["WelderEmployerEnglish"].ToString();
                myWordDocument.Tables[3].Cell(21, 2).Range.Text = DateTime.Today.ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                myWordDocument.Tables[3].Cell(21, 4).Range.Text = DateTime.Today.ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));

                myWordDocument.Tables[4].Cell(1, 3).Range.Text = myDataRowView["CertificateNo"].ToString();
                myWordDocument.Tables[4].Cell(5, 1).Range.Text = myDataRowView["WelderEmployerEnglish"].ToString();
                myWordDocument.Tables[4].Cell(5, 2).Range.Text = DateTime.Today.ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                myWordDocument.Tables[4].Cell(7, 1).Range.Text = myDataRowView["WelderEnglishName"].ToString() + " " + myDataRowView["WelderName"].ToString();
            
                str_BookmarkName = "First";
                Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
                str_BookmarkName = "Last";
                Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
                myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
                myRange.Copy();
                myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
                myWordDocument.Application.Selection.Paste();
            }

            str_BookmarkName = "First";
            Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            str_BookmarkName = "Last";
            Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            myRange.Delete(ref oMissing, ref oMissing);

            object object_Count = 1;
            object object_wdCharacter = ZCWord.WdUnits.wdCharacter;
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.Delete(ref object_wdCharacter, ref object_Count);
            myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            myWordApp.Selection.TypeBackspace();
            myWordApp.Selection.TypeBackspace();

            myWordApp.Visible = true;
        }

        private void button_LROperator_Click(object sender, EventArgs e)
        {
            //DataView myDataView_SubjectPositionResult;
            //DataView myDataView = new DataView(this.myDataTable);
            ////myDataView.RowFilter = "CertificateNo is Not Null";
            //myDataView.RowFilter = "SkillResult or SkillMakeupResult";
            //myDataView.Sort = "IssueNo, ExaminingNo";
            //if (myDataView.Count == 0)
            //{
            //    MessageBox.Show("没有证书！");
            //    return;
            //}

            //ZCWord.Application myWordApp = new ZCWord.Application();
            //ZCWord.Document myWordDocument;
            //ZCWord.Range myRange;
            //object str_FileName = string.Format("{0}\\Data\\LR焊接操作工证书.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            //object oMissing = System.Reflection.Missing.Value;
            //object bool_ReadOnly = true;
            //myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            //object str_BookmarkName;
            //object Bookmark_Start;
            //object Bookmark_End;
            //object object_wdStory = ZCWord.WdUnits.wdStory;
            //Image myImage_WelderPicture;
            //string str_TempFileName;


            //foreach (DataRowView myDataRowView in myDataView)
            //{
            //    myWordDocument.Tables[1].Cell(1, 3).Range.Text = myDataRowView["CertificateNo"].ToString();
            //    myWordDocument.Tables[1].Cell(5, 2).Range.Text = myDataRowView["WPSNo"].ToString();
           
            //    myWordDocument.Tables[2].Cell(2, 2).Range.Text = myDataRowView["WelderEnglishName"].ToString();
            //    myWordDocument.Tables[2].Cell(3, 2).Range.Text = myDataRowView["IdentificationCard"].ToString();
            //    myWordDocument.Tables[2].Cell(5, 2).Range.Text = Class_DataValidateTool.GetBirthdaybyIdentificationCard(myDataRowView["IdentificationCard"].ToString()).ToString("d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) + " / " + "China";
            //    myWordDocument.Tables[2].Cell(6, 2).Range.Text = myDataRowView["WelderEmployerEnglish"].ToString();
 
            //    myWordDocument.Tables[3].Cell(4, 2).Range.Text = string.Format("{0}", myDataRowView["WeldingProcessNo"]);
            //    myWordDocument.Tables[3].Cell(4, 3).Range.Text = string.Format("{0}", myDataRowView["WeldingProcessNo"]);


            //    str_BookmarkName = "First";
            //    Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            //    str_BookmarkName = "Last";
            //    Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            //    myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            //    myRange.Copy();
            //    myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            //    myWordDocument.Application.Selection.Paste();
            //}

            //str_BookmarkName = "First";
            //Bookmark_Start = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Start;
            //str_BookmarkName = "Last";
            //Bookmark_End = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).End;
            //myRange = myWordDocument.Range(ref Bookmark_Start, ref Bookmark_End);
            //myRange.Delete(ref oMissing, ref oMissing);

            //object object_Count = 1;
            //object object_wdCharacter = ZCWord.WdUnits.wdCharacter;
            //myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            //myWordApp.Selection.Delete(ref object_wdCharacter, ref object_Count);
            //myWordDocument.Application.Selection.EndKey(ref object_wdStory, ref oMissing);
            //myWordApp.Selection.TypeBackspace();
            //myWordApp.Selection.TypeBackspace();

            //myWordApp.Visible = true;
        }

        private void button_ExportCCSSum_Click(object sender, EventArgs e)
        {
            DataView myDataView = new DataView(this.myDataTable);
            if (this.checkBox_ExportCCSMustQCAccess.Checked)
            {
                myDataView.RowFilter = "ExamSubjectID is Not Null And CertificateNo is Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            }
            else
            {
                myDataView.RowFilter = "ExamSubjectID is Not Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            }
            myDataView.Sort = "IssueNo, ExaminingNo";
            
            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Range myRange;
            object str_FileName = string.Format("{0}\\Data\\CCS评定汇总表.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            int i = myDataView.Count -25;
            while (i>0)
            {
                myWordDocument.Tables[1].Cell(9 , 1).Range.Rows.Add(ref oMissing);
                i--;
            }
            i = 1;
            object object_wdStory = ZCWord.WdUnits.wdStory;
            bool bool_RT = false;
            bool bool_BT=false;
            DataTable myTable_Temp = myDataView.ToTable();
            string str_TestItem = "";
            string str_BaseMetal = "";
            string str_WeldingConsumables = "";
            foreach (DataRow myDataRow in Class_Data.GetDistinctField(myTable_Temp, "CCSWeldingProcess").Rows)
            {
                if (string.IsNullOrEmpty(str_TestItem))
                {
                    str_TestItem = myDataRow["CCSWeldingProcess"].ToString();
                }
                else
                {
                    str_TestItem += "; " + myDataRow["CCSWeldingProcess"].ToString();
                }
            }
            foreach (DataRow myDataRow in Class_Data.GetDistinctField(myTable_Temp, "MaterialCCSGroupItemName").Rows)
            {
                if (string.IsNullOrEmpty(str_BaseMetal))
                {
                    str_BaseMetal = myDataRow["MaterialCCSGroupItemName"].ToString();
                }
                else
                {
                    str_BaseMetal += "; " + myDataRow["MaterialCCSGroupItemName"].ToString();
                }
            }
            foreach (DataRow myDataRow in Class_Data.GetDistinctField(myTable_Temp, "ScopeofWeldingConsumableCCSGroup").Rows)
            {
                if (string.IsNullOrEmpty(str_WeldingConsumables))
                {
                    str_WeldingConsumables = myDataRow["ScopeofWeldingConsumableCCSGroup"].ToString();
                }
                else
                {
                    str_WeldingConsumables += "; " + myDataRow["ScopeofWeldingConsumableCCSGroup"].ToString();
                }
            }
            myWordDocument.Tables[1].Cell(3, 2).Range.Text = Properties.Settings.Default.CCSTestCommittee;
            myWordDocument.Tables[1].Cell(3, 4).Range.Text = str_TestItem;
            myWordDocument.Tables[1].Cell(4, 2).Range.Text = str_BaseMetal;
            myWordDocument.Tables[1].Cell(4, 4).Range.Text = str_WeldingConsumables;
            myWordDocument.Tables[1].Cell(5, 2).Range.Text = "沪东中华";
            foreach (DataRowView myDataRowView in myDataView)
            {
                if (i == 1)
                {
                    myWordDocument.Tables[1].Cell(5, 4).Range.Text = string.Format("{0:yyyy-M-d}", myDataRowView["SignUpDate"]);
                    //bool_RT = myDataRowView["RTTestDate"] != DBNull.Value;
                    //bool_BT=myDataRowView["BendTestDate"] != DBNull.Value;
                }
                myWordDocument.Tables[1].Cell(7 + i, 1).Range.Text = i.ToString();
                myWordDocument.Tables[1].Cell(7 + i, 2).Range.Text = myDataRowView["WelderName"].ToString();
                myWordDocument.Tables[1].Cell(7 + i, 3).Range.Text = myDataRowView["RegistrationNo"].ToString();
                myWordDocument.Tables[1].Cell(7 + i, 4).Range.Text = myDataRowView["ExaminingNo"].ToString();
                myWordDocument.Tables[1].Cell(7 + i, 5).Range.Text = myDataRowView["TheoryResult"].ToString();
                myWordDocument.Tables[1].Cell(7 + i, 6).Range.Text ="合格";
                myWordDocument.Tables[1].Cell(7 + i, 7).Range.Text =  "合格" ;
                myWordDocument.Tables[1].Cell(7 + i, 8).Range.Text = "合格";
                i++;
            }

            myWordDocument.Tables[2].Cell(1, 2).Range.Text = Properties.Settings.Default.Lister;
            myWordDocument.Tables[2].Cell(1, 4).Range.Text = DateTime.Today.ToString("yyyy-M-d");
            myWordApp.Visible = true;
        }

        private void button_ExportCCS2015_Click(object sender, EventArgs e)
        {
            string str_Regex = string.Format("^{0}-APPLY-\\d{{2}}-\\d{{5}}$", Properties.Settings.Default.CCSTestCommitteeID);
            DataView myDataView = new DataView(this.myDataTable);
            if (this.checkBox_ExportCCSMustQCAccess.Checked)
            {
                myDataView.RowFilter = "ExamSubjectID is Not Null And CertificateNo is Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            }
            else
            {
                myDataView.RowFilter = "ExamSubjectID is Not Null And ((TheoryResultNeed=true and (TheoryResult>=PassScore or TheoryMakeupResult>=PassScore)) or TheoryResultNeed=false) and ((SkillResultNeed=true and (SkillResult Or SkillMakeupResult)) or SkillResultNeed=false)";
            }
            myDataView.Sort = "IssueNo, ExaminingNo";
            DataTable myTable_Temp = myDataView.ToTable();
            //确定所有需要办证的焊工电子照片是否齐全
            Hashtable myHashtable_WelderPicture = Class_Welder.GetWelderPictureHashtableBinary(myTable_Temp); ;
            if (myHashtable_WelderPicture.Count < Class_Data.GetDistinctField(myDataView.ToTable(), "IdentificationCard").Rows.Count)
            {
                if (MessageBox.Show("有部分焊工没有照片，确认导出“办证文件”吗？", "确认窗口", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            Class_ExamField.RefreshData();
            if (System.Text.RegularExpressions.Regex.IsMatch(Class_ExamField.CCSApplyNo, str_Regex))
            {
                Class_ExamField.CCSApplyNo = string.Format("{0}-APPLY-{1}-{2}", Properties.Settings.Default.CCSTestCommitteeID, DateTime.Today.Year.ToString().Substring(2, 2), Class_ExamField.CCSApplyNo.Substring(Class_ExamField.CCSApplyNo.Length - 5, 5));
            }
            else
            {
                Class_ExamField.CCSApplyNo = string.Format("{0}-APPLY-{1}-00001", Properties.Settings.Default.CCSTestCommitteeID, DateTime.Today.Year.ToString().Substring(2, 2));
            }
            ADODB.Recordset rs = new ADODB.Recordset();
            ADODB.FieldAttributeEnum myEnum = ADODB.FieldAttributeEnum.adFldMayDefer | ADODB.FieldAttributeEnum.adFldIsNullable | ADODB.FieldAttributeEnum.adFldUnknownUpdatable | ADODB.FieldAttributeEnum.adFldMayBeNull;
            rs.Fields.Append("WelderNo", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("WelderMarkNo", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("WelderName", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs.Fields.Append("WelderSex", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs.Fields.Append("WelderIDNo", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs.Fields.Append("OtherIDNo", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("TestGrade", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs.Fields.Append("WorkType", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs.Fields.Append("ApplyKind", ADODB.DataTypeEnum.adVarChar, 100, myEnum, Type.Missing);
            rs.Fields.Append("BaseMetal", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs.Fields.Append("FillerMetal", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("ThickNess", ADODB.DataTypeEnum.adDouble, 0, myEnum, Type.Missing);
            rs.Fields.Append("PipeThickNess", ADODB.DataTypeEnum.adDouble, 0, myEnum, Type.Missing);
            rs.Fields.Append("PipeOutSide", ADODB.DataTypeEnum.adDouble, 0, myEnum, Type.Missing);
            rs.Fields.Append("ButtWelding", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("Employer", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("TestCommitteeNo", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("Education", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("WorkingYears", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs.Fields.Append("Postcode", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs.Fields.Append("Address", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("Tel", ADODB.DataTypeEnum.adVarChar, 100, myEnum, Type.Missing);
            rs.Fields.Append("ValidCer", ADODB.DataTypeEnum.adVarChar, 100, myEnum, Type.Missing);
            rs.Fields.Append("TestType", ADODB.DataTypeEnum.adVarChar, 100, myEnum, Type.Missing);
            rs.Fields.Append("WeldingEx", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("TestBasicNo", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("TestBasicScore", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs.Fields.Append("TestActionRemark", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("TestActionNo", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("TestActionScore", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs.Fields.Append("TestTestScore1", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("TestTestScore2", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("ApplyNo", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("TestNo", ADODB.DataTypeEnum.adVarChar, 100, myEnum, Type.Missing);
            rs.Fields.Append("WelderPic", ADODB.DataTypeEnum.adLongVarBinary, 1073741823, myEnum, Type.Missing);
            rs.Fields.Append("OtherProject", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs.Fields.Append("WPSNo", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            for (int i = 0; i < rs.Fields.Count; i++)
            {
                rs.Fields[i].Precision = 255;
            }
            rs.Fields["ThickNess"].Precision = 15;
            rs.Fields["PipeThickNess"].Precision = 15;
            rs.Fields["PipeOutSide"].Precision = 15;
            rs.Fields["ThickNess"].NumericScale = 1;
            rs.Fields["PipeThickNess"].NumericScale = 1;
            rs.Fields["PipeOutSide"].NumericScale = 1;
            float float_StudentThickness;
            float float_StudentExternalDiameter;

            rs.Open("TB_People_Info", Type.Missing, ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockOptimistic, -1);
            foreach (DataRow dr in myTable_Temp.Rows)
            {
                rs.AddNew(Type.Missing, Type.Missing);
                if (string.IsNullOrEmpty(dr["RegistrationNo"].ToString()))
                {
                    dr["RegistrationNo"] = Class_TestCommitteeRegistrationNo.AutoFill(Properties.Settings.Default.CCSTestCommitteeID, dr["IdentificationCard"].ToString());
                }
                rs.Fields[0].Value = dr["RegistrationNo"];
                rs.Fields[1].Value = dr["ExaminingNo"];
                rs.Fields[2].Value = dr["WelderName"];
                rs.Fields[3].Value = dr["Sex"];
                rs.Fields[4].Value = dr["IdentificationCard"];
                rs.Fields[5].Value = "";
                rs.Fields[6].Value = dr["CCSSubject"];
                rs.Fields[7].Value = dr["WeldingProject"];
                rs.Fields[8].Value = "新证";
                rs.Fields[9].Value = dr["MaterialCCSGroupItemName"];
                rs.Fields[10].Value = dr["ScopeofWeldingConsumableCCSGroup"];
                if (!float.TryParse(dr["StudentThickness"].ToString().Trim(), out float_StudentThickness))
                {
                    float_StudentThickness = 0;
                }
                if (!float.TryParse(dr["StudentExternalDiameter"].ToString().Trim(), out float_StudentExternalDiameter))
                {
                    float_StudentExternalDiameter = 0;
                }
                if (dr["WorkPieceType"].ToString() == "板")
                {
                    rs.Fields[11].Value = Math.Round(float_StudentThickness, 0);
                    rs.Fields[12].Value = DBNull.Value;
                    rs.Fields[13].Value = DBNull.Value;
                }
                else
                {
                    rs.Fields[11].Value = DBNull.Value;
                    rs.Fields[12].Value = Math.Round(float_StudentThickness, 0);
                    rs.Fields[13].Value = Math.Round(float_StudentExternalDiameter, 0);
                }
                rs.Fields[14].Value = dr["ScopeofCCSAssemblage"];
                rs.Fields[15].Value = dr["WelderEmployer"];
                rs.Fields[16].Value = Properties.Settings.Default.CCSTestCommitteeID;
                rs.Fields[17].Value = dr["Schooling"];
                rs.Fields[18].Value = DBNull.Value;
                rs.Fields[19].Value = DBNull.Value;
                rs.Fields[20].Value = DBNull.Value;
                rs.Fields[21].Value = DBNull.Value;
                rs.Fields[22].Value = DBNull.Value;
                rs.Fields[23].Value = dr["CCSWeldingProcess"];
                rs.Fields[24].Value = "";//工作经历
                rs.Fields[25].Value = Class_ExamField.CCSApplyNo;//TestBasicNo
                if (dr["TheoryResult"] != DBNull.Value && (int)dr["TheoryResult"] >= (int)dr["PassScore"])
                {
                    rs.Fields[26].Value = dr["TheoryResult"];
                }
                else if (dr["TheoryMakeupResult"] != DBNull.Value && (int)dr["TheoryMakeupResult"] >= (int)dr["PassScore"])
                {
                    rs.Fields[26].Value = dr["TheoryMakeupResult"];
                }
                else
                {
                    rs.Fields[26].Value = DBNull.Value;
                }
                rs.Fields[27].Value = string.Format("{0} : {1}", dr["IssueNo"], dr["ExaminingNo"]);//TestActionRemark
                rs.Fields[28].Value = Class_ExamField.CCSApplyNo;
                rs.Fields[29].Value = "合格";
                if (dr["RTTestDate"] == DBNull.Value)
                {
                    rs.Fields[30].Value = "合格";
                    rs.Fields[31].Value = "--";
                }
                else
                {
                    rs.Fields[30].Value = "--";
                    rs.Fields[31].Value = "合格";
                }
                rs.Fields[32].Value = Class_ExamField.CCSApplyNo;
                rs.Fields[33].Value = dr["CCSSubjectTestNo"];
                byte[] mybyte = Class_Welder.GetWelderPictureBinary(dr["IdentificationCard"].ToString());
                if (mybyte == null)
                {
                    rs.Fields[34].Value = DBNull.Value;
                }
                else
                {
                    rs.Fields[34].Value = mybyte;
                }
                rs.Fields[35].Value = "";
                rs.Fields[36].Value = dr["WPSNo"].ToString();
                //rs.Fields[36].Value = string.Format("WPS-{0}-{1}-{2}", dr["WeldingProcessAb"], dr["StudentMaterial"], dr["WeldingClass"]);
            }

            ADODB.Recordset rs_Apply = new ADODB.Recordset();
            rs_Apply.Fields.Append("ApplyNo", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs_Apply.Fields.Append("ApplyRq", ADODB.DataTypeEnum.adDBTimeStamp, -1, myEnum, Type.Missing);
            rs_Apply.Fields.Append("Employer", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs_Apply.Fields.Append("TestItem", ADODB.DataTypeEnum.adVarChar, 536870910, myEnum, Type.Missing);
            rs_Apply.Fields.Append("BaseMetal", ADODB.DataTypeEnum.adVarChar, 536870910, myEnum, Type.Missing);
            rs_Apply.Fields.Append("WeldingConsumables", ADODB.DataTypeEnum.adVarChar, 536870910, myEnum, Type.Missing);
            rs_Apply.Fields.Append("PlaceofTest", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs_Apply.Fields.Append("DateofTest", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs_Apply.Fields.Append("WishDate", ADODB.DataTypeEnum.adDBTimeStamp, -1, myEnum, Type.Missing);
            rs_Apply.Fields.Append("PNum", ADODB.DataTypeEnum.adInteger, -1, myEnum, Type.Missing);
            rs_Apply.Fields.Append("HwhNo", ADODB.DataTypeEnum.adVarChar, 10, myEnum, Type.Missing);
            rs_Apply.Fields.Append("HwhName", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs_Apply.Fields.Append("HwhAddress", ADODB.DataTypeEnum.adVarChar, 200, myEnum, Type.Missing);
            rs_Apply.Fields.Append("HwhPostNo", ADODB.DataTypeEnum.adVarChar, 50, myEnum, Type.Missing);
            rs_Apply.Fields.Append("HwhLxr", ADODB.DataTypeEnum.adVarChar, 100, myEnum, Type.Missing);
            rs_Apply.Fields.Append("HwhTel", ADODB.DataTypeEnum.adVarChar, 100, myEnum, Type.Missing);
            rs_Apply.Fields.Append("HwhFax", ADODB.DataTypeEnum.adVarChar, 100, myEnum, Type.Missing);
            for (int i = 0; i < rs_Apply.Fields.Count; i++)
            {
                rs_Apply.Fields[i].Precision = 255;
            }
            rs_Apply.Fields["PNum"].Precision = 10;

            rs_Apply.Open("TB_Certificate_Sqs", Type.Missing, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, -1);
            string str_TestItem = "";
            string str_BaseMetal = "";
            string str_WeldingConsumables = "";
            foreach (DataRow myDataRow in Class_Data.GetDistinctField(myTable_Temp, "CCSWeldingProcess").Rows)
            {
                if (string.IsNullOrEmpty(str_TestItem))
                {
                    str_TestItem = myDataRow["CCSWeldingProcess"].ToString();
                }
                else
                {
                    str_TestItem += "; " + myDataRow["CCSWeldingProcess"].ToString();
                }
            }
            foreach (DataRow myDataRow in Class_Data.GetDistinctField(myTable_Temp, "MaterialCCSGroupItemName").Rows)
            {
                if (string.IsNullOrEmpty(str_BaseMetal))
                {
                    str_BaseMetal = myDataRow["MaterialCCSGroupItemName"].ToString();
                }
                else
                {
                    str_BaseMetal += "; " + myDataRow["MaterialCCSGroupItemName"].ToString();
                }
            }
            foreach (DataRow myDataRow in Class_Data.GetDistinctField(myTable_Temp, "ScopeofWeldingConsumableCCSGroup").Rows)
            {
                if (string.IsNullOrEmpty(str_WeldingConsumables))
                {
                    str_WeldingConsumables = myDataRow["ScopeofWeldingConsumableCCSGroup"].ToString();
                }
                else
                {
                    str_WeldingConsumables += "; " + myDataRow["ScopeofWeldingConsumableCCSGroup"].ToString();
                }
            }
            rs_Apply.AddNew(Type.Missing, Type.Missing);
            rs_Apply.Fields["ApplyNo"].Value = Class_ExamField.CCSApplyNo;
            rs_Apply.Fields["ApplyRq"].Value = DateTime.Today.ToString("yyyy-M-d");
            rs_Apply.Fields["Employer"].Value = Properties.Settings.Default.CCSTestCommittee;
            rs_Apply.Fields["TestItem"].Value = str_TestItem;
            rs_Apply.Fields["BaseMetal"].Value = str_BaseMetal;
            rs_Apply.Fields["WeldingConsumables"].Value = str_WeldingConsumables;
            rs_Apply.Fields["PlaceofTest"].Value = Properties.Settings.Default.CCSTestCommittee;
            rs_Apply.Fields["DateofTest"].Value = DateTime.Today.ToString("yyyy-M-d");
            rs_Apply.Fields["WishDate"].Value = DateTime.Today.ToString("yyyy-M-d");
            rs_Apply.Fields["PNum"].Value = myDataView.Count;
            rs_Apply.Fields["HwhNo"].Value = Properties.Settings.Default.CCSTestCommitteeID;
            rs_Apply.Fields["HwhName"].Value = Properties.Settings.Default.CCSTestCommittee;
            rs_Apply.Fields["HwhAddress"].Value = Properties.Settings.Default.MailEmployerAddress;
            rs_Apply.Fields["HwhPostNo"].Value = Properties.Settings.Default.MailEmployerPostalcode;
            rs_Apply.Fields["HwhLxr"].Value = Properties.Settings.Default.Lister;
            rs_Apply.Fields["HwhTel"].Value = Properties.Settings.Default.LinkTel;
            rs_Apply.Fields["HwhFax"].Value = "";

            SaveFileDialog myForm = new SaveFileDialog();
            myForm.Filter = "All files (*.*)|*.*";
            myForm.FileName = string.Format("{0}({1})-{2}人", Class_ExamField.CCSApplyNo, DateTime.Today.ToString("yyyy-M-d"), myDataView.Count);
            myForm.RestoreDirectory = true;
            if (myForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (!Directory.Exists(myForm.FileName))
            {
                Directory.CreateDirectory(myForm.FileName);
            }
            File.Delete(myForm.FileName + "\\人员名单" + ".data");
            File.Delete(myForm.FileName + "\\申请数据" + ".data");
            rs.Save(myForm.FileName + "\\人员名单" + ".data", ADODB.PersistFormatEnum.adPersistXML);
            rs_Apply.Save(myForm.FileName + "\\申请数据" + ".data", ADODB.PersistFormatEnum.adPersistXML);

            Class_ExamField.CCSApplyNo = Class_Tools.GetNextSequence(Class_ExamField.CCSApplyNo, 5);
            Class_ExamField.UpdateField();
            MessageBox.Show("操作完毕！");
        }
    }
}