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
    public class hydcheck_valve : Valve
    {
        private List<TestType> TestTypeName = new List<TestType>();
        Dictionary<string, string> Pict = new Dictionary<string, string>();
        Dictionary<string, string> table = new Dictionary<string, string>();
        public hydcheck_valve()
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
            list.Add(TestType.稳态压差流量特性试验);
            list.Add(TestType.液控单向阀最小控制压力);
            list.Add(TestType.液控单向阀泄漏量试验);
            return list;
        }
        protected override string 模板路径
        {
            get
            {
                return this.路径 + "\\template\\液控单向阀模板.docx";
            }
        }

        protected override string 保存路径
        {
            get
            {
                return this.路径 + "\\report\\液控单向阀\\液控单向阀试验报告.doc";
            }
        }

        protected override string 元件名称
        {
            get
            {
                return "液控单向阀";
            }
        }
        /// <summary>
        /// 等待油口B的压力上升到设定压力的50%
        /// </summary>
        /// <param name="pressure"></param>
        //public void WaitPressureBUntil(float pressure)
        //{
        //    while (Group["B口压力"] <= 0.5 * pressure)
        //    {
        //        System.Threading.Thread.Sleep(1000);
        //    }
        //    System.Threading.Thread.Sleep(2000);
        //}
        ///// <summary>
        ///// 等待油口A的压力上升到设定压力的50%
        ///// </summary>
        ///// <param name="pressure"></param>
        //public void WaitPressureSUntil(float pressure)
        //{
        //    while (Group["A口压力"] <= 0.5 * pressure)
        //    {
        //        System.Threading.Thread.Sleep(1000);
        //    }
        //    System.Threading.Thread.Sleep(2000);
        //}
      
        /// <summary>
        /// 稳态压差实验-单一状态
        /// </summary>
        /// <param name="dictCurve">由曲线名字和曲线构成的字典</param>
        /// <param name="state">球阀状态，也即液控单向阀液流方向</param>
        /// <param name="pa_pressure">控制油压力</param>
        private void SteadystatePreeesureSingleSide(Dictionary<string,Curve> dictCurve,CircuitState state,float pa_pressure)
        {
            if (state != CircuitState.ABOut && state != CircuitState.BAOut)
                return;
            string key = state.ToString()+"-控制油"+pa_pressure.ToString()+"MPa";          
            Curve curve = new Curve();
            curve.Name = key;
            dictCurve.Add(key,curve);        
            
            this.SetCircuitState(state);
            this.SetThrottleValve(100f);
            this.SetTestValveState(TestValveState.右位);
            this.SetValve4(10f);
            this.SetPaPressure(pa_pressure);//设置先导油的压力
            this.SetSourcePre(this.额定压力);
            float max_flow = (float)(this.额定流量);
            this.SetSourceFlow(0);
            Pause(3000);
            const int div_cnt = 20;
            const int measure_cnt = 10;
            float pressure_A = 0;
            float pressure_B = 0;          
            float delta_q = (float)(max_flow / div_cnt);
            float flow = 0;
            for (int i = 0; i <= div_cnt; i++)
            {
                this.SetSourceFlow(i * delta_q);

                //读取压力流量数据
                flow = 0;
                pressure_A = 0;
                pressure_B = 0;               
                for (int j = 0; j < measure_cnt; j++)
                {
                    Pause(1000);
                    flow += this.当前流量绝对值 / measure_cnt;
                    pressure_A += this.当前A口压力 / measure_cnt;
                    pressure_B += this.当前B口压力 / measure_cnt;
                }
                //将数据添加到曲线
                curve.AddPoint(flow, Math.Abs(pressure_A - pressure_B));
            }

            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.SetThrottleValve(50f);        
        }

        /// <summary>
        /// 稳态压差特性实验
        /// </summary>
         protected void SteadystatePreeesure()
        {
             
            CurvePanel panel = new CurvePanel();
            Dictionary<string,Curve> dictCurve= new Dictionary<string,Curve>();
            panel.Title = TestType.稳态压差流量特性试验.ToString();
            panel.XLabel = "流量(L/Min)";
            panel.YLabel = "压差(MPa)";
         //   SteadystatePreeesureSingleSide(dictCurve,CircuitState.ABOut,0);
         //   SteadystatePreeesureSingleSide(dictCurve, CircuitState.ABOut, 10f);
            SteadystatePreeesureSingleSide(dictCurve, CircuitState.BAOut, 0);
             foreach(string key in dictCurve.Keys)
             {
                 panel.AddCurve(dictCurve[key]);
             }
             this.dictCurvePanel.Remove(panel.Title);
             this.dictCurvePanel.Add(panel.Title, panel);
             this.LOG.Debug("稳态压差流量特性试验完成");
        }
        private void MinControlPreTest()//液控单向阀最小控制压力
        {
            CurvePanel panel = new CurvePanel();
            panel.Title = TestType.液控单向阀最小控制压力.ToString()+"实验曲线";
            panel.XLabel = "体积流量(L/Min)";
            panel.YLabel = "控制压力(MPa)";
            
            Curve curvePBmax= new Curve();
            Curve curve75PBmax = new Curve();
            Curve curve50PBmax = new Curve();
            Curve curve25PBmax = new Curve();
            Curve curvePBmin = new Curve();
            //添加曲线
            panel.AddCurve(curvePBmax);
            panel.AddCurve(curve75PBmax);
            panel.AddCurve(curve50PBmax);
            panel.AddCurve(curve25PBmax);
            panel.AddCurve(curvePBmin);
            //添加曲线名称
            curvePBmax.Name = "100%PBmax";
            curve75PBmax.Name = "75%PBmax";
            curve50PBmax.Name = "50%PBmax";
            curve25PBmax.Name = "25%PBmax";
            curvePBmin.Name = "PBmin";

            this.SetTestValveState(TestValveState.右位);
            this.SetCircuitState(CircuitState.ATIn);
            this.SetThrottleValve(100f);//设置比例方向阀13/14.1/14.2的位置(右位开口最大)
           
            this.SetValve4(0f); ;//设置比例减压阀4的压力值为0
         //   this.SetPaPressure((float)(5 * this.开启压力));//设置先导控制油压力,暂定16
            this.SetPaPressure(10f);//设置先导控制油压力,暂定16
            //2改为5倍开启压力
            //在操作面板上显示配置界面用户配置最大设定压力和被试流量
            //FormMinControlPress frm_minconpress = new FormMinControlPress("请输入实验压力",(float)this.额定压力);
            this.SetSourceFlow(this.额定流量);
            for (int i = 1; i < 5; i++)
            {
                //每一个压力点寻找最小开启压力
                double OilPressure = this.额定压力 * i * 0.25;
                this.SetSourcePre(OilPressure);
                this.WaitPressureAUntil(OilPressure * 0.8);
                const int div_cnt = 100;
                double[] OpenPressure = new double[6];
                double[] DesiredFlow = new double[6];
                for (int j = 0; j < 6; j++)
                {
                    //每个设定压力下，寻找6个开启压力及对应的流量
                    int FlagFind = 1;
                    int m = 0;//减压阀加载用
                    while (FlagFind == 1)
                    {
                        //寻找最低开启压力，一个点
                        m = m + 1; 
                        this.SetValve4(m * (float)(this.额定压力 / div_cnt));
                        Pause(1000);
                        //if (Math.Abs(Math.Abs(Group[selectedFlowmeter]) / this.额定流量) >= 0.5)
                        {
                            OpenPressure[j] = this.Pa口传感器压力;
                            DesiredFlow[j] = this.当前流量;
                            LOG.Debug("第" + j + "组数据");
                            FlagFind = 0;
                        }
                    }
                }
                for (int n = 0; n < 6; n++)          //n个数要进行n-1趟比较,按照流量从小到大排列
                {
                    for (int P = 0; P < 5; P++)
                    {
                        if (DesiredFlow[P] > DesiredFlow[P + 1])
                        {
                            //依次比较两个相邻的数，将小数放在前面，大数放在后面
                            double temp = DesiredFlow[P];
                            DesiredFlow[P] = DesiredFlow[P + 1];
                            DesiredFlow[P + 1] = temp;

                            temp = OpenPressure[P];
                            OpenPressure[P] = OpenPressure[P + 1];
                            OpenPressure[P + 1] = temp;
                        }
                    }
                }
                
                switch(i)
                {
                    case 1:
                        {
                            for(int j=0;j<6;j++)
                            {
                                curve25PBmax.AddPoint(DesiredFlow[j], OpenPressure[j]);
                            }
                            break;
                        }
                    case 2:
                        {
                            for(int j=0;j<6;j++)
                            {
                                curve50PBmax.AddPoint(DesiredFlow[j], OpenPressure[j]);
                            }
                            break;
                        }
                    case 3:
                        {
                            for(int j=0;j<6;j++)
                            {
                                curve75PBmax.AddPoint(DesiredFlow[j], OpenPressure[j]);
                            }
                            break;
                        }
                    case 4:
                        {
                            for(int j=0;j<6;j++)
                            {
                                curvePBmax.AddPoint(DesiredFlow[j], OpenPressure[j]);
                            }
                            break;
                        }     
                }
            }
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.dictCurvePanel.Remove(panel.Title);
            this.dictCurvePanel.Add(panel.Title, panel);
            this.LOG.Debug("液控单向阀最小控制压力实验完成");
            }
    /*        Curve curve = new Curve();
            curve .Name ="液控单向阀最小控制压力曲线";
            panel.AddCurve(curve);
            this.SetCircuitState(CircuitState.ATIn);
       //     this.SetCircuitState(CircuitState.BAOut);
            this.SetThrottleValve(100f);//设置比例方向阀13/14.1/14.2的位置(右位开口最大)
            this.SetValve4(0f); ;//设置比例减压阀4的压力值为0
            this.SetPaPressure((float)(5*this.开启压力));//设置先导控制油压力,暂定16
            //2改为5倍开启压力
            //在操作面板上显示配置界面用户配置最大设定压力和被试流量
            //FormMinControlPress frm_minconpress = new FormMinControlPress("请输入实验压力",(float)this.额定压力);
            FormMinControlPress frm_minconpress = new FormMinControlPress("请输入试验压力", (float)this.额定压力);
            frm_minconpress.ShowDialog();
            this.SetSourcePre(frm_minconpress.ret);
            if(frm_minconpress.DialogResult == DialogResult.OK)
            {
                LOG.Debug("压力填写完毕");
                bool need_test = true;
                while(need_test)
                {
                    FormMinControlPress frm_setflow = new FormMinControlPress("请输入试验流量",(float)this.额定流量);
                    need_test = frm_setflow.ShowDialog()==DialogResult.OK;
                    if(!need_test)
                        return;
                    LOG.Debug("流量填写完毕");
                    this.SetSourceFlow(frm_setflow.ret);
                    this.WaitPressureUntil(frm_minconpress.ret);
                    const int div_cnt = 20;
                    for (int i = 0; i < div_cnt; i++)
                    {
                        this.SetValve4(i *(float) (this.开启压力 / div_cnt));
                        System.Threading.Thread.Sleep(3000);
                        if (Math.Abs(Math.Abs(Group[selectedFlowmeter]) - frm_setflow.ret) <= 0.5)
                        {
                            curve.AddPoint(frm_setflow.ret, this.Pa口传感器压力);
                            break;
                        }

                    }
                }
                
            }
            else 
            {

                MessageBox.Show("退出实验");
            }
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.dictCurvePanel.Remove(panel.Title);
            this.dictCurvePanel.Add(panel.Title, panel);
            this.LOG.Debug("液控单向阀最小控制压力实验完成");
     
     
        }
     */
        private void HyConLeakageTest()//液控单向阀泄漏量试验
        {
            CurvePanel panel = new CurvePanel();
            panel.Title = TestType.液控单向阀泄漏量试验.ToString() + "曲线";
            panel.XLabel = "压力(MPa)";
            panel.YLabel = "泄漏量(Ml/Min)";
            Curve curve_leak = new Curve();
            panel.AddCurve(curve_leak);
            curve_leak.Name = "泄漏量";

            float retnum;
            float testret = 0;
            int time = 0;
            float max_pressure = (float)this.额定压力;
            bool needtest = true;

            //this.SetCircuitState(CircuitState.BTIn);
            this.SetCircuitState(CircuitState.A);
            this.SetValve4(0);
            while (needtest)
            {
                FormLeakHydcheck leakHydcheck_config = new FormLeakHydcheck(max_pressure);
                needtest = leakHydcheck_config.ShowDialog() == DialogResult.OK;
                if (!needtest)
                    break;
                this.SetThrottleValve(100f);//使阀13,14_1,14_2工作于右位，且开口最大
                this.SetSourcePre(leakHydcheck_config.实验压力);
                this.SetSourceFlow(20);
                this.WaitPressureAUntil(leakHydcheck_config.实验压力);
                LOG.Debug("系统达到试验压力");
                FormLeakageReturn frm_return = new FormLeakageReturn(leakHydcheck_config.testtimecount,this);
                frm_return.ShowDialog();
                LOG.Debug("倒计时窗口显示");
                time = leakHydcheck_config.testtimecount;
                testret = frm_return.retvol;
                retnum = (frm_return.retvol / leakHydcheck_config.testtimecount) * 60f;
                curve_leak.AddPoint(leakHydcheck_config.实验压力, retnum);
            }
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
            this.dictCurvePanel.Remove(panel.Title);
            this.dictCurvePanel.Add(panel.Title, panel);
           this.LOG.Debug("泄漏实验已完成");
          
        }

        protected override void SetTestValveState(TestValveState state)
        {
            this.SetTestValveStatePilot (state);
        }
        protected override void RunTest(TestType testType)
        {
            LOG.Debug("RunTest");
            if (!TestTypeName.Contains(testType))
                TestTypeName.Add(testType); 
            switch (testType)
            {
                case TestType.耐压试验:
                    this.EndurationTest();
                    break;
                case TestType.稳态压差流量特性试验:
                    this.SteadystatePreeesure();
                    LOG.Debug("RunTest");
                    break;
                case TestType.液控单向阀最小控制压力:
                    this.MinControlPreTest();
                    break;
                case TestType.液控单向阀泄漏量试验:
                    this.HyConLeakageTest();
                    break;
                default:
                    throw new TestTypeNotSupportedException();
            }
        }
     
        public override void GenerateReport()
        {
            WordHelper helper = SetReportBasicInfo(true);
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
                    string 图片路径 = 路径 + "\\report\\液控单向阀\\液控单向阀稳态压差流量特性试验曲线"+"--"+ currentTime +".bmp";
                    string key = TestType.稳态压差流量特性试验.ToString(); 
                    Pict.Add("$稳态压差流量特性曲线$", 图片路径);
                    this.dictCurvePanel[key].SaveBMP(图片路径);
                }
                if (tt == TestType.液控单向阀最小控制压力)
                {
                    string 图片路径 = 路径 + "\\report\\液控单向阀\\液控单向阀最小控制压力试验曲线"+"--"+ currentTime +".bmp";
                    string key = TestType.液控单向阀最小控制压力.ToString()+"实验曲线";
                    Pict.Add("$最小控制压力曲线$", 图片路径);
                    dictCurvePanel[key].SaveBMP(图片路径);
                }
                if (tt == TestType.液控单向阀泄漏量试验)
                {
                    string 图片路径 = 路径 + "\\report\\液控单向阀\\液控单向阀泄漏量试验曲线" + "--" + currentTime + ".bmp";
                    string key =TestType.液控单向阀泄漏量试验.ToString() + "曲线";
                    Pict.Add("$泄漏量实验曲线$", 图片路径);
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
            WordHelper helper = SetReportBasicInfo(false);
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
                    string 图片路径 = 路径 + "\\report\\液控单向阀\\液控单向阀稳态压差流量特性试验曲线" + "--" + currentTime + ".bmp";
                    string key = TestType.稳态压差流量特性试验.ToString();
                    Pict2.Add("$稳态压差流量特性曲线$", 图片路径);
                    this.dictCurvePanel[key].SaveBMP(图片路径);
                }
                if (tt == TestType.液控单向阀最小控制压力)
                {
                    string 图片路径 = 路径 + "\\report\\液控单向阀\\液控单向阀最小控制压力试验曲线" + "--" + currentTime + ".bmp";
                    string key = TestType.液控单向阀最小控制压力.ToString() + "实验曲线";
                    Pict2.Add("$最小控制压力曲线$", 图片路径);
                    dictCurvePanel[key].SaveBMP(图片路径);
                }
                if (tt == TestType.液控单向阀泄漏量试验)
                {
                    string 图片路径 = 路径 + "\\report\\液控单向阀\\液控单向阀泄漏量试验曲线" + "--" + currentTime + ".bmp";
                    string key = TestType.液控单向阀泄漏量试验.ToString() + "曲线";
                    Pict2.Add("$泄漏量实验曲线$", 图片路径);
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

    }
}
