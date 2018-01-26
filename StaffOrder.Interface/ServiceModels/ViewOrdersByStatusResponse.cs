using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Interface.ServiceModels
{
    public class ViewOrdersByStatusResponse
    {
        public List<Order> Orders { get; set; }
    }
}
