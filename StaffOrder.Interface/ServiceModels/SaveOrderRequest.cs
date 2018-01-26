using System;

namespace StaffOrder.Interface.ServiceModels
{
    public class SaveOrderRequest
    {
        public DateTime OrderDate { get; set; }
        public string EmployeeNo { get; set; }
        public int OrdCode { get; set; }
        public int ItemNo { get; set; }
        public string Mailing { get; set; }
        public string Month { get; set; }
        public int page { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Dept { get; set; }
    }
}