using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TableDatabase
{
    public abstract class DBManager
    {
        public DataTable DataTable { get; set; } = new DataTable();
        public DataGridView Grid { get; set; }

        public SqlConnectionStringBuilder SqlConnectionString { get; set; } = new SqlConnectionStringBuilder()
        {
            DataSource = @"ASUS-A17\SQLEXPRESS",
            InitialCatalog = "pointsdb",
            IntegratedSecurity = true,
        };


        public abstract bool Process();
    }
}