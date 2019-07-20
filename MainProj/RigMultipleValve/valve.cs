using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MainProj.Utils;
namespace MainProj.Local
{    
    public class Valve:device
    {


        #region 全局参数

        /// <summary>
        /// 操作球阀需要的最低Pa压力
        /// 默认为10MPa
        /// </summary>
        private const float 球阀操作最低设定压力 = 10f;

        /// <summary>
        /// 阀试验台球阀数量,阀16,阀2.1~2.12，共13个
        /// </summary>
        private const int 阀试验台球阀总数 = 13;

        /// <summary>
        /// 当该值为false时表示球阀可以正常自动切换，如果未true表示不能正常切换，需要提示操作人员手动切换球阀
        /// </summary>
        private const bool 球阀需要手动切换 = false;

        /// <summary>
        /// 球阀操作的最长等待时间，单位：秒，默认300s
        /// </summary>
        private const int 球阀操作最长允许超时 = 300;
        

        #endregion

        #region 数据库字段
        public int Id { get; set; }
        public string 型号 { get; set; }
        public string 序列号 { get; set; }
        public string 制造商 { get; set; }
        public double P口耐压 { get; set; }
        public double T口耐压 { get; set; }
        public double A口耐压 { get; set; }
        public double B口耐压 { get; set; }
        public double 额定压力 { get; set; }
        public double 额定流量 { get; set; }
        public bool 有外泄漏口 { get; set; }
        public bool 液控 { get; set; }

        public double X口压力 { get; set; }
        public double 开启压力 { get; set; }
        #endregion

        #region 传感器状态
        protected float 当前流量绝对值
        {
            get;
            //{
            //    return (float)(Math.Abs(Group[selectedFlowmeter]));
            //}
        }

        protected float 当前流量
        {
            get;
            //{
            //    return (float)Group[selectedFlowmeter];
            //}
        }

        protected float 当前P口压力
        {
            get;
            //{
            //    return (float)Group["P口压力"];
            //}
        }
        protected float 当前T口压力
        {
            get;
            //{
            //    return (float)Group["T口压力"];
            //}
        }
        protected float 当前A口压力
        {
            get;
            //{
            //    return (float)Group["A口压力"];
            //}
        }
        protected float 当前B口压力
        {
            get;
            //{
            //    return (float)Group["B口压力"];
            //}
        }
        protected float Pa口传感器压力
        {
            get;
            
                //return (float)Group["控制油Pa口压力"];
            
        }

        #endregion

        #region 压力流量设定操作
        /// <summary>
        /// 油源Pa口设定压力
        /// </summary>
        protected float 油源Pa口设定压力
        {
            get
            {
                //return Group["阀台当前Pa压力"];
                return 1;
            }
            set
            {
                //Group["阀台当前Pa压力"] = value;
                LOG.Info(String.Format("阀台当前Pa压力被设定为:{0:F}MPa", value));
            }
        }

        /// <summary>
        /// 如果要允许设置球阀状态，则给球阀先导级供油,否则将球阀控制油断开
        /// </summary>
        protected bool 允许设置球阀状态
        {
            set
            {
                //Group["阀3_2左控缓存"] = value;

                if (value)
                {
                    if (this.油源Pa口设定压力 < 球阀操作最低设定压力)
                    {
                        LOG.Info(String.Format("Pa口的当前目标设定压力为%fMPa，小于球阀开启时系统要求的最低设定压力%fMPa，因此强制将设定压力改为%fMPa", this.油源Pa口设定压力, 球阀操作最低设定压力, 球阀操作最低设定压力));
                        this.油源Pa口设定压力 = 球阀操作最低设定压力;
                    }

                }

            }
        }

        protected float 油源P口设定压力
        {
            set
            {
                //Group["油源压力"] = value;
                LOG.Debug(String.Format("已设置油源压力为:{0:F}MPa", value));
            }
        }

        /// <summary>
        /// 设置油源流量
        /// </summary>
        protected float 油源P口设定流量
        {
            set
            {
                //Group["油源流量"] = value;
                LOG.Debug(String.Format("已设置油源流量为:{0:F}L/min", value));
            }
        }

        protected float 节流阀控制信号
        {
            get
            {
                //if (Group["阀13位移缓存"] != Group["阀14_1位移缓存"] ||
                //    Group["阀13位移缓存"] != Group["阀14_2位移缓存"])
                //    LOG.Warn("阀13、14.1、14.2位移缓存不一致,获取节流阀控制信号时返回阀13位移缓存");

                //return Group["阀13位移缓存"];
                return 1;
            }
            set
            {
                float val = value;
                if (val > 100)
                    val = 100;

                if (val < 0)
                    val = 0;

                //Group["阀13位移缓存"] = val;
                //Group["阀14_1位移缓存"] = val;
                //Group["阀14_2位移缓存"] = val;
            }
        }

        #endregion

        #region 被试阀操作
        /// <summary> 
        /// 设置被试比例阀的比例控制信号
        /// -10V~10V对应的控制指令为0~100
        /// </summary>
        protected float 被试阀比例控制信号
        {
            //get
            //{
            //return Group["被试阀1位移缓存"];
            //}
            set
            {
                float val = value;
                if (val > 100)
                    val = 100;

                if (val < 0)
                    val = 0;

                //Group["被试阀1位移缓存"] = val;
                LOG.Debug(String.Format("被试阀比例控制信号被设置为:{0:F}", val));
            }
        }

        #endregion

        protected string 路径
        {
            get
            {
                return System.IO.Path.GetFullPath("..");
            }
        }

        protected virtual string 元件名称
        {
            get
            {
                return "阀";
            }
        }

        protected virtual string 保存路径
        {
            get
            {
                return this.路径 + "\\report\\试验报告.doc";
            }
        }

        protected virtual string 模板路径
        {
            get
            {
                return null;
            }
        }
        
        protected string selectedFlowmeter;



        private string[] conVarNameL=new string[阀试验台球阀总数];
        private string[] conVarNameR = new string[阀试验台球阀总数];
        private string[] retVarNameL = new string[阀试验台球阀总数];
        private string[] retVarNameR = new string[阀试验台球阀总数];

        private System.Timers.Timer heartbeatTimer= new System.Timers.Timer(500);

        private Int16 cntHeartBeart=0;


        protected byte[] testReport;

        public delegate void TestEndEventHandler();//声明委托,类对象不能找到此声明，仅为声明非对象
        public event TestEndEventHandler TestEndEvent;//创建事件并发布
        public event TestEndEventHandler EndurationEndEvent;

        /// <summary>
        /// 对试验类型列表进行排序
        /// </summary>
        public virtual void SortTestList()
        {
            this.试验类型列表.Sort();
        }
        public Valve()
        {
            conVarNameL[0] = "阀16左控缓存";
            conVarNameR[0] = "阀16右控缓存";
            retVarNameL[0] = "阀16左到位缓存";
            retVarNameR[0] = "阀16右到位缓存";
            for (int i = 1; i < 13; i++)
            {
                conVarNameL[i] = "阀2_" + i.ToString() + "左控缓存";
                conVarNameR[i] = "阀2_" + i.ToString() + "右控缓存";
                retVarNameL[i] = "阀2_" + i.ToString() + "左到位缓存";
                retVarNameR[i] = "阀2_" + i.ToString() + "右到位缓存";
            }
            //有关heartbeat都注释了
            //this.heartbeatTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnHeartBeatTimer);
            //this.heartbeatTimer.AutoReset=true;
            _tested = false;//表示该阀尚未做过试验


        }

        protected void SelectFlowMeter()
        {
            //LOG.Debug("SelectFlowMeter开始");
            //if (Group["阀2_11综合状态"] == 2 || Group["阀2_11综合状态"] == 3)
            //    selectedFlowmeter = "流量计LL31流量";
            //else if (Group["阀2_12综合状态"] == 2 || Group["阀2_12综合状态"] == 3)
            //    selectedFlowmeter = "流量计LL32流量";
            //else
            //    selectedFlowmeter = "流量计LL33流量";
            //LOG.Debug("SelectFlowMeter结束");
        }








        //private void Run(Object stateInfo)
        //{
        //    LOG.Info("试验开始..."); 
        //    LOG.Info(String.Format("当前选择的试验元件型号为：{0}", this.型号));
        //    try
        //    {
        //        this.SetOfSelectFlowMeter((float)this.额定流量);
        //        this.decideOnAdjPropValve((float)this.额定流量);
        //        this.SelectFlowMeter();
                
        //        recordor.StartRecord();//开始记录
        //        LOG.Info("开始记录数据");
        //        foreach (TestType testType in this.试验类型列表)
        //        {
        //            LOG.Info(testType.ToString() + " 开始");
        //            RunTest(testType);
        //            LOG.Info(testType.ToString() + " 结束");
        //        }
        //        recordor.EndRecort();//stop record and save data to folder named "report"
        //        LOG.Info("停止记录数据");
        //        this.SaveReportToDB();
        //        LOG.Info("试验报告已转为BLOB");
        //        this.SaveTestData();//save data to Mysql database
        //        LOG.Info("试验记录以保存到数据库，如有需要请在中央控制室查看");
        //        this.SetSourceFlow(0);
        //        this.SetSourcePre(0);//1102
        //        this.SetFlowMeasureValveOn();//1031
        //        this.SetCircuitState(CircuitState.ALLOn);
        //        _tested = true;//表示该阀做过试验
        //    }
        //    catch (BallValveOperateTimeOutException e)
        //    {
        //        LOG.Error("球阀操作超时，试验终止");
        //        this.SetSourceFlow(0);
        //        this.SetSourcePre(0);//1102
        //    }
        //    catch (TestAbortException e)
        //    {
        //        LOG.Error("试验被用户主动终止");
        //    }
        //    catch (Exception e)
        //    {
        //        LOG.Debug(e);
        //        throw e;
        //    }
        //    finally
        //    {
        //        this.heartbeatTimer.Enabled = false;
        //    }           
           
        //    //此处使能启动按钮
        //    //此处禁掉暂停按钮
        //    TestEndEvent();//触发button使能状态改变的事件
        //    //this.SetSourceFlow(0);
        //    //this.SetSourcePre(0);//移到上面了，先把压力流量卸下来再操作球阀打开
        //    LOG.Info("试验结束,请打印实验报告...");
        //}


        protected virtual void SetTestValveState(TestValveState state)
        {

        }

        
        protected void AllowSetBallValve(bool val)
        {
/*            Group["阀3_2左控缓存"] = true*/;
        }

        /// <summary>
        /// 设置球阀状态
        /// list变量的第0个阀为阀16，后续的1~12分别对应阀2.1~2.12
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool SetCircuitState(CircuitState state)
        {
            if (球阀需要手动切换)
            {
                string info = "球阀操作装置被设置为无法正常切换,请手动将球阀设置为" + state.ToString();
                LOG.Debug(info);
                MessageBox.Show(info);
            }
            //如果需要调整球阀操作时的设定压力，请更改valve类的变量：球阀操作最低设定压力
            this.允许设置球阀状态 = true;
            bool[] list = new bool[阀试验台球阀总数];
            int ballvalve_cnt_need_operate = 11;
            switch (state)
            {
                case CircuitState.ATOut:
                    list[0] = false;
                    list[1] = true;
                    list[2] = false;
                    list[3] = false;
                    list[4] = true;
                    list[5] = true;
                    list[6] = false;
                    list[7] = true;
                    list[8] = false;
                    list[9] = false;
                    list[10] = true;                    
                    break;
                case CircuitState.ATIn:
                    list[0] = false;
                    list[1] = true;
                    list[2] = true;
                    list[3] = false;
                    list[4] = true;
                    list[5] = false;
                    list[6] = true;
                    list[7] = false;
                    list[8] = true;
                    list[9] = true;
                    list[10] = false;
                    break;
                case CircuitState.BTOut:
                    list[0] = false;
                    list[1] = true;
                    list[2] = false;
                    list[3] = true;
                    list[4] = false;
                    list[5] = false;
                    list[6] = true;
                    list[7] = true;
                    list[8] = false;
                    list[9] = false;
                    list[10] = true;
                    break;
                case CircuitState.BTIn:
                    list[0] = false;
                    list[1] = true;
                    list[2] = true;
                    list[3] = true;
                    list[4] = false;
                    list[5] = true;//0822
                    list[6] = false;//0822
                    list[7] = false;
                    list[8] = true;
                    list[9] = true;
                    list[10] = false;
                    break;
                case CircuitState.PTOut:
                    list[0] = true;  //原来为false
                    list[1] = true;
                    list[2] = false;
                    list[3] = false;
                    list[4] = false;
                    list[5] = false;
                    list[6] = false;
                    list[7] = true;
                    list[8] = false;
                    list[9] = false;
                    list[10] = true;
                    break;
                case CircuitState.ABOut:
                    list[0] = false;
                    list[1] = true;
                    list[2] = false;
                    list[3] = true;
                    list[4] = true;
                    list[5] = true;
                    list[6] = false;
                    list[7] = false;
                    list[8] = true;
                    list[9] = false;
                    list[10] = true;
                    break;
                case CircuitState.BAOut:
                    list[0] = false;
                    list[1] = true;
                    list[2] = true;
                    list[3] = true;
                    list[4] = true;
                    list[5] = false;
                    list[6] = true;
                    list[7] = true;
                    list[8] = false;
                    list[9] = true;
                    list[10] = false;
                    break;
                case CircuitState.PAOut:
                    list[0] = true;//0821改原为false
                    list[1] = true;
                    list[2] = true;
                    list[3] = false;
                    list[4] = true;
                    list[5] = false;
                    list[6] = false;
                    list[7] = true;
                    list[8] = false;
                    list[9] = true;
                    list[10] = false;
                    break;
                case CircuitState.PBOut:
                    list[0] = true;  //原来为false
                    list[1] = true;
                    list[2] = true;//原来为false
                    list[3] = true;
                    list[4] = false;
                    list[5] = false;
                    list[6] = false;
                    list[7] = false;
                    list[8] = true;
                    list[9] = false;
                    list[10] = true;    //原来为false
                    break;
                case CircuitState.P:
                    list[0] = true;
                    list[1] = true;
                    list[2] = false;
                    list[3] = false;
                    list[4] = false;
                    list[5] = false;
                    list[6] = false;
                    list[7] = false;
                    list[8] = false;
                    list[9] = false;
                    list[10] = false;
                    break;
                case CircuitState.T:
                    list[0] = false;
                    list[1] = false;
                    list[2] = true;
                    list[3] = false;
                    list[4] = false;
                    list[5] = true;
                    list[6] = false;
                    list[7] = false;
                    list[8] = false;
                    list[9] = true;
                    list[10] = true;
                    break;
                case CircuitState.A:
                    list[0] = false;
                    list[1] = false;
                    list[2] = false;
                    list[3] = false;
                    list[4] = true;
                    list[5] = true;
                    list[6] = false;
                    list[7] = false;
                    list[8] = false;
                    list[9] = false;
                    list[10] = false;
                    break;
                case CircuitState.B:
                    list[0] = false;
                    list[1] = false;
                    list[2] = false;
                    list[3] = true;
                    list[4] = false;
                    list[5] = false;
                    list[6] = true;
                    list[7] = false;
                    list[8] = false;
                    list[9] = false;
                    list[10] = false;
                    break;
                case CircuitState.PABTOut:
                    list[0] = true;
                    list[1] = true;
                    list[2] = true;
                    list[3] = true;
                    list[4] = true;
                    list[5] = false;
                    list[6] = false;
                    list[7] = false;
                    list[8] = true;
                    list[9] = true;
                    list[10] = false;
                    break;
                case CircuitState.PT2Out:
                    list[0] = true;//0828修改，做内泄露实验时需要球阀16打开
                    list[1] = false;
                    list[2] = true;
                    list[3] = false;
                    list[4] = false;
                    list[5] = false;
                    list[6] = false;
                    list[7] = false;
                    list[8] = false;
                    list[9] = false;
                    list[10] = false;
                    break;
                case CircuitState.ALLOn:
                    list[0] = true;
                    list[1] = true;
                    list[2] = true;
                    list[3] = true;
                    list[4] = true;
                    list[5] = true;
                    list[6] = true;
                    list[7] = true;
                    list[8] = true;
                    list[9] = true;
                    list[10] = true;

                    list[11] = true;
                    list[12] = true;

                    ballvalve_cnt_need_operate = 13;
                    break;
               
            }

            //设置球阀状态
            for (int i = 0; i < ballvalve_cnt_need_operate; i++)
            {
                //Group[conVarNameL[i]] = list[i];
                //Group[conVarNameR[i]] = !list[i];
            }

            //等待球阀接近开关反馈状态
            int timeout;
            for (timeout = 球阀操作最长允许超时; timeout >= 0; timeout--)
            {
                int i;
                for (i=0; i < ballvalve_cnt_need_operate; i++)
                {
                    //if (Group[retVarNameL[i]] != list[i] || Group[retVarNameR[i]] == list[i])
                    {
                        LOG.Debug(retVarNameL[i] + " 或者 " + retVarNameR[i] + " 尚未到位，继续等待球阀操作到位");
                        break;
                    }
                        
                }
                if (i == ballvalve_cnt_need_operate)
                    break;

                Pause(1000);
            }
            if (timeout <=0)
            {
                throw new BallValveOperateTimeOutException();
            }
            
            for (int i = 0; i < ballvalve_cnt_need_operate; i++)
            {
                //Group[conVarNameL[i]] = false;
                //Group[conVarNameR[i]] = false;
            }
            this.允许设置球阀状态 = false;
            LOG.Debug("已经将阀试验台球阀状态设置为" + state.ToString());
            return true;
        }

        /// <summary>
        /// 把流量计的球阀都打开
        /// </summary>
        /// <returns></returns>
        protected bool SetFlowMeasureValveOn()
        {
            //Group["阀3_2左控缓存"] = true;
            //Group["阀2_11左控缓存"] = true;
            //Group["阀2_11右控缓存"] = false;
            //Group["阀2_12左控缓存"] = true;
            //Group["阀2_12右控缓存"] = false;
            int timeout = 80;
            while (timeout-- > 0)
            {
                System.Threading.Thread.Sleep(1000);
                //if (Group["阀2_11综合状态"] == 3 && Group["阀2_12综合状态"] == 3 )
                //{
                //    Group["阀3_2左控缓存"] = false;
                //    break;
                //}

                if (timeout < 0)
                {
                    throw new BallValveOperateTimeOutException();
                }

            }
            //Group["阀3_2左控缓存"] = false;
            //Group["阀2_11左控缓存"] = false;
            //Group["阀2_11右控缓存"] = false;
            //Group["阀2_12左控缓存"] = false;
            //Group["阀2_12右控缓存"] = false;
            return true;
        }
        /// <summary>
        /// 设置油源压力
        /// </summary>
        /// <param name="presure">压力，单位MPa</param>
        public void SetSourcePre(double presure)//1031
        {
            this.油源P口设定压力 = (float)presure;
        }

        /// <summary>
        /// 设置油源流量，使得油源供应流量比实际需求流量略高
        /// </summary>
        protected void FitSourceFlow()
        {
            this.油源P口设定流量 = this.当前流量绝对值 + 120f;
            Pause(2000);
        }

        /// <summary>
        /// 设置油源流量
        /// </summary>
        /// <param name="flow">流量，单位L/min</param>
        public void SetSourceFlow(double flow)
        {
            this.油源P口设定流量 = (float)flow;
        }


        private void waitPressure(double press,CircuitState state)
        { 
            switch(state)
            {
                case CircuitState.P:
                    WaitPressurePUntil(press);
                    break;
                case CircuitState.A:
                    WaitPressureAUntil(press);
                    break;
                case CircuitState.B:
                    WaitPressureBUntil(press);
                    break;
                case CircuitState.T:
                    WaitPressureTUntil(press);
                    break;
            }
                
}
        /// <summary>
        /// 耐压实验的公共执行程序
        /// </summary>
        /// <param name="press">油源供给压力</param>
        /// <param name="state">球阀需要的状态</param>
        public void Enduration_Test(double press,CircuitState state)
        {
            this.SetCircuitState(state);
            this.SetSourceFlow(20);
            this.SetSourcePre(press);
            this.waitPressure(press, state);
            //此处要添加压力等待时间
            FormKeepTime frm_keeptime = new FormKeepTime();
            frm_keeptime.ShowDialog();
            if (frm_keeptime.DialogResult == DialogResult.OK)
            {
                FormMaintainPressure frm_maintainpress = new FormMaintainPressure(frm_keeptime.retnum);
                frm_maintainpress.ShowDialog();
                if (frm_maintainpress.DialogResult == DialogResult.OK)
                {
                    //this.SetCircuitState(CircuitState.ALLOn);
                    this.SetSourceFlow(0);
                    this.SetSourcePre(0);                    
                    this.LOG.Debug("耐压实验成功，将进行后续实验");
                }
                else
                {
                   // this.SetCircuitState(CircuitState.ALLOn);
                    this.SetSourceFlow(0);
                    this.SetSourcePre(0);
                    this.LOG.Debug("耐压失败，已结束实验");
                }
            }
            else
            {
                this.SetCircuitState(CircuitState.ALLOn);
                this.SetSourceFlow(0);
                this.SetSourcePre(0);
                throw new TestAbortException();//显示抛出异常在catch中被捕获
            }

        }


        /// <summary>
        /// 耐压试验
        /// </summary>
        public void EndurationTest()
        {
            if (this.P口耐压 > 0)
            {
                this.LOG.Debug("P口耐压开始");
                Enduration_Test(this.P口耐压, CircuitState.P);
                
               
            }
            if (this.A口耐压 > 0)
            {
                this.LOG.Debug("A口耐压开始");
                this.Enduration_Test(this.A口耐压, CircuitState.A);
                
            }
            if (this.B口耐压 > 0)
            {
                this.LOG.Debug("B口耐压开始");
                this.Enduration_Test(this.B口耐压, CircuitState.B);
                
            }
            if (this.T口耐压 > 0)
            {
                this.LOG.Debug("T口耐压开始");
                this.Enduration_Test(this.T口耐压, CircuitState.T);
                
            }
            if (this.EndurationEndEvent != null)
            {
                this.EndurationEndEvent();
            }
            this.SetSourcePre(0);
            this.SetSourceFlow(0);
        }
        /// <summary>
        /// 根据被试阀流量选择需要使用的调节阀
        /// </summary>
        /// <param name="flow">被试阀额定流量</param>
        public void decideOnAdjPropValve(float flow)
        {
            LOG.Debug("decideOnAdjPropValve开始");
            //Group["是否启用阀13"] = false;
            //Group["是否启用阀14_2"] = false;
            //Group["是否启用阀14_1"] = false;
            //if (flow * 1.2f <= 125f)
            //{
            //    Group["是否启用阀13"] = true;
            //}
            //else if (flow * 1.2f > 125f && flow * 1.2f <= 200f)
            //{
            //    Group["是否启用阀14_1"] = true;//14_1和14_2任选一个
            //}
            //else if (flow * 1.2f > 200f && flow * 1.2f <= 325f)
            //{
            //    Group["是否启用阀13"] = true;
            //    Group["是否启用阀14_1"] = true;//14_1和14_2任选一个
            //}
            //else if (flow * 1.2f > 325f && flow * 1.2f <= 400f)
            //{
            //    Group["是否启用阀14_2"] = true;
            //    Group["是否启用阀14_1"] = true;
            //}
            //else if (flow * 1.2f > 400f)
            //{
            //    Group["是否启用阀13"] = true;
            //    Group["是否启用阀14_2"] = true;
            //    Group["是否启用阀14_1"] = true;
            //}
            LOG.Debug("decideOnAdjPropValve结束");

        }
        /// <summary>
        /// 根据额定流量选择流量计
        /// </summary>
        /// <param name="flow">被试阀额定流量</param>
        public void SetOfSelectFlowMeter(float flow)
        {
            LOG.Debug("SetOfSelectFlowMeter开始");
            //Group["阀3_2左控缓存"] = true;
            //Group["阀台当前Pa压力"] = 10f;
            //if (flow <= 600f && flow > 160f)
            //{
            //    Group["阀2_11左控缓存"] = true;
            //    Group["阀2_11右控缓存"] = false;
            //    Group["阀2_12左控缓存"] = false;
            //    Group["阀2_12右控缓存"] = true;
            //    Group["阀15控制缓存"] = false;       
            //}
            //else if (flow <= 160f && flow > 16f)
            //{
            //    Group["阀2_11右控缓存"] = true;
            //    Group["阀2_11左控缓存"] = false;
            //    Group["阀2_12左控缓存"] = true;
            //    Group["阀2_12右控缓存"] = false;
            //    Group["阀15控制缓存"] = false;
            //}
            //else if (flow <= 16f)
            //{
            //    Group["阀2_11右控缓存"] = true;
            //    Group["阀2_11左控缓存"] = false;
            //    Group["阀2_12右控缓存"] = true;
            //    Group["阀2_12左控缓存"] = false;
            //    Group["阀15控制缓存"] = true;
            //}
            //int timeout = 80;                               
            //while (timeout-- > 0)
            //{
            //     LOG.Debug(String.Format("timeout为:{0:F}", timeout));
            //    System.Threading.Thread.Sleep(1000);
            //    if ((Group["阀2_11综合状态"] == 3 && Group["阀2_12综合状态"] == 12 && Group["阀15控制缓存"] == false)
            //        || (Group["阀2_12综合状态"] == 3 && Group["阀2_11综合状态"] == 12 && Group["阀15控制缓存"] == false)
            //        || (Group["阀15控制缓存"] == true && Group["阀2_12综合状态"] == 12 && Group["阀2_11综合状态"] == 12))
            //    {
            //        Group["阀3_2左控缓存"] = false; 
            //        LOG.Debug(String.Format("timeout1为:{0:F}", timeout));
            //        break;
            //    }

            //    if (timeout < 0)
            //    {
            //        throw new BallValveOperateTimeOutException();
            //    }

            //}
            LOG.Debug("SetOfSelectFlowMeter结束");
        }          
        /// <summary>
        /// 设置阀台当前Pa压力
        /// </summary>
        /// <param name="pressure">需要设定的压力值,单位MPa</param>
        public void SetPaPressure(float pressure )
        {
            this.油源Pa口设定压力 = pressure;
        }

        /// <summary>
        /// 设置阀台当前Pa压力
        /// </summary>
        /// <param name="pressure">需要设定的压力值,单位MPa</param>
        public void SetPaPressure(double pressure)
        {
            this.SetPaPressure((float)pressure);
        }

        /// <summary>
        /// 设置阀台当前Pa压力
        /// </summary>
        /// <param name="pressure">需要设定的压力值,单位MPa</param>
        public void SetPaPressure(int pressure)
        {
            this.SetPaPressure((float)pressure);
        }

       /// <summary>
       /// 设置节流流量
       /// 调节阀13,14_1,14_2的阀芯位置
       /// </summary>
       /// <param name="location">传入的阀芯位置缓存值，为浮点数,有效范围为50f~100f</param>
        public void SetThrottleValve(float location)
        {
            if (location < 50f)
                location = 50f;
            if (location > 100f)
                location = 100f;

            //Group["阀13位移缓存"] = location;
            //Group["阀14_1位移缓存"] = location;
            //Group["阀14_2位移缓存"] = location;
            //Group["调节阀缓存值"] = location;
            LOG.Debug("已将调节阀13,14_1,14_2的阀芯位置设置为" + location.ToString());
        }
        /// <summary>
        /// 设置控制油路先导级的启闭状态，原理图中阀8
        /// </summary>
        /// <param name="state">左位，右位，中位</param>
        public void SetTestValveStatePilot(TestValveState state)
        {
            //switch (state)
            //{
            //    case TestValveState.左位:
            //        Group["阀8右控缓存"] = false;
            //        Group["阀8左控缓存"] = true;
            //        break;
            //    case TestValveState.右位:
            //        Group["阀8右控缓存"] = true;
            //        Group["阀8左控缓存"] = false;
            //        break;
            //    default:
            //        Group["阀8右控缓存"] = false;
            //        Group["阀8左控缓存"] = false;
            //        break;

            //}
        }

        /// <summary>
        /// 给被试阀先导级的X口供油，仅当被试阀为液控时使用
        /// </summary>
        /// <param name="state">true表示先导级供油，false表示先导级取消供油</param>
        public void SetTestValveStatePilotX(bool state)
        {
            if (state)
            {
                SetTestValveStatePilot(TestValveState.右位);
            }
            else
            {
                SetTestValveStatePilot(TestValveState.中位);
            }
        }

        /// <summary>
        /// 设置先导供油压力
        /// </summary>
        /// <param name="pressure">设定压力值，单位：MPa</param>
        public void SetTestValvePilotPressure(float pressure)
        {
            // 阀试验台比例减压阀值
            //Group["阀4压力值缓存"] = pressure;
            this.LOG.Info(String.Format("阀试验台比例减压阀被设置为:{0:F}MPa", pressure));
            if (this.油源Pa口设定压力 < pressure)
            {
                this.LOG.Warn(String.Format("检测到阀试验台比例减压阀的压力为:{0:F}MPa，大于油源Pa口的设定压力:{1:F}MPa", pressure, this.油源Pa口设定压力));
            }            
        }

        /// <summary>
        /// 设置先导供油压力
        /// </summary>
        /// <param name="pressure">设定压力值，单位：MPa</param>
        public void SetTestValvePilotPressure(double pressure)
        {
            SetTestValvePilotPressure((float)pressure);
        }

        /// <summary>
        /// 设置先导供油压力
        /// </summary>
        /// <param name="pressure">设定压力值，单位：MPa</param>
        public void SetTestValvePilotPressure(int pressure)
        {
            SetTestValvePilotPressure((float)pressure);
        }


        /// <summary>
        /// 设置被试电磁阀的电磁铁状态24V：左、中、右
        /// </summary>
        /// <param name="state"></param>
        protected void SetTestValveState_24V(TestValveState state)
        {
            //Group["被试阀电压切换缓存"] = false;
            //switch (state)
            //{
            //    case TestValveState.左位:
            //        Group["被试阀右控缓存_24V"] = false;
            //        Group["被试阀左控缓存_24V"] = true;
            //        break;
            //    case TestValveState.右位:
            //        Group["被试阀右控缓存_24V"] = true;
            //        Group["被试阀左控缓存_24V"] = false;
            //        break;
            //    default:
            //        Group["被试阀右控缓存_24V"] = false;
            //        Group["被试阀左控缓存_24V"] = false;
            //        break;
            //}
        }
        /// <summary>
        /// 设置被试电磁阀的电磁铁状态22V：左、中、右
        /// </summary>
        /// <param name="state"></param>
        public void SetTestValveState_22V(TestValveState state)
        {
            //Group["被试阀电压切换缓存"] = true;
            //switch (state)
            //{
            //    case TestValveState.左位:
            //        Group["被试阀右控缓存_22V"] = false;
            //        Group["被试阀左控缓存_22V"] = true;
            //        break;
            //    case TestValveState.右位:
            //        Group["被试阀右控缓存_22V"] = true;
            //        Group["被试阀左控缓存_22V"] = false;
            //        break;
            //    default:
            //        Group["被试阀右控缓存_22V"] = false;
            //        Group["被试阀左控缓存_22V"] = false;
            //        break;
            //}
            LOG.Debug("电磁铁22V电源被设置为" + state.ToString());
        }
                
        

        /// <summary>
        /// 设置先导控制减压阀4的压力值
        /// </summary>
        /// <param name="num"></param>
        public void SetValve4(float num)
        {
            //Group["阀4压力值缓存"] = num;
        }
        protected static double FloatToDouble(float i)
        {
            return Convert.ToDouble(i);
        }
               
        
        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="miliseconds"></param>
        public void Pause(int miliseconds)
        {
            System.Threading.Thread.Sleep(miliseconds);
        }


        public void WaitPressurePUntil(double pressure)
        {
            while (this.当前P口压力 <= 0.5 * pressure)
            {
                System.Threading.Thread.Sleep(1000);
            }
            System.Threading.Thread.Sleep(2000);
        }
        public void WaitPressureBUntil(double pressure)
        {
            while (this.当前B口压力 <= 0.5 * pressure)
            {
                System.Threading.Thread.Sleep(1000);
            }
            System.Threading.Thread.Sleep(2000);
        }
        public void WaitPressureAUntil(double pressure)
        {
            while (this.当前A口压力 <= 0.5 * pressure)
            {
                System.Threading.Thread.Sleep(1000);
            }
            System.Threading.Thread.Sleep(2000);
        }
        public void WaitPressureTUntil(double pressure)
        {
            while (this.当前T口压力 <= 0.5 * pressure)
            {
                System.Threading.Thread.Sleep(1000);
            }
            System.Threading.Thread.Sleep(2000);
        }
        
    }

    //TestType 所有实验


    public enum elemag_oil_locState
    {
       左位A口,
       左位B口,
       左位T口,
       右位A口,
       右位B口,
       右位T口

    }
    public enum CircuitState
    {
        ATOut,
        ATIn,
        BTOut,
        BTIn,
        PTOut,
        ABOut,
        BAOut,
        PAOut,
        PBOut,
        P,
        A,
        B,
        T,
        PABTOut,
        PT2Out,
        ALLOff,
        ALLOn
    }

    public enum TestValveState
    {
        中位,
        左位,
        右位
    }


    //public enum TestType
    //{
    //耐压试验,
    //    稳态流量压力特性试验,
    //    稳态压差流量特性试验,
    //    外泄漏试验,
    //    最低工作压力试验,
    //    内部泄漏试验,
    //    工作范围试验,
    //    直接作用式单向阀最小开启压力,
    //    液控单向阀最小控制压力,
    //    直接作用式单向阀泄漏量试验,
    //    液控单向阀泄漏量试验,
    //    稳态压力流量特性试验,
    //    恒定阀压降输出流量输入信号特性试验,
    //    节流调节特性试验,
    //    输出流量负载压差特性试验,
    //    输出流量阀压降特性试验,
    //    极限功率特性试验
    //}





    public class BallValveOperateTimeOutException : Exception
    {

    }



}
