using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Infrastructure.Logging
{
    public interface ILoggerService
    {
        void LogDebug(string debug, params object[] objects);

        void LogInformation(string info, params object[] objects);

        void LogError(Exception ex, string message, params object[] objects);
    }
}
