using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWPFBoilerplate.SQLiteControls
{
    public class DBControl
    {
        public void CreateDB(string dbPath)
        {
            SQLiteConnection.CreateFile(dbPath);
        }

        public SQLiteConnection ConnectDB(string dbPath)
        {
            string connString = @"Data Source=" + dbPath + ";Pooling=true;FailIfMissing=false";
            var conn = new SQLiteConnection(connString);
            conn.Open();
            return conn;
        }

        public int SendQuery(string queryString, SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand(queryString, conn);
            return command.ExecuteNonQuery();
        }
    }
}
