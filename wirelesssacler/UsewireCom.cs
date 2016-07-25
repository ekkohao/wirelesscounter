using System;
using System.Collections.Generic;
using System.Text;
using ConnectCom;
using CommunicationProtocol;
using System.IO.Ports;
using MySqlCon;
using System.Configuration;
using System.Data;

namespace wirelesssacler
{
    public class UsewireCom : Connect
    {
        /// <summary>
        /// 定义用户协议
        /// </summary>
        private CommunicationProtocol.ProtoColConnect wireProtocol;

        /// <summary>
        /// 设备序列转换对象
        /// </summary>
        private SequenceWithStrToByte Sequence = new SequenceWithStrToByte();


        /// <summary>
        /// 临时存放时间
        /// </summary>
        private DateTime dt;
        private struct Timestruct
        {
            public int year;
            public int mouth;
            public int day;
            public int hour;
            public int minutes;
            public int seconds;
        }

        private static LinkedList<Dev_Real> _Real = new LinkedList<Dev_Real>();
        private LinkedListNode<Dev_Real> _pReal = _Real.First;

        private static LinkedList<Dev_RecordAction> _Action = new LinkedList<Dev_RecordAction>();
        private LinkedListNode<Dev_RecordAction> _pAction = _Action.First;

        private static LinkedList<Dev_RecordHistroy> _Histroy = new LinkedList<Dev_RecordHistroy>();
        private LinkedListNode<Dev_RecordHistroy> _pHis = _Histroy.First;

        public static LinkedList<DevBackTime> _DBtime = new LinkedList<DevBackTime>();
        private LinkedListNode<DevBackTime> _pDbtime = _DBtime.First;
        private bool Iswriteok = false;
        private bool Isinit = false;
        private bool Istime = false;
        private bool Isreal = false;
        private bool Isaction=false;
        private bool Isline =false;
        private bool Ishisco = false;
        private bool Ishimsg=false ;
        private SqlHelp Save = new SqlHelp();

        public delegate void SerialPortDataReceiveEventArgs(object sender, SerialDataReceivedEventArgs e, byte[] bits);
        public event SerialPortDataReceiveEventArgs DataRecived;

        /// <summary>
        /// 一次循环次数的记录
        /// </summary>
        private int Ciclenumber = 1440;
        /// <summary>
        /// 时间结构
        /// </summary>
        private Timestruct CurDevT ;
        /// <summary>
        /// 间隔毫秒级别
        /// </summary>
        public int interval_T = 6000;
        public int InterReal = 7000;

        #region 返回的报文
        private byte[] Protocol_real;
        private byte[] Protocol_realtime;
        private byte[] Protocol_Action;
        private byte[] Protocol_write;
        private byte[] Protocol_online;
        private byte[] Protocol_init;
        private byte[] Protocol_hiscot;
        private byte[] Protocol_hismsg;
        #endregion
        /// <summary>
        /// 缓冲区大小
        /// </summary>
        public List<byte> PortByte = new List<byte>(4096);
        public byte[] tempreal;
        public byte[] temptime;
        public byte[] tempaction;
        public byte[] tempwrite;
        public byte[] temponline;
        public byte[] tempinit;
        public byte[] temphiscot;
        public byte[] temphismsg;

        #region 串口接受缓冲结构
        BAction _baction;
        BHiscot _bhiscot;
        Bhismsg _bhismsg;
        BInit _binit;
        BOnline _bonline;
        BReal _breal;
        BTime _btime;
        BWrite _bwrite;

        #endregion
        /// <summary>
        /// 构造函数,传入协议,和设备列表
        /// </summary>
        /// <param name="comPortName"></param>
        /// <param name="baudRate"></param>
        /// <param name="ProtocolName"></param>
        /// <param name="proconet"></param>
        public UsewireCom(string comPortName, int baudRate, string ProtocolName, CommunicationProtocol.ProtoColConnect proconet, LinkedList<Device> ds)
            : base(
                comPortName, baudRate, ProtocolName)
        {
            ///
            wireProtocol = proconet;//传递协议对象进来
           

            //根据协议来初始化传递给参数
            if (wireProtocol.Name == "1.0.0.0")
            {
                this.DataRecived += DataRecivedWithOutmA;
                InterReal = 5000;
            }
            else if (wireProtocol.Name == "2.0.0.0")
            {
                InterReal = 8000;
                this.DataRecived +=DataRecivedWithmA;
            }
            else
                this.DataRecived += UsewireCom_DataRecived;
            
            wireProtocol.Version = proconet.Instruction;
            wireProtocol.Instruction = proconet.Instruction;
            //初始化协议报文
            SetProtocol(proconet);
            //初始化设备链表
            initdevlist(ds);
            //必须先初始化协议，在为数据接收分配缓冲指定大小内存
            SetReciveStruct();
            setSerialPort();

        }

        void UsewireCom_DataRecived(object sender, SerialDataReceivedEventArgs e, byte[] bits)
        {
            throw new NotImplementedException();
        }


       


        public  void _CComPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            byte[] _data = new byte[_CComPort.BytesToRead];
            _CComPort.Read(_data, 0, _data.Length);
            if (_data.Length == 0) { return; }
            if (this.DataRecived!= null)
            {
                DataRecived(sender, e, _data);
              
            }
            //_serialPort.DiscardInBuffer();  //清空接收缓冲区
            //---------------------------------------------------------------------是否全部丢弃
            _CComPort.DiscardInBuffer();
        }
        public  void setSerialPort()
        {
            if (_CComPort != null)
            {
                //设置触发DataReceived事件的字节数为1
                _CComPort.ReceivedBytesThreshold = 1;
                //接收到一个字节时，也会触发DataReceived事件
                _CComPort.DataReceived += new SerialDataReceivedEventHandler(_CComPort_DataReceived);
            }
        }
        private void initdevlist(LinkedList<Device> ds)
        {
            LinkedListNode<Device> _pd = ds.First;
      
            
            while(_pd != null)
            {
                Dev_Real devreal = new Dev_Real();
                Dev_RecordAction devaction = new Dev_RecordAction();
                Dev_RecordHistroy devhistroy = new Dev_RecordHistroy();
                DevBackTime devback = new DevBackTime();
                devreal.dev = _pd.Value;
                devaction.dev = _pd.Value;
                devhistroy.dev = _pd.Value;
                devback.dev = _pd.Value;
               

                _Real.AddLast(devreal);
                _Action.AddLast(devaction);
                _Histroy.AddLast(devhistroy);
                _DBtime.AddLast(devback);

                _pd = _pd.Next;
            }
            //System.Windows.Forms.MessageBox.Show(_Action.Count.ToString());
        }

        private void SetProtocol(ProtoColConnect pro)
        {
            Protocol_real = pro.BackRealMsg();
            Protocol_realtime = pro.BackRealtimeMsg();
            Protocol_Action = pro.BackActionMsg();
            Protocol_write = pro.BackWriteMsg();

            Protocol_online = pro.BackOnline();
            Protocol_init = pro.BackInitDevice();
            if (pro.BackHistroyCount() != null && pro.BackHistroyMsg() != null)
            {
                Protocol_hiscot = pro.BackHistroyCount();
                Protocol_hismsg = pro.BackHistroyMsg();
            }
        }
        /// <summary>
        /// 为接收的不同报文分配临时存储空间
        /// </summary>
        private void SetReciveStruct()
        {

            tempreal = new byte[Protocol_real[2]];
            temptime = new byte[Protocol_realtime[2]];
            tempaction = new byte[Protocol_Action[2]];
            tempwrite = new byte[Protocol_write[2]];
            temponline = new byte[Protocol_online[2]];
            tempinit = new byte[Protocol_init[2]];
            if (Protocol_hiscot != null && Protocol_hismsg != null)
            {
                temphiscot = new byte[Protocol_hiscot[2]];
                temphismsg = new byte[Protocol_hismsg[2]];
            }
            _baction = new BAction();

            _binit = new BInit();
            _bonline = new BOnline();
            _breal = new BReal();
            _btime = new BTime();
            _bwrite = new BWrite();
            if (Protocol_hiscot != null && Protocol_hismsg != null)
            {
                _bhiscot = new BHiscot();
                _bhismsg = new Bhismsg();
            }
        }

        /// <summary>
        /// 全电流处理接收函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="Readbits">串口缓冲区数据</param>
        private void DataRecivedWithmA(object sender, System.IO.Ports.SerialDataReceivedEventArgs e, byte[] Readbits)
        {
            PortByte.AddRange(Readbits);
            while (PortByte.Count >= 10)
            {
                ///依次比较长度，报文头，功能码，报文接收字符

                if (PortByte[0] == Protocol_realtime[0] && PortByte[5] == Protocol_realtime[1])
                {
                    if (PortByte.Count < Protocol_realtime[2]) break;
                    //校验
                    byte[] temp = new byte[Protocol_realtime[2] - 3];
                    for (int i = 0; i < Protocol_realtime[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_realtime[2] - 2])
                    {
                        PortByte.CopyTo(0, temptime, 0, Protocol_realtime[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProTimeData(temptime, temptime.Length);


                    }
                    else
                        PortByte.RemoveRange(0, Protocol_realtime[2]);
                }
                else if (PortByte[0] == Protocol_real[0] && PortByte[5] == Protocol_real[1])
                {
                    //返回实时数据 线获得设备的时间，在获取数据
                    if (PortByte.Count < Protocol_real[2]) break;

                    //校验
                    byte[] temp = new byte[Protocol_real[2] - 3];
                    for (int i = 0; i < Protocol_real[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_real[2] - 2])
                    {
                        PortByte.CopyTo(0, tempreal, 0, Protocol_real[2]);
                        PortByte.Clear();//清空，找到数据，清空数据
                        //返回时间了。
                        //处理temptime
                        ProDevData(tempreal, tempreal.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_real[2]);

                }
                else if (PortByte[0] == Protocol_Action[0] && PortByte[5] == Protocol_Action[1])
                {
                    //返回动作时间
                    if (PortByte.Count < Protocol_Action[2]) break;
                    //校验
                    byte[] temp = new byte[Protocol_Action[2] - 3];
                    for (int i = 0; i < Protocol_Action[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_Action[2] - 2])
                    {
                        PortByte.CopyTo(0, tempaction, 0, Protocol_Action[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProActData(tempaction, tempaction.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_Action[2]);

                }
                else if (PortByte[0] == Protocol_write[0] && PortByte[5] == Protocol_write[1])
                {
                    //返回写入时间
                    if (PortByte.Count < Protocol_write[2]) break;
                    byte[] temp = new byte[Protocol_write[2] - 3];
                    for (int i = 0; i < Protocol_write[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_write[2] - 2])
                    {
                        PortByte.CopyTo(0, tempwrite, 0, Protocol_write[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProWriteData(tempwrite, tempwrite.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_write[2]);
                }
                else if (PortByte[0] == Protocol_online[0] && PortByte[5] == Protocol_online[1])
                {
                    //返回设备是否在线
                    if (PortByte.Count < Protocol_online[2]) break;
                    byte[] temp = new byte[Protocol_online[2] - 3];
                    for (int i = 0; i < Protocol_online[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_online[2] - 2])
                    {
                        PortByte.CopyTo(0, temponline, 0, Protocol_online[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProOnlineData(temponline, temponline.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_online[2]);
                }
                else if (PortByte[0] == Protocol_init[0] && PortByte[5] == Protocol_init[1])
                {
                    //返回初始化
                    if (PortByte.Count < Protocol_init[2]) break;
                    byte[] temp = new byte[Protocol_init[2] - 3];
                    for (int i = 0; i < Protocol_init[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_init[2] - 2])
                    {
                        PortByte.CopyTo(0, tempinit, 0, Protocol_init[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProInitData(tempinit, tempinit.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_init[2]);
                }
                else if (PortByte[0] == Protocol_hiscot[0] && PortByte[5] == Protocol_hiscot[1])
                {
                    //返回历史记录个数
                    if (PortByte.Count < Protocol_hiscot[2]) break;
                    byte[] temp = new byte[Protocol_hiscot[2] - 3];
                    for (int i = 0; i < Protocol_hiscot[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_hiscot[2] - 2])
                    {
                        PortByte.CopyTo(0, temphiscot, 0, Protocol_hiscot[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProHisRecordData(temphiscot, temphiscot.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_hiscot[2]);
                }
                else if (PortByte[0] == Protocol_hismsg[0] && PortByte[5] == Protocol_hismsg[1])
                {
                    //返回历史记录报文
                    if (PortByte.Count < Protocol_hismsg[2]) break;
                    byte[] temp = new byte[Protocol_hismsg[2] - 3];
                    for (int i = 0; i < Protocol_hismsg[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_hismsg[2] - 2])
                    {
                        PortByte.CopyTo(0, temphismsg, 0, Protocol_hismsg[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProHisMsgData(temphismsg, temphismsg.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_hismsg[2]);
                }
                else
                {
                    PortByte.RemoveAt(0);
                }
            }


        }

        /// <summary>
        /// 不带全电流处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="Readbits"></param>
        private void DataRecivedWithOutmA(object sender, System.IO.Ports.SerialDataReceivedEventArgs e, byte[] Readbits)
        {

            PortByte.AddRange(Readbits);
            while (PortByte.Count >= 10)
            {
                ///依次比较长度，报文头，功能码，报文接收字符

                if (PortByte[0] == Protocol_realtime[0] && PortByte[5] == Protocol_realtime[1])
                {
                    if (PortByte.Count < Protocol_realtime[2]) break;
                    //校验
                    byte[] temp = new byte[Protocol_realtime[2] - 3];
                    for (int i = 0; i < Protocol_realtime[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_realtime[2] - 2])
                    {
                        PortByte.CopyTo(0, temptime, 0, Protocol_realtime[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProTimeData2(temptime, temptime.Length);


                    }
                    else
                        PortByte.RemoveRange(0, Protocol_realtime[2]);
                }
                else if (PortByte[0] == Protocol_real[0] && PortByte[5] == Protocol_real[1])
                {
                    //返回实时数据 线获得设备的时间，在获取数据
                    if (PortByte.Count < Protocol_real[2]) break;

                    //校验
                    byte[] temp = new byte[Protocol_real[2] - 3];
                    for (int i = 0; i < Protocol_real[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_real[2] - 2])
                    {
                        PortByte.CopyTo(0, tempreal, 0, Protocol_real[2]);
                        PortByte.Clear();//清空，找到数据，清空数据
                        //返回时间了。
                        //处理temptime
                        ProDevData2(tempreal, tempreal.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_real[2]);

                }
                else if (PortByte[0] == Protocol_Action[0] && PortByte[5] == Protocol_Action[1])
                {
                    //返回动作时间
                    if (PortByte.Count < Protocol_Action[2]) break;
                    //校验
                    byte[] temp = new byte[Protocol_Action[2] - 3];
                    for (int i = 0; i < Protocol_Action[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_Action[2] - 2])
                    {
                        PortByte.CopyTo(0, tempaction, 0, Protocol_Action[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProActData2(tempaction, tempaction.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_Action[2]);

                }
                else if (PortByte[0] == Protocol_write[0] && PortByte[5] == Protocol_write[1])
                {
                    //返回写入时间
                    if (PortByte.Count < Protocol_write[2]) break;
                    byte[] temp = new byte[Protocol_write[2] - 3];
                    for (int i = 0; i < Protocol_write[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_write[2] - 2])
                    {
                        PortByte.CopyTo(0, tempwrite, 0, Protocol_write[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProWriteData2(tempwrite, tempwrite.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_write[2]);
                }
                else if (PortByte[0] == Protocol_online[0] && PortByte[5] == Protocol_online[1])
                {
                    //返回设备是否在线
                    if (PortByte.Count < Protocol_online[2]) break;
                    byte[] temp = new byte[Protocol_online[2] - 3];
                    for (int i = 0; i < Protocol_online[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_online[2] - 2])
                    {
                        PortByte.CopyTo(0, temponline, 0, Protocol_online[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProOnlineData2(temponline, temponline.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_online[2]);
                }
                else if (PortByte[0] == Protocol_init[0] && PortByte[5] == Protocol_init[1])
                {
                    //返回初始化
                    if (PortByte.Count < Protocol_init[2]) break;
                    byte[] temp = new byte[Protocol_init[2] - 3];
                    for (int i = 0; i < Protocol_init[2] - 3; i++)
                    {
                        temp[i] = PortByte[i + 1];
                    }
                    byte cs = wireProtocol.CheckCrc(temp);
                    //返回设备的时间
                    if (cs == PortByte[Protocol_init[2] - 2])
                    {
                        PortByte.CopyTo(0, tempinit, 0, Protocol_init[2]);
                        PortByte.Clear();
                        //返回时间了。
                        //处理temptime
                        ProInitData2(tempinit, tempinit.Length);
                    }
                    else
                        PortByte.RemoveRange(0, Protocol_init[2]);
                }
                #region 该协议无历史记录
                //else if (PortByte[0] == Protocol_hiscot[0] && PortByte[5] == Protocol_hiscot[1])
                //{
                //    //返回历史记录个数
                //    if (PortByte.Count < Protocol_hiscot[2]) break;
                //    byte[] temp = new byte[Protocol_hiscot[2] - 3];
                //    for (int i = 0; i < Protocol_hiscot[2] - 3; i++)
                //    {
                //        temp[i] = PortByte[i + 1];
                //    }
                //    byte cs = wireProtocol.CheckCrc(temp);
                //    //返回设备的时间
                //    if (cs == PortByte[Protocol_hiscot[2] - 2])
                //    {
                //        PortByte.CopyTo(0, temphiscot, 0, Protocol_hiscot[2]);
                //        PortByte.Clear();
                //        //返回时间了。
                //        //处理temptime
                //        ProActData(temphiscot, temphiscot.Length);
                //    }
                //    else
                //        PortByte.RemoveRange(0, Protocol_hiscot[2]);
                //}
                //else if (PortByte[0] == Protocol_hismsg[0] && PortByte[5] == Protocol_hismsg[1])
                //{
                //    //返回历史记录报文
                //    if (PortByte.Count < Protocol_hismsg[2]) break;
                //    byte[] temp = new byte[Protocol_hismsg[2] - 3];
                //    for (int i = 0; i < Protocol_hismsg[2] - 3; i++)
                //    {
                //        temp[i] = PortByte[i + 1];
                //    }
                //    byte cs = wireProtocol.CheckCrc(temp);
                //    //返回设备的时间
                //    if (cs == PortByte[Protocol_hismsg[2] - 2])
                //    {
                //        PortByte.CopyTo(0, temphismsg, 0, Protocol_hismsg[2]);
                //        PortByte.Clear();
                //        //返回时间了。
                //        //处理temptime
                //        ProActData(temphismsg, temphismsg.Length);
                //    }
                //    else
                //        PortByte.RemoveRange(0, Protocol_hismsg[2]);
                //}
                #endregion
                else
                {
                    PortByte.RemoveAt(0);
                }
            }



        }




        //这里面处理接收过来的数据的解析和存储
        //处理保温的发送，给我一串设备的序列号，然后发送报文。
        //定义几个事件来提供给父类来访问
        #region 带全电流协议处理函数 共8个处理函数
        //8个函数处理接收到的数据
        /// <summary>
        /// 处理时间函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProTimeData(byte[] da, int lenght)
        {
          
            _btime.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            CurDevT = new Timestruct();
            CurDevT.year = da[7] + 2000;
            CurDevT.mouth = da[8];
            CurDevT.day= da[9];
            CurDevT.hour = da[10];
            CurDevT.minutes = da[11];
            CurDevT.seconds = da[12];


            try
            {
                _btime.B_time = new DateTime(CurDevT.year, CurDevT.mouth, CurDevT.day, CurDevT.hour, CurDevT.minutes, CurDevT.seconds);
                _btime.number = _btime.id.ToString();
            }
            catch
            {
                _bhismsg.year = new DateTime(2000, 1, 1, 1, 1, 1).ToString();
            }
            if (_btime.number.Length % 2 != 0) _btime.number = "0" + _btime.number;
            dt = DateTime.Now;
            //处理得到设备实时时间保存，然后去获取数据
            LinkedListNode<DevBackTime> _pD = _DBtime.First;
            while (_pD != null)
            {
                //如果找到当前设备
                if (_pD.Value.dev.number == _btime.number)
                {
                    //设置时间
                    _pD.Value.btime = _btime.B_time;
                    _pD.Value.curtime = dt;
                    Istime = true;
                    break;
                }
                _pD = _pD.Next;
            }
            LinkedListNode<Dev_Real> _pR = _Real.First;
            while (_pR != null)
            {
                if (_pR.Value.dev.number == _btime.number)
                {
                    _pR.Value.Sendtime = _btime.B_time.ToString();
                    break;
                }
                _pR = _pR.Next;
            }


        }
        /// <summary>
        /// 处理实时数据函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProDevData(byte[] da, int lenght)
        {
            Isreal = true;

            _breal.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _breal.number = _breal.id.ToString();
            if (_breal.number.Length % 2 != 0) _breal.number = "0" + _breal.number;
            _breal.count = da[7];
            _breal.mA = da[8] * 256 + da[9];

            LinkedListNode<Dev_Real> _myreal = _Real.First;
            while(_myreal!=null)
            {
                if(_myreal.Value.dev.number==_breal.number)
                {
                    _myreal.Value.Count = _breal.count;
                    _myreal.Value.mA = _breal.mA;
                    _myreal.Value.backtime = DateTime.Now.ToString();
                    //存出数据
                    Dev_Real dr = _myreal.Value;
                    SaveReal_Data(dr);
                    break;
                }

                _myreal = _myreal.Next;
            }
            
        }
        /// <summary>
        /// 处理动作记录函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProActData(byte[] da, int lenght)
        {
           
            _baction.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _baction.number = _baction.id.ToString();
            if (_baction.number.Length % 2 != 0) _baction.number = "0" + _baction.number;
            _baction.count = da[7] * 256 + da[8];
            if (da[9] == 0) da[9] = 1;
            if (da[10] == 0) da[10] = 1;
            if (da[11] == 0) da[11] = 1;
            try
            {
                _baction.actime = new DateTime(da[9] + 2000, da[10], da[11], da[12], da[13], da[14]).ToString();
            }
            catch
            {
                //
                _baction.actime = new DateTime(2001,1, 1, 1, 1,1).ToString();
            }
            LinkedListNode<Dev_RecordAction> Myact = _Action.First;
            while(Myact!=null)
            {
                if(Myact.Value.dev.number==_baction.number)
                {
                    Myact.Value.num = _baction.count;
                    Myact.Value.time = _baction.actime;
                    Isaction = true;
                    Dev_RecordAction dr = Myact.Value;
                    SaveLight_Data(dr);
                    break;
                }
                Myact = Myact.Next;
            }
        }
        /// <summary>
        /// 写入时间到设备返回函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProWriteData(byte[] da, int lenght)
        {
            _bwrite.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _bwrite.number = _bwrite.id.ToString();
            if (_bwrite.number.Length % 2 != 0) _bwrite.number = "0" + _bwrite.number;
            _bwrite.code = da[7];
            _bwrite.value = da[8];
            //Iswriteok
            if (_bwrite.code == 0x00)
            {
                //da[8]年
                _bwrite.value = da[8]+2000;
                Iswriteok = true;
            }
            else if (_bwrite.code == 0x01)
            {
                //月
                Iswriteok = true;
            }
            else if (_bwrite.code == 0x02)
            {
                //日
                Iswriteok = true;
            }
            else if (_bwrite.code == 0x03)
            {
                //时
                Iswriteok = true;
            }
            else if (_bwrite.code == 0x04)
            {
                //分
                Iswriteok = true;
            }
            else if (_bwrite.code == 0x05)
            {
                //秒
                Iswriteok = true;
            }
        }
        /// <summary>
        /// 处理在线函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProOnlineData(byte[] da, int lenght)
        {
            Isline = true;
            _bonline.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _bonline.number = _bonline.id.ToString();
            if (_bonline.number.Length % 2 != 0) _bonline.number = "0" + _bonline.number;
            _bonline.Isonline = true;

        }
        /// <summary>
        /// 处理初始化函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProInitData(byte[] da, int lenght)
        {
            _binit.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _binit.number = _binit.id.ToString();
            if (_binit.number.Length % 2 != 0) _binit.number = "0" + _binit.number;
            _binit.isinit = true;
            Isinit = true;


        }
        /// <summary>
        /// 处理记录个数函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProHisRecordData(byte[] da, int lenght)
        {
           
            _bhiscot.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _bhiscot.number = _bhiscot.id.ToString();
            if (_bhiscot.number.Length % 2 != 0) _bhiscot.number = "0" + _bhiscot.number;
            _bhiscot.cicile = da[7];
            _bhiscot.count = da[8] * 256 + da[9];
            LinkedListNode<Dev_RecordHistroy> _His = _Histroy.First;
            while(_His!=null)
            {
                if(_His.Value.dev.number==_bhiscot.number)
                {
                    _His.Value.cicle=_bhiscot.cicile;
                    _His.Value.totol = _bhiscot.count;
                    _His.Value.callt = DateTime.Now.ToString();
                    Ishisco = true;
                    break;
                }
                _His = _His.Next;
            }
        }
        /// <summary>
        /// 处理历史记录函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProHisMsgData(byte[] da, int lenght)
        {
          
            _bhismsg.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _bhismsg.number = _bhismsg.id.ToString();
            if (_bhismsg.number.Length % 2 != 0) _bhismsg.number = "0" + _bhismsg.number;
            _bhismsg.Count = da[7] * 256 + da[8];
            try { 
            _bhismsg.year = new DateTime(da[9] + 2000, da[10],da[11], da[12],0,0).ToString();
            }
            catch
            {
                _bhismsg.year = new DateTime(2000, 1, 1,1, 1, 1).ToString();
            }
            _bhismsg.mA = da[13] * 256 + da[14];
          

            LinkedListNode<Dev_RecordHistroy> _Hsg = _Histroy.First;
            while (_Hsg != null)
            {
                if (_Hsg.Value.dev.number == _bhismsg.number)
                {
                    _Hsg.Value.Count = _bhismsg.Count;
                    _Hsg.Value.mA = _bhismsg.mA;
                    _Hsg.Value.recordt = _bhismsg.year;
                    Ishimsg = true;
                    Dev_RecordHistroy dr = _Hsg.Value;
                    SaveHis_Data(dr);
                    break;
                }
                _Hsg = _Hsg.Next;
            }

        }
        #endregion
        #region 不带全电流协议处理函数 共6个处理函数
        /// <summary>
        /// 处理时间函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProTimeData2(byte[] da, int lenght)
        {
 
            _btime.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            CurDevT = new Timestruct();
            CurDevT.year = da[7] + 2000;
            CurDevT.mouth = da[8];
            CurDevT.day = da[9];
            CurDevT.hour = da[10];
            CurDevT.minutes = da[11];
            CurDevT.seconds = da[12];
            _btime.B_time = new DateTime(CurDevT.year, CurDevT.mouth, CurDevT.day, CurDevT.hour, CurDevT.minutes, CurDevT.seconds);
      
            _btime.number = _btime.id.ToString();
            if (_btime.number.Length % 2 != 0) _btime.number = "0" + _btime.number;
            dt = DateTime.Now;
            //处理得到设备实时时间保存，然后去获取数据
            LinkedListNode<DevBackTime> _pD = _DBtime.First;
            while (_pD != null)
            {
                //如果找到当前设备
                if (_pD.Value.dev.number == _btime.number)
                {
                    //设置时间
                    _pD.Value.btime = _btime.B_time;
                    _pD.Value.curtime = dt;
                    Istime = true;
                    break;
                }
                _pD = _pD.Next;
            }
            LinkedListNode<Dev_Real> _pR = _Real.First;
            while (_pR != null)
            {
                if (_pR.Value.dev.number == _btime.number)
                {
                    _pR.Value.Sendtime = _btime.B_time.ToString();
                    break;
                }
                _pR = _pR.Next;
            }

        }
        /// <summary>
        /// 处理实时数据函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProDevData2(byte[] da, int lenght)
        {

            Isreal = true;
            _breal.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _breal.number = _breal.id.ToString();
            if (_breal.number.Length % 2 != 0) _breal.number = "0" + _breal.number;
            _breal.count = da[7];
            _breal.mA = 0;
            LinkedListNode<Dev_Real> _myreal = _Real.First;
            while (_myreal != null)
            {
                if (_myreal.Value.dev.number == _breal.number)
                {
                    _myreal.Value.Count = _breal.count;
                    _myreal.Value.mA = _breal.mA;
                    _myreal.Value.backtime = DateTime.Now.ToString();
                    //存出数据
                    //Isreal = true;
                    Dev_Real dr = _myreal.Value;
                    SaveReal_Data(dr);
                    break;
                }

                _myreal = _myreal.Next;
            }
        }
        /// <summary>
        /// 处理动作记录函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProActData2(byte[] da, int lenght)
        {
             
            _baction.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _baction.number = _baction.id.ToString();
            if (_baction.number.Length % 2 != 0) _baction.number = "0" + _baction.number;
            _baction.count = da[7] * 256 + da[8];
            if (da[9] == 0) da[9] = 1;
            if (da[10] == 0) da[10] = 1;
            if (da[11] == 0) da[11] = 1;
            _baction.actime = new DateTime(da[9] + 2000, da[10], da[11], da[12], da[13],da[14]).ToString();
            LinkedListNode<Dev_RecordAction> Myact = _Action.First;
            while (Myact != null)
            {
                if (Myact.Value.dev.number == _baction.number)
                {
                    Myact.Value.num = _baction.count;
                    Myact.Value.time = _baction.actime;
                    Isaction = true;
                    Dev_RecordAction dr = Myact.Value;
                    SaveLight_Data(dr);
                    break;
                }
                Myact = Myact.Next;
            }
        }
        /// <summary>
        /// 写入时间到设备返回函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProWriteData2(byte[] da, int lenght)
        {
            _bwrite.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _bwrite.number = _bwrite.id.ToString();
            if (_bwrite.number.Length % 2 != 0) _bwrite.number = "0" + _bwrite.number;
            _bwrite.code = da[7];
            _bwrite.value = da[8];
            //Iswriteok
            if (_bwrite.code == 0x00)
            {
                //da[8]年
                _bwrite.value = da[8] + 2000;
                Iswriteok = true;
            }
            else if (_bwrite.code == 0x01)
            {
                //月
                Iswriteok = true;
            }
            else if (_bwrite.code == 0x02)
            {
                //日
                Iswriteok = true;
            }
            else if (_bwrite.code == 0x03)
            {
                //时
                Iswriteok = true;
            }
            else if (_bwrite.code == 0x04)
            {
                //分
                Iswriteok = true;
            }
            else if (_bwrite.code == 0x05)
            {
                //秒
                Iswriteok = true;
            }
        }
        /// <summary>
        /// 处理在线函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProOnlineData2(byte[] da, int lenght)
        {
            Isline = true;
            _bonline.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _bonline.number = _bonline.id.ToString();
            if (_bonline.number.Length % 2 != 0) _bonline.number = "0" + _bonline.number;
            _bonline.Isonline = true;
        }
        /// <summary>
        /// 处理初始化函数
        /// </summary>
        /// <param name="da">数据</param>
        /// <param name="lenght">数据数组长度</param>
        private void ProInitData2(byte[] da, int lenght)
        {
            _binit.id = da[1] * 256 * 256 * 256 + da[2] * 256 * 256 + da[3] * 256 + da[4];
            _binit.number = _binit.id.ToString();
            if (_binit.number.Length % 2 != 0) _binit.number = "0" + _binit.number;
            _binit.isinit = true;
            Isinit = true;
        }
        #endregion


        public bool  Mywrite(string add,out string msg)
        {
            msg = string.Empty;
            byte[] addr  = Sequence.SeqStrToByte(add, ref msg);
            if (addr == null) return false;
            bool isok =false;
            DateTime mt = DateTime.Now;
            byte[] sendmt;
            int[] sendd = new int[6];
            sendd[0] =mt.Year - 2000;
            sendd[1] = mt.Month;
            sendd[2] =mt.Day;
            sendd[3] =mt.Hour;
            sendd[4] =mt.Minute;
            sendd[5] =mt.Second;
            //依次写入时间
            for(int i=0;i<6;i++)//循环写入时间的6个值
            {
                for (int j = 0; j <2; j++)
                {
                    if (Iswriteok == false)
                    {
                        if (j >= 1)
                        {
                            isok = false;
                           
                        }
                        else
                        {
                            sendmt = wireProtocol.WriteMsg(addr, i, sendd[i]);
                            SendData(sendmt, 0, sendmt.Length);
                            Delaytime.Delay(interval_T);
                        }
                    }
                    else
                    {
                        Iswriteok =false;
                        isok = true;
                        break;
                    }
                }
                if(isok==false)
                {
                    if(i==0)
                    {
                        msg = "写入设备（年份）时间错误";
                    }
                    else if(i==1)
                    {
                        msg = "写入设备（月份）时间错误";
                    }
                    else if (i == 2)
                    {
                        msg = "写入设备（日份）时间错误";
                    }
                    else if (i == 3)
                    {
                        msg = "写入设备（小时）时间错误";
                    }
                    else if (i == 4)
                    {
                        msg = "写入设备（分钟）时间错误";
                    }
                    else if (i == 5)
                    {
                        msg = "写入设备（秒）时间错误";
                    }
             
                    break;
                }
            }

            return isok;
        }
        public bool Mywrite(string add, out string msg,DateTime mt)
        {
            msg = string.Empty;
            byte[] addr = Sequence.SeqStrToByte(add, ref msg);
            if (addr == null) return false;
            bool isok = false;
            byte[] sendmt;
            int[] sendd = new int[6];
            sendd[0] = mt.Year - 2000;
            sendd[1] = mt.Month;
            sendd[2] = mt.Day;
            sendd[3] = mt.Hour;
            sendd[4] = mt.Minute;
            sendd[5] = mt.Second;
            //依次写入时间
            for (int i = 0; i < 6; i++)//循环写入时间的6个值
            {
                for (int j = 0; j < 2; j++)
                {
                    if (Iswriteok == false)
                    {
                        if (j >= 1)
                        {
                            isok = false;

                        }
                        else
                        {
                            sendmt = wireProtocol.WriteMsg(addr, i, sendd[i]);
                            SendData(sendmt, 0, sendmt.Length);
                            Delaytime.Delay(interval_T);
                        }
                    }
                    else
                    {
                        Iswriteok = false;
                        isok = true;
                        break;
                    }
                }
                if (isok == false)
                {
                    if (i == 0)
                    {
                        msg = "写入设备（年份）时间错误";
                    }
                    else if (i == 1)
                    {
                        msg = "写入设备（月份）时间错误";
                    }
                    else if (i == 2)
                    {
                        msg = "写入设备（日份）时间错误";
                    }
                    else if (i == 3)
                    {
                        msg = "写入设备（小时）时间错误";
                    }
                    else if (i == 4)
                    {
                        msg = "写入设备（分钟）时间错误";
                    }
                    else if (i == 5)
                    {
                        msg = "写入设备（秒）时间错误";
                    }

                    break;
                }
            }

            return isok;
        }
        internal BackState InitDev(string CurrentNumber)
        {
            BackState ok = BackState.No;
            string msg="";
            byte[] add = Sequence.SeqStrToByte(CurrentNumber,ref msg);
            if(add==null)
            {
                System.Windows.Forms.MessageBox.Show(msg);
                ok = BackState.Err;
                return ok;
            }
            byte[] sendp = wireProtocol.InitDevice(add);
            if(sendp!=null)
            {
                for (int i = 0; i < 3; i++)
                {
                    //发送设备初始化代码
                    if(Isinit)
                    {
                        Isinit = false;
                        ok = BackState.Yes;
                        break;
                    }
                    else
                    {
                        this.SendData(sendp, 0, sendp.Length);
                        ok = BackState.No;
                       // System.Threading.Thread.Sleep(4000);
                        Delaytime.Delay(interval_T);
                    }                  
                }
                if(ok==BackState.No)
                {
                    ok = BackState.Err;
                }
            }
            

            return ok;
        }

        internal BackState sendOneReal(string CurrentNumber)
        {
            string msg = "";
            BackState bs = new BackState();
            bs = BackState.No;
            byte[] add = Sequence.SeqStrToByte(CurrentNumber, ref msg);
            
            if (add == null)
            {
               
              //  System.Windows.Forms.MessageBox.Show(msg);
                bs = BackState.Err;   
                return bs ;
            }
            byte[] sendp = wireProtocol.RealMsg(add);
            if (sendp!=null)
            {
                //实时数据招测
                for(int i=0;i<2;i++)
                {
                    if(Isreal)
                    {
                        Isreal = false;
                        bs = BackState.Yes;
                        break;
                    }
                    else
                    {
                        if(i>=1)
                        {
                            
                             bs = BackState.Err;
                             break;
                        }
                        this.SendData(sendp, 0, sendp.Length);
                        Delaytime.Delay(InterReal);
                    }
                }
            }
            return bs;
        }

        internal BackState SendOneHistroy(string num,out string msg,out int totol)//设备序列，设备消息，总次数
        {
            msg = string.Empty;
            totol = 0;
            BackState bs = new BackState();
            bs= BackState.No;
            byte[] add = Sequence.SeqStrToByte(num, ref msg);
            if (add == null)
            {
               // System.Windows.Forms.MessageBox.Show(msg);
               
                bs= BackState.Err;
                return bs;
            }
            byte[] sendp = wireProtocol.HistroyCout(add);
            if(sendp==null)
            {
                msg = "发送指令不正确，由不正确序列号导致";
                bs = BackState.Err;
                return bs;
            }

            for(int i=0;i<2;i++)
            {
                if(Ishisco)
                {
                    Ishisco = false;
                    bs = BackState.Yes;
                    break;
                }
                else
                {
                    if (i >= 1)
                    {
                        bs = BackState.Err;
                        break;
                    }
                    else
                    {
                        this.SendData(sendp, 0, sendp.Length);
                        Delaytime.Delay(interval_T);
                    }
                }
            }
            if(bs==BackState.Err)
            {
                msg = "没有查询到历史记录的总条数,请重新点击";
                return bs; //如果没有招到历史记录的次数，则返回，否则继续
            }
            //获取记录次数
            //然后获取次数
            int a = _bhiscot.cicile;
            if (a >= 255)
            {

                msg = "当前历史记录没有存储数据或存储溢出";

                return bs;
            }
            int b = _bhiscot.count;
            if (b > Ciclenumber) //大于1440(条)
            {
                #region 大于1440条
                byte[] sendt;
                int cout = b- Ciclenumber * a; //计算真的的记录次数,从cout开始
                totol =b;
                msg = "";
                for (int i = cout; i <= cout + Ciclenumber; i++)
                {
                    
                    sendt = wireProtocol.HistroyMsg(add, i);
                    
                    for(int j=0;j<2;j++) //没个记录发一次，超过一次记录，则提示有数据不完整
                    {
                        if (Ishimsg)
                        {
                            Ishimsg = false;
                            break;
                        }
                        else
                        {
                            if(j>=1)
                            {
                                msg += "Error：第" + i.ToString() + "条历史记录数据没有收到。\r\n";
                                break;
                            }
                            else
                            {
                  
                                this.SendData(sendt, 0, sendt.Length);
                                Delaytime.Delay(interval_T);
                            }
                          
                        }
                    }

                }
                #endregion 
            }
            else
            {
                #region 小于1440
                int cout = b ;
                totol = b;
                if (totol == 0)
                    msg = "设备没有历史记录";
                else
                    msg = "";

                byte [] sendt;
                for (int i = 1; i < cout +1; i++)
                {
                    sendt = wireProtocol.HistroyMsg(add, i);
                    for (int j = 0; j < 2; j++)
                    {
                        if (Ishimsg)
                        {
                            Ishimsg = false;
                            break;
                        }
                        else
                        {
                            if (j >= 1)
                            {
                                //
                                msg += "第" + i.ToString() + "条历史记录没有收到。\r\n";
                                break;
                            }
                            else
                            {
                                this.SendData(sendt, 0, sendt.Length);

                                Delaytime.Delay(interval_T);
                            }
          
                        }
                    }

                }
                #endregion
            }
            
            //发送本设备历史数据
            return bs;
        }


        ///数据存储
        ///
        #region 存储数据
        private void SaveReal_Data(Dev_Real dr)
        {
         
            string str= "select * from Dev_Real where Dev_ID='"+dr.dev.number+"'";
            DataTable dt = Save.ReturnTable(str); 
            if (dt.Rows.Count>0)
            {
                //有记录
                //查询上次的记录的动作次数
                 string old = dt.Rows[0]["Dev_Num"].ToString();//获取上次的动作记录
                 str = "update Dev_Real set Dev_Num ="+dr.Count+",Dev_OldNum ="+ old +",Dev_mA = "+dr.mA+",Dev_Time='"+dr.Sendtime+"',Dev_Loadtime='"+dr.backtime+"' where Dev_ID='" + dr.dev.number + "'";
                 Save.Insert(str);
            }
            else
            {
                //无记录
                string old = "0";
                str = "insert into Dev_Real(Dev_ID,Dev_Addr,Dev_Phase,Dev_Num,Dev_OldNum,Dev_mA,Dev_Time,Dev_Loadtime) Values('"+dr.dev.number+"','"+dr.dev.addr+"','"+dr.dev.phase+"',"+dr.Count+",'"+ old +"',"+dr.mA+",'"+dr.Sendtime+"','"+dr.backtime+"')";
                Save.Insert(str);
            }

        }
  
        private void  SaveLight_Data(Dev_RecordAction dr)
        {
            string str = "insert into DevLight_Histroy(Dev_ID,Dev_Addr,Dev_Phase,Dev_Num,Dev_Time) Values('"+dr.dev.number+"','"+dr.dev.addr+"','"+dr.dev.phase+"',"+dr.num+",'"+dr.time+"')";
            string str3 = "SELECT DevLight_Histroy.Dev_ID, DevLight_Histroy.Dev_Num, DevLight_Histroy.Dev_Time FROM DevLight_Histroy Where DevLight_Histroy.Dev_ID='" + dr.dev.number + "'AND DevLight_Histroy.Dev_Num='"+dr.num+"'";
            DataTable de = Save.ReturnTable(str3);
            if(de.Rows.Count>0)
            {
                return;
            }
            else
            {
                Save.Insert(str);
            }
          
        }
        private void SaveHis_Data(Dev_RecordHistroy dr)
        {
            string str = "insert into DevmA_Histroy(Dev_ID,Dev_Addr,Dev_Phase,Dev_Num,Dev_mA,Dev_Time,Dev_Total,Dev_Loadtime) Values('" + dr.dev.number + "','" + dr.dev.addr + "','" + dr.dev.phase + "'," + dr.Count + ","+dr.mA+",'" + dr.recordt+"',"+dr.totol+",'"+dr.callt+"')";

            string str3 = "SELECT DevmA_Histroy.Dev_ID, DevmA_Histroy.Dev_Time FROM DevmA_Histroy where DevmA_Histroy.Dev_ID = '" + dr.dev.number + "'AND DevmA_Histroy.Dev_Num= '" +dr.Count + "' AND DevmA_Histroy.Dev_Time='" + dr.recordt + "'";
            DataTable de = Save.ReturnTable(str3);
            if (de.Rows.Count > 0)
            {
                ///
            }
            else
            {
                Save.Insert(str);
            }
          
        }
        #endregion

        internal bool Query_Light(int count, string CurrentNumber,out string err)
        {
            err = string.Empty;
            bool bs = false;
            byte[] add = Sequence.SeqStrToByte(CurrentNumber, ref err);
            if (add == null)
            {
               // System.Windows.Forms.MessageBox.Show(msg);
                return bs;
            }
            for (int i = 1; i <= count;i++)
            {
                byte[] send = wireProtocol.ActionMsg(add,i);
                for (int j = 0; j < 2; j++)
                {
                    if (Isaction)
                    {
                        Isaction = false;
                        bs = true;
                        break;
                    }
                    else
                    {
                        if (j >= 1) 
                        {
                            bs = false;
                            break;
                        }
                        else
                        {
                            this.SendData(send, 0, send.Length); 
                            Delaytime.Delay(interval_T);
                        }
                     
                    }
                }

                if(bs==false)
                {
                    err = "第"+i.ToString()+"历史数据记录获取失败";
                    break;

                }

            }
            return bs;
        }

        internal bool Query_Light2(string CurrentNumber, int count,int start, out string err)
        {
            err = string.Empty;
            bool bs = false;
            byte[] add = Sequence.SeqStrToByte(CurrentNumber, ref err);
            if (add == null)
            {
                // System.Windows.Forms.MessageBox.Show(msg);
                return bs;
            }
            err = null;
            for (int i = start+1; i <= count; i++)
            {
                byte[] send = wireProtocol.ActionMsg(add, i);
                for (int j = 0; j < 2; j++)
                {
                    if (Isaction)
                    {
                        Isaction = false;
                        bs = true;
                        break;
                    }
                    else
                    {
                        if (j >= 1)
                        {
                            bs = false;
                            break;
                        }
                        else
                        {
                            this.SendData(send, 0, send.Length);
                            Delaytime.Delay(interval_T);
                        }

                    }
                 }

                if (bs == false)
                {
                    err += "第" + i.ToString() + "条历史数据记录获取失败\r\n";
                    
                }

            }
            return bs;
        }
        internal bool SendMultitermRealData(string  number,out string err)
        {


            
            err = string.Empty;
            bool bs = false;
            byte[] add = Sequence.SeqStrToByte(number, ref err);
               if (add != null)
                {
                        byte[] sendp = wireProtocol.RealMsg(add);
                        if (sendp != null)
                        {
                            //发送一组设备的数据
                            for (int i = 0; i < 2; i++)
                            {
                                if (Isreal)
                                {
                                    Isreal = false;
                                    bs = true;
                                    break;
                                }
                                else
                                {
                                    if (i >= 1)
                                    {
                                        err = "数据获取失败";
                                        bs = false;
                                        break;
                                    }
                                    else
                                    {
                                        this.SendData(sendp, 0, sendp.Length);
                                        Delaytime.Delay(InterReal);
                                    }
                                }
                            }
                        }
                       else
                        {
                            err = "发送指令错误";

                        }
                  }
                  else
                 {
                     err="设备序列不正确";
                 }
   
            return bs;
        }
        internal void RefreshList(LinkedList<Device> _PData)
        {
            //刷新列表
            LinkedListNode<Device> _pd = _PData.First;
            _Real.Clear();
            _Histroy.Clear();
            _Action.Clear();
            _DBtime.Clear();

            while (_pd != null)
            {
                Dev_Real devreal = new Dev_Real();
                Dev_RecordAction devaction = new Dev_RecordAction();
                Dev_RecordHistroy devhistroy = new Dev_RecordHistroy();
                DevBackTime devback = new DevBackTime();
                devreal.dev = _pd.Value;
                devaction.dev = _pd.Value;
                devhistroy.dev = _pd.Value;
                devback.dev = _pd.Value;


                _Real.AddLast(devreal);
                _Action.AddLast(devaction);
                _Histroy.AddLast(devhistroy);
                _DBtime.AddLast(devback);

                _pd = _pd.Next;
            }
        }

        internal BackState SerchLight(LinkedList<downdata> de)
        {
            BackState f = BackState.No;
            LinkedListNode<downdata> _pf = de.First;

            while(_pf!=null)
            {
                string msg = "";
                byte[] add = Sequence.SeqStrToByte(_pf.Value.id, ref msg);
                if (add == null)
                {
                    _pf = _pf.Next;
                    return f;
                }
                for (int i = _pf.Value.indexf; i <= _pf.Value.count; i++)
                {
                    byte[] send = wireProtocol.ActionMsg(add, i);
                    for (int j = 0; j < 2; j++)
                    {
                        if (Isaction)
                        {
                            Isaction = false;
                            f = BackState.Yes;
                            break;
                        }
                        else
                        {
                            this.SendData(send, 0, send.Length);
                            f = BackState.No;
                            Delaytime.Delay(interval_T);
                        }
                    }
                }
                _pf = _pf.Next;

            }
            f = BackState.Yes;


            return f;
        }

        public bool SendTime(string CurrentNumber)
        {
            string msg = "";
            bool ok = false;
            byte[] add = Sequence.SeqStrToByte(CurrentNumber, ref msg);

            if (add == null)
            {             
                return false;
            }
            byte[] sendt = wireProtocol.RealtimeMsg(add);

            if (sendt != null)
            {

                for (int i = 0; i < 2; i++)
                {
                    if (Istime)
                    {
                        Istime = false;
                        ok = true;
                        break;
                    }
                    else
                    {
                        if (i >= 1)
                        {
                            ok = false;
                        }
                        else
                        {
                            this.SendData(sendt, 0, sendt.Length);
                            Delaytime.Delay(interval_T);
                        }
                    }
                }
            }
           
         return ok;
            
        }

        internal BackState SendOneHistroy(string number, int daynum, out string err, out int num)
        {
            err = string.Empty;
            num = 0;
            BackState bs = new BackState();
            bs = BackState.No;
            byte[] add = Sequence.SeqStrToByte(number, ref err);
            if (add == null)
            {
                bs = BackState.Err;
                return bs;
            }
            byte[] sendp = wireProtocol.HistroyCout(add);
            if (sendp == null)
            {
                err = "发送指令不正确，由不正确序列号导致";
                bs = BackState.Err;
                return bs;
            }

            for (int i = 0; i < 2; i++)
            {
                if (Ishisco)
                {
                    Ishisco = false;
                    bs = BackState.Yes;
                    break;
                }
                else
                {
                    if (i >= 1)
                    {
                        bs = BackState.Err;
                        break;
                    }
                    else
                    {
                        this.SendData(sendp, 0, sendp.Length);
                        Delaytime.Delay(interval_T);
                    }
                }
            }
            if (bs == BackState.Err)
            {
                err = "没有查询到历史记录的总条数,请重新点击";
                return bs; //如果没有招到历史记录的次数，则返回，否则继续
            }
            //获取记录次数
            //然后获取次数
            int a = _bhiscot.cicile;
            if (a >= 255)
            {

                err= "当前历史记录没有存储数据或存储溢出";

                return bs;
            }
            int b = _bhiscot.count;
            if (b > Ciclenumber) //大于1440(条)
            {
                #region 大于1440条
                byte[] sendt;
                int cout = b - Ciclenumber * a; //计算真的的记录次数,从cout开始
                num = b;
                err = "";
                int startcount = 1;
                if (num - daynum > 0)
                {
                    startcount = num - daynum;
                }
                for (int i = startcount; i <= cout + Ciclenumber; i++)
                {

                    sendt = wireProtocol.HistroyMsg(add, i);

                    for (int j = 0; j < 2; j++) //没个记录发一次，超过一次记录，则提示有数据不完整
                    {
                        if (Ishimsg)
                        {
                            Ishimsg = false;
                            break;
                        }
                        else
                        {
                            if (j >= 1)
                            {
                                err += "Error：第" + i.ToString() + "条历史记录数据没有收到。\r\n";
                                break;
                            }
                            else
                            {

                                this.SendData(sendt, 0, sendt.Length);
                                Delaytime.Delay(interval_T);
                            }

                        }
                    }

                }
                #endregion
            }
            else
            {
                #region 小于1440
                int cout = b;
                num = b;
                if (num == 0)
                    err = "设备没有历史记录";
                else
                    err = "";

                byte[] sendt;
                int startcount = 1;
                if(num-daynum>0 )
                {
                    startcount = num - daynum;
                }

                for (int i = startcount; i < cout + 1; i++)
                {
                    sendt = wireProtocol.HistroyMsg(add, i);
                    for (int j = 0; j < 2; j++)
                    {
                        if (Ishimsg)
                        {
                            Ishimsg = false;
                            break;
                        }
                        else
                        {
                            if (j >= 1)
                            {
                                //
                                err += "第" + i.ToString() + "条历史记录没有收到。\r\n";
                                break;
                            }
                            else
                            {
                                this.SendData(sendt, 0, sendt.Length);

                                Delaytime.Delay(interval_T);
                            }

                        }
                    }

                }
                #endregion
            }

            //发送本设备历史数据
            return bs;
        }
    }
}
