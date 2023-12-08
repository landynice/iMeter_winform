using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protocol.Core._698.Enums;

namespace Protocol.Core._698.DataType
{
    public class TI
    {
        public TI() { }
        public TI(byte[] data)
        {
            if (data == null || data.Length != 3) throw new ArgumentNullException("data");
            this.Unit = (TI_Unit)data[0];
            this.Interval = (ushort)(data[1] << 8 | data[2]);
        }
        public TI_Unit Unit { get; set; }
        public ushort Interval { get; set; }
        public byte[] Data => new byte[3] { (byte)this.Unit, (byte)(this.Interval >> 8), (byte)(this.Interval & 0x0f) };
        public int Length = 3;
        public static byte DataType = 84;
    }
}
