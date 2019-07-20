using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProj.Utils
{
   public class Table
    {
         IList<double> XList { get; set; }//实验压力
        IList<double> YList { get; set; }//泄漏量
         IList<double> TList { get; set; }//时间
        IList<double> Y0List { get; set; }//量杯读数

        public double[] X
        {
            get
            {
                return XList.ToArray();
            }
        }

        public double[] Y
        {
            get
            {
                return YList.ToArray();
            }
        }
          public double[] T
        {
            get
            {
                return TList.ToArray();
            }
        }

        public double[] Y0
        {
            get
            {
                return Y0List.ToArray();
            }
        }

        public string Name { get; set; }

        public Table() {
            this.XList = new List<double>();
            this.YList = new List<double>();
            this.TList = new List<double>();
            this.Y0List = new List<double>();
        }

        public void AddPoint(double x, double y,double t, double y0)//压力，泄漏量，时间，量杯读数
        {
            this.XList.Add(x);
            this.YList.Add(y);
            this.TList.Add(t);
            this.Y0List.Add(y0);
        }

        public void AddPoint(float x, float y,float t, float y0)
        {
            this.XList.Add(x);
            this.YList.Add(y);
            this.TList.Add(t);
            this.Y0List.Add(y0);
        }
    }

    }

