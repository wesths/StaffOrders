using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Infrastructure.DomainExceptions.HttpResponse
{
    public class HttpDomainErrorResponse
    {
        public Error Error { get; set; }
    }

    public class Error
    {
        public string ErrorMessage { get; set; }
    }
}
