﻿using System.Configuration;
using System.Data.SqlClient;
using NServiceBus;
using NServiceBus.Transports.SQLServer;

class NamedConnectionString
{
    private string connectionString;

    void ConnectionString(EndpointConfiguration endpointConfiguration)
    {
        #region sqlserver-config-connectionstring

        var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
        transport.ConnectionString("Data Source=INSTANCE_NAME;Initial Catalog=some_database;Integrated Security=True");

        #endregion
    }

    void ConnectionName(EndpointConfiguration endpointConfiguration)
    {
        #region sqlserver-named-connection-string

        var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
        transport.ConnectionStringName("MyConnectionString");

        #endregion
    }

    void ConnectionFactory(EndpointConfiguration endpointConfiguration)
    {
        #region sqlserver-custom-connection-factory

        var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
        transport.UseCustomSqlConnectionFactory(async () =>
        {
            connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            // perform custom operations

            return connection;
        });

        #endregion
    }
}
