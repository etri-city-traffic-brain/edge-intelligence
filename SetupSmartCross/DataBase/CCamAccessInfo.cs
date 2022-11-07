using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupSmartCross.DataBase
{

    public class CrossDirection
    {
        public static string E = "0";
        public static string W = "1";
        public static string S = "2";
        public static string N = "3";
        public static string NE = "4";
        public static string NW = "5";
        public static string SE = "6";
        public static string SW = "7";
        public static string IN = "8";
    }

    public class CCamAccessInfo
    {
        public string cam_id;
        public string direction;
        public string direction_name;
        public string name;
        public double x;
        public double y;
        public double angle;
    }

    public class CCamAccessColor
    {
        public static Color[] Colors = new Color[12] { 
            Color.FromArgb(63, 104, 155), 
            Color.FromArgb(157, 64, 61), 
            Color.FromArgb(126, 153, 71),
            Color.FromArgb(104, 80, 132),
            Color.FromArgb(59, 140, 162),
            Color.FromArgb(203, 122, 55),
            Color.FromArgb(78, 128, 188),
            Color.FromArgb(191, 79, 76),
            Color.FromArgb(154, 186, 88),
            Color.FromArgb(127, 99, 161),
            Color.FromArgb(74, 171, 197),
            Color.FromArgb(246, 146, 69),
        };
    }
}
