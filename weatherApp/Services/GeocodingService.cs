using System.Net.Http;
using System.Text.Json;
using weatherApp.Models;

namespace weatherApp.Services;

public class GeocodingService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private const string BaseUrl = "https://api.geoapify.com/v1/geocode/";

    public GeocodingService(string apiKey)
    {
        _httpClient = new HttpClient();
        _apiKey = apiKey;
    }
    
    public async Task<GeoapifyResponse?> GetCoords(string city)
    {
        try
        {
            string url = $"{BaseUrl}/search?text={Uri.EscapeDataString(city)}&apiKey={_apiKey}";
            var res = await _httpClient.GetAsync(url);
            
            if (!res.IsSuccessStatusCode)
                return null;
            
            string json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<GeoapifyResponse>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка получения данных погоды: {ex.Message}");
            return null;
        }
    }
}