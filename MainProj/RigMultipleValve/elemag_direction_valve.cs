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
    /// 电磁换向阀
    /// </summary>
    public class elemag_direction_valve:direction_valve
    {
        Dictionary<string, string> Pict = new Dictionary<string, string>();
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dictionary<string, List<double[]>> tableDict = new Dictionary<string, List<double[]>>();//1026
        Dictionary<string, string> table = new Dictionary<string, string>();//1022             
        
        string 图片路径;
             
        public List<TestType> 实验类型 = new List<TestType>();
        string dir = System.IO.Directory.GetCurrentDirectory();
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(elemag_direction_valve));

        protected override string 模板路径
        {
            get
            {
                return this.路径 + "\\template\\电磁换向阀模板.docx";
            }
        }

        protected override string 保存路径
        {
            get
            {
                return this.路径 + "\\report\\电磁换向阀\\电磁换向阀试验报告.doc";
            }
        }

        protected override string 元件名称
        {
            get
            {
                return "电磁换向阀";
            }
        }
        
        public elemag_direction_valve()
        {
            if (this.试验类型列表 == null)
            {
                this.试验类型列表 = new List<TestType>();
            }
        }            

        /// <summary>
        /// 内部泄漏试验
        /// 本试验是为了测定方向阀处某一工作状态时，具有一定压力差又互不相通的阀口之间的油液世漏量
        /// 建立加压压力和泄漏量的关系，输出内泄漏曲线，横坐标为加压压力，纵坐标为泄漏量
        /// </summary>
        protected override void IntenalLeakage()
        {
            CurvePanel panelLeakage = new CurvePanel();
            Dictionary<string,Curve> dictCurve = new Dictionary<string,Curve>();
            float retvol = 0;
            float testret=0;
            int time=0;
            panelLeakage.Title = TestType.内部泄漏试验.ToString()+"曲线";
            panelLeakage.XLabel = "压力(MPa)";
            panelLeakage.YLabel = "泄漏量(ml/min)";
            this.SetCircuitState(CircuitState.PTOut);
            for (int i = 0; i < 10; i++)
            {
                this.SetTestValveState(TestValveState.右位);
                Pause(1000);
                this.SetTestValveState(TestValveState.左位);
                Pause(1000);
            }
            this.SetTestValveState(TestValveState.中位);
            this.SetSourceFlow(0);
            this.SetSourcePre(0);
            Pause(1000);         
            this.SetCircuitState(CircuitState.P);
            bool needtest = true;
            Curve curve;
            string oil_loc;
            //获取参数
            while (needtest)
            {
                FormSetleak frmConfig = new FormSetleak();
                needtest=frmConfig.ShowDialog()==DialogResult.OK;
                if (!needtest)
                    break;

                //获取接油口位置
                oil_loc = frmConfig.location;
                string key = frmConfig.elestate.ToString() + frmConfig.location;
                if (!dictCurve.Keys.Contains(key))
                {
                    curve = new Curve();
                    curve.Name = key + "口";
                    dictCurve.Add(key, curve);
                }
                else
                {
                    curve = dictCurve[key];
                }

                //设置压力流量          
                this.SetSourcePre(frmConfig.试验压力);
                this.SetSourceFlow(20);
                this.WaitPressurePUntil(frmConfig.试验压力);
                this.SetTestValveState(frmConfig.elestate);
                System.Threading.Thread.Sleep(1000);

                //保压延时并获取结果
                FormLeakageReturn frm = new FormLeakageReturn(frmConfig.Timecount,this);
                frm.ShowDialog();
                time = frmConfig.Timecount;
                testret = frm.retvol;
                retvol = (frm.retvol/frmConfig.Timecount)*60f;//获取泄漏量的值

                curve.AddPoint(frmConfig.试验压力, retvol);
                this.SetTestValveState(TestValveState.中位);
                
               
            }
            
            foreach(string key in dictCurve.Keys)
            {
                panelLeakage.AddCurve(dictCurve[key]);
            }
            this.dictCurvePanel.Remove(panelLeakage.Title);
            this.dictCurvePanel.Add(panelLeakage.Title, panelLeakage);
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.SetCircuitState(CircuitState.ALLOn);
            this.log.Debug("内部泄漏实验完成");

        }
        

        /// <summary>
        /// 稳态压差流量特性试验
        /// 建立被试阀阀口压差和通过被试阀流量的关系，输出压差和流量的关系曲线图
        /// </summary>
        protected override void SteadystatePreeesure()
        {
            this.SteadystatePreeesureSingleSide(TestValveState.左位);
            while(this.当前流量绝对值>2f)
            {
                Pause(1000);
            }
            this.SteadystatePreeesureSingleSide(TestValveState.右位);
            this.SetCircuitState(CircuitState.ALLOn);
            log.Debug("稳态压差试验已完成");
        }

        /// <summary>
        /// 稳态压差流量特性试验   单边子程序
        /// </summary>
        /// <param name="state"></param>
        private void SteadystatePreeesureSingleSide(TestValveState state) {
            if (state == TestValveState.中位)
                return;

            CurvePanel panel = new CurvePanel();
            panel.Title = TestType.稳态压差流量特性试验.ToString()+"(电磁铁" + state .ToString()+ ")";
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


            this.SetCircuitState(CircuitState.PABTOut);
            this.SetThrottleValve(100f);
            this.SetTestValveState(state);
            this.SetSourcePre(this.额定压力);
            float max_flow = (float)(this.额定流量);
            this.SetSourceFlow(0);
            Pause(3000);

            const int div_cnt = 20;
            const int measure_cnt = 10;

            float pressure_A = 0;
            float pressure_B = 0;
            float pressure_P = 0;
            float pressure_T = 0;
            float delta_q = (float)(max_flow / div_cnt);

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
                    flow += Math.Abs(this.当前流量绝对值 / measure_cnt);
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

        //private void WorkScopeSingleSide(TestValveState state)
        //{
        //    CurvePanel panel = new CurvePanel();
        //    panel.Title = TestType.工作范围试验.ToString() + "(电磁铁" + state.ToString() + ")";
        //    panel.XLabel = "流量(L/min)";
        //    panel.YLabel = "P口压力(MPa)";
        //    Curve curveOD = new Curve();
        //    Curve curveABC = new Curve();
        //    panel.AddCurve(curveOD);
        //    panel.AddCurve(curveABC);
        //    curveOD.Name = "OD";
        //    curveABC.Name = "ABC";
        //    this.SetCircuitState(CircuitState.PABTOut);
        //    this.SetThrottleValve(100f);
        //    Pause(1000);
        //    this.SetSourcePre(this.额定压力);
        //    SetTestValveState_22V(state);
        //    Pause(2000);

        //    const int div_cnt = 20;
        //    float delta_q = (float)(this.额定流量) / div_cnt;

        //    // 左位试验开始
        //    // 第一步：画OD曲线
        //    this.log.Debug("开始画左位OD曲线");
        //    for (int i = 0; i <= div_cnt; i++)
        //    {
        //        this.SetSourceFlow(i * delta_q);
        //        Pause(3000);
        //        curveOD.AddPoint(this.当前流量绝对值, this.当前P口压力);
        //        this.log.Debug("横坐标流量：" + 当前流量绝对值 + "--" + "纵坐标压力" + 当前P口压力);
        //    }
        //    this.log.Debug("左位OD曲线已完成绘制");
        //    this.SetSourceFlow((float)(this.额定流量));
        //    Pause(3000);
        //    float delta_p = (float)((this.额定压力- curveOD.Y.Max()) / 20);
            
        //    this.log.Debug("开始ABC曲线试验");
        //    for (int j = 0; j <= 5; j++)  //加载阀缓慢关闭：5S
        //    {
        //        this.SetThrottleValve(100 - j * 10f);
        //        Pause(1000);
        //    }
        //    // 第二步:画ABC
        //    this.log.Debug("开始左中位切换");
        //    this.SetThrottleValve(57f);//调节阀从57开始，目的是避过调节阀自身的死区
        //    for (int k = 0; k <= 20; k++)
        //    {
        //        this.SetSourcePre((float)((float)(this.额定压力) - k * delta_p));
        //        this.WaitPressurePUntil((float)((float)(this.额定压力) - k * delta_p));
        //        SetTestValveState_22V(TestValveState.中位);//将被试阀调至中位          
        //        Pause(1000);
        //        SetTestValveState_22V(state);//每次改变压力就要重新回中再切回左位/右位，确保开始的点是正常的工作点。
        //        Pause(1000);
        //        if (k == 0)
        //        {
        //            curveABC.AddPoint(0f, this.当前P口压力);
        //            this.log.Debug("纵坐标压力" + 当前P口压力);//调试时用
        //        }///找A点    
        //        WorkScopeStart(state);              
        //        this.log.Debug("工作范围判定启动" + Group["工作范围判定启动"] + "--" + "左中切换" + Group["左中切换"] + "右中切换" + Group["右中切换"]);
        //        Pause(1000);
        //        this.log.Debug("工作范围判定启动" + Group["工作范围判定启动"] + "--" + "左中切换" + Group["左中切换"] + "右中切换" + Group["右中切换"]);
        //        WaitWorkScope();
        //        curveABC.AddPoint((float)Group["上次流量最大值"], this.当前P口压力);
        //        this.log.Debug("横坐标流量：" + ((float)Group["上次流量最大值"]) + "--" + "纵坐标压力" + Group["P口压力"] + "13开度" + Group["阀13位移缓存"]);

        //    }
           
        //    this.SetSourcePre(0);
        //    this.SetSourceFlow(0);
        //    SetTestValveState_22V(TestValveState.中位);
        //    this.SetThrottleValve(50f);
        //    this.dictCurvePanel.Remove(panel.Title);
        //    this.dictCurvePanel.Add(panel.Title, panel);
        //}

        ///// <summary>
        ///// 工作范围试验(GB8106-87)
        ///// 本试验是为了测定换向阀能正常换向的压力和流量的边界值范围
        ///// 
        /////     A                B
        ///// (P) ------------------\
        /////    |                    \             
        /////    |                      \C
        /////    |                       |
        /////    |                       |D
        /////    |                      /
        /////   O|____________________/(q)
        /////     
        ///// </summary>
        //protected override void WorkScope()
        //{
        //    WorkScopeSingleSide(TestValveState.左位);
        //    WorkScopeSingleSide(TestValveState.右位);
        //    log.Debug("工作范围试验已完成");
        //}

        //public override void SortTestList()
        //{
                    
        //}
       
        ///// <summary>
        ///// 生成试验报告
        ///// </summary>
        //public override void GenerateReport()
        //{
        //    WordHelper helper = this.SetReportBasicInfo(true);

        //    string currentTime = DateTime.Today.ToString("yyyy-MM-dd");
        //    Dictionary<string, string> Dict = new Dictionary<string, string>();
        //    foreach (TestType tt in 实验类型)
        //    {
        //        if (tt == TestType.耐压试验)
        //        {
        //            Dict.Add("$P$", this.P口耐压.ToString() + "Mpa");
        //            Dict.Add("$T$", this.T口耐压.ToString() + "Mpa");
        //            Dict.Add("$A$", this.A口耐压.ToString() + "Mpa");
        //            Dict.Add("$B$", this.B口耐压.ToString() + "Mpa");
        //            helper.InserttextValue(Dict);//写入文本
        //        }
        //        if (tt == TestType.稳态压差流量特性试验)
        //        {
        //            string 图片路径1 = 路径 + "\\report\\电磁换向阀\\电磁换向阀稳态压差流量特性试验曲线(左位)"+"--"+ currentTime +".bmp";
        //            string 图片路径2 = 路径 + "\\report\\电磁换向阀\\电磁换向阀稳态压差流量特性试验曲线(右位)" + "--" + currentTime + ".bmp";
        //            string key1=TestType.稳态压差流量特性试验.ToString()+"(电磁铁左位)";
        //            string key2=TestType.稳态压差流量特性试验.ToString()+"(电磁铁右位)";
        //            Pict.Add("$稳态压差流量特性曲线1$", 图片路径1);
        //            Pict.Add("$稳态压差流量特性曲线2$", 图片路径2);
        //            this.dictCurvePanel[key1].SaveBMP(图片路径1);
        //            this.dictCurvePanel[key2].SaveBMP(图片路径2);
        //        }

        //        else if (tt == TestType.内部泄漏试验)
        //        {        
        //             图片路径 = 路径 + "\\report\\电磁换向阀\\电磁换向阀内部泄漏试验曲线"+"--"+ currentTime + ".bmp";
        //             Pict.Add("$内部泄漏试验曲线$", 图片路径);
        //             string key = TestType.内部泄漏试验.ToString() + "曲线";
        //             this.dictCurvePanel[key].SaveBMP(图片路径);         
                    
        //        }
        //        else if (tt == TestType.工作范围试验)
        //        {
        //            string 图片路径1,图片路径2;
        //            图片路径1 = 路径 + "\\report\\电磁换向阀\\电磁换向阀工作范围试验左位曲线" + "--" + currentTime + ".bmp";
        //            图片路径2 = 路径 + "\\report\\电磁换向阀\\电磁换向阀工作范围试验右位曲线" + "--" + currentTime + ".bmp";
        //            Pict.Add("$工作范围试验左位$", 图片路径1);
        //            Pict.Add("$工作范围试验右位$", 图片路径2);
        //            string key1 = TestType.工作范围试验.ToString() + "(电磁铁左位)";
        //            string key2 = TestType.工作范围试验.ToString() + "(电磁铁右位)";
        //            this.dictCurvePanel[key1].SaveBMP(图片路径1);
        //            this.dictCurvePanel[key2].SaveBMP(图片路径2);
        //        }
               
        //    }
        //    helper.Insertpicture(Pict);//写入图片
        //    helper.SaveDocument(保存路径);
        //    MessageBox.Show("报告已生成");

        //}

        //public override void SaveReportToDB()
        //{
        //    WordHelper helper = this.SetReportBasicInfo(false);

        //    Dictionary<string, string> Pict2 = new Dictionary<string, string>();
        //    string currentTime = DateTime.Today.ToString("yyyy-MM-dd");
        //    Dictionary<string, string> Dict = new Dictionary<string, string>();
        //    foreach (TestType tt in 实验类型)
        //    {
        //        if (tt == TestType.耐压试验)
        //        {
        //            Dict.Add("$P$", this.P口耐压.ToString() + "Mpa");
        //            Dict.Add("$T$", this.T口耐压.ToString() + "Mpa");
        //            Dict.Add("$A$", this.A口耐压.ToString() + "Mpa");
        //            Dict.Add("$B$", this.B口耐压.ToString() + "Mpa");
        //            helper.InserttextValue(Dict);//写入文本
        //        }
        //        if (tt == TestType.稳态压差流量特性试验)
        //        {
        //            string 图片路径1 = 路径 + "\\report\\电磁换向阀\\电磁换向阀稳态压差流量特性试验曲线(左位)" + "--" + currentTime + ".bmp";
        //            string 图片路径2 = 路径 + "\\report\\电磁换向阀\\电磁换向阀稳态压差流量特性试验曲线(右位)" + "--" + currentTime + ".bmp";
        //            string key1 = TestType.稳态压差流量特性试验.ToString() + "(电磁铁左位)";
        //            string key2 = TestType.稳态压差流量特性试验.ToString() + "(电磁铁右位)";
        //            Pict2.Add("$稳态压差流量特性曲线1$", 图片路径1);
        //            Pict2.Add("$稳态压差流量特性曲线2$", 图片路径2);
        //            this.dictCurvePanel[key1].SaveBMP(图片路径1);
        //            this.dictCurvePanel[key2].SaveBMP(图片路径2);
        //        }

        //        else if (tt == TestType.内部泄漏试验)
        //        {
        //            图片路径 = 路径 + "\\report\\电磁换向阀\\电磁换向阀内部泄漏试验曲线" + "--" + currentTime + ".bmp";
        //            Pict2.Add("$内部泄漏试验曲线$", 图片路径);
        //            string key = TestType.内部泄漏试验.ToString() + "曲线";
        //            this.dictCurvePanel[key].SaveBMP(图片路径);

        //        }
        //        else if (tt == TestType.工作范围试验)
        //        {
        //            string 图片路径1, 图片路径2;
        //            图片路径1 = 路径 + "\\report\\电磁换向阀\\电磁换向阀工作范围试验左位曲线" + "--" + currentTime + ".bmp";
        //            图片路径2 = 路径 + "\\report\\电磁换向阀\\电磁换向阀工作范围试验右位曲线" + "--" + currentTime + ".bmp";
        //            Pict2.Add("$工作范围试验左位$", 图片路径1);
        //            Pict2.Add("$工作范围试验右位$", 图片路径2);
        //            string key1 = TestType.工作范围试验.ToString() + "(电磁铁左位)";
        //            string key2 = TestType.工作范围试验.ToString() + "(电磁铁右位)";
        //            this.dictCurvePanel[key1].SaveBMP(图片路径1);
        //            this.dictCurvePanel[key2].SaveBMP(图片路径2);
        //        }

        //    }
        //    helper.Insertpicture(Pict2);//写入图片
        //    //保存试验报告到本地，调取本地试验报告为二进制格式保存到数据库
        //    helper.SaveDocument(保存路径);
        //    FileStream getBinWord = new FileStream(保存路径, FileMode.Open);
        //    this.testReport = new byte[getBinWord.Length];
        //    getBinWord.Read(testReport, 0, (int)getBinWord.Length);
        //    getBinWord.Close();
        //    File.Delete(保存路径);
        //    foreach (KeyValuePair<string,string> u in Pict2)
        //    {
        //        File.Delete(u.Value);
        //    }
        //    MessageBox.Show("报告已生成");
        //}
        //protected override void RunTest(TestType testType)
        //{
        //    实验类型.Add(testType);
        //    switch (testType)
        //    {
        //        case TestType.耐压试验:
        //            this.EndurationTest();
        //            break;
        //        case TestType.内部泄漏试验:
        //            this.IntenalLeakage();
        //            break;
        //        case TestType.稳态压差流量特性试验:
        //            this.SteadystatePreeesure();
        //            break;
        //        case TestType.工作范围试验:
        //            this.WorkScope();
        //            break;
        //        default:
        //            throw new TestTypeNotSupportedException();
        //    }
        //}

        //protected override void SetTestValveState(TestValveState state)
        //{
        //    this.SetTestValveState_24V(state);
        //}
        //private void WorkScopeStart(TestValveState state)
        //{
        //    Group["给定步长"] = 1f;
        //    switch(state)
        //    {
        //        case TestValveState.左位:
        //            Group["工作范围判定启动"] = true;
        //            Group["左中切换"] = true;
        //            Group["右中切换"] = false;
        //            break;
        //        case TestValveState.右位:
        //            Group["工作范围判定启动"] = true;
        //            Group["左中切换"] = false;
        //            Group["右中切换"] = true;
        //            break;
        //        case TestValveState.中位:
        //            Group["工作范围判定启动"] = false;
        //            Group["左中切换"] = false;
        //            Group["右中切换"] = false;
        //            break;

        //    }
               
        //}
        //private void WaitWorkScope()
        //{
        //    while (Group["工作范围判定启动"] == true)
        //    {
        //        System.Threading.Thread.Sleep(1000);
        //    }
        //}
    }

}
