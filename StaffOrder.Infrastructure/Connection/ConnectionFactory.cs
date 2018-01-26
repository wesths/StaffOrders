using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StaffOrder.Infrastructure.Connection
{
    public class ConnectionFactory : IConnectionFactory
    {
        public SqlConnection GetNewSqlConnectionWithLoginDetails(SqlConnection oldConnection, string newUserName, string newPassword)
        {
            return oldConnection;
            
        }
    }
    
}
