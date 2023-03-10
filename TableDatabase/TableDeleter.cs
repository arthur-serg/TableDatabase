using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TableDatabase
{
    public class TableDeleter : DBManager
    {
        public override bool Process() => DeleteRowById(RowID);

        public int RowID { get; set; }
        public DataGridViewRow SelectedRow { get; set; }

        public TableDeleter(DataGridViewRow row, DataGridView dgv)
        {
            SelectedRow = row;
            RowID = (int)row.Cells["id"].Value;
            Grid = dgv;
        }


        private bool DeleteRowById(int rowId)
        {
            var sqlExpression = "sp_DeleteRowById";
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Open();
                var query = new SqlCommand(sqlExpression, connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.AddWithValue("id", rowId);
                query.ExecuteNonQuery();
                connection.Close();
                DeleteRowFromGrid();
            }

            return true;
        }

        private void DeleteRowFromGrid()
        {
            Grid.Rows.RemoveAt(SelectedRow.Index);
        }
    }
}