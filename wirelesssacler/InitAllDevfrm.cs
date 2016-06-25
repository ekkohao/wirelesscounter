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
        private UsewireCom WireCom;
        private string findSql;
        private string findGroup;
        public InitAllDevfrm(UsewireCom WireCom)
        {
            InitializeComponent();
            this.WireCom = WireCom;
            findGroup="";
        }
        public InitAllDevfrm(UsewireCom WireCom,string iGroup)
        {
            InitializeComponent();
            this.WireCom = WireCom;
            findGroup=iGroup;
        }
        private SqlHelp sql = new SqlHelp();
        private LinkedList<string> mylist;

        private void InitAllDevfrm_Load(object sender, EventArgs e)
        {
            findSql="select * from Dev_List";
            if (findGroup != "")
            {
                findSql = findSql + " where Dev_Addr = '"+findGroup+"'";
            }
            DataTable dt = sql.ReturnTable(findSql);
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
            date_Time_Picker.Value = DateTime.Now;
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
            InitAllDevInfofrm f = new InitAllDevInfofrm(mylist,WireCom);
            if (f.ShowDialog() == DialogResult.Yes)
                f.flag = false;
            f.Dispose();

        }

        private void box_set_time_CheckedChanged(object sender, EventArgs e)
        {
                date_Time_Picker.Enabled = box_set_time.Checked;
        }

        private void init_all_time_Click(object sender, EventArgs e)
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
            InitAllDevTimefrm f = new InitAllDevTimefrm(mylist, WireCom, date_Time_Picker.Value, box_set_time.Checked);
            if (f.ShowDialog() == DialogResult.Yes)
                f.flag = false;
            f.Dispose();
        }

    }
}
