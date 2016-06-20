using System;
using System.Collections.Generic;
using System.Text;

namespace wirelesssacler
{
    public class DeviceStruct
    {
        public DeviceStruct()
        {
            InitializeComponent();
        }

        public Information informsg;
        private void InitializeComponent()
        {
            informsg.dev_id = 0;
            informsg.addr = "";
            informsg.loadtime = "";
            informsg.Number = 0;
            informsg.phase = "";
            informsg.time = "";
            informsg.total_current = 0;
        }

        public struct Information
        {
         public long dev_id;
         public string addr;
         public string phase;
         public int total_current;//全电流
         public int Number;//动作次数
         public string time;//返回时间
         public string loadtime;//下载时间
        }
    }
}
