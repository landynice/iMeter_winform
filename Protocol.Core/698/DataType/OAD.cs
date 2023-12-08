using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Core._698.DataType
{
    public class OAD
    {
        public OAD(byte[] oad)
        {
            this.OI = new OI(oad[0], oad[1]);
            this.Attribute = oad[2];
            this.Descriptor = oad[3];
        }
        public OI OI { get; set; }
        public byte Attribute { get; set; }
        public byte Descriptor { get; set; }

        public static byte DataType = 81;
        public byte[] Data => this.OI.Data.Concat(new byte[] { Attribute, Descriptor }).ToArray();

    }
}
