using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells;
using CCWin;
using MySqlCon;


namespace wirelesssacler
{
    public partial class InitAllDevfrm : Skin_DevExpress
    {
        public InitAllDevfrm()
        {
            InitializeComponent();
        }
        private SqlHelp sql = new SqlHelp();
        private LinkedList<string> mylist;

        private void InitAllDevfrm_Load(object sender, EventArgs e)
        {
            DataTable dt = sql.ReturnTable("select * from Dev_List");
            if (dt.Rows.Count == 0)
            {               
                MessageBox.Show("暂无设备，请导入设备清单！");
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {                  
                        try
                        {                           
                            string name = dt.Rows[i]["Dev_ID"].ToString();
                            string add = dt.Rows[i]["Dev_Addr"].ToString();
                            string ph = dt.Rows[i]["Dev_Phase"].ToString();
                            string names = "设备序列号[" + name + "] 杆塔地址[" + add + "] 监测相位[" + ph + "]";
                            
                            ListBox_dev.Items.Add(names);
                            ListBox_dev.SetItemChecked(i, true);
                        }
                        catch
                        {
                            continue;
                        }                  
                }
            }
        }

        private void check_all_CheckedChanged(object sender, EventArgs e)
        {
            if (check_all.Checked)
            {
                for (int j = 0; j < ListBox_dev.Items.Count; j++)
                { 
                    ListBox_dev.SetItemChecked(j, true);
                    
                }
            }
            else
            {
                for (int j = 0; j < ListBox_dev.Items.Count; j++)
                { ListBox_dev.SetItemChecked(j, false); }
            }
        }

        private void btn_initAll_Click(object sender, EventArgs e)
        {
            if (btn_initAll.Text != "初始化所选设备") return;
            mylist = new LinkedList<string>();
            for (int j = 0; j < ListBox_dev.Items.Count; j++)
            {
                if (ListBox_dev.GetItemChecked(j))
                {

                    string onum = ListBox_dev.Items[j].ToString();///);
                    int i = onum.IndexOf("[") + 1;
                    int k = onum.IndexOf("]");
                    string nnum = onum.Substring(i, k - i);
                    mylist.AddLast(nnum);

                }
            }
            if (mylist == null || mylist.Count == 0)
            {
                MessageBox.Show("请选择至少一个设备");
                return;
            }
            InitAllDevInfofrm f = new InitAllDevInfofrm(mylist);
            f.Show();

        }
    }
}
