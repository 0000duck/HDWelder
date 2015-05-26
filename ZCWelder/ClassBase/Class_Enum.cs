using System;
using System.Collections.Generic;
using System.Text;

namespace ZCWelder.ClassBase
{
    public enum   Enum_DataTable : long
    {
        Schooling = 1,
        WeldingPosition = 2,
        Assemblage = 4,
        ExamStatus = 8,
        JointType = 16,
        Material =32 ,
        WeldingConsumable =64,
        WorkPieceType = 128,
        MaterialCCSGroup = 256,
        KindofExam = 512,
        LayerWelding = 1024,
        Employer =2048,
        MaterialISOGroup = 4096,
        ShipClassification = 8192,
        WeldingStandard = 16384 ,
        WeldingStandardAndGroup = 32768 ,
        Ship = 65536,
        ShipandShipClassification = 131072,
        TestCommittee = 262144,
        WeldingConsumableCCSGroup = 524288,
        WeldingConsumableISOGroup = 1048576,
        WeldingSubject = 2097152,
        WeldingSubjectApplicable = 4194304,
        WeldingSubjectPosition = 8388608,
        WeldingProcess = 16777216,
        Issue = 33554432 ,
        WelderStudentQC = 67108864,
        WelderIssueStudentQCRegistrationNo = 134217728,
        Welder = 268435456,
        WelderBelong = 536870912,
        GXTheoryIssue = 1073741824,
        GXTheoryWelderStudent = 2147483648,
        SubjectPositionResult = 4294967296,
        LaborServiceTeam = 8589934592,
        KindofEmployer = 17179869184,
        SubjectPositionResultSecond = 34359738368,
        WelderTestCommitteeRegistrationNo = 68719476736,
        WelderBelongLog = 137438953472,
        IssueProcess = 274877906944,
        GXTheoryIssueProcess = 549755813888,
        IssueProcessUnion = 1099511627776,
        IssueStudentQCRegistrationNo = 2199023255552,
        WelderBelongQC= 4398046511104,
        WelderBelongExam = 8796093022208,
        EmployerGroup = 17592186044416,
        KindofEmployerWelder = 35184372088832,
        BlackList = 70368744177664,
        Department = 140737488355328,
        WorkPlace = 281474976710656,
        KindofEmployerIssue = 562949953421312,
        KindofEmployerStudent = 1125899906842624,
        KindofEmployerExam = 2251799813685248,
        WeldingStandardGroup = 4503599627370496,
        ExamAll = 9007199254740992,
        MaterialCCSGrade = 18014398509481984,
        MaterialGBName = 36028797018963968,
        GrooveType = 72057594037927936,
        ProjectGroup = 144115188075855872,
        WeldingConsumableCCSGrade = 288230376151711744,
        WeldingConsumableGBName = 576460752303423488,
        KindofMaterial = 1152921504606846976,
        KindofWeldingConsumable = 2305843009213693952,
        WPS = 4611686018427387904

        //WeldingEquipment = 268435456,
        
    }

    public enum Enum_DataTableSecond : long
    {
        WeldingEquipment = 1,
        KindofWeld = 2,
        GrooveType = 4,
        TypeofCurrentAndPolarity = 8,
        WPSWeldingSequence= 16,
        WPSWeldingLayer= 32,
        WPSGasAndWeldingFlux = 64,
        WPSHeatTreatment= 128,
        WPSImage = 256,
        GasAndWeldingFluxGroup = 512,
        GasAndWeldingFlux = 1024,
        HeatTreatment = 2048,
        KindofLimit = 4096,
        HeatMethod = 8192,
        ImageGroup= 16384,
        Flaw = 32768,
        ReviveQC = 65536,
        Choice = 131072,
        EssayQuestion = 262144,
        Judgment = 524288,
        MultiChoice = 1048576,
        Subject = 2097152
        //WeldingSubjectApplicable = 4194304,
        //WeldingSubjectPosition = 8388608,
        //WeldingProcess = 16777216,
        //Issue = 33554432,
        //WelderStudentQC = 67108864,
        //WelderIssueStudentQCRegistrationNo = 134217728,
        //Welder = 268435456,
        //WelderBelong = 536870912,
        //GXTheoryIssue = 1073741824,
        //GXTheoryWelderStudent = 2147483648,
        //SubjectPositionResult = 4294967296,
        //LaborServiceTeam = 8589934592,
        //KindofEmployer = 17179869184,
        //SubjectPositionResultSecond = 34359738368,
        //WelderTestCommitteeRegistrationNo = 68719476736,
        //Flaw = 137438953472,
        //IssueProcess = 274877906944,
        //GXTheoryIssueProcess = 549755813888,
        //IssueProcessUnion = 1099511627776,
        //IssueStudentQCRegistrationNo = 2199023255552,
        //WelderBelongQC = 4398046511104,
        //WelderBelongExam = 8796093022208,
        //EmployerGroup = 17592186044416,
        //KindofEmployerWelder = 35184372088832,
        //BlackList = 70368744177664,
        //Department = 140737488355328,
        //WorkPlace = 281474976710656,
        //KindofEmployerIssue = 562949953421312,
        //KindofEmployerStudent = 1125899906842624,
        //KindofEmployerExam = 2251799813685248,
        //WeldingStandardGroup = 4503599627370496,
        //ExamAll = 9007199254740992,
        //MaterialCCSGrade = 18014398509481984,
        //MaterialGBName = 36028797018963968,
        //GrooveType = 72057594037927936,
        //ProjectGroup = 144115188075855872,
        //WeldingConsumableCCSGrade = 288230376151711744,
        //WeldingConsumableGBName = 576460752303423488,
        //KindofMaterial = 1152921504606846976,
        //KindofWeldingConsumable = 2305843009213693952,
        //WPS = 4611686018427387904

    }

}
