using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FoodieGo.Infrastructure.Database
{
    public class SqlConnectionFactory
    {
        private readonly string _connectionString;
        public SqlConnectionFactory(string connectionString) => _connectionString = connectionString;
        //TODO : Setup SQL Connection String
        public MySqlConnection Create() => new MySqlConnection(_connectionString);
    }
}
