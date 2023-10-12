using System.Globalization;
using Microsoft.Extensions.Logging;

namespace WatchList.Core.Logger
{
    public class FileLogger : ILogger
    {
        private LogLevel _logLevel;
        private readonly string _pathFileLog;

        public FileLogger(LogLevel logLevel, string pathFileLog)
        {
            _logLevel = logLevel;
            _pathFileLog = pathFileLog;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = formatter(state, exception);
            var logText = string.Format("[{0} {1:G}] {2}", logLevel, DateTime.Now, message);
            File.AppendAllText(BuildPath(), logText + Environment.NewLine);
        }

        public bool IsEnabled(LogLevel logLevel) => _logLevel <= logLevel;

        public IDisposable? BeginScope<TState>(TState state)
            where TState : notnull
            => new Disposable();

        private sealed class Disposable : IDisposable
        {
            public void Dispose()
            {
            }
        }

        private string BuildPath()
        {
            var dateStr = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            return Path.Combine(_pathFileLog, dateStr + ".txt");
        }
    }
}
