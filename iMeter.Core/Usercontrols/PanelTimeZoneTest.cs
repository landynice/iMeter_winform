using System;
using System.Windows.Forms;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelTimeZoneTest : UserControl
    {
        public override string Text { get => "时区时段测试"; }
        public PanelTimeZoneTest()
        {
            InitializeComponent();
        }

        private void btnSqRead_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 15; i++)
            {
                TextBox tmpTextBox = this.Controls.Find("txtSq" + i.ToString(), true)[0] as TextBox;
                tmpTextBox.Text = "";
            }
            Functions.Delay(10);

            string sqStr = null;
            Protocol645 p645 = new Protocol645();
            if (rBtnSq1.Checked) p645.ReadData("04010000", out sqStr);
            if (rBtnSq2.Checked) p645.ReadData("04020000", out sqStr);
            if (sqStr.Length > 0)
            {
                for (int i = 0; i < sqStr.Length / 6; i++)
                {
                    TextBox tmpTextBox = this.gBSq.Controls.Find("txtSq" + (i + 1).ToString(), true)[0] as TextBox;
                    tmpTextBox.Text = sqStr.Substring(sqStr.Length - (i + 1) * 6, 6);
                }
            }
        }

        private void btnSdRead_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 15; i++)
            {
                TextBox tmpTextBox = this.Controls.Find("txtSd" + i.ToString(), true)[0] as TextBox;
                tmpTextBox.Text = "";
            }
            Functions.Delay(10);

            string sdStr = null;
            Protocol645 p645 = new Protocol645();
            if (rBtnSd1.Checked)//第一套
            {
                for (int i = 1; i < 9; i++)
                {
                    if ((this.gBSd.Controls.Find("rBtnSd_" + i.ToString(), true)[0] as RadioButton).Checked)
                        p645.ReadData("0401000" + i.ToString(), out sdStr);
                }
            }
            if (rBtnSd2.Checked)//第二套
            {
                for (int i = 1; i < 9; i++)
                {
                    if ((this.gBSd.Controls.Find("rBtnSd_" + i.ToString(), true)[0] as RadioButton).Checked)
                        p645.ReadData("0402000" + i.ToString(), out sdStr);
                }
            }
            if (sdStr != null)
            {
                for (int i = 0; i < sdStr.Length / 6; i++)
                {
                    TextBox tmpTextBox = this.gBSd.Controls.Find("txtSd" + (i + 1).ToString(), true)[0] as TextBox;
                    tmpTextBox.Text = sdStr.Substring(sdStr.Length - (i + 1) * 6, 6);
                }
            }
        }

        private void btnSqSet_Click(object sender, EventArgs e)
        {
            string sData = null;
            for (int i = 14; i > 0; i--)
            {
                TextBox tmpTextBox = this.gBSq.Controls.Find("txtSq" + i.ToString(), true)[0] as TextBox;
                sData += tmpTextBox.Text.Trim();
            }
            Protocol645 p645 = new Protocol645();
            if (rBtnSq1.Checked) p645.SetParameter("04010000", sData);
            if (rBtnSq2.Checked) p645.SetParameter("04020000", sData);
        }

        private void btnSdSet_Click(object sender, EventArgs e)
        {
            string sData = null;
            Protocol645 p645 = new Protocol645();
            for (int i = 14; i > 0; i--)
            {
                TextBox tmpTextBox = this.gBSd.Controls.Find("txtSd" + i.ToString(), true)[0] as TextBox;
                sData += tmpTextBox.Text.Trim();
            }
            if (rBtnSd1.Checked)
            {
                for (int i = 1; i < 9; i++)
                {
                    if ((this.gBSd.Controls.Find("rBtnSd_" + i.ToString(), true)[0] as RadioButton).Checked)
                        p645.SetParameter("0401000" + i.ToString(), sData);
                }
            }
            if (rBtnSd2.Checked)
            {
                for (int i = 1; i < 9; i++)
                {
                    if ((this.gBSd.Controls.Find("rBtnSd_" + i.ToString(), true)[0] as RadioButton).Checked)
                        p645.SetParameter("0402000" + i.ToString(), sData);
                }
            }
        }

        private void btn2SqChangeRead_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txt2SqChange, "04000106");
        }//读两套时区表切换时间

        private void btn2SdChangeRead_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txt2SdChange, "04000107");
        }//读两套时段表切换时间

        private void btn2SqChangeSet_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(txt2SqChange, "04000106");
        }//设两套时区切换时间

        private void btn2SdChangeSet_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(txt2SdChange, "04000107");
        }//设两套时段切换时间

        private void btnSqNowRead_Click(object sender, EventArgs e)
        {
            txtSqNow.Text = "";
            Functions.Delay(10);
            string result = null;
            Protocol645 p645 = new Protocol645();
            if (p645.ReadData("04000503", out result))
            {
                int a = Convert.ToInt16(result, 16) & 0x20;
                if (a == 0x00) txtSqNow.Text = "第1套";
                if (a == 0x20) txtSqNow.Text = "第2套";
            }
        }//读当前运行的时区

        private void btnSdNowRead_Click(object sender, EventArgs e)
        {
            txtSdNow.Text = "";
            Functions.Delay(10);
            string result = null;
            Protocol645 p645 = new Protocol645();
            if (p645.ReadData("04000503", out result))
            {
                int a = Convert.ToInt16(result, 16) & 0x01;
                if (a == 0x00) txtSdNow.Text = "第1套";
                if (a == 0x01) txtSdNow.Text = "第2套";
            }
        }//读当前运行的时段

        private void btnClrSqTab_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 15; i++)
            {
                TextBox tmpTextBox = this.Controls.Find("txtSq" + i.ToString(), true)[0] as TextBox;
                tmpTextBox.Text = "";
            }
        }

        private void btnClrSdTab_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 15; i++)
            {
                TextBox tmpTextBox = this.Controls.Find("txtSd" + i.ToString(), true)[0] as TextBox;
                tmpTextBox.Text = "";
            }
        }

    }
}
