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
    public partial class UserControl_WeldingProcessBase : UserControl
    {
        private Class_WeldingProcess myClass_WeldingProcess;
        
        public UserControl_WeldingProcessBase()
        {
            InitializeComponent();
        }

        private void UserControl_WeldingProcessBase_Load(object sender, EventArgs e)
        {

        }

        public void InitControl(Class_WeldingProcess myClass_WeldingProcess, bool bool_Add)
        {
            this.myClass_WeldingProcess = myClass_WeldingProcess;

            if (bool_Add == false)
            {
                this.textBox_WeldingProcessAb .ReadOnly = true;
                this.textBox_WeldingProcessAb.Text = myClass_WeldingProcess.WeldingProcessAb;
                this.textBox_WeldingProcess.Text = myClass_WeldingProcess.WeldingProcess;
                this.textBox_WeldingProcessEnglishName.Text = myClass_WeldingProcess.WeldingProcessEnglishName;
                this.textBox_ProtectGas.Text = myClass_WeldingProcess.ProtectGas;
                this.textBox_KindofCCSWeldingProcess.Text = myClass_WeldingProcess.KindofCCSWeldingProcess;
                this.textBox_CCSWeldingProcess.Text = myClass_WeldingProcess.CCSWeldingProcess;
                this.textBox_ScopeofCCSWeldingProcess.Text = myClass_WeldingProcess.ScopeofCCSWeldingProcess;
                this.textBox_WeldingProcessNo.Text = myClass_WeldingProcess.WeldingProcessNo ;
                this.textBox_WeldingProcessRemark.Text = myClass_WeldingProcess.WeldingProcessRemark ;
                this.checkBox_MultiWeldingProcess.Checked = myClass_WeldingProcess.MultiWeldingProcess;
                this.numericUpDown_WeldingProcessIndex .Value = myClass_WeldingProcess.WeldingProcessIndex ;
            }
            else
            {
            }

        }

        public void FillClass()
        {
            myClass_WeldingProcess.WeldingProcess = this.textBox_WeldingProcess.Text;
            myClass_WeldingProcess.WeldingProcessAb  = this.textBox_WeldingProcessAb .Text;
            myClass_WeldingProcess.WeldingProcessEnglishName = this.textBox_WeldingProcessEnglishName.Text;
            myClass_WeldingProcess.ProtectGas = this.textBox_ProtectGas.Text;
            myClass_WeldingProcess.KindofCCSWeldingProcess = this.textBox_KindofCCSWeldingProcess.Text;
            myClass_WeldingProcess.CCSWeldingProcess = this.textBox_CCSWeldingProcess.Text;
            myClass_WeldingProcess.ScopeofCCSWeldingProcess = this.textBox_ScopeofCCSWeldingProcess.Text;
            myClass_WeldingProcess.WeldingProcessNo = this.textBox_WeldingProcessNo.Text;
            myClass_WeldingProcess.MultiWeldingProcess = this.checkBox_MultiWeldingProcess.Checked;
            myClass_WeldingProcess.WeldingProcessRemark = this.textBox_WeldingProcessRemark.Text;
            myClass_WeldingProcess.WeldingProcessIndex = (int)this.numericUpDown_WeldingProcessIndex.Value;
        }
    }
}
