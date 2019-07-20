namespace MainProj
{
    partial class FormStart
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.confirmAirButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.confirmButton4 = new System.Windows.Forms.Button();
            this.confirmButton3 = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.confirmButton2 = new System.Windows.Forms.Button();
            this.confirmButton1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.confirmAirButton);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.confirmButton4);
            this.groupBox1.Controls.Add(this.confirmButton3);
            this.groupBox1.Controls.Add(this.buttonConfirm);
            this.groupBox1.Controls.Add(this.confirmButton2);
            this.groupBox1.Controls.Add(this.confirmButton1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 352);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "手动提示";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(152, 281);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 42;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(21, 281);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(120, 16);
            this.label38.TabIndex = 41;
            this.label38.Text = "伺服阀VDS1信号";
            // 
            // confirmAirButton
            // 
            this.confirmAirButton.Location = new System.Drawing.Point(316, 215);
            this.confirmAirButton.Name = "confirmAirButton";
            this.confirmAirButton.Size = new System.Drawing.Size(187, 35);
            this.confirmAirButton.TabIndex = 38;
            this.confirmAirButton.Text = "已排除液压缸内的空气";
            this.confirmAirButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 223);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 37;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(21, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "位移传感器LVDT";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Location = new System.Drawing.Point(415, 281);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 41);
            this.buttonCancel.TabIndex = 40;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // confirmButton4
            // 
            this.confirmButton4.Location = new System.Drawing.Point(316, 157);
            this.confirmButton4.Name = "confirmButton4";
            this.confirmButton4.Size = new System.Drawing.Size(102, 30);
            this.confirmButton4.TabIndex = 35;
            this.confirmButton4.Text = "确认";
            this.confirmButton4.UseVisualStyleBackColor = true;
            this.confirmButton4.Click += new System.EventHandler(this.confirmButton4_Click);
            // 
            // confirmButton3
            // 
            this.confirmButton3.Location = new System.Drawing.Point(316, 111);
            this.confirmButton3.Name = "confirmButton3";
            this.confirmButton3.Size = new System.Drawing.Size(102, 30);
            this.confirmButton3.TabIndex = 34;
            this.confirmButton3.Text = "确认";
            this.confirmButton3.UseVisualStyleBackColor = true;
            this.confirmButton3.Click += new System.EventHandler(this.confirmButton3_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfirm.AutoSize = true;
            this.buttonConfirm.Location = new System.Drawing.Point(315, 281);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(81, 41);
            this.buttonConfirm.TabIndex = 39;
            this.buttonConfirm.Text = "确定";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // confirmButton2
            // 
            this.confirmButton2.Location = new System.Drawing.Point(316, 70);
            this.confirmButton2.Name = "confirmButton2";
            this.confirmButton2.Size = new System.Drawing.Size(102, 30);
            this.confirmButton2.TabIndex = 33;
            this.confirmButton2.Text = "确认";
            this.confirmButton2.UseVisualStyleBackColor = true;
            this.confirmButton2.Click += new System.EventHandler(this.confirmButton2_Click_1);
            // 
            // confirmButton1
            // 
            this.confirmButton1.Location = new System.Drawing.Point(316, 25);
            this.confirmButton1.Name = "confirmButton1";
            this.confirmButton1.Size = new System.Drawing.Size(102, 30);
            this.confirmButton1.TabIndex = 32;
            this.confirmButton1.Text = "确认";
            this.confirmButton1.UseVisualStyleBackColor = true;
            this.confirmButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(36, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "请先确认CK1和CK2球阀已关闭\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(36, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 32);
            this.label3.TabIndex = 30;
            this.label3.Text = "请断开加载缸        \r\n给比例伺服阀VDS1控制信号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(36, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "请手动调整RF1溢流阀压力至2Mpa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(36, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "请先确认CK1和CK2球阀已关闭\r\n";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 387);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormStart";
            this.Text = "试运转试验";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmButton4;
        private System.Windows.Forms.Button confirmButton3;
        private System.Windows.Forms.Button confirmButton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button confirmAirButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button confirmButton2;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}