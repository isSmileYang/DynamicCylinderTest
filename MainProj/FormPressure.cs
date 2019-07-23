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
    public partial class FormPressure : Form
    {
        DateTime fiveM = new DateTime();
        Timer timer = new Timer();
        public FormPressure()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
           
            this.buttonStart.Enabled = true;
            this.buttonTheOther.Enabled = false;
            
            timer1.Interval = 1000;
            timer2.Interval = 1000;
        }



        private void buttonStart_Click(object sender, EventArgs e)
        {
            
           
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Tick += new EventHandler(timer2_Tick);
            fiveM = DateTime.Parse("00:00:05");
           
            if (buttonTheOther.Enabled)
            {
                timer2.Start();
            }
            else
            {
                timer1.Start();
            }
                   
        }

        private void buttonTheOther_Click(object sender, EventArgs e)
        {
           
            this.buttonStart.Enabled = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fiveM != Convert.ToDateTime("00:00:00"))
            {
                fiveM = fiveM.AddSeconds(-1);
                textBox1.Text = fiveM.Hour.ToString("00") + ":" + fiveM.Minute.ToString("00") + ":" + fiveM.Second.ToString("00");
            }
            else
            {
                this.buttonTheOther.Enabled = true;
                timer1.Stop();
                this.buttonStart.Enabled = false;
            }
                 
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (fiveM != Convert.ToDateTime("00:00:00"))
            {
                fiveM = fiveM.AddSeconds(-1);
                textBox1.Text = fiveM.Hour.ToString("00") + ":" + fiveM.Minute.ToString("00") + ":" + fiveM.Second.ToString("00");
            }
            else
            {
                timer2.Stop();
                this.buttonTheOther.Enabled = false;
                this.buttonStart.Enabled = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
