using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableDatabase
{
    class DBWriter : DBManager
    {
        public DataGridView Grid { get; set; }

        public override bool Process()
        {
            var connection = new SQLiteConnection(DbPath);
            connection.Open();
            var query = connection.CreateCommand();
            query.CommandText = "insert into " + DB.TableName + "(id, X, Y) values(@id,@X,@Y)";

            for (int i = 0; i < Grid.RowCount; ++i)
            {
                query.Parameters.AddWithValue("id", i);
                query.Parameters.AddWithValue("X", Grid.Rows[i].Cells[0].Value);
                query.Parameters.AddWithValue("Y", Grid.Rows[i].Cells[1].Value);
                query.ExecuteNonQuery();
                query.Parameters.Clear();
            }

            connection.Close();
            return true;
        }
    }
}