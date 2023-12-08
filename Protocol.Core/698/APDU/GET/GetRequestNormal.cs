using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protocol.Core._698.DataType;

namespace Protocol.Core._698.APDU.GET
{
    public class GetRequestNormal
    {
        public static byte bit = 1;

        public GetRequestNormal(PIID PIID, OAD OAD)
        {
            this.PIID = PIID;
            this.OAD = OAD;
        }
        public PIID PIID { get; set; }
        public OAD OAD { get; set; }
        public byte[] Data => new byte[] { 0x01, this.PIID.Data, this.OAD.Data[0], this.OAD.Data[1], this.OAD.Data[2], this.OAD.Data[3] };
    }
}
