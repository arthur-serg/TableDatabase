using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableDatabase
{
    class DBReader : DBManager
    {
        public SQLiteDataReader DataReader { get; set; }

        private void ReadDb()
        {
            var connection = new SQLiteConnection(DbPath);
            connection.Open();
            var query = new SQLiteCommand("select * from " + DB.TableName, connection);
            DataReader = query.ExecuteReader();

            Grid.AllowUserToAddRows = false;
            Grid.ColumnCount = DataReader.FieldCount - 1;
        }

        public override bool Process()
        {
            if (!isDbExists()) return false;
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