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
    public class relief_valve:Valve
    {
      

        private List<double> FlowList = new List<double>();
        private List<double> PressureList = new List<double>();
        private List<double> FlowListMinPre = new List<double>();
        private List<double> PressureListMinPre = new List<double>();
        Dictionary<string, string> Pict = new Dictionary<string, string>();
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        private List<TestType> TestTypeName = new List<TestType>();

        protected override string 模板路径
        {
            get
            {
                return this.路径 + "\\template\\溢流阀模板.docx";
            }
        }

        protected override string 保存路径
        {
            get
            {
                return this.路径 + "\\report\\溢流阀\\溢流阀试验报告.doc";
            }
        }

        protected override string 元件名称
        {
            get
            {
                return "溢流阀";
            }
        }


        public relief_valve()
        {
            if (this.试验类型列表 == null)
            {
                this.试验类型列表 = new List<TestType>();
            }
            //foreach (TestType tt in GetSupportedTestType())
            //{
            //    this.试验类型列表.Add(tt);
            //}        
        }
        public static IList<TestType> GetSupportedTestType()
        {
            IList<TestType> list = new List<TestType>();
            list.Add(TestType.耐压试验);
            list.Add(TestType.稳态压力流量特性试验);
            list.Add(TestType.最低工作压力试验);
            return list;
        }

        /// <summary>
        /// 稳态压力流量特性试验
        /// 设置不同的出口压力值，针对不同的出口压力设定值（必须包含最高和最低）：
        /// 流量从零加到最大，再从最大减到0，测试被试阀的进口压力
        /// </summary>
        private void StaticPressureFlowTest()
        {
            CurvePanel panel = new CurvePanel();
            panel.Title = TestType.稳态压力流量特性试验.ToString()+"曲线";
            panel.XLabel = "流量(L/min)";
            panel.YLabel = "压力(MPa)";
            this.SetOfSelectFlowMeter((float)this.额定流量);
            this.SetCircuitState(CircuitState.PTOut );//设置球阀状态,出口流量检测
            this.SetThrottleValve(100f);//设置比例方向阀13/14.1/14.2的位置(右位开口最大)
            this.SetSourcePre(this.额定压力);

            const int div_cnt = 20;
            const int measure_cnt = 10;
            float delta_q = (float)(this.额定流量 / div_cnt);
            float flow = 0;
            float pressure_P = 0;
            int repeat_cnt=0;

            while (System.Windows.Forms.MessageBox.Show("调整溢流阀的设定压力值，是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Curve curve = new Curve();
                panel.AddCurve(curve);
                curve.Name = repeat_cnt++.ToString();
                this.SetSourcePre(this.额定压力);
                for (int i = 0; i <= div_cnt; i++)
                {
                    this.SetSourceFlow(i * delta_q);

                    //读取压力流量数据
                    flow = 0;
                    pressure_P = 0;
                    for (int j = 0; j < measure_cnt; j++)
                    {
                        Pause(500);
                        flow += Math.Abs(this.当前流量绝对值 / measure_cnt);
                        pressure_P += this.当前P口压力 / measure_cnt;
                    }
                    //将数据添加到曲线
                    curve.AddPoint(flow, pressure_P);
                }
                
                for (int i = div_cnt - 1; i >= 0; i--)
                {
                    this.SetSourceFlow(i * delta_q);

                    //读取压力流量数据
                    flow = 0;
                    pressure_P = 0;
                    for (int j = 0; j < measure_cnt; j++)
                    {
                        Pause(500);
                        flow += Math.Abs(this.当前流量绝对值 / measure_cnt);
                        pressure_P += this.当前P口压力 / measure_cnt;
                    }
                    //将数据添加到曲线
                    curve.AddPoint(flow, pressure_P);
                }
                this.SetSourcePre(0);
                this.SetSourceFlow(0);
            }
            //this.SetSourcePre(0);
            //this.SetThrottleValve(50f);//设置比例方向阀13/14.1/14.2的位置(右位开口最大)
            this.dictCurvePanel.Remove(panel.Title);
            this.dictCurvePanel.Add(panel.Title, panel);
        }

        /// <summary>
        /// 最低工作压力试验
        /// </summary>
        private void MinworkingPreTest()
        {
            if (System.Windows.Forms.MessageBox.Show("是否已调整减压阀的设定压力值为最小", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurvePanel panel = new CurvePanel();
                panel.Title = TestType.最低工作压力试验.ToString() + "曲线";
                panel.XLabel = "流量(L/min)";
                panel.YLabel = "压力(MPa)";
                this.SetOfSelectFlowMeter((float)this.额定流量);
                this.SetCircuitState(CircuitState.PTOut);//设置球阀状态,出口流量检测
                this.SetThrottleValve(100f);//设置比例方向阀13/14.1/14.2的位置(右位开口最大)
                this.SetSourcePre(this.额定压力);

                const int div_cnt = 20;
                const int measure_cnt = 10;
                float delta_q = (float)(this.额定流量 / div_cnt);
                float flow = 0;
                float pressure_P = 0;
                int repeat_cnt = 0;

                Curve curve = new Curve();
                panel.AddCurve(curve);
                curve.Name = repeat_cnt++.ToString();
                for (int i = 0; i <= div_cnt; i++)
                {
                    this.SetSourceFlow(i * delta_q);

                    //读取压力流量数据
                    flow = 0;
                    pressure_P = 0;
                    for (int j = 0; j < measure_cnt; j++)
                    {
                        Pause(500);
                        flow += Math.Abs(this.当前流量绝对值 / measure_cnt);
                        pressure_P += this.当前P口压力 / measure_cnt;
                    }
                    //将数据添加到曲线
                    curve.AddPoint(flow, pressure_P);
                }
                this.SetSourcePre(0);
                this.SetSourceFlow(0);
                this.SetThrottleValve(50f);//设置比例方向阀13/14.1/14.2的位置(右位开口最大)
                this.dictCurvePanel.Remove(panel.Title);
                this.dictCurvePanel.Add(panel.Title, panel);
            }
            else
            {
                this.LOG.Debug("未将设定压力值置最小，试验结束");
            }
        }
        protected override void RunTest(TestType testType)
        {
            if(!TestTypeName.Contains(testType))
                TestTypeName.Add(testType); 
            switch (testType)
            {
                case TestType.耐压试验:
                    this.EndurationTest();
                    break;
                case TestType.稳态压力流量特性试验:
                    this.StaticPressureFlowTest();
                    break;
                case TestType.最低工作压力试验:
                    this.MinworkingPreTest();
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
                     Dict.Add("$P$", this.P口耐压.ToString() + "Mpa");
                     Dict.Add("$T$", this.T口耐压.ToString() + "Mpa");
                     Dict.Add("$A$", this.A口耐压.ToString() + "Mpa");
                     Dict.Add("$B$", this.B口耐压.ToString() + "Mpa");
                     helper.InserttextValue(Dict);
                 }
                 if (tt == TestType.稳态压力流量特性试验)
                 {
                     string 图片路径 = 路径 + "\\report\\溢流阀\\溢流阀稳态压力流量特性曲线" + "--" + currentTime + ".bmp";
                     Pict.Add("$稳态压力流量曲线$", 图片路径);
                     string key = TestType.稳态压力流量特性试验.ToString() + "曲线";
                     this.dictCurvePanel[key].SaveBMP(图片路径); 
                 }
                 if (tt == TestType.最低工作压力试验)
                 {

                     string 图片路径 = 路径 + "\\report\\溢流阀\\溢流阀工作压力特性曲线" + "--" + currentTime + ".bmp";
                     Pict.Add("$工作压力特性曲线$", 图片路径);
                     string key = TestType.最低工作压力试验.ToString() + "曲线";
                     this.dictCurvePanel[key].SaveBMP(图片路径); 
                 }
             }
            helper.InserttextValue(Dict);//写入文本
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
                    Dict.Add("$P$", this.P口耐压.ToString() + "Mpa");
                    Dict.Add("$T$", this.T口耐压.ToString() + "Mpa");
                    Dict.Add("$A$", this.A口耐压.ToString() + "Mpa");
                    Dict.Add("$B$", this.B口耐压.ToString() + "Mpa");
                    helper.InserttextValue(Dict);
                }
                if (tt == TestType.稳态压力流量特性试验)
                {
                    string 图片路径 = 路径 + "\\report\\溢流阀\\溢流阀稳态压力流量特性曲线" + "--" + currentTime + ".bmp";
                    Pict2.Add("$稳态压力流量曲线$", 图片路径);
                    string key = TestType.稳态压力流量特性试验.ToString() + "曲线";
                    this.dictCurvePanel[key].SaveBMP(图片路径);
                }
                if (tt == TestType.最低工作压力试验)
                {

                    string 图片路径 = 路径 + "\\report\\溢流阀\\溢流阀工作压力特性曲线" + "--" + currentTime + ".bmp";
                    Pict2.Add("$工作压力特性曲线$", 图片路径);
                    string key = TestType.最低工作压力试验.ToString() + "曲线";
                    this.dictCurvePanel[key].SaveBMP(图片路径);
                }
            }
            helper.InserttextValue(Dict);//写入文本
            helper.Insertpicture(Pict2);//写入图片
            helper.SaveDocument(保存路径);
            //保存试验报告到本地，调取本地试验报告为二进制格式保存到数据库
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
