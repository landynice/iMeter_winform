using System;
using System.Windows.Forms;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelBroadSetTimeTest : UserControl
    {
        Timer timerPCTime = new Timer();
        public PanelBroadSetTimeTest()
        {
            InitializeComponent();
        }

        private void checkBoxPCTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPCTime.Checked)
            {
                txtBroadcastSetTime1.Text = DateTime.Now.ToString("yyMMdd");
                txtBroadcastSetTime2.Text = DateTime.Now.ToString("HHmmss");
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
            txtBroadcastSetTime1.Text = DateTime.Now.ToString("yyMMdd");
            txtBroadcastSetTime2.Text = DateTime.Now.ToString("HHmmss");
        }

        private void btnBroadcastSetTime_Click(object sender, EventArgs e)
        {
            if (txtBroadcastSetTime1.Text.Length + txtBroadcastSetTime2.Text.Length < 12)
            {
                MessageBox.Show("数据不足，请重新输入！");
                return;
            }
            Protocol645 p645 = new Protocol645();
            p645.BroadcastSetTime(txtBroadcastSetTime1.Text + txtBroadcastSetTime2.Text);
        }

        private void btnReadMeterTime_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txtMeterTime1, "04000101");
            txtMeterTime1.Text = txtMeterTime1.Text.Substring(0, 6);
            p645.ReadParameter(txtMeterTime2, "04000102");
        }

        private void btnSetMeterTime_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(txtMeterTime1, "04000101");
            Functions.Delay(10);
            p645.SetParameter(txtMeterTime2, "04000102");
        }

        private void btnRead1stJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txt1stJsr, "04000B01");
        }

        private void btnRead2ndJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txt2ndJsr, "04000B02");
        }

        private void btnRead3rdJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txt3rdJsr, "04000B03");
        }

        private void btnSet1stJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(txt1stJsr, "04000B01");
        }

        private void btnSet2ndJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(txt2ndJsr, "04000B02");
        }

        private void btnSet3rdJsr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(txt3rdJsr, "04000B03");
        }


    }
}
