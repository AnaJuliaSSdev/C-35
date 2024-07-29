using Microsoft.Data.SqlClient;

namespace AdoNetCrudProducts.DB;

public class Connection
{
    private readonly string connectionString = "Connection string here";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}
