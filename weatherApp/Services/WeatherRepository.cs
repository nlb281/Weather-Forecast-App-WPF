using Microsoft.Data.Sqlite;

namespace weatherApp.Services;

public class WeatherRepository
{
     private readonly string _connectionString;

     public WeatherRepository(string connectionString)
     {
          _connectionString = connectionString;
     }

     // GET запросы
     public string GetTheme()
     {
          string theme;

          using var connection = new SqliteConnection(_connectionString);
          
          connection.Open();

          var command = connection.CreateCommand();
          command.CommandText = "SELECT theme FROM Settings WHERE id = 1";

          object? result = command.ExecuteScalar();

          theme = result?.ToString() ?? "light";
          
          return theme;
     }
     
     public string GetLastCity()
     {
          string lastCity;

          using var connection = new SqliteConnection(_connectionString);
          
          connection.Open();

          var command = connection.CreateCommand();
          command.CommandText = "SELECT lastCity FROM Settings WHERE id = 1";

          object? result = command.ExecuteScalar();

          lastCity = result?.ToString() ?? "Москва";
          
          return lastCity;
     }

     public List<string> GetFavoriteCities()
     {
          var cities = new List<string>();
          
          using var connection = new SqliteConnection(_connectionString);
          
          connection.Open();
          
          var command = connection.CreateCommand();
          command.CommandText = "SELECT city FROM FavoriteCities";
          
          using var reader = command.ExecuteReader();

          while (reader.Read())
          {
               cities.Add(reader.GetString(0));
          }
          
          return cities;
     }
     
     // UPDATE запросы
     public void UpdateTheme(string theme)
     {
          if (string.IsNullOrWhiteSpace(theme))
               return;
          
          using var connection = new SqliteConnection(_connectionString);
          
          connection.Open();
          
          var command = connection.CreateCommand();
          command.CommandText = "UPDATE Settings SET theme = $theme WHERE id = 1";
          
          command.Parameters.AddWithValue("$theme", theme);
          
          command.ExecuteNonQuery();
     }
     
     public void UpdateLastCity(string lastCity)
     {
          if (string.IsNullOrWhiteSpace(lastCity))
               return;
          
          using var connection = new SqliteConnection(_connectionString);
          
          connection.Open();
          
          var command = connection.CreateCommand();
          command.CommandText = "UPDATE Settings SET lastCity = $lastCity WHERE id = 1";
          
          command.Parameters.AddWithValue("$lastCity", lastCity);
          
          command.ExecuteNonQuery();
     }
     
     // POST Запросы
     public void AddFavoriteCity(string city)
     {
          if (string.IsNullOrWhiteSpace(city))
               return;
          
          if (IsFavorite(city))
               return; 
          
          using var connection = new SqliteConnection(_connectionString);
          
          connection.Open();
          
          var command = connection.CreateCommand();
          command.CommandText = "INSERT INTO FavoriteCities (city) VALUES ($city)";
          
          command.Parameters.AddWithValue("$city", city);
          
          command.ExecuteNonQuery();
     }
     
     // DELETE Запросы
     public void RemoveFavoriteCity(string city)
     {
          if (string.IsNullOrWhiteSpace(city))
               return;
          
          using var connection = new SqliteConnection(_connectionString);
          
          connection.Open();
          
          var command = connection.CreateCommand();
          command.CommandText = "DELETE FROM FavoriteCities WHERE city = $city";
          
          command.Parameters.AddWithValue("$city", city);
          
          command.ExecuteNonQuery();
     }
     
     // Проверка явл. ли город уже в спике "Избранное"
     public bool IsFavorite(string city)
     {
          if (string.IsNullOrWhiteSpace(city))
               return false;

          using var connection = new SqliteConnection(_connectionString);
          
          connection.Open();
          
          var command = connection.CreateCommand();
          command.CommandText = "SELECT COUNT(*) FROM FavoriteCities WHERE city = $city";
          
          command.Parameters.AddWithValue("$city", city);
          
          var count = Convert.ToInt32(command.ExecuteScalar());
          
          return count > 0;
     }
}