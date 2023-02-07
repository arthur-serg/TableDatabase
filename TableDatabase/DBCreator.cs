using System;
using System.Diagnostics;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace TableDatabase
{
    class DBCreator : DBManager
    {
        public override bool Process()
        {
            if (!System.IO.File.Exists(Application.StartupPath + "\\" + DB.DbName))
            {
                using (var sqlConnection = new SQLiteConnection(DbPath))
                {
                    sqlConnection.Open();
                    var query = sqlConnection.CreateCommand();
                    var transaction = sqlConnection.BeginTransaction();
                    query.CommandText = "create table " + DB.TableName + " (id int primary key, " + DB.X + " double " +
                                        "," + DB.Y + " double " + ");";

                    query.ExecuteNonQuery();

                    transaction.Commit();
                    Debug.WriteLine("table " + DB.TableName + " was created");
                }

                return true;
            }

            else
            {
                Debug.WriteLine($"Database: {Application.StartupPath + "\\" + DB.DbName} already exists.");
                return false;
            }
        }
    }
}