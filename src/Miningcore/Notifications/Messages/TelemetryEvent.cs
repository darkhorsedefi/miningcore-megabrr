using System;
using System.Collections.Generic;
using System.Text;

namespace Miningcore.Notifications.Messages
{
    public enum TelemetryCategory
    {
        /// <summary>
        /// Share processed
        /// </summary>
        Share = 1,

        /// <summary>
        /// Blocktemplate over BTStream received
        /// </summary>
        BtStream,

        /// <summary>
        /// JsonRPC Request to Daemon
        /// </summary>
        RpcRequest,

        /// <summary>
        /// Number of TCP connections to a pool
        /// </summary>
        Connections,

        /// <summary>
        /// Hash computation time
        /// </summary>
        Hash,
    }

    public record TelemetryEvent
    {
        public TelemetryEvent(string poolId, TelemetryCategory category, TimeSpan elapsed, bool? success = null, string error = null)
        {
            PoolId = poolId;
            Category = category;
            Elapsed = elapsed;
            Success = success;
            Error = error;
        }

        public TelemetryEvent(string poolId, TelemetryCategory category, string info, TimeSpan elapsed, bool? success = null, string error = null) :
            this(poolId, category, elapsed, success, error)
        {
            Info = info;
        }

        public string PoolId { get; }
        public TelemetryCategory Category { get; }
        public string Info { get; }
        public TimeSpan Elapsed { get; }
        public bool? Success { get; }
        public string Error { get; }
        public int Total { get; set; }
    }
}
