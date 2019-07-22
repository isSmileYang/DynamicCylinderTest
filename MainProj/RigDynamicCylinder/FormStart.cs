using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using HyTestRTDataService.RunningMode;

namespace MainProj
{
    public partial class FormStart : Form
    {

        private List<TextBox> checkedTextBoxList = new List<TextBox>();
        ILog LOG = LogManager.GetLogger(typeof(FormStart));
        public RunningServer server = RunningServer.getServer();
        Random umber = new Random();
        public bool flag = true;
        public FormStart()
        {
           this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();           
            this.confirmButton.Enabled = true;
            this.ButtonAir.Enabled = false;
          
        }
        
        private void ButtonAir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (flag)
                timer1.Start();
            else
                timer1.Stop();
            flag = !flag;
            this.ButtonAir.Enabled = true;
        }

        private void dataScanner1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int r1 = umber.Next(10, 20);
            textBox1.Text = r1.ToString();
        }
    }
}
