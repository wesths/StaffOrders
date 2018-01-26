using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Domain
{
    public class OrderContact
    {
        public int OrderId{ get; set; }
        public string  ContactName { get; set; }
        public string ContactNo { get; set; }
        public string ExtNo { get; set; }
    }
}
