using System;
using System.Windows.Forms;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelOftenUsePara : UserControl
    {
        public readonly string ControlName = "常用参数";

        public PanelOftenUsePara()
        {
            InitializeComponent();
        }

        private void ButtonParameterRead(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            object obj = splitContainer4.Panel2.Controls.Find("tb" + btn.Name.Substring(4), true)[0];
            string dataId = btn.Name.Substring(4);
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(obj, dataId);
        }

        private void ButtonParameterSet(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            object obj = splitContainer4.Panel2.Controls.Find("tb" + btn.Name.Substring(4), true)[0];
            string dataId = btn.Name.Substring(4);
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(obj, dataId);
        }

        private void cBSelectAll_CheckedChanged(object sender, EventArgs e)//全选
        {
            foreach (Control ckb in splitContainer4.Panel2.Controls)
            {
                if (ckb is CheckBox)
                {
                    if (cBSelectAll.Checked)
                    {
                        ((CheckBox)ckb).Checked = true;
                    }
                    else ((CheckBox)ckb).Checked = false;
                }
            }
        }

        private void btnReadAndSet(object sender, EventArgs e)//大读写按钮
        {
            Button btn = (Button)sender;
            foreach (Control ckb in this.splitContainer4.Panel2.Controls)
            {
                if (ckb is CheckBox)
                {
                    if (((CheckBox)ckb).Checked)
                    {
                        object obj = this.splitContainer4.Panel2.Controls.Find("tb" + ckb.Name.Substring(2, 8), true)[0];
                        string dataId = ckb.Name.Substring(2, 8);
                        Protocol645 p645 = new Protocol645();
                        if (btn == btnR)
                        {
                            p645.ReadParameter(obj, dataId);
                        }
                        if (btn == btnS)
                        {
                            p645.SetParameter(obj, dataId);
                        }
                    }
                }
            }
        }

        private void CountTextNum(object sender, EventArgs e)//计字节数
        {
            TextBox tb = (TextBox)sender;
            Control gb = tb.Parent;
            if (gb is GroupBox)
            {
                (gb as GroupBox).Text = "字节数:" + Counter.CountTxtByte(tb.Text);
            }
        }

        private void TongyongReadAndSet(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox tbVal = new TextBox();
            TextBox tbId = new TextBox();
            if (btn == btnTongyongR || btn == btnTongyongS) { tbVal = tbTongyong; tbId = tbTongyongID; }
            Protocol645 p645 = new Protocol645();
            if (btn == btnTongyongR)
                p645.ReadParameter(tbVal, tbId.Text);
            else
                p645.SetParameter(tbId.Text, tbVal.Text);
        }

        private void TextBoxInputEnterEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox tbVal = new TextBox();
                TextBox tbId = (TextBox)sender;
                if (tbId == tbTongyongID) tbVal = tbTongyong;
                else return;
                Protocol645 p645 = new Protocol645();
                p645.ReadParameter(tbVal, tbId.Text);
            }
        }

    }
}
