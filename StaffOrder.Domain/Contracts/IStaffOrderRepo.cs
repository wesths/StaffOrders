using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Domain.Contracts
{
    public interface IStaffOrderRepo
    {
        StaffMember GetStaffMember(string firstName, string lastName);
        StaffMember GetStaffMemberEmpNo(string empNo);
        StaffMember GetStaffMember(string userName);
        List<Order> GetOrdersForStaffMember(string empNo);
        OrderContact GetOrderContactDetails(int ordId);
        void SaveOrder(Order order);
        void SavePersonalDetails(StaffMember staffMember);
        void SaveOrderContactDetails(OrderContact orderContact);
    }
}
