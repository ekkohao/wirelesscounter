using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationProtocol
{

    /// <summary>
    ///  有全电流协议重写通信报文方法Initialization protocol
    /// </summary>
    partial class CommunicateWithmA:ProtoColConnect
    {
     
        private void InitializationProtocol()
        {
            //设置报文的协议功能代码
            this.Head_Real = 0x00;
            this.Head_Realtime = 0x01;
            this.Head_Action = 0x04;

            this.Head_writeDev = 0x31;
            this.Head_Online = 0x41;
            this.Head_init = 0x42;
            //有历史记录的功能码
            this.Head_HistroyMsg = 0x03;
            this.Head_HistroyCout = 0x02;
           
        }

        /// <summary>
        /// 获取某些位的字节
        /// </summary>
        /// <param name="startbit">开始copy位置</param>
        /// <param name="endbit">结束copy位置,包含这位</param>
        /// <param name="copy">copy的字节数组</param>
        /// <returns></returns>
        public override byte [] CopyMsg(int startbit,int endbit,byte [] copy)
        {
            if(startbit>=endbit) return null;
              byte[] temp=new byte[endbit-startbit+1];
              for (int i = 0; i < endbit-startbit+1; i++)
            {
                temp[i] = copy[startbit + i];
            }
            return temp;
        }
        #region   发送的报文
        /// <summary>
        /// 实时数据包文
        /// </summary>
        /// <param name="temp">地址</param>
        /// <returns>返回整条报文</returns>
        public override byte[] RealMsg(byte[] temp)
        {
            byte[] _Msg = new byte[10];
            _Msg[0] = 0x11;//协议头为0x11
            for (int i = 0; i < 4;i++)
            {
                _Msg[i + 1] = temp[i];
            }
            _Msg[5] = Head_Real;
            _Msg[6] = 0x00;
            _Msg[7] = 0x00;

            ///注意下标位置
            _Msg[8] = this.CheckCrc(CopyMsg(1, 7, _Msg));
            _Msg[9] = 0x16;
             return _Msg;
            //return base.RealMsg(_Msg);
        }
        public override byte[] RealtimeMsg(byte[] temp)
        {
            byte[] _Msg = new byte[10];
            _Msg[0] = 0x11;//协议头为0x11
            for (int i = 0; i < 4; i++)
            {
                _Msg[i + 1] = temp[i];
            }
            _Msg[5] = Head_Realtime;
            _Msg[6] = 0x00;
            _Msg[7] = 0x00;

            _Msg[8] = this.CheckCrc(CopyMsg(1,7, _Msg));
            ///注意下标位置
            _Msg[9] = 0x16;
            return _Msg;
           // return base.RealtimeMsg(_Msg);
        }
        /// <summary>
        /// 查询动作的记录时间
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="Count">动作的次数</param>
        /// <returns></returns>
        public override byte[] ActionMsg(byte[] temp,int Count)
        {
            byte[] _Msg = new byte[10];
            _Msg[0] = 0x11;//协议头为0x11
            for (int i = 0; i < 4; i++)
            {
                _Msg[i + 1] = temp[i];
            }
            _Msg[5] = Head_Action;

            _Msg[6] = Convert.ToByte(Count/ 256); //次数高位,次数低位
            _Msg[7] = Convert.ToByte(Count % 256); 
            _Msg[8] = this.CheckCrc(CopyMsg(1, 7, _Msg));
            ///注意下标位置
            _Msg[9] = 0x16;
            return _Msg;
            //return base.ActionMsg(_Msg,Count);
        }

        /// <summary>
        /// 依次写入时间 0x00-0x05 分别代表年，月，日，时，分，秒;
        /// </summary>
        /// <param name="temp">
        /// </param>
        /// <returns></returns>
        public override byte[] WriteMsg(byte[] temp,int code,int timedata)
        {
            byte[] _Msg = new byte[10];
            _Msg[0] = 0x11;//协议头为0x11
            for (int i = 0; i < 4; i++)
            {
                _Msg[i + 1] = temp[i];
            }
            _Msg[5] = Head_writeDev;

            _Msg[6] = Convert.ToByte(code); //次数高位,次数低位
            _Msg[7] = Convert.ToByte(timedata);

            _Msg[8] = this.CheckCrc(CopyMsg(1, 7, _Msg));
            ///注意下标位置
            _Msg[9] = 0x16;
            return _Msg;
          //  return base.WriteMsg(_Msg,time,timedata);
        }
        public override byte[] Online(byte[] temp)
        {
            byte[] _Msg = new byte[10];
            _Msg[0] = 0x11;//协议头为0x11
            for (int i = 0; i < 4; i++)
            {
                _Msg[i + 1] = temp[i];
            }
            _Msg[5] = Head_Online;

            _Msg[6] = 0x00; //次数高位,次数低位
            _Msg[7] = 0x00;

            _Msg[8] = this.CheckCrc(CopyMsg(1, 7, _Msg));
            ///注意下标位置
            _Msg[9] = 0x16;
            return _Msg;
            //return base.Online(_Msg);
        }
        public override byte[] InitDevice(byte[] init)
        {
            byte[] _Msg = new byte[10];
            _Msg[0] = 0x11;//协议头为0x11
            for (int i = 0; i < 4; i++)
            {
                _Msg[i + 1] = init[i];
            }
            _Msg[5] = Head_init;

            _Msg[6] = 0x00; //次数高位,次数低位
            _Msg[7] = 0x01;//00普通初始化，01清历史记录

            _Msg[8] = this.CheckCrc(CopyMsg(1, 7, _Msg));
            ///注意下标位置
            _Msg[9] = 0x16;
            return _Msg;
            //return base.InitDevice(_Msg);
        }

        /// <summary>
        /// 历史记录
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="cout"></param>
        /// <returns></returns>
        public override byte[] HistroyMsg(byte[] temp,int cout)
        {
            //等报文出来重写

            byte[] _Msg = new byte[10];
            _Msg[0] = 0x11;//协议头为0x11
            for (int i = 0; i < 4; i++)
            {
                _Msg[i + 1] = temp[i];
            }
            _Msg[5] = Head_HistroyMsg;
            if (cout <0 || cout >=65535)
            {
               
                _Msg[6] = 0;
                _Msg[7] = 0;
            }
            else
            {
                _Msg[6] = Convert.ToByte(cout / 256); //次数高位,次数低位
                _Msg[7] = Convert.ToByte(cout % 256);
            }
            _Msg[8] = this.CheckCrc(CopyMsg(1, 7, _Msg));
            ///注意下标位置
            _Msg[9] = 0x16;
            return _Msg;
          //  return base.HistroyMsg(_Msg,cout);
        }
        /// <summary>
        /// 历史记录个数
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public override byte[] HistroyCout(byte[] temp)
        {
             byte[] _Msg = new byte[10];
            _Msg[0] = 0x11;//协议头为0x11
            for (int i = 0; i < 4; i++)
            {
                _Msg[i + 1] = temp[i];
            }
            _Msg[5] = Head_HistroyCout;

            _Msg[6] = 0x00; //次数高位,次数低位
            _Msg[7] = 0x00;

            _Msg[8] = this.CheckCrc(CopyMsg(1, 7, _Msg));
            ///注意下标位置
            _Msg[9] = 0x16;
            return _Msg;
           // return base.HistroyCout(_Msg);
        }
        #endregion 

        #region 返回报文用于检测接收的报文是否是当前功能码的报文返回头，功能码，长度，结束码

        public override byte[] BackRealMsg()
        {
            byte[] temp = new byte[4];

            temp[0] = 0x69;
            temp[1] = this.Head_Real;
            temp[2] = 0x0c;
            temp[3] = 0x16;
            return temp;
        }

        public override byte[] BackRealtimeMsg()
        {
            byte[] temp = new byte[4];

            temp[0] = 0x69;
            temp[1] = this.Head_Realtime;
            temp[2] = 0x0f;
            temp[3] = 0x16;
            return temp;
        }
        public override byte[] BackActionMsg()
        {
            byte[] temp = new byte[4];

            temp[0] = 0x69;
            temp[1] = this.Head_Action;
            temp[2] = 0x11;
            temp[3] = 0x16;
            return temp;
        }

        public override byte[] BackWriteMsg()
        {
            //return base.BackWriteMsg();
            byte[] temp = new byte[4];

            temp[0] = 0x69;
            temp[1] = this.Head_writeDev;
            temp[2] = 0x0b;
            temp[3] = 0x16;
            return temp;
        }
        public override byte[] BackOnline()
        {
            byte[] temp = new byte[4];

            temp[0] = 0x69;
            temp[1] = this.Head_Online;
            temp[2] = 0x0b;
            temp[3] = 0x16;
            return temp;
            //return base.BackOnline();
        }
        public override byte[] BackInitDevice()
        {
            byte[] temp = new byte[4];

            temp[0] = 0x69;
            temp[1] = this.Head_init;
            temp[2] = 0x0b;
            temp[3] = 0x16;
            return temp;
            //return base.BackInitDevice();
        }

        public override byte[] BackHistroyMsg()
        {
            byte[] temp = new byte[4];

            temp[0] = 0x69;
            temp[1] = this.Head_HistroyMsg;
            temp[2] = 0x11;
            temp[3] = 0x16;
            return temp;
           // return base.BackHistroyMsg(temp);
        }

        public override byte[] BackHistroyCount()
        {
            byte[] temp = new byte[4];

            temp[0] = 0x69;
            temp[1] = this.Head_HistroyCout;
            temp[2] = 0x0c;
            temp[3] = 0x16;
            return temp;
           // return base.BackHistroyCount();
        }
        #endregion

    }
}
