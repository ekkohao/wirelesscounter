namespace wirelesssacler
{
    partial class AddDevfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDevfrm));
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.tb_xulie = new CCWin.SkinControl.SkinTextBox();
            this.tb_add = new CCWin.SkinControl.SkinTextBox();
            this.Add = new CCWin.SkinControl.SkinButton();
            this.cbx_pahse = new CCWin.SkinControl.SkinComboBox();
            this.skinToolTip1 = new CCWin.SkinToolTip(this.components);
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.White;
            this.skinLabel1.Location = new System.Drawing.Point(34, 65);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(74, 21);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "设备序列";
            // 
            // skinLabel2
            // 
            this.skinLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.ForeColor = System.Drawing.Color.White;
            this.skinLabel2.Location = new System.Drawing.Point(34, 162);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(74, 21);
            this.skinLabel2.TabIndex = 1;
            this.skinLabel2.Text = "安装杆塔";
            // 
            // skinLabel3
            // 
            this.skinLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.ForeColor = System.Drawing.Color.White;
            this.skinLabel3.Location = new System.Drawing.Point(25, 248);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(106, 21);
            this.skinLabel3.TabIndex = 2;
            this.skinLabel3.Text = "监测路线位置";
            // 
            // tb_xulie
            // 
            this.tb_xulie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_xulie.BackColor = System.Drawing.Color.Transparent;
            this.tb_xulie.DownBack = null;
            this.tb_xulie.Icon = null;
            this.tb_xulie.IconIsButton = false;
            this.tb_xulie.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.tb_xulie.IsPasswordChat = '\0';
            this.tb_xulie.IsSystemPasswordChar = false;
            this.tb_xulie.Lines = new string[0];
            this.tb_xulie.Location = new System.Drawing.Point(140, 65);
            this.tb_xulie.Margin = new System.Windows.Forms.Padding(0);
            this.tb_xulie.MaxLength = 32767;
            this.tb_xulie.MinimumSize = new System.Drawing.Size(33, 40);
            this.tb_xulie.MouseBack = null;
            this.tb_xulie.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.tb_xulie.Multiline = true;
            this.tb_xulie.Name = "tb_xulie";
            this.tb_xulie.NormlBack = null;
            this.tb_xulie.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.tb_xulie.ReadOnly = false;
            this.tb_xulie.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_xulie.Size = new System.Drawing.Size(242, 40);
            // 
            // 
            // 
            this.tb_xulie.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_xulie.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_xulie.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.tb_xulie.SkinTxt.Location = new System.Drawing.Point(6, 7);
            this.tb_xulie.SkinTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_xulie.SkinTxt.Multiline = true;
            this.tb_xulie.SkinTxt.Name = "BaseText";
            this.tb_xulie.SkinTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_xulie.SkinTxt.Size = new System.Drawing.Size(230, 26);
            this.tb_xulie.SkinTxt.TabIndex = 0;
            this.tb_xulie.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tb_xulie.SkinTxt.WaterText = "请输入10位设备序列号位置";
            this.tb_xulie.TabIndex = 8;
            this.tb_xulie.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinToolTip1.SetToolTip(this.tb_xulie, "输入10位的设备序列号");
            this.tb_xulie.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tb_xulie.WaterText = "请输入10位设备序列号位置";
            this.tb_xulie.WordWrap = true;
            // 
            // tb_add
            // 
            this.tb_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_add.BackColor = System.Drawing.Color.Transparent;
            this.tb_add.DownBack = null;
            this.tb_add.Icon = null;
            this.tb_add.IconIsButton = false;
            this.tb_add.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.tb_add.IsPasswordChat = '\0';
            this.tb_add.IsSystemPasswordChar = false;
            this.tb_add.Lines = new string[0];
            this.tb_add.Location = new System.Drawing.Point(140, 153);
            this.tb_add.Margin = new System.Windows.Forms.Padding(0);
            this.tb_add.MaxLength = 32767;
            this.tb_add.MinimumSize = new System.Drawing.Size(33, 40);
            this.tb_add.MouseBack = null;
            this.tb_add.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.tb_add.Multiline = true;
            this.tb_add.Name = "tb_add";
            this.tb_add.NormlBack = null;
            this.tb_add.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.tb_add.ReadOnly = false;
            this.tb_add.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_add.Size = new System.Drawing.Size(242, 40);
            // 
            // 
            // 
            this.tb_add.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_add.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_add.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.tb_add.SkinTxt.Location = new System.Drawing.Point(6, 7);
            this.tb_add.SkinTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_add.SkinTxt.Multiline = true;
            this.tb_add.SkinTxt.Name = "BaseText";
            this.tb_add.SkinTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_add.SkinTxt.Size = new System.Drawing.Size(230, 26);
            this.tb_add.SkinTxt.TabIndex = 0;
            this.tb_add.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tb_add.SkinTxt.WaterText = "请输入设备安装所在杆塔位置";
            this.tb_add.TabIndex = 4;
            this.tb_add.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinToolTip1.SetToolTip(this.tb_add, "设备安装的杆塔位置");
            this.tb_add.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tb_add.WaterText = "请输入设备安装所在杆塔位置";
            this.tb_add.WordWrap = true;
            // 
            // Add
            // 
            this.Add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            this.Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Add.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            this.Add.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Add.DownBack = null;
            this.Add.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(150)))));
            this.Add.Image = ((System.Drawing.Image)(resources.GetObject("Add.Image")));
            this.Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add.IsDrawGlass = false;
            this.Add.Location = new System.Drawing.Point(308, 315);
            this.Add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Add.MouseBack = null;
            this.Add.Name = "Add";
            this.Add.NormlBack = null;
            this.Add.Size = new System.Drawing.Size(88, 44);
            this.Add.TabIndex = 6;
            this.Add.Text = "添加";
            this.skinToolTip1.SetToolTip(this.Add, "添加新设备");
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // cbx_pahse
            // 
            this.cbx_pahse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbx_pahse.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.cbx_pahse.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.cbx_pahse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(100)))));
            this.cbx_pahse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_pahse.FormattingEnabled = true;
            this.cbx_pahse.Items.AddRange(new object[] {
            "上",
            "中",
            "下",
            "左",
            "右",
            "左上",
            "左中",
            "左下",
            "右上",
            "右中",
            "右下"});
            this.cbx_pahse.Location = new System.Drawing.Point(140, 250);
            this.cbx_pahse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_pahse.Name = "cbx_pahse";
            this.cbx_pahse.Size = new System.Drawing.Size(242, 24);
            this.cbx_pahse.TabIndex = 7;
            this.skinToolTip1.SetToolTip(this.cbx_pahse, "请输入或者从下拉框中选择\\r\\n设备监测路线所在位置");
            this.cbx_pahse.WaterText = "请输入或选择监测路线位置";
            // 
            // skinToolTip1
            // 
            this.skinToolTip1.AutoPopDelay = 5000;
            this.skinToolTip1.InitialDelay = 500;
            this.skinToolTip1.OwnerDraw = true;
            this.skinToolTip1.ReshowDelay = 800;
            // 
            // AddDevfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.BorderColor = System.Drawing.Color.White;
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(426, 391);
            this.Controls.Add(this.cbx_pahse);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.tb_add);
            this.Controls.Add(this.tb_xulie);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.EffectBack = System.Drawing.Color.ForestGreen;
            this.EffectCaption = CCWin.TitleType.EffectTitle;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.InnerBorderColor = System.Drawing.Color.Transparent;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "AddDevfrm";
            this.ShadowColor = System.Drawing.Color.Transparent;
            this.ShowBorder = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowSystemMenu = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加新设备";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(5, 0);
            this.Load += new System.EventHandler(this.AddDevfrm_Load);
            this.Shown += new System.EventHandler(this.AddDevfrm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinTextBox tb_xulie;
        private CCWin.SkinControl.SkinTextBox tb_add;
        private CCWin.SkinControl.SkinButton Add;
        private CCWin.SkinControl.SkinComboBox cbx_pahse;
        private CCWin.SkinToolTip skinToolTip1;
    }
}