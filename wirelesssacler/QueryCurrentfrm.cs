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
    public partial class QueryCurrentfrm : Skin_DevExpress
    {
        private string CurrentNumber;

        public QueryCurrentfrm()
        {
            InitializeComponent();
        }
        SqlHelp query = new SqlHelp();

        string realstr ;
        string mastr ;
        string lightstr;

        public QueryCurrentfrm(string currentNumber)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.CurrentNumber = currentNumber;

             realstr = "select * from Dev_Real where Dev_ID='" + CurrentNumber + "'";
             mastr = "SELECT DevmA_Histroy.Dev_ID AS 设备序列, DevmA_Histroy.Dev_Addr AS 安装地址, DevmA_Histroy.Dev_Phase AS 监测路线位置, DevmA_Histroy.Dev_mA AS 电流（uA）, DevmA_Histroy.Dev_Num AS 记录条数 ,DevmA_Histroy.Dev_Time AS 存储时间, DevmA_Histroy.Dev_Total AS 历史记录总条数, DevmA_Histroy.Dev_Loadtime AS 下载时间 FROM DevmA_Histroy WHERE (DevmA_Histroy.Dev_ID='" + CurrentNumber + "')";
             lightstr = "SELECT DevLight_Histroy.Dev_ID as 设备序列, DevLight_Histroy.Dev_Addr as 安装地址, DevLight_Histroy.Dev_Phase as 监测路线位置, DevLight_Histroy.Dev_Num as 动作次数, DevLight_Histroy.Dev_Time as 动作时间 FROM DevLight_Histroy where Dev_ID='" + CurrentNumber + "'";
        }

        private void QueryCurrentfrm_Load(object sender, EventArgs e)
        {
            tb_number.Text = this.CurrentNumber;
            this.Text = "正在加载当前设备数据";
            
        }

        private void QueryCurrentfrm_Shown(object sender, EventArgs e)
        {
            bool su=Queryreal();
            su= UpdataLightHistroy();
            su= UpdataMaHistroy();
            this.Text = "查询当前设备数据";
            if(su==false)
            {
                MessageBox.Show("当前设备至少有一项数据查询结果为空.");
            }

        }

        private bool Queryreal()
        {
            bool ok=false; 
            DataTable dt = query.ReturnTable(realstr);
            if (dt!=null && dt.Rows.Count > 0)
            {
               if(dt.Rows[0]["Dev_ID"].ToString()==this.CurrentNumber)
               {
                   tb_Cout.Text = dt.Rows[0]["Dev_Num"].ToString();
                   tb_mA.Text = dt.Rows[0]["Dev_mA"].ToString();
                   tb_calltime.Text = dt.Rows[0]["Dev_Loadtime"].ToString();
                   tb_total.Text = dt.Rows[0]["Dev_OldNum"].ToString();

               }
               ok = true;
            }
            //else
            //{
            //    MessageBox.Show("无该设备当前实时数据记录!");
            //}
            return ok;
        }

        private bool UpdataLightHistroy()
        {
            bool ok = false;
            DataTable dt = query.ReturnTable(lightstr);
            if (dt!=null && dt.Rows.Count > 0)
            {
                DataGridViewRecordLight.DataSource = dt;
                ok = true;
            }
            return ok;
        }

        private bool UpdataMaHistroy()
        {
            bool ok = false;
            try
            {
              //  mastr = "SELECT * FROM DevmA_Histroy WHERE (Dev_ID='"+this.CurrentNumber+"')";
                DataTable dt = query.ReturnTable(mastr);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ok = true;
                    DataGridView_Recordhistroy.DataSource = dt;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ok;
        }
    }
}
