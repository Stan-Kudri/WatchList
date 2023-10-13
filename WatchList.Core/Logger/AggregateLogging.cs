using Microsoft.Extensions.Logging;

namespace WatchList.Core.Logger
{
    public class AggregateLogging : List<ILogger>, ILogger
    {
        private readonly LogLevel _logLevel;

        public AggregateLogging()
            : base()
        {
        }

        public AggregateLogging(int capacity)
            : base(capacity)
        {
        }

        public AggregateLogging(IEnumerable<ILogger> collection)
            : base(collection)
        {
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            foreach (var loggin in this)
            {
                loggin.Log(logLevel, eventId, state, exception, formatter);
            }
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
