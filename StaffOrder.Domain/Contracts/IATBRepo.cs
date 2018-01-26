using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Domain.Contracts
{
    public interface IATBRepo
    {
        ATB GetATB(string empNo);
    }
}
