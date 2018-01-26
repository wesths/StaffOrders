using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Infrastructure.DomainExceptions.HttpResponse
{
    public static class HttpErrorResponse
    {
        public static string GetHttpErrorResponse(Exception exception)
        {
            //if we can to do something special for a domainexception do it here
            var httpDomainErrorResponse = new HttpDomainErrorResponse();
            httpDomainErrorResponse.Error = new Error() { ErrorMessage = exception.Message };

            var jsonResponse = JsonConvert.SerializeObject(httpDomainErrorResponse);

            return jsonResponse;
        }
    }
}
