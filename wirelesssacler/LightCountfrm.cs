using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Threading;
using MySqlCon;

namespace wirelesssacler
{
    public partial class LightCountfrm : Skin_DevExpress
    {
  
        public LightCountfrm(string numbs)
        {
            InitializeComponent();

            num = numbs;
            this.Text = "加载数据中。。。";
        }

        private string num;
        public delegate bool queryLight(string num, int count, int start, out string err);//(int cout,string  number,out string err);

        public event queryLight Query;

        private SqlHelp sql = new SqlHelp();
        private string xulie;
        private int Total= 0;
        private string time;
        private int oldnum = 0;//上次的动作次数
        private int lastnum = 0;//上次下载的次数
        private void btn_query_Click(object sender, EventArgs e)
        {
            btn_query.Cursor = Cursors.WaitCursor;
            Indicator.AutoStart = true;
            Msgtxt.Text = "";
            if (Total > 0)
            {
              
                time = DateTime.Now.ToString();
                 string err="";
                 lb_noty.Text = "正在加载数据大约需要"+(6*(Total-lastnum))+"秒！";
                 bool bs=false;
                 if (Total - lastnum > 0)
                 {
                     bs = Query(xulie, Total, lastnum, out err);
                 }
                 else
                 {
                     bs = true;
                 }
                 if(bs)
                {
                    btn_query.Text = "查询";
                    lb_noty.Text = "查询成功";

                    DataTable sq = sql.ReturnTable("Select * from DevLight_Histroy where Dev_ID='" + xulie + "'");
                    if(sq!=null && sq.Rows.Count>0)
                    {
                        string txt = "";
                        for (int i = 0; i < sq.Rows.Count; i++)
                        {
                            txt += "设备序列:" + sq.Rows[i]["Dev_ID"].ToString() + "\r\n";
                            txt += "设备地址:" + sq.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                            txt += "监测相位" + sq.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                            txt += "动作次数" + sq.Rows[i]["Dev_Num"].ToString() + "\r\n";
                            txt += "动作时间" + sq.Rows[i]["Dev_Time"].ToString() + "\r\n";
                            txt += "\r\n";
                      
                        }
                        Msgtxt.Text +=txt+"\r\r\n";
                    }
                    else
                    {
                        lb_noty.Text = "数据加载失败，请重新下载历史记录数据。";
                    }
                }
                else
                 {
                    Msgtxt.Text +=err;
                 }
            }
            else
            {
              
                MessageBox.Show("当前设备动作记录次数为0，请查询该设备的实时数据，确认设备有没有产生新的动作记录。");
                this.Close();
            }
            Indicator.AutoStart = false;
            btn_query.Cursor = Cursors.Default;
        }

        private void Msgtxt_TextChanged(object sender, EventArgs e)
        {
            Msgtxt.Select(Msgtxt.TextLength, 0);
            Msgtxt.ScrollToCaret();
        }

        private void LightCountfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(btn_query.Text.Length>2)
            //{
            //    e.Cancel = true;
            //    MessageBox.Show("数据下载中，请稍后.....");
            //}
            this.DialogResult = DialogResult.Yes;
        }

        private void LightCountfrm_Shown(object sender, EventArgs e)
        {
            this.Text = "动作记录查询";
            dev_number.Text = num;
            DataTable dt = sql.ReturnTable("select * from Dev_Real where Dev_ID='" + num + "'");
            int cout = 0;
            if (dt.Rows.Count == 0)
            {
                cout = 0;
            }
            else
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Dev_ID"].ToString() ==num)
                    {                  
                       cout = Convert.ToInt32(dt.Rows[i]["Dev_Num"].ToString());
                       oldnum = Convert.ToInt32(dt.Rows[i]["Dev_OldNum"].ToString());
                       Total = cout;
                    }
                }
            }
            lb_count.Text = cout.ToString(); 
            if (cout == 0)
                lb_noty.Text = "没有设备的动作次数记录，请获取设备实时数据后查看是否有新动作记录。";
            else
            {
                if ((cout - oldnum) > 0)
                    lb_noty.Text = "该设备动作了" + cout.ToString() + "次,新增" + (cout - oldnum) + "次,预计下载需要" + (cout - oldnum) * 6 + "秒";
                else
                {
                    lb_noty.Text = "该设备动作次数" + cout.ToString() + "次,无新增次数,建议不需要下载动作次数";
                }
            }
            xulie = num;
            lb_hiscout.Text = oldnum.ToString();
            DataTable dt2 = sql.ReturnTable("select * from DevLight_Histroy where Dev_ID='" + num + "'");
            if (dt2.Rows.Count > 0)
            {
                int[] numbs = new int[dt2.Rows.Count];
                for (int i = 0; i < dt2.Rows.Count; i++)
                {

                    try
                    {
                        numbs[i] = Convert.ToInt32(dt2.Rows[i]["Dev_Num"].ToString());

                    }
                    catch
                    {
                       continue;
                    }

                }

                int max = 0;
                for (int j = 0; j < numbs.Length; j++)
                {
                    max = max > numbs[j] ? max : numbs[j];
                }
                lastnum = max;

            }
            else
            {
                lastnum = 0;
            }
            lb_downcout.Text = lastnum.ToString();
        }
    }
}
