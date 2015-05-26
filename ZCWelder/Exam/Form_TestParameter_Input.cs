using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZCWelder.Exam
{
    public partial class Form_TestParameter_Input : Form
    {
        public string str_BendTestItem;
        public bool bool_Supervisor;
        public bool bool_FaceDT;
        public bool bool_RT;
        public string str_LinkTel;

        public Form_TestParameter_Input()
        {
            InitializeComponent();
        }

        private void Form_TestParameter_Input_Load(object sender, EventArgs e)
        {
            this.comboBox_BendTestItem.Text = "���������";
            
        }

        private void button_OnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.comboBox_BendTestItem.Text))
            {
                MessageBox.Show("����������Ŀ!");
                this.DialogResult = DialogResult.None;
                return;
            }
            if (string.IsNullOrEmpty(this.textBox_Tel .Text))
            {
                MessageBox.Show("��������ϵ�绰!");
                this.DialogResult = DialogResult.None;
                return;
            }
            this.bool_Supervisor = this.checkBox_Supervisor.Checked;
            this.str_BendTestItem = this.comboBox_BendTestItem.Text;
            this.bool_FaceDT = this.checkBox_FaceDT.Checked;
            this.bool_RT = this.checkBox_RT.Checked;
            this.str_LinkTel = this.textBox_Tel.Text;
        }
    }
}