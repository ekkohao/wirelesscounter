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
            this.btn_initAll.Location = new System.Drawing.Point(383, 400);
            this.btn_initAll.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.btn_initAll.MouseBack = null;
            this.btn_initAll.Name = "btn_initAll";
            this.btn_initAll.NormlBack = null;
            this.btn_initAll.Size = new System.Drawing.Size(128, 36);
            this.btn_initAll.TabIndex = 0;
            this.btn_initAll.Text = "初始化所选设备";
            this.btn_initAll.UseVisualStyleBackColor = false;
            this.btn_initAll.Click += new System.EventHandler(this.btn_initAll_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.check_all, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ListBox_dev, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 405);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // check_all
            // 
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
            this.check_all.Location = new System.Drawing.Point(3, 366);
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
            this.ListBox_dev.Size = new System.Drawing.Size(504, 357);
            this.ListBox_dev.TabIndex = 19;
            // 
            // InitAllDevfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(518, 443);
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
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton btn_initAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CCWin.SkinControl.SkinCheckBox check_all;
        private System.Windows.Forms.CheckedListBox ListBox_dev;
    }
}