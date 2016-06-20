namespace wirelesssacler
{
    partial class CallCurrentFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallCurrentFrom));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_callData = new CCWin.SkinControl.SkinButton();
            this.RichTextBox = new CCWin.SkinControl.RtfRichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.lb_noty = new CCWin.SkinControl.SkinLabel();
            this.lb_grop = new CCWin.SkinControl.SkinLabel();
            this.Indicator = new CCWin.SkinControl.SkinProgressIndicator();
            this.skinPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.tableLayoutPanel1);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 34);
            this.skinPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(510, 740);
            this.skinPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.RichTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 740);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_callData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 683);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 54);
            this.panel1.TabIndex = 0;
            // 
            // btn_callData
            // 
            this.btn_callData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_callData.BackColor = System.Drawing.Color.Transparent;
            this.btn_callData.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            this.btn_callData.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_callData.DownBack = null;
            this.btn_callData.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_callData.ForeColor = System.Drawing.Color.White;
            this.btn_callData.Location = new System.Drawing.Point(389, 4);
            this.btn_callData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_callData.MouseBack = null;
            this.btn_callData.Name = "btn_callData";
            this.btn_callData.NormlBack = null;
            this.btn_callData.Size = new System.Drawing.Size(93, 46);
            this.btn_callData.TabIndex = 2;
            this.btn_callData.Text = "招收";
            this.btn_callData.UseVisualStyleBackColor = false;
            this.btn_callData.Click += new System.EventHandler(this.btn_callData_Click);
            // 
            // RichTextBox
            // 
            this.RichTextBox.BackColor = System.Drawing.Color.White;
            this.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RichTextBox.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.RichTextBox.Location = new System.Drawing.Point(3, 104);
            this.RichTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.ReadOnly = true;
            this.RichTextBox.Size = new System.Drawing.Size(504, 572);
            this.RichTextBox.TabIndex = 3;
            this.RichTextBox.Text = "";
            this.RichTextBox.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            this.RichTextBox.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.skinLabel1);
            this.panel2.Controls.Add(this.lb_noty);
            this.panel2.Controls.Add(this.lb_grop);
            this.panel2.Controls.Add(this.Indicator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 94);
            this.panel2.TabIndex = 4;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.White;
            this.skinLabel1.Location = new System.Drawing.Point(3, 11);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(119, 17);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "当前查询设备序列为:";
            // 
            // lb_noty
            // 
            this.lb_noty.AutoSize = true;
            this.lb_noty.BackColor = System.Drawing.Color.Transparent;
            this.lb_noty.BorderColor = System.Drawing.Color.Transparent;
            this.lb_noty.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_noty.ForeColor = System.Drawing.Color.White;
            this.lb_noty.Location = new System.Drawing.Point(3, 53);
            this.lb_noty.Name = "lb_noty";
            this.lb_noty.Size = new System.Drawing.Size(35, 17);
            this.lb_noty.TabIndex = 6;
            this.lb_noty.Text = "提示:";
            // 
            // lb_grop
            // 
            this.lb_grop.AutoSize = true;
            this.lb_grop.BackColor = System.Drawing.Color.Transparent;
            this.lb_grop.BorderColor = System.Drawing.Color.Transparent;
            this.lb_grop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_grop.ForeColor = System.Drawing.Color.White;
            this.lb_grop.Location = new System.Drawing.Point(128, 11);
            this.lb_grop.Name = "lb_grop";
            this.lb_grop.Size = new System.Drawing.Size(23, 20);
            this.lb_grop.TabIndex = 4;
            this.lb_grop.Text = "空";
            // 
            // Indicator
            // 
            this.Indicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Indicator.BackColor = System.Drawing.Color.Transparent;
            this.Indicator.CircleColor = System.Drawing.Color.White;
            this.Indicator.Location = new System.Drawing.Point(429, 4);
            this.Indicator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Indicator.Name = "Indicator";
            this.Indicator.Percentage = 0F;
            this.Indicator.Size = new System.Drawing.Size(72, 72);
            this.Indicator.TabIndex = 5;
            this.Indicator.Text = "skinProgressIndicator1";
            // 
            // CallCurrentFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(518, 778);
            this.Controls.Add(this.skinPanel1);
            this.EffectBack = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.EffectCaption = CCWin.TitleType.EffectTitle;
            this.EffectWidth = 1;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "CallCurrentFrom";
            this.ShowBorder = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "获取设备数据";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CallCurrentFrom_FormClosing);
            this.Load += new System.EventHandler(this.CallCurrentFrom_Load);
            this.Shown += new System.EventHandler(this.CallCurrentFrom_Shown);
            this.skinPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinLabel lb_grop;
        private CCWin.SkinControl.RtfRichTextBox RichTextBox;
        private CCWin.SkinControl.SkinButton btn_callData;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinProgressIndicator Indicator;
        private CCWin.SkinControl.SkinLabel lb_noty;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}