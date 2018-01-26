﻿using StaffOrder.Interface.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Interface.Contracts
{
    public interface IAdminService
    {
        ViewAllStaffOrdersResponse ViewAllStaffOrders(ViewAllStaffOrdersRequest request);
        ProcessStaffOrderResponse ProcessStaffOrder(ProcessStaffOrderRequest request);
    }
}