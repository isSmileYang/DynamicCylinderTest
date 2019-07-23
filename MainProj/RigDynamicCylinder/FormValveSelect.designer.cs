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
            this.Dynamic_CylinderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.试验类型列表BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.Dynamic_CylinderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.试验类型列表BindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // 试验类型列表BindingSource
            // 
            this.试验类型列表BindingSource.DataMember = "试验类型列表";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(109, 44);
            this.toolStripButton1.Text = "开始试验";
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
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer10);
            this.tabPage1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1012, 503);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "动态油缸";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.splitContainer10.Size = new System.Drawing.Size(1004, 490);
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
            this.checkedListBox.Size = new System.Drawing.Size(540, 490);
            this.checkedListBox.TabIndex = 0;
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
            this.Text = "动态油缸试验选择";
            ((System.ComponentModel.ISupportInitialize)(this.Dynamic_CylinderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.试验类型列表BindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private System.Windows.Forms.DataGridViewTextBoxColumn 额定电压DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource 试验类型列表BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabPage tabPage1;
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