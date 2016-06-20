using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationProtocol
{
    public  class SequenceWithStrToByte
    {
        private ulong minvalue = 16777216;
        private ulong maxvalue = 4294967295;
        public  byte [] SeqStrToByte(string number ,ref string msg)
        {
            byte[] temp=null;
            if(isNumberic(number)==false)
            {
                msg = "序列号不正确，必须全部为数字";
                return null;
            }
            if(number.Length<8)
            {
                msg = "序列号长度过短，请使用长度为8位以上的数字序列号";
                return null;
            }
            else
            {
                ulong result = ulong.Parse(number);
                if (result > maxvalue || result < minvalue)
                {
                    msg = "序列号数字过大。请使用8位以上且小于4294967296大于16777216的数字序列";
                    return null;
                }

                //将数字转换为16进制的字符串
                number=Convert.ToInt64(number).ToString("X");
               // number = String.Format("{0:X}", number);
                //隔开字符，以空格代替
                number = number.Replace(" ","");
                if((number.Length%2)!=0)
                {
                    number ="0"+number ;
                }
                if (number.Length != 8) 
                {
                    msg = "序列号不对，长度是8，请确保转换后的16进制长度为8或7";
                    return null;
                }
                temp = new byte[number.Length / 2];
                for(int i=0;i<temp.Length;i++)
                {
                    temp[i] = Convert.ToByte(number.Substring(i * 2, 2), 16);
                }
            }
            msg ="ok";
            return temp;

        }


        public  bool isNumberic(string message)
        {
            System.Text.RegularExpressions.Regex rex =
            new System.Text.RegularExpressions.Regex(@"^\d+$");
            ulong  result = 0;
            if (message == null) return false;
            if (rex.IsMatch(message))
            {
                result = ulong.Parse(message);
                return true;
            }
            else
                return false;
        }

        public string SeqByteToStr(byte [] Addr ,ref string msg)
        {
            string temp=null;
            if (Addr.Length != 4)
            {
                msg = "地址位数不正确，必须为4位的16进制数";
                return temp;
            }         
           long t = Addr[0] * 256 * 256 * 256 + Addr[1] * 256 * 256 + Addr[2] * 256 + Addr[3];
            temp = t.ToString();
            if(temp.Length%2!=0)
            {
                temp = "0" + temp;
            }
            return temp;
        }
    }
}
