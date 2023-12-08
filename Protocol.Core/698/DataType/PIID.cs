using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Core._698.DataType
{
    public class PIID
    {
        public PIID(byte b)
        {
            this.Data = b;
        }
        public byte priority => (byte)(this.Data >> 7);
        public byte Data { get; set; }
        public int Length = 1;
    }
}
