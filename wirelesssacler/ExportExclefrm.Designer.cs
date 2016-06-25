namespace wirelesssacler
{
    partial class ExportExclefrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportExclefrm));
            this.ListBox_dev = new System.Windows.Forms.CheckedListBox();
            this.check_all = new CCWin.SkinControl.SkinCheckBox();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Excle = new CCWin.SkinControl.SkinButton();
            this.skinPictureBox2 = new CCWin.SkinControl.SkinPictureBox();
            this.btn_openfile = new CCWin.SkinControl.SkinButton();
            this.CheckBox_real = new CCWin.SkinControl.SkinCheckBox();
            this.checkBox_hist = new CCWin.SkinControl.SkinCheckBox();
            this.CheckBox_light = new CCWin.SkinControl.SkinCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox2)).BeginInit();
            this.SuspendLayout();
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
            this.ListBox_dev.Size = new System.Drawing.Size(324, 372);
            this.ListBox_dev.TabIndex = 19;
            // 
            // check_all
            // 
            this.check_all.AutoSize = true;
            this.check_all.BackColor = System.Drawing.Color.Transparent;
            this.check_all.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.check_all.DownBack = null;
            this.check_all.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_all.ForeColor = System.Drawing.Color.White;
            this.check_all.LightEffect = false;
            this.check_all.LightEffectBack = System.Drawing.Color.Transparent;
            this.check_all.Location = new System.Drawing.Point(3, 381);
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
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skinPictureBox1.BackgroundImage")));
            this.skinPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.skinPictureBox1.Location = new System.Drawing.Point(3, 3);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(45, 43);
            this.skinPictureBox1.TabIndex = 22;
            this.skinPictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.Controls.Add(this.check_all, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ListBox_dev, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 405);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.skinPictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(333, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 372);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Excle);
            this.panel2.Controls.Add(this.skinPictureBox2);
            this.panel2.Controls.Add(this.btn_openfile);
            this.panel2.Controls.Add(this.CheckBox_real);
            this.panel2.Controls.Add(this.checkBox_hist);
            this.panel2.Controls.Add(this.CheckBox_light);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 372);
            this.panel2.TabIndex = 23;
            // 
            // btn_Excle
            // 
            this.btn_Excle.BackColor = System.Drawing.Color.Transparent;
            this.btn_Excle.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Excle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Excle.DownBack = null;
            this.btn_Excle.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Excle.ForeColor = System.Drawing.Color.White;
            this.btn_Excle.Location = new System.Drawing.Point(27, 260);
            this.btn_Excle.MouseBack = null;
            this.btn_Excle.Name = "btn_Excle";
            this.btn_Excle.NormlBack = null;
            this.btn_Excle.Size = new System.Drawing.Size(128, 41);
            this.btn_Excle.TabIndex = 0;
            this.btn_Excle.Text = "导出Excle";
            this.btn_Excle.UseVisualStyleBackColor = false;
            this.btn_Excle.Click += new System.EventHandler(this.btn_Excle_Click);
            // 
            // skinPictureBox2
            // 
            this.skinPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skinPictureBox2.BackgroundImage")));
            this.skinPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.skinPictureBox2.Location = new System.Drawing.Point(3, 3);
            this.skinPictureBox2.Name = "skinPictureBox2";
            this.skinPictureBox2.Size = new System.Drawing.Size(45, 43);
            this.skinPictureBox2.TabIndex = 22;
            this.skinPictureBox2.TabStop = false;
            // 
            // btn_openfile
            // 
            this.btn_openfile.BackColor = System.Drawing.Color.Transparent;
            this.btn_openfile.BaseColor = System.Drawing.Color.Transparent;
            this.btn_openfile.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_openfile.DownBack = null;
            this.btn_openfile.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_openfile.ForeColor = System.Drawing.Color.White;
            this.btn_openfile.Location = new System.Drawing.Point(27, 325);
            this.btn_openfile.MouseBack = null;
            this.btn_openfile.Name = "btn_openfile";
            this.btn_openfile.NormlBack = null;
            this.btn_openfile.Size = new System.Drawing.Size(128, 40);
            this.btn_openfile.TabIndex = 21;
            this.btn_openfile.Text = "打开文件位置";
            this.btn_openfile.UseVisualStyleBackColor = false;
            // 
            // CheckBox_real
            // 
            this.CheckBox_real.AutoSize = true;
            this.CheckBox_real.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_real.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.CheckBox_real.DownBack = null;
            this.CheckBox_real.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckBox_real.ForeColor = System.Drawing.Color.White;
            this.CheckBox_real.LightEffect = false;
            this.CheckBox_real.LightEffectBack = System.Drawing.Color.Transparent;
            this.CheckBox_real.Location = new System.Drawing.Point(17, 88);
            this.CheckBox_real.MouseBack = null;
            this.CheckBox_real.Name = "CheckBox_real";
            this.CheckBox_real.NormlBack = null;
            this.CheckBox_real.SelectedDownBack = null;
            this.CheckBox_real.SelectedMouseBack = null;
            this.CheckBox_real.SelectedNormlBack = null;
            this.CheckBox_real.Size = new System.Drawing.Size(148, 23);
            this.CheckBox_real.TabIndex = 1;
            this.CheckBox_real.Text = "设备实时数据";
            this.CheckBox_real.UseVisualStyleBackColor = false;
            // 
            // checkBox_hist
            // 
            this.checkBox_hist.AutoSize = true;
            this.checkBox_hist.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_hist.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkBox_hist.DownBack = null;
            this.checkBox_hist.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_hist.ForeColor = System.Drawing.Color.White;
            this.checkBox_hist.LightEffect = false;
            this.checkBox_hist.LightEffectBack = System.Drawing.Color.Transparent;
            this.checkBox_hist.Location = new System.Drawing.Point(17, 166);
            this.checkBox_hist.MouseBack = null;
            this.checkBox_hist.Name = "checkBox_hist";
            this.checkBox_hist.NormlBack = null;
            this.checkBox_hist.SelectedDownBack = null;
            this.checkBox_hist.SelectedMouseBack = null;
            this.checkBox_hist.SelectedNormlBack = null;
            this.checkBox_hist.Size = new System.Drawing.Size(148, 23);
            this.checkBox_hist.TabIndex = 3;
            this.checkBox_hist.Text = "历史数据记录";
            this.checkBox_hist.UseVisualStyleBackColor = false;
            // 
            // CheckBox_light
            // 
            this.CheckBox_light.AutoSize = true;
            this.CheckBox_light.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_light.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.CheckBox_light.DownBack = null;
            this.CheckBox_light.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckBox_light.ForeColor = System.Drawing.Color.White;
            this.CheckBox_light.LightEffect = false;
            this.CheckBox_light.LightEffectBack = System.Drawing.Color.Transparent;
            this.CheckBox_light.Location = new System.Drawing.Point(17, 128);
            this.CheckBox_light.MouseBack = null;
            this.CheckBox_light.Name = "CheckBox_light";
            this.CheckBox_light.NormlBack = null;
            this.CheckBox_light.SelectedDownBack = null;
            this.CheckBox_light.SelectedMouseBack = null;
            this.CheckBox_light.SelectedNormlBack = null;
            this.CheckBox_light.Size = new System.Drawing.Size(148, 23);
            this.CheckBox_light.TabIndex = 2;
            this.CheckBox_light.Text = "设备动作记录";
            this.CheckBox_light.UseVisualStyleBackColor = false;
            // 
            // ExportExclefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(518, 443);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportExclefrm";
            this.ShowBorder = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出设备数据";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(10, 0);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExportExclefrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ListBox_dev;
        private CCWin.SkinControl.SkinCheckBox check_all;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CCWin.SkinControl.SkinButton btn_Excle;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox2;
        private CCWin.SkinControl.SkinButton btn_openfile;
        private CCWin.SkinControl.SkinCheckBox CheckBox_real;
        private CCWin.SkinControl.SkinCheckBox checkBox_hist;
        private CCWin.SkinControl.SkinCheckBox CheckBox_light;
    }
}