namespace ModelBinding.options
{
    public class textFileLoggerOptions
    {
        public string FilePath { get; set; } = "Logs/app-log.txt";
        public LogLevel MinimumLogLevel { get; set; } = LogLevel.Information;
        public bool UseDailyRollingFiles { get; set; } = true;
    }
}
