namespace MainProj
{
    partial class FormConfig
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
            this.lbDigitalMeter10 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.label7 = new System.Windows.Forms.Label();
            this.lbDigitalMeter13 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.label11 = new System.Windows.Forms.Label();
            this.记录小腔最低启动压力 = new System.Windows.Forms.Button();
            this.记录大腔最低启动压力 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lbAnalogMeter1 = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbDigitalMeter10
            // 
            this.lbDigitalMeter10.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter10.Format = "0000";
            this.lbDigitalMeter10.Location = new System.Drawing.Point(551, 256);
            this.lbDigitalMeter10.Name = "lbDigitalMeter10";
            this.lbDigitalMeter10.Renderer = null;
            this.lbDigitalMeter10.Signed = false;
            this.lbDigitalMeter10.Size = new System.Drawing.Size(111, 45);
            this.lbDigitalMeter10.TabIndex = 104;
            this.lbDigitalMeter10.Value = 0D;
            this.lbDigitalMeter10.VarName = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(104, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 22);
            this.label7.TabIndex = 103;
            this.label7.Text = "被试缸小腔压力PS1 ";
            // 
            // lbDigitalMeter13
            // 
            this.lbDigitalMeter13.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter13.Format = "0000";
            this.lbDigitalMeter13.Location = new System.Drawing.Point(118, 256);
            this.lbDigitalMeter13.Name = "lbDigitalMeter13";
            this.lbDigitalMeter13.Renderer = null;
            this.lbDigitalMeter13.Signed = false;
            this.lbDigitalMeter13.Size = new System.Drawing.Size(111, 45);
            this.lbDigitalMeter13.TabIndex = 106;
            this.lbDigitalMeter13.Value = 0D;
            this.lbDigitalMeter13.VarName = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(537, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 22);
            this.label11.TabIndex = 105;
            this.label11.Text = "被试缸大腔压力PS2";
            // 
            // 记录小腔最低启动压力
            // 
            this.记录小腔最低启动压力.Location = new System.Drawing.Point(77, 315);
            this.记录小腔最低启动压力.Name = "记录小腔最低启动压力";
            this.记录小腔最低启动压力.Size = new System.Drawing.Size(204, 41);
            this.记录小腔最低启动压力.TabIndex = 107;
            this.记录小腔最低启动压力.Text = "记录小腔最低启动压力";
            this.记录小腔最低启动压力.UseVisualStyleBackColor = true;
            this.记录小腔最低启动压力.Click += new System.EventHandler(this.记录小腔最低启动压力_Click);
            // 
            // 记录大腔最低启动压力
            // 
            this.记录大腔最低启动压力.Location = new System.Drawing.Point(504, 315);
            this.记录大腔最低启动压力.Name = "记录大腔最低启动压力";
            this.记录大腔最低启动压力.Size = new System.Drawing.Size(204, 41);
            this.记录大腔最低启动压力.TabIndex = 108;
            this.记录大腔最低启动压力.Text = "记录大腔最低启动压力";
            this.记录大腔最低启动压力.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 190);
            this.label1.TabIndex = 109;
            this.label1.Text = "\r\n小腔启动压力特性试验\r\n\r\n调整溢流阀的压力至2mpa\r\nVL1节流阀全部打开\r\nCK1高压球阀打开\r\nCK2高压球阀关闭\r\n给比例伺服阀VDS1控制信号\r\n" +
    "VL1节流阀的阀口慢慢调小";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(547, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 190);
            this.label3.TabIndex = 111;
            this.label3.Text = "\r\n大腔启动压力特性试验\r\n\r\n调整溢流阀的压力至2mpa\r\nVL1节流阀全部打开\r\nCK1高压球阀打开\r\nCK2高压球阀关闭\r\n给比例伺服阀VDS1控制信号\r\n" +
    "VL1节流阀的阀口慢慢调小";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(341, 222);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(115, 20);
            this.label38.TabIndex = 113;
            this.label38.Text = "伺服阀VDS1信号";
            // 
            // lbAnalogMeter1
            // 
            this.lbAnalogMeter1.BackColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter1.BodyColor = System.Drawing.Color.White;
            this.lbAnalogMeter1.Location = new System.Drawing.Point(300, 12);
            this.lbAnalogMeter1.MaxValue = 100D;
            this.lbAnalogMeter1.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.lbAnalogMeter1.MinValue = 0D;
            this.lbAnalogMeter1.Name = "lbAnalogMeter1";
            this.lbAnalogMeter1.NeedleColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbAnalogMeter1.Renderer = null;
            this.lbAnalogMeter1.ScaleColor = System.Drawing.Color.Black;
            this.lbAnalogMeter1.ScaleDivisions = 10;
            this.lbAnalogMeter1.ScaleSubDivisions = 10;
            this.lbAnalogMeter1.Size = new System.Drawing.Size(187, 189);
            this.lbAnalogMeter1.TabIndex = 112;
            this.lbAnalogMeter1.Value = 40D;
            this.lbAnalogMeter1.VarName = "var1";
            this.lbAnalogMeter1.ViewGlass = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 387);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.lbAnalogMeter1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.记录大腔最低启动压力);
            this.Controls.Add(this.记录小腔最低启动压力);
            this.Controls.Add(this.lbDigitalMeter13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbDigitalMeter10);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormConfig";
            this.Text = "启动压力特性实验";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter10;
        private System.Windows.Forms.Label label7;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button 记录小腔最低启动压力;
        private System.Windows.Forms.Button 记录大腔最低启动压力;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label38;
        private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter lbAnalogMeter1;
        private System.Windows.Forms.Timer timer1;
    }
}