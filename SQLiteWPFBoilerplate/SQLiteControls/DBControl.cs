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

        public void ConnectDB(string dbPath)
        {
            var conn = new SQLiteConnection(dbPath);
            conn.Open();
        }

        public int SendQuery(string queryString, SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand(queryString, conn);
            return command.ExecuteNonQuery();
        }
    }
}
