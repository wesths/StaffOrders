using StaffOrder.Domain.Contracts;
using StaffOrder.Interface.Contracts;
using StaffOrder.Interface.ServiceModels;
using StaffOrder.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Service
{
    public class AgentService : IAgentService
    {
        private IATBRepo _atbRepo;
        private IStaffOrderRepo _staffOrderRepo;
        IStockRepo _stockRepo;
        public AgentService(IATBRepo atbRepo, IStaffOrderRepo staffOrderRepo, IStockRepo stockRepo)
        {
            _atbRepo = atbRepo;
            _staffOrderRepo = staffOrderRepo;
            _stockRepo = stockRepo;
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
            else if (request.EmpNo != null)
            {
                staffMember = _staffOrderRepo.GetStaffMemberEmpNo(request.EmpNo);
            }
            else
            {
                staffMember = _staffOrderRepo.GetStaffMember(request.Username);
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

        public GetListStaffOrdersForStaffMemberResponse GetStaffOrdersForStaffMember(GetStaffOrdersForStaffMemberRequest request)
        {
            var orders = _staffOrderRepo.GetOrdersForStaffMember(request.EmpNo);

            List<GetStaffOrdersForStaffMemberResponse> list = new List<GetStaffOrdersForStaffMemberResponse>();

            foreach(var item in orders)
            {
                var contactDetails = _staffOrderRepo.GetOrderContactDetails(item.OrderId);

                list.Add(new GetStaffOrdersForStaffMemberResponse()
                {
                    OrderId = item.OrderId,
                    Dept = item.Dept,
                    Description = item.Description,
                    EmployeeNo = item.EmployeeNo,
                    Mailing = item.Mailing,
                    Month = item.Month,
                    OrderDate = item.OrderDate,
                    page = item.page,
                    OrderCode = item.OrdCode,
                    Price = item.Price,
                    Size = item.Size,
                    StatusID = item.StatusID,
                    ContactName = contactDetails.ContactName,
                    ContactNo = contactDetails.ContactNo,
                    ExtNo = contactDetails.ExtNo
                });
            }

            GetListStaffOrdersForStaffMemberResponse response = new GetListStaffOrdersForStaffMemberResponse()
            {
                Responses = list
            };

            return response;
        }

        public GetStockResponse GetStock(GetStockRequest request)
        {
            var stock = _stockRepo.GetStock(request.ItemNo);

            GetStockResponse response = new GetStockResponse()
            {
                ItemNo = stock.ItemNo,
                AXCategory = stock.AXCategory,
                AXClass = stock.AXClass,
                AXSubCategory = stock.AXSubCategory,
                CashPrice = stock.CashPrice,
                Colour = stock.Colour,
                OrdCode = stock.OrdCode,
                OrdCodeDescrip = stock.OrdCodeDescrip,
                Page = stock.Page,
                Pattern = stock.Pattern,
                QtyAvail = stock.QtyAvail,
                SequenceNo = stock.SequenceNo,
                Size = stock.Size,
                Variation = stock.Variation
                 
            };

            return response;
        }

        public void SaveOrder(SaveOrderRequest request)
        {
            var staff = _staffOrderRepo.GetStaffMember(request.EmployeeNo);

            if (staff == null)
            {
                throw new StaffException("Staff Member does not have an employee number. Please capture it.");
            }
            

            Domain.Order order = new Domain.Order()
            {
                Dept = request.Dept,
                OrderDate = DateTime.Now,
                Description = request.Description,
                EmployeeNo = request.EmployeeNo,
                ItemNo = request.ItemNo,
                Mailing = request.Mailing,
                Month = request.Month,
                OrdCode = request.OrdCode,
                page = request.page,
                Price = request.Price,
                Size = request.Size,
                StatusID = 1
            };

            var stock = _stockRepo.GetStock(order.ItemNo);

            if (stock == null)
            {
                throw new StaffException("Item not available.");
            }

            if (stock.QtyAvail > 0)
            {
                _staffOrderRepo.SaveOrder(order);
            }
            else
            {
                throw new StaffException("Not enough stock for this order.");
            }

        }

        public void SaveOrderContactDetails(SaveOrderContactDetailsRequest request)
        {
            throw new NotImplementedException();
        }

        public void SavePersonalDetails(SavePersonalDetails request)
        {
            Domain.StaffMember staffMember = new Domain.StaffMember()
            {
                ContactNo = request.ContactNo,
                Department = request.Department,
                EmpNo = request.EmpNo,
                ExtNo = request.ExtNo,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };

            _staffOrderRepo.SavePersonalDetails(staffMember);
        }
    }
}
