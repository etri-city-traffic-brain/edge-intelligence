using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupSmartCross.DataBase
{
    public struct CODEINFO
    {
        public string code_id;
        public string code_name;
    }

    public class CodeInfo : List<CODEINFO>
    {

        public string GetCode(string name)
        {
            string code = string.Empty;
            foreach (CODEINFO item in this.Where(p => p.code_name == name))
            {
                code = item.code_id;
            }
            return code;
        }

        public string GetName(string code)
        {
            string name = string.Empty;
            foreach (CODEINFO item in this.Where(p => p.code_id == code))
            {
                name = item.code_name;
            }
            return name;
        }
    }
}
