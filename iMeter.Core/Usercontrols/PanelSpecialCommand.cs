using System;
using System.Windows.Forms;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelSpecialCommand : UserControl
    {
        Timer timerPCTime = new Timer();

        public PanelSpecialCommand()
        {
            InitializeComponent();
        }


        #region 公用
        private void btnReadDsFreezeTime_Click(object sender, EventArgs e)//读定时冻结时间
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txtDsFreezeTime, "040009A0");
        }

        private void btnMeterClr_Click(object sender, EventArgs e)//电表清零
        {
            Protocol645 p645 = new Protocol645();
            p645.MeterClr();
        }

        private void btnEvenClr_Click(object sender, EventArgs e)//事件总清零
        {
            Protocol645 p645 = new Protocol645();
            p645.EventClear();
        }

        private void btnSubEvenClr_Click(object sender, EventArgs e)//分项事件清零
        {
            Protocol645 p645 = new Protocol645();
            p645.EventClear(txtClrId.Text);
        }

        private void btnMaxXlClr_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.MaxDemandClear();
        }

        private void btnSetPcDataTime_Click(object sender, EventArgs e)//设当前电脑日期时间
        {
            Protocol645 p645 = new Protocol645();
            string dataDate = DateTime.Now.ToString("yyMMdd");
            dataDate = Functions.JustWeek(dataDate);
            p645.SetParameter("04000101", dataDate);
            p645.SetParameter("04000102", DateTime.Now.ToString("HHmmss"));
        }

        private void btnFreeze_Click(object sender, EventArgs e)//冻结
        {
            Protocol645 p645 = new Protocol645();
            p645.BroadcastFreeze(txtFreezeData.Text.PadLeft(8, '9'));
        }

        private void btn多功能端子控制_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            string strData = "";
            if (rbTimeSecPulse.Checked) strData = "00";
            if (rbMandCyclePulse.Checked) strData = "01";
            if (rbPeriodChangePulse.Checked) strData = "02";

            p645.MultFunOutPutCtrl(strData);
        }
        #endregion

        #region KM
        private void btnReadKMVer_Click(object sender, EventArgs e)//读科美内部版本号
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txtKMVer, "048000E1");
            string ss = null;
            for (int i = txtKMVer.Text.Length; i > 0; i--)
            {
                ss += txtKMVer.Text.Substring(i - 1, 1);
            }
            txtKMVer.Text = ss;
        }

        private void btnSetCc_Click(object sender, EventArgs e)//设出厂
        {
            Protocol645 p645 = new Protocol645();
            if (p645.Factory040001E0(true))
                MessageBox.Show("设出厂成功！");
            else MessageBox.Show("设出厂失败！");
        }

        private void btnCancelCc_Click(object sender, EventArgs e)//取消出厂
        {
            Protocol645 p645 = new Protocol645();
            if (p645.Factory040001E0(false))
                MessageBox.Show("清出厂成功！");
            else MessageBox.Show("清出厂失败！");
        }

        //private void button18_Click(object sender, EventArgs e)//改超级密码
        //{
        //    _TextBoxPsw.Text = "47574B4D";
        //}

        private void button19_Click(object sender, EventArgs e)//040001E0读出厂状态
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(textBox20, "040001E0");
            if (textBox20.Text == "AA55")
                textBox20.Text = "未出厂";
            else textBox20.Text = "已出厂";
        }

        private void button16_Click_1(object sender, EventArgs e)//04091120设出厂
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter("04091120", "0000");
        }

        private void button17_Click_1(object sender, EventArgs e)//04091120清出厂
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter("04091120", "AA55");
        }

        #region KM三相表清EEPROM
        private void btnKM三相表清EEPROM_Click(object sender, EventArgs e)
        {
            string strVol = (float.Parse(tbVol.Text) * 100).ToString().PadLeft(8, '0');
            string strCurr = (float.Parse(tbCurr.Text) * 1000).ToString().PadLeft(8, '0');
            string strMaxCurr = (float.Parse(tbMaxCurr.Text) * 1000).ToString().PadLeft(8, '0');
            string strYouGongLevel = (float.Parse(tbYouGongLevel.Text) * 10).ToString().PadLeft(2, '0');
            string strWuGongLevel = (float.Parse(tbWuGongLevel.Text) * 10).ToString().PadLeft(2, '0');
            string strYouGongConst = tbYouGongConst.Text.PadLeft(8, '0');
            string strWuGongConst = tbWuGongConst.Text.PadLeft(8, '0');
            string strMeterModel = comboBoxMeterModel.SelectedIndex.ToString().PadLeft(2, '0');
            string strProductDate = tbProductDate.Text.PadLeft(8, '0');
            string strProtocalVer = comboBoxProtocalVer.SelectedIndex.ToString().PadLeft(2, '0');

            Protocol645 p645 = new Protocol645();
            if (p645.KM3PhaseClrEEP(strVol, strCurr, strMaxCurr, strYouGongLevel, strWuGongLevel, strYouGongConst, strWuGongConst,
                strMeterModel, strProductDate, strProtocalVer))
                MessageBox.Show("命令已发送！");
            else
                MessageBox.Show("命令发送失败！");
        }
        #endregion

        #region KM单相表清EEP
        private void btnKMClrEEP_Click(object sender, EventArgs e)
        {
            string result = null;
            Protocol645 p645 = new Protocol645();
            p645.KMClrEEP(out result);
        }
        #endregion
        #endregion

        #region 银河龙芯
        private void btnReadYinheVer_Click(object sender, EventArgs e)//读银河龙芯版本号
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(txtYinhelongxinVer, "0400F11F");
        }
        #endregion

        #region 福建
        private void button20_Click(object sender, EventArgs e)//福建：点对点校时
        {
            if (textBox21.Text.Length != 12)
            {
                MessageBox.Show("数据不足，请重新输入！");
                return;
            }
            Protocol645 p645 = new Protocol645();
            p645.FujianDianDuiDianSetTime(textBox21.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox21.Text = DateTime.Now.ToString("yyMMddHHmmss");
                if (timerPCTime.Enabled)
                {
                    timerPCTime.Stop();
                }
                timerPCTime.Interval = 1000;
                this.timerPCTime.Tick -= new EventHandler(PCTime_Tick);
                this.timerPCTime.Tick += new EventHandler(PCTime_Tick);
                timerPCTime.Start();
            }
            else
            {
                timerPCTime.Stop();
            }
        }

        private void PCTime_Tick(object sender, EventArgs e)
        {
            textBox21.Text = DateTime.Now.ToString("yyMMddHHmmss");
        }

        private void button22_Click(object sender, EventArgs e)//福建：读表时间
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(textBox24, "04000101");
            textBox24.Text = textBox24.Text.Substring(0, 6);
            p645.ReadParameter(textBox23, "04000102");
        }

        private void button23_Click(object sender, EventArgs e)//福建：设表时间
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(textBox24, "04000101");
            Functions.Delay(10);
            p645.SetParameter(textBox23, "04000102");
        }
        #endregion

        #region 复旦微
        private void button21_Click(object sender, EventArgs e)//复旦微：电表初始化
        {
            string result = null;
            Protocol645 p645 = new Protocol645();
            p645.FDWBroad("1413", "8054", out result);
        }

        private void button24_Click(object sender, EventArgs e)//复旦微：厂内模式使能命令
        {
            string result = null;
            Protocol645 p645 = new Protocol645();
            p645.FDWBroad("550F", "FF", out result);
        }

        private void button25_Click(object sender, EventArgs e)//复旦微：退出厂内模式
        {
            string result = null;
            Protocol645 p645 = new Protocol645();
            p645.FDWBroad("AA0F", "00", out result);
        }
        #endregion

        #region 钜泉
        private void btnReadJvQuanSoftVer_Click(object sender, EventArgs e)//读钜泉内部软件版本号
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tBJvQuanVer, "04CC0000");
        }

        private void btnReadJvQuanFac_Click(object sender, EventArgs e)//读钜泉出厂模式
        {
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tBJvQuanFacMod, "04CC0001");
        }

        private void btnSetJvQuanFacMod_Click(object sender, EventArgs e)//设钜泉出厂模式
        {
            if (tBSetJvQuanFacMod.Text == "FF" || tBSetJvQuanFacMod.Text == "00")
            {
                Protocol645 p645 = new Protocol645();
                p645.SetParameter(tBSetJvQuanFacMod, "04CC0001");
            }
            else
            {
                MessageBox.Show("请填00或FF！");
            }
        }

        private void btnJvQuanInit_Click(object sender, EventArgs e)//钜泉初始化
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter("04CC00FF", "");
        }
        #endregion

        #region 欣瑞利
        private void CountTextNum(object sender, EventArgs e)//计字节数
        {
            TextBox tb = (TextBox)sender;
            Control gb = tb.Parent;
            if (gb is GroupBox)
            {
                (gb as GroupBox).Text = "字节数:" + Counter.CountTxtByte(tb.Text);
            }
        }
        private void _97IdReadSet(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox tbVal = new TextBox();
            TextBox tbId = new TextBox();
            string res = string.Empty;
            Protocol645 p645 = new Protocol645();
            if (btn == btnRead1 || btn == btnSet1) { tbId = txtId1; tbVal = txtData1; }
            if (btn == btnRead2 || btn == btnSet2) { tbId = txtId2; tbVal = txtData2; }
            if (btn == btnRead1 || btn == btnRead2)
            {
                tbVal.Text = "";
                Functions.Delay(10);
                p645.SF_ReadData(tbId.Text, out res);
                tbVal.Text = res;
            }
            if (btn == btnSet1 || btn == btnSet2)
            {
                if (!p645.SF_SetData(tbId.Text, tbVal.Text))
                {
                    //statusReturn.Text = "";
                }
            }
        }
        private void btnReadC14D_Click(object sender, EventArgs e)
        {
            txtRc14d.Text = "";
            Functions.Delay(10);
            string result = string.Empty;
            Protocol645 p645 = new Protocol645();
            if (p645.SF_ReadData("C14D", out result))
            {
                txtRc14d.Text = result;
            }
        }

        private void btnSetC14D_Click(object sender, EventArgs e)
        {
            string data = txtSc14d.Text.PadLeft(2, '0');
            Protocol645 p645 = new Protocol645();
            if (!p645.SF_SetData("C14D", data))
            {
                MessageBox.Show("设置失败！");
            }
        }
        
        private void btnInit_Click(object sender, EventArgs e)
        {
            //string frm = "68 AA AA AA AA AA AA 68 04 0A 43 F3 33 7D 85 87 33 34 3A CA 37 16";
            //Protocol645 p645 = new Protocol645();
            //Protocol645.SendAndReceiveFrame(frm.Replace(" ",""));
        }
        #endregion

    }
}
