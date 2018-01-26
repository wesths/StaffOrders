using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StaffOrder.Infrastructure.Connection
{
    public interface IConnectionFactory
    {
        SqlConnection GetNewSqlConnectionWithLoginDetails(SqlConnection oldConnection, string newUserName, string newPassword);
    }
}
