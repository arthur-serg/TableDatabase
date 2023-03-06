using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableDatabase
{
    public class DBUpdater : DBManager
    {
        public DBUpdater(DataGridView dgv)
        {
            Grid = dgv;
        }

        public async Task ProcessAsync() => await Task.Run(Process);

        public override bool Process()
        {
            var sqlExpression = "sp_UpdateTable";

            using (SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Open();

                var query = new SqlCommand(sqlExpression, connection);
                query.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < Grid.Rows.Count; ++i)
                {
                    query.Parameters.AddWithValue("id", Grid.Rows[i].Cells["id"].Value);
                    query.Parameters.AddWithValue("X", Grid.Rows[i].Cells["X"].Value);
                    query.Parameters.AddWithValue("Y", Grid.Rows[i].Cells["Y"].Value);
                    query.ExecuteNonQuery();
                    query.Parameters.Clear();
                }
                connection.Close();
            }

            return true;
        }
    }
}