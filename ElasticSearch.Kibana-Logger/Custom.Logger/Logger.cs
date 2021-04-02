using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace Custom.Logger
{
    public class CustomLogger : ILogger
    {
        private readonly string _name;

        private readonly CustomLoggerConfiguration _config;

        public CustomLogger(string name, CustomLoggerConfiguration config) => (_name, _config) = (name, config);

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => logLevel == _config.LogLevel;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //if (!IsEnabled(logLevel))
            //    return;

            if (_config.EventId == 0 || _config.EventId == eventId.Id)
            {
                if (_config.LoggerType == LoggerType.ElasticSearch)
                {
                    var eventIdx = eventId.Id; // CustomLoggerEvents Enum Id 
                    var logLevelx = logLevel; // Error , Info , etc .
                    var name = _name; // Controller Name
                    var message = $"{formatter(state, exception)}";

                }
            }

        }
    }

    public static class CustomLoggerExtensions
    {
        public static ILoggingBuilder AddColorConsoleLogger(this ILoggingBuilder builder) => builder.AddColorConsoleLogger(new CustomLoggerConfiguration());

        public static ILoggingBuilder AddColorConsoleLogger(this ILoggingBuilder builder, Action<CustomLoggerConfiguration> configure)
        {
            var config = new CustomLoggerConfiguration();
            configure(config);
            return builder.AddColorConsoleLogger(config);
        }

        public static ILoggingBuilder AddColorConsoleLogger(this ILoggingBuilder builder, CustomLoggerConfiguration config)
        {
            builder.AddProvider(new CustomLoggerProvider(config));
            return builder;
        }
    }

    public sealed class CustomLoggerProvider : ILoggerProvider
    {
        private readonly CustomLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new ConcurrentDictionary<string, CustomLogger>();

        public CustomLoggerProvider(CustomLoggerConfiguration config) => _config = config;

        public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _config));

        public void Dispose() => _loggers.Clear();
    }

    public class CustomLoggerConfiguration
    {
        public int EventId { get; set; }
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public LoggerType LoggerType { get; set; }
    }

    public enum LoggerType
    {
        ElasticSearch = 1,
        Files = 2,
        Database = 3
    }

    public class CustomLoggerEvents
    {
        public const int CreateItem = 201;
        public const int ReadItem = 200;
        public const int UpdateItem = 1004;
        public const int DeleteItem = 1005;
        public const int ListItems = 1001;
        // -----------
        public const int ResourceNotFound = 404;
        public const int Error = 500;
    }
}
