using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;


namespace TableDatabase
{
    public static class DB
    {
        public static readonly string DbName = "database.db";
        public static readonly string TableName = "PointsTable";
        public static readonly string Hostname = "Database";
        public static readonly string X = "X";
        public static readonly string Y = "Y";
    };

    internal class DatabaseManager
    {
        private readonly string connectToDbPath = @"URI=file: " + Application.StartupPath + "\\" + DB.DbName;

        public SQLiteDataReader DataReader { get; set; }

        public void CreateDatabase()
        {
            Debug.WriteLine("initializeDatabase()");
            if (!System.IO.File.Exists(Application.StartupPath + "\\" + DB.DbName))
            {
                using (var sqlConnection = new SQLiteConnection(connectToDbPath))
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
            }

            else
            {
                Debug.WriteLine($"Database: {Application.StartupPath + "\\" + DB.DbName} already exists.");
                return;
            }
        }

        internal SQLiteDataReader ReadDatabase()
        {
            var connection = new SQLiteConnection(connectToDbPath);
            connection.Open();
            var query = connection.CreateCommand();

            query.CommandText = "select * from " + DB.TableName;
            query.ExecuteNonQuery();
            DataReader = query.ExecuteReader();
            return DataReader;
        }

        internal void InsertData()
        {
            var connection = new SQLiteConnection(connectToDbPath);
            connection.Open();
            var query = connection.CreateCommand();
            query.CommandText = "insert into " + DB.TableName + "(id, X, Y) values(@id,@X,@Y)";

            //TODO: insert data properly.
        }
    };
}