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
    public partial class ExpParaDeter : Form
    {
        public double 负载模拟输出力 ;
        public double 被试油缸的压力 ;
        public double 需要的模拟质量值 ;
        public ExpParaDeter()
        {
            InitializeComponent();
        }
        private void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void transmission()
        {

            负载模拟输出力 = double.Parse(textBox1.Text.Trim() == "" ? "-1" : textBox1.Text.Trim());
            被试油缸的压力 = Convert.ToDouble(textBox2.Text);
            需要的模拟质量值 = Convert.ToDouble(textBox3.Text);
            Thread.Sleep(500);
        }

        private void buttonensure_Click(object sender, EventArgs e)
        {
           this.transmission();
            
            if (负载模拟输出力 >= 0.1 && 负载模拟输出力 <= 4.0)
            {
                MessageBox.Show("用小液压缸实现", "ERROR");
                //“负载模拟力”参数选择小力传感器FS1的输入信号
                //负载模拟力参数 = FS1;
            }
            else if (负载模拟输出力 > 4.0 && 负载模拟输出力 <= 150.0)
            {
                MessageBox.Show("用大液压缸实现", "ERROR");
            }
            else
            {
                MessageBox.Show("超出范围");
            }
        }

        private void buttonzero_Click(object sender, EventArgs e)
        {
            this.clear();
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
