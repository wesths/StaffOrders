using StaffOrder.Domain.Contracts;
using StaffOrder.Interface.Contracts;
using StaffOrder.Interface.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Service
{
    public class AdminService : IAdminService
    {
        private IManagementRepo _managementRepo;

        public AdminService(IManagementRepo managementRepo)
        {
            _managementRepo = managementRepo;
        }

        public void ProcessStaffOrder(ProcessStaffOrderRequest request)
        {
            _managementRepo.ProcessOrder(request.OrderId, request.StatusId);
        }

        public ViewAllStaffOrdersResponse ViewAllStaffOrders(ViewAllStaffOrdersRequest request)
        {
            var staffOrders = _managementRepo.ViewAllOrders();
            List<Order> orders = new List<Order>();
            foreach (var order in staffOrders)
            {
                orders.Add(new Order()
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    EmployeeNo = order.EmployeeNo,
                    OrdCode = order.OrdCode,
                    ItemNo = order.ItemNo,
                    Mailing = order.Mailing,
                    Month = order.Month,
                    Page = order.page,
                    Description = order.Description,
                    Size = order.Size,
                    Price = order.Price,
                    Dept = order.Dept,
                    StatusID = order.StatusID
                });
            }

            ViewAllStaffOrdersResponse response = new ViewAllStaffOrdersResponse()
            {
                Orders = orders
            };

            return response;
        }

        public ViewStaffOrderByIDResponse ViewStaffOrderByID(ViewStaffOrderByIDRequest request)
        {
            var order = _managementRepo.ViewOrderByID(request.OrderId);
            ViewStaffOrderByIDResponse response = new ViewStaffOrderByIDResponse()
            {
                Order = new Order()
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    EmployeeNo = order.EmployeeNo,
                    OrdCode = order.OrdCode,
                    ItemNo = order.ItemNo,
                    Mailing = order.Mailing,
                    Month = order.Month,
                    Page = order.page,
                    Description = order.Description,
                    Size = order.Size,
                    Price = order.Price,
                    Dept = order.Dept,
                    StatusID = order.StatusID
                }
            };
            return response;
        }

        public ViewOrdersByStatusResponse ViewOrdersByStatus(ViewOrdersByStatusRequest request)
        {
            var staffOrders = _managementRepo.ViewOrdersByStatus(request.StatusId);
            List<Order> orders = new List<Order>();
            foreach (var order in staffOrders)
            {
                orders.Add(new Order()
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    EmployeeNo = order.EmployeeNo,
                    OrdCode = order.OrdCode,
                    ItemNo = order.ItemNo,
                    Mailing = order.Mailing,
                    Month = order.Month,
                    Page = order.page,
                    Description = order.Description,
                    Size = order.Size,
                    Price = order.Price,
                    Dept = order.Dept,
                    StatusID = order.StatusID
                });
            }

            ViewOrdersByStatusResponse response = new ViewOrdersByStatusResponse()
            {
                Orders = orders
            };

            return response;
        }
    }
}
