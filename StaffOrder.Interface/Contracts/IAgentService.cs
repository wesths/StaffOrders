using StaffOrder.Interface.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Interface.Contracts
{
    public interface IAgentService
    {
        void SaveOrderContactDetails(SaveOrderContactDetailsRequest request);
        void SaveOrder(SaveOrderRequest request);
        void SavePersonalDetails(SavePersonalDetails request);
        GetPersonalDetailsResponse GetPersonalDetails(GetPersonalDetailsRequest request);
        GetStaffOrdersForStaffMemberResponse GetStaffOrdersForStaffMember(GetStaffOrdersForStaffMemberRequest request);
        GetATBforStaffMemberResponse GetATBforStaffMember(GetATBforStaffMemberRequest request);
        GetStockResponse GetStock(GetStockRequest request);

    }
}
