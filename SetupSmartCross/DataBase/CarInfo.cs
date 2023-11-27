using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupSmartCross.DataBase
{
    public class CarInfo
    {
        public string GROUP_KEY { get; set; }
        public string ID { get; set; }
        public ulong SEQ { get; set; }
        public string CROSS_ID { get; set; }
        public string CROSS_NAME { get; set; }
        public DateTime CAP_DATE { get; set; }
        public string CAR_NUM { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int CROSS_COUNT { get; set; }
        public int POINT_COUNT { get; set; }
    }
}
