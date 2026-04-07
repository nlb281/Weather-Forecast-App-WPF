using CommunityToolkit.Mvvm.ComponentModel;
using DotNetEnv;
using weatherApp.Services;

namespace weatherApp.ViewModels;

public partial class MainWindowViewModel
{
    private readonly GeocodingService _geocodingService;
    private readonly WeatherService _weatherService;
    private readonly WeatherRepository _repository;
    
    public MainWindowViewModel(
        GeocodingService geocodingService,
        WeatherService weatherService,
        WeatherRepository repository)
    {
        _geocodingService = geocodingService;
        _weatherService = weatherService;
        _repository = repository;
    }
}