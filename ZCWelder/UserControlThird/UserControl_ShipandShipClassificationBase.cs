using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ZCCL.ClassBase;
using ZCWelder.ClassBase;
using ZCWelder.ParameterQuery;

namespace ZCWelder.UserControlThird
{
    public partial class UserControl_ShipandShipClassificationBase : UserControl
    {
        public Class_ShipandShipClassification myClass_ShipandShipClassification;
        /// <summary>
        /// 存储最近一次输入的数据
        /// </summary>
        static private Class_ShipandShipClassification myClass_ShipandShipClassificationDefault;
        
        public UserControl_ShipandShipClassificationBase()
        {
            InitializeComponent();
        }

        private void UserControl_ShipandShipClassification_Base_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="myClass_ShipandShipClassification"></param>
        /// <param name="bool_Add"></param>
        public void InitControl(Class_ShipandShipClassification myClass_ShipandShipClassification, bool bool_Add)
        {
            this.myClass_ShipandShipClassification = myClass_ShipandShipClassification;
            if (bool_Add)
            {
                if (myClass_ShipandShipClassificationDefault != null)
                {
                }
            }
            else
            {
                this.button_ShipboardNo.Enabled = false;
                this.button_ShipClassificationAb.Enabled = false;          
                this.textBox_ShipClassificationAb .Text = this.myClass_ShipandShipClassification.ShipClassificationAb;
                Class_ShipClassification myClass_ShipClassification = new Class_ShipClassification(this.myClass_ShipandShipClassification.ShipClassificationAb);
                this.textBox_ShipClassification.Text = myClass_ShipClassification.ShipClassification;
                this.textBox_ShipboardNo.Text  = this.myClass_ShipandShipClassification.ShipboardNo;

                if (myClass_ShipandShipClassification.ShipandShipClassificationIndex >= this.numericUpDown_ShipandShipClassificationIndex.Minimum && myClass_ShipandShipClassification.ShipandShipClassificationIndex <= this.numericUpDown_ShipandShipClassificationIndex.Maximum)
                {
                    this.numericUpDown_ShipandShipClassificationIndex.Value = myClass_ShipandShipClassification.ShipandShipClassificationIndex;
                }
                this.textBox_ShipandShipClassificationRemark.Text = myClass_ShipandShipClassification.ShipandShipClassificationRemark;
            }

        }

        /// <summary>
        /// 更新数据到对象中
        /// </summary>
        public void FillClass()
        {
            myClass_ShipandShipClassification.ShipClassificationAb = this.textBox_ShipClassificationAb.Text;
            myClass_ShipandShipClassification.ShipboardNo = this.textBox_ShipboardNo.Text;
            myClass_ShipandShipClassification.ShipandShipClassificationIndex = (int)this.numericUpDown_ShipandShipClassificationIndex.Value;
            myClass_ShipandShipClassification.ShipandShipClassificationRemark = this.textBox_ShipandShipClassificationRemark.Text;

            if (myClass_ShipandShipClassificationDefault == null)
            {
                myClass_ShipandShipClassificationDefault = new Class_ShipandShipClassification();
            }

        }

        private void button_ShipClassificationAb_Click(object sender, EventArgs e)
        {
            Form_ShipClassificationQuery myForm = new Form_ShipClassificationQuery();
            if (this.myClass_ShipandShipClassification .ShipClassificationAb  != null)
            {
                myForm.myClass_ShipClassification = new Class_ShipClassification(this.myClass_ShipandShipClassification.ShipClassificationAb );
            }
            else
            {
                myForm.myClass_ShipClassification = new Class_ShipClassification();
            }

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.textBox_ShipClassificationAb .Text  = myForm.myClass_ShipClassification.ShipClassificationAb;
                this.textBox_ShipClassification.Text = myForm.myClass_ShipClassification.ShipClassification;
            }

        }

        private void button_ShipboardNo_Click(object sender, EventArgs e)
        {
            Form_ShipQuery myForm = new Form_ShipQuery();
            if (this.myClass_ShipandShipClassification .ShipboardNo  != null)
            {
                myForm.myClass_Ship = new Class_Ship(this.myClass_ShipandShipClassification.ShipboardNo);
            }
            else
            {
                myForm.myClass_Ship = new Class_Ship();
            }

            if (myForm.ShowDialog() == DialogResult.OK)
            {
                this.myClass_ShipandShipClassification.ShipboardNo = myForm.myClass_Ship.ShipboardNo;
                this.textBox_ShipboardNo .Text = myForm.myClass_Ship.ShipboardNo;
            }

        }
    }
}
