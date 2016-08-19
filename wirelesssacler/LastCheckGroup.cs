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
        private int DayCount=6;
        private int MyDay=0;
        /// <summary>
        /// 查询历史数据
        /// </summary>
        /// <param name="number"></param>
        /// <param name="err"></param>
        /// <param name="num"></param>
        /// <param name="lastnum"></param>
        /// <returns></returns>
        public delegate BackState CallHistroy(string number, int daynum,int daynumend, out string err, out int num);
        public event CallHistroy callHistroyData;
        private void LastCheckGroup_Shown(object sender, EventArgs e)
        {
            string CurentGroup = this.devaddr;

            DataTable dt = query.ReturnTable("select * from `Dev_List` where Dev_Addr='" + CurentGroup + "' ORDER BY Dev_ID");

            if (dt.Rows.Count > 0)
            {
                nubs = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    nubs[i] = dt.Rows[i]["Dev_ID"].ToString();
                }
                lb_grop.Text = this.devaddr + ",共有" + nubs.Length + "个设备";
            }
            if (nubs.Length > 0)
            {
                for (int i = 0; i < nubs.Length; i++)
                {
                   rtbmsg.Text += nubs[i] + "\r\n"; 
                }
            }
            else
            {
                MessageBox.Show("当前杆塔没有设备");
              
            }
            this.dateFromPicker.CustomFormat = "yyyy-MM-dd";
            this.dateToPicker.CustomFormat = "yyyy-MM-dd";

        }

        private void btn_callData_Click(object sender, EventArgs e)
        {
            if (nubs.Length == 0) return;
            int countF = GetCount(dateFromPicker.Text.ToString(), 0);
            int countT = GetCount(dateToPicker.Text.ToString(), 1);
            if (countF < 0 || countT < 0 || countF < countT)
            {
                MessageBox.Show("时间大于当前时间或起始时间大于结束时间", "错误", MessageBoxButtons.OK);
                return;
            }      
            btn_callData.Cursor = Cursors.WaitCursor;
            RichTextBox.Text = "";
            lb_noty.Text = "开始下载数据,最长大约需要"+ (countF-countT)*6+"秒";
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
                    Isback = callHistroyData(nubs[j],countF,countT, out err, out num);
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
                                int countFF, countTT;
                                if (num - countF > 0)
                                {
                                    countFF = num - countF + 1;
                                }
                                else
                                {
                                    countFF = 1;
                                }
                                if (num - countT > 0)
                                {
                                    countTT = num - countT;
                                }
                                else
                                {
                                    countTT = 1;
                                }
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (num < 1440)
                                    {
                                        int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                       
                                        for (int k = countFF; k <= countTT; k++)
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
                                        for (int k = countFF; k <= countTT; k++)
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
        private int GetCount(string datestr, int mode)
        {
            string nowstr = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime timeFrom = Convert.ToDateTime(datestr);
            DateTime timeEnd = Convert.ToDateTime(nowstr);
            int DayDiff = Math.Abs(((TimeSpan)(timeEnd - timeFrom)).Days);
            int temp = Int32.Parse(DateTime.Now.ToString("HH")) / 4 + 1;
            DayDiff = DayDiff * DayCount + temp;
            if (mode == 1)
            {
                if (datestr == nowstr)
                    DayDiff -= temp;
                else
                    DayDiff -= DayCount;
            }

            return DayDiff;
        }

    }
}
