using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MWord = Microsoft.Office.Interop.Word;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using MainProj.Utils;
using System.IO;

namespace MainProj.Local
{
    public class check_valve:Valve
    {
        private double MinOpeningPressure;
        private int TimeKeep;
        private float TestPressure;
        private float testret = 0;
        Dictionary<string, string> Pict = new Dictionary<string, string>();
        Dictionary<string, string> table = new Dictionary<string, string>();
        private List<TestType> TestTypeName = new List<TestType>();
        public check_valve()
        {
            if (this.试验类型列表 == null)
            {
                this.试验类型列表 = new List<TestType>();
            }
        }

        protected override string 模板路径
          {
              get
              {
                  return this.路径 + "\\template\\直接作用式单向阀模板.docx";
              }
          }

        protected override string 保存路径
          {
              get
              {
                  return this.路径 + "\\report\\直接作用式单向阀\\直接作用式单向阀试验报告.doc";
              }
          }

        protected override string 元件名称
          {
              get
              {
                  return "直接作用式单向阀";
              }
          }
        public static IList<TestType> GetSupportedTestType()
        {
            IList<TestType> list = new List<TestType>();
            list.Add(TestType.耐压试验);
            list.Add(TestType.稳态压差流量特性试验);
            list.Add(TestType.直接作用式单向阀最小开启压力);
            list.Add(TestType.直接作用式单向阀泄漏量试验);
            return list;
        }

        /// <summary>
        /// 稳态压差流量特性试验
        /// </summary>
        private void SteadyPreDifFlowTest()
        {
            CurvePanel panel = new CurvePanel();
            panel.Title = TestType.稳态压差流量特性试验.ToString()+"曲线";
            panel.XLabel = "流量(L/Min)";     
            panel.YLabel = "压差(MPa)";

            //Curve curveAB = new Curve();
            //curveAB.Name = "BA口";
            //panel.AddCurve(curveAB);
            Curve curvePABT = new Curve();
            curvePABT.Name = "BA口";
            panel.AddCurve(curvePABT);



            //this.SetCircuitState(CircuitState.ABOut);//设置球阀状态
            this.SetCircuitState(CircuitState.PABTOut);//设置球阀状态
            //因为上面叠加了一个液动方向阀，外控外排，需要先导油
            this.SetPaPressure(8);
            this.SetTestValveStatePilot(TestValveState.右位);
            this.SetValve4(5);

            this.SetThrottleValve(100f);//设置比例方向阀13/14.1/14.2的位置(右位开口最大)
            this.SetSourcePre(this.额定压力);//设置最大试验压力
            float max_flow = (float)(this.额定流量);
            this.SetSourceFlow(0);
            const int div_cnt = 20;
            const int measure_cnt = 10;

            float pressure_A = 0;
            float pressure_B = 0;
            float delta_q = (float)(max_flow / div_cnt);
            float flow = 0;
            for (int i = 0; i <= div_cnt; i++)
            {
                this.SetSourceFlow(i * delta_q);
                Pause(3000);
                //读取压力流量数据
                flow = 0;
                pressure_A = 0;
                pressure_B = 0;
                for (int j = 0; j < measure_cnt; j++)
                {
                    Pause(1000);
                    flow += this.当前流量绝对值 / measure_cnt;
                    pressure_A += this.当前A口压力 / measure_cnt;

                    //pressure_B += this.当前B口压力 / measure_cnt;
                    pressure_B += this.当前T口压力 / measure_cnt;
                }
                //将数据添加到曲线
                curvePABT.AddPoint(flow, pressure_A - pressure_B);

            }
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.SetThrottleValve(50f);
            this.dictCurvePanel.Remove(panel.Title);
            this.dictCurvePanel.Add(panel.Title, panel);
           
            
        }
        /// <summary>
        /// 直接作用式单向阀最小开启压力
        /// </summary>
        //private void MinOpeningPreTest()
        //{
        //    MinOpeningPressure = 0;
        //    const int test_num = 10;
        //    const int increase_num = 20;

        //    //this.SetCircuitState(CircuitState.ABOut);
        //    this.SetCircuitState(CircuitState.PABTOut);

        //    this.SetThrottleValve(50f);
        //    for (int i = 1; i <= test_num; i++)//重复10次实验
        //    {
        //        for (int j = 1; j < increase_num; j++)
        //        {
        //            SetThrottleValve(50f + (50 / increase_num));
        //            Pause(2000);
        //            if((this.当前流量绝对值) >= 2f)
        //                break;
        //        }
        //        MinOpeningPressure += (this.当前A口压力 - this.当前B口压力) / test_num;
        //    }
        //    this.LOG.Debug("直接作用式单向阀最小开启压力试验结束");
        //}
        private void MinOpeningPreTest()
        {
            MinOpeningPressure = 0;
            const int test_num = 5;

            //this.SetCircuitState(CircuitState.ABOut);
            this.SetCircuitState(CircuitState.PABTOut);

            //因为上面叠加了一个液动方向阀，外控外排，需要先导油
            this.SetPaPressure(8);
            this.SetTestValveStatePilot(TestValveState.右位);
            this.SetValve4(5);

            this.SetThrottleValve(100f);
            this.SetSourceFlow(20);
            this.SetSourcePre(0);
            double[] TempMinOpeningPressure = new double[test_num];
            for (int i = 1; i <= test_num; i++)//重复5次试验,得到5个开启压力
            {
                int j=1;
                while(this.当前流量绝对值<=2f)
                {
                    //获取当前 i 秩序下的一个开启压力
                    this.SetSourcePre( j * 0.01);
                    Pause(1000);
                    TempMinOpeningPressure[i-1] = this.当前B口压力;
                    j++;
                }
            }
            for (int i = 0; i < (test_num-1); i++) //取最大值,，取最小一个（还是最大一个？）
            {
                if(TempMinOpeningPressure[0]<TempMinOpeningPressure[i+1])
                {
                    TempMinOpeningPressure[0]=TempMinOpeningPressure[i+1];
                }
            }
            MinOpeningPressure = TempMinOpeningPressure[0];
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.LOG.Debug("直接作用式单向阀最小开启压力试验结束");
        }
        /// <summary>
        /// 直接作用式单向阀泄漏量试验
        /// </summary>
         private void DirectLeakageTest()
        {
            CurvePanel panel = new CurvePanel();
            panel.Title = TestType.直接作用式单向阀泄漏量试验.ToString()+"曲线";
            panel.XLabel = "压力(MPa)";
            panel.YLabel = "泄漏量(Ml/Min)";
            Curve curve_leak = new Curve();
            panel.AddCurve(curve_leak);
            curve_leak.Name = "泄漏量";

            float retnum;
            //float testret = 0;
            int time = 0;
            float max_pressure = (float)this.额定压力;
            bool needtest = true;

            //this.SetCircuitState(CircuitState.BTIn);
            this.SetCircuitState(CircuitState.T);

            while (needtest)
            {
                FormLeakHydcheck leakHydcheck_config = new FormLeakHydcheck(max_pressure);
                needtest = leakHydcheck_config.ShowDialog() == DialogResult.OK;
                if (!needtest)
                    break;
                this.SetThrottleValve(100f);//使阀13,14_1,14_2工作于右位，且开口最大
                this.SetSourcePre(leakHydcheck_config.实验压力);
                this.SetSourceFlow(20);
                //在试验报告记录用
                this.TestPressure=leakHydcheck_config.实验压力;
                this.TimeKeep = leakHydcheck_config.testtimecount;

                this.WaitPressureTUntil(leakHydcheck_config.实验压力);
                FormLeakageReturn frm_return = new FormLeakageReturn(leakHydcheck_config.testtimecount,this);
                frm_return.ShowDialog();
                time = leakHydcheck_config.testtimecount;
                testret = frm_return.retvol;
                //retnum = (frm_return.retvol / leakHydcheck_config.testtimecount) * 60f;
                //curve_leak.AddPoint(leakHydcheck_config.实验压力, retnum);
            }
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.dictCurvePanel.Remove(panel.Title);
            this.dictCurvePanel.Add(panel.Title, panel);
            MessageBox.Show("泄漏实验已完成");
        }
         protected override void RunTest(TestType testType)
         {
             if (!TestTypeName.Contains(testType))
                 TestTypeName.Add(testType); 
             switch (testType)
             {
                 case TestType.耐压试验:
                     this.EndurationTest();
                     break;
                 case TestType.稳态压差流量特性试验:
                     this.SteadyPreDifFlowTest();
                     break;
                 case TestType.直接作用式单向阀最小开启压力:
                     this.MinOpeningPreTest();
                     break;
                 case TestType.直接作用式单向阀泄漏量试验:
                     this.DirectLeakageTest();
                     break;
                 default:
                     throw new TestTypeNotSupportedException();
             }
         }
         public override void GenerateReport()
         {
             WordHelper helper = this.SetReportBasicInfo(true);
             string currentTime = DateTime.Today.ToString("yyyy-MM-dd");
             Dictionary<string, string> Dict = new Dictionary<string, string>();
             foreach (TestType tt in TestTypeName)
             {
                 if (tt == TestType.耐压试验)
                 {
                     Dict.Add("$P$", Convert.ToString(this.P口耐压));
                     Dict.Add("$T$", Convert.ToString(this.T口耐压));
                     Dict.Add("$A$", Convert.ToString(this.A口耐压));
                     Dict.Add("$B$", Convert.ToString(this.B口耐压));
                     helper.InserttextValue(Dict);//写入文本
                 }
                 if (tt == TestType.稳态压差流量特性试验)
                 {
                     string 图片路径 = 路径 + "\\report\\直接作用式单向阀\\直接作用式单向阀稳态压差流量特性试验曲线" + "--" + currentTime + ".bmp";
                     string key = TestType.稳态压差流量特性试验.ToString() + "曲线";
                     Pict.Add("$稳态压差流量特性曲线$", 图片路径);
                     this.dictCurvePanel[key].SaveBMP(图片路径);
                 }
                 if (tt == TestType.直接作用式单向阀最小开启压力)
                 {
                     Dict.Add("$开启压力$", Convert.ToString(MinOpeningPressure));
                     helper.InserttextValue(Dict);
                 }
                 if (tt == TestType.直接作用式单向阀泄漏量试验 )
                 {
                     Dict.Add("$测试时间$", Convert.ToString(this.TimeKeep));
                     Dict.Add("$测试压力$", Convert.ToString(this.TestPressure));
                     Dict.Add("$泄漏量$", Convert.ToString( testret));
                     helper.InserttextValue(Dict);
                     //string 图片路径 = 路径 + "\\report\\直接作用式单向阀\\直接作用式单向阀泄漏量试验曲线" + "--" + currentTime + ".bmp";
                     //string key = TestType.直接作用式单向阀泄漏量试验.ToString() + "曲线";
                     //Pict.Add("$泄漏量实验曲线$", 图片路径);
                     //this.dictCurvePanel[key].SaveBMP(图片路径);                   
                 }
             }       
             helper.Insertpicture(Pict);//写入图片
             helper.SaveDocument(保存路径);
             MessageBox.Show("报告已生成");
         }
         public override void SaveReportToDB()
         {
             Dictionary<string, string> Pict2 = new Dictionary<string, string>();
             WordHelper helper = this.SetReportBasicInfo(false);
             string currentTime = DateTime.Today.ToString("yyyy-MM-dd");
             Dictionary<string, string> Dict = new Dictionary<string, string>();
             foreach (TestType tt in TestTypeName)
             {
                 if (tt == TestType.耐压试验)
                 {
                     Dict.Add("$P$", Convert.ToString(this.P口耐压));
                     Dict.Add("$T$", Convert.ToString(this.T口耐压));
                     Dict.Add("$A$", Convert.ToString(this.A口耐压));
                     Dict.Add("$B$", Convert.ToString(this.B口耐压));
                     helper.InserttextValue(Dict);//写入文本
                 }
                 if (tt == TestType.稳态压差流量特性试验)
                 {
                     string 图片路径 = 路径 + "\\report\\直接作用式单向阀\\直接作用式单向阀稳态压差流量特性试验曲线" + "--" + currentTime + ".bmp";
                     string key = TestType.稳态压差流量特性试验.ToString() + "曲线";
                     Pict2.Add("$稳态压差流量特性曲线$", 图片路径);
                     this.dictCurvePanel[key].SaveBMP(图片路径);
                 }
                 if (tt == TestType.直接作用式单向阀最小开启压力)
                 {
                     Dict.Add("$开启压力$", Convert.ToString(MinOpeningPressure));
                     helper.InserttextValue(Dict);
                 }
                 if (tt == TestType.直接作用式单向阀泄漏量试验)
                 {
                     Dict.Add("$测试时间$", Convert.ToString(this.TimeKeep));
                     Dict.Add("$测试压力$", Convert.ToString(this.TestPressure));
                     Dict.Add("$泄漏量$", Convert.ToString(testret));
                     helper.InserttextValue(Dict);
                     //string 图片路径 = 路径 + "\\report\\直接作用式单向阀\\直接作用式单向阀泄漏量试验曲线" + "--" + currentTime + ".bmp";
                     //string key = TestType.直接作用式单向阀泄漏量试验.ToString() + "曲线";
                     //Pict.Add("$泄漏量实验曲线$", 图片路径);
                     //this.dictCurvePanel[key].SaveBMP(图片路径);                   
                 }
             }
             helper.Insertpicture(Pict2);//写入图片
             //保存试验报告到本地，调取本地试验报告为二进制格式保存到数据库
             helper.SaveDocument(保存路径);
             FileStream getBinWord = new FileStream(保存路径, FileMode.Open);
             this.testReport = new byte[getBinWord.Length];
             getBinWord.Read(testReport, 0, (int)getBinWord.Length);
             getBinWord.Close();
             File.Delete(保存路径);
             foreach (KeyValuePair<string, string> u in Pict2)
             {
                 File.Delete(u.Value);
             }
             MessageBox.Show("报告已生成");
         }
    }
}
