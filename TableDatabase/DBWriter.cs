using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace TableDatabase
{
    class DBWriter : DBManager
    {
        public async Task ProcessAsync() => await Task.Run(Process);

        public override bool Process()
        {
            //TODO: сделать хранимую процедуру и вставлять всё в ней, а здесь вызывать.

            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var query = connection.CreateCommand();
            query.CommandText = "insert into " + DB.TableName + "(X, Y) values(@X,@Y)";

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