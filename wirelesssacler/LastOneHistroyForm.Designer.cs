namespace wirelesssacler
{
    partial class LastOneHistroyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LastOneHistroyForm));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RichTextBox = new CCWin.SkinControl.RtfRichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LastDayCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_callData = new CCWin.SkinControl.SkinButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Indicator = new CCWin.SkinControl.SkinProgressIndicator();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.lb_grop = new CCWin.SkinControl.SkinLabel();
            this.lb_noty = new CCWin.SkinControl.SkinLabel();
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
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(510, 740);
            this.skinPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.RichTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.48183F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.51817F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 740);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // RichTextBox
            // 
            this.RichTextBox.BackColor = System.Drawing.Color.White;
            this.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RichTextBox.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.RichTextBox.Location = new System.Drawing.Point(3, 101);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.ReadOnly = true;
            this.RichTextBox.Size = new System.Drawing.Size(504, 529);
            this.RichTextBox.TabIndex = 3;
            this.RichTextBox.Text = "";
            this.RichTextBox.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.LastDayCount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btn_callData);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 636);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 101);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(98, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 26);
            this.button1.TabIndex = 15;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(179, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 26);
            this.button2.TabIndex = 14;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LastDayCount
            // 
            this.LastDayCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LastDayCount.Location = new System.Drawing.Point(128, 55);
            this.LastDayCount.Name = "LastDayCount";
            this.LastDayCount.Size = new System.Drawing.Size(51, 26);
            this.LastDayCount.TabIndex = 13;
            this.LastDayCount.Text = "0";
            this.LastDayCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LastDayCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LastDayCount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(365, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "上次下载到0条数据,需要下载全部数据请点击下载全部历史数据按钮";
            // 
            // btn_callData
            // 
            this.btn_callData.BackColor = System.Drawing.Color.Transparent;
            this.btn_callData.BaseColor = System.Drawing.Color.Transparent;
            this.btn_callData.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_callData.DownBack = null;
            this.btn_callData.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_callData.ForeColor = System.Drawing.Color.White;
            this.btn_callData.Location = new System.Drawing.Point(375, 37);
            this.btn_callData.MouseBack = null;
            this.btn_callData.Name = "btn_callData";
            this.btn_callData.NormlBack = null;
            this.btn_callData.Size = new System.Drawing.Size(90, 44);
            this.btn_callData.TabIndex = 2;
            this.btn_callData.Text = "招收";
            this.btn_callData.UseVisualStyleBackColor = false;
            this.btn_callData.Click += new System.EventHandler(this.btn_callData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(215, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "天";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "查询最近:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Indicator);
            this.panel2.Controls.Add(this.skinLabel1);
            this.panel2.Controls.Add(this.lb_grop);
            this.panel2.Controls.Add(this.lb_noty);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 92);
            this.panel2.TabIndex = 5;
            // 
            // Indicator
            // 
            this.Indicator.BackColor = System.Drawing.Color.Transparent;
            this.Indicator.CircleColor = System.Drawing.Color.White;
            this.Indicator.Location = new System.Drawing.Point(416, 3);
            this.Indicator.Name = "Indicator";
            this.Indicator.Percentage = 0F;
            this.Indicator.Size = new System.Drawing.Size(74, 74);
            this.Indicator.TabIndex = 5;
            this.Indicator.Text = "skinProgressIndicator1";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.White;
            this.skinLabel1.Location = new System.Drawing.Point(11, 16);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(140, 14);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "当前查询设备序列为:";
            // 
            // lb_grop
            // 
            this.lb_grop.AutoSize = true;
            this.lb_grop.BackColor = System.Drawing.Color.Transparent;
            this.lb_grop.BorderColor = System.Drawing.Color.Transparent;
            this.lb_grop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_grop.ForeColor = System.Drawing.Color.White;
            this.lb_grop.Location = new System.Drawing.Point(164, 16);
            this.lb_grop.Name = "lb_grop";
            this.lb_grop.Size = new System.Drawing.Size(21, 14);
            this.lb_grop.TabIndex = 4;
            this.lb_grop.Text = "空";
            // 
            // lb_noty
            // 
            this.lb_noty.AutoSize = true;
            this.lb_noty.BackColor = System.Drawing.Color.Transparent;
            this.lb_noty.BorderColor = System.Drawing.Color.Transparent;
            this.lb_noty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_noty.ForeColor = System.Drawing.Color.White;
            this.lb_noty.Location = new System.Drawing.Point(12, 51);
            this.lb_noty.Name = "lb_noty";
            this.lb_noty.Size = new System.Drawing.Size(42, 14);
            this.lb_noty.TabIndex = 6;
            this.lb_noty.Text = "提示:";
            // 
            // LastOneHistroyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(140)))));
            this.ClientSize = new System.Drawing.Size(518, 778);
            this.Controls.Add(this.skinPanel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LastOneHistroyForm";
            this.ShowBorder = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载设备最近历史数据";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LastOneHistroyForm_FormClosing);
            this.Load += new System.EventHandler(this.LastOneHistroyForm_Load);
            this.Shown += new System.EventHandler(this.LastOneHistroyForm_Shown);
            this.skinPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinLabel lb_noty;
        private CCWin.SkinControl.SkinProgressIndicator Indicator;
        private CCWin.SkinControl.SkinLabel lb_grop;
        private CCWin.SkinControl.RtfRichTextBox RichTextBox;
        private CCWin.SkinControl.SkinButton btn_callData;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox LastDayCount;
    }
}