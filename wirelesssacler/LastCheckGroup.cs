using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using MySqlCon;
namespace wirelesssacler
{
    public partial class LastCheckGroup : Skin_DevExpress
    {
        public LastCheckGroup()
        {
            InitializeComponent();
        }
        public LastCheckGroup(string addr)
        {
            InitializeComponent();
            devaddr = addr;
        }
        private string devaddr;
        private SqlHelp query = new SqlHelp();
        private string[] nubs = null;
        private BackState Isback;
        private int DayCount=4;
        private int MyDay=0;
        /// <summary>
        /// 查询历史数据
        /// </summary>
        /// <param name="number"></param>
        /// <param name="err"></param>
        /// <param name="num"></param>
        /// <param name="lastnum"></param>
        /// <returns></returns>
        public delegate BackState CallHistroy(string number, int daynum, out string err, out int num);
        public event CallHistroy callHistroyData;
        private void LastCheckGroup_Shown(object sender, EventArgs e)
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
                MessageBox.Show("当前杆塔没有设备");
              
            }
            if (nubs.Length > 0)
            {
                for (int i = 0; i < nubs.Length; i++)
                {
                    string cmd = "SELECT DevmA_Histroy.Dev_ID, Last(DevmA_Histroy.Dev_Num) AS Dev_Num FROM DevmA_Histroy GROUP BY DevmA_Histroy.Dev_ID, DevmA_Histroy.Dev_Total HAVING (((DevmA_Histroy.Dev_ID)='" + nubs[i] + "'))";
                    DataTable dr = query.ReturnTable(cmd);
                    if (dr.Rows.Count > 0)
                    {
                        rtbmsg.Text += nubs[0] + "上次下载到第" + dr.Rows[0]["Dev_Num"] + "条数据,需要下载数据请点击下载按钮";

                    }
                    else
                    {
                         rtbmsg.Text += nubs[0] + "上次下载到0条数据,需要下载请点击下载按钮";
                    }
                }
            }
            else
            {
                rtbmsg.Text += "没有查询到设备数据相关信息";
            }
        }

        private void btn_callData_Click(object sender, EventArgs e)
        {
            if (nubs.Length == 0) return;
            try
            {
                if (Convert.ToInt32(LastDayCount.Value) == 0)
                {
                    MessageBox.Show("查询天数必须大于0");
                    return;
                }
            }
            catch
            {
                return;
            }
            MyDay = Convert.ToInt32(LastDayCount.Value) * DayCount;
            
            btn_callData.Cursor = Cursors.WaitCursor;
            RichTextBox.Text = "";
            lb_noty.Text = "开始下载数据,大约需要"+ MyDay*6+"秒";
            Indicator.AutoStart = true;
                //历史数据
                lb_noty.Text = "开始下载数据";
                Isback = BackState.No;
                for (int j = 0; j < nubs.Length; j++)
                {
                    lb_noty.Text = "开始下载第" + (j + 1).ToString() + "个设备数据";
                    string err; int num;
                    //
                    #region 历史数据
                    Isback = callHistroyData(nubs[j],MyDay, out err, out num);
                    if (Isback == BackState.Yes)
                    {

                        if (num != 0)
                        {

                            #region 收到数据


                            lb_noty.Text = "下载完成,共" + (num % 1440).ToString() + "历史记录";
                            RichTextBox.Text += err;
                            DataTable dt = query.ReturnTable("select * from DevmA_Histroy where Dev_ID='" + nubs[j] + "'");
                            RichTextBox.Text+="设备："+nubs[j]+"数据下载完成。\r\n";
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (num < 1440)
                                    {
                                        int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                        if (num - MyDay > 0)
                                        {
                                            MyDay = num - MyDay;
                                        }
                                        else
                                            MyDay = 1;
                                        for (int k = MyDay; k < num; k++)
                                        {
                                            if (t == k)
                                            {
                                                RichTextBox.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                                RichTextBox.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                                RichTextBox.Text += "监测路线位置: " + dt.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                                                RichTextBox.Text += "记录次数:第 " + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                                RichTextBox.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                                RichTextBox.Text += "数据存储时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                                RichTextBox.Text += "数据下载时间: " + dt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
                                                RichTextBox.Text += "\r\n";
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                        t = t % 1440;
                                        if (num - MyDay > 0)
                                        {
                                            MyDay = num - MyDay;
                                        }
                                        else
                                            MyDay = 1;
                                        for (int k = MyDay; k < num; k++)
                                        {
                                     
                                            if (t == k)
                                            {
                                                RichTextBox.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                                RichTextBox.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                                RichTextBox.Text += "监测路线位置: " + dt.Rows[i]["Dev_Phase"].ToString() + "\r\n";
                                                RichTextBox.Text += "记录次数: 第" + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                                RichTextBox.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                                RichTextBox.Text += "数据存储时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                                RichTextBox.Text += "数据下载时间: " + dt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
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
                           
                           rtbmsg.Text += nubs[j] + "下载完成,共" + (num % 1440).ToString() + "历史记录";

                           RichTextBox.Text += err + "\r\n";
                        }
                    }
                    else
                    {
                        lb_noty.Text = "下载" + nubs[j] + "失败";
                        RichTextBox.Text += "下载第" + (j+1).ToString() + "个设备数据失败\r\n";
                        RichTextBox.Text += err + "\r\n";
                    }
                    #endregion


                }
            lb_noty.Text = "本组数据下载完成.";
            Indicator.AutoStart = false;
            btn_callData.Cursor = Cursors.Default;
        }

        private void LastCheckGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
