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
    public partial class FormLeakHydcheck : Form
    {
        public int testtimecount = 0;
        public float 实验压力;
        private float 最大试验压力;
        public FormLeakHydcheck(float 最大允许压力)
        {
            InitializeComponent();
            最大试验压力 = 最大允许压力;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()==""||textBox2.Text.Trim()=="")
            {
                MessageBox.Show("请将实验参数输入完整");
                    return;
            }
            else if(Convert.ToInt32(textBox1.Text)<300)
            {               
                MessageBox.Show("实验时间最少为300秒，请重新输入实验时间");
                return;
            }
            else if(Convert.ToSingle(textBox2.Text)>最大试验压力)
            {
                MessageBox.Show("实验压力最大为"+最大试验压力.ToString()+"，请重新输入实验压力");
                return;
            }

            testtimecount = Convert.ToInt32(textBox1.Text);
            this.实验压力 = Convert.ToSingle(textBox2.Text);
            this.DialogResult = DialogResult.OK;           
            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
