using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupSmartCross.DataBase
{

    public class LocalType
    {
        public static string Cross = "0";
        public static string Road = "1";
    }

    public class LocalGroupInfo
    {
        public string id;
        public string parent_id;
        public string name;
        public string level;
        public string local_type;
    }
}
