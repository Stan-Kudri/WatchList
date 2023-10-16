using Microsoft.Extensions.Logging;

namespace WatchList.Test.CoreTest
{
    public sealed class TestLogger : ILogger
    {
        private readonly LogLevel _logLevel;

        public TestLogger(LogLevel logLevel = LogLevel.Trace) => _logLevel = logLevel;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = formatter(state, exception);
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
