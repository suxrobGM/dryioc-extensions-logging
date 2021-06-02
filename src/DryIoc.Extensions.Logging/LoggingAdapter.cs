using System;
using Microsoft.Extensions.Logging;

namespace DryIoc.Extensions.Logging
{
    /// <summary>
    /// Logging adapter.
    /// </summary>
    /// <typeparam name="T">Logger category.</typeparam>
    internal class LoggingAdapter<T> : ILogger<T>
    {
        private readonly ILogger adaptee;          

        public LoggingAdapter(ILoggerFactory factory)
        {
            adaptee = factory.CreateLogger<T>();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return adaptee.BeginScope(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return adaptee.IsEnabled(logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            adaptee.Log(logLevel, eventId, state, exception, formatter);
        }
    }   
}
