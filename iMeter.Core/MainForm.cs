using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using System.IO.Ports;
using System.Threading;
//using OAUS.Core;
//using System.Net;
//using System.Net.Sockets;
using System.Drawing;
using PublicFunction;
using Protocol.Core;
using System.Collections.Generic;
//using Communication.Core;

namespace iMeter
{
    public partial class MainForm : Form
    {
        private Thread clientThread;
        public MainForm()
        {
            InitializeComponent();
            IProtocol.MsgEvent += UpdateMsg;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InterfaceInit();
            LoadUserCtrol();
            //加载文本框记录
            //LoadInterfacePara(tabControl1);

            //CheckUpdata();//启动后检查是否有更新
            //LinkToServer();
        }

        #region 界面初始化
#if false
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <returns>UpdataSuccess:更新成功；CancelUpdata:取消更新；NoUpdata:没有更新；</returns>
        private string CheckUpdata()
        {            
            string ip = "10.2.1.108";
            string hostname = System.Net.Dns.GetHostName();
            System.Net.IPAddress[] addressList = System.Net.Dns.GetHostAddresses(hostname);
            foreach (System.Net.IPAddress p in addressList)
            {
                if (p.ToString() == ip) return "LocalIp";
            }
            if (!Ping(ip)) return "LinkIpFalse";
            if (!IsConnet(ip, 4540)) return "LinkPortFalse";
            if (VersionHelper.HasNewVersion(ip, 4540))
            {
                if (MessageBox.Show(
                    "有可用的更新，是否更新软件？", "软件更新", MessageBoxButtons.YesNo, MessageBoxIcon.Information) 
                    == DialogResult.Yes)
                {
                    string Current = AppDomain.CurrentDomain.BaseDirectory; //获取当前根目录
                    INI ini = new INI(Current + "/config.ini");
                    ini.Writue("SoftWareInfo", "isUpdata", "true");

                    string updateExePath = AppDomain.CurrentDomain.BaseDirectory + "AutoUpdater\\AutoUpdater.exe";
                    System.Diagnostics.Process myProcess = System.Diagnostics.Process.Start(updateExePath);
                    this.Close();
                    return "UpdataSuccess";
                }
                else return "CancelUpdata";
            }
            else return "NoUpdata";
        }
        private void LinkToServer()
        {
            clientThread = new Thread(InfoHandler);
            clientThread.Start();
        }
        private void InfoHandler()
        { 
            byte[] result = new byte[1024];
            IPAddress ip = IPAddress.Parse("10.2.1.108");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (true)
            {
                Functions.Delay(10000);
                if (!Ping("10.2.1.108")) continue;
                if (!IsConnet("10.2.1.108", 8885)) continue;
                try
                {
                    clientSocket.Connect(new IPEndPoint(ip, 8885));//配置服务器IP与端口
                    
                    int receiveLength = clientSocket.Receive(result);
                    string res = Encoding.ASCII.GetString(result, 0, receiveLength);
                    if (res == "GetClientIP")
                    {
                        try
                        {
                            string hostname = Dns.GetHostName();
                            IPAddress[] addressList = Dns.GetHostAddresses(hostname);
                            string localIp = addressList[0].ToString();
                            clientSocket.Send(Encoding.ASCII.GetBytes("[" + hostname + "][" + localIp + "]"));
                        }
                        catch
                        {
                            clientSocket.Shutdown(SocketShutdown.Both);
                            clientSocket.Close();
                            continue;
                        }
                    }
                    else
                    { 
                        tbComMemo.AppendText(res + "\r\n");
                    }
                }
                catch
                {
                    //clientSocket.Shutdown(SocketShutdown.Both);
                    //clientSocket.Close();
                    continue;
                }
                continue;
            }
            
        }
#endif

        /// <summary>
        /// 界面初始化
        /// </summary>
        private void InterfaceInit()
        {
            //电表基本参数初始化
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();//获取当前电脑串口
            if (ports.Length < 1)
            {
                ports = new string[1] { "COM1" };//如果当前电脑没有串口，默认写com1
            }
            Array.Sort(ports);
            toolStripComboBoxCom.Items.AddRange(ports);

            string fileRoot = AppDomain.CurrentDomain.BaseDirectory;//获取当前根目录
            string strConfig = fileRoot + "/config.ini";

            if (File.Exists(@strConfig))//ini文件是否存在
            {
                INI ini = new INI(strConfig);

                bool isThePortExist = false;   //判断ini文件中保存的串口在当前电脑是否有
                for (int i = 0; i < ports.Length; i++)
                {
                    isThePortExist = (ports[i] == ini.ReadValue("ComPortSetting", "MeterCom") ? true : false);
                    if (isThePortExist)
                    {
                        toolStripComboBoxCom.Text = ini.ReadValue("ComPortSetting", "MeterCom");
                        break;
                    }
                }
                if (!isThePortExist)
                {
                    toolStripComboBoxCom.Text = ports[0];
                }

                toolStripComboBoxBps.Text    = ini.ReadValue("ComPortSetting", "MeterBaud");
                toolStripTextBoxOprCode.Text = ini.ReadValue("ComPortSetting", "MeterOprCode");
                toolStripTextBoxPsw.Text     = ini.ReadValue("ComPortSetting", "MeterPsw");
                toolStripTbAddr.Text         = ini.ReadValue("MeterInfo",      "MeterAddress");
                toolStripTBCA.Text = ini.ReadValue("MeterInfo", "CA");
                //界面选择
                if (Functions.IsNum(ini.ReadValue("Interface", "TabControlSelect")))
                    tabControl1.SelectedIndex = Convert.ToInt16(ini.ReadValue("Interface", "TabControlSelect"));
                
                //是否显示更新信息
                if(ini.ReadValue("SoftWareInfo", "isUpdata") == "true")
                {
                    ini.Writue("SoftWareInfo", "isUpdata", "false");
                    AboutBox1 about = new AboutBox1();
                    about.ShowDialog();
                }
            }
            else
            {
                toolStripComboBoxCom.Text    = ports[0];
                toolStripComboBoxBps.Text    = "2400";
                toolStripTextBoxOprCode.Text = "00000001";
                toolStripTextBoxPsw.Text     = "00000002";
                toolStripTBCA.Text = "A1";
            }
			//初始化串口
			if (toolStripComboBoxCom.Text != string.Empty && toolStripComboBoxBps.Text != string.Empty)
			{
				IProtocol.PortName = toolStripComboBoxCom.Text;
				IProtocol.BaudRate = Convert.ToInt32(toolStripComboBoxBps.Text);
			}
            //ComPort.ComportName = toolStripComboBoxCom.Text;
            //ComPort.ComportBaudRate = int.Parse(toolStripComboBoxBps.Text);
            //底部状态栏初始化
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Interval = 1000;
            timer1.Start();
            //其他
            //btnEnergyTestStop.Enabled = false;
            //treeView1.ExpandAll();//展开treeView
            //通讯地址、密码、操作者代码
            Protocol645.Addr = toolStripTbAddr.Text.PadLeft(12, '0');
            Protocol645.Psw = toolStripTextBoxPsw.Text.PadLeft(8, '0');
            Protocol645.OprCode = toolStripTextBoxOprCode.Text.PadLeft(8, '0');
            Protocol698.CA = toolStripTBCA.Text.PadLeft(2, '0');
            //费率表格初始化
            //dgRates.Rows.Add(32);
            //for (int i = 0; i < 32; i++)
            //{
            //    dgRates.Rows[i].HeaderCell.Value = "费率" + (i + 1).ToString("D2");
            //    dgRates[1, i].Value = "NNNN.NNNN 元";
            //}
            //比较新旧版本是否一致，不一致则弹出更新信息
        }

        /// <summary>
        /// 加载控件
        /// </summary>
        private void LoadUserCtrol()
        {
            List<Control> controls = new List<Control>
            {
                new PanelOftenUsePara(),    //常用参数
                new PanelReadWriteAndDisp(),//多项读写/显示
                new PanelSpecialCommand(),  //特殊命令
                new PanelEsamAndCtrol(),    //ESAM/费控
                new PanelStatePara(),       //状态字/模式字/特征字
                new PanelTimeZoneTest(),    //时区时段测试
                new PanelBroadSetTimeTest(),//广播校时测试
                new PanelEventTest(),       //事件测试
                new PanelFreezeTest(),      //冻结测试
                new PanelEnergyTest(),      //电量测试
                new PanelReadData(),        //读数据
                new PanelProtocol698(),     //698协议通讯
                new PanelInfinitTest()      //多次读取
            };
            try
            {
                foreach (Control control in controls)
                {
                    TabPage tabPage = new TabPage(control.Text);
                    control.Dock = DockStyle.Fill;
                    tabPage.Controls.Add(control);
                    tabControl1.TabPages.Add(tabPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 保存界面数据
        /// </summary>
        /// <param name="userControl">控件名称</param>
        private void SaveInterfacePara(Control userControl)
        {
            string Current = AppDomain.CurrentDomain.BaseDirectory; //获取当前根目录

            INI ini = new INI(Current + "/Memo.ini");
            foreach(Control ctrl in userControl.Controls)
            {
                if(ctrl is TextBox)
                {
                    if (!(ctrl as TextBox).ReadOnly)
                    {
                        ini.Writue(userControl.Name, ctrl.Name, ctrl.Text);
                    }
                }
                if (ctrl is CheckBox)
                {
                    ini.Writue(userControl.Name, ctrl.Name, (ctrl as CheckBox).Checked.ToString());
                }
            }
            foreach (Control ctrl in userControl.Controls)
            {
                SaveInterfacePara(ctrl);
            }
        }

        /// <summary>
        /// 加载控件界面数据
        /// </summary>
        /// <param name="userControl">控件名称</param>
        private void LoadInterfacePara(Control userControl)
        {
            string strFileName = AppDomain.CurrentDomain.BaseDirectory + "/Memo.ini"; //获取当前根目录

            if (File.Exists(@strFileName))//ini文件是否存在
            {
                INI ini = new INI(strFileName);
                foreach (Control ctrl in userControl.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        if (!(ctrl as TextBox).ReadOnly)
                        {
                            ctrl.Text = ini.ReadValue(userControl.Name, ctrl.Name);
                        }
                    }
                    if(ctrl is CheckBox)
                    {
                        string isCheck = ini.ReadValue(userControl.Name, ctrl.Name);
                        if (isCheck.ToLower() == "true")
                            (ctrl as CheckBox).Checked = true;
                        else
                            (ctrl as CheckBox).Checked = false;
                    }
                }
                foreach (Control ctrl in userControl.Controls)
                {
                    LoadInterfacePara(ctrl);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 通讯参数改变则更改相应属性
        /// </summary>
        /// <param name="sender">触发的控件</param>
        /// <param name="e"></param>
        private void CommunicationPropertyChange(object sender, EventArgs e)
        {
            //IProtocol.PortName = "COM1";
            //IProtocol.BaudRate = 2400;
            Protocol645 p645 = new Protocol645();
            if (sender == toolStripTbAddr)
            {
                Protocol645.Addr = toolStripTbAddr.Text.PadLeft(12, '0');       //表地址改变，则写入addr
                string temp1 = toolStripTbAddr.Text.PadLeft(12, '0');
                string temp2 = "";
                for (int i = 6; i > 0; i--)
                {
                    temp2 += temp1.Substring(i * 2 - 2, 2);
                }
                Protocol698.Addr = temp2;
            }
            if (sender == toolStripTextBoxPsw)     Protocol645.Psw         = toolStripTextBoxPsw.Text.PadLeft(8, '0');    //密码改变，则写入psw
            if (sender == toolStripTextBoxOprCode) Protocol645.OprCode     = toolStripTextBoxOprCode.Text.PadLeft(8, '0');//操作者代码改变，则写入oprcode
            if (sender == toolStripTBCA) Protocol698.CA = toolStripTBCA.Text.PadLeft(2, '0');

            if (sender == toolStripComboBoxCom) IProtocol.PortName = toolStripComboBoxCom.Text;                   //串口号改变
            if (sender == toolStripComboBoxBps) IProtocol.BaudRate = int.Parse(toolStripComboBoxBps.Text);        //波特率改变

            if (sender == menuItemBps2400)
            {
                if (p645.ChangeBaudrate("08"))
                {
                    IProtocol.BaudRate = 2400;
                    //ComPort.ComportBaudRate = 2400;
                    toolStripComboBoxBps.SelectedIndex = 1;
                }
            }
            if (sender == menuItemBps9600)
            {
                if (p645.ChangeBaudrate("20"))
                {
                    IProtocol.BaudRate = 9600;
                    //ComPort.ComportBaudRate = 9600;
                    toolStripComboBoxBps.SelectedIndex = 3;
                }
            }
        }
#endregion

#region 窗口关闭时将界面参数写入ini文件
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string Current = AppDomain.CurrentDomain.BaseDirectory; //获取当前根目录

            INI ini = new INI(Current + "/config.ini");
            ini.Writue("ComPortSetting", "MeterCom",         toolStripComboBoxCom.Text);
            ini.Writue("ComPortSetting", "MeterBaud",        toolStripComboBoxBps.Text);
            ini.Writue("ComPortSetting", "MeterOprCode",     toolStripTextBoxOprCode.Text);
            ini.Writue("ComPortSetting", "MeterPsw",         toolStripTextBoxPsw.Text);
            ini.Writue("MeterInfo",      "MeterAddress",     toolStripTbAddr.Text.PadLeft(12, '0'));
            ini.Writue("MeterInfo", "CA", toolStripTBCA.Text);
            //写入最后界面记录
            //ini.Writue("Interface", "TabControlSelect", tabControl1.SelectedIndex.ToString());
            //写入文本记录
            //SaveInterfacePara(tabControl1);

            //ComPort.ComClose();
            Environment.Exit(Environment.ExitCode);
            Dispose();
            Close();
        }
#endregion

#region 菜单设置
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Err信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutFrm = new About();
            aboutFrm.ShowDialog();
        }
        private void 测试方法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestMethod testMethodFrm = new TestMethod();
            testMethodFrm.ShowDialog();
        }
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        /// <summary>
        /// ping
        /// </summary>
        /// <param name="ip">远程ip地址</param>
        /// <returns>ping得通返回true，否则false</returns>
        private bool Ping(string ip)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
            options.DontFragment = true;
            string data = "Test Data!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;//Timeout时间，单位：毫秒
            System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout, buffer, options);
            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 连接某IP的端口
        /// </summary>
        /// <param name="ip">要连接的ip</param>
        /// <param name="port">要连接的端口</param>
        /// <returns>连上返回true，否则false</returns>
        private bool IsConnet(string ip, int port)
        {
            bool tcpListen = false;
            bool udpListen = false;//设定端口状态标识位
            System.Net.IPAddress myIpAddress = System.Net.IPAddress.Parse(ip);
            System.Net.IPEndPoint myIpEndPoint = new System.Net.IPEndPoint(myIpAddress, port);
            try
            {
                System.Net.Sockets.TcpClient tcpClient = new System.Net.Sockets.TcpClient();
                tcpClient.Connect(myIpEndPoint);//对远程计算机的指定端口提出TCP连接请求
                tcpListen = true;
            }
            catch { }
            try
            {
                System.Net.Sockets.UdpClient udpClient = new System.Net.Sockets.UdpClient();
                udpClient.Connect(myIpEndPoint);//对远程计算机的指定端口提出UDP连接请求
                udpListen = true;
            }
            catch { }
            if (tcpListen == false || udpListen == false)
                return false;
            else
                return true;
        }
        private void 检查更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string updataResult = CheckUpdata();
            //string showMessage = "";
            //switch (updataResult)
            //{
            //    case "LocalIp": showMessage = "本机IP不允许升级"; break;
            //    case "LinkIpFalse": showMessage = "连接服务器IP失败"; break;
            //    case "LinkPortFalse": showMessage = "连接服务器端口失败"; break;
            //    case "NoUpdata": showMessage = "没有可用的更新"; break;
            //    default: break;
            //}
            //if (showMessage != "")
            //    MessageBox.Show(showMessage, "错误信息");
        }

        private void SoftwareView(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;

        }
#endregion

#region 表地址
        private void toolStripBtnWriteAddr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            if (toolStripTbAddr.Text != "")
            {
                string addr = toolStripTbAddr.Text.PadLeft(12, '0');
                if (Functions.IsNum(addr))
                {
                    p645.WriteAddress(addr);
                }
                else MessageBox.Show("请不要输入数字以外的字符！");
            }
            else MessageBox.Show("请输入表地址！");
        }

        private void toolStripBtnReadAddr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            toolStripTbAddr.Text = "";
            Functions.Delay(60);
            string result = null;
            if (p645.ReadAddress(out result))
            {
                toolStripTbAddr.Text = result;
            }
        }
#endregion

#region 报文监控
        private void UpdateMsg(bool isSend, string str)
        {
            string txt = "[" + DateTime.Now.ToString("HH:mm:ss") + "]";
            txt += isSend ? "发送：" : "接收：";
            for (int i = 0; i < str.Length; i += 2)
            {
                txt += (str.Substring(i, 2) + " ");
            }
            this.tbComMemo.AppendText(txt + "\r\n");

            if (!isSend)
            {
                this.tbComMemo.AppendText("----------------------------------------------------------------------\r\n");
                Frame645 frame = new Frame645(str);
                if (frame.IsValidFrame)
                {
                    Functions.Delay(100);
                    statusReturn.ForeColor = (frame.ErrInfo == "正常应答")
                        ? Color.Green
                        : Color.Red;
                    statusReturn.Text = frame.ErrInfo;
                    if (frame.DataId.Length == 8)
                        tsslSorF.Text = "ID: " + frame.DataId;
                }
            }
        }
#endregion

#region 右键菜单
        private Control ctrl;//定义右键菜单contextmenustrip获取控件
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ctrl = (sender as ContextMenuStrip).SourceControl;
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctrl is TextBox)
            {
                ((TextBox)ctrl).Clear();
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctrl is TextBox)
            {
                ((TextBox)ctrl).SelectAll();
            }
        }

        private void 复制toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ctrl is TextBox)
            {
                if (((TextBox)ctrl).SelectedText != "")
                {
                    Clipboard.SetDataObject(((TextBox)ctrl).SelectedText, true);
                }
            }
        }




        #endregion

        private void toolStripComboBoxCom_DropDown(object sender, EventArgs e)
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();//获取当前电脑串口
            if (ports.Length < 1)
            {
                ports = new string[1] { "COM1" };//如果当前电脑没有串口，默认写com1
            }
            Array.Sort(ports);
            toolStripComboBoxCom.Items.Clear();
            toolStripComboBoxCom.Items.AddRange(ports);
        }
    }
}
