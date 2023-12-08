using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelStatePara : UserControl
    {
        public override string Text { get => "状态字/模式字/特征字"; }
        public PanelStatePara()
        {
            InitializeComponent();
        }

        private void btnReadStatus1_Click(object sender, EventArgs e)//电表运行状态字1
        {
            tbRunStatus1.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbRunStatus1, "04000501");
            string str = tbRunStatus1.Text;
            if (str.Length == 4)
            {
                List<string> list = new List<string>();
                list.Add("电表运行状态字1：");
                list.Add("保留");
                list.Add("费控模式状态\r\n(0本地，\r\n1远程)");
                list.Add("无功功率方向\r\n(0正向,1反向)");
                list.Add("有功功率方向\r\n(0正向,1反向)");
                list.Add("停电抄表电池\r\n(0正常,1欠压)");
                list.Add("时钟电池\r\n(0正常,1欠压)");
                list.Add("需量积算方式\r\n(0滑差,1区间)");
                list.Add("计量单元异常");
                list.Add("时钟故障");
                list.Add("透支状态");
                list.Add("存储器故障\r\n或损坏");
                list.Add("内部程序错误");
                list.Add("保留");
                list.Add("保留");
                list.Add("ESAM错误");
                list.Add("控制回路错误");
                DrawGrid(str, list);
            }
        }

        private void btnReadStatus2_Click(object sender, EventArgs e)//电表运行状态字2
        {
            tbRunStatus2.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbRunStatus2, "04000502");
            string str = tbRunStatus2.Text;
            if (str.Length == 4)
            {
                List<string> list = new List<string>();
                list.Add("电表运行状态字2：");
                list.Add("保留");
                list.Add("C相无功功率方向\r\n(0正向,1反向)");
                list.Add("B相无功功率方向\r\n(0正向,1反向)");
                list.Add("A相无功功率方向\r\n(0正向,1反向)");
                list.Add("保留");
                list.Add("C相有功功率方向\r\n(0正向,1反向)");
                list.Add("B相有功功率方向\r\n(0正向,1反向)");
                list.Add("A相有功功率方向\r\n(0正向,1反向)");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                DrawGrid(str, list);
            }
        }

        private void btnReadStatus3_Click(object sender, EventArgs e)//电表运行状态字3
        {
            tbRunStatus3.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbRunStatus3, "04000503");
            string str = tbRunStatus3.Text;
            if (str.Length == 4)
            {
                List<string> list = new List<string>();
                list.Add("电表运行状态字3：");
                list.Add("预跳闸报警状态\r\n(0无,1有)");
                list.Add("继电器命令状态\r\n(0通,1断)");
                list.Add("当前运行时区\r\n(0第一套,1第二套");
                list.Add("继电器状态\r\n(0通,1断)");
                list.Add("红外认证/编程\r\n允许状态\r\n(0失效,1有效)");
                list.Add("供电方式");
                list.Add("(00主电源\r\n01辅助电源\r\n10电池供电)");
                list.Add("当前运行时段\r\n(0第一套,1第二套)");
                list.Add("远程开户\r\n(0开户,1未开户)");
                list.Add("本地开户\r\n(0开户,1未开户)");
                list.Add("身份认证状态\r\n(0失效,1有效)");
                list.Add("保电状态\r\n(0非保电,1保电)");
                list.Add("保留");
                list.Add("保留");
                list.Add("电能表类型");
                list.Add("(00非预付费\r\n01电量型预付费表\r\n10电费型预付费表)");
                DrawGrid(str, list);
            }
        }

        private void btnReadStatus4_Click(object sender, EventArgs e)//电表运行状态字4
        {
            tbRunStatus4.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbRunStatus4, "04000504");
            string str = tbRunStatus4.Text;
            if (str.Length == 4)
            {
                List<string> list = new List<string>();
                list.Add("电表运行状态字4：\r\nA相故障状态");
                list.Add("断相");
                list.Add("潮流反向");
                list.Add("过载");
                list.Add("过流");
                list.Add("失流");
                list.Add("过压");
                list.Add("欠压");
                list.Add("失压");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("断流");
                DrawGrid(str, list);
            }
        }

        private void btnReadStatus5_Click(object sender, EventArgs e)//电表运行状态字5
        {
            tbRunStatus5.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbRunStatus5, "04000505");
            string str = tbRunStatus5.Text;
            if (str.Length == 4)
            {
                List<string> list = new List<string>();
                list.Add("电表运行状态字5：\r\nB相故障状态");
                list.Add("断相");
                list.Add("潮流反向");
                list.Add("过载");
                list.Add("过流");
                list.Add("失流");
                list.Add("过压");
                list.Add("欠压");
                list.Add("失压");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("断流");
                DrawGrid(str, list);
            }
        }

        private void btnReadStatus6_Click(object sender, EventArgs e)//电表运行状态字6
        {
            tbRunStatus6.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbRunStatus6, "04000506");
            string str = tbRunStatus6.Text;
            if (str.Length == 4)
            {
                List<string> list = new List<string>();
                list.Add("电表运行状态字6：\r\nC相故障状态");
                list.Add("断相");
                list.Add("潮流反向");
                list.Add("过载");
                list.Add("过流");
                list.Add("失流");
                list.Add("过压");
                list.Add("欠压");
                list.Add("失压");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("断流");
                DrawGrid(str, list);
            }
        }

        private void btnReadStatus7_Click(object sender, EventArgs e)//电表运行状态字7
        {
            tbRunStatus7.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbRunStatus7, "04000507");
            string str = tbRunStatus7.Text;
            if (str.Length == 4)
            {
                List<string> list = new List<string>();
                list.Add("电表运行状态字7：\r\n合相故障状态");
                list.Add("总功率因数\r\n超下限\r\n(0无故障,1故障)");
                list.Add("需量超限");
                list.Add("掉电");
                list.Add("辅助电源失电");
                list.Add("电流不平衡");
                list.Add("电压不平衡");
                list.Add("电流逆相序");
                list.Add("电压逆相序");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("开端钮盖\r\n(0无故障,1故障)");
                list.Add("开表盖\r\n(0无故障,1故障)");
                list.Add("电流严重不平衡\r\n(0无故障,1故障)");
                DrawGrid(str, list);
            }

        }

        private void btn有功方式特征字_Click(object sender, EventArgs e)
        {
            tbYgzhfstzz.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbYgzhfstzz, "04000601");
            string str = tbYgzhfstzz.Text;
            if (str.Length == 2)
            {
                List<string> list = new List<string>();
                list.Add("有功组合方式特征字：");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("反向有功\r\n(0不减,1减)");
                list.Add("反向有功\r\n(0不加,1加)");
                list.Add("正向有功\r\n(0不减,1减)");
                list.Add("正向有功\r\n(0不加,1加)");
                DrawGrid(str, list);
            }
        }

        private void btn无功组合方式1特征字_Click(object sender, EventArgs e)
        {
            tbWgzhfstzz1.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbWgzhfstzz1, "04000602");
            string str = tbWgzhfstzz1.Text;
            if (str.Length == 2)
            {
                List<string> list = new List<string>();
                list.Add("无功组合方式1特征字：");
                list.Add("IV象限\r\n(0不减,1减)");
                list.Add("IV象限\r\n(0不加,1加)");
                list.Add("III象限\r\n(0不减,1减)");
                list.Add("III象限\r\n(0不加,1加)");
                list.Add("II象限\r\n(0不减,1减)");
                list.Add("II象限\r\n(0不加,1加)");
                list.Add("I象限\r\n(0不减,1减)");
                list.Add("I象限\r\n(0不加,1加)");
                DrawGrid(str, list);
            }
        }

        private void btn无功组合方式2特征字_Click(object sender, EventArgs e)
        {
            tbWgzhfstzz2.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbWgzhfstzz2, "04000603");
            string str = tbWgzhfstzz2.Text;
            if (str.Length == 2)
            {
                List<string> list = new List<string>();
                list.Add("无功组合方式2特征字：");
                list.Add("IV象限\r\n(0不减,1减)");
                list.Add("IV象限\r\n(0不加,1加)");
                list.Add("III象限\r\n(0不减,1减)");
                list.Add("III象限\r\n(0不加,1加)");
                list.Add("II象限\r\n(0不减,1减)");
                list.Add("II象限\r\n(0不加,1加)");
                list.Add("I象限\r\n(0不减,1减)");
                list.Add("I象限\r\n(0不加,1加)");
                DrawGrid(str, list);
            }
        }

        private void btn周休日特征字_Click(object sender, EventArgs e)
        {
            tbZxrtzz.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbZxrtzz, "04000801");
            string str = tbZxrtzz.Text;
            if (str.Length == 2)
            {
                List<string> list = new List<string>();
                list.Add("周休日特征字：");
                list.Add("保留");
                list.Add("周六");
                list.Add("周五");
                list.Add("周四");
                list.Add("周三");
                list.Add("周二");
                list.Add("周一");
                list.Add("周日");
                DrawGrid(str, list);
            }
        }

        private void btn负荷纪录模式字_Click(object sender, EventArgs e)
        {
            tbFhjlmsz.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbFhjlmsz, "04000901");
            string str = tbFhjlmsz.Text;
            if (str.Length == 2)
            {
                List<string> list = new List<string>();
                list.Add("负荷纪录模式字：");
                list.Add("保留");
                list.Add("保留");
                list.Add("当前需量");
                list.Add("四象限无功\r\n总电能");
                list.Add("有、无功\r\n总电能");
                list.Add("功率因数");
                list.Add("有、无功\r\n功率");
                list.Add("电压、电流、\r\n频率");
                DrawGrid(str, list);
            }
        }

        private void btn冻结数据模式字_Click(object sender, EventArgs e)
        {
            tbDjsjmsz.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbDjsjmsz, "04000902");
            string str = tbDjsjmsz.Text;
            if (str.Length == 2)
            {
                List<string> list = new List<string>();
                list.Add("冻结数据模式字：");
                list.Add("变量");
                list.Add("反向有功最大\r\n需量及发生时间");
                list.Add("正向有功最大\r\n需量及发生时间");
                list.Add("四象限无功\r\n电能");
                list.Add("组合无功2\r\n电能");
                list.Add("组合无功1\r\n电能");
                list.Add("反向有功\r\n电能");
                list.Add("正向有功\r\n电能");
                DrawGrid(str, list);
            }
        }

        private void btn电表运行特征字1_Click(object sender, EventArgs e)
        {
            tbDbyxtzz1.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbDbyxtzz1, "04001101");
            string str = tbDbyxtzz1.Text;
            if (str.Length == 2)
            {
                List<string> list = new List<string>();
                list.Add("电表运行特征字1：");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("主动上报模式\r\n(0不启用后续标志,\r\n1启用后续标志)");
                list.Add("液晶①②字样意义\r\n(0显示1,2套时段,\r\n1显示1,2套费率)");
                list.Add("外置开关控制方式\r\n(0电平,1脉冲)");
                DrawGrid(str, list);
            }
        }

        private void btn读主动上报模式字_Click(object sender, EventArgs e)
        {
            tbZdsbmsz.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbZdsbmsz, "04001104");
            string str = tbZdsbmsz.Text;
            if (str.Length == 16)
            {
                List<string> list = new List<string>();
                list.Add("主动上报模式字：");
                list.Add("时钟故障");
                list.Add("保留");
                list.Add("存储器故障\r\n或损坏");
                list.Add("内部程序错误");
                list.Add("时钟电池\r\n电压低");
                list.Add("内卡初始化\r\n错误");
                list.Add("ESAM错误");
                list.Add("负荷开关\r\n误动或拒动");
                list.Add("合闸成功");
                list.Add("跳闸成功");
                list.Add("电源异常");
                list.Add("恒定磁场干扰");
                list.Add("开端钮盖");
                list.Add("开表盖");
                list.Add("透支状态");
                list.Add("停电抄表\r\n电池欠压");
                list.Add("断相");
                list.Add("功率反向");
                list.Add("过载");
                list.Add("过流");
                list.Add("失流");
                list.Add("过压");
                list.Add("欠压");
                list.Add("失压");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("断流");
                list.Add("总功率因数\r\n超下限");
                list.Add("需量超限");
                list.Add("掉电");
                list.Add("辅助电源失电");
                list.Add("电流不平衡");
                list.Add("电压不平衡");
                list.Add("电流逆相序");
                list.Add("电压逆相序");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("全失压");
                list.Add("潮流反向");
                list.Add("电流严重不平衡");
                list.Add("周休日编程");
                list.Add("时区表编程");
                list.Add("时段表编程");
                list.Add("校时");
                list.Add("事件清零");
                list.Add("需量清零");
                list.Add("电表清零");
                list.Add("编程");
                list.Add("密钥更新");
                list.Add("阶梯表编程");
                list.Add("费率参数表编程");
                list.Add("结算日编程");
                list.Add("无功组合\r\n方式2编程");
                list.Add("无功组合\r\n方式1编程");
                list.Add("有功组合\r\n方式编程");
                list.Add("节假日编程");
                DrawGrid(str, list);
            }
        }

        private void btn设主动上报模式字_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(tbZdsbmsz, "04001104");
        }

        private void btn主动上报状态字_Click(object sender, EventArgs e)
        {
            tbZdsbztz.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbZdsbztz, "04001501");
            string str = tbZdsbztz.Text.Substring(tbZdsbztz.Text.Length - 24);
            if (str.Length == 24)
            {
                List<string> list = new List<string>();
                list.Add("主动上报状态字：");
                list.Add("时钟故障");
                list.Add("保留");
                list.Add("存储器故障\r\n或损坏");
                list.Add("内部程序错误");
                list.Add("时钟电池电压低");
                list.Add("内卡初始化错误");
                list.Add("ESAM错误");
                list.Add("负荷开关\r\n误动或拒动");
                list.Add("合闸成功");
                list.Add("跳闸成功");
                list.Add("电源异常");
                list.Add("恒定磁场干扰");
                list.Add("开端钮盖");
                list.Add("开表盖");
                list.Add("透支状态");
                list.Add("停电抄表电池欠压");
                list.Add("A相断相");
                list.Add("A相功率反向");
                list.Add("A相过载");
                list.Add("A相过流");
                list.Add("A相失流");
                list.Add("A相过压");
                list.Add("A相欠压");
                list.Add("A相失压");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("A相断流");
                list.Add("B相断相");
                list.Add("B相功率反向");
                list.Add("B相过载");
                list.Add("B相过流");
                list.Add("B相失流");
                list.Add("B相过压");
                list.Add("B相欠压");
                list.Add("B相失压");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("B相断流");
                list.Add("C相断相");
                list.Add("C相功率反向");
                list.Add("C相过载");
                list.Add("C相过流");
                list.Add("C相失流");
                list.Add("C相过压");
                list.Add("C相欠压");
                list.Add("C相失压");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("C相断流");
                list.Add("总功率因数超下限");
                list.Add("需量超限");
                list.Add("掉电");
                list.Add("辅助电源失电");
                list.Add("电流不平衡");
                list.Add("电压不平衡");
                list.Add("电流逆相序");
                list.Add("电压逆相序");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("全失压");
                list.Add("潮流反向");
                list.Add("电流严重不平衡");
                list.Add("周休日编程");
                list.Add("时区表编程");
                list.Add("时段表编程");
                list.Add("校时");
                list.Add("事件清零");
                list.Add("需量清零");
                list.Add("电表清零");
                list.Add("编程");
                list.Add("密钥更新");
                list.Add("阶梯表编程");
                list.Add("费率参数表编程");
                list.Add("结算日编程");
                list.Add("无功组合\r\n方式2编程");
                list.Add("无功组合\r\n方式1编程");
                list.Add("有功组合\r\n方式编程");
                list.Add("节假日编程");
                DrawGrid(str, list);
            }
        }

        private void btn复位主动上报状态字_Click(object sender, EventArgs e)
        {
            Protocol645 p645 = new Protocol645();
            p645.SetParameter(tbFwzdsbztz, "04001503");
        }

        private void btn插卡状态字_Click(object sender, EventArgs e)
        {
            tbCkztz.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbCkztz, "04001502");
            string str = tbCkztz.Text;
            if (str.Length == 4)
            {
                List<string> list = new List<string>();
                list.Add("插卡状态字：");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("插卡状态\r\n(00未知,01成功,10失败)");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                list.Add("保留");
                DrawGrid(str, list);
            }
        }

        private void btn密钥状态字_Click(object sender, EventArgs e)
        {
            tbMyztz.Text = null;
            Protocol645 p645 = new Protocol645();
            p645.ReadParameter(tbMyztz, "04000508");
            string str = tbMyztz.Text;
            if (str.Length == 8)
            {
                List<string> list = new List<string>();
                list.Add("密钥状态字：");
                list.Add("密钥7状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥6状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥5状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥4状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥3状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥2状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥1状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("主控密钥状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥15状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥14状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥13状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥12状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥11状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥10状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥9状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥8状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥23状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥22状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥21状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥20状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥19状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥18状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥17状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥16状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥31状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥30状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥29状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥28状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥27状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥26状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥25状态\r\n(0测试状态,\r\n1正式状态)");
                list.Add("密钥24状态\r\n(0测试状态,\r\n1正式状态)");
                DrawGrid(str, list);
            }
        }

        /// <summary>
        /// 画表格
        /// 输入数据值，list表格解释内容
        /// 处理单元格的数值并将数值为1的显示绿色背景
        /// </summary>
        /// <param name="rowNums"></param>
        /// <param name="strValue"></param>
        private void DrawGrid(string strValue, List<string> listGridVal)
        {
            dgvStatus.Rows.Clear();//清除表格

            //处理数据值，将十六进制码转成8位二进制码
            byte[] byteValue = new byte[strValue.Length / 2];
            string[] strValue_byte = new string[strValue.Length / 2];
            for (int i = 0; i < strValue.Length / 2; i++)
            {
                byteValue[i] = Convert.ToByte(strValue.Substring(strValue.Length - (i + 1) * 2, 2), 16);
                strValue_byte[i] = Convert.ToString(byteValue[i], 2).PadLeft(8, '0');
            }

            if (strValue.Length > 0)
            {
                dgvStatus.Rows.Add((strValue.Length / 2) * 3 + 1);//添加空行
                dgvStatus[0, 0].Value = listGridVal[0];//标题
                for (int row = 0; row < strValue.Length / 2; row++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        //1.写Bit位，并填充颜色
                        dgvStatus[column, row * 3 + 1].Value = "Bit" + (8 * row + 7 - column).ToString();
                        dgvStatus[column, row * 3 + 1].Style.BackColor = Color.DarkGray;
                        //2.填入数值，数值为1的填充颜色
                        dgvStatus[column, row * 3 + 2].Value = strValue_byte[row][column];
                        if (strValue_byte[row][column] == '1')
                            dgvStatus[column, row * 3 + 2].Style.BackColor = Color.Green;
                        //3.写入解释
                        dgvStatus[column, row * 3 + 3].Value = listGridVal[row * 8 + column + 1];
                    }
                }
            }
        }

    }
}
