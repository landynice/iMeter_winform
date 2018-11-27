using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelProtocol698 : UserControl
    {
        private Thread TestThread;//定义线程
        public PanelProtocol698()
        {
            InitializeComponent();
        }

        private void PanelProtocol698_Load(object sender, EventArgs e)
        {
            ckbAPDUDiv_CheckedChanged(sender, e);
            ckbAutoCalcChk_CheckedChanged(sender, e);
            ckbAutoCalcLen_CheckedChanged(sender, e);
            ckbOldVerDisp_CheckedChanged(sender, e);
            Protocol698.Addr = txt698Addr.Text;

            comboBoxSecurityRule.SelectedIndex = 2;
        }

        private string GetCs(string str)
        {
            ushort hcs = Protocol698.pppfcs16(str);
            return (hcs & 0x00ff).ToString("X2") + ((hcs >> 8) & 0x00ff).ToString("X2");
        }
        private void btnCalcHCS_Click(object sender, EventArgs e)
        {
            tbHCS.Text = "";
            Functions.Delay(50);

            string frm = tbLen.Text + tbCtl.Text + tbAF.Text + tbSA.Text + tbCA.Text;
            frm = frm.Replace(" ", "").Replace("\n", "").Replace("\r", "");

            if (tbLen.Text.Replace(" ", "").Length != 4
                || tbCtl.Text.Replace(" ", "").Length != 2
                || tbAF.Text.Replace(" ", "").Length != 2
                || tbSA.Text.Replace(" ", "").Length < 2
                || tbCA.Text.Replace(" ", "").Length != 2
                || frm.Length % 2 == 1)
            {
                MessageBox.Show("请输入正确帧！");
            }
            else
            {
                ushort hcs = Protocol698.pppfcs16(frm);
                tbHCS.Text = (hcs & 0x00ff).ToString("X2") + " " + ((hcs >> 8) & 0x00ff).ToString("X2");
            }
        }

        private void btnCalcFCS_Click(object sender, EventArgs e)
        {
            tbFCS.Text = "";
            Functions.Delay(50);

            string frm = "";
            frm = (ckbAPDUDiv.Checked) ? (tbLen.Text + tbCtl.Text + tbAF.Text + tbSA.Text + tbCA.Text + tbHCS.Text + tbAPDU_1.Text + tbAPDU_2.Text
                + tbAPDU_3.Text + tbAPDU_4.Text + tbAPDU_5.Text + tbAPDU_6.Text) :
                (tbLen.Text + tbCtl.Text + tbAF.Text + tbSA.Text + tbCA.Text + tbHCS.Text + tbAPDU.Text);
            frm = frm.Replace(" ", "").Replace("\n", "").Replace("\r", "");

            if (tbLen.Text.Replace(" ", "").Length != 4
                || tbCtl.Text.Replace(" ", "").Length != 2
                || tbAF.Text.Replace(" ", "").Length != 2
                || tbSA.Text.Replace(" ", "").Length < 2
                || tbCA.Text.Replace(" ", "").Length != 2
                || tbHCS.Text.Replace(" ", "").Length != 4
                //|| tbAPDU.Text.Replace(" ", "").Replace("\n", "").Replace("\r", "").Length < 2
                || frm.Length % 2 == 1)
            {
                MessageBox.Show("请输入正确帧！");
            }
            else
            {
                ushort fcs = Protocol698.pppfcs16(frm);
                tbFCS.Text = (fcs & 0x00ff).ToString("X2") + " " + ((fcs >> 8) & 0x00ff).ToString("X2");
            }
            tbFCS.Update();
        }

        private void btnCalcLen_Click(object sender, EventArgs e)
        {
            tbLen.Text = "";
            Functions.Delay(50);

            string frm = "";
            frm = (ckbAPDUDiv.Checked) ? (tbCtl.Text + tbAF.Text + tbSA.Text + tbCA.Text + tbAPDU_1.Text + tbAPDU_2.Text
                + tbAPDU_3.Text + tbAPDU_4.Text + tbAPDU_5.Text + tbAPDU_6.Text) :
                (tbCtl.Text + tbAF.Text + tbSA.Text + tbCA.Text + tbAPDU.Text);
            frm = frm.Replace(" ", "").Replace("\n", "").Replace("\r", "");

            if (tbCtl.Text.Replace(" ", "").Length != 2
                || tbAF.Text.Replace(" ", "").Length != 2
                || tbSA.Text.Replace(" ", "").Length < 2
                || tbCA.Text.Replace(" ", "").Length != 2
                //|| tbAPDU.Text.Replace(" ", "").Replace("\n", "").Replace("\r", "").Length < 2
                || frm.Length % 2 == 1)
            {
                MessageBox.Show("请输入正确帧！");
                return;
            }
            else
            {
                int len = 0;
                len = frm.Length / 2 + 2 + 2 + 2;//len长度加2，hcs长度加2，fcs长度加2
                int len_H = len / 256;
                int len_L = len % 256;
                tbLen.Text = len_L.ToString("X2") + " " + len_H.ToString("X2");
            }
            tbLen.Update();
        }

        private void btn698send_Click(object sender, EventArgs e)
        {
            btnClrData_Click(sender, e);
            if (ckbClearBefore.Enabled && ckbClearBefore.Checked) tb698Explain.Clear();
            if (ckbAutoCalcLen.Checked) btnCalcLen_Click(sender, e);
            if (ckbAutoCalcChk.Checked) { btnCalcHCS_Click(sender, e); btnCalcFCS_Click(sender, e); }

            string txString = "";
            txString = (ckbAPDUDiv.Checked) ? (tb68.Text + tbLen.Text + tbCtl.Text + tbAF.Text + tbSA.Text + tbCA.Text + tbHCS.Text + tbAPDU_1.Text + tbAPDU_2.Text
                + tbAPDU_3.Text + tbAPDU_4.Text + tbAPDU_5.Text + tbAPDU_6.Text + tbFCS.Text + tb16.Text) :
                (tb68.Text + tbLen.Text + tbCtl.Text + tbAF.Text + tbSA.Text + tbCA.Text + tbHCS.Text + tbAPDU.Text + tbFCS.Text + tb16.Text);
            txString = txString.Replace(" ", "").Replace("\r", "").Replace("\n", "");

            if (tbLen.Text.Replace(" ", "").Length != 4
                || tbCtl.Text.Replace(" ", "").Length != 2
                || tbAF.Text.Replace(" ", "").Length != 2
                || tbSA.Text.Replace(" ", "").Length < 2
                || tbCA.Text.Replace(" ", "").Length != 2
                || tbHCS.Text.Replace(" ", "").Length != 4
                || tbFCS.Text.Replace(" ", "").Length != 4
                //|| tbAPDU.Text.Replace(" ", "").Replace("\r", "").Replace("\n", "").Length < 2
                || txString.Length % 2 == 1)
            {
                MessageBox.Show("请输入正确帧！");
                return;
            }

            Protocol698 p698 = new Protocol698();
            string res = p698.SendAndRecv(txString);
            if (res != null && res.Length > 0)
            {
                string[] frm = new string[res.Length / 2];
                for (int i = 0; i < res.Length / 2; i++)
                {
                    frm[i] = res.Substring(i * 2, 2);
                }
                int frmLen = Convert.ToInt16(frm[2] + frm[1], 16) + 2;
                if (frmLen != frm.Length) return;

                OldVerDisp698(frm);//旧版报文接收
                if (!ckbOldVerDisp.Checked)
                {
                    NewVerDisp698(res);//新版报文接收
                }
            }
        }

        private void OldVerDisp698(string[] frm)
        {
            //分框接收报文
            tbLen2.Text = frm[1] + " " + frm[2];
            tbCtl2.Text = frm[3];
            tbAF2.Text = frm[4];
            int saLen = (Convert.ToInt16(frm[4]) & 0x07) + 1;
            for (int i = 0; i < saLen; i++)
            {
                tbSA2.Text += (frm[5 + i] + " ");
            }
            tbCA2.Text = frm[5 + saLen];
            tbHCS2.Text = frm[6 + saLen] + " " + frm[7 + saLen];
            for (int i = 8 + saLen; i < frm.Length - 3; i++)
            {
                tbAPDU2.Text += (frm[i] + " ");
            }
            tbFCS2.Text = frm[frm.Length - 3] + " " + frm[frm.Length - 2];
        }
        private void AddDispTxt(string strInput, Color fontColor)
        {
            int start = tb698Explain.Text.Length;
            tb698Explain.AppendText(strInput + "\r\n");

            int p1 = tb698Explain.Text.IndexOf(strInput, start);
            int p2 = strInput.Length;
            //tb698Explain.ForeColor = Color.Black;
            tb698Explain.Select(p1, p2);
            tb698Explain.SelectionColor = fontColor;
            tb698Explain.Refresh();
        }
        private void NewVerDisp698(string frm)
        {
            Frame698 frame = new Frame698(frm);
            if (!frame.IsValidFrame) return;
            AddDispTxt(frame.FrameStart68 + "    ── 帧起始符", Color.Gray);
            AddDispTxt(frame.LengthFrame + " ── 长度域L=" + frame.Length + "字节", Color.Gray);
            AddDispTxt(frame.CtrlStr + "    ── 控制域C", Color.Gray);
            AddDispTxt(frame.SaFrame + "   ── SA", Color.Gray);
            AddDispTxt(frame.CaStr + "    ── CA", Color.Gray);
            AddDispTxt(frame.HcsFrame + " ── HCS 帧头校验", Color.Gray);
            AddDispTxt("──────────────────APDU──────────────────", Color.Black);
            AddDispTxt(frame.ApduFrame, Color.Black);
            AddDispTxt("─────────────────End APDU─────────────────", Color.Black);
            AddDispTxt(frame.FcsFrame + " ── FCS 帧校验", Color.Gray);
            AddDispTxt(frame.FrameEnd16 + "    ── 帧结束符", Color.Gray);
        }
        private void NewVerDisp698(string[] frm)
        {
            //XDocument xd = XDocument.Load("xml698Data.xml");
            //XElement rt = xd.Element("Data");
            int frmLen = frm.Length;
            int posNum = 0;

            tb698Explain.AppendText(frm[posNum++] + "    ── 帧起始符\r\n");
            tb698Explain.AppendText(frm[posNum++] + " " + frm[posNum++] + " ── 长度域L=" + Convert.ToInt16(frm[posNum] + frm[posNum - 1], 16) + "字节\r\n");

            string ctrl = "";
            int c = Convert.ToInt16(frm[posNum], 16);
            switch (c & 0xc0)
            {
                case 0x00: ctrl += "[DIR=0,PRM=0,客户机对服务器上报的响应]"; break;
                case 0x40: ctrl += "[DIR=0,PRM=1,客户机发起的请求]"; break;
                case 0x80: ctrl += "[DIR=1,PRM=0,服务器发起的上报]"; break;
                case 0xc0: ctrl += "[DIR=1,PRM=1,服务器对客户机请求的响应]"; break;
            }
            switch (c & 0x20)
            {
                case 0x00: ctrl += "[不分帧]"; break;
                case 0x20: ctrl += "[分帧]"; break;
            }
            switch (c & 0x07)
            {
                case 0x01: ctrl += "[功能码(1):链路管理]"; break;
                case 0x03: ctrl += "[功能码(3):用户数据]"; break;
                default: ctrl += "[功能码(" + Convert.ToString(c & 0x07) + "):保留]"; break;
            }
            tb698Explain.AppendText(frm[posNum++] + "    ── 控制域C " + ctrl + "\r\n");
            int af = Convert.ToInt16(frm[posNum], 16);
            string strAf = "";
            switch (af & 0xc0)
            {
                case 0x00: strAf += "[单地址]"; break;
                case 0x01: strAf += "[通配地址]"; break;
                case 0x02: strAf += "[组地址]"; break;
                case 0x03: strAf += "[广播地址]"; break;
            }
            strAf += "[逻辑地址:" + (af & 0x30).ToString() + "]";
            strAf += "[地址长度:" + ((af & 0x0f) + 1).ToString() + "]";

            tb698Explain.AppendText(frm[posNum++]);
            for (int i = 0; i < (af & 0x0f) + 1; i++)
            {
                tb698Explain.AppendText(frm[posNum++]);
            }
            tb698Explain.AppendText(" ── SA " + strAf + "\r\n");
            tb698Explain.AppendText(frm[posNum++] + "    ── CA\r\n");
            tb698Explain.AppendText(frm[posNum++] + " " + frm[posNum++] + " ── HCS 帧头校验\r\n");
            tb698Explain.AppendText("──────────────────APDU──────────────────\r\n");
            switch (frm[posNum++])
            {
                case "01": tb698Explain.AppendText("01 ── APDU Tag [1] LINK-Response\r\n"); break;
                case "02": tb698Explain.AppendText("02 ── APDU Tag [2] CONNECT-Request\r\n"); break;
                case "03": tb698Explain.AppendText("03 ── APDU Tag [3] RELEASE-Request\r\n"); break;
                case "05": tb698Explain.AppendText("05 ── APDU Tag [5] GET-Request\r\n"); break;
                case "06": tb698Explain.AppendText("06 ── APDU Tag [6] SET-Request\r\n"); break;
                case "07": tb698Explain.AppendText("07 ── APDU Tag [7] ACTION-Request\r\n"); break;
                case "08": tb698Explain.AppendText("08 ── APDU Tag [8] REPORT-Response\r\n"); break;
                case "09": tb698Explain.AppendText("09 ── APDU Tag [9] PROXY-Request\r\n"); break;
                case "10": tb698Explain.AppendText("10 ── APDU Tag [16] SECURITY-Request\r\n"); break;
                case "81": tb698Explain.AppendText("81 ── APDU Tag [129] LINK-Request\r\n"); break;
                case "82": tb698Explain.AppendText("82 ── APDU Tag [130] CONNECT-Response\r\n"); break;
                case "83": tb698Explain.AppendText("83 ── APDU Tag [131] RELEASE-Response\r\n"); break;
                case "84": tb698Explain.AppendText("84 ── APDU Tag [132] RELEASE-Notification\r\n"); break;
                case "85"://GET-Response
                    {
                        #region GET-Response
                        tb698Explain.AppendText("85 ── APDU Tag [133] GET-Response\r\n");
                        switch (frm[posNum++])
                        {
                            case "01": //GetResponseNormal
                                {
                                    tb698Explain.AppendText("01 ── [1] GetResponseNormal\r\n");
                                    tb698Explain.AppendText(frm[posNum++] + " ── PIID-ACD\r\n");
                                    tb698Explain.AppendText(frm[posNum++] + frm[posNum++] + " " + frm[posNum++] + frm[posNum++] + " ── OAD\r\n");
                                    switch (frm[posNum++])
                                    {
                                        case "00":
                                            {
                                                tb698Explain.AppendText("00 ── DAR\r\n");
                                                int tmp = Convert.ToInt16(frm[posNum]);
                                                string darType = Protocol698.GetDARType(tmp);
                                                tb698Explain.AppendText(frm[posNum++] + " ── DAR [" + tmp + darType + "]\r\n");
                                                break;
                                            }
                                        case "01":
                                            {
                                                tb698Explain.AppendText("01 ── Data\r\n");
                                                int tmp = Convert.ToInt16(frm[posNum], 16);
                                                string dataType = Protocol698.GetDataType(tmp);
                                                tb698Explain.AppendText(frm[posNum++] + " ── 数据类型:[" + dataType + "]\r\n");
                                                int size = Convert.ToInt16(frm[posNum], 16);
                                                tb698Explain.AppendText(frm[posNum++] + " ── SIZE(" + size + ")\r\n");
                                                string data = "";
                                                for (int i = posNum; i < frmLen - 5; i++)
                                                {
                                                    data += frm[posNum++];
                                                }
                                                tb698Explain.AppendText(data);
                                                switch (dataType)
                                                {
                                                    case "date_time":
                                                        {
                                                            int year = Convert.ToInt16(data.Substring(0, 4), 16);
                                                            int month = Convert.ToInt16(data.Substring(4, 2), 16);
                                                            int day_of_month = Convert.ToInt16(data.Substring(6, 2), 16);
                                                            int day_of_week = Convert.ToInt16(data.Substring(8, 2), 16);
                                                            int hour = Convert.ToInt16(data.Substring(10, 2), 16);
                                                            int minute = Convert.ToInt16(data.Substring(12, 2), 16);
                                                            int second = Convert.ToInt16(data.Substring(14, 2), 16);
                                                            int milliseconds = Convert.ToInt16(data.Substring(16), 16);
                                                            tb698Explain.AppendText(" ── " + year + "-" + month + "-" + day_of_month + "-"
                                                                + "周" + day_of_week + " " + hour + ":" + minute + ":" + second + ":" + milliseconds + "\r\n");
                                                            break;
                                                        }
                                                    case "date":
                                                        {
                                                            int year = Convert.ToInt16(data.Substring(0, 4), 16);
                                                            int month = Convert.ToInt16(data.Substring(4, 2), 16);
                                                            int day_of_month = Convert.ToInt16(data.Substring(6, 2), 16);
                                                            int day_of_week = Convert.ToInt16(data.Substring(8, 2), 16);
                                                            tb698Explain.AppendText(" ── " + year + "-" + month + "-" + day_of_month + "-"
                                                                + "周" + day_of_week + "\r\n");
                                                            break;
                                                        }
                                                    case "time":
                                                        {
                                                            int hour = Convert.ToInt16(data.Substring(0, 2), 16);
                                                            int minute = Convert.ToInt16(data.Substring(2, 2), 16);
                                                            int second = Convert.ToInt16(data.Substring(4, 2), 16);
                                                            tb698Explain.AppendText(" ── " + hour + ":" + minute + ":" + second + "\r\n");
                                                            break;
                                                        }
                                                    case "date_time_s":
                                                        {
                                                            int year = Convert.ToInt16(data.Substring(0, 4), 16);
                                                            int month = Convert.ToInt16(data.Substring(4, 2), 16);
                                                            int day = Convert.ToInt16(data.Substring(6, 2), 16);
                                                            int hour = Convert.ToInt16(data.Substring(8, 2), 16);
                                                            int minute = Convert.ToInt16(data.Substring(10, 2), 16);
                                                            int second = Convert.ToInt16(data.Substring(12), 16);
                                                            tb698Explain.AppendText(" ── " + year + "-" + month + "-" + day + " "
                                                                + hour + ":" + minute + ":" + second + "\r\n");
                                                            break;
                                                        }
                                                    default: tb698Explain.AppendText("\r\n"); break;
                                                }
                                                break;
                                            }
                                        default: tb698Explain.AppendText("返回错误\r\n"); break;
                                    }
                                    break;
                                }
                            case "02"://GetResponseNormallist
                                {
                                    break;
                                }
                            case "03"://GetResponseRecord
                                {
                                    break;
                                }
                            case "04"://GetResponseRecordList
                                {
                                    break;
                                }
                            case "05"://GetResponseNext
                                {
                                    break;
                                }
                        }
                        break;
                        #endregion
                    }
                case "86":
                    {
                        #region SET-Response
                        tb698Explain.AppendText("86 ── APDU Tag [134] SET-Response\r\n");
                        switch (frm[posNum++])
                        {
                            case "01": //SetResponseNormal
                                {
                                    tb698Explain.AppendText("01 ── [1] SetResponseNormal\r\n");
                                    tb698Explain.AppendText(frm[posNum++] + " ── PIID-ACD\r\n");
                                    tb698Explain.AppendText(frm[posNum++] + frm[posNum++] + " " + frm[posNum++] + frm[posNum++] + " ── OAD\r\n");
                                    int tmp = Convert.ToInt16(frm[posNum]);
                                    string darType = Protocol698.GetDARType(tmp);
                                    tb698Explain.AppendText(frm[posNum++] + " ── DAR [" + tmp + darType + "]\r\n");
                                    break;
                                }
                            case "02": //SetResponseNormalList
                                {
                                    tb698Explain.AppendText("02 ── [2] SetResponseNormalList\r\n");
                                    tb698Explain.AppendText(frm[posNum++] + " ── PIID-ACD\r\n");
                                    int num = Convert.ToInt16(frm[posNum], 16);
                                    tb698Explain.AppendText(frm[posNum++] + " ── SEQUENCE OF的个数=" + num + "\r\n");
                                    for (int i = 0; i < num; i++)
                                    {
                                        tb698Explain.AppendText(frm[posNum++] + frm[posNum++] + " " + frm[posNum++] + frm[posNum++] + " ── OAD" + (i + 1) + "\r\n");
                                        int tmp = Convert.ToInt16(frm[posNum]);
                                        string darType = Protocol698.GetDARType(tmp);
                                        tb698Explain.AppendText(frm[posNum++] + " ── DAR [" + tmp + darType + "]\r\n");
                                    }
                                    break;
                                }
                            case "03": //SetThenGetResponseNormalList
                                {
                                    tb698Explain.AppendText("03 ── [3] SetResponseNormalList\r\n");
                                    tb698Explain.AppendText(frm[posNum++] + " ── PIID-ACD\r\n");
                                    int num = Convert.ToInt16(frm[posNum], 16);
                                    tb698Explain.AppendText(frm[posNum++] + " ── SEQUENCE OF的个数=" + num + "\r\n");
                                    for (int i = 0; i < num; i++)
                                    {
                                        tb698Explain.AppendText(frm[posNum++] + frm[posNum++] + " " + frm[posNum++] + frm[posNum++] + " ── set OAD" + (i + 1) + "\r\n");
                                        int tmp = Convert.ToInt16(frm[posNum]);
                                        string darType = Protocol698.GetDARType(tmp);
                                        tb698Explain.AppendText(frm[posNum++] + " ── DAR [" + tmp + darType + "]\r\n");
                                    }
                                    tb698Explain.AppendText(frm[posNum++] + frm[posNum++] + " " + frm[posNum++] + frm[posNum++] + " ── read OAD" + "\r\n");
                                    for (int i = posNum; i < frmLen - 5; i++)
                                    {
                                        tb698Explain.AppendText(frm[posNum++]);
                                    }
                                    tb698Explain.AppendText(" ── Data\r\n");
                                    break;
                                }
                            default: tb698Explain.AppendText("返回错误\r\n"); break;
                        }
                        break;
                        #endregion
                    }
                case "87": tb698Explain.AppendText("87 ── APDU Tag [135] ACTION-Response\r\n"); break;
                case "88": tb698Explain.AppendText("88 ── APDU Tag [136] REPORT-Notification\r\n"); break;
                case "89": tb698Explain.AppendText("89 ── APDU Tag [137] PROXY-Response\r\n"); break;
                case "90": tb698Explain.AppendText("90 ── APDU Tag [144] SECURITY-Response\r\n"); break;
                default: tb698Explain.AppendText("返回错误\r\n"); break;
            }
            tb698Explain.AppendText(frm[frmLen - 5] + " ── FollowReport\r\n");
            tb698Explain.AppendText(frm[frmLen - 4] + " ── 时间标签\r\n");
            tb698Explain.AppendText("─────────────────End APDU─────────────────\r\n");
            tb698Explain.AppendText(frm[frmLen - 3] + " " + frm[frmLen - 2] + " ── FCS\r\n");
            tb698Explain.AppendText(frm[frmLen - 1] + "    ── 结束符\r\n");
            tb698Explain.AppendText("------------------------------------------------------------------------------------\r\n\r\n\r\n");
        }

        private void btnClrData_Click(object sender, EventArgs e)
        {
            tbLen2.Text = "";
            tbCtl2.Text = "";
            tbAF2.Text = "";
            tbSA2.Text = "";
            tbCA2.Text = "";
            tbHCS2.Text = "";
            tbAPDU2.Text = "";
            tbFCS2.Text = "";
        }

        private void ckbAPDUDiv_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAPDUDiv.Checked)
            {
                tbAPDU_1.Visible = true;
                tbAPDU_2.Visible = true;
                tbAPDU_3.Visible = true;
                tbAPDU_4.Visible = true;
                tbAPDU_5.Visible = true;
                tbAPDU_6.Visible = true;
                tbAPDU.Visible = false;
            }
            else
            {
                tbAPDU_1.Visible = false;
                tbAPDU_2.Visible = false;
                tbAPDU_3.Visible = false;
                tbAPDU_4.Visible = false;
                tbAPDU_5.Visible = false;
                tbAPDU_6.Visible = false;
                tbAPDU.Visible = true;
            }
        }

        private void ckbAutoCalcChk_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAutoCalcChk.Checked)
            {
                btnCalcFCS.Visible = false;
                btnCalcHCS.Visible = false;
                tbHCS.Width = 227;
                tbFCS.Width = 227;
            }
            else
            {
                btnCalcFCS.Visible = true;
                btnCalcHCS.Visible = true;
                tbHCS.Width = 100;
                tbFCS.Width = 100;
            }
        }

        private void ckbAutoCalcLen_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAutoCalcLen.Checked)
            {
                btnCalcLen.Visible = false;
                tbLen.Width = 227;
            }
            else
            {
                btnCalcLen.Visible = true;
                tbLen.Width = 100;
            }
        }

        private void ckbOldVerDisp_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbOldVerDisp.Checked)
            {
                tb698Explain.Visible = false;
                ckbClearBefore.Enabled = false;
            }
            else
            {
                tb698Explain.Visible = true;
                ckbClearBefore.Enabled = true;
            }
        }

        #region 数据处理
        private void button1_Click(object sender, EventArgs e)
        {
            tb10Data.Text = "";
            Functions.Delay(50);

            string stringNum16 = tb16Data.Text.ToUpper().Replace(" ", "");
            string charTable = "0123456789ABCDEF";
            long intNum10 = 0;

            if (stringNum16 == "") return;
            foreach (char c in stringNum16)
            {
                if (!charTable.Contains(c))
                {
                    MessageBox.Show("请输入有效字符");
                    return;
                }
            }

            if (stringNum16.Length % 2 != 0)
            {
                MessageBox.Show("请输入足够的字节数！");
                return;
            }

            if (ckbChangeByByte.Checked)
            {
                for (int i = 0; i < stringNum16.Length; i += 2)
                {
                    intNum10 = Convert.ToInt16(stringNum16.Substring(i, 2), 16);
                    tb10Data.Text += (intNum10.ToString() + " ");
                }
            }
            else
            {
                intNum10 = Convert.ToInt64(stringNum16, 16);
                tb10Data.Text = intNum10.ToString();
            }
        }

        private void btn10to16_Click(object sender, EventArgs e)
        {
            tb16Data.Text = "";
            Functions.Delay(50);

            string stringNum10 = tb10Data.Text.Replace(" ", "");
            string[] stringArrayNum10 = tb10Data.Text.Trim().Split(' ');
            string charTable = "0123456789";
            byte byteNum16 = 0;
            long intNum16 = 0;

            if (stringNum10 == "") return;
            foreach (char c in stringNum10)
            {
                if (!charTable.Contains(c))
                {
                    MessageBox.Show("请输入有效字符");
                    return;
                }
            }
            if (ckbChangeByByte.Checked)
            {
                for (int i = 0; i < stringArrayNum10.Length; i++)
                {
                    byteNum16 = Convert.ToByte(stringArrayNum10[i], 10);
                    tb16Data.Text += (byteNum16.ToString("X2") + " ");
                }
            }
            else
            {
                intNum16 = Convert.ToInt64(stringNum10, 10);
                tb16Data.Text = intNum16.ToString("X");
            }
        }

        private void tbSub33_Click(object sender, EventArgs e)
        {
            tbAfter33.Text = "";
            Functions.Delay(50);

            string strBeforeAdd33 = tbBefore33.Text.ToUpper().Replace(" ", string.Empty);
            string charTable = "0123456789ABCDEF";

            if (strBeforeAdd33 == "") return;
            foreach (char c in strBeforeAdd33)
            {
                if (!charTable.Contains(c))
                {
                    MessageBox.Show("请输入有效字符");
                    return;
                }
            }

            if (strBeforeAdd33.Length % 2 != 0)
            {
                MessageBox.Show("请输入足够的字节数！");
                return;
            }

            byte[] hexBeforeSub33 = new byte[strBeforeAdd33.Length / 2];
            for (int i = 0; i < strBeforeAdd33.Length / 2; i++)
            {
                hexBeforeSub33[i] = Convert.ToByte(strBeforeAdd33.Substring(i * 2, 2), 16);
                tbAfter33.AppendText(((byte)((hexBeforeSub33[i] - 0x33) % 256)).ToString("X2") + " ");
            }
        }

        private void btnAdd33_Click(object sender, EventArgs e)
        {
            tbBefore33.Text = "";
            Functions.Delay(50);

            string strBeforeAdd33 = tbAfter33.Text.ToUpper().Replace(" ", string.Empty);
            string charTable = "0123456789ABCDEF";

            if (strBeforeAdd33 == "") return;
            foreach (char c in strBeforeAdd33)
            {
                if (!charTable.Contains(c))
                {
                    MessageBox.Show("请输入有效字符");
                    return;
                }
            }

            if (strBeforeAdd33.Length % 2 != 0)
            {
                MessageBox.Show("请输入足够的字节数！");
                return;
            }

            string strAfterAdd33 = Counter.StringAdd33(strBeforeAdd33);
            for (int i = 0; i < strAfterAdd33.Length / 2; i++)
            {
                tbBefore33.AppendText(strAfterAdd33.Substring(2 * i, 2) + " ");
            }
        }

        #endregion

        #region 698通信测试
        private bool ComTest698Flag = false;
        private string Addr = string.Empty;
        private int SendCnt = 0;
        private int SuccessCnt = 0;
        private string Oads = string.Empty;
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!Functions.IsNum(txtCnt.Text))
            {
                MessageBox.Show("测试次数请填入数字");
                return;
            }
            int cnt = int.Parse(txtCnt.Text);
            if (cnt < 0) return;

            if (btnTest.Text == "开始测试")
            {
                Oads = txtOad.Text.Replace(" ", "").Replace("\r", "").Replace("\n", ""); ;
                if (Oads.Length % 8 != 0)
                {
                    MessageBox.Show("OAD不正确！");
                    return;
                }
                SendCnt = 0;
                SuccessCnt = 0;
                Protocol698 p698 = new Protocol698();
                Addr = p698.ReadAddr();
                if (Addr.Length == 0)
                {
                    MessageBox.Show("读表地址失败！");
                }

                ComTest698Flag = true;
                Control.CheckForIllegalCrossThreadCalls = false;//不检查跨线程的调用是否合法
                TestThread = new Thread(new ThreadStart(Comm698Test));
                TestThread.IsBackground = true;
                TestThread.Start();
            }
            if (btnTest.Text == "停止测试")
            {
                ComTest698Flag = false;
                if (TestThread.IsAlive) //判断SetTimeEventTestThread是否存在，不能撤消一个不存在的线程，否则会引发异常
                {
                    TestThread.Abort(); //撤消SetTimeEventTestThread
                }
            }

            btnTest.Text = (ComTest698Flag ? "停止测试" : "开始测试");
        }

        private void Comm698Test()
        {
            int oadCnt = Oads.Length / 8;
            string[] oad = new string[oadCnt];
            for (int i = 0; i < oadCnt; i++)
            {
                oad[i] = Oads.Substring(i * 8, 8);
            }

            int cnt = int.Parse(txtCnt.Text);
            if (cnt == 0)
            {
                cnt = 1000000;
            }

            Protocol698 p698 = new Protocol698();
            for (int i = 0; i < cnt; i++)
            {
                string txString = string.Empty;
                txString = "681700" + "43" + (Addr.Length / 2 - 1).ToString("x2") + Addr.ReverseStr() + "10";
                txString += GetCs(txString.Substring(2));
                txString += "050101";
                Random ro = new Random();
                int rand = ro.Next(oadCnt);
                txString += oad[rand];
                txString += "00";
                txString += GetCs(txString.Substring(2));
                txString += "16";

                string res = string.Empty;
                SendCnt++;

                string ret = p698.SendAndRecv(txString);
                if (ret != null && ret.Length > 0)
                {
                    if (res.Length != 0)
                    {
                        SuccessCnt++;
                    }
                }
                double rate = SuccessCnt / SendCnt * 100;
                txtRate.Text = SuccessCnt + "/" + SendCnt + "*100% = " + rate.ToString() + "%";
            }
            btnTest.Text = "开始测试";
            if (TestThread.IsAlive) //判断SetTimeEventTestThread是否存在，不能撤消一个不存在的线程，否则会引发异常
            {
                TestThread.Abort(); //撤消SetTimeEventTestThread
            }
        }
        #endregion

        private void btnReadEsamInfo_Click(object sender, EventArgs e)
        {
            txt698EsamSerial.Text = string.Empty;
            txt698KeyVer.Text = string.Empty;
            txt698CommTimeLimit.Text = string.Empty;
            txt698CommRestTime.Text = string.Empty;
            txt698Counter.Text = string.Empty;
            txt698EsamVer.Text = string.Empty;
            txt698MeterNo.Text = string.Empty;
            txtApdu.Text = string.Empty;
            Functions.Delay(10);

            Protocol698 p698 = new Protocol698();
            byte[] ret = p698.ReadData("F1000200" + "F1000400" + "F1000500" + "F1000600" + "F1000700" + "40020200" + "F1000300");
            string strApdu = ret.ToHexString();
            txtApdu.Text = strApdu;

            int esamSerialNoStart = strApdu.IndexOf("F1000200") + 8 + 6;//序列号
            txt698EsamSerial.Text = strApdu.Substring(esamSerialNoStart, 16);
            Protocol698.SerialNo = Transfer.StrToByte(txt698EsamSerial.Text);

            int keyVerStart = strApdu.IndexOf("F1000400") + 8 + 6;//对称密钥版本
            txt698KeyVer.Text = strApdu.Substring(keyVerStart, 32);

            int commLimitStart = strApdu.IndexOf("F1000500") + 8 + 4;//会话时效门限
            txt698CommTimeLimit.Text = strApdu.Substring(commLimitStart, 8);

            int commRestTimeStart = strApdu.IndexOf("F1000600") + 8 + 4;//会话时效剩余时间
            txt698CommRestTime.Text = strApdu.Substring(commRestTimeStart, 8);

            int counterStart = strApdu.IndexOf("F1000700") + 8 + 8;//当前计数器
            txt698Counter.Text = strApdu.Substring(counterStart, 8);

            int esamVerStart = strApdu.IndexOf("F1000300") + 8 + 6;//ESAM版本号
            txt698EsamVer.Text = strApdu.Substring(esamVerStart, 10);

            int meterNoStart = strApdu.IndexOf("40020200") + 8 + 6;//表号
            txt698MeterNo.Text = strApdu.Substring(meterNoStart, 12);
            Protocol698.MeterNo = Transfer.StrToByte(txt698MeterNo.Text);

            txtCommState.Text = "未协商或已失效";
            txtCommState.BackColor = Color.Red;
            txtCommCertState.Text = "未协商或已失效";
            txtCommCertState.BackColor = Color.Red;
            txtConnectState.Text = "未连接或已失效";
            txtConnectState.BackColor = Color.Red;
        }

        private void txt698Addr_TextChanged(object sender, EventArgs e)
        {
            Protocol698.Addr = txt698Addr.Text;
        }

        private void btnRead698Addr_Click(object sender, EventArgs e)
        {
            txt698Addr.Text = string.Empty;
            Functions.Delay(10);
            Protocol698 p698 = new Protocol698();
            txt698Addr.Text = p698.ReadAddr();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Consult consult = new Consult();
            consult.ProtocolVer = txtProtocolVer.Text;
            consult.ProtocolConformance = txtProtocolConformance.Text;
            consult.FunctionConformance = txtFunctionConformance.Text;
            int txMaxSize = int.Parse(txtTxMaxSize.Text);
            consult.TxMaxSize = (txMaxSize >> 8).ToString("X2") + (txMaxSize & 0x00ff).ToString("X2");
            int rxMaxSize = int.Parse(txtRxMaxSize.Text);
            consult.RxMaxSize = (rxMaxSize >> 8).ToString("X2") + (rxMaxSize & 0x00ff).ToString("X2");
            int maxSizeFrmNum = int.Parse(txtMaxSizeFrmNum.Text);
            consult.MaxSizeFrmNum = maxSizeFrmNum.ToString("X2");
            int maxApduSize = int.Parse(txtMaxApduSize.Text);
            consult.MaxApduSize = (maxApduSize >> 8).ToString("X2") + (maxApduSize & 0x00ff).ToString("X2");
            int overTime = int.Parse(txtOverTime.Text);
            consult.OverTime = (overTime >> 24).ToString("X2") + (overTime >> 16).ToString("X2") +(overTime >> 8).ToString("X2") + (overTime & 0x00ff).ToString("X2");
            consult.SecurityRule = comboBoxSecurityRule.SelectedIndex.ToString("X2");
            Protocol698 p698 = new Protocol698();
            p698.Connect(txt698KeyVer.Text, consult);
        }

        private void UpdateProtocol698Attribute(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb == txt698EsamSerial)
            {
                try
                {
                    Protocol698.SerialNo = Transfer.StrToByte(tb.Text);
                }
                catch
                {
                }
            }
            if (tb == txt698MeterNo)
            {
                try
                {
                    Protocol698.MeterNo = Transfer.StrToByte(tb.Text);
                }
                catch
                {
                }
            }
            if (tb == txt698Counter)
            {
                try
                {
                    Protocol698.ASCTR = Convert.ToInt32(tb.Text, 16);
                }
                catch
                {
                }
            }
        }

        private void btnCountCRC_Click(object sender, EventArgs e)
        {
            string frm = txtFrm645.Text.Replace(" ", "");
            if (frm.Length % 2 != 0)
            {
                MessageBox.Show("报文错");
                return;
            }

            byte[] byteFrm = Transfer.StrToByte(frm);
            int sum = 0;
            foreach (byte b in byteFrm)
            {
                sum += b;
            }
            int crc = sum % 256;
            MessageBox.Show("校验和为：" + crc.ToString("X2"));
        }
    }
}
