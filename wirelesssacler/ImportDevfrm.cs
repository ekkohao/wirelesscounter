using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells;
using MySqlCon;
using CCWin;
namespace wirelesssacler
{
    public partial class ImportDevfrm : Skin_DevExpress
    {
        public ImportDevfrm()
        {
            InitializeComponent();
            OnMyValueChanged += new MyValueChanged(afterMyValueChanged);
            //this.splitContainer1.Panel2Collapsed = true;
        }
    
        private string myValue="";
          //定义一个委托
        public delegate void MyValueChanged(object sender, EventArgs e);
        //与委托相关联的事件
        public event MyValueChanged OnMyValueChanged;

        //将afterMyValueChanged的委托绑定到事件上
        public CommunicationProtocol.SequenceWithStrToByte Convertstr = new CommunicationProtocol.SequenceWithStrToByte();
        
       //通知父窗体刷新设备列表

        public delegate void RefashList();
        public event RefashList refresh;
    public string MyValue
    {
        get { return myValue; }
        set 
        {
            //如果赋的值与原值不同
            if (value!=myValue)
            {

            //就触发该事件!
                WhenMyValueChange();
            }

            //然后赋值!
            myValue = value; 
        }
    }

 

    //触发事件

    private void WhenMyValueChange()
    {
          if (OnMyValueChanged != null)

        {

            OnMyValueChanged(this, null);

        }

    }
    //变量改变后触发
    private void afterMyValueChanged(object sender,EventArgs e)
    {

        //do something
        importmsg.Text += MyValue + "\r\n";
        importmsg.Focus();
        importmsg.Select(importmsg.TextLength, 0);
        importmsg.ScrollToCaret();
        

    }

        private void btn_import_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                   
                    
                    string ext= System.IO.Path.GetExtension(openFileDialog.FileName);// fi.Name;
                   if(ext==".xls"||ext==".xlsx")
                   {
                         Path_text.Text = System.IO.Path.GetFullPath(openFileDialog.FileName);
                         
                   }
                    else
                   {
                       MessageBox.Show("文件格式不对，请选择.xls或.xlsx格式的excle文件.");
                   }
                  // Directory
                }
            }

                                      

              

        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
             if (File.Exists(Path_text.Text))
             {
                 //存在
                // this.splitContainer1.Panel2Collapsed = false;
                // this.splitContainer1.Panel1Collapsed = true;

                 //读取excle函数,添加到数据库
                 //加入到数据库
               
                  DataTable temp= ReadExcle(Path_text.Text);
                  timer1.Enabled = true;
                  TableToshujuku(temp);
                  refresh();
             }
        }
        private  DataTable  ReadExcle(string filename)
        {
            
            myValue = "开始解析文件";
            DataTable dt = new DataTable();

            Workbook workbook = new Workbook(filename);
           // workbook.Open(filename);
            Worksheet wkSheet = null;
         //   Cells cells = workbook.Worksheets[0].Cells; 
             wkSheet = workbook.Worksheets[0];
                //声明DataTable存放sheet
                //设置Table名为sheet的名称
             dt.TableName = wkSheet.Name;

                //遍历行
             for (int x = 0; x < wkSheet.Cells.MaxDataRow + 1; x++)
             {
                 //声明DataRow存放sheet的数据行
                 DataRow dRow = null;
                
                 //遍历列
                 for (int y = 0; y < wkSheet.Cells.MaxDataColumn + 1; y++)
                 {
                     //获取单元格的值

                     string value = wkSheet.Cells[x, y].StringValue.Trim();
                    
                     //如果是第一行，则当作表头
                     if (x == 0)
                     {
                         
                         //设置表头
                         DataColumn dCol = new DataColumn(value);
                         dt.Columns.Add(dCol);
                        
                         MyValue= value;
                     }
                     //非第一行，则为数据行
                     else
                     {
                         //每次循环到第一列时，实例DataRow
                       
                         if (y == 0)
                         {
                             dRow = dt.NewRow();
                         }
                         else if(y==1)
                         {
                             string noty = "";
                             //在这里监测序列是否正确
                             byte[] add = Convertstr.SeqStrToByte(value, ref noty);
                             if (add == null || add.Length != 4)
                             {
                                 myValue = "设备序列-"+value+"-不可用:" + noty;
                                 dRow = null;
                                 break;
                             }
                         }
                         //给第Y列赋值
                         dRow[y] = value;
                         MyValue = value;
                     }
                 }

                 if (dRow != null)
                 {
                     dt.Rows.Add(dRow);
                 }

             }
             wkSheet = null;
             workbook = null;
            return dt;
        }

        private void  TableToshujuku(DataTable dt)
        {
            SqlHelp mysql = new SqlHelp();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string chechk = "select [Dev_ID] from `Dev_List` where [Dev_ID] = '" + dt.Rows[i][1].ToString()+"'";
                    string insertstr = "insert into `Dev_List` (Dev_ID,Dev_Addr,Dev_Phase) values('" + dt.Rows[i][1].ToString() + "','" + dt.Rows[i][2].ToString() + "','" + dt.Rows[i][3].ToString() + "')";
                    DataTable te = mysql.ReturnTable(chechk);
                    if (te.Rows.Count == 0)
                    {
                        mysql.Insert(insertstr);
                    }
                    else
                    {
                        MyValue = "设备序列号位："+dt.Rows[i][1].ToString() + "已存在";
                    }

                }
            }
            MyValue = "导入完毕";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(MyValue=="导入完毕")
            {
                timer1.Stop();
                ImportProgressBar.Value=100;
                //System.Threading.Thread.Sleep(3000);
                Delaytime.Delay(1000);
                if(MessageBox.Show("是否退出？","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                if(ImportProgressBar.Value<=100)
                {
                    ImportProgressBar.Value++;
                }
            }


            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
