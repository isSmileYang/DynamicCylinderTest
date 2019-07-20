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
    public partial class FormStart : Form
    {

        private List<TextBox> checkedTextBoxList = new List<TextBox>();

        Random umber = new Random();

        public FormStart()
        {
           this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.confirmButton2.Enabled = false;
            this.confirmButton3.Enabled = false;
            this.confirmButton4.Enabled = false;
            this.confirmAirButton.Enabled = false;
            this.confirmButton1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.confirmButton2.Enabled = true;
        }

  

        private void confirmButton3_Click(object sender, EventArgs e)
        {
            this.confirmButton4.Enabled = true;
        }

        private void confirmButton4_Click(object sender, EventArgs e)
        {
            
                this.confirmAirButton.Enabled = true;
        }

        private void confirmButton2_Click_1(object sender, EventArgs e)
        {
            this.confirmButton3.Enabled = true;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (!this.confirmAirButton.Enabled || !this.confirmButton1.Enabled || !this.confirmButton2.Enabled || !this.confirmButton3.Enabled || !this.confirmButton4.Enabled)
            {
                MessageBox.Show("请将以上步骤全部确认");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            //LOG.Info("您已取消配置");
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int r1 = umber.Next(0, 10);
            textBox1.Text = r1.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int r2 = umber.Next(10, 20);
            textBox2.Text = r2.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            timer2.Start();
        }
    }
}
