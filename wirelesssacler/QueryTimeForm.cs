using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace wirelesssacler
{
    public partial class QueryTimeForm : Skin_DevExpress
    {
        public QueryTimeForm( string curnumber)
        {
            InitializeComponent();
            number =curnumber;
        }
        private string number;

        public delegate bool GetDev(string Numbe,out string time,out string local);
        public event GetDev GetDevtime;
        public delegate bool WriteTtime(string number,out string err);
        public event WriteTtime  Writedev; 
        private void QueryTimeForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_qurytime_Click(object sender, EventArgs e)
        {
            btn_qurytime.Cursor = Cursors.WaitCursor;
            tb_devtime.Text = "获取时间中...";
            string times,loacl;
            if(GetDevtime(number,out times,out loacl))
            {
                //提示是否时间一致
                tb_devtime.Text = times;
                DateTime dt1 = new DateTime();
                DateTime dt2 = new DateTime();
                dt1 = Convert.ToDateTime(times);
                dt2 = Convert.ToDateTime(loacl);
                if(comparetime(dt1,dt2))
                {
                    //修改时间
                    NotyTimefrm no = new NotyTimefrm(dt1.ToString(), dt2.ToString(), number);
                    no.Write += no_Write;
                    no.ShowDialog();
                }
                else
                {
                    label5.Text = "时间相差不大，不需要修改时间";
                }
            }
            else
            {
                tb_devtime.Text = "获取失败，请重试";
            }
            btn_qurytime.Cursor = Cursors.Default;
        }

        bool no_Write(string number, out string err)
        {
             bool wri=Writedev(number, out err);
             if(wri)
             {
                 label5.Text = "写入设备时间完成";
             }
            return wri;
        }

        private void QueryTimeForm_Shown(object sender, EventArgs e)
        {
            string cmd="SELECT Dev_List.Dev_ID, Dev_List.Dev_Addr, Dev_List.Dev_Phase FROM Dev_List where Dev_List.Dev_ID='"+number+"'";
            MySqlCon.SqlHelp sql=new MySqlCon.SqlHelp();
            DataTable dt = sql.ReturnTable(cmd);
            if(dt.Rows.Count>0)
            {              
              tb_devaddr.Text = dt.Rows[0]["Dev_Addr"].ToString();
              tb_phrse.Text = dt.Rows[0]["Dev_Phase"].ToString();
              tb_devnumber.Text = number;
              tb_devtime.Text = "请点击获取时间按钮获取设备时间...";         
            }
        }
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
        public  bool comparetime(DateTime dt, DateTime ct)
        {
            bool chang = false;
            //时间处理函数
            if (dt.Year != ct.Year || dt.Month != ct.Month || dt.Day != ct.Day || dt.Hour != ct.Hour)
            {
                //年月日不同，提示去修改时间
                chang = true;
            }
            else
            {
                //计算当前的分钟和秒数
                int fen = ct.Minute - dt.Minute;
                if (fen > -10 || fen < 10)
                {
                    //当前时间比设备快不止1分钟，提示修改
                    chang = false;
                }
                else
                {
                    chang = true;
                }
            }
            return chang;
        }

        private void btn_tongbu_Click(object sender, EventArgs e)
        {
            btn_tongbu.Cursor = Cursors.WaitCursor;
            string err=string.Empty;
            label5.Text = "立即同步中...";
            bool wri = Writedev(number, out err);
            if (wri)
            {
                label5.Text = "写入设备时间完成";
            }
            else
            {
                label5.Text = err;
            }
            btn_tongbu.Cursor = Cursors.Default;
        }
    }
}
