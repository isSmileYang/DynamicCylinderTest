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
    public partial class FormKeepTime : Form
    {
        int IsInt;
        public int retnum;
        public FormKeepTime()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入保压时间");
                return;
            }


            else if (int.TryParse(textBox1.Text, out IsInt) == false)
            {
                MessageBox.Show("请输入一个整数");
                return;

            }
            else if (Convert.ToDouble(textBox1.Text) < 5)
            {
                MessageBox.Show("请输入一个不小于5的数值");
                return;
            }
            try
            {
                retnum = Convert.ToInt32(textBox1.Text);

                DialogResult = DialogResult.OK;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void FormKeepTime_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
    }
}
