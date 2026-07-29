using System.Text;

namespace ModelBinding.options
{
    public class TextFileLogger : ILogger
    {


        private readonly string _categoryName;
        private readonly textFileLoggerOptions _options;
        private readonly ICorrelationIdAccessor _correlationIdAccessor;

        private static readonly object _fileLock = new();

        public TextFileLogger(string categoryName, textFileLoggerOptions options,
            ICorrelationIdAccessor correlationIdAccessor)
        {
            _categoryName = categoryName;
            options = _options;
            correlationIdAccessor = _correlationIdAccessor;
        }


        public IDisposable? BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= _options.MinimumLogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if(!IsEnabled(logLevel))
            {
                return;
            }
            var message = formatter(state ,exception);
            var correlationId = _correlationIdAccessor.getCorrelationId();
            var logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} " +
                $"[{logLevel}] " +
                $"{_categoryName} " +
                $"[CorrelationId:{correlationId}] - " +
                $"{message}" +
                Environment.NewLine;


            lock(_fileLock)
            {
                File.AppendAllText(
                    _options.FilePath,
                    logLine,
                    Encoding.UTF8
                    );
            }
        }
    }
}
