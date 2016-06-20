using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationProtocol
{
    /// <summary>
    /// 功能码
    /// </summary>
    public interface Iportocol_Head:IprotocolVersion
    {
        #region 8个发送报文头
        /// <summary>
        /// 实时报文头
        /// </summary>
        byte Head_Real { get; set; }
        /// <summary>
        /// 历史报文头
        /// </summary>
        byte Head_HistroyMsg { get; set; }
        /// <summary>
        /// 历史记录个数报文
        /// </summary>
        byte Head_HistroyCout { get; set; }

        /// <summary>
        /// 设备时间报文头
        /// </summary>
        byte Head_Realtime { get; set; }

        /// <summary>
        /// 动作报文头
        /// </summary>
        byte Head_Action { get; set; }
        /// <summary>
        /// 写入时间报文头
        /// </summary>
        byte Head_writeDev { get; set; }
        /// <summary>
        /// 设备在线报文头
        /// </summary>
        byte Head_Online { get; set; }
        /// <summary>
        /// 设备初始化报文头
        /// </summary>
        byte Head_init { get;set; }

        /// <summary>
        /// 报文结束位
        /// </summary>
        byte protocol_stop { get; set; }


        #endregion

     
     

        #region 8个接收报文头
        /// <summary>
        /// 实时报文头
        /// </summary>
        byte Back_Real { get; set; }
        /// <summary>
        /// 历史报文头
        /// </summary>
        byte Back_HistroyMsg { get; set; }
        /// <summary>
        /// 初始化历史记录数报文头
        /// </summary>
        byte Back_HistroyCount { get; set; }

        /// <summary>
        /// 设备时间报文头
        /// </summary>
        byte Back_Realtime { get; set; }

        /// <summary>
        /// 动作报文头
        /// </summary>
        byte Back_Action { get; set; }
        /// <summary>
        /// 写入时间报文头
        /// </summary>
        byte Back_writeDev { get; set; }
        /// <summary>
        /// 设备在线报文头
        /// </summary>
        byte Back_Online { get; set; }
        /// <summary>
        /// 设备初始化报文头
        /// </summary>
        byte Back_init { get; set; }
   
        #endregion


    }


}
