
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using HyTestRTDataService.RunningMode;

namespace MainProj
{
    public partial class FormBuffer : Form
    {
        public FormBuffer()
        {
            InitializeComponent();
        }
        public string Value { get; set; }
       
        private void GetInformation_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.Text = Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入实验人员姓名");
                return;
            }
            try
            {
                Value = textBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
