using System;
using System.Collections.Generic;
using System.Text;

namespace ZCWelder.ClassBase
{
    public class EventArgs_Parameter : EventArgs
    {
        public string str_Parameter;
        public string str_ParameterName;
        public string str_ParameterKey;
        public string str_Filter;
        public bool bool_isFilter;

        public EventArgs_Parameter(string str_Parameter, string str_ParameterName)
        {
            this.str_Parameter = str_Parameter;
            this.str_ParameterName = str_ParameterName;
            this.bool_isFilter = false;
        }

        public EventArgs_Parameter(string str_Parameter, string str_ParameterName, string str_ParameterKey)
        {
            this.str_Parameter = str_Parameter;
            this.str_ParameterName = str_ParameterName;
            this.str_ParameterKey = str_ParameterKey;
            this.bool_isFilter = false;
        }
    }

    public delegate void EventHandler_Parameter(object sender, EventArgs_Parameter e);

    static public class Publisher_Parameter
    {
        static public event EventHandler_Parameter EventName;

        static public void OnEventName(EventArgs_Parameter e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }

    public class EventArgs_ShipClassification : EventArgs
    {
        public string str_ShipClassificationAb;
        public string str_ShipboardNo;
        public string str_Year;
        public bool  bool_GXTheory;
        public string str_Filter;
        public bool bool_JustFill=false ;

        public EventArgs_ShipClassification(string str_ShipClassificationAb, bool  bool_GXTheory)
        {
            this.str_ShipClassificationAb = str_ShipClassificationAb;
            this.bool_GXTheory = bool_GXTheory;
        }
    }

    public delegate void EventHandler_ShipClassification(object sender, EventArgs_ShipClassification e);

    static public class Publisher_ShipClassification
    {
        static public event EventHandler_ShipClassification EventName;

        static public void OnEventName(EventArgs_ShipClassification e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }
    
    public class EventArgs_Issue : EventArgs
    {
        public string str_IssueNo;
        /// <summary>
        /// Issue »ò GXTheory
        /// </summary>
        public bool bool_GXTheory;
        public bool bool_JustFill = false;

        public EventArgs_Issue(string str_IssueNo, bool bool_GXTheory)
        {
            this.str_IssueNo = str_IssueNo;
            this.bool_GXTheory = bool_GXTheory;
        }
    }

    public delegate void EventHandler_Issue(object sender, EventArgs_Issue e);

    static public class Publisher_Issue
    {
        static public event EventHandler_Issue EventName;

        static public void OnEventName(EventArgs_Issue e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }
    
    public class EventArgs_WelderFilter : EventArgs
    {
        public string str_IdentificationCard;
        public string str_WelderName;
        public string str_WelderWorkerID;
        public string str_RegistrationNo;
        public string str_ExaminingNo;
        public string str_CertificateNo;
        public string str_IssueNo; 
        public string str_Filter;

        public EventArgs_WelderFilter(string str_Filter)
        {
            this.str_Filter = str_Filter;
        }
    }

    public delegate void EventHandler_WelderFilter(object sender, EventArgs_WelderFilter e);

    static public class Publisher_WelderFilter
    {
        static public event EventHandler_WelderFilter EventName;

        static public void OnEventName(EventArgs_WelderFilter e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }
    
    public class EventArgs_Student : EventArgs
    {
        public string str_ExaminingNo;
        public string str_IdentificationCard;
        public bool bool_GXTheory;
        public bool bool_JustFill = false;

        public EventArgs_Student(string str_ExaminingNo, string str_IdentificationCard, bool bool_GXTheory)
        {
            this.str_ExaminingNo = str_ExaminingNo;
            this.str_IdentificationCard = str_IdentificationCard;
            this.bool_GXTheory = bool_GXTheory;
        }
    }

    public delegate void EventHandler_Student(object sender, EventArgs_Student e);

    static public class Publisher_Student
    {
        static public event EventHandler_Student EventName;

        static public void OnEventName(EventArgs_Student e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }
    
    public class EventArgs_Welder : EventArgs
    {
        public string str_IdentificationCard;

        public EventArgs_Welder( string str_IdentificationCard)
        {
            this.str_IdentificationCard = str_IdentificationCard;
        }
    }

    public delegate void EventHandler_Welder(object sender, EventArgs_Welder e);

    static public class Publisher_Welder
    {
        static public event EventHandler_Welder EventName;

        static public void OnEventName(EventArgs_Welder e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }
    
    public class EventArgs_StudentSecond : EventArgs
    {
        public string str_ExaminingNo;

        public EventArgs_StudentSecond(string str_ExaminingNo)
        {
            this.str_ExaminingNo = str_ExaminingNo;
        }
    }

    public delegate void EventHandler_StudentSecond(object sender, EventArgs_StudentSecond e);

    static public class Publisher_StudentSecond
    {
        static public event EventHandler_StudentSecond EventName;

        static public void OnEventName(EventArgs_StudentSecond e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }

    public class EventArgs_DataManager : EventArgs
    {
        public string str_DataManagerText;
        public string str_DataManagerName;
        public string str_DataManagerTag;
        public string str_Filter;

        public EventArgs_DataManager(string str_DataManagerText, string str_DataManagerName, string str_DataManagerTag)
        {
            this.str_DataManagerText = str_DataManagerText;
            this.str_DataManagerName = str_DataManagerName;
            this.str_DataManagerTag = str_DataManagerTag;
        }
    }

    public delegate void EventHandler_DataManager(object sender, EventArgs_DataManager e);

    static public class Publisher_DataManager
    {
        static public event EventHandler_DataManager EventName;

        static public void OnEventName(EventArgs_DataManager e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }

    public class EventArgs_WeldingStandard : EventArgs
    {
        public string str_WeldingStandard;
        public string str_Filter;
        public bool bool_JustFill = false;

        public EventArgs_WeldingStandard(string str_WeldingStandard)
        {
            this.str_WeldingStandard = str_WeldingStandard;
        }
    }

    public delegate void EventHandler_WeldingStandard(object sender, EventArgs_WeldingStandard e);

    static public class Publisher_WeldingStandard
    {
        static public event EventHandler_WeldingStandard EventName;

        static public void OnEventName(EventArgs_WeldingStandard e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }

    public class EventArgs_WeldingSubject : EventArgs
    {
        public string str_SubjectID;
        public bool bool_JustFill = false;

        public EventArgs_WeldingSubject(string str_SubjectID)
        {
            this.str_SubjectID = str_SubjectID;
        }
    }

    public delegate void EventHandler_WeldingSubject(object sender, EventArgs_WeldingSubject e);

    static public class Publisher_WeldingSubject
    {
        static public event EventHandler_WeldingSubject EventName;

        static public void OnEventName(EventArgs_WeldingSubject e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }

    public class EventArgs_Unit : EventArgs
    {
        public string EmployerGroup;
        public string EmployerHPID;
        public string DepartmentHPID;
        public string WorkPlaceHPID;
        public bool bool_JustFill = false;

        public EventArgs_Unit(string EmployerHPID, string DepartmentHPID, string WorkPlaceHPID)
        {
            this.EmployerHPID = EmployerHPID;
            this.DepartmentHPID = DepartmentHPID;
            this.WorkPlaceHPID = WorkPlaceHPID;
        }

        public EventArgs_Unit()
        {
        }
    }

    public delegate void EventHandler_Unit(object sender, EventArgs_Unit e);

    static public class Publisher_Unit
    {
        static public event EventHandler_Unit EventName;

        static public void OnEventName(EventArgs_Unit e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }

    public class EventArgs_WelderBelong : EventArgs
    {
        public string str_IdentificationCard;
        public bool bool_JustFill = false;

        public EventArgs_WelderBelong(string str_IdentificationCard)
        {
            this.str_IdentificationCard = str_IdentificationCard;
        }
    }

    public delegate void EventHandler_WelderBelong(object sender, EventArgs_WelderBelong e);

    static public class Publisher_WelderBelong
    {
        static public event EventHandler_WelderBelong EventName;

        static public void OnEventName(EventArgs_WelderBelong e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }

    public class EventArgs_KindofEmployer : EventArgs
    {
        public string str_KindofEmployer;
        public string str_Filter;
        public bool bool_JustFill = false;

        public EventArgs_KindofEmployer(string str_KindofEmployer)
        {
            this.str_KindofEmployer = str_KindofEmployer;
        }

        public EventArgs_KindofEmployer()
        {
        }
    }

    public delegate void EventHandler_KindofEmployer(object sender, EventArgs_KindofEmployer e);

    static public class Publisher_KindofEmployer
    {
        static public event EventHandler_KindofEmployer EventName;

        static public void OnEventName(EventArgs_KindofEmployer e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }

    public class EventArgs_KindofEmployerIssue : EventArgs
    {
        public int int_KindofEmployerIssueID;
        public bool bool_JustFill = false;

        public EventArgs_KindofEmployerIssue(int int_KindofEmployerIssueID)
        {
            this.int_KindofEmployerIssueID = int_KindofEmployerIssueID;
        }

        public EventArgs_KindofEmployerIssue()
        {
        }
    }

    public delegate void EventHandler_KindofEmployerIssue(object sender, EventArgs_KindofEmployerIssue e);

    static public class Publisher_KindofEmployerIssue
    {
        static public event EventHandler_KindofEmployerIssue EventName;

        static public void OnEventName(EventArgs_KindofEmployerIssue e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }
    
    public class EventArgs_WPSQuery : EventArgs
    {
        public string str_Filter;
        public bool bool_JustFill = false;

        public EventArgs_WPSQuery(string str_Filter)
        {
            this.str_Filter = str_Filter;
        }

        public EventArgs_WPSQuery()
        {
        }
    }

    public delegate void EventHandler_WPSQuery(object sender, EventArgs_WPSQuery e);

    static public class Publisher_WPSQuery
    {
        static public event EventHandler_WPSQuery EventName;

        static public void OnEventName(EventArgs_WPSQuery e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }

    public class EventArgs_WPS : EventArgs
    {
        public string str_WPSID;
        public bool bool_JustFill = false;

        public EventArgs_WPS(string str_WPSID)
        {
            this.str_WPSID = str_WPSID;
        }
    }

    public delegate void EventHandler_WPS(object sender, EventArgs_WPS e);

    static public class Publisher_WPS
    {
        static public event EventHandler_WPS EventName;

        static public void OnEventName(EventArgs_WPS e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }
        
    public class EventArgs_ReviveQC : EventArgs
    {
        public string str_Filter;
        public bool bool_JustFill = false;

        public EventArgs_ReviveQC(string str_Filter)
        {
            this.str_Filter = str_Filter;
        }

        public EventArgs_ReviveQC()
        {
        }
    }

    public delegate void EventHandler_ReviveQC(object sender, EventArgs_ReviveQC e);

    static public class Publisher_ReviveQC
    {
        static public event EventHandler_ReviveQC EventName;

        static public void OnEventName(EventArgs_ReviveQC e)
        {
            if (EventName != null)
            {
                EventName(null, e);
            }
        }
    }
}
