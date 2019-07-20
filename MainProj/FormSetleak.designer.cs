namespace MainProj
{
    partial class FormSetleak
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
            this.label1 = new System.Windows.Forms.Label();
            this.ele_mag_A = new System.Windows.Forms.Button();
            this.ele_mag_B = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Location_A = new System.Windows.Forms.Button();
            this.Location_B = new System.Windows.Forms.Button();
            this.Location_T = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Finish = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "电磁铁接通或先导油情况：";
            // 
            // ele_mag_A
            // 
            this.ele_mag_A.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ele_mag_A.Location = new System.Drawing.Point(253, 69);
            this.ele_mag_A.Name = "ele_mag_A";
            this.ele_mag_A.Size = new System.Drawing.Size(44, 58);
            this.ele_mag_A.TabIndex = 1;
            this.ele_mag_A.Text = "A";
            this.ele_mag_A.UseVisualStyleBackColor = true;
            this.ele_mag_A.Click += new System.EventHandler(this.ele_mag_A_Click);
            // 
            // ele_mag_B
            // 
            this.ele_mag_B.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ele_mag_B.Location = new System.Drawing.Point(358, 69);
            this.ele_mag_B.Name = "ele_mag_B";
            this.ele_mag_B.Size = new System.Drawing.Size(42, 58);
            this.ele_mag_B.TabIndex = 2;
            this.ele_mag_B.Text = "B";
            this.ele_mag_B.UseVisualStyleBackColor = true;
            this.ele_mag_B.Click += new System.EventHandler(this.ele_mag_B_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "接油口位置选择";
            // 
            // Location_A
            // 
            this.Location_A.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location_A.Location = new System.Drawing.Point(253, 162);
            this.Location_A.Name = "Location_A";
            this.Location_A.Size = new System.Drawing.Size(44, 49);
            this.Location_A.TabIndex = 5;
            this.Location_A.Text = "A";
            this.Location_A.UseVisualStyleBackColor = true;
            this.Location_A.Click += new System.EventHandler(this.Location_A_Click);
            // 
            // Location_B
            // 
            this.Location_B.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location_B.Location = new System.Drawing.Point(358, 162);
            this.Location_B.Name = "Location_B";
            this.Location_B.Size = new System.Drawing.Size(42, 49);
            this.Location_B.TabIndex = 6;
            this.Location_B.Text = "B";
            this.Location_B.UseVisualStyleBackColor = true;
            this.Location_B.Click += new System.EventHandler(this.Location_B_Click);
            // 
            // Location_T
            // 
            this.Location_T.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location_T.Location = new System.Drawing.Point(462, 162);
            this.Location_T.Name = "Location_T";
            this.Location_T.Size = new System.Drawing.Size(39, 49);
            this.Location_T.TabIndex = 7;
            this.Location_T.Text = "T";
            this.Location_T.UseVisualStyleBackColor = true;
            this.Location_T.Click += new System.EventHandler(this.Location_T_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 38);
            this.label3.TabIndex = 8;
            this.label3.Text = "请设置实验时间";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(253, 270);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 41);
            this.textBox1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 38);
            this.label4.TabIndex = 10;
            this.label4.Text = "请设置实验压力";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(253, 361);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(209, 41);
            this.textBox2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(468, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 38);
            this.label5.TabIndex = 12;
            this.label5.Text = "秒";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(468, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 38);
            this.label6.TabIndex = 13;
            this.label6.Text = "兆帕";
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start.Location = new System.Drawing.Point(19, 465);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(169, 58);
            this.Start.TabIndex = 14;
            this.Start.Text = "启动实验";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Finish
            // 
            this.Finish.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Finish.Location = new System.Drawing.Point(358, 465);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(169, 58);
            this.Finish.TabIndex = 15;
            this.Finish.Text = "结束实验";
            this.Finish.UseVisualStyleBackColor = true;
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(7, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(322, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "A表示阀芯在左位，B表示阀芯在右位";
            // 
            // FormSetleak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 554);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Location_T);
            this.Controls.Add(this.Location_B);
            this.Controls.Add(this.Location_A);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ele_mag_B);
            this.Controls.Add(this.ele_mag_A);
            this.Controls.Add(this.label1);
            this.Name = "FormSetleak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置内泄漏试验参数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ele_mag_A;
        private System.Windows.Forms.Button ele_mag_B;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Location_A;
        private System.Windows.Forms.Button Location_B;
        private System.Windows.Forms.Button Location_T;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Finish;
        private System.Windows.Forms.Label label7;
    }
}