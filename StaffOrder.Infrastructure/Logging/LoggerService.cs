using Newtonsoft.Json;
using NLog;
using StaffOrder.Infrastructure.Tracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaffOrder.Infrastructure.Logging
{
    public class LoggerService : ILoggerService
    {
        private ILogger _logger;
        private ITrackingService _trackingService;

        public LoggerService(ITrackingService trackingService)
        {
            _logger = LogManager.GetLogger(this.GetType().FullName);
            _trackingService = trackingService;
        }
        /// <summary>
        /// Log debug information
        /// </summary>
        /// <param name="debug"></param>
        /// <param name="objects">objects to format into debug message</param>
        public void LogDebug(string debug, params object[] objects)
        {
            var message = FormatMessage(debug, objects);
            var args = GetLogArguments();

            _logger.Debug(message, args);
        }

        /// <summary>
        /// Log general information
        /// </summary>
        /// <param name="info"></param>
        /// <param name="objects">objects to format into info message</param>
        public void LogInformation(string info, params object[] objects)
        {
            var message = FormatMessage(info, objects);
            var args = GetLogArguments();

            _logger.Info(message, args);
        }

        /// <summary>
        /// Log an error
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="error"></param>
        /// <param name="objects">objects to format into error message</param>
        public void LogError(Exception ex, string error, params object[] objects)
        {
            var message = FormatMessage(error, objects);
            var args = GetLogArguments();

            _logger.Error(ex, error, args);
        }

        /// <summary>
        /// Get all the arguments that we want to send to our log provider
        /// </summary>
        /// <returns></returns>
        private object[] GetLogArguments()
        {
            var resultList = new List<object>();

            var trackingId = _trackingService.GetTrackingIdForContext();

            resultList.Add(new { TrackingId = trackingId });

            //How to add extra fields
            //resultList.Add(new { TrackingId = trackingId, Test1 = "Hi MOM" });

            return resultList.ToArray();
        }

        /// <summary>
        /// Formats the `message` with extra objects supplied
        /// </summary>
        /// <param name="message">Format of the message</param>
        /// <param name="objects">Actual values for formatting</param>
        /// <returns></returns>
        private string FormatMessage(string message, params object[] objects)
        {
            if (objects.Length == 0)
            {
                return message;
            }

            var jsonObjects = objects.Select(obj => JsonConvert.SerializeObject(obj)).ToArray();
            message = string.Format(message + "{0}", jsonObjects).Replace("{", "{{").Replace("}", "}}");
            return message;
        }
    }
}
