using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using log4net;
using MainProj.Util;

namespace MainProj
{
    public partial class FormZedGraphWithSingle : Form
    {
        private ILog LOG = LogManager.GetLogger(typeof(FormZedGraphWithSingle));

        private string imageSavePath;

        public FormZedGraphWithSingle()
        {
            InitializeComponent();
        }

        public FormZedGraphWithSingle(GraphInfo info)
        {
            InitializeComponent();
            zedGraphControl1.GraphPane.Title.Text = info.Title;//设置标题内容
            zedGraphControl1.GraphPane.XAxis.Title.Text = info.XTitle;//X轴标题
            zedGraphControl1.GraphPane.YAxis.Title.Text = info.YTitle;
            
            PointPairList list1 = info.List;//数据

            zedGraphControl1.GraphPane.Title.FontSpec.Size = 18;//设置标题大小
            zedGraphControl1.GraphPane.XAxis.Title.FontSpec.Size = 14;//设置x轴标题大小
            zedGraphControl1.GraphPane.YAxis.Title.FontSpec.Size = 14;//设置y轴标题大小

            zedGraphControl1.GraphPane.CurveList.Clear();

            LineItem mycurve = zedGraphControl1.GraphPane.AddCurve(info.YTitle + "-" + info.XTitle + "图线", list1, Color.Red, SymbolType.None);//绘制图表

            if (info.hasY2)
            {
                zedGraphControl1.GraphPane.Y2Axis.Title.Text = info.Y2Title;
                PointPairList list2 = info.List2;
                zedGraphControl1.GraphPane.Y2Axis.Title.FontSpec.Size = 14;//设置y轴标题大小
                LineItem mycurve2 = zedGraphControl1.GraphPane.AddCurve(info.Y2Title + "-" + info.XTitle + "图线", list2, Color.Blue, SymbolType.None);
                mycurve2.IsY2Axis = true;
                zedGraphControl1.GraphPane.Y2Axis.IsVisible = true;
            }

            //坐标轴范围、刻度调整后需要加上下面的语句才能刷新
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();

            imageSavePath = info.imageSavePath;
        }
        //保存
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                zedGraphControl1.GetImage().Save(imageSavePath);
                LOG.Info("曲线已保存到"+imageSavePath);
            }
            catch (System.Exception ex)
            {
                LOG.Error("图片保存失败"+ex.Message);
            }
//            zedGraphControl1.SaveAs("mapmap.png");
        }
        //关闭
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
