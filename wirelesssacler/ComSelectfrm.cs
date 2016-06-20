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
    public partial class ComSelectfrm : Skin_DevExpress
    {
        public ComSelectfrm()
        {
            InitializeComponent();
        }
        private static LinkedList<string> portlist = null;

        public string Connport = null;

        public LinkedList<string> AddPorts
        {
            get
            {
                return portlist;
            }
            set
            {
                portlist= value;
            }
        }
        private void ComSelectfrm_Load(object sender, EventArgs e)
        {
            if(portlist==null)
            {
                return;
            }
            else
            {
                LinkedListNode<string> portname =   portlist.First;           
                while(portname!=null)
                {
                    CCWin.SkinControl.SkinListBoxItem lv = new CCWin.SkinControl.SkinListBoxItem();
                    lv.Text = portname.Value;
                    skinListBox.Items.Add(lv);
                    portname = portname.Next;
                } 
            }
           
        }

        private void skinListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CCWin.SkinControl.SkinListBox lv =( CCWin.SkinControl.SkinListBox) sender;
            if(lv.SelectedItem==null)
            {
             
                 return;
            }
            Connport=lv.SelectedItem.ToString();

            this.DialogResult = DialogResult.OK;
           
        }

       
    }
}
