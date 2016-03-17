using System;
using System.Configuration;

namespace AbiokaDDD.Infrastructure.Common.ApplicationSettings
{
    public class WebConfigConnectionStringRepository : IConnectionStringRepository
	{
        public string ReadAppSetting(string appSettingName) {
            return ConfigurationManager.AppSettings[appSettingName];
        }

        public string ReadConnectionString(string connectionStringName)
		{
            var conn = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (conn == null)
                throw new ArgumentNullException($"Connection string with name {connectionStringName} couldn't be found in the configuration file.");

            return conn.ConnectionString;
		}
	}
}
