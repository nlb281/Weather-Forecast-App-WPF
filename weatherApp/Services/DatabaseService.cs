using System.IO;
using Microsoft.Data.Sqlite;

namespace weatherApp.Services;

public class DatabaseService
{
    private readonly string _connectionString;


    public DatabaseService(string databaseName = "weather.db")
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, databaseName);
  
        _connectionString = $"Data Source={dbPath}";
    }

    public string GetConnectionString()
    {
        return _connectionString;
    }
    
    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        
        connection.Open();
        
        Console.WriteLine("БД открыта/создана");
    
        CreateSettingsTable(connection);
        Console.WriteLine("Таблица Settings создана");
    
        CreateFavoriteCitiesTable(connection);
        Console.WriteLine("Таблица FavoriteCities создана");
    
        InsertInitialData(connection);
        Console.WriteLine("Начальные данные вставлены");
    }

    public void CreateSettingsTable(SqliteConnection connection)
    {
        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Settings (
                id INTEGER PRIMARY KEY CHECK (id = 1),
                theme TEXT NOT NULL DEFAULT 'light',
                lastCity TEXT NOT NULL DEFAULT 'Москва'
            )
        ";
        
        command.ExecuteNonQuery();
    }
    
    public void CreateFavoriteCitiesTable(SqliteConnection connection)
    {
        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS FavoriteCities (
                id INTEGER  PRIMARY KEY AUTOINCREMENT,
                city TEXT NOT NULL UNIQUE
            )
        ";
        
        command.ExecuteNonQuery();
    }

    public void InsertInitialData(SqliteConnection connection)
    {
        var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT OR IGNORE INTO Settings (id, theme, lastCity)
            VALUES (1, 'light', 'Москва')
        ";
        
        command.ExecuteNonQuery();
    }
}