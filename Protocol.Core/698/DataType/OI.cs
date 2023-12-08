using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Core._698.DataType
{
    public class OI
    {
        public OI(byte[] oi)
        {
            this.OIA = oi[0];
            this.OIB = oi[1];
        }
        public OI(byte oia, byte oib)
        {
            this.OIA = oia;
            this.OIB = oib;
        }
        public byte OIA { get; set; }
        public byte OIB { get; set; }

        public static byte DataType = 80;
        public byte[] Data => new byte[] { OIA, OIB };
    }
}
