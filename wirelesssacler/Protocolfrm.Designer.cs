namespace wirelesssacler
{
    partial class Protocolfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Protocolfrm));
            this.btn_change = new CCWin.SkinControl.SkinButton();
            this.RBtn_JCY = new CCWin.SkinControl.SkinRadioButton();
            this.Rbtn_JSQ = new CCWin.SkinControl.SkinRadioButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.RichBox = new CCWin.SkinControl.SkinChatRichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_change
            // 
            this.btn_change.BackColor = System.Drawing.Color.Transparent;
            this.btn_change.BaseColor = System.Drawing.Color.Transparent;
            this.btn_change.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_change.ForeColor = System.Drawing.Color.White;
            this.btn_change.Location = new System.Drawing.Point(266, 180);

            this.btn_change.Name = "btn_change";

            this.btn_change.Size = new System.Drawing.Size(64, 30);
            this.btn_change.TabIndex = 0;
            this.btn_change.Text = "更改";
            this.btn_change.UseVisualStyleBackColor = false;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // RBtn_JCY
            // 
            this.RBtn_JCY.AutoSize = true;
            this.RBtn_JCY.BackColor = System.Drawing.Color.Transparent;
            this.RBtn_JCY.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.RBtn_JCY.DownBack = null;
            this.RBtn_JCY.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RBtn_JCY.ForeColor = System.Drawing.Color.White;
            this.RBtn_JCY.LightEffect = false;
            this.RBtn_JCY.Location = new System.Drawing.Point(29, 153);
            this.RBtn_JCY.MouseBack = null;
            this.RBtn_JCY.Name = "RBtn_JCY";
            this.RBtn_JCY.NormlBack = null;
            this.RBtn_JCY.SelectedDownBack = null;
            this.RBtn_JCY.SelectedMouseBack = null;
            this.RBtn_JCY.SelectedNormlBack = null;
            this.RBtn_JCY.Size = new System.Drawing.Size(142, 21);
            this.RBtn_JCY.TabIndex = 1;
            this.RBtn_JCY.TabStop = true;
            this.RBtn_JCY.Text = "带全电流协议(监测仪)";
            this.RBtn_JCY.UseVisualStyleBackColor = false;
            this.RBtn_JCY.CheckedChanged += new System.EventHandler(this.RBtn_JCY_CheckedChanged);
            // 
            // Rbtn_JSQ
            // 
            this.Rbtn_JSQ.AutoSize = true;
            this.Rbtn_JSQ.BackColor = System.Drawing.Color.Transparent;
            this.Rbtn_JSQ.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Rbtn_JSQ.DownBack = null;
            this.Rbtn_JSQ.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rbtn_JSQ.ForeColor = System.Drawing.Color.White;
            this.Rbtn_JSQ.LightEffect = false;
            this.Rbtn_JSQ.Location = new System.Drawing.Point(188, 153);
            this.Rbtn_JSQ.MouseBack = null;
            this.Rbtn_JSQ.Name = "Rbtn_JSQ";
            this.Rbtn_JSQ.NormlBack = null;
            this.Rbtn_JSQ.SelectedDownBack = null;
            this.Rbtn_JSQ.SelectedMouseBack = null;
            this.Rbtn_JSQ.SelectedNormlBack = null;
            this.Rbtn_JSQ.Size = new System.Drawing.Size(142, 21);
            this.Rbtn_JSQ.TabIndex = 2;
            this.Rbtn_JSQ.TabStop = true;
            this.Rbtn_JSQ.Text = "无全电流协议(计数器)";
            this.Rbtn_JSQ.UseVisualStyleBackColor = false;
            this.Rbtn_JSQ.CheckedChanged += new System.EventHandler(this.Rbtn_JSQ_CheckedChanged);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.White;
            this.skinLabel1.Location = new System.Drawing.Point(7, 34);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 3;
            this.skinLabel1.Text = "说明";
            // 
            // RichBox
            // 
            this.RichBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RichBox.Location = new System.Drawing.Point(52, 51);
            this.RichBox.Name = "RichBox";
            this.RichBox.Size = new System.Drawing.Size(250, 96);
            this.RichBox.TabIndex = 4;
            this.RichBox.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Protocolfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(130)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(344, 224);
            this.Controls.Add(this.RichBox);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.Rbtn_JSQ);
            this.Controls.Add(this.RBtn_JCY);
            this.Controls.Add(this.btn_change);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Protocolfrm";
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通信协议更改界面";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(10, 0);
            this.Load += new System.EventHandler(this.Protocolfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton btn_change;
        private CCWin.SkinControl.SkinRadioButton RBtn_JCY;
        private CCWin.SkinControl.SkinRadioButton Rbtn_JSQ;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinChatRichTextBox RichBox;
        private System.Windows.Forms.Timer timer1;
    }
}