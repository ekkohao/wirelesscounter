using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationProtocol
{
    public interface Iprotocol_Body:IprotocolVersion
    {
        /// <summary>
        /// 校验位函数
        /// </summary>
        byte CheckCrc(byte[] temp);
        /// <summary>
        /// 复制数组
        /// </summary>
        /// <param name="startbit"></param>
        /// <param name="endbit"></param>
        /// <param name="copy"></param>
        /// <returns></returns>
        byte[] CopyMsg(int startbit, int endbit, byte[] copy);

         #region 发送报文
         /// <summary>
        /// 发送实时协议报文
        /// </summary>
        /// <returns></returns>
         byte[] RealMsg(byte[] temp);
        /// <summary>
        /// 发送设备实时时间
        /// </summary>
        /// <returns></returns>
         byte[] RealtimeMsg(byte[] temp);

        /// <summary>
        /// 动作报文
        /// </summary>
        /// <returns></returns>
         byte[] ActionMsg(byte[] temp,int Cout);
        /// <summary>
        /// 2小时历史记录报文
        /// </summary>
        /// <returns></returns>
         byte[] HistroyMsg(byte[] temp,int Cout);
         
        /// <summary>
        /// 历史的记录个数
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
         byte[] HistroyCout(byte[] temp);
        /// <summary>
        /// 写入设备时间
        /// </summary>
        /// <returns></returns>
         byte[] WriteMsg(byte[] temp,int time,int timedata);

        /// <summary>
        /// 设备是否在线
        /// </summary>
        /// <returns></returns>
         byte[] Online(byte[] temp);

        /// <summary>
        /// 设备初始化
        /// </summary>
        /// <returns></returns>
         byte[] InitDevice(byte[] temp);
        #endregion

        #region 返回报文
        ///用于检测报文
        ///
         /// <summary>
         /// 发送实时协议报文
         /// </summary>
         /// <returns></returns>
         byte[] BackRealMsg();
         /// <summary>
         /// 发送设备实时时间
         /// </summary>
         /// <returns></returns>
         byte[] BackRealtimeMsg();

         /// <summary>
         /// 动作报文
         /// </summary>
         /// <returns></returns>
         byte[] BackActionMsg();
         /// <summary>
         /// 2小时历史记录报文
         /// </summary>
         /// <returns></returns>
         byte[] BackHistroyMsg();
        /// <summary>
        /// 返回历史记录个数
        /// </summary>
        /// <returns></returns>
         byte[] BackHistroyCount();
         /// <summary>
         /// 写入设备时间
         /// </summary>
         /// <returns></returns>
         byte[] BackWriteMsg();

         /// <summary>
         /// 设备是否在线
         /// </summary>
         /// <returns></returns>
         byte[] BackOnline();

         /// <summary>
         /// 设备初始化
         /// </summary>
         /// <returns></returns>
         byte[] BackInitDevice();

        #endregion
    }
}
