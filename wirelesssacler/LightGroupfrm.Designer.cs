namespace wirelesssacler
{
    partial class LightGroupfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightGroupfrm));
            this.lb_noty = new CCWin.SkinControl.SkinLabel();
            this.Indicator = new CCWin.SkinControl.SkinProgressIndicator();
            this.btn_query = new CCWin.SkinControl.SkinButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ListBox_dev = new System.Windows.Forms.CheckedListBox();
            this.tb_msg = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckBox_all = new CCWin.SkinControl.SkinCheckBox();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.skinPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_noty
            // 
            this.lb_noty.AutoSize = true;
            this.lb_noty.BackColor = System.Drawing.Color.Transparent;
            this.lb_noty.BorderColor = System.Drawing.Color.Transparent;
            this.lb_noty.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_noty.ForeColor = System.Drawing.Color.White;
            this.lb_noty.Location = new System.Drawing.Point(3, 47);
            this.lb_noty.Name = "lb_noty";
            this.lb_noty.Size = new System.Drawing.Size(224, 17);
            this.lb_noty.TabIndex = 5;
            this.lb_noty.Text = "提示：无动作记录时不需要下载动作数据";
            // 
            // Indicator
            // 
            this.Indicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Indicator.BackColor = System.Drawing.Color.Transparent;
            this.Indicator.CircleColor = System.Drawing.Color.White;
            this.Indicator.Location = new System.Drawing.Point(434, 3);
            this.Indicator.Name = "Indicator";
            this.Indicator.Percentage = 0F;
            this.Indicator.Size = new System.Drawing.Size(61, 61);
            this.Indicator.TabIndex = 1;
            this.Indicator.Text = "Indicator";
            // 
            // btn_query
            // 
            this.btn_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_query.BackColor = System.Drawing.Color.Transparent;
            this.btn_query.BaseColor = System.Drawing.Color.Transparent;
            this.btn_query.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_query.DownBack = null;
            this.btn_query.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.ForeColor = System.Drawing.Color.White;
            this.btn_query.Location = new System.Drawing.Point(422, 80);
            this.btn_query.MouseBack = null;
            this.btn_query.Name = "btn_query";
            this.btn_query.NormlBack = null;
            this.btn_query.Size = new System.Drawing.Size(73, 34);
            this.btn_query.TabIndex = 0;
            this.btn_query.Text = "招收";
            this.btn_query.UseVisualStyleBackColor = false;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.skinPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.44784F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 740);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.tableLayoutPanel3);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(3, 3);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(504, 734);
            this.skinPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(504, 734);
            this.tableLayoutPanel3.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.ListBox_dev, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tb_msg, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(498, 592);
            this.tableLayoutPanel2.TabIndex = 20;
            // 
            // ListBox_dev
            // 
            this.ListBox_dev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_dev.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox_dev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(100)))));
            this.ListBox_dev.FormattingEnabled = true;
            this.ListBox_dev.Location = new System.Drawing.Point(3, 3);
            this.ListBox_dev.Name = "ListBox_dev";
            this.ListBox_dev.Size = new System.Drawing.Size(492, 290);
            this.ListBox_dev.TabIndex = 18;
            // 
            // tb_msg
            // 
            this.tb_msg.BackColor = System.Drawing.Color.White;
            this.tb_msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_msg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_msg.Location = new System.Drawing.Point(3, 299);
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.Size = new System.Drawing.Size(492, 290);
            this.tb_msg.TabIndex = 14;
            this.tb_msg.Text = "";
            this.tb_msg.TextChanged += new System.EventHandler(this.tb_msg_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CheckBox_all);
            this.panel1.Controls.Add(this.Indicator);
            this.panel1.Controls.Add(this.lb_noty);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 601);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 130);
            this.panel1.TabIndex = 21;
            // 
            // CheckBox_all
            // 
            this.CheckBox_all.AutoSize = true;
            this.CheckBox_all.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_all.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.CheckBox_all.DownBack = null;
            this.CheckBox_all.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckBox_all.Location = new System.Drawing.Point(3, 3);
            this.CheckBox_all.MouseBack = null;
            this.CheckBox_all.Name = "CheckBox_all";
            this.CheckBox_all.NormlBack = null;
            this.CheckBox_all.SelectedDownBack = null;
            this.CheckBox_all.SelectedMouseBack = null;
            this.CheckBox_all.SelectedNormlBack = null;
            this.CheckBox_all.Size = new System.Drawing.Size(51, 21);
            this.CheckBox_all.TabIndex = 19;
            this.CheckBox_all.Text = "全选";
            this.CheckBox_all.UseVisualStyleBackColor = false;
            this.CheckBox_all.CheckedChanged += new System.EventHandler(this.CheckBox_all_CheckedChanged);
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
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
            // LightGroupfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(140)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(518, 778);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.skinPanel1);
            this.EffectBack = System.Drawing.Color.Black;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LightGroupfrm";
            this.ShowBorder = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载分组设备动作记录次数";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(5, 0);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LightGroupfrm_FormClosing);
            this.Load += new System.EventHandler(this.LightGroupfrm_Load);
            this.Shown += new System.EventHandler(this.LightGroupfrm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.skinPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinLabel lb_noty;
        private CCWin.SkinControl.SkinProgressIndicator Indicator;
        private CCWin.SkinControl.SkinButton btn_query;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.CheckedListBox ListBox_dev;
        private CCWin.SkinControl.SkinCheckBox CheckBox_all;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox tb_msg;
    }
}