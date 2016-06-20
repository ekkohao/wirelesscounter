using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using MySqlCon;
using CCWin;

namespace wirelesssacler
{
    public partial class CallMutinData :Skin_DevExpress
    {
        public CallMutinData()
        {
            InitializeComponent();
        }
        public CallMutinData(string ver)
        {
            InitializeComponent();
            usrver = ver;
            if(ver=="1.0.0.0")
            {
                //无全电流
                btn_CallHistroyData.Enabled = false;
                btn_LastHistroyData.Enabled = false;
                IsCloseHis = true;
            }
            Sendstr = new LinkedList<string>();
            _pSend = Sendstr.First;
        }
        public delegate bool MutinRealdata(string number,out string err);
        public event MutinRealdata CallRealData;
        public delegate BackState MutinHistroydata(string number,out string err, out int num);
        public event MutinHistroydata CallHistroyData;
        public static LinkedList<string> Sendstr;
        public LinkedListNode<string> _pSend;
        public delegate bool CallLightData(string number,int total,int lasttotal, out string err);
        public event CallLightData CallLight;
        public delegate BackState MutinHistroydata2(string number,int day, out string err, out int num);
        public event MutinHistroydata2 CallHistroyData2;
        public bool IsCloseHis=false;
        
        public static Thread CheckIsback;
        public static bool Isback = false;
        private SqlHelp query = new SqlHelp();
        private string usrver;
        private int Myday = 0;

        private bool exit = false;
        private void CallMutinData_Load(object sender, EventArgs e)
        {

            DataGridView.Columns.Add("devid", "设备序列");
            DataGridView.Columns.Add("devaddr", "安装地址");
            DataGridView.Columns.Add("devphase", "监测相位");
            DataGridView.AllowUserToAddRows = false;

            DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
            newColumn.HeaderText = "状态";
            DataGridView.Columns.Add(newColumn);



            SqlHelp load = new SqlHelp();
            string str = "select * from Dev_List";
            DataTable dt = load.ReturnTable(str);
            if (dt.Rows.Count > 0)
            {
                DataGridView.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    object[] f = new object[3];
                    f[0] = dt.Rows[i][1];
                    f[1] = dt.Rows[i][2];
                    f[2] = dt.Rows[i][3];
                    DataGridView.Rows.Add(f);


                }
            }

        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
                if (e.ColumnIndex == 4)
                {
                    foreach (DataGridViewRow row in this.DataGridView.Rows)
                    {
                        if (row.Cells[0].RowIndex != e.RowIndex)
                        {
                            row.Cells[0].Value = false;  // 设置  CheckBox    
                        }
                    }
                }
            
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (Convert.ToBoolean(DataGridView.Rows[e.RowIndex].Cells[3].Value) == false)
                {
                    DataGridView.Rows[e.RowIndex].Cells[3].Value = true;

                    Sendstr.AddLast(DataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                else
                {
                    DataGridView.Rows[e.RowIndex].Cells[3].Value = false;
                    Sendstr.Remove(DataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch
            {

            }
           
        }

        private void btn_CallReal_Click(object sender, EventArgs e)
        {
            exit = false;
            btn_CallReal.Cursor = Cursors.WaitCursor;
            btn_CallHistroyData.Enabled = false;
            btn_Light.Enabled = false;
            btn_LastHistroyData.Enabled = false;
            Indicator.AutoStart = true;
            rhtx_SelectItem.Text = "";
            rhtx_BackData.Text = "";
            _pSend = Sendstr.First;
            if (Sendstr.Count > 0)
            {
                //Send = Sendstr;
                 lb_noty.Text="开始下载，请等待，等待时间大约"+Sendstr.Count*6+"秒";
                while (_pSend != null && exit==false)
                {
                    rhtx_SelectItem.Text += "设备序列号为:" + _pSend.Value + "获取数据中\r\n";
                    lb_noty.Text = "开始下载设备序列为"+_pSend.Value+"数据";
                    string err;
                    Isback = CallRealData(_pSend.Value,out err);
                    if(Isback==false)
                    {
                        rhtx_SelectItem.Text += "下载数据失败设备:" + _pSend.Value+ err + "\r\n"; ;
                    }
                    else
                    {
                        CheckRealBack(_pSend.Value);
                    }
                    _pSend = _pSend.Next;
                }
                lb_noty.Text = "下载数据完成。";
            }
           
            Indicator.AutoStart = false;
            btn_CallHistroyData.Enabled = true;
            btn_Light.Enabled = true;
            btn_LastHistroyData.Enabled = true;
            btn_CallReal.Cursor = Cursors.Default;
        }

        private void btn_CallHistroyData_Click(object sender, EventArgs e)
        {
            exit = false;
            btn_CallHistroyData.Cursor = Cursors.WaitCursor;
            Indicator.AutoStart = true;
            btn_CallReal.Enabled = false;
            btn_Light.Enabled = false;
            btn_LastHistroyData.Enabled = false;
            rhtx_SelectItem.Text = "";
            rhtx_BackData.Text = "";
            _pSend = Sendstr.First;
            if (Sendstr.Count > 0)
            {
                lb_noty.Text = "正在获取数据，请耐心等候";
                while (_pSend != null && exit==false)
                {
                    rhtx_SelectItem.Text += "设备序列号为:" + _pSend.Value + "开始下载数据,请稍后。,请等待几分钟\r\n";
                    string err = string.Empty; int num = 0;
                    BackState Isback2 = CallHistroyData(_pSend.Value,out err, out num);
                    #region

                    if (Isback2 == BackState.Yes)
                    {
                        if (num != 0)
                        {

                            #region 收到数据
                            rhtx_SelectItem.Text += "设备序列号为:" + _pSend.Value + "下载完成,共" + (num % 1440).ToString() + "历史记录\r\n";
                            lb_noty.Text = "下载中，大约需要" + (num % 1440) * Sendstr.Count*6+"秒";
                            if (err != string.Empty)
                            {
                                rhtx_BackData.Text += "设备序列号为:" + _pSend.Value + err + "\r\n";
                            }
                            DataTable dt = query.ReturnTable("select * from DevmA_Histroy where Dev_ID='" + _pSend.Value + "'");
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (num < 1440)
                                    {
                                        int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                        for (int k = 0; k < num; k++)
                                        {
                                            if (t == k)
                                            {
                                                rhtx_BackData.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "监测的相位: " + dt.Rows[i]["Dev_Phase"].ToString() + "(相位)\r\n";
                                                rhtx_BackData.Text += "历史数据: 第" + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                                if (usrver == "2.0.0.0")
                                                {
                                                    rhtx_BackData.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                                }
                                                rhtx_BackData.Text += "设备召测时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "\r\n";
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                        t = t % 1440;
                                        for (int k = 0; k < num; k++)
                                        {
                                            if (t == k)
                                            {
                                                rhtx_BackData.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "监测的相位: " + dt.Rows[i]["Dev_Phase"].ToString() + "(相位)\r\n";
                                                rhtx_BackData.Text += "历史数据: 第" + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                                if (usrver == "2.0.0.0")
                                                {
                                                    rhtx_BackData.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                                }
                                                rhtx_BackData.Text += "设备召测时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "\r\n";
                                                break;
                                            }
                                        }
                                    }

                                }
                            }

                            #endregion

                        }
                        else
                        {
                            rhtx_SelectItem.Text += "设备序列号为:" + _pSend.Value + "下载完成,共" + (num % 1440).ToString() + "历史记录"+"\r\n";
                            rhtx_BackData.Text += "设备序列号为:" + _pSend.Value + err + "\r\n";
                        }
                    }
                    else
                    {

                        rhtx_SelectItem.Text += "设备序列号为:" + _pSend.Value + "下载失败" + "\r\n";
                        rhtx_BackData.Text += "设备序列号为:" + _pSend.Value + err + "\r\n";
                    }
                    #endregion 历史数据库
                    _pSend = _pSend.Next;
                }
                //Send = Sendstr;
                Isback = false;

              
            }
            lb_noty.Text = "获取数据结束。";
            Indicator.AutoStart = false;
            btn_CallReal.Enabled = true;
            btn_Light.Enabled = true;
            btn_LastHistroyData.Enabled = true;
            btn_CallHistroyData.Cursor = Cursors.Default;
        }




       private void CheckRealBack( string number)
       {
           DataTable ldt = query.ReturnTable("select * from Dev_Real where Dev_ID='" + number + "'");
           if (ldt.Rows.Count > 0)
           {
               for (int i = 0; i < ldt.Rows.Count; i++)
               {
                   rhtx_BackData.Text += "设备序列号: " + ldt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                   rhtx_BackData.Text += "设备地址:" + ldt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                   rhtx_BackData.Text += "监测的相位: " + ldt.Rows[i]["Dev_Phase"].ToString() + "(相位)\r\n";
                   rhtx_BackData.Text += "设备动作次数: " + ldt.Rows[i]["Dev_Num"].ToString() + "(次)\r\n";
                   rhtx_BackData.Text += "上次查询动作次数：" + ldt.Rows[i]["Dev_OldNum"].ToString() + "(次)\r\n";
                   if (ldt.Rows[0]["Dev_mA"].ToString() == "-1")
                   {
                      // rhtx_BackData.Text += "设备不具有全电流功能，无法获取数据。\r\n";
                   }
                   else
                   {
                       rhtx_BackData.Text += "设备全电流:" + ldt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                   }

                   rhtx_BackData.Text += "设备召测时间: " + ldt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
                   rhtx_BackData.Text += "\r\n";
               }
           }
   
       }

       private void rhtx_SelectItem_TextChanged(object sender, EventArgs e)
       {
          
           rhtx_SelectItem.Select(rhtx_SelectItem.Text.Length , 0);
           rhtx_SelectItem.ScrollToCaret();
       }

       private void rhtx_BackData_TextChanged(object sender, EventArgs e)
       {
           rhtx_BackData.Select(rhtx_BackData.Text.Length , 0);
           rhtx_BackData.ScrollToCaret();
       }


       private void CallMutinData_FormClosing(object sender, FormClosingEventArgs e)
       {
           //if (IsCloseHis == false)
           //{
           //    if (btn_CallHistroyData.Enabled == false || btn_CallReal.Enabled == false)
           //    {
           //        e.Cancel = true;
           //        MessageBox.Show("数据下载中，请稍后......");
           //    }
           //}
           //else
           //{
           //    if (btn_CallReal.Enabled == false)
           //    {
           //        e.Cancel = true;
           //        MessageBox.Show("数据下载中，请稍后......");
           //    }
           //}
           exit = true;
           this.DialogResult = DialogResult.Yes;
       }

       private void btn_Light_Click(object sender, EventArgs e)
       {
           exit = false;
           btn_Light.Cursor = Cursors.WaitCursor;
           btn_CallReal.Enabled = false;
           btn_CallHistroyData.Enabled = false;
           Indicator.AutoStart = true;
           btn_LastHistroyData.Enabled = false;
           rhtx_BackData.Text = "";
           rhtx_SelectItem.Text = "";
           lb_noty.Text = "开始获取动作次数";
           LinkedListNode<string> _pS;
           LinkedList<string> ps = new LinkedList<string>();
           _pS = Sendstr.First;
           if (Sendstr.Count > 0)
           {
               //Send = Sendstr;
               while (_pS!= null && exit==false)
               {
                   #region ///
                   string err;
                   int s = 1;
                   int cout = 0;
                   cout= getLightnum(_pS.Value, out s);
                   if(cout>0)
                   {
                       if (s == 0)
                       {
                           rhtx_SelectItem.Text += "设备序列号为:" + _pS.Value + "---没有产生新动作记录数据，将不下载数据\r\n";
                       }
                       else
                       {
                           rhtx_SelectItem.Text += "正在获取设备序列号为:" + _pS.Value+"动作数据大约"+((cout-s)*6).ToString()+"秒\r\n";
                           rhtx_BackData.Text += "正在设获取备序列号为:" + _pS.Value + "动作数据大约" + ((cout - s)*6).ToString() + "秒\r\n";
                           #region 
                           //产生新增动作
                           bool call = CallLight(_pS.Value,cout,s, out err);
                           if (call)
                           {
                               DataTable sq = query.ReturnTable("Select * from DevLight_Histroy where Dev_ID='" + _pS.Value + "'");
                               if (sq != null && sq.Rows.Count > 0)
                               {
                                   for (int i = 0; i < sq.Rows.Count; i++)
                                   {
                                       rhtx_BackData.Text += "设备序列:" + sq.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                       rhtx_BackData.Text += "设备地址:" + sq.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                       rhtx_BackData.Text += "监测相位" + sq.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                                       rhtx_BackData.Text += "动作次数" + sq.Rows[i]["Dev_Num"].ToString() + "\r\n";
                                       rhtx_BackData.Text += "动作时间" + sq.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                       rhtx_BackData.Text += "\r\n";
                                   }
                                   rhtx_BackData.Text += "\r\r\n";
                               }
                               else
                               {
                                   lb_noty.Text = "数据加载失败，请重新获取记录数据。";
                               }
                           }
                           else
                           {
                               if (err != string.Empty)
                               {
                                   rhtx_SelectItem.Text += "设备序列号为:" + _pS.Value + err + "\r\n";
                               }
                           }
                           #endregion
                       }
                       
                   }
                   else
                   {
                       rhtx_SelectItem.Text += "设备序列号为:" + _pS.Value+"动作记录次数没有，请获取实时数据\r\n";
                   }
                   #endregion
                   _pS = _pS.Next;
               }
               ps= Sendstr;
           
           }
           else
           {
               MessageBox.Show("请选择你需要下载的设备");
           }
           lb_noty.Text = "获取动作次数结束。";
           btn_Light.Cursor = Cursors.Default;
           Indicator.AutoStart = false;
           btn_CallReal.Enabled = true;
           btn_CallHistroyData.Enabled = true;
           btn_LastHistroyData.Enabled = true;
       }

        private int getLightnum(string num,out int start)
       {
           DataTable dt = query.ReturnTable("select * from Dev_Real where Dev_ID='" + num + "'");
           int cout = 0;
           int oldnum = 0;
           start = 1;
           if (dt.Rows.Count == 0)
           {
               cout = 0;
           }
           else
           {


               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   if (dt.Rows[i]["Dev_ID"].ToString() == num)
                   {
        
                     cout = Convert.ToInt32(dt.Rows[i]["Dev_Num"].ToString());
                     oldnum = Convert.ToInt32(dt.Rows[i]["Dev_OldNum"].ToString());
                   }
               }
           }
           if (cout == 0)
               return cout;
           else
               start = cout - oldnum;
           return cout;
       }

        private void btn_LastHistroyData_Click(object sender, EventArgs e)
        {
            exit = false;
            DayForm day = new DayForm();
            day.SetDayCount += day_SetDayCount;
            day.ShowDialog();
            if (Myday == 0) return;

            btn_CallHistroyData.Cursor = Cursors.WaitCursor;    
            Indicator.AutoStart = true;
            btn_CallReal.Enabled = false;
            btn_Light.Enabled = false;
            btn_CallHistroyData.Enabled = false;
            rhtx_SelectItem.Text = "";
            rhtx_BackData.Text = "";
            _pSend = Sendstr.First;
            if (Sendstr.Count > 0)
            {
                lb_noty.Text = "正在获取数据，请耐心等候";
                lb_noty.Text = "下载中，大约需要" + Myday * 6 * Sendstr.Count + "秒";
                while (_pSend != null && exit==false)
                {
                    rhtx_SelectItem.Text += "设备序列号为:" + _pSend.Value + "开始下载数据,请稍后。,请等待几分钟\r\n";
                    string err = string.Empty; int num = 0;
                    BackState Isback2 = CallHistroyData2(_pSend.Value,Myday, out err, out num);
                    #region

                    if (Isback2 == BackState.Yes)
                    {
                        if (num != 0)
                        {

                            #region 收到数据
                            rhtx_SelectItem.Text += "设备序列号为:" + _pSend.Value + "下载完成,从第" + ((num % 1440) - Myday).ToString() + "条至第" + (num % 1440).ToString() + "条历史记录\r\n";
                            
                            if (err != string.Empty)
                            {
                                rhtx_BackData.Text += "设备序列号为:" + _pSend.Value + err + "\r\n";
                            }
                            DataTable dt = query.ReturnTable("select * from DevmA_Histroy where Dev_ID='" + _pSend.Value + "'");
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (num < 1440)
                                    {
                                        int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);        
                                        if(Myday>num)
                                        {
                                            Myday=1;
                                        }
                                        for (int k =num-Myday+1; k < num+1; k++)
                                        {
                                            if (t == k)
                                            {
                                                rhtx_BackData.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "监测的相位: " + dt.Rows[i]["Dev_Phase"].ToString() + "(相位)\r\n";
                                                rhtx_BackData.Text += "历史数据: 第" + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                                if (usrver == "2.0.0.0")
                                                {
                                                    rhtx_BackData.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                                }
                                                rhtx_BackData.Text += "设备召测时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "\r\n";
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                        t = t % 1440;
                                        if(Myday>num)
                                        {
                                            Myday = 1;
                                        }
                                        for (int k =num-Myday+1; k < num+1; k++)
                                        {
                                            if (t == k)
                                            {
                                                rhtx_BackData.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "监测的相位: " + dt.Rows[i]["Dev_Phase"].ToString() + "(相位)\r\n";
                                                rhtx_BackData.Text += "历史数据: 第" + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                                if (usrver == "2.0.0.0")
                                                {
                                                    rhtx_BackData.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                                }
                                                rhtx_BackData.Text += "设备召测时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                                rhtx_BackData.Text += "\r\n";
                                                break;
                                            }
                                        }
                                    }

                                }
                            }

                            #endregion

                        }
                        else
                        {
                            rhtx_SelectItem.Text += "设备序列号为:" + _pSend.Value + "下载完成,共0条历史记录\r\n";
                            rhtx_BackData.Text += "设备序列号为:" + _pSend.Value + err + "\r\n";
                        }
                    }
                    else
                    {

                        rhtx_SelectItem.Text += "设备序列号为:" + _pSend.Value + "下载失败" + "\r\n";
                        rhtx_BackData.Text += "设备序列号为:" + _pSend.Value + err + "\r\n";
                    }
                    #endregion 历史数据库
                    _pSend = _pSend.Next;
                }
                //Send = Sendstr;
                Isback = false;


            }
            lb_noty.Text = "获取数据结束。";
            Indicator.AutoStart = false;
            btn_CallReal.Enabled = true;
            btn_Light.Enabled = true;
            btn_CallHistroyData.Enabled = true;
            btn_CallHistroyData.Cursor = Cursors.Default;
        }


        void day_SetDayCount(int day)
        {
            Myday = day*6;
        }
    }
}
