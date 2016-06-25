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
    public partial class ExportExclefrm : Skin_DevExpress
    {
        public ExportExclefrm()
        {
            InitializeComponent();
        }
        public ExportExclefrm(string ver)
        {
            InitializeComponent();
            if(ver=="1.0.0.0")
            {
                checkBox_hist.Enabled = false;
            }
        }
        private SqlHelp sql = new SqlHelp();
        private LinkedList<string> mylist;
        private void ExportExclefrm_Load(object sender, EventArgs e)
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

        private void btn_Excle_Click(object sender, EventArgs e)
        {
            if (btn_Excle.Text != "导出Excle") return;
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
            if(mylist==null || mylist.Count==0)
            {
                MessageBox.Show("请选择至少一个设备");
                return;
            }
            if(checkBox_hist.Checked==false && CheckBox_light.Checked==false && CheckBox_real.Checked==false)
            {
                MessageBox.Show("请选择你要导出的数据类别,至少一种！");
                return;
            }
            btn_Excle.Text = "请稍后..";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path2 = "导出数据文件夹";
            path = Path.Combine(path, path2);
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            } 
            ExportData(mylist, CheckBox_real.Checked, CheckBox_light.Checked, checkBox_hist.Checked,path);
            btn_Excle.Text = "导出完毕";
            Delaytime.Delay(1000);
            btn_Excle.Text = "导出Excle";
           // if(MessageBox.Show("是否打开导出数据文件夹？","导出提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }

        private void ExportData(LinkedList<string> list, bool real, bool light, bool his,string path)
        {
            bool reok=false, reli=false, rehis=false;
            if (real)
            {
               reok= Export_real(list,path);
            }
            if (light)
            {
                reli=Export_light(list,path);
            }
            if (his)
            {
               rehis= Export_histroy(list,path);
            }
            if(real)
            {
                if(reok==false)
                {
                    MessageBox.Show("实时数据导出失败，暂无查询的实时数据数据");
                }
            }
            if (light)
            {
                if (reli == false)
                {
                    MessageBox.Show("动作记录导出失败，暂无动作记录数据");
                }
            }
            if (his)
            {
                if (rehis == false)
                {
                    MessageBox.Show("历史数据导出失败，暂无历史数据");
                }
            }
        }

        private bool Export_real(LinkedList<string> plist,string path)
        {
            bool ok = false;
            SqlHelp outsql = new SqlHelp();
            DataTable ot = outsql.ReturnTable("select * from `Dev_Real`");
            string filename = "设备实时数据-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xls";
            string filepath = Path.Combine(path, filename);
            if (File.Exists(filepath))
                System.IO.File.Delete(filepath); // 判断文件名是否已存在
            if (ot != null && ot.Rows.Count>0)
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
                    cellSheet.Cells[0, 1].PutValue("设备序列号");
                    cellSheet.Cells[0, 2].PutValue("设备安装地址");
                    cellSheet.Cells[0, 3].PutValue("监测相位(A/B/C)");
                    cellSheet.Cells[0, 4].PutValue("本次查询动作次数");
                    cellSheet.Cells[0, 5].PutValue("上次查询动作次数");
                    cellSheet.Cells[0, 6].PutValue("全电流(uA)");
                   // cellSheet.Cells[0, 7].PutValue("设备时间");
                    cellSheet.Cells[0, 7].PutValue("数据下载时间");


                }
                #endregion

                #region 填入数据
                {
                  //  LinkedListNode<string> _p = plist.First;
                    int rowIndex = 1;
                    for (int i = 0; i < ot.Rows.Count; i++)
                    {
                        LinkedListNode<string> _p = plist.First;
                        while(_p!=null)
                        {

                            if(_p.Value==ot.Rows[i][1].ToString())
                            {
                                cellSheet.Cells[rowIndex, 0].PutValue(ot.Rows[i][0]);
                                cellSheet.Cells[rowIndex, 1].PutValue(ot.Rows[i][1]);
                                cellSheet.Cells[rowIndex, 2].PutValue(ot.Rows[i][2]);
                                cellSheet.Cells[rowIndex, 3].PutValue(ot.Rows[i][3]);
                                cellSheet.Cells[rowIndex, 4].PutValue(ot.Rows[i][4]);
                                cellSheet.Cells[rowIndex, 5].PutValue(ot.Rows[i][5]);
                                cellSheet.Cells[rowIndex, 6].PutValue(ot.Rows[i][6]);
                                cellSheet.Cells[rowIndex, 7].PutValue(ot.Rows[i][8]);
                              //  cellSheet.Cells[rowIndex, 8].PutValue(ot.Rows[i][8]);
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
                ok = true;

            }
            return ok;
        }
        private bool Export_light(LinkedList<string> plist,string path)
        {
            bool ok = false;
            SqlHelp outsql = new SqlHelp();
            DataTable ot = outsql.ReturnTable("select * from `DevLight_Histroy`");
            string filename = "设备动作数据-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xls";
         
            string filepath = Path.Combine(path, filename);
            if (File.Exists(filepath))
                System.IO.File.Delete(filepath); // 判断文件名是否已存在
            if (ot != null && ot.Rows.Count > 0)
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
                    cellSheet.Cells[0, 0].PutValue("ID");
                    cellSheet.Cells[0, 1].PutValue("设备序列号");
                    cellSheet.Cells[0, 2].PutValue("设备安装地址");
                    cellSheet.Cells[0, 3].PutValue("监测相位(A/B/C)");
                    cellSheet.Cells[0, 4].PutValue("动作次数");
                    cellSheet.Cells[0, 5].PutValue("动作时间");

                }
                #endregion

                #region 填入数据
                {
                   // LinkedListNode<string> _p = plist.First;
                    int rowIndex = 1;
                    for (int i = 0; i < ot.Rows.Count; i++)
                    {
                        LinkedListNode<string> _p = plist.First;
                        while (_p!=null)
                        {
                            if (_p.Value == ot.Rows[i][1].ToString())
                            {
                                cellSheet.Cells[rowIndex, 0].PutValue(ot.Rows[i][0]);
                                cellSheet.Cells[rowIndex, 1].PutValue(ot.Rows[i][1]);
                                cellSheet.Cells[rowIndex, 2].PutValue(ot.Rows[i][2]);
                                cellSheet.Cells[rowIndex, 3].PutValue(ot.Rows[i][3]);
                                cellSheet.Cells[rowIndex, 4].PutValue(ot.Rows[i][4]);
                                cellSheet.Cells[rowIndex, 5].PutValue(ot.Rows[i][5]);

                                break;
                                rowIndex++;
                            }
                            _p = _p.Next;
                        }
 
                    }
                }

                #endregion

                cellSheet.AutoFitColumns();
                workbook.Save(Path.GetFullPath(filepath));
                ok = true;

            }
            return ok;
        }
        private bool Export_histroy(LinkedList<string> plist,string path)
        {
            bool ok = false;
            SqlHelp outsql = new SqlHelp();
            DataTable ot = outsql.ReturnTable("select * from `DevmA_Histroy`");
            string filename = "历史记录数据-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xls";
            string filepath = Path.Combine(path, filename);
            if (File.Exists(filepath))
                System.IO.File.Delete(filepath); // 判断文件名是否已存在
            if (ot != null && ot.Rows.Count > 0)
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
                    cellSheet.Cells[0, 0].PutValue("ID");
                    cellSheet.Cells[0, 1].PutValue("设备序列号");
                    cellSheet.Cells[0, 2].PutValue("设备安装地址");
                    cellSheet.Cells[0, 3].PutValue("监测相位(A/B/C)");
                    //cellSheet.Cells[0, 4].PutValue("当前记录条数");
                    cellSheet.Cells[0, 4].PutValue("全电流(uA)");
                    cellSheet.Cells[0, 5].PutValue("存储时间");
                    cellSheet.Cells[0, 6].PutValue("历史记录总条数");
                    cellSheet.Cells[0, 7].PutValue("下载时间");

                }
                #endregion

                #region 填入数据
                {
                   // LinkedListNode<string> _p = plist.First;
                    int rowIndex = 1;
                    for (int i = 0; i < ot.Rows.Count; i++)
                    {
                        LinkedListNode<string> _p = plist.First;
                        while (_p!=null)
                        {
                            if (_p.Value == ot.Rows[i][1].ToString())
                            {
                                cellSheet.Cells[rowIndex, 0].PutValue(ot.Rows[i][0]);
                                cellSheet.Cells[rowIndex, 1].PutValue(ot.Rows[i][1]);
                                cellSheet.Cells[rowIndex, 2].PutValue(ot.Rows[i][2]);
                                cellSheet.Cells[rowIndex, 3].PutValue(ot.Rows[i][3]);
                                //cellSheet.Cells[rowIndex, 4].PutValue(ot.Rows[i][4]);
                                cellSheet.Cells[rowIndex, 4].PutValue(ot.Rows[i][5]);
                                cellSheet.Cells[rowIndex, 5].PutValue(ot.Rows[i][6]);
                                cellSheet.Cells[rowIndex, 6].PutValue(ot.Rows[i][7]);
                                cellSheet.Cells[rowIndex, 7].PutValue(ot.Rows[i][8]);
                                break;
                                rowIndex++;
                            }
                            _p = _p.Next;
                        }

                    }
                }

                #endregion

                cellSheet.AutoFitColumns();
                workbook.Save(Path.GetFullPath(filepath));
                ok = true;

            }
            return ok;
        }

        private void btn_openfile_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path2 = "导出数据文件夹";
            path = Path.Combine(path, path2);
            System.Diagnostics.Process.Start("explorer.exe", path);
        }


    }
}
