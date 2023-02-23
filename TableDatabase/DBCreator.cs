using System.Data;
using System.Data.SqlClient;

namespace TableDatabase
{
    public class DBCreator : DBManager
    {
        public override bool Process()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var sqlExpression = "sp_DeleteRows";
                var connection = new SqlConnection(ConnectionString);
                connection.Open();
                var query = new SqlCommand(sqlExpression, connection);
                query.CommandType = CommandType.StoredProcedure;
                query.ExecuteNonQuery();
                connection.Close();
            }

            return true;
        }
    }
}