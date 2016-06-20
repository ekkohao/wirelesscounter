using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationProtocol
{
    /// <summary>
    ///  有全电流协议
    /// </summary>
    public partial class CommunicateWithmA
    {
        public CommunicateWithmA()
        {
            InitializationProtocol();
        }

        /// <summary>
        /// 有参数构造函数
        /// </summary>
        /// <param name="names"></param>
        /// <param name="versions"></param>
        /// <param name="instructions"></param>
        public CommunicateWithmA( string names,string versions,string instructions)
        {
            InitializationProtocol();
            Name = names;
            Version = versions;
            Instruction = instructions;
        }

        #region 功能码标志
        private string name,version,instruction;
        private byte Send_real, Send_time, Send_action, Send_write;
        private byte Send_online, Send_init, Send_hismsg, Send_hiscout;
        private byte Back_real, Back_time, Back_action, Back_write;
        private byte Back_online, Back_inits, Back_hismsg, Back_hiscout;
        private byte stopbit;
        #endregion
        /// <summary>
        /// 协议名称
        /// </summary>
        public override string Name { get { return name;} set { name=value;} }
        /// <summary>
        /// 协议版本
        /// </summary>
        public override string Version { get { return version; } set { version = value; } }

        /// <summary>
        /// 协议说明
        /// </summary>
        public override string Instruction { get { return instruction; } set { instruction = value; } }


        #region 8个发送报文的功能码
        /// <summary>
        /// 实时报文头
        /// </summary>
        ///  Send_real, Send_time, Send_action, Send_write;
        //// Send_online, Send_init, Send_hismsg, Send_hiscout;
        public override byte Head_Real { get { return Send_real; } set { Send_real = value; } }
        /// <summary>
        /// 历史报文头
        /// </summary>
        /// 
        public override byte Head_HistroyMsg { get { return Send_hismsg; } set { Send_hismsg = value; } }
        public override byte Head_HistroyCout{  get { return Send_hiscout; } set { Send_hiscout = value; } }
        /// <summary>
        /// 设备时间报文头
        /// </summary>
        public override byte Head_Realtime { get { return Send_time; } set { Send_time = value; } }

        /// <summary>
        /// 动作报文头
        /// </summary>
        public override byte Head_Action { get { return Send_action; } set { Send_action = value; } }
        /// <summary>
        /// 写入时间报文头
        /// </summary>
        public override byte Head_writeDev { get { return Send_write; } set { Send_write = value; } }
        /// <summary>
        /// 设备在线报文头
        /// </summary>
        public override byte Head_Online { get { return Send_online; } set { Send_online = value; } }
        /// <summary>
        /// 设备初始化报文头
        /// </summary>
        public override byte Head_init { get { return Send_init; } set { Send_init = value; } }

        /// <summary>
        /// 报文结束位
        /// </summary>
        public override byte protocol_stop { get { return stopbit; } set { stopbit =value; } }
        #endregion



        //Back_real, Back_time, Back_action, Back_write;
        // Back_online, Back_init, Back_hismsg, Back_hiscout;
        #region 8个接收报文功能码
        /// <summary>
        /// 实时报文头
        /// </summary>
        public override byte Back_Real { get { return Back_real; } set { Back_real = value; } }
        /// <summary>
        /// 历史报文头BackHistroyMsg
        /// </summary>
        public override byte Back_HistroyCount { get { return Back_hiscout; } set { Back_hiscout = value; } }
        public override byte Back_HistroyMsg { get { return Back_hismsg; } set { Back_hismsg = value; } }
        /// <summary>
        /// 设备时间报文头
        /// </summary>
        public override byte Back_Realtime { get { return Back_time; } set { Back_time = value; } }

        /// <summary>
        /// 动作报文头
        /// </summary>
        public override byte Back_Action { get { return Back_action; } set { Back_action = value; } }
        /// <summary>
        /// 写入时间报文头
        /// </summary>
        public override byte Back_writeDev { get { return Back_write; } set { Back_write = value; } }
        /// <summary>
        /// 设备在线报文头
        /// </summary>
        public override byte Back_Online { get { return Back_online; } set { Back_online = value; } }
        /// <summary>
        /// 设备初始化报文头
        /// </summary>
        public override byte Back_init { get { return Back_inits; } set { Back_inits = value; } }

      
        #endregion
    }
}
