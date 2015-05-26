using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;

namespace ZCWelder.UserControlFirst
{
    public partial class UserControl_Exam : UserControl
    {
        public UserControl_Exam()
        {
            InitializeComponent();
        }

        private void UserControl_Exam_Load(object sender, EventArgs e)
        {
            for (int i = this.tabControl_Student .TabCount - 1; i >= 0; i--)
            {
                this.tabControl_Student.SelectedIndex = i;
            }

            Publisher_ShipClassification.EventName += new EventHandler_ShipClassification(InitstatusStrip);
            Publisher_Issue.EventName += new EventHandler_Issue(InitstatusStrip);
            Publisher_Student.EventName += new EventHandler_Student(InitstatusStrip);
        }

        private void InitstatusStrip(object sender, EventArgs_ShipClassification e)
        {
            string str_Filter;
            if (!string.IsNullOrEmpty(e.str_ShipClassificationAb))
            {
                str_Filter = string.Format("船级社：{0}", e.str_ShipClassificationAb);
                if (!string.IsNullOrEmpty(e.str_ShipboardNo))
                {
                    str_Filter += string.Format(" -> {0}", e.str_ShipboardNo);
                    if (e.bool_GXTheory)
                    {
                        str_Filter += " -> 理论考试";
                    }
                    //else
                    //{
                    //    str_Filter += " -> 技能考试";
                    //}

                }
                else if (!string.IsNullOrEmpty(e.str_Year))
                {
                    str_Filter += string.Format(" -> {0}", e.str_Year);
                }
            }
            else
            {
                str_Filter = string.Format("检索条件：{0}", e.str_Filter );
            }
            this.toolStripStatusLabel_ShipClassification.Text = str_Filter;
        }

        private void InitstatusStrip(object sender, EventArgs_Issue e)
        {
            this.toolStripStatusLabel_IssueNo  .Text = string.Format("班级编号：{0}", e.str_IssueNo ) ;
        }

        private void InitstatusStrip(object sender, EventArgs_Student e)
        {
            this.toolStripStatusLabel_ExaminingNo .Text =string.Format("钢印号：{0}",e.str_ExaminingNo );
        }
    }
}
