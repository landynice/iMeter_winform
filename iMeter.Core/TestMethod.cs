using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iMeter
{
    public partial class TestMethod : Form
    {
        public TestMethod()
        {
            InitializeComponent();
        }

        private void TestMethod_Load(object sender, EventArgs e)
        {
            textBoxSetTime.Text =
                "测试方法：\r\n\r\n"
                + "1、将电表内的校时记录清零；\r\n\r\n"
                + "2、随机设置时间；\r\n\r\n"
                + "3、抄读10次校时记录，比较上1次记录中的“校时后时间”是否为刚才设进去的时间；\r\n\r\n"
                + "4、比较现在读回来的2~10次记录是否等于上次读回来的1~9次记录；\r\n\r\n"
                + "5、重复1~4步骤；\r\n\r\n";

            textBoxZhengdian.Text =
                "测试方法：\r\n\r\n"
                + "1、抄读上1~N（N>1）次整点冻结数据，保存到m1；\r\n\r\n"
                + "2、设电表时间为现在小时的59分55秒（若电表为半整点冻结，则判断分钟如果小于30分就设为当前小时的29分55秒，如果分钟大于或等于30就设为当前小时的59分55秒）；\r\n\r\n"
                + "3、等待10秒（等电表时间跑过整点（半整点））；\r\n\r\n"
                + "4、抄读上1~N（N>1）次整点冻结数据，保存到m2；\r\n\r\n"
                + "5、比较上1次整点冻结中整点冻结时间是否等于刚跑过的整点（半整点）；\r\n\r\n"
                + "6、比较m2中的上2~N次数据是否等于m1中的上1~N-1次数据；\r\n\r\n"
                + "7、重复2~6步骤；\r\n\r\n";
        }
    }
}
