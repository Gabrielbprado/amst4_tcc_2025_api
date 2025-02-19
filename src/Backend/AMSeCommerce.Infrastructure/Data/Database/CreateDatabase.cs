using Dapper;
using Microsoft.Data.SqlClient;
namespace AMSeCommerce.Infrastructure.Data.Database;

public static class CreateDatabase
{
    public static void Create(string connectionString)
    {
        var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

        var databaseName = connectionStringBuilder.InitialCatalog;

        connectionStringBuilder.Remove("Database");

        using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

        var parameters = new DynamicParameters();
        parameters.Add("name", databaseName);

        var records = dbConnection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);
        Console.WriteLine(databaseName);
        if (records.Any() is false)
            dbConnection.Execute($"CREATE DATABASE {databaseName}");
    }
}