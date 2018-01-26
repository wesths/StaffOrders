using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Domain.Contracts
{
    public interface IStaffOrderRepo
    {
        StaffMember GetStaffMember(string firstName, string lastName);
        StaffMember GetStaffMember(string empNo);
    }
}
