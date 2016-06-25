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
    public partial class InitAllDevTimefrm : Skin_DevExpress
    {
        private UsewireCom WireCom;
        public static bool Isback;
        public static Thread CheckIsback ;
        private static string dev_id;
        private static SqlHelp sql = new SqlHelp();
        private DateTime stime;
        private static string err="";
        private static bool issettime;
        public bool flag=true;
        private static bool isnotend=true;
        LinkedList<string> plist;
        public InitAllDevTimefrm(LinkedList<string> mylist,UsewireCom WireCom,DateTime tt,bool issett)
        {
            InitializeComponent();
            plist = mylist;
            this.WireCom=WireCom;
            RichTextBox.Text="";
            stime = tt;
            issettime = issett;
        }
        private void InitAllDevTimefrm_Load(object sender, EventArgs e)
        {
            InitAllDev(plist);
        }
        private void InitAllDev(LinkedList<string> mylist)
        {
            Isback = false;
            Indicator.AutoStart = true;
            l_msg.Text = "共同步" + mylist.Count.ToString() + "个设备";
            int i;
            LinkedListNode<string> _p=mylist.First;
            for(i=0;i<mylist.Count&&flag;i++,_p=_p.Next)
            {
                isnotend = true;
                err = "";
                dev_id = _p.Value;
                l_msg.Text = "共同步" + mylist.Count + "个设备,当前第"+(i+1).ToString()+"个";
                RichTextBox.Text += "---------------------------------------------\r\n";
                RichTextBox.Text += "设备[" + dev_id + "]开始同步时间...\n";         
                //调用回调函数发送初始化信息，并返回数据
                CheckIsback = new Thread(CheckBack);
                CheckIsback.IsBackground = true;
                CheckIsback.Start();
                Delaytime.Delay(500);
                if (!issettime)
                {
                    stime = DateTime.Now;
                }
                Isback=WireCom.Mywrite(dev_id,out err,stime);
                while (isnotend)
                    Delaytime.Delay(1000); 
            }
            l_msg.Text = mylist.Count.ToString() + "个设备同步时间已完成";

            Indicator.AutoStart = false;
            
        }
        private  void CheckBack(object obj)
        {
            //int Cout = 0;
            while(flag)
            {
              
                
                if(Isback)
                {
                    //收到返回的数据指令
                    this.Invoke((EventHandler)delegate
                    {
                        RichTextBox.Text += "正在同步时间..\r\n"; 
                        string str1 = "update Dev_Real set Dev_Time='"+ stime.ToString() +"' where Dev_ID='" + dev_id + "'";
                             try
                             {
                                 sql.Insert(str1);
                             }
                             catch
                             {
                                 RichTextBox.Text += "###同步时间失败###\r\n"; 
                             }
                             RichTextBox.Text += "同步成功！时间已设置为[" + stime.ToString() + "]\r\n";
                             Isback = false;
                    });
                    break;
                }
                else
                {
                   
                    if(err==""||err=="ok")
                    {
                        this.Invoke((EventHandler)delegate
                        {
                            RichTextBox.Text = RichTextBox.Text.Substring(0, RichTextBox.Text.Length - 1)+"同步过程中,请稍后...\n"; 
                            Delaytime.Delay(1000);
                            RichTextBox.Text = RichTextBox.Text.Substring(0, RichTextBox.Text.Length - "同步过程中,请稍后...\n".Length )+"\n"; 
                            Delaytime.Delay(1000);
                        });
                    }
                    else
                    {
                        this.Invoke((EventHandler)delegate
                        {
                            Indicator.AutoStart = false;
                            RichTextBox.Text = RichTextBox.Text + err + "###同步失败###\r\n"; 
                            Isback =false;
                            
                        });
                        break;
                    }
                    //没有收到
                   
                }
            }
            isnotend = false;
        }

        private void InitAllDevTimefrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Indicator.AutoStart) {
                MessageBox.Show("正在通信中，无法关闭", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);              
                    e.Cancel = true;
                    return;
            }
            this.DialogResult = DialogResult.Yes;
            isnotend = false;
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            RichTextBox.Focus();
            RichTextBox.Select(RichTextBox.TextLength, 0);
            RichTextBox.ScrollToCaret();
        }

    }
}
