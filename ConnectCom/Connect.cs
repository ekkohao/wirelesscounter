using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace ConnectCom
{
    public class Connect
    {
        public SerialPort _CComPort=null;
        public bool ReceiveEventFlag = false;//接收事件是否有效，无效为真，有效位假

        private string ComProtocol = null;

        public string GetProtocolVersion
        {
            get
            {
                return ComProtocol;
            }
        }
          /// <summary>
        /// 构造函数,可以自定义串口的初始化参数
        /// </summary>
        /// <param name="comPortName">需要操作的COM口名称</param>
        /// <param name="baudRate">COM的速度</param>
        /// <param name="parity">奇偶校验位</param>
        /// <param name="dataBits">数据长度</param>
        /// <param name="stopBits">停止位</param>
        public Connect( string comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            _CComPort= new SerialPort(comPortName, baudRate, parity, dataBits, stopBits);
           
        }
        /// <summary>
        /// 构造串口函数
        /// </summary>
        /// <param name="comPortName"></param>
        /// <param name="baudRate"></param>
        /// <param name="version"></param>
        public Connect(string comPortName, int baudRate,string  version)
        {
            _CComPort = new SerialPort();
            _CComPort.PortName = comPortName;
            _CComPort.BaudRate = baudRate;
            _CComPort.StopBits = StopBits.One;
            _CComPort.DataBits = 8;
            ComProtocol = version;
        }


        /// <summary>
        /// 打开串口资源
        /// </summary>
        public bool openPort()
        {
            bool ok = false;
            //如果串口是打开的，先关闭
            if (_CComPort.IsOpen)
                _CComPort.Close();
            try
            {
                //打开串口
                _CComPort.Open();
                ok = true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return ok;
        }
        /// <summary>
        /// 关闭串口资源,操作完成后,一定要关闭串口
        /// </summary>
        public void closePort()
        {
            //如果串口处于打开状态,则关闭
            if (_CComPort.IsOpen)
                _CComPort.Close();
        }

        /// <summary>
        /// 获取端口连接状态
        /// </summary>
        /// <returns></returns>
        public bool getIsOpen()
        {
            //如果串口是打开的，true,否则为false;
            bool flag = false;
            try { flag = _CComPort.IsOpen; }
            catch { }
            return flag;

        }

        /// <summary>
        /// 串口数据发送
        /// </summary>
        /// <param name="data"></param>
    
        public void SendData(byte[] data, int offset, int count)
        {
            if (_CComPort.IsOpen)
            {
                _CComPort.Write(data, offset, count);
            }
        }

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="SendData">发送数据</param>
        /// <param name="ReceiveData">接收数据</param>
        /// <param name="Overtime">超时时间</param>
        /// <returns></returns>

        //public int SendCommand(byte[] SendData, ref  byte[] ReceiveData, int Overtime)
        //{

        //    if (_CComPort.IsOpen)
        //    {
        //        ReceiveEventFlag = true;        //关闭接收事件
        //        _CComPort.DiscardInBuffer();         //清空接收缓冲区                 
        //        _CComPort.Write(SendData, 0, SendData.Length);
        //        int num = 0, ret = 0;
        //        while (num++ < Overtime)
        //        {
        //            if (_CComPort.BytesToRead >= ReceiveData.Length) break;
        //            System.Threading.Thread.Sleep(1);
        //        }
        //        if (_CComPort.BytesToRead >= ReceiveData.Length)
        //            ret = _CComPort.Read(ReceiveData, 0, ReceiveData.Length);
        //        ReceiveEventFlag = false;       //打开事件
        //        return ret;
        //    }
        //    return -1;
        //}


    }
}
