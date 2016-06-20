using System;
using System.Collections.Generic;
using System.Text;


namespace wirelesssacler
{

    /// <summary>
    /// 数据结构
    /// </summary>
        /// <summary>
        /// 设备结构
        /// </summary>
        public struct Device
        {
            public string number;//号码
            public string addr;//地址
            public string phase;//检测相位
            public byte [] sqeuence;//序列
           
        }
   
        /// <summary>
        /// 设备实时数据记录结构
        /// </summary>
        public class Dev_Real
        {
            public Device dev;
            public int Count;
            public int mA;
            /// <summary>
            /// 数据返回的时间
            /// </summary>
            public string backtime;
            /// <summary>
            /// 设备时间
            /// </summary>
            public string Sendtime;
            public Dev_Real()
            {
                Count = 0;
                mA = 0;
                backtime = null;
                Sendtime = null;
               // dev = new Device();
            }

        }
        public class DevBackTime
        {
            public Device dev;
            public DateTime btime;
            public DateTime curtime;
           
        }
        /// <summary>
        /// 设备动作记录结构
        /// </summary>
        public class Dev_RecordAction
        {
            public Device dev;
            public int num;
            public string time;
            public Dev_RecordAction()
            {
                dev = new Device();
                num = 0;
                time = null;
            }
        }
         /// <summary>
         /// 设备2小时历史记录结构
         /// </summary>
        public class Dev_RecordHistroy
        {
            public Device dev;
            /// <summary>
            /// 当前的记录次数
            /// </summary>
            public int Count;
            public int mA;
            /// <summary>
            /// 总次数
            /// </summary>
            public int totol;
            /// <summary>
            /// 循环数
            /// </summary>
            public int cicle;
            /// <summary>
            /// 记录的时间
            /// </summary>
            public string recordt;
            /// <summary>
            /// 招测时间
            /// </summary>
            public string callt;
            public Dev_RecordHistroy()
            {
                dev = new Device();
                Count = 0;
                mA = 0;
                recordt = null;
            }
        }

      //返回的数据存储结构
      public struct BTime
      {
          public string number;
          public DateTime B_time;
          public long id;
      }
     public struct BReal
     {
         public string number;
         public int count;
         public int mA;
         public long id;
     }
     public struct BAction
     {
         public string number;
         public int count;
         /// <summary>
         /// 时间
         /// </summary>
         public string actime;
         public long id;
     }
    public struct BWrite
    {
        public long id;
        public string number;
        /// <summary>
        /// 功能码
        /// </summary>
        public int code;
        /// <summary>
        /// 值
        /// </summary>
        public int value;
    }
    public struct BOnline
    {
        public string number;
        public bool Isonline;
        public long id;
    }

    public struct BInit
    {
        public string number;
        public bool isinit;
        public long id;
    }
    public struct BHiscot
    {
        public string number;
        /// <summary>
        /// 循环次数
        /// </summary>
        public int cicile;
        /// <summary>
        /// 返回的记录值
        /// </summary>
        public int count;
        public long id;
    }
    public struct Bhismsg
    {
        public string number;
        public int Count;
        public string year;
        public int mA;
        public long id;
    }

    public enum BackState
    {
        Yes,
        No,
        Err
    }

    public struct BackRealstate
    {
        public  BackState bs;
        public string number;
        public string addr;//安装位置
        public string pahse;
        public int count;
        public int mA;
        public DateTime time;
        public DateTime backtime;
    }
    public struct downdata
    {
       public  string id;//设备id
       public int count;//动作总次数
       public  int indexf;//上次记录几次找
    }
}

