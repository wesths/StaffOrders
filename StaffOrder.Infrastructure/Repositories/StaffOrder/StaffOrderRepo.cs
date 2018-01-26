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

namespace StaffOrder.Infrastructure.Repositories.StaffOrder
{
    public class StaffOrderRepo : IStaffOrderRepo
    {
        private IConnectionFactory _connectionFactory;
        private IConfigService _configService;
        private string connection;
        public StaffOrderRepo(IConnectionFactory connectionFactory, IConfigService configService)
        {
            _configService = configService;
            _connectionFactory = connectionFactory;
            connection = configService.GetSQLConnectionString();
        }

        public StaffMember GetStaffMember(string firstName, string lastName)
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = "select FirstName, " +
                "LastName, " +
                "EmpNo, " +
                "Dept," +
                "ContactNo, " +
                "ExtNo " +
                " from stoStaff " +
                "where FirstName = @FirstName " +
                "and LastName = @LastName";

            DynamicParameters param = new DynamicParameters();

            param.Add("@FirstName", firstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LastName", lastName, dbType: DbType.String, direction: ParameterDirection.Input);

            Domain.StaffMember staffMember = conn.Query<Domain.StaffMember>(sqlStr, param, commandType: CommandType.Text).SingleOrDefault();

            return staffMember;
        }

        public StaffMember GetStaffMember(string empNo)
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = "select FirstName, " +
                "LastName, " +
                "EmpNo, " +
                "Dept," +
                "ContactNo, " +
                "ExtNo " +
                " from stoStaff " +
                "where EmpNo = @EmpNo ";

            DynamicParameters param = new DynamicParameters();

            param.Add("@EmpNo", empNo, dbType: DbType.String, direction: ParameterDirection.Input);            

            Domain.StaffMember staffMember = conn.Query<Domain.StaffMember>(sqlStr, param, commandType: CommandType.Text).SingleOrDefault();

            return staffMember;
        }
    }
}
