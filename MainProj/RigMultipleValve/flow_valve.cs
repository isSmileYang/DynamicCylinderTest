using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using MainProj.Utils;
using System.IO;
using System.Windows.Forms;


namespace MainProj.Local
{

    public class flow_valve : Valve
    {
       
        List<TestType> testTypes = new List<TestType>();
        Dictionary<string, string> Pict = new Dictionary<string, string>();     

        protected override string 模板路径
        {
            get
            {
                return this.路径 + "\\template\\流量控制阀模板.docx";
            }
        }

        protected override string 保存路径
        {
            get
            {
                return this.路径 + "\\report\\流量控制阀\\流量控制阀试验报告.doc";
            }
        }

        protected override string 元件名称
        {
            get
            {
                return "流量控制阀";
            }
        }

        public flow_valve()
        {
            if (this.试验类型列表 == null)
            {
                this.试验类型列表 = new List<TestType>();
            }
        }

        public static IList<TestType> GetSupportedTestType()
        {
            IList<TestType> list = new List<TestType>();
            list.Add(TestType.耐压试验);
            list.Add(TestType.外泄漏试验);
            list.Add(TestType.稳态流量压力特性试验);
            return list;
        }

        protected override void RunTest(TestType testType)
        {
            if (!this.testTypes.Contains(testType))
                this.testTypes.Add(testType);
            switch (testType)
            {
                case TestType.耐压试验:
                    this.EndurationTest();
                    break;
                case TestType.外泄漏试验:
                    this.ExternalLeakTest();     ///实验程序
                    break;
                case TestType.稳态流量压力特性试验:
                    this.StaticFlowPressureTest();
                    break;
                default:
                    throw new TestTypeNotSupportedException();
            }

        }

        /// <summary>
        /// 外泄漏试验
        /// </summary>
        public void ExternalLeakTest()
        {
            if (this.有外泄漏口 == true)
            {
                CurvePanel panel = new CurvePanel();
                Dictionary<string, Curve> dictCurve = new Dictionary<string, Curve>();
                panel.Title = TestType.外泄漏试验.ToString() + "曲线";
                panel.XLabel = "流量(L/Min)";
                panel.YLabel = "压差(MPa)";
                bool need_test = true;
                int test_num = 0;
                while (need_test)
                {
                    test_num++;
                    flow_valve_confirmForm frm_confirm = new flow_valve_confirmForm();
                    need_test = frm_confirm.ShowDialog() == DialogResult.OK;
                    if (!need_test)
                        break;
                    StaticFlowPressSingleState(panel, CircuitState.ATIn, test_num);
                    StaticFlowPressSingleState(panel, CircuitState.ATOut, test_num);                    
                }
                
                foreach (string key in dictCurve.Keys)
                {
                    panel.AddCurve(dictCurve[key]);
                }
                this.SetSourcePre(0);
                this.SetSourceFlow(0);
                this.SetThrottleValve(50f);
                this.dictCurvePanel.Remove(panel.Title);
                this.dictCurvePanel.Add(panel.Title, panel);                  
            }
            else
            {
                LOG.Error("无外泄漏口，无法做外泄漏试验！");
                return;
            }                          
        }

        /// <summary>
        /// 稳态流量压力特性试验-指定阀口开度
        /// </summary>
        /// <param name="dictCurve"></param>
        /// <param name="state"></param>
        /// <param name="n">第N次试验</param>
        private void StaticFlowPressSingleState( CurvePanel panel, CircuitState state,int n)
        {
            string key = state.ToString() + "曲线"+n.ToString();
            Curve curve = new Curve();
            curve.Name = key;
            panel.AddCurve(curve);

            this.SetCircuitState(state);  //设置球阀状态
            this.SetThrottleValve(100f);
            this.SetSourcePre(this.额定压力);
            float max_flow = (float)(this.额定流量);
            this.SetSourceFlow(0);
            //Pause(3000);

            const int div_cnt = 20;
            const int measure_cnt = 5;
            float pressure_A = 0;
            float pressure_T = 0;
            float delta_q = (float)(max_flow / div_cnt);
            float flow = 0;
            for (int i = 0; i <= div_cnt; i++)
            {
                this.SetSourceFlow(i * delta_q);
                //读取压力流量数据
                flow = 0;
                pressure_A = 0;
                pressure_T = 0;
                for (int j = 0; j < measure_cnt; j++)
                {
                    Pause(1000);
                    flow += this.当前流量绝对值 / measure_cnt;
                    pressure_A += this.当前A口压力 / measure_cnt;
                    pressure_T += this.当前T口压力 / measure_cnt;
                }
                //将数据添加到曲线               
                curve.AddPoint(flow, pressure_A - pressure_T);
            }
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.SetThrottleValve(50f);           
        }
        
        /// <summary>
        /// 稳态流量压力特性试验
        /// </summary>
        public void StaticFlowPressureTest()
        {           
          
            CurvePanel panel = new CurvePanel();
            panel.Title = TestType.稳态流量压力特性试验.ToString() + "曲线";
            panel.XLabel = "流量(L/Min)";
            panel.YLabel = "压差(MPa)";

            Dictionary<string, Curve> dictCurve = new Dictionary<string, Curve>();
            bool need_test = true;
            int i = 1;
            while (need_test)
            {
                flow_valve_confirmForm frm_confirm = new flow_valve_confirmForm();
                need_test = frm_confirm.ShowDialog() == DialogResult.OK;
                if (!need_test)
                    break;              
                StaticFlowPressSingleState(panel, CircuitState.ATIn, i);
                i++;
            }

            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.SetThrottleValve(50f);
            this.dictCurvePanel.Remove(panel.Title);
            this.dictCurvePanel.Add(panel.Title, panel);   
        }

        public override void GenerateReport()
        {
            WordHelper helper = SetReportBasicInfo(true);
            string currentTime = DateTime.Today.ToString("yyyy-MM-dd");
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            foreach (TestType tt in testTypes)
            {
                if (tt == TestType.耐压试验)
                {
                    Dict.Add("$P$", this.P口耐压.ToString() + "Mpa");
                    Dict.Add("$T$", this.T口耐压.ToString() + "Mpa");
                    Dict.Add("$A$", this.A口耐压.ToString() + "Mpa");
                    Dict.Add("$B$", this.B口耐压.ToString() + "Mpa");
                }
                if (tt == TestType.稳态流量压力特性试验)
                {
                    string 图片路径 = 路径 + "\\report\\流量控制阀\\流量控制阀稳态压差流量特性试验曲线"+"--"+ currentTime +".bmp";
                    string key = TestType.稳态流量压力特性试验.ToString() + "曲线";
                    Pict.Add("$流量控制阀稳态特性曲线$", 图片路径);
                    this.dictCurvePanel[key].SaveBMP(图片路径);  
                }
                if ((tt == TestType.外泄漏试验)&&this.有外泄漏口==true)
                {
                    string 图片路径 = 路径 + "\\report\\流量控制阀\\外泄漏试验曲线" + "--" + currentTime + ".bmp";
                    string key = TestType.外泄漏试验.ToString() + "曲线";
                    Pict.Add("$外泄漏试验曲线$", 图片路径);
                    this.dictCurvePanel[key].SaveBMP(图片路径);  
                }                                              
            }
            helper.InserttextValue(Dict);//写入文本 
            LOG.Debug("写入文本");
            helper.Insertpicture(Pict);//写入图片
            LOG  .Debug("写入图片");
            helper.SaveDocument(保存路径);
            LOG.Debug("保存路径");
            System.Windows.Forms.MessageBox.Show("报告已生成");
        }
        /// <summary>
        /// 将临时实验报告保存至report\cache\xx阀文件夹，使用过后暂时无需删除
        /// 可定时清理cache文件夹
        /// </summary>
        public override void SaveReportToDB()
        {
            Dictionary<string, string> Pict2 = new Dictionary<string, string>();
            WordHelper helper = SetReportBasicInfo(false);                              //无需弹窗填写试验人员
            string currentTime = DateTime.Today.ToString("yyyy-MM-dd");
            string 临时文件 = 路径 + "\\report\\cache\\流量控制阀\\流量控制阀试验报告" + currentTime + ".doc";      //保存路径到cache
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            foreach (TestType tt in testTypes)
            {
                if (tt == TestType.耐压试验)
                {
                    Dict.Add("$P$", this.P口耐压.ToString() + "Mpa");
                    Dict.Add("$T$", this.T口耐压.ToString() + "Mpa");
                    Dict.Add("$A$", this.A口耐压.ToString() + "Mpa");
                    Dict.Add("$B$", this.B口耐压.ToString() + "Mpa");
                }
                if (tt == TestType.稳态流量压力特性试验)
                {
                    string 图片路径 = 路径 + "\\report\\cache\\流量控制阀\\流量控制阀稳态压差流量特性试验曲线" + "--" + currentTime + ".bmp";   //图片保存到cache
                    string key = TestType.稳态流量压力特性试验.ToString() + "曲线";
                    Pict2.Add("$流量控制阀稳态特性曲线$", 图片路径);
                    this.dictCurvePanel[key].SaveBMP(图片路径);
                }
                if ((tt == TestType.外泄漏试验) && this.有外泄漏口 == true)
                {
                    string 图片路径 = 路径 + "\\report\\cache\\流量控制阀\\外泄漏试验曲线" + "--" + currentTime + ".bmp";                     //图片保存到cache
                    string key = TestType.外泄漏试验.ToString() + "曲线";
                    Pict2.Add("$外泄漏试验曲线$", 图片路径);
                    this.dictCurvePanel[key].SaveBMP(图片路径);
                }
            }
            //向试验报告写入信息
            helper.InserttextValue(Dict);//写入文本 
            LOG.Debug("写入文本");
            helper.Insertpicture(Pict2);//写入图片
            LOG.Debug("写入图片");
            helper.SaveDocument(临时文件);
            LOG.Debug(临时文件);
            /*存数据库
             *1.调取本地试验报告为二进制格式保存到数据库 
             *2.log提示保存成功*/
            FileStream getBinWord = new FileStream(临时文件, FileMode.Open);
            this.testReport = new byte[getBinWord.Length];
            getBinWord.Read(testReport, 0, (int)getBinWord.Length);
            getBinWord.Close();
            LOG.Debug("报告已保存到数据库");
        }
    }
}
    
