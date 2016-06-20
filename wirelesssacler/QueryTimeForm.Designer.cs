namespace wirelesssacler
{
    partial class QueryTimeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryTimeForm));
            this.btn_qurytime = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_devnumber = new System.Windows.Forms.TextBox();
            this.tb_devaddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_devtime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_phrse = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_tongbu = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // btn_qurytime
            // 
            this.btn_qurytime.BackColor = System.Drawing.Color.Transparent;
            this.btn_qurytime.BaseColor = System.Drawing.Color.Transparent;
            this.btn_qurytime.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_qurytime.DownBack = null;
            this.btn_qurytime.ForeColor = System.Drawing.Color.White;
            this.btn_qurytime.Location = new System.Drawing.Point(271, 231);
            this.btn_qurytime.MouseBack = null;
            this.btn_qurytime.Name = "btn_qurytime";
            this.btn_qurytime.NormlBack = null;
            this.btn_qurytime.Size = new System.Drawing.Size(104, 34);
            this.btn_qurytime.TabIndex = 0;
            this.btn_qurytime.Text = "获取设备时间后";
            this.btn_qurytime.UseVisualStyleBackColor = false;
            this.btn_qurytime.Click += new System.EventHandler(this.btn_qurytime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "设备序列号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "设备地址:";
            // 
            // tb_devnumber
            // 
            this.tb_devnumber.Location = new System.Drawing.Point(98, 43);
            this.tb_devnumber.Name = "tb_devnumber";
            this.tb_devnumber.ReadOnly = true;
            this.tb_devnumber.Size = new System.Drawing.Size(257, 21);
            this.tb_devnumber.TabIndex = 3;
            // 
            // tb_devaddr
            // 
            this.tb_devaddr.Location = new System.Drawing.Point(98, 81);
            this.tb_devaddr.Name = "tb_devaddr";
            this.tb_devaddr.ReadOnly = true;
            this.tb_devaddr.Size = new System.Drawing.Size(257, 21);
            this.tb_devaddr.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(33, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "设备时间:";
            // 
            // tb_devtime
            // 
            this.tb_devtime.Location = new System.Drawing.Point(98, 166);
            this.tb_devtime.Name = "tb_devtime";
            this.tb_devtime.ReadOnly = true;
            this.tb_devtime.Size = new System.Drawing.Size(257, 21);
            this.tb_devtime.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "提示:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(84, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "点击按钮获取设备时间后确认是否校正时间";
            // 
            // tb_phrse
            // 
            this.tb_phrse.Location = new System.Drawing.Point(98, 121);
            this.tb_phrse.Name = "tb_phrse";
            this.tb_phrse.ReadOnly = true;
            this.tb_phrse.Size = new System.Drawing.Size(257, 21);
            this.tb_phrse.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(33, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "监测相位:";
            // 
            // btn_tongbu
            // 
            this.btn_tongbu.BackColor = System.Drawing.Color.Transparent;
            this.btn_tongbu.BaseColor = System.Drawing.Color.Transparent;
            this.btn_tongbu.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_tongbu.DownBack = null;
            this.btn_tongbu.ForeColor = System.Drawing.Color.White;
            this.btn_tongbu.Location = new System.Drawing.Point(157, 231);
            this.btn_tongbu.MouseBack = null;
            this.btn_tongbu.Name = "btn_tongbu";
            this.btn_tongbu.NormlBack = null;
            this.btn_tongbu.Size = new System.Drawing.Size(100, 34);
            this.btn_tongbu.TabIndex = 11;
            this.btn_tongbu.Text = "立即同步时间";
            this.btn_tongbu.UseVisualStyleBackColor = false;
            this.btn_tongbu.Click += new System.EventHandler(this.btn_tongbu_Click);
            // 
            // QueryTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(397, 272);
            this.Controls.Add(this.btn_tongbu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_phrse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_devtime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_devaddr);
            this.Controls.Add(this.tb_devnumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_qurytime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QueryTimeForm";
            this.ShowBorder = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "获取设备时间";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.QueryTimeForm_Load);
            this.Shown += new System.EventHandler(this.QueryTimeForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton btn_qurytime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_devnumber;
        private System.Windows.Forms.TextBox tb_devaddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_devtime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_phrse;
        private System.Windows.Forms.Label label6;
        private CCWin.SkinControl.SkinButton btn_tongbu;
    }
}