using Serilog;
using Serilog.Core;

namespace WatchList.Core.Extension
{
    public static class LoggerExtension
    {
        public static Logger CreateLogger(this string logDirectory)
            => new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(
                    Path.Combine(logDirectory, "log.txt"),
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 5 * 1024 * 1024,
                    rollOnFileSizeLimit: true,
                    shared: true)
                .CreateLogger();
    }
}
