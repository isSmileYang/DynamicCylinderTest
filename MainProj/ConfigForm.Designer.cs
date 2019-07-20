namespace MainProj
{
    partial class ConfigForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbLed3 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.lbLed4 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.lbLed1 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLed2 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbDigitalMeter6 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigitalMeter5 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigitalMeter4 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigitalMeter3 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigitalMeter2 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigitalMeter1 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbDigitalMeter10 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button大缸伸出预备 = new System.Windows.Forms.Button();
            this.button小缸伸出预备 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lbLed3);
            this.groupBox1.Controls.Add(this.lbLed4);
            this.groupBox1.Controls.Add(this.lbLed1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbLed2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "球阀状态检查";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(688, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 35);
            this.button1.TabIndex = 59;
            this.button1.Text = "确认实验参数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbLed3
            // 
            this.lbLed3.BackColor = System.Drawing.Color.Transparent;
            this.lbLed3.BlinkInterval = 500;
            this.lbLed3.Label = "";
            this.lbLed3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.lbLed3.LedColor = System.Drawing.Color.Red;
            this.lbLed3.LedSize = new System.Drawing.SizeF(17F, 17F);
            this.lbLed3.Location = new System.Drawing.Point(408, 27);
            this.lbLed3.Name = "lbLed3";
            this.lbLed3.Renderer = null;
            this.lbLed3.Size = new System.Drawing.Size(25, 21);
            this.lbLed3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed3.TabIndex = 58;
            this.lbLed3.VarName = null;
            // 
            // lbLed4
            // 
            this.lbLed4.BackColor = System.Drawing.Color.Transparent;
            this.lbLed4.BlinkInterval = 500;
            this.lbLed4.Label = "";
            this.lbLed4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.lbLed4.LedColor = System.Drawing.Color.Red;
            this.lbLed4.LedSize = new System.Drawing.SizeF(17F, 17F);
            this.lbLed4.Location = new System.Drawing.Point(408, 47);
            this.lbLed4.Name = "lbLed4";
            this.lbLed4.Renderer = null;
            this.lbLed4.Size = new System.Drawing.Size(25, 21);
            this.lbLed4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed4.TabIndex = 57;
            this.lbLed4.VarName = null;
            // 
            // lbLed1
            // 
            this.lbLed1.BackColor = System.Drawing.Color.Transparent;
            this.lbLed1.BlinkInterval = 500;
            this.lbLed1.Label = "";
            this.lbLed1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.lbLed1.LedColor = System.Drawing.Color.Red;
            this.lbLed1.LedSize = new System.Drawing.SizeF(17F, 17F);
            this.lbLed1.Location = new System.Drawing.Point(294, 27);
            this.lbLed1.Name = "lbLed1";
            this.lbLed1.Renderer = null;
            this.lbLed1.Size = new System.Drawing.Size(25, 21);
            this.lbLed1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed1.TabIndex = 56;
            this.lbLed1.VarName = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(335, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 55;
            this.label5.Text = "T2口阀：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(335, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 54;
            this.label4.Text = "P2口阀：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(229, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 53;
            this.label3.Text = "T1口阀：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(229, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "P1口阀：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "开始检查试验台球阀状态：";
            // 
            // lbLed2
            // 
            this.lbLed2.BackColor = System.Drawing.Color.Transparent;
            this.lbLed2.BlinkInterval = 500;
            this.lbLed2.Label = "";
            this.lbLed2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.lbLed2.LedColor = System.Drawing.Color.Red;
            this.lbLed2.LedSize = new System.Drawing.SizeF(17F, 17F);
            this.lbLed2.Location = new System.Drawing.Point(294, 47);
            this.lbLed2.Name = "lbLed2";
            this.lbLed2.Renderer = null;
            this.lbLed2.Size = new System.Drawing.Size(25, 21);
            this.lbLed2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed2.TabIndex = 50;
            this.lbLed2.VarName = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbDigitalMeter6);
            this.groupBox2.Controls.Add(this.lbDigitalMeter5);
            this.groupBox2.Controls.Add(this.lbDigitalMeter4);
            this.groupBox2.Controls.Add(this.lbDigitalMeter3);
            this.groupBox2.Controls.Add(this.lbDigitalMeter2);
            this.groupBox2.Controls.Add(this.lbDigitalMeter1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lbDigitalMeter10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 155);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "压力传感器读数";
            // 
            // lbDigitalMeter6
            // 
            this.lbDigitalMeter6.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter6.Format = "0000";
            this.lbDigitalMeter6.Location = new System.Drawing.Point(442, 115);
            this.lbDigitalMeter6.Name = "lbDigitalMeter6";
            this.lbDigitalMeter6.Renderer = null;
            this.lbDigitalMeter6.Signed = false;
            this.lbDigitalMeter6.Size = new System.Drawing.Size(67, 31);
            this.lbDigitalMeter6.TabIndex = 118;
            this.lbDigitalMeter6.Value = 0D;
            this.lbDigitalMeter6.VarName = null;
            // 
            // lbDigitalMeter5
            // 
            this.lbDigitalMeter5.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter5.Format = "0000";
            this.lbDigitalMeter5.Location = new System.Drawing.Point(255, 115);
            this.lbDigitalMeter5.Name = "lbDigitalMeter5";
            this.lbDigitalMeter5.Renderer = null;
            this.lbDigitalMeter5.Signed = false;
            this.lbDigitalMeter5.Size = new System.Drawing.Size(67, 31);
            this.lbDigitalMeter5.TabIndex = 117;
            this.lbDigitalMeter5.Value = 0D;
            this.lbDigitalMeter5.VarName = null;
            // 
            // lbDigitalMeter4
            // 
            this.lbDigitalMeter4.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter4.Format = "0000";
            this.lbDigitalMeter4.Location = new System.Drawing.Point(57, 115);
            this.lbDigitalMeter4.Name = "lbDigitalMeter4";
            this.lbDigitalMeter4.Renderer = null;
            this.lbDigitalMeter4.Signed = false;
            this.lbDigitalMeter4.Size = new System.Drawing.Size(67, 31);
            this.lbDigitalMeter4.TabIndex = 116;
            this.lbDigitalMeter4.Value = 0D;
            this.lbDigitalMeter4.VarName = null;
            // 
            // lbDigitalMeter3
            // 
            this.lbDigitalMeter3.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter3.Format = "0000";
            this.lbDigitalMeter3.Location = new System.Drawing.Point(637, 56);
            this.lbDigitalMeter3.Name = "lbDigitalMeter3";
            this.lbDigitalMeter3.Renderer = null;
            this.lbDigitalMeter3.Signed = false;
            this.lbDigitalMeter3.Size = new System.Drawing.Size(67, 31);
            this.lbDigitalMeter3.TabIndex = 115;
            this.lbDigitalMeter3.Value = 0D;
            this.lbDigitalMeter3.VarName = null;
            // 
            // lbDigitalMeter2
            // 
            this.lbDigitalMeter2.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter2.Format = "0000";
            this.lbDigitalMeter2.Location = new System.Drawing.Point(442, 56);
            this.lbDigitalMeter2.Name = "lbDigitalMeter2";
            this.lbDigitalMeter2.Renderer = null;
            this.lbDigitalMeter2.Signed = false;
            this.lbDigitalMeter2.Size = new System.Drawing.Size(67, 31);
            this.lbDigitalMeter2.TabIndex = 114;
            this.lbDigitalMeter2.Value = 0D;
            this.lbDigitalMeter2.VarName = null;
            // 
            // lbDigitalMeter1
            // 
            this.lbDigitalMeter1.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter1.Format = "0000";
            this.lbDigitalMeter1.Location = new System.Drawing.Point(255, 56);
            this.lbDigitalMeter1.Name = "lbDigitalMeter1";
            this.lbDigitalMeter1.Renderer = null;
            this.lbDigitalMeter1.Signed = false;
            this.lbDigitalMeter1.Size = new System.Drawing.Size(67, 31);
            this.lbDigitalMeter1.TabIndex = 113;
            this.lbDigitalMeter1.Value = 0D;
            this.lbDigitalMeter1.VarName = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(418, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 22);
            this.label12.TabIndex = 112;
            this.label12.Text = "负载调整压力PS3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(229, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 22);
            this.label10.TabIndex = 111;
            this.label10.Text = "负载基准压力PS2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(32, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 22);
            this.label7.TabIndex = 106;
            this.label7.Text = "负载系统压力PS1 ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(609, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 22);
            this.label11.TabIndex = 107;
            this.label11.Text = "被试系统压力PS4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(32, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 22);
            this.label6.TabIndex = 105;
            this.label6.Text = "被试缸试验压力PS5";
            // 
            // lbDigitalMeter10
            // 
            this.lbDigitalMeter10.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter10.Format = "0000";
            this.lbDigitalMeter10.Location = new System.Drawing.Point(57, 56);
            this.lbDigitalMeter10.Name = "lbDigitalMeter10";
            this.lbDigitalMeter10.Renderer = null;
            this.lbDigitalMeter10.Signed = false;
            this.lbDigitalMeter10.Size = new System.Drawing.Size(67, 31);
            this.lbDigitalMeter10.TabIndex = 110;
            this.lbDigitalMeter10.Value = 0D;
            this.lbDigitalMeter10.VarName = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(229, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 22);
            this.label8.TabIndex = 108;
            this.label8.Text = "被试缸B腔压力PS6 ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(418, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 22);
            this.label9.TabIndex = 109;
            this.label9.Text = "被试缸A腔压力PS7 ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button大缸伸出预备);
            this.groupBox3.Controls.Add(this.button小缸伸出预备);
            this.groupBox3.Location = new System.Drawing.Point(13, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 70);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "液压缸控制";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(260, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "小缸伸出预备";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button大缸伸出预备
            // 
            this.button大缸伸出预备.Enabled = false;
            this.button大缸伸出预备.Location = new System.Drawing.Point(146, 19);
            this.button大缸伸出预备.Name = "button大缸伸出预备";
            this.button大缸伸出预备.Size = new System.Drawing.Size(92, 32);
            this.button大缸伸出预备.TabIndex = 1;
            this.button大缸伸出预备.Text = "大缸伸出预备";
            this.button大缸伸出预备.UseVisualStyleBackColor = true;
            this.button大缸伸出预备.Click += new System.EventHandler(this.button大缸伸出预备_Click);
            // 
            // button小缸伸出预备
            // 
            this.button小缸伸出预备.Enabled = false;
            this.button小缸伸出预备.Location = new System.Drawing.Point(32, 20);
            this.button小缸伸出预备.Name = "button小缸伸出预备";
            this.button小缸伸出预备.Size = new System.Drawing.Size(92, 32);
            this.button小缸伸出预备.TabIndex = 0;
            this.button小缸伸出预备.Text = "小缸伸出预备";
            this.button小缸伸出预备.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 625);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLed2;
        private System.Windows.Forms.Button button1;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLed3;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLed4;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLed1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter6;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter5;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter4;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter3;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter2;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button大缸伸出预备;
        private System.Windows.Forms.Button button小缸伸出预备;
    }
}