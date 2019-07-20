using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProj.Local;

namespace MainProj
{
    public partial class GetInformation : Form
    {
        public GetInformation(String label)
        {
            InitializeComponent();
            label1.Text = label;
        }
        public GetInformation(string label, string title)
        {
            InitializeComponent();
            label1.Text = label;
            this.Text = title;
        }

        private void GetInformation_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.Text = Value;
        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()=="")
            {
                MessageBox.Show("请输入实验人员姓名");
                return;
            }
            try
            {
                Value = textBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
                     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        public string Value { get; set; }
    }
}
