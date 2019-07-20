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
using MainProj;

namespace MainProj.Local
{
    /// <summary>
    /// 液动换向阀
    /// </summary>
    public class hydraulic_valve:direction_valve
    {
        Dictionary<string, string> Pict = new Dictionary<string, string>();
        Dictionary<string, string> table = new Dictionary<string, string>();        
        public List<float> 工作压力1 = new List<float>();
        public List<float> 工作流量1 = new List<float>();
        public List<float> 工作压力2 = new List<float>();
        public List<float> 工作流量2 = new List<float>();        
        double[] 工作压力1d;
        double[] 工作流量1d;
        double[] 工作压力2d;
        double[] 工作流量2d;
 
        string 图片路径;
        public List<TestType> 实验类型 = new List<TestType>();
        string dir = System.IO.Directory.GetCurrentDirectory();
      
        protected override string 模板路径
        {
            get
            {
                return this.路径 + "\\template\\液动换向阀模板.docx";
            }
        }

        protected override string 保存路径
        {
            get
            {
                return this.路径 + "\\report\\液动换向阀\\液动换向阀试验报告.doc";
            }
        }

        protected override string 元件名称
        {
            get
            {
                return "液动换向阀";
            }
        }
        /// <summary>
        /// 内部泄漏实验
        /// </summary>
        protected override void IntenalLeakage()
        {
            base.IntenalLeakage();
        }
        /// <summary>
        /// 左位或右位稳态压差流量特性实验
        /// </summary>
        /// <param name="state">被试阀阀芯位置</param>
        private void SteadystatePreeesureSingleSide(TestValveState state)
        {
            if (state == TestValveState.中位)
                return;

            //用电液换向阀代替液动换向阀时用到
            if (state == TestValveState.左位) 
            {
                //左位：PBAT
                MessageBox.Show("设置到左位");
            }
            if (state == TestValveState.右位) 
            {
                //右位：PABT
                MessageBox.Show("设置到右位");
            }   
            CurvePanel panel = new CurvePanel();
            panel.Title = TestType.稳态压差流量特性试验.ToString() + "("+state.ToString() + ")";
            panel.XLabel = "流量(L/min)";
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

            SetValve4(10f);//10是百分比
            this.SetPaPressure(10f);//设置先导油的压力
            this.SetCircuitState(CircuitState.PABTOut);
            this.SetThrottleValve(100f);
            this.SetTestValveState(state);
            this.SetSourcePre(this.额定压力);
            float 最大流量 = (float)(this.额定流量);
            this.SetSourceFlow(0);
            Pause(3000);

            const int div_cnt = 20;
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

            SetTestValveState(TestValveState.中位);
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.SetThrottleValve(50f);

            this.dictCurvePanel.Remove(panel.Title);
            this.dictCurvePanel.Add(panel.Title, panel);
        }
        /// <summary>
        /// 稳态压差流量特性实验
        /// </summary>
        protected override void SteadystatePreeesure()
        {
            SteadystatePreeesureSingleSide(TestValveState.左位);
            SteadystatePreeesureSingleSide(TestValveState.右位);
            MessageBox.Show("稳态压差试验已完成");
        }
     
        /// <summary>
        /// 工作范围试验
        /// </summary>
        //protected override void WorkScope()
        //{
        //    MessageBox.Show("请将球阀设置为PABT出口状态");
        //    this.SetCircuitState(CircuitState.PABTOut);
        //    FormWorkScope workscope = new FormWorkScope();
        //    workscope.ShowDialog();
        //    Group["阀4压力值缓存"] = 0f;
        //    System.Threading.Thread.Sleep(1000);
        //    MessageBox.Show("请将球阀设置为AB出口状态");
        //    this.SetCircuitState(CircuitState.ABOut);
        //    Group["阀13位移缓存"] = 50f;
        //    Group["阀14_1位移缓存"] = 50f;
        //    Group["阀14_2位移缓存"] = 50f;//工作于左位开度最小
        //    System.Threading.Thread.Sleep(1000);
        //    this.SetSourcePre(workscope.最大试验压力);
        //    float 试验流量分值 = (float)(workscope.最大试验流量) / 20;
        //    float[] 压力传感器值10_1 = new float[21];
        //    float[] 被试阀流量值 = new float[21];
        //    /*画OD曲线，问题：以流量计读数为准还是设定值为准*/
        //    for (int i = 0; i <= 20; i++)
        //    {
        //        this.SetSourceFlow(i * 试验流量分值);
        //        //System.Threading.Thread.Sleep(3000);
        //        横坐标流量.Add((float)Group[selectedFlowmeter]);
        //        纵坐标压力.Add((float)Group["P口压力"]);
        //    }
        //    横坐标流量.ForEach(i => 工作流量1.Add(i));
        //    纵坐标压力.ForEach(i => 工作压力1.Add(i));
        //    横坐标流量.Clear();
        //    纵坐标压力.Clear();
        //    float 压力差分值 = (float)(this.额定压力 / 20);
        //    List<float> P口压力 = new List<float>();
        //    List<float> 流量计流量 = new List<float>();
        //    bool 判断数据点 = true;//直到被试阀第一次不能换向则为false
        //    /*画ABC曲线*/
        //    for (int j = 0; j <= 20; j++)
        //    {
        //        Group["阀13位移缓存"] = 50 + j * 2.5f;
        //        Group["阀14_1位移缓存"] = 50 + j * 2.5f;
        //        Group["阀14_2位移缓存"] = 50 + j * 2.5f;
        //        //System.Threading.Thread.Sleep(3000);
        //        Group["阀8左控缓存"] = false;
        //        Group["阀8右控缓存"] = true;
        //        //System.Threading.Thread.Sleep(3000);
        //        if (判断数据点 == true)
        //        {
        //            纵坐标压力.Add((float)Group["控制油Pa口压力"]);
        //            横坐标流量.Add((float)Group[selectedFlowmeter]);
        //        }
        //        if ((Group["P口压力"] - Group["A口压力"]) > 1)
        //        {
        //            判断数据点 = false;
        //            //主阀压力未知，暂时按1MPa递增
        //            for (int m = 1; m <= 20; m++)
        //            {
        //                //this.SetSourcePre(this.额定压力 - m * 压力差分值);
        //                Group["阀4压力值缓存"] = m;
        //                System.Threading.Thread.Sleep(3000);
        //                if ((Group["P口压力"] - Group["A口压力"]) < 1)
        //                {
        //                    纵坐标压力.Add((float)Group["控制油Pa口压力"]);
        //                    横坐标流量.Add((float)Group[selectedFlowmeter]);
        //                    break;
        //                }
        //            }
        //            continue;
        //        }
        //        Group["阀8左控缓存"] = true;
        //        Group["阀8右控缓存"] = false;
        //        //System.Threading.Thread.Sleep(3000);
        //        if ((Group["P口压力"] - Group["B口压力"]) > 1)
        //        {
        //            判断数据点 = false;
        //            for (int m = 1; m <= 20; m++)
        //            {
        //                //this.SetSourcePre(this.额定压力 - m * 压力差分值);
        //                Group["阀4压力值缓存"] = m;
        //                //System.Threading.Thread.Sleep(3000);
        //                if ((Group["P口压力"] - Group["A口压力"]) < 1)
        //                {
        //                    纵坐标压力.Add((float)Group["控制油Pa口压力"]);
        //                    横坐标流量.Add((float)Group[selectedFlowmeter]);
        //                    break;
        //                }
        //            }
        //            continue;
        //        }
        //        Group["阀8左控缓存"] = false;
        //        Group["阀8右控缓存"] = false;
        //    }
        //    Group["阀8左控缓存"] = false;
        //    Group["阀8右控缓存"] = false;
        //    横坐标流量.ForEach(i => 工作流量2.Add(i));
        //    纵坐标压力.ForEach(i => 工作压力2.Add(i));
        //    纵坐标压力.Clear();
        //    横坐标流量.Clear();
        //    //System.Threading.Thread.Sleep(3000);
        //    所做试验["工作范围试验"] = true;
        //    MessageBox.Show("工作范围试验已完成");
        //}
     
        public override void GenerateReport()
        {
            //Pict = new Dictionary<string, string>();
            WordHelper helper = SetReportBasicInfo(true);
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
                    string 图片路径1 = 路径 + "\\report\\液动换向阀\\液动换向阀稳态压差流量特性试验曲线(左位)"+"--"+ currentTime +".bmp";
                    string 图片路径2 = 路径 + "\\report\\液动换向阀\\液动换向阀稳态压差流量特性试验曲线(右位)"+"--"+ currentTime + ".bmp";
                    Pict.Add("$稳态压差流量特性曲线1$", 图片路径1);
                    Pict.Add("$稳态压差流量特性曲线2$", 图片路径2);
                    string key1 = TestType.稳态压差流量特性试验.ToString() + "(左位)";
                    string key2 = TestType.稳态压差流量特性试验.ToString() + "(右位)";
                    this.dictCurvePanel[key1].SaveBMP(图片路径1);
                    this.dictCurvePanel[key2].SaveBMP(图片路径2);
                }
                else if (tt == TestType.内部泄漏试验)
                {
                    图片路径 = 路径 + "\\report\\液动换向阀\\液动换向阀内部泄漏试验曲线" + "--" + currentTime + ".bmp";
                    Pict.Add("$内部泄漏试验曲线$", 图片路径);
                    string key = TestType.内部泄漏试验.ToString() + "曲线";
                    this.dictCurvePanel[key].SaveBMP(图片路径);         
                }
                else if (tt == TestType.工作范围试验)
                {
                    图片路径 = 路径 + "\\report\\液动换向阀\\液动换向阀工作范围试验曲线.bmp";
                    Pict.Add("$工作范围试验$", 图片路径);
                    工作流量1d = Array.ConvertAll(工作流量1.ToArray(), new Converter<float, double>(FloatToDouble));
                    工作压力1d = Array.ConvertAll(工作压力1.ToArray(), new Converter<float, double>(FloatToDouble));
                    工作流量2d = Array.ConvertAll(工作流量2.ToArray(), new Converter<float, double>(FloatToDouble));
                    工作压力2d = Array.ConvertAll(工作压力2.ToArray(), new Converter<float, double>(FloatToDouble));
                    double 最大值x = (工作流量1d.Max()) > (工作流量2d.Max()) ? (工作流量1d.Max()) : (工作流量2d.Max());
                    double 最大值y = (工作压力1d.Max()) > (工作压力2d.Max()) ? (工作压力1d.Max()) : (工作压力2d.Max());
                    List<double[]> args = new List<double[]> { 工作流量1d, 工作压力1d, 工作流量2d, 工作压力2d };
                    List<string> Curname = new List<string>() { "曲线1", "曲线2" };
                    ZedSave.SavePic(图片路径, "工作范围特性试验", "流量(L/min)", "压力(MPa)", 0, 最大值x, 0, 最大值y, args, Curname, true);
                    工作压力1.Clear();
                    工作流量1.Clear();
                    工作压力2.Clear();
                    工作流量2.Clear();
                    Array.Clear(工作流量1d, 0, 工作流量1d.Length);
                    Array.Clear(工作压力1d, 0, 工作压力1d.Length);
                    Array.Clear(工作流量2d, 0, 工作流量2d.Length);
                    Array.Clear(工作压力2d, 0, 工作压力2d.Length);
                }
            }
            helper.Insertpicture(Pict);//写入图片
            helper.SaveDocument(保存路径);
            MessageBox.Show("报告已生成");

        }

        public override void SaveReportToDB()
        {
            Dictionary<string, string> Pict2 = new Dictionary<string, string>();
            WordHelper helper = SetReportBasicInfo(false);
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
                    string 图片路径1 = 路径 + "\\report\\液动换向阀\\液动换向阀稳态压差流量特性试验曲线(左位)" + "--" + currentTime + ".bmp";
                    string 图片路径2 = 路径 + "\\report\\液动换向阀\\液动换向阀稳态压差流量特性试验曲线(右位)" + "--" + currentTime + ".bmp";
                    Pict2.Add("$稳态压差流量特性曲线1$", 图片路径1);
                    Pict2.Add("$稳态压差流量特性曲线2$", 图片路径2);
                    string key1 = TestType.稳态压差流量特性试验.ToString() + "(左位)";
                    string key2 = TestType.稳态压差流量特性试验.ToString() + "(右位)";
                    this.dictCurvePanel[key1].SaveBMP(图片路径1);
                    this.dictCurvePanel[key2].SaveBMP(图片路径2);
                }
                else if (tt == TestType.内部泄漏试验)
                {
                    图片路径 = 路径 + "\\report\\液动换向阀\\液动换向阀内部泄漏试验曲线" + "--" + currentTime + ".bmp";
                    Pict2.Add("$内部泄漏试验曲线$", 图片路径);
                    string key = TestType.内部泄漏试验.ToString() + "曲线";
                    this.dictCurvePanel[key].SaveBMP(图片路径);
                }
                else if (tt == TestType.工作范围试验)
                {
                    图片路径 = 路径 + "\\report\\液动换向阀\\液动换向阀工作范围试验曲线.bmp";
                    Pict2.Add("$工作范围试验$", 图片路径);
                    工作流量1d = Array.ConvertAll(工作流量1.ToArray(), new Converter<float, double>(FloatToDouble));
                    工作压力1d = Array.ConvertAll(工作压力1.ToArray(), new Converter<float, double>(FloatToDouble));
                    工作流量2d = Array.ConvertAll(工作流量2.ToArray(), new Converter<float, double>(FloatToDouble));
                    工作压力2d = Array.ConvertAll(工作压力2.ToArray(), new Converter<float, double>(FloatToDouble));
                    double 最大值x = (工作流量1d.Max()) > (工作流量2d.Max()) ? (工作流量1d.Max()) : (工作流量2d.Max());
                    double 最大值y = (工作压力1d.Max()) > (工作压力2d.Max()) ? (工作压力1d.Max()) : (工作压力2d.Max());
                    List<double[]> args = new List<double[]> { 工作流量1d, 工作压力1d, 工作流量2d, 工作压力2d };
                    List<string> Curname = new List<string>() { "曲线1", "曲线2" };
                    ZedSave.SavePic(图片路径, "工作范围特性试验", "流量(L/min)", "压力(MPa)", 0, 最大值x, 0, 最大值y, args, Curname, true);
                    工作压力1.Clear();
                    工作流量1.Clear();
                    工作压力2.Clear();
                    工作流量2.Clear();
                    Array.Clear(工作流量1d, 0, 工作流量1d.Length);
                    Array.Clear(工作压力1d, 0, 工作压力1d.Length);
                    Array.Clear(工作流量2d, 0, 工作流量2d.Length);
                    Array.Clear(工作压力2d, 0, 工作压力2d.Length);
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
            foreach (KeyValuePair<string,string> u in Pict2)
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
                case TestType.工作范围试验:
                    this.WorkScope();
                    break;
                default:
                    throw new TestTypeNotSupportedException();
            }
        }

        protected override void SetTestValveState(TestValveState state)
        {
            this.SetTestValveStatePilot(state);
        }
    }
}
