namespace wirelesssacler
{
    partial class ExportDevExclefrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportDevExclefrm));
            this.check_all = new CCWin.SkinControl.SkinCheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Excle = new CCWin.SkinControl.SkinButton();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.btn_openfile = new CCWin.SkinControl.SkinButton();
            this.DevTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.Controls.Add(this.check_all, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DevTreeView, 0, 0);
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Excle);
            this.panel1.Controls.Add(this.skinPictureBox1);
            this.panel1.Controls.Add(this.btn_openfile);
            this.panel1.Location = new System.Drawing.Point(333, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 372);
            this.panel1.TabIndex = 21;
            // 
            // btn_Excle
            // 
            this.btn_Excle.BackColor = System.Drawing.Color.Transparent;
            this.btn_Excle.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Excle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Excle.DownBack = null;
            this.btn_Excle.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Excle.ForeColor = System.Drawing.Color.White;
            this.btn_Excle.Location = new System.Drawing.Point(27, 119);
            this.btn_Excle.MouseBack = null;
            this.btn_Excle.Name = "btn_Excle";
            this.btn_Excle.NormlBack = null;
            this.btn_Excle.Size = new System.Drawing.Size(128, 41);
            this.btn_Excle.TabIndex = 0;
            this.btn_Excle.Text = "导出Excle";
            this.btn_Excle.UseVisualStyleBackColor = false;
            this.btn_Excle.Click += new System.EventHandler(this.btn_Excle_Click);
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
            // btn_openfile
            // 
            this.btn_openfile.BackColor = System.Drawing.Color.Transparent;
            this.btn_openfile.BaseColor = System.Drawing.Color.Transparent;
            this.btn_openfile.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_openfile.DownBack = null;
            this.btn_openfile.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_openfile.ForeColor = System.Drawing.Color.White;
            this.btn_openfile.Location = new System.Drawing.Point(27, 190);
            this.btn_openfile.MouseBack = null;
            this.btn_openfile.Name = "btn_openfile";
            this.btn_openfile.NormlBack = null;
            this.btn_openfile.Size = new System.Drawing.Size(128, 40);
            this.btn_openfile.TabIndex = 21;
            this.btn_openfile.Text = "打开文件位置";
            this.btn_openfile.UseVisualStyleBackColor = false;
            this.btn_openfile.Click += new System.EventHandler(this.btn_openfile_Click);
            // 
            // DevTreeView
            // 
            this.DevTreeView.CheckBoxes = true;
            this.DevTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevTreeView.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DevTreeView.Location = new System.Drawing.Point(3, 3);
            this.DevTreeView.Name = "DevTreeView";
            this.DevTreeView.Size = new System.Drawing.Size(324, 372);
            this.DevTreeView.TabIndex = 22;
            this.DevTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.DevTreeView_AfterCheck);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 103);
            this.label1.TabIndex = 23;
            this.label1.Text = "提示：组号前的复选框可全选或取消子节点的复选框，但请勿双击";
            // 
            // ExportDevExclefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(518, 443);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportDevExclefrm";
            this.ShowBorder = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出设备信息";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(10, 0);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExportDevExclefrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinCheckBox check_all;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private CCWin.SkinControl.SkinButton btn_Excle;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private CCWin.SkinControl.SkinButton btn_openfile;
        private System.Windows.Forms.TreeView DevTreeView;
        private System.Windows.Forms.Label label1;
    }
}