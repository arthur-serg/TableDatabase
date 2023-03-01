using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TableDatabase
{
    public static class DB
    {
        public static readonly string DbName = "database.db";
        public static readonly string TableName = "pointstable";
        public static readonly string Hostname = "Database";
        public static readonly string X = "X";
        public static readonly string Y = "Y";
    };

    public abstract class DBManager
    {
        public DataTable DataTable { get; set; } = new DataTable();
        public DataGridView Grid { get; set; } = new DataGridView();


        public SqlConnectionStringBuilder SqlConnectionString { get; set; } = new SqlConnectionStringBuilder()
        {
            DataSource = @"ASUS-A17\SQLEXPRESS",
            InitialCatalog = "pointsdb",
            IntegratedSecurity = true,
        };

        public abstract bool Process();
    }
}