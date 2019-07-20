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
using System.IO;
using MainProj.Utils;

namespace MainProj.Local
{
    /// <summary>
    /// 手动换向阀
    /// </summary>
    public class manual_valve:direction_valve
    {
        Dictionary<string, string> Pict = new Dictionary<string, string>();
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dictionary<string, string> table = new Dictionary<string, string>();   
        string 图片路径;
        public List<TestType> 实验类型 = new List<TestType>();
        string dir = System.IO.Directory.GetCurrentDirectory();    

        protected override string 模板路径
        {
            get
            {
                return this.路径 + "\\template\\手动换向阀模板.docx";  
            }
        }

        protected override string 保存路径
        {
            get
            {
                return this.路径 + "\\report\\手动换向阀\\手动换向阀试验报告.doc";
            }
        }

        protected override string 元件名称
        {
            get
            {
                return "手动换向阀";
            }
        }


        protected override void IntenalLeakage()
        {
            base.IntenalLeakage();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        private void SteadystatePreeesureSingleSide(TestValveState state)         
        {
            if (state == TestValveState.中位)
                return;

            CurvePanel panel = new CurvePanel();
            panel.Title = TestType.稳态压差流量特性试验.ToString()+"(" + state .ToString()+ ")";
            panel.XLabel = "流量(L/Min)";
            panel.YLabel = "压差(MPa)";
            Curve curvePT = new Curve();
            Curve curvePA = new Curve();
            Curve curvePB = new Curve();
            Curve curveAT = new Curve();
            Curve curveBT = new Curve();
            //添加曲线
            panel.AddCurve(curvePT);
            panel.AddCurve(curvePA);
            panel.AddCurve(curvePB);
            panel.AddCurve(curveAT);
            panel.AddCurve(curveBT);
            //添加曲线名称
            curvePT.Name = "PT口";
            curvePA.Name = "PA口";
            curvePB.Name = "PB口";
            curveAT.Name = "AT口";
            curveBT.Name = "BT口";


            this.SetCircuitState(CircuitState.PABTOut);
            this.SetThrottleValve(100f);
            this.SetTestValveState(state);
            this.SetSourcePre(this.额定压力);
            float 最大流量 = (float)(this.额定流量);
            this.SetSourceFlow(0);
            Pause(3000);

            const int div_cnt = 10;
            const int measure_cnt = 10;

            float pressure_A = 0;
            float pressure_B = 0;
            float pressure_P = 0;
            float pressure_T = 0;
            float delta_q = (float)(最大流量 / div_cnt);

            float flow = 0;
            for (int i = 0; i <= div_cnt; i++)
            {
                this.SetSourceFlow(i * delta_q);

                //读取压力流量数据
                flow = 0;
                pressure_A = 0;
                pressure_B = 0;
                pressure_P = 0;
                pressure_T = 0;
                for (int j = 0; j < measure_cnt; j++)
                {
                    Pause(500);
                    flow += this.当前流量绝对值 / measure_cnt;
                    pressure_A += this.当前A口压力 / measure_cnt;
                    pressure_B += this.当前B口压力 / measure_cnt;
                    pressure_P += this.当前P口压力 / measure_cnt;
                    pressure_T += this.当前T口压力 / measure_cnt;
                }
                //将数据添加到曲线
                curvePT.AddPoint(flow, pressure_P - pressure_T);
                curvePA.AddPoint(flow, pressure_P - pressure_A);
                curvePB.AddPoint(flow, pressure_P - pressure_B);
                curveAT.AddPoint(flow, pressure_A - pressure_T);
                curveBT.AddPoint(flow, pressure_B - pressure_T);
               
            }       
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            SetTestValveState(TestValveState.中位);
            this.SetThrottleValve(50f);

            this.dictCurvePanel.Remove(panel.Title);
            this.dictCurvePanel.Add(panel.Title, panel);
        }
        /// <summary>
        /// 稳态压差流量特性实验
        /// </summary>
        protected override void SteadystatePreeesure()
        {
            this.SteadystatePreeesureSingleSide(TestValveState.左位);
            this.SteadystatePreeesureSingleSide(TestValveState.右位);
            LOG.Debug("稳态压差试验已完成");
        }
      
        public override void GenerateReport()
        {
            WordHelper helper = this.SetReportBasicInfo(true);
            string currentTime = DateTime.Today.ToString("yyyy-MM-dd");
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            foreach (TestType tt in 实验类型)
            {
                if (tt == TestType.耐压试验)
                {
                    Dict.Add("$P$", this.P口耐压.ToString());
                    Dict.Add("$T$", this.T口耐压.ToString());
                    Dict.Add("$A$", this.A口耐压.ToString());
                    Dict.Add("$B$", this.B口耐压.ToString());
                    helper.InserttextValue(Dict);//写入文本
                }
                if (tt == TestType.稳态压差流量特性试验)
                {
                    string 图片路径1 = 路径 + "\\report\\手动换向阀\\手动换向阀稳态压差流量特性试验曲线(左位)" + "--" + currentTime + ".bmp";
                    string 图片路径2 = 路径 + "\\report\\手动换向阀\\手动换向阀稳态压差流量特性试验曲线(右位)" + "--" + currentTime + ".bmp";
                    string key1 = TestType.稳态压差流量特性试验.ToString() + "(左位)";
                    string key2 = TestType.稳态压差流量特性试验.ToString() + "(右位)";
                    Pict.Add("$稳态压差流量特性曲线1$", 图片路径1);
                    Pict.Add("$稳态压差流量特性曲线2$", 图片路径2);
                    this.dictCurvePanel[key1].SaveBMP(图片路径1);
                    this.dictCurvePanel[key2].SaveBMP(图片路径2);
                }
                else if (tt == TestType.内部泄漏试验)
                {
                    图片路径 = 路径 + "\\report\\手动换向阀\\手动换向阀内部泄漏试验曲线" + "--" + currentTime + ".bmp";
                    Pict.Add("$内部泄漏试验曲线$", 图片路径);
                    string key = TestType.内部泄漏试验.ToString() + "曲线";
                    this.dictCurvePanel[key].SaveBMP(图片路径);         
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
            foreach (TestType tt in 实验类型)
            {
                if (tt == TestType.耐压试验)
                {
                    Dict.Add("$P$", this.P口耐压.ToString());
                    Dict.Add("$T$", this.T口耐压.ToString());
                    Dict.Add("$A$", this.A口耐压.ToString());
                    Dict.Add("$B$", this.B口耐压.ToString());
                    helper.InserttextValue(Dict);//写入文本
                }
                if (tt == TestType.稳态压差流量特性试验)
                {
                    string 图片路径1 = 路径 + "\\report\\手动换向阀\\手动换向阀稳态压差流量特性试验曲线(左位)" + "--" + currentTime + ".bmp";
                    string 图片路径2 = 路径 + "\\report\\手动换向阀\\手动换向阀稳态压差流量特性试验曲线(右位)" + "--" + currentTime + ".bmp";
                    string key1 = TestType.稳态压差流量特性试验.ToString() + "(左位)";
                    string key2 = TestType.稳态压差流量特性试验.ToString() + "(右位)";
                    Pict2.Add("$稳态压差流量特性曲线1$", 图片路径1);
                    Pict2.Add("$稳态压差流量特性曲线2$", 图片路径2);
                    this.dictCurvePanel[key1].SaveBMP(图片路径1);
                    this.dictCurvePanel[key2].SaveBMP(图片路径2);
                }
                else if (tt == TestType.内部泄漏试验)
                {
                    图片路径 = 路径 + "\\report\\手动换向阀\\手动换向阀内部泄漏试验曲线" + "--" + currentTime + ".bmp";
                    Pict2.Add("$内部泄漏试验曲线$", 图片路径);
                    string key = TestType.内部泄漏试验.ToString() + "曲线";
                    this.dictCurvePanel[key].SaveBMP(图片路径);
                }
            }
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

        protected override void RunTest(TestType testType)
        {
            实验类型.Add(testType);
            switch (testType)
            {
                case TestType.耐压试验:
                    this.EndurationTest();
                    break;
                case TestType.内部泄漏试验:
                    this.IntenalLeakage();
                    break;
                case TestType.稳态压差流量特性试验:
                    this.SteadystatePreeesure();
                    break;
                default:
                    throw new TestTypeNotSupportedException();
            }
        }
        /// <summary>
        /// 设置被试阀至指定工位
        /// </summary>
        /// <param name="state"></param>
        protected override void SetTestValveState(TestValveState state)
        {
            MessageBox.Show("请手动将被试阀切换至" + state.ToString());
        }
    }
}
