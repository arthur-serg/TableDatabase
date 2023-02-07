using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDatabase
{
    class DBWriter : DBManager
    {
        public override bool Process()
        {
            var connection = new SQLiteConnection(DbPath);
            connection.Open();
            var query = connection.CreateCommand();
            query.CommandText = "insert into " + DB.TableName + "(id, X, Y) values(@id,@X,@Y)";

            return true;
        }
    }
}