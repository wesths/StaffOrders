using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Domain
{
    public class ATB
    {
        public string EmpNo { get; set; }
        public string Name { get; set; }
        public double OutstandingBalance { get; set; }
        public string Status { get; set; }
        public double CreditLimit { get; set; }
    }
}
