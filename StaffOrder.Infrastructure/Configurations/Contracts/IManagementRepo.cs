using System;
using System.Collections.Generic;
using System.Text;
using StaffOrder.Domain.Management;

namespace StaffOrder.Infrastructure.Configurations.Contracts
{
    public interface IManagementRepo
    {
        List<Order> ViewAllOrders();
        Order ViewOrderByID(int orderID);
        List<Order> ViewOrdersByStatus(int status);
        void ProcessOrder(int orderID, int status);
    }
}
