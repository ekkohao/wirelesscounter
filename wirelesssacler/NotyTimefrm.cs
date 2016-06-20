using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Threading;
using System.Xml;
using System.Configuration;
namespace wirelesssacler
{
    public partial class NotyTimefrm : Skin_DevExpress
    {
        public BackState writesuccess;
        public Thread protread;
        private string num;

        public NotyTimefrm( string dt,string ct,string numb)
        {
            InitializeComponent();
            skinTextBox4.Text = dt;
            skinTextBox5.Text = ct;
            num = numb;

        }
        public delegate bool WriteTtime(string number,out string err);
        public event WriteTtime  Write;
        public bool Auto = false;
        private void btnSet_Click(object sender, EventArgs e)
        {

            btn_Set.Cursor = Cursors.WaitCursor;
            string errs;
            lb_noty2.Text = "设置时间中....";
           if(Write(num,out errs))//执行事件并等待结果
           {
               lb_noty2.Text = errs;
               Thread.Sleep(1000);
               this.Close();
           }
            else
           {
               lb_noty2.Text = errs;
           }
           btn_Set.Cursor = Cursors.Default;
        }
        private void NotyTimefrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(btn_Set.Enabled==false)
            {
                e.Cancel = true;
            }
        }
        private void NotyTimefrm_Shown(object sender, EventArgs e)
        {
            if(Auto==false)
            {
                //不自动校准时间
                DialogResult dr;
                dr = MessageBox.Show("请检测当前计算机时间是否准确，以便于\r同设备通信时以此时间来同步设备时间.", "时间提示", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)  
                    Microsoft.Win32.SystemEvents.TimeChanged += new EventHandler(SystemEvents_TimeChanged);
                else if (dr == DialogResult.Cancel)
                {
                    if (MessageBox.Show("你选择取消后，下载打开软件将不提示时间更改", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //写入配置文件
                        SetAppConfig("Notytime", "false");
                    }

                }
            }
        }
        private void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("系统时间被改变了,软件将以系统\r时间为依据同步设备时间，现在时间为：" + DateTime.Now.ToString(), "系统时间更改提示");
            SetAppConfig("Calibration", "ture");

        }
        private void SetAppConfig(string strKey, string keyValue)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(Application.ExecutablePath + ".config");
            XmlNode xnode;
            XmlElement x1;
            XmlElement x2;
            xnode = doc.SelectSingleNode("//appSettings");
            x1 = (XmlElement)xnode.SelectSingleNode("//add[@key='" + strKey + "']");
            if (x1 != null) x1.SetAttribute("value", keyValue);
            else
            {
                x2 = doc.CreateElement("add");
                x2.SetAttribute("key", strKey);
                x2.SetAttribute("value", keyValue);
                xnode.AppendChild(x2);
            }

            doc.Save(Application.ExecutablePath + ".config");
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            if(btn_Set.Enabled==false)
            {
                MessageBox.Show("数据同步中，无法关闭，请稍后再试");
                return;
            }
            this.Close();
        }

        private void NotyTimefrm_Load(object sender, EventArgs e)
        {
            string auto= ConfigurationManager.AppSettings["Notytime"];
            Auto = Convert.ToBoolean(auto);
        }
    }
}
