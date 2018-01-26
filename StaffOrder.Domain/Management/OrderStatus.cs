using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Domain.Management
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Desc { get; set; }
    }
}
