using System;
using System.Windows.Forms;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelEnergyTest : UserControl
    {
        public override string Text { get => "电量测试"; }
        public PanelEnergyTest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开始测试按钮：读电量、时间
        /// </summary>
        private void btnEnergyTestStart_Click(object sender, EventArgs e)
        {
            this.btnEnergyTestStart.Enabled = false;
            this.btnEnergyTestStop.Enabled = true;
            this.checkBoxZuhe.Enabled = false;
            this.checkBoxZhengxiang.Enabled = false;
            this.checkBoxFanxiang.Enabled = false;
            this.radioButtonZ.Enabled = false;
            this.radioButtonZ_F.Enabled = false;
            this.radioButtonF.Enabled = false;
            dataGridViewTestEnergy.Rows.Clear();
            Protocol645 p645 = new Protocol645();

            int k = 0;
            dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());//加空行
            dataGridViewTestEnergy[6, k].Value = DateTime.Now.ToString("HH:mm:ss");
            if (checkBoxZuhe.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "开始组合有功电量";

                string sEnergy = null;
                double[] energy = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    p645.ReadData("00000" + i.ToString() + "00", out sEnergy);//00000000、00000100、00000200、00000300、00000400
                    dataGridViewTestEnergy[i, k].Value = Functions.RecvDataDeal(sEnergy, 6, 2);
                    energy[i] = Convert.ToDouble(dataGridViewTestEnergy[i, k].Value);
                }

                double wucha = energy[0] - (energy[1] + energy[2] + energy[3] + energy[4]);
                dataGridViewTestEnergy[5, k].Value = wucha.ToString("F2");
                k++;
                Update();
            }
            if (checkBoxZhengxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "开始正向有功电量";

                string zEnergy = null;
                double[] energy = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    p645.ReadData("00010" + i.ToString() + "00", out zEnergy);//00010000、00010100、00010200、00010300、00010400
                    dataGridViewTestEnergy[i, k].Value = Functions.RecvDataDeal(zEnergy, 6, 2);
                    energy[i] = Convert.ToDouble(dataGridViewTestEnergy[i, k].Value);
                }

                double wucha = energy[0] - (energy[1] + energy[2] + energy[3] + energy[4]);
                dataGridViewTestEnergy[5, k].Value = wucha.ToString("F2");
                k++;
                Update();
            }
            if (checkBoxFanxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "开始反向有功电量";

                string fEnergy = null;
                double[] energy = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    p645.ReadData("00020" + i.ToString() + "00", out fEnergy);//00020000、00020100、00020200、00020300、00020400
                    dataGridViewTestEnergy[i, k].Value = Functions.RecvDataDeal(fEnergy, 6, 2);
                    energy[i] = Convert.ToDouble(dataGridViewTestEnergy[i, k].Value);
                }

                double wucha = energy[0] - (energy[1] + energy[2] + energy[3] + energy[4]);
                dataGridViewTestEnergy[5, k].Value = wucha.ToString("F2");
                k++;
                Update();
            }

            if (radioButtonZ_F.Checked && checkBoxZuhe.Checked && checkBoxZhengxiang.Checked && checkBoxFanxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "组合=正+反(误差)";

                for (int i = 0; i < 5; i++)
                {
                    double energy = Convert.ToDouble(dataGridViewTestEnergy[i, 0].Value);
                    double energy1 = Convert.ToDouble(dataGridViewTestEnergy[i, 1].Value);
                    double energy2 = Convert.ToDouble(dataGridViewTestEnergy[i, 2].Value);
                    double wucha = energy - energy1 - energy2;
                    dataGridViewTestEnergy[i, k].Value = wucha.ToString("F2");
                }
                k++;
                Update();
            }
            if (radioButtonZ.Checked && checkBoxZuhe.Checked && checkBoxZhengxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "组合=正(误差)";

                for (int i = 0; i < 5; i++)
                {
                    double energy = Convert.ToDouble(dataGridViewTestEnergy[i, 0].Value);
                    double energy1 = Convert.ToDouble(dataGridViewTestEnergy[i, 1].Value);
                    double wucha = energy - energy1;
                    dataGridViewTestEnergy[i, k].Value = wucha.ToString("F2");
                }
                k++;
                Update();
            }
            if (radioButtonF.Checked && checkBoxZuhe.Checked && checkBoxFanxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "组合=反(误差)";

                if (checkBoxZhengxiang.Checked)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        double energy = Convert.ToDouble(dataGridViewTestEnergy[i, 0].Value);
                        double energy1 = Convert.ToDouble(dataGridViewTestEnergy[i, 2].Value);
                        double wucha = energy - energy1;
                        dataGridViewTestEnergy[i, k].Value = wucha.ToString("F2");
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        double energy = Convert.ToDouble(dataGridViewTestEnergy[i, 0].Value);
                        double energy1 = Convert.ToDouble(dataGridViewTestEnergy[i, 1].Value);
                        double wucha = energy - energy1;
                        dataGridViewTestEnergy[i, k].Value = wucha.ToString("F2");
                    }
                }
                k++;
                Update();
            }
        }
        /// <summary>
        /// 结束测试按钮：读电量、时间、电压、电流、功率因数，计算理论值、实际值
        /// </summary>
        private void btnEnergyTestStop_Click(object sender, EventArgs e)
        {
            this.btnEnergyTestStart.Enabled = true;
            this.btnEnergyTestStop.Enabled = false;
            this.checkBoxZuhe.Enabled = true;
            this.checkBoxZhengxiang.Enabled = true;
            this.checkBoxFanxiang.Enabled = true;
            this.radioButtonZ.Enabled = true;
            this.radioButtonZ_F.Enabled = true;
            this.radioButtonF.Enabled = true;
            string startTestTime = Convert.ToString(this.dataGridViewTestEnergy[6, 0].Value);
            string stopTestTime = null;
            Protocol645 p645 = new Protocol645();

            int k = this.dataGridViewTestEnergy.RowCount - 1;
            dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());//加空行
            dataGridViewTestEnergy[6, k].Value = DateTime.Now.ToString("HH:mm:ss");
            stopTestTime = Convert.ToString(dataGridViewTestEnergy[6, k].Value);

            if (checkBoxZuhe.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "结束组合有功电量";
                double[] energy = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    string sEnergy = null;
                    p645.ReadData("00000" + i.ToString() + "00", out sEnergy);
                    dataGridViewTestEnergy[i, k].Value = Functions.RecvDataDeal(sEnergy, 6, 2);
                    energy[i] = Convert.ToDouble(dataGridViewTestEnergy[i, k].Value);
                }
                double wucha = energy[0] - (energy[1] + energy[2] + energy[3] + energy[4]);
                dataGridViewTestEnergy[5, k].Value = wucha.ToString("F2");

                k++;
                Update();
            }
            if (checkBoxZhengxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "结束正向有功电量";
                double[] energy = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    string zEnergy = null;
                    p645.ReadData("00010" + i.ToString() + "00", out zEnergy);
                    dataGridViewTestEnergy[i, k].Value = Functions.RecvDataDeal(zEnergy, 6, 2);
                    energy[i] = Convert.ToDouble(dataGridViewTestEnergy[i, k].Value);
                }
                double wucha = energy[0] - (energy[1] + energy[2] + energy[3] + energy[4]);
                dataGridViewTestEnergy[5, k].Value = wucha.ToString("F2");

                k++;
                Update();
            }
            if (checkBoxFanxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "结束反向有功电量";
                double[] energy = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    string fEnergy = null;
                    p645.ReadData("00020" + i.ToString() + "00", out fEnergy);
                    dataGridViewTestEnergy[i, k].Value = Functions.RecvDataDeal(fEnergy, 6, 2);
                    energy[i] = Convert.ToDouble(dataGridViewTestEnergy[i, k].Value);
                }
                double wucha = energy[0] - (energy[1] + energy[2] + energy[3] + energy[4]);
                dataGridViewTestEnergy[5, k].Value = wucha.ToString("F2");

                k++;
                Update();
            }

            if (radioButtonZ_F.Checked && checkBoxZuhe.Checked && checkBoxZhengxiang.Checked && checkBoxFanxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "组合=正+反(误差)";

                for (int i = 0; i < 5; i++)
                {
                    double energy = Convert.ToDouble(dataGridViewTestEnergy[i, 0].Value);
                    double energy1 = Convert.ToDouble(dataGridViewTestEnergy[i, 1].Value);
                    double energy2 = Convert.ToDouble(dataGridViewTestEnergy[i, 2].Value);
                    double wucha = energy - energy1 - energy2;
                    dataGridViewTestEnergy[i, k].Value = wucha.ToString("F2");
                }

                k++;
                Update();
            }
            if (radioButtonZ.Checked && checkBoxZuhe.Checked && checkBoxZhengxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "组合=正(误差)";

                for (int i = 0; i < 5; i++)
                {
                    double energy = Convert.ToDouble(dataGridViewTestEnergy[i, 0].Value);
                    double energy1 = Convert.ToDouble(dataGridViewTestEnergy[i, 1].Value);
                    double wucha = energy - energy1;
                    dataGridViewTestEnergy[i, k].Value = wucha.ToString("F2");
                }

                k++;
                Update();
            }
            if (radioButtonF.Checked && checkBoxZuhe.Checked && checkBoxFanxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "组合=反(误差)";

                if (checkBoxZhengxiang.Checked)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        double energy = Convert.ToDouble(dataGridViewTestEnergy[i, 0].Value);
                        double energy1 = Convert.ToDouble(dataGridViewTestEnergy[i, 2].Value);
                        double wucha = energy - energy1;
                        dataGridViewTestEnergy[i, k].Value = wucha.ToString("F2");
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        double energy = Convert.ToDouble(dataGridViewTestEnergy[i, 0].Value);
                        double energy1 = Convert.ToDouble(dataGridViewTestEnergy[i, 1].Value);
                        double wucha = energy - energy1;
                        dataGridViewTestEnergy[i, k].Value = wucha.ToString("F2");
                    }
                }

                k++;
                Update();
            }

            dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());//加空行
            k++;

            //计算实际走电量、理论走电量
            //理论走电
            dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
            dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "理论走电";
            string A_voltageStr = null;
            string A_currentStr = null;
            string powerFactorStr = null;
            p645.ReadData("02010100", out A_voltageStr);
            p645.ReadData("02020100", out A_currentStr);
            p645.ReadData("02060000", out powerFactorStr);
            double A_voltage = Functions.RecvDataDeal(A_voltageStr, 3, 1);
            double A_current = Functions.RecvDataDeal(A_currentStr, 3, 3);
            double powerFactor = Functions.RecvDataDeal(powerFactorStr, 1, 3);
            double secondTime = Functions.CountTimeSpan(startTestTime, stopTestTime);
            double factEnergy = A_voltage * A_current * powerFactor * secondTime / 1000;
            this.dataGridViewTestEnergy[0, k].Value = factEnergy.ToString("F3");

            k++;
            //实际走电
            int zuheEnergyStartIndex = 0;
            int zuheEnergyEndIndex = 0;
            int zhengxEnergyStartIndex = 0;
            int zhengxEnergyEndIndex = 0;
            int fanxEnergyStartIndex = 0;
            int fanxEnergyEndIndex = 0;

            for (int i = 0; i < k; i++)
            {
                if (Convert.ToString(this.dataGridViewTestEnergy.Rows[i].HeaderCell.Value) == "开始组合有功电量")
                    zuheEnergyStartIndex = i;
                if (Convert.ToString(this.dataGridViewTestEnergy.Rows[i].HeaderCell.Value) == "开始正向有功电量")
                    zhengxEnergyStartIndex = i;
                if (Convert.ToString(this.dataGridViewTestEnergy.Rows[i].HeaderCell.Value) == "开始反向有功电量")
                    fanxEnergyStartIndex = i;
                if (Convert.ToString(this.dataGridViewTestEnergy.Rows[i].HeaderCell.Value) == "结束组合有功电量")
                    zuheEnergyEndIndex = i;
                if (Convert.ToString(this.dataGridViewTestEnergy.Rows[i].HeaderCell.Value) == "结束正向有功电量")
                    zhengxEnergyEndIndex = i;
                if (Convert.ToString(this.dataGridViewTestEnergy.Rows[i].HeaderCell.Value) == "结束反向有功电量")
                    fanxEnergyEndIndex = i;
            }
            if (checkBoxZuhe.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "实际组合走电";
                for (int i = 0; i < 5; i++)
                {
                    dataGridViewTestEnergy[i, k].Value = Convert.ToDouble(dataGridViewTestEnergy[i, zuheEnergyEndIndex].Value)
                       - Convert.ToDouble(dataGridViewTestEnergy[i, zuheEnergyStartIndex].Value);
                }
                k++;
            }
            if (checkBoxZhengxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "实际正向走电";
                for (int i = 0; i < 5; i++)
                {
                    dataGridViewTestEnergy[i, k].Value = Convert.ToDouble(dataGridViewTestEnergy[i, zhengxEnergyEndIndex].Value)
                       - Convert.ToDouble(dataGridViewTestEnergy[i, zhengxEnergyStartIndex].Value);
                }
                k++;
            }
            if (checkBoxFanxiang.Checked)
            {
                dataGridViewTestEnergy.Rows.Add(new DataGridViewRow());
                dataGridViewTestEnergy.Rows[k].HeaderCell.Value = "实际反向走电";
                for (int i = 0; i < 5; i++)
                {
                    dataGridViewTestEnergy[i, k].Value = Convert.ToDouble(dataGridViewTestEnergy[i, fanxEnergyEndIndex].Value)
                       - Convert.ToDouble(dataGridViewTestEnergy[i, fanxEnergyStartIndex].Value);
                }
                k++;
            }
        }


    }
}
