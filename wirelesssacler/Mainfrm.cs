using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using MySqlCon;

using CCWin;
using CCWin.SkinControl;
using CCWin.SkinClass;
using System.IO;
using Aspose.Cells;
using System.Configuration;
using CommunicationProtocol;
using System.Xml;
using System.Threading;
using System.Runtime.InteropServices;
using _CUSTOM_CONTROLS;

namespace wirelesssacler
{
    public partial class Mainfrm : Skin_VS
    {
        public Mainfrm()
        {
            InitializeComponent();
            //  this.ShowInTaskbar = false;
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            //SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            Point sp = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Left = sp.X - this.Width - 100; // dp.X + 600;           
            this.Top = (sp.Y - this.Height) / 2;
            mysql = new SqlHelp();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path2 = "设备清单";
            string filepath = Path.Combine(path, path2);
            if (Directory.Exists(filepath) == false)
            {
                Directory.CreateDirectory(filepath);
            }
            GetMyProVersion = GetAppConfig("ProtocolVersion");
            if (GetMyProVersion != null)
            {
                //读取成功数据
                if (GetMyProVersion == "1.0.0.0")//奇数带全电流
                {
                    MyProConnect = new CommunicationProtocol.CommunicateWithOutmA();
                    //不带全电流，则历史记录不能获取，关闭相关功能


                    MyProConnect.Name = GetMyProVersion;
                    DownLoadRecentHistroy.Enabled = false;
                    DownRecentHistroy.Enabled = false;

                }
                else if (GetMyProVersion == "2.0.0.0")//偶数带全电流
                {
                    MyProConnect = new CommunicationProtocol.CommunicateWithmA();
                    MyProConnect.Name = GetMyProVersion;
                    DownLoadRecentHistroy.Enabled = true;
                    DownRecentHistroy.Enabled = true;
                }




                // this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true); 
            }
            // MessageBox.Show(MyProConnect.Name);
            DataTable dt = mysql.ReturnTable("select * from `Dev_List`");
            if (dt.Rows.Count > 0)
            {
                SequenceWithStrToByte Sequence = new SequenceWithStrToByte();
                Device initdevice;
                string notyms = "ok";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    initdevice.number = dt.Rows[i]["Dev_ID"].ToString();
                    initdevice.phase = dt.Rows[i]["Dev_Phase"].ToString();
                    initdevice.addr = dt.Rows[i]["Dev_Addr"].ToString();
                    byte[] ad = Sequence.SeqStrToByte(initdevice.number, ref notyms);
                    if (ad != null)
                    {
                        initdevice.sqeuence = ad;
                        _PData.AddLast(initdevice);
                    }
                }

            }


        }

        private SqlHelp mysql;

        private string CurrentNumber;//鼠标点击时设备序列
        private string CurentGroup;//鼠标点击分组的名称

        private UsewireCom WireCom;

        private CommunicationProtocol.ProtoColConnect MyProConnect;
        private string MyprotocolVersion = null;
        public LinkedList<Device> _PData = new LinkedList<Device>();

        private string MyPort = null;
        private int MyRate = 9600;

        //管理窗口
        private static Form1 manger2 = new Form1();
        //数据窗口
        private static Form2 center = new Form2();

        public string GetMyProVersion
        {
            get
            {
                return MyprotocolVersion;
            }
            set
            {
                MyprotocolVersion = value;
            }
        }

        /// <summary>
        /// 返回＊.exe.config文件中appSettings配置节的value项
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    string strvalue = ConfigurationManager.AppSettings[strKey];
                    if (strvalue == "")
                    {
                        return null;
                    }
                    else
                    {
                        return strvalue;
                    }
                }
            }
            return null;
        }


        private void Mainfrm_Load(object sender, EventArgs e)
        {
            //初始化俩个窗体
            manger2.MdiParent = this;

            manger2.Parent = this.devtab.TabPages[2];
            manger2.Dock = DockStyle.Fill;

            //manger_RefreshNow
            center.MdiParent = this;
            center.RefreshNow += manger_RefreshNow;
            center.Parent = this.devtab.TabPages[3];
            center.Dock = DockStyle.Fill;

            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;

            //  Connectfrm con = new Connectfrm();

            //  if (con.ShowDialog() == DialogResult.OK)
            //  {
            //      MyPort = con.UsePort;

            //      if (MyProConnect != null)
            //      {
            //          //读取协议
            //          WireCom = new UsewireCom(MyPort, MyRate, MyProConnect.Name, MyProConnect,_PData);
            //          try
            //          {

            //              //ConPort.Open();
            //              bool ok = WireCom.openPort();
            //              if (ok)
            //              {
            //                  pic_Com.BackgroundImage = Properties.Resources.online;

            //              }
            //          }
            //          catch
            //          {
            //              MessageBox.Show("串口打开失败!");
            //          }
            //      }
            //      else
            //      {
            //          MessageBox.Show("配置协议失败:无协议");

            //      }


            //  }
            //  con.Dispose();

            //  //加载设备到列表中
            //  AddDevToList();


            //DataTable  ds=  mysql.ReturnTable("select * from Dev_List");
            //  if(ds.Rows.Count>0)
            //  {
            //      for (int k = 0; k < ds.Rows.Count;k++)
            //      {
            //          string v = ds.Rows[k]["Dev_ID"].ToString();
            //          string s = ds.Rows[k]["Dev_Addr"].ToString();
            //          txtSearch.AutoCompleteCustomSource.Add(v);
            //          txtSearch.AutoCompleteCustomSource.Add(s);
            //      }
            //  }

        }
        // using System.Runtime.InteropServices;

        //然后写API引用部分的代码，放入 class 内部
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        const int WM_SYSCOMMAND = 0x112;
        const int SC_CLOSE = 0xF060;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Maximized;
            IntPtr hwnd = this.Handle;
            SendMessage(hwnd, WM_SYSCOMMAND, SC_MAXIMIZE, 0); // 最大化
        }
        //获取数据到txt列表中
        private void AddDevToList()
        {
            //添加设备
            //添加选项卡一的设备
            //添加选项卡二的设备
            //添加选项卡三的设备

            DataTable dt = mysql.ReturnTable("select * from `Dev_List`");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                    cst.DisplayName = dt.Rows[i]["Dev_ID"].ToString();
                    cst.NicName = "监测路线位置：" + dt.Rows[i]["Dev_Phase"].ToString();
                    cst.PersonalMsg = "所在杆塔位置：" + dt.Rows[i]["Dev_Addr"].ToString();
                    cst.HeadImage = Properties.Resources.dev;
                    AllListBox.Items[0].SubItems.Add(cst);

                }
                //选项卡2
                DataTable dtcopy = dt.Copy();
                DataView dv = dt.DefaultView;
                dv.Sort = "Dev_Addr";
                dtcopy = dv.ToTable();
                for (int j = 0; j < dtcopy.Rows.Count; j++)
                {
                    //添加第一次循环数据
                    _CUSTOM_CONTROLS._ChatListBox2.ChatListItem lt = new _CUSTOM_CONTROLS._ChatListBox2.ChatListItem();
                    lt.Text = dtcopy.Rows[j]["Dev_Addr"].ToString();
                    _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                    cst.DisplayName = dtcopy.Rows[j]["Dev_ID"].ToString();
                    cst.NicName = "监测路线位置：" + dtcopy.Rows[j]["Dev_Phase"].ToString();
                    cst.PersonalMsg = "所在杆塔位置：" + dtcopy.Rows[j]["Dev_Addr"].ToString();
                    cst.HeadImage = cst.HeadImage = Properties.Resources.dev; //; Image.FromFile("./img/dev.jpg");
                    lt.SubItems.Add(cst);

                    for (int k = j + 1; k < dtcopy.Rows.Count; k++)
                    {

                        //  MessageBox.Show(dt.Rows[j]["Dev_Addr"].ToString() + "----" + dt.Rows[k]["Dev_Addr"].ToString());
                        string str1 = dtcopy.Rows[j]["Dev_Addr"].ToString();
                        string str2 = dtcopy.Rows[k]["Dev_Addr"].ToString();

                        if (String.Compare(str1, str2) == 0)
                        {

                            _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst2 = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                            cst2.DisplayName = dtcopy.Rows[k]["Dev_ID"].ToString();
                            cst2.NicName = "监测路线位置：" + dtcopy.Rows[k]["Dev_Phase"].ToString();
                            cst2.PersonalMsg = "所在杆塔位置：" + dtcopy.Rows[k]["Dev_Addr"].ToString();
                            cst2.HeadImage = cst.HeadImage = Properties.Resources.dev;// Image.FromFile("./img/dev.jpg");
                            lt.SubItems.Add(cst2);
                            j++;//找到一行一样加入，并跳过此行 

                        }


                    }
                    GroupListBox.Items.Add(lt);

                }

            }
            else
            {
                MessageBox.Show("加载失败，设备数据为空，请手动加入设备清单");
            }

        }
        private void AddDevToList2()
        {
            //添加设备
            //添加选项卡一的设备
            //添加选项卡二的设备

            DataTable dt = mysql.ReturnTable("select * from `Dev_List`");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                    cst.DisplayName = dt.Rows[i]["Dev_ID"].ToString();
                    cst.NicName = "监测路线位置：" + dt.Rows[i]["Dev_Phase"].ToString();
                    cst.PersonalMsg = "所在杆塔位置：" + dt.Rows[i]["Dev_Addr"].ToString();
                    cst.HeadImage = Properties.Resources.dev;
                    AllListBox.Items[0].SubItems.Add(cst);

                }
                //选项卡2
                DataTable dtcopy = dt.Copy();
                DataView dv = dt.DefaultView;
                dv.Sort = "Dev_Addr";
                dtcopy = dv.ToTable();
                for (int j = 0; j < dtcopy.Rows.Count; j++)
                {
                    //添加第一次循环数据
                    _CUSTOM_CONTROLS._ChatListBox2.ChatListItem lt = new _CUSTOM_CONTROLS._ChatListBox2.ChatListItem();
                    lt.Text = dtcopy.Rows[j]["Dev_Addr"].ToString();
                    _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                    cst.DisplayName = dtcopy.Rows[j]["Dev_ID"].ToString();
                    cst.NicName = "监测路线位置：" + dtcopy.Rows[j]["Dev_Phase"].ToString();
                    cst.PersonalMsg = "所在杆塔位置：" + dtcopy.Rows[j]["Dev_Addr"].ToString();
                    cst.HeadImage = cst.HeadImage = Properties.Resources.dev; //; Image.FromFile("./img/dev.jpg");
                    lt.SubItems.Add(cst);

                    for (int k = j + 1; k < dtcopy.Rows.Count; k++)
                    {

                        //  MessageBox.Show(dt.Rows[j]["Dev_Addr"].ToString() + "----" + dt.Rows[k]["Dev_Addr"].ToString());
                        string str1 = dtcopy.Rows[j]["Dev_Addr"].ToString();
                        string str2 = dtcopy.Rows[k]["Dev_Addr"].ToString();

                        if (String.Compare(str1, str2) == 0)
                        {

                            _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst2 = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                            cst2.DisplayName = dtcopy.Rows[k]["Dev_ID"].ToString();
                            cst2.NicName = "监测路线位置：" + dtcopy.Rows[k]["Dev_Phase"].ToString();
                            cst2.PersonalMsg = "所在杆塔位置：" + dtcopy.Rows[k]["Dev_Addr"].ToString();
                            cst2.HeadImage = cst.HeadImage = Properties.Resources.dev;// Image.FromFile("./img/dev.jpg");
                            lt.SubItems.Add(cst2);
                            j++;//找到一行一样加入，并跳过此行 

                        }


                    }
                    GroupListBox.Items.Add(lt);

                }

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") return;
            SerchfrmDate(txtSearch.Text);
            //txtSearch.Text = "";

        }

        private void SerchfrmDate(string Data)
        {
            Messagefrm mfrm = new Messagefrm(Data, MyProConnect.Name);
            mfrm.Doquery += new Messagefrm.DoQuery(QuerySerch);
            mfrm.DoqueryAddr += new Messagefrm.DoQueryAddr(QuerySerchAddr);
            mfrm.Dolight += mfrm_Dolight;
            mfrm.Dolightaddr += mfrm_Dolightaddr;
            mfrm.Show();
        }

        void mfrm_Dolightaddr(string add)
        {
            //throw new NotImplementedException();
            //动作记录
            LightGroupfrm grop = new LightGroupfrm(add);
            grop.Query += new LightGroupfrm.queryLight(Querylight);
            if (grop.ShowDialog() == DialogResult.Yes)
            {
                grop.Query -= new LightGroupfrm.queryLight(Querylight);
            }
            grop.Dispose();

        }

        void mfrm_Dolight(string num)
        {
            LightCountfrm lc = new LightCountfrm(num);
            lc.Query += new LightCountfrm.queryLight(Querylight);

            if (lc.ShowDialog() == DialogResult.Yes)
            {
                lc.Query -= new LightCountfrm.queryLight(Querylight);
            }
            lc.Dispose();
        }

        private void QuerySerchAddr(string add, bool isreal)
        {
            //throw new NotImplementedException();
            if (isreal)
            {
                CallGroupfrm grop = new CallGroupfrm(add, true, GetMyProVersion);
                grop.callRealData += new CallGroupfrm.CallReal(this.sendGroupReal);

                if (grop.ShowDialog() == DialogResult.Yes)
                {
                    grop.callRealData -= new CallGroupfrm.CallReal(this.sendGroupReal);
                }
                grop.Dispose();
            }
            else
            {

                CallGroupfrm grop = new CallGroupfrm(add, false, GetMyProVersion);
                grop.callHistroyData += new CallGroupfrm.CallHistroy(sendGroupHistroy);

                if (grop.ShowDialog() == DialogResult.Yes)
                {
                    grop.callHistroyData -= new CallGroupfrm.CallHistroy(sendGroupHistroy);
                }
                grop.Dispose();
            }
        }

        //下载序列数据，true实时，false 历史
        private void QuerySerch(string num, bool isreal)
        {
            if (isreal) //下载序列的实时数据
            {
                CallCurrentFrom call = new CallCurrentFrom(num, true, GetMyProVersion);
                call.callRealData += new CallCurrentFrom.CallReal(sendOneReal);


                if (call.ShowDialog() == DialogResult.Yes)
                {
                    call.callRealData -= new CallCurrentFrom.CallReal(sendOneReal);
                }
                call.Dispose();
            }
            else  //下载序列的历史数据
            {
                CallCurrentFrom call = new CallCurrentFrom(num, false, GetMyProVersion);
                call.callHistroyData += new CallCurrentFrom.CallHistroy(sendOneHistroy);
                if (call.ShowDialog() == DialogResult.Yes)
                {
                    call.callHistroyData -= new CallCurrentFrom.CallHistroy(sendOneHistroy);
                }
                call.Dispose();
            }
        }

        private void pic_Com_Click(object sender, EventArgs e)
        {
            //if(WireCom==null)
            //{
            //     WireCom = new UsewireCom(MyPort,MyRate, MyProConnect.Name, MyProConnect, _PData);
            //}
            if (WireCom != null && WireCom.getIsOpen())
            {
                ConClosefrm close = new ConClosefrm(WireCom._CComPort.PortName, WireCom._CComPort.BaudRate.ToString(), WireCom._CComPort.DataBits.ToString(), WireCom._CComPort.StopBits.ToString());
                if (DialogResult.OK == close.ShowDialog())
                {
                    WireCom.closePort();
                    pic_Com.BackgroundImage = Properties.Resources.offline;
                }

            }
            else
            {
                Connectfrm con = new Connectfrm();

                if (con.ShowDialog() == DialogResult.OK)
                {
                    MyPort = con.UsePort;
                    con.Close();

                    //连接串口,并打开

                    if (MyProConnect != null)
                    {
                        //读取协议
                        WireCom = new UsewireCom(MyPort, MyRate, MyProConnect.Name, MyProConnect, _PData);
                        try
                        {
                            WireCom.openPort();
                            pic_Com.BackgroundImage = Properties.Resources.online;
                        }
                        catch
                        {
                            MessageBox.Show("串口打开失败!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("配置协议失败:无协议");
                        return;
                    }

                }
                con.Dispose();
            }
        }

        private void toolMenu_Click(object sender, EventArgs e)
        {

            MangerMenu.Show(SkToolCdTwo, new Point(3, -2), ToolStripDropDownDirection.AboveRight);

            //  toolMenu.Checked = true;
        }

        private void tsb_SysSet_Click(object sender, EventArgs e)
        {
            SystemSetMenu.Show(SkToolCdTwo, new Point(40, -2), ToolStripDropDownDirection.AboveRight);

        }


        private void tsb_openfile_Click(object sender, EventArgs e)
        {
            //打开文件夹
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path2 = "导出数据文件夹";
            string filepath = Path.Combine(path, path2);
            if (Directory.Exists(filepath))
            {
                System.Diagnostics.Process.Start("explorer.exe", filepath);
            }
            else
            {
                //
                MessageBox.Show("导出数据文件夹不存在！");
            }


        }

        private void outList_Click(object sender, EventArgs e)
        {
            SqlHelp outsql = new SqlHelp();
            DataTable ot = outsql.ReturnTable("select * from `Dev_List`");
            string filename = "导出设备清单-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xls";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path2 = "设备清单";
            path = Path.Combine(path, path2);
            string filepath = Path.Combine(path, filename);
            if (File.Exists(filepath))
                System.IO.File.Delete(filepath); // 判断文件名是否已存在

            if (ot != null)
            {

                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet cellSheet = workbook.Worksheets[0];
                //为单元格添加样式      
                Aspose.Cells.Style style = workbook.Styles[workbook.Styles.Add()];
                //设置居中  
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                //设置背景颜色  
                style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                //列名的处理  
                #region  列名的处理
                {
                    //cellSheet.Cells[rowIndex, colIndex].PutValue(dt.Columns[i].ColumnName);
                    //cellSheet.Cells[rowIndex, colIndex].Style.Font.IsBold = true;
                    //cellSheet.Cells[rowIndex, colIndex].Style.Font.Name = "宋体";
                    //cellSheet.Cells[rowIndex, colIndex].Style = style; 
                    cellSheet.Cells[0, 0].PutValue("ID");
                    cellSheet.Cells[0, 1].PutValue("设备ID");
                    cellSheet.Cells[0, 2].PutValue("设备地址");
                    cellSheet.Cells[0, 3].PutValue("监测路线位置");


                }
                #endregion

                #region 填入数据
                {

                    int rowIndex = 1;
                    for (int i = 0; i < ot.Rows.Count; i++)
                    {
                        cellSheet.Cells[rowIndex, 0].PutValue(ot.Rows[i][0]);
                        cellSheet.Cells[rowIndex, 1].PutValue(ot.Rows[i][1]);
                        cellSheet.Cells[rowIndex, 2].PutValue(ot.Rows[i][2]);
                        cellSheet.Cells[rowIndex, 3].PutValue(ot.Rows[i][3]);

                        rowIndex++;
                    }
                }

                #endregion

                cellSheet.AutoFitColumns();

                workbook.Save(Path.GetFullPath(filepath));




            }

            MessageBox.Show("已导出设备清单");

        }

        private void importList_Click(object sender, EventArgs e)
        {
            ImportDevfrm import = new ImportDevfrm();
            import.refresh += new ImportDevfrm.RefashList(ReFreList);
            import.Show();
        }

        private void ReFreList()
        {
            //刷新设备
            AllListBox.Items[0].SubItems.Clear();
            GroupListBox.Items.Clear();
            AddDevToList2();
            _PData.Clear();
            //更新设备列表
            DataTable dt = mysql.ReturnTable("select * from `Dev_List`");
            if (dt.Rows.Count > 0)
            {
                SequenceWithStrToByte Sequence = new SequenceWithStrToByte();
                Device initdevice;
                string notyms = "ok";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    initdevice.number = dt.Rows[i]["Dev_ID"].ToString();
                    initdevice.phase = dt.Rows[i]["Dev_Phase"].ToString();
                    initdevice.addr = dt.Rows[i]["Dev_Addr"].ToString();
                    byte[] ad = Sequence.SeqStrToByte(initdevice.number, ref notyms);
                    if (ad != null)
                    {
                        initdevice.sqeuence = ad;
                        _PData.AddLast(initdevice);
                    }
                }

            }
            //更新协议里面的设备列表
            if (WireCom != null)
            {
                WireCom.RefreshList(_PData);
            }

        }

        private void MangerMenuItem_Click(object sender, EventArgs e)
        {
            MangerDevfrm manger = new MangerDevfrm();
            manger.RefreshNow += manger_RefreshNow;
            manger.Show();
        }

        void manger_RefreshNow()
        {
            //刷新列表
            ReFreList();
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmItemDatacenter_Click(object sender, EventArgs e)
        {
            DataCenterfrm center = new DataCenterfrm();
            center.Show();
        }

        private void tsmItem_reflash_Click(object sender, EventArgs e)
        {
            DataTable dt = mysql.ReturnTable("select * from `Dev_List`");
            if (dt.Rows.Count > 0)
            {
                AllListBox.Items[0].SubItems.Clear();
                DataTable dtcopy2 = dt.Copy();
                DataView dv2 = dt.DefaultView;
                dv2.Sort = "Dev_Addr";
                dtcopy2 = dv2.ToTable();
                for (int i = 0; i < dtcopy2.Rows.Count; i++)
                {
                    _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                    cst.DisplayName = dt.Rows[i]["Dev_ID"].ToString();
                    cst.NicName = "监测路线位置：" + dt.Rows[i]["Dev_Phase"].ToString();
                    cst.PersonalMsg = "所在杆塔位置：" + dt.Rows[i]["Dev_Addr"].ToString();
                    cst.HeadImage = cst.HeadImage = Properties.Resources.dev; //Image.FromFile("./img/dev.jpg");
                    AllListBox.Items[0].SubItems.Add(cst);

                }
                DataTable dtcopy = dt.Copy();
                DataView dv = dt.DefaultView;
                dv.Sort = "Dev_Addr";
                dtcopy = dv.ToTable();
                GroupListBox.Items.Clear();
                for (int j = 0; j < dtcopy.Rows.Count; j++)
                {
                    //添加第一次循环数据
                    _CUSTOM_CONTROLS._ChatListBox2.ChatListItem lt = new _CUSTOM_CONTROLS._ChatListBox2.ChatListItem();
                    lt.Text = dtcopy.Rows[j]["Dev_Addr"].ToString();
                    _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                    cst.DisplayName = dtcopy.Rows[j]["Dev_ID"].ToString();
                    cst.NicName = "监测路线位置：" + dtcopy.Rows[j]["Dev_Phase"].ToString();
                    cst.PersonalMsg = "所在杆塔位置：" + dtcopy.Rows[j]["Dev_Addr"].ToString();
                    cst.HeadImage = cst.HeadImage = Properties.Resources.dev; // Image.FromFile("./img/dev.jpg");
                    lt.SubItems.Add(cst);

                    for (int k = j + 1; k < dtcopy.Rows.Count; k++)
                    {

                        //  MessageBox.Show(dt.Rows[j]["Dev_Addr"].ToString() + "----" + dt.Rows[k]["Dev_Addr"].ToString());
                        string str1 = dtcopy.Rows[j]["Dev_Addr"].ToString();
                        string str2 = dtcopy.Rows[k]["Dev_Addr"].ToString();

                        if (String.Compare(str1, str2) == 0)
                        {

                            _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst2 = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                            cst2.DisplayName = dtcopy.Rows[k]["Dev_ID"].ToString();
                            cst2.NicName = "监测路线位置：" + dtcopy.Rows[k]["Dev_Phase"].ToString();
                            cst2.PersonalMsg = "所在杆塔位置：" + dtcopy.Rows[k]["Dev_Addr"].ToString();
                            cst2.HeadImage = cst.HeadImage = Properties.Resources.dev; // Image.FromFile("./img/dev.jpg");
                            lt.SubItems.Add(cst2);
                            j++;//找到一行一样加入，并跳过此行 

                        }


                    }
                    GroupListBox.Items.Add(lt);
                }
            }
        }

        private void tsmItemSortbyid_Click(object sender, EventArgs e)
        {

            DataTable dt = mysql.ReturnTable("select * from `Dev_List`");
            if (dt.Rows.Count > 0)
            {

                DataTable dtcopy = dt.Copy();
                DataView dv = dt.DefaultView;
                dv.Sort = "Dev_ID";
                dtcopy = dv.ToTable();
                AllListBox.Items[0].SubItems.Clear();
                for (int j = 0; j < dtcopy.Rows.Count; j++)
                {
                    //添加第一次循环数据

                    _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                    cst.DisplayName = dtcopy.Rows[j]["Dev_ID"].ToString();
                    cst.NicName = "监测路线位置：" + dtcopy.Rows[j]["Dev_Phase"].ToString();
                    cst.PersonalMsg = "所在杆塔位置：" + dtcopy.Rows[j]["Dev_Addr"].ToString();
                    cst.HeadImage = cst.HeadImage = Properties.Resources.dev; //Image.FromFile("./img/dev.jpg");

                    AllListBox.Items[0].SubItems.Add(cst);
                }
            }

        }

        private void tsmItemSortbyphase_Click(object sender, EventArgs e)
        {
            DataTable dt = mysql.ReturnTable("select * from `Dev_List`");
            if (dt.Rows.Count > 0)
            {
                AllListBox.Items[0].SubItems.Clear();
                DataTable dtcopy = dt.Copy();
                DataView dv = dt.DefaultView;
                dv.Sort = "Dev_Phase";
                dtcopy = dv.ToTable();

                for (int j = 0; j < dtcopy.Rows.Count; j++)
                {
                    //添加第一次循环数据
                    _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                    cst.DisplayName = dtcopy.Rows[j]["Dev_ID"].ToString();
                    cst.NicName = "监测路线位置：" + dtcopy.Rows[j]["Dev_Phase"].ToString();
                    cst.PersonalMsg = "所在杆塔位置：" + dtcopy.Rows[j]["Dev_Addr"].ToString();
                    cst.HeadImage = cst.HeadImage = Properties.Resources.dev; //Image.FromFile("./img/dev.jpg");

                    AllListBox.Items[0].SubItems.Add(cst);
                }
            }
        }

        private void tsmItemSortbyaddr_Click(object sender, EventArgs e)
        {
            DataTable dt = mysql.ReturnTable("select * from `Dev_List`");
            if (dt.Rows.Count > 0)
            {

                DataTable dtcopy = dt.Copy();
                DataView dv = dt.DefaultView;
                dv.Sort = "Dev_Addr";
                dtcopy = dv.ToTable();
                AllListBox.Items[0].SubItems.Clear();
                for (int j = 0; j < dtcopy.Rows.Count; j++)
                {
                    //添加第一次循环数据
                    _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem cst = new _CUSTOM_CONTROLS._ChatListBox2.ChatListSubItem();
                    cst.DisplayName = dtcopy.Rows[j]["Dev_ID"].ToString();
                    cst.NicName = "监测路线位置：" + dtcopy.Rows[j]["Dev_Phase"].ToString();
                    cst.PersonalMsg = "所在杆塔位置：" + dtcopy.Rows[j]["Dev_Addr"].ToString();
                    cst.HeadImage = cst.HeadImage = Properties.Resources.dev;// Image.FromFile("./img/dev.jpg");

                    AllListBox.Items[0].SubItems.Add(cst);
                }
            }
        }

        private void queryMenu_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            try
            {
                CallMutinData call = new CallMutinData(GetMyProVersion);
                call.CallRealData += new CallMutinData.MutinRealdata(sendMultitermReal);
                call.CallHistroyData += new CallMutinData.MutinHistroydata(sendMultitermHistroy);
                call.CallLight += call_CallLight;
                call.CallHistroyData2 += new CallMutinData.MutinHistroydata2(SendLastDayHistroyData);
                call.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private BackState SendLastDayHistroyData(string number, int day, out string err, out int num)
        {
            return WireCom.SendOneHistroy(number, day, out err, out num);
        }

        private bool call_CallLight(string p, int total, int old, out string err)
        {

            bool call = WireCom.Query_Light2(p, total, old, out err);//Query_Light2(string CurrentNumber, int count,int start, out string err)
            return false;
        }

        private void tbMenu_QueryCenter_Click(object sender, EventArgs e)
        {
            DataCenterfrm cet = new DataCenterfrm();
            cet.Show();
        }

        private void ToolStripMenuItem_Query_Click(object sender, EventArgs e)
        {
            QueryCurrentfrm qgfrm = new QueryCurrentfrm(CurrentNumber);
            qgfrm.Show();
        }

        private void MenuItemCallCurrent_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            CallCurrentFrom call = new CallCurrentFrom(CurrentNumber, true, GetMyProVersion);
            call.callRealData += new CallCurrentFrom.CallReal(sendOneReal);

            if (call.ShowDialog() == DialogResult.Yes)
            {
                call.callRealData -= new CallCurrentFrom.CallReal(sendOneReal);
            }
            call.Dispose();
        }

        private void MenuItem_quer2hours_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            CallCurrentFrom call = new CallCurrentFrom(CurrentNumber, false, GetMyProVersion);
            call.callHistroyData += new CallCurrentFrom.CallHistroy(sendOneHistroy);
            if (call.ShowDialog() == DialogResult.Yes)
            {
                call.Visible = false;
                call.callHistroyData -= new CallCurrentFrom.CallHistroy(sendOneHistroy);

            }
            call.Dispose();

        }

        private void ToolStripMenuItemInit_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            byte[] initfo = new byte[8];
            //检测报文
            string number = CurrentNumber;
            Initdevfrom init = new Initdevfrom(initfo, number);
            init.InitDev += new Initdevfrom.InitDevice(this.InitDev);
            if (init.ShowDialog() == DialogResult.OK)
            {

                init.InitDev -= new Initdevfrom.InitDevice(this.InitDev);
                init.Close();
            }

            init.Dispose();
        }

        private void QueryRecordMenu_Click(object sender, EventArgs e)
        {
            QueryGroupForm grop = new QueryGroupForm(CurentGroup);

            grop.Show();
        }

        private void CallGroupHistroyMenu_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            CallGroupfrm grop = new CallGroupfrm(CurentGroup, false, GetMyProVersion);
            grop.callHistroyData += new CallGroupfrm.CallHistroy(this.sendGroupHistroy);
            grop.ShowDialog();
            grop.Dispose();
        }


        private void CallgroupMenu_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            CallGroupfrm grop = new CallGroupfrm(CurentGroup, true, GetMyProVersion);
            grop.callRealData += new CallGroupfrm.CallReal(this.sendGroupReal);
            if (grop.ShowDialog() == DialogResult.Yes)
            {
                grop.callRealData -= new CallGroupfrm.CallReal(this.sendGroupReal);
            }
            grop.Dispose();
        }


        private void AllListBox_MouseUpItem(object sender, _CUSTOM_CONTROLS._ChatListBox2.ChatListEventArgs e)
        {
            CurentGroup = e.SelectItem.Text;
            if (e.Button == MouseButtons.Right)
                ChatAllDevItemMenu.Show(Cursor.Position);
        }
        private void AllListBox_MouseUpSubItem(object sender, _CUSTOM_CONTROLS._ChatListBox2.ChatListEventArgs e)
        {
            CurrentNumber = e.SelectSubItem.DisplayName;
            if (e.Button == MouseButtons.Right)
                UserMenu.Show(Cursor.Position);
        }
        private void GroupListBox_MouseUpItem(object sender, _CUSTOM_CONTROLS._ChatListBox2.ChatListEventArgs e)
        {
            CurentGroup = e.SelectItem.Text;
            if (e.Button == MouseButtons.Right)
                ChatGropuMenu.Show(Cursor.Position);
        }

        private void GroupListBox_MouseUpSubItem(object sender, _CUSTOM_CONTROLS._ChatListBox2.ChatListEventArgs e)
        {
            CurrentNumber = e.SelectSubItem.DisplayName;
            if (e.Button == MouseButtons.Right)
                UserMenu.Show(Cursor.Position);
        }

        //private void chatlb_Group_Click(object sender, EventArgs e)
        //{
        //    //this.VerticalScroll.
        //    if (this.GroupListBox.SelectItem != null)
        //               CurentGroup = this.chatlb_Group.SelectItem.Text;

        //}

        #region 召测设备数据被调用函数

        //1个初始化，2个召测数据，实时数据和历史数据(分组和单个和多个)，7个,外加动作记录数据查询

        //设备初始化函数，若收到数据，请置Initdevfrom.Isback=true;
        private BackState InitDev()
        {
            BackState init = BackState.No;
            init = WireCom.InitDev(CurrentNumber);
            //发送报文
            // MessageBox.Show(CurrentNumber);
            return init;
        }

        //发送1个设备实时的报文
        private BackState sendOneReal(string num)
        {
            BackState bs = WireCom.sendOneReal(num);
            //发送一个设备的地址
            //  bs.bs = BackState.Yes;

            return bs;
        }

        //发送1个设备4小时记录的报文
        private BackState sendOneHistroy(string number, out string msg, out int num)
        {
            //发送一个设备的地址
            BackState bs = WireCom.SendOneHistroy(number, out msg, out num);

            return bs;
        }


        //根据分组发送1组设备实时记录的报文
        private BackState sendGroupReal(string addr)
        {

            //根据分组发送1组设备实时的报文
            BackState bs = WireCom.sendOneReal(addr);

            return bs;
        }
        //根据分组发送1组设备2小时记录的报文
        private BackState sendGroupHistroy(string num, out string msg, out int totol)
        {
            //MessageBox.Show(CurentGroup);
            //string num,out string msg,out int totol

            BackState bs = WireCom.SendOneHistroy(num, out msg, out totol);
            return bs;
        }



        //发送多个个设备实时的报文
        private bool sendMultitermReal(string Sendstr, out string err)
        {

            //MessageBox.Show(Sendstr.Count.ToString());
            bool bs = WireCom.SendMultitermRealData(Sendstr, out err);
            return bs;
        }
        //发送多个设备2小时记录的报文
        private BackState sendMultitermHistroy(string number, out string msg, out int num)
        {
            //MessageBox.Show(Sendstr.Count.ToString());
            BackState bs = WireCom.SendOneHistroy(number, out msg, out num);
            return bs;
        }
        //发送召测动作记录的报文

        #endregion

        private void Mainfrm_Shown(object sender, EventArgs e)
        {

            //    this.WindowState = FormWindowState.Maximized;
            //try
            //{
            //    string bv = GetAppConfig("Notytime");
            //    bool notyter = Convert.ToBoolean(bv);
            //    if(notyter==false)
            //    {
            //        return;
            //    }
            //}
            //catch
            //{
            //    return;
            //}
            //DialogResult dr;
            //     dr=MessageBox.Show("请查看电脑系统时间是否准确，以便于\r以系统时间为标准来同步设备时间.","时间提示",MessageBoxButtons.YesNoCancel,
            //     MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
            //     if (dr == DialogResult.Yes)
            //     //定制事件    
            //     {
            //         Microsoft.Win32.SystemEvents.TimeChanged += new EventHandler(SystemEvents_TimeChanged);//事件处理
            //         MessageBox.Show("请修改系统时间，可从右下角日期\r《更改日期和时间设置》来更改。\r点击确定按钮后不要忘了更改。","更该确认提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //     }
            //     else if (dr == DialogResult.No)
            //     {
            //         //不更换时间
            //         SetAppConfig("Notytime", "true");
            //     }
            //     else if (dr == DialogResult.Cancel)
            //     {
            //         if (MessageBox.Show("你选择取消后，下次启动软件将不提示时间校准", "校准提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //         {
            //             //写入配置文件
            //             SetAppConfig("Notytime", "false");
            //         }

            //     }

            //为taabpge添加数据管理窗体
            //this.WindowState = FormWindowState.Maximized;

            timer_start.Start();//显示窗体


        }
        private void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            SetAppConfig("Calibration", "ture");
            MessageBox.Show("系统时间被改变了,软件将以系统\r时间为依据同步设备时间，现在时间为：" + DateTime.Now.ToString(), "系统时间更改提示");


        }

        private void MenuItem_Light_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            LightCountfrm lc = new LightCountfrm(CurrentNumber);
            lc.Query += new LightCountfrm.queryLight(Querylight);

            if (lc.ShowDialog() == DialogResult.Yes)
            {
                lc.Visible = false;
                lc.Query -= new LightCountfrm.queryLight(Querylight);
            }
            lc.Dispose();
        }


        private bool Query_Light(int cout, string number, out string err)
        {
            bool bs = WireCom.Query_Light(cout, CurrentNumber, out err);

            return bs;
        }

        private void communication_protocol_Click(object sender, EventArgs e)
        {
            //   if (MessageBox.Show("是否更改协议，请去保持协议与设备使用协议一致", "更改提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Protocolfrm profrm;
                if (WireCom == null)
                {
                    profrm = new Protocolfrm(false, MyProConnect.Name);
                }
                else
                {
                    profrm = new Protocolfrm(WireCom.getIsOpen(), MyProConnect.Name);
                }
                profrm.changePro += new Protocolfrm.ChangePro(Pro_change);
                profrm.ShowDialog();
            }
        }

        private bool Pro_change(string ver)
        {

            if (WireCom == null || WireCom.getIsOpen() == false)
            {

                if (ver == "1.0.0.0")//奇数不带全电流
                {
                    MyProConnect = new CommunicationProtocol.CommunicateWithOutmA();
                    //不带全电流，则历史记录不能获取，关闭相关功能

                    DownLoadRecentHistroy.Enabled = false;
                    DownRecentHistroy.Enabled = false;
                    DownLoadRecentHistroy.ToolTipText = "该版本为不带全电流的计数器，无历史记录功能";

                }
                else if (ver == "2.0.0.0")//偶数带全电流
                {
                    MyProConnect = new CommunicationProtocol.CommunicateWithmA();

                    DownLoadRecentHistroy.Enabled = true;
                    DownRecentHistroy.Enabled = true;

                }
                MyProConnect.Name = ver;
                MyprotocolVersion = ver;
                //WireCom = new UsewireCom(tb_port.Text, Convert.ToInt32(cbx_braoud.Text.Trim()), MyProConnect.Name, MyProConnect, _PData);
                //读取appconfig
                SetAppConfig("ProtocolVersion", ver);
            }

            return true;
        }
        private void SetAppConfig(string strKey, string keyValue)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(Application.ExecutablePath + ".config");
            XmlNode xnode;
            XmlElement x1;
            XmlElement x2;
            xnode = doc.SelectSingleNode("//appSettings");
            x1 = (XmlElement)xnode.SelectSingleNode("//add[@key='" + strKey + "']");
            if (x1 != null) x1.SetAttribute("value", keyValue);
            else
            {
                x2 = doc.CreateElement("add");
                x2.SetAttribute("key", strKey);
                x2.SetAttribute("value", keyValue);
                xnode.AppendChild(x2);
            }

            doc.Save(Application.ExecutablePath + ".config");
        }

        ///每次使用是设备都插入零时列表中
        //
        private void btn_help_Click(object sender, EventArgs e)
        {
            string path = "UserHelp\\help.html";
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("打开文档失败，文件不存在！文档可能人为\r被损害或者删除，请重新安装程序解决,或者\r使用提供的说明使用书.", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //处理数据
            if (e.KeyCode == Keys.Enter)
            {
                //按下enter键
                //处理信息
                if (txtSearch.Text == "" || txtSearch.Text == null) return;
                SerchfrmDate(txtSearch.Text);
                txtSearch.Text = "";
            }
        }

        private void toolButtonExcle_Click(object sender, EventArgs e)
        {
            ExportExclefrm f = new ExportExclefrm(MyProConnect.Name);
            f.Show();
        }


        public bool Querylight(string number, int count, int start, out string err)
        {
            bool bs = WireCom.Query_Light2(number, count, start, out err);
            return bs;
        }

        private void ToolStripMenuItem_downgl_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            LightGroupfrm grop = new LightGroupfrm(CurentGroup);
            grop.Query += new LightGroupfrm.queryLight(Querylight);
            if (grop.ShowDialog() == DialogResult.Yes)
            {
                grop.Query -= new LightGroupfrm.queryLight(Querylight);
            }
            // grop.Show();
            grop.Dispose();
        }

        private void JiaoZhuntimeMenu_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            QueryTimeForm qt = new QueryTimeForm(CurrentNumber);
            qt.GetDevtime += qt_GetDevtime;
            qt.Writedev += qt_Writedev;
            if (qt.ShowDialog() == DialogResult.Yes)
            {
                qt.GetDevtime -= qt_GetDevtime;
                qt.Writedev -= qt_Writedev;
            }
            qt.Dispose();
        }

        bool qt_Writedev(string number, out string err)
        {
            bool wriok = WireCom.Mywrite(number, out err);
            return wriok;
        }

        bool qt_GetDevtime(string Numbe, out string tim, out string local)
        {
            tim = string.Empty;
            local = string.Empty;
            bool ok = false;
            ok = WireCom.SendTime(Numbe);
            if (ok)
            {
                LinkedListNode<DevBackTime> _pD = UsewireCom._DBtime.First;
                while (_pD != null)
                {
                    //如果找到当前设备
                    if (_pD.Value.dev.number == Numbe)
                    {
                        //设置时间
                        tim = _pD.Value.btime.ToString();
                        local = _pD.Value.curtime.ToString();
                        break;
                    }
                    _pD = _pD.Next;
                }
            }
            return ok;
        }

        private void DownLoadRecentHistroy_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            LastOneHistroyForm last = new LastOneHistroyForm(CurrentNumber);
            last.callHistroyData += last_callHistroyData;
            if (last.ShowDialog() == DialogResult.Yes)
            {
                last.Visible = false;
                last.callHistroyData -= last_callHistroyData;
            }
            last.Dispose();
        }

        BackState last_callHistroyData(string number, int daynum, out string err, out int num)
        {
            return WireCom.SendOneHistroy(number, daynum, out err, out num);
        }



        BackState lg_callHistroyData(string number, int daynum, out string err, out int num)
        {
            return WireCom.SendOneHistroy(number, daynum, out err, out num);
        }

        private void Mainfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否退出应用？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                e.Cancel = false;
            } 
            else
            {
                e.Cancel = true;
            }

        }

        private void DownRecentHistroy_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            LastCheckGroup lg = new LastCheckGroup(this.CurentGroup);
            lg.callHistroyData += lg_callHistroyData;
            if (lg.ShowDialog() == DialogResult.Yes)
            {
                lg.Visible = false;
                lg.callHistroyData -= lg_callHistroyData;

            }
        }

        private void AllListBox_ClickSubItem(object sender, ChatListClickEventArgs e, MouseEventArgs es)
        {
            ChatListSubItem d = e.SelectSubItem;

        }

        private void btn_downRealData_Click(object sender, EventArgs e)
        {
            if (devtab.SelectedIndex == 0 || devtab.SelectedIndex == 1)
            {
                switch (devtab.SelectedIndex)
                {
                    case 0://从全部设备选择
                        if (AllListBox.SelectSubItem != null)
                        {
                            if (WireCom == null || WireCom.getIsOpen() == false)
                            {
                                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                                return;
                            }
                            CallCurrentFrom call = new CallCurrentFrom(AllListBox.SelectSubItem.DisplayName, true, GetMyProVersion);
                            call.callRealData += new CallCurrentFrom.CallReal(sendOneReal);

                            if (call.ShowDialog() == DialogResult.Yes)
                            {
                                call.callRealData -= new CallCurrentFrom.CallReal(sendOneReal);
                            }
                            call.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("请选择一台设备!");
                        }
                        break;
                    case 1://从分组选择
                        if (GroupListBox.SelectSubItem != null)
                        {
                            if (WireCom == null || WireCom.getIsOpen() == false)
                            {
                                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                                return;
                            }
                            CallCurrentFrom call = new CallCurrentFrom(GroupListBox.SelectSubItem.DisplayName, true, GetMyProVersion);
                            call.callRealData += new CallCurrentFrom.CallReal(sendOneReal);

                            if (call.ShowDialog() == DialogResult.Yes)
                            {
                                call.callRealData -= new CallCurrentFrom.CallReal(sendOneReal);
                            }
                            call.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("请选择一台设备!");
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        private void btn_CheckData_Click(object sender, EventArgs e)
        {
            DataCenterfrm cet = new DataCenterfrm();
            cet.Show();
        }

        private void btn_setDev_Click(object sender, EventArgs e)
        {
            MangerDevfrm manger = new MangerDevfrm();
            manger.RefreshNow += manger_RefreshNow;
            manger.Show();
        }

        private void importdevlist_Click(object sender, EventArgs e)
        {
            ImportDevfrm import = new ImportDevfrm();
            import.refresh += new ImportDevfrm.RefashList(ReFreList);
            import.Show();
        }

        private void btn_addOne_Click(object sender, EventArgs e)
        {
            AddDevfrm addfrm = new AddDevfrm();
            addfrm.Focus();
            if (addfrm.ShowDialog() == DialogResult.Yes)
            {
                string d1, d2, d3;
                d1 = addfrm.iD;
                d2 = addfrm.aDDr;
                d3 = addfrm.pHase;
                SqlHelp sql = new SqlHelp();
                string str = "insert into Dev_List (Dev_ID,Dev_Addr,Dev_Phase) Values('" + d1 + "','" + d2 + "','" + d3 + "')";
                sql.Insert(str);
                //  RefreshNow();

                manger_RefreshNow();
            }

        }

        private void AllListBox_Click(object sender, EventArgs e)
        {
            //if(AllListBox.SelectItem!=null)
            //{
            //  AllListBox.SelectItem.IsOpen = true;
            //}
        }

        private int stepvalue = 0;
        //void ScrolValue(int v)
        //{         
        //   this.AllListBox.chatVScroll.Value += v;
        //}

        //private void btn_up_MouseDown(object sender, MouseEventArgs e)
        //{
        //    stepvalue = -100;
        //    timer1.Start();        
        //}

        //private void btn_up_MouseUp(object sender, MouseEventArgs e)
        //{

        //    timer1.Stop();
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    ScrolValue(stepvalue);
        //}

        //private void btn_down_MouseDown(object sender, MouseEventArgs e)
        //{
        //    stepvalue = 200;
        //    timer1.Start();
        //}

        //private void btn_down_MouseUp(object sender, MouseEventArgs e)
        //{
        //    timer1.Stop();
        //}

        //private void btn_up_Click(object sender, EventArgs e)
        //{
        //    ScrolValue(-200);
        //}

        //private void btn_down_Click(object sender, EventArgs e)
        //{
        //    ScrolValue(200);
        //}

        private void timer_start_Tick(object sender, EventArgs e)
        {
            timer_start.Enabled = false;
            manger2.Visible = true;
            center.Visible = true;
            #region 打开串口
            Connectfrm con = new Connectfrm();

            if (con.ShowDialog() == DialogResult.OK)
            {
                MyPort = con.UsePort;

                if (MyProConnect != null)
                {
                    //读取协议
                    WireCom = new UsewireCom(MyPort, MyRate, MyProConnect.Name, MyProConnect, _PData);
                    try
                    {

                        //ConPort.Open();
                        bool ok = WireCom.openPort();
                        if (ok)
                        {
                            pic_Com.BackgroundImage = Properties.Resources.online;

                        }
                    }
                    catch
                    {
                        MessageBox.Show("串口打开失败!");
                    }
                }
                else
                {
                    MessageBox.Show("配置协议失败:无协议");

                }


            }
            con.Dispose();

            //加载设备到列表中
            AddDevToList();


            DataTable ds = mysql.ReturnTable("select * from Dev_List");
            if (ds.Rows.Count > 0)
            {
                for (int k = 0; k < ds.Rows.Count; k++)
                {
                    string v = ds.Rows[k]["Dev_ID"].ToString();
                    string s = ds.Rows[k]["Dev_Addr"].ToString();
                    txtSearch.AutoCompleteCustomSource.Add(v);
                    txtSearch.AutoCompleteCustomSource.Add(s);
                }
            }
            if (MyProConnect == null)
            {
                MessageBox.Show("配置参数错误，应用程序不能正常使用，请重新配置参数或重新安装.", "启动失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            #endregion
            // this.WindowState = FormWindowState.Maximized;

            this.Opacity = 1;
            this.ShowInTaskbar = true;
        }

        private void btn_exportDev_Click(object sender, EventArgs e)
        {
            ExportDevExclefrm f = new ExportDevExclefrm();
            f.Show();
        }

        private void btn_init_all_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            InitAllDevfrm f = new InitAllDevfrm(WireCom);

            f.Show();
        }

        private void initGroupDev_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            InitAllDevfrm f = new InitAllDevfrm(WireCom, CurentGroup);
            f.Show();
        }

        private void initGroupTime_Click(object sender, EventArgs e)
        {
            if (WireCom == null || WireCom.getIsOpen() == false)
            {
                MessageBox.Show("通信端口没有打开，请打开通信端口!");
                return;
            }
            InitAllDevfrm f = new InitAllDevfrm(WireCom, CurentGroup);
            f.Show();
        }


    }
}
