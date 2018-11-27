using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication.Core;

namespace Protocol.Core
{
    /// <summary>
    /// 串口报文处理
    /// </summary>
    /// <param name="isSend">true:发送 false:接收</param>
    /// <param name="msg">报文</param>
    public delegate void MsgHander(bool isSend, string msg);

    public abstract class IProtocol
    {
        //声明报文处理事件
        public static event MsgHander MsgEvent;

        protected static string _portName = "COM1";
        protected static int _baudRate = 2400;

        private readonly string _4FEString = "FEFEFEFE";//在主站发送帧信息之前，先发送4个字节FEH， 以唤醒接收方

        /// <summary>
        /// 串口号
        /// </summary>
        public static string PortName
        {
            get
            {
                return _portName;
            }
            set
            {
                if (value.Substring(0, 3).ToUpper() == "COM")
                {
                    _portName = value;
                }
            }
        }

        /// <summary>
        /// 波特率
        /// </summary>
        public static int BaudRate
        {
            get
            {
                return _baudRate;
            }
            set
            {
                if (value > 0)
                {
                    _baudRate = value;
                }
            }
        }

        /// <summary>
        /// 判断是否读完
        /// </summary>
        /// <param name="frm">报文</param>
        /// <returns>bool类型</returns>
        protected abstract bool ReceiveFinishJudge(byte[] frm);

        /// <summary>
        /// 分析报文
        /// </summary>
        /// <param name="frm">报文</param>
        protected abstract void AnayzeFrm(string frm);

        protected virtual bool Send(string str)
        {
			bool ret = false;
            str = _4FEString + str;//根据645协议，加4个FE通讯会好很多
			try
			{
				SerialPortCom _sp = new SerialPortCom(_portName, _baudRate);
				_sp.ReceiveFinishEven += ReceiveFinishJudge;

                ret = _sp.Send(str);
                if (MsgEvent != null)
                {
                    MsgEvent(true, str);
                }
			}
			catch(Exception ex)
			{
				throw ex;
			}
            return ret;
        }

        protected virtual string SendAndRec(string str)
        {
			string ret = string.Empty;
            str = _4FEString + str;//根据645协议，加4个FE通讯会好很多
			try
			{
				SerialPortCom _sp = new SerialPortCom(_portName, _baudRate);
				_sp.ReceiveFinishEven += ReceiveFinishJudge;
                ret = _sp.SendAndReceive(str);
                if (MsgEvent != null)
                {
                    MsgEvent(true, str);
                    MsgEvent(false, ret);
                }
				AnayzeFrm(ret);
			}
			catch(Exception ex)
			{
				throw ex;
			}
            
            return ret;
        }

        
    }
}
