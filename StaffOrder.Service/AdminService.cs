using StaffOrder.Interface.Contracts;
using StaffOrder.Interface.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Service
{
    public class AdminService : IAdminService
    {
        public ProcessStaffOrderResponse ProcessStaffOrder(ProcessStaffOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public ViewAllStaffOrdersResponse ViewAllStaffOrders(ViewAllStaffOrdersRequest request)
        {
            throw new NotImplementedException();
        }

        public ViewOrderByIDResponse ViewOrderByID(ViewOrderByIDRequest request)
        {
            throw new NotImplementedException();
        }

        public ViewOrdersByStatusResponse ViewOrdersByStatus(ViewOrdersByStatusRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
