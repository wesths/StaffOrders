﻿using Dapper;
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

        public OrderContact GetOrderContactDetails(int ordNo)
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = "select StaffOrdNo as OrderId, " +
                "ContactName, " +
                "ContactNo, " +
                "ExtNo" +                
                " from stoOrderContact " +
                "where StaffOrdNo = @OrdNo ";
            DynamicParameters param = new DynamicParameters();

            param.Add("@OrdNo", ordNo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            Domain.OrderContact orderContact = conn.Query<Domain.OrderContact>(sqlStr, param, commandType: CommandType.Text).SingleOrDefault();

            return orderContact;
        }

        public List<Domain.Order> GetOrdersForStaffMember(string empNo)
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = "select StaffOrdNo as OrderId, " +
                "EmpNo as EmployeeNo, " +
                "OrdCode, " +
                "ItemNo," +
                "ItemDepartment as Dept, " +
                "Mailing, " +
                "Month," +
                "Page," +
                "ItemDesciption as Description," +
                "Size," +
                "Price," +
                "OrdDate as OrderDate" +
                " from stoStaffOrder " +
                "where EmpNo = @empNo ";
            DynamicParameters param = new DynamicParameters();

            param.Add("@empNo", empNo, dbType: DbType.String, direction: ParameterDirection.Input);

            List<Domain.Order> staffOrders = conn.Query<Domain.Order>(sqlStr, param, commandType: CommandType.Text).ToList();

            return staffOrders;
        }

        public StaffMember GetStaffMember(string firstName, string lastName)
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = "select UserName, " +
                "FirstName, " +
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

        public StaffMember GetStaffMember(string userName)
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = "select UserName, " +
                "FirstName, " +
                "LastName, " +
                "EmpNo, " +
                "Dept," +
                "ContactNo, " +
                "ExtNo " +
                " from stoStaff " +
                "where UserName = @UserName ";

            DynamicParameters param = new DynamicParameters();

            param.Add("@UserName", userName, dbType: DbType.String, direction: ParameterDirection.Input);

            Domain.StaffMember staffMember = conn.Query<Domain.StaffMember>(sqlStr, param, commandType: CommandType.Text).SingleOrDefault();

            return staffMember;
        }

        public StaffMember GetStaffMemberEmpNo(string empNo)
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

        public void SaveOrder(Order order)
        {            

            var sqlStr = "Insert stoStaffOrder (EmpNo,OrdCode,ItemNo,ItemDepartment,Mailing,Month,Page,ItemDesciption,Size,Price,OrdDate,Auditdte,AuditUsr) " +
                " values (@EmpNo, @OrdCode, @ItemNo, @ItemDepartment, @Mailing, @Month, @Page, @ItemDescription, @Size, @Price, @OrdDate, @Auditdte, @AuditUsr)";
            DynamicParameters param = new DynamicParameters();
            var today = DateTime.Now;
            var user = "wesths";
                        
            param.Add("@EmpNo", order.EmployeeNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@OrdCode", order.OrdCode, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ItemNo", order.ItemNo, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ItemDepartment", order.Dept, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Mailing", order.Mailing, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Month", order.Month, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Page", order.page, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ItemDescription", order.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Size", order.Size, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Price", order.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("@OrdDate", today, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("@Auditdte", today, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("@AuditUsr", user, dbType: DbType.String, direction: ParameterDirection.Input);

            using (IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty))
            {
                conn.Execute(sqlStr, param, null, null, CommandType.Text);// StoredProcedure);
            }
        }

        public void SaveOrderContactDetails(OrderContact orderContact)
        {
            var sqlStr = $"if not exists ( select 1 from stoOrderContact where staffOrdNo = {orderContact.OrderId} )" +
                " begin " +
                " Insert stoOrderContact (staffOrdNo,ContactName,ContactNo,ExtNo) " +
                $" values ({orderContact.OrderId}, '{orderContact.ContactName}', '{orderContact.ContactNo}','{orderContact.ExtNo}')" +
                " end " + 
                " else " +
                "  begin " +
                " update stoOrderContact " +
                $" set ContactName = '{orderContact.ContactName}'," +
                $" ContactNo = '{orderContact.ContactNo}', " +
                $" Extno = '{orderContact.ExtNo}' " +
                $" where StaffOrdNo = {orderContact.OrderId}" +
                " end ";

            using (IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty))
            {
                conn.Execute(sqlStr, null, null, null, CommandType.Text);// StoredProcedure);
            }
        }

        public void SavePersonalDetails(StaffMember staffMember)
        {
            var sqlStr = $"if not exists ( select 1 from stoStaff where Username = '{staffMember.UserName}' )" +
                " begin " +
                "Insert stoStaff (FirstName,LastName,EmpNo,Dept,ContactNo,ExtNo,UserName) " +
                $" values ('{staffMember.FirstName}', '{staffMember.LastName}', {staffMember.EmpNo}, '{staffMember.Department}', '{staffMember.ContactNo}', '{staffMember.ExtNo}', '{staffMember.UserName}')" +
                " end " +
                " else " +
                "  begin " +
                " update stoStaff " +
                $" set FirstName = '{staffMember.FirstName}'," +
                $" LastName = '{staffMember.LastName}', " +
                $" EmpNo = '{staffMember.EmpNo}', " +
                $" Dept = '{staffMember.Department}', " +
                $" ContactNo = '{staffMember.ContactNo}', " +
                $" ExtNo = '{staffMember.ExtNo}' " +
                $" where Username = '{staffMember.UserName}'" +
                " end ";

            
            using (IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty))
            {
                conn.Execute(sqlStr, null, null, null, CommandType.Text);// StoredProcedure);
            }
        }
    }
}
