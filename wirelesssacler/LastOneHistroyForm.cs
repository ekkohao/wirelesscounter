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
        private int DayCount = 4;//一天4条
        private string number;
        /// <summary>
        /// 查询历史数据
        /// </summary>
        /// <param name="number"></param>
        /// <param name="err"></param>
        /// <param name="num"></param>
        /// <param name="lastnum"></param>
        /// <returns></returns>
        public delegate BackState CallHistroy(string number,int daynum ,out string err, out int num);
        public event CallHistroy callHistroyData;
        public SqlHelp query = new SqlHelp();
        private int LastDownCount = 0;
        private void LastOneHistroyForm_Shown(object sender, EventArgs e)
        {
          
        }

        private void LastOneHistroyForm_Load(object sender, EventArgs e)
        {
            //获取设备最近的数据
            string cmd = "SELECT DevmA_Histroy.Dev_ID, Last(DevmA_Histroy.Dev_Num) AS Dev_Num FROM DevmA_Histroy GROUP BY DevmA_Histroy.Dev_ID, DevmA_Histroy.Dev_Total HAVING (((DevmA_Histroy.Dev_ID)='" + number + "'))";
            DataTable dr = query.ReturnTable(cmd);
            if (dr.Rows.Count > 0)
            {
                label4.Text = "上次下载到第" + dr.Rows[0]["Dev_Num"] + "条数据,需要下载全部数据请点击下载全部历史数据按钮";
                LastDownCount =Convert.ToInt32(dr.Rows[0]["Dev_Num"]);
            }
            else
            {
                label4.Text = "上次下载到0条数据,需要下载全部数据请点击下载全部历史数据按钮";
            }

        }

        private void btn_callData_Click(object sender, EventArgs e)
        {
            btn_callData.Cursor = Cursors.WaitCursor;
            Indicator.AutoStart = true;
            if(Convert.ToInt32(LastDayCount.Text.ToString())>0)
            {
                
             //   MessageBox.Show(LastDayCount.Value.ToString());
                int MyCount =Convert.ToInt32(LastDayCount.Text.ToString())*DayCount;
                lb_noty.Text="开始下载数据，请耐心等候，预计"+MyCount*6+"秒";
               // if(MyCount>LastDownCount)
               
                    //要查询的天数的历史记录大于总记录，则从0开始，否则从总记录减去要查询的次数开始
                RichTextBox.Text = "";
                string err; int total = 0;
                BackState bs = callHistroyData(number, MyCount, out err, out total);
                if(bs==BackState.Yes)
                {
                   // lb_noty.Text="下载完成，该设备总存储"+(total)+"条数据";
                    //查询记录
                    if (total!= 0)
                    {

                        #region 收到数据

                        //  Indicator.AutoStart = false;
                        lb_noty.Text = "下载完成,该设备总存储" + (total % 1440).ToString() + "个历史记录数据";
                        RichTextBox.Text += err;
                        DataTable dt = query.ReturnTable("select * from DevmA_Histroy where Dev_ID='" + this.number+ "'");
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (total < 1440)
                                {
                                    if(total-MyCount>0)
                                    {
                                        MyCount = total-MyCount;
                                    }
                                    else
                                    {
                                        MyCount =1;
                                    }
                                    int t = Convert.ToInt32(dt.Rows[i]["Dev_Num"]);
                                    for (int k =MyCount; k < total + 1; k++)
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
                                    if (total - MyCount > 0)
                                    {
                                        MyCount = total-MyCount;
                                    }
                                    else
                                    {
                                        MyCount = 1;
                                    }
                                    for (int k = MyCount; k < total + 1; k++)
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


            }
            else
            {
                MessageBox.Show("查询的天数必须大于0");
            }
            Indicator.AutoStart = false;
            btn_callData.Cursor = Cursors.Default;
        }

        private void LastOneHistroyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void LastDayCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int t = Int32.Parse(LastDayCount.Text.ToString());
            if (t > 0)
                LastDayCount.Text = (t - 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int t = Int32.Parse(LastDayCount.Text.ToString());
            LastDayCount.Text = (t + 1).ToString();
        } 
    }
}
