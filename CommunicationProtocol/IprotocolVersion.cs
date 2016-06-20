using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationProtocol
{
   public interface IprotocolVersion
    {
        /// <summary>
        /// 协议名称
        /// </summary>
        string Name{get;set;}
        /// <summary>
        /// 协议版本
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// 协议说明
        /// </summary>
        string Instruction { get; set; }

 
     
    }
}
