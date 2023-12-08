using System;
using System.Linq;
using Protocol.Core._698.DataType;

namespace Protocol.Core._698.APDU.TimeTag
{
    public class TimeTag
    {
        public TimeTag(date_time_s sendTime, TI allowTransferDelayTime)
        {
            this.SendTime = sendTime;
            this.AllowTransferDelayTime = allowTransferDelayTime;
        }
        public date_time_s SendTime { get; set; }
        public TI AllowTransferDelayTime { get; set; }
        public byte[] Data
        {
            get
            {
                if (this.SendTime != null && this.AllowTransferDelayTime != null)
                {
                    byte[] ret = new byte[10];
                    Array.Copy(this.SendTime.Data, ret, this.SendTime.Length);
                    return this.SendTime.Data.Concat(this.AllowTransferDelayTime.Data).ToArray();
                }
                else
                {
                    return new byte[] { 0x00 };
                }
            }
        }

    }
}
