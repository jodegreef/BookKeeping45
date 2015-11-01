//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookKeeping45.Queries.Infrastructure
//{
//    public class ConnectionProvider : IConnectionProvider
//    {
//        public System.Data.IDbConnection GetOpenConnection()
//        {
//            var connectionString = ConfigurationManager.ConnectionStrings["MyApp"].ConnectionString;
//            var sqlConnection = new SqlConnection(connectionString);
//            sqlConnection.Open();
//            return sqlConnection;
//        }
//    }
//}
