using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace CommunicationProtocol
{
    public  class ProtoColConnect:Iprotocol
    {
     
        public ProtoColConnect()
        {

        }
        /// <summary>
        /// 协议名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 协议版本
        /// </summary>
        public virtual string Version { get; set; }

        /// <summary>
        /// 协议说明
        /// </summary>
        public virtual string Instruction { get; set; }


        #region 8个发送报文的功能码
        /// <summary>
        /// 实时报文头
        /// </summary>
       public virtual byte Head_Real { get; set; }
        /// <summary>
        /// 历史报文头
        /// </summary>
       public virtual byte Head_HistroyMsg { get; set; }
       public virtual byte Head_HistroyCout { get; set; }
        /// <summary>
        /// 设备时间报文头
        /// </summary>
       public virtual byte Head_Realtime { get; set; }

        /// <summary>
        /// 动作报文头
        /// </summary>
       public virtual byte Head_Action { get; set; }
        /// <summary>
        /// 写入时间报文头
        /// </summary>
       public virtual byte Head_writeDev { get; set; }
        /// <summary>
        /// 设备在线报文头
        /// </summary>
       public virtual byte Head_Online { get; set; }
        /// <summary>
        /// 设备初始化报文头
        /// </summary>
        public virtual byte Head_init { get; set; }

        /// <summary>
        /// 报文结束位
        /// </summary>
       public virtual byte protocol_stop { get; set; }
        #endregion




        #region 8个接收报文功能码
        /// <summary>
        /// 实时报文头
        /// </summary>
       public virtual byte  Back_Real { get; set; }

       public virtual byte Back_HistroyCount { get; set; }
       public virtual byte Back_HistroyMsg { get; set; }
   
        /// <summary>
        /// 设备时间报文头
        /// </summary>
       public virtual byte Back_Realtime { get; set; }

        /// <summary>
        /// 动作报文头
        /// </summary>
       public virtual byte Back_Action { get; set; }
        /// <summary>
        /// 写入时间报文头
        /// </summary>
       public virtual byte Back_writeDev { get; set; }
        /// <summary>
        /// 设备在线报文头
        /// </summary>
       public virtual byte Back_Online { get; set; }
        /// <summary>
        /// 设备初始化报文头
        /// </summary>
       public virtual byte Back_init { get; set; }
        #endregion

        /// <summary>
        /// 校验位函数
        /// </summary>
       public virtual byte  CheckCrc(byte[] memorySpage)
       {

            /// <returns>返回校验和结果</returns>    
            int num = 0;
            for (int i = 0; i < memorySpage.Length; i++)
            {
                num = (num + memorySpage[i]); //取低字节 
            }
            
            //实际上num 这里已经是结果了，如果只是取int 可以直接返回了
            num = num % 0x100;
              
            //返回累加校验和  
            return Convert.ToByte(num);
       }
        #region 发送报文
        /// <summary>
        /// 发送实时协议报文
        /// </summary>
        /// <returns></returns>
       public virtual byte[] RealMsg(byte[] temp)
       {
           return temp;
       }
        /// <summary>
        /// 发送设备实时时间
        /// </summary>
        /// <returns></returns>
       public virtual byte[] RealtimeMsg(byte[] temp)
       {
           return temp;
       }

        /// <summary>
        /// 动作报文
        /// </summary>
        /// <returns></returns>
       public virtual byte[] ActionMsg(byte[] temp,int Count)
       {
           return temp;
       }
        /// <summary>
        /// 2小时历史记录报文
        /// </summary>
        /// <returns></returns>
       public virtual byte[] HistroyMsg(byte[] temp, int cout)
       {
           return temp;
       }
       /// <summary>
       /// 历史记录个数
       /// </summary>
        public virtual byte[] HistroyCout(byte [] temp)
       {
           return temp;
       }
        /// <summary>
        /// 写入设备时间
        /// </summary>
        /// <returns></returns>
       public virtual byte[] WriteMsg(byte[] temp, int time, int timedata)
       {
           return temp;
       }

        /// <summary>
        /// 设备是否在线
        /// </summary>
        /// <returns></returns>
       public virtual byte[] Online(byte[] temp)
      {
          return temp;
      }

        /// <summary>
        /// 设备初始化
        /// </summary>
        /// <returns></returns>
       public virtual byte[] InitDevice(byte[] init)
       {
           return init;
       }
        #endregion

        #region 返回报文
        ///用于检测报文
        ///
        /// <summary>
        /// 发送实时协议报文
        /// </summary>
        /// <returns></returns>
       public virtual byte[] BackRealMsg()
       {
           byte[] temp = new byte[4];
           return temp;
       }
        /// <summary>
        /// 发送设备实时时间
        /// </summary>
        /// <returns></returns>
       public virtual byte[] BackRealtimeMsg()
      {
          byte[] temp = new byte[4];
          return temp;
      }

        /// <summary>
        /// 动作报文
        /// </summary>
        /// <returns></returns>
       public virtual byte[] BackActionMsg()
      {
          byte[] temp = new byte[4];
          return temp;
      }
        /// <summary>
       /// 2小时历史记录报文
       /// </summary>
        /// <returns></returns>
       public virtual byte[] BackHistroyMsg()
      {
          byte[] temp = new byte[4];
          return temp;
      }
       public virtual byte[] BackHistroyCount()
       {
           byte[] temp = new byte[4];
           return temp;
       }
        /// <summary>
        /// 写入设备时间
        /// </summary>
        /// <returns></returns>
       public virtual byte[] BackWriteMsg()
      {
          byte[] temp = new byte[4];
          return temp;
      }

        /// <summary>
        /// 设备是否在线
        /// </summary>
        /// <returns></returns>
       public virtual byte[] BackOnline()
       {
           byte[] temp = new byte[4];
           return temp;
       }

        /// <summary>
        /// 设备初始化
        /// </summary>
        /// <returns></returns>
       public virtual byte[] BackInitDevice()
      {
          byte[] temp = new byte[4];
          return temp;
      }

        #endregion
       public virtual byte[] CopyMsg(int startbit, int endbit, byte[] copy)
       {
           return copy;
       }
       

       

  
    }
}
