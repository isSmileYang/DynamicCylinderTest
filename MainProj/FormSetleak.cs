using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProj;
using MainProj.Local;
namespace MainProj
{
    public partial class FormSetleak : Form
    {
        public int Timecount;                 
        public float 试验压力 = 0;
        public float 流量;
        public bool 是否手动 = false;
        private string ele_magnet_str = "";
        public string ele_mag = "";
        public string location = "";
       //public TestValveState elestate = TestValveState.中位;
        public FormSetleak()
        {
            InitializeComponent();
        }    
        private void Start_Click(object sender, EventArgs e)
        {
            if ((ele_magnet_str != "A" && ele_magnet_str != "B") || (location != "A" && location != "B" && location != "T") || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请检查是否已完整输入实验所需信息");
                return;
            }
            this.Timecount = Convert.ToInt32(this.textBox1.Text);
            this.试验压力 = Convert.ToSingle(this.textBox2.Text);        
            if (是否手动)
            {
                if (ele_magnet_str == "A")
                {
                    MessageBox.Show("请手动将被试阀置于左位");
                }
                else if (ele_magnet_str == "B")
                {
                    MessageBox.Show("请手动将被试阀置于右位");
                }
              
            }
           
            this.DialogResult = DialogResult.OK;
        }

        private void ele_mag_A_Click(object sender, EventArgs e)
        {
            ele_magnet_str = "A";
            ele_mag = "左位";
            //elestate = TestValveState.左位;
            ele_mag_B.Enabled = false;
        }

        private void ele_mag_B_Click(object sender, EventArgs e)
        {
            ele_magnet_str = "B";
            ele_mag = "右位";
            //elestate = TestValveState.右位;
            ele_mag_A.Enabled = false;
        }

        private void Location_A_Click(object sender, EventArgs e)
        {
            location = "A";
            Location_B.Enabled = false;
            Location_T.Enabled = false;
        }

        private void Location_B_Click(object sender, EventArgs e)
        {
            location = "B";
            Location_A.Enabled = false;
            Location_T.Enabled = false;
        }

        private void Location_T_Click(object sender, EventArgs e)
        {
            location = "T";
            Location_A.Enabled = false;
            Location_B.Enabled = false;
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
          
        }
    }
}
