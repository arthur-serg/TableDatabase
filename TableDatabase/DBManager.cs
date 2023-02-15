using System.Data;
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

    abstract class DBManager
    {
        public DataTable DataTable { get; set; } = new DataTable();
        public DataGridView Grid { get; set; } = new DataGridView();

        public string ConnectionString { get; } =
            @"Data Source=ASUS-A17\SQLEXPRESS;Initial Catalog=pointsdb;Integrated Security=True";

        public abstract bool Process();
    }
}