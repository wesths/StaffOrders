using System;
using System.Collections.Generic;

namespace StaffOrder.Interface.ServiceModels
{
    public class GetListStaffOrdersForStaffMemberResponse
    {
        public IEnumerable<GetStaffOrdersForStaffMemberResponse> Responses { get; set; }

    }

    public class GetStaffOrdersForStaffMemberResponse
    {
        public string OrderDate { get; set; }
        public int OrderId { get; set; }
        public string EmployeeNo { get; set; }
        public int OrderCode { get; set; }
        public string Mailing { get; set; }
        public string Month { get; set; }
        public int page { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int StatusID { get; set; }
        public string Dept { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string ExtNo { get; set; }

    }
}