using System;
using System.Windows.Forms;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelReadWriteAndDisp : UserControl
    {
        public PanelReadWriteAndDisp()
        {
            InitializeComponent();
        }

        private void CountTextNum(object sender, EventArgs e)//计字节数
        {
            TextBox tb = (TextBox)sender;
            Control gb = tb.Parent;
            if (gb is GroupBox)
            {
                (gb as GroupBox).Text = "字节数:" + Functions.CountTxtByte(tb.Text);
            }
        }

        private void TongyongReadAndSet(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox tbVal = new TextBox();
            TextBox tbId = new TextBox();
            Protocol645 p645 = new Protocol645();
            if (btn == button4 || btn == button9) { tbVal = textBox12; tbId = textBox13; }
            if (btn == button12 || btn == button13) { tbVal = textBox17; tbId = textBox16; }
            if (btn == button10 || btn == button11) { tbVal = textBox15; tbId = textBox14; }
            if (btn == button14 || btn == button15) { tbVal = textBox19; tbId = textBox18; }
            if (btn == button4 || btn == button12 || btn == button10 || btn == button14)
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
                Protocol645 p645 = new Protocol645();
                if (tbId == textBox13) tbVal = textBox12;
                else if (tbId == textBox16) tbVal = textBox17;
                else if (tbId == textBox14) tbVal = textBox15;
                else if (tbId == textBox18) tbVal = textBox19;
                else return;
                p645.ReadParameter(tbVal, tbId.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)//读电量并判断总电量-尖峰平谷的误差
        {
            foreach (Control tb in this.gbEnergy.Controls)
            {
                if (tb is TextBox)
                    tb.Text = "";
            }

            string result = null;
            Protocol645 p645 = new Protocol645();
            for (int i = 0; i < 5; i++)
            {
                if (p645.ReadData("00000" + i.ToString() + "00", out result))
                {
                    (this.gbEnergy.Controls.Find("tbEnergy" + i.ToString(), true))[0].Text =
                        Convert.ToString(Convert.ToDouble(result) / 100);
                }
            }

            double sum = 0;
            sum = Convert.ToDouble(tbEnergy1.Text) + Convert.ToDouble(tbEnergy2.Text) + Convert.ToDouble(tbEnergy3.Text) + Convert.ToDouble(tbEnergy4.Text);
            tbEnergy5.Text = Convert.ToString(sum);
            tbEnergy6.Text = ((Convert.ToDouble(tbEnergy0.Text) - sum)).ToString("F4");
        }

        #region 循显/键显
        private void btn读循显屏数_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbXunxianNum, "04000301");
        }

        private void btn读键显屏数_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbJianxianNum, "04000305");
        }

        private void btn设循显屏数_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(tbXunxianNum, "04000301");
        }

        private void btn设键显屏数_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(tbJianxianNum, "04000305");
        }

        private void btn读显示内容_Click(object sender, EventArgs e)
        {
            int displayNum = 0;
            string startId = null;
            string display = null;
            Protocol645 p645 = new Protocol645();

            if (rbDisplayAuto.Checked)
            {
                if (!p645.ReadParameter(tbXunxianNum, "04000301")) return;
                startId = "040401";
                displayNum = Convert.ToInt16(tbXunxianNum.Text);
            }
            if (rbDisplayButton.Checked)
            {
                if (!p645.ReadParameter(tbJianxianNum, "04000305")) return;
                startId = "040402";
                displayNum = Convert.ToInt16(tbJianxianNum.Text);
            }

            dgvDisplay.Rows.Clear();
            dgvDisplay.Rows.Add(displayNum);
            //progressBar.Maximum = displayNum;
            //progressBar.Value = 0;
            for (int i = 0; i < displayNum; i++)
            {
                dgvDisplay.Rows[i].HeaderCell.Value = "第" + (i + 1).ToString() + "屏";
                if (p645.ReadData(startId + (i + 1).ToString("X2"), out display))
                {
                    dgvDisplay[0, i].Value = display.Substring(2);
                    dgvDisplay[1, i].Value = display.Substring(0, 2);
                    try
                    {
                        dgvDisplay[2, i].Value = Functions.DISPLAY[display];
                    }
                    catch { }
                    //progressBar.Value++;
                }
                else
                {
                    MessageBox.Show("读表出错！");
                    return;
                }
            }
        }

        private void btn设显示内容_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            if (rbDisplayAuto.Checked)
            {
                int displayautoNum = Convert.ToInt16(tbXunxianNum.Text);
                if (dgvDisplay.Rows.Count == displayautoNum)
                {
                    //progressBar.Maximum = displayautoNum;
                    //progressBar.Value = 0;
                    for (int i = 0; i < displayautoNum; i++)
                    {
                        if (dgvDisplay[0, i].Value.ToString().Length == 8 && dgvDisplay[1, i].Value.ToString().Length == 2)
                        {
                            p645.SetParameter("040401" + (i + 1).ToString("X2"), dgvDisplay[1, i].Value.ToString() + dgvDisplay[0, i].Value.ToString());
                            //progressBar.Value++;
                        }
                        else
                        {
                            MessageBox.Show("输入数据长度错误，请检查！");
                            return;
                        }
                    }
                    MessageBox.Show("设表完毕！");
                }
                else
                {
                    MessageBox.Show("表格内容与要设置的屏数不相符");
                }

            }
            if (rbDisplayButton.Checked)
            {
                int displaybuttonNum = Convert.ToInt16(tbJianxianNum.Text);
                if (dgvDisplay.Rows.Count == displaybuttonNum)
                {
                    //progressBar.Maximum = displaybuttonNum;
                    //progressBar.Value = 0;
                    for (int i = 0; i < displaybuttonNum; i++)
                    {
                        if (dgvDisplay[0, i].Value.ToString().Length == 8 && dgvDisplay[1, i].Value.ToString().Length == 2)
                        {
                            p645.SetParameter("040402" + (i + 1).ToString("X2"), dgvDisplay[1, i].Value.ToString() + dgvDisplay[0, i].Value.ToString());
                            //progressBar.Value++;
                        }
                        else
                        {
                            MessageBox.Show("输入数据长度错误，请检查！");
                            return;
                        }
                    }
                    MessageBox.Show("设表完毕！");
                }
                else
                {
                    MessageBox.Show("表格内容与要设置的屏数不相符");
                }
            }
        }
        #endregion

        #region 块抄
        private void btnReadBlock_Click(object sender, EventArgs e)
        {
            tbBlockData.Text = "";
            tbBlockData.Refresh();
            byte ctl;
            string ret;
            byte seq = 1;
            string id = tbReadBlockID.Text;
            Protocol645 p645 = new Protocol645();
            if (p645.ReadBlockData(id, out ctl, out ret))
            {
                tbBlockData.AppendText("第" + seq.ToString() + "帧数据(" + ret.Length / 2 + "字节)：\r\n");
                tbBlockData.AppendText(ret + "\r\n---------------------------------\r\n");
                if (ctl == 0xb1)
                {
                    do
                    {
                        if (p645.ReadNextBlock(id, seq, out ctl, out ret))
                        {
                            tbBlockData.AppendText("第" + (seq + 1).ToString() + "帧数据(" + ret.Length / 2 + "字节)：\r\n");
                            tbBlockData.AppendText(ret + "\r\n---------------------------------\r\n");
                            seq++;
                        }
                        else break;
                    } while (ctl == 0xb2);
                }
            }
        }
        #endregion

    }
}
