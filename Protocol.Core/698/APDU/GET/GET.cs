using Protocol.Core._698.Enums;
using System.Net;

namespace Protocol.Core._698.APDU.GET
{
    public class GET
    {
        public GET() { }
        public GET(APDU_Type APDU_Type)
        {

        }
        public static GetRequest GetRequest { get; set; }
        public static GetResponse GetResponse { get; set; }
    }
}
