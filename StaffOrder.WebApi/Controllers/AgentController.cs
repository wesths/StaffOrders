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
    [Route("api/Agent")]
    public class AgentController : Controller
    {
        private IAgentService _agentService;
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpPost]
        [Route("GetATB")]
        public GetATBforStaffMemberResponse GetATB(GetATBforStaffMemberRequest request)
        {
            var result = _agentService.GetATBforStaffMember(request);
            return result;
        }

        [HttpPost]
        [Route("GetPersonalDetails")]
        public GetPersonalDetailsResponse GetPersonalDetails(GetPersonalDetailsRequest request)
        {
            var result = _agentService.GetPersonalDetails(request);
            return result;

        }

        [HttpPost]
        [Route("GetStaffOrdersForStaffMember")]
        public GetListStaffOrdersForStaffMemberResponse GetStaffOrdersForStaffMember(GetStaffOrdersForStaffMemberRequest request)
        {
            var result = _agentService.GetStaffOrdersForStaffMember(request);
            return result;
        }

        [HttpPost]
        [Route("GetStock")]
        public GetStockResponse GetStock(GetStockRequest request)
        {
            var result = _agentService.GetStock(request);
            return result;

        }

        [HttpPost]
        [Route("SaveOrder")]
        public void SaveOrder(SaveOrderRequest request)
        {
            _agentService.SaveOrder(request);
        }

        [HttpPost]
        [Route("SavePersonalDetails")]
        public void SavePersonalDetails(SavePersonalDetails request)
        {
            _agentService.SavePersonalDetails(request);
        }
    }
}