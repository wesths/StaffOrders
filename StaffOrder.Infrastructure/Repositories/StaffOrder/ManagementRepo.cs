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

        public void ProcessOrder(int orderID, int statusId)
        {
            string auditUser = "test";
            using (IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty))
            {
                var procedure = @"INSERT INTO [dbo].[StoStaffOrdStatusTrack]
                  ([staffOrdNo] ,[StaffOrdStatusID],[Auditdte],[AuditUsr])
                VALUES (@staffOrdNo, @StaffOrdStatusID, GETDATE(), @user)";

                var parameters = new DynamicParameters();
                parameters.Add("@staffOrdNo", orderID);
                parameters.Add("@StaffOrdStatusID", statusId);
                parameters.Add("@user", auditUser);

                conn.Execute(procedure, parameters, null, null, CommandType.Text);
            }
        }     

        public List<Domain.Order> ViewAllOrders()
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
                          ,(select top 1 StaffOrdStatusID from [Omega].[dbo].StoStaffOrdStatusTrack sst 
                                    WHERE sst.[staffOrdNo] = sso.[staffOrdNo] 
                                    order by auditDte desc) as StatusID
                        FROM [Omega].[dbo].[StoStaffOrder] sso";

            List<Order> orders = conn.Query<Order>(sqlStr, null, commandType: CommandType.Text).ToList();
            return orders;
        }

        public List<Domain.Order> ViewOrdersByStatus(int status)
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            //TODO: Refactor Status Get  
            var sqlStr = @"select * from 
                        (SELECT sso.[staffOrdNo] as OrderID
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
		                        ,(  select top 1 StaffOrdStatusID from Omega.dbo.StoStaffOrdStatusTrack sst 
                                    WHERE sst.[staffOrdNo] = sso.[staffOrdNo] 
                                    order by auditDte desc) as StatusID
                            FROM [Omega].[dbo].[StoStaffOrder] sso
	                        ) staffordersUpdated
	                        where StatusID = @StatusID";
            DynamicParameters param = new DynamicParameters();

            param.Add("@StatusID", status, dbType: DbType.Int32, direction: ParameterDirection.Input);

            List<Order> orders = conn.Query<Order>(sqlStr, param, commandType: CommandType.Text).ToList();
            return orders;
        }
        public Domain.Order ViewOrderByID(int orderID)
        {
            //TODO: Add Contact Details and status
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = @"SELECT sso.[staffOrdNo] as OrderID
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
                          ,(select top 1 StaffOrdStatusID from Omega.dbo.StoStaffOrdStatusTrack sst 
                                    WHERE sst.[staffOrdNo] = sso.[staffOrdNo] 
                                    order by auditDte desc) as StatusID
                        FROM[Omega].[dbo].[StoStaffOrder] sso
            where staffOrdNo = @OrderID";
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrderID", orderID, dbType: DbType.String, direction: ParameterDirection.Input);

            Order order = conn.Query<Order>(sqlStr, param, commandType: CommandType.Text).FirstOrDefault();

            return order;

        }
    }
}
