using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SDMine.Collector.DataAccess
{
    public class DbContext
    {
        public static IDbConnection CreateConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SDMine"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
