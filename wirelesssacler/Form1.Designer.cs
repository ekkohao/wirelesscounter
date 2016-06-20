namespace wirelesssacler
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            CCWin.SkinControl.Animation animation2 = new CCWin.SkinControl.Animation();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.TabHistroy = new CCWin.SkinControl.SkinTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.MaDataGridView = new CCWin.SkinControl.SkinDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LightDataGridView = new CCWin.SkinControl.SkinDataGridView();
            this.skinPanel.SuspendLayout();
            this.TabRealAndHistroy.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RealDataGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.TabHistroy.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel
            // 
            this.skinPanel.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel.Controls.Add(this.TabRealAndHistroy);
            this.skinPanel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel.DownBack = null;
            this.skinPanel.Location = new System.Drawing.Point(0, 0);
            this.skinPanel.MouseBack = null;
            this.skinPanel.Name = "skinPanel";
            this.skinPanel.NormlBack = null;
            this.skinPanel.Size = new System.Drawing.Size(553, 471);
            this.skinPanel.TabIndex = 1;
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
            this.TabRealAndHistroy.Controls.Add(this.tabPage4);
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
            this.TabRealAndHistroy.Size = new System.Drawing.Size(553, 471);
            this.TabRealAndHistroy.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabRealAndHistroy.TabIndex = 1;
            this.TabRealAndHistroy.SelectedIndexChanged += new System.EventHandler(this.TabRealAndHistroy_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.RealDataGridView);
            this.tabPage3.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3.ForeColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(553, 431);
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.RealDataGridView.Size = new System.Drawing.Size(547, 425);
            this.RealDataGridView.TabIndex = 0;
            this.RealDataGridView.TitleBack = null;
            this.RealDataGridView.TitleBackColorBegin = System.Drawing.Color.White;
            this.RealDataGridView.TitleBackColorEnd = System.Drawing.Color.White;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(90)))));
            this.tabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage4.Controls.Add(this.TabHistroy);
            this.tabPage4.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage4.ForeColor = System.Drawing.Color.White;
            this.tabPage4.Location = new System.Drawing.Point(0, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(553, 431);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "历史数据记录";
            // 
            // TabHistroy
            // 
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.TabHistroy.Animation = animation2;
            this.TabHistroy.AnimatorType = CCWin.SkinControl.AnimationType.Custom;
            this.TabHistroy.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.TabHistroy.Controls.Add(this.tabPage1);
            this.TabHistroy.Controls.Add(this.tabPage2);
            this.TabHistroy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabHistroy.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabHistroy.HeadBack = null;
            this.TabHistroy.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.TabHistroy.ItemSize = new System.Drawing.Size(80, 30);
            this.TabHistroy.Location = new System.Drawing.Point(3, 3);
            this.TabHistroy.Multiline = true;
            this.TabHistroy.Name = "TabHistroy";
            this.TabHistroy.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("TabHistroy.PageArrowDown")));
            this.TabHistroy.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("TabHistroy.PageArrowHover")));
            this.TabHistroy.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("TabHistroy.PageCloseHover")));
            this.TabHistroy.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("TabHistroy.PageCloseNormal")));
            this.TabHistroy.PageDown = ((System.Drawing.Image)(resources.GetObject("TabHistroy.PageDown")));
            this.TabHistroy.PageHover = ((System.Drawing.Image)(resources.GetObject("TabHistroy.PageHover")));
            this.TabHistroy.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.TabHistroy.PageNorml = null;
            this.TabHistroy.SelectedIndex = 0;
            this.TabHistroy.Size = new System.Drawing.Size(547, 425);
            this.TabHistroy.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabHistroy.TabIndex = 0;
            this.TabHistroy.SelectedIndexChanged += new System.EventHandler(this.TabHistroy_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.MaDataGridView);
            this.tabPage1.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.ForeColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(0, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(547, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "历史记录";
            // 
            // MaDataGridView
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.MaDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.MaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.MaDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MaDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.MaDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MaDataGridView.ColumnFont = null;
            this.MaDataGridView.ColumnForeColor = System.Drawing.Color.Black;
            this.MaDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.MaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MaDataGridView.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            this.MaDataGridView.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MaDataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.MaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaDataGridView.EnableHeadersVisualStyles = false;
            this.MaDataGridView.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.MaDataGridView.HeadFont = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaDataGridView.HeadForeColor = System.Drawing.Color.Black;
            this.MaDataGridView.HeadSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            this.MaDataGridView.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.MaDataGridView.Location = new System.Drawing.Point(3, 3);
            this.MaDataGridView.Name = "MaDataGridView";
            this.MaDataGridView.ReadOnly = true;
            this.MaDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MaDataGridView.RowHeadersVisible = false;
            this.MaDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.MaDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.MaDataGridView.RowTemplate.Height = 23;
            this.MaDataGridView.Size = new System.Drawing.Size(541, 389);
            this.MaDataGridView.TabIndex = 0;
            this.MaDataGridView.TitleBack = null;
            this.MaDataGridView.TitleBackColorBegin = System.Drawing.Color.White;
            this.MaDataGridView.TitleBackColorEnd = System.Drawing.Color.White;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LightDataGridView);
            this.tabPage2.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.ForeColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(0, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(547, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "动作记录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LightDataGridView
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.LightDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.LightDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.LightDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.LightDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.LightDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LightDataGridView.ColumnFont = null;
            this.LightDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LightDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.LightDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LightDataGridView.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            this.LightDataGridView.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LightDataGridView.DefaultCellStyle = dataGridViewCellStyle11;
            this.LightDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightDataGridView.EnableHeadersVisualStyles = false;
            this.LightDataGridView.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LightDataGridView.HeadFont = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LightDataGridView.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.LightDataGridView.Location = new System.Drawing.Point(3, 3);
            this.LightDataGridView.Name = "LightDataGridView";
            this.LightDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LightDataGridView.RowHeadersVisible = false;
            this.LightDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(176)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.LightDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.LightDataGridView.RowTemplate.Height = 23;
            this.LightDataGridView.Size = new System.Drawing.Size(541, 389);
            this.LightDataGridView.TabIndex = 1;
            this.LightDataGridView.TitleBack = null;
            this.LightDataGridView.TitleBackColorBegin = System.Drawing.Color.White;
            this.LightDataGridView.TitleBackColorEnd = System.Drawing.Color.White;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(553, 471);
            this.Controls.Add(this.skinPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DataCenterfrm_Load);
            this.Shown += new System.EventHandler(this.DataCenterfrm_Shown);
            this.skinPanel.ResumeLayout(false);
            this.TabRealAndHistroy.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RealDataGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.TabHistroy.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MaDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LightDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinTabControl TabRealAndHistroy;
        private System.Windows.Forms.TabPage tabPage3;
        private CCWin.SkinControl.SkinDataGridView RealDataGridView;
        private System.Windows.Forms.TabPage tabPage4;
        private CCWin.SkinControl.SkinTabControl TabHistroy;
        private System.Windows.Forms.TabPage tabPage1;
        private CCWin.SkinControl.SkinDataGridView MaDataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private CCWin.SkinControl.SkinDataGridView LightDataGridView;
        private CCWin.SkinControl.SkinPanel skinPanel;
    }
}