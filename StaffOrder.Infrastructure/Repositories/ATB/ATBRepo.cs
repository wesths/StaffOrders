using Dapper;
using StaffOrder.Domain;
using StaffOrder.Domain.Contracts;
using StaffOrder.Infrastructure.Configurations.Contracts;
using StaffOrder.Infrastructure.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StaffOrder.Infrastructure.Repositories.ATB
{
    public class ATBRepo : IATBRepo
    {
        private IConnectionFactory _connectionFactory;
        private readonly IConfigService _configService;
        private string connection;
        public ATBRepo(IConnectionFactory connectionFactory, IConfigService configService)
        {
            _connectionFactory = connectionFactory;
            _configService = configService;
            connection = configService.GetSQLConnectionString();

        }
        public Domain.ATB GetATB(string empNo)
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = "select EmpNo, " +
                "Name, " +
                "OutstandingBalance as OutstandingBalance, " +
                "status," +
                "CreditLimit" +
                " from stoStaffATB " +
                "where EmpNo = @EmpNo";

            DynamicParameters param = new DynamicParameters();

            param.Add("@EmpNo", empNo, dbType: DbType.String, direction: ParameterDirection.Input);

            Domain.ATB atb = conn.Query<Domain.ATB>(sqlStr, param, commandType: CommandType.Text).SingleOrDefault();

            return atb;
        }
    }
}
