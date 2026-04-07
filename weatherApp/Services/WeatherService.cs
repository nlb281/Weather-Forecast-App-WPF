using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using weatherApp.Models;

namespace weatherApp.Services;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private const string BaseUrl = "https://api.weather.yandex.ru/v2/";

    public WeatherService(string apiKey)
    {
        _httpClient = new HttpClient();
        _apiKey = apiKey;
        
        _httpClient.DefaultRequestHeaders.Add("X-Yandex-Weather-Key", _apiKey);
    }
    
    public async Task<WeatherResponse?> GetWeatherByCoords(double latitude, double longitude)
    {
        try
        {
            string latStr = latitude.ToString(CultureInfo.InvariantCulture);
            string lonStr = longitude.ToString(CultureInfo.InvariantCulture);
            
            string url = $"{BaseUrl}forecast?lat={latStr}&lon={lonStr}&lang=ru_RU";
            var res = await _httpClient.GetAsync(url);
            
            if (!res.IsSuccessStatusCode)
                return null;
            
            string json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<WeatherResponse>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error receiving weather data: {ex.Message}");
            return null;
        }
    }
}