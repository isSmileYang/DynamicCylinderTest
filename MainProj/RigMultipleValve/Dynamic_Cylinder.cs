using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProj.Utils;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MainProj.Local
{
    public class Dynamic_Cylinder : Valve
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(Dynamic_Cylinder));
        Dictionary<string, string> Pict = new Dictionary<string, string>();
        List<TestType> testTypes = new List<TestType>();
  
        public Dynamic_Cylinder()
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
                return this.路径 + "\\template\\减压阀模板.docx";
            }
        }

        protected override string 保存路径
        {
            get
            {
                return this.路径 + "\\report\\减压阀\\减压阀试验报告.doc";
            }
        }

        protected override string 元件名称
        {
            get
            {
                return "减压阀";
            }
        }
        public static IList<TestType> GetSupportedTestType()
        {
            IList<TestType> list = new List<TestType>();
            list.Add(TestType.耐压试验);
            list.Add(TestType.最低工作压力试验);
            list.Add(TestType.稳态压力流量特性试验);
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
        /// <summary>
        /// 稳态压力流量特性试验
        /// </summary>
        private void StaticPressureFlowTest()
        {
            while(this.当前流量绝对值>2f)
            {
                Pause(1000);
            }
            CurvePanel panel = new CurvePanel();
            panel.Title = TestType.稳态压力流量特性试验.ToString() + "曲线";
            panel.XLabel = "流量(L/min)";
            panel.YLabel = "压力(MPa)";

            this.SetCircuitState(CircuitState.PBOut);//设置球阀状态,出口流量检测
            this.SetThrottleValve(100f);//设置比例方向阀13/14.1/14.2的位置(右位开口最大)
            const int div_cnt = 20;
            const int measure_cnt = 10;
            float delta_q = (float)(this.额定流量 / div_cnt);
            float flow = 0;
            float pressure_B = 0;
            int repeat_cnt = 0;

            while (System.Windows.Forms.MessageBox.Show("调整减压阀的设定压力值，是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Curve curve = new Curve();
                panel.AddCurve(curve);
                curve.Name = repeat_cnt++.ToString();
                this.SetSourcePre(this.额定压力);
                this.SetSourceFlow(this.额定流量 + 10f);
                Pause(15000);
                
                for (int i = div_cnt; i >= 0; i--)
                {
                    this.SetSourceFlow(i * delta_q);

                    //读取压力流量数据
                    flow = 0;
                    pressure_B = 0;
                    for (int j = 0; j < measure_cnt; j++)
                    {
                        Pause(1000);
                        flow += Math.Abs(this.当前流量绝对值 / measure_cnt);
                        pressure_B += this.当前B口压力 / measure_cnt;
                        //pressure_B += (this.当前P口压力-this.当前B口压力 )/ measure_cnt;
                    }
                    //将数据添加到曲线
                    curve.AddPoint(flow, pressure_B);

                }
                for (int i = 1; i <= div_cnt; i++)
                {
                    this.SetSourceFlow(i * delta_q);

                    //读取压力流量数据
                    flow = 0;
                    pressure_B = 0;
                    for (int j = 0; j < measure_cnt; j++)
                    {
                        Pause(500);
                        flow += Math.Abs(this.当前流量绝对值 / measure_cnt);
                        pressure_B += this.当前B口压力 / measure_cnt;
                    }
                    //将数据添加到曲线
                    curve.AddPoint(flow, pressure_B);
                }
                 this.SetSourcePre(0);
                 this.SetSourceFlow(0);
            }
            //this.SetSourcePre(0);
            //this.SetSourceFlow(0);
            this.SetThrottleValve(50f);//设置比例方向阀13/14.1/14.2的位置(右位开口最大)
            this.dictCurvePanel.Remove(panel.Title);
            this.dictCurvePanel.Add(panel.Title, panel);
        }
        /// <summary>
        /// 最低工作压力试验
        /// </summary>
        private void MinworkingPreTest()
        {
            while (this.当前流量绝对值 > 2f)
            {
                Pause(1000);
            }
            if (System.Windows.Forms.MessageBox.Show("是否已调整减压阀的设定压力值为最小", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurvePanel panel = new CurvePanel();
                panel.Title = TestType.最低工作压力试验.ToString() + "曲线";
                panel.XLabel = "流量(L/min)";
                panel.YLabel = "压力(MPa)";

                this.SetCircuitState(CircuitState.PBOut);//设置球阀状态,出口流量检测
                this.SetThrottleValve(100f);//设置比例方向阀13/14.1/14.2的位置(右位开口最大)
                this.SetSourcePre(this.额定压力);
                this.SetSourceFlow(this.额定流量 + 10f);
                Pause(15000) ;
                const int div_cnt = 20;
                const int measure_cnt = 10;
                float delta_q = (float)(this.额定流量 / div_cnt);
                float flow = 0;
                float pressure_B = 0;
                int repeat_cnt = 0;

                Curve curve = new Curve();
                panel.AddCurve(curve);
                curve.Name = repeat_cnt++.ToString();
                for (int i = 0; i <= div_cnt; i++)
                {
                    this.SetSourceFlow(i * delta_q);

                    //读取压力流量数据
                    flow = 0;
                    pressure_B = 0;
                    for (int j = 0; j < measure_cnt; j++)
                    {
                        Pause(500);
                        flow += Math.Abs(this.当前流量绝对值 / measure_cnt);
                        pressure_B += this.当前B口压力 / measure_cnt;
                    }
                    //将数据添加到曲线
                    curve.AddPoint(flow, pressure_B);
                }
                this.SetSourcePre(0);
                this.SetSourceFlow(0);
                this.SetThrottleValve(50f);
                this.dictCurvePanel.Remove(panel.Title);
                this.dictCurvePanel.Add(panel.Title, panel);
            }
            else
            {
                this.log.Debug("未将工作压力值置最小，试验结束");
            }
        }
        public override void GenerateReport()
        {
            WordHelper helper = this.SetReportBasicInfo(true);
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
                    helper.InserttextValue(Dict);
                }
                if (tt == TestType.稳态压力流量特性试验)
                {
                    string 图片路径 = 路径 + "\\report\\减压阀\\减压阀稳态压力流量特性试验曲线" + "--" + currentTime + ".bmp";
                    string key = TestType.稳态压力流量特性试验.ToString() + "曲线";
                    Pict.Add("$稳态压力流量特性曲线$", 图片路径);
                    this.dictCurvePanel[key].SaveBMP(图片路径);  
                    
                }
                if (tt == TestType.最低工作压力试验)
                {
                    string 图片路径 = 路径 + "\\report\\减压阀\\减压阀工作压力特性曲线" + "--" + currentTime + ".bmp";
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
            foreach (TestType tt in testTypes)
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
                    string 图片路径 = 路径 + "\\report\\减压阀\\减压阀稳态压力流量特性试验曲线" + "--" + currentTime + ".bmp";
                    string key = TestType.稳态压力流量特性试验.ToString() + "曲线";
                    Pict2.Add("$稳态压力流量特性曲线$", 图片路径);
                    this.dictCurvePanel[key].SaveBMP(图片路径);

                }
                if (tt == TestType.最低工作压力试验)
                {
                    string 图片路径 = 路径 + "\\report\\减压阀\\减压阀工作压力特性曲线" + "--" + currentTime + ".bmp";
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
