using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Data.SqlClient ;
using System.Windows.Forms;
using ZCCL.DataGridViewManager;
using ZCCL.SystemInformation ;
using ZCCL.AspNet;
using ZCCL.Report;
using System.Collections;
using System.Configuration;
using ZCCL.ClassBase;
using ZCExcel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace ZCWelder.ClassBase
{
    /// <summary>
    /// 全局静态类，主要用来初始系统的全局变量
    /// </summary>
    static public class Class_Public
    {
        #region "Fields"
        /// <summary>
        /// 存储系统所有的数据表
        /// </summary>
        static public Hashtable myHashtable = new Hashtable();

        static public double dbl_RoomTemperature=20;
        #endregion

        static Class_Public()
        {

        }

        static public void InitializeData()
        {
            InitializeData(Enum_DataTable.Employer | Enum_DataTable.Department | Enum_DataTable.WorkPlace | Enum_DataTable.EmployerGroup | Enum_DataTable.LaborServiceTeam | Enum_DataTable.KindofEmployer);
            InitializeData(Enum_DataTable.Assemblage | Enum_DataTable.ExamStatus | Enum_DataTable.JointType | Enum_DataTable.Schooling | Enum_DataTable.Material | Enum_DataTable.WeldingConsumable
                | Enum_DataTable.WorkPieceType | Enum_DataTable.MaterialCCSGroup | Enum_DataTable.KindofExam | Enum_DataTable.MaterialISOGroup
                | Enum_DataTable.Ship | Enum_DataTable.ShipandShipClassification | Enum_DataTable.ShipClassification | Enum_DataTable.WeldingStandard | Enum_DataTable.WeldingStandardAndGroup | Enum_DataTable.WeldingStandardGroup
                | Enum_DataTable.TestCommittee | Enum_DataTable.WeldingConsumableCCSGroup | Enum_DataTable.WeldingConsumableISOGroup | Enum_DataTable.WeldingSubject | Enum_DataTable.WeldingSubjectApplicable | Enum_DataTable.WeldingSubjectPosition
                | Enum_DataTable.WeldingProcess | Enum_DataTable.WelderBelongLog | Enum_DataTable.WeldingPosition | Enum_DataTable.LayerWelding );
            InitializeData(Enum_DataTable.Issue | Enum_DataTable.GXTheoryIssue | Enum_DataTable.GXTheoryWelderStudent | Enum_DataTable.WelderStudentQC | Enum_DataTable.Welder | Enum_DataTable.WelderBelong | Enum_DataTable.SubjectPositionResult | Enum_DataTable.ExamAll | Enum_DataTable.SubjectPositionResultSecond | Enum_DataTable.WelderTestCommitteeRegistrationNo
                | Enum_DataTable.IssueProcess | Enum_DataTable.GXTheoryIssueProcess | Enum_DataTable.IssueProcessUnion | Enum_DataTable.WelderBelongQC | Enum_DataTable.WelderBelongExam  | Enum_DataTable.WelderIssueStudentQCRegistrationNo
                | Enum_DataTable.KindofEmployerWelder | Enum_DataTable.KindofEmployerIssue | Enum_DataTable.KindofEmployerStudent| Enum_DataTable.KindofEmployerExam | Enum_DataTable.BlackList );
            InitializeData(Enum_DataTable.WPS );
            InitializeData(Enum_DataTableSecond.WeldingEquipment | Enum_DataTableSecond.KindofWeld| Enum_DataTableSecond.GrooveType   | Enum_DataTableSecond.TypeofCurrentAndPolarity | Enum_DataTableSecond.WPSWeldingLayer | Enum_DataTableSecond.WPSWeldingSequence| Enum_DataTableSecond.WPSGasAndWeldingFlux| Enum_DataTableSecond.WPSHeatTreatment| Enum_DataTableSecond.WPSImage
                | Enum_DataTableSecond.GasAndWeldingFlux | Enum_DataTableSecond.GasAndWeldingFluxGroup | Enum_DataTableSecond.HeatTreatment | Enum_DataTableSecond.KindofLimit | Enum_DataTableSecond.HeatMethod | Enum_DataTableSecond.ImageGroup | Enum_DataTableSecond.Flaw | Enum_DataTableSecond.Judgment| Enum_DataTableSecond.Choice| Enum_DataTableSecond.EssayQuestion| Enum_DataTableSecond.MultiChoice| Enum_DataTableSecond.Subject  );
            InitializeData(Enum_DataTableSecond.ReviveQC);
        }

        static public void InitializeComboBox(ComboBox myComboBox, string str_DataTableName, string str_ValueMember, string str_DisplayMember)
        {
            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[str_DataTableName];
            Class_DataControlBind.InitializeComboBox(myComboBox, myClass_Data.myDataView, str_ValueMember, str_DisplayMember);
    
        }

        static private void InitializeData(Enum_DataTable myEnum_DataTable)
        {
            if ((myEnum_DataTable & Enum_DataTable.WelderBelongLog) == Enum_DataTable.WelderBelongLog)
            {
                string[] str_Keys = new string[] { "WelderBelongLogID" };
                string str_Sort = "WelderBelongLogID DESC";
                string str_SQL = "Select * From View_Person_WelderBelongLog";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WelderBelongLog.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WeldingSubject) == Enum_DataTable.WeldingSubject)
            {
                string[] str_Keys = new string[] { "SubjectID" };
                string str_Sort = "SubjectID";
                string str_SQL = "Select * From Parameter_WeldingSubject";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingSubject.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WeldingSubjectPosition) == Enum_DataTable.WeldingSubjectPosition)
            {
                string[] str_Keys = new string[] { "SubjectID", "WeldingPosition" };
                string str_Sort = "SubjectID, WeldingPosition";
                string str_SQL = "Select * From View_Parameter_WeldingSubjectPosition";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingSubjectPosition.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WeldingSubjectApplicable) == Enum_DataTable.WeldingSubjectApplicable)
            {
                string[] str_Keys = new string[] { "SubjectID", "ApplicableSubjectID" };
                string str_Sort = "SubjectID, ApplicableSubjectID";
                string str_SQL = "Select * From View_Parameter_WeldingSubjectApplicable";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingSubjectApplicable.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.EmployerGroup) == Enum_DataTable.EmployerGroup)
            {
                string[] str_Keys = new string[] { "EmployerGroup" };
                string str_Sort = "EmployerGroupIndex, EmployerGroup";
                string str_SQL = "Select * From Unit_EmployerGroup";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.EmployerGroup.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.Employer) == Enum_DataTable.Employer)
            {
                string[] str_Keys = new string[] { "EmployerHPID" };
                string str_Sort = "EmployerIndex, Employer";
                string str_SQL = "Select * From View_Unit_Employer";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.Employer.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.Department) == Enum_DataTable.Department)
            {
                string[] str_Keys = new string[] { "DepartmentHPID" };
                string str_Sort = "DepartmentIndex, Department";
                string str_SQL = "Select * From View_Unit_Department";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.Department.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WorkPlace) == Enum_DataTable.WorkPlace)
            {
                string[] str_Keys = new string[] { "WorkPlaceHPID" };
                string str_Sort = "WorkPlaceIndex, WorkPlace";
                string str_SQL = "Select * From View_Unit_WorkPlace";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WorkPlace.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.LaborServiceTeam) == Enum_DataTable.LaborServiceTeam)
            {
                string[] str_Keys = new string[] { "LaborServiceTeamHPID" };
                string str_Sort = "LaborServiceTeamIndex, LaborServiceTeam";
                string str_SQL = "Select * From View_Unit_LaborServiceTeam";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.LaborServiceTeam.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.KindofEmployer) == Enum_DataTable.KindofEmployer)
            {
                string[] str_Keys = new string[] { "KindofEmployer" };
                string str_Sort = "KindofEmployerIndex, KindofEmployer";
                string str_SQL = "Select * From View_Unit_KindofEmployer";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.KindofEmployer.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.Schooling) == Enum_DataTable.Schooling)
            {
                string[] str_Keys = new string[] { "Schooling" };
                string str_Sort = "SchoolingIndex, Schooling";
                string str_SQL = "Select * From Parameter_Schooling";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.Schooling.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.Assemblage) == Enum_DataTable.Assemblage)
            {
                string[] str_Keys = new string[] { "Assemblage" };
                string str_Sort = "AssemblageIndex";
                string str_SQL = "Select * From Parameter_Assemblage";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.Assemblage.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.JointType) == Enum_DataTable.JointType)
            {
                string[] str_Keys = new string[] { "JointType" };
                string str_Sort = "JointTypeIndex";
                string str_SQL = "Select * From Parameter_JointType";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.JointType.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.Material) == Enum_DataTable.Material)
            {
                string[] str_Keys = new string[] { "Material" };
                string str_Sort = "MaterialIndex, Material";
                string str_SQL = "Select * From View_Parameter_Material";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.Material.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.TestCommittee ) == Enum_DataTable.TestCommittee)
            {
                string[] str_Keys = new string[] { "TestCommitteeID" };
                string str_Sort = "TestCommitteeIndex";
                string str_SQL = "Select * From Parameter_TestCommittee";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.TestCommittee.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.MaterialCCSGroup ) == Enum_DataTable.MaterialCCSGroup)
            {
                string[] str_Keys = new string[] { "MaterialCCSGroupAb" };
                string str_Sort = "MaterialCCSGroupIndex";
                string str_SQL = "Select * From Parameter_MaterialCCSGroup";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.MaterialCCSGroup.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.MaterialISOGroup ) == Enum_DataTable.MaterialISOGroup)
            {
                string[] str_Keys = new string[] { "MaterialISOGroupAb" };
                string str_Sort = "MaterialISOGroupIndex";
                string str_SQL = "Select * From Parameter_MaterialISOGroup";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.MaterialISOGroup.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WeldingConsumableCCSGroup ) == Enum_DataTable.WeldingConsumableCCSGroup)
            {
                string[] str_Keys = new string[] { "WeldingConsumableCCSGroupAb" };
                string str_Sort = "WeldingConsumableCCSGroupIndex";
                string str_SQL = "Select * From Parameter_WeldingConsumableCCSGroup";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingConsumableCCSGroup.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WeldingConsumableISOGroup ) == Enum_DataTable.WeldingConsumableISOGroup)
            {
                string[] str_Keys = new string[] { "WeldingConsumableISOGroupAb" };
                string str_Sort = "WeldingConsumableISOGroupIndex";
                string str_SQL = "Select * From Parameter_WeldingConsumableISOGroup";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingConsumableISOGroup.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.ShipClassification) == Enum_DataTable.ShipClassification)
            {
                string[] str_Keys = new string[] { "ShipClassificationAb" };
                string str_Sort = "ShipClassificationIndex";
                string str_SQL = "Select * From Parameter_ShipClassification";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.ShipClassification.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.Ship) == Enum_DataTable.Ship)
            {
                string[] str_Keys = new string[] { "ShipboardNo" };
                string str_Sort = "ShipIndex, ShipboardNo";
                string str_SQL = "Select * From Parameter_Ship";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.Ship.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.ShipandShipClassification) == Enum_DataTable.ShipandShipClassification)
            {
                string[] str_Keys = new string[] { "ShipClassificationAb", "ShipboardNo" };
                string str_Sort = "ShipandShipClassificationIndex, ShipClassificationAb, ShipboardNo";
                string str_SQL = "Select * From View_Parameter_ShipandShipClassification";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.ShipandShipClassification.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }
            if ((myEnum_DataTable & Enum_DataTable.WeldingConsumable) == Enum_DataTable.WeldingConsumable)
            {
                string[] str_Keys = new string[] { "WeldingConsumable" };
                string str_Sort = "WeldingConsumableIndex, WeldingConsumable";
                string str_SQL = "Select * From View_Parameter_WeldingConsumable";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingConsumable.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WeldingProcess) == Enum_DataTable.WeldingProcess)
            {
                string[] str_Keys = new string[] { "WeldingProcessAb" };
                string str_Sort = "WeldingProcessIndex";
                string str_SQL = "Select * From Parameter_WeldingProcess";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingProcess.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WeldingStandard) == Enum_DataTable.WeldingStandard)
            {
                string[] str_Keys = new string[] { "WeldingStandard" };
                string str_Sort = "WeldingStandardIndex";
                string str_SQL = "Select * From Parameter_WeldingStandard";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingStandard.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WeldingStandardGroup) == Enum_DataTable.WeldingStandardGroup)
            {
                string[] str_Keys = new string[] { "WeldingStandardGroup" };
                string str_Sort = "WeldingStandardGroupIndex";
                string str_SQL = "Select * From Parameter_WeldingStandardGroup";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingStandardGroup.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WeldingStandardAndGroup) == Enum_DataTable.WeldingStandardAndGroup)
            {
                string[] str_Keys = new string[] { "WeldingStandardGroup", "WeldingStandard" };
                string str_Sort = "WeldingStandardGroup, WeldingStandardAndGroupIndex, WeldingStandard";
                string str_SQL = "Select * From View_Parameter_WeldingStandardAndGroup";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingStandardAndGroup.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WorkPieceType) == Enum_DataTable.WorkPieceType)
            {
                string[] str_Keys = new string[] { "WorkPieceType" };
                string str_Sort = "WorkPieceTypeIndex";
                string str_SQL = "Select * From Parameter_WorkPieceType";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WorkPieceType.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.KindofExam) == Enum_DataTable.KindofExam)
            {
                string[] str_Keys = new string[] { "KindofExam" };
                string str_Sort = "KindofExamIndex";
                string str_SQL = "Select * From Parameter_KindofExam";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.KindofExam.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.ExamStatus) == Enum_DataTable.ExamStatus)
            {
                string[] str_Keys = new string[] { "ExamStatus" };
                string str_Sort = "ExamStatusIndex";
                string str_SQL = "Select * From Parameter_ExamStatus";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.ExamStatus.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.Issue) == Enum_DataTable.Issue)
            {
                string[] str_Keys = new string[] { "IssueNo" };
                string str_Sort = "IssueNo";
                string str_SQL = "Select * From View_Exam_Issue";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.Issue.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.IssueProcess) == Enum_DataTable.IssueProcess)
            {
                string[] str_Keys = new string[] { "IssueProcessID" };
                string str_Sort = "IssueProcessBeginDate";
                string str_SQL = "Select * From View_Exam_IssueProcess";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.IssueProcess.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.IssueProcessUnion) == Enum_DataTable.IssueProcessUnion)
            {
                string[] str_Keys = new string[] {  };
                string str_Sort = "IssueNo, IssueProcessBeginDate";
                string str_SQL = "Select * From View_Union_Exam_IssueProcess";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.IssueProcessUnion.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.GXTheoryIssueProcess) == Enum_DataTable.GXTheoryIssueProcess)
            {
                string[] str_Keys = new string[] { "IssueProcessID" };
                string str_Sort = "IssueProcessBeginDate";
                string str_SQL = "Select * From View_Exam_GXTheoryIssueProcess";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.GXTheoryIssueProcess.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.GXTheoryIssue) == Enum_DataTable.GXTheoryIssue)
            {
                string[] str_Keys = new string[] { "IssueNo" };
                string str_Sort = "IssueNo";
                string str_SQL = "Select * From View_Exam_GXTheoryIssue";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.GXTheoryIssue.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.Welder) == Enum_DataTable.Welder)
            {
                string[] str_Keys = new string[] { "IdentificationCard" };
                string str_Sort = "WelderName";
                string str_SQL = "Select * From View_Person_Welder";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.Welder.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WelderStudentQC) == Enum_DataTable.WelderStudentQC)
            {
                string[] str_Keys = new string[] { "ExaminingNo" };
                string str_Sort = "ExaminingNo";
                string str_SQL = "Select * From View_Exam_WelderIssueStudentQC";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WelderStudentQC.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.SubjectPositionResult) == Enum_DataTable.SubjectPositionResult)
            {
                string[] str_Keys = new string[] { "ExaminingNo", "WeldingPosition" };
                string str_Sort = "ExaminingNo, WeldingPosition";
                string str_SQL = "Select * From View_Exam_SubjectPositionResult";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.SubjectPositionResult.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.SubjectPositionResultSecond) == Enum_DataTable.SubjectPositionResultSecond)
            {
                string[] str_Keys = new string[] { "ExaminingNo", "WeldingPosition" };
                string str_Sort = "ExaminingNo, WeldingPosition";
                string str_SQL = "Select * From View_Exam_SubjectPositionResult";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.SubjectPositionResultSecond.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.GXTheoryWelderStudent) == Enum_DataTable.GXTheoryWelderStudent)
            {
                string[] str_Keys = new string[] { "ExaminingNo" };
                string str_Sort = "ExaminingNo";
                string str_SQL = "Select * From View_Exam_GXTheoryWelderStudent";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.GXTheoryWelderStudent.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.ExamAll) == Enum_DataTable.ExamAll)
            {
                string[] str_Keys = new string[] { "ExaminingNo" };
                string str_Sort = "ExaminingNo";
                string str_SQL = "Select * From View_Union_Exam_All";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.ExamAll.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WelderIssueStudentQCRegistrationNo) == Enum_DataTable.WelderIssueStudentQCRegistrationNo)
            {
                string[] str_Keys = new string[] { "ExaminingNo" };
                string str_Sort = "ExaminingNo";
                string str_SQL = "Select * From View_Union_Exam_WelderIssueStudentQCRegistrationNo";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WelderIssueStudentQCRegistrationNo.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WelderTestCommitteeRegistrationNo) == Enum_DataTable.WelderTestCommitteeRegistrationNo)
            {
                string[] str_Keys = new string[] { "TestCommitteeID", "RegistrationNo" };
                string str_Sort = "TestCommitteeID, RegistrationNo";
                string str_SQL = "Select * From View_Person_WelderTestCommitteeRegistrationNo";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WelderTestCommitteeRegistrationNo.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WelderBelong) == Enum_DataTable.WelderBelong)
            {
                string[] str_Keys = new string[] { "WelderBelongID" };
                string str_Sort = "WelderName";
                string str_SQL = "Select * From View_Person_WelderBelong";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WelderBelong.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WelderBelongQC) == Enum_DataTable.WelderBelongQC)
            {
                //不能设置主键，因为有焊工会同时出现在多个单位，造成连接后的考编号重复。
                string[] str_Keys = new string[] { };
                string str_Sort = "WelderName";
                string str_SQL = "Select * From View_Person_WelderBelong_QC";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WelderBelongQC.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WelderBelongExam) == Enum_DataTable.WelderBelongExam)
            {
                //不能设置主键，因为有焊工会同时出现在多个单位，造成连接后的考编号重复。
                string[] str_Keys = new string[] { };
                string str_Sort = "WelderName";
                string str_SQL = "Select * From View_Person_WelderBelong_Exam";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WelderBelongExam.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.KindofEmployerWelder) == Enum_DataTable.KindofEmployerWelder)
            {
                string[] str_Keys = new string[] { "KindofEmployerWelderID" };
                string str_Sort = "WelderName";
                string str_SQL = "Select * From View_SignUp_KindofEmployerWelder";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.KindofEmployerWelder.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.KindofEmployerIssue) == Enum_DataTable.KindofEmployerIssue)
            {
                string[] str_Keys = new string[] { "KindofEmployerIssueID" };
                string str_Sort = "IssueNo";
                string str_SQL = "Select * From View_SignUp_KindofEmployerIssue";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.KindofEmployerIssue.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.KindofEmployerStudent) == Enum_DataTable.KindofEmployerStudent)
            {
                string[] str_Keys = new string[] { "KindofEmployerStudentID" };
                string str_Sort = "KindofEmployerStudentID";
                string str_SQL = "Select * From View_SignUp_KindofEmployerStudent";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.KindofEmployerStudent.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.KindofEmployerExam) == Enum_DataTable.KindofEmployerExam)
            {
                string[] str_Keys = new string[] {  };
                string str_Sort = "WelderName";
                string str_SQL = "Select * From View_SignUp_KindofEmployerWelder_Exam";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.KindofEmployerExam.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.BlackList) == Enum_DataTable.BlackList)
            {
                string[] str_Keys = new string[] {  };
                string str_Sort = "WelderName";
                string str_SQL = "Select * From View_Person_BlackList";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.BlackList.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WPS) == Enum_DataTable.WPS)
            {
                string[] str_Keys = new string[] { "WPSID" };
                string str_Sort = "WPSID";
                string str_SQL = "Select * From View_Wps_WPS";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WPS.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.WeldingPosition) == Enum_DataTable.WeldingPosition)
            {
                string[] str_Keys = new string[] { "WeldingPosition" };
                string str_Sort = "WeldingPosition";
                string str_SQL = "Select * From Parameter_WeldingPosition";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.WeldingPosition.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTable.LayerWelding) == Enum_DataTable.LayerWelding)
            {
                string[] str_Keys = new string[] { "LayerWelding" };
                string str_Sort = "LayerWelding";
                string str_SQL = "Select * From Parameter_LayerWelding";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTable.LayerWelding.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }
        }

        static private void InitializeData(Enum_DataTableSecond  myEnum_DataTable)
        {
            if ((myEnum_DataTable & Enum_DataTableSecond.ReviveQC) == Enum_DataTableSecond.ReviveQC)
            {
                string[] str_Keys = new string[] { "ReviveQCID" };
                string str_Sort = "ReviveQCID DESC";
                string str_SQL = "Select * From View_Exam_ReviveQC";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.ReviveQC.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.WeldingEquipment) == Enum_DataTableSecond.WeldingEquipment)
            {
                string[] str_Keys = new string[] { "WeldingEquipment" };
                string str_Sort = "WeldingEquipment";
                string str_SQL = "Select * From Parameter_WeldingEquipment";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.WeldingEquipment.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.KindofWeld) == Enum_DataTableSecond.KindofWeld)
            {
                string[] str_Keys = new string[] { "KindofWeld" };
                string str_Sort = "KindofWeldIndex";
                string str_SQL = "Select * From Parameter_KindofWeld";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.KindofWeld.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.GrooveType) == Enum_DataTableSecond.GrooveType)
            {
                string[] str_Keys = new string[] { "GrooveType" };
                string str_Sort = "GrooveTypeIndex";
                string str_SQL = "Select * From Parameter_GrooveType";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.GrooveType.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.TypeofCurrentAndPolarity) == Enum_DataTableSecond.TypeofCurrentAndPolarity)
            {
                string[] str_Keys = new string[] { "TypeofCurrentAndPolarity" };
                string str_Sort = "TypeofCurrentAndPolarityIndex";
                string str_SQL = "Select * From Parameter_TypeofCurrentAndPolarity";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.TypeofCurrentAndPolarity.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.WPSWeldingSequence) == Enum_DataTableSecond.WPSWeldingSequence)
            {
                string[] str_Keys = new string[] { "WPSSequenceID" };
                string str_Sort = "WPSID, WPSSequencePassWeldingBegin, WPSSequencePassWeldingEnd, WPSSequenceID";
                string str_SQL = "Select *, (cast(WPSSequenceHeatInputMin as nvarchar(255)) + ' ~ ' + cast(WPSSequenceHeatInputMax as nvarchar(255))) AS WPSSequenceHeatInputRange From View_Wps_WPSWeldingSequence";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.WPSWeldingSequence.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.WPSWeldingLayer) == Enum_DataTableSecond.WPSWeldingLayer)
            {
                string[] str_Keys = new string[] { "WPSLayerID" };
                string str_Sort = "WPSID, WPSLayerNo";
                string str_SQL = "Select * From Wps_WPSWeldingLayer";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.WPSWeldingLayer.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.WPSGasAndWeldingFlux) == Enum_DataTableSecond.WPSGasAndWeldingFlux)
            {
                string[] str_Keys = new string[] { "WPSGasAndWeldingFluxID" };
                string str_Sort = "WPSID, WPSGasAndWeldingFlux";
                string str_SQL = "Select * From Wps_WPSGasAndWeldingFlux";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.WPSGasAndWeldingFlux.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.WPSHeatTreatment) == Enum_DataTableSecond.WPSHeatTreatment)
            {
                string[] str_Keys = new string[] { "WPSHeatTreatmentID" };
                string str_Sort = "WPSID, WPSHeatTreatment";
                string str_SQL = "Select * From WPS_WPSHeatTreatment";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.WPSHeatTreatment.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.WPSImage) == Enum_DataTableSecond.WPSImage)
            {
                string[] str_Keys = new string[] { "WPSImageID" };
                string str_Sort = "WPSID, WPSImageName";
                string str_SQL = "Select * From WPS_WPSImage";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.WPSImage.ToString(), str_Keys, "1=0", str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.GasAndWeldingFluxGroup) == Enum_DataTableSecond.GasAndWeldingFluxGroup)
            {
                string[] str_Keys = new string[] { "GasAndWeldingFluxGroup" };
                string str_Sort = "GasAndWeldingFluxGroup";
                string str_SQL = "Select * From Parameter_GasAndWeldingFluxGroup";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.GasAndWeldingFluxGroup.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.GasAndWeldingFlux) == Enum_DataTableSecond.GasAndWeldingFlux)
            {
                string[] str_Keys = new string[] { "GasAndWeldingFlux" };
                string str_Sort = "GasAndWeldingFlux";
                string str_SQL = "Select * From Parameter_GasAndWeldingFlux";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.GasAndWeldingFlux.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.HeatTreatment) == Enum_DataTableSecond.HeatTreatment)
            {
                string[] str_Keys = new string[] { "HeatTreatment" };
                string str_Sort = "HeatTreatmentIndex";
                string str_SQL = "Select * From Parameter_HeatTreatment";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.HeatTreatment.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.KindofLimit) == Enum_DataTableSecond.KindofLimit)
            {
                string[] str_Keys = new string[] { "KindofLimit" };
                string str_Sort = "KindofLimitIndex";
                string str_SQL = "Select * From Parameter_KindofLimit";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.KindofLimit.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.HeatMethod) == Enum_DataTableSecond.HeatMethod)
            {
                string[] str_Keys = new string[] { "HeatMethod" };
                string str_Sort = "HeatMethodIndex";
                string str_SQL = "Select * From Parameter_HeatMethod";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.HeatMethod.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.ImageGroup) == Enum_DataTableSecond.ImageGroup)
            {
                string[] str_Keys = new string[] { "ImageGroup" };
                string str_Sort = "ImageGroupIndex";
                string str_SQL = "Select * From Parameter_ImageGroup";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.ImageGroup.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.Flaw) == Enum_DataTableSecond.Flaw)
            {
                string[] str_Keys = new string[] { "Flaw" };
                string str_Sort = "FlawIndex";
                string str_SQL = "Select * From Parameter_Flaw";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.Flaw.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.Judgment) == Enum_DataTableSecond.Judgment)
            {
                string[] str_Keys = new string[] { "JudgmentID" };
                string str_Sort = "JudgmentID";
                string str_SQL = "Select * From Question_Judgment";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.Judgment.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.Choice) == Enum_DataTableSecond.Choice)
            {
                string[] str_Keys = new string[] { "ChoiceID" };
                string str_Sort = "ChoiceID";
                string str_SQL = "Select * From Question_Choice";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.Choice.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.EssayQuestion) == Enum_DataTableSecond.EssayQuestion)
            {
                string[] str_Keys = new string[] { "EssayQuestionID" };
                string str_Sort = "EssayQuestionID";
                string str_SQL = "Select * From Question_EssayQuestion";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.EssayQuestion.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.Subject) == Enum_DataTableSecond.Subject)
            {
                string[] str_Keys = new string[] { "Subject" };
                string str_Sort = "SubjectIndex";
                string str_SQL = "Select * From Question_Subject";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.Subject.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }

            if ((myEnum_DataTable & Enum_DataTableSecond.MultiChoice) == Enum_DataTableSecond.MultiChoice)
            {
                string[] str_Keys = new string[] { "MultiChoiceID" };
                string str_Sort = "MultiChoiceID";
                string str_SQL = "Select * From Question_MultiChoice";
                Class_Data myClass_Data = new Class_Data(str_SQL, Enum_DataTableSecond.MultiChoice.ToString(), str_Keys, null, str_Sort);
                myHashtable.Add(myClass_Data.myDataTable.TableName, myClass_Data);

            }


       }

        static public void ExportEMSExcel(string Linkman, string Employer, string EmployerAddress, string LinkTel, string EmployerCity, string Postalcode)
        {
            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            string  str_FileName = string.Format("{0}\\Data\\EMS_模板.xls", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            ZCExcel.Application myExcelApp = new ZCExcel.Application();
            ZCExcel.Workbook myExcelBook = myExcelApp.Workbooks.Open( str_FileName,  oMissing,  bool_ReadOnly,  oMissing,  oMissing,  oMissing,  oMissing,  oMissing,  oMissing, oMissing,  oMissing, oMissing,  oMissing,  oMissing,  oMissing);
            ZCExcel.Worksheet myExcelSheet = (ZCExcel.Worksheet)myExcelBook.Worksheets[1];

            myExcelSheet.get_Range("C2", System.Reflection.Missing.Value).Value2 = Class_zwjPublic.myClass_CustomUser.Name;
            myExcelSheet.get_Range("C8", System.Reflection.Missing.Value).Value2  = Class_zwjPublic.myClass_CustomUser.Name;
            myExcelSheet.get_Range("D2", System.Reflection.Missing.Value).Value2 = Properties.Settings.Default.LinkTel ;
            myExcelSheet.get_Range("B3", System.Reflection.Missing.Value).Value2 = Properties.Settings.Default.MailEmployer   ;
            myExcelSheet.get_Range("B4", System.Reflection.Missing.Value).Value2 = Properties.Settings.Default.MailEmployerAddress  ;
            string str_Postalcode;
            str_Postalcode = Properties.Settings.Default.MailEmployerPostalcode;
            if (str_Postalcode.Length == 6)
            {
                str_Postalcode=str_Postalcode.Insert(5, " ");
                str_Postalcode = str_Postalcode.Insert(4, " ");
                str_Postalcode = str_Postalcode.Insert(3, " ");
                str_Postalcode = str_Postalcode.Insert(2, " ");
                str_Postalcode = str_Postalcode.Insert(1, " ");
                str_Postalcode = str_Postalcode.Insert(0, " ");
            }
            myExcelSheet.get_Range("E5", System.Reflection.Missing.Value).Value2 = str_Postalcode;
            
            myExcelSheet.get_Range("G2", System.Reflection.Missing.Value).Value2 = Linkman  ;
            myExcelSheet.get_Range("G3", System.Reflection.Missing.Value).Value2 =Employer   ;
            myExcelSheet.get_Range("G4", System.Reflection.Missing.Value).Value2 =EmployerAddress  ;
            myExcelSheet.get_Range("I2", System.Reflection.Missing.Value).Value2 = LinkTel   ;
            str_Postalcode =Postalcode ;
            if (str_Postalcode.Length == 6)
            {
                str_Postalcode = str_Postalcode.Insert(6, "    ");
                str_Postalcode = str_Postalcode.Insert(5, " ");
                str_Postalcode = str_Postalcode.Insert(4, " ");
                str_Postalcode = str_Postalcode.Insert(3, " ");
                str_Postalcode = str_Postalcode.Insert(2, " ");
                str_Postalcode = str_Postalcode.Insert(1, " ");
            }
            myExcelSheet.get_Range("G5", System.Reflection.Missing.Value).Value2 = EmployerCity;
            myExcelSheet.get_Range("H5", System.Reflection.Missing.Value).Value2 = str_Postalcode;

            myExcelApp.Visible = true;
        }
   }

    static public class Class_ExamField
    {
        #region "Fields"
        static public int MonthsOfExamCheatRestrict;
        static public int MonthsOfExamRestrict;
        static public int TimesOfExamRestrict;
        static public int MonthsOfExamRestrictLast;
        static public bool UnFinishedExamRestrict;
        static public bool OverdueSwitch;
        static public int SupervisionOffset;
        static public int QCRegain;
        static public bool WelderUpdatebyLast;
        static public string  CCSApplyNo;
        static public string CCSSIGNNo;
        static public int WelderPictureFileLength;
        #endregion

        static Class_ExamField()
        {
            MonthsOfExamCheatRestrict = 6;
            MonthsOfExamRestrict = 3;
            TimesOfExamRestrict = 2;
            MonthsOfExamRestrictLast = 0;
            UnFinishedExamRestrict = false ;
            OverdueSwitch = true ;
            SupervisionOffset = 0;
            WelderUpdatebyLast = true  ;
            CCSApplyNo = "SH06-APPLY-11-00003";
            CCSSIGNNo = "SH06-SIGN-11-00001";
            WelderPictureFileLength = 524288;

            Class_SystemInformation myClass_SystemInformation;

            if (Class_SystemInformation.myHashtable_Parameter.Contains("CCSApplyNo".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["CCSApplyNo".ToLower()];
                CCSApplyNo = myClass_SystemInformation.ParameterValue;
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "CCSApplyNo";
                myClass_SystemInformation.ParameterValue = "SH06-APPLY-11-00003";
                myClass_SystemInformation.ParameterRemark = "CCS焊工证书申请控制号";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("CCSSIGNNo".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["CCSSIGNNo".ToLower()];
                CCSSIGNNo = myClass_SystemInformation.ParameterValue;
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "CCSSIGNNo";
                myClass_SystemInformation.ParameterValue = "SH06-SIGN-11-00001";
                myClass_SystemInformation.ParameterRemark = "CCS焊工证书签证申请控制号";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("WelderPictureFileLength".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["WelderPictureFileLength".ToLower()];
                int.TryParse( myClass_SystemInformation.ParameterValue, out WelderPictureFileLength);
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "WelderPictureFileLength";
                myClass_SystemInformation.ParameterValue = "524288";
                myClass_SystemInformation.ParameterRemark = "焊工照片限制大小";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("MonthsOfExamCheatRestrict".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["MonthsOfExamCheatRestrict".ToLower()];
                int.TryParse( myClass_SystemInformation.ParameterValue, out MonthsOfExamCheatRestrict);
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "MonthsOfExamCheatRestrict";
                myClass_SystemInformation.ParameterValue = "6";
                myClass_SystemInformation.ParameterRemark = "作弊、违规违纪限制间隔期(月)";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("MonthsOfExamRestrict".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["MonthsOfExamRestrict".ToLower()];
                int.TryParse(myClass_SystemInformation.ParameterValue, out MonthsOfExamRestrict);
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "MonthsOfExamRestrict";
                myClass_SystemInformation.ParameterValue = "3";
                myClass_SystemInformation.ParameterRemark = "考试次数限制月份(月)";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("TimesOfExamRestrict".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["TimesOfExamRestrict".ToLower()];
                int.TryParse(myClass_SystemInformation.ParameterValue, out TimesOfExamRestrict);
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "TimesOfExamRestrict";
                myClass_SystemInformation.ParameterValue = "2";
                myClass_SystemInformation.ParameterRemark = "考试次数限制月份限制次数";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("MonthsOfExamRestrictLast".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["MonthsOfExamRestrictLast".ToLower()];
                int.TryParse(myClass_SystemInformation.ParameterValue, out MonthsOfExamRestrictLast);
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "MonthsOfExamRestrictLast";
                myClass_SystemInformation.ParameterValue = "0";
                myClass_SystemInformation.ParameterRemark = "考试限制间隔期(月)";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("UnFinishedExamRestrict".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["UnFinishedExamRestrict".ToLower()];
                bool.TryParse(myClass_SystemInformation.ParameterValue, out UnFinishedExamRestrict);
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "UnFinishedExamRestrict";
                myClass_SystemInformation.ParameterValue = "true";
                myClass_SystemInformation.ParameterRemark = "考试未结束限制报考开关";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("OverdueSwitch".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["OverdueSwitch".ToLower()];
                bool.TryParse(myClass_SystemInformation.ParameterValue, out OverdueSwitch);
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "OverdueSwitch";
                myClass_SystemInformation.ParameterValue = "true";
                myClass_SystemInformation.ParameterRemark = "使用证书覆盖功能";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("SupervisionOffset".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["SupervisionOffset".ToLower()];
                int.TryParse(myClass_SystemInformation.ParameterValue, out SupervisionOffset);
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "SupervisionOffset";
                myClass_SystemInformation.ParameterValue = "0";
                myClass_SystemInformation.ParameterRemark = "签证月份偏移量(月)";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("QCRegain".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["QCRegain".ToLower()];
                int.TryParse(myClass_SystemInformation.ParameterValue, out QCRegain);
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "QCRegain";
                myClass_SystemInformation.ParameterValue = "0";
                myClass_SystemInformation.ParameterRemark = "复训月份偏移量(月)";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }
            
            if (Class_SystemInformation.myHashtable_Parameter.Contains("WelderUpdatebyLast".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["WelderUpdatebyLast".ToLower()];
                bool.TryParse(myClass_SystemInformation.ParameterValue, out WelderUpdatebyLast);
            }
            else
            {
                myClass_SystemInformation = new Class_SystemInformation();
                myClass_SystemInformation.Parameter = "WelderUpdatebyLast";
                myClass_SystemInformation.ParameterValue = "true";
                myClass_SystemInformation.ParameterRemark = "更新最新焊工信息";
                myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Add);
            }

        }

        static public void RefreshData()
        {
            Class_SystemInformation myClass_SystemInformation;

            if (Class_SystemInformation.myHashtable_Parameter.Contains("CCSApplyNo".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["CCSApplyNo".ToLower()];
                myClass_SystemInformation.FillData();
                CCSApplyNo = myClass_SystemInformation.ParameterValue;
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("CCSSIGNNo".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["CCSSIGNNo".ToLower()];
                myClass_SystemInformation.FillData();
                CCSSIGNNo = myClass_SystemInformation.ParameterValue;
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("WelderPictureFileLength".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["WelderPictureFileLength".ToLower()];
                myClass_SystemInformation.FillData();
                int.TryParse(myClass_SystemInformation.ParameterValue, out WelderPictureFileLength);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("MonthsOfExamCheatRestrict".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["MonthsOfExamCheatRestrict".ToLower()];
                myClass_SystemInformation.FillData();
                int.TryParse(myClass_SystemInformation.ParameterValue, out MonthsOfExamCheatRestrict);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("MonthsOfExamRestrict".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["MonthsOfExamRestrict".ToLower()];
                myClass_SystemInformation.FillData();
                int.TryParse(myClass_SystemInformation.ParameterValue, out MonthsOfExamRestrict);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("TimesOfExamRestrict".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["TimesOfExamRestrict".ToLower()];
                myClass_SystemInformation.FillData();
                int.TryParse(myClass_SystemInformation.ParameterValue, out TimesOfExamRestrict);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("MonthsOfExamRestrictLast".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["MonthsOfExamRestrictLast".ToLower()];
                myClass_SystemInformation.FillData();
                int.TryParse(myClass_SystemInformation.ParameterValue, out MonthsOfExamRestrictLast);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("UnFinishedExamRestrict".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["UnFinishedExamRestrict".ToLower()];
                myClass_SystemInformation.FillData();
                bool.TryParse(myClass_SystemInformation.ParameterValue, out UnFinishedExamRestrict);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("OverdueSwitch".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["OverdueSwitch".ToLower()];
                myClass_SystemInformation.FillData();
                bool.TryParse(myClass_SystemInformation.ParameterValue, out OverdueSwitch);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("SupervisionOffset".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["SupervisionOffset".ToLower()];
                myClass_SystemInformation.FillData();
                int.TryParse(myClass_SystemInformation.ParameterValue, out SupervisionOffset);
            }

            if (Class_SystemInformation.myHashtable_Parameter.Contains("QCRegain".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["QCRegain".ToLower()];
                myClass_SystemInformation.FillData();
                int.TryParse(myClass_SystemInformation.ParameterValue, out QCRegain);
            }
            
            if (Class_SystemInformation.myHashtable_Parameter.Contains("WelderUpdatebyLast".ToLower()))
            {
                myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["WelderUpdatebyLast".ToLower()];
                myClass_SystemInformation.FillData();
                bool.TryParse(myClass_SystemInformation.ParameterValue, out WelderUpdatebyLast);
            }

        }

        static public void UpdateField()
        {
            Class_SystemInformation myClass_SystemInformation;
            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["MonthsOfExamCheatRestrict".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.MonthsOfExamCheatRestrict.ToString();
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);

            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["MonthsOfExamRestrict".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.MonthsOfExamRestrict .ToString();
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);

            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["MonthsOfExamRestrictLast".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.MonthsOfExamRestrictLast .ToString();
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);

            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["OverdueSwitch".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.OverdueSwitch .ToString();
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);

            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["SupervisionOffset".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.SupervisionOffset .ToString();
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);

            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["QCRegain".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.QCRegain.ToString();
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);

            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["TimesOfExamRestrict".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.TimesOfExamRestrict .ToString();
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);

            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["UnFinishedExamRestrict".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.UnFinishedExamRestrict .ToString();
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);

            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["WelderUpdatebyLast".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.WelderUpdatebyLast.ToString();
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);

            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["CCSApplyNo".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.CCSApplyNo;
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);

            myClass_SystemInformation = (Class_SystemInformation)Class_SystemInformation.myHashtable_Parameter["CCSSIGNNo".ToLower()];
            myClass_SystemInformation.ParameterValue = Class_ExamField.CCSSIGNNo ;
            myClass_SystemInformation.AddAndModify(Enum_zwjKindofUpdate.Modify);
        }
    }

}
