using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Domain.Management
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string EmployeeNo { get; set; }
        public int OrdCode { get; set; }
        public int ItemNo { get; set; }
        public string Mailing { get; set; }
        public int Month { get; set; }
        public int Page { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int StatusID { get; set; }
        public string Dept { get; set; }
        
    }
}
