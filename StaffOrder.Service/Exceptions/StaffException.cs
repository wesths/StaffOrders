using StaffOrder.Infrastructure.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Service.Exceptions
{
    public class StaffException : DomainException
    {
        public StaffException(string message) : base(message)
        {
        }
    }
}
