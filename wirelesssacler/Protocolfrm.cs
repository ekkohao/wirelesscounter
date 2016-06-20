using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace wirelesssacler
{
    public partial class Protocolfrm :Skin_DevExpress
    {
        public Protocolfrm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 串口十分打开，通信协议版本
        /// </summary>
        /// <param name="Comopen"></param>
        /// <param name="protocolversion"></param>
        /// <param name="?"></param>
        public Protocolfrm(bool Comopen,string protocolversion)
        {
            InitializeComponent();
            open = Comopen;
            version = protocolversion;
        }
        private bool open = false;
        private string version = "";

        public delegate bool ChangePro(string ver);
        public event ChangePro changePro;
        private bool ok = false;
        private void btn_change_Click(object sender, EventArgs e)
        {
            if(open)
            {
                MessageBox.Show("当前通信端口正在使用中，请点击通信端口图标关闭通信后再切换协议！");
                return;
            }
            else
            {
                timer1.Start();
                if(Rbtn_JSQ.Checked && RBtn_JCY.Checked==false)
                {
                    ok=changePro("1.0.0.0");
                }
                else if (Rbtn_JSQ.Checked==false && RBtn_JCY.Checked)
                {
                    ok=changePro("2.0.0.0");
                }
            }
        }

        private void Protocolfrm_Load(object sender, EventArgs e)
        {
            if (open)
            {
                RichBox.Text = "串口已经打开,请关闭串口后操作！";
              //  btn_change.Enabled = false;
            }
            else
            {
                if(version=="1.0.0.0")
                {
                    //不带全电流
                    Rbtn_JSQ.Checked = true;
                }
                else
                {
                    //带全电流
                    RBtn_JCY.Checked = true;
                }
            }
        }

        private void RBtn_JCY_CheckedChanged(object sender, EventArgs e)
        {
            if(RBtn_JCY.Checked)
            {
                RichBox.Text = "当前设备使用协议为带全电流的协议，使用该协议的设备不仅具有不带全电流的功能，而且带有记录全电流功能，设备具有保存全电流的记录功能，能够查询到设备的全电流历史记录。";
                Rbtn_JSQ.Checked = false;
            }
        }

        private void Rbtn_JSQ_CheckedChanged(object sender, EventArgs e)
        {
            if(Rbtn_JSQ.Checked)
            {
                RichBox.Text = "当前设备使用协议为无全电流的协议，使用该协议设备只能记录动作次数，设备能记录动作的记录，本协议不具有获取历史数据的记录。";
                RBtn_JCY.Checked = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ok)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
