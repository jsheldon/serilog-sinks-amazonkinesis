using System;
using Serilog.Events;
using Serilog.Formatting;

namespace Serilog.Sinks.Amazon.Kinesis.Common
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KinesisSinkOptionsBase : ILogShipperOptions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamName"></param>
        protected KinesisSinkOptionsBase(string streamName)
        {
            if (streamName == null) throw new ArgumentNullException("streamName");

            StreamName = streamName;
            Period = DefaultPeriod;
            BatchPostingLimit = DefaultBatchPostingLimit;
        }

        /// <summary>
        /// Optional path to directory that can be used as a log shipping buffer for increasing the reliabilty of the log forwarding.
        /// </summary>
        public string BufferBaseFilename { get; set; }

        /// <summary>
        /// The default time to wait between checking for event batches. Defaults to 2 seconds.
        /// </summary>
        public static readonly TimeSpan DefaultPeriod = TimeSpan.FromSeconds(2);

        /// <summary>
        /// The default maximum number of events to post in a single batch. Defaults to 500.
        /// </summary>
        public static readonly int DefaultBatchPostingLimit = 500;

        /// <summary>
        /// The default stream name to use for the log events.
        /// </summary>
        public string StreamName { get; set; }

        /// <summary>
        /// The maximum number of events to post in a single batch. Defaults to 500.
        /// </summary>
        public int BatchPostingLimit { get; set; }

        /// <summary>
        /// The time to wait between sending event batches.
        /// </summary>
        public TimeSpan Period { get; set; }

        /// <summary>
        /// Supplies culture-specific formatting information, or null.
        /// </summary>
        public IFormatProvider FormatProvider { get; set; }

        /// <summary>
        /// The minimum log event level required in order to write an event to the sink.
        /// </summary>
        public LogEventLevel? MinimumLogEventLevel { get; set; }

        /// <summary>
        /// The maximum size, in bytes, to which the buffer log file for a specific date will be allowed to grow. 
        /// By default no limit will be applied.
        /// </summary>
        public long? BufferFileSizeLimitBytes { get; set; }

        /// <summary>
        /// Customizes the formatter used when converting the log events into the durable sink. 
        /// Please note that the formatter output must be valid JSON.
        /// </summary>
        public ITextFormatter CustomDurableFormatter { get; set; }

        /// <summary>
        /// An eventhandler which will be invoked whenever there is an error in log sending.
        /// </summary>
        public EventHandler<LogSendErrorEventArgs> OnLogSendError { get; set; }

        /// <summary>
        /// Allow the log files to be shared by multiple processes. The default is false.
        /// </summary>
        public bool Shared { get; set; }
    }
}