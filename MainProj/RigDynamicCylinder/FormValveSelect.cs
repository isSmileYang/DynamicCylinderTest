using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using MainProj.Local;
using MainProj;



namespace MainProj
{

    public partial class FormValveSelect : Form
    {

        AutoSizeFormClass asc = new AutoSizeFormClass();
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(FormValveSelect));
        MainProj.Local.LocalDbContext context;
        //创建动态油缸子类对象
        public Dynamic_Cylinder currentTest;
        // Dynamic_Cylinder TestType = new Dynamic_Cylinder();

        //选择动态油缸实验
        public Dynamic_Cylinder SelectedValve { get; set; }

        public FormValveSelect()
        {
            InitializeComponent();
            //context = new MainProj.Local.LocalDbContext();
            //context.Dynamic_Cylinders.Load();
            foreach (TestType xt in Dynamic_Cylinder.GetSupportedTestType())
            {
                this.checkedListBox.Items.Add(xt);

            }
            //Dynamic_CylinderCurrentChanged(null, null);
        }

        private void OnSelect(object sender, EventArgs e)
        {
            //用来调用子类里重写了的方法的全局变量
            //this.currentDevice = new Dynamic_Cylinder();
            ////动态油缸子类对象实例化
            this.currentTest = new Dynamic_Cylinder();

            if (checkedListBox.SelectedIndex == 0)
            {
                //  this.currentTest.试验类型.Add(TestType.试运转试验);
                // public static int Num = 0;
                this.currentTest.StartWorkTest();
            }
            else if (checkedListBox.SelectedIndex == 1)
            {
                this.currentTest.StartPressureTest();
               
            }
            else if (checkedListBox.SelectedIndex == 2)
            {
                 this.currentTest.PressTest();
               
            }
            else if (checkedListBox.SelectedIndex == 3)
            {
                this.currentTest.EnduranceTest();
            }
            else if (checkedListBox.SelectedIndex == 4)
            {
            }
            else if (checkedListBox.SelectedIndex == 5)
            {
         
            }
            else if (checkedListBox.SelectedIndex == 6)
            {
                MessageBox.Show("请调节RF1溢流阀压力为5Mpa", "进入缓冲试验");
                this.Close();
                this.currentTest.StartBufferTest();
                //this.currentTest.Items.Add(TestType.缓冲试验);
            }
            else if (checkedListBox.SelectedIndex == 7)
            {

            }
            else if (checkedListBox.SelectedIndex == 8)
            {
                this.currentTest.LoadEfficiencyTest();
                MessageBox.Show("进入负载实验", "进入负载实验");
                // this.currentTest.Items.Add(TestType.负载效率试验);
                // this.Close();
            }
            else if (checkedListBox.SelectedIndex == 9)
            {
                //this.currentTest.testTypes.Add(TestType.负载效率试验);
                this.currentTest.LoadEfficiencyTest();

            }

            //if (this.SelectedValve == null)
            //    return;
           // this.DialogResult = DialogResult.OK;
            //this.Close();
        }
        /// <summary>
        /// 重复确定被试件同时实验有效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Dynamic_CylinderCurrentChanged(object sender, EventArgs e)
        //{

        //    if (currentTest == null)
        //        return;
        //    //MessageBox.Show("x");
        //    for (int i = 0; i < this.checkedListBox.Items.Count; i++)
        //    {
        //        if (currentTest.试验类型列表.Contains((TestType)this.checkedListBox.Items[i]))
        //        {
        //            this.checkedListBox.SetItemChecked(i, true);
        //        }
        //        else
        //        {
        //            this.checkedListBox.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //选中复选框执行
        //private void OnFlowValveItemCheck(object sender, ItemCheckEventArgs e)
        //{ 
        //    //SharedBase vl = this.Dynamic_CylinderBindingSource.Current as SharedBase;
        //    if (currentTest == null)
        //        return;
        //    TestType tt = (TestType)this.checkedListBox.Items[e.Index];
        //    if (e.NewValue == CheckState.Checked)
        //    {
        //        if (!currentTest.试验类型列表.Contains(tt))
        //            currentTest.试验类型列表.Add(tt);
        //    }
        //    else
        //    {
        //        currentTest.试验类型列表.Remove(tt);
        //    }
        //}

        private void Dynamic_CylinderBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

   

        private void Dynamic_CylinderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
