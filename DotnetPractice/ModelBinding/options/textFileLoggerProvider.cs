using Microsoft.Extensions.Options;

namespace ModelBinding.options
{
    public class textFileLoggerProvider : ILoggerProvider
    {

        private readonly textFileLoggerOptions _options;
        private readonly ICorrelationIdAccessor _correlationIdAccessor;

        public textFileLoggerProvider(
            IOptions<textFileLoggerOptions> options,
            ICorrelationIdAccessor correlationIdAccessor)
        {
            _options = options.Value;
            _correlationIdAccessor =
                correlationIdAccessor;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new TextFileLogger(
                            categoryName,
                            _options,
                            _correlationIdAccessor);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
