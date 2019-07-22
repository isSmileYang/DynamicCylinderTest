
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
    public partial class FormConfig : Form
    {
        
        ILog LOG = LogManager.GetLogger(typeof(FormConfig));
        public RunningServer server = RunningServer.getServer();
        Random umber = new Random();
       
        public static double x;
        public FormConfig()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = 500;
            
        }
        /// <summary>
        /// 测试Label显示实时数据
        /// </summary>

        
        bool flag = true;
      
        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }
        private void 记录小腔最低启动压力_Click(object sender, EventArgs e)
        {
            double r1 = umber.Next(0, 10);
            //textBox1.Text = r1.ToString();
            if (flag)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                double x = r1;
            }  
            flag = !flag;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int r1 = umber.Next(0, 10);
            //textBox1.Text = r1.ToString();
            lbDigitalMeter13.Value = r1;
        }
    }
}
