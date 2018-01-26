using Microsoft.Extensions.Configuration;
using StaffOrder.Infrastructure.Configurations.ConfigModels;
using StaffOrder.Infrastructure.Configurations.Contracts;

namespace StaffOrder.Infrastructure.Configurations
{
    public class ConfigService : IConfigService
    {
        private readonly ServicesEndpoints _servicesEndpoints;
        protected AppSettings _appSettings { get; }
        protected ConfigSettings _configSettings { get; }
        protected ConnectionStrings _connStrings { get; }

        public ConfigService(IConfiguration config, AppSettings appSettings, ConfigSettings configSettings,
             ConnectionStrings connStrings, ServicesEndpoints servicesEndpoints)
        {
            _appSettings = appSettings;
            _configSettings = configSettings;
            _servicesEndpoints = servicesEndpoints;
            _connStrings = connStrings;
        }

        public string GetServiceEndPoint(string serviceName)
        {
            var endpoint = _servicesEndpoints.Services[serviceName].Url;

            return endpoint;
        }



        public string GetMySQLConnectionString()
        {
            var connstr = _connStrings.MySQLConnection;
            return connstr;
        }

        public string GetSQLConnectionString()
        {
            var connstr = _connStrings.OmegaConnection;
            return connstr;
        }
    }
}
