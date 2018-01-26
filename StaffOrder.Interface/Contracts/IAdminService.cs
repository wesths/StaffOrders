using StaffOrder.Interface.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Interface.Contracts
{
    public interface IAdminService
    {
        ViewAllStaffOrdersResponse ViewAllStaffOrders(ViewAllStaffOrdersRequest request);
        void ProcessStaffOrder(ProcessStaffOrderRequest request);
        ViewOrdersByStatusResponse ViewOrdersByStatus(ViewOrdersByStatusRequest request);
        ViewStaffOrderByIDResponse ViewStaffOrderByID(ViewStaffOrderByIDRequest request);
    }
}
