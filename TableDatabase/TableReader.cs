using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TableDatabase
{
    public class TableReader : DBManager
    {
        public SqlDataReader DataReader { get; set; }

        private void ReadDb()
        {
            var sqlExpression = "sp_Select";
            var connection = new SqlConnection(SqlConnectionString.ConnectionString);
            connection.Open();
            var query = new SqlCommand(sqlExpression, connection);
            query.CommandType = CommandType.StoredProcedure;
            DataReader = query.ExecuteReader();
            Grid = new DataGridView();
            Grid.AllowUserToAddRows = false;
            Grid.ColumnCount = DataReader.FieldCount;
        }

        public override bool Process()
        {
            ReadDb();
            Console.WriteLine(Grid.Rows.Count);
            return true;
        }

        public void FillDataTableFromGrid(DataGridView dgv, out DataTable dt)
        {
            DataTable = new DataTable();

            for (int i = 0; i < dgv.ColumnCount; ++i)
            {
                DataTable.Columns.Add(dgv.Columns[i].Name);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dataRow = DataTable.NewRow();
                for (int i = 0; i < dgv.ColumnCount; ++i)
                {
                    dataRow[i] = row.Cells[i].Value;
                }

                DataTable.Rows.Add(dataRow);
            }

            dt = DataTable;
        }
    }
}