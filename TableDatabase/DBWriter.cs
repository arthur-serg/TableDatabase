using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace TableDatabase
{
    public class DBWriter : DBManager
    {
        public async Task ProcessAsync() => await Task.Run(Process);

        public override bool Process()
        {
            var sqlExpression = "sp_InsertPoint";
            var connection = new SqlConnection(SqlConnectionString.ConnectionString);
            connection.Open();
            var query = new SqlCommand(sqlExpression, connection);
            query.CommandType = CommandType.StoredProcedure;

            var writerThread = new Thread(() =>
            {
                for (int i = 0; i < Grid.RowCount; ++i)
                {
                    query.Parameters.AddWithValue("X", Grid.Rows[i].Cells["X"].Value);
                    query.Parameters.AddWithValue("Y", Grid.Rows[i].Cells["Y"].Value);
                    query.ExecuteNonQuery();
                    query.Parameters.Clear();
                }
            });
            writerThread.Start();
            writerThread.Join();

            connection.Close();
            return true;
        }
    }
}