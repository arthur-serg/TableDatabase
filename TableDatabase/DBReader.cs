using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public override bool Process()
        {
            if (!isDbExists()) return false;
            ReadDb();
            return true;
        }
    }
}