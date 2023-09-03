using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public string SendQuery(string queryString, SQLiteConnection conn)
        {
            try
            {   
                using (SQLiteCommand command = new SQLiteCommand(queryString, conn))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    StringBuilder resultBuilder = new StringBuilder();

                    while (reader.Read())
                    {
                        // 가정: 결과는 하나의 컬럼만 반환된다고 가정합니다.
                        string value = reader.GetString(0); // 결과의 첫 번째 컬럼을 string으로 읽어옴
                        resultBuilder.AppendLine(value);
                    }

                    return resultBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQLite Error");
                return null;
            }
        }
    }


    //DML Methods (To disallow running script from form)
    public class DML
    {
        public void Select(string items, string tableName)
        {
            
        }

        public void Insert(string item, string tableName)
        {

        }
        public void Update(string items, string tableName)
        {

        }

        public void Delete(string item, string tableName)
        {

        }
    }
}
