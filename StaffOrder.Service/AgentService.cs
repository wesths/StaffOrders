using StaffOrder.Domain.Contracts;
using StaffOrder.Interface.Contracts;
using StaffOrder.Interface.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Service
{
    public class AgentService : IAgentService
    {
        private IATBRepo _atbRepo;
        private IStaffOrderRepo _staffOrderRepo;
        public AgentService(IATBRepo atbRepo, IStaffOrderRepo staffOrderRepo)
        {
            _atbRepo = atbRepo;
            _staffOrderRepo = staffOrderRepo;
        }
        public GetATBforStaffMemberResponse GetATBforStaffMember(GetATBforStaffMemberRequest request)
        {
            var atb = _atbRepo.GetATB(request.EmpNo);

            GetATBforStaffMemberResponse response = new GetATBforStaffMemberResponse()
            {
                CreditLimit = atb.CreditLimit,
                EmpNo = atb.EmpNo,
                Name = atb.Name,
                OutstandingBalance = atb.OutstandingBalance,
                Status = atb.Status
            };
            return response;
        }

        public GetPersonalDetailsResponse GetPersonalDetails(GetPersonalDetailsRequest request)
        {
            Domain.StaffMember staffMember;
            if ((request.FirstName != null) && (request.LastName != null))
            {
                staffMember = _staffOrderRepo.GetStaffMember(request.FirstName, request.LastName);
            }
            else
            {
                staffMember = _staffOrderRepo.GetStaffMember(request.EmpNo);
            }

            GetPersonalDetailsResponse response = new GetPersonalDetailsResponse()
            {
                EmpNo = staffMember.EmpNo,
                ContactNo = staffMember.ContactNo,
                LastName = staffMember.LastName,
                FirstName = staffMember.FirstName,
                Department = staffMember.Department,
                ExtNo = staffMember.ExtNo
            };

            return response;
            
        }

        public GetStaffOrdersForStaffMemberResponse GetStaffOrdersForStaffMember(GetStaffOrdersForStaffMemberRequest request)
        {
            throw new NotImplementedException();
        }

        public GetStockResponse GetStock(GetStockRequest request)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(SaveOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public void SaveOrderContactDetails(SaveOrderContactDetailsRequest request)
        {
            throw new NotImplementedException();
        }

        public void SavePersonalDetails(SavePersonalDetails request)
        {
            throw new NotImplementedException();
        }
    }
}
