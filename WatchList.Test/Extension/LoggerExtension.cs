using Serilog;
using Serilog.Core;

namespace WatchList.Test.Extension
{
    public static class LoggerExtension
    {
        public static Logger CreateLoggerTestExtension()
            => new LoggerConfiguration().WriteTo.Debug().CreateLogger();
    }
}
