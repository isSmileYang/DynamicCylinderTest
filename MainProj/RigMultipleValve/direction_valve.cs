
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

//using MainProj.
namespace MainProj.Local
{
    public class direction_valve : Valve
    {
        public List<float> 纵坐标压力 = new List<float>();
        public List<float> 横坐标流量 = new List<float>();

        public List<float> 左位泄露压力A口 = new List<float>();
        public List<float> 左位泄露压力B口 = new List<float>();
        public List<float> 左位泄露压力T口 = new List<float>();
        public List<float> 右位泄露压力A口 = new List<float>();
        public List<float> 右位泄露压力B口 = new List<float>();
        public List<float> 右位泄露压力T口 = new List<float>();
        public List<float> 左位泄露流量A口 = new List<float>();
        public List<float> 左位泄露流量B口 = new List<float>();
        public List<float> 左位泄露流量T口 = new List<float>();
        public List<float> 右位泄露流量A口 = new List<float>();
        public List<float> 右位泄露流量B口 = new List<float>();
        public List<float> 右位泄露流量T口 = new List<float>();
        public List<string> 阀芯位置及接油口 = new List<string>();

        public List<int> 左位A口测试时间 = new List<int>();
        public List<int> 左位B口测试时间 = new List<int>();
        public List<int> 左位T口测试时间 = new List<int>();
        public List<int> 右位A口测试时间 = new List<int>();
        public List<int> 右位B口测试时间 = new List<int>();
        public List<int> 右位T口测试时间 = new List<int>();
        public List<float> 左位A口量杯读数 = new List<float>();
        public List<float> 左位B口量杯读数 = new List<float>();
        public List<float> 左位T口量杯读数 = new List<float>();
        public List<float> 右位A口量杯读数 = new List<float>();
        public List<float> 右位B口量杯读数 = new List<float>();
        public List<float> 右位T口量杯读数 = new List<float>();
        public double[] 左位泄露压力A; public double[] 左位泄露压力B; public double[] 左位泄露压力T;
        public double[] 左位泄露流量A; public double[] 左位泄露流量B; public double[] 左位泄露流量T;
        public double[] 右位泄露压力A; public double[] 右位泄露压力B; public double[] 右位泄露压力T;
        public double[] 右位泄露流量A; public double[] 右位泄露流量B; public double[] 右位泄露流量T;

        public bool 操作完成;
        public Dictionary<string, bool> 所做试验 = new Dictionary<string, bool>();
        log4net.ILog logoutput = log4net.LogManager.GetLogger(typeof(device));
        public List<float> 泄露压力1 = new List<float>();
        public List<float> 泄露流量1 = new List<float>();
        public string rettype;
        protected string 图片路径temp;
        string oil_loc;
        public direction_valve()
        {
            if (this.试验类型列表 == null)
            {
                this.试验类型列表 = new List<TestType>();
            }
            //foreach (TestType tt in GetSupportedTestType())
            //{
            //    this.试验类型列表.Add(tt);
            //}
            所做试验.Add("稳态压差流量特性试验", false);
            所做试验.Add("内部泄露试验", false);
            所做试验.Add("工作范围试验", false);

        }

        public static IList<TestType> GetSupportedTestType()
        {
            IList<TestType> list = new List<TestType>();
            list.Add(TestType.耐压试验);
            list.Add(TestType.稳态压差流量特性试验);
            list.Add(TestType.内部泄漏试验);
            list.Add(TestType.工作范围试验);
            return list;
        }

        /// <summary>
        /// 内部泄漏试验
        /// 本试验是为了测定方向阀处某一工作状态时，具有一定压力差又互不相通的阀口之间的油液世漏量
        /// 建立加压压力和泄漏量的关系，输出内泄漏曲线，横坐标为加压压力，纵坐标为泄漏量
        /// </summary>
        protected virtual void IntenalLeakage()
        {
            CurvePanel panelLeakage = new CurvePanel();
            Dictionary<string, Curve> dictCurve = new Dictionary<string, Curve>();
            float retvol = 0;
            float testret = 0;
            int time = 0;
            panelLeakage.Title = TestType.内部泄漏试验.ToString() + "曲线";
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
            //获取参数
            while (needtest)
            {
                FormSetleak frmConfig = new FormSetleak();
                needtest = frmConfig.ShowDialog() == DialogResult.OK;
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
                MessageBox.Show("压力已建立，请打开泄漏油口，并放置量杯");
                //保压延时并获取结果
                FormLeakageReturn frm = new FormLeakageReturn(frmConfig.Timecount, this);
                frm.ShowDialog();
                time = frmConfig.Timecount;
                testret = frm.retvol;
                retvol = (frm.retvol / frmConfig.Timecount) * 60f;//获取泄漏量的值

                curve.AddPoint(frmConfig.试验压力, retvol);
                this.SetTestValveState(TestValveState.中位);

            }

            foreach (string key in dictCurve.Keys)
            {
                panelLeakage.AddCurve(dictCurve[key]);
            }
            this.dictCurvePanel.Remove(panelLeakage.Title);
            this.dictCurvePanel.Add(panelLeakage.Title, panelLeakage);
            this.SetSourcePre(0);
            this.SetSourceFlow(0);

        }

        /// <summary>
        /// 稳态压差流量特性试验
        /// 建立被试阀阀口压差和通过被试阀流量的关系，输出压差和流量的关系曲线图
        /// </summary>
        protected virtual void SteadystatePreeesure()
        {

        }

        /// <summary>
        /// 工作范围试验
        /// 本试验是为了测定换向阀能正常换向的压力和流量的边界值范围
        /// </summary>
        protected virtual void WorkScope()
        {

        }


    }
}