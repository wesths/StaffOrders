using System.Collections.Generic;

namespace StaffOrder.Interface.ServiceModels
{
    public class ViewAllStaffOrdersResponse
    {
        public List<Order> Orders { get; set; }
    }
}