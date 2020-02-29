using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace instagram
{
    public static class Log
    {
        internal static ILoggerFactory LoggerFactory { get; set; }
        internal static ILogger _logger { get; set; }

        internal static void CreateLogger(string categoryName)
        {
            LoggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            _logger =  LoggerFactory.CreateLogger(categoryName);
        }
    }
}
