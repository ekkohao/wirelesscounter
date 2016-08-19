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
    public partial class LastOneHistroyForm : Skin_DevExpress
    {
        public LastOneHistroyForm()
        {
            InitializeComponent();
        }
        public LastOneHistroyForm(string addr)
        {
             InitializeComponent();
             number=addr;
             lb_grop.Text = number;
        }
        private int DayCount = 6;//一天4条
        private string number;
        /// <summary>
        /// 查询历史数据
        /// </summary>
        /// <param name="number"></param>
        /// <param name="err"></param>
        /// <param name="num"></param>
        /// <param name="lastnum"></param>
        /// <returns></returns>
        public delegate BackState CallHistroy(string number,int daynum ,int daynumend,out string err, out int num);
        public event CallHistroy callHistroyData;
        public SqlHelp query = new SqlHelp();
        private int LastDownCount = 0;
        private void LastOneHistroyForm_Shown(object sender, EventArgs e)
        {
          
        }

        private void LastOneHistroyForm_Load(object sender, EventArgs e)
        {
            this.dateFromPicker.CustomFormat = "yyyy-MM-dd";
            this.dateToPicker.CustomFormat = "yyyy-MM-dd";
            //Console.WriteLine(dateFromPicker.Text.ToString());
            //Console.WriteLine(dateToPicker.Text.ToString());
        }

        private void btn_callData_Click(object sender, EventArgs e)
        {
            int countF = GetCount(dateFromPicker.Text.ToString(),0);
            int countT = GetCount(dateToPicker.Text.ToString(),1);
            if (countF < 0 || countT < 0 || countF < countT)
            {
                MessageBox.Show("时间大于当前时间或起始时间大于结束时间", "错误", MessageBoxButtons.OK);
                return;
            }

            btn_callData.Cursor = Cursors.WaitCursor;
            Indicator.AutoStart = true;
                
             //   MessageBox.Show(LastDayCount.Value.ToString());
             //int MyCount = Convert.ToInt32(dateFromPicker.Text.ToString()) * DayCount;
            lb_noty.Text = "开始下载数据，请耐心等候，最长等待" + (countF - countT) * 6 + "秒";
               // if(MyCount>LastDownCount)
               
                    //要查询的天数的历史记录大于总记录，则从0开始，否则从总记录减去要查询的次数开始
                RichTextBox.Text = "";
                string err; int total = 0;
                BackState bs = callHistroyData(number, countF, countT, out err, out total);
                if(bs==BackState.Yes)
                {
                   // lb_noty.Text="下载完成，该设备总存储"+(total)+"条数据";
                    //查询记录
                    if (total > 0)
                    {

                        #region 收到数据

                        //  Indicator.AutoStart = false;
                        lb_noty.Text = "下载完成,该设备总存储" + (total % 1440).ToString() + "个历史记录数据";
                        RichTextBox.Text += err;
                        DataTable dt = query.ReturnTable("select * from DevmA_Histroy where Dev_ID='" + this.number + "' ORDER BY Dev_Num");
                        if (dt.Rows.Count > 0)
                        {
                            if (total - countF > 0)
                            {
                                countF = total - countF + 1;
                            }
                            else
                            {
                                countF = 1;
                            }
                            if (total - countT > 0)
                            {
                                countT = total - countT;
                            }
                            else
                            {
                                countT = 1;
                            }
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (total < 1440)
                                {
                                    
                                    int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                    for (int k = countF; k < countT + 1; k++)
                                    {
                                        if (t == k)
                                        {
                                            RichTextBox.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                            RichTextBox.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                            RichTextBox.Text += "监测的相位: " + dt.Rows[i]["Dev_Phase"].ToString() + "(相位)\r\n";
                                            RichTextBox.Text += "记录次数:第 " + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                            RichTextBox.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                            RichTextBox.Text += "数据存储时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                            RichTextBox.Text += "设备召测时间: " + dt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
                                            RichTextBox.Text += "\r\n";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                    t = t % 1440;
                                    for (int k = countF; k < countT + 1; k++)
                                    {
                                        if (t == k)
                                        {
                                            RichTextBox.Text += "设备序列号: " + dt.Rows[i]["Dev_ID"].ToString() + "\r\n";
                                            RichTextBox.Text += "设备地址:" + dt.Rows[i]["Dev_Addr"].ToString() + "\r\n";
                                            RichTextBox.Text += "监测的相位: " + dt.Rows[i]["Dev_Phase"].ToString() + "(相位)\r\n";
                                            RichTextBox.Text += "记录次数:第 " + dt.Rows[i]["Dev_Num"].ToString() + "条\r\n";
                                            RichTextBox.Text += "设备全电流: " + dt.Rows[i]["Dev_mA"].ToString() + "（μA）\r\n";
                                            RichTextBox.Text += "数据存储时间: " + dt.Rows[i]["Dev_Time"].ToString() + "\r\n";
                                            RichTextBox.Text += "设备召测时间: " + dt.Rows[i]["Dev_Loadtime"].ToString() + "\r\n";
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
                       
                        lb_noty.Text = "下载完成,共" + (total % 1440).ToString() + "个历史数据记录";
                        RichTextBox.Text += err + "\r\n";
                    }
                }
                else
                {
                    RichTextBox.Text = err;
                }

            Indicator.AutoStart = false;
            btn_callData.Cursor = Cursors.Default;
        }

        private void LastOneHistroyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
        private int GetCount(string datestr,int mode)
        {
            string nowstr = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime timeFrom = Convert.ToDateTime(datestr);
            DateTime timeEnd = Convert.ToDateTime(nowstr);
            int DayDiff = Math.Abs(((TimeSpan)(timeEnd - timeFrom)).Days);
            int temp = Int32.Parse(DateTime.Now.ToString("HH")) / 4+1;
            DayDiff =DayDiff*DayCount+temp;
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
