﻿namespace StaffOrder.Interface.ServiceModels
{
    public class GetATBforStaffMemberResponse
    {
        public string EmpNo { get; set; }
        public string Name { get; set; }
        public double OutstandingBalance { get; set; }
        public string Status { get; set; }
        public double CreditLimit { get; set; }
    }
}