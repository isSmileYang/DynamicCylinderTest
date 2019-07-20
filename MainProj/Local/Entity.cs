using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace MainProj.Local
{
    public class Test
    {
        public int Id { get; set; }
        public string 序列号 { get; set; }
        public string 试验台 { get; set; }
        public string 试验设备 { get; set; }
        public string 设备型号 { get; set; }
        public string 试验时间 { get; set; }
        public byte[] 试验报告 { get; set; }
        public byte[] 试验数据 { get; set; }
    }
    
    public class Alarm
    {
        public int Id { get; set; }
        public string PLC { get; set; }
        public string Variable { get; set; }
        public string Value { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public int Rank { get; set; }
        public bool Confirm { get; set; }
        public bool Recover { get; set; }
    }

    public class DataForm
    {
        public int Id { get; set; }
        public DateTime timestamp { get; set; }
        public string varname { get; set; }
        public double Data { get; set; }

    }
}
