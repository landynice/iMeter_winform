using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelFreezeTest : UserControl
    {
        private Thread TestThread;//定义线程

        public PanelFreezeTest()
        {
            InitializeComponent();
        }

        #region 整点冻结测试
        private bool ZhengdianFreezeTestStartFlag = false;
        private void btnZhengdianFreezeTest_Click(object sender, EventArgs e)
        {
            if (this.btnZhengdianFreezeTest.Text == "开始测试")
            {
                ZhengdianFreezeTestStartFlag = true;
                this.btnZhengdianTestDataSave.Enabled = false;
                this.labelZhengdianTestResult.Text = "测试结果：";
                Control.CheckForIllegalCrossThreadCalls = false;//不检查跨线程的调用是否合法
                TestThread = new Thread(new ThreadStart(ZhengdianFreezeTest));
                TestThread.IsBackground = true;
                TestThread.Start();
            }
            if (this.btnZhengdianFreezeTest.Text == "停止测试")
            {
                ZhengdianFreezeTestStartFlag = false;
                this.btnZhengdianTestDataSave.Enabled = true;
                if (TestThread.IsAlive) //判断SetTimeEventTestThread是否存在，不能撤消一个不存在的线程，否则会引发异常
                {
                    TestThread.Abort(); //撤消SetTimeEventTestThread
                }
            }
            btnZhengdianFreezeTest.Text = (ZhengdianFreezeTestStartFlag ? "停止测试" : "开始测试");
        }

        private void ZhengdianFreezeTest()
        {
            this.tBZhengdianFreeze.Clear();
            //整点冻结测试
            bool zhengdianFreezeIsOk = false;
            int timesOfZhengdianFreeze = Convert.ToInt16(this.tBTimesOfZhengdianRec.Text);
            string[] _NtimesZhengdianFreezeOld = new string[timesOfZhengdianFreeze];//测之前先记录整点冻结数据
            string[] _NtimesZhengdianFreezeNew = new string[timesOfZhengdianFreeze];//测之后记录整点冻结数据，判断新的上2~N次记录是否等于旧的上1~(N-1)次记录
            int startTestHour = DateTime.Now.Hour;
            //****************************读整点冻结数据*********************************************
            for (int m = 0; m < timesOfZhengdianFreeze; m++)
            {
                _NtimesZhengdianFreezeOld[m] = ReadLastNtimesZhengdianFreeze(m + 1);
                if (_NtimesZhengdianFreezeOld[m].Length == 58)
                {
                    tBZhengdianFreeze.AppendText("      上" + (m + 1).ToString("D3") + "次整点冻结：" + _NtimesZhengdianFreezeOld[m] + "  读取成功！\r\n");
                }
                else
                {
                    tBZhengdianFreeze.AppendText("      上" + (m + 1).ToString("D3") + "次整点冻结：" + _NtimesZhengdianFreezeOld[m] + "  读取失败！\r\n");
                }
            }
            for (int i = 0; i < int.Parse(tBTimesOfZhengdianFreezeTest.Text); i++)
            {
                //****************************设时间在整点（半整点）前5秒*********************************
                string setTime = "000000";
                string _1stZhengdianTime = null;//先定义上1次过整点冻结的时间，方便后面比较
                if (rBZhengdian.Checked)
                {
                    setTime = startTestHour.ToString("D2") + "5955";
                    if (startTestHour < 23)
                        _1stZhengdianTime = (startTestHour + 1).ToString("D2") + "00";
                    else _1stZhengdianTime = "0000";
                }
                if (rBBanZhengdian.Checked && (DateTime.Now.Minute < 30))
                {
                    setTime = startTestHour.ToString("D2") + "2955";
                    _1stZhengdianTime = startTestHour.ToString("D2") + "30";
                }
                if (rBBanZhengdian.Checked && (DateTime.Now.Minute >= 30))
                {
                    setTime = startTestHour.ToString("D2") + "5955";
                    if (startTestHour < 23)
                        _1stZhengdianTime = (startTestHour + 1).ToString("D2") + "00";
                    else _1stZhengdianTime = "0000";
                }
                startTestHour++;
                if (startTestHour == 24) startTestHour = 0;

                Protocol645 p645 = new Protocol645();
                if (p645.WriteData("04000102", setTime))
                    tBZhengdianFreeze.AppendText((i + 1).ToString("D5") + ":设电表时间："
                        + setTime.Substring(0, 2) + ":" + setTime.Substring(2, 2) + ":" + setTime.Substring(4, 2) + "  设置成功！\r\n");
                else
                    tBZhengdianFreeze.AppendText((i + 1).ToString("D5") + ":设电表时间：设电表时间失败！ 失败原因：\r\n");
                //****************************等待时间过整点（半整点）************************************
                tBZhengdianFreeze.AppendText("      等待10秒...\r\n");
                Functions.Delay(10000);//等待10秒
                //****************************读整点冻结数据*********************************************
                for (int m = 0; m < timesOfZhengdianFreeze; m++)
                {
                    _NtimesZhengdianFreezeNew[m] = ReadLastNtimesZhengdianFreeze(m + 1);
                    if (_NtimesZhengdianFreezeNew[m].Length == 58)
                    {
                        tBZhengdianFreeze.AppendText("      上" + (m + 1).ToString("D3") + "次整点冻结：" + _NtimesZhengdianFreezeNew[m] + "  读取成功！\r\n");
                    }
                    else
                    {
                        tBZhengdianFreeze.AppendText("      上" + (m + 1).ToString("D3") + "次整点冻结：" + _NtimesZhengdianFreezeNew[m] + "  读取失败！\r\n");
                    }
                }
                //****************************判断新的上1次整点冻结时间是否正确***************************
                if (_NtimesZhengdianFreezeNew[0] != null && _NtimesZhengdianFreezeNew[0].Substring(6, 4) == _1stZhengdianTime)
                {
                    //****************************判断新的上2~N次记录是否等于旧的上1~(N-1)次记录**************
                    for (int m = 1; m < timesOfZhengdianFreeze; m++)
                    {
                        if (_NtimesZhengdianFreezeNew[m] == _NtimesZhengdianFreezeOld[m - 1])//新的上2~N次等于旧的上1~(N-1)次
                        {
                            zhengdianFreezeIsOk = true;
                        }
                        else
                        {
                            zhengdianFreezeIsOk = false;
                            break;
                        }
                    }
                    //_NtimesZhengdianFreezeOld = _NtimesZhengdianFreezeNew;
                    System.Array.Copy(_NtimesZhengdianFreezeNew, _NtimesZhengdianFreezeOld, _NtimesZhengdianFreezeNew.Length);//新的终究要变成旧的，好吧。。。
                }
                else
                {
                    zhengdianFreezeIsOk = false;
                }
                if (zhengdianFreezeIsOk)
                    this.tBZhengdianFreeze.AppendText("整点冻结记录正确！\r\n");
                else
                    this.tBZhengdianFreeze.AppendText("整点冻结记录失败！\r\n");
            }
            this.tBZhengdianFreeze.AppendText("整点冻结测试结束！");

            //判断测试结果是否合格
            string testRec = this.tBZhengdianFreeze.Text;
            if (testRec.Contains("失败"))
                this.labelZhengdianTestResult.Text = "测试结果：不合格";
            else
                this.labelZhengdianTestResult.Text = "测试结果：合格";

            this.btnZhengdianFreezeTest.Text = "开始测试";
            this.btnZhengdianTestDataSave.Enabled = true;
        }
        /// <summary>
        /// 读上N次整点冻结记录
        /// 输入：次数n
        /// 返回：整点冻结时间+整点冻结正向有功总电能+整点冻结反向有功总电能+整点冻结数据块
        /// </summary>
        private string ReadLastNtimesZhengdianFreeze(int n)
        {
            return ReadLastNtimesRec("050400", n) + ReadLastNtimesRec("050401", n) + ReadLastNtimesRec("050402", n) + ReadLastNtimesRec("0504FF", n);
        }

        private void btnZhengdianTestDataSave_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog objSave = new System.Windows.Forms.SaveFileDialog();
            objSave.Filter = "(*.txt)|*.txt|" + "(*.*)|*.*";
            objSave.FileName = "整点冻结测试" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
            if (objSave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fileWriter = new StreamWriter(objSave.FileName, true);//写入文件
                fileWriter.Write(this.tBZhengdianFreeze.Text);//将整点冻结测试数据写入
                fileWriter.Close();//关闭StreamWriter对象
            }
        }
        #endregion

        #region 日冻结测试
        private bool RidongjieTestStartFlag = false;
        private void btnRidongjieTest_Click(object sender, EventArgs e)
        {
            if (btnRidongjieTest.Text == "开始测试")
            {
                RidongjieTestStartFlag = true;
                this.btnRidongjieDataSave.Enabled = false;
                this.lblRidongjieResult.Text = "测试结果：";
                Control.CheckForIllegalCrossThreadCalls = false;//不检查跨线程的调用是否合法
                TestThread = new Thread(new ThreadStart(RidongjieTest));
                TestThread.IsBackground = true;
                TestThread.Start();
            }
            if (btnRidongjieTest.Text == "停止测试")
            {
                RidongjieTestStartFlag = false;
                this.btnRidongjieTest.Enabled = true;
                if (TestThread.IsAlive) //判断SetTimeEventTestThread是否存在，不能撤消一个不存在的线程，否则会引发异常
                {
                    TestThread.Abort(); //撤消SetTimeEventTestThread
                }
            }
            btnRidongjieTest.Text = (RidongjieTestStartFlag ? "停止测试" : "开始测试");
        }

        private void RidongjieTest()
        {
            this.tBRidongjieRec.Clear();

            bool riFreezeIsOk = false;
            int timesOfRiFreeze = Convert.ToInt16(this.tBRidongjieRecTimes.Text);
            string[] _NtimesRiFreezeOld = new string[timesOfRiFreeze];//测之前先记录日冻结数据
            string[] _NtimesRiFreezeNew = new string[timesOfRiFreeze];//测之后记录日冻结数据，判断新的上2~N次记录是否等于旧的上1~(N-1)次记录
            string ridongjieDate = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadData("04001203", out ridongjieDate);
            //****************************读日冻结数据*********************************************
            for (int m = 0; m < timesOfRiFreeze; m++)
            {
                _NtimesRiFreezeOld[m] = ReadLastNtimesRiFreeze(m + 1);
                if (_NtimesRiFreezeOld[m].Length == 138)
                {
                    tBRidongjieRec.AppendText("      上" + (m + 1).ToString("D3") + "次日冻结：" + _NtimesRiFreezeOld[m] + "  读取成功！\r\n");
                }
                else
                {
                    tBRidongjieRec.AppendText("      上" + (m + 1).ToString("D3") + "次日冻结：" + _NtimesRiFreezeOld[m] + "  读取失败！\r\n");
                }
            }
            for (int i = 0; i < int.Parse(tBRidongjieTestTimes.Text); i++)
            {
                //****************************设时间在日冻结时间前5秒*********************************
                string setTime = "000000";
                //日冻结时间有4种可能：00:00、00:XX、XX:00、XX:XX
                if (ridongjieDate == "0000")
                {
                    setTime = "235955";
                }
                else if (ridongjieDate.Substring(0, 2) == "00" && ridongjieDate.Substring(2, 2) != "00")
                {
                    setTime = "00" + (Convert.ToInt16(ridongjieDate.Substring(2, 2)) - 1).ToString("D2") + "55";
                }
                else if (ridongjieDate.Substring(0, 2) != "00" && ridongjieDate.Substring(2, 2) == "00")
                {
                    setTime = (Convert.ToInt16(ridongjieDate.Substring(0, 2)) - 1).ToString("D2") + "5955";
                }
                else if (ridongjieDate.Substring(0, 2) != "00" && ridongjieDate.Substring(2, 2) != "00")
                {
                    setTime = ridongjieDate.Substring(0, 2) + (Convert.ToInt16(ridongjieDate.Substring(2, 2)) - 1).ToString("D2") + "55";
                }

                if (p645.WriteData("04000102", setTime))
                    this.tBRidongjieRec.AppendText((i + 1).ToString("D5") + ":设电表时间："
                        + setTime.Substring(0, 2) + ":" + setTime.Substring(2, 2) + ":" + setTime.Substring(4, 2) + "  设置成功！\r\n");
                else
                    this.tBRidongjieRec.AppendText((i + 1).ToString("D5") + ":设电表时间：设电表时间失败！\r\n");
                //****************************等待时间过日冻结时间************************************
                tBRidongjieRec.AppendText("      等待10秒...\r\n");
                Functions.Delay(10000);//等待10秒
                //****************************读日冻结数据*********************************************
                for (int m = 0; m < timesOfRiFreeze; m++)
                {
                    _NtimesRiFreezeNew[m] = ReadLastNtimesRiFreeze(m + 1);
                    if (_NtimesRiFreezeNew[m].Length == 138)
                    {
                        tBRidongjieRec.AppendText("      上" + (m + 1).ToString("D3") + "次日冻结：" + _NtimesRiFreezeNew[m] + "  读取成功！\r\n");
                    }
                    else
                    {
                        tBRidongjieRec.AppendText("      上" + (m + 1).ToString("D3") + "次日冻结：" + _NtimesRiFreezeNew[m] + "  读取失败！\r\n");
                    }
                }
                //****************************判断新的上1次日冻结时间是否正确***************************
                if (_NtimesRiFreezeNew[0].Substring(6, 4) == ridongjieDate)
                {
                    //****************************判断新的上2~N次记录是否等于旧的上1~(N-1)次记录**************
                    for (int m = 1; m < timesOfRiFreeze; m++)
                    {
                        if (_NtimesRiFreezeNew[m] == _NtimesRiFreezeOld[m - 1])//新的上2~N次等于旧的上1~(N-1)次
                        {
                            riFreezeIsOk = true;
                        }
                        else
                        {
                            riFreezeIsOk = false;
                            break;
                        }
                    }
                    System.Array.Copy(_NtimesRiFreezeNew, _NtimesRiFreezeOld, _NtimesRiFreezeNew.Length);//新的终究要变成旧的，好吧。。。
                }
                else
                {
                    riFreezeIsOk = false;
                }
                if (riFreezeIsOk)
                    this.tBRidongjieRec.AppendText("日冻结记录正确！\r\n");
                else
                    this.tBRidongjieRec.AppendText("日冻结记录失败！\r\n");
            }
            this.tBRidongjieRec.AppendText("日冻结测试结束！");

            //判断测试结果是否合格
            string testRec = this.tBRidongjieRec.Text;
            if (testRec.Contains("失败"))
                this.lblRidongjieResult.Text = "测试结果：不合格";
            else
                this.lblRidongjieResult.Text = "测试结果：合格";

            this.btnRidongjieTest.Text = "开始测试";
            this.btnRidongjieDataSave.Enabled = true;
        }

        /// <summary>
        /// 读上N次日冻结记录
        /// 输入：次数n
        /// 返回：日冻结时间+日冻结正向有功总电能+日冻结反向有功总电能+日冻结变量数据
        /// </summary>
        private string ReadLastNtimesRiFreeze(int n)
        {
            return ReadLastNtimesRec("050600", n) + ReadLastNtimesRec("050601", n) + ReadLastNtimesRec("050602", n) + ReadLastNtimesRec("050610", n);
        }

        private void btnRidongjieDataSave_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog objSave = new System.Windows.Forms.SaveFileDialog();
            objSave.Filter = "(*.txt)|*.txt|" + "(*.*)|*.*";
            objSave.FileName = "日冻结测试" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
            if (objSave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fileWriter = new StreamWriter(objSave.FileName, true);//写入文件
                fileWriter.Write(this.tBRidongjieRec.Text);//将校时记录测试数据写入
                fileWriter.Close();//关闭StreamWriter对象
            }
        }

        private void btnSetRidongjieTime_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(tBRidongjieTime, "04001203");
        }



        #endregion
        /// <summary>
        /// 读上n次事件记录
        /// 输入：事件记录ID前6位【D3D2D1】、第n次记录
        /// 返回：记录数据
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private string ReadLastNtimesRec(string recID, int n)
        {
            string result = null;
            string recv = null;
            int recID_int = 0x00000000 + Convert.ToInt32(recID.PadRight(8, '0'), 16);

            recID_int += n;
            Protocol645 p645 = new Protocol645();
            if (p645.ReadData(Convert.ToString(recID_int, 16).PadLeft(8, '0'), out recv))
                result += recv;
            recv = null;

            return result;
        }
    }
}
