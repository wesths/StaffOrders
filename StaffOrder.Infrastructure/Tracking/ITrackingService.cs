using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Infrastructure.Tracking
{
    public interface ITrackingService
    {
        string GetTrackingIdHeaderFieldName();

        string GetTrackingIdForContext();

        void AddTrackingIdToContext(HttpContext context);

    }
}
