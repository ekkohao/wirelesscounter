namespace wirelesssacler
{
    partial class Messagefrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Messagefrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_light = new CCWin.SkinControl.SkinButton();
            this.btn_cancle = new CCWin.SkinControl.SkinButton();
            this.btn_downhis = new CCWin.SkinControl.SkinButton();
            this.lb_noty = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.btn_downreal = new CCWin.SkinControl.SkinButton();
            this.btn_Look = new CCWin.SkinControl.SkinButton();
            this.tb_dev = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btn_light);
            this.panel1.Controls.Add(this.btn_cancle);
            this.panel1.Controls.Add(this.btn_downhis);
            this.panel1.Controls.Add(this.lb_noty);
            this.panel1.Controls.Add(this.skinLabel2);
            this.panel1.Controls.Add(this.btn_downreal);
            this.panel1.Controls.Add(this.btn_Look);
            this.panel1.Controls.Add(this.tb_dev);
            this.panel1.Controls.Add(this.skinLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 306);
            this.panel1.TabIndex = 0;
            // 
            // btn_light
            // 
            this.btn_light.BackColor = System.Drawing.Color.Transparent;
            this.btn_light.BaseColor = System.Drawing.Color.Transparent;
            this.btn_light.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_light.DownBack = null;
            this.btn_light.ForeColor = System.Drawing.Color.White;
            this.btn_light.Location = new System.Drawing.Point(196, 178);
            this.btn_light.MouseBack = null;
            this.btn_light.Name = "btn_light";
            this.btn_light.NormlBack = null;
            this.btn_light.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_light.Size = new System.Drawing.Size(103, 37);
            this.btn_light.TabIndex = 10;
            this.btn_light.Text = "下载动作记录";
            this.btn_light.UseVisualStyleBackColor = false;
            this.btn_light.Click += new System.EventHandler(this.btn_light_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancle.BaseColor = System.Drawing.Color.Transparent;
            this.btn_cancle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_cancle.DownBack = null;
            this.btn_cancle.ForeColor = System.Drawing.Color.White;
            this.btn_cancle.Location = new System.Drawing.Point(301, 268);
            this.btn_cancle.MouseBack = null;
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.NormlBack = null;
            this.btn_cancle.Size = new System.Drawing.Size(64, 27);
            this.btn_cancle.TabIndex = 9;
            this.btn_cancle.Text = "退出";
            this.btn_cancle.UseVisualStyleBackColor = false;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_downhis
            // 
            this.btn_downhis.BackColor = System.Drawing.Color.Transparent;
            this.btn_downhis.BaseColor = System.Drawing.Color.Transparent;
            this.btn_downhis.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_downhis.DownBack = null;
            this.btn_downhis.ForeColor = System.Drawing.Color.White;
            this.btn_downhis.Location = new System.Drawing.Point(85, 221);
            this.btn_downhis.MouseBack = null;
            this.btn_downhis.Name = "btn_downhis";
            this.btn_downhis.NormlBack = null;
            this.btn_downhis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_downhis.Size = new System.Drawing.Size(105, 38);
            this.btn_downhis.TabIndex = 8;
            this.btn_downhis.Text = "下载历史数据";
            this.btn_downhis.UseVisualStyleBackColor = false;
            this.btn_downhis.Click += new System.EventHandler(this.btn_downhis_Click);
            // 
            // lb_noty
            // 
            this.lb_noty.AutoSize = true;
            this.lb_noty.BackColor = System.Drawing.Color.Transparent;
            this.lb_noty.BorderColor = System.Drawing.Color.Transparent;
            this.lb_noty.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_noty.ForeColor = System.Drawing.Color.White;
            this.lb_noty.Location = new System.Drawing.Point(61, 122);
            this.lb_noty.Name = "lb_noty";
            this.lb_noty.Size = new System.Drawing.Size(226, 34);
            this.lb_noty.TabIndex = 7;
            this.lb_noty.Text = "下载实时数据耗时10秒，下载历史数据所\r\n需时间需要几十秒至几分钟。";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.ForeColor = System.Drawing.Color.White;
            this.skinLabel2.Location = new System.Drawing.Point(32, 105);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(35, 17);
            this.skinLabel2.TabIndex = 6;
            this.skinLabel2.Text = "提示:";
            // 
            // btn_downreal
            // 
            this.btn_downreal.BackColor = System.Drawing.Color.Transparent;
            this.btn_downreal.BaseColor = System.Drawing.Color.Transparent;
            this.btn_downreal.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_downreal.DownBack = null;
            this.btn_downreal.ForeColor = System.Drawing.Color.White;
            this.btn_downreal.Location = new System.Drawing.Point(85, 177);
            this.btn_downreal.MouseBack = null;
            this.btn_downreal.Name = "btn_downreal";
            this.btn_downreal.NormlBack = null;
            this.btn_downreal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_downreal.Size = new System.Drawing.Size(105, 38);
            this.btn_downreal.TabIndex = 5;
            this.btn_downreal.Text = "下载实时数据";
            this.btn_downreal.UseVisualStyleBackColor = false;
            this.btn_downreal.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_Look
            // 
            this.btn_Look.BackColor = System.Drawing.Color.Transparent;
            this.btn_Look.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Look.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Look.DownBack = null;
            this.btn_Look.ForeColor = System.Drawing.Color.White;
            this.btn_Look.Location = new System.Drawing.Point(196, 221);
            this.btn_Look.MouseBack = null;
            this.btn_Look.Name = "btn_Look";
            this.btn_Look.NormlBack = null;
            this.btn_Look.Size = new System.Drawing.Size(103, 38);
            this.btn_Look.TabIndex = 4;
            this.btn_Look.Text = "查看旧数据";
            this.btn_Look.UseVisualStyleBackColor = false;
            this.btn_Look.Click += new System.EventHandler(this.btn_Look_Click);
            // 
            // tb_dev
            // 
            this.tb_dev.BackColor = System.Drawing.Color.Transparent;
            this.tb_dev.DownBack = null;
            this.tb_dev.Icon = null;
            this.tb_dev.IconIsButton = false;
            this.tb_dev.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.tb_dev.IsPasswordChat = '\0';
            this.tb_dev.IsSystemPasswordChar = false;
            this.tb_dev.Lines = new string[0];
            this.tb_dev.Location = new System.Drawing.Point(64, 48);
            this.tb_dev.Margin = new System.Windows.Forms.Padding(0);
            this.tb_dev.MaxLength = 32767;
            this.tb_dev.MinimumSize = new System.Drawing.Size(28, 28);
            this.tb_dev.MouseBack = null;
            this.tb_dev.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.tb_dev.Multiline = true;
            this.tb_dev.Name = "tb_dev";
            this.tb_dev.NormlBack = null;
            this.tb_dev.Padding = new System.Windows.Forms.Padding(5);
            this.tb_dev.ReadOnly = true;
            this.tb_dev.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_dev.Size = new System.Drawing.Size(259, 56);
            // 
            // 
            // 
            this.tb_dev.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_dev.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_dev.SkinTxt.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_dev.SkinTxt.ForeColor = System.Drawing.Color.Red;
            this.tb_dev.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.tb_dev.SkinTxt.Multiline = true;
            this.tb_dev.SkinTxt.Name = "BaseText";
            this.tb_dev.SkinTxt.ReadOnly = true;
            this.tb_dev.SkinTxt.Size = new System.Drawing.Size(249, 46);
            this.tb_dev.SkinTxt.TabIndex = 0;
            this.tb_dev.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tb_dev.SkinTxt.WaterText = "";
            this.tb_dev.TabIndex = 2;
            this.tb_dev.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_dev.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tb_dev.WaterText = "";
            this.tb_dev.WordWrap = true;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.White;
            this.skinLabel1.Location = new System.Drawing.Point(15, 17);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(112, 17);
            this.skinLabel1.TabIndex = 1;
            this.skinLabel1.Text = "设备序列/安装地址:";
            // 
            // Messagefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.BorderColor = System.Drawing.Color.DodgerBlue;
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(386, 344);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MdiBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MinimizeBox = false;
            this.Name = "Messagefrm";
            this.ShowBorder = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "搜素显示界面";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CCWin.SkinControl.SkinLabel lb_noty;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinButton btn_downreal;
        private CCWin.SkinControl.SkinButton btn_Look;
        private CCWin.SkinControl.SkinTextBox tb_dev;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinButton btn_cancle;
        private CCWin.SkinControl.SkinButton btn_downhis;
        private CCWin.SkinControl.SkinButton btn_light;

    }
}