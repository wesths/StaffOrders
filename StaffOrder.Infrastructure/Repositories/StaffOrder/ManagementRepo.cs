using Dapper;
using StaffOrder.Domain.Management;
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
    public class ManagementRepo : IManagementRepo
    {
        private IConnectionFactory _connectionFactory;
        private IConfigService _configService;
        private string connection;
        public ManagementRepo(IConnectionFactory connectionFactory, IConfigService configService)
        {
            _configService = configService;
            _connectionFactory = connectionFactory;
            connection = configService.GetSQLConnectionString();
        }

        public void ProcessOrder(int orderID, int status)
        {

            //TODO:

            //using (IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection)))
            //{
            //    var procedure = "insert into stoStaffOrderStatus values (@ )";

            //    var parameters = new DynamicParameters();
            //    parameters.Add("PersonNo", correspondence.personNo);
            //    parameters.Add("CompNo", 1);
            //    parameters.Add("DocCode", correspondence.docCode);
            //    parameters.Add("FreeText", string.Empty);

            //    conn.Execute(procedure, parameters, null, null, CommandType.StoredProcedure);
            //}
        }

        public List<Order> ViewAllOrders()
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = @"SELECT [staffOrdNo] as OrderID
                          ,[EmpNo] as EmployeeNo
                          ,[OrdCode]
                          ,[ItemNo]
                          ,[ItemDepartment] as Dept
                          ,[Mailing]
                          ,[Month]
                          ,[Page]
                          ,[ItemDesciption] as Description
                          ,[Size]
                          ,[Price]
                          ,[OrdDate] as OrderDate
                        FROM[Omega].[dbo].[StoStaffOrder]";

            List<Order> orders = conn.Query<Order>(sqlStr, null, commandType: CommandType.Text).ToList();
            return orders;
        }

        public List<Order> ViewOrdersByStatus(int status)
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);
            
            //TODO: Refactor Status Get  
            //
            var sqlStr = @"SSELECT [staffOrdNo] as OrderID
                          ,[EmpNo] as EmployeeNo
                          ,[OrdCode]
                          ,[ItemNo]
                          ,[ItemDepartment] as Dept
                          ,[Mailing]
                          ,[Month]
                          ,[Page]
                          ,[ItemDesciption] as Description
                          ,[Size]
                          ,[Price]
                          ,[OrdDate] as OrderDate
                        FROM[Omega].[dbo].[StoStaffOrder]
            WHERE StatusID = @StatusID";
            DynamicParameters param = new DynamicParameters();

            param.Add("@StatusID", status, dbType: DbType.Int32, direction: ParameterDirection.Input);

            List<Order> orders = conn.Query<Order>(sqlStr, param, commandType: CommandType.Text).ToList();
            return orders;
        }

        Order IManagementRepo.ViewOrderByID(int orderID)
        {
            //TODO: Add Contact Details and status
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = @"SELECT [staffOrdNo] as OrderID
                          ,[EmpNo] as EmployeeNo
                          ,[OrdCode]
                          ,[ItemNo]
                          ,[ItemDepartment] as Dept
                          ,[Mailing]
                          ,[Month]
                          ,[Page]
                          ,[ItemDesciption] as Description
                          ,[Size]
                          ,[Price]
                          ,[OrdDate] as OrderDate
                        FROM[Omega].[dbo].[StoStaffOrder]
            where staffOrdNo = @OrderID";
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrderNo", orderID, dbType: DbType.String, direction: ParameterDirection.Input);

            Order order = conn.Query<Order>(sqlStr, param, commandType: CommandType.Text).FirstOrDefault();

            return order;

        }
    }
}
