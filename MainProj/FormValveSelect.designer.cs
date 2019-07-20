namespace MainProj
{
    partial class FormValveSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormValveSelect));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Dynamic_CylinderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkvalveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.elemagdirectionvalveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.electrohydvalveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hydraulicvalveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.manualvalveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mechoperavalveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reduce_valveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.relief_valveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.propodirectionvalveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hydcheckvalveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.试验类型列表BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.miniToolStrip = new System.Windows.Forms.BindingNavigator(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reduce_valveBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.reduce_valveDataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.Dynamic_CylinderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkvalveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemagdirectionvalveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.electrohydvalveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hydraulicvalveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manualvalveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mechoperavalveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reduce_valveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relief_valveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propodirectionvalveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hydcheckvalveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.试验类型列表BindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reduce_valveBindingNavigator)).BeginInit();
            this.reduce_valveBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reduce_valveDataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dynamic_CylinderBindingSource
            // 
            this.Dynamic_CylinderBindingSource.DataSource = typeof(MainProj.Local.Dynamic_Cylinder);
            this.Dynamic_CylinderBindingSource.CurrentChanged += new System.EventHandler(this.Dynamic_CylinderCurrentChanged);
            // 
            // 试验类型列表BindingSource
            // 
            this.试验类型列表BindingSource.DataMember = "试验类型列表";
            this.试验类型列表BindingSource.DataSource = this.elemagdirectionvalveBindingSource;
            this.试验类型列表BindingSource.CurrentChanged += new System.EventHandler(this.试验类型列表BindingSource_CurrentChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(81, 44);
            this.toolStripButton1.Text = "选择";
            this.toolStripButton1.Click += new System.EventHandler(this.OnSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1020, 47);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "新项选择";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AddNewItem = null;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.CountItem = null;
            this.miniToolStrip.DeleteItem = null;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.miniToolStrip.Location = new System.Drawing.Point(207, 4);
            this.miniToolStrip.MoveFirstItem = null;
            this.miniToolStrip.MoveLastItem = null;
            this.miniToolStrip.MoveNextItem = null;
            this.miniToolStrip.MovePreviousItem = null;
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.PositionItem = null;
            this.miniToolStrip.Size = new System.Drawing.Size(210, 27);
            this.miniToolStrip.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reduce_valveBindingNavigator);
            this.tabPage1.Controls.Add(this.splitContainer10);
            this.tabPage1.Controls.Add(this.reduce_valveDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1012, 503);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "动态油缸";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reduce_valveBindingNavigator
            // 
            this.reduce_valveBindingNavigator.AddNewItem = null;
            this.reduce_valveBindingNavigator.CountItem = this.bindingNavigatorCountItem1;
            this.reduce_valveBindingNavigator.DeleteItem = null;
            this.reduce_valveBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.reduce_valveBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5});
            this.reduce_valveBindingNavigator.Location = new System.Drawing.Point(4, 236);
            this.reduce_valveBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.reduce_valveBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.reduce_valveBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.reduce_valveBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.reduce_valveBindingNavigator.Name = "reduce_valveBindingNavigator";
            this.reduce_valveBindingNavigator.PositionItem = this.bindingNavigatorPositionItem1;
            this.reduce_valveBindingNavigator.Size = new System.Drawing.Size(1004, 27);
            this.reduce_valveBindingNavigator.TabIndex = 3;
            this.reduce_valveBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(32, 24);
            this.bindingNavigatorCountItem1.Text = "/ {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "总项数";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem1.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem1.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "位置";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem1.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem1.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // splitContainer10
            // 
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer10.Location = new System.Drawing.Point(4, 5);
            this.splitContainer10.Name = "splitContainer10";
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.AllowDrop = true;
            this.splitContainer10.Panel1.AutoScroll = true;
            this.splitContainer10.Panel1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.splitContainer10.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer10.Panel1.BackgroundImage = global::MainProj.Properties.Resources.动态油缸液压原理图;
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.checkedListBox);
            this.splitContainer10.Size = new System.Drawing.Size(1004, 231);
            this.splitContainer10.SplitterDistance = 460;
            this.splitContainer10.TabIndex = 2;
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(540, 231);
            this.checkedListBox.TabIndex = 0;
            // 
            // reduce_valveDataGridView
            // 
            this.reduce_valveDataGridView.AutoGenerateColumns = false;
            this.reduce_valveDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reduce_valveDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.reduce_valveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reduce_valveDataGridView.DataSource = this.reduce_valveBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.reduce_valveDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.reduce_valveDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reduce_valveDataGridView.Location = new System.Drawing.Point(4, 328);
            this.reduce_valveDataGridView.Name = "reduce_valveDataGridView";
            this.reduce_valveDataGridView.RowTemplate.Height = 23;
            this.reduce_valveDataGridView.Size = new System.Drawing.Size(1004, 170);
            this.reduce_valveDataGridView.TabIndex = 1;
            this.reduce_valveDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reduce_valveDataGridView_CellContentClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 47);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1020, 536);
            this.tabControl.TabIndex = 0;
            // 
            // FormValveSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 583);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormValveSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormValveSelect";
            this.Load += new System.EventHandler(this.FormValveSelect_Load);
            this.SizeChanged += new System.EventHandler(this.FormValveSelect_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Dynamic_CylinderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkvalveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemagdirectionvalveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.electrohydvalveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hydraulicvalveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manualvalveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mechoperavalveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reduce_valveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relief_valveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propodirectionvalveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hydcheckvalveBindingSource)).EndInit();
           // ((System.ComponentModel.ISupportInitialize)(this.试验类型列表BindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reduce_valveBindingNavigator)).EndInit();
            this.reduce_valveBindingNavigator.ResumeLayout(false);
            this.reduce_valveBindingNavigator.PerformLayout();
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reduce_valveDataGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource Dynamic_CylinderBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 型号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 制造商DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn p口耐压DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn t口耐压DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn a口耐压DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn b口耐压DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 额定压力DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 额定流量DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 外泄漏口DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 试验类型列表DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.BindingSource elemagdirectionvalveBindingSource;
        private System.Windows.Forms.BindingSource mechoperavalveBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.BindingSource electrohydvalveBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.BindingSource hydraulicvalveBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        private System.Windows.Forms.BindingSource manualvalveBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private System.Windows.Forms.BindingSource checkvalveBindingSource;
        private System.Windows.Forms.BindingSource reduce_valveBindingSource;
        private System.Windows.Forms.BindingSource relief_valveBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 额定电压DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource propodirectionvalveBindingSource;
        private System.Windows.Forms.BindingSource hydcheckvalveBindingSource;
        private System.Windows.Forms.BindingSource 试验类型列表BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.BindingNavigator miniToolStrip;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.BindingNavigator reduce_valveBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.DataGridView reduce_valveDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn79;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn81;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn82;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn83;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn84;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn85;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn86;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn87;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 有外泄漏口DataGridViewCheckBoxColumn2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.SplitContainer splitContainer10;
        private System.Windows.Forms.CheckedListBox checkedListBox;
    }
}