using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using MySqlCon;
using System.Threading;

namespace wirelesssacler
{
    public partial class LightGroupfrm : Skin_DevExpress
    {
        public delegate bool queryLight(string num,int count,int start,out string err);

        public event queryLight Query;

        private SqlHelp sql = new SqlHelp();
  
        private int oldnum = 0;//上次的动作次数

        private bool exit = false;
        public LightGroupfrm(string addr)
        {
            InitializeComponent();
            tb_msg.Text += "该安装地址所在设备的动作次数记录:\r\n";
           DataTable dt = sql.ReturnTable("select * from Dev_Real where Dev_Addr='" + addr + "'");
            int cout = 0;
            if (dt.Rows.Count == 0)
            {
                lb_noty.Text = "读取该组设备数据实时数据,获取动作次数记录失败,请先下载实时数据";
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                        try
                        {
                            cout = Convert.ToInt32(dt.Rows[i]["Dev_Num"].ToString());
                            oldnum = Convert.ToInt32(dt.Rows[i]["Dev_OldNum"].ToString());
                            string numid = dt.Rows[i]["Dev_ID"].ToString();
                            int downnum = GetMaxCount(numid);
                            tb_msg.Text += "设备序列" + numid + "上次动作次数" + oldnum.ToString() + "条，" + "本次动作次数" + cout.ToString() + "条 ，上次招收到第" + downnum + "条" + "\r\n\r\n";
                            string name = dt.Rows[i]["Dev_ID"].ToString();
                            string add = dt.Rows[i]["Dev_Addr"].ToString();
                            string ph = dt.Rows[i]["Dev_Phase"].ToString();
                            string names = add + "(" + name + ")" + "监测路线位置:" + ph;
                            downdata dd = new downdata();
                            dd.id = name;
                            dd.count = cout;
                            dd.indexf = downnum;
                            ListBox_dev.Items.Add(names);
                        }
                        catch
                        {
                            continue;
                        }
                }
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            exit = false;
            btn_query.Cursor = Cursors.WaitCursor;
            Indicator.AutoStart = true;
            LinkedList<string> mylist = new LinkedList<string>();
             for (int j = 0; j < ListBox_dev.Items.Count; j++)
             {
                  if(ListBox_dev.GetItemChecked(j))
                  {
                      
                      string onum= ListBox_dev.Items[j].ToString();///);
                      int i = onum.IndexOf("(")+1;
                      int k = onum.IndexOf(")");
                      string nnum = onum.Substring(i, k - i);
                      mylist.AddLast(nnum);
                  }
             }
             if(mylist.Count>0)
             {
                
                 LinkedListNode<string> ps = mylist.First;
                 tb_msg.Text = "";
                 while(ps!=null && exit==false)
                 {
                     #region ///
                    
                     string err;
                     int s = 1;
                     int cout = 0;
                     cout = getLightnum(ps.Value, out s);
                     if (cout > 0)
                     {
                        
                      
                             tb_msg.Text += "正在获取设备序列号为:" + ps.Value + "动作数据大约" + ((cout - s)*6).ToString() + "秒\r\n";
                          //   tb_msg.Text += "正在设获取备序列号为:" + ps.Value + "动作数据大约" + (cout - s).ToString() + "秒\r\n";
                             #region
                             //产生新增动作
                             if (exit)
                             {
                                 break;
                             }
                             bool call = Query(ps.Value, cout, s, out err);
                             if (call)
                             {
                                 DataTable sq = sql.ReturnTable("Select * from DevLight_Histroy where Dev_ID='" + ps.Value + "'");
                                 if (sq != null && sq.Rows.Count > 0)
                                 {
                                     for (int i = 0; i < sq.Rows.Count; i++)
                                     {
                                         tb_msg.Text += "设备序列:" + sq.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                         tb_msg.Text += "设备地址:" + sq.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                         tb_msg.Text += "监测相位" + sq.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                                         tb_msg.Text += "动作次数" + sq.Rows[i]["Dev_Num"].ToString() + "\r\n";
                                         tb_msg.Text += "动作时间" + sq.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                         tb_msg.Text += "\r\n";
                                     }
                                     tb_msg.Text+= "\r\r\n";
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
                                     tb_msg.Text += "设备序列号为:" + ps.Value + "\r\n" + err + "\r\n";
                                 }
                             }
                             #endregion
                         

                     }
                     else
                     {
                         tb_msg.Text += "设备序列号为:" + ps.Value + "动作记录次数没有，请获取实时数据\r\n";
                     }
                     #endregion

                     ps = ps.Next;
                 }
                 tb_msg.Text += "下载设备数据结束\r\n";
             }
            else
             {
                 tb_msg.Text += "没有选择设备\r\n";
             }
             Indicator.AutoStart = false;
             btn_query.Cursor = Cursors.Default;
        }

        private void CheckBox_all_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_all.Checked)
            {
                for (int j = 0; j < ListBox_dev.Items.Count; j++)
                { ListBox_dev.SetItemChecked(j, true); }
            }
            else
            {
                for (int j = 0; j < ListBox_dev.Items.Count; j++)
                { ListBox_dev.SetItemChecked(j, false); }
            }
        }


        private void LightGroupfrm_Shown(object sender, EventArgs e)
        {
            if(btn_query.Enabled==false)
            {
                MessageBox.Show("无动作记录总次数，请下载实时数据获取当前动作记录总次数！");
                this.Close();

            }
        }

        private int getLightnum(string num, out int start)
        {
            DataTable dt = sql.ReturnTable("select * from Dev_Real where Dev_ID='" + num + "'");
            int cout = 0;
            int oldnum = 0;
            start = 0;
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
                        oldnum = GetMaxCount(num);
                    }
                }
            }
            if (cout == 0)
                return cout;
            else
                start = oldnum;
            return cout;
        }

        private void tb_msg_TextChanged(object sender, EventArgs e)
        {
            tb_msg.Select(tb_msg.TextLength, 0);
            tb_msg.ScrollToCaret();
        }

        private void LightGroupfrm_Load(object sender, EventArgs e)
        {
           
        }
        private int  GetMaxCount(string num)
        {

            DataTable dt2 = sql.ReturnTable("select * from DevLight_Histroy where Dev_ID='" + num + "'");
            int maxnum = 0;
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
                maxnum = max;

            }
            else
            {
                maxnum = 0;
            }
            return maxnum;
        }

        private void LightGroupfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            this.DialogResult = DialogResult.Yes;
        }
    }
}
