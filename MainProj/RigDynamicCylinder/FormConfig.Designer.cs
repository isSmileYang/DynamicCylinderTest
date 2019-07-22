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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbDigitalMeter10
            // 
            this.lbDigitalMeter10.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter10.Format = "0000";
            this.lbDigitalMeter10.Location = new System.Drawing.Point(551, 237);
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
            this.label7.Location = new System.Drawing.Point(104, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 22);
            this.label7.TabIndex = 103;
            this.label7.Text = "被试缸小腔压力PS1 ";
            // 
            // lbDigitalMeter13
            // 
            this.lbDigitalMeter13.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter13.Format = "0000";
            this.lbDigitalMeter13.Location = new System.Drawing.Point(118, 237);
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
            this.label11.Location = new System.Drawing.Point(537, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 22);
            this.label11.TabIndex = 105;
            this.label11.Text = "被试缸大腔压力PS2";
            // 
            // 记录小腔最低启动压力
            // 
            this.记录小腔最低启动压力.Location = new System.Drawing.Point(77, 296);
            this.记录小腔最低启动压力.Name = "记录小腔最低启动压力";
            this.记录小腔最低启动压力.Size = new System.Drawing.Size(204, 41);
            this.记录小腔最低启动压力.TabIndex = 107;
            this.记录小腔最低启动压力.Text = "记录小腔最低启动压力";
            this.记录小腔最低启动压力.UseVisualStyleBackColor = true;
            this.记录小腔最低启动压力.Click += new System.EventHandler(this.记录小腔最低启动压力_Click);
            // 
            // 记录大腔最低启动压力
            // 
            this.记录大腔最低启动压力.Location = new System.Drawing.Point(504, 296);
            this.记录大腔最低启动压力.Name = "记录大腔最低启动压力";
            this.记录大腔最低启动压力.Size = new System.Drawing.Size(204, 41);
            this.记录大腔最低启动压力.TabIndex = 108;
            this.记录大腔最低启动压力.Text = "记录大腔最低启动压力";
            this.记录大腔最低启动压力.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(230, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 99);
            this.label1.TabIndex = 109;
            this.label1.Text = "                    启动压力特性试验\r\n手动调溢流阀压力至2mpa，VL1节流阀全部打开\r\nCK1高压球阀打开，CK2高压球阀关闭\r\n给比例伺" +
    "服阀VDS1控制信号，VL1阀口慢慢调小";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(471, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(283, 74);
            this.label3.TabIndex = 111;
            this.label3.Text = "\r\n     被试液压缸大腔启动压力特性\r\n使被试缸大腔压力逐渐升高至缸启动";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(54, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 74);
            this.label2.TabIndex = 112;
            this.label2.Text = "\r\n     被试液压缸小腔启动压力特性\r\n使被试缸大腔压力逐渐升高至缸启动";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 387);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}