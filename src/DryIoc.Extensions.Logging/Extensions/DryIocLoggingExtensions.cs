using Microsoft.Extensions.Logging;

namespace DryIoc.Extensions.Logging
{
    /// <summary>
    /// Dry IoC logging extensions
    /// </summary>
    public static class DryIocLoggingExtensions
    {
        
        /// <summary>
        /// Register any logger factory with <see cref="ILogger{TCategoryName}"/> adapter.
        /// </summary>
        /// <param name="registrator">Instance of <see cref="IRegistrator"/></param>
        /// <param name="loggerFactory">Logger factory</param>
        /// <returns></returns>
        public static IRegistrator RegisterLoggerFactory(this IRegistrator registrator, ILoggerFactory loggerFactory)
        {
            registrator.RegisterInstance(loggerFactory);
            registrator.Register(typeof(ILogger<>), typeof(LoggingAdapter<>));
            return registrator;
        }
    }
}