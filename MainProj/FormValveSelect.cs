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
        public Dynamic_Cylinder currentTest;
        //
        //在主界面跳入该窗体的地方实例化
        // public Dynamic_Cylinder currentDevice;

        //选择动态油缸实验
        public SharedBase SelectedValve { get; set; }
        
        public FormValveSelect()
        {
            InitializeComponent();

            //context = new MainProj.Local.LocalDbContext();
            //context.Dynamic_Cylinders.Load();

            foreach (TestType xt in Dynamic_Cylinder.GetSupportedTestType())
            {
                this.checkedListBox.Items.Add(xt);
                
            }
            Dynamic_CylinderCurrentChanged(null, null);
        }

        private void OnSelect(object sender, EventArgs e)
        {
            //用来调用子类里重写了的方法的全局变量
            //this.currentDevice = new Dynamic_Cylinder();

            this.currentTest = new Dynamic_Cylinder();

            if (checkedListBox.SelectedIndex==0)
            {
                FormStart f1 = new FormStart();
                f1.Show();
                this.SelectedValve = this.Dynamic_CylinderBindingSource.Current as SharedBase;
               
                this.currentTest.testTypes.Add(TestType.试运转试验);
            }
            else if (checkedListBox.SelectedIndex == 1)
            {
                FormConfig cfm = new FormConfig();
                cfm.Show();
                this.SelectedValve = this.Dynamic_CylinderBindingSource.Current as SharedBase;
            }
            else if (checkedListBox.SelectedIndex == 2)
            {
               //想进入试验
            }
            else if (checkedListBox.SelectedIndex==3)
            {               
            }
            else if (checkedListBox.SelectedIndex == 4)
            {
                
            }
            else if (checkedListBox.SelectedIndex==5)
            {
                
            }
            else if (checkedListBox.SelectedIndex == 6)
            {
                MessageBox.Show("请调节RF1溢流阀压力为5Mpa", "进入缓冲试验,");
                this.Close();
                this.currentTest.testTypes.Add(TestType.缓冲试验);

            }
            else if (checkedListBox.SelectedIndex == 7)
            {
                
            }
            else if (tabControl.SelectedIndex == 8)
            {
                
            }
            else if(tabControl.SelectedIndex==9)
            {
               
            }
           
            //if (this.SelectedValve == null)
            //    return;
            this.DialogResult = DialogResult.OK;
            this.Close();
           
        }
        /// <summary>
        /// 重复确定被试件同时实验有效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dynamic_CylinderCurrentChanged(object sender, EventArgs e)
        {
            SharedBase vl = this.Dynamic_CylinderBindingSource.Current as SharedBase;
            if (vl == null)
                return;
            //MessageBox.Show("x");
            for (int i = 0; i < this.checkedListBox.Items.Count; i++)
            {
                if (vl.试验类型列表.Contains((TestType)this.checkedListBox.Items[i]))
                {
                    this.checkedListBox.SetItemChecked(i, true);
                }
                else
                {
                    this.checkedListBox.SetItemChecked(i, false);
                }
            }
        }
        
        //选中复选框执行
        private void OnFlowValveItemCheck(object sender, ItemCheckEventArgs e)
        { 
            SharedBase vl = this.Dynamic_CylinderBindingSource.Current as SharedBase;
            if (vl == null)
                return;
            TestType tt = (TestType)this.checkedListBox.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                if (!vl.试验类型列表.Contains(tt))
                    vl.试验类型列表.Add(tt);
            }
            else
            {
                vl.试验类型列表.Remove(tt);
            }
        }

        private void Dynamic_CylinderBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer9_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListBoxCheckValve_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Dynamic_CylinderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void relief_valveBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBoxReduceValve_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        private void FormValveSelect_Load(object sender, EventArgs e)
        {
            //asc.controllInitializeSize(this);
        }
        private void FormValveSelect_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
            //  this.WindowState = (System.Windows.Forms.FormWindowState)(2);//记录完控件的初始位置和大小后，再最大化
        }
        
        //1024 以下新加

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void direction_valveDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reduce_valveDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkedListBoxFlowValve_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 试验类型列表BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
