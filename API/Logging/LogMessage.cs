using System;

namespace KeenSap.Portal.API.Logging
{
    public class LogMessage
    {
        public DateTimeOffset Timestamp { get; set; }
        public string Message { get; set; }
    }
}