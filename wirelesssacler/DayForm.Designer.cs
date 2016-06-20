namespace wirelesssacler
{
    partial class DayForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.daycout = new System.Windows.Forms.NumericUpDown();
            this.btn_quit = new CCWin.SkinControl.SkinButton();
            this.btn_Day = new CCWin.SkinControl.SkinButton();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.daycout)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择要查询的天数(距离今天的天数)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(218, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "天";
            // 
            // daycout
            // 
            this.daycout.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daycout.Location = new System.Drawing.Point(130, 92);
            this.daycout.Name = "daycout";
            this.daycout.Size = new System.Drawing.Size(81, 33);
            this.daycout.TabIndex = 4;
            // 
            // btn_quit
            // 
            this.btn_quit.BackColor = System.Drawing.Color.Transparent;
            this.btn_quit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_quit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_quit.DownBack = null;
            this.btn_quit.ForeColor = System.Drawing.Color.White;
            this.btn_quit.Location = new System.Drawing.Point(281, 12);
            this.btn_quit.MouseBack = null;
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.NormlBack = null;
            this.btn_quit.Size = new System.Drawing.Size(33, 23);
            this.btn_quit.TabIndex = 5;
            this.btn_quit.Text = "X";
            this.btn_quit.UseVisualStyleBackColor = false;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // btn_Day
            // 
            this.btn_Day.BackColor = System.Drawing.Color.Transparent;
            this.btn_Day.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.btn_Day.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Day.DownBack = null;
            this.btn_Day.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Day.ForeColor = System.Drawing.Color.White;
            this.btn_Day.Location = new System.Drawing.Point(222, 153);
            this.btn_Day.MouseBack = null;
            this.btn_Day.Name = "btn_Day";
            this.btn_Day.NormlBack = null;
            this.btn_Day.Size = new System.Drawing.Size(82, 34);
            this.btn_Day.TabIndex = 6;
            this.btn_Day.Text = "OK";
            this.btn_Day.UseVisualStyleBackColor = false;
            this.btn_Day.Click += new System.EventHandler(this.btn_Day_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(50, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "距离今天";
            // 
            // DayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(326, 199);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Day);
            this.Controls.Add(this.btn_quit);
            this.Controls.Add(this.daycout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(326, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(326, 199);
            this.Name = "DayForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询最近时间设备历史数据";
            ((System.ComponentModel.ISupportInitialize)(this.daycout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown daycout;
        private CCWin.SkinControl.SkinButton btn_quit;
        private CCWin.SkinControl.SkinButton btn_Day;
        private System.Windows.Forms.Label label3;
    }
}