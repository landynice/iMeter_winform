using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPESAM.Core
{
    public class EsamState
    {
        /// <summary>
        /// 0成功，其它失败
        /// </summary>
        public int StateData
        { get; set; }


        public string StateDataMessage
        {
            get
            {
                if (StateData == 0)
                {
                    return "成功";
                }
                else if (StateData == 45)
                {
                    return "密码机密钥错";
                }
                else if (StateData == 48)
                {
                    return "无设备或设备无效";
                }
                else if (StateData == 56)
                {
                    return "创建socket句柄失败";
                }
                else if (StateData == 57)
                {
                    return "连接服务器失败";
                }
                else if (StateData == 64)
                {
                    return "客户端发送数据失败";
                }
                else if (StateData == 65)
                {
                    return "客户端接收数据失败";
                }
                else if (StateData == 100)
                {
                    return "打开设备失败";
                }
                else if (StateData == 160)
                {
                    return "连接密码机失败";
                }
                else if (StateData == 161)
                {
                    return "操作权限不够";
                }
                else if (StateData == 162)
                {
                    return "USBKey不是操作员";
                }
                else if (StateData == 163)
                {
                    return "服务器发送数据失败";
                }
                else if (StateData == 164)
                {
                    return "服务端接收报文失败";
                }
                else if (StateData == 165)
                {
                    return "密码机加密数据失败";
                }
                else if (StateData == 166)
                {
                    return "密码机导出密钥失败";
                }
                else if (StateData == 167)
                {
                    return "密码机计算MAC失败";
                }
                else if (StateData == 168)
                {
                    return "服务器已断开连接";
                }
                else if (StateData == 169)
                {
                    return "数据无效";
                }
                else if (StateData == 170)
                {
                    return "密码机收发报文错误";
                }
                else if (StateData == 171)
                {
                    return "密码机故障";
                }
                else if (StateData == 172)
                {
                    return "数据库出错";
                }
                else if (StateData >= 700 && StateData <= 712)
                {
                    return "客户端导出密钥失败";
                }
                else if (StateData >= 800 && StateData <= 810)
                {
                    return "计算MAC失败";
                }
                else if (StateData >= 900 && StateData <= 910)
                {
                    return "加密数据失败";
                }
                else if (StateData >= 1000 && StateData <= 1010)
                {
                    return "数据长度错";
                }
                else if (StateData == 1100)
                {
                    return "USBKey权限不正确";
                }
                else if (StateData == 1107)
                {
                    return "系统认证错误";
                }
                else if (StateData >= 1108 && StateData <= 1111)
                {
                    return "操作USBKey失败";
                }
                else if (StateData == 1206)
                {
                    return "签名数据错误";
                }
                else
                {
                    return "其它错误";
                }
            }
        }

        public bool ResultState
        {
            get
            {
                return (StateData == 0);
            }
        }
        /// <summary>
        /// 执行信息
        /// </summary>
        public string Message
        { get; set; }

        public EsamState(int stateData)
        {
            StateData = stateData;
        }

        public EsamState(int stateData,string message)
        {
            StateData = stateData;
            Message = message;
        }
    }

    /// <summary>
    /// 返回一个数据的Esam操作结果
    /// </summary>
    public class OneDataEsamState : EsamState
    {
        /// <summary>
        /// 数据数
        /// </summary>
        public string EsamData
        { get; set; }

        public OneDataEsamState(int stateData, string data)
            : base(stateData)
        {
            EsamData = data;
        }

        public OneDataEsamState(int stateData, string message, string data)
            : base(stateData, message)
        {
            EsamData = data;
        }
    }

    /// <summary>
    /// 返回身份认证函数的Esam操作结果
    /// </summary>
    public class IdentityAuthenticationState : EsamState
    {
        /// <summary>
        /// 数据数1
        /// </summary>
        public string OutRand
        { get; set; }

        /// <summary>
        /// 数据数2
        /// </summary>
        public string OutEndata
        { get; set; }

        public IdentityAuthenticationState(int stateData, string outRand, string outEndata)
            : base(stateData)
        {
            OutRand = outRand;
            OutEndata = outEndata;
        }

        public IdentityAuthenticationState(int stateData, string message)
            : base(stateData)
        {
        }
    }
    /// <summary>
    /// 主站会话协商Esam操作结果
    /// </summary>
    public class InitSessionState : EsamState
    {
        /// <summary>
        /// 主站随机数（16Byte）
        /// </summary>
        public string OutRandHost
        { get; set; }
        /// <summary>
        /// 会话协商数据，建立应用连接中的密文1
        /// </summary>
        public string OutSessionInit
        { get; set; }
        /// <summary>
        /// 协商数据签名(4Byte)，建立应用连接中的客户机签名1
        /// </summary>
        public string OutSign
        { get; set; }

        public InitSessionState(int stateData, string outRandHost, string outSessionInit, string outSign)
            : base(stateData)
        {
            OutRandHost = outRandHost;
            OutSessionInit = outSessionInit;
            OutSign = outSign;
        }

        public InitSessionState(int stateData, string message)
            : base(stateData, message)
        {
        }
    }
    /// <summary>
    /// 上报数据验证Esam操作结果
    /// </summary>
    public class VerifyReportDataState : EsamState
    {
        /// <summary>
        /// 明文数据，iOperateMode=1，为空
        /// </summary>
        public string OutData
        { get; set; }
        /// <summary>
        /// 主动上报随机数
        /// </summary>
        public string OutRSPCTR
        { get; set; }

        public VerifyReportDataState(int stateData, string outData, string outRSPCTR)
            : base(stateData)
        {
            OutData = outData;
            OutRSPCTR = outRSPCTR;
        }
        public VerifyReportDataState(int stateData, string message)
            : base(stateData, message)
        {
        }
    }
    /// <summary>
    /// 加密Esam操作结果
    /// </summary>
    public class GetResponseDataState : EsamState
    {
        /// <summary>
        /// 安全标识，4字节
        /// </summary>
        public string OutSID
        { get; set; }
        /// <summary>
        /// SID的附加数据,不小于2字节
        /// </summary>
        public string OutAttachData
        { get; set; }
        /// <summary>
        /// 数据，明文或密文数据
        /// </summary>
        public string OutData
        { get; set; }
        /// <summary>
        /// 数据校验码，4字节，根据iOperateMode确定是否存在
        /// </summary>
        public string OutMac
        { get; set; }

        public GetResponseDataState(int stateData, string outSID, string outAttachData, string outData, string outMac)
            : base(stateData)
        {
            OutSID = outSID;
            OutAttachData = outAttachData;
            OutData = outData;
            OutMac = outMac;
        }
        public GetResponseDataState(int stateData, string message)
            : base(stateData, message)
        {
        }
    }
    /// <summary>
    /// 抄读ESAM参数Esam操作结果
    /// </summary>
    public class GetESAMDataState : EsamState
    {
        /// <summary>
        /// 主站随机数（16Byte）
        /// </summary>
        public string OutRandHost
        { get; set; }
        /// <summary>
        /// 安全标识，4字节
        /// </summary>
        public string OutSID
        { get; set; }
        /// <summary>
        /// SID的附加数据,不小于2字节
        /// </summary>
        public string OutAttachData
        { get; set; }

        public GetESAMDataState(int stateData, string outRandHost, string outSID, string outAttachData)
            : base(stateData)
        {
            OutRandHost = outRandHost;
            OutSID = outSID;
            OutAttachData = outAttachData;
        }
        public GetESAMDataState(int stateData, string message)
            : base(stateData, message)
        {
        }
    }
}
