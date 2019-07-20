using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MWord=Microsoft.Office.Interop.Word;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using MainProj.Utils;

namespace MainProj.Local
{
    public class mechopera_valve : direction_valve
    {
        Dictionary<string, string> Pict=new Dictionary<string, string>();
        Dictionary<string, string> Dict=new Dictionary<string, string>();
        public List<float> 稳态压力1 = new List<float>();
        public List<float> 稳态流量1 = new List<float>();
        public List<float> 稳态压力2 = new List<float>();
        public List<float> 稳态流量2 = new List<float>();
        public List<float> 工作压力1 = new List<float>();
        public List<float> 工作流量1 = new List<float>();
        public List<float> 工作压力2 = new List<float>();
        public List<float> 工作流量2 = new List<float>();

        double[] 稳态压力1d;
        double[] 稳态流量1d;
        double[] 稳态压力2d;
        double[] 稳态流量2d;
        double[] 工作压力1d;
        double[] 工作流量1d;
        double[] 工作压力2d;
        double[] 工作流量2d;
        double[] 泄露压力1d;
        double[] 泄露流量1d;

        string 路径;
        string 模板路径;
        string 保存路径;
        string 图片路径;
        public List<TestType> 实验类型 = new List<TestType>();
        string dir = System.IO.Directory.GetCurrentDirectory();
        
        public mechopera_valve()
        {
            //Directory.SetCurrentDirectory(Directory.GetParent(dir).FullName);
            路径 = Path.GetFullPath("..");
            模板路径 = 路径+ "\\template\\机动换向阀模板.docx";                     
        }
        //protected override void SteadystatePreeesure()
        //{
        //    if (所做试验["稳态压差流量特性试验"] == true)
        //        MessageBox.Show("内部泄漏试验已完成，是否继续?");
        //    MessageBox.Show("请将球阀设置为PABT出口状态");
        //    this.SetCircuitState(CircuitState.PABTOut);
        //    Group["阀13位移缓存"] = 100f;
        //    Group["阀14_1位移缓存"] = 100f;
        //    Group["阀14_2位移缓存"] = 100f;
        //    MessageBox.Show("请手动将被试阀置于A位");
        //    //等待用户操作完毕后再确认
        //    this.SetSourcePre(this.额定压力);
        //    float 最大流量 = (float)(this.额定流量);
        //    this.SetSourceFlow(0);
        //    float[] A口压力 = new float[21];
        //    float[] B口压力 = new float[21];
        //    float[] P口压力 = new float[21];
        //    float[] T口压力 = new float[21];
        //    float qset = (float)(最大流量 * 0.05);
        //    float 流量计值 = 0;
        //    for (int i = 0; i < 21; i++)
        //    {
        //        this.SetSourceFlow(i * qset);
        //        int j = 0;
        //        while (j < 10)
        //        {
        //            //System.Threading.Thread.Sleep(1000);
        //            流量计值 += (float)Group[selectedFlowmeter];
        //            A口压力[i] = A口压力[i] + (float)Group["A口压力"];
        //            B口压力[i] = A口压力[i] + (float)Group["B口压力"];
        //            P口压力[i] = A口压力[i] + (float)Group["P口压力"];
        //            T口压力[i] = A口压力[i] + (float)Group["T口压力"];
        //            j++;
        //        }
        //        A口压力[i] = A口压力[i] / 10;
        //        B口压力[i] = B口压力[i] / 10;
        //        P口压力[i] = P口压力[i] / 10;
        //        T口压力[i] = T口压力[i] / 10;
        //        纵坐标压力.Add((float)(P口压力[i] - T口压力[i]));
        //        横坐标流量.Add(流量计值 / 10);
        //        流量计值 = 0;
        //    }
        //    //画图
        //    横坐标流量.ForEach(i => 稳态流量1.Add(i));
        //    纵坐标压力.ForEach(i => 稳态压力1.Add(i));
        //    横坐标流量.Clear();
        //    纵坐标压力.Clear();
        //    //System.Threading.Thread.Sleep(3000);
        //    MessageBox.Show("请手动将被试阀置于B位");
        //    //等待用户操作完毕后再确认
        //    this.SetSourceFlow(0);
        //    //System.Threading.Thread.Sleep(3000);
        //    float[] A口压力右 = new float[21];
        //    float[] B口压力右 = new float[21];
        //    float[] P口压力右 = new float[21];
        //    float[] T口压力右 = new float[21];
        //    for (int i = 0; i < 21; i++)
        //    {
        //        this.SetSourceFlow(i * qset);
        //        int j = 0;
        //        while (j < 10)
        //        {
        //            //System.Threading.Thread.Sleep(1000);
        //            流量计值 += (float)Group[selectedFlowmeter];
        //            A口压力右[i] = A口压力右[i] + (float)Group["A口压力"];
        //            B口压力右[i] = A口压力右[i] + (float)Group["B口压力"];
        //            P口压力右[i] = A口压力右[i] + (float)Group["P口压力"];
        //            T口压力右[i] = A口压力右[i] + (float)Group["T口压力"];
        //            j++;
        //        }
        //        A口压力右[i] = A口压力右[i] / 10;
        //        B口压力右[i] = B口压力右[i] / 10;
        //        P口压力右[i] = P口压力右[i] / 10;
        //        T口压力右[i] = T口压力右[i] / 10;
        //        纵坐标压力.Add((float)(P口压力右[i] - T口压力右[i]));
        //        横坐标流量.Add(流量计值 / 10);
        //        流量计值 = 0;
        //    }
        //    横坐标流量.ForEach(i => 稳态流量2.Add(i));
        //    纵坐标压力.ForEach(i => 稳态压力2.Add(i));
        //    横坐标流量.Clear();
        //    纵坐标压力.Clear();
        //    MessageBox.Show("请手动将被试阀置于中位");
        //    //等待用户操作完毕后再确认
        //    所做试验["稳态压差流量特性试验"] = true;
        //    MessageBox.Show("稳态压差试验已完成");
        //}


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


        public static double FloatToDouble(float i)
        {
            return Convert.ToDouble(i);
        }
        public override void GenerateReport()
        {
            WordHelper wordh = new WordHelper();
            wordh.CreateNewDocument(模板路径);
            保存路径 = 路径 + "\\report\\机动换向阀试验报告.doc";
            Dict.Add("$项目$", "机动换向阀试验");
            Dict.Add("$人员$", "章晓伟");
            Dict.Add("$日期$", "12月19日");
            wordh.InserttextValue(Dict);//写入文本
            foreach (TestType tt in 实验类型)
            {
                if (tt == TestType.耐压试验)
                {
                    Dict.Add("$P$", "20");
                    Dict.Add("$T$", "20");
                    Dict.Add("$A$", "20");
                    Dict.Add("$B$", "20");
                    wordh.InserttextValue(Dict);//写入文本
                }
                if (tt == TestType.稳态压差流量特性试验)
                {
                    图片路径 = 路径 + "\\report\\机动换向阀稳态压差流量特性试验曲线.bmp";
                    Pict.Add("$稳态压差流量特性曲线$", 图片路径);
                    稳态流量1d = Array.ConvertAll(稳态流量1.ToArray(), new Converter<float, double>(FloatToDouble));
                    稳态压力1d = Array.ConvertAll(稳态压力1.ToArray(), new Converter<float, double>(FloatToDouble));
                    稳态流量2d = Array.ConvertAll(稳态流量2.ToArray(), new Converter<float, double>(FloatToDouble));
                    稳态压力2d = Array.ConvertAll(稳态压力2.ToArray(), new Converter<float, double>(FloatToDouble));
                    double 最大值x = (稳态流量1d.Max()) > (稳态流量2d.Max()) ? (稳态流量1d.Max()) : (稳态流量2d.Max());
                    double 最大值y = (稳态压力1d.Max()) > (稳态压力2d.Max()) ? (稳态压力1d.Max()) : (稳态压力2d.Max());
                    List<double[]> args = new List<double[]> { 稳态流量1d, 稳态压力1d, 稳态流量2d, 稳态压力2d };
                    List<string> Curname = new List<string>() { "曲线1", "曲线2" };
                    ZedSave.SavePic(图片路径, "稳态压差流量特性试验", "流量(L/min)", "压力(MPa)", 0, 最大值x, 0, 最大值y, args, Curname, true);
                    稳态压力1.Clear();
                    稳态流量1.Clear();
                    稳态压力2.Clear();
                    稳态流量2.Clear();
                    Array.Clear(稳态流量1d, 0, 稳态流量1d.Length);
                    Array.Clear(稳态压力1d, 0, 稳态压力1d.Length);
                    Array.Clear(稳态流量2d, 0, 稳态流量2d.Length);
                    Array.Clear(稳态压力2d, 0, 稳态压力2d.Length);

                }
                else if (tt == TestType.内部泄漏试验)
                {
                    图片路径 = 路径 + "\\report\\机动换向阀内部泄漏试验曲线.bmp";
                    Pict.Add("$内部泄漏试验曲线$", 图片路径);
                    泄露流量1d = Array.ConvertAll(泄露流量1.ToArray(), new Converter<float, double>(FloatToDouble));
                    泄露压力1d = Array.ConvertAll(泄露压力1.ToArray(), new Converter<float, double>(FloatToDouble));
                    double 最大值x = 泄露流量1d.Max();
                    double 最大值y = 泄露压力1d.Max();
                    List<double[]> args = new List<double[]> { 泄露流量1d, 泄露压力1d };
                    List<string> Curname = new List<string>() { "曲线1" };
                    ZedSave.SavePic(图片路径, "内部泄漏试验", "流量(L/min)", "压力(MPa)", 0, 最大值x, 0, 最大值y, args, Curname, true);
                    泄露流量1.Clear();
                    泄露压力1.Clear();
                    Array.Clear(泄露流量1d, 0, 泄露流量1d.Length);
                    Array.Clear(泄露压力1d, 0, 泄露压力1d.Length);
                }
            }
            wordh.Insertpicture(Pict);//写入图片
            wordh.SaveDocument(保存路径);
            MessageBox.Show("报告已生成");
        }

        public override void SaveReportToDB()
        {
            WordHelper wordh = new WordHelper();
            wordh.CreateNewDocument(模板路径);
            保存路径 = 路径 + "\\report\\机动换向阀试验报告.doc";
            Dict.Add("$项目$", "机动换向阀试验");
            Dict.Add("$人员$", "章晓伟");
            Dict.Add("$日期$", "12月19日");
            wordh.InserttextValue(Dict);//写入文本
            foreach (TestType tt in 实验类型)
            {
                if (tt == TestType.耐压试验)
                {
                    Dict.Add("$P$", "20");
                    Dict.Add("$T$", "20");
                    Dict.Add("$A$", "20");
                    Dict.Add("$B$", "20");
                    wordh.InserttextValue(Dict);//写入文本
                }
                if (tt == TestType.稳态压差流量特性试验)
                {
                    图片路径 = 路径 + "\\report\\机动换向阀稳态压差流量特性试验曲线.bmp";
                    Pict.Add("$稳态压差流量特性曲线$", 图片路径);
                    稳态流量1d = Array.ConvertAll(稳态流量1.ToArray(), new Converter<float, double>(FloatToDouble));
                    稳态压力1d = Array.ConvertAll(稳态压力1.ToArray(), new Converter<float, double>(FloatToDouble));
                    稳态流量2d = Array.ConvertAll(稳态流量2.ToArray(), new Converter<float, double>(FloatToDouble));
                    稳态压力2d = Array.ConvertAll(稳态压力2.ToArray(), new Converter<float, double>(FloatToDouble));
                    double 最大值x = (稳态流量1d.Max()) > (稳态流量2d.Max()) ? (稳态流量1d.Max()) : (稳态流量2d.Max());
                    double 最大值y = (稳态压力1d.Max()) > (稳态压力2d.Max()) ? (稳态压力1d.Max()) : (稳态压力2d.Max());
                    List<double[]> args = new List<double[]> { 稳态流量1d, 稳态压力1d, 稳态流量2d, 稳态压力2d };
                    List<string> Curname = new List<string>() { "曲线1", "曲线2" };
                    ZedSave.SavePic(图片路径, "稳态压差流量特性试验", "流量(L/min)", "压力(MPa)", 0, 最大值x, 0, 最大值y, args, Curname, true);
                    稳态压力1.Clear();
                    稳态流量1.Clear();
                    稳态压力2.Clear();
                    稳态流量2.Clear();
                    Array.Clear(稳态流量1d, 0, 稳态流量1d.Length);
                    Array.Clear(稳态压力1d, 0, 稳态压力1d.Length);
                    Array.Clear(稳态流量2d, 0, 稳态流量2d.Length);
                    Array.Clear(稳态压力2d, 0, 稳态压力2d.Length);

                }
                else if (tt == TestType.内部泄漏试验)
                {
                    图片路径 = 路径 + "\\report\\机动换向阀内部泄漏试验曲线.bmp";
                    Pict.Add("$内部泄漏试验曲线$", 图片路径);
                    泄露流量1d = Array.ConvertAll(泄露流量1.ToArray(), new Converter<float, double>(FloatToDouble));
                    泄露压力1d = Array.ConvertAll(泄露压力1.ToArray(), new Converter<float, double>(FloatToDouble));
                    double 最大值x = 泄露流量1d.Max();
                    double 最大值y = 泄露压力1d.Max();
                    List<double[]> args = new List<double[]> { 泄露流量1d, 泄露压力1d };
                    List<string> Curname = new List<string>() { "曲线1" };
                    ZedSave.SavePic(图片路径, "内部泄漏试验", "流量(L/min)", "压力(MPa)", 0, 最大值x, 0, 最大值y, args, Curname, true);
                    泄露流量1.Clear();
                    泄露压力1.Clear();
                    Array.Clear(泄露流量1d, 0, 泄露流量1d.Length);
                    Array.Clear(泄露压力1d, 0, 泄露压力1d.Length);
                }
            }
            wordh.Insertpicture(Pict);//写入图片
            wordh.SaveDocument(保存路径);
            MessageBox.Show("报告已生成");
        }
    }

    
}
