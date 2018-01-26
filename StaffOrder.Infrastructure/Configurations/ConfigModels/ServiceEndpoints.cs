using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Infrastructure.Configurations.ConfigModels
{
    public class ServicesEndpoints
    {
        public Dictionary<string, ServiceAttributes> Services { get; set; } // Dictionaries must have string keys
    }

    public partial class ServiceAttributes
    {
        public string Url { get; set; }
    }
}
