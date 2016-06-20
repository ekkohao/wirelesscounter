using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CCWin;


namespace wirelesssacler
{
    public partial class AddDevfrm : Skin_DevExpress
    {
        public AddDevfrm()
        {
            InitializeComponent();
        }

        public string iD;
        public string aDDr;
        public string pHase;

        private void Add_Click(object sender, EventArgs e)
        {
            if(tb_add.Text=="" || tb_xulie.Text=="" || cbx_pahse.Text=="")
            {
                MessageBox.Show("请填入完整信息");
            }
            else
            {
               
                iD = tb_xulie.Text;
                aDDr = tb_add.Text;
                pHase = cbx_pahse.Text;
                ///检验函数
                ///
                if(IsNum(iD))
                {
                    if (iD.Length== 10)
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        MessageBox.Show("输入的序列号长度不够，请输入10位数字");
                    }
                }
                else
                {
                    tb_xulie.Text = "";
                    tb_add.Text="";
                    cbx_pahse.Text="";
                    MessageBox.Show("输入的序列号不是数字，请重新输入！");
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

        private void AddDevfrm_Shown(object sender, EventArgs e)
        {
            this.Add.Focus();
        }

        private void AddDevfrm_Load(object sender, EventArgs e)
        {

        }
    }
}
