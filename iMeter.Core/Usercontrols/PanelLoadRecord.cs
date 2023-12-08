using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iMeter.Usercontrols
{
    public partial class PanelLoadRecord : UserControl
    {
        public override string Text { get => "负荷记录"; }
        public PanelLoadRecord()
        {
            InitializeComponent();
        }
    }
}
