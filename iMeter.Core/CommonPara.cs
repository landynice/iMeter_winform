using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using iMeter.BaseClass;

namespace iMeter
{
    partial class MainForm
    {
        #region 读设函数
        /// <summary>
        /// 读参数
        /// </summary>
        /// <param name="tbObj">文本框控件name</param>
        /// <param name="dataId">数据ID</param>
        private bool ReadParameter(object tbObj, string dataId)
        {
            if (!(tbObj is TextBox)) return false;

            TextBox tb = (TextBox)tbObj;
            tb.ForeColor = Color.Black;
            tb.Text = "";
            Method.Delay(10);
            string result = null;
            if (Protocol645.ReadData(dataId, out result))
            {
                tb.Text = result;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 设参数
        /// </summary>
        /// <param name="tbObj">要输入数据的文本框控件name</param>
        /// <param name="dataId"></param>
        private void SetParameter(object tbObj, string dataId)
        {
            if(!(tbObj is TextBox)) return;

            TextBox tb = (TextBox)tbObj;
            string strDate = tb.Text;

            if (strDate.Length != tb.MaxLength)
            {
                MessageBox.Show("数据长度过长或不足！");
                return;
            }

            if (dataId == "04000101" || strDate.Length == 6)//如果是日期，则要判断星期
            {
                strDate = Method.JustWeek(strDate);
            }
            if (!Protocol645.WriteData(dataId, strDate))
            {
                tb.ForeColor = Color.Red;
                tb.Text = "Err";
            }
        }

        /// <summary>
        /// 设参数
        /// </summary>
        /// <param name="dataId">数据ID</param>
        /// <param name="data">数据</param>
        private void SetParameter(string dataId, string data)
        {
            data = data.Replace(" ", "").Replace("\r\n", "");
            Protocol645.WriteData(dataId, data);
        }
        #endregion

        private void ButtonParameterRead(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ReadParameter(splitContainer4.Panel2.Controls.Find("tb" + btn.Name.Substring(4), true)[0], btn.Name.Substring(4));
        }
        private void ButtonParameterSet(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SetParameter(splitContainer4.Panel2.Controls.Find("tb" + btn.Name.Substring(4), true)[0], btn.Name.Substring(4));
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
        private void btnR_Click(object sender, EventArgs e)//大读按钮
        {
            int ctrolNums = 0;
            foreach (Control ckb in this.splitContainer4.Panel2.Controls)
            {
                if (ckb is CheckBox)
                {
                    if (((CheckBox)ckb).Checked)
                    {
                        ctrolNums++;
                    }
                }
            }
            progressBar.Maximum = ctrolNums;
            progressBar.Value = 0;
            foreach (Control ckb in this.splitContainer4.Panel2.Controls)
            {
                if (ckb is CheckBox)
                {
                    if (((CheckBox)ckb).Checked)
                    {
                        ReadParameter(this.splitContainer4.Panel2.Controls.Find("tb" + ckb.Name.Substring(2, 8), true)[0], ckb.Name.Substring(2, 8));
                        progressBar.Value++;
                    }
                }
            }
        }
        private void btnS_Click(object sender, EventArgs e)//大写按钮
        {
            int ctrolNums = 0;
            foreach (Control ckb in this.splitContainer4.Panel2.Controls)
            {
                if (ckb is CheckBox)
                {
                    if (((CheckBox)ckb).Checked)
                    {
                        ctrolNums++;
                    }
                }
            }
            progressBar.Maximum = ctrolNums;
            progressBar.Value = 0;
            foreach (Control ckb in this.splitContainer4.Panel2.Controls)
            {
                if (ckb is CheckBox)
                {
                    if (((CheckBox)ckb).Checked)
                    {
                        SetParameter(this.splitContainer4.Panel2.Controls.Find("tb" + ckb.Name.Substring(2, 8), true)[0], ckb.Name.Substring(2, 8));
                        progressBar.Value++;
                    }
                }
            }
        }
        private void CountTextNum(object sender, EventArgs e)//计字节数
        {
            TextBox tb = (TextBox)sender;
            string txt = tb.Text.Replace(" ", "").Replace("\r\n", "");
            int tNum = txt.Length / 2;
            Control gb = tb.Parent;
            if (gb is GroupBox)
            {
                (gb as GroupBox).Text = "字节数:" + tNum.ToString();
            }
        }
        private void TongyongReadAndSet(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox tbVal = new TextBox();
            TextBox tbId = new TextBox();
            if (btn == btnTongyongR || btn == btnTongyongS) { tbVal = tbTongyong; tbId = tbTongyongID; }
            if (btn == button4      || btn == button9)      { tbVal = textBox12;  tbId = textBox13;    }
            if (btn == button12     || btn == button13)     { tbVal = textBox17;  tbId = textBox16;    }
            if (btn == button10     || btn == button11)     { tbVal = textBox15;  tbId = textBox14;    }
            if (btn == button14     || btn == button15)     { tbVal = textBox19;  tbId = textBox18;    }
            if (btn == btnTongyongR || btn == button4 || btn == button12 || btn == button10 || btn == button14)
                ReadParameter(tbVal, tbId.Text);
            else
                SetParameter(tbId.Text, tbVal.Text);
        }
        private void TextBoxInputEnterEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox tbVal = new TextBox();
                TextBox tbId = (TextBox)sender;
                if (tbId == tbTongyongID)   tbVal = tbTongyong;
                else if (tbId == textBox13) tbVal = textBox12;
                else if (tbId == textBox16) tbVal = textBox17;
                else if (tbId == textBox14) tbVal = textBox15;
                else if (tbId == textBox18) tbVal = textBox19;
                else return;
                ReadParameter(tbVal, tbId.Text);
            }
        }
    }
}
