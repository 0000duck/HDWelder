using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZCWord = Microsoft.Office.Interop.Word;
using ZCWelder.ClassBase;
using ZCCL.AspNet;
using ZCCL.ClassBase;
using ZCWelder.ParameterQuery;
using ZCCL.Tools;
using System.IO;

namespace ZCWelder.Question
{
    public partial class Form_ExportPaper : Form
    {
        public Form_ExportPaper()
        {
            InitializeComponent();
        }

        private void Form_ExportPaper_Load(object sender, EventArgs e)
        {
            Class_Public.InitializeComboBox(this.ComboBox_Subject, Enum_DataTableSecond.Subject.ToString(), "Subject", "Subject");

        }

        private void Button_ExportPaper_Click(object sender, EventArgs e)
        {
            if (ComboBox_Subject.SelectedValue==null)
            {
                MessageBox.Show("请选择科目！");
                return;
            }
            if (string.IsNullOrEmpty(TextBox_Mark.Text))
            {
                MessageBox.Show("请输入标签！");
                return;
            }
            double dbl_PointSum = 0;
            int int_JudgmentQuantity;
            int int_ChoiceQuantity;
            int int_EssayQuestionQuantity;
            int int_MultiChoiceQuantity;
            double dbl_JudgmentPoint;
            double dbl_ChoicePoint;
            double dbl_EssayQuestionPoint;
            double dbl_MultiChoicePoint;
            int.TryParse(this.TextBox_JudgmentQuantity.Text, out int_JudgmentQuantity);
            int.TryParse(this.TextBox_ChoiceQuantity.Text, out int_ChoiceQuantity);
            int.TryParse(this.TextBox_EssayQuestionQuantity.Text, out int_EssayQuestionQuantity);
            int.TryParse(this.TextBox_MultiChoiceQuantity.Text, out int_MultiChoiceQuantity);
            double.TryParse(this.TextBox_JudgmentPoint.Text, out dbl_JudgmentPoint);
            double.TryParse(this.TextBox_ChoicePoint.Text, out dbl_ChoicePoint);
            double.TryParse(this.TextBox_MultiChoicePoint.Text, out dbl_MultiChoicePoint);
            double.TryParse(this.TextBox_EssayQuestionPoint.Text, out dbl_EssayQuestionPoint);

            double dbl_PointSumCompute = int_JudgmentQuantity * dbl_JudgmentPoint + int_ChoiceQuantity * dbl_ChoicePoint + int_MultiChoiceQuantity * dbl_MultiChoicePoint + int_EssayQuestionQuantity * dbl_EssayQuestionPoint;
            double.TryParse(this.TextBox_PointSum.Text, out dbl_PointSum);
            if (dbl_PointSum != dbl_PointSumCompute)
            {
                MessageBox.Show("分值总数不对！");
                return;
            }

            DataTable myDataTable_Judgment = ((Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.Judgment.ToString()]).myDataView.ToTable();
            DataTable myDataTable_Choice = ((Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.Choice.ToString()]).myDataView.ToTable();
            DataTable myDataTable_MultiChoice = ((Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.MultiChoice.ToString()]).myDataView.ToTable();
            DataTable myDataTable_EssayQuestion = ((Class_Data)Class_Public.myHashtable[Enum_DataTableSecond.EssayQuestion.ToString()]).myDataView.ToTable();
            DataView myDataView_Temp;
            myDataView_Temp = new DataView(myDataTable_Judgment);
            myDataView_Temp.RowFilter = string.Format("Subject='{0}'", this.ComboBox_Subject.SelectedValue.ToString());
            myDataTable_Judgment = myDataView_Temp.ToTable();
            myDataView_Temp = new DataView(myDataTable_Choice);
            myDataView_Temp.RowFilter = string.Format("Subject='{0}'", this.ComboBox_Subject.SelectedValue.ToString());
            myDataTable_Choice = myDataView_Temp.ToTable();
            myDataView_Temp = new DataView(myDataTable_EssayQuestion);
            myDataView_Temp.RowFilter = string.Format("Subject='{0}'", this.ComboBox_Subject.SelectedValue.ToString());
            myDataTable_EssayQuestion = myDataView_Temp.ToTable();
            myDataView_Temp = new DataView(myDataTable_MultiChoice);
            myDataView_Temp.RowFilter = string.Format("Subject='{0}'", this.ComboBox_Subject.SelectedValue.ToString());
            myDataTable_MultiChoice = myDataView_Temp.ToTable();

            int i;
            int k;
            int u;
            int v;
            string str_DataMark;
            if (myDataTable_Judgment.Rows.Count < int_JudgmentQuantity)
            {
                MessageBox.Show("判断题数量超过数据库中数量,请输入一个不超过" + myDataTable_Judgment.Rows.Count + "的数！");
                return;
            }

            if (myDataTable_Choice.Rows.Count < int_ChoiceQuantity)
            {
                MessageBox.Show("选择题数量超过数据库中数量,请输入一个不超过" + myDataTable_Choice.Rows.Count + "的数！");
                return;
            }

            if (myDataTable_MultiChoice.Rows.Count < int_MultiChoiceQuantity)
            {
                MessageBox.Show("多项选择题数量超过数据库中数量,请输入一个不超过" + myDataTable_MultiChoice.Rows.Count + "的数！");
                return;
            }

            if (myDataTable_EssayQuestion.Rows.Count < int_EssayQuestionQuantity)
            {
                MessageBox.Show("问答题数量超过数据库中数量,请输入一个不超过" + myDataTable_EssayQuestion.Rows.Count + "的数！");
                return;
            }
            ZCWord.Application myWordApp = new ZCWord.Application();
            ZCWord.Document myWordDocument;
            ZCWord.Document myWordDocument_Result;
            ZCWord.Range myRange;

            object oMissing = System.Reflection.Missing.Value;
            object bool_ReadOnly = true;
            object str_BookmarkName;

            if (int_MultiChoiceQuantity != 0)
            {
                object str_FileName = string.Format("{0}\\Data\\HP样卷模版.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                object str_FileName_Result = string.Format("{0}\\Data\\HP样卷答案模版.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                myWordDocument_Result = myWordApp.Documents.Open(ref str_FileName_Result, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            }
            else
            {
                object str_FileName = string.Format("{0}\\Data\\HP样卷模版无多项选择题.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                object str_FileName_Result = string.Format("{0}\\Data\\HP样卷答案模版无多项选择题.doc", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                myWordDocument = myWordApp.Documents.Open(ref str_FileName, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                myWordDocument_Result = myWordApp.Documents.Open(ref str_FileName_Result, ref oMissing, ref bool_ReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            }

            string str_Temp;
            string str_TempResult = "";
            Random myRandom = new Random();
            DataRow myDataRow;

            str_BookmarkName = "str_Subject";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = this.ComboBox_Subject.Text + " 理论考试试题(" + this.TextBox_Mark.Text + ")";
            str_BookmarkName = "str_Datemark";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            str_DataMark = string.Format("日戳：{0}{1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            myRange.Text = str_DataMark;
            str_BookmarkName = "str_mark";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = this.ComboBox_Subject.Text + "·" + this.TextBox_Mark.Text;
            str_BookmarkName = "str_JudgmentPoint";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = this.TextBox_JudgmentPoint.Text;
            str_BookmarkName = "str_ChoicePoint";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = this.TextBox_ChoicePoint.Text;
            if (int_MultiChoiceQuantity != 0)
            {
                str_BookmarkName = "str_MultiChoicePoint";
                myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
                myRange.Text = this.TextBox_MultiChoicePoint.Text;
                str_BookmarkName = "str_MultiChoiceQuantity";
                myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
                myRange.Text = this.TextBox_MultiChoiceQuantity.Text;
            }

            str_BookmarkName = "str_EssayQuestionPoint";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = this.TextBox_EssayQuestionPoint.Text;
            str_BookmarkName = "str_JudgmentQuantity";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = this.TextBox_JudgmentQuantity.Text;
            str_BookmarkName = "str_ChoiceQuantity";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = this.TextBox_ChoiceQuantity.Text;
            str_BookmarkName = "str_EssayQuestionQuantity";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = this.TextBox_EssayQuestionQuantity.Text;

            str_BookmarkName = "str_Subject";
            myRange = myWordDocument_Result.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = this.ComboBox_Subject.Text + " 理论考试试题(" + this.TextBox_Mark.Text + ")";
            str_BookmarkName = "str_Datemark";
            myRange = myWordDocument_Result.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = str_DataMark;
            if (int_JudgmentQuantity <= 10)
            {
                u = 2;
                v = 10;
            }
            else if (int_JudgmentQuantity <= 30 && int_JudgmentQuantity > 10)
            {
                u = 4;
                v = int_JudgmentQuantity / 2 + (int_JudgmentQuantity % 2);
            }
            else
            {
                u = (int_JudgmentQuantity / 15) * 2;
                if (int_JudgmentQuantity / 15 != 0)
                {
                    u += 2;
                }
                v = 15;
            }
            myRange = myWordDocument.Tables[2].Range;
            myWordDocument.Tables[2].Delete();
            myWordDocument.Tables.Add(myRange, u, v, ref oMissing, ref oMissing);
            myWordDocument.Tables[2].Borders.OutsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
            myWordDocument.Tables[2].Borders.InsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
            myWordDocument.Tables[2].Range.Font.Size = 12; ;
            myWordDocument.Tables[2].Range.ParagraphFormat.LineSpacingRule = ZCWord.WdLineSpacing.wdLineSpaceSingle;
            myWordDocument.Tables[2].Range.Rows.Height = 20;
            myWordDocument.Tables[2].Rows.Alignment = ZCWord.WdRowAlignment.wdAlignRowCenter;
            myWordDocument.Tables[2].Range.ParagraphFormat.Alignment = ZCWord.WdParagraphAlignment.wdAlignParagraphCenter;

            myRange = myWordDocument_Result.Tables[1].Range;
            myWordDocument_Result.Tables[1].Delete();
            myWordDocument_Result.Tables.Add(myRange, u, v, ref oMissing, ref oMissing);
            myWordDocument_Result.Tables[1].Borders.OutsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
            myWordDocument_Result.Tables[1].Borders.InsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
            myWordDocument_Result.Tables[1].Range.Font.Size = 12;
            myWordDocument_Result.Tables[1].Range.ParagraphFormat.LineSpacingRule = ZCWord.WdLineSpacing.wdLineSpaceSingle;
            myWordDocument_Result.Tables[1].Range.Rows.Height = 20;
            myWordDocument_Result.Tables[1].Rows.Alignment = ZCWord.WdRowAlignment.wdAlignRowCenter;
            myWordDocument_Result.Tables[1].Range.ParagraphFormat.Alignment = ZCWord.WdParagraphAlignment.wdAlignParagraphCenter;

            if (int_ChoiceQuantity <= 10)
            {
                u = 2;
                v = 10;
            }
            else if (int_ChoiceQuantity <= 30 && int_ChoiceQuantity > 10)
            {
                u = 4;
                v = int_ChoiceQuantity / 2 + (int_ChoiceQuantity % 2);
            }
            else
            {
                u = (int_ChoiceQuantity / 15) * 2;
                if (int_ChoiceQuantity % 15 != 0)
                {
                    u += 2;
                }
                v = 15;
            }
            myRange = myWordDocument.Tables[3].Range;
            myWordDocument.Tables[3].Delete();
            myWordDocument.Tables.Add(myRange, u, v, ref oMissing, ref oMissing);
            myWordDocument.Tables[3].Borders.OutsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
            myWordDocument.Tables[3].Borders.InsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
            myWordDocument.Tables[3].Range.Font.Size = 12;
            myWordDocument.Tables[3].Range.ParagraphFormat.LineSpacingRule = ZCWord.WdLineSpacing.wdLineSpaceSingle;
            myWordDocument.Tables[3].Range.Rows.Height = 20;
            myWordDocument.Tables[3].Rows.Alignment = ZCWord.WdRowAlignment.wdAlignRowCenter;
            myWordDocument.Tables[3].Range.ParagraphFormat.Alignment = ZCWord.WdParagraphAlignment.wdAlignParagraphCenter;

            myRange = myWordDocument_Result.Tables[2].Range;
            myWordDocument_Result.Tables[2].Delete();
            myWordDocument_Result.Tables.Add(myRange, u, v, ref oMissing, ref oMissing);
            myWordDocument_Result.Tables[2].Borders.OutsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
            myWordDocument_Result.Tables[2].Borders.InsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
            myWordDocument_Result.Tables[2].Range.Font.Size = 12;
            myWordDocument_Result.Tables[2].Range.ParagraphFormat.LineSpacingRule = ZCWord.WdLineSpacing.wdLineSpaceSingle;
            myWordDocument_Result.Tables[2].Range.Rows.Height = 20;
            myWordDocument_Result.Tables[2].Rows.Alignment = ZCWord.WdRowAlignment.wdAlignRowCenter;
            myWordDocument_Result.Tables[2].Range.ParagraphFormat.Alignment = ZCWord.WdParagraphAlignment.wdAlignParagraphCenter;

            if (int_MultiChoiceQuantity != 0)
            {
                if (int_MultiChoiceQuantity <= 5)
                {
                    u = 2;
                    v = 5;
                }
                else
                {
                    u = (int_MultiChoiceQuantity / 5) * 2;
                    if (int_MultiChoiceQuantity % 5 != 0)
                    {
                        u += 2;
                    }
                    v = 5;
                }
                myRange = myWordDocument.Tables[4].Range;
                myWordDocument.Tables[4].Delete();
                myWordDocument.Tables.Add(myRange, u, v, ref oMissing, ref oMissing);
                myWordDocument.Tables[4].Borders.OutsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
                myWordDocument.Tables[4].Borders.InsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
                myWordDocument.Tables[4].Range.Font.Size = 12;
                myWordDocument.Tables[4].Range.ParagraphFormat.LineSpacingRule = ZCWord.WdLineSpacing.wdLineSpaceSingle;
                myWordDocument.Tables[4].Range.Rows.Height = 20;
                myWordDocument.Tables[4].Rows.Alignment = ZCWord.WdRowAlignment.wdAlignRowCenter;
                myWordDocument.Tables[4].Range.ParagraphFormat.Alignment = ZCWord.WdParagraphAlignment.wdAlignParagraphCenter;

                myRange = myWordDocument_Result.Tables[3].Range;
                myWordDocument_Result.Tables[3].Delete();
                myWordDocument_Result.Tables.Add(myRange, u, v, ref oMissing, ref oMissing);
                myWordDocument_Result.Tables[3].Borders.OutsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
                myWordDocument_Result.Tables[3].Borders.InsideLineStyle = ZCWord.WdLineStyle.wdLineStyleSingle;
                myWordDocument_Result.Tables[3].Range.Font.Size = 12;
                myWordDocument_Result.Tables[3].Range.ParagraphFormat.LineSpacingRule = ZCWord.WdLineSpacing.wdLineSpaceSingle;
                myWordDocument_Result.Tables[3].Range.Rows.Height = 20;
                myWordDocument_Result.Tables[3].Rows.Alignment = ZCWord.WdRowAlignment.wdAlignRowCenter;
                myWordDocument_Result.Tables[3].Range.ParagraphFormat.Alignment = ZCWord.WdParagraphAlignment.wdAlignParagraphCenter;
            }


            int myRandom_Number;
            str_Temp = "";

            if (int_JudgmentQuantity <= 10)
            {
                u = 2;
                v = 10;
            }
            else if (int_JudgmentQuantity <= 30 && int_JudgmentQuantity > 10)
            {
                u = 4;
                v = int_JudgmentQuantity / 2 + (int_JudgmentQuantity % 2);
            }
            else
            {
                u = (int_JudgmentQuantity / 15) * 2;
                if (int_JudgmentQuantity % 15 != 0)
                {
                    u += 2;
                }

                v = 15;
            }

            k = 1;
            u = 1;
            for (i = 1; i <= int_JudgmentQuantity; i++)
            {
                if (u > v)
                {
                    k = k + 2;
                    u = u - v;
                }

                myRandom_Number = myRandom.Next(myDataTable_Judgment.Rows.Count);
                myDataRow = myDataTable_Judgment.Rows[myRandom_Number];
                if (this.CheckBox_Result.Checked)
                {
                    if ((bool)myDataRow["Result"])
                    {
                        str_Temp += i + "、" + myDataRow["QuestionText"].ToString() + "(√)";
                    }
                    else
                    { str_Temp += i + "、" + myDataRow["QuestionText"].ToString() + "(×)"; }
                }
                else
                { str_Temp += i + "、" + myDataRow["QuestionText"].ToString() + "(   )"; }

                myWordDocument.Tables[2].Cell(k, u).Range.Text = i.ToString();
                myWordDocument_Result.Tables[1].Cell(k, u).Range.Text = i.ToString();
                if ((bool)myDataRow["Result"])
                { myWordDocument_Result.Tables[1].Cell(k + 1, u).Range.Text = "√"; }
                else
                { myWordDocument_Result.Tables[1].Cell(k + 1, u).Range.Text = "×"; }

                myDataTable_Judgment.Rows.Remove(myDataRow);
                if (i < int_JudgmentQuantity)
                {
                    str_Temp += (Char)10;
                }
                u += 1;
            }
            str_BookmarkName = "str_Judgment";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = str_Temp;

            str_Temp = "";
            if (int_ChoiceQuantity <= 10)
            {
                u = 2;
                v = 10;
            }
            else if (int_ChoiceQuantity <= 30 && int_ChoiceQuantity > 10)
            {
                u = 4;
                v = int_ChoiceQuantity / 2 + (int_ChoiceQuantity % 2);
            }
            else
            {
                u = (int_ChoiceQuantity / 15) * 2;
                if (int_ChoiceQuantity % 15 != 0)
                {
                    u += 2;
                }
                v = 15;
            }
            k = 1;
            u = 1;
            for (i = 1; i <= int_ChoiceQuantity; i++)
            {
                if (u > v)
                {
                    k = k + 2;
                    u = u - v;
                }
                myRandom_Number = myRandom.Next(myDataTable_Choice.Rows.Count);
                myDataRow = myDataTable_Choice.Rows[myRandom_Number];
                if (this.CheckBox_Result.Checked)
                {
                    str_Temp += i + "、" + myDataRow["QuestionText"].ToString() + "(" + myDataRow["Result"].ToString() + ")\n";
                }
                else
                {
                    str_Temp += i + "、" + myDataRow["QuestionText"].ToString() + "(   )\n";
                }

                str_Temp += "A、" + myDataRow["A"].ToString() + "\t\t" + "B、" + myDataRow["B"];
                switch (myDataRow["ResultQuantity"].ToString())
                {
                    case "3":
                        str_Temp += "\t\t" + "C、" + myDataRow["C"];
                        break;
                    case "4":
                        str_Temp += "\t\t" + "C、" + myDataRow["C"] + "\t\t" + "D、" + myDataRow["D"];
                        break;
                    case "5":
                        str_Temp += "\t\t" + "C、" + myDataRow["C"] + "\t\t" + "D、" + myDataRow["D"] + "\t\t" + "E、" + myDataRow["E"];
                        break;
                }
                myWordDocument.Tables[3].Cell(k, u).Range.Text = i.ToString();
                myWordDocument_Result.Tables[2].Cell(k, u).Range.Text = i.ToString();
                myWordDocument_Result.Tables[2].Cell(k + 1, u).Range.Text = myDataRow["Result"].ToString();
                myDataTable_Choice.Rows.Remove(myDataRow);
                if (i < int_ChoiceQuantity)
                {
                    str_Temp += "\n";
                }
                u += 1;
            }
            str_BookmarkName = "str_Choice";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = str_Temp;

            if (int_MultiChoiceQuantity != 0)
            {
                str_Temp = "";

                string str_TempMultiChoiceResult;
                if (int_MultiChoiceQuantity <= 5)
                {
                    u = 2;
                    v = 5;
                }
                else
                {
                    u = (int_MultiChoiceQuantity / 5) * 2;
                    if (int_MultiChoiceQuantity % 5 != 0)
                    {
                        u += 2;
                    }
                    v = 5;
                }
                k = 1;
                u = 1;
                for (i = 1; i <= int_MultiChoiceQuantity; i++)
                {

                    str_TempMultiChoiceResult = "";
                    if (u > v)
                    {
                        k = k + 2;
                        u = u - v;
                    }

                    myRandom_Number = myRandom.Next(myDataTable_MultiChoice.Rows.Count);
                    myDataRow = myDataTable_MultiChoice.Rows[myRandom_Number];
                    if (this.CheckBox_Result.Checked)
                    {
                    }
                    else
                    {
                        str_Temp += i.ToString() + "、" + myDataRow["QuestionText"] + "(   )" + "\n";
                    }
                    str_Temp += "A、" + myDataRow["A"] + "\t\t" + "B、" + myDataRow["B"];
                    if ((bool)myDataRow["ResultA"])
                    {
                        str_TempMultiChoiceResult += "A";
                    }
                    if ((bool)myDataRow["ResultB"])
                    {
                        str_TempMultiChoiceResult += "B";
                    }
                    switch (myDataRow["ResultQuantity"].ToString())
                    {
                        case "3":
                            str_Temp += "\t\t" + "C、" + myDataRow["C"];
                            if ((bool)myDataRow["ResultC"])
                            {
                                str_TempMultiChoiceResult += "C";
                            }
                            break;
                        case "4":
                            str_Temp += "\t\t" + "C、" + myDataRow["C"] + "\t\t" + "D、" + myDataRow["D"];
                            if ((bool)myDataRow["ResultC"])
                            {
                                str_TempMultiChoiceResult += "C";
                            }
                            if ((bool)myDataRow["ResultD"])
                            {
                                str_TempMultiChoiceResult += "D";
                            }
                            break;
                        case "5":
                            str_Temp += "\t\t" + "C、" + myDataRow["C"] + "\t\t" + "D、" + myDataRow["D"] + "\t\t" + "E、" + myDataRow["E"];
                            if ((bool)myDataRow["ResultC"])
                            {
                                str_TempMultiChoiceResult += "C";
                            }
                            if ((bool)myDataRow["ResultD"])
                            {
                                str_TempMultiChoiceResult += "D";
                            }
                            if ((bool)myDataRow["ResultE"])
                            {
                                str_TempMultiChoiceResult += "E";
                            }
                            break;
                        case "6":
                            str_Temp += "\t\t" + "C、" + myDataRow["C"] + "\t\t" + "D、" + myDataRow["D"] + "\t\t" + "E、" + myDataRow["E"] + "\t\t" + "F、" + myDataRow["F"];
                            if ((bool)myDataRow["ResultC"])
                            {
                                str_TempMultiChoiceResult += "C";
                            }
                            if ((bool)myDataRow["ResultD"])
                            {
                                str_TempMultiChoiceResult += "D";
                            }
                            if ((bool)myDataRow["ResultE"])
                            {
                                str_TempMultiChoiceResult += "E";
                            }
                            if ((bool)myDataRow["ResultF"])
                            {
                                str_TempMultiChoiceResult += "F";
                            }
                            break;
                        case "7":
                            str_Temp += "\t\t" + "C、" + myDataRow["C"] + "\t\t" + "D、" + myDataRow["D"] + "\t\t" + "E、" + myDataRow["E"] + "\t\t" + "F、" + myDataRow["F"] + "\t\t" + "G、" + myDataRow["G"];
                            if ((bool)myDataRow["ResultC"])
                            {
                                str_TempMultiChoiceResult += "C";
                            }
                            if ((bool)myDataRow["ResultD"])
                            {
                                str_TempMultiChoiceResult += "D";
                            }
                            if ((bool)myDataRow["ResultE"])
                            {
                                str_TempMultiChoiceResult += "E";
                            }
                            if ((bool)myDataRow["ResultF"])
                            {
                                str_TempMultiChoiceResult += "F";
                            }
                            if ((bool)myDataRow["ResultG"])
                            {
                                str_TempMultiChoiceResult += "G";
                            }
                            break;
                    }
                    myWordDocument.Tables[4].Cell(k, u).Range.Text = i.ToString();
                    myWordDocument_Result.Tables[3].Cell(k, u).Range.Text = i.ToString();
                    myWordDocument_Result.Tables[3].Cell(k + 1, u).Range.Text = str_TempMultiChoiceResult;
                    myDataTable_MultiChoice.Rows.Remove(myDataRow);
                    if (i < int_MultiChoiceQuantity)
                    {
                        str_Temp += "\n";

                        u += 1;
                    }
                }
                str_BookmarkName = "str_MultiChoice";
                myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
                myRange.Text = str_Temp;
            }

            str_Temp = "";
            str_TempResult = "";
            for (i = 1; i <= int_EssayQuestionQuantity; i++)
            {
                myRandom_Number = myRandom.Next(myDataTable_EssayQuestion.Rows.Count);
                myDataRow = myDataTable_EssayQuestion.Rows[myRandom_Number];
                str_Temp += i.ToString() + "、" + myDataRow["QuestionText"] + "\n";
                str_TempResult += i.ToString() + "、" + myDataRow["QuestionText"] + "\n";
                if (this.CheckBox_Result.Checked)
                {
                    str_Temp += string.Format("{0}\n", myDataRow["Result"]);
                }
                else
                {
                    str_Temp +="\n\n\n\n\n\n\n\n\n\n\n\n";
                }
                str_TempResult += myDataRow["Result"].ToString();
                myDataTable_EssayQuestion.Rows.Remove(myDataRow);
                if (i < int_EssayQuestionQuantity)
                {
                    str_TempResult += "\n";

                }
            }

            str_BookmarkName = "str_EssayQuestion";
            myRange = myWordDocument.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = str_Temp;
            str_BookmarkName = "str_EssayQuestion";
            myRange = myWordDocument_Result.Bookmarks.get_Item(ref str_BookmarkName).Range;
            myRange.Text = str_TempResult;

            myWordApp.Visible = true;

        }

    }
}
