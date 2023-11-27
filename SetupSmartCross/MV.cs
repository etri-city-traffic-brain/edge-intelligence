using Common;
using DataBaseControl;
using SetupSmartCross.DataBase;
using SetupSmartCross.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SetupSmartCross
{
    public enum Permission
    {
        ImageSave,
        FileSave,
        Print,
        ManageUser,
        SetupSystem,
        SetupTraffic,
        ManageCrossCam,
        ManageCross,
        Search,
        MonitorTrafficDelay,
        SearchTrafficLog,
        SearchTrafficStats,
        SearchCrossCamStatus,
        SearchLinkLog,
        SearchLinkStats,
    }

    public enum TreeLocalIcon
    {
        Off = 0,
        On = 1,
        CrossA = 10,
        CrossB = 20,
        CrossC = 30,
        CrossD = 40,
        CrossE = 50,
        CrossF = 60,
        CrossFF = 70,
        CrossFFF = 80,
        Road = 100,
    }

    class MV
    {
        public static CPU cpu { get; set; }
        public static Memory memory { get; set; }

        public static CodeInfo LocalType = new CodeInfo();
        public static CodeInfo CrossDirection = new CodeInfo();
        public static CodeInfo CrossType = new CodeInfo();
        public static CodeInfo Permission = new CodeInfo();

        public static LogControl LogCtrl { get; set; }
        public static DbManager DbManager { get; set; }
        public static dynamic SQL;
        public static LoadData LoadData { get; set; }

        public static Dictionary<string, BitmapImage> MapIconInfo = new Dictionary<string, BitmapImage>();
        public static Dictionary<string, Image> IconInfo = new Dictionary<string, Image>();
    }
}
