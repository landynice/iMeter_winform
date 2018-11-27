using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iMeter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //MainForm frm = new MainForm();
            //Sunisoft.IrisSkin.SkinEngine skin = new Sunisoft.IrisSkin.SkinEngine((System.ComponentModel.Component)frm);
            //skin.SkinFile = "DiamondBlue.ssk";//指定皮肤文件
            //skin.TitleFont = new System.Drawing.Font("微软雅黑", 10F);//指定标题栏的Font
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
