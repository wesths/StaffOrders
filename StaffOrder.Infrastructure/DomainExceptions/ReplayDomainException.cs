using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Infrastructure.DomainExceptions
{
    public class ReplayDomainException : DomainException
    {
        public ReplayDomainException(string message) : base(message)
        {
        }

        public ReplayDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
