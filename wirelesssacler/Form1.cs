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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlHelp query = new SqlHelp();

        string realstr = "select * from Dev_Real";
        string mastr = "select * from DevmA_Histroy";
        string lightstr = "select * from DevLight_Histroy";

        private void DataCenterfrm_Load(object sender, EventArgs e)
        {
            //加载数据到表
            //添加列表头
            AddColoum();

        }

        private void AddColoum()
        {
            RealDataGridView.Columns.Add("DevID", "设备序列号");
            RealDataGridView.Columns.Add("DevAddr", "安装地址");
            RealDataGridView.Columns.Add("DevPhase", "监测路线位置");
            RealDataGridView.Columns.Add("DevNum", "本次查询动作次数");
            RealDataGridView.Columns.Add("Dev_OldNum", "上次查询动作次数");
            RealDataGridView.Columns.Add("DevmA", "电流(uA)");
            RealDataGridView.Columns.Add("Devloactime", "召测数据时间");

            MaDataGridView.Columns.Add("DevID", "设备序列号");
            MaDataGridView.Columns.Add("DevAddr", "安装地址");
            MaDataGridView.Columns.Add("DevPhase", "监测路线位置");
            MaDataGridView.Columns.Add("DevNum", "历史数据条数");
            MaDataGridView.Columns.Add("DevmA", "电流(uA)");
            MaDataGridView.Columns.Add("Devtime", "数据存储时间");
            MaDataGridView.Columns.Add("Devloactime", "召测数据时间");
            
            LightDataGridView.Columns.Add("DevID", "设备序列号");
            LightDataGridView.Columns.Add("DevAddr", "安装地址");
            LightDataGridView.Columns.Add("DevPhase", "监测路线位置");
            LightDataGridView.Columns.Add("DevNum", "动作次数");
            LightDataGridView.Columns.Add("Devtime", "动作时间");
        }
        private void UpdateReal()
        {
            DataTable dt = query.ReturnTable(realstr);
            if (dt.Rows.Count > 0)
            {

                RealDataGridView.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    object[] f = new object[7];
                    f[0] = dt.Rows[i][1];
                    f[1] = dt.Rows[i][2];
                    f[2] = dt.Rows[i][3];
                    f[3] = dt.Rows[i][4];
                    f[4] = dt.Rows[i][5];
                    f[5] = dt.Rows[i][6];
                    f[6] = dt.Rows[i][8];
                    RealDataGridView.Rows.Add(f);


                }
            }
            else
            {
                //   MessageBox.Show("读取上次查询实时记录数据失败，当前没有记录的数据");
            }

        }
        private void UpdataLightHistroy()
        {
            DataTable dt = query.ReturnTable(lightstr);
            if (dt.Rows.Count > 0)
            {
                LightDataGridView.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    object[] f = new object[5];
                    f[0] = dt.Rows[i][1];
                    f[1] = dt.Rows[i][2];
                    f[2] = dt.Rows[i][3];
                    f[3] = dt.Rows[i][4];
                    f[4] = dt.Rows[i][5];
                    LightDataGridView.Rows.Add(f);


                }
            }
            else
            {
                //  MessageBox.Show("读取动作记录数据失败，当前没有记录的数据");
            }
        }

        private void UpdataMaHistroy()
        {
            DataTable dt = query.ReturnTable(mastr);
            if (dt.Rows.Count > 0)
            {
                MaDataGridView.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object[] f = new object[7];
                    f[0] = dt.Rows[i][1];
                    f[1] = dt.Rows[i][2];
                    f[2] = dt.Rows[i][3];
                    f[3] = dt.Rows[i][4];
                    f[4] = dt.Rows[i][5];
                    f[5] = dt.Rows[i][6];
                    f[6] = dt.Rows[i][8];
                    MaDataGridView.Rows.Add(f);


                }
            }
            else
            {
                //    MessageBox.Show("读取历史记录数据失败，当前没有记录的数据");
            }
        }
        void DataCenterfrm_Shown(object sender, EventArgs e)
        {
            UpdateReal();
            //UpdataLightHistroy();
            UpdataMaHistroy();


        }


        private void TabRealAndHistroy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabRealAndHistroy.SelectedIndex == 0)
            {
                //默认的
                UpdateReal();
            }
            else if (TabRealAndHistroy.SelectedIndex == 1)
            {

                UpdataMaHistroy(); 
            }
            else
            {
                UpdataLightHistroy();
            }
        }

    }
}
