using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelEventTest : UserControl
    {
        private Thread TestThread;//定义线程

        public PanelEventTest()
        {
            InitializeComponent();
        }


        #region 校时事件测试
        private bool TimeSetEventTestStartFlag = false;
        private void btnTimeSetEventTest_Click(object sender, EventArgs e)
        {
            if (!Functions.IsNum(textBoxTestTimes.Text)) return;
            int testTimes = int.Parse(textBoxTestTimes.Text);
            if (testTimes < 1) return;
            //TestProcess setTimeEventTestProcess = new TestProcess(txtBoxTimeSetEvent, Protocol645, testTimes);
            if (btnTimeSetEventTest.Text == "开始测试")
            {
                TimeSetEventTestStartFlag = true;
                this.labelSetTimeEventTestResult.Text = "测试结果:";
                Control.CheckForIllegalCrossThreadCalls = false;//不检查跨线程的调用是否合法
                TestThread = new Thread(new ThreadStart(SetTimeEventTest));
                TestThread.IsBackground = true;
                TestThread.Start();
            }
            if (btnTimeSetEventTest.Text == "停止测试")
            {
                //setTimeEventTestProcess.StopTestProcess();
                TimeSetEventTestStartFlag = false;
                this.btnDataSave.Enabled = true;
                if (TestThread.IsAlive) //判断SetTimeEventTestThread是否存在，不能撤消一个不存在的线程，否则会引发异常
                {
                    TestThread.Abort(); //撤消SetTimeEventTestThread
                }
            }
            btnTimeSetEventTest.Text = (TimeSetEventTestStartFlag ? "停止测试" : "开始测试");
        }
        public void SetTimeEventTest()
        {
            txtBoxTimeSetEvent.Clear();
            Protocol645 p645 = new Protocol645();

            //校时记录清零
            txtBoxTimeSetEvent.AppendText("校时记录清零。。。");
            if (p645.EventClear("033004")) txtBoxTimeSetEvent.AppendText("  成功！\r\n");
            else txtBoxTimeSetEvent.AppendText("  失败！\r\n");

            //校时记录测试
            Functions.Delay(100);//等待清零动作完成
            bool setTimeEventIsOk = false;
            string[] _10timesSetTimeEvent = new string[10];//将10次校时记录写进一个数组，以便比较
            for (int m = 0; m < 10; m++)
            {
                _10timesSetTimeEvent[m] = ReadLastNtimesRec("033004", m + 1);
                if (_10timesSetTimeEvent[m] == "00000000000000000000000000000000")//判断是否已经清零
                    setTimeEventIsOk = true;
                else
                {
                    setTimeEventIsOk = false;
                    break;
                }
            }
            if (setTimeEventIsOk)
            {
                for (int i = 0; i < int.Parse(textBoxTestTimes.Text); i++)
                {
                    //********************随机设时间*********************************
                    string setTime = Functions.GenerateRandomTime();
                    if (p645.WriteData("04000102", setTime))
                        txtBoxTimeSetEvent.AppendText((i + 1).ToString("D5") + ":随机设电表时间："
                            + setTime.Substring(0, 2) + ":" + setTime.Substring(2, 2) + ":" + setTime.Substring(4, 2) + "..........................成功！\r\n");
                    else
                        txtBoxTimeSetEvent.AppendText((i + 1).ToString("D5") + ":设电表时间：设电表时间失败！\r\n");
                    //********************读校时记录总次数，检查是否记录正确*********************************
                    Functions.Delay(50);
                    string timesOfSetTime = null;
                    if (p645.ReadData("03300400", out timesOfSetTime))
                    {
                        txtBoxTimeSetEvent.AppendText("      读校时次数：" + timesOfSetTime.Substring(0, 6));
                        if (timesOfSetTime == (i + 1).ToString("D6"))
                            txtBoxTimeSetEvent.AppendText("      校时次数符合实际设的次数，成功！\r\n");
                        else txtBoxTimeSetEvent.AppendText("      校时次数不符合实际设的次数，失败！\r\n");
                    }
                    else//如果失败就读多一次
                        if (p645.ReadData("03300400", out timesOfSetTime))
                    {
                        txtBoxTimeSetEvent.AppendText("      读校时次数：" + timesOfSetTime.Substring(0, 6));
                        if (timesOfSetTime == (i + 1).ToString("D6"))
                            txtBoxTimeSetEvent.AppendText("      校时次数符合实际设的次数，成功！\r\n");
                        else txtBoxTimeSetEvent.AppendText("      校时次数不符合实际设的次数，失败！\r\n");
                    }
                    else
                        txtBoxTimeSetEvent.AppendText("      读校时次数失败！\r\n");
                    //********************读上10次校时记录，检查是否记录正确*********************************
                    //读10次记录
                    for (int j = 0; j < 10; j++)
                    {
                        if (ReadLastNtimesRec("033004", j + 1) != null)
                            txtBoxTimeSetEvent.AppendText("      上" + (j + 1).ToString("D2") + "次校时记录："
                                + ReadLastNtimesRec("033004", j + 1) + "  成功！\r\n");
                        else
                            txtBoxTimeSetEvent.AppendText("      上" + (j + 1).ToString("D2") + "次校时记录：读上"
                                + (j + 1).ToString() + "次校时记录失败！\r\n");
                    }
                    //判断10次记录
                    //this.txtBoxTimeSetEvent.AppendText("      判断10次校时事件是否正确记录（判断上1次事件记录的校时后时间是否为所设时间、判断10次记录是否轮换正确）。。。\r\n");
                    string[] _10timesSetTimeEventTemp = new string[10];
                    for (int m = 0; m < 10; m++)
                    {
                        _10timesSetTimeEventTemp[m] = ReadLastNtimesRec("033004", m + 1);
                    }
                    if (ReadLastNtimesRec("033004", 1) != null && ReadLastNtimesRec("033004", 1).Substring(6, 6) == setTime)//判断第一次是否等于所设时间
                    {
                        for (int m = 1; m < 10; m++)
                        {
                            if (_10timesSetTimeEventTemp[m] == _10timesSetTimeEvent[m - 1])//新的上2~10次等于旧的上1~9次
                            {
                                setTimeEventIsOk = true;
                            }
                            else
                            {
                                setTimeEventIsOk = false;
                                break;
                            }
                        }
                        //_10timesSetTimeEvent = _10timesSetTimeEventTemp;
                        System.Array.Copy(_10timesSetTimeEventTemp, _10timesSetTimeEvent, _10timesSetTimeEvent.Length);//新的写入旧的，以便下次比较
                    }
                    else
                    {
                        setTimeEventIsOk = false;
                    }
                    if (setTimeEventIsOk)
                        txtBoxTimeSetEvent.AppendText("      10次校时事件记录正确！\r\n");
                    else
                        txtBoxTimeSetEvent.AppendText("      10次校时事件记录失败！\r\n");
                }
            }
            else
                txtBoxTimeSetEvent.AppendText("10校时记录不为空，请检查是否清空！失败！\r\n");
            txtBoxTimeSetEvent.AppendText("\r\n校时记录自动测试结束！\r\n");

            //判断测试结果是否合格
            string testRec = txtBoxTimeSetEvent.Text;
            if (testRec.Contains("失败"))
                labelSetTimeEventTestResult.Text = "测试结果：不合格";
            else
                labelSetTimeEventTestResult.Text = "测试结果：合格";

            btnTimeSetEventTest.Text = "开始测试";
            btnDataSave.Enabled = true;
        }

        private void btnDataSave_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog objSave = new System.Windows.Forms.SaveFileDialog();
            objSave.Filter = "(*.txt)|*.txt|" + "(*.*)|*.*";
            objSave.FileName = "校时记录测试" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
            if (objSave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fileWriter = new StreamWriter(objSave.FileName, true);//写入文件
                fileWriter.Write(this.txtBoxTimeSetEvent.Text);//将校时记录测试数据写入
                fileWriter.Close();//关闭StreamWriter对象
            }
        }
        #endregion

        #region 事件抄读对比
        string[] _NtimesRec1 = new string[10];//测之前记录
        string[] _NtimesRec2 = new string[10];//测之后记录
        private void btnR1_NRec1_Click(object sender, EventArgs e)
        {
            tBTestRec1.Text = "";//测试前清空文本
            lbRecTestResult.Text = "对比结果：";
            for (int n = 0; n < _NtimesRec1.Length; n++)
            {
                _NtimesRec1[n] = "";
            }
            int recNo = Convert.ToInt16(this.tBRecN.Text);
            for (int m = 0; m < recNo; m++)
            {
                _NtimesRec1[m] = ReadLastNtimesRec(tBRecID.Text, m + 1);
                if (_NtimesRec1[m].Length != 0)
                {
                    tBTestRec1.AppendText("上" + (m + 1).ToString("D3") + "次记录：" + _NtimesRec1[m] + "  读取成功！\r\n");
                }
                else
                {
                    tBTestRec1.AppendText("上" + (m + 1).ToString("D3") + "次记录：" + _NtimesRec1[m] + "  读取失败！\r\n");
                }
            }
        }

        private void btnR1_NRec2_Click(object sender, EventArgs e)
        {
            tBTestRec2.Text = "";//测试前清空文本
            lbRecTestResult.Text = "对比结果：";
            for (int n = 0; n < _NtimesRec1.Length; n++)
            {
                _NtimesRec2[n] = "";
            }
            int recNo = Convert.ToInt16(this.tBRecN.Text);
            for (int m = 0; m < recNo; m++)
            {
                _NtimesRec2[m] = ReadLastNtimesRec(tBRecID.Text, m + 1);
                if (_NtimesRec2[m].Length != 0)
                {
                    tBTestRec2.AppendText("上" + (m + 1).ToString("D3") + "次记录：" + _NtimesRec2[m] + "  读取成功！\r\n");
                }
                else
                {
                    tBTestRec2.AppendText("上" + (m + 1).ToString("D3") + "次记录：" + _NtimesRec2[m] + "  读取失败！\r\n");
                }
            }
        }

        private void btnCmp2Rec_Click(object sender, EventArgs e)
        {
            lbRecTestResult.Text = "对比结果：对比一致";
            for (int n = 0; n < _NtimesRec1.Length - 1; n++)
            {
                if (_NtimesRec2[n + 1] != _NtimesRec1[n])
                {
                    lbRecTestResult.Text = "对比结果：对比不一致";
                    break;
                }
            }
        }

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
        #endregion

    }
}
