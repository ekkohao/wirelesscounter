using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using CCWin;

using Manger.sys.port;
namespace wirelesssacler
{
    public partial class Connectfrm : Skin_DevExpress
    {
        public Connectfrm()
        {
            InitializeComponent();
           
        }

        public string UsePort = null;
        /// <summary>
        /// 获取计算机USB端口
        /// </summary>
        /// <returns></returns>
        private LinkedList<string> GetComPorts()
        {
            SysManges sys = new SysManges();
            string[] ports = sys.GetHardware(SysManges.HardwareEnum.Win32_PnPEntity);
            LinkedList<string> pcPort = new LinkedList<string>();
            ports = SerialPort.GetPortNames();
            SerialPort TestPort = new SerialPort();
            for (int i = 0; i < ports.Length; i++)
            {
              //  if (ports[i].Contains("Port") || ports[i].Contains("USB-SERIAL"))
               // {

                    string str = ports[i];
                //    str = str.Substring(str.IndexOf('('), str.Length - str.IndexOf('('));
                 //   str = str.Substring(1, str.Length - 2);
                    TestPort.PortName = str;
                    if (str == "COM1")
                        continue;
                    try
                    {
                        TestPort.Open();
                        TestPort.Close();
                        pcPort.AddLast(str);
                    }
                    catch
                    {
                        //TestPort.PortName = null;
                        continue;
                    }
                 
             //   }

            }
            return pcPort;
        }

        private void Connectfrm_Load(object sender, EventArgs e)
        {
          
       
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            LinkedList<string> Getport = GetComPorts();
            ComSelectfrm Select = new ComSelectfrm();
            Select.AddPorts = Getport;
            if(Select.ShowDialog()==DialogResult.OK)
            {
                UsePort = Select.Connport;
                Select.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                UsePort = null;
            }
        }

        private void btn_refalsh_Click(object sender, EventArgs e)
        {
            LinkedList<string> port = GetComPorts();

            if (port.Count == 0)
            {
                this.spc_Contalpanel.Panel1Collapsed = false;
                this.spc_Contalpanel.Panel2Collapsed = true;
                MessageBox.Show("无可用端口号，请检查设备是否插入!");
            }
            else if (port.Count == 1)
            {
                //有1个串口
                ///默认选择
                
                UsePort = port.First.Value;
              //  UsePort = "COM4";
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.spc_Contalpanel.Panel1Collapsed = true;
                this.spc_Contalpanel.Panel2Collapsed = false;
               
                //提示用户选择串口
                ComSelectfrm Select = new ComSelectfrm();
                Select.AddPorts = port;
                if (Select.ShowDialog() == DialogResult.OK)
                {
                    UsePort = Select.Connport;
                    Select.Close();
                    this.DialogResult = DialogResult.OK;
                }

            }
        }

        private void Connectfrm_Shown(object sender, EventArgs e)
        {
            LinkedList<string> port = GetComPorts();
          
            if (port.Count == 0)
            {
                this.spc_Contalpanel.Panel1Collapsed = false;
                this.spc_Contalpanel.Panel2Collapsed = true;
                btn_refalsh.Visible = true;
                label_noty.Text="请插入数据采集设备接收端并点击刷新按钮。";
            }
            else if (port.Count == 1)
            {
                //有1个串口
                ///默认选择
                UsePort = port.First.Value;
              //  UsePort = "COM4";//测试用
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.spc_Contalpanel.Panel1Collapsed = true;
                this.spc_Contalpanel.Panel2Collapsed = false;
                //提示用户选择串口
                ComSelectfrm Select = new ComSelectfrm();
                Select.AddPorts = port;
                if (Select.ShowDialog() == DialogResult.OK)
                {
                    UsePort = Select.Connport;
                    Select.Close();
                    this.DialogResult = DialogResult.OK;
                }

            }
        }
    }
    
}
