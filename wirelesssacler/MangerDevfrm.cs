using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySqlCon;

using CCWin;
using Aspose.Cells;
using System.IO;
using System.Text.RegularExpressions;

namespace wirelesssacler
{
    public partial class MangerDevfrm : Skin_DevExpress
    {
        public MangerDevfrm()
        {
            InitializeComponent();
        }

        private string id;
        private string addr;
        private string phase;
        private string oldid;
        string deleteid;
        private void MangerDevfrm_Load(object sender, EventArgs e)
        {

            DG_List.Columns.Add("devid", "设备序列");
            DG_List.Columns.Add("devaddr", "设备安装地址");
            DG_List.Columns.Add("devphase", "监测路线位置");
            DG_List.AllowUserToAddRows = false;
            //加载设备
            
        }

        public delegate void RefreshListNow();
        public event RefreshListNow RefreshNow;
        private bool  ListLoad()
        {
            bool Isload = false;
            SqlHelp load = new SqlHelp();
            string str = "select * from Dev_List";
            DataTable dt= load.ReturnTable(str);
            DG_List.Rows.Clear();
            if(dt.Rows.Count>0)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                 
                   object [] f=new object[3];
                   f[0] = dt.Rows[i][1];
                   f[1] = dt.Rows[i][2];
                   f[2] = dt.Rows[i][3];
                   DG_List.Rows.Add(f);


                }
                Isload = true;
            }

            return Isload;

        }

        private void DG_List_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(DG_List.Rows.Count>0)
            {
                if (DG_List.Rows[e.RowIndex].Cells[0].Value == null || DG_List.Rows[e.RowIndex].Cells[1].Value == null || DG_List.Rows[e.RowIndex].Cells[2].Value == null)
                {
                   // MessageBox.Show("请填写完整记录");
                    return;
                }
                //if (DG_List.Rows[e.RowIndex].Cells[1].Value == null)
                //{
                //    MessageBox.Show("请填写完整记录");
                //    return;
                //}
                //if (DG_List.Rows[e.RowIndex].Cells[2].Value == null)
                //{
                //    MessageBox.Show("请填写完整记录");
                //    return;
                //}
                string inid = DG_List.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (IsNum(inid) == false || inid.Length != 10)
                {
                    DG_List.Rows[e.RowIndex].Cells[0].Value = null;
                    MessageBox.Show("请输入10位序列号数字");
                    return;
                }
                id = DG_List.Rows[e.RowIndex].Cells[0].Value.ToString();
                addr = DG_List.Rows[e.RowIndex].Cells[1].Value.ToString();
                phase = DG_List.Rows[e.RowIndex].Cells[2].Value.ToString();

                SqlHelp sql = new SqlHelp();
                string str = "update Dev_List set Dev_ID= '"+id+"',Dev_Addr='"+addr+"',Dev_Phase='"+phase+"' where Dev_ID='"+oldid + "'";
                string up = "update Dev_Real set Dev_ID= '" + id + "',Dev_Addr='" + addr + "',Dev_Phase='" + phase + "' where Dev_ID='" + oldid + "'";
                sql.Insert(up);
               if( sql.Insert2(str)>0)
               {
                   RefreshNow();
               }
                else
               {
                   str = "insert into Dev_List (Dev_ID,Dev_Addr,Dev_Phase) Values('" + id + "','" + addr + "','" + phase + "')";
                   if(sql.Insert2(str)>0)
                   {
                       RefreshNow();
                   }
                   else
                   {
                       MessageBox.Show("添加设备失败");
                   }
               }
               
            }
        }
        public bool IsNum(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
             !objTwoDotPattern.IsMatch(strNumber) &&
             !objTwoMinusPattern.IsMatch(strNumber) &&
             objNumberPattern.IsMatch(strNumber);
        }
        private void DG_List_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (DG_List.Rows.Count > 0)
            {
                if (DG_List.Rows[e.RowIndex].Cells[0].Value == null) return;
                oldid = DG_List.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void deletedev_Click(object sender, EventArgs e)
        {
            if(btn_d_zd.Checked==true)
            {
                MessageBox.Show("请切换到编辑模式");
                return;
            }
           

             if (MessageBox.Show("是否删除该设备？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
             {
                 List<string> select = new List<string>();

                 foreach (DataGridViewRow gdvr in DG_List.SelectedRows)
                 {
                     select.Add(gdvr.Cells[0].Value.ToString());
                 }
                 for (int i = 0; i < select.Count; i++)
                 {
                     SqlHelp sql = new SqlHelp();
                     string str = "delete from Dev_List where Dev_ID ='" + select[i] + "'";
                     sql.Insert(str);
                 }
                 RefreshNow();
                 if (ListLoad() == false)
                 {
                     //MessageBox.Show("刷新失败");
                     Console.Write("设备读取失败");
                 }
             }
        }

        private void AddDev_Click(object sender, EventArgs e)
        {
            if (btn_d_zd.Checked == true)
            {
                MessageBox.Show("请切换到编辑模式");
                return;
            }
            AddDevfrm addfrm = new AddDevfrm();
            if(addfrm.ShowDialog()==DialogResult.Yes)
            {
                string d1, d2, d3;
                d1 = addfrm.iD;
                d2 = addfrm.aDDr;
                d3 = addfrm.pHase;
                SqlHelp sql = new SqlHelp();
                string str = "insert into Dev_List (Dev_ID,Dev_Addr,Dev_Phase) Values('"+d1+"','"+d2+"','"+d3+"')"; 
                sql.Insert(str);
                RefreshNow();
               
                ListLoad();
            }
        }

        private void DG_List_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DG_List.Rows[e.RowIndex].Cells[0].Value == null) return;
                deleteid = DG_List.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
           // MessageBox.Show(DG_List.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void MangerDevfrm_Shown(object sender, EventArgs e)
        {
            if (ListLoad() == false)
            {
                MessageBox.Show("加载设备失败，无设备数据");
            }
        }

        private void btn_falsh_Click(object sender, EventArgs e)
        {
            if (ListLoad() == false)
            {
                MessageBox.Show("刷新失败，无设备数据!");
            }
        }
        private void btn_d_zd_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_d_zd.Checked)
            {
                btn_d_bj.Checked = false;
                DG_List.ReadOnly = true;
                DG_List.RowHeadersVisible = false;
                DG_List.AllowUserToAddRows = false;
            }
            else
            {
                DG_List.ReadOnly = false;
                DG_List.RowHeadersVisible = true;
                DG_List.AllowUserToAddRows = true;
            }
        }

        private void btn_d_bj_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_d_bj.Checked)
            {
                btn_d_zd.Checked = false;
            }
        }

        private int nrow = 0;
        private void DG_List_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            nrow = row;
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            SqlHelp outsql = new SqlHelp();
            DataTable ot = outsql.ReturnTable("select * from `Dev_List`");
            string filename ="导出设备清单-"+ DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xls";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path2 = "设备清单";
            path = Path.Combine(path, path2);
            string filepath = Path.Combine(path, filename);
            if (File.Exists(filepath))
                System.IO.File.Delete(filepath); // 判断文件名是否已存在

            if (ot != null)
            {

                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet cellSheet = workbook.Worksheets[0];
                //为单元格添加样式      
                Aspose.Cells.Style style = workbook.Styles[workbook.Styles.Add()];
                //设置居中  
                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
                //设置背景颜色  
                style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                style.Pattern = BackgroundType.Solid;
                style.Font.IsBold = true;
                //列名的处理  
                #region  列名的处理
                {
                    //cellSheet.Cells[rowIndex, colIndex].PutValue(dt.Columns[i].ColumnName);
                    //cellSheet.Cells[rowIndex, colIndex].Style.Font.IsBold = true;
                    //cellSheet.Cells[rowIndex, colIndex].Style.Font.Name = "宋体";
                    //cellSheet.Cells[rowIndex, colIndex].Style = style; 
                    cellSheet.Cells[0, 0].PutValue("ID");
                    cellSheet.Cells[0, 1].PutValue("设备ID");
                    cellSheet.Cells[0, 2].PutValue("设备地址");
                    cellSheet.Cells[0, 3].PutValue("监测路线位置");


                }
                #endregion

                #region 填入数据
                {

                    int rowIndex = 1;
                    for (int i = 0; i < ot.Rows.Count; i++)
                    {
                        cellSheet.Cells[rowIndex, 0].PutValue(ot.Rows[i][0]);
                        cellSheet.Cells[rowIndex, 1].PutValue(ot.Rows[i][1]);
                        cellSheet.Cells[rowIndex, 2].PutValue(ot.Rows[i][2]);
                        cellSheet.Cells[rowIndex, 3].PutValue(ot.Rows[i][3]);

                        rowIndex++;
                    }
                }

                #endregion

                cellSheet.AutoFitColumns();

                workbook.Save(Path.GetFullPath(filepath));




            }

            MessageBox.Show("已导出设备清单:"+filepath);

        }

        }
}
