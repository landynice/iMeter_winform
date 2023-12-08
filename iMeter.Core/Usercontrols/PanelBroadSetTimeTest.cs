using System;
using System.Windows.Forms;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelBroadSetTimeTest : UserControl
    {
        public override string Text { get => "广播校时测试"; }
        Timer timerPCTime = new Timer();
        public PanelBroadSetTimeTest()
        {
            InitializeComponent();
            cbAddrSch.SelectedIndex = 0;
        }

        //获取电脑日期时间
        private void checkBoxPCTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPCTime.Checked)
            {
                txtBroadcastSetTime1.Text = DateTime.Now.ToString("yyMMddHHmmss");
                if (timerPCTime.Enabled)
                {
                    timerPCTime.Stop();
                }
                timerPCTime.Interval = 1000;
                this.timerPCTime.Tick -= new EventHandler(timerBroadSetTime_Tick);
                this.timerPCTime.Tick += new EventHandler(timerBroadSetTime_Tick);
                timerPCTime.Start();
            }
            else
            {
                timerPCTime.Stop();
            }
        }

        private void timerBroadSetTime_Tick(object sender, EventArgs e)
        {
            txtBroadcastSetTime1.Text = DateTime.Now.ToString("yyMMddHHmmss");
        }

        //广播校时
        private void btnBroadcastSetTime_Click(object sender, EventArgs e)
        {
            if (txtBroadcastSetTime1.Text.Length < 12)
            {
                MessageBox.Show("数据不足，请重新输入！");
                return;
            }
            Protocol645 p645 = new Protocol645();
            p645.BroadcastSetTime(txtBroadcastSetTime1.Text, cbAddrSch.Text);
        }

        //读表日期时间
        private void btnReadMeterTime_Click(object sender, EventArgs e)
        {
            txtMeterTime1.Text = string.Empty;
            Protocol645 p645 = new Protocol645();
            if (p645.ReadData("0400010C", out string data))
            {
                txtMeterTime1.Text = data.Remove(6, 2);//去掉星期
            }
            else
            {
                return;
            }
        }

        //设表日期时间
        private void btnSetMeterTime_Click(object sender, EventArgs e)
        {
            if (txtMeterTime1.Text.Length != 12)
            {
                MessageBox.Show("数据长度不足12！");
                return;
            }
            Protocol645 p645 = new Protocol645();
            string dateWeek = Functions.JustWeek(txtMeterTime1.Text.Substring(0, 6));
            string time = txtMeterTime1.Text.Substring(6);
            p645.SetParameter("0400010C", dateWeek + time);
        }

        //读第一结算日
        private void btnRead1stJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txt1stJsr, "04000B01");
        }

        //读第二结算日
        private void btnRead2ndJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txt2ndJsr, "04000B02");
        }

        //读第三结算日
        private void btnRead3rdJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txt3rdJsr, "04000B03");
        }

        //设第一结算日
        private void btnSet1stJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(txt1stJsr, "04000B01");
        }

        //设第二结算日
        private void btnSet2ndJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(txt2ndJsr, "04000B02");
        }

        //设第三结算日
        private void btnSet3rdJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(txt3rdJsr, "04000B03");
        }

        //超级广播校时
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBroadcastSetTime1.Text.Length != 12)
            {
                MessageBox.Show("数据不足12！");
                return;
            }
            Protocol645 p645 = new Protocol645();
            p645.SuperBroadcastSetTime(txtBroadcastSetTime1.Text);
        }
    }
}
