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

namespace wirelesssacler
{
    public partial class CallGroupfrm : Skin_DevExpress
    {
        public CallGroupfrm()
        {
            InitializeComponent();
        }
        private string devaddr;

        private bool isReal;//是否为时时的数据还是历史
        public static Thread CheckIsback;
        public static BackState Isback ;
        public string Loadtime;
        public delegate BackState CallReal(string p = null);
        public event CallReal callRealData;

        public delegate BackState CallHistroy(string p,out string err,out int num);
        public event CallHistroy callHistroyData;
        public SqlHelp query = new SqlHelp();
        private string[] nubs = null;
        private string userver;
        public CallGroupfrm(string DevGroup,bool Isreal,string ver)
        {
            InitializeComponent();
            this.devaddr = DevGroup;
            isReal = Isreal;
            userver = ver;
            if (isReal)
            {
                this.Text = "获取数据设备分组名称:" + DevGroup + "-----实时数据界面";
               
            }
            else
            {
                this.Text = "获取数据设备分组名称:" + DevGroup + "-----历史记录数据界面";
                
            }

        }

        private bool exit = false;
      
        private void CallgroupForm_Load(object sender, EventArgs e)
        {

          
          
        }

        private void CallgroupForm_Shown(object sender, EventArgs e)
        {
            string CurentGroup = this.devaddr;

            DataTable dt = query.ReturnTable("select * from `Dev_List` where Dev_Addr='" + CurentGroup + "'");
           
            if (dt.Rows.Count > 0)
            {
                nubs = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    nubs[i] = dt.Rows[i]["Dev_ID"].ToString();
                }
                lb_grop.Text = this.devaddr + ",共有" + nubs.Length + "个设备";
            }
            else
            {
                MessageBox.Show("当前不存在此设备");
                this.Close();
            }
        }


        private void btn_callData_Click(object sender, EventArgs e)
        {
            exit = false;
            if (nubs.Length == 0) return;
            btn_callData.Cursor = Cursors.WaitCursor;
            RichTextBox.Text = "";
            Loadtime = DateTime.Now.ToString();
            lb_noty.Text = "开始下载数据";
            Indicator.AutoStart = true;
            if (isReal)
            {
                    for (int j = 0; j < nubs.Length;j++)
                    {
                        if (exit) break;
                        lb_noty.Text = "开始下载第"+(j+1).ToString()+"个设备数据。";
                        if(Isback==callRealData(nubs[j]))
                        {
                            #region   ////
                            if (Isback == BackState.Yes)
                            {
                                //读取数据
                                DataTable ldt = query.ReturnTable("select * from Dev_Real where Dev_ID='" + nubs[j] + "'");
                                if (ldt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < ldt.Rows.Count; i++)
                                    {
                                        RichTextBox.Text += "设备序列号: " + ldt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                        RichTextBox.Text += "设备地址: " + ldt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                        RichTextBox.Text += "监测路线位置: " + ldt.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                                        RichTextBox.Text += "本次查询动作次数: " + ldt.Rows[i]["Dev_Num"].ToString() + "(次)\r\n";
                                        RichTextBox.Text += "上次查询动作次数：" + ldt.Rows[i]["Dev_OldNum"].ToString() + "(次)\r\n";
                                        //if (ldt.Rows[i]["Dev_mA"].ToString() == "-1")
                                        //{
                                        //   // RichTextBox.Text += "设备不具有全电流功能无电流数据.\r\n";
                                        //}
                                      //  else
                                       // {
                                            if (userver == "2.0.0.0")
                                            {
                                                RichTextBox.Text += "设备全电流: " + ldt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                            }
                                       // }
                                        RichTextBox.Text += "数据下载时间: " + ldt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
                                        RichTextBox.Text += "\r\n";
                                        int oldact = Convert.ToInt32(ldt.Rows[i]["Dev_OldNum"]);
                                        int newact = Convert.ToInt32(ldt.Rows[i]["Dev_Num"]);
                                        if (oldact != newact)
                                        {
                                            RichTextBox.Text += "有新增记录动作产生\n";
                                        }

                                    }
                                }
                                else
                                {
                                    RichTextBox.Text += "读取数据失败.\r\n";
                                }
                         
                            }
                            else
                            {
                                RichTextBox.Text +=nubs[j]+ "读取数据失败.\r\n";
                            }
                            #endregion
                        }
                        else
                        {
                            RichTextBox.Text += "下载第" + (j+1).ToString() + "个设备数据，设备序列："+nubs[j]+"失败。\r\n";
                        }
                    }
                   lb_noty.Text = "下载设备数据结束。";
            }
            else
            {
                //历史数据
                lb_noty.Text = "开始下载数据：";
                Isback = BackState.No;
          for (int j = 0; j < nubs.Length;j++)
                    {
                        lb_noty.Text = "开始下载第"+(j+1).ToString()+"个设备数据。";
                        string err; int num;
                        //
                        if (exit)
                            break;
                        #region 历史数据
                        Isback = callHistroyData(nubs[j], out err, out num);
                        if(Isback==BackState.Yes)
                        {
                        
                                if (num != 0)
                                {

                                    #region 收到数据

                                    
                                    lb_noty.Text = "下载完成,共" + (num % 1440).ToString() + "历史记录";
                                    RichTextBox.Text += err;
                                    DataTable dt = query.ReturnTable("select * from DevmA_Histroy where Dev_ID='" + nubs[j] + "'");
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
                                                        RichTextBox.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                                        RichTextBox.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                                        RichTextBox.Text += "监测路线位置: " + dt.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                                                        RichTextBox.Text += "记录次数:第 " + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                                        if (userver == "2.0.0.0")
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
                                                for (int k = 0; k < num; k++)
                                                {
                                                    if (t == k)
                                                    {
                                                        RichTextBox.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                                        RichTextBox.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                                        RichTextBox.Text += "监测的相位: " + dt.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                                                        RichTextBox.Text += "记录次数: 第" + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                                        if (userver == "2.0.0.0")
                                                        {
                                                            RichTextBox.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                                        }
                                                        RichTextBox.Text += "数据存储时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                                        RichTextBox.Text += "设备召测时间: " + dt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
                                                        RichTextBox.Text += "\r\n";
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

                                    lb_noty.Text = "下载完成,共" + (num % 1440).ToString() + "历史记录";
                                    RichTextBox.Text += err+"\r\n";
                                }
                        }
                        else
                        {
                                lb_noty.Text = "下载"+nubs[j]+"失败.";
                                RichTextBox.Text += "下载第" + j.ToString() + "个设备数据失败.";
                                RichTextBox.Text += err+"\r\n";
                         }
                         #endregion
 
                        
                    }
                 lb_noty.Text = "下载设备数据结束。";
                
              
            }

            lb_noty.Text = "本组数据下载完成。";
            Indicator.AutoStart = false;
            btn_callData.Cursor = Cursors.Default;
        }
        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            RichTextBox.Select(RichTextBox.Text.Length , 0);
            RichTextBox.ScrollToCaret();
        }

        private void CallGroupfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(this.btn_callData.Text.Length>2)
            //{
            //    e.Cancel = true;
            //    MessageBox.Show("数据下载中，请稍后.......");
            //}
            exit = true;
            this.DialogResult = DialogResult.Yes;
        }

     
    }
}
