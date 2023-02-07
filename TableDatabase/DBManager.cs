using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    abstract class DBManager
    {
        public bool isDbExists() => System.IO.File.Exists(Application.StartupPath + "\\" + DB.DbName);
        public string DbPath { get; } = @"URI=file: " + Application.StartupPath + "\\" + DB.DbName;

        public abstract bool Process();
    }
}