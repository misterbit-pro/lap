using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PrintDB.Database
{
    public class DataAccess
    {
        public static List<object[]> LoadData(string sql, string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new MySqlCommand(sql, connection);

                var reader = cmd.ExecuteReader();

                var allValues = new List<object[]>();

                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    allValues.Add(values);
                }

                return allValues;
            }
        }

        public static string GenerateConnectionString(string database = null) 
            => database == null 
                ? "server=localhost;user=root;password=example" 
                : $"server=localhost;user=root;password=example;database={database}";
    }
}
