namespace MainProj
{
    partial class FormMaintainPressure
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
            this.label2 = new System.Windows.Forms.Label();
            this.continue_button = new System.Windows.Forms.Button();
            this.end_button = new System.Windows.Forms.Button();
            this.On_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(95, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "耐压实验倒计时";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 64);
            this.label2.TabIndex = 1;
            this.label2.Text = "00:00";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // continue_button
            // 
            this.continue_button.Enabled = false;
            this.continue_button.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.continue_button.Location = new System.Drawing.Point(61, 313);
            this.continue_button.Name = "continue_button";
            this.continue_button.Size = new System.Drawing.Size(114, 38);
            this.continue_button.TabIndex = 2;
            this.continue_button.Text = "继续实验";
            this.continue_button.UseVisualStyleBackColor = true;
            this.continue_button.Click += new System.EventHandler(this.continue_button_Click);
            // 
            // end_button
            // 
            this.end_button.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.end_button.Location = new System.Drawing.Point(236, 313);
            this.end_button.Name = "end_button";
            this.end_button.Size = new System.Drawing.Size(114, 38);
            this.end_button.TabIndex = 3;
            this.end_button.Text = "结束实验";
            this.end_button.UseVisualStyleBackColor = true;
            this.end_button.Click += new System.EventHandler(this.end_button_Click);
            // 
            // On_timer
            // 
            this.On_timer.Interval = 1000;
            this.On_timer.Tick += new System.EventHandler(this.On_timer_Tick);
            // 
            // FormMaintainPressure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 410);
            this.Controls.Add(this.end_button);
            this.Controls.Add(this.continue_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormMaintainPressure";
            this.Text = "耐压实验";
            this.Load += new System.EventHandler(this.FormMaintainPressure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button continue_button;
        private System.Windows.Forms.Button end_button;
        private System.Windows.Forms.Timer On_timer;
    }
}