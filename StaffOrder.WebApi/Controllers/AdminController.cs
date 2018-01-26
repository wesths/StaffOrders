using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffOrder.Interface.ServiceModels;

namespace StaffOrder.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        public AdminController()
        {

        }
        [Route("ProcessStaffOrder")]
        public ProcessStaffOrderResponse ProcessStaffOrder(ProcessStaffOrderRequest request)
        {
            throw new NotImplementedException();
        }
        [Route("ViewAllStaffOrders")]
        public ViewAllStaffOrdersResponse ViewAllStaffOrders(ViewAllStaffOrdersRequest request)
        {
            throw new NotImplementedException();
        }

    }
}