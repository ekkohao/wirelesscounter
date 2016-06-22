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
    public partial class InitAllDevInfofrm : Skin_DevExpress
    {
        private UsewireCom WireCom;
        public static BackState Isback=BackState.No;
        public static Thread CheckIsback ;
        private static string dev_id;
        private static SqlHelp sql = new SqlHelp();
        LinkedList<string> plist;
        public InitAllDevInfofrm(LinkedList<string> mylist,UsewireCom WireCom)
        {
            InitializeComponent();
            plist = mylist;
            this.WireCom=WireCom;
            RichTextBox.Text="";
           
        }
        private void InitAllDevInfofrm_Load(object sender, EventArgs e)
        {
            InitAllDev(plist);
        }
        private void InitAllDev(LinkedList<string> mylist)
        {
            Isback = BackState.No;
            Indicator.AutoStart = true;
            int i;
            LinkedListNode<string> _p=mylist.First;
            for(i=0;i<mylist.Count;i++,_p=_p.Next)
            {
                dev_id = _p.Value;
                RichTextBox.Text += "---------------------------------------------\r\n";
                RichTextBox.Text += "设备[" + dev_id + "]开始初始化...\r\n";         
                //调用回调函数发送初始化信息，并返回数据
                CheckIsback = new Thread(CheckBack);
                CheckIsback.IsBackground = true;
                CheckIsback.Start();
                Delaytime.Delay(500);
                Isback=WireCom.InitDev(dev_id);        
            }
            Indicator.AutoStart = false;
            
        }
        private  void CheckBack(object obj)
        {
            //int Cout = 0;
            while(true)
            {
              
                
                if(Isback==BackState.Yes)
                {
                    //收到返回的数据指令
                    this.Invoke((EventHandler)delegate
                    {
                        RichTextBox.Text += "正在整理数据..\r\n"; 
                     //   this.btn_Init.Text = "设置";
                        //清空实时数据
       
                            //
                             string str1 = "update Dev_Real set Dev_Num = 0,Dev_OldNum =0,Dev_mA = 0,Dev_Time='0',Dev_Loadtime='0' where Dev_ID='" + dev_id + "'";
                             string str2 = "delete from DevLight_Histroy where  Dev_ID='"+dev_id+"'";
                             string str3 = "delete from DevmA_Histroy where  Dev_ID='" + dev_id + "'";
                             try
                             {
                                 sql.Insert(str1);
                                 sql.Insert(str2);
                                 sql.Insert(str3);
                             }
                             catch
                             {
                                 RichTextBox.Text += "###初始化失败###\r\n"; 
                             }
                             RichTextBox.Text += "初始化成功！\r\n";
                             RichTextBox.Focus();
                             RichTextBox.Select(RichTextBox.TextLength, 0);
                             RichTextBox.ScrollToCaret(); 
                    });
                    break;
                }
                else
                {
                   
                    if(Isback==BackState.No)
                    {
                        this.Invoke((EventHandler)delegate
                        {
                            //  this.btn_Init.Text = "重试"+"("+ Cout.ToString()+")";
                            RichTextBox.Text += "初始化过程中,请稍后...\r\n";
                            Delaytime.Delay(2000);
                        });
                    }
                    else
                    {
                        this.Invoke((EventHandler)delegate
                        {
                            Indicator.AutoStart = false;
                            //this.btn_Init.Text = "重试";
                            RichTextBox.Text += "###初始化失败###\r\n"; 
                            Isback =BackState.No;
                            
                        });
                        break;
                    }
                    //没有收到
                   
                }
            }
            if(Isback==BackState.Yes)
            {
                
                //初始化数据
                //清空数据
                string de = "delete from Dev_Real where Dev_ID='"+ dev_id+"'";
                SqlHelp sql = new SqlHelp();
                sql.Insert(de);
                Thread.Sleep(100);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void InitAllDevInfofrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (btn_Init.Text.Length > 2)
            //{
            //    e.Cancel = true;
            //    MessageBox.Show("正在通信中，无法关闭......");
            //}
            this.DialogResult = DialogResult.Yes;
        }

    }
}
