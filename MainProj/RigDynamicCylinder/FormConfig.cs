
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
        public double 负载模拟输出力;
        public double 被试油缸的压力;
        public double 需要的模拟质量值;

    
        public FormConfig()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        /// <summary>
        /// 测试Label显示实时数据
        /// </summary>

        Random umber = new Random();
        bool flag = true;
      
        private void ConfigForm_Load(object sender, EventArgs e)
        {
        }

        //private void button大缸伸出预备_Click(object sender, EventArgs e)
        //{
        //    ///试验暂停          
        //    if (DS2_a == true)
        //    {
        //        DS2_a = false;
        //        //server.NormalWrite<int>("DS2-a", 1);

        //    }
        //    else if (DS2_a == false)
        //    {
        //        //server.NormalWrite<int>("DS2-a", 0);
        //        DS2_a = true;

        //    }

        //}
        //点击按钮就可以有最小值
      
        private void 记录小腔最低启动压力_Click(object sender, EventArgs e)
        {
            int r1 = umber.Next(0, 10);
            //textBox1.Text = r1.ToString();
            if (flag)
                timer1.Start();
            else 
                timer1.Stop();
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
