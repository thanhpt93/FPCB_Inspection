using Microsoft.Data.Sqlite;

namespace Hwaseung;

internal static class AuthService
{
    private static readonly string DbPath = Path.Combine(AppContext.BaseDirectory, "users.db");
    private static readonly string ConnectionString = $"Data Source={DbPath}";

    public static void InitializeDatabase()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var createCmd = connection.CreateCommand();
        createCmd.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL UNIQUE,
                Password TEXT NOT NULL,
                Role TEXT NOT NULL
            );
            """;
        createCmd.ExecuteNonQuery();

        SeedUser(connection, "admin", "admin123", "admin");
        SeedUser(connection, "user", "user123", "user");
    }

    public static bool TryAuthenticate(string username, string password, out string role)
    {
        role = string.Empty;

        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var cmd = connection.CreateCommand();
        cmd.CommandText =
            """
            SELECT Role
            FROM Users
            WHERE Username = $username AND Password = $password
            LIMIT 1;
            """;
        cmd.Parameters.AddWithValue("$username", username);
        cmd.Parameters.AddWithValue("$password", password);

        var result = cmd.ExecuteScalar();
        if (result is null)
        {
            return false;
        }

        role = result.ToString() ?? string.Empty;
        return !string.IsNullOrWhiteSpace(role);
    }

    private static void SeedUser(SqliteConnection connection, string username, string password, string role)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText =
            """
            INSERT OR IGNORE INTO Users (Username, Password, Role)
            VALUES ($username, $password, $role);
            """;
        cmd.Parameters.AddWithValue("$username", username);
        cmd.Parameters.AddWithValue("$password", password);
        cmd.Parameters.AddWithValue("$role", role);
        cmd.ExecuteNonQuery();
    }
}
