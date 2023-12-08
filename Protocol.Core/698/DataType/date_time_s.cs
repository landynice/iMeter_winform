

namespace Protocol.Core._698.DataType
{
    public class date_time_s
    {
        public date_time_s() { }
        public date_time_s(ushort year, byte month, byte day, byte hour, byte minute, byte second)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public date_time_s(byte[] dateTimeS)
        {
            if (dateTimeS != null && dateTimeS.Length == 7)
            {
                this.year = (ushort)(dateTimeS[0] << 8 | dateTimeS[1]);
                this.month = dateTimeS[2];
                this.day = dateTimeS[3];
                this.hour = dateTimeS[4];
                this.minute = dateTimeS[5];
                this.second = dateTimeS[6];
            }
        }

        public ushort year { get; set; }
        public byte month { get; set; }
        public byte day { get; set; }
        public byte hour { get; set; }
        public byte minute { get; set; }
        public byte second { get; set; }

        public byte[] Data => new byte[] { (byte)(year >> 8), (byte)(year & 0x0f), month, day, hour, minute, second };
        public int Length = 7;
    }
}
