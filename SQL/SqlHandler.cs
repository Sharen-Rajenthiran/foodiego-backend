using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace FoodieGo.API.SQL
{
    public class SqlHandler
    {
        private string database = "foodiego";
        private string connectionString = "Server=localhost;Database=FoodieGo;User=root;Password=;";

        public string getConnectionString() { return $"{connectionString}database={database}"; }

        public void DbStartup()
        {
            try
            {
                using (var initialConnection = new MySqlConnection(connectionString))
                {
                    initialConnection.Open();
                    string sql = $"CREATE  DATABASE IF NOT EXISTS {database}";
                    ExecuteQuery(sql, initialConnection);
                }

                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                // Create table if not exists
                CreateTable(connection);

                // Delete unused tables if exists
                DeleteTable(connection);
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void ExecuteQuery(string query, MySqlConnection con)
        {
            try
            {
                using MySqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Execute Query Error : " + ex.Message);
            }
        }

        private void CreateTable(MySqlConnection con)
        {
            string[] sql = [@"
                CREATE TABLE IF NOT EXISTS Users (
                    Id CHAR(36) NOT NULL,
                    Password VARCHAR(255) NOT NULL,
                    PRIMARY KEY (Id)
                ) ENGINE=InnoDB"];

            foreach (var query in sql)
            {
                ExecuteQuery(query, con);
            }
        }
        private void DeleteTable(MySqlConnection con)
        {
            string[] deleteSql = [
                "DROP TABLE IF EXISTS user",
                "DROP TABLE IF EXISTS  __efmigrationshistory"
                ];

            foreach (var query in deleteSql)
            {
                ExecuteQuery(query, con);
            }
        }

    }
}
