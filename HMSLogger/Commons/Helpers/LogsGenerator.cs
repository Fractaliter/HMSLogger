using System;
using System.Collections.Generic;

namespace HMSLogger
{
    static class LogsGenerator
    {
        static List<string> LogInfo;

        static LogsGenerator()
        {
            //
            // Allocate the list.
            //
            LogInfo = new List<string>();
        }
        public static void Add(string value)
        {
            //
            // Record this value in the list.
            //
            LogInfo.Add(value);
        }
        public static string Read()
        {
            //
            // Write out the results.
            //
            string Strings =string.Empty;
            foreach (var value in LogInfo)
            {
                Strings += LogInfo;
            }
            return Strings;
        }
        public static List<string> GetList()
        {
            return LogInfo;
        }
    }
}
