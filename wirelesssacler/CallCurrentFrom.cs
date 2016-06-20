using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CCWin;
using MySqlCon;
using CommunicationProtocol;
using System.Configuration;

namespace wirelesssacler
{
    public partial class CallCurrentFrom : Skin_DevExpress
    {
        public CallCurrentFrom()
        {
            InitializeComponent();
           
        }
         private string devaddr;

        private bool isReal;//是否为实时的数据还是历史
        public static BackState Isback; //=new BackRealstate() ;
        public static BackState Isback2 ;//= new BackState();
        public delegate BackState CallReal(string num);
        public event CallReal callRealData;

        public delegate BackState CallHistroy( string number, out string err,out int num );
        public event CallHistroy callHistroyData;
        public SqlHelp query = new SqlHelp();
        private int totalnum = 0;

        private SequenceWithStrToByte Convernumer = new SequenceWithStrToByte();

     
        private string usever;
        public CallCurrentFrom(string DevID, bool Isreal,string version)
        {
            InitializeComponent();
            this.devaddr = DevID;
            isReal = Isreal;
            usever = version;
           
            if(isReal)
            {
                this.Text = "召测设备:"+DevID+"-----获取实时数据界面";
                Isback = BackState.No;
            }
            else
            {
                Isback2 = BackState.No;
                this.Text = "召测设备:" + DevID + "-----获取历史记录数据界面";
               
            }
        }

        private void CallCurrentFrom_Load(object sender, EventArgs e)
        {
               lb_grop.Text = this.devaddr;
        }





        private void btn_callData_Click(object sender, EventArgs e)
        {
         
            if (btn_callData.Text != "招收") return;
            btn_callData.Cursor = Cursors.WaitCursor;
          
            if (isReal)
            {
                #region 实时查询
                ////查询当前数据库的上次动作次数记录，如果一致，则不提示，否则提示，不提示有旧数据
                // DataTable t=query.ReturnTable("select * from Dev_Real where Dev_ID='" + this.devaddr + "'");
                // if (t.Rows.Count > 0)
                // {               
                //         totalnum = Convert.ToInt32(t.Rows[0]["Dev_OldNum"]);
                //        // Loadtime = t.Rows[0]["Dev_Loadtime"].ToString();
                // }
                 //比较时间
                //如果为前一个小时找的数据则不查询
                // DateTime dt=Convert.ToDateTime(Loadtime);
                // DateTime dt2 = DateTime.Now;

                //bool isclick = getHour(dt, dt2);
                //if(isclick)
                //{
                //    if (MessageBox.Show("检测到24小时内有查询过该设备数据,\r是否继续下载？\r  (是<下载>否<查看旧数据>) ", "下载提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                //    {
                //        DataTable ldt = query.ReturnTable("select * from Dev_Real where Dev_ID='" + this.devaddr + "'");
                //        if (ldt.Rows.Count > 0)
                //        {
                //            for (int i = 0; i < ldt.Rows.Count; i++)
                //            {
                //                RichTextBox.Text += "设备序列号: " + ldt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                //                RichTextBox.Text += "设备地址:" + ldt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                //                RichTextBox.Text += "监测路线位置: " + ldt.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                //                RichTextBox.Text += "本次查询动作次数: " + ldt.Rows[i]["Dev_Num"].ToString() + "(次)\r\n";
                //                RichTextBox.Text += "上次查询动作次数：" + ldt.Rows[i]["Dev_OldNum"].ToString() + "(次)\r\n";
                //                if (usever == "2.0.0.0")
                //                {
                //                    RichTextBox.Text += "设备全电流: " + ldt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                //                }
                //                RichTextBox.Text += "设备存储时间: " + ldt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
                //                RichTextBox.Text += "\r\n";
                //            }
                //        }
                //        else
                //        {
                //            MessageBox.Show("数据加载失败！请到菜单里点击查询按钮。");
                //        }
                //        btn_callData.Cursor = Cursors.Default;
                //        return;
                //    }
                //}
                lb_noty.Text = "开始下载数据,大约等待10秒中";
                Indicator.AutoStart = true;
                btn_callData.Text = "招收中...";
                RichTextBox.Text += "\r\n";
                Isback = BackState.No;
                //启动进度条
                Isback= callRealData(this.devaddr);
                //关闭进度条
                if(Isback==BackState.Yes)
                {
                    btn_callData.Text = "招收";
                    lb_noty.Text = "招收数据结束。";
                    Indicator.AutoStart = false;
                    //读取数据
                    DataTable ldt = query.ReturnTable("select * from Dev_Real where Dev_ID='" + this.devaddr + "'");
                    if (ldt.Rows.Count > 0)
                    {
                        for (int i = 0; i < ldt.Rows.Count; i++)
                        {
                            RichTextBox.Text += "设备序列号: " + ldt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                            RichTextBox.Text += "设备地址: " + ldt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                            RichTextBox.Text += "监测路线位置: " + ldt.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                            RichTextBox.Text += "本次查询动作次数: " + ldt.Rows[i]["Dev_Num"].ToString() + "(次)\r\n";
                            RichTextBox.Text += "上次查询动作次数：" + ldt.Rows[i]["Dev_OldNum"].ToString() + "(次)\r\n";
                            if (usever == "2.0.0.0")
                            {
                                RichTextBox.Text += "设备全电流: " + ldt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                            }
                            RichTextBox.Text += "获取数据时间: " + ldt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
                            RichTextBox.Text += "\r\n";
                            int oldact = Convert.ToInt32(ldt.Rows[i]["Dev_OldNum"]);
                            int newact = Convert.ToInt32(ldt.Rows[i]["Dev_Num"]);
                            if (oldact != newact)
                            {

                                RichTextBox.Text += "有新增动作记录,如果需要知道新增记录产生\r\n时间请点击下载动作记录菜单.\n";

                            }
                            else
                            {
                                RichTextBox.Text += "设备没有新增动作记录.\n";

                            }
                        }
                    }
                }
                else
                {
                    btn_callData.Text = "招收";
                     if(RichTextBox.Text!="")
                     {
                         RichTextBox.Text = "获取数据失败，请重试！\r\n";
                     }
                     lb_noty.Text="招收数据失败";
                     Indicator.AutoStart = false;
                }
                #endregion 

            }
            else
            {
                #region
                lb_noty.Text = "开始下载数据,请稍后,请等待几分钟.";
                Indicator.AutoStart = true;
             
                Isback2 = BackState.No;
                string err; int num;
                Isback2 = callHistroyData(this.devaddr,out err,out num);

                if(Isback2==BackState.Yes)
                {
                    if (num != 0)
                    {

                        #region 收到数据

                      //  Indicator.AutoStart = false;
                        lb_noty.Text = "下载完成,共"+(num%1440).ToString()+"个历史记录次数";
                        RichTextBox.Text += err;
                        DataTable dt = query.ReturnTable("select * from DevmA_Histroy where Dev_ID='" + this.devaddr + "'");
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (num < 1440)
                                {
                                    int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                    for (int k = 1; k < num+1; k++)
                                    {
                                        if (t == k)
                                        {
                                            RichTextBox.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                            RichTextBox.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                            RichTextBox.Text += "监测路线位置: " + dt.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                                            RichTextBox.Text += "记录次数:第 " + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                            if (usever == "2.0.0.0")
                                            {
                                                RichTextBox.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                            }
                                            RichTextBox.Text += "设备存储时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                            RichTextBox.Text += "获取数据时间: " + dt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
                                            RichTextBox.Text += "\r\n";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                    t = t % 1440;
                                    for (int k = 1; k < num+1; k++)
                                    {
                                        if (t == k)
                                        {
                                            RichTextBox.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                            RichTextBox.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                            RichTextBox.Text += "监测路线位置: " + dt.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                                            RichTextBox.Text += "记录次数:第 " + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                            if (usever == "2.0.0.0")
                                            {
                                                RichTextBox.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                            }
                                            RichTextBox.Text += "设备存储时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                            RichTextBox.Text += "获取数据时间: " + dt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
                                            RichTextBox.Text += "\r\n";
                                            break;
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            RichTextBox.Text += "读取数据失败\r\n";
                        }

                        #endregion

                    }
                    else
                    {
                        Indicator.AutoStart = false;
                        lb_noty.Text = "下载完成,共" + (num % 1440).ToString() + "个历史数据记录";
                        RichTextBox.Text += err+"\r\n";
                    }
                }
                else
                {
                    Indicator.AutoStart = false;
                    lb_noty.Text = "获取数据失败。";
                    RichTextBox.Text += err+"\r\n";
                }
                #endregion 历史数据库
                btn_callData.Text = "下载";
            }
            Indicator.AutoStart = false;
            btn_callData.Cursor = Cursors.Default;
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            RichTextBox.Select(RichTextBox.Text.Length , 0);
            RichTextBox.ScrollToCaret();
        }

        private void CallCurrentFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(btn_callData.Text.Length>2)
            //{
            //    e.Cancel = true;
            //    MessageBox.Show("正在通信中，无法关闭，请稍后...");
            //}
            this.DialogResult = DialogResult.Yes;
        }

        private void CallCurrentFrom_Shown(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 返回差的时间
        /// </summary>
        /// <param name="odt">旧数据</param>
        /// <param name="ndt">新数据</param>
        /// <returns></returns>
        internal bool getHour(DateTime odt,DateTime ndt)
        {
            //int i=0;
            if(DateTime.Compare(odt, ndt)<=0)
            {
                //时间
                if(ndt.Year>odt.Year)
                {
                    return false;
                }
                else
                {
                    if(ndt.Month>odt.Month)
                    {
                        return false;
                    }
                    else
                    {
                        if((ndt.Day-odt.Day)>1)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
   
                        
                    }
                }

            }
            else
            {
                return true;
            }

        }
    }
}
