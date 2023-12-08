using System;
using System.Windows.Forms;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelEsamAndCtrol : UserControl
    {
        public override string Text { get => "ESAM/费控"; }
        private Timer timerPCTime = new Timer();
        public PanelEsamAndCtrol()
        {
            InitializeComponent();
        }

        #region 控制功能
        int timeCountDown_mm = 0;
        int timeCountDown_ss = 59;
        private void btn控制功能_Click_1(object sender, EventArgs e)
        {
            string endTime = tbEndTime.Text;
            if (endTime.Length != 12)
            {
                MessageBox.Show("命令有效截止长度不足！");
                return;
            }

            //倒计时控制
            if (rbYutiaozha1.Checked || rbYutiaozha2.Checked)
            {
                string x = tbYutiaozhaTime.Text;
                x = (Convert.ToInt16(x, 16) * 5).ToString("X2");
                x = x.Substring(x.Length - 2, 2);
                timeCountDown_mm = Convert.ToInt16(x, 16);
                lblTimeCountDown.Text = "倒计时：" + timeCountDown_mm.ToString("D4") + ":00";
                timeCountDown_mm--;
                timeCountDown_ss = 60;
                if (timerPCTime.Enabled)
                {
                    timerPCTime.Stop();
                }
                timerPCTime.Interval = 1000;
                this.timerPCTime.Tick -= new EventHandler(TimeCountDown);
                this.timerPCTime.Tick += new EventHandler(TimeCountDown);
                timerPCTime.Start();
            }
            #region 控制
            string N1N2 = null;
            if (rbTiaozha.Checked) N1N2 = "1A00";//跳闸
            if (rbYunxuhezha.Checked) N1N2 = "1B00";//允许合闸
            if (rbZhijiehezha.Checked) N1N2 = "1C00";//直接合闸
            if (rbYutiaozha1.Checked)
            {
                string ss = tbYutiaozhaTime.Text.PadLeft(2, '0');
                N1N2 = "1D" + ss;
            }
            if (rbYutiaozha2.Checked)
            {
                string ss = tbYutiaozhaTime.Text.PadLeft(2, '0');
                N1N2 = "1E" + ss;
            }
            if (rbBaojing.Checked) N1N2 = "2A00";
            if (rbJiechubaojing.Checked) N1N2 = "2B00";
            if (rbBaodian.Checked) N1N2 = "3A00";
            if (rbJiechubaodian.Checked) N1N2 = "3B00";

            Protocol645 p645 = new Protocol645();
            //明文模式
            if (rbMingwen.Checked)
            {
                string putData = endTime + Transfer.ReverseString(N1N2);
                if (p645.FeikongControl(putData))
                {
                    MessageBox.Show("操控成功！");
                }
                else
                {
                    MessageBox.Show("操控失败！");
                }
            }
            //密文模式
            if (rbMiwen.Checked)
            {
                string orginalPsw = Protocol645.Psw;
                Esam645Service.EsamOptionClient ESAMproxy = new Esam645Service.EsamOptionClient();//要操作时才new
                try
                {
                    string putData = N1N2 + endTime;
                    string enData = ESAMproxy.Meter_Formal_UserControl(0, tbRand2.Text, tbDiv.Text, tbEsamNo.Text, putData);

                    Protocol645.Psw = orginalPsw.Substring(0, 6) + "98";//临时改为98级密码
                    if (p645.FeikongControl(enData))
                    {
                        MessageBox.Show("操控成功！");
                    }
                    else
                    {
                        MessageBox.Show("操控失败！");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                finally
                {
                    ESAMproxy.Close();
                    Protocol645.Psw = orginalPsw;//用后要改回原界面密码，否则影响其他功能使用
                }
            }
            #endregion
        }

        //分、秒倒计时
        private void TimeCountDown(object sender, EventArgs e)
        {
            if (timeCountDown_mm >= 0)
            {
                timeCountDown_ss--;
                lblTimeCountDown.Text = "倒计时：" + timeCountDown_mm.ToString("D4") + ":" + timeCountDown_ss.ToString("D2");
                if (timeCountDown_ss == 0)
                {
                    if (timeCountDown_mm != 0)
                    {
                        timeCountDown_mm--;
                        timeCountDown_ss = 60;
                    }
                    else
                    {
                        timerPCTime.Stop();
                    }
                }
            }
        }
        #endregion

        private void btn身份认证_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            Esam645Service.EsamOptionClient ESAMproxy = new Esam645Service.EsamOptionClient();//要操作时才new
            string meterNum = "000000000000";
            if (p645.ReadData("04000402", out meterNum))
            {
                tbDiv.Text = "0000" + meterNum;
            }
            else
                MessageBox.Show("读表号出错！");
            Functions.Delay(100);
            int flag = 0;//公钥为0
            if (rbFlagPri.Checked) flag = 1;//私钥为1
            try
            {
                tbRand.Text = ESAMproxy.Meter_Formal_IdentityAuthentication(flag, tbDiv.Text).OutRand;//取随机数
                tbEndata.Text = ESAMproxy.Meter_Formal_IdentityAuthentication(flag, tbDiv.Text).OutEndata;//取密文
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Functions.Delay(100);
            string result = null;
            if (p645.SecurityAuthentication("070000FF", tbDiv.Text + tbRand.Text + tbEndata.Text, out result))
            {
                tbEsamNo.Text = result.Substring(0, 16);
                tbRand2.Text = result.Substring(16);
            }
            else//身份认证经常不成功，试多一次又好了，什么鬼。。。那我就试多一次吧。。。
                if (p645.SecurityAuthentication("070000FF", tbDiv.Text + tbRand.Text + tbEndata.Text, out result))
            {
                tbEsamNo.Text = result.Substring(0, 16);
                tbRand2.Text = result.Substring(16);
            }
            else
                MessageBox.Show("身份认证失败！");
            ESAMproxy.Close();//每次操作完都要关掉!!!真讨厌，老贺你能不能做成自动关掉的啊。。
        }

        private void btn身份认证失效_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            tbRegisterFal.Clear();
            Functions.Delay(100);
            string result = null;
            if (p645.SecurityAuthentication("070002FF", "", out result))
            {
                tbRegisterFal.AppendText("身份认证已失效！" + "\r\n");
                tbRegisterFal.AppendText("客户编号：" + result.Substring(24) + "\r\n");
                tbRegisterFal.AppendText("剩余金额(ESAM内)：" + result.Substring(16, 8) + "\r\n");
                tbRegisterFal.AppendText("购电次数(ESAM内)：" + result.Substring(8, 8) + "\r\n");
                tbRegisterFal.AppendText("密钥状态：" + result.Substring(0, 8) + "\r\n");
            }
            else MessageBox.Show("身份认证失效错误");
        }

        private void btn读认证时效_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbRenzhengshixiao, "02800022");
        }

        private void btn设认证时效_Click(object sender, EventArgs e)
        {
            if (Functions.IsNum(tbRenzhengshixiao.Text) && tbRenzhengshixiao.Text.Length == 4)
            {
                if (tbRand2.Text != "" && tbEsamNo.Text != "")
                {
                    Esam645Service.EsamOptionClient ESAMproxy = new Esam645Service.EsamOptionClient();//要操作时才new
                    try
                    {
                        string putApdu = "04D6822B0E";
                        string macStr = ESAMproxy.Meter_Formal_ParameterUpdate(0, tbRand2.Text, tbDiv.Text, putApdu, tbRenzhengshixiao.Text).MAC;
                        string putData = macStr + tbRenzhengshixiao.Text;
                        string ret = null;
                        Protocol645 p645 = new Protocol645();
                        p645.SecurityAuthentication("070001FF", putData, out ret);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    finally
                    {
                        ESAMproxy.Close();
                    }
                }
                else MessageBox.Show("请先身份认证！");
            }
            else MessageBox.Show("请输入4位数字时效！");
        }

        private void btn读认证状态_Click(object sender, EventArgs e)
        {
            string result = null;
            Protocol645 p645 = new Protocol645();
            if (p645.ReadData("04000503", out result))
            {
                int x = Convert.ToInt32(result, 16);
                if ((x & 0x2000) == 0x2000)
                    tbRenzhengState.Text = "身份认证有效";
                else
                    tbRenzhengState.Text = "身份认证无效";
            }
            else MessageBox.Show("读认证状态失败！");
        }

        private void btn清零操作_Click(object sender, EventArgs e)
        {
            if (tbRand2.Text != "" && tbEsamNo.Text != "")
            {
                if (tbEndTime.Text.Length != 12)
                {
                    MessageBox.Show("命令有效截止长度不足！");
                    return;
                }
                Esam645Service.EsamOptionClient ESAMproxy = new Esam645Service.EsamOptionClient();//要操作时才new
                try
                {
                    Protocol645 p645 = new Protocol645();
                    //电量清零
                    if (rbEnergyClr.Checked)
                    {
                        string putData = "1A00" + tbEndTime.Text;
                        string enData = ESAMproxy.Meter_Formal_DataClear1(0, tbRand2.Text, tbDiv.Text, putData);
                        if (p645.MeterClr(enData))
                        {
                            MessageBox.Show("电量清零成功！");
                        }
                        else MessageBox.Show("电量清零失败");
                    }
                    //事件清零
                    if (rbEvenClr.Checked)
                    {
                        if (tbEvenClrID.Text.Length != 8)
                        {
                            MessageBox.Show("请输入8位清零ID！");
                            return;
                        }
                        string putData = "1B00" + tbEndTime.Text + tbEvenClrID.Text;
                        string enData = ESAMproxy.Meter_Formal_DataClear2(0, tbRand2.Text, tbDiv.Text, putData);
                        if (p645.EventClear98(enData))
                        {
                            MessageBox.Show("事件清零成功！");
                        }
                        else MessageBox.Show("事件清零失败");
                    }
                    //需量清零
                    if (rbDemandClr.Checked)
                    {
                        string putData = "1900" + tbEndTime.Text;
                        string enData = ESAMproxy.Meter_Formal_DataClear2(0, tbRand2.Text, tbDiv.Text, putData);
                        if (p645.MaxDemandClear98(enData))
                        {
                            MessageBox.Show("需量清零成功！");
                        }
                        else MessageBox.Show("需量清零失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ESAMproxy.Close();
                }
            }
            else MessageBox.Show("请先身份认证！");
        }

        #region 一类参数
        private void btn表号读_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbMeterNo, "04000402");
        }

        private void btn电流变比读_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbCurrentCh, "04000306");
        }

        private void btn电压变比读_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbVolCh, "04000307");
        }

        private void btn报警金额1读_Click(object sender, EventArgs e)
        {
            string ret = null;
            Protocol645 p645 = new Protocol645();
            if (p645.ReadData("04001001", out ret))
            {
                tbWarr1.Text = ret.Insert(6, ".");
            }
        }

        private void btn报警金额2读_Click(object sender, EventArgs e)
        {
            string ret = null;
            Protocol645 p645 = new Protocol645();
            if (p645.ReadData("04001002", out ret))
            {
                tbWarr2.Text = ret.Insert(6, ".");
            }
        }

        private void btn费率切换时间读_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbRatesChTime, "04000108");
        }

        private void btn阶梯切换时间读_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbStepChTime, "04000109");
        }

        /// <summary>
        /// 99级权限写数据
        /// </summary>
        /// <param name="putApdu">5个字节命令头</param>
        /// <param name="dataID">数据ID</param>
        /// <param name="putData">数据</param>
        private void Level99PramSet(string putApdu, string dataID, string putData)
        {
            if (Functions.IsNum(putData))
            {
                if (tbRand2.Text != "" && tbEsamNo.Text != "")
                {
                    string orginalPsw = Protocol645.Psw;
                    Esam645Service.EsamOptionClient ESAMproxy = new Esam645Service.EsamOptionClient();//要操作时才new
                    try
                    {
                        string macStr = ESAMproxy.Meter_Formal_ParameterUpdate(0, tbRand2.Text, tbDiv.Text, putApdu, putData).MAC;
                        Protocol645.Psw = "00000099";//临时改为99级密码
                        Protocol645 p645 = new Protocol645();
                        p645.WriteData(dataID, macStr + putData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    finally
                    {
                        ESAMproxy.Close();
                        Protocol645.Psw = orginalPsw;//用完后要改回界面上的密码，否则影响其他功能使用
                    }
                }
                else
                {
                    MessageBox.Show("请先身份认证！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入数字!");
                return;
            }
        }
        private void btn表号ESAM设_Click(object sender, EventArgs e)
        {
            string putData = tbMeterNo.Text;
            if (putData.Length != 12)
                putData = putData.PadLeft(12, '0');
            Level99PramSet("04D6821E12", "04000402", putData);
        }

        private void btn电流变比ESAM设_Click(object sender, EventArgs e)
        {
            string putData = tbCurrentCh.Text;
            if (putData.Length != 6)
                putData = putData.PadLeft(6, '0');
            Level99PramSet("04D682180F", "04000306", putData);
        }

        private void btn电压变比ESAM设_Click(object sender, EventArgs e)
        {
            string putData = tbVolCh.Text;
            if (putData.Length != 6)
                putData = putData.PadLeft(6, '0');
            Level99PramSet("04D6821B0F", "04000307", putData);
        }

        private void btn报警金额1ESAM设_Click(object sender, EventArgs e)
        {
            string putData = tbWarr1.Text.Replace(".", "");//去掉小数点
            if (putData.Length != 8)
                putData = putData.PadLeft(8, '0');
            Level99PramSet("04D6821010", "04001001", putData);
        }

        private void btn报警金额2ESAM设_Click(object sender, EventArgs e)
        {
            string putData = tbWarr2.Text.Replace(".", "");//去掉小数点
            if (putData.Length != 8)
                putData = putData.PadLeft(8, '0');
            Level99PramSet("04D6821410", "04001002", putData);
        }

        private void btn费率切换时间ESAM设_Click(object sender, EventArgs e)
        {
            string putData = tbRatesChTime.Text;
            if (putData.Length != 10)
                putData = putData.PadLeft(10, '0');
            Level99PramSet("04D6820A11", "04001008", putData);
        }

        private void btn阶梯切换时间ESAM设_Click(object sender, EventArgs e)
        {
            string putData = tbStepChTime.Text;
            if (putData.Length != 10)
                putData = putData.PadLeft(10, '0');
            Level99PramSet("04D684C411", "04001009", putData);
        }

        private void btn费率读_Click(object sender, EventArgs e)
        {
            string ret = null;
            string dataID = "040501FF";//当前套费率
            if (rbBeiyongtao.Checked) dataID = "040502FF";//备用套费率
            Protocol645 p645 = new Protocol645();
            if (p645.ReadData(dataID, out ret))
            {
                int n = ret.Length / 8;
                for (int i = 0; i < 32; i++)
                {
                    this.dgRates[0, i].Value = "";
                }
                for (int i = 0; i < n; i++)
                {
                    this.dgRates[0, i].Value = ret.Substring(ret.Length - 8 * (i + 1), 8).Insert(4, ".");
                }
            }
        }

        private void btn费率ESAM设_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt16(numUpdownDianjia.Value);
            string putData = null;
            string putDataReverse = null;
            for (int i = 0; i < n; i++)
            {
                string s = null;
                if (this.dgRates[0, i].Value == null || this.dgRates[0, i].Value.ToString() == "")
                {
                    putData += "00000000";
                }
                else
                {
                    s = this.dgRates[0, i].Value.ToString();
                    if (s.Contains("."))
                    {
                        string[] ss = s.Split('.');
                        putData += (ss[0].PadLeft(4, '0') + ss[1].PadRight(4, '0'));
                    }
                    else putData += (s.PadLeft(4, '0') + "0000");
                }
            }
            for (int i = 0; i < n; i++)
            {
                putDataReverse += putData.Substring(8 * (n - i - 1), 8);
            }
            string putApdu = "04D68404" + (n * 4 + 0x0C).ToString("X2");

            if (Functions.IsNum(putData))
            {
                if (tbRand2.Text != "" && tbEsamNo.Text != "")
                {
                    string orginalPsw = Protocol645.Psw;
                    Esam645Service.EsamOptionClient ESAMproxy = new Esam645Service.EsamOptionClient();//要操作时才new
                    try
                    {
                        string macStr = ESAMproxy.Meter_Formal_ParameterUpdate2(0, tbRand2.Text, tbDiv.Text, putApdu, putData).MAC;
                        Protocol645.Psw = "00000099";//临时改为99级密码
                        Protocol645 p645 = new Protocol645();
                        p645.WriteData("040502FF", macStr + putDataReverse);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    finally
                    {
                        ESAMproxy.Close();
                        Protocol645.Psw = orginalPsw;//用完后要改回界面上的密码，否则影响其他功能使用
                    }
                }
                else
                {
                    MessageBox.Show("请先身份认证！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入数字!");
                return;
            }
        }
        #endregion

        #region 二类参数
        private void tbErleishujv_TextChanged(object sender, EventArgs e)
        {
            gbErleishujv.Text = "字节数:" + (tbErleishujv.Text.Length / 2).ToString();
        }

        private void btn二类数据读_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbErleishujv, tbErleishujvID.Text);
        }

        private void btn二类数据ESAM设_Click(object sender, EventArgs e)
        {
            string putData = this.tbErleishujv.Text;
            if (putData.Length > 1)
            {
                if (tbRand2.Text != "" && tbEsamNo.Text != "")
                {
                    string orginalPsw = Protocol645.Psw;
                    Esam645Service.EsamOptionClient ESAMproxy = new Esam645Service.EsamOptionClient();//要操作时才new
                    try
                    {
                        string dataID = this.tbErleishujvID.Text;
                        putData = dataID + putData;
                        int dataID_DI2 = Convert.ToInt16(dataID.Substring(2, 2), 16);
                        string putApdu = null;
                        if (dataID_DI2 % 5 == 0) putApdu = "04D68900" + (putData.Length / 2 + 0x0C).ToString("X2");
                        if (dataID_DI2 % 5 == 1) putApdu = "04D69000" + (putData.Length / 2 + 0x0C).ToString("X2");
                        if (dataID_DI2 % 5 == 2) putApdu = "04D69100" + (putData.Length / 2 + 0x0C).ToString("X2");
                        if (dataID_DI2 % 5 == 3) putApdu = "04D69200" + (putData.Length / 2 + 0x0C).ToString("X2");
                        if (dataID_DI2 % 5 == 4) putApdu = "04D69300" + (putData.Length / 2 + 0x0C).ToString("X2");
                        string macStr = ESAMproxy.Meter_Formal_ParameterElseUpdate(0, tbRand2.Text, tbDiv.Text, putApdu, putData).MAC;
                        string enData = ESAMproxy.Meter_Formal_ParameterElseUpdate(0, tbRand2.Text, tbDiv.Text, putApdu, putData).DataValue;
                        this.tbEndataErlei.Text = enData;
                        this.tbMacErlei.Text = macStr;
                        Protocol645.Psw = "00000098";//临时改为98级密码
                        Protocol645 p645 = new Protocol645();
                        p645.WriteData(dataID, macStr + enData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    finally
                    {
                        ESAMproxy.Close();
                        Protocol645.Psw = orginalPsw;//用完后要改回界面上的密码，否则影响其他功能使用
                    }
                }
                else
                {
                    MessageBox.Show("请先身份认证！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入要设的数据!");
                return;
            }
        }

        private void btn二类数据发送_Click(object sender, EventArgs e)//200次发送
        {
            string orginalPsw = Protocol645.Psw;
            if (tbMacErlei.Text == "" || tbEndataErlei.Text == "")
            {
                MessageBox.Show("请先获取密文及MAC！");
                return;
            }
            Protocol645.Psw = "00000098";//临时改为98级密码
            for (int i = 0; i < Convert.ToInt16(this.tbSendTimes.Text); i++)
            {
                this.lblTimes.Text = (i + 1).ToString();
                Protocol645 p645 = new Protocol645();
                p645.WriteData(this.tbErleishujvID.Text, this.tbMacErlei.Text + this.tbEndataErlei);
                Functions.Delay(100);
            }
            Protocol645.Psw = orginalPsw;//用完后要改回界面上的密码，否则影响其他功能使用
        }

        private void dgErleiData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tempDgv = sender as DataGridView;//获取事件发送者
            if (e.ColumnIndex > -1 && e.RowIndex > -1)//防止 Index 出错
            {
                if (e.ColumnIndex == 1)
                {
                    tbErleishujvID.Text = tempDgv[e.ColumnIndex, e.RowIndex].Value.ToString();
                }
            }
        }
        #endregion

    }
}
