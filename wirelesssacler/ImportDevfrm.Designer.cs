namespace wirelesssacler
{
    partial class ImportDevfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportDevfrm));
            this.Path_text = new CCWin.SkinControl.SkinTextBox();
            this.btn_import = new CCWin.SkinControl.SkinButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.btn_ok = new CCWin.SkinControl.SkinButton();
            this.btn_no = new CCWin.SkinControl.SkinButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.importmsg = new System.Windows.Forms.RichTextBox();
            this.ImportProgressBar = new CCWin.SkinControl.SkinProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.skinGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Path_text
            // 
            this.Path_text.BackColor = System.Drawing.Color.Transparent;
            this.Path_text.DownBack = null;
            this.Path_text.Icon = null;
            this.Path_text.IconIsButton = false;
            this.Path_text.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.Path_text.IsPasswordChat = '\0';
            this.Path_text.IsSystemPasswordChar = false;
            this.Path_text.Lines = new string[0];
            this.Path_text.Location = new System.Drawing.Point(27, 16);
            this.Path_text.Margin = new System.Windows.Forms.Padding(0);
            this.Path_text.MaxLength = 32767;
            this.Path_text.MinimumSize = new System.Drawing.Size(28, 28);
            this.Path_text.MouseBack = null;
            this.Path_text.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.Path_text.Multiline = false;
            this.Path_text.Name = "Path_text";
            this.Path_text.NormlBack = null;
            this.Path_text.Padding = new System.Windows.Forms.Padding(5);
            this.Path_text.ReadOnly = false;
            this.Path_text.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Path_text.Size = new System.Drawing.Size(248, 28);
            // 
            // 
            // 
            this.Path_text.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Path_text.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Path_text.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.Path_text.SkinTxt.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Path_text.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.Path_text.SkinTxt.Name = "BaseText";
            this.Path_text.SkinTxt.Size = new System.Drawing.Size(238, 18);
            this.Path_text.SkinTxt.TabIndex = 0;
            this.Path_text.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.Path_text.SkinTxt.WaterText = "";
            this.Path_text.TabIndex = 0;
            this.Path_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Path_text.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.Path_text.WaterText = "";
            this.Path_text.WordWrap = true;
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.Transparent;
            this.btn_import.BaseColor = System.Drawing.Color.Transparent;
            this.btn_import.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_import.DownBack = null;
            this.btn_import.ForeColor = System.Drawing.Color.White;
            this.btn_import.Location = new System.Drawing.Point(306, 16);
            this.btn_import.MouseBack = null;
            this.btn_import.Name = "btn_import";
            this.btn_import.NormlBack = null;
            this.btn_import.Size = new System.Drawing.Size(75, 28);
            this.btn_import.TabIndex = 1;
            this.btn_import.Text = "打开文件路径";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.White;
            this.skinLabel1.Location = new System.Drawing.Point(3, 0);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(112, 16);
            this.skinLabel1.TabIndex = 2;
            this.skinLabel1.Text = "设备清单地址:";
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_ok.BaseColor = System.Drawing.Color.Transparent;
            this.btn_ok.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_ok.DownBack = null;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(219, 72);
            this.btn_ok.MouseBack = null;
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.NormlBack = null;
            this.btn_ok.Size = new System.Drawing.Size(76, 37);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_no
            // 
            this.btn_no.BackColor = System.Drawing.Color.Transparent;
            this.btn_no.BaseColor = System.Drawing.Color.Transparent;
            this.btn_no.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_no.DownBack = null;
            this.btn_no.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_no.Location = new System.Drawing.Point(306, 72);
            this.btn_no.MouseBack = null;
            this.btn_no.Name = "btn_no";
            this.btn_no.NormlBack = null;
            this.btn_no.Size = new System.Drawing.Size(70, 37);
            this.btn_no.TabIndex = 4;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = false;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 34);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.ImportProgressBar);
            this.splitContainer1.Panel1.Controls.Add(this.skinGroupBox1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.skinLabel1);
            this.splitContainer1.Panel2.Controls.Add(this.Path_text);
            this.splitContainer1.Panel2.Controls.Add(this.btn_no);
            this.splitContainer1.Panel2.Controls.Add(this.btn_import);
            this.splitContainer1.Panel2.Controls.Add(this.btn_ok);
            this.splitContainer1.Size = new System.Drawing.Size(414, 288);
            this.splitContainer1.SplitterDistance = 163;
            this.splitContainer1.TabIndex = 5;
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.Green;
            this.skinGroupBox1.Controls.Add(this.importmsg);
            this.skinGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(150)))));
            this.skinGroupBox1.Location = new System.Drawing.Point(3, 19);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(408, 141);
            this.skinGroupBox1.TabIndex = 2;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "导入信息提示";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // importmsg
            // 
            this.importmsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importmsg.Location = new System.Drawing.Point(3, 17);
            this.importmsg.Name = "importmsg";
            this.importmsg.Size = new System.Drawing.Size(402, 121);
            this.importmsg.TabIndex = 6;
            this.importmsg.Text = "";
            // 
            // ImportProgressBar
            // 
            this.ImportProgressBar.Back = null;
            this.ImportProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.ImportProgressBar.BarBack = null;
            this.ImportProgressBar.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ImportProgressBar.ForeColor = System.Drawing.Color.Red;
            this.ImportProgressBar.Location = new System.Drawing.Point(13, 3);
            this.ImportProgressBar.Name = "ImportProgressBar";
            this.ImportProgressBar.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ImportProgressBar.Size = new System.Drawing.Size(379, 10);
            this.ImportProgressBar.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ImportDevfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(422, 326);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportDevfrm";
            this.ShowBorder = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入清单界面";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.skinGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox Path_text;
        private CCWin.SkinControl.SkinButton btn_import;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinButton btn_ok;
        private CCWin.SkinControl.SkinButton btn_no;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CCWin.SkinControl.SkinProgressBar ImportProgressBar;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RichTextBox importmsg;
        private System.Windows.Forms.Timer timer1;
    }
}