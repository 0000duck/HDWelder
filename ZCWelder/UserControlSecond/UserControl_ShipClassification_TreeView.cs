using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;
using ZCCL.ClassBase;
using ZCCL.DataGridViewManager ;

namespace ZCWelder.UserControlSecond
{
    public partial class UserControl_ShipClassification_TreeView : UserControl
    {
        private bool  bool_GXTheory;

        public UserControl_ShipClassification_TreeView()
        {
            InitializeComponent();
        }

        private void UserControl_ShipClassification_TreeView_Load(object sender, EventArgs e)
        {
            this.InitTreeView();
            this.InitControls();
        }

        /// <summary>
        /// 年份控制与船号控制不能同时使用
        /// 理论控制只适用于船号控制
        /// </summary>
        private void InitTreeView()
        {
            this.treeView_Data .Nodes.Clear();
            TreeNode myTreeNode;
            TreeNode myTreeNode_ShipClassification;
            TreeNode myTreeNode_Ship;
            TreeNode myTreeNode_Year;
            TreeNode myTreeNode_Theory;

            myTreeNode = new TreeNode();
            myTreeNode.Text = "全部";
            myTreeNode.Tag = "全部";

            Class_Data myClass_Data = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ShipClassification .ToString()];
            Class_Data myClass_ShipandShipClassification = (Class_Data)Class_Public.myHashtable[Enum_DataTable.ShipandShipClassification.ToString()];
            DataView myDataView_ShipandShipClassification = new DataView(myClass_ShipandShipClassification.myDataTable);
            myDataView_ShipandShipClassification.Sort = myClass_ShipandShipClassification.myDataView.Sort;

            foreach (DataRowView myDataRowView in myClass_Data.myDataView)
            {
                myTreeNode_ShipClassification = new TreeNode();
                myTreeNode_ShipClassification.Text = myDataRowView["ShipClassification"].ToString();
                myTreeNode_ShipClassification.Tag = myDataRowView["ShipClassificationAb"].ToString();
                if ((bool)myDataRowView["ShipRestrict"] )
                {
                    myDataView_ShipandShipClassification.RowFilter = string.Format("ShipClassificationAb='{0}'", myDataRowView["ShipClassificationAb"].ToString());
                    foreach (DataRowView myDataRowView_Ship in myDataView_ShipandShipClassification)
                    {
                        myTreeNode_Ship = new TreeNode();
                        myTreeNode_Ship.Text = myDataRowView_Ship["ShipboardNo"].ToString ();
                        myTreeNode_Ship.Tag = "ShipboardNo";
                        if ((bool)myDataRowView["TheorySeparate"])
                        {
                            myTreeNode_Theory = new TreeNode();
                            myTreeNode_Theory.Text = "理论考试";
                            myTreeNode_Theory.Tag = true ;
                            myTreeNode_Ship.Nodes.Add(myTreeNode_Theory);
                            myTreeNode_Theory = new TreeNode();
                            myTreeNode_Theory.Text = "技能考试";
                            myTreeNode_Theory.Tag = false ;
                            myTreeNode_Ship.Nodes.Add(myTreeNode_Theory);
                        }
                        myTreeNode_ShipClassification.Nodes.Add(myTreeNode_Ship);
                    }
                }
                else if ((bool)myDataRowView["YearSeparate"])
                {
                    int int_YearBegin=(int)myDataRowView["YearBegin"];
                    int int_YearEnd=(int)myDataRowView["YearEnd"] ;
                    for (int i = int_YearBegin;i<=int_YearEnd;i++)
                    {
                       myTreeNode_Year = new TreeNode();
                        myTreeNode_Year.Text = i.ToString();
                        myTreeNode_Year.Tag = "Year";
                        if ( i == int_YearEnd)
                        {
                            myTreeNode_Year.NodeFont = new Font(this.treeView_Data.Font, this.treeView_Data.Font.Style | FontStyle.Bold);
                        }
                        myTreeNode_ShipClassification.Nodes.Add(myTreeNode_Year);
                    }
                }
                myTreeNode.Nodes.Add(myTreeNode_ShipClassification);
            }
            this.treeView_Data.Nodes.Add(myTreeNode);
            this.label_Data.Text = string.Format("船级社，（{0}）：", myTreeNode.Nodes.Count);
            this.treeView_Data.Select();
            myTreeNode.Expand();
            //EventArgs_ShipClassification my_e = new EventArgs_ShipClassification(null, false );
            //Publisher_ShipClassification.OnEventName(my_e);
        }

        private void InitControls()
        {
            this.comboBox_KindofEmployer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox_KindofEmployer.AutoCompleteSource = AutoCompleteSource.ListItems;

            Class_Public.InitializeComboBox(this.ComboBox_WeldingProcessAb, Enum_DataTable.WeldingProcess.ToString(), "WeldingProcessAb", "WeldingProcessAb");
            Class_Public.InitializeComboBox(this.comboBox_Material, Enum_DataTable.Material.ToString(), "Material", "Material");
            Class_Public.InitializeComboBox(this.ComboBox_Employer, Enum_DataTable.Employer.ToString(), "EmployerHPID", "Employer");
            Class_Public.InitializeComboBox(this.comboBox_KindofEmployer, Enum_DataTable.KindofEmployer.ToString(), "KindofEmployer", "KindofEmployer");
            Class_Public.InitializeComboBox(this.comboBox_ShipboardNo, Enum_DataTable.Ship.ToString(), "ShipboardNo", "ShipboardNo");
            Class_Public.InitializeComboBox(this.comboBox_WeldingConsumable, Enum_DataTable.WeldingConsumable.ToString(), "WeldingConsumable", "WeldingConsumable");
            Class_Public.InitializeComboBox(this.comboBox_ShipClassificationAb, Enum_DataTable.ShipClassification.ToString(), "ShipClassificationAb", "ShipClassificationAb");

            this.comboBox_Material.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox_Material.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.comboBox_WeldingConsumable.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox_WeldingConsumable.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.ComboBox_Employer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.ComboBox_Employer.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.ComboBox_Employer.Text = "";
            this.comboBox_KindofEmployer.Text = "";
            this.comboBox_Material.Text = "";
            this.comboBox_ShipboardNo.Text = "";
            this.comboBox_WeldingConsumable.Text = "";
            this.ComboBox_WeldingProcessAb.Text = "";
            this.comboBox_ShipClassificationAb.Text = "";

        }

        private void toolStripMenuItem_DataGridViewColumnGroupRefresh_Click(object sender, EventArgs e)
        {
            this.InitTreeView();
        }

        private void treeView_Data_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EventArgs_ShipClassification my_e = new EventArgs_ShipClassification(null, false );
            switch (this.treeView_Data.SelectedNode.Level)
            {
                case 0:
                    break;
                case 1:
                    my_e.str_ShipClassificationAb = this.treeView_Data.SelectedNode.Tag.ToString();
                    break;
                case 2:
                    my_e.str_ShipClassificationAb = this.treeView_Data.SelectedNode.Parent.Tag.ToString();
                    if (this.treeView_Data.SelectedNode.Tag.ToString() == "ShipboardNo")
                    {
                        my_e.str_ShipboardNo = this.treeView_Data.SelectedNode.Text;
                    }
                    else
                    {
                        my_e.str_Year  = this.treeView_Data.SelectedNode.Text;
                    }
                    break;
                case 3:
                    my_e.str_ShipClassificationAb = this.treeView_Data.SelectedNode.Parent .Parent.Tag.ToString();
                    my_e.str_ShipboardNo = this.treeView_Data.SelectedNode.Parent.Text;
                    my_e.bool_GXTheory  =(bool ) this.treeView_Data.SelectedNode.Tag ;
                    break;
            }
            this.bool_GXTheory = my_e.bool_GXTheory;
            Publisher_ShipClassification.OnEventName(my_e);

        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            string str_Filter = "1=1";
            if (this.MaskedTextBox_IssueNoBegin.Text.Length > 0)
            {
                if (string.IsNullOrEmpty(this.MaskedTextBox_IssueNoBegin.Text))
                {
                    str_Filter = str_Filter + string.Format(" And IssueNo = '{0}'", this.MaskedTextBox_IssueNoBegin.Text);
                }
                else
                {
                    str_Filter = str_Filter + string.Format(" And (IssueNo >= '{0}' And IssueNo <= '{1}')", this.MaskedTextBox_IssueNoBegin.Text, this.MaskedTextBox_IssueNoEnd .Text);
                }
            }
            if (this.ComboBox_WeldingProcessAb .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And WeldingProcessAb = '{0}'", this.ComboBox_WeldingProcessAb .Text);
            }
            if (this.ComboBox_Employer .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And IssueEmployer = '{0}'", this.ComboBox_Employer.Text);
            }
            if (this.comboBox_KindofEmployer .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And KindofEmployer = '{0}'", this.comboBox_KindofEmployer.Text);
            }
            if (this.comboBox_ShipClassificationAb .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And ShipClassificationAb = '{0}'", this.comboBox_ShipClassificationAb.Text);
            }
            if (this.comboBox_ShipboardNo  .Text.Length > 0)
            {
                str_Filter = str_Filter + string.Format(" And ShipboardNo = '{0}'", this.comboBox_ShipboardNo.Text);
            }
            if (!this.bool_GXTheory)
            {
                if (this.comboBox_Material  .Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And IssueMaterial = '{0}'", this.comboBox_Material .Text);
                }
                if (this.comboBox_WeldingConsumable   .Text.Length > 0)
                {
                    str_Filter = str_Filter + string.Format(" And IssueWeldingConsumable = '{0}'", this.comboBox_WeldingConsumable.Text);
                }
            }
            switch (this.ComboBox_SignUpDate.Text)
            {
                case "报名日期起始":
                    str_Filter = str_Filter + string.Format(" And SignUpDate >= '{0}' And SignUpDate < '{1}'", this.DateTimePicker_SignUpDateBegin.Value.Date, this.DateTimePicker_SignUpDateEnd.Value.Date.AddDays(1));
                    break;
                case "培训开始日期":
                    str_Filter = str_Filter + string.Format(" And DateBeginningofTrain >= '{0}' And DateBeginningofTrain < '{1}'", this.DateTimePicker_SignUpDateBegin.Value.Date, this.DateTimePicker_SignUpDateEnd.Value.Date.AddDays(1));
                    break;
                case "培训结束日期":
                    str_Filter = str_Filter + string.Format(" And DateEndingofTrain >= '{0}' And DateEndingofTrain < '{1}'", this.DateTimePicker_SignUpDateBegin.Value.Date, this.DateTimePicker_SignUpDateEnd.Value.Date.AddDays(1));
                    break;
                case "理论考试日期":
                    str_Filter = str_Filter + string.Format(" And TheoryExamDate >= '{0}' And TheoryExamDate < '{1}'", this.DateTimePicker_SignUpDateBegin.Value.Date, this.DateTimePicker_SignUpDateEnd.Value.Date.AddDays(1));
                    break;
                case "技能考试日期":
                    if (!this.bool_GXTheory)
                    {
                        str_Filter = str_Filter + string.Format(" And SkillExamDate >= '{0}' And SkillExamDate < '{1}'", this.DateTimePicker_SignUpDateBegin.Value.Date, this.DateTimePicker_SignUpDateEnd.Value.Date.AddDays(1));
                    }
                    break;
                case "理论补考日期":
                    str_Filter = str_Filter + string.Format(" And TheoryMakeupDate >= '{0}' And TheoryMakeupDate < '{1}'", this.DateTimePicker_SignUpDateBegin.Value.Date, this.DateTimePicker_SignUpDateEnd.Value.Date.AddDays(1));
                    break;
                case "技能补考日期":
                    if (!this.bool_GXTheory)
                    {
                        str_Filter = str_Filter + string.Format(" And SkillMakeupDate >= '{0}' And SkillMakeupDate < '{1}'", this.DateTimePicker_SignUpDateBegin.Value.Date, this.DateTimePicker_SignUpDateEnd.Value.Date.AddDays(1));
                    }
                    break;
                case "办证日期起始":
                    str_Filter = str_Filter + string.Format(" And IssueIssuedOn >= '{0}' And IssueIssuedOn < '{1}'", this.DateTimePicker_SignUpDateBegin.Value.Date, this.DateTimePicker_SignUpDateEnd.Value.Date.AddDays(1));
                    break;
                default:
                    break;
            }
            EventArgs_ShipClassification g = new EventArgs_ShipClassification(null, this.bool_GXTheory);
            g.str_Filter = str_Filter;
            Publisher_ShipClassification.OnEventName(g);
        }

        private void button_QueryAdvance_Click(object sender, EventArgs e)
        {
            Form_QueryFilter myForm = new Form_QueryFilter();
            if (this.bool_GXTheory == false )
            {
                myForm.InitControl(Enum_DataTable.Issue .ToString());
            }
            else 
            {
                myForm.InitControl(Enum_DataTable.GXTheoryIssue  .ToString());
           }
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                EventArgs_ShipClassification g = new EventArgs_ShipClassification(null, this.bool_GXTheory );
                g.str_Filter = myForm.str_Filter;
                Publisher_ShipClassification.OnEventName(g);
            }

        }

        private void MaskedTextBox_IssueNoBegin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.MaskedTextBox_IssueNoEnd.Text))
            {
                this.MaskedTextBox_IssueNoEnd.Text = this.MaskedTextBox_IssueNoBegin.Text;
            }
        }

    }
}
