using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationProtocol
{
    public interface Iprotocol:Iportocol_Head,Iprotocol_Body,IprotocolVersion
    {
        /// <summary>
        /// 协议初始化
        /// </summary>
    }
}
