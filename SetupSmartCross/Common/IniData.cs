using System;
using System.Collections.Generic;
using System.IO;
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
        public static int MapMaxZoomLevel = 17;
        public static string MapPath = "Maps";
        public static string MapPbfPath = "¼¼Á¾.osm.pbf";
        public static int MapKind = 0;

        public static string ParamCrossColorFast = "Green";
        public static string ParamCrossColorSlow = "Orange";
        public static string ParamCrossColorStop = "Red";
        public static double ParamCrossSlow = 30;
        public static double ParamCrossStop = 60;

        public static void Read()
        {
            CenterDbIP = IniControl.ReadIniFile("CENTER", "DATABASE_IP", "");
            CenterDbPort = IniControl.ReadIniFile("CENTER", "DATABASE_PORT", "0");
            CenterDbID = IniControl.ReadIniFile("CENTER", "DATABASE_ID", "");
            CenterDbPW = IniControl.ReadIniFile("CENTER", "DATABASE_PW", "");

            MapX = IniControl.ReadIniFileDouble("MAP", "X", "0");
            MapY = IniControl.ReadIniFileDouble("MAP", "Y", "0");
            MapZ = IniControl.ReadIniFileInt("MAP", "Z", MapZ.ToString());
            MapMinZoomLevel = IniControl.ReadIniFileInt("MAP", "MIN_ZOOM_LEVEL", MapMinZoomLevel.ToString());
            MapMaxZoomLevel = IniControl.ReadIniFileInt("MAP", "MAX_ZOOM_LEVEL", MapMaxZoomLevel.ToString());
            MapPath = IniControl.ReadIniFile("MAP", "PATH", MapPath);
            MapKind = IniControl.ReadIniFileInt("MAP", "KIND", "0");
            MapPbfPath = IniControl.ReadIniFile("MAP", "PBF_PATH", MapPbfPath);
          
            if(string.IsNullOrEmpty(MapPath))
            {
                MapPath = Path.Combine(Application.StartupPath, "Maps");
            }
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
            IniControl.WriteIniFile("MAP", "PBF_PATH", MapPbfPath);
        }
    }
}
