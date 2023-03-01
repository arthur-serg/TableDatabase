using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace TableDatabase
{
    public class DBRowByIDDeleter : DBManager
    {
        public override bool Process() => DeleteRowById(RowID);

        public int RowID { get; set; }

        public DBRowByIDDeleter(int rowIndex)
        {
            RowID = rowIndex;
        }

        private bool DeleteRowById(int rowId)
        {
            var sqlExpression = "sp_DeleteRowById";
            var connection = new SqlConnection(SqlConnectionString.ConnectionString);
            connection.Open();
            var query = new SqlCommand(sqlExpression, connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.AddWithValue("id", rowId);
            query.ExecuteNonQuery();
            connection.Close();

            //TODO: update grid wrt to deleted row from DB
            return true;
        }
    }
}