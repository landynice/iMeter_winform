using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPESAM.Core
{
    public class Esam698Service : IEsam698Service
    {
        # region 通用操作
        /// <summary>
        /// 连接密码机(服务器)函数,用于连接服务器或密码机
        /// </summary>
        /// <param name="PutIP">密码机IP地址</param>
        /// <param name="PutPort">密码机端口号</param>
        /// <param name="PutCtime">最大超时时间，字符型，单位：s</param>
        /// <returns></returns>
        public EsamState ConnectDevice(string PutIP, string PutPort, string PutCtime)
        {
            try
            {
                int result = Esam698OptionUtil.ConnectDevice(PutIP, PutPort, PutCtime);
                return new EsamState(result);
            }
            catch (Exception ex)
            {
                return new EsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// 断开密码机(服务器)函数
        /// </summary>
        /// <returns></returns>
        public EsamState CloseDevice()
        {
            try
            {
                int result = Esam698OptionUtil.CloseDevice();
                return new EsamState(result);
            }
            catch (Exception ex)
            {
                return new EsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// 连接密码机(直连密码机)函数
        /// </summary>
        /// <param name="PutIP">密码机IP地址</param>
        /// <param name="PutPort">密码机端口号</param>
        /// <param name="PutCtime">最大超时时间，字符型，单位：s</param>
        /// <returns>0成功，其它失败</returns>
        public EsamState SetIp(string PutIP, string PutPort, string PutCtime)
        {
            try
            {
                int result = Esam698OptionUtil.SetIp(PutIP, PutPort, PutCtime);
                return new EsamState(result);
            }
            catch (Exception ex)
            {
                return new EsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// 用于产生随机数，也可以不调用本函数产生随机数
        /// </summary>
        /// <param name="InRandLen">8或16，表示输出的随机数长度</param>
        /// <returns>8字节或16字节随机数</returns>
        public OneDataEsamState CreateRand(int InRandLen)
        {
            try
            {
                string rtndata = new string('0', 1024);
                int result = Esam698OptionUtil.CreateRand(InRandLen,ref rtndata);
                return new OneDataEsamState(result, rtndata.Substring(0, rtndata.IndexOf('\0')));
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message, null);
            }
        }

        #endregion

        #region 2013版 电能表正式ESAM函数

        /// <summary>
        /// 身份认证函数
        /// </summary>
        /// <param name="Flag">整型，0: 公钥密钥状</param>
        /// <param name="PutDiv">表示输入的分散因子,字符型,长度16，“0000”+表号</param>
        /// <returns></returns>
        public IdentityAuthenticationState Meter_Formal_IdentityAuthentication(int Flag, string PutDiv)
        {
            try
            {
                string ourRand = new string('0', 1024);
                string ourEnddata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_IdentityAuthentication(Flag, PutDiv, ref ourRand, ref ourEnddata);
                if (result == 0)
                {
                    return new IdentityAuthenticationState(result, ourRand.Substring(0, ourRand.IndexOf('\0')), ourEnddata.Substring(0, ourEnddata.IndexOf('\0')));
                }
                else
                {
                    return new IdentityAuthenticationState(result,null,null);
                }
            }
            catch (Exception ex)
            {
                return new IdentityAuthenticationState(1, ex.Message);
            }
        }
        /// <summary>
        /// 远程控制加密函数
        /// </summary>
        /// <param name="Flag">整型，0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutEsamNo">表示输入的ESAM序列号,复位信息的后8字节,字符型,长度16</param>
        /// <param name="PutData">表示跳闸或合闸控制命令明文,字符型</param>
        /// <returns>输出的密文,字符型</returns>
        public OneDataEsamState Meter_Formal_UserControl(int Flag, string PutRand, string PutDiv, string PutEsamNo, string PutData)
        {
            try
            {
                string ourEnddata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_UserControl(Flag, PutRand, PutDiv, PutEsamNo, PutData,ref ourEnddata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, ourEnddata.Substring(0, ourEnddata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 一类参数MAC计算函数
        /// </summary>
        /// <param name="Flag">整型，0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号； PutApdu 写</param>
        /// <param name="PutApdu">写ESAM命令头，5字节；</param>
        /// <param name="PutData">表示输入的一类参数明文,字符型；</param>
        /// <returns>输出的数据和MAC</returns>
        public OneDataEsamState Meter_Formal_ParameterUpdate(int Flag, string PutRand, string PutDiv, string PutApdu, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_ParameterUpdate(Flag, PutRand, PutDiv, PutApdu, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result,null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// 当前电价参数MAC计算函数
        /// </summary>
        /// <param name="Flag">整型，0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutApdu">写ESAM命令头，5字节；</param>
        /// <param name="PutData">表示输入的当前电价参数明文,字符型；</param>
        /// <param name="OutData"></param>
        /// <returns>输出的数据和MAC</returns>
        public OneDataEsamState Meter_Formal_ParameterUpdate1(int Flag, string PutRand, string PutDiv, string PutApdu, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_ParameterUpdate1(Flag, PutRand, PutDiv, PutApdu, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// 备用电价参数MAC计算函数
        /// </summary>
        /// <param name="Flag">整型，0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutApdu">写ESAM命令头，5字节；</param>
        /// <param name="PutData">表示输入的备用电价参数明文,字符型；</param>
        /// <returns>输出的数据和MAC</returns>
        public OneDataEsamState Meter_Formal_ParameterUpdate2(int Flag, string PutRand, string PutDiv, string PutApdu, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_ParameterUpdate2(Flag, PutRand, PutDiv, PutApdu, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result,null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 二类参数加密函数
        /// </summary>
        /// <param name="Flag">整型，0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutApdu">写ESAM命令头，5字节；</param>
        /// <param name="PutData">表示输入的二类参数明文,字符型；</param>
        /// <returns>输出的密文和MAC,字符型</returns>
        public OneDataEsamState Meter_Formal_ParameterElseUpdate(int Flag, string PutRand, string PutDiv, string PutApdu, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_ParameterElseUpdate(Flag, PutRand, PutDiv, PutApdu, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result,null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 远程充值函数
        /// </summary>
        /// <param name="Flag">整型，0: 密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutData">表示输入的参数明文,包含购电金额、购电次数和户号；</param>
        /// <param name="OutData"></param>
        /// <returns>输出的数据，购电金额+购电次数+MAC1+户号+MAC2</returns>
        public OneDataEsamState Meter_Formal_InCreasePurse(int Flag, string PutRand, string PutDiv, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_InCreasePurse(Flag, PutRand, PutDiv, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 钱包初始化
        /// </summary>
        /// <param name="Flag">整型，0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutData">表示输入的数据明文，包含预置金额；</param>
        /// <returns>输出的数据，预置金额+MAC1+“00000000”+MAC2</returns>
        public OneDataEsamState Meter_Formal_InintPurse(int Flag, string PutRand, string PutDiv, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_InintPurse(Flag, PutRand, PutDiv, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result,null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 电量清零函数
        /// </summary>
        /// <param name="Flag">整型，0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutData">入参，清零数据；</param>
        /// <returns>20字节密文</returns>
        public OneDataEsamState Meter_Formal_DataClear1(int Flag, string PutRand, string PutDiv, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_DataClear1(Flag, PutRand, PutDiv, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 需量/事件清零函数
        /// </summary>
        /// <param name="counter">整型，0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutData">入参，清零数据；</param>
        /// <returns>20字节密文</returns>
        public OneDataEsamState Meter_Formal_DataClear2(int counter, string PutRand, string PutDiv, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_DataClear2(counter, PutRand, PutDiv, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 红外认证函数
        /// </summary>
        /// <param name="Flag">0: 测试密钥状态；</param>
        /// <param name="PutDiv">8字节分散因子，“0000”+表号；</param>
        /// <param name="PutEsamNo">8字节ESAM序列号，电能表红外查询命令返回；</param>
        /// <param name="PutRand1">8字节随机数，产生随机数函数返回</param>
        /// <param name="PutRand1Endata">8字节随机数1密文，电能表红外查询命令返回</param>
        /// <param name="PutRand2">8字节随机数2，电能表红外查询命令返回</param>
        /// <returns></returns>
        public OneDataEsamState Meter_Formal_InfraredAuth(int Flag, string PutDiv, string PutEsamNo, string PutRand1, string PutRand1Endata, string PutRand2)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_InfraredAuth(Flag, PutDiv, PutEsamNo, PutRand1, PutRand1Endata, PutRand2,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 数据回抄
        /// </summary>
        /// <param name="Flag">0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutApdu">命令头，5字节（04D686+起始地址+Len，Len为明文数据长度+0x0C）；</param>
        /// <param name="PutData">数据回抄返回的数据；</param>
        /// <param name="PutMac">4字节数据回抄返回的MAC；</param>
        /// <returns></returns>
        public EsamState Meter_Formal_MacCheck(int Flag, string PutRand, string PutDiv, string PutApdu, string PutData, string PutMac)
        {
            try
            {
                int result = Esam698OptionUtil.Meter_Formal_MacCheck(Flag, PutRand, PutDiv, PutApdu, PutData, PutMac);
                return new EsamState(result);
            }
            catch (Exception ex)
            {
                return new EsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 密文+MAC计算函数
        /// </summary>
        /// <param name="Flag">0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutEsamNo">8字节Esam序列号；</param>
        /// <param name="PutFileID">1字节文件标识；</param>
        /// <param name="PutDataBegin">2字节起始字节；</param>
        /// <param name="PutData">明文数据；</param>
        /// <returns>输出的密文和MAC数据</returns>
        public OneDataEsamState Meter_Formal_EncMacWrite(int Flag, string PutRand, string PutDiv, string PutEsamNo, string PutFileID, string PutDataBegin, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_EncMacWrite(Flag, PutRand, PutDiv, PutEsamNo, PutFileID, PutDataBegin, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// MAC计算函数
        /// </summary>
        /// <param name="Flag">0: 测试密钥状态；</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutEsamNo">8字节Esam序列号；</param>
        /// <param name="PutFileID">1字节文件标识；</param>
        /// <param name="PutDataBegin">2字节起始字节；</param>
        /// <param name="PutData">明文数据；</param>
        /// <returns>输出的4字节MAC数据</returns>
        public OneDataEsamState Meter_Formal_MacWrite(int Flag, string PutRand, string PutDiv, string PutEsamNo, string PutFileID, string PutDataBegin, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_MacWrite(Flag, PutRand, PutDiv, PutEsamNo, PutFileID, PutDataBegin, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// 软件比对数据加密函数
        /// </summary>
        /// <param name="PutKeyid">1字节密钥标识；</param>
        /// <param name="PutDiv">8字节比对因子；</param>
        /// <param name="PutData">比对数据块，64字节；</param>
        /// <returns>64字节输出的密文</returns>
        public OneDataEsamState Meter_Formal_EncForCompare(string PutKeyid, string PutDiv, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_EncForCompare(PutKeyid, PutDiv, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 钱包退费加密函数
        /// </summary>
        /// <param name="Flag">整型，0: 测试密钥状态</param>
        /// <param name="PutRand">随机数，电表身份认证成功返回， 4字节；</param>
        /// <param name="PutDiv">分散因子，8字节，“0000”+表号；</param>
        /// <param name="PutData">示输入的4字节退费金额,字符型；</param>
        /// <param name="OutEndata">输出的密文和MAC,字符型。</param>
        /// <returns></returns>
        public OneDataEsamState Meter_Formal_DecreasePurse(int Flag, string PutRand, string PutDiv, string PutData)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Meter_Formal_DecreasePurse(Flag, PutRand, PutDiv, PutData,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }

        /// <summary>
        /// 参数预置卡函数
        /// </summary>
        /// <param name="PutData1">指令信息文件数据，32字节；</param>
        /// <param name="PutData2">钱包文件数据，8字节；</param>
        /// <param name="PutData3">当前套费率文件数据，258字节；</param>
        /// <param name="PutData4">备用套费率文件数据，258字节；</param>
        /// <param name="PutData5">保留；</param>
        /// <returns></returns>
        public EsamState Meter_Formal_Preset_Card(string PutData1, string PutData2, string PutData3, string PutData4, string PutData5)
        {
            try
            {
                int result = Esam698OptionUtil.Meter_Formal_Preset_Card(PutData1, PutData2, PutData3, PutData4, PutData5);
                return new EsamState(result);
            }
            catch (Exception ex)
            {
                return new EsamState(1, ex.Message);
            }
        }

        ///// <summary>
        ///// 读取参数预置卡函数
        ///// </summary>
        ///// <param name="OutData1">参数信息文件数据，32字节；</param>
        ///// <param name="OutData2">钱包文件数据，8字节</param>
        ///// <param name="OutData3">当前套费率文件数据，258字节；</param>
        ///// <param name="OutData4">备用套费率文件数据，258字节；</param>
        ///// <param name="OutData5">钱包文件数据，8字节</param>
        ///// <returns></returns>
        //public EsamState Meter_ReadPreset_Card(ref string OutData1, ref string OutData2, ref string OutData3, ref string OutData4, ref string OutData5)
        //{
        //    try
        //    {
        //        //未完成的代码---liyunhe
        //        int result = Esam698OptionUtil.Meter_ReadPreset_Card(ref OutData1, ref OutData2, ref OutData3, ref OutData4, ref OutData5);
        //        return new EsamState(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new EsamState(1, ex.Message);
        //    }
        //}

        #endregion

        #region 面向对象--电能表远程动态库接口
        /// <summary>
        /// 主站会话协商
        /// 对称密码连接认证机制，用于主站与设备进行会话协商时产生密文1 和客户机签名1，该过程在建立应用连接时完成。
        /// </summary>
        /// <param name="iKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="cDiv">分散因子（8Byte），iKeyState=0，cDiv 为芯片序列号；iKeyState=1，cDiv 为表号</param>
        /// <param name="cASCTR">应用会话计数,可从芯片读出,系统必须存储，每次会话必须上次大1,4字节</param>
        /// <param name="cFLG">应用密钥产生标识，1Byte，默认”01”;</param>
        /// <returns>0成功，其它失败</returns>
        public InitSessionState Obj_Meter_Formal_InitSession(int iKeyState, string cDiv, string cASCTR, string cFLG)
        {
            try
            {
                string cOutRandHost = new string('0', 512);
                string cOutSessionInit = new string('0', 1024);
                string cOutSign = new string('0', 512);

                int result = Esam698OptionUtil.Obj_Meter_Formal_InitSession(iKeyState, ref cDiv, ref cASCTR, ref cFLG, ref cOutRandHost,ref cOutSessionInit, ref cOutSign);
                if (result == 0)
                {
                    string cOutRandHostData = cOutRandHost.Substring(0, cOutRandHost.IndexOf('\0'));
                    string cOutSessionInitData = cOutSessionInit.Substring(0, cOutSessionInit.IndexOf('\0'));
                    string cOutSignData = cOutSign.Substring(0, cOutSign.IndexOf('\0'));
                    return new InitSessionState(result, cOutRandHostData, cOutSessionInitData, cOutSignData);
                }
                else
                {
                    return new InitSessionState(result, null, null, null);
                }
            }
            catch (Exception ex)
            {
                return new InitSessionState(1, ex.Message);
            }
        }
        /// <summary>
        /// 主站会话协商验证
        /// 对称密码连接认证机制，用于主站验证设备会话协商时返回的数据，验证成功主站产生会话密钥
        /// </summary>
        /// <param name="iKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="cDiv">分散因子（8Byte），iKeyState=0，cDiv 为芯片序列号；iKeyState=1，cDiv 为表号</param>
        /// <param name="cRandHost">主站随机数R1（16Byte）</param>
        /// <param name="cSessionData">终端返回的会话协商数据(48Byte)，建立应用连接中的密文2；</param>
        /// <param name="cSign">终端返回的会话协商数据签名(4Byte) ，建立应用连接中的客户机签名2；</param>
        /// <returns>会话密钥</returns>
        public OneDataEsamState Obj_Meter_Formal_VerifySession(int iKeyState, string cDiv, string cRandHost, string cSessionData, string cSign)
        {
            try
            {
                string outdata  = new string('0', 1024);
                int result = Esam698OptionUtil.Obj_Meter_Formal_VerifySession(iKeyState,ref cDiv,ref cRandHost,ref cSessionData,ref cSign,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// 抄读数据验证
        /// 主站验证设备返回的抄读数据，具体指抄读电能表返回的数据
        /// </summary>
        /// <param name="iKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="iOperateMode">操作模式,1明文+Mac,2密文,3,密文+MAC</param>
        /// <param name="cMeterNo">电表表号,8字节，不足补0</param>
        /// <param name="cRandHost">主站随机数(16Byte)</param>
        /// <param name="cReadData">抄读数据</param>
        /// <param name="cMac">数据</param>
        /// <param name="cOutData">明文抄读数据，iOperateMode=1，为空</param>
        /// <returns>0成功，其它失败</returns>
        public EsamState Obj_Meter_Formal_VerifyReadData(int iKeyState, int iOperateMode, string cMeterNo, string cRandHost, string cReadData, string cMac, string cOutData)
        {
            try
            {
                int result = Esam698OptionUtil.Obj_Meter_Formal_VerifyReadData(iKeyState, iOperateMode, cMeterNo, cRandHost, cReadData, cMac, cOutData);
                return new EsamState(result);
            }
            catch (Exception ex)
            {
                return new EsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// 上报数据验证
        /// 设备主动上报数据时，主站验证数据的合法性
        /// </summary>
        /// <param name="iKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="iOperateMode">操作模式,1明文+Mac,2密文,3,密文+MAC</param>
        /// <param name="cMeterNo">电表表号,8字节，不足补0</param>
        /// <param name="cRandT">终端随机数(12B)</param>
        /// <param name="cReportData">上报数据</param>
        /// <param name="cMac">MAC 数据</param>
        /// <param name="cOutData">明文数据，iOperateMode=1，为空</param>
        /// <param name="cOutRSPCTR">主动上报随机数</param>
        /// <returns>0成功，其它失败</returns>
        public VerifyReportDataState Obj_Meter_Formal_VerifyReportData(int iKeyState, int iOperateMode, string cMeterNo, string cRandT, string cReportData, string cMac)
        {
            try
            {
                string cOutData = new string('0', 1024);
                string cOutRst = new string('0', 1024);

                int result = Esam698OptionUtil.Obj_Meter_Formal_VerifyReportData(iKeyState, iOperateMode, cMeterNo, cRandT, cReportData, cMac,ref  cOutData,ref cOutRst);
                if (result == 0)
                {
                    return new VerifyReportDataState(result, cOutData.Substring(0, cOutData.IndexOf('\0')), cOutRst.Substring(0, cOutRst.IndexOf('\0')));
                }
                else
                {
                    return new VerifyReportDataState(result, null, null);
                }
            }
            catch (Exception ex)
            {
                return new VerifyReportDataState(1, ex.Message);
            }
        }
        /// <summary>
        /// 上报数据返回报文加密
        /// 用于设备主动上报主站返回帧数据加密计算
        /// </summary>
        /// <param name="iKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="iOperateMode">操作模式,1明文+Mac,2密文,3,密文+MAC</param>
        /// <param name="cMeterNo">电表表号,8字节，不足补0</param>
        /// <param name="RandHost">上报随机数，12Byte</param>
        /// <param name="cReportData">上报数据</param>
        /// <returns>0成功，其它失败</returns>
        public GetResponseDataState Obj_Meter_Formal_GetResponseData(int iKeyState, int iOperateMode, string cMeterNo, string RandHost, string cReportData)
        {
            try
            {
                string OutSID = new string('0', 1024);
                string OutAttachData = new string('0', 1024);
                string cOutData = new string('0', 1024);
                string ucOutMac = new string('0', 1024);

                int result = Esam698OptionUtil.Obj_Meter_Formal_GetResponseData(iKeyState, iOperateMode, cMeterNo, RandHost, cReportData, ref OutSID, ref OutAttachData, ref cOutData, ref ucOutMac);
                if (result == 0)
                {
                    string OutSIDData = OutSID.Substring(0, OutSID.IndexOf('\0'));
                    string OutAttachDataStr = OutAttachData.Substring(0, OutAttachData.IndexOf('\0'));
                    string cOutDataStr = cOutData.Substring(0, cOutData.IndexOf('\0'));
                    string ucOutMacData = ucOutMac.Substring(0, ucOutMac.IndexOf('\0'));
                    return new GetResponseDataState(result, OutSIDData, OutAttachDataStr, cOutDataStr, ucOutMacData);
                }
                else
                {
                    return new GetResponseDataState(result, null, null, null, null);
                }
            }
            catch (Exception ex)
            {
                return new GetResponseDataState(1, ex.Message);
            }
        }
        /// <summary>
        /// 安全传输加密
        /// 用于对具体业务数据进行数据加密计算。
        /// </summary>
        /// <param name="iOperateMode">操作模式,1明文+Mac,2密文,3,密文+MAC</param>
        /// <param name="cESAMNO">ESAM系列号,8字节。电表安全芯片序列号，从芯片中读取,系统需存储(此处可为空)</param>
        /// <param name="cSessionKey">会话秘钥，176字节，建立会话成功后希存储的会话秘钥</param>
        /// <param name="cTaskType">参数类型 2:设置会话实效门限 4:安全模式参数、会话时效门限；5:电价、电价切换时间、费率时段、对时；8:拉闸任务；3:除上述操作外的数据加密，密钥更新、写ESAM 操作和钱包操作数据下发通过此函数进行安全计算</param>
        /// <param name="cTaskData">数据明文；N Byte</param>
        /// <returns>0成功，其它失败</returns>
        public GetResponseDataState Obj_Meter_Formal_GetSessionData(int iOperateMode, string cESAMNO, string cSessionKey, int cTaskType, string cTaskData)
        {
            try
            {
                string OutSID = new string('0', 1024);
                string OutAttachData = new string('0', 1024);
                string cOutData = new string('0', 1024);
                string ucOutMac = new string('0', 1024);

                int result = Esam698OptionUtil.Obj_Meter_Formal_GetSessionData(iOperateMode, cESAMNO, cSessionKey, cTaskType, cTaskData, ref OutSID, ref OutAttachData, ref cOutData, ref ucOutMac);
                if (result == 0)
                {
                    string OutSIDData = OutSID.Substring(0, OutSID.IndexOf('\0'));
                    string OutAttachDataStr = OutAttachData.Substring(0, OutAttachData.IndexOf('\0'));
                    string cOutDataStr = cOutData.Substring(0, cOutData.IndexOf('\0'));
                    string ucOutMacData = ucOutMac.Substring(0, ucOutMac.IndexOf('\0'));
                    return new GetResponseDataState(result, OutSIDData, OutAttachDataStr, cOutDataStr, ucOutMacData);
                }
                else
                {
                    return new GetResponseDataState(result, null, null, null, null);
                }
            }
            catch (Exception ex)
            {
                return new GetResponseDataState(1, ex.Message);
            }
        }
        /// <summary>
        /// 加密数据
        /// </summary>
        /// <param name="iOperateMode"></param>
        /// <param name="cESAMNO"></param>
        /// <param name="cSessionKey"></param>
        /// <param name="cTaskData"></param>
        /// <returns></returns>
        public GetResponseDataState Obj_Meter_Formal_GetMeterSetData(int iOperateMode, string cESAMNO, string cSessionKey, string cTaskData)
        {
            try
            {
                string OutSID = new string('0', 1024);
                string OutAttachData = new string('0', 1024);
                string cOutData = new string('0', 1024);
                string ucOutMac = new string('0', 1024);

                int result = Esam698OptionUtil.Obj_Meter_Formal_GetMeterSetData(iOperateMode, cESAMNO, cSessionKey, cTaskData, ref OutSID, ref OutAttachData, ref cOutData, ref ucOutMac);
                if (result == 0)
                {
                    string OutSIDData = OutSID.Substring(0, OutSID.IndexOf('\0'));
                    string OutAttachDataStr = OutAttachData.Substring(0, OutAttachData.IndexOf('\0'));
                    string cOutDataStr = cOutData.Substring(0, cOutData.IndexOf('\0'));
                    string ucOutMacData = ucOutMac.Substring(0, ucOutMac.IndexOf('\0'));
                    return new GetResponseDataState(result, OutSIDData, OutAttachDataStr, cOutDataStr, ucOutMacData);
                }
                else
                {
                    return new GetResponseDataState(result, null, null, null, null);
                }
            }
            catch (Exception ex)
            {
                return new GetResponseDataState(1, ex.Message);
            }
        }
        /// <summary>
        /// 安全传输解密,
        /// 用于电能表返回帧数据解密验证
        /// </summary>
        /// <param name="iKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="iOperateMode">操作模式,1明文+Mac,2密文,3,密文+MAC</param>
        /// <param name="cESAMNO">ESAM系列号,8字节。电表安全芯片序列号，从芯片中读取,系统需存储(此处可为空)</param>
        /// <param name="cSessionKey">会话秘钥，176字节，建立会话成功后希存储的会话秘钥</param>
        /// <param name="cTaskData">数据明文；N Byte</param>
        /// <param name="cMac">MAC 数据</param>
        /// <param name="cOutData"></param>
        /// <returns>数据明文</returns>
        public OneDataEsamState Obj_Meter_Formal_VerifyMeterData(int iKeyState, int iOperateMode, string cESAMNO, string cSessionKey, string cTaskData, string cMac)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Obj_Meter_Formal_VerifyMeterData(iKeyState, iOperateMode, cESAMNO, cSessionKey, cTaskData, cMac, ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// 广播数据加密
        /// 用于广播数据加密计算
        /// </summary>
        /// <param name="iKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="iOperateMode">操作模式,1明文+Mac,2密文,3,密文+MAC</param>
        /// <param name="cESAMNO">ESAM系列号,8字节。电表安全芯片序列号，从芯片中读取,系统需存储(此处可为空)</param>
        /// <param name="cBrdCstAddr">广播地址</param>
        /// <param name="AGSEQ">广播应用通信序列号，4Byte</param>
        /// <param name="cBrdCstData">广播数据明文</param>
        /// <returns>0成功，其它失败</returns>
        public GetResponseDataState Obj_Meter_Formal_GetGrpBrdCstData(int iKeyState, int iOperateMode, string cESAMNO, string cBrdCstAddr, string AGSEQ, string cBrdCstData)
        {
            try
            {
                string OutSID = new string('0', 1024);
                string OutAttachData = new string('0', 1024);
                string cOutData = new string('0', 1024);
                string ucOutMac = new string('0', 1024);

                int result = Esam698OptionUtil.Obj_Meter_Formal_GetGrpBrdCstData(iKeyState, iOperateMode, cESAMNO, cBrdCstAddr, AGSEQ, cBrdCstData, ref OutSID, ref OutAttachData, ref cOutData, ref ucOutMac);
                if (result == 0)
                {
                    string OutSIDData = OutSID.Substring(0, OutSID.IndexOf('\0'));
                    string OutAttachDataStr = OutAttachData.Substring(0, OutAttachData.IndexOf('\0'));
                    string cOutDataStr = cOutData.Substring(0, cOutData.IndexOf('\0'));
                    string ucOutMacData = ucOutMac.Substring(0, ucOutMac.IndexOf('\0'));
                    return new GetResponseDataState(result, OutSIDData, OutAttachDataStr, cOutDataStr, ucOutMacData);
                }
                else
                {
                    return new GetResponseDataState(result, null, null, null, null);
                }
            }
            catch (Exception ex)
            {
                return new GetResponseDataState(1, ex.Message);
            }
        }
        /// <summary>
        /// 设置 ESAM 参数
        /// 用于设置表号、当前套电价文件、备用套电价文件、ESAM 存储标识等ESAM中存储的数据
        /// </summary>
        /// <param name="InKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="InOperateMode">操作模式,1明文+Mac,2密文,3,密文+MAC</param>
        /// <param name="cESAMNO">ESAM系列号,8字节。电表安全芯片序列号，从芯片中读取,系统需存储(此处可为空)</param>
        /// <param name="cSessionKey">会话秘钥，176字节，建立会话成功后希存储的会话秘钥</param>
        /// <param name="cMeterNo">电表表号,8字节，不足补0</param>
        /// <param name="cESAMRand"></param>
        /// <param name="cData">4ByteOAD + 1Byte 内容LEN + 内容</param>
        /// <returns>0成功，其它失败</returns>
        public GetResponseDataState Obj_Meter_Formal_SetESAMData(int InKeyState, int InOperateMode, string cESAMNO, string cSessionKey, string cMeterNo, string cESAMRand, string cData)
        {
            try
            {
                string OutSID = new string('0', 1024);
                string OutAttachData = new string('0', 1024);
                string cOutData = new string('0', 1024);
                string ucOutMac = new string('0', 1024);

                int result = Esam698OptionUtil.Obj_Meter_Formal_SetESAMData(InKeyState, InOperateMode, cESAMNO, cSessionKey, cMeterNo, cESAMRand, cData, ref OutSID, ref OutAttachData, ref cOutData, ref ucOutMac);
                if (result == 0)
                {
                    string OutSIDData = OutSID.Substring(0, OutSID.IndexOf('\0'));
                    string OutAttachDataStr = OutAttachData.Substring(0, OutAttachData.IndexOf('\0'));
                    string cOutDataStr = cOutData.Substring(0, cOutData.IndexOf('\0'));
                    string ucOutMacData = ucOutMac.Substring(0, ucOutMac.IndexOf('\0'));
                    return new GetResponseDataState(result, OutSIDData, OutAttachDataStr, cOutDataStr, ucOutMacData);
                }
                else
                {
                    return new GetResponseDataState(result, null, null, null, null);
                }
            }
            catch (Exception ex)
            {
                return new GetResponseDataState(1, ex.Message);
            }
        }
        /// <summary>
        /// 抄读 ESAM 参数
        /// 用于抄读号、当前套电价文件、备用套电价文件、ESAM 存储标识等ESAM中存储的数据
        /// </summary>
        /// <param name="iKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="iOperateMode">操作模式,1明文+Mac,2密文,3,密文+MAC</param>
        /// <param name="cMeterNo">表号(8Byte)，不够8Byte 前面填充0</param>
        /// <param name="cOAD">OAD?</param>
        /// <param name="cOutRandHost">主站随机数（16Byte）</param>
        /// <param name="cOutSID">安全标识，4字节</param>
        /// <param name="cOutAttachData">SID的附加数据,不小于2字节</param>
        /// <returns>0成功，其它失败</returns>
        public GetESAMDataState Obj_Meter_Formal_GetESAMData(int iKeyState, int iOperateMode, string cMeterNo, string cOAD)
        {
            try
            {
                string outRandHost = new string('0', 1024);
                string OutSID = new string('0', 1024);
                string OutAttachData = new string('0', 1024);

                int result = Esam698OptionUtil.Obj_Meter_Formal_GetESAMData(iKeyState, iOperateMode, cMeterNo, cOAD, ref outRandHost, ref OutSID, ref OutAttachData);
                if (result == 0)
                {
                    return new GetESAMDataState(result, outRandHost.Substring(0, outRandHost.IndexOf('\0')), OutSID.Substring(0, OutSID.IndexOf('\0')), OutAttachData.Substring(0, OutAttachData.IndexOf('\0')));
                }
                else
                {
                    return new GetESAMDataState(result,null,null,null);
                }
            }
            catch (Exception ex)
            {
                return new GetESAMDataState(1, ex.Message);
            }
        }
        /// <summary>
        /// 抄读 ESAM 参数验证
        /// </summary>
        /// <param name="InKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="iOperateMode">操作模式,1明文+Mac,2密文,3,密文+MAC</param>
        /// <param name="cESAMNO">ESAM系列号,8字节。电表安全芯片序列号，从芯片中读取</param>
        /// <param name="cMeterNo">表号(8Byte)，不够8Byte 前面填充0</param>
        /// <param name="cRandHost">主站随机数(16Byte)</param>
        /// <param name="cOAD">OAD?</param>
        /// <param name="cTaskData">输入的明文或密文数据</param>
        /// <param name="cMAC">MAC，4Byte</param>
        /// <returns>输出的明文数据</returns>
        public OneDataEsamState Obj_Meter_Formal_VerifyESAMData(int InKeyState, int iOperateMode, string cESAMNO, string cMeterNo, string cRandHost, string cOAD, string cTaskData, string cMAC)
        {
            try
            {
                string outdata = new string('0', 1024);
                int result = Esam698OptionUtil.Obj_Meter_Formal_VerifyESAMData(InKeyState, iOperateMode, cESAMNO, cMeterNo, cRandHost, cOAD, cTaskData, cMAC,ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result, null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }
        /// <summary>
        /// 钱包操作
        /// 用于设置表号、当前套电价文件、备用套电价文件、ESAM 存储标识
        /// </summary>
        /// <param name="iOperateMode">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="cESAMNO">ESAM系列号,8字节。电表安全芯片序列号，从芯片中读取</param>
        /// <param name="cSessionKey">会话秘钥，176字节，建立会话成功后希存储的会话秘钥</param>
        /// <param name="cTaskType">任务序编号， 9，钱包初始化；10，钱包充值；11，钱包退费</param>
        /// <param name="cTaskData">数据明文，包含预置金额，4Byte cOutSID</param>
        /// <param name="cOutSID">安全标识，4字节</param>
        /// <param name="cOutAttachData">SID的附加数据,不小于2字节</param>
        /// <param name="cOutData">数据，明文或密文</param>
        /// <param name="cOutMAC">数据检验码，根据iOperateMode确定是否有无</param>
        /// <returns></returns>
        public GetResponseDataState Obj_Meter_Formal_GetPurseData(int iOperateMode, string cESAMNO, string cSessionKey, int cTaskType, string cTaskData)
        {
            try
            {
                string OutSID = new string('0', 1024);
                string OutAttachData = new string('0', 1024);
                string cOutData = new string('0', 1024);
                string ucOutMac = new string('0', 1024);

                int result = Esam698OptionUtil.Obj_Meter_Formal_GetPurseData(iOperateMode, cESAMNO, cSessionKey, cTaskType, cTaskData, ref OutSID, ref OutAttachData, ref cOutData, ref ucOutMac);
                if (result == 0)
                {
                    string OutSIDData = OutSID.Substring(0, OutSID.IndexOf('\0'));
                    string OutAttachDataStr = OutAttachData.Substring(0, OutAttachData.IndexOf('\0'));
                    string cOutDataStr = cOutData.Substring(0, cOutData.IndexOf('\0'));
                    string ucOutMacData = ucOutMac.Substring(0, ucOutMac.IndexOf('\0'));
                    return new GetResponseDataState(result, OutSIDData, OutAttachDataStr, cOutDataStr, ucOutMacData);
                }
                else
                {
                    return new GetResponseDataState(result, null, null, null, null);
                }
            }
            catch (Exception ex)
            {
                return new GetResponseDataState(1, ex.Message);
            }
        }
        /// <summary>
        /// 软件比对函数
        /// 用于加密从电能表返回的明文数据单元
        /// </summary>
        /// <param name="iKeyState">对称秘钥状态：0出厂秘钥，1正式秘钥</param>
        /// <param name="cESAMNo">ESAM系列号,8字节。电表安全芯片序列号，从芯片中读取</param>
        /// <param name="cDIV">比对因子，见《面向对象的互操作性数据交换协议》</param>
        /// <param name="cKeyID">密钥标识，协议传入</param>
        /// <param name="cData">加密的数据单元，见《面向对象的互操作性数据交换协议</param>
        /// <returns>密文数据</returns>
        public OneDataEsamState Obj_Meter_Formal_EncForCompare(int iKeyState, string cESAMNo, string cDIV, string cKeyID, string cData)
        {
            try
            {
                string outdata = new string('0', 1024);
               
                int result = Esam698OptionUtil.Obj_Meter_Formal_EncForCompare(iKeyState, cESAMNo, cDIV, cKeyID, cData, ref outdata);
                if (result == 0)
                {
                    return new OneDataEsamState(result, outdata.Substring(0, outdata.IndexOf('\0')));
                }
                else
                {
                    return new OneDataEsamState(result,null);
                }
            }
            catch (Exception ex)
            {
                return new OneDataEsamState(1, ex.Message);
            }
        }
        #endregion
    }
}
