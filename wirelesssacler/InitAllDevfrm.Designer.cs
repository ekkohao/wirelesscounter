namespace wirelesssacler
{
    partial class InitAllDevfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitAllDevfrm));
            this.btn_initAll = new CCWin.SkinControl.SkinButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.check_all = new CCWin.SkinControl.SkinCheckBox();
            this.ListBox_dev = new System.Windows.Forms.CheckedListBox();
            this.init_all_time = new CCWin.SkinControl.SkinButton();
            this.date_Time_Picker = new System.Windows.Forms.DateTimePicker();
            this.box_set_time = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_initAll
            // 
            this.btn_initAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_initAll.BackColor = System.Drawing.Color.Transparent;
            this.btn_initAll.BaseColor = System.Drawing.Color.Transparent;
            this.btn_initAll.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_initAll.DownBack = null;
            this.btn_initAll.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_initAll.ForeColor = System.Drawing.Color.White;
            this.btn_initAll.Location = new System.Drawing.Point(920, 557);
            this.btn_initAll.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.btn_initAll.MouseBack = null;
            this.btn_initAll.Name = "btn_initAll";
            this.btn_initAll.NormlBack = null;
            this.btn_initAll.Size = new System.Drawing.Size(128, 43);
            this.btn_initAll.TabIndex = 0;
            this.btn_initAll.Text = "初始化所选设备";
            this.btn_initAll.UseVisualStyleBackColor = false;
            this.btn_initAll.Click += new System.EventHandler(this.btn_initAll_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ListBox_dev, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1044, 523);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // check_all
            // 
            this.check_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.check_all.AutoSize = true;
            this.check_all.BackColor = System.Drawing.Color.Transparent;
            this.check_all.Checked = true;
            this.check_all.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_all.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.check_all.DownBack = null;
            this.check_all.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_all.ForeColor = System.Drawing.Color.White;
            this.check_all.LightEffect = false;
            this.check_all.LightEffectBack = System.Drawing.Color.Transparent;
            this.check_all.Location = new System.Drawing.Point(7, 563);
            this.check_all.MouseBack = null;
            this.check_all.Name = "check_all";
            this.check_all.NormlBack = null;
            this.check_all.SelectedDownBack = null;
            this.check_all.SelectedMouseBack = null;
            this.check_all.SelectedNormlBack = null;
            this.check_all.Size = new System.Drawing.Size(59, 20);
            this.check_all.TabIndex = 20;
            this.check_all.Text = "全选";
            this.check_all.UseVisualStyleBackColor = false;
            this.check_all.CheckedChanged += new System.EventHandler(this.check_all_CheckedChanged);
            // 
            // ListBox_dev
            // 
            this.ListBox_dev.BackColor = System.Drawing.Color.White;
            this.ListBox_dev.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox_dev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_dev.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox_dev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(150)))));
            this.ListBox_dev.FormattingEnabled = true;
            this.ListBox_dev.HorizontalScrollbar = true;
            this.ListBox_dev.Location = new System.Drawing.Point(3, 3);
            this.ListBox_dev.Name = "ListBox_dev";
            this.ListBox_dev.Size = new System.Drawing.Size(1038, 517);
            this.ListBox_dev.TabIndex = 19;
            // 
            // init_all_time
            // 
            this.init_all_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.init_all_time.BackColor = System.Drawing.Color.Transparent;
            this.init_all_time.BaseColor = System.Drawing.Color.Transparent;
            this.init_all_time.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.init_all_time.DownBack = null;
            this.init_all_time.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.init_all_time.ForeColor = System.Drawing.Color.White;
            this.init_all_time.Location = new System.Drawing.Point(768, 557);
            this.init_all_time.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.init_all_time.MouseBack = null;
            this.init_all_time.Name = "init_all_time";
            this.init_all_time.NormlBack = null;
            this.init_all_time.Size = new System.Drawing.Size(147, 43);
            this.init_all_time.TabIndex = 0;
            this.init_all_time.Text = "同步所选设备时间";
            this.init_all_time.UseVisualStyleBackColor = false;
            this.init_all_time.Click += new System.EventHandler(this.init_all_time_Click);
            // 
            // date_Time_Picker
            // 
            this.date_Time_Picker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.date_Time_Picker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.date_Time_Picker.Enabled = false;
            this.date_Time_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_Time_Picker.Location = new System.Drawing.Point(596, 559);
            this.date_Time_Picker.Name = "date_Time_Picker";
            this.date_Time_Picker.ShowUpDown = true;
            this.date_Time_Picker.Size = new System.Drawing.Size(166, 21);
            this.date_Time_Picker.TabIndex = 25;
            this.date_Time_Picker.Value = new System.DateTime(2016, 6, 22, 14, 51, 1, 0);
            // 
            // box_set_time
            // 
            this.box_set_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.box_set_time.AutoSize = true;
            this.box_set_time.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.box_set_time.Location = new System.Drawing.Point(596, 585);
            this.box_set_time.Name = "box_set_time";
            this.box_set_time.Size = new System.Drawing.Size(108, 16);
            this.box_set_time.TabIndex = 26;
            this.box_set_time.Text = "设置初始化时间";
            this.box_set_time.UseVisualStyleBackColor = true;
            this.box_set_time.CheckedChanged += new System.EventHandler(this.box_set_time_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(111, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 10);
            this.label1.TabIndex = 27;
            this.label1.Text = "提示：若不设置初始化时间，则分别为每个设备同步为计算机的实时时间";
            // 
            // InitAllDevfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(1055, 611);
            this.Controls.Add(this.check_all);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box_set_time);
            this.Controls.Add(this.date_Time_Picker);
            this.Controls.Add(this.init_all_time);
            this.Controls.Add(this.btn_initAll);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InitAllDevfrm";
            this.ShowBorder = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "初始化设备";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(10, 0);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InitAllDevfrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton btn_initAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CCWin.SkinControl.SkinCheckBox check_all;
        private System.Windows.Forms.CheckedListBox ListBox_dev;
        private CCWin.SkinControl.SkinButton init_all_time;
        private System.Windows.Forms.DateTimePicker date_Time_Picker;
        private System.Windows.Forms.CheckBox box_set_time;
        private System.Windows.Forms.Label label1;
    }
}