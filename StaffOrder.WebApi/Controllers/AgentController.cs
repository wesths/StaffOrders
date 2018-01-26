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
    }
}