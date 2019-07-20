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
    public partial class FormMaintainPressure : Form
    {
        private TimeSpan ts;//耐压实验进行时间
        public int i;
        public FormMaintainPressure(int num)
        {
            InitializeComponent();
            i = num;
            ts = new TimeSpan(0, i, 0);
        }

        private void continue_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FormMaintainPressure_Load(object sender, EventArgs e)
        {
            this.On_timer.Enabled = true;
            this.On_timer.Start();
        }

        private void On_timer_Tick(object sender, EventArgs e)
        {
            string Minutes;
            string Seconds;
             if(ts.Minutes<10)
             {
                  Minutes = "0" + ts.Minutes.ToString();

             }
             else
             {
                 Minutes = ts.Minutes.ToString();
             }
            if(ts.Seconds<10)
            {
                 Seconds = "0" + ts.Seconds.ToString(); 
            }
            else
            {
                Seconds =  ts.Seconds.ToString();
            }
            this.label2.Text = Minutes + ":" +Seconds;
            ts = ts.Subtract(new TimeSpan(0, 0, 1));
            if (ts.Seconds < 0)
            {
                On_timer.Enabled = false;
                continue_button.Enabled = true;
                MessageBox.Show("耐压实验完成，检查后，如有泄漏油，请点击结束试验");
            }
        }

        private void end_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
