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

namespace StaffOrder.Infrastructure.Repositories.Stock
{
    public class StockRepo : IStockRepo
    {
        private IConnectionFactory _connectionFactory;
        private IConfigService _configService;
        private string connection;
        public StockRepo(IConnectionFactory connectionFactory, IConfigService configService)
        {
            _configService = configService;
            _connectionFactory = connectionFactory;
            connection = configService.GetSQLConnectionString();
        }
        public Domain.Stock GetStock(int itemNo)
        {
            IDbConnection conn = _connectionFactory.GetNewSqlConnectionWithLoginDetails(new SqlConnection(connection), String.Empty, String.Empty);

            var sqlStr = "select AXCategory, " +
                                "AXSubCategory, " +
                                "AXClass, " +
                                 "Pattern, " +
                                "OrdCodeDescrip, " +
                                "OrdCode, " +
                                "Size, " +
                                "Colour, " +
                                "Variation, " +
                                 "Page, " +
                               "SequenceNo, " +
                               "ItemNo, " +
                               "CashPrice, " +
                               "QtyAvail" +
                " from stoStock " +
                "where ItemNO = @ItemNo";

            DynamicParameters param = new DynamicParameters();

            param.Add("@ItemNo", itemNo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            Domain.Stock stock = conn.Query<Domain.Stock>(sqlStr, param, commandType: CommandType.Text).SingleOrDefault();

            return stock;
        }
    }
}
