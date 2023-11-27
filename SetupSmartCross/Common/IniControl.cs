using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Common
{
    public class IniControl
    {
        /* .ini파일 쓰는 함수
        * string section : [section]
        * string key : 값의 키 (val의 key)
        * string val : 키의 값 (key의 val)
        * filePath  : 쓸 ini 파일경로
        */
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val,
                                                            string filePath);

        /*  .ini파일 읽는 함수
        * string section : 가져올 값의 키가 속해있는 섹션이름
        * string key : 가져올 값의 키이름
        * string def : 키의 값이 없을경우 기본값(default)
        * StringBuilder retVal : 가져올 값
        * int size : 가져올 값의 길이
        * string filePath : 읽어올 ini 파일경로
        * 
        * return value : 읽어들여온 데이터 길이
        */
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def,
                                                StringBuilder retVal, int size, string filePath);

        public static bool IniExists()
        {
            return System.IO.File.Exists(Application.StartupPath + @"\Config.ini");
        }

        public static bool IniExists(string path)
        {
            return System.IO.File.Exists(path);
        }

        // ini쓰기
        public static void WriteIniFile(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, Application.StartupPath + @"\Config.ini");
        }

        public static void WriteIniFile(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        // ini읽기
        public static string ReadIniFile(string section, string key, string def = "")
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, def, sb, sb.Capacity, Application.StartupPath + @"\Config.ini");

            return sb.ToString();
        }

        public static string ReadIniFile(string section, string key, string def, string path)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, def, sb, sb.Capacity, path);

            return sb.ToString();
        }

        public static int ReadIniFileInt(string section, string key, string def)
        {
            int Result = 0;
            int.TryParse(ReadIniFile(section, key, def), out Result);

            return Result;
        }

        public static double ReadIniFileDouble(string section, string key, string def)
        {
            double Result = 0;
            double.TryParse(ReadIniFile(section, key, def), out Result);

            return Result;
        }

        //public string ReadIniFile(string section, string key, string path)
        //{
        //    StringBuilder sb = new StringBuilder(255);
        //    GetPrivateProfileString(section, key, "", sb, sb.Capacity, path);

        //    return sb.ToString();
        //}

    }
}
