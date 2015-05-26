using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCWelder.ClassBase;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_WeldingPositionBase : UserControl
    {
        public Class_WeldingPosition myClass_WeldingPosition;

        public UserControl_WeldingPositionBase()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingPositionBase_Load(object sender, EventArgs e)
        {

        }

        public void InitControl(Class_WeldingPosition myClass_WeldingPosition, bool bool_Add)
        {
            this.myClass_WeldingPosition = myClass_WeldingPosition;
            if (bool_Add == false)
            {
                this.textBox_WeldingPosition .ReadOnly = true;
                this.textBox_WeldingPosition.Text = myClass_WeldingPosition.WeldingPosition ;
                this.textBox_WeldingPositionABS.Text = myClass_WeldingPosition.WeldingPositionABS;
                this.textBox_WeldingPositionCCS.Text = myClass_WeldingPosition.WeldingPositionCCS;
                this.textBox_WeldingPositionDenomination.Text = myClass_WeldingPosition.WeldingPositionDenomination;
                this.textBox_WeldingPositionISO.Text = myClass_WeldingPosition.WeldingPositionISO;
                this.textBox_WeldingPositionRemark.Text = myClass_WeldingPosition.WeldingPositionRemark;
                this.numericUpDown_WeldingPositionIndex .Value = myClass_WeldingPosition.WeldingPositionIndex ;
            }

        }

        public void FillClass()
        {
                myClass_WeldingPosition.WeldingPosition=(string) this.textBox_WeldingPosition.Text  ;
                myClass_WeldingPosition.WeldingPositionABS=(string)this.textBox_WeldingPositionABS.Text;
                myClass_WeldingPosition.WeldingPositionCCS=(string)this.textBox_WeldingPositionCCS.Text;
                myClass_WeldingPosition.WeldingPositionDenomination=(string)this.textBox_WeldingPositionDenomination.Text;
                myClass_WeldingPosition.WeldingPositionISO=(string)this.textBox_WeldingPositionISO.Text  ;
                myClass_WeldingPosition.WeldingPositionRemark=(string)this.textBox_WeldingPositionRemark.Text;
               myClass_WeldingPosition.WeldingPositionIndex=(int) this.numericUpDown_WeldingPositionIndex.Value  ;

        }

    }
}
