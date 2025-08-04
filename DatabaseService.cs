using Microsoft.Data.Sqlite;
using System.IO;

namespace MovieCatalogApp.Services
{
    public class DatabaseService
    {
        private const string DbFileName = "movies.db";

        public DatabaseService()
        {
            if (!File.Exists(DbFileName))
            {
                InitializeDatabase();
            }
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection($"Data Source={DbFileName}");
            connection.Open();

            var command = connection.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL
                    );
                ";
            command.ExecuteNonQuery();
        }

        public void AddUser(string username, string password)
        {
            using var connection = new SqliteConnection($"Data Source={DbFileName}");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Users (Username, Password)
                VALUES ($username, $password);
            ";
            command.Parameters.AddWithValue("$username", username);
            command.Parameters.AddWithValue("$password", password); // HASH LATER
            command.ExecuteNonQuery();
        }
    }
}
