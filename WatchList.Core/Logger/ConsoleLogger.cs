using Microsoft.Extensions.Logging;

namespace WatchList.Core.Logger
{
    public sealed class ConsoleLogger : ILogger
    {
        private readonly LogLevel _logLevel;

        public ConsoleLogger(LogLevel logLevel) => _logLevel = logLevel;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = formatter(state, exception);
            Console.WriteLine("[{0} {1:G}] {2}", logLevel, DateTime.Now, message);
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
    }
}
