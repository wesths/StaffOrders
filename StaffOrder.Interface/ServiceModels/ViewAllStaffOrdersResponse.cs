﻿using System.Collections.Generic;

namespace StaffOrder.Interface.ServiceModels
{
    public class ViewAllStaffOrdersResponse
    {
        List<Order> Orders { get; set; }
    }
}