namespace wirelesssacler
{
    partial class DataCenterfrm
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
            CCWin.SkinControl.Animation animation1 = new CCWin.SkinControl.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataCenterfrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinPanel = new CCWin.SkinControl.SkinPanel();
            this.TabRealAndHistroy = new CCWin.SkinControl.SkinTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RealDataGridView = new CCWin.SkinControl.SkinDataGridView();
            this.historyshow = new System.Windows.Forms.TabPage();
            this.historyPage = new CCWin.SkinControl.SkinDataGridView();
            this.actionshow = new System.Windows.Forms.TabPage();
            this.actionPage = new CCWin.SkinControl.SkinDataGridView();
            this.skinPanel.SuspendLayout();
            this.TabRealAndHistroy.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RealDataGridView)).BeginInit();
            this.historyshow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyPage)).BeginInit();
            this.actionshow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionPage)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel
            // 
            this.skinPanel.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel.Controls.Add(this.TabRealAndHistroy);
            this.skinPanel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel.DownBack = null;
            this.skinPanel.Location = new System.Drawing.Point(4, 34);
            this.skinPanel.MouseBack = null;
            this.skinPanel.Name = "skinPanel";
            this.skinPanel.NormlBack = null;
            this.skinPanel.Size = new System.Drawing.Size(510, 740);
            this.skinPanel.TabIndex = 0;
            // 
            // TabRealAndHistroy
            // 
            animation1.AnimateOnlyDifferences = false;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 2F;
            animation1.TransparencyCoeff = 0F;
            this.TabRealAndHistroy.Animation = animation1;
            this.TabRealAndHistroy.AnimatorType = CCWin.SkinControl.AnimationType.Custom;
            this.TabRealAndHistroy.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.TabRealAndHistroy.Controls.Add(this.tabPage3);
            this.TabRealAndHistroy.Controls.Add(this.historyshow);
            this.TabRealAndHistroy.Controls.Add(this.actionshow);
            this.TabRealAndHistroy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabRealAndHistroy.HeadBack = null;
            this.TabRealAndHistroy.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.TabRealAndHistroy.ItemSize = new System.Drawing.Size(120, 40);
            this.TabRealAndHistroy.Location = new System.Drawing.Point(0, 0);
            this.TabRealAndHistroy.Name = "TabRealAndHistroy";
            this.TabRealAndHistroy.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("TabRealAndHistroy.PageArrowDown")));
            this.TabRealAndHistroy.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("TabRealAndHistroy.PageArrowHover")));
            this.TabRealAndHistroy.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("TabRealAndHistroy.PageCloseHover")));
            this.TabRealAndHistroy.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("TabRealAndHistroy.PageCloseNormal")));
            this.TabRealAndHistroy.PageDown = ((System.Drawing.Image)(resources.GetObject("TabRealAndHistroy.PageDown")));
            this.TabRealAndHistroy.PageHover = ((System.Drawing.Image)(resources.GetObject("TabRealAndHistroy.PageHover")));
            this.TabRealAndHistroy.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.TabRealAndHistroy.PageNorml = null;
            this.TabRealAndHistroy.SelectedIndex = 0;
            this.TabRealAndHistroy.Size = new System.Drawing.Size(510, 740);
            this.TabRealAndHistroy.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabRealAndHistroy.TabIndex = 1;
            this.TabRealAndHistroy.SelectedIndexChanged += new System.EventHandler(this.TabRealAndHistroy_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.RealDataGridView);
            this.tabPage3.Font = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3.ForeColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(510, 700);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "实时数据记录";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RealDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.RealDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.RealDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.RealDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.RealDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.RealDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RealDataGridView.ColumnFont = null;
            this.RealDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RealDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.RealDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RealDataGridView.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            this.RealDataGridView.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RealDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.RealDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RealDataGridView.EnableHeadersVisualStyles = false;
            this.RealDataGridView.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.RealDataGridView.HeadFont = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RealDataGridView.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.RealDataGridView.Location = new System.Drawing.Point(3, 3);
            this.RealDataGridView.Name = "RealDataGridView";
            this.RealDataGridView.ReadOnly = true;
            this.RealDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RealDataGridView.RowHeadersVisible = false;
            this.RealDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.RealDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.RealDataGridView.RowTemplate.Height = 23;
            this.RealDataGridView.Size = new System.Drawing.Size(504, 694);
            this.RealDataGridView.TabIndex = 0;
            this.RealDataGridView.TitleBack = null;
            this.RealDataGridView.TitleBackColorBegin = System.Drawing.Color.White;
            this.RealDataGridView.TitleBackColorEnd = System.Drawing.Color.White;
            // 
            // historyshow
            // 
            this.historyshow.BackColor = System.Drawing.Color.Transparent;
            this.historyshow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.historyshow.Controls.Add(this.historyPage);
            this.historyshow.Font = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyshow.ForeColor = System.Drawing.Color.White;
            this.historyshow.Location = new System.Drawing.Point(0, 40);
            this.historyshow.Name = "historyshow";
            this.historyshow.Padding = new System.Windows.Forms.Padding(3);
            this.historyshow.Size = new System.Drawing.Size(510, 700);
            this.historyshow.TabIndex = 1;
            this.historyshow.Text = "历史数据记录";
            this.historyshow.UseVisualStyleBackColor = true;
            // 
            // historyPage
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.historyPage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.historyPage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.historyPage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.historyPage.BackgroundColor = System.Drawing.SystemColors.Window;
            this.historyPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.historyPage.ColumnFont = null;
            this.historyPage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.historyPage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.historyPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyPage.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            this.historyPage.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.historyPage.DefaultCellStyle = dataGridViewCellStyle7;
            this.historyPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyPage.EnableHeadersVisualStyles = false;
            this.historyPage.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.historyPage.HeadFont = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyPage.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.historyPage.Location = new System.Drawing.Point(3, 3);
            this.historyPage.Name = "historyPage";
            this.historyPage.ReadOnly = true;
            this.historyPage.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.historyPage.RowHeadersVisible = false;
            this.historyPage.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.historyPage.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.historyPage.RowTemplate.Height = 23;
            this.historyPage.Size = new System.Drawing.Size(504, 694);
            this.historyPage.TabIndex = 1;
            this.historyPage.TitleBack = null;
            this.historyPage.TitleBackColorBegin = System.Drawing.Color.White;
            this.historyPage.TitleBackColorEnd = System.Drawing.Color.White;
            // 
            // actionshow
            // 
            this.actionshow.BackColor = System.Drawing.Color.Transparent;
            this.actionshow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.actionshow.Controls.Add(this.actionPage);
            this.actionshow.Font = new System.Drawing.Font("华文宋体", 14.25F);
            this.actionshow.ForeColor = System.Drawing.Color.White;
            this.actionshow.Location = new System.Drawing.Point(0, 40);
            this.actionshow.Name = "actionshow";
            this.actionshow.Padding = new System.Windows.Forms.Padding(3);
            this.actionshow.Size = new System.Drawing.Size(510, 700);
            this.actionshow.TabIndex = 2;
            this.actionshow.Text = "动作数据记录";
            this.actionshow.UseVisualStyleBackColor = true;
            // 
            // actionPage
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.actionPage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.actionPage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.actionPage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.actionPage.BackgroundColor = System.Drawing.SystemColors.Window;
            this.actionPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.actionPage.ColumnFont = null;
            this.actionPage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("华文宋体", 14.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.actionPage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.actionPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actionPage.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            this.actionPage.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("华文宋体", 14.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.actionPage.DefaultCellStyle = dataGridViewCellStyle11;
            this.actionPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionPage.EnableHeadersVisualStyles = false;
            this.actionPage.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.actionPage.HeadFont = new System.Drawing.Font("华文宋体", 14.25F);
            this.actionPage.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.actionPage.Location = new System.Drawing.Point(3, 3);
            this.actionPage.Name = "actionPage";
            this.actionPage.ReadOnly = true;
            this.actionPage.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.actionPage.RowHeadersVisible = false;
            this.actionPage.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.actionPage.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.actionPage.RowTemplate.Height = 23;
            this.actionPage.Size = new System.Drawing.Size(504, 694);
            this.actionPage.TabIndex = 1;
            this.actionPage.TitleBack = null;
            this.actionPage.TitleBackColorBegin = System.Drawing.Color.White;
            this.actionPage.TitleBackColorEnd = System.Drawing.Color.White;
            // 
            // DataCenterfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(140)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(518, 778);
            this.Controls.Add(this.skinPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataCenterfrm";
            this.ShowBorder = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "杆塔设备数据查询中心(点击选项卡进行切换)";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DataCenterfrm_Load);
            this.Shown += new System.EventHandler(this.DataCenterfrm_Shown);
            this.skinPanel.ResumeLayout(false);
            this.TabRealAndHistroy.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RealDataGridView)).EndInit();
            this.historyshow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.historyPage)).EndInit();
            this.actionshow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.actionPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel;
        private CCWin.SkinControl.SkinTabControl TabRealAndHistroy;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage historyshow;
        private System.Windows.Forms.TabPage actionshow;
        private CCWin.SkinControl.SkinDataGridView RealDataGridView;
        private CCWin.SkinControl.SkinDataGridView historyPage;
        private CCWin.SkinControl.SkinDataGridView actionPage;
    }
}