using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffOrder.Interface.Contracts;
using StaffOrder.Interface.ServiceModels;

namespace StaffOrder.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [Route("ProcessStaffOrder")]
        public void ProcessStaffOrder(ProcessStaffOrderRequest request)
        {
            _adminService.ProcessStaffOrder(request);
        }

        [HttpPost]
        [Route("ViewAllStaffOrders")]
        public ViewAllStaffOrdersResponse ViewAllStaffOrders(ViewAllStaffOrdersRequest request)
        {
            return _adminService.ViewAllStaffOrders(request);
        }

        [HttpPost]
        [Route("ViewStaffOrderByID")]
        public ViewStaffOrderByIDResponse ViewStaffOrderByID(ViewStaffOrderByIDRequest request)
        {
            return _adminService.ViewStaffOrderByID(request);
        }

        //TODO: Rename
        [HttpPost]
        [Route("ViewOrdersByStatus")]
        public ViewOrdersByStatusResponse ViewOrdersByStatus(ViewOrdersByStatusRequest request)
        {
            return _adminService.ViewOrdersByStatus(request);
        }

    }
}