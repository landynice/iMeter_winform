using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protocol.Core._698.DataType;

namespace Protocol.Core._698.APDU.GET
{
    public class GetRequestNormalList
    {
        public static byte bit = 2;
        public GetRequestNormalList(PIID PIID, OAD[] OADs)
        {
            this.PIID = PIID;
            this.OADs = OADs;
        }
        public PIID PIID { get; set; }
        public OAD[] OADs { get; set; }
    }
}
