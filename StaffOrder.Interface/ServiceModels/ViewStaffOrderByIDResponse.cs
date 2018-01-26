using System.Collections.Generic;

namespace StaffOrder.Interface.ServiceModels
{
    public class ViewStaffOrderByIDResponse
    {
        List<Order> Orders { get; set; }
    }
}