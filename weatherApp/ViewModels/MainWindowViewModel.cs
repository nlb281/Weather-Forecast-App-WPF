using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DotNetEnv;
using weatherApp.Models;
using weatherApp.Services;

namespace weatherApp.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly GeocodingService _geocodingService;
    private readonly WeatherService _weatherService;
    private readonly WeatherRepository _repository;
    
    [ObservableProperty]
    private string cityName = string.Empty;
    
    [ObservableProperty]
    private double temperature;
    
    [ObservableProperty]
    private double feelsLike;
    
    [ObservableProperty]
    private double humidity;
    
    [ObservableProperty]
    private double pressure;
    
    [ObservableProperty]
    private double windSpeed;
    
    [ObservableProperty]
    private string condition = string.Empty;
    
    [ObservableProperty]
    private string weatherIcon = string.Empty;
    
    public MainWindowViewModel(
        GeocodingService geocodingService,
        WeatherService weatherService,
        WeatherRepository repository)
    {
        _geocodingService = geocodingService;
        _weatherService = weatherService;
        _repository = repository;

        CityName = _repository.GetLastCity();
        
        if (!string.IsNullOrWhiteSpace(CityName))
        {
            _ = SearchWeather();
        }
    }
    
    [RelayCommand]
    private async Task SearchWeather()
    {
        if (string.IsNullOrWhiteSpace(CityName))
        {
            return;
        }
    
        try
        {
            GeoapifyResponse? geoResponse = await _geocodingService.GetCoords(CityName);
        
            if (geoResponse?.Features == null || geoResponse.Features.Count == 0)
            {
                return;
            }
        
            double lon = geoResponse.Features[0].Properties.Longitude;
            double lat = geoResponse.Features[0].Properties.Latitude;
        
            WeatherResponse? weatherResponse = await _weatherService.GetWeatherByCoords(lat, lon);
    
            if (weatherResponse?.Fact != null)
            {
                Temperature = weatherResponse.Fact.Temperature;
                FeelsLike = weatherResponse.Fact.FeelsLike;
                Humidity = weatherResponse.Fact.Humidity;
                Pressure = weatherResponse.Fact.Pressure;
                WindSpeed = weatherResponse.Fact.WindSpeed;
                Condition = weatherResponse.Fact.Condition;
                WeatherIcon = weatherResponse.Fact.Icon;
                Console.WriteLine("Weather Found");  
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}