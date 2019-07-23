namespace MainProj
{
    partial class FormPressure
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonTheOther = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(732, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "第一步：请给比例伺服阀VDS1控制信号，使被试液压缸活塞停留在行程左/右端";
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.Location = new System.Drawing.Point(544, 120);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(127, 52);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "开始保压";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonTheOther
            // 
            this.buttonTheOther.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTheOther.Location = new System.Drawing.Point(544, 257);
            this.buttonTheOther.Name = "buttonTheOther";
            this.buttonTheOther.Size = new System.Drawing.Size(127, 47);
            this.buttonTheOther.TabIndex = 7;
            this.buttonTheOther.Text = "检查另一端";
            this.buttonTheOther.UseVisualStyleBackColor = true;
            this.buttonTheOther.Click += new System.EventHandler(this.buttonTheOther_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(28, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 100);
            this.label2.TabIndex = 1;
            this.label2.Text = "第二步：请调节RF1溢流阀的压力为15Mpa\r\n\r\n分别向工作腔施加15Mpa压力";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(28, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(476, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "第三步：保压5min，观察试液压缸有无泄漏和损坏";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(63, 271);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(304, 33);
            this.textBox1.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormPressure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 361);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonTheOther);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Name = "FormPressure";
            this.Text = "耐压试验";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonTheOther;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}