using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainProj.Utils;
using System.Windows.Forms;
using HyTestRTDataService.RunningMode;
using System.IO;
using MainProj.Util;

namespace MainProj.Local
{
    public class SharedBase
    {
        #region
       
        //画图
        protected Dictionary<string, CurvePanel> dictCurvePanel = new Dictionary<string, CurvePanel>();
        //通用试验对象
        public Thread threadTest;
        public RunningServer server = RunningServer.getServer();
        internal bool istested = false;
       
        //数据记录周期
        private TestRecorder recorder = new TestRecorder(500);
        //本试验参数
        public double 测试试验时间;
        public double 试验最大压力;
        

        protected virtual log4net.ILog LOG
        {
            get
            {
                return log4net.LogManager.GetLogger(this.GetType());
            }
        }
       
        //实验停止委托
        private delegate void Datadelegate();
        //???
        public DateTime reporttime;
        public List<TestType> 试验类型列表 { get; set; }
        protected byte[] testReport;
        //数据库字段
        //public int Id { get; set; }
        //public string 型号 { get; set; }
        //public string 制造商 { get; set; }
        //通用试验参数
        public string 实验人员;
        public string 试验时间;
        public static string 路径;
        public static string 图片路径;
        private static string 保存路径;
        private static string 模板路径;
        #endregion
        public SharedBase()
        {
           
        }

        public RunState GetRunState()
        {
            if (this.threadTest == null)
                return RunState.Stopped;
            switch (this.threadTest.ThreadState)
            {
                case ThreadState.Running:
                case ThreadState.WaitSleepJoin:
                    return RunState.Runing;
                case ThreadState.Suspended:
                    return RunState.Paused;
                default:
                    return RunState.Stopped;
            }
        }

        public void Start()
        {       
            if (this.threadTest == null)
            {
                threadTest = new Thread(this.Run);
            }
            if (threadTest.ThreadState != ThreadState.Running)
            {
                threadTest.Start(new object());
            }
            LOG.Debug("试验开始");
        }

        public void SuspendTest()
        {
            if ((threadTest.ThreadState == ThreadState.Unstarted) || (threadTest.ThreadState == ThreadState.Stopped))
            {
                LOG.Debug("当前试验尚未开始或已停止，暂停无效!");
                return;
            }
            threadTest.Suspend();//挂起当前线程
            ///休眠,挂起需要时间  
            System.Threading.Thread.Sleep(300);
            // if(runTest.ThreadState==ThreadState.Suspended)       
            // log.Info("试验暂停中...");
            LOG.Debug("试验暂停");
        }

        public void ResumeTest()
        {
            if (threadTest.ThreadState == ThreadState.Suspended)
            {
                threadTest.Resume();
                System.Threading.Thread.Sleep(300);
            }
            else
            {
                //System.Windows.Forms.MessageBox.Show("当前线程非挂起状态，无法继续！");
                LOG.Debug("当前试验尚未进入暂停状态，无法继续！");
            }
            LOG.Debug("试验恢复");
        }
        public void AbortTest()
        {
            //this.SetSourcePre(0); 阀台需要
            //this.SetSourceFlow(0);
            //this.SetCircuitState(CircuitState.ALLOn);
            //this.SetFlowMeasureValveOn();//1031
            try
            {
                threadTest.Abort();
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
            LOG.Debug("试验中止");
        }

        /// <summary>
        /// 把dictionary中的数据放到指定的模板里
        /// </summary>
        public void Generate()
        {
            LOG.Info("正在生成试验报告");
            GenerateReport();
            LOG.Info("报告已生成");
        }

        public virtual void GenerateReport()
        {
            //LOG.Info("正在写入基础信息...");
            //Dictionary<string, string> Pict = new Dictionary<string, string>();
            //WordHelper helper = SetReportBasicInfo(true);

            //string key = "位移时间曲线";

            //if (File.Exists(图片路径))
            //{
            //    Pict.Add("$动态油缸位移时间曲线$", 图片路径);
            //    helper.Insertpicture(Pict);
            //    LOG.Debug("正在写入图片");

            // helper.SaveDocument(保存路径);
            //}
            //else
            //{
            //    LOG.Error("因为本次实验没有保存图片，无法生成试验报告");
            //}
        }
  
        public virtual void Run(Object stateInfo)
        {
           // MessageBox.Show("试验结束,请打印实验报告...");
        }

        public void SaveTestData()
        {
            Test test = new Test()
            {
                //序列号 = this.序列号,
                //试验台 = this.试验台,
                //设备型号 = this.型号,
                试验时间 = System.DateTime.Now.ToString(),
                试验数据 = recorder.dataBLOB,//实验数据二进制文件
                试验报告 = this.testReport,//fake实验报告
            };
            using (LocalDbContext db = new LocalDbContext())
            {
                db.Set<Test>().Add(test);
                db.SaveChanges();  //将修改持久化到存储器中
            }
        }
  
        public virtual void RunTest(TestType testType)
        {
            
        }
        
        WordHelper helper = new WordHelper();
        //弹出提示框，给工作人员名单
        public virtual WordHelper SetReportBasicInfo(bool isManul)
        {
           
            Dictionary<string, string> dict = new Dictionary<string, string>();
            helper.CreateNewDocument(SharedBase.模板路径);
            string 人员名字 = "我是谁";
            if (isManul)
            {
                //窗口获取实验人员信息
                GetInformation Inf = new GetInformation("请输入实验人员的姓名");
                人员名字 = Inf.ShowDialog() == DialogResult.OK && Inf.Value.Length > 0 ? Inf.Value : "XXXX";
            }

            dict.Add("$人员$", 人员名字);
            dict.Add("$日期$", DateTime.Now.ToLongDateString());

            dict.Add("$试验持续时间$", this.测试试验时间.ToString() + "s");
            dict.Add("$试验最大压力$", this.试验最大压力.ToString() + "MPa");

            MessageBox.Show("缓冲油缸试验报告文档保存在项目的report中，请查收");
            helper.InserttextValue(dict);
            return helper;
        }
    }

    public enum TestType
    {
         试运转试验,
         启动压力特性试验,
         耐压试验,
         耐久性试验,
         内外泄漏试验,
         低压下的泄漏试验,
         缓冲试验,
         负载效率试验,
         行程检验,
         频率响应试验,
         阶跃响应试验
    }
    public enum RunState
    {
        Stopped,
        Runing,
        Paused
    }
    //所有的枚举类型都要放在其中

    public class TestTypeNotSupportedException : Exception
    {

    }

    public class TestAbortException : Exception
    {

    }
    public class AutoAbortException : Exception
    {

    }

}
