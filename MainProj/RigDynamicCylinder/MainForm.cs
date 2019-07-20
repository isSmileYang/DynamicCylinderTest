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

        TestType test;

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

        #region button event
        // 试验配置按钮
        private void OnChoose(object sender, EventArgs e)
        {
            FormValveSelect frm = new FormValveSelect();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.currentTest == null) return;
                this.currentTest = frm.currentTest;
                AllowTest();
            }
         
        //如果点击取消，没事儿
    
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
            //
            this.currentTest.TestEndEvent += OnTestEnd;
            this.AllowTest();
            //要启动实验的生成报告时

            flag = 0;//将暂停继续按钮恢复到暂停状态       

            this.toolStripButtonStart.Enabled = false;
            this.toolStripButtonPause.Enabled = true;
            this.toolStripButtonStop.Enabled = true;
            this.toolStripButtonPause.Text = "暂停";

            log.Debug("试验开始");
            //通知连接服务，试验开始


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
            this.toolStripButtonStart.Enabled = false;// true;
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
        ///  结束实验开始画图
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

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    m_IsFullScreen = !m_IsFullScreen;//点一次全屏，再点还原。  
        //    this.SuspendLayout();
        //    if (m_IsFullScreen)//全屏 
        //    {
        //        //SetFormFullScreen(m_IsFullScreen);
        //        this.WindowState = FormWindowState.Maximized;
        //        this.FormBorderStyle = FormBorderStyle.None;
        //        this.Activate();
        //    }
        //    else//还原 TODO:还原后的窗体应该与全屏前的大小一致
        //    {
        //       // this.Size = new Size(Width_, Height_);
        //        this.FormBorderStyle = FormBorderStyle.Sizable;
        //        this.WindowState = FormWindowState.Normal;
        //        //SetFormFullScreen(m_IsFullScreen);
        //        this.Activate();
        //    }
        //    this.ResumeLayout(false);
        //}
    }
}
#endregion