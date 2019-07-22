using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;
using System.Threading;
using System.IO;
using HyTestRTDataService.RunningMode;
using HyTestRTDataService;
using MainProj.Local;

namespace MainProj
{
    public partial class MainForm : Form//,IDataExchangable
    {
         ILog log = log4net.LogManager.GetLogger(typeof(MainForm));
        //实例RunningServer
        private RunningServer server = RunningServer.getServer();
        //暂停/继续按键次数
        private int flag = 0;
       
        //画图类里的变量
        FormZedGraphWithSingle graphForm;

        public static int test=0;
        private delegate void Datadelegate();
        //基类的对象，必须在某个方法里实例化之后才能有所作为（选择在窗体加载时）
        private Dynamic_Cylinder currentTest = null;
      
        /// <summary>
        /// 构造函数，作用是初始化界面
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //连接通道
            server.Run();
            //计时器++开始

            foreach (TestType xt in Dynamic_Cylinder.GetSupportedTestType())
            {
                this.checkedListBox.Items.Add(xt);

            }
        }

        #region form event

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer2.Start();
            //窗体加载时子类对象实例化为非空
            this.currentTest = new Dynamic_Cylinder();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //做一下关闭连接检查
        }

        #endregion
        //模拟曲线的随机生成数
        Random rNumber = new Random();
        #region button event
        // 试验配置按钮
        private void OnChoose(object sender, EventArgs e)
        {
            //选择实验界面实例变量
            //FormValveSelect frm = new FormValveSelect();
            this.currentTest = new Dynamic_Cylinder();
            if (checkedListBox.SelectedIndex == 0)
            {
                this.currentTest.StartWorkTest();
               
            }
            else if (checkedListBox.SelectedIndex == 1)
            {
                this.currentTest.StartPressureTest();
               test = 2;
            }
            else if (checkedListBox.SelectedIndex == 2)
            {
                this.currentTest.PressTest();
               // int r1 = rNumber.Next(1, 10);
               // dataScanner1.VarName = server.InstantRead<double>("压力传感器PS1").ToString();

            }
            else if (checkedListBox.SelectedIndex == 3)
            {
                this.currentTest.EnduranceTest();
            }
            else if (checkedListBox.SelectedIndex == 4)
            {
            }
            else if (checkedListBox.SelectedIndex == 5)
            {

            }
            else if (checkedListBox.SelectedIndex == 6)
            {
                MessageBox.Show("请调节RF1溢流阀压力为5Mpa", "进入缓冲试验");
                MainForm.test = 6;
                AllowTest();
            }
            else if (checkedListBox.SelectedIndex == 7)
            {

            }
            else if (checkedListBox.SelectedIndex == 8)
            {
                MainForm.test = 8;
                AllowTest();
            }
            else if (checkedListBox.SelectedIndex == 9)
            {
                
               // this.currentTest.LoadEfficiencyTest();
              //  AllowTest();
              //  MainForm.test = 8;

            }
            else if (checkedListBox.SelectedIndex == 10)
            {
                //this.currentTest.testTypes.Add(TestType.负载效率试验);
                this.currentTest.LoadEfficiencyTest();

            }
        }
        // 试验开始按钮
        private void OnTestStart_Click(object sender, EventArgs e)
        {
            
            if (this.currentTest == null)
            {
                log.Debug("currentTest=null");
                return;
            }

            this.currentTest.Start();    //试验开始 
            this.currentTest.TestEndEvent += OnTestEnd;
            //要启动实验的生成报告时
            this.AllowTest();
            
            flag = 0;//将暂停继续按钮恢复到暂停状态       

            this.toolStripButtonStart.Enabled = false;
            this.toolStripButtonPause.Enabled = true;
            this.toolStripButtonStop.Enabled = true;
            this.toolStripButtonPause.Text = "暂停";
            //通知连接服务，试验开始
            //log.Debug("试验开始");



        }
        //试验暂停按钮
        private void OnTestPause_Click(object sender, EventArgs e)
        {
            ///试验暂停          
            if (flag == 0)   //flag为0表示可暂停
            {
                this.currentTest.SuspendTest();//将当前线程挂起
                this.toolStripButtonPause.Text = "继续";
                log.Info("试验暂停中...");
                flag = 1;
                return;
            }
            if (flag == 1)//flag为1表示可继续
            {
                this.toolStripButtonPause.Text = "暂停";
                this.currentTest.ResumeTest();
                flag = 0;

            }
        }
        //试验暂停按钮
        private void OnTestStop_Click(object sender, EventArgs e)
        {
            ///试验停止
            this.currentTest.AbortTest();
            log.Info("试验停止");
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonPause.Enabled = false;
            this.toolStripButtonStart.Enabled = false;
        }
        //debug按钮
        private void OnDebug_Click(object sender, EventArgs e)
        {
            //FormTest frm = new FormTest();
            //frm.ShowDialog();
            log.Info("暂不支持调试，如需调试请联系开发人员");
        }
        //生成试验报告按钮
        private void GenerateReport_Click(object sender, EventArgs e)
        {
            log.Info("正在处理数据，准备开始生成试验报告，这个过程可能持续几秒，请等待...");
            if (this.currentTest == null)
            {
                log.Error("尚未进行配置");
                MessageBox .Show("尚未进行配置");
                return;
            }
            //解决未进行试验bug
            if (this.currentTest.istested == false)
            {
                log.Error("未进行试验，不能生成报告");
                return;
            }
            this.currentTest.Generate();
        }
        //退出按钮
        private void OnQuit(object sender, EventArgs e)
        {
            //关闭连接释放独占请求
            System.Environment.Exit(0);
            //this.Close();
        }

        #endregion

        #region other event

        #endregion

        #region method

        public void AllowTest()
        {
            if (this.currentTest == null)
                return;

            if (this.currentTest.GetRunState() == RunState.Runing)
                return;

            this.toolStripButtonStart.Enabled = true;
            this.toolStripButtonPause.Enabled = false;
            this.toolStripButtonStop.Enabled = false;
        }

        public void ForbidTest()
        {
            this.toolStripButtonStart.Enabled = false;
            this.toolStripButtonPause.Enabled = false;
            this.toolStripButtonStop.Enabled = false;
        }


        /// <summary>
        ///  实验图生成并展示
        /// </summary>
        private void OnTestEnd()
        {
            
            Datadelegate tmpdelegate = () =>
            {
                this.toolStripButtonStart.Enabled = false;
                this.toolStripButtonPause.Enabled = false;
                this.toolStripButtonStop.Enabled = false;
                graphForm = new FormZedGraphWithSingle(currentTest.testGraphInfo);
                graphForm.Show();
            };
            this.Invoke(tmpdelegate);    ///后台进程调用当前UI进程
            
        }
     

        //实时显示现在时间
        private void timer2_Tick(object sender, EventArgs e)
        {
            label25.Text = System.DateTime.Now.ToString();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lbDigitalMeter10_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel14_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
#endregion