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
using System.Threading;

namespace MainProj.Local
{    
    public class Propodirection_valve : Valve
    {
        public Dictionary<string, bool> 所做试验 = new Dictionary<string, bool>();

        Dictionary<string, string> Pict = new Dictionary<string, string>();

        private const float 阀口总压降 = 1.0f;
       
        public List<TestType> 实验类型 = new List<TestType>();

        string dir = System.IO.Directory.GetCurrentDirectory();

        protected override string 模板路径
        {
            get
            {
                return this.路径 + "\\template\\比例方向阀模板.docx";
            }
        }
        protected override string 保存路径
        {
            get
            {
                return this.路径 + "\\report\\比例方向阀\\比例方向阀试验报告.doc";
            }
        }
        protected override string 元件名称
        {
            get
            {
                return "比例方向阀";
            }
        }
        /// <summary>
        /// 选择球阀不同打开方式下的计算阀压降的方式
        /// </summary>
        /// <param name="state"></param>
        //  public void SelectMethodOfCal(CircuitState state)
        //  {
        //      Group["PABTOut"] = false;
        //      Group["PAOut"] = false;
        //      Group["PBOut"] = false;
        //      Group["ATOut"] = false;
        //      Group["BTOut"] = false;   
        //      switch(state)
        //      {
        //          case CircuitState.PABTOut:
        //              Group["PABTOut"] = true;
        //              break;
        //          case CircuitState.PAOut:
        //              Group["PAOut"] = true;
        //              break;
        //          case CircuitState.PBOut:
        //              Group["PBOut"] = true;
        //              break;
        //          case CircuitState.ATIn:
        //              Group["ATOut"] = true;
        //              break;
        //          case CircuitState.BTIn:
        //              Group["BTOut"] = true;
        //              break;
        //       }
        //      LOG.Debug("PLC阀口压降的计算方式设置为：" + state.ToString());
        //    }

        //  public void StartPressureDropAdjust()
        //  {
        //      Group["压降调节"] = true;
        //      LOG.Debug("开始压差调节");
        //  }

        //  public void StartSinAndGetMaxFlow()
        //  {
        //      Group["正弦信号启动"] = true;
        //      Group["最大流量值获取"] = true;
        //  }
        //  /// <summary>
        //  /// 调节阀13、14_1、14_2的开度
        //  /// </summary>
        //  /// <param name="position"></param>
        //  public void AdjustOfRegulatingValve(float position)
        //  {
        //      float Position = position;
        //      Group["阀13位移缓存"] = Position;
        //      Group["阀14_1位移缓存"] = Position;
        //      Group["阀14_2位移缓存"] = Position;
        //  }

        //  /// <summary>
        //  /// 等待阀压降达到目标值
        //  /// </summary>
        //  public void Wait()
        //  {
        //     while (Group["压降调节"] == true || Math.Abs(Group["调节偏差"]) > Group["给定允许误差"])
        //      {
        //          if (Group["步长除以10的次数"] >= 4f)
        //          {
        //              break;
        //          }
        //          LOG.Debug("循环");
        //          Group["压降调节"] = true;
        //          Pause(1000);
        //      }
        //      if (Group["压降调节"] == false || Math.Abs(Group["调节偏差"]) <= Group["给定允许误差"])
        //      {
        //          this.LOG.Debug(Group["调节偏差"] + "阀13位移缓存是" + Group["阀13位移缓存"] + "被试阀位移缓存" + Group["被试阀1位移缓存"]);
        //          LOG.Debug("XXX");
        //      }

        //  }
        //  /// <summary>
        //  /// PLC中阀口压降调节程序的初始化
        //  /// </summary>
        //  public void Init()
        //  {
        //      if (this.X口压力>0)
        //      {
        //          this.SetTestValveStatePilotX(true);
        //          this.SetTestValvePilotPressure(this.X口压力);
        //      }

        //      this.被试阀比例控制信号 = 50f;
        //      this.SetThrottleValve(50f);

        //      Group["给定步长"] = 1f;//用户设置步长
        //      Group["给定允许误差"] = 0.05f;
        //      Group["被试阀阀口总压降"] = 阀口总压降;
        //      Group["压降调节"] = false;
        //      Group["正弦信号启动"] = false;
        //      Group["最大流量值获取"] = false;
        //      Group["调节阀缓存值"] = 55f;

        //  }
        //  /// <summary>
        //  /// 实验结束复位
        //  /// </summary>
        //  public void Reset()
        //  {
        //      this.SetSourceFlow(0);
        //      this.SetSourcePre(0);

        //      this.被试阀比例控制信号=50f;//关闭被试阀口
        //      this.SetThrottleValve(50f);

        //      this.SetTestValveStatePilotX(false);
        //      this.SetTestValvePilotPressure(0);

        //      Group["被试阀阀口总压降"] = 0f;
        //      Group["给定步长"] = 0f;
        //      Group["给定允许误差"] = 0f;
        //      Group["压降调节"] = false;
        //      Group["正弦信号启动"] = false;
        //      Group["最大流量值获取"] = false;
        //      Group["步长除以10的次数"] = 0f;//09*04
        //      Group["调节阀缓存值"] = 55f;
        //      Group["递增步长"] = 1f;

        //      this.SetCircuitState(CircuitState.ALLOn);
        //      this.SetPaPressure(0);
        //  }
        public Propodirection_valve()
        {
            if (this.试验类型列表 == null)
            {
                this.试验类型列表 = new List<TestType>();
            }

            所做试验.Add("内部泄漏试验", false);
            所做试验.Add("恒定阀压降输出流量输入信号特性试验", false);
            所做试验.Add("节流调节特性试验", false);
            所做试验.Add("输出流量负载压差特性试验", false);
            所做试验.Add("输出流量阀压降特性试验", false);
            所做试验.Add("极限功率特性试验", false);
            string dir = System.IO.Directory.GetCurrentDirectory();

        }
        public static IList<TestType> GetSupportedTestType()
        {
            IList<TestType> list = new List<TestType>();
            list.Add(TestType.耐压试验);
            list.Add(TestType.内部泄漏试验);
            list.Add(TestType.恒定阀压降输出流量输入信号特性试验);
            list.Add(TestType.节流调节特性试验);
            list.Add(TestType.输出流量负载压差特性试验);
            list.Add(TestType.输出流量阀压降特性试验);
            list.Add(TestType.极限功率特性试验);
            return list;
        }

        //  /// <summary>
        //  /// 内泄漏试验
        //  /// </summary>
        //  protected void IntenalLeakage()
        //  {
        //      CurvePanel panel = new CurvePanel();
        //      panel.Title = TestType.内部泄漏试验.ToString();
        //      panel.XLabel = "输入信号(V)";
        //      panel.YLabel = "流量(L/min)";

        //      Curve curve = new Curve();
        //      curve.Name = "";
        //      panel.AddCurve(curve);

        //      List<float> 输入信号 = new List<float>();
        //      List<float> 流量计1的值 = new List<float>();
        //      this.Init();  
        //      Group["阀3_1左控缓存"] = true;
        //      this.SetPaPressure(16f);     
        //      this.LOG.Debug("请将球阀设置为PT2出口状态");
        //      this.SetCircuitState(CircuitState.PT2Out);
        //      this.FitSourceFlow();
        //      this.SetSourcePre(12);
        //      this.WaitPressurePUntil(5);
        //      this.SetSourceFlow(30);                             
        //      for (int i = -20; i <= 20;i++)
        //      {
        //          Group["被试阀1位移缓存"] = 50f + i * 2.5f;
        //          System.Threading.Thread.Sleep(2000);
        //          if (Group["流量计MF1流量"] >= 16f)
        //          {
        //              MessageBox.Show("泄漏量超过流量计量程，请更换流量计");
        //              throw new AutoAbortException();
        //          }
        //          curve.AddPoint((float)(i * 5f), (float)Group["流量计MF1流量"]);
        //      }        
        //      this.Reset();
        //      Group["阀3_1左控缓存"] = false;

        //      this.dictCurvePanel.Remove(panel.Title);
        //      this.dictCurvePanel.Add(panel.Title, panel);
        //  }

        //  /// <summary>
        //  /// 恒定阀压降输出流量输入信号特性试验
        //  /// </summary>
        //  protected void ConstantPressureDropFlowSignal()
        //  {
        //      CurvePanel panel = new CurvePanel();
        //      panel.Title = TestType.恒定阀压降输出流量输入信号特性试验.ToString();
        //      panel.XLabel = "控制信号";
        //      panel.YLabel = "流量(L/min)";

        //      Curve curve = new Curve();
        //      curve.Name = "";

        //      panel.AddCurve(curve);
        //      this.SetOfSelectFlowMeter((float)this.额定流量);
        //      this.Init();

        //      this.油源Pa口设定压力 = 16f;
        //      this.SelectMethodOfCal(CircuitState.PABTOut);      
        //      this.SetCircuitState(CircuitState.PABTOut);
        //      this.油源P口设定流量 =(float) this.额定流量;
        //      //this.油源P口设定流量 = this.当前流量 + 150f;
        //      this.油源P口设定压力 = (float)this.额定压力;
        //      Pause(5000);

        //      List<float> signals = new List<float>();

        //      for (float offset = 0; offset < 1f; offset = offset +0.1f)
        //          signals.Add(50f + 50 * offset);
        //      for (float offset = 1f; offset >-1f; offset = offset - 0.1f)
        //          signals.Add(50f + 50 * offset);
        //      for (float offset = -1f; offset <= 0; offset = offset + 0.1f)
        //          signals.Add(50f + 50 * offset);

        //      foreach (float signal in signals)
        //      {
        //          this.被试阀比例控制信号 = signal;
        //          Pause(2000);
        //        //  this.油源P口设定流量 = this.当前流量 + 150f;
        //          this.StartPressureDropAdjust();
        //          this.Wait();
        //          Pause(2000);//加载阀调整结束后，等待流量计响应时间读取流量值
        //          curve.AddPoint(signal * 2.0 - 100f, this.当前流量绝对值 * (signal>=50?-1:1f));
        //      }

        //      this.Reset();

        //      this.dictCurvePanel.Remove(panel.Title);
        //      this.dictCurvePanel.Add(panel.Title, panel);
        //  }

        //  /// <summary>
        //  /// 节流调节特性试验
        //  /// </summary>
        //  protected void Throttlecharact()
        //  {
        //      CurvePanel panel = new CurvePanel();
        //      panel.Title = TestType.节流调节特性试验.ToString();
        //      panel.XLabel = "输入信号(%)";
        //      panel.YLabel = "输出流量(L/min)";

        //      Curve curvePA = new Curve();
        //      Curve curveBT = new Curve();
        //      Curve curvePB = new Curve();
        //      Curve curveAT = new Curve();
        //      curvePA.Name = "PA";
        //      curveBT.Name = "BT";
        //      curvePB.Name = "PB";
        //      curveAT.Name = "AT";

        //      panel.AddCurve(curvePA);
        //      panel.AddCurve(curveBT);
        //      panel.AddCurve(curvePB);
        //      panel.AddCurve(curveAT);
        //      this.SetOfSelectFlowMeter((float)this.额定流量);
        //      this.Init();

        //      this.油源Pa口设定压力 = 16f;            
        //      this.SelectMethodOfCal(CircuitState.PAOut);
        //      this.SetCircuitState(CircuitState.PAOut);

        //      this.油源P口设定压力 = (float)this.额定压力;
        //      this.油源P口设定流量 = this.当前流量绝对值 + 70f;
        //      //this.WaitPressure();  
        //      Pause(2000);                          
        //      this.LOG.Debug("PA实验开始");
        //      this.LOG.Debug("被试阀由中位至正向最大");
        //      this.LOG.Debug(Group["递增步长"]);

        //      for (int i = 0; i <= 20; i++)
        //      {
        //          Group["被试阀1位移缓存"] = 50f + i * 2.5f;
        //          this.FitSourceFlow();
        //          //this.StartAdjust();
        //          this.LOG.Debug("压降调节");
        //          this.LOG.Debug(Group["递增步长"]);
        //          Group["压降调节"] = true;
        //          Pause(1000);
        //          this.LOG.Debug("StartAdjust()" + i);
        //          this.Wait();
        //          Pause(2000);
        //          curvePA.AddPoint(i * 5,this.当前流量绝对值);
        //      }

        //      this.LOG.Debug("PA实验结束");            
        //      this.SetSourcePre(0);
        //      this.SetSourceFlow(0);          
        //      System.Threading.Thread.Sleep(1000);//等待流量压力稳定
        //      this.Init();
        //      this.SelectMethodOfCal(CircuitState.PBOut); 
        //      this.LOG.Debug("将球阀设置为PB出口状态");
        //      this.SetCircuitState(CircuitState.PBOut);             
        //     // this.FitSourceFlow();
        //      this.SetSourceFlow((float)this.额定流量);
        //      this.SetSourcePre((float)this.额定压力);
        //      //this.WaitPressurePUntil(5);           
        //      this.LOG.Debug("PB实验开始");
        //      this.LOG.Debug("被试阀由中位至负向最大");

        //      for (int i = 0; i <= 20; i++)
        //      {
        //          Group["被试阀1位移缓存"] = 50f - i * 2.5f;
        //          this.FitSourceFlow();
        //          //this.StartAdjust();
        //          Group["压降调节"] = true;
        //          this.LOG.Debug("压降调节 " + Group["压降调节"]);
        //          Pause(1000);
        //          this.LOG.Debug("1s后压降调节 " + Group["压降调节"]);
        //          this.LOG.Debug("StartAdjust()" + i);
        //          this.Wait();
        //          Pause(2000);
        //          curvePB.AddPoint(-i * 5, -this.当前流量绝对值);
        //      }


        //      this.LOG.Debug("PB实验结束");
        //      this.SetSourcePre(0);
        //      this.SetSourceFlow(0);
        //      System.Threading.Thread.Sleep(1000);//等待流量压力稳定
        //      this.Init();
        //      this.SelectMethodOfCal(CircuitState.ATIn);
        //      this.LOG.Debug("将球阀设置为AT进口状态");
        //      this.SetCircuitState(CircuitState.ATIn);
        //      System.Threading.Thread.Sleep(1000);//等待流量稳定 
        //      this.FitSourceFlow();
        //      this.SetSourcePre((float)this.额定压力);
        //    //  this.WaitPressurePUntil(5);
        //      this.LOG.Debug("AT实验开始");
        //      this.LOG.Debug("被试阀由中位至负向最大");

        //      for (int i = 0; i <= 20; i++)
        //      {
        //          Group["被试阀1位移缓存"] = 50f - i * 2.5f;
        //          this.FitSourceFlow();
        //          Group["压降调节"] = true;
        //          //this.StartAdjust();
        //          this.LOG.Debug("压降调节 " + Group["压降调节"]);
        //          Pause(1000);
        //          this.LOG.Debug("1s后压降调节 " + Group["压降调节"]);
        //          this.LOG.Debug("StartAdjust()" + i);
        //          this.Wait();
        //          Pause(2000);
        //          curveAT.AddPoint(-i * 5, this.当前流量绝对值);
        //      }

        //      this.LOG.Debug("AT实验结束");
        //      this.SetSourcePre(0);
        //      this.SetSourceFlow(0);
        //      System.Threading.Thread.Sleep(1000);//等待流量压力稳定
        //      this.Init();
        //      this.SelectMethodOfCal(CircuitState.BTIn);
        //      this.LOG.Debug("请将球阀设置为BT进口状态");
        //      this.SetCircuitState(CircuitState.BTIn);
        //      System.Threading.Thread.Sleep(1000);//等待流量稳定  
        //      this.FitSourceFlow();
        //      this.SetSourcePre((float)this.额定压力);
        //    //  this.WaitPressurePUntil(5);        
        //      this.LOG.Debug("BT实验开始");
        //      this.LOG.Debug("被试阀由中位至正向最大");
        //      for (int i = 0; i <= 20; i++)
        //      {
        //          Group["被试阀1位移缓存"] = 50f + i * 2.5f;
        //          this.FitSourceFlow();
        //          Group["压降调节"] = true;
        //          //this.StartAdjust();
        //          this.LOG.Debug("StartAdjust()" + i);
        //         // this.Wait();
        //         Pause(1000);
        //         this.Wait();
        //          Pause(2000);
        //          curveBT.AddPoint(i * 5, -this.当前流量绝对值);
        //      }

        //      this.LOG.Debug("BT实验结束");
        //      this.Reset();
        //      this.dictCurvePanel.Remove(panel.Title);
        //      this.dictCurvePanel.Add(panel.Title, panel);
        //  }

        //  /// <summary>
        //  /// 输出流量负载压差特性试验
        //  /// </summary>
        //  protected void OutputFlowLoadPresureDif()
        //  {
        //      CurvePanel panel = new CurvePanel();
        ////      panel.Title = TestType.恒定阀压降输出流量输入信号特性试验.ToString();
        //      panel.Title = TestType.输出流量负载压差特性试验.ToString();
        //      panel.XLabel = "负载压差（MPa）";
        //      panel.YLabel = "流量(L/min)";
        //      this.SetOfSelectFlowMeter((float)this.额定流量);
        //      this.Init();
        //      this.油源Pa口设定压力 = 16f;
        //      this.SetCircuitState(CircuitState.PABTOut);
        //      this.FitSourceFlow();
        //      this.SetSourcePre((float)this.额定压力);
        //      //this.WaitPressurePUntil(5);
        //      for (int j = 0; j <= 8; j++)
        //      {
        //          Curve curve = new Curve();
        //          curve.Name = j.ToString();
        //          panel.AddCurve(curve);

        //          this.被试阀比例控制信号 = 50f + 50 * (4 - j) * 0.25f;
        //          if (j == 4)
        //              continue;
        //          else
        //          {
        //              this.FitSourceFlow();
        //              for (int i = 20; i >= 0; i--)
        //              {
        //                  this.节流阀控制信号 = (float)(55 + i * 0.5f);
        //                  Pause(2000);
        //                  curve.AddPoint(this.当前A口压力 - this.当前B口压力, this.当前流量绝对值);
        //              }
        //              this.LOG.Debug(j);
        //          }
        //      }

        //      this.Reset();
        //      this.dictCurvePanel.Remove(panel.Title);
        //      this.dictCurvePanel.Add(panel.Title, panel);           
        //  }

        //  /// <summary>
        //  /// 输出流量阀压降特性试验
        //  /// </summary>
        //  protected void OutputFlowValvePreeesureDif()
        //  {
        //      CurvePanel panel = new CurvePanel();
        //      panel.Title = TestType.输出流量阀压降特性试验.ToString();
        //      panel.XLabel = "阀压降(MPa)";
        //      panel.YLabel = "输出流量(L/min)";
        //      this.SetOfSelectFlowMeter((float)this.额定流量);
        //      this.Init();
        //      this.SetPaPressure(16f);
        //      this.LOG.Debug("请将球阀设置为PABT出口状态");
        //      this.SetCircuitState(CircuitState.PABTOut);
        //      this.FitSourceFlow();
        //      this.SetSourcePre((float)this.额定压力);
        //      this.WaitPressurePUntil(5);
        //      for (int j = 0; j <= 8; j++)
        //      {
        //          Curve curve = new Curve();
        //          curve.Name = j.ToString();
        //          curve.Name = (50 * (4 - j) * 0.25*2).ToString();
        //          panel.AddCurve(curve);

        //          this.被试阀比例控制信号 = 50f + 50 * (4 - j) * 0.25f;
        //          if (j == 4)
        //              continue;
        //          else
        //          {                   
        //              for (int i = 20; i >= 0; i--)
        //              {
        //                  this.FitSourceFlow();
        //                  float pos = (float)(55 + i * 0.5f);
        //                  this.AdjustOfRegulatingValve(pos);
        //                  Pause(2000);
        //                  curve.AddPoint(this.当前P口压力 - this.当前T口压力 - Math.Abs(this.当前A口压力 - this.当前B口压力), this.当前流量);
        //              }
        //          }
        //      }
        //      this.Reset();
        //      this.dictCurvePanel.Remove(panel.Title);
        //      this.dictCurvePanel.Add(panel.Title, panel);  
        //  }
        //  /// <summary>
        //  /// 极限功率特性试验
        //  /// </summary>
        //  protected void ExtremePower()
        //  {
        //      CurvePanel panel = new CurvePanel();
        //      panel.Title = TestType.极限功率特性试验.ToString();
        //      panel.XLabel = "阀压降(MPa)";
        //      panel.YLabel = "输出流量(L/min)";
        //      Curve curve = new Curve();
        //      panel.AddCurve(curve);

        //      this.Init();
        //      this.SetPaPressure(16f);
        //      this.LOG.Debug("请将球阀设置为PABT出口状态");
        //      this.SetCircuitState(CircuitState.PABTOut);
        //      this.SelectMethodOfCal(CircuitState.PABTOut);
        //      this.FitSourceFlow();
        //      this.AdjustOfRegulatingValve(100f);
        //      for(int i = 1; ; i++)
        //      {
        //          float pressure = 0.5f * i;
        //          if (pressure <= this.额定压力)
        //          {
        //              this.SetSourcePre(pressure);
        //              this.WaitPressurePUntil(pressure);
        //              this.StartSinAndGetMaxFlow();
        //              Group["给定被试位移缓存"] = 95f;
        //              Group["流量的最大值"] = 0f;
        //              Pause(5000);

        //              curve.AddPoint(Group["采集的阀压降"], Group["流量的最大值"]);
        //          }
        //          else
        //              break;
        //      }
        //      this.Reset();
        //      this.dictCurvePanel.Remove(panel.Title);
        //      this.dictCurvePanel.Add(panel.Title, panel);
        //  }

        //  protected override void RunTest(TestType testType)
        //  {
        //      实验类型.Add(testType);
        //      switch (testType)
        //      {
        //          case TestType.耐压试验:
        //              this.EndurationTest();
        //              break;
        //          case TestType.恒定阀压降输出流量输入信号特性试验:
        //              this.ConstantPressureDropFlowSignal();
        //              break;
        //          case TestType.节流调节特性试验:
        //              this.Throttlecharact();
        //              break;
        //          case TestType.输出流量负载压差特性试验:
        //              this.OutputFlowLoadPresureDif();
        //              break;
        //          case TestType.输出流量阀压降特性试验:
        //              this.OutputFlowValvePreeesureDif();
        //              break;
        //          case TestType.内部泄漏试验:
        //              this.IntenalLeakage();
        //              break;
        //          case TestType.极限功率特性试验:
        //              this.ExtremePower();
        //              break;
        //          default:
        //              throw new TestTypeNotSupportedException();
        //      }
        //  }
        //  public override void GenerateReport()
        //  {
        //      WordHelper helper = this.SetReportBasicInfo(true);
        //      Dictionary<string, string> Dict = new Dictionary<string, string>();

        //      string 图片路径;

        //      foreach (TestType tt in 实验类型)
        //      {
        //          if (tt == TestType.耐压试验)
        //          {
        //              Dict.Add("$P$", this.P口耐压.ToString() + "MPa");
        //              Dict.Add("$T$", this.T口耐压.ToString() + "MPa");
        //              Dict.Add("$A$", this.A口耐压.ToString() + "MPa");
        //              Dict.Add("$B$", this.B口耐压.ToString() + "MPa");
        //              helper.InserttextValue(Dict);//写入文本
        //          }
        //          if (tt == TestType.恒定阀压降输出流量输入信号特性试验)
        //          {
        //              图片路径 = 路径 + "\\report\\比例方向阀恒定阀压降输出流量输入信号特性试验曲线.bmp";
        //              string key = TestType.恒定阀压降输出流量输入信号特性试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict.Add("$恒定阀压降输出流量输入信号特性曲线$", 图片路径);
        //          }
        //          else if (tt == TestType.节流调节特性试验)
        //          {
        //              图片路径 = 路径 + "\\report\\比例方向阀节流调节特性试验曲线.bmp";
        //              string key = TestType.节流调节特性试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict.Add("$节流调节特性试验曲线$", 图片路径);
        //          }
        //          else if (tt == TestType.输出流量负载压差特性试验)
        //          {
        //              图片路径 = 路径 + "\\report\\比例方向阀输出流量负载压差特性试验曲线.bmp";
        //              string key = TestType.输出流量负载压差特性试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict.Add("$输出流量负载压差特性试验曲线$", 图片路径);                    
        //          }
        //          else if (tt == TestType.输出流量阀压降特性试验)
        //          {
        //              图片路径 = 路径 + "\\report\\比例方向阀输出流量阀压降特性试验曲线.bmp";
        //              string key = TestType.输出流量阀压降特性试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict.Add("$输出流量阀压降特性试验曲线$", 图片路径);
        //          }
        //          else if (tt == TestType.内部泄漏试验)
        //          {
        //              图片路径 = 路径 + "\\report\\内部泄漏试验曲线.bmp";
        //              string key = TestType.内部泄漏试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict.Add("$内部泄漏试验曲线$", 图片路径);                    
        //          }
        //          else if (tt == TestType.极限功率特性试验)
        //          {
        //              图片路径 = 路径 + "\\report\\极限功率特性试验曲线.bmp";
        //              string key = TestType.极限功率特性试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict.Add("$极限功率特性试验曲线$", 图片路径);
        //          }
        //      }

        //      helper.Insertpicture(Pict);//写入图片
        //      helper.SaveDocument(保存路径);
        //      MessageBox.Show("报告已生成");
        //  }

        //  public override void SaveReportToDB()
        //  {
        //      Dictionary<string, string> Pict2 = new Dictionary<string, string>();
        //      WordHelper helper = this.SetReportBasicInfo(false);
        //      Dictionary<string, string> Dict = new Dictionary<string, string>();

        //      string currentTime = DateTime.Today.ToString("yyyy-MM-dd");
        //      string 图片路径;
        //      string 临时文件 = 路径 + "\\report\\cache\\比例方向阀\\比例方向阀试验报告" + currentTime + ".doc";

        //      foreach (TestType tt in 实验类型)
        //      {
        //          if (tt == TestType.耐压试验)
        //          {
        //              Dict.Add("$P$", this.P口耐压.ToString() + "MPa");
        //              Dict.Add("$T$", this.T口耐压.ToString() + "MPa");
        //              Dict.Add("$A$", this.A口耐压.ToString() + "MPa");
        //              Dict.Add("$B$", this.B口耐压.ToString() + "MPa");

        //          }
        //          if (tt == TestType.恒定阀压降输出流量输入信号特性试验)
        //          {
        //              图片路径 = 路径 + "\\report\\cache\\比例方向阀恒定阀压降输出流量输入信号特性试验曲线.bmp";
        //              string key = TestType.恒定阀压降输出流量输入信号特性试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict2.Add("$恒定阀压降输出流量输入信号特性曲线$", 图片路径);
        //          }
        //          else if (tt == TestType.节流调节特性试验)
        //          {
        //              图片路径 = 路径 + "\\report\\cache\\比例方向阀节流调节特性试验曲线.bmp";
        //              string key = TestType.节流调节特性试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict2.Add("$节流调节特性试验曲线$", 图片路径);
        //          }
        //          else if (tt == TestType.输出流量负载压差特性试验)
        //          {
        //              图片路径 = 路径 + "\\report\\cache\\比例方向阀输出流量负载压差特性试验曲线.bmp";
        //              string key = TestType.输出流量负载压差特性试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict2.Add("$输出流量负载压差特性试验曲线$", 图片路径);
        //          }
        //          else if (tt == TestType.输出流量阀压降特性试验)
        //          {
        //              图片路径 = 路径 + "\\report\\cache\\比例方向阀输出流量阀压降特性试验曲线.bmp";
        //              string key = TestType.输出流量阀压降特性试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict2.Add("$输出流量阀压降特性试验曲线$", 图片路径);
        //          }
        //          else if (tt == TestType.内部泄漏试验)
        //          {
        //              图片路径 = 路径 + "\\report\\cache\\内部泄漏试验曲线.bmp";
        //              string key = TestType.内部泄漏试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict2.Add("$内部泄漏试验曲线$", 图片路径);
        //          }
        //          else if (tt == TestType.极限功率特性试验)
        //          {
        //              图片路径 = 路径 + "\\report\\cache\\极限功率特性试验曲线.bmp";
        //              string key = TestType.极限功率特性试验.ToString();

        //              this.dictCurvePanel[key].SaveBMP(图片路径);
        //              Pict2.Add("$极限功率特性试验曲线$", 图片路径);
        //          }
        //      }

        //      helper.InserttextValue(Dict);//写入文本
        //      helper.Insertpicture(Pict2);//写入图片
        //      LOG.Debug("写入图片");
        //      helper.SaveDocument(临时文件);
        //      LOG.Debug(临时文件);

        //      //保存试验报告到本地，调取本地试验报告为二进制格式保存到数据库
        //      FileStream getBinWord = new FileStream(临时文件, FileMode.Open);
        //      this.testReport = new byte[getBinWord.Length];
        //      getBinWord.Read(testReport, 0, (int)getBinWord.Length);
        //      getBinWord.Close();
        //      LOG.Debug("报告已保存到数据库");
        //  }
    }
}
