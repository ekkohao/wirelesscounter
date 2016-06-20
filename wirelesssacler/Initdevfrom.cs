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
    public partial class Initdevfrom : Skin_DevExpress
    {
        private byte[] sendbyte;
        private string number;
        private SqlHelp sql = new SqlHelp();
        public Initdevfrom(byte[] initinfo, string num)
        {
            InitializeComponent();
            sendbyte = initinfo;
            number = num;
           
        }

        public static BackState Isback=BackState.No;
        public delegate BackState InitDevice();
        public event  InitDevice  InitDev;
        public static Thread CheckIsback ;
      

        private void Initdevfrom_Load(object sender, EventArgs e)
        {
            tb_number.Text = number;
            tb_Cout.Text = "无记录";
            //获取设备的动作次数

            string str = "select * from Dev_Real";
             DataTable dt=sql.ReturnTable(str);
             if(dt.Rows.Count>0)
             {
                 if (dt.Rows[0]["Dev_ID"].ToString() == tb_number.Text)
                 {
                     int tcout = 0;
                     try
                     {
                         tcout = Convert.ToInt32(dt.Rows[0]["Dev_Num"]);
                     }
                     catch
                     {
                         tcout = 0;
                     }
                     tb_Cout.Text =tcout.ToString();
                     if (Convert.ToInt32(tb_Cout.Text) <= 10 == true)
                     {
                         tb_noty.Text = "次数较少，建议不要初始化,除非更换避雷器";
                     }
                 }
                
             }
            else
             {
                 tb_Cout.Text = "无记录";
             }
        }

        private void btn_Init_Click(object sender, EventArgs e)
        {
            if (Indicator.AutoStart == true) { return; }
            if (tb_number.Text != "" && tb_number.Text != null)
            {
                Isback = BackState.No;
                Indicator.AutoStart = true;
                tb_noty.Text = "正在发送，请等待几秒钟";
                //调用回调函数发送初始化信息，并返回数据
                CheckIsback = new Thread(CheckBack);
                CheckIsback.IsBackground = true;
                CheckIsback.Start();
                Delaytime.Delay(500);
                Isback = InitDev(); 
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
                        Indicator.AutoStart = false;
                        tb_noty.Text = "设备初始化成功!";
                     //   this.btn_Init.Text = "设置";
                        //清空实时数据
                        if(MessageBox.Show("初始化完毕是否清空原先旧数据？","提示信息",MessageBoxButtons.YesNo)==DialogResult.Yes)
                        {
                            //
                             string str1 = "update Dev_Real set Dev_Num = 0,Dev_OldNum =0,Dev_mA = 0,Dev_Time='0',Dev_Loadtime='0' where Dev_ID='" + tb_number.Text + "'";
                             string str2 = "delete from DevLight_Histroy where  Dev_ID='"+tb_number.Text+"'";
                             string str3 = "delete from DevmA_Histroy where  Dev_ID='" + tb_number.Text + "'";
                             try
                             {
                                 sql.Insert(str1);
                                 sql.Insert(str2);
                                 sql.Insert(str3);
                             }
                             catch
                             {
                                 MessageBox.Show("清空异常，清空失败。");
                             }
                        }
   
                    });
                    break;
                }
                else
                {
                   
                    if(Isback==BackState.No)
                    {
                        //Cout++;
                        this.Invoke((EventHandler)delegate
                        {
                          //  this.btn_Init.Text = "重试"+"("+ Cout.ToString()+")";
                            tb_noty.Text = "初始化过程中...";
                        });
                        Delaytime.Delay(1000);
                    }
                    else
                    {
                        this.Invoke((EventHandler)delegate
                        {
                            Indicator.AutoStart = false;
                            //this.btn_Init.Text = "重试";
                            tb_noty.Text = "设备初始化失败!";
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
                string de = "delete from Dev_Real where Dev_ID='"+ number+"'";
                SqlHelp sql = new SqlHelp();
                sql.Insert(de);
                Thread.Sleep(100);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Initdevfrom_FormClosing(object sender, FormClosingEventArgs e)
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
