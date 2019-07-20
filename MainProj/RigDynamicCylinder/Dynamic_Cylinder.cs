using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using HyTestRTDataService;
using MainProj.Utils;
using MainProj.Util;
using System.IO;
using System.Windows.Forms;


namespace MainProj.Local
{

    public class Dynamic_Cylinder : SharedBase
    {

        //当前试验线程
        // public Thread threadTest;

        //试验结束后失效三个试验按钮，触发生成图片
        public delegate void TestEndEventHandler();
        public event TestEndEventHandler TestEndEvent;
        //模拟曲线的随机生成数
        Random rNumber = new Random();
        //记录周期500ms
        private TestRecorder recorder = new TestRecorder(500);
        public List<TestType> testTypes = new List<TestType>();
        Dictionary<string, string> Pict = new Dictionary<string, string>();

        //试验曲线变量实例化
        public GraphInfo testGraphInfo; 
        public string 模板路径
        {
            get
            {
                return Dynamic_Cylinder.路径 + "\\template\\缓冲试验报告模板.docx";
            }
            set { }
        }

        public  string 保存路径
        {
            get
            {
                return Dynamic_Cylinder.路径 + "\\report\\缓冲试验报告.docx";
            }
            set { }
        }

        public  string 元件名称
        {
            get
            {
                return "流量控制阀";
            }
        }

        public Dynamic_Cylinder()
        {
            if (this.试验类型列表 == null)
            {
                this.试验类型列表 = new List<TestType>();
            }
            路径 = Path.GetFullPath("..");
            模板路径 = 路径 + "\\template\\缓冲试验报告模板.docx";
            图片路径 = 路径 + "\\report\\pict\\缓冲试验报告曲线" + DateTime.Now.ToString("yy-MM-dd hhmmss") + ".bmp"; ;
            保存路径 = 路径 + "\\report\\缓冲试验报告.docx";
            testGraphInfo = new GraphInfo("缓冲试验报告", "时间", "位移", 图片路径);
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
        public override void RunTest(TestType testType)
         {
             if (!this.testTypes.Contains(testType))
                 this.testTypes.Add(testType);
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
                default:
                     throw new TestTypeNotSupportedException();
            }

         }

        /// <summary>
        /// 试运转实验
        /// </summary>
        /// <param name="dictCurve"></param>
        /// <param name="state"></param>
        /// <param name="n">第N次试验</param>
        private void StartWorkTest()
        {
           
        }

        /// <summary>
        ///启动压力特性试验
        /// </summary>
        
        public void StartPressureTest()
        {           
          
        }
        /// <summary>
        /// 耐压试验
        /// </summary>
        public void PressTest()
        {

        }
        /// <summary>
        /// 耐久性试验
        /// </summary>
        public void EnduranceTest()
        {

        }

        /// <summary>
        /// 缓冲试验
        /// </summary>
        public void StartBufferTest()
        {
              //server.NormalWrite("试验开始", true);
                int r1 = rNumber.Next(0, 5);
                int r2 = rNumber.Next(0, 10);
                //int r3 = rNumber.Next(0, 20);
                //开始试验
                for (int i = 0; i < 50; i++)
                {
                    LOG.Info(String.Format("第 {0}\t组数据 : {1}", i, Math.Sqrt(i)));
                    Thread.Sleep(50);
                   //testGraphInfo.List.Add(i, r1 * Math.Sqrt(i) - r2 + r3 * Math.Pow(i, 0.5));                     //*******获取关键数据，重要，待修改
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
            recorder.StartRecord();    //开始试验记录
            try
            {
                LOG.Info("开始记录数据");
                foreach (TestType testType in this.试验类型列表)
                {
                    LOG.Info(testType.ToString() + " 开始");
                    RunTest(testType);
                    LOG.Info(testType.ToString() + " 结束");
                }
                //获取实验数据包
                istested = true;
                //停止记录试验
                recorder.EndRecort();

                //LOG.Info("试验结束,请打印实验报告...");

            }
            catch (TestAbortException e)
            {
                LOG.Error("试验被用户主动终止");
            }
            catch (Exception e)
            {
                LOG.Debug(e);
                throw e;
            }
            finally
            {
                TestEndEvent();
                MessageBox.Show("试验结束,请打印实验报告...");
            }

        }

        public override void GenerateReport()
        {
            LOG.Info("正在写入基础信息...");
            Dictionary<string, string> Pict = new Dictionary<string, string>();
            WordHelper helper = SetReportBasicInfo(true);

            string key = "位移时间曲线";

            if (File.Exists(图片路径))
            {
                Pict.Add("$动态油缸位移时间曲线$", 图片路径);
                helper.Insertpicture(Pict);
                LOG.Debug("正在写入图片");
               //此处省略保存路径
            }
            else
            {
                LOG.Error("因为本次实验没有保存图片，无法生成试验报告");
            }
        }
        WordHelper helper = new WordHelper();
        //弹出提示框，给工作人员名单
        public override  WordHelper SetReportBasicInfo(bool isManul)
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

            MessageBox.Show("缓冲油缸试验报告文档保存在项目的report中，请查收");
            helper.InserttextValue(dict);
            return helper;
        }


    }
}
    
