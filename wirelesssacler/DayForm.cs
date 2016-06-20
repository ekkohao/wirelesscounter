using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wirelesssacler
{
    public partial class DayForm : Form
    {
        public DayForm()
        {
            InitializeComponent();
        }
        public delegate void SetDay(int day);

        public event SetDay SetDayCount; 
    
        private void btn_Day_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(daycout.Value)==0)
            {
                MessageBox.Show("天数必须大于0");
            }
            else
            {
                int count = Convert.ToInt32(daycout.Value);
                SetDayCount(count);
                this.Close();
            }
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
