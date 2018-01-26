using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Infrastructure.Configurations.Contracts
{
    public interface IConfigService
    {
        string GetServiceEndPoint(string serviceName);

        string GetMySQLConnectionString();
        string GetSQLConnectionString();
    }
}
