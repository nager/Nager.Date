using AspNetCoreRateLimit;

namespace Nager.Date.IntegrationTests
{
    internal class TestableAppSettings
    {
        internal class DefaultLogging
        {
            public Microsoft.Extensions.Logging.LogLevel Default { get; set; } = Microsoft.Extensions.Logging.LogLevel.Debug;
        }
        internal class LoggingInfo
        {
            public DefaultLogging LogLevel { get; set; } = new DefaultLogging();
        }
        public LoggingInfo Logging { get; set; } = new LoggingInfo();
        public string AllowedHosts { get; set; } = "*";
        public bool? EnableIpRateLimiting { get; set; }
        public bool? EnableCors { get; set; }
        public bool? EnableSwaggerMode { get; set; }
        public IpRateLimitOptions IpRateLimiting { get; set; }
    }
}
