using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using MySqlCon;
namespace wirelesssacler
{
    public partial class QueryGroupForm : Skin_DevExpress
    {
        public QueryGroupForm()
        {
            InitializeComponent();
        }

          private string devaddr;
          private SqlHelp query = new SqlHelp();

          string realstr;
          string mastr;
          string lightstr;
        public QueryGroupForm(string DevAddr)
        {
            InitializeComponent();
            this.devaddr = DevAddr;
            tb_Group.Text = DevAddr;
        }

        private void QueryGroupForm_Load(object sender, EventArgs e)
        {
            AddColoum();
            realstr = "select * from Dev_Real where Dev_Addr='" + devaddr + "'";
            mastr = "select * from DevmA_Histroy where Dev_Addr='" + devaddr + "'";
            lightstr = "select * from DevLight_Histroy where Dev_Addr='" + devaddr + "'";
        }
        private void AddColoum()
        {
            RealDataGridView.Columns.Add("DevID", "设备序列号");
            RealDataGridView.Columns.Add("DevAddr", "设备地址");
            RealDataGridView.Columns.Add("DevPhase", "监测相位");
            RealDataGridView.Columns.Add("DevNum", "本次查询动作次数");
            RealDataGridView.Columns.Add("Dev_OldNum", "上次查询动作次数");
            RealDataGridView.Columns.Add("DevmA", "电流(uA)");
            RealDataGridView.Columns.Add("Devloactime", "召测数据时间");

            LightDataGridView.Columns.Add("DevID", "设备序列号");
            LightDataGridView.Columns.Add("DevAddr", "设备地址");
            LightDataGridView.Columns.Add("DevPhase", "监测相位");
            LightDataGridView.Columns.Add("DevNum", "动作次数");
            LightDataGridView.Columns.Add("Devtime", "动作时间");

            MaDataGridView.Columns.Add("DevID", "设备序列号");
            MaDataGridView.Columns.Add("DevAddr", "设备地址");
            MaDataGridView.Columns.Add("DevPhase", "监测相位");
            MaDataGridView.Columns.Add("DevNum", "动作次数");
            MaDataGridView.Columns.Add("DevmA", "电流(uA)");
            MaDataGridView.Columns.Add("Devtime", "数据存储时间");
            MaDataGridView.Columns.Add("Devloactime", "召测数据时间");


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

        }

        private void QueryGroupForm_Shown(object sender, EventArgs e)
        {
            UpdateReal();
        }

        private void skinTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(skinTabControl1.SelectedIndex==0)
            {
                UpdateReal();
            }
            else if(skinTabControl1.SelectedIndex==1)
            {
                UpdataLightHistroy();
            }
            else if(skinTabControl1.SelectedIndex==2)
            {
                UpdataMaHistroy();
            }
        }

        private void RealDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
