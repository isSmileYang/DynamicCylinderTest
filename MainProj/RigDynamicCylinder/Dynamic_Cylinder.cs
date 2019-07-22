using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using HyTestRTDataService;
using MainProj.Utils;
using MainProj.Util;
using HyTestRTDataService.RunningMode;


namespace MainProj.Local
{

    public class Dynamic_Cylinder : SharedBase
    {

        //当前试验线程
        // public Thread threadTest;
        //实验停止委托
        private delegate void Datadelegate();
        public delegate void TestEndEventHandler();
        public event TestEndEventHandler TestEndEvent;

        //模拟曲线的随机生成数
        Random rNumber = new Random();
        //记录周期500ms
        private TestRecorder recorder = new TestRecorder(500);
        //list类型的实例变量试验类型列表
        public List<TestType> 试验类型列表 { get; set; }
        //？？？
        public List<TestType> 试验类型 = new List<TestType>();
        Dictionary<string, string> Pict = new Dictionary<string, string>();

        //判断是否做了实验
        internal bool istested = false;

        //试验曲线变量实例化
        public GraphInfo testGraphInfo;
        //选择试验界面实例变量
       // public FormValveSelect fs = new FormValveSelect();
        
        public string 模板路径;
        public string 保存路径;
        public  string 元件名称
        {
            get
            {
                return "动态油缸";
            }
        }

        public Dynamic_Cylinder()
        {
          //  if (this.试验类型列表 == null)
           // {
            //    this.试验类型列表 = new List<TestType>();
           // }
            路径 = Path.GetFullPath("..");
            模板路径 = 路径 + "\\template\\动态油缸试验报告模板.docx";
            保存路径 = 路径 + "\\report\\动态油缸试验报告.docx";
           // 图片路径 = 路径 + "\\report\\pict\\动态油缸缓冲试验曲线" + DateTime.Now.ToString("yy-MM-dd hhmmss") + ".bmp";
           // testGraphInfo = new GraphInfo("缓冲试验报告图", "时间", "位移", 图片路径);
        }
        public void GraphChoose()
        {
            if (MainForm.test == 6)
            {
                图片路径 = 路径 + "\\report\\pict\\动态油缸缓冲试验曲线" + DateTime.Now.ToString("yy-MM-dd hhmmss") + ".bmp";
                testGraphInfo = new GraphInfo("缓冲试验报告图", "时间", "位移", 图片路径);
            }
            else if (MainForm.test == 8)
            {
                图片路径 = 路径 + "\\report\\pict\\负载效率试验曲线" + DateTime.Now.ToString("yy-MM-dd hhmmss") + ".bmp";
                // testGraphInfo = new GraphInfo("负载效率试验报告图", "压力", "负载效率", 图片路径);
                testGraphInfo = new GraphInfo("负载效率试验报告图", "压力", "负载效率", 图片路径);
            }
        }
            //在选择实验界面遍历动态油缸的实验
            public static IList<TestType> GetSupportedTestType()
        {

            IList<TestType> list = new List<TestType>();
            list.Add(TestType.试运转试验);
            list.Add(TestType.启动压力特性试验);
            list.Add(TestType.耐压试验);
            list.Add(TestType.耐久性试验);
            list.Add(TestType.内外泄漏试验);
            list.Add(TestType.低压下的泄漏试验);
            list.Add(TestType.缓冲试验);
            list.Add(TestType.行程检验);
            list.Add(TestType.负载效率试验);
            list.Add(TestType.频率响应试验);
            list.Add(TestType.阶跃响应试验);
            return list;
        }
        //依次触发选中的实验
        public void RunTest(TestType testType)
         {
            MessageBox.Show("我在RunTest这里");
           this.试验类型.Add(testType);
             switch (testType)
             {
                 case TestType.试运转试验:
                     this.StartWorkTest();     
                      break;
                 case TestType.启动压力特性试验:
                     this.StartPressureTest();
                     break;
                case TestType.耐压试验:
                    this.PressTest();
                    break;
                case TestType.耐久性试验:
                    this.EnduranceTest();
                    break;
                case TestType.缓冲试验:
                    this.StartBufferTest();
                    break;
                case TestType.负载效率试验:
                    this.LoadEfficiencyTest();
                    break;
                default:
                     throw new TestTypeNotSupportedException();
            }

         }
        public class TestTypeNotSupportedException : Exception
        {

        }
        /// <summary>
        /// 试运转实验
        /// </summary>
        /// <param name="dictCurve"></param>
        /// <param name="state"></param>
        /// <param name="n">第N次试验</param>
        public void StartWorkTest()
        {
            FormStart f1 = new FormStart();
            f1.Show();
            // = server.NormalRead<double>("位移传感器LVDT",0);
            
        }

        /// <summary>
        ///启动压力特性试验
        /// </summary>
        
        public void StartPressureTest()
        {
            FormConfig cfm = new FormConfig();
            cfm.Show();
        }
        /// <summary>
        /// 耐压试验
        /// </summary>
        public void PressTest()
        {
            FormPressure f3 = new FormPressure();
            f3.Show();
        }
        /// <summary>
        /// 耐久性试验
        /// </summary>
        public void EnduranceTest()
        {
            server.NormalWrite<double>("比例伺服阀VDS1",0);
            MessageBox.Show("手动调整RF1溢流阀的压力至10mpa，CK1高压球阀关闭，CK2高压球阀关闭，调节RF2溢流阀至14Mpa,调节RF3溢流阀至5.6Mpa", "耐久性试验手动提示");
        }

        /// <summary>
        /// 缓冲试验
        /// </summary>
        public void StartBufferTest()
        {
                int r1 = rNumber.Next(1, 10);
                int r2 = rNumber.Next(5, 10);
            //开始试验
            for (int i = 0; i < 60; i++)
                {
                    LOG.Info(String.Format("第 {0}\t组数据 : {1}", i, Math.Sqrt(i)));
                    //Thread.Sleep(50);
                    testGraphInfo.List.Add(i, r1 * Math.Sqrt(i) - r2 * Math.Pow(i, 0.5));
                }
        }
        /// <summary>
        /// 负载效率试验
        /// </summary>
        public void LoadEfficiencyTest()
        {
            
            int r1 = rNumber.Next(1, 5);
            int r2 =rNumber.Next(10, 20);
            //int r3 = rNumber.Next(0, 20);
            //开始试验
            for (int i = 10; i < 60; i++)
            {
                LOG.Info(String.Format("第 {0}\t组数据 : {1}", i, Math.Sqrt(i)));
                //Thread.Sleep(50);
                testGraphInfo.List.Add(i, r1 * Math.Sqrt(i) - r2);
            }
           
        }

      
        /// <summary>
        /// 重写的Run,考虑移回基类
        /// </summary>
        /// <param name="stateInfo"></param>
        public override void Run(Object stateInfo)
        {
            LOG.Info("试验开始...");
            //recorder.StartRecord();    //开始试验记录
            try
            {
                GraphChoose();
                LOG.Info("开始记录数据");
                if (MainForm.test == 6)
                {
                    StartBufferTest();
                }
                else if (MainForm.test == 8)
                {
                    LoadEfficiencyTest();
                }
                else
                {
                    MessageBox.Show("Oh,no");
                }
                 MessageBox.Show("我在run这里");
                //获取实验数据包
                 istested = true;
                //停止记录试验
               // recorder.EndRecort();      
                LOG.Info("试验结束,请打印实验报告...");
            }
            catch (Exception e)
            {
                LOG.Debug(e);
                throw e;
            }
            finally
            {
                TestEndEvent();
            }
    
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

        public void GenerateReport()
        {
            LOG.Info("正在写入基础信息...");
            Dictionary<string, string> Pict = new Dictionary<string, string>();
            WordHelper helper = SetReportBasicInfo(true);
           
            //选择试验生成图片
            //MessageBox.Show("HI");
                if (File.Exists(图片路径))
                {
                    if (MainForm.test == 6)
                    {
                       
                        //string key = "位移时间曲线";
                        
                        Pict.Add("$动态油缸位移时间曲线$", 图片路径);
                        helper.Insertpicture(Pict);
                        LOG.Debug("正在写入图片");
                        helper.SaveDocument(保存路径);
                    }
                    else if (MainForm.test == 8)
                    {
                       // string key = "负载效率曲线";
                        Pict.Add("$动态油缸负载效率试验曲线$", 图片路径);
                        helper.Insertpicture(Pict);
                        LOG.Debug("正在写入图片");
                        helper.SaveDocument(保存路径);
                    }
                }
                else
                {
                    LOG.Error("因为本次实验没有保存图片，无法生成试验报告");
                }
            MessageBox.Show("本次试验报告文档保存在项目MainProj的report中，请查收");
        }
        WordHelper helper = new WordHelper();
        //弹出提示框，给工作人员名单
        public WordHelper SetReportBasicInfo(bool isManul)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            helper.CreateNewDocument(this.模板路径);
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
            helper.InserttextValue(dict);
            return helper;
        }

           
       

    }
}
    
