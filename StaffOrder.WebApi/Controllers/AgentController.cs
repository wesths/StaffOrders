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
        public GetATBforStaffMemberResponse GetATB([FromBody]GetATBforStaffMemberRequest request)
        {
            var result = _agentService.GetATBforStaffMember(request);
            return result;
        }

        [HttpPost]
        [Route("GetPersonalDetails")]
        public GetPersonalDetailsResponse GetPersonalDetails([FromBody]GetPersonalDetailsRequest request)
        {
            var result = _agentService.GetPersonalDetails(request);
            return result;

        }

        [HttpPost]
        [Route("GetStaffOrdersForStaffMember")]
        public GetListStaffOrdersForStaffMemberResponse GetStaffOrdersForStaffMember([FromBody]GetStaffOrdersForStaffMemberRequest request)
        {
            var result = _agentService.GetStaffOrdersForStaffMember(request);
            return result;
        }

        [HttpPost]
        [Route("GetStock")]
        public GetStockResponse GetStock([FromBody]GetStockRequest request)
        {
            var result = _agentService.GetStock(request);
            return result;

        }

        [HttpPost]
        [Route("SaveOrder")]
        public void SaveOrder([FromBody]SaveOrderRequest request)
        {
            _agentService.SaveOrder(request);
        }

        [HttpPost]
        [Route("SavePersonalDetails")]
        public void SavePersonalDetails([FromBody]SavePersonalDetails request)
        {
            _agentService.SavePersonalDetails(request);
        }

        [HttpPost]
        [Route("SaveOrderContactDetails")]
        public void SaveOrderContactDetails([FromBody]SaveOrderContactDetailsRequest request)
        {
            _agentService.SaveOrderContactDetails(request);
        }
    }
}