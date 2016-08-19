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
    public partial class ExportDevExclefrm : Skin_DevExpress
    {
        public ExportDevExclefrm()
        {
            InitializeComponent();
        }
        private SqlHelp sql = new SqlHelp();
        private LinkedList<string> mylist;
        private TreeNode[] node;
        private void ExportDevExclefrm_Load(object sender, EventArgs e)
        {

            DataTable dtaddr = sql.ReturnTable("select DISTINCT Dev_Addr from Dev_List");
            if (dtaddr.Rows.Count == 0)
            {               
                MessageBox.Show("暂无设备，请导入设备清单！");
            }
            else
            {
                for (int i = 0; i < dtaddr.Rows.Count; i++)
                {
                    add_dev_tree(dtaddr.Rows[i]["Dev_Addr"].ToString());
                }
                DevTreeView.ExpandAll();
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{                  
                //        try
                //        {                           
                //            string name = dt.Rows[i]["Dev_ID"].ToString();
                //            string add = dt.Rows[i]["Dev_Addr"].ToString();
                //            string ph = dt.Rows[i]["Dev_Phase"].ToString();
                //            string names = "设备序列号[" + name + "] 杆塔地址[" + add + "] 监测相位[" + ph + "]";
                //            ListBox_dev.Items.Add(names);
                //        }
                //        catch
                //        {
                //            continue;
                //        }                  
                //}
            }
        }

        private void add_dev_tree(string addr) {
            DataTable dt = sql.ReturnTable("select * from Dev_List where Dev_Addr = '" + addr + "' ORDER BY Dev_ID");
            TreeNode node = DevTreeView.Nodes.Add("组号："+addr);
            for (int i = 0; i < dt.Rows.Count; i++) {
                node.Nodes.Add("设备序列号：[" + dt.Rows[i]["Dev_ID"].ToString() + "] 监测相位：[" + dt.Rows[i]["Dev_Phase"].ToString()+"]");
                
            }
        }
         
        private void check_all_CheckedChanged(object sender, EventArgs e)
        {

            if (check_all.Checked)
            {
                foreach (TreeNode t in DevTreeView.Nodes)
                {
                    t.Checked = true;
                    foreach (TreeNode node in t.Nodes)
                    {
                        node.Checked = true;
                    }
                }
            }
            else
            {
                foreach (TreeNode t in DevTreeView.Nodes)
                {
                    t.Checked = false;
                    foreach (TreeNode node in t.Nodes)
                    {
                        node.Checked = false;
                    }
                }
            }
        }

        private void btn_Excle_Click(object sender, EventArgs e)
        {
            if (btn_Excle.Text != "导出Excle") return;
            mylist = new LinkedList<string>();
            foreach (TreeNode t in DevTreeView.Nodes) 
            {
                foreach (TreeNode node in t.Nodes)
                {
                    if (node.Checked)
                    {
                        string onum = node.Text;
                        int i = onum.IndexOf("[") + 1;
                        int k = onum.IndexOf("]");
                        string nnum = onum.Substring(i, k - i);
                        mylist.AddLast(nnum);
                    }
                }
            }

            if (mylist == null || mylist.Count == 0)
            {
                MessageBox.Show("请选择至少一个设备");
                return;
            }
            btn_Excle.Text = "请稍后..";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path2 = "设备清单";
            path = Path.Combine(path, path2);
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            ExportData(mylist, path);
            btn_Excle.Text = "导出完毕";
            Delaytime.Delay(1000);
            btn_Excle.Text = "导出Excle";
            // if(MessageBox.Show("是否打开导出数据文件夹？","导出提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }

        private void ExportData(LinkedList<string> plist, string path)
        {
            SqlHelp outsql = new SqlHelp();
            DataTable ot = outsql.ReturnTable("select * from `Dev_List`");
            string filename = "导出设备清单-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xls";
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
                        LinkedListNode<string> _p = plist.First;
                        while (_p != null)
                        {

                            if (_p.Value == ot.Rows[i][1].ToString())
                            {
                                cellSheet.Cells[rowIndex, 0].PutValue(ot.Rows[i][0]);
                                cellSheet.Cells[rowIndex, 1].PutValue(ot.Rows[i][1]);
                                cellSheet.Cells[rowIndex, 2].PutValue(ot.Rows[i][2]);
                                cellSheet.Cells[rowIndex, 3].PutValue(ot.Rows[i][3]);
                                rowIndex++;
                                break;
                            }
                            _p = _p.Next;
                        }         
                    }
                }

                #endregion
                cellSheet.AutoFitColumns();
                workbook.Save(Path.GetFullPath(filepath));
            }
        } 

        private void btn_openfile_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path2 = "设备清单";
            path = Path.Combine(path, path2);
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void DevTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

    }
}
