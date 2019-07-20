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
using MainProj;

namespace MainProj
{
    public partial class FormLeakageReturn : Form
    {
        private int elapsetime;

        public float retvol;
        private DataMid currentValve;
        public FormLeakageReturn(int elapsetime, DataMid valve)
        {
            InitializeComponent();
            this.elapsetime = elapsetime;
            currentValve = valve;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim()=="")
            {
                MessageBox.Show("请输入结果");
                return;
            }

            try
            {
                this.retvol = Convert.ToSingle(this.textBox1.Text.ToString());
              
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void OnTimer(object sender, EventArgs e)
        {
            if (this.elapsetime > 0)
            {
                this.elapsetime = this.elapsetime - 1;
            }
            else
            {
                
               // currentValve.SetSourcePre(0);
               // currentValve.SetSourceFlow(0);
                System.Threading.Thread.Sleep(2000);
                this.timer1.Enabled = false;
                this.timer1.Stop();
                this.button1.Enabled = true;
                MessageBox.Show("本次内泄漏实验完成，请先关闭泄漏油口，并输入量杯读数");
                this.textBox1.Enabled = true;
            }
            this.label1.Text = "倒计时：" + elapsetime.ToString() + "秒";
        }

        private void OnLoad(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.textBox1.Enabled = false;
            this.timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
