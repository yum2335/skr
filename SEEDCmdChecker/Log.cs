using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SeedCmdChecker
{
    public static class Log
    {
        #region フィールド
        private static readonly string logFileName = "CanConsole.csv";
        private static StreamWriter logStream = null;
        #endregion

        #region メソッド
        private static void fileOpen()
        {
            try
            {
                if (logStream == null)
                {
                    if (File.Exists(logFileName) == false)
                    {
                        File.Create(logFileName);
                    }
                    Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                    logStream = new StreamWriter(logFileName, true, sjisEnc);
                    logStream.Write(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:ffff") + "[START]");
                }
            }
            catch
            {

            }
        }

        public static void Write(string log , bool addTime)
        {
            fileOpen();

            try
            {
                if (addTime == true )
                {
                    logStream.Write(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:ffff") + " " + log);
                }
                else
                {
                    logStream.Write(log);
                }
            }
            catch
            {

            }
        }

        public static void WriteLine(string log, bool addTime)
        {
            fileOpen();

            try
            {
                if (addTime == true)
                {
                    logStream.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + " " + log);
                }
                else
                {
                    logStream.WriteLine(log);
                }
            }
            catch
            {

            }
        }

        public static void Close()
        {
            if (logStream != null)
            {
                logStream.Close();
                logStream = null;
            }
        }
        #endregion
    }
}
