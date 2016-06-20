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
    public partial class Messagefrm : Skin_DevExpress
    {
        public bool isNumberic(string message)
        {
            System.Text.RegularExpressions.Regex rex =
            new System.Text.RegularExpressions.Regex(@"^\d+$");
            ulong result = 0;
            if (message == null) return false;
            if (rex.IsMatch(message))
            {
                result = ulong.Parse(message);
                return true;
            }
            else
                return false;
        }
        private bool isnum=false;
        private string devnum;
        public Messagefrm(string dev,string version)
        {
            InitializeComponent();
            if(version=="1.0.0.0")
            {
                btn_downhis.Enabled = false;
            }
            else
            {
                btn_downhis.Enabled = true;
            }
            tb_dev.Text = dev;
            if(isNumberic(dev))
            {
                //数字
                isnum = true;
               // lb_noty.Text = "1111";
            }
            else
            {
                //非数字
                isnum = false;
            }
            devnum = dev;
        }
        public delegate  void DoQuery(string num,bool isreal);
        public delegate  void  DoQueryAddr(string add,bool isreal);
        public delegate void DoQueryLight(string num);
        public delegate void DoQueryLightAdd(string add);
        /// <summary>
        /// 下载序列数据，true实时，false 历史
        /// </summary>
        public event DoQuery Doquery;
        /// <summary>
        /// 下载序列数据，true实时，false 历史
        /// </summary>
        public event DoQueryAddr DoqueryAddr;
        /// <summary>
        /// 下载序列
        /// </summary>
        public event DoQueryLight Dolight;
        /// <summary>
        /// 下载组
        /// </summary>
        public event DoQueryLightAdd Dolightaddr;

        private void btn_Look_Click(object sender, EventArgs e)
        {
            if (isnum)
            {
                QueryCurrentfrm qur = new QueryCurrentfrm(tb_dev.Text);
                qur.ShowDialog();
            }
            else
            {
                QueryGroupForm grop = new QueryGroupForm(tb_dev.Text);
                grop.ShowDialog();
            }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if(isnum)
            {
                //下载该序列数据
                Doquery(tb_dev.Text,true);
            }
            else
            {
                //下载该组设备数据
                DoqueryAddr(tb_dev.Text,true);
            }
        }

        private void btn_downhis_Click(object sender, EventArgs e)
        {
            if (isnum)
            {
                //下载该序列数据
                Doquery(tb_dev.Text,false);
            }
            else
            {
                //下载该组设备数据
                DoqueryAddr(tb_dev.Text,false);
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_light_Click(object sender, EventArgs e)
        {
            if(isnum)
            {
                //查询该设备
                Dolight(tb_dev.Text);
            }
            else
            {
                //查询该组
                Dolightaddr(tb_dev.Text);
            }
        }
  



    }
}
