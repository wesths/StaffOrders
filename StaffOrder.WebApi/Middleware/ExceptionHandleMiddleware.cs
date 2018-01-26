using Microsoft.AspNetCore.Http;
using StaffOrder.Infrastructure.DomainExceptions;
using StaffOrder.Infrastructure.DomainExceptions.HttpResponse;
using StaffOrder.Infrastructure.Logging;
using StaffOrder.Infrastructure.Tracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StaffOrder.WebApi.Middleware
{
    public class ExceptionHandleMiddleware
    {
        private readonly ILoggerService _logger;
        private readonly ITrackingService _trackingService;
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(
      RequestDelegate next,
      ILoggerService logger,
      ITrackingService trackingService)
        {
            _next = next;
            _logger = logger;
            _trackingService = trackingService;
        }

        /// <summary>
        /// Will catch all exceptions in application
        /// Will add tracking Id to the HttpContext for future use
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                _trackingService.AddTrackingIdToContext(context);
                // bind the user to the header for scrope

                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        //TODO remove a the logMessage set, logger service might be a good candidate
        /// <summary>
        /// Handles all exceptions in application
        /// </summary>
        /// <param name="context">The HttpContext for the request</param>
        /// <param name="exception">The exception that was thrown</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _trackingService.AddTrackingIdToContext(context);
            var logMessage = "An unhandled exception has occurred: " + exception.Message;
            var code = (int)HttpStatusCode.InternalServerError;

            var result = HttpErrorResponse.GetHttpErrorResponse(exception);

            if (exception is ReplayDomainException)
            {
                logMessage = "A replay domain validation exception has occurred: " + exception.Message;
                code = DomainException.HttpErrorCode;
            }
            else if (exception is DomainException)
            {
                logMessage = "A domain validation exception has occurred: " + exception.Message;
                code = DomainException.HttpErrorCode;
            }

            _logger.LogError(exception, logMessage);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(result);
        }
    }
}
