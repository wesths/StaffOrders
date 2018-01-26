using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Infrastructure.Configurations.ConfigModels
{
    public class ConnectionStrings
    {
        public string OmegaConnection { get; set; }
        public string MySQLConnection { get; set; }
        public int Timeout { get; set; }
    }
}
