using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class IniData
    {
        public static string LoginID = string.Empty;

        public static string CenterDbIP = string.Empty;
        public static string CenterDbPort = string.Empty;
        public static string CenterDbID = string.Empty;
        public static string CenterDbPW = string.Empty;
        
        public static double MapX = double.NaN;
        public static double MapY = double.NaN;
        public static int MapZ = 13;
        public static int MapMinZoomLevel = 13;
        public static int MapMaxZoomLevel = 18;
        public static string MapPath = string.Empty;
        public static int MapKind = 0;

        public static void Read()
        {
            CenterDbIP = IniControl.ReadIniFile("CENTER", "DATABASE_IP", "");
            CenterDbPort = IniControl.ReadIniFile("CENTER", "DATABASE_PORT", "0");
            CenterDbID = IniControl.ReadIniFile("CENTER", "DATABASE_ID", "");
            CenterDbPW = IniControl.ReadIniFile("CENTER", "DATABASE_PW", "");

            MapX = IniControl.ReadIniFileDouble("MAP", "X", "0");
            MapY = IniControl.ReadIniFileDouble("MAP", "Y", "0");
            MapZ = IniControl.ReadIniFileInt("MAP", "Z", "13");
            MapMinZoomLevel = IniControl.ReadIniFileInt("MAP", "MIN_ZOOM_LEVEL", "13");
            MapMaxZoomLevel = IniControl.ReadIniFileInt("MAP", "MAX_ZOOM_LEVEL", "17");
            MapPath = IniControl.ReadIniFile("MAP", "PATH", "");
            MapKind = IniControl.ReadIniFileInt("MAP", "KIND", "0");            
        }

        public static void Write()
        {

            IniControl.WriteIniFile("CENTER", "DATABASE_IP", CenterDbIP);
            IniControl.WriteIniFile("CENTER", "DATABASE_PORT", CenterDbPort);
            IniControl.WriteIniFile("CENTER", "DATABASE_ID", CenterDbID);
            IniControl.WriteIniFile("CENTER", "DATABASE_PW", CenterDbPW);

            IniControl.WriteIniFile("MAP", "X", MapX.ToString());
            IniControl.WriteIniFile("MAP", "Y", MapY.ToString());
            IniControl.WriteIniFile("MAP", "Z", MapZ.ToString());
            IniControl.WriteIniFile("MAP", "MIN_ZOOM_LEVEL", MapMinZoomLevel.ToString());
            IniControl.WriteIniFile("MAP", "MAX_ZOOM_LEVEL", MapMaxZoomLevel.ToString());
            IniControl.WriteIniFile("MAP", "PATH", MapPath);
            IniControl.WriteIniFile("MAP", "KIND", MapKind.ToString());
        }
    }
}
