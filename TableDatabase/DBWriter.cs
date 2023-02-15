using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace TableDatabase
{
    class DBWriter : DBManager
    {
        public async Task ProcessAsync() => await Task.Run(Process);

        public override bool Process()
        {
            var connection = new SQLiteConnection(DbPath);
            connection.Open();
            var query = connection.CreateCommand();
            query.CommandText = "insert into " + DB.TableName + "(id, X, Y) values(@id,@X,@Y)";

            var writerThread = new Thread(() =>
            {
                for (int i = 0; i < Grid.RowCount; ++i)
                {
                    query.Parameters.AddWithValue("id", i);
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