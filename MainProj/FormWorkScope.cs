using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProj
{
    public partial class FormWorkScope : Form
    {
        public double 最大试验流量;
        public double 最大试验压力;
        

        public FormWorkScope()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            最大试验流量 = Convert.ToDouble(this.textBox1.Text);
            最大试验压力 = Convert.ToDouble(this.textBox2.Text);
            this.Close();
        }
    }
}
