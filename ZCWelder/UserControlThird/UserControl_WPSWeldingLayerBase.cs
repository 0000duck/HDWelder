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
    public partial class UserControl_WPSWeldingLayerBase : UserControl
    {
        public Class_WPSWeldingLayer myClass_WPSWeldingLayer;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_WPSWeldingLayer myClass_WPSWeldingLayerDefault;

        public UserControl_WPSWeldingLayerBase()
        {
            InitializeComponent();
        }

        private void UserControl_WPSWeldingLayerBase_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_WPSWeldingLayer"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_WPSWeldingLayer myClass_WPSWeldingLayer, bool bool_Add)
        {
            this.myClass_WPSWeldingLayer = myClass_WPSWeldingLayer;
            this.textBox_pWPSID.Text = myClass_WPSWeldingLayer.WPSID ;
            this.textBox_pWPSLayerNo .Text  = myClass_WPSWeldingLayer.WPSLayerNo.ToString() ;
            if (bool_Add)
            {
                if (myClass_WPSWeldingLayerDefault != null && myClass_WPSWeldingLayerDefault.WPSLayerID == this.myClass_WPSWeldingLayer.WPSLayerID)
                {
                    this.numericUpDown_pWPSLayerPass.Value = myClass_WPSWeldingLayerDefault.WPSLayerPass;
                    this.numericUpDown_pWPSSideNo.Value = myClass_WPSWeldingLayerDefault.WPSSideNo;
                }
            }
            else
            {
                this.numericUpDown_pWPSSideNo.Value  = myClass_WPSWeldingLayer.WPSSideNo;
                this.textBox_pWPSLayerID.Text = myClass_WPSWeldingLayer.WPSLayerID.ToString();
                this.numericUpDown_pWPSLayerPass.Value = myClass_WPSWeldingLayer.WPSLayerPass;
                this.textBox_pWPSPassSequence.Text = myClass_WPSWeldingLayer.WPSPassSequence;
                this.textBox_pWPSLayerRemark.Text = myClass_WPSWeldingLayer.WPSLayerRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_WPSWeldingLayer.WPSLayerRemark = this.textBox_pWPSLayerRemark.Text;
            myClass_WPSWeldingLayer.WPSLayerPass = (int)this.numericUpDown_pWPSLayerPass.Value;
            myClass_WPSWeldingLayer.WPSSideNo = (int)this.numericUpDown_pWPSSideNo.Value;

            if (myClass_WPSWeldingLayerDefault == null)
            {
                myClass_WPSWeldingLayerDefault = new Class_WPSWeldingLayer();
            }
            myClass_WPSWeldingLayerDefault.WPSLayerPass =(int) this.numericUpDown_pWPSLayerPass.Value;
            myClass_WPSWeldingLayerDefault.WPSSideNo  =(int) this.numericUpDown_pWPSSideNo .Value;
            myClass_WPSWeldingLayerDefault.WPSLayerID = myClass_WPSWeldingLayer.WPSLayerID ;

        }

    }
}
