using System;
using System.Windows.Forms;
using System.IO;
using PublicFunction;
using Protocol.Core;

namespace iMeter
{
    public partial class PanelInfinitTest : UserControl
    {
        public override string Text { get => "多次读取"; }
        public PanelInfinitTest()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            txtContent.Text = string.Empty;

            string id = txtId.Text;
            if (id.Length != 8)
            {
                MessageBox.Show("ID长度错误！");
                return;
            }

            if (!Functions.IsNum(txtTimes.Text))
            {
                MessageBox.Show("次数必须为阿拉伯数字");
                return;
            }
            UInt32 times = UInt32.Parse(txtTimes.Text.Replace(" ", ""));

            string result = string.Empty;
            Protocol645 p645 = new Protocol645();
            for (UInt32 i = 0; i < times; i++)
            {
                bool re = p645.ReadData(id, out result);
                if (re)
                {
                    txtContent.AppendText(string.Format("第{0}次读取数据：{1}\r\n", (i + 1).ToString().PadLeft(4, '0'), result));
                }
                else
                {
                    txtContent.AppendText(string.Format("第{0}次读取数据：非法报文帧，丢弃。\r\n", (i + 1).ToString().PadLeft(4, '0')));
                }
                Functions.Delay(100);
            }
        }

        private void btnOutData_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog objSave = new System.Windows.Forms.SaveFileDialog();
            objSave.Filter = "(*.txt)|*.txt|" + "(*.*)|*.*";
            objSave.FileName = "读取数据" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
            if (objSave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fileWriter = new StreamWriter(objSave.FileName, true);//写入文件
                fileWriter.Write(this.txtContent.Text);
                fileWriter.Close();//关闭StreamWriter对象
            }
        }
    }
}
