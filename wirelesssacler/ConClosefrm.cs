using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace wirelesssacler
{
    public partial class ConClosefrm : Skin_DevExpress
    {
        public ConClosefrm(string com,string btl,string data,string stop)
        {
            InitializeComponent();
            skinTextBox1.Text = com;
            skinTextBox2.Text = btl;
            skinTextBox3.Text = data;
            skinTextBox4.Text = stop;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
